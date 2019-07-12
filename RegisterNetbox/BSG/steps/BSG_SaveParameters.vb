Imports System.Reflection

Public Class BSG_SaveParameters

	Dim OutputName As String
	Dim thisServerObj As Object
	Dim thisServerModel As String
	Dim ignoreParams() As String = {"cpuid", "serialno", "macaddr", "version"}

	Public Sub New(ByRef ServerObj As Object, ByRef model As String)
		InitializeComponent()
		thisServerObj = ServerObj
		thisServerModel = model
	End Sub

	Private Sub SaveParameters_Load() Handles MyBase.Load
		TB_Model.Text = thisServerModel

		Date_DTP.Value = Date.Now
	End Sub

	Private Sub B_Save_Click() Handles B_Save.Click
		If JSONFileName.Text.Length = 0 Or TB_Model.Text.Length = 0 Or TB_Version.Text.Length = 0 Or ParamDescription.Text.Length = 0 Then
			MsgBox("Please fill out all of the fields before saving the file.")
			Return
		End If

		Dim counter = 0
		Dim foundIgnore As Boolean = False

		Dim objWriter As New IO.StreamWriter(JSONFileName.Text)
		objWriter.WriteLine("#" & TB_Model.Text & "|" & Date_DTP.Text & "|" & TB_Version.Text & "|" & ParamDescription.Text)

		Dim fields As FieldInfo() = thisServerObj.GetType().GetFields
		objWriter.Write("{ ")

		For Each field In fields
			foundIgnore = False

			' check to see if this is a parameter that we do not need
			For i As Integer = 0 To ignoreParams.Length - 1
				If field.Name = ignoreParams(i) Then
					foundIgnore = True
					Exit For
				End If
			Next

			If foundIgnore Then
			    Continue For
			End If

			' check to see if we are not the first entry
			If counter <> 0 Then
				objWriter.Write(", ")
			End If
			counter += 1

			' check to see if we are a string
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