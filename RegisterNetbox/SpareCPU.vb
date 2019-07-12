Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class SpareCPU
    Const DEFAULT_MACADDRESS As String = "70-b3-d5-85-20-00"

	Dim jsonapi As New JSON_API()
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim nextMAC As String = ""
    Dim unitNumber As Integer = 1
    Dim baseSerialNumber As String = ""
    Dim formLoaded As Boolean = False

	Private Sub SpareCPU_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		sqlapi.GetNextMACAddress(myCmd, myReader, nextMAC)

		'If sqlapi.BelowHighestUsedMAC(myCmd, myReader, nextMAC) = True Then
		'	Dim answer As Integer = MessageBox.Show("You are working with a MAC Address that is below the highest used MAC Address." & vbCrLf &
		'											"Would you like to continue?", "Continue?", MessageBoxButtons.YesNo)
		'	If answer = DialogResult.No Then
		'		Close()
		'	End If
		'End If

		NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC

		'Populate SystemType drop-down
		CB_SystemType.DataSource = GetDropDownItems()
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200

		formLoaded = True
		CB_SystemType_SelectedValueChanged()
		CPUSerialNumber.Focus()
	End Sub

	Private Sub CB_SystemType_SelectedValueChanged() Handles CB_SystemType.SelectedValueChanged
		If formLoaded = True Then
			Dim zerosString As String = ""
			Dim myReader As SqlDataReader = Nothing

			Try
				myCmd.CommandText = "SELECT * FROM dbo.SystemType WHERE name = '" & CB_SystemType.Text & "'"
				myReader = myCmd.ExecuteReader()
				If myReader.Read() Then
					baseSerialNumber = myReader("BaseSerialNumber")
				End If
				myReader.Close()

				myCmd.CommandText = "SELECT * FROM dbo.SystemParameters WHERE id = '" & baseSerialNumber & "'"
				myReader = myCmd.ExecuteReader()
				If myReader.Read() Then
					unitNumber = CInt(myReader("valuestring"))
				End If
				myReader.Close()

				If unitNumber < 10 Then
					zerosString = "0000"
				ElseIf unitNumber < 100 Then
					zerosString = "000"
				ElseIf unitNumber < 1000 Then
					zerosString = "00"
				ElseIf unitNumber < 10000 Then
					zerosString = "0"
				Else
					zerosString = ""
				End If
			Catch ex As Exception
				If Not myReader Is Nothing Then
					myReader.Close()
				End If
				MsgBox(ex.Message)
				Return
			End Try

			SystemSerialNumber.Text = baseSerialNumber & "-" & zerosString & unitNumber
			CPUSerialNumber.Focus()
		End If
	End Sub

	Private Sub UpdateCPUMACButton_Click() Handles UpdateCPUMACButton.Click
		UpdateMAC()
	End Sub

	Private Sub UpdateMAC()
        Dim WResponse As String = ""
        Dim result As String = ""
        Dim MACAddress As String = ""
        Dim systemType As String = ""
        Dim override As Boolean = False
        Dim useCurrent As Boolean = False
        Dim resultBoolean As Boolean = False
        Dim obj = Nothing
        Dim databaseCPUSerialNumber As String = CPUSerialNumber.Text

        'Check to see that we do not have our IP and Serial Number dialogs empty. Then check to see if we have the entry in our database.
        If TB_IPAddress.Text.Length = 0 Then
            MsgBox("Please specify IP Address to register")
            Return
        End If
        If CPUSerialNumber.Text.Length = 0 Then
            MsgBox("Please specify a CPU Serial number to register")
            Return
        Else
            'Check to make sure our board is in the database.
            If sqlapi.FindBoardSerialNumber(myCmd, myReader, databaseCPUSerialNumber, result) = False Then
                MsgBox(result)
                Return
            End If
        End If

		'Get the JSON from the remote server so we can see the current machine information.
		If jsonapi.GetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, WResponse) Then
			Cursor = Cursors.Default
			Try
				obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
			Catch
				MsgBox("Could not convert JSON result string")
				Return
			End Try

			'Check to see if there is a MAC address on the machine.
			If obj.macaddress = Nothing Then
				MsgBox("System did not return valid MAC Address, exiting")
				Return
			Else
				'Check to see if the machines MAC is the default MAC Address.
				If String.Compare(obj.macaddress, DEFAULT_MACADDRESS) <> 0 Then
					Dim answer As Integer = MessageBox.Show("This CPU does not have the default MAC Address. Would you like to continue?", "Continue?", MessageBoxButtons.YesNo)
					If answer = DialogResult.No Then
						Return
					End If
				End If
			End If

			'Check to see if our CPU board already has been assigned a MAC Address.
			If sqlapi.GetMACAddress(myCmd, myReader, databaseCPUSerialNumber, MACAddress, result) = True Then
				'This is where our board has a MAC Address in the database.
				'Give the user the option to Use the MAC, Override MAC, or quit
				Dim foo As New CustomMessageBox("This CPU Board already has been assigned" & MACAddress & " as a MAC Address." & vbCrLf &
												"Would you like to use this MAC Address, use the next available MAC Address or Cancel?")
				foo.ShowDialog()
				Dim test As Integer = foo.DialogResult

				Select Case test
					Case DialogResult.Yes
						'This is where we want to use the current MAC Address assigned to the CPU.
						useCurrent = True
					Case DialogResult.No
						'This is where we want to use the Next available MAC Address.
						If LookForNextMACAddress(MACAddress) = False Then
							Return
						End If
					Case DialogResult.Cancel
						'This is where we do not want to continue.
						Return
				End Select
			Else
				'This is where our board has no MAC Address in the database.
				If LookForNextMACAddress(MACAddress) = False Then
					Return
				End If
			End If
		Else
			Return
        End If

		'Update the machine's MAC Address, Serial Number, and CPU Board Serial Number.
		If jsonapi.SetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, MACAddress, SystemSerialNumber.Text, databaseCPUSerialNumber, WResponse) Then
			Try
				obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
			Catch
				MsgBox("Could not convert JSON result string")
				Return
			End Try

			If sqlapi.AddSpareCPU(myCmd, myConn, CB_SystemType.Text, SystemSerialNumber.Text, databaseCPUSerialNumber, result, obj, MACAddress, obj.macaddress) = False Then
				MsgBox(result)
				Return
			End If

			'Check to see if we used the CPU's current MAC or if we used the next avaliable one.
			If useCurrent = False Then
				'Now bump the MAC address and save to the database.
				If sqlapi.UpdateNextMACAddress(myCmd, nextMAC, True, result) = False Then
					MsgBox(result)
					Return
				End If
				NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC
			End If

			ReturnedSerialNo.Text = databaseCPUSerialNumber
			CPUSerialNumber.Text = ""
			'jsonapi.DoRemoteReboot(TB_BaseIP.Text & TB_IPAddress.Text, WResponse)

			'Update what ever unit number that we used.
			unitNumber += 1
			myCmd.CommandText = "UPDATE SystemParameters SET valuestring = " & unitNumber & " Where id = '" & baseSerialNumber & "'"
			myCmd.ExecuteNonQuery()

			'Make sure we update the system number that we are using as well for the next board.
			CB_SystemType_SelectedValueChanged()
		Else
			Cursor = Cursors.Default
            Return
        End If
        TB_IPAddress.Text = ""
        TB_IPAddress.Focus()
    End Sub

    Private Function LookForNextMACAddress(ByRef MACAddress As String) As Boolean
        Dim result As String = ""
        Dim CPUBoardSerialNo As String = ""
        Dim continueLookingForOpenMac As Boolean = False
        Do
            'Check the database for the next MAC that we are using.
            If sqlapi.FindMACAddress(myCmd, myReader, NextMACAddress.Text, CPUBoardSerialNo, result) = True Then

                'Check to see if the working MAC Address is assigned to the CPU that we are working with.
                If String.Equals(CPUSerialNumber.Text, CPUBoardSerialNo) = False Then
                    'This is where the MAC Address has already been taken in the database.
                    If continueLookingForOpenMac = False Then
                        Dim retry As Integer = MessageBox.Show("Found " & NextMACAddress.Text & " assigned to CPU " & CPUBoardSerialNo & " in the database." & vbCrLf & _
                                                               "Would you like to increase the MAC Address and retry?", "Retry?", MessageBoxButtons.YesNo)
                        If retry = DialogResult.No Then
                            Return False
                        Else
                            continueLookingForOpenMac = True
                        End If
                    End If

                    'Bump the MAC in the database and then assign it to the textbox.
                    sqlapi.UpdateNextMACAddress(myCmd, nextMAC, True, result)
                    NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC
                Else
                    If UseMACQustion(MACAddress) = False Then
                        Return False
                    Else
                        Exit Do
                    End If
                End If
            Else
                If UseMACQustion(MACAddress) = False Then
                    Return False
                Else
                    Exit Do
                End If
            End If
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

    Function GetDropDownItems() As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)
        Dim myReader As SqlDataReader = Nothing

        Try
            myCmd.CommandText = "SELECT * FROM dbo.SystemType WHERE name LIKE '%Spare%' ORDER BY name"
            myReader = myCmd.ExecuteReader()
            If myReader.HasRows = True Then
                While myReader.Read()
                    dropDownItems.Add(New DropDownItem(myReader("id").ToString, myReader("name")))
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

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class