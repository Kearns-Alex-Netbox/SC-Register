Imports System.Data.SqlClient

Public Class MenuMaintenance
	Dim myCmd As New SqlCommand("", myConn)

	Private Sub Maintenance_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub AddSystemCommentButton_Click() Handles AddSystemCommentButton.Click
		Dim DoAddSystemComment As New AddSystemComment()
		DoAddSystemComment.ShowDialog()
	End Sub

	Private Sub AddBoardCommentButton_Click() Handles AddBoardCommentButton.Click
		Dim DoAddBoardComment As New AddBoardComment()
		DoAddBoardComment.ShowDialog()
	End Sub

	Private Sub SwapBoardsButton_Click() Handles SwapBoardsButton.Click
		Dim DoSwapBoards As New SwapBoards
		DoSwapBoards.ShowDialog()
	End Sub

	Private Sub RemoveSystemButton_Click() Handles RemoveSystemButton.Click
		Dim DoRemoveSystem As New RemoveSystem
		DoRemoveSystem.ShowDialog()
	End Sub

	Private Sub RemoveBoard_Button_Click() Handles RemoveBoard_Button.Click
		Dim DoRemoveBoard As New RemoveBoard
		DoRemoveBoard.ShowDialog()
	End Sub

	Private Sub B_EmptyMACAddress_Click() Handles B_EmptyMACAddress.Click
		Dim DoEmptyMACAddress As New EmptyMACAddress
		DoEmptyMACAddress.ShowDialog()
	End Sub

	Private Sub B_AddSystemType_Click() Handles B_AddSystemType.Click
		Dim DoAddSystemType As New AddSystemType
		DoAddSystemType.ShowDialog()
	End Sub

	Private Sub B_EditSystemDefinition_Click() Handles B_EditSystemDefinition.Click
		Dim DoEditSystemDefinition As New EditSystemDefinition
		DoEditSystemDefinition.ShowDialog()
	End Sub

	Private Sub B_EditSystemSlots_Click() Handles B_EditSystemSlots.Click
		Dim DoEditSystemSlots As New EditSystemSlots
		DoEditSystemSlots.ShowDialog()
	End Sub

	Private Sub B_HardwareVersion_Click() Handles B_HardwareVersion.Click
		Dim DoHardwareVersion As New HardwareVersions
		DoHardwareVersion.ShowDialog()
	End Sub

	Private Sub B_SpareCPU_Click() Handles B_SpareCPU.Click
		Dim DoSpareCPU As New SpareCPU
		DoSpareCPU.ShowDialog()
	End Sub

	Private Sub PrintLabel_Button_Click() Handles PrintLabel_Button.Click
		Dim DoPrintLabel As New PrintLabels
		DoPrintLabel.ShowDialog()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	'Private Sub B_ExtraComponents_Click(sender As Object, e As EventArgs) Handles B_ExtraComponents.Click
	'	Dim DoExtraComponents As New ExtraComponents
	'	DoExtraComponents.ShowDialog()
	'End Sub

	'Private Sub B_SystemExtras_Click(sender As Object, e As EventArgs) Handles B_SystemExtras.Click
	'	Dim DoSystemExtras As New SystemExtras
	'	DoSystemExtras.ShowDialog()
	'End Sub
End Class