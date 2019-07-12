Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class BSG_RegisterMAC
    Const DEFAULT_MACADDRESS	  As String = "0-00"
	Dim   systemType			  As String = ""
	Dim	  databaseCPUSerialNumber As String = ""
    Dim   nextMAC				  As String = ""

	Dim myCmd As New SqlCommand("", myConn)

	Private Sub RegisterMAC_Load() Handles MyBase.Load
		sqlapi.BSG_GetNextMACAddress(myCmd, nextMAC)

		'If sqlapi.BSG_BelowHighestUsedMAC(myCmd, nextMAC) = True Then
		'	Dim answer As Integer = MessageBox.Show("You are working with a MAC Address that is below the highest used MAC Address." & vbCrLf &
		'											"Would you like to continue?", "Continue?", MessageBoxButtons.YesNo)
		'	If answer = DialogResult.No Then
		'		Close()
		'	End If
		'End If

		NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC

		If WorkingSystemSerialNumber <> "" Then
			SerialNumber.Text = WorkingSystemSerialNumber
			TB_IPAddress.Text = WorkingIP
		End If

		'Populate SystemType drop-down
		GetDropDownItems()
	End Sub

	Private Sub SerialNumber_LostFocus() Handles SerialNumber.LostFocus
		GetDropDownItems()
	End Sub

	Private Sub UpdateSystemMACButton_Click() Handles UpdateSystemMACButton.Click
		if UpdateMAC() = False Then
			Return
		End If

		TB_IPAddress.Text = ""
		SerialNumber.Text = ""
		TB_IPAddress.Focus()
		GetDropDownItems()
	End Sub

	Private Sub NextButton_Click() Handles NextButton.Click
		If UpdateMAC() = False Then
			Return
		End If

		WorkingSystemSerialNumber = ""
        WorkingIP = ""

		BSG_MenuMain.RegisterSystem_Button_Click()
		Close()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub RegisterMAC_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		If e.CloseReason = CloseReason.UserClosing Then
			WorkingIP = ""
			WorkingSystemSerialNumber = ""
		End If
	End Sub

	Private Function UpdateMAC() As Boolean
		Dim jsonapi As New JSON_API()
        Dim WResponse As String = ""
        Dim result As String = ""
        Dim MACAddress As String = ""
        Dim override As Boolean = False
        Dim useCurrent As Boolean = False
        Dim obj = Nothing
		Dim CPUBoardSerialNo As String = Boards_ComboBox.Text
        databaseCPUSerialNumber = ""

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

		'Check to see if there is a MAC address on the machine.
		If obj.macaddress = Nothing Then
			MsgBox("System did not return valid MAC Address, exiting")
			Return False
		End If

		'Check to see if the machines MAC is the default MAC Address.
		If String.Compare(obj.macaddress, BASE_MAC(CurrentIndex) & DEFAULT_MACADDRESS) <> 0 Then
			Dim answer As Integer = MessageBox.Show("This CPU does not have the default MAC Address [" & obj.macaddress.ToString & "]. Would you like to continue?", "Continue?", MessageBoxButtons.YesNo)
			If answer = DialogResult.No Then
				Return False
			End If
		End If

		' check to see if the system type in the database matches what the machine tells us.
        If sqlapi.BSG_CheckSystemType(myCmd, SerialNumber.Text, obj.model.ToString, result) <> True Then
            MsgBox(result)
            Return False
        End If

		' check to see if our CPU board already has been assigned a MAC Address.
		If sqlapi.BSG_GetMACAddress(myCmd, CPUBoardSerialNo, MACAddress, result) = True Then
			' give the user the option to use the MAC, Override MAC, or quit
			Dim foo As New CustomMessageBox("This CPU Board already has been assigned" & MACAddress & " as a MAC Address." & vbCrLf &
											"Would you like to use this MAC Address, use the next available MAC Address or Cancel?")
			foo.ShowDialog()

			Select Case foo.DialogResult
				Case DialogResult.Yes
					'This is where we want to use the current MAC Address assigned to the CPU.
					useCurrent = True
				Case DialogResult.No
					'This is where we want to use the Next available MAC Address.
					If LookForNextMACAddress(MACAddress) = False Then
						Return False
					End If
				Case DialogResult.Cancel
					'This is where we do not want to continue.
					Return False
			End Select
		Else
			' no MAC attached, look for the next available one
			If LookForNextMACAddress(MACAddress) = False Then
				Return False
			End If
		End If

		'Update the machine's MAC Address, Serial Number, and CPU Board Serial Number.
		If jsonapi.SetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, MACAddress, SerialNumber.Text, CPUBoardSerialNo, WResponse) = False Then
			Return False
		End If

		Try
			obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
		Catch
			MsgBox("Could not convert JSON result string")
			Return False
		End Try

		'Register the network and update the database entry.
		If sqlapi.BSG_RegisterNetwork(SerialNumber.Text, CPUBoardSerialNo, MACAddress, obj.macaddress, result) = False Then
			MsgBox(result)
			Return False
		End If
		
		'Check to see if we used the CPU's current MAC or if we used the next avaliable one.
		If useCurrent = False Then
			'Now bump the MAC address and save to the database.
			If sqlapi.BSG_UpdateNextMACAddress(myCmd, nextMAC, True, result) = False Then
				MsgBox(result)
				Return False
			End If
			NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC
		End If

		ReturnedSerialNo.Text = obj.serial
		
		jsonapi.RemoteReboot(TB_BaseIP.Text & TB_IPAddress.Text, WResponse)
		
        Return True
    End Function

    Private Function LookForNextMACAddress(ByRef MACAddress As String) As Boolean
        Dim result As String = ""
        Dim firstcheck As Boolean = true
		Dim CPUBoardSerialNo As String = Boards_ComboBox.Text

        Do
            ' check the database for the next MAC that we are using.
			If sqlapi.BSG_FindMACAddress(myCmd, NextMACAddress.Text, databaseCPUSerialNumber, result) = False Then
				If UseMACQustion(MACAddress) = False Then
                    Return False
                End If

				Exit Do
			End If

			'Check to see if the working MAC Address is assigned to the CPU that we are working with.
            If String.Equals(CPUBoardSerialNo, databaseCPUSerialNumber) = True Then
				If UseMACQustion(MACAddress) = False Then
                    Return False
                End If

				Exit Do
            End If

			'This is where the MAC Address has already been taken in the database.
            If firstcheck = True Then
                Dim retry As Integer = MessageBox.Show("Found " & NextMACAddress.Text & " assigned to CPU " & databaseCPUSerialNumber & " in the database." & vbCrLf & _
                                                        "Would you like to increase the MAC Address and retry?", "Retry?", MessageBoxButtons.YesNo)
                If retry = DialogResult.No Then
                    Return False
                End If

				firstcheck = False
            End If

            'Bump the MAC in the database and then assign it to the textbox.
            sqlapi.BSG_UpdateNextMACAddress(myCmd, nextMAC, True, result)
            NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC

        Loop

        Return True
    End Function

    Private Function UseMACQustion(ByRef MACAddress As String) As Boolean
        Dim answer As Integer = MessageBox.Show(NextMACAddress.Text & " is available." & vbCrLf & _
                                                "Would you like to use this MAC Address?", "Continue?", MessageBoxButtons.YesNo)
        If answer = DialogResult.No Then
            Return False
        Else
            MACAddress = NextMACAddress.Text
            Return True
        End If
    End Function

	Private sub GetDropDownItems()
        Dim dropDownItems = New List(Of DropDownItem)
		Dim myCmd As New SqlCommand("SELECT 
  s.[MotherBoard.boardid]
, b1.SerialNumber

, s.[MainCPU.boardid]
, b2.SerialNumber

, s.[Slot2.boardid]
, b3.SerialNumber

, s.[Slot3.boardid]
, b4.SerialNumber

, s.[Slot4.boardid]
, b5.SerialNumber
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