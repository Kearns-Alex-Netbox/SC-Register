Imports System.Reflection
Imports System.Data.SqlClient

Public Class SaveParameters
	Dim myCmd As New SqlCommand("", myConn)

	Dim OutputName As String
	Dim thisServerObj As Object
	Dim thisServerModel As String
	Dim thisServerVersion As String
	Dim ignoreParams() As String = {"cpuid", "serialno", "macaddr", "version"}

	Public Sub New(ByRef ServerObj As Object, ByRef model As String, ByRef version As String)
		InitializeComponent()
		thisServerObj = ServerObj
		thisServerModel = model
		thisServerVersion = version
	End Sub

	Private Sub SaveParameters_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		TB_Model.Text = thisServerModel
		TB_Version.Text = thisServerVersion
	End Sub

	Private Sub B_Save_Click() Handles B_Save.Click
		If JSONFileName.Text.Length = 0 Or TB_Model.Text.Length = 0 Or TB_Date.Text.Length = 0 Or TB_Version.Text.Length = 0 Or ParamDescription.Text.Length = 0 Then
			MsgBox("Please fill out all of the fields before saving the file.")
			Return
		End If

		Dim counter = 0
		Dim foundIgnore As Boolean = False

		Dim objWriter As New IO.StreamWriter(JSONFileName.Text)
		objWriter.WriteLine("#" & TB_Model.Text & "|" & TB_Date.Text & "|" & TB_Version.Text & "|" & ParamDescription.Text)

		Dim typ As Type = thisServerObj.GetType()
		Dim fields As FieldInfo() = typ.GetFields
		objWriter.Write("{ ")

		For Each field In fields
			If field.Name.Equals("value__") Then Continue For
			foundIgnore = False

			For i As Integer = 0 To ignoreParams.Length - 1
				If field.Name = ignoreParams(i) Then
					foundIgnore = True
					Exit For
				End If
			Next
			If foundIgnore Then Continue For

			If counter <> 0 Then
				objWriter.Write(", ")
			End If
			counter += 1
			If field.FieldType.Name = "String" Then
				objWriter.Write("""" + field.Name + """" + ":" + """" + field.GetValue(thisServerObj) + """")
			Else
				objWriter.Write("""" + field.Name + """" + ":" + field.GetValue(thisServerObj).ToString())
			End If
		Next
		objWriter.WriteLine(" }")
		objWriter.Close()

		Close()
	End Sub

	Private Sub Cancel_Button_Click() Handles Cancel_Button.Click
		Close()
	End Sub

	Private Sub BrowseFile_Click() Handles BrowseFile.Click
		Dim fd As OpenFileDialog = New OpenFileDialog()

		'fd.CheckFileExists = False              ' Don't check if file already exists
		fd.Title = "Select Output JSON Filename"
		fd.InitialDirectory = My.Settings.ParameterFolder
		fd.Filter = "JSON files (*.json)|*.json"
		fd.FilterIndex = 2
		fd.RestoreDirectory = True

		If fd.ShowDialog() = DialogResult.OK Then
			OutputName = fd.FileName
			JSONFileName.Text = OutputName
		End If
	End Sub

End Class