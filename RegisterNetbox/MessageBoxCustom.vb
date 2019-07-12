Public Class MessageBoxCustom

	Public Sub New(ByRef message As String, ByRef OneText As String, ByRef TwoText As String, ByRef ThreeText As String, ByRef FourText As String)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Message_RichTextBox.Text = message

		One_Button.Text = OneText

		If TwoText IsNot Nothing Then
			Two_Button.Text = TwoText
		Else
			Two_Button.Text = ""
			Two_Button.Enabled = False
			Two_Button.Visible = False
		End If

		If ThreeText IsNot Nothing Then
			Three_Button.Text = ThreeText
		Else
			Three_Button.Text = ""
			Three_Button.Enabled = False
			Three_Button.Visible = False
		End If

		If FourText IsNot Nothing Then
			Four_Button.Text = ThreeText
		Else
			Four_Button.Text = ""
			Four_Button.Enabled = False
			Four_Button.Visible = False
		End If
	End Sub

	Private Sub One_Button_Click() Handles One_Button.Click
		DialogResult = 1
	End Sub

	Private Sub Two_Button_Click() Handles Two_Button.Click
		DialogResult = 2
	End Sub

	Private Sub Three_Button_Click() Handles Three_Button.Click
		DialogResult = 3
	End Sub

	Private Sub Four_Button_Click() Handles Four_Button.Click
		DialogResult = 4
	End Sub

End Class