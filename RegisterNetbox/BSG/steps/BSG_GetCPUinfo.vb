Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class BSG_GetCPUinfo

	Dim systemType As String = ""

	Private Sub BSG_GetCPUinfo_Load() Handles MyBase.Load
		If WorkingSystemSerialNumber <> "" Then
			SerialNumber.Text = WorkingSystemSerialNumber
		End If

		'Populate SystemType drop-down
		GetDropDownItems()
		
	End Sub

	Private Sub SerialNumber_LostFocus() Handles SerialNumber.LostFocus
		GetDropDownItems()
	End Sub
	
	Private Sub UpdateCPU_Button_Click() Handles UpdateCPU_Button.Click
		if UpdateInformation() = False Then
			Return
		End If

		TB_IPAddress.Text = ""
		SerialNumber.Text = ""
		TB_IPAddress.Focus()
		GetDropDownItems()
	End Sub

	Private Sub NextButton_Click() Handles NextButton.Click
		If UpdateInformation() = False Then
			Return
		End If

		WorkingSystemSerialNumber = ReturnedSerialNo.Text
        WorkingIP = TB_IPAddress.Text

		BSG_MenuMain.RegisterMAC_Button_Click()
		Close()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub BSG_GetCPUinfo_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		If e.CloseReason = CloseReason.UserClosing Then
			WorkingIP = ""
			WorkingSystemSerialNumber = ""
		End If
	End Sub
	
	Private Function UpdateInformation() As Boolean
		Dim jsonapi As New JSON_API()
		Dim WResponse As String = ""
		Dim result As String = ""
		Dim obj = Nothing
		Dim CPUBoardSerialNo As String = Boards_ComboBox.Text
		'Dim CPUBoardID As String = Boards_ComboBox.SelectedValue
		Dim myCmd As New SqlCommand("", myConn)

		' check for our IP
		If TB_IPAddress.Text.Length = 0 Then
			MsgBox("Please specify IP Address to register")
			Return False
		End If

		' check for CPU board existince
		If Boards_ComboBox.SelectedValue = "" Then
			MsgBox("Please choose a board to update.")
			Return False
		End If

		' get the JSON from the remote server so we can see the current machine information.
        If jsonapi.GetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, WResponse) = false Then
			MsgBox("Could not get JSON information from the machine")
            Return False
        End If

		' try to convert JSON to our object
		Try
            obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
        Catch
            MsgBox("Could not convert JSON result string")
            Return False
        End Try

		' check to see if the system type in the database matches what the machine tells us.
        If sqlapi.BSG_CheckSystemType(myCmd, SerialNumber.Text, obj.model.ToString, result) <> True Then
            MsgBox(result)
            Return False
        End If

        ' update the CPU information
        ' this needs to be done first so we do not acidentally push the data to the box and it not work in the database
        If sqlapi.BSG_UpdateCPUInformation(myCmd, SerialNumber.Text, result, obj, CPUBoardSerialNo) = False Then
            MsgBox(result)  'might need to delete this message display
            Return False
        End If

        'Update the machine's MAC Address, Serial Number, and CPU Board Serial Number.
        If jsonapi.SetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, obj.macaddress, SerialNumber.Text, CPUBoardSerialNo, WResponse) = False Then
			Return False
		End If

		Try
            obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
        Catch
            MsgBox("Could not convert JSON result string")
            Return False
        End Try

        ReturnedSerialNo.Text = obj.serial

		myCmd.CommandText = "UPDATE SystemParameters SET [valuestring] = '" & Boards_ComboBox.SelectedIndex & "' WHERE [id] = '" & systemType & " CPU Index'"
		myCmd.ExecuteNonQuery

		Return True
	End Function

	Private sub GetDropDownItems()
        Dim dropDownItems = New List(Of DropDownItem)
		Dim myCmd As New SqlCommand("SELECT 
s.[MotherBoard.boardid]
,b1.SerialNumber

,s.[MainCPU.boardid]
,b2.SerialNumber

,s.[Slot2.boardid]
,b3.SerialNumber

,s.[Slot3.boardid]
,b4.SerialNumber

,s.[Slot4.boardid]
,b5.SerialNumber
FROM System s
LEFT JOIN Board b1 ON s.[MotherBoard.boardid] = b1.boardid
LEFT JOIN Board b2 ON s.[MainCPU.boardid] = b2.boardid
LEFT JOIN Board b3 ON s.[Slot2.boardid] = b3.boardid
LEFT JOIN Board b4 ON s.[Slot3.boardid] = b4.boardid
LEFT JOIN Board b5 ON s.[Slot4.boardid] = b5.boardid
WHERE s.SerialNumber = '" & SerialNumber.Text & "'
AND s.[dbo.SystemStatus.id] != (SELECT 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')", myConn)
		
		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		' check to see if we got data back
		If dt_results.Rows.Count <> 0 Then
			For index As Integer = 0 To dt_results.Columns.Count - 1 Step 2
				If dt_results.Rows(0).IsNull(index) = false Then
					dropDownItems.Add(New DropDownItem(dt_results.Rows(0)(index).ToString(), dt_results.Rows(0)(index + 1).ToString()))
				End If
			Next
		End If

		' set up our combo box
		Boards_ComboBox.DisplayMember = "Name"
		Boards_ComboBox.ValueMember = "ID"
		Boards_ComboBox.DropDownHeight = 200
		
		Boards_ComboBox.DataSource = dropDownItems

		Dim selectedIndex As Integer = -1

		myCmd.CommandText = "SELECT 
[ServerModel] 
FROM dbo.SystemType 
WHERE id = 
(SELECT 
[dbo.SystemType.id] 
FROM dbo.System 
WHERE SerialNumber = '" & SerialNumber.Text & "' 
AND [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped'))"

		dt_results = New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		' check to see if we got any results back
		If dt_results.Rows.Count = 0 Then
            systemType = ""
		Else
			systemType = dt_results.Rows(0)(0).ToString()
		End If

		myCmd.CommandText = "SELECT valuestring FROM SystemParameters WHERE [id] = '" & systemType & " CPU Index'"
		dt_results = New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count = 0 AND systemType.Length <> 0 Then
			myCmd.CommandText = "INSERT INTO SystemParameters([id], [valuestring]) VALUES('" & systemType & " CPU Index', '-1')"
			myCmd.ExecuteNonQuery
		ElseIf 1 <= dt_results.Rows.Count
			selectedIndex = dt_results.Rows(0)(0).ToString()
		End If

		Boards_ComboBox.SelectedIndex = selectedIndex
        Return
    End sub

End Class