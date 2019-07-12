Imports System.Data.SqlClient

Public Class ScrapConfirmation
	Const MOTHERBOARD As String = "MotherBoard"
	Const MAIN_CPU As String = "MainCPU"
	Const SLOT_2 As String = "Slot2"
	Const SLOT_3 As String = "Slot3"
	Const SLOT_4 As String = "Slot4"
	Const SLOT_5 As String = "Slot5"
	Const SLOT_6 As String = "Slot6"
	Const SLOT_7 As String = "Slot7"

	Dim myCmd As New SqlCommand("", myConn)
	Dim systemSNO As String = ""
	Dim myReader As SqlDataReader = Nothing

	Dim OriginalBoardlist As New List(Of String)

	Public Sub New(ByRef SNO As String)
		InitializeComponent()
		systemSNO = SNO
	End Sub

	Private Sub ScrapConfirmation_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		CenterToParent()

		SetInfo(systemSNO)
	End Sub

	Private Sub SetInfo(ByRef systemSerialNo As String)
		Dim result As String = ""
		Dim record As Guid = Nothing

		L_SytemSerialNumber.Text = systemSerialNo

		If sqlapi.FindSystemSerialNumber(myCmd, myReader,systemSerialNo, result) = True Then

			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, MOTHERBOARD, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, MotherboardSerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, MAIN_CPU, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot1SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_2, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot2SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_3, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot3SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_4, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot4SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_5, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot5SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_6, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot6SerialNumber.Text, result)
				End If
			End If
			If sqlapi.GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNo, SLOT_7, record, result) = True Then
				If record <> Guid.Empty Then
					sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot7SerialNumber.Text, result)
				End If
			End If

			' Create our Original List of Boards.
			OriginalBoardlist.Add(MotherboardSerialNumber.Text)
			OriginalBoardlist.Add(Slot1SerialNumber.Text)
			OriginalBoardlist.Add(Slot2SerialNumber.Text)
			OriginalBoardlist.Add(Slot3SerialNumber.Text)
			OriginalBoardlist.Add(Slot4SerialNumber.Text)
			OriginalBoardlist.Add(Slot5SerialNumber.Text)
			OriginalBoardlist.Add(Slot6SerialNumber.Text)
			OriginalBoardlist.Add(Slot7SerialNumber.Text)

		Else
			MsgBox("System Serial Number does not exist.")
		End If
	End Sub

	Private Sub B_Cancel_Click() Handles B_Cancel.Click
		DialogResult = DialogResult.No
		Close()
	End Sub

	Private Sub B_Scrap_Click() Handles B_Scrap.Click
		Dim FinalBoardlist As New List(Of String)

		' Create our final list of boards.
		FinalBoardlist.Add(MotherboardSerialNumber.Text)
		FinalBoardlist.Add(Slot1SerialNumber.Text)
		FinalBoardlist.Add(Slot2SerialNumber.Text)
		FinalBoardlist.Add(Slot3SerialNumber.Text)
		FinalBoardlist.Add(Slot4SerialNumber.Text)
		FinalBoardlist.Add(Slot5SerialNumber.Text)
		FinalBoardlist.Add(Slot6SerialNumber.Text)
		FinalBoardlist.Add(Slot7SerialNumber.Text)

		'Now loop through our list and make sure all of the boards exist in the database.
		'This should really only be checking the new text we added.
		Dim results As String = ""
		For Each board In FinalBoardlist
			If board.Length = 0 Then
				Continue For
			End If

			If sqlapi.FindBoardSerialNumber(myCmd, myReader, board, "") = False Then
				results = results & board & vbNewLine
			End If
		Next

		'Now check to see if we have boards that do not exist
		If results.Length <> 0 Then
			MsgBox("These boards are not found in the database:" & vbNewLine & results)
			Return
		End If

		Dim transaction As SqlTransaction = Nothing

		transaction = myConn.BeginTransaction("Swap")

		Try
			myCmd.Connection = myConn
			myCmd.Transaction = transaction

			' Handle any special swaps needed.
			If SpecialSwap(OriginalBoardlist, FinalBoardlist) = False Then
				Return
			End If

			transaction.Commit()
		Catch ex As Exception
			MsgBox(ex.Message)
			sqlapi.RollBack(transaction, "")
			Return
		End Try

		DialogResult = DialogResult.Yes
	End Sub

	Private Function SpecialSwap(ByRef oldBoards As List(Of String), ByRef newBoards As List(Of String)) As Boolean
		Dim sqlSlotSyntax() As String = {"[MotherBoard.boardid]", "[MainCPU.boardid]", "[Slot2.boardid]",
			"[Slot3.boardid]", "[Slot4.boardid]", "[Slot5.boardid]", "[Slot6.boardid]", "[Slot7.boardid]"}

		Dim currentIndex As Integer = 0

		Dim resultsTable As New DataTable
		Dim record As New Guid

		For Each oldboard In oldBoards
			If oldboard <> newBoards(currentIndex) Then
				'Begin with NULL so if we do not have a board to work with then it will still carry through and work.
				Dim oldGUID As String = "NULL"
				Dim oldSystemid As String = "NULL"
				Dim oldSerialNumber As String = "NULL"

				Dim newGUID As String = "NULL"
				Dim newSystemid As String = "NULL"
				Dim newSerialNumber As String = "NULL"


				If oldboard.Length <> 0 Then
					'Get the ID.
					sqlapi.GetBoardGUIDBySerialNumber(myCmd, myReader, oldboard, oldGUID, "")
					oldGUID = "'" & oldGUID & "'"

					'Get the system information.
					myCmd.CommandText = "SELECT systemid, SerialNumber FROM dbo.System WHERE " & sqlSlotSyntax(currentIndex) & " = " & oldGUID
					resultsTable.Clear()
					resultsTable.Load(myCmd.ExecuteReader)

					'Make sure we have found the board attached to a system. If not rollback and get out.
					If resultsTable.Rows.Count <> 0 Then
						oldSystemid = "'" & resultsTable(0)("systemid").ToString & "'"
						oldSerialNumber = resultsTable(0)("SerialNumber").ToString
					End If
				End If

				If newBoards(currentIndex).Length <> 0 Then
					'Get the ID.
					sqlapi.GetBoardGUIDBySerialNumber(myCmd, myReader, newBoards(currentIndex), newGUID, "")
					newGUID = "'" & newGUID & "'"

					'Get the system information.
					myCmd.CommandText = "SELECT systemid, SerialNumber FROM dbo.System WHERE " & sqlSlotSyntax(currentIndex) & " = " & newGUID
					resultsTable.Clear()
					resultsTable.Load(myCmd.ExecuteReader)

					'Make sure we have found the board attached to a system. If not rollback and get out.
					If resultsTable.Rows.Count <> 0 Then
						newSystemid = "'" & resultsTable(0)("systemid").ToString & "'"
						newSerialNumber = resultsTable(0)("SerialNumber").ToString
					End If
				End If

				'Comment the boards
				sqlapi.AddBoardComment(myCmd, oldboard, "Swapped with " & newBoards(currentIndex) & " into " & newSerialNumber, record, "")
				sqlapi.AddBoardComment(myCmd, newBoards(currentIndex), "Swapped with " & oldboard & " into " & oldSerialNumber, record, "")

				'Comment the system.
				sqlapi.AddSystemComment(myCmd, oldSerialNumber, "Swapped " & oldboard & " out with " & newBoards(currentIndex), record, "")
				sqlapi.AddSystemComment(myCmd, newSerialNumber, "Swapped " & newBoards(currentIndex) & " out with " & oldboard, record, "")

				'Set the locations to NULL before we set them to the new board IDs. Table constraint only lets one ID be in one record.
				myCmd.CommandText = "UPDATE System SET " & sqlSlotSyntax(currentIndex) & " = NULL WHERE systemid = " & oldSystemid
				myCmd.ExecuteNonQuery()

				myCmd.CommandText = "UPDATE System SET " & sqlSlotSyntax(currentIndex) & " = NULL WHERE systemid = " & newSystemid
				myCmd.ExecuteNonQuery()

				'Set the new board IDs into the new Systems.
				myCmd.CommandText = "UPDATE System SET " & sqlSlotSyntax(currentIndex) & " = " & newGUID & " WHERE systemid = " & oldSystemid
				myCmd.ExecuteNonQuery()

				myCmd.CommandText = "UPDATE System SET " & sqlSlotSyntax(currentIndex) & " = " & oldGUID & " WHERE systemid = " & newSystemid
				myCmd.ExecuteNonQuery()
			End If

			currentIndex += 1
		Next

		Return True
	End Function

End Class