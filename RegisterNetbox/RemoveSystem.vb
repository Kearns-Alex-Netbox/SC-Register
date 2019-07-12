Imports System.Data.SqlClient

Public Class RemoveSystem
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Private Sub RemoveSystem_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub RemoveSystemButton_Click() Handles RemoveSystemButton.Click
		Dim result As String = ""
		If SystemSerialNumber.Text.Length <> 0 Then
			If sqlapi.RemoveSystem(myCmd, SystemSerialNumber.Text, result) = False Then
				MsgBox(result)
				Return
			End If
		Else
			MsgBox("System Serial Number needs to be filled in.")
			Return
		End If
		ResultStatus.Text = "System '" & SystemSerialNumber.Text & "' was removed from the database."
		SystemSerialNumber.Text = ""
		SystemSerialNumber.Focus()
	End Sub

	Private Sub CancelButton_Click() Handles Cancel_Button.Click
		Close()
	End Sub

End Class