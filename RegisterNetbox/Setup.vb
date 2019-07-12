Imports System.Data.SqlClient

Public Class Setup
	Dim myCmd As New SqlCommand("", myConn)
	Dim result As String = ""
	Dim myReader As SqlDataReader = Nothing

	Private Sub Setup_Load() Handles MyBase.Load
		L_Version.Text = "V:" & Application.ProductVersion & " " & CurrentDatabase
		Text &= "  (" & sqlapi._Username & ")"

		sqlapi.GetNextMACAddress(myCmd, myReader, NextMACAddress.Text)
		MACAddressBase.Text = BASE_MAC(CurrentIndex)
		ParameterFolder.Text = My.Settings.ParameterFolder
		TempFolder.Text = My.Settings.TempFolder
		SearchFolder.Text = My.Settings.SearchFolder
		Printer_TextBox.Text = My.Settings.ZebraPrinter
	End Sub

	Private Sub BrowseDirectoryParametersButton_Click() Handles BrowseDirectoryParametersButton.Click
		OpenFolderLocation(ParameterFolder.Text, "Select folder - Parameters", ParameterFolder.Text)
	End Sub

	Private Sub BrowseDirectoryTempButton_Click() Handles BrowseDirectoryTempButton.Click
		OpenFolderLocation(TempFolder.Text, "Select folder - Temp", TempFolder.Text)
	End Sub

	Private Sub BrowseDirectorySearchButton_Click() Handles BrowseDirectorySearchButton.Click
		OpenFolderLocation(SearchFolder.Text, "Select folder - Search Files", SearchFolder.Text)
	End Sub

	Private Sub Printer_Button_Click() Handles Printer_Button.Click
		'Set Printer
		Dim p As New PrintDialog
		p.UseEXDialog = True
		If p.ShowDialog <> DialogResult.OK Then
			Return
		End If

		Printer_TextBox.Text = p.PrinterSettings.PrinterName
	End Sub

	Private Sub B_Save_Click() Handles B_Save.Click
		If NextMACAddress.Text.Length = 0 Then
			MsgBox("MAC Address cannot be blank.")
			Return
		End If
		If ParameterFolder.Text.Length = 0 Or TempFolder.Text.Length = 0 Or SearchFolder.Text.Length = 0 Then
			MsgBox("All folders must be filled in.")
			Return
		End If

		My.Settings.ParameterFolder = ParameterFolder.Text
		My.Settings.TempFolder = TempFolder.Text
		My.Settings.SearchFolder = SearchFolder.Text
		My.Settings.ZebraPrinter = Printer_TextBox.Text
		My.Settings.Save()

		If sqlapi.UpdateNextMACAddress(myCmd, NextMACAddress.Text, False, result) = False Then
			MsgBox(result)
			Return
		End If

		Close()
	End Sub

	Private Sub B_Cancel_Click() Handles B_Cancel.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub OpenFolderLocation(ByVal root As String, ByVal windowTitle As String, ByRef finalLocation As String)
		' method: https://stackoverflow.com/questions/32370524/setting-root-folder-for-folderbrowser
		Using obj As New OpenFileDialog
			obj.Filter = "foldersOnly|*.none"
			obj.CheckFileExists = False
			obj.CheckPathExists = False
			obj.InitialDirectory = root
			obj.CustomPlaces.Add("\\Server1\EngineeringReleased\Utilities")
			obj.CustomPlaces.Add("C:")
			obj.Title = windowTitle
			obj.FileName = "OpenFldrPath"

			If obj.ShowDialog = Windows.Forms.DialogResult.OK Then
				finalLocation = IO.Directory.GetParent(obj.FileName).FullName
			End If
		End Using
	End Sub

End Class