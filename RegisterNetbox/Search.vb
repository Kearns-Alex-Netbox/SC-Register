Imports System.Data.SqlClient
Imports System.IO

Public Class Search
	Const S_COMMAND As Integer = 0
	Const S_SYNTAX As Integer = 1
	Const S_COUNT As Integer = 2


	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim searchFileNames(50) As String
	Dim searchDescriptions(50) As String
	Dim boardSerialNumber As String = ""
	Dim systemSerialNumber As String = ""
	Dim boardGUID As String = ""
	Dim SelectedFilename As String = ""

	Private Sub Search_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		'Build list of Search files and descriptions
		BuildListOfSearchFiles(My.Settings.SearchFolder)
		For index = 0 To searchDescriptions.Length
			If searchDescriptions(index) Is Nothing Then
				Exit For
			End If
			CB_Reports.Items.Add(searchDescriptions(index))
		Next
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

	Private Sub B_SearchSerialNumber_Click() Handles B_SearchSerialNumber.Click
		Dim result As String = ""

		If TB_SerialNumber.Text.Length = 0 Then
			MsgBox("Serial Number must be filled in.")
			Return
		End If

		myCmd.CommandText = "SELECT systemid FROM system where SerialNumber = '" & TB_SerialNumber.Text &
				"' AND Instance = (Select MAX(instance) from system where SerialNumber = '" & TB_SerialNumber.Text & "')"

		Dim resultTable As New DataTable
		resultTable.Load(myCmd.ExecuteReader)

		If resultTable.Rows.Count <> 0 Then
			'The serial number we are looking for is a System. Open up the whole system information dialog.
			Dim DoViewSystemInfo As New ViewSystemInfo(resultTable.Rows(0)("systemid").ToString)
			DoViewSystemInfo.ShowDialog()
		Else
			'The serial number we are looking for is a Board.
			boardSerialNumber = TB_SerialNumber.Text
			If sqlapi.GetBoardGUIDBySerialNumber(myCmd, myReader, boardSerialNumber, boardGUID, result) = False Then
				MsgBox("Serial Number: " & TB_SerialNumber.Text & "Does not exist in the database.")
				Return
			End If

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
	End Sub

	Private Function BuildListOfSearchFiles(ByRef Path As String)
		Dim line As String
		Dim count As Integer = 0
		Dim dirs As String() = Directory.GetFiles(Path, "*.txt")
		Dim dir As String

		For Each dir In dirs
			Try
				Using sr As New StreamReader(dir)
					line = sr.ReadLine()
					If line IsNot Nothing Then
						searchFileNames(count) = dir

						' If we have a comment line, it us used to list the readable string
						If line.Substring(0, 1) = "#" Then
							searchDescriptions(count) = line.Substring(1)
						Else
							searchDescriptions(count) = dirs(count)
						End If
						count += 1
					End If
				End Using
			Catch exc As Exception
				MsgBox("Could not read file: " + exc.ToString())
				Return Nothing
			End Try
		Next
		Return count
	End Function

	Private Sub B_SearchReport_Click() Handles B_SearchReport.Click
		Dim command As String = ""
		Dim nameToSyntax As New List(Of String)
		Dim countCommand As String = ""

		Dim state As Integer = S_COMMAND
		Try
			Using sr As New StreamReader(SelectedFilename)
				Dim line As String = ""

				Do
					line = sr.ReadLine()
					If line Is Nothing Then
						Exit Do
					End If

					' if we hit a blank line then just continue
					If line.Length = 0 Then
						Continue Do
					End If

					Select Case line.Substring(0, 1)
						Case "#"

						Case ";"
							'Advance to the next state
							state += 1

						Case Else
							Select Case state
								Case S_COMMAND
									command = command & line & vbNewLine

								Case S_SYNTAX
									nameToSyntax.Add(line)

								Case S_COUNT
									countCommand = countCommand & line & vbNewLine

							End Select
					End Select
				Loop Until line Is Nothing
			End Using

		Catch exc As Exception
			MsgBox("Could not read file: " + exc.ToString())
			Return
		End Try

		Dim DoViewReportInfo As New ViewReportInfo(command, nameToSyntax, countCommand)
		DoViewReportInfo.Show()
	End Sub

	Private Sub CB_Reports_SelectedIndexChanged() Handles CB_Reports.SelectedIndexChanged
		Dim index As Integer
		For index = 0 To searchDescriptions.Length
			If Nothing = searchDescriptions(index) Then
				Exit For
			End If
			If CB_Reports.SelectedItem = searchDescriptions(index) Then
				SelectedFilename = searchFileNames(index)
				Exit For
			End If
		Next
	End Sub

End Class