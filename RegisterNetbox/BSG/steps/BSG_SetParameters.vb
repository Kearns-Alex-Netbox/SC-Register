Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json
Imports System.Reflection

Public Class BSG_SetParameters
	Const AQUA_REVIVAL As String = "Aqua Revival"

    Const SERVER_MODEL_INDEX As Integer = 0
    Const DATE_INDEX As Integer = 1
    Const VERSION_INDEX As Integer = 2
    Const DESCRIPTION_INDEX As Integer = 3

    Dim jsonapi As New JSON_API()
    Dim fileObj
	Dim controlerObj
    Dim ParamStrings(120) As String
    Dim cpuid As String
    Dim ThisSerialNo As String
    Dim ignoreID As Integer

	Dim myCmd As New SqlCommand("", myConn)

	Dim formLoaded As Boolean = False

	Private Sub SetParameters_Load() Handles MyBase.Load
		'Populate SystemType drop-down
		GetDropDownSystemType()

		formLoaded = True
		CB_SystemType.SelectedIndex = My.Settings.BSG_SPSystemType
	End Sub

	Sub GetDropDownSystemType()
        Dim dropDownItems = New List(Of DropDownItem)

		myCmd.CommandText = "SELECT 
* 
FROM dbo.SystemType 
WHERE name NOT LIKE '%Spare%' 
ORDER BY name"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count <> 0 Then
			For Each row As DataRow In dt_results.Rows
				dropDownItems.Add(New DropDownItem(row("ServerModel").ToString, row("name")))
			Next
		End If

		CB_SystemType.DataSource = dropDownItems
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200
		CB_SystemType.SelectedIndex = -1
    End Sub

	Private Sub CB_SystemType_SelectedIndexChanged() Handles CB_SystemType.SelectedIndexChanged
		If formLoaded = False Then
			Return
		End If

		My.Settings.BSG_SPSystemType = CB_SystemType.SelectedIndex
		My.Settings.Save()

		Results.Items.Clear()

		Select Case CB_SystemType.SelectedValue.ToString
			Case AQUA_REVIVAL
				If LoadDefinitions(CB_SystemType.SelectedValue.ToString) = False Then
					Return
				End If

			Case Else
				MsgBox("This program currently does not support setting parameters for this System Type.")
				Return
		End Select

		'Build list of JSON files and descriptions
		BuildListOfJSONFiles(CB_SystemType.SelectedValue.ToString)
		ButtonSetParam.Enabled = False
		SaveToFileButton.Enabled = False
	End Sub

	Private Function LoadDefinitions(byref serverModel As String) As Boolean
		If File.Exists(My.Settings.ParameterFolder & "\" & serverModel & " Parameter Definitions.txt") = False Then
			MsgBox(serverModel & " Parameter Definitions.txt was not found at:" & My.Settings.ParameterFolder)
			Return False
		End If

		Array.Clear(ParamStrings, 0, ParamStrings.Length)

		Select Case serverModel
			Case AQUA_REVIVAL
				ignoreID = 49

		End Select

		Dim fStream As New FileStream(My.Settings.ParameterFolder & "\" & serverModel & " Parameter Definitions.txt", FileMode.Open)
		Dim sReader As New StreamReader(fStream)
		Dim index As Integer = 1

		Do While sReader.Peek >= 0
			ParamStrings(index) = sReader.ReadLine
			index += 1
		Loop

		sReader.Close()
		fStream.Close()

		Return True
	End Function

	Private Sub JSONComboBox_SelectedIndexChanged() Handles JSONComboBox.SelectedIndexChanged
		ButtonSetParam.Enabled = False
		SaveToFileButton.Enabled = False
	End Sub

	Private Sub BuildListOfJSONFiles(ByRef systemType As String)
		Dim dropDownItems = New List(Of DropDownItem)
		
        Dim dirs As String() = Directory.GetFiles(My.Settings.ParameterFolder, "*.json")

        For Each dir As String In dirs
            Try
                Dim parsedHeader As String()
                Using sr As New StreamReader(dir)
                    dim line As string = sr.ReadLine()

					If line Is Nothing Then
						Continue For
					End If

                    parsedHeader = line.Split("|")

					' substring(1) to get rid of the "#"
					If parsedHeader(SERVER_MODEL_INDEX).Substring(1) <> systemType Then
						Continue For
					End If

                    ' If we have a comment line, it us used to list the readable string
                    If line.Substring(0, 1) = "#" Then
						dropDownItems.Add(New DropDownItem(dir, parsedHeader(VERSION_INDEX) & " - " & parsedHeader(DATE_INDEX) & " - " & parsedHeader(DESCRIPTION_INDEX)))
                    Else
						dropDownItems.Add(New DropDownItem(dir, dir))
                    End If	
                End Using
            Catch ex As Exception
                MsgBox("Could not read file: " + ex.ToString())
                Return
            End Try
        Next
		
		JSONComboBox.DataSource = dropDownItems
		JSONComboBox.DisplayMember = "Name"
		JSONComboBox.ValueMember = "ID"
		JSONComboBox.DropDownHeight = 200
		JSONComboBox.SelectedIndex = -1
    End Sub

	Private Sub ButtonGetParam_Click() Handles ButtonGetParam.Click
		Dim line As String = ""
		Dim passed As Boolean = True
		Dim FieldNo As Integer
		Dim rawServerJSON As String = ""

		If JSONComboBox.SelectedValue Is Nothing Then
			MsgBox("Please select Parameter file for comparison")
			Return
		End If

		' Open file and load up the parameter
		Using sr As New StreamReader(JSONComboBox.SelectedValue.ToString)
			' first line is the header
			line = sr.ReadLine()

			' second line is the JSON
			line = sr.ReadLine()
		End Using

		' Convert it from JSON into an internal object
		Try
			fileObj = JsonConvert.DeserializeObject(Of BSG_JSON_Results)(line)
		Catch ex As Exception
			MsgBox("Could not convert JSON result string: " + ex.ToString)
			Return
		End Try

		Results.Items.Add("Server: " + TB_BaseIP.Text & TB_IPAddress.Text)

		' Now get the parameters
		If jsonapi.GetRemoteParameters(TB_BaseIP.Text & TB_IPAddress.Text, rawServerJSON) = False Then
			MsgBox(rawServerJSON)
			Return
		End If

		Try
			controlerObj = JsonConvert.DeserializeObject(Of BSG_JSON_Results)(rawServerJSON)
		Catch ex As Exception
			MsgBox("Could not convert JSON result string: " + ex.ToString())
			Return
		End Try
			
		Dim fileFields As FieldInfo() = fileObj.GetType().GetFields
		Dim controlerFields As FieldInfo() = controlerObj.GetType().GetFields

		' grab the controler's cpuid and serialno
		cpuid = controlerObj.cpuid
		ThisSerialNo = controlerObj.serialno

		For Each currentFileField In fileFields
			' if our file JSON has a value of NOTHING for the same field then skip it (i.e. cpuid - our file will not have a value).
			If IsNothing(currentFileField.GetValue(fileObj)) Then
				Continue For
			End If

			' start with the entry not being found in our server JSON
			dim foundEntry As Boolean = False

			For Each currentControlerField In controlerFields

				If currentControlerField.Name.Substring(0, 1) = "p" And IsNumeric(currentControlerField.Name.Substring(1)) Then
					FieldNo = CInt(currentControlerField.Name.Substring(1))
				End If

				If currentFileField.Name <> currentControlerField.Name Then
					Continue For
				End If

				If currentControlerField.GetValue(controlerObj) = currentFileField.GetValue(fileObj) Or
				FieldNo = ignoreID then
					foundEntry = True
					Exit For
				End If

				' we did not match the vlaue. log it
				passed = False
				
				Results.Items.Add(String.Format("{0,-16} did not match (FILE: {1,-3} | IP: {2,-3})", currentControlerField.Name, currentFileField.GetValue(fileObj).ToString(), currentControlerField.GetValue(controlerObj).ToString()))

				' check to see if we are a p# so we can grab the purpose of the parameter
				If currentControlerField.Name.Substring(0, 1) = "p" And IsNumeric(currentControlerField.Name.Substring(1)) And FieldNo < ParamStrings.Length Then
					Results.Items.Add(String.Format("  Purpose: {0}", ParamStrings(FieldNo)))
				End If

				foundEntry = True
				Exit For
			Next

			If foundEntry = false Then
				Results.Items.Add("Did not find parameter: " + currentFileField.Name)
				passed = False
			End If
		Next

		If passed Then
			Results.Items.Add("  PASSED")
		End If

		ButtonSetParam.Enabled = True
		SaveToFileButton.Enabled = True
	End Sub

	Private Sub ButtonSetParam_Click() Handles ButtonSetParam.Click
		Dim WebResponse As String = ""
		Dim result As String = ""
		Dim obj = Nothing

		If jsonapi.GetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, WebResponse) = False Then
			MsgBox(WebResponse)
			Return
		End If

		Try
			obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WebResponse)
		Catch
			MsgBox("Could not convert JSON result string")
			Return
		End Try

		'Check to see if the system type in the Control matches the parameters that we want to set it witih.
		If String.Compare(obj.model.ToString, CB_SystemType.SelectedValue) <> 0 Then
			MsgBox("You cannot set the parameters of the controler type (" & obj.model.ToString & ") with the parameters of the controler type (" & CB_SystemType.SelectedText & ")")
			Return
		End If

		If jsonapi.SetParametersRequest(TB_BaseIP.Text & TB_IPAddress.Text, fileObj, cpuid, Results, WebResponse) Then
			If sqlapi.BSG_SetParameters(ThisSerialNo, JSONComboBox.SelectedValue.ToString, result) = False Then
				MsgBox(result)
			End If
		End If
	End Sub

	Private Sub ButtonClearList_Click() Handles ButtonClearList.Click
		Results.Items.Clear()
	End Sub

	Private Sub SaveToFileButton_Click() Handles SaveToFileButton.Click
		If controlerObj Is Nothing Then
			MsgBox("Must Get parameters from IP.")
			Return
		End If
		Dim BSG_DoSaveParameterForm = New BSG_SaveParameters(controlerObj, CB_SystemType.SelectedValue)
		BSG_DoSaveParameterForm.ShowDialog()
		BuildListOfJSONFiles(CB_SystemType.SelectedValue)
	End Sub

	Private Sub ButtonExit_Click() Handles ButtonExit.Click
		Close()
	End Sub

	

End Class

''''
'''' SHARED WITH THE ORIGINAL SET PARAMETERS DECLARATION
''''
'Public Class JSON_Set_Results
'    Public changed As Integer
'End Class

Public Class BSG_JSON_Results
	Public serialno As String
	Public cpuid As String
	Public tzone As Integer
	Public dst As UShort
	Public version As String
	Public macaddr As String
	Public deltap As UShort
	Public dptrigger As Single
	Public anpressureenable As UShort
	Public pressure As Single
	Public p1 As UShort
	Public p2 As UShort
	Public p3 As UShort
	Public p4 As UShort
	Public p5 As UShort
	Public p6 As UShort
	Public p7 As UShort
	Public p8 As UShort
	Public p9 As UShort
	Public p10 As UShort
	Public p11 As UShort
	Public p12 As UShort
	Public p13 As UShort
	Public p14 As UShort
	Public p15 As UShort
	Public p16 As UShort
	Public p17 As UShort
	Public p18 As UShort
	Public p19 As UShort
	Public p20 As UShort
	Public p21 As UShort
	Public p22 As UShort
	Public p23 As UShort
	Public p24 As UShort
	Public p25 As UShort
	Public p26 As UShort
	Public p27 As UShort
	Public p28 As UShort
	Public p29 As UShort
	Public p30 As UShort
	Public p31 As UShort
	Public p32 As UShort
	Public p33 As UShort
	Public p34 As UShort
	Public p35 As UShort
	Public p36 As UShort
	Public p37 As UShort
	Public p38 As UShort
	Public p39 As UShort
	Public p40 As UShort
	Public p41 As UShort
	Public p42 As UShort
	Public p43 As UShort
	Public p44 As UShort
	Public p45 As UShort
	Public p46 As UShort
	Public p47 As UShort
	Public p48 As UShort
	Public p49 As UShort
	Public p50 As UShort
	Public p51 As UShort
	Public p52 As UShort
	Public p53 As UShort
	Public p54 As UShort
	Public p55 As UShort
	Public p56 As UShort
	Public p57 As UShort
	Public p58 As UShort
	Public p59 As UShort
	Public p60 As UShort
End Class