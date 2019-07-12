Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class GetCPUinfo
	Dim jsonapi As New JSON_API()
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim CPUBoardSerialNo As String = ""
	Dim databaseCPUSerialNumber As String = ""

	Private Sub GetCPUinfo_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		If WorkingSystemSerialNumber <> "" Then
			SerialNumber.Text = WorkingSystemSerialNumber
		End If
	End Sub

	Private Sub GetCPUinfo_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		If e.CloseReason = CloseReason.UserClosing Then
			WorkingIP = ""
			WorkingSystemSerialNumber = ""
		End If
	End Sub

	Private Sub UpdateSystemMACButton_Click() Handles UpdateSystemMACButton.Click
		UpdateInformation()
	End Sub

	Private Function UpdateInformation() As Boolean
		Dim WResponse As String = ""
		Dim result As String = ""
		Dim systemType As String = ""
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

            'Check to see if the system type in the database matches what the machine tells us.
            If sqlapi.CheckSystemType(myCmd, myReader, SerialNumber.Text, obj.model.ToString, result) <> True Then
                MsgBox(result)
                Return False
            End If

            'Grab the CPU Board serial number from the System serial number.
            If sqlapi.GetCPUSerialNumberBySystemSerialNumber(myCmd, myReader, SerialNumber.Text, CPUBoardSerialNo, result) = False Then
                MsgBox(result)
                Return False
            End If
        Else
            MsgBox("Could not get JSON information from the machine")
            Return False
        End If

        'Register the network and update the database entry.
        ' this needs to be done first so we do not acidentally push the data to the box and it not work in the database
        If sqlapi.UpdateCPUInformation(myCmd, myConn, SerialNumber.Text, result, obj) = False Then
            MsgBox(result)  'might need to delete this message display
            Return False
        End If

        'Update the machine's MAC Address, Serial Number, and CPU Board Serial Number.
        If jsonapi.SetMachineInfo(TB_BaseIP.Text & TB_IPAddress.Text, obj.macaddress, SerialNumber.Text, CPUBoardSerialNo, WResponse) Then
            Try
                obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WResponse)
            Catch
                MsgBox("Could not convert JSON result string")
                Return False
            End Try

            ReturnedSerialNo.Text = SerialNumber.Text
            SerialNumber.Text = ""
        Else
            Cursor = Cursors.Default
            Return False
        End If
		TB_IPAddress.Text = ""
		TB_IPAddress.Focus()
		Return True
	End Function

	Private Sub NextButton_Click() Handles NextButton.Click
		Dim useIP As String = TB_IPAddress.Text
		If UpdateInformation() = False Then
			Return
		End If
		WorkingSystemSerialNumber = ReturnedSerialNo.Text
        WorkingIP = useIP

		MenuMain.RegisterMACButton_Click()
		Close()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class