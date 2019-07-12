Imports System.Data.SqlClient

Public Class AddSystemComment
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim systemSNO As String = ""
	Dim currentStatus As String = ""
	Dim fromMaint As Boolean = False

	Public Sub New(Optional ByRef SNO As String = "", Optional ByRef fromMaintenance As Boolean = True)
		InitializeComponent()
		systemSNO = SNO
		fromMaint = fromMaintenance
	End Sub

	Private Sub AddSystemComment_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		SystemSerialNumber.Text = systemSNO

		'Populate SystemType drop-down
		CB_SystemStatus.DataSource = GetDropDownItems()
		CB_SystemStatus.DisplayMember = "Name"
		CB_SystemStatus.ValueMember = "ID"

		Show()
		CenterToParent()

		If fromMaint = False Then
			SystemComment.Focus()
		End If
	End Sub

	Private Sub AddSystemCommentButton_Click() Handles AddSystemCommentButton.Click
		Dim record As Guid = Nothing
		Dim result As String = ""

		Dim answer As Integer = 0
        If SystemSerialNumber.Text.Length <> 0 And SystemComment.Text.Length <> 0 Then
            ' check to see if we are dealing with a scrapped unit
            If currentStatus = SQL_API.SS_SCRAPPED And currentStatus <> CB_SystemStatus.SelectedValue Then
                MsgBox("Cannot change a scrapped system to another status.")
                Return
            End If

            'If we are Scrapping the unit, we need to call another dialog box to confirm the action.
            If CB_SystemStatus.SelectedValue = SQL_API.SS_SCRAPPED Then
                Dim scrapDialog As New ScrapConfirmation(SystemSerialNumber.Text)

                scrapDialog.ShowDialog()
                answer = scrapDialog.DialogResult

                If answer = DialogResult.No Then
                    Return
                End If
            End If

            If sqlapi.AddSystemComment(myCmd, SystemSerialNumber.Text, SystemComment.Text, record, result) = False Then
                MsgBox(result)
                Return
            End If


            If currentStatus <> CB_SystemStatus.SelectedValue Then
                If sqlapi.UpdateSystemStatus(myCmd, myConn, CB_SystemStatus.SelectedValue, SystemSerialNumber.Text, result, True) = False Then
                    MsgBox(result)
                    Return
                End If
            End If
        Else
            MsgBox("Make sure System Serial Number and Comment text fields are filled out.")
			Return
		End If

		ResultStatus.Text = "Comment was added to System '" & SystemSerialNumber.Text & "'"
		SystemSerialNumber.Text = ""
		If fromMaint = True Then
			SystemSerialNumber.Focus()
		End If
	End Sub

	Private Sub CancelButton_Click() Handles Cancel_Button.Click
		Close()
	End Sub

	Function GetDropDownItems() As List(Of DropDownItem)
		Dim dropDownItems = New List(Of DropDownItem)
		Dim myReader As SqlDataReader = Nothing

		Try
			myCmd.CommandText = "SELECT * FROM dbo.SystemStatus ORDER BY name"
			myReader = myCmd.ExecuteReader()
			If myReader.HasRows = True Then
				While myReader.Read()
					dropDownItems.Add(New DropDownItem(myReader("name"), myReader("name")))
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

	Private Sub SystemSerialNumber_LostFocus() Handles SystemSerialNumber.LostFocus
		Dim result As String = ""
		currentStatus = ""
		Dim record As Guid = Nothing

		If SystemSerialNumber.Text.Length <> 0 Then
			If sqlapi.GetSystemCurrentStatus(myCmd, myReader, SystemSerialNumber.Text, record, currentStatus, result) = False Then
				MsgBox(result)
				Return
			End If

			CB_SystemStatus.SelectedIndex = CB_SystemStatus.FindStringExact(currentStatus)

			RTB_Results.Clear()
			sqlapi.GetSystemAudit(myCmd, myReader, SystemSerialNumber.Text, RTB_Results, result)
		End If
	End Sub

	Private Sub BatchNote_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BatchNote_Button.Click
		Dim startingSNO As String = SystemSerialNumber.Text
		Dim endingSNO As String = EndingSNO_TextBox.Text

		'Logic checking.
		If startingSNO.Length = 0 Then
			MsgBox("Please input a starting Serial Number")
			Return
		End If

		If endingSNO.Length = 0 Then
			MsgBox("Please input an ending Serial Number")
			Return
		End If

		If startingSNO = endingSNO Then
			MsgBox("Starting and ending Serial Numbers are the same.")
			Return
		End If

		If SystemComment.Text.Length = 0 Then
			MsgBox("Please input a comment for the batch.")
			Return
		End If

		Dim board As String = startingSNO.Substring(0, startingSNO.IndexOf("-"))
		Dim startingnumber As Integer = startingSNO.Substring(startingSNO.IndexOf("-") + 1)
		Dim endingnumber As Integer = endingSNO.Substring(startingSNO.IndexOf("-") + 1)

		If startingnumber > endingnumber Then
			MsgBox("Starting Serial Number is larger than the ending Serial Number")
			Return
		End If

		Dim result As String = ""
		While startingnumber <= endingnumber
			Dim record As Guid = Nothing

			'Check to see if the serial number is in the database.
			If sqlapi.FindSystemSerialNumber(myCmd, myReader, board & "-" & startingnumber, "") = False Then
				result = result & board & "-" & startingnumber & vbNewLine
				startingnumber += 1
				Continue While
			End If

			'Add the batch comment.
			If sqlapi.AddSystemComment(myCmd, board & "-" & startingnumber, "BATCH: " & SystemComment.Text, record, result) = False Then
				MsgBox(result)
				Return
			End If

			startingnumber += 1
		End While

		If result.Length <> 0 Then
			ResultStatus.Text = "Batch Comment was added for all except these Serial Numbers. They do not exist in the database:" & vbNewLine & result
		Else
			ResultStatus.Text = "Batch Comment has been added to the boards."
		End If
	End Sub

End Class