Imports System.Data.SqlClient

Public Class BSG_AddBoard
	Dim myCmd As New SqlCommand("", myConn)
	Dim scanned As Integer = 0
	Dim lastboard As String = ""

	Private Sub AddBoard_Load() Handles MyBase.Load
		BoardSerialNumber.Focus()
	End Sub

	Private Sub SaveButton_Click() Handles SaveButton.Click
		Dim result As String = ""
		Dim startingSNO As String = BoardSerialNumber.Text
		Dim endingSNO As String = EndingSNO_TextBox.Text

		If startingSNO.Length = 0 Then
			MsgBox("Board Serial Number needs to be filled in.")
			Return
		End If

		' make both of them the same starting number to handle the for loop later if only one is being added
		' get the board SNO
		Dim startboard As String = startingSNO.Substring(0, startingSNO.IndexOf("-"))
		Dim endboard As String = startboard

		' get the board number
		Dim startingnumber As Integer = startingSNO.Substring(startingSNO.IndexOf("-") + 1)
		Dim endingnumber As Integer = startingnumber

		' get the number of digits required in the SNO
		Dim startNumDigits As Integer = startingSNO.Substring(startingSNO.IndexOf("-") + 1).Length
		Dim endNumDigits As Integer = startNumDigits

		Dim batchString As String = ""

		' check to see if we have an ending board
		If endingSNO.Length <> 0 Then
			' update the ending to what was set
			endingnumber = endingSNO.Substring(endingSNO.IndexOf("-") + 1)
			endboard = endingSNO.Substring(0, endingSNO.IndexOf("-"))
			endNumDigits = endingSNO.Substring(endingSNO.IndexOf("-") + 1).Length
			batchString = "BATCH: "
		End If

		' check to see if we are using the same board
		If startboard.Equals(endboard) = False Then
			MsgBox("Please use the same board type.")
			Return
		End If

		' check to see if the end is smaller than the start
		If endingnumber < startingnumber Then
			MsgBox("Starting Serial Number is larger than the ending Serial Number")
			Return
		End If

		' make sure we are rplacing the same number of digits
		If endNumDigits <> startNumDigits Then
			MsgBox("Please make the number of digits in the SNO the same.")
			Return
		End If

		Dim fullResult As String = ""

		' loop until we reach the last number
		While startingnumber <= endingnumber

			Dim currentBoardSNO As String = startboard & "-" & startingnumber.ToString("D" & startNumDigits)

			'Check to see if the serial number is in the database.
			If sqlapi.BSG_FindBoardSerialNumber(myCmd, currentBoardSNO, "") = True Then
				fullResult = fullResult & currentBoardSNO & " already added." & vbNewLine
				startingnumber += 1
				Continue While
			End If

			If sqlapi.BSG_AddBoard(myCmd, currentBoardSNO, result, False, CurrentRevision_TextBox.Text) = False Then
				fullResult = fullResult & "ERROR: " & result & vbNewLine
				startingnumber += 1
				Continue While
			End If

			If BoardComment.Text.Length <> 0 Then
				If sqlapi.BSG_AddBoardComment(myCmd, currentBoardSNO, batchString & BoardComment.Text, result) = False Then
					fullResult = fullResult & "ERROR: " & result & vbNewLine
					startingnumber += 1
				End If
			End If

			startingnumber += 1
			scanned += 1
		End While

		If fullResult.Length <> 0 Then
			ResultStatus.Text = "Some errors occured: " & vbNewLine & fullResult
		Else
			ResultStatus.Text = "All boards were added."
		End If

		L_Scanned.Text = "Scanned: " & scanned
		BoardSerialNumber.Text = ""
		EndingSNO_TextBox.Text = ""
		BoardComment.Text = ""

        'Set focus to system serial number again.
        BoardSerialNumber.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub BoardSerialNumber_LostFocus() Handles BoardSerialNumber.LostFocus
		Dim startingSNO As String = BoardSerialNumber.Text

		If startingSNO.Length = 0 Then
			Return
		End If

		Dim board As String = startingSNO.Substring(0, startingSNO.IndexOf("-"))

		' we only want to update if we are a different board
		If lastboard.Equals(board) = True Then
			Return
		End If

		myCmd.CommandText = "SELECT [HardwareVersion] FROM BoardType WHERE [BaseSerialNo] = '" & board & "'"

		Dim hardwareVersion As String = myCmd.ExecuteScalar

		CurrentRevision_TextBox.Text = hardwareVersion

		lastboard = board
	End Sub
End Class