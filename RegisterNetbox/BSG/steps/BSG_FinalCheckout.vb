Imports System.Data.SqlClient
Imports System.IO

Public Class BSG_FinalCheckout
    Const TIMERCOUNT = 30   '30 seconds

	Private Sub FinalCheckout_Load() Handles MyBase.Load
		SerialNo.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub UpdateButton_Click() Handles UpdateButton.Click
		Dim result As String = ""
		Dim continueOn As Boolean = True
		Dim dirs As String()
		Dim filename As String = ""
		Dim myCmd As New SqlCommand("", myConn)

		'Check to see if we have a serial number.
		If SerialNo.Text.Length = 0 Then
			MsgBox("You need to add in a system serial number.")
			Return
		End If

		'Check to see if the passed serial number exists in the database.
		If sqlapi.BSG_FindSystemSerialNumber(myCmd, SerialNo.Text, result) = False Then
			MsgBox("Issue finding SNO: " & result)
			CheckoutStatus.Text = "Error: " & result
			Return
		End If

SEARCH:
		Dim endTime As Date = Date.Now().AddSeconds(TIMERCOUNT)

		Do While Date.Now() < endTime
			dirs = Directory.GetFiles(My.Settings.TempFolder, "*.pdf")

			If dirs.Length = 1 Then
				filename = SerialNo.Text & ".pdf"
				Exit Do
			Else If 2 <= dirs.Length then
				MsgBox("There is more than one .pdf at the temp target location. Please verify that only one PDF file is in " & My.Settings.TempFolder & ".")
				Return
			End If

			'Sleep for 1 second and then retry the DO loop.
			Threading.Thread.Sleep(1000)
		Loop

		If dirs.Length = 0 Then
			Dim answer As Integer = MessageBox.Show("Could not find PDF at '" & My.Settings.TempFolder & "'. Would you like to Ignore, Retry, or Abort?", "Retry?", MessageBoxButtons.AbortRetryIgnore)

			If answer = DialogResult.Ignore Then
				CheckoutStatus.Text = SerialNo.Text + " Checkout WITHOUT PDF!"
			ElseIf answer = DialogResult.Abort Then
				CheckoutStatus.Text = sqlapi._Username + " decided not to continue."
				Return
			ElseIf answer = DialogResult.Retry Then
				GoTo SEARCH
			End If
		End If

		 If sqlapi.BSG_FinalCheckout(SerialNo.Text, filename, result) = False Then
			MsgBox(result)
			CheckoutStatus.Text = "Error: " & result
			Return
		End If

		Try
			Dim location As String = CurrentCheckout & SerialNo.Text & ".pdf"

			If File.Exists(location) = True Then

				Dim duplicateNumber As Integer = 1
				Dim location2 As String = CurrentCheckout & SerialNo.Text & " -" & duplicateNumber & ".pdf"

				Do While File.Exists(location2) = True
					duplicateNumber += 1
					location2 = CurrentCheckout & SerialNo.Text & " -" & duplicateNumber & ".pdf"
				Loop

				File.Copy(location, location2, True)
				File.Delete(location)
			End If

			File.Copy(dirs(0), location, True)
			File.Delete(dirs(0))

			CheckoutStatus.Text = SerialNo.Text + " Checkout with PDF."
		Catch ex As Exception
			MsgBox("Error: " & ex.Message)
			CheckoutStatus.Text = "Error: " & ex.Message
			Return
		End Try

		SerialNo.Focus()
	End Sub

End Class