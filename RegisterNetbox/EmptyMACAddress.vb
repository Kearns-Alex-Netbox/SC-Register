Imports System.Data.SqlClient

Public Class EmptyMACAddress
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Private Sub EmptyMACAddress_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub B_5Addresses_Click() Handles B_5Addresses.Click
		LB_Addresses.Items.Clear()
		GrabAddresses(5)
	End Sub
	Private Sub B_10Addresses_Click() Handles B_10Addresses.Click
		LB_Addresses.Items.Clear()
		GrabAddresses(10)
	End Sub
	Private Sub B_25Addresses_Click() Handles B_25Addresses.Click
		LB_Addresses.Items.Clear()
		GrabAddresses(25)
	End Sub
	Private Sub B_50Addresses_Click() Handles B_50Addresses.Click
		LB_Addresses.Items.Clear()
		GrabAddresses(50)
	End Sub
	Private Sub B_100Addresses_Click() Handles B_100Addresses.Click
		LB_Addresses.Items.Clear()
		GrabAddresses(100)
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub GrabAddresses(ByRef number As Integer)
		Dim MACAddressBase As String = "70-b3-d5-85-2"
		Dim NextMACAddress As String = "0-50"
		Dim numberOfEntries As Integer = 0

		Do While numberOfEntries < number
			If sqlapi.FindMACAddress(myCmd, myReader, MACAddressBase & NextMACAddress, "", "") = False Then
				LB_Addresses.Items.Add(MACAddressBase & NextMACAddress)
				LB_Addresses.Refresh()
				numberOfEntries += 1
			End If

			Dim TempMACAddr As String = NextMACAddress
			Dim LowPart As Integer
			Dim HighPart As Integer = Convert.ToInt32(TempMACAddr.Substring(0, 1), 16)

			LowPart = Convert.ToInt32(TempMACAddr.Substring(2), 16)
			LowPart += 1
			If LowPart >= 256 Then
				LowPart = 0
				HighPart += 1
			End If

			NextMACAddress = HighPart.ToString("x") + "-" + LowPart.ToString("x2")
		Loop
	End Sub

End Class