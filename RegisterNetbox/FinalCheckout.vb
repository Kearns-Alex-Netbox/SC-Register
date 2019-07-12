Imports System.Data.SqlClient
Imports System.IO

Public Class FinalCheckout
    Const TIMERCOUNT = 30   '30 seconds

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Private Sub FinalCheckout_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		SerialNo.Focus()
	End Sub

	Private Sub UpdateButton_Click() Handles UpdateButton.Click
		Dim result As String = ""
		Dim override As Boolean = False
		Dim resultBoolean As Boolean = False
		Dim noPDF As Boolean = False
		Dim continueOn As Boolean = True
		Dim dirs As String()
		Cursor.Current = Cursors.WaitCursor

		'Check to see if we have a serial number.
		If SerialNo.Text.Length > 0 Then
			'Check to see if the passed serial number exists in the database.
			If sqlapi.FindSystemSerialNumber(myCmd, myReader, SerialNo.Text, result) Then
				'Attempt to update the record in the database.
				Dim sleepCount = 0
				Do
					dirs = Directory.GetFiles(My.Settings.TempFolder, "*.pdf")
					If dirs.Length <> 0 Then
						'Check to see if we have more than one PDF file already in the directory location.
						If dirs.Length >= 2 Then
							MsgBox("There is more than one file at the temp target location. Please verify that only one PDF file is in " & My.Settings.TempFolder & ".")
							Return
						Else
							Exit Do
						End If
					Else
						'Sleep for 1 second and then retry the DO loop.
						Threading.Thread.Sleep(1000)
						sleepCount += 1
					End If

					If sleepCount = TIMERCOUNT Then     'After TIMERCOUNT seconds, give up on looking for the file.
						Dim ignore_abort_retry As Integer = MessageBox.Show("Could not find PDF at '" & My.Settings.TempFolder & "'. Would you like to Ignore, Retry, or Abort?", "Retry?", MessageBoxButtons.AbortRetryIgnore)
						If ignore_abort_retry = DialogResult.Ignore Then
							noPDF = True
							Exit Do
						ElseIf ignore_abort_retry = DialogResult.Abort Then
							continueOn = False
							Exit Do
						ElseIf ignore_abort_retry = DialogResult.Retry Then
							sleepCount = 0
						End If
					End If
				Loop

				If continueOn = True Then
					resultBoolean = sqlapi.FinalCheckout(myCmd, myConn, SerialNo.Text, SerialNo.Text & ".pdf", result, override, noPDF)

					If resultBoolean = False Then
						MsgBox(result)
						Return
					End If

					If noPDF = False Then
						Try
							Dim location As String = CurrentCheckout & SerialNo.Text & ".pdf"
							Dim duplicateNumber As Integer = 1
							Dim location2 As String = CurrentCheckout & SerialNo.Text & " -" & duplicateNumber & ".pdf"

							If File.Exists(location) = True Then
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
							CheckoutStatus.Text = "Did not work."
							Return
						End Try
					Else
						CheckoutStatus.Text = SerialNo.Text + " Checkout WITHOUT PDF!"
					End If
				Else
					CheckoutStatus.Text = sqlapi._Username + " decided not to continue."
				End If

			Else
				CheckoutStatus.Text = "Could not find Serial Number"
			End If
		Else
			MsgBox("You need to add in a system serial number.")
		End If
		Cursor.Current = Cursors.Default
		SerialNo.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

End Class