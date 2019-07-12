Imports System.Data.SqlClient

Public Class AddBoardComment
	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim boardSNO As String = ""
	Dim currentStatus As String = ""
	Dim fromMaint As Boolean = False

	Public Sub New(Optional ByRef SNO As String = "", Optional ByRef fromMaintenance As Boolean = True)
		InitializeComponent()
		boardSNO = SNO
		fromMaint = fromMaintenance
	End Sub

	Private Sub AddBoardComment_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
		BoardSerialNumber.Text = boardSNO

		'Populate SystemType drop-down
		CB_BoardStatus.DataSource = GetDropDownItems()
		CB_BoardStatus.DisplayMember = "Name"
		CB_BoardStatus.ValueMember = "ID"

		Show()

		If fromMaint = False Then
			BoardComment.Focus()
		End If
	End Sub

	Private Sub AddBoardCommentButton_Click() Handles AddBoardCommentButton.Click
		Dim record As Guid = Nothing
		Dim result As String = ""

        If BoardSerialNumber.Text.Length <> 0 And BoardComment.Text.Length <> 0 Then
            ' check to see if we are dealing with a scrapped board
            If currentStatus = SQL_API.SS_SCRAPPED And currentStatus <> CB_BoardStatus.SelectedValue Then
                MsgBox("Cannot change a scrapped board to another status.")
                Return
            End If

            If sqlapi.AddBoardComment(myCmd, BoardSerialNumber.Text, BoardComment.Text, record, result) = False Then
                MsgBox(result)
                Return
            End If

            If currentStatus <> CB_BoardStatus.SelectedValue Then
                If sqlapi.UpdateBoardStatus(myCmd, CB_BoardStatus.SelectedValue, BoardSerialNumber.Text, result) = False Then
                    MsgBox(result)
                    Return
                End If
            End If
        Else
            MsgBox("Make sure Board Serial Number and Comment text fields are filled out.")
			Return
		End If
		ResultStatus.Text = "Comment was added to Board '" & BoardSerialNumber.Text & "'"
		BoardSerialNumber.Text = ""
		If fromMaint = False Then
			BoardSerialNumber.Focus()
		Else
			BoardComment.Focus()
		End If
	End Sub

	Private Sub CancelButton_Click() Handles Cancel_Button.Click
		Close()
	End Sub

	Function GetDropDownItems() As List(Of DropDownItem)
		Dim dropDownItems = New List(Of DropDownItem)
		Dim myReader As SqlDataReader = Nothing

		Try
			myCmd.CommandText = "SELECT * FROM dbo.BoardStatus ORDER BY name"
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

	Private Sub BoardSerialNumber_LostFocus() Handles BoardSerialNumber.LostFocus
		Dim result As String = ""
		currentStatus = ""
		Dim record As Guid = Nothing

		If BoardSerialNumber.Text.Length <> 0 Then
			If sqlapi.GetBoardCurrentStatus(myCmd, myReader, BoardSerialNumber.Text, currentStatus, result) = False Then
				MsgBox(result)
				Return
			End If

			CB_BoardStatus.SelectedIndex = CB_BoardStatus.FindStringExact(currentStatus)

			RTB_Results.Clear()
			sqlapi.GetBoardAudit(myCmd, myReader, BoardSerialNumber.Text, RTB_Results, result)
		End If
	End Sub

	Private Sub BatchNote_Button_Click() Handles BatchNote_Button.Click
		Dim startingSNO As String = BoardSerialNumber.Text
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

		If BoardComment.Text.Length = 0 Then
			MsgBox("Please input a comment for the batch.")
			Return
		End If

		Dim startboard As String = startingSNO.Substring(0, startingSNO.IndexOf("-"))
		Dim endboard As String = startboard

		Dim startingnumber As Integer = startingSNO.Substring(startingSNO.IndexOf("-") + 1)
		Dim endingnumber As Integer = startingnumber

		' get the number of digits required in the SNO
		Dim startNumDigits As Integer = startingSNO.Substring(startingSNO.IndexOf("-") + 1).Length
		Dim endNumDigits As Integer = startNumDigits

		If startingnumber > endingnumber Then
			MsgBox("Starting Serial Number is larger than the ending Serial Number")
			Return
		End If

		' make sure we are rplacing the same number of digits
		If endNumDigits <> startNumDigits Then
			MsgBox("Please make the number of digits in the SNO the same.")
			Return
		End If

		Dim result As String = ""
		While startingnumber <= endingnumber
			Dim record As Guid = Nothing

			Dim currentBoardSNO As String = startboard & "-" & startingnumber.ToString("D" & startNumDigits)

			'Check to see if the serial number is in the database.
			If sqlapi.FindBoardSerialNumber(myCmd, myReader, currentBoardSNO, "") = False Then
				result = result & currentBoardSNO & vbNewLine
				startingnumber += 1
				Continue While
			End If

			'Add the batch comment.
			If sqlapi.AddBoardComment(myCmd, currentBoardSNO, "BATCH: " & BoardComment.Text, record, result) = False Then
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