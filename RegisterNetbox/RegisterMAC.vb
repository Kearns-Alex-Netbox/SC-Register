﻿Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class RegisterMAC
    Const DEFAULT_MACADDRESS As String = "70-b3-d5-85-20-00"

	Dim jsonapi As New JSON_API()
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim CPUBoardSerialNo As String = ""
    Dim databaseCPUSerialNumber As String = ""
    Dim nextMAC As String = ""

	Private Sub RegisterMAC_Load() Handles MyBase.Load
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
		If WorkingSystemSerialNumber <> "" Then
			SerialNumber.Text = WorkingSystemSerialNumber
			TB_IPAddress.Text = WorkingIP
		End If
	End Sub

	Private Sub RegisterMAC_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		If e.CloseReason = CloseReason.UserClosing Then
			WorkingIP = ""
			WorkingSystemSerialNumber = ""
		End If
	End Sub

	Private Sub UpdateSystemMACButton_Click() Handles UpdateSystemMACButton.Click
		UpdateMAC()
	End Sub

	Private Function UpdateMAC() As Boolean
        Dim WResponse As String = ""
        Dim result As String = ""
        Dim MACAddress As String = ""
        Dim systemType As String = ""
        Dim override As Boolean = False
        Dim useCurrent As Boolean = False
        Dim resultBoolean As Boolean = False
        Dim obj = Nothing
        databaseCPUSerialNumber = ""

        'Check to see that we do not have our IP and Serial Number dialogs empty. Then check to see if we have the entry in our database.
        If TB_IPAddress.Text.Length = 0 Then
            MsgBox("Please specify IP Address to register")
            Return False
        End If
        If SerialNumber.Text.Length = 0 Then
            MsgBox("Please specify a Serial number to register")
            Return False
        Else
            'Check to make sure out system is in the database.
            If sqlapi.FindSystemSerialNumber(myCmd, myReader, SerialNumber.Text, result) = False Then
                MsgBox(result)
                Return False
            End If
        End If

		'Get the JSON from the remote server so we can see the current machine information.
		If jsonapi.GetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, WResponse) Then
			Cursor = Cursors.Default
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
			Else
				'Check to see if the machines MAC is the default MAC Address.
				If String.Compare(obj.macaddress, DEFAULT_MACADDRESS) <> 0 Then
					Dim answer As Integer = MessageBox.Show("This CPU does not have the default MAC Address [" & obj.macaddress.ToString & "]. Would you like to continue?", "Continue?", MessageBoxButtons.YesNo)
					If answer = DialogResult.No Then
						Return False
					End If
				End If
			End If

			'Check to see if the system type in the database matches what the machine tells us.
			If sqlapi.CheckSystemType(myCmd, myReader, SerialNumber.Text, obj.model.ToString, result) <> True Then
				MsgBox(result)
				Return False
			End If

			'Grab the CPU Board serial number from the System serial number.
			If sqlapi.GetCPUSerialNumberBySystemSerialNumber(myCmd, myReader, SerialNumber.Text, CPUBoardSerialNo, result) = True Then
				'Check to see if our CPU board already has been assigned a MAC Address.
				If sqlapi.GetMACAddress(myCmd, myReader, CPUBoardSerialNo, MACAddress, result) = True Then
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
								Return False
							End If
						Case DialogResult.Cancel
							'This is where we do not want to continue.
							Return False
					End Select
				Else
					'This is where our board has no MAC Address in the database.
					If LookForNextMACAddress(MACAddress) = False Then
						Return False
					End If
				End If
			End If
		Else
			Return False
        End If

		'Update the machine's MAC Address, Serial Number, and CPU Board Serial Number.
		If jsonapi.SetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, MACAddress, SerialNumber.Text, CPUBoardSerialNo, WResponse) Then
			Try
				obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
			Catch
				MsgBox("Could not convert JSON result string")
				Return False
			End Try

			'Register the network and update the database entry.
			resultBoolean = sqlapi.RegisterNetwork(myCmd, myConn, SerialNumber.Text, CPUBoardSerialNo, MACAddress, obj.macaddress, result, override)

			If resultBoolean = False Then
				MsgBox(result)
				Return False
			Else
				'Check to see if we used the CPU's current MAC or if we used the next avaliable one.
				If useCurrent = False Then
					'Now bump the MAC address and save to the database.
					If sqlapi.UpdateNextMACAddress(myCmd, nextMAC, True, result) = False Then
						MsgBox(result)
						Return False
					End If
					NextMACAddress.Text = BASE_MAC(CurrentIndex) + nextMAC
				End If

				ReturnedSerialNo.Text = SerialNumber.Text
				SerialNumber.Text = ""
				jsonapi.RemoteReboot(TB_BaseIP.Text & TB_IPAddress.Text, WResponse)
			End If
		Else
			Cursor = Cursors.Default
            Return False
        End If
        TB_IPAddress.Text = ""
        TB_IPAddress.Focus()
        Return True
    End Function

    Private Function LookForNextMACAddress(ByRef MACAddress As String) As Boolean
        Dim result As String = ""
        Dim continueLookingForOpenMac As Boolean = False
        Do
            'Check the database for the next MAC that we are using.
            If sqlapi.FindMACAddress(myCmd, myReader, NextMACAddress.Text, databaseCPUSerialNumber, result) = True Then

                'Check to see if the working MAC Address is assigned to the CPU that we are working with.
                If String.Equals(CPUBoardSerialNo, databaseCPUSerialNumber) = False Then
                    'This is where the MAC Address has already been taken in the database.
                    If continueLookingForOpenMac = False Then
                        Dim retry As Integer = MessageBox.Show("Found " & NextMACAddress.Text & " assigned to CPU " & databaseCPUSerialNumber & " in the database." & vbCrLf & _
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

	Private Sub NextButton_Click() Handles NextButton.Click
		If UpdateMAC() = False Then
			Return
		End If
		WorkingSystemSerialNumber = ""
        WorkingIP = ""

		MenuMain.RegisterSystemButton_Click()
		Close()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class