Imports System.Data.SqlClient

Public Class SubAssemblyMB
	Dim myCmd As New SqlCommand("", myConn)
	Dim scanned As Integer = 0

	Private Sub SubAssemblyMB_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		BoardSerialNumber.Focus()
	End Sub

	Private Sub SaveButton_Click() Handles SaveButton.Click
		Dim result As String = ""
		Dim record As Guid = Nothing
		If BoardSerialNumber.Text.Length <> 0 Then
			If sqlapi.UpdateBoardStatus(myCmd, "Sub-Assembly", BoardSerialNumber.Text, result) = False Then
				MsgBox(result)
				Return
			End If
		Else
			MsgBox("Board Serial Number needs to be filled in.")
			Return
		End If

		ResultStatus.Text = "Changed " & BoardSerialNumber.Text & " status to Sub-Assembly."
		scanned += 1
		L_Scanned.Text = "Scanned: " & scanned
		BoardSerialNumber.Text = ""

		'Set focus to system serial number again.
		BoardSerialNumber.Focus()
	End Sub


	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class