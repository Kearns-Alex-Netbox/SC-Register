Imports System.Data.SqlClient

Public Class ExtraComponents
	Const ENTRIES_TO_SHOW As Integer = 10

	Dim myCmd As New SqlCommand("", myConn)

	Dim da As SqlDataAdapter
	Dim ds As DataSet
	Dim scrollVal As Integer
	Dim numberOfRecords As Integer

	Private Sub ExtraComponents_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		KeyPreview = True

		RetrieveData()
	End Sub

	Private Sub RetrieveData()
		Dim result As String = ""
		Try
			myCmd.CommandText = "SELECT COUNT(*) FROM ExtraComponents"
			numberOfRecords = myCmd.ExecuteScalar
			myCmd.CommandText = "SELECT Description, DateOfService, Qty FROM ExtraComponents ORDER BY Description"
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			scrollVal = 0
			da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")

			B_Previous.Enabled = False
			B_Next.Enabled = True

			DataGridView1.DataSource = ds.Tables(0)
			DataGridView1.Focus()

			DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_First_Click() Handles B_First.Click
		scrollVal = 0
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = False
		B_Next.Enabled = True
	End Sub

	Private Sub B_Previous_Click() Handles B_Previous.Click
		scrollVal = scrollVal - ENTRIES_TO_SHOW
		If scrollVal <= 0 Then
			scrollVal = 0
			B_Previous.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Next.Enabled = True
	End Sub

	Private Sub B_Next_Click() Handles B_Next.Click
		scrollVal = scrollVal + ENTRIES_TO_SHOW
		If scrollVal > numberOfRecords Then
			scrollVal = numberOfRecords - ENTRIES_TO_SHOW
			If scrollVal < 0 Then
				scrollVal = 0
			End If
			B_Next.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		'Check to see if we can keep scrolling or if we are at the end of the table.
		If scrollVal + ENTRIES_TO_SHOW >= numberOfRecords Then
			B_Next.Enabled = False
		End If
		DataGridView1.Focus()
		B_Previous.Enabled = True
	End Sub

	Private Sub B_Last_Click() Handles B_Last.Click
		scrollVal = numberOfRecords - ENTRIES_TO_SHOW
		If scrollVal < 0 Then
			scrollVal = 0
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = True
		B_Next.Enabled = False
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		If TB_Description.Text.Length <> 0 And TB_Quantity.Text.Length <> 0 And TB_Month.Text.Length <> 0 And
			TB_Day.Text.Length <> 0 And TB_Year.Text.Length <> 0 Then

			' test to see if we got a number for the quantity
			Try
				Dim intTest As Integer = TB_Quantity.Text
			Catch ex As Exception
				MsgBox("Please make sure the Quantity is a whole integer.")
				Return
			End Try

			' test to see if we have a valid date
			Try
				Dim intTest As Integer = TB_Month.Text

				' check to see if we have a valid month
				If intTest < 0 Or 12 < intTest Then
					MsgBox("Please use a valid Month.")
					Return
				End If

				intTest = TB_Day.Text

				' check to see if we have a valid day
				If intTest < 0 Or 31 < intTest Then
					MsgBox("Please use a valid Day.")
					Return
				End If

				intTest = TB_Year.Text

				' check to see if we have a valid year
				If intTest < 2010 Then
					MsgBox("Please use a valid Year.")
					Return
				End If

			Catch ex As Exception
				MsgBox("Please make sure the Date is a whole integer.")
				Return
			End Try

			' add all of them together to make our datatime format
			Dim dateOfService As String = TB_Year.Text & "-" & TB_Month.Text & "-" & TB_Day.Text

			' try inserting this new record into the database
			Try
				myCmd.CommandText = ("INSERT INTO ExtraComponents(id,Description,Qty,DateOfService,LastUpdate) 
									  VALUES(NEWID(), '" & TB_Description.Text & "','" & TB_Quantity.Text & "','" & dateOfService & "',GETDATE())")
				myCmd.ExecuteNonQuery()
				RetrieveData()
				TB_Result.Text = dateOfService & ": " & TB_Description.Text & " QTY:  " & TB_Quantity.Text

				TB_Description.Text = ""
				TB_Quantity.Text = ""
				TB_Day.Text = ""
				TB_Month.Text = ""
				TB_Year.Text = ""
			Catch ex As Exception
				TB_Result.Text = "Could not add Extra Component to the database." & ex.Message
			End Try
			TB_Description.Focus()
		Else
			MsgBox("Please fill in each textbox before trying to add a new Extra Component.")
		End If
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

End Class