Imports System.Data.SqlClient

Public Class EditSystemDefinition
    Const SYSTEM_TYPE_TABLE As String = "dbo.SystemType"
    Const BOARD_TYPE_TABLE As String = "dbo.BoardType"
    Const IS_TRUE As String = "1"
    Const IS_FALSE As String = "0"

	Dim myCmd As New SqlCommand("", myConn)
	Dim fourmLoaded As Boolean = False

	Private Sub EditSystemDefinition_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		'Populate SystemType drop-down
		CB_SystemType.DataSource = GetDropDownItems(SYSTEM_TYPE_TABLE)
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200

		CB_BoardType.DataSource = GetDropDownItems(BOARD_TYPE_TABLE)
		CB_BoardType.DisplayMember = "Name"
		CB_BoardType.ValueMember = "ID"
		CB_BoardType.DropDownHeight = 200
		CB_BoardType.SelectedIndex = -1

		'add in the number of items to pick from
		CB_Slot.DataSource = GetDropDownItemNumbers()
		CB_Slot.DisplayMember = "Name"
		CB_Slot.ValueMember = "ID"
		CB_Slot.DropDownHeight = 200
		CB_Slot.SelectedIndex = -1


		fourmLoaded = True
		UpdateLB_Definitions()
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		Dim mandatory As String = ""
		Dim result As String = ""

		If ChB_Mandatory.Checked = True Then
			mandatory = IS_TRUE
		Else
			mandatory = IS_FALSE
		End If

		If Description_TextBox.Text.Length = 0 Then
			MsgBox("Please enter a description.")
			Return
		End If

		If sqlapi.FindSystemDefinition(myCmd, CB_SystemType.SelectedValue, CB_BoardType.SelectedValue, CB_Slot.SelectedIndex) = True Then
			MsgBox("This system definition is already in the database.")
			Return
		End If

		Dim answer As Integer = MessageBox.Show("System Type: " & CB_SystemType.Text & vbCrLf &
												"Item Number: " & CB_Slot.SelectedIndex & vbCrLf &
												"Description: " & Description_TextBox.Text & vbCrLf &
												"Board Type: " & CB_BoardType.Text & vbCrLf &
												"Mandatory: " & ChB_Mandatory.Checked & vbCrLf &
												"Would you like to add this System Definition to the database?", "Add?", MessageBoxButtons.YesNo)
		If answer = DialogResult.No Then
			TB_Result.Text = "User decided not to add system definition to the database."
			Return
		End If

		If sqlapi.AddSystemDefinition(CB_SystemType.SelectedValue, CB_BoardType.SelectedValue, CB_Slot.SelectedIndex, mandatory, Description_TextBox.Text, result) = False Then
			MsgBox(result)
			Return
		End If

		TB_Result.Text = "System Definition " & CB_BoardType.Text & " Item " & CB_Slot.SelectedIndex & " Mandatory: " & ChB_Mandatory.Checked & " has been added for " & CB_SystemType.Text
		UpdateLB_Definitions()
	End Sub

	Private Sub B_Remove_Click() Handles B_Remove.Click
		Dim mandatory As String = ""
		Dim result As String = ""

		If ChB_Mandatory.Checked = True Then
			mandatory = IS_TRUE
		Else
			mandatory = IS_FALSE
		End If

		If sqlapi.FindSystemDefinition(myCmd, CB_SystemType.SelectedValue, CB_BoardType.SelectedValue, CB_Slot.SelectedIndex) = False Then
			MsgBox("This system definition is not in the database.")
			Return
		End If

		Dim answer As Integer = MessageBox.Show("System Type: " & CB_SystemType.Text & vbCrLf &
												"Board Type: " & CB_BoardType.Text & vbCrLf &
												"Item Number: " & CB_Slot.SelectedIndex & vbCrLf &
												"Would you like to remove this System Definition from the database?", "Remove?", MessageBoxButtons.YesNo)
		If answer = DialogResult.No Then
			TB_Result.Text = "User decided not to remove system definition from the database."
			Return
		End If

		If sqlapi.RemoveSystemDefinition(myCmd, CB_SystemType.SelectedValue, CB_BoardType.SelectedValue, CB_Slot.SelectedIndex, result) = False Then
			MsgBox(result)
			Return
		End If

		TB_Result.Text = "System Definition " & CB_BoardType.Text & " Slot " & CB_Slot.SelectedIndex & " Mandatory: " & ChB_Mandatory.Checked & " has been removed from " & CB_SystemType.Text
		UpdateLB_Definitions()
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

	Function GetDropDownItems(ByRef table As String) As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)
        Dim myReader As SqlDataReader = Nothing

        Try
            myCmd.CommandText = "SELECT * FROM " & table & " ORDER BY name"
            myReader = myCmd.ExecuteReader()
            If myReader.HasRows = True Then
                While myReader.Read()
                    If table = SYSTEM_TYPE_TABLE Then
                        dropDownItems.Add(New DropDownItem(myReader("id").ToString, myReader("name")))
                    Else
                        dropDownItems.Add(New DropDownItem(myReader("id").ToString, myReader("BaseSerialNo")))
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
        Return dropDownItems
    End Function

	Function GetDropDownItemNumbers() As List(Of DropDownItem)
		Dim dropDownItems = New List(Of DropDownItem)

		Dim maxboards As Integer = 0

		If CurrentDatabase = Databases(NB_DEVEL) Or CurrentDatabase = Databases(NB_PRODUCTION) Then
			maxboards = MAX_NB_SLOTS
		ElseIf CurrentDatabase = Databases(BSG_DEVEL) Or CurrentDatabase = Databases(BSG_PRODUCTION) Then
			maxboards = MAX_BSG_SLOTS
		End If

		For index As Integer = 0 To maxboards - 1
			dropDownItems.Add(New DropDownItem(index, "Item: " & index))
		Next

		Return dropDownItems
	End Function

	Private Sub CB_SystemType_SelectedValueChanged() Handles CB_SystemType.SelectedValueChanged
		UpdateLB_Definitions()
	End Sub

	Private Sub UpdateLB_Definitions()
        If fourmLoaded = False Then
            Return
        End If
		
        myCmd.CommandText = "SELECT 
							   y.SlotNumber As 'Item'
							 , CASE
								WHEN  y.Mandatory = 1 THEN 'Y'
								ELSE 'N'
						       END AS 'Reqire'
							 , s.BaseSerialNo AS 'Base SNO'
							 , y.Description AS 'Info'
						     FROM dbo.SystemDefinition y LEFT JOIN dbo.BoardType s ON y.[BoardType.id] = s.id WHERE y.[SystemType.id] = '" & CB_SystemType.SelectedValue & "' ORDER BY SlotNumber"

		dim da = New SqlDataAdapter(myCmd)
		dim ds = New DataSet()

		da.Fill(ds, "TABLE")

		Deffinition_DataGridView.DataSource = ds.Tables(0)

		For Each column In Deffinition_DataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next column

    End Sub

End Class