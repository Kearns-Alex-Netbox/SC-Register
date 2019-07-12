Imports System.Data.SqlClient

Public Class RemoveBoard
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Private Sub RemoveBoard_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub RemoveBoardButton_Click() Handles RemoveBoardButton.Click
		Dim result As String = ""
		Dim record As String = ""

		If BoardSerialNumber.Text.Length = 0 Then
			MsgBox("System Serial Number needs to be filled in.")
			Return
		End If

		If sqlapi.FindBoardSerialNumber(myCmd, myReader, BoardSerialNumber.Text, result) = False Then
			MsgBox(result)
			Return
		End If

		If sqlapi.GetBoardGUIDBySerialNumber(myCmd, myReader, BoardSerialNumber.Text, record, result) = False Then
			MsgBox(result)
			Return
		End If

		myCmd.CommandText = "SELECT Instance, SerialNumber FROM dbo.System WHERE ([MotherBoard.boardid] = '" & record & "' OR [MainCPU.boardid] = '" & record &
			"' OR [Slot2.boardid] = '" & record & "' OR [Slot3.boardid] = '" & record & "' OR [Slot4.boardid] = '" & record &
			"' OR [Slot5.boardid] = '" & record & "' OR [Slot6.boardid] = '" & record & "' OR [Slot7.boardid] = '" & record & "')"

		Dim tableResults As New DataTable()
		tableResults.Load(myCmd.ExecuteReader)

		If tableResults.Rows.Count <> 0 Then
			For Each row In tableResults.Rows
				result = result & row(0) & " - " & row(1) & vbNewLine
			Next
			MsgBox("This board is part of these systems: " & vbNewLine & result)
			Return
		End If

		myCmd.CommandText = "DELETE FROM dbo.Board WHERE SerialNumber = '" & BoardSerialNumber.Text & "'"
		myCmd.ExecuteNonQuery()

		myCmd.CommandText = "DELETE FROM dbo.BoardAudit WHERE [dbo.Board.Boardid] = '" & record & "'"
		myCmd.ExecuteNonQuery()


		ResultStatus.Text = "Board '" & BoardSerialNumber.Text & "' was removed from the database."
		BoardSerialNumber.Text = ""
		BoardSerialNumber.Focus()

	End Sub

	Private Sub CancelButton_Click() Handles Cancel_Button.Click
		Close()
	End Sub

End Class