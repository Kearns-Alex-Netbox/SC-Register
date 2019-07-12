Imports System.Data.SqlClient

Public Class SwapBoards
    Const BOARDSTATUS As Integer = 1
    Const SYSTEMSTATUS As Integer = 2

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Private Sub SwapBoards_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		'Populate SystemType drop-down
		CB_SystemStatus.DataSource = GetDropDownItems(SYSTEMSTATUS)
		CB_SystemStatus.DisplayMember = "Name"
		CB_SystemStatus.ValueMember = "ID"

		'Populate OldBoardType drop-down
		CB_OldBoardStatus.DataSource = GetDropDownItems(BOARDSTATUS)
		CB_OldBoardStatus.DisplayMember = "Name"
		CB_OldBoardStatus.ValueMember = "ID"
		CB_OldBoardStatus.SelectedIndex = CB_OldBoardStatus.FindStringExact("Rework")
	End Sub

	Private Sub SwapBoardsButton_Click() Handles SwapBoardsButton.Click
		Dim result As String = ""

		If SystemSerialNumber.Text.Length <> 0 And OldBoardSerialNumber.Text.Length <> 0 And NewBoardSerialNumber.Text.Length <> 0 And IssueComment.Text.Length <> 0 Then
			If sqlapi.SwapBoards(myCmd, myConn, SystemSerialNumber.Text, OldBoardSerialNumber.Text, NewBoardSerialNumber.Text, IssueComment.Text, CB_SystemStatus.SelectedValue, CB_OldBoardStatus.SelectedValue, result) = False Then
				MsgBox(result)
				Return
			End If
		Else
			MsgBox("System, Old board, board issue, and new board serial numbers need to be filled in.")
			Return
		End If
		ResultStatus.Text = "Board'" & OldBoardSerialNumber.Text & "' was swapped for Board '" & NewBoardSerialNumber.Text & "' in System '" & SystemSerialNumber.Text
		SystemSerialNumber.Text = ""
		OldBoardSerialNumber.Text = ""
		NewBoardSerialNumber.Text = ""
		IssueComment.Text = ""
		SystemSerialNumber.Focus()
	End Sub

	Private Sub CancelButton_Click() Handles Cancel_Button.Click
		Close()
	End Sub

	Function GetDropDownItems(ByRef status As Integer) As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)
        Dim myReader As SqlDataReader = Nothing

        Select Case status
            Case BOARDSTATUS
                Try
                    myCmd.CommandText = "SELECT * FROM dbo.BoardStatus ORDER BY name"
                    myReader = myCmd.ExecuteReader()
                    If myReader.HasRows = True Then
                        While myReader.Read()
                            If String.Compare(myReader("name"), "Rework") = 0 Or String.Compare(myReader("name"), "Board Checked") = 0 Then
                                dropDownItems.Add(New DropDownItem(myReader("name"), myReader("name")))
                            End If
                        End While
                    End If
                    myReader.Close()
                Catch ex As Exception
                    If Not myReader Is Nothing Then
                        myReader.Close()
                    End If
                    MsgBox(ex.Message)
                End Try
            Case SYSTEMSTATUS
                Try
                    myCmd.CommandText = "SELECT * FROM dbo.SystemStatus ORDER BY name"
                    myReader = myCmd.ExecuteReader()
                    If myReader.HasRows = True Then
                        While myReader.Read()
                            If String.Compare(myReader("name"), "Rework") <> 0 Then
                                dropDownItems.Add(New DropDownItem(myReader("name"), myReader("name")))
                            End If
                        End While
                    End If
                    myReader.Close()
                Catch ex As Exception
                    If Not myReader Is Nothing Then
                        myReader.Close()
                    End If
                    MsgBox(ex.Message)
                End Try
            Case Else
        End Select

        Return dropDownItems
    End Function

	Private Sub SystemSerialNumber_LostFocus() Handles SystemSerialNumber.LostFocus
		Dim result As String = ""
		Dim currentStatus As String = ""
		Dim record As Guid = Nothing

		If SystemSerialNumber.Text.Length <> 0 Then
			If sqlapi.GetSystemCurrentStatus(myCmd, myReader, SystemSerialNumber.Text, record, currentStatus, result) = False Then
				MsgBox(result)
				Return
			End If

			CB_SystemStatus.SelectedIndex = CB_SystemStatus.FindStringExact(currentStatus)
		End If
	End Sub

End Class