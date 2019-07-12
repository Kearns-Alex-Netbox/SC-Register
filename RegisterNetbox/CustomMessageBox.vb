Public Class CustomMessageBox
    Dim message As String

    Public Sub New(ByRef messageString As String)
        message = messageString
        InitializeComponent()
    End Sub

	Private Sub CustomMessageBox_Load() Handles MyBase.Load
		TextBox1.Text = message
	End Sub

	Private Sub B_UseCurrent_Click() Handles B_UseCurrent.Click
		DialogResult = DialogResult.Yes
		Close()
	End Sub

	Private Sub B_UseNext_Click() Handles B_UseNext.Click
		DialogResult = DialogResult.No
		Close()
	End Sub

	Private Sub B_No_Click() Handles B_No.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

End Class