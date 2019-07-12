Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json
Imports System.Reflection

Public Class SetParameters
    Const DEFENDER_4 As String = "Defender"
    Const DEFENDER_7 As String = "Defender7"
    Const ETS_7 As String = "ETS7"
    Const ODYSSEY_7 As String = "Sand7"
    Const VORTISAND_4 As String = "Vortisand"
    Const VORTISAND_7 As String = "Vortisand7"
    Const WA_2300 As String = "AquaMetrix 2300"

    Const SERVER_MODEL_INDEX As Integer = 0
    Const DATE_INDEX As Integer = 1
    Const VERSION_INDEX As Integer = 2
    Const DESCRIPTION_INDEX As Integer = 3

    Public thisServerObj

    Dim jsonapi As New JSON_API()
    Dim baseObj
    Dim ParamStrings(120) As String
    Dim cpuid As String
    Dim rawServerJSON As String = ""
    Dim ThisSerialNo As String
    Dim ignoreID As Integer

    Dim SelectedFilename As String
    Dim SelectedServerModel As String
    Dim SelectedVersion As String

    Dim JSONFileNames(30) As String
    Dim JSONDescriptions(30) As String
    Dim JSONVersions(30) As String

	Dim myCmd As New SqlCommand("", myConn)

	Dim formLoaded As Boolean = False

	Private Sub SetParameters_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		'Populate SystemType drop-down
		CB_SystemType.DataSource = GetDropDownItems()
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200

		formLoaded = True
		CB_SystemType.SelectedIndex = My.Settings.SPSystemType
	End Sub

	Private Sub CB_SystemType_SelectedValueChanged() Handles CB_SystemType.SelectedValueChanged
		If formLoaded = False Then
			Return
		End If

		SelectedServerModel = CB_SystemType.SelectedValue

		If formLoaded = True Then
			My.Settings.SPSystemType = CB_SystemType.SelectedIndex
			My.Settings.Save()
		End If

		Results.Items.Clear()
		JSONComboBox.Items.Clear()

		Select Case SelectedServerModel
			Case DEFENDER_4
				If LoadDefenderParameters() = False Then
					Return
				End If

			Case DEFENDER_7
				If LoadDefenderParameters() = False Then
					Return
				End If

			Case ODYSSEY_7
				If LoadOdysseyParameters() = False Then
					Return
				End If

			Case VORTISAND_4
				If LoadVortisandParameters() = False Then
					Return
				End If

			Case Else
				MsgBox("This program currently does not support setting parameters for this System Type.")
				Return
		End Select

		'Build list of JSON files and descriptions
		BuildListOfJSONFiles(My.Settings.ParameterFolder, SelectedServerModel)
		ButtonSetParam.Enabled = False
		SaveToFileButton.Enabled = False
	End Sub

	Private Function LoadDefenderParameters() As Boolean
		If File.Exists(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt") = False Then
			MsgBox(SelectedServerModel & " Parameter Definitions.txt was not found at:" & My.Settings.ParameterFolder)
			Return False
		End If

		Array.Clear(ParamStrings, 0, ParamStrings.Length)
		ignoreID = 49

		Dim fStream As New FileStream(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt", FileMode.Open)
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

	Private Function LoadOdysseyParameters() As Boolean
		If File.Exists(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt") = False Then
			MsgBox("Odyssey Parameter Definitions.txt was not found at:" & My.Settings.ParameterFolder)
			Return False
		End If

		Array.Clear(ParamStrings, 0, ParamStrings.Length)
		ignoreID = 4

		Dim fStream As New FileStream(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt", FileMode.Open)
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

	Private Function LoadVortisandParameters() As Boolean
		If File.Exists(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt") = False Then
			MsgBox("Vortisand Parameter Definitions.txt was not found at:" & My.Settings.ParameterFolder)
			Return False
		End If

		Array.Clear(ParamStrings, 0, ParamStrings.Length)
		ignoreID = 13

		Dim fStream As New FileStream(My.Settings.ParameterFolder & "\" & SelectedServerModel & " Parameter Definitions.txt", FileMode.Open)
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
		Dim index As Integer

		For index = 0 To JSONDescriptions.Length
			If Nothing = JSONDescriptions(index) Then
				Exit For
			End If
			If JSONComboBox.SelectedItem = JSONDescriptions(index) Then
				SelectedFilename = JSONFileNames(index)
				SelectedVersion = JSONVersions(index)
				Exit For
			End If
		Next
		ButtonSetParam.Enabled = False
		SaveToFileButton.Enabled = False
	End Sub

	Private Function BuildListOfJSONFiles(ByRef Path As String, ByRef systemType As String)
        Dim line As String
        Dim count As Integer = 0
        Dim dirs As String() = Directory.GetFiles(Path, "*.json")
        Dim dir As String

        Array.Clear(JSONFileNames, 0, JSONFileNames.Length)
        Array.Clear(JSONDescriptions, 0, JSONDescriptions.Length)

        For Each dir In dirs
            Try
                Dim parsedHeader As String()
                Using sr As New StreamReader(dir)
                    line = sr.ReadLine()
                    parsedHeader = line.Split(New Char() {"|"c})
                    If line IsNot Nothing Then
                        If String.Compare(parsedHeader(SERVER_MODEL_INDEX).Substring(1), systemType) = 0 Then
                            JSONFileNames(count) = dir

                            ' If we have a comment line, it us used to list the readable string
                            If line.Substring(0, 1) = "#" Then
                                JSONDescriptions(count) = parsedHeader(VERSION_INDEX) & "   " & parsedHeader(DATE_INDEX) & "   " & parsedHeader(DESCRIPTION_INDEX)
                                JSONVersions(count) = parsedHeader(VERSION_INDEX)
                            Else
                                JSONDescriptions(count) = dirs(count)
                            End If
                            count += 1
                        End If
                    End If
                End Using
            Catch exc As Exception
                MsgBox("Could not read file: " + exc.ToString())
                Return Nothing
            End Try
        Next

        For index = 0 To JSONDescriptions.Length
            If JSONDescriptions(index) Is Nothing Then
                Exit For
            End If
            JSONComboBox.Items.Add(JSONDescriptions(index))
        Next
        Return count
    End Function

	Private Sub ButtonGetParam_Click() Handles ButtonGetParam.Click
		Dim line As String = ""
		Dim passed As Boolean = True
		Dim FieldNo As Integer

		If SelectedFilename = Nothing Then
			MsgBox("Please select Parameter file for comparison")
			Return
		End If

		' Open file and load up the parameter
		Try
			While True
				Using sr As New StreamReader(SelectedFilename)
					While Not sr.EndOfStream
						line = sr.ReadLine()
						' If we have a comment line in the file, skip over it
						If line.Substring(0, 1) <> "#" Then
							Exit While
						End If
					End While
				End Using
				Exit While
			End While

		Catch exc As Exception
			MsgBox("Could not read file: " + exc.ToString())
			Return
		End Try

		' Convert it from JSON into an internal object
		Try
			baseObj = JsonConvert.DeserializeObject(Of JSON_Results)(line)
		Catch ex As Exception
			MsgBox("Could not convert JSON result string: " + ex.ToString)
			Return
		End Try
		If baseObj Is Nothing Then
			MsgBox("Could not convert JSON result string")
			Return
		End If

		Results.Items.Add("Server: " + TB_BaseIP.Text & TB_IPAddress.Text)

		' Get the serial # from the box, so we know who we're talking to
		If Not jsonapi.GetSerialNumberFromIP(TB_BaseIP.Text & TB_IPAddress.Text, ThisSerialNo) Then
			Return
		End If

		' Now get the parameters
		If jsonapi.GetRemoteParameters(TB_BaseIP.Text & TB_IPAddress.Text, rawServerJSON) Then
			Try
				thisServerObj = JsonConvert.DeserializeObject(Of JSON_Results)(rawServerJSON)
			Catch ex As Exception
				MsgBox("Could not convert JSON result string: " + ex.ToString())
				Return
			End Try
			If Not IsNothing(thisServerObj) Then
				Dim basetyp As Type = baseObj.GetType()
				Dim basefields As FieldInfo() = basetyp.GetFields
				Dim typ As Type = thisServerObj.GetType()
				Dim fields As FieldInfo() = typ.GetFields
				Dim foundEntry As Boolean = False

				cpuid = thisServerObj.cpuid

				For Each basefield In basefields
					If basefield.Name.Equals("value__") Then Continue For
					If IsNothing(basefield.GetValue(baseObj)) Then Continue For
					foundEntry = False

					For Each field In fields
						If field.Name.Equals("value__") Then Continue For
						If basefield.Name = field.Name Then
							If field.GetValue(thisServerObj) <> basefield.GetValue(baseObj) Then
								If field.Name.Substring(0, 1) = "p" And IsNumeric(field.Name.Substring(1)) Then
									FieldNo = CInt(field.Name.Substring(1))
								End If
								If FieldNo <> ignoreID Then
									passed = False
									Results.Items.Add("Parameter; " + field.Name + " value did not match (JSON FILE: " + basefield.GetValue(baseObj).ToString() + " IP SERVER: " + field.GetValue(thisServerObj).ToString() + ")")

									If field.Name.Substring(0, 1) = "p" And IsNumeric(field.Name.Substring(1)) Then
										If FieldNo < ParamStrings.Length Then
											Results.Items.Add("  Purpose: " + ParamStrings(FieldNo))
										End If
									End If
								End If
							End If
							foundEntry = True
							Exit For
						End If
					Next
					If Not foundEntry Then
						Results.Items.Add("Did not find parameter: " + basefield.Name)
						passed = False
						Exit For
					End If
				Next
			End If
		End If
		If passed Then
			Results.Items.Add("  PASSED")
		End If
		ButtonSetParam.Enabled = True
		SaveToFileButton.Enabled = True
	End Sub

	Private Sub ButtonSetParam_Click() Handles ButtonSetParam.Click
		Dim WResp As String = ""
		Dim result As String = ""
		Dim obj = Nothing

		If jsonapi.GetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, WResp) Then
			Try
				obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResp)
			Catch
				MsgBox("Could not convert JSON result string")
				Return
			End Try

			'Check to see if the system type in the Control matches the parameters that we want to set it witih.
			If String.Compare(obj.model.ToString, SelectedServerModel) <> 0 Then
				MsgBox("You cannot set the parameters of the controler type (" & obj.model.ToString & ") with the parameters of the controler type (" & SelectedServerModel & ")")
				Return
			End If
		End If

		If jsonapi.SetParametersRequest(TB_BaseIP.Text & TB_IPAddress.Text, baseObj, cpuid, Results, WResp) Then
			If sqlapi.SetParameters(myCmd, myConn, ThisSerialNo, SelectedFilename, result) = False Then
				MsgBox(result)
			End If
		End If
	End Sub

	Private Sub ButtonClearList_Click() Handles ButtonClearList.Click
		Results.Items.Clear()
	End Sub

	Private Sub SaveToFileButton_Click() Handles SaveToFileButton.Click
		If thisServerObj Is Nothing Then
			MsgBox("Must Get parameters from Netbox")
			Return
		End If
		Dim DoSaveParameterForm = New SaveParameters(thisServerObj, SelectedServerModel, SelectedVersion)
		DoSaveParameterForm.ShowDialog()
		BuildListOfJSONFiles(My.Settings.ParameterFolder, SelectedServerModel)
	End Sub

	Private Sub ButtonExit_Click() Handles ButtonExit.Click
		Close()
	End Sub

	Function GetDropDownItems() As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)
        Dim myReader As SqlDataReader = Nothing

        Try
            myCmd.CommandText = "SELECT * FROM dbo.SystemType ORDER BY name"
            myReader = myCmd.ExecuteReader()
            If myReader.HasRows = True Then
                While myReader.Read()
                    dropDownItems.Add(New DropDownItem(myReader("ServerModel").ToString, myReader("name")))
                End While
            End If
            myReader.Close()
        Catch ex As Exception
            If Not myReader Is Nothing Then
                myReader.Close()
            End If
            MsgBox(ex.Message)
        End Try
        Return dropDownItems
    End Function

End Class

Public Class JSON_Set_Results
    Public changed As Integer
End Class

Public Class JSON_Results
    Public serialno As String
    Public cpuid As String
    Public tzone As Integer
    Public dst As UShort
    Public version As String
    Public spiversion As String
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
    Public p61 As UShort
    Public p62 As UShort
    Public p63 As UShort
    Public p64 As UShort
    Public p65 As UShort
    Public p66 As UShort
    Public p67 As UShort
    Public p68 As UShort
    Public p69 As UShort
    Public p70 As UShort
    Public p81 As UShort
    Public p82 As UShort
    Public p83 As UShort
    Public p84 As UShort
    Public p85 As UShort
    Public p86 As UShort
    Public p87 As UShort
    Public p88 As UShort
    Public p89 As UShort
    Public p90 As UShort
    Public p91 As UShort
    Public p92 As UShort
    Public p93 As UShort
    Public p94 As UShort
    Public p95 As UShort
    Public p96 As UShort
    Public p97 As UShort
    Public p98 As UShort
    Public p99 As UShort
    Public p100 As UShort
    Public p101 As UShort
    Public p102 As UShort
    Public p103 As UShort
    Public p104 As UShort
    Public p105 As UShort
    Public p106 As UShort
    Public p107 As UShort
    Public p108 As UShort
    Public p109 As UShort
    Public p110 As UShort
    Public p111 As UShort
    Public p112 As UShort
    Public p113 As UShort
    Public p114 As UShort
    Public p115 As UShort
    Public p116 As UShort
    Public p117 As UShort
    Public p118 As UShort
    Public p119 As UShort
    Public p120 As UShort
End Class