Imports System.Data.SqlClient
Public Class LabelCompare

	Dim myCmd As New SqlCommand("", myConn)

	Private Sub LabelCompare_Load() Handles MyBase.Load
		CenterToParent()
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub Label_TextBox_LostFocus() Handles Label_TextBox.LostFocus
		If Serial_TextBox.Text <> Label_TextBox.Text Then
			My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
			Info_Label.Text = "They do not match!"
		Else
			Dim mycmd As New SqlCommand("SELECT * FROM System WHERE SerialNumber = '" & Serial_TextBox.Text & "'", myConn)
			Dim results As New DataTable
			results.Load(mycmd.ExecuteReader)

			If results.Rows.Count <> 0 Then
				My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
				Info_Label.Text = "They do match!"
			Else
				My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
				Info_Label.Text = "The System Serial Number is not in the database."
			End If
		End If

		Serial_TextBox.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class