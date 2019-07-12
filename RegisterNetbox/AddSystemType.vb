Imports System.Data.SqlClient

Public Class AddSystemType
	Dim myCmd As New SqlCommand("", myConn)

	Private Sub AddSystemType_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		TB_SystemName.Focus()
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		Dim result As String = ""

		If TB_BaseSerialNumber.Text.Length = 0 Or TB_SystemName.Text.Length = 0 Or TB_ServerModel.Text.Length = 0 Then
			MsgBox("Please fill out all three text fields.")
			Return
		End If

		If sqlapi.FindSystemName(myCmd, TB_SystemName.Text) = True Then
			MsgBox("This system name is already in the database.")
			Return
		End If

		Dim answer As Integer = MessageBox.Show("Name:" & TB_SystemName.Text & vbCrLf &
												"Base Serial Number:" & TB_BaseSerialNumber.Text & vbCrLf &
												"Server Model:" & TB_ServerModel.Text & vbCrLf &
												"Would you like to add this System Type to the database?", "Add?", MessageBoxButtons.YesNo)
		If answer = DialogResult.No Then
			TB_Result.Text = "User decided not to add system type to the database."
			Return
		End If

		If sqlapi.AddSystemType(myCmd, TB_SystemName.Text, TB_BaseSerialNumber.Text, TB_ServerModel.Text, result) = False Then
			MsgBox(result)
			Return
		End If

		TB_Result.Text = TB_SystemName.Text & " was added to the database with a base serial number of " & TB_BaseSerialNumber.Text & " and a Server Model of " & TB_ServerModel.Text
		TB_BaseSerialNumber.Text = ""
		TB_SystemName.Text = ""
		TB_SystemName.Focus()
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

End Class