Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class ViewReportInfo
    Const MAX_SEARCH_HISTROY As Integer = 10

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim scrollVal As Integer
	Dim nameToSyntax As List(Of String)
	Dim command As String = ""
    Dim command2 As String = ""
    Dim entriesToShow As Integer = 25
    Dim numberOfRecords As Integer
    Dim direction As String = ""

    Dim searchCommand As String = ""
    Dim searchCommand2 As String = ""

    Dim cbHistory As New List(Of Integer)
    Dim tbHistory As New List(Of String)
    Dim searchIndex As Integer = 0

	Public Sub New(ByRef commandText As String, ByRef syntaxName As List(Of string), ByRef commandText2 As String)
		InitializeComponent()
		command = commandText
		nameToSyntax = syntaxName
		command2 = commandText2
	End Sub

	Private Sub ViewReportInfo_Load() Handles MyBase.Load
		Dim result As String = ""
		Text &= "  (" & sqlapi._Username & ")"

		Try
			sqlapi.GetNumberOfRecords(myCmd, myReader, command2, numberOfRecords, result)
			L_Results.Text = "Number of results: " & numberOfRecords

			myCmd.CommandText = command
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			RetrieveData()

			CB_Sort.DataSource = GetDropDownItems()
			CB_Sort.DisplayMember = "Name"
			CB_Sort.ValueMember = "ID"
			CB_Sort.DropDownHeight = 200

			CB_Search.DataSource = GetDropDownItems()
			CB_Search.DisplayMember = "Name"
			CB_Search.ValueMember = "ID"
			CB_Search.DropDownHeight = 200

			TabControl1.Focus()
			TabControl1.SelectedIndex = 0
			TB_Search.Select()

		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
		Try
			Dim result As String = ""
			Dim serialNumber As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
			Dim instanceNumber As String = ""
			Dim systemSerialNumber As String = ""
			Dim boardSerialNumber As String = ""
			Dim boardGUID As String = ""
			Dim originalCmdString As String = myCmd.CommandText

			Try
				instanceNumber = DataGridView1.Rows(e.RowIndex).Cells("#").Value.ToString
			Catch ex As Exception

			End Try

			myCmd.CommandText = "SELECT systemid FROM system where SerialNumber = '" & serialNumber & "' AND Instance = '" & instanceNumber & "'"

			Dim resultTable As New DataTable
			resultTable.Load(myCmd.ExecuteReader)

			If resultTable.Rows.Count <> 0 Then
				'The serial number we are looking for is a System. Open up the whole system information dialog.
				Dim DoViewSystemInfo As New ViewSystemInfo(resultTable.Rows(0)("systemid").ToString)
				DoViewSystemInfo.ShowDialog()
			Else
				'The serial number we are looking for is a Board.
				boardSerialNumber = serialNumber
				sqlapi.GetBoardGUIDBySerialNumber(myCmd, myReader, boardSerialNumber, boardGUID, result)

				'The next step is to find out if the board is part of a system or not.
				myCmd.CommandText = "SELECT SerialNumber, systemid FROM dbo.System WHERE ([MotherBoard.boardid] = '" & boardGUID & "' OR [MainCPU.boardid] = '" & boardGUID &
					"' OR [Slot2.boardid] = '" & boardGUID & "' OR [Slot3.boardid] = '" & boardGUID & "' OR [Slot4.boardid] = '" & boardGUID &
					"' OR [Slot5.boardid] = '" & boardGUID & "' OR [Slot6.boardid] = '" & boardGUID & "' OR [Slot7.boardid] = '" & boardGUID &
					"' OR [Slot8.boardid] = '" & boardGUID & "' OR [Slot9.boardid] = '" & boardGUID & "' OR [Slot10.boardid] = '" & boardGUID & "')"

				Dim checkSystem As New DataTable
				checkSystem.Load(myCmd.ExecuteReader)

				If checkSystem.Rows.Count <> 0 Then
					'The board is part of a system already. Open up the whole system information dialog.
					Dim DoViewSystemInfo As New ViewSystemInfo(checkSystem(0)("systemid").ToString)
					DoViewSystemInfo.ShowDialog()
				Else
					'The board is not part of a system. Open up the Board information dialog.
					Dim DoViewBoardInfo As New ViewBoardInfo(boardSerialNumber)
					DoViewBoardInfo.ShowDialog()
				End If
			End If

			'Set our command string back to the original string.
			myCmd.CommandText = originalCmdString
		Catch ex As Exception

		End Try
	End Sub

	Private Sub B_First_Click() Handles B_First.Click
		scrollVal = 0
		ds.Clear()
		da.Fill(ds, scrollVal, entriesToShow, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = False
		B_Next.Enabled = True
	End Sub

	Private Sub B_Previous_Click() Handles B_Previous.Click
		scrollVal = scrollVal - entriesToShow
		If scrollVal <= 0 Then
			scrollVal = 0
			B_Previous.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, entriesToShow, "TABLE")
		DataGridView1.Focus()
		B_Next.Enabled = True
	End Sub

	Private Sub B_Next_Click() Handles B_Next.Click
		scrollVal = scrollVal + entriesToShow
		If scrollVal > numberOfRecords Then
			scrollVal = numberOfRecords - entriesToShow
			If scrollVal < 0 Then
				scrollVal = 0
			End If
			B_Next.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, entriesToShow, "TABLE")
		'Check to see if we can keep scrolling or if we are at the end of the table.
		If scrollVal + entriesToShow >= numberOfRecords Then
			B_Next.Enabled = False
		End If
		DataGridView1.Focus()
		B_Previous.Enabled = True
	End Sub

	Private Sub B_Last_Click() Handles B_Last.Click
		scrollVal = numberOfRecords - entriesToShow
		If scrollVal < 0 Then
			scrollVal = 0
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, entriesToShow, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = True
		B_Next.Enabled = False
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

	Private Sub B_Refresh_Click() Handles B_Refresh.Click
		Dim result As String = ""
		Try
			searchCommand = ""
			searchCommand2 = ""
			sqlapi.GetNumberOfRecords(myCmd, myReader, command2, numberOfRecords, result)
			L_Results.Text = "Number of results: " & numberOfRecords

			ds.Clear()
			myCmd.CommandText = command
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			RetrieveData()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Search_Click() Handles B_Search.Click
		Dim result As String = ""
		Try
			searchCommand = command
			searchCommand2 = command2

			If command.Contains("WHERE") Then
				searchCommand = searchCommand & " AND " & CB_Search.SelectedValue & " LIKE '%" & TB_Search.Text & "%' ORDER BY " & nameToSyntax(0) & " ASC"
			Else
				searchCommand = searchCommand & " WHERE " & CB_Search.SelectedValue & " LIKE '%" & TB_Search.Text & "%' ORDER BY " & nameToSyntax(0) & " ASC"
			End If

			If command2.Contains("WHERE") Then
				searchCommand2 = searchCommand2 & " AND "
			Else
				searchCommand2 = searchCommand2 & " WHERE "
			End If

			sqlapi.GetNumberOfRecords(myCmd, myReader, searchCommand2 & CB_Search.SelectedValue & " LIKE '%" & TB_Search.Text & "%'", numberOfRecords, result)

			L_Results.Text = "Number of results: " & numberOfRecords

			myCmd.CommandText = searchCommand
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			If cbHistory.Count <> 0 Then
				If (cbHistory(cbHistory.Count - 1) = CB_Search.SelectedIndex And String.Compare(tbHistory(tbHistory.Count - 1), TB_Search.Text) = 0) = False Then
					If cbHistory.Count = MAX_SEARCH_HISTROY Then
						cbHistory.RemoveRange(0, 1)
						tbHistory.RemoveRange(0, 1)
					End If
					cbHistory.Add(CB_Search.SelectedIndex)
					tbHistory.Add(TB_Search.Text)
				End If
			Else
				cbHistory.Add(CB_Search.SelectedIndex)
				tbHistory.Add(TB_Search.Text)
			End If

			RetrieveData()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Sort_Click() Handles B_Sort.Click
		Try
			Dim newCommand As String = ""

			If String.Compare(searchCommand, "") = 0 Then
				newCommand = command
			Else
				newCommand = searchCommand
			End If

			If newCommand.Contains("ORDER BY") Then
				newCommand = newCommand.Substring(0, newCommand.IndexOf("ORDER BY ") + 9) & CB_Sort.SelectedValue   '9 is how long 'ORDER BY ' is
			Else
				newCommand = newCommand & " ORDER BY " & CB_Sort.SelectedValue
			End If

			If RB_AscendingSort.Checked Then
				newCommand = newCommand & " ASC"
			Else
				newCommand = newCommand & " DESC"
			End If

			myCmd.CommandText = newCommand
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			RetrieveData()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub RetrieveData()
        scrollVal = 0
        da.Fill(ds, scrollVal, entriesToShow, "TABLE")
        B_Previous.Enabled = False
        B_Forward.Enabled = False
        B_Next.Enabled = True
        If cbHistory.Count < 2 Then
            B_Back.Enabled = False
        Else
            searchIndex = cbHistory.Count - 1
            CB_Search.SelectedIndex = cbHistory(searchIndex)
            TB_Search.Text = tbHistory(searchIndex)
            B_Back.Enabled = True
        End If

        DataGridView1.DataSource = ds.Tables(0)
		DataGridView1.Focus()
		DataGridView1.Columns(0).Frozen = True

		For Each column In DataGridView1.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next column
    End Sub

	Private Sub B_Back_Click() Handles B_Back.Click
		If searchIndex <> 0 Then
			searchIndex -= 1
			CB_Search.SelectedIndex = cbHistory(searchIndex)
			TB_Search.Text = tbHistory(searchIndex)
			B_Forward.Enabled = True

			If searchIndex = 0 Then
				B_Back.Enabled = False
			End If
		End If
	End Sub

	Private Sub B_Forward_Click() Handles B_Forward.Click
		If searchIndex <> cbHistory.Count - 1 Then
			searchIndex += 1
			CB_Search.SelectedIndex = cbHistory(searchIndex)
			TB_Search.Text = tbHistory(searchIndex)
			B_Back.Enabled = True

			If searchIndex = cbHistory.Count - 1 Then
				B_Forward.Enabled = False
			End If
		End If
	End Sub

	Private Sub TB_Search_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TB_Search.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
			Call B_Search_Click()
		End If
    End Sub

	Private Sub CB_Display_SelectedValueChanged() Handles CB_Display.SelectedValueChanged
		entriesToShow = CInt(CB_Display.Text)
	End Sub

	Function GetDropDownItems() As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)
        Dim nameToSyntaxIndex = 0

        For Each dc As DataColumn In ds.Tables(0).Columns
            dropDownItems.Add(New DropDownItem(nameToSyntax(nameToSyntaxIndex), dc.ColumnName))
            nameToSyntaxIndex += 1
        Next

        Return dropDownItems
    End Function

	Private Sub B_CreateExcel_Click() Handles B_CreateExcel.Click
		Try
			Dim Temp_ds As New DataSet
			da.Fill(Temp_ds, "TABLE")

			Dim xlApp As New Excel.Application
			Dim xlWorkBook As Excel.Workbook
			Dim xlWorkSheet As Excel.Worksheet
			Dim misValue As Object = Reflection.Missing.Value
			Dim INDEX_row As Integer = 1
			Dim INDEX_column As Integer = 1

			xlWorkBook = xlApp.Workbooks.Add(misValue)
			xlWorkSheet = xlWorkBook.Sheets("sheet1")

			xlWorkSheet.PageSetup.CenterHeader = "Report   " & Date.Now

			For Each dc As DataColumn In Temp_ds.Tables(0).Columns
				xlWorkSheet.Cells(1, INDEX_column) = dc.ColumnName
				INDEX_column += 1
			Next

			INDEX_row += 1
			'Reset the Column index
			INDEX_column = 1

			For Each dr As DataRow In Temp_ds.Tables(0).Rows
				For Each dc As DataColumn In Temp_ds.Tables(0).Columns
					xlWorkSheet.Cells(INDEX_row, INDEX_column) = dr(dc).ToString
					INDEX_column += 1
				Next
				INDEX_row += 1
				'Reset the Column index
				INDEX_column = 1
			Next

			xlWorkSheet.Range("A1:X1").EntireColumn.AutoFit()
			xlWorkSheet.Range("A1").EntireRow.Font.Bold = True
			xlWorkSheet.Range("A1:X1").EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

			xlApp.DisplayAlerts = False
			xlApp.Visible = True

			releaseObject(xlWorkSheet)
			releaseObject(xlWorkBook)
			releaseObject(xlApp)
		Catch ex As Exception
			MsgBox("File was not written: " & ex.Message)
		End Try
	End Sub

	Private Sub releaseObject(ByVal obj As Object)
        Try
			Runtime.InteropServices.Marshal.ReleaseComObject(obj)
			obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class