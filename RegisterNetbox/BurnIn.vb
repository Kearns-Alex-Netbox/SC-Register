Imports System.Data.SqlClient

Public Class BurnIn
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim runningTransaction As Boolean = False
	Dim skippedStepsSNOs As New List(Of String)

	Private Sub BurnIn_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		SerialNo.Focus()
	End Sub

	Private Sub UpdateButton_Click() Handles UpdateButton.Click
		runningTransaction = True
		SerialNo.Text = ""
		LB_Log.Items.Clear()

		'Attempt to update the record in the database.
		For Each serialNumber In Queue.Items
			Dim result As String = ""
			Dim override As Boolean = False
			Dim resultBoolean As Boolean = False

			If serialNumber <> Nothing Then
				If serialNumber.Length <> 0 Then
					resultBoolean = sqlapi.BurnIn(myCmd, myConn, serialNumber, skippedStepsSNOs, result)

					If resultBoolean = True Then
						LB_Log.Items.Add("Updated " & serialNumber & " to 'Burn In' status.")
					Else
						LB_Log.Items.Add("Failed " & serialNumber & ": " & result)
					End If
				End If
			End If
		Next

		LB_Log.Items.Add("Done")
		Queue.Items.Clear()
		runningTransaction = False
		SerialNo.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub SerialNo_Leave() Handles SerialNo.LostFocus
		Try
			If ExitButton.Focused Or B_Clear.Focused Or B_ClearQueue.Focused Then

			ElseIf runningTransaction <> True And SerialNo.Text.Length <> 0 Then
				'Check to see if our Text already is in our queue. **Not case sensitive**
				If Queue.FindString(SerialNo.Text) = -1 Then
					Queue.Items.Add(SerialNo.Text)
					Queue.TopIndex = Queue.Items.Count - 1
					SerialNo.SelectAll()
					SerialNo.Focus()
				End If
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Clear_Click() Handles B_Clear.Click
		LB_Log.Items.Clear()
	End Sub

	Private Sub B_ClearQueue_Click() Handles B_ClearQueue.Click
		Queue.Items.Clear()
	End Sub

End Class