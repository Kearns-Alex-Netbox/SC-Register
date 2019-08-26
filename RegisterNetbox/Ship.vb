Imports System.Data.SqlClient

Public Class Ship
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim runningTransaction As Boolean = False
	Dim skippedStepsSNOs As New List(Of String)
	Dim skippedSNOsDetails As New List(Of String)
	Dim totalQueue As Integer = 0

	Private Sub Ship_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		CB_ShipOption.DataSource = GetDropDownItems()
		CB_ShipOption.DisplayMember = "Name"
		CB_ShipOption.ValueMember = "ID"

		CB_ShipOption.SelectedIndex = CB_ShipOption.FindString("Shipped-Customer")

		Queue_Label.Text = "Queue " & totalQueue

		TextFile_Label.Text = TextFile_Label.Text & My.Settings.TempFolder & "\"

		Date_DTP.Value = Date.Now
	End Sub

	Private Sub UpdateButton_Click() Handles UpdateButton.Click
		runningTransaction = True
		SerialNo.Text = ""
		Log_RichTextBox.Clear()

		Dim updateAll As Boolean = False
		Dim blankList As New List(Of String)

		'Date logic checking
		Dim errorMessage As String = ""
		Dim infoDate As Date = Date_DTP.Value.Date
		Dim shipQuantity As Integer = Ship_NUD.Value

		Dim totalNumber = 1

		skippedStepsSNOs.Clear()
		skippedSNOsDetails.Clear()

		'we need to list them in order.
		Dim shipTable As New DataTable
		shipTable.Columns.Add("Serial Number")

		Dim rowNumber As Integer = 1
		For Each serialNumber In Queue_ListBox.Items
			If serialNumber <> Nothing Then
				If serialNumber.Length <> 0 Then
					shipTable.Rows.Add(serialNumber)
					rowNumber += 1
				End If
			End If
		Next

		'Deal with sorting the serial numbers into boxes and create the text file
		shipTable.DefaultView.Sort = "[Serial Number] ASC"
		shipTable = shipTable.DefaultView.ToTable

		For Each row As DataRow In shipTable.Rows
			Dim results As String = ""
			Dim record As Guid
			Dim registerDateTime As DateTime = Nothing
			Dim parameterDateTime As DateTime = Nothing
			Dim burnInDateTime As DateTime = Nothing
			Dim checkoutDateTime As DateTime = Nothing
			Dim addString As String = ""

			' check to see if we are working with a system or a board
			If sqlapi.FindSystemSerialNumber(myCmd, myReader,row("Serial Number"), results) Then

				sqlapi.GetSystemDate(myCmd, myReader, row("Serial Number"), "RegisterDate", registerDateTime, record, results)
				sqlapi.GetSystemDate(myCmd, myReader, row("Serial Number"), "ParameterDate", parameterDateTime, record, results)
				sqlapi.GetSystemDate(myCmd, myReader, row("Serial Number"), "BurnInDate", burnInDateTime, record, results)
				sqlapi.GetSystemDate(myCmd, myReader, row("Serial Number"), "CheckoutDate", checkoutDateTime, record, results)

				Dim systemType As String = ""
				sqlapi.GetSystemCurrentType(myCmd, myReader, row("Serial Number"), systemType, results)

				'First check to see if we did not get any dates.
				If registerDateTime = Nothing Then
					addString = addString & "MAC Address,  "
				End If

				If parameterDateTime = Nothing And systemType.Contains("2300") = False Then
					addString = addString & "Paramters,  "
				End If

				If burnInDateTime = Nothing Then
					addString = addString & "Burn In,  "
				End If

				If checkoutDateTime = Nothing Then
					addString = addString & "Check Out,  "
				End If

			End If

			If addString.Length <> 0 Then
				skippedStepsSNOs.Add(row("Serial Number"))
				skippedSNOsDetails.Add(addString)
			End If

			If totalNumber = shipQuantity Then
				Exit For
			Else
				totalNumber += 1
			End If
		Next

		If skippedStepsSNOs.Count <> 0 Then
			Dim alert As New MessageBoxCustom("Some of the Serial Numbers that were entered have skipped some steps. Would you like to continue with the ones that are ready?" _
												& vbNewLine _
												& vbNewLine & "1 - Continue with Good" _
												& vbNewLine & "2 - Continue with All" _
												& vbNewLine & "3 - Cancel", "1", "2", "3", Nothing)

			If alert.ShowDialog = 3 Then
				Return
			End If

			If alert.DialogResult = 2 Then
				updateAll = True
			ElseIf alert.DialogResult = 1 Then
				updateAll = False
			End If
		End If

		'Reset our total number scaned
		totalNumber = 1

		'Attempt to update the record in the database.
		For Each row As DataRow In shipTable.Rows
			Dim result As String = ""
			Dim override As Boolean = False
			Dim resultBoolean As Boolean = False

			If row("Serial Number") <> Nothing Then
				If row("Serial Number").Length <> 0 Then

					If updateAll = False Then
						resultBoolean = sqlapi.ShipAndInvoice(myCmd, myConn, row("Serial Number"), CB_ShipOption.SelectedValue, skippedStepsSNOs, result, infoDate)
					Else
						resultBoolean = sqlapi.ShipAndInvoice(myCmd, myConn, row("Serial Number"), CB_ShipOption.SelectedValue, blankList, result, infoDate)
					End If

					If resultBoolean = True Then
						Log_RichTextBox.AppendText("Shipped " & row("Serial Number") & " to: " & CB_ShipOption.SelectedValue & vbNewLine)
					Else
						Log_RichTextBox.AppendText("Failed " & row("Serial Number") & ": " & result & vbNewLine)
					End If
				End If
			End If

			If totalNumber = shipQuantity Then
				Exit For
			Else
				totalNumber += 1
			End If
		Next

		Dim detailsIndex As Integer = 0
		If skippedStepsSNOs.Count <> 0 Then
			Log_RichTextBox.AppendText(vbNewLine & vbNewLine & "SNO Skipped Steps Details:" & vbNewLine)

			For Each item In skippedStepsSNOs
				Log_RichTextBox.AppendText(item & vbNewLine & skippedSNOsDetails(detailsIndex) & vbNewLine)
				detailsIndex += 1
			Next
		End If

		Log_RichTextBox.AppendText("Done")
		Queue_ListBox.Items.Clear()
		runningTransaction = False
		SerialNo.Focus()
		totalQueue = 0
		Queue_Label.Text = "Queue " & totalQueue
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub SerialNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles SerialNo.LostFocus
		Dim result As String = ""
		Dim myReader As SqlDataReader = Nothing

		Try
			If runningTransaction <> True And SerialNo.Text.Length <> 0 And UpdateButton.Focused <> True Then
				'Check to see if our Text already is in our queue. **Not case sensitive**
				If Queue_ListBox.FindString(SerialNo.Text) = -1 Then
					If sqlapi.FindSystemSerialNumber(myCmd, myReader,SerialNo.Text, result) = False Then

						' check to see if we are using a board
						If sqlapi.FindBoardSerialNumber(myCmd, myReader, SerialNo.Text, result) = False Then
							My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
							MsgBox("Serial number: '" + SerialNo.Text + "' is not a valid system or board.")
							Return
						End If
					End If

					Queue_ListBox.Items.Add(SerialNo.Text)
					totalQueue += 1
					Queue_Label.Text = "Queue " & totalQueue
					Queue_ListBox.TopIndex = Queue_ListBox.Items.Count - 1
					SerialNo.Text = ""
					SerialNo.Focus()
				Else
					SerialNo.Text = ""
					SerialNo.Focus()
				End If
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Clear_Click() Handles B_Clear.Click
		Log_RichTextBox.Clear()
	End Sub

	Function GetDropDownItems() As List(Of DropDownItem)
		Dim dropDownItems = New List(Of DropDownItem)
		Dim myReader As SqlDataReader = Nothing

		Try
			myCmd.CommandText = "SELECT * from dbo.SystemStatus"
			myReader = myCmd.ExecuteReader()
			If myReader.HasRows = True Then
				While myReader.Read()
					If String.Compare(myReader("name").Substring(0, 4), "Ship") = 0 Then
						dropDownItems.Add(New DropDownItem(myReader("name"), myReader("name")))
					End If
				End While
			End If
			myReader.Close()
		Catch ex As Exception
			If Not myReader Is Nothing Then
				myReader.Close()
			End If
			MsgBox(ex.Message)
		End Try
		Return dropDownItems
	End Function

	Private Sub B_ClearQueue_Click() Handles B_ClearQueue.Click
		Queue_ListBox.Items.Clear()
	End Sub

	Private Sub PreShip_Button_Click() Handles PreShip_Button.Click
		'Date logic checking
		Dim errorMessage As String = ""
		Dim perBox As Integer = PerBox_NUD.Value
		
		Dim shipTable As New DataTable
		shipTable.Columns.Add("#", GetType(Integer))
		shipTable.Columns.Add("Serial Number")
		shipTable.Columns.Add("Box", GetType(Integer))

		Dim rowNumber As Integer = 1
		For Each serialNumber In Queue_ListBox.Items
			If serialNumber <> Nothing Then
				If serialNumber.Length <> 0 Then
					shipTable.Rows.Add(rowNumber, serialNumber, 0)
					rowNumber += 1
				End If
			End If
		Next

		'Deal with sorting the serial numbers into boxes and create the text file
		shipTable.DefaultView.Sort = "[Serial Number] ASC"
		shipTable = shipTable.DefaultView.ToTable

		Dim boxNumber As Integer = 1
		Dim controlerNumber As Integer = 1
		For Each row As DataRow In shipTable.Rows
			row("Box") = boxNumber

			If controlerNumber = perBox Then
				boxNumber += 1
				controlerNumber = 1
			Else
				controlerNumber += 1
			End If
		Next

		if PrintShipText(shipTable) = False Then
			return
		End If

		'Only print labels and ship text if this is checked.
		If Print_CheckBox.Checked = True Then
			PrintLabel(CInt(Ship_NUD.Value), shipTable)
		End If

		shipTable.DefaultView.Sort = "[#] ASC"
		shipTable = shipTable.DefaultView.ToTable

		shipTable.Columns().Remove("#")

		Boxes_DataGridView.DataSource = shipTable
	End Sub

	Private function PrintShipText(byref shipTable As DataTable) As boolean
		Dim shipQuantity As Integer = Ship_NUD.Value
		Dim perBox As Integer = PerBox_NUD.Value

		If totalQueue < shipQuantity Then
			MsgBox("Please scan enough to meet your ship quantity.")
			Return false
		End If

		' have to replace the '\' in the date time picker to not confuse with directory levels.
		Dim fileName As String = My.Settings.TempFolder & "\" & Date_DTP.Text.Replace("\", "-").Replace("/", "-") & " Shipment.txt"

		Dim numberCompleted As Integer = 0

		Using writer As New IO.StreamWriter(fileName, False)
			writer.WriteLine(shipQuantity & " PCs")
			writer.WriteLine()

			'Calculate how many boxes are needed and what is remaining. This is based on the number that we want to ship.
			dim boxNumber = shipQuantity \ perBox
			Dim remaining As Integer = shipQuantity - (boxNumber * perBox)

			If remaining <> 0 Then
				boxNumber += 1
			End If


			For i As Integer = 1 To boxNumber
				writer.Write("Box " & i & " 23x23x9 - ")

				If i = boxNumber And remaining <> 0 Then
					Dim weigth As Double = 3.3 * (remaining)
					writer.Write(weigth & " lbs" & vbNewLine)
				Else
					writer.Write("20 lbs" & vbNewLine)
				End If
			Next

			writer.WriteLine()

			Dim serialString As String = ""
			boxNumber = 1
			dim controlerNumber = 1
			Dim totalNumber As Integer = 1
			For Each row As DataRow In shipTable.Rows
				serialString = serialString & row("Serial Number") & ", "

				If controlerNumber = perBox Then
					writer.WriteLine("Box " & boxNumber & " " & serialString.Substring(0, serialString.Length - 2))
					serialString = ""
					boxNumber += 1
					controlerNumber = 1
				Else
					controlerNumber += 1
				End If

				If totalNumber = shipQuantity Then
					Exit For
				Else
					totalNumber += 1
				End If
			Next

			If serialString.Length <> 0 Then
				writer.WriteLine("Box " & boxNumber & " " & serialString.Substring(0, serialString.Length - 2))
			End If
		End Using

		Return True
	End function

	Private sub PrintLabel(byref shipQuantity As Integer, byref shipTable As DataTable)
		Dim totalNumber = 1
		If PrintLabels.CheckPrinter(My.Settings.ZebraPrinter) = False Then
			Return
		End If

		'delete the temp labels in order before re-ordering the table.
		For Each row As DataRow In shipTable.Rows
			If PrintLabels.PrintLabels(row("Serial Number"), 1, myCmd, My.Settings.ZebraPrinter) = False Then
				Exit For
			End If


			If totalNumber = shipQuantity Then
				Exit For
			Else
				totalNumber += 1
			End If

			'Continue to try to delete the file once we are done with it
			Dim deleted = False
			While deleted = False
				Try
					If IO.File.Exists(My.Settings.TempFolder & "\" & row("Serial Number") & ".prn") Then
						IO.File.Delete(My.Settings.TempFolder & "\" & row("Serial Number") & ".prn")
					End If
					deleted = True
				Catch ex As Exception

				End Try
			End While
		Next
	End sub

End Class