Imports System.Data.SqlClient

Public Class RegisterSystem
    Const IS_FALSE As String = "0"
    Const IS_TRUE As String = "1"

    Const SLOT_0 As String = "0"
    Const SLOT_1 As String = "1"
    Const SLOT_2 As String = "2"
    Const SLOT_3 As String = "3"
    Const SLOT_4 As String = "4"
    Const SLOT_5 As String = "5"
    Const SLOT_6 As String = "6"
	Const SLOT_7 As String = "7"
	Const SLOT_8 As String = "8"
	Const SLOT_9 As String = "9"
	Const SLOT_10 As String = "10"

	Dim SNOInputs() As TextBox = {}
	Dim SNOLabels() As   Label = {}

	Dim myCmd As New SqlCommand("", myConn)
	Dim formLoaded As Boolean = False

	Private Sub RegisterSystem_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		'Populate SystemType drop-down
		CB_SystemType.DataSource = GetDropDownItems()
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200

		CB_SystemType.SelectedIndex = -1

		SNOInputs = {MotherboardSerialNumber, CPUSerialNumber, Slot2SerialNumber, Slot3SerialNumber, Slot4SerialNumber, Slot5SerialNumber, Slot6SerialNumber,
			Slot7SerialNumber, Slot8SerialNumber, Slot9SerialNumber, Slot10SerialNumber}
		SNOLabels = {Motherboard_Label, Slot1_Label, Slot2_Label, Slot3_Label, Slot4_Label, Slot5_Label, Slot6_Label, Slot7_Label, Keyboard_Label, LCD_Label, LCDdriver_Label}

		formLoaded = True
        CB_SystemType.SelectedIndex = My.Settings.SystemType

		'CB_Extras.SelectedIndex = CB_Extras.FindString("")


	End Sub

	Private Sub RegisterSystem_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		If e.CloseReason = CloseReason.UserClosing Then
			WorkingSystemSerialNumber = ""
			WorkingIP = ""
		End If
	End Sub

	Private Sub SaveButton_Click() Handles SaveButton.Click
		If SaveChanges() = False Then
			Return
		End If

		For index As Integer = 0 To MAX_NB_SLOTS
			SNOInputs(index).Text = ""
		Next

		SystemSerialNumber.Text = ""

		'Set focus to system serial number again.
		SystemSerialNumber.Focus()
	End Sub

	Private Sub ClearButton_Click() Handles ClearButton.Click
		'Clear all of the text fields.
		For index As Integer = 0 To MAX_NB_SLOTS
			SNOInputs(index).Text = ""
		Next

		SystemSerialNumber.Text = ""

		ResultStatus.Text = ""

		WorkingSystemSerialNumber = ""

		'Set focus to system serial number again
		SystemSerialNumber.Focus()
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		WorkingSystemSerialNumber = ""
		Close()
	End Sub

	Private Sub NextButton_Click() Handles NextButton.Click
		If SaveChanges() = False Then
			Return
		End If
		WorkingSystemSerialNumber = SystemSerialNumber.Text
        WorkingIP = ""

		MenuMain.GetCPUInfoButton_Click()
		Close()
	End Sub

	Private Function SaveChanges() As Boolean
		Dim serialNumbers As String() = {
			MotherboardSerialNumber.Text.ToUpper(), 
			CPUSerialNumber.Text.ToUpper(), 
			Slot2SerialNumber.Text.ToUpper(), 
			Slot3SerialNumber.Text.ToUpper(),
			Slot4SerialNumber.Text.ToUpper(), 
			Slot5SerialNumber.Text.ToUpper(), 
			Slot6SerialNumber.Text.ToUpper(), 
			Slot7SerialNumber.Text.ToUpper(), 
			Slot8SerialNumber.Text.ToUpper(),
			Slot9SerialNumber.Text.ToUpper(), 
			Slot10SerialNumber.Text.ToUpper()}
		Dim result As String = ""
        Dim slimModel As Boolean = False
        If CB_SystemType.Text = "ETS 7" Then
            slimModel = True
        End If
        ResultStatus.Text = ""

        'Check to see that the serial number has been filled in.
        If SystemSerialNumber.Text.Length = 0 Then
            MsgBox("System Serial Number needs to be filled in.")
            Return False
        End If

		If CheckSystemAndMandatoryBoards() = False Then
			Return False
		End If

		'If CB_Extras.Items(CB_Extras.SelectedIndex).name.Length = 0 Then
		'    MsgBox("Please make sure you have an Extra defined and selected for this system type.")
		'    Return False
		'End If

		'If sqlapi.AddSystemWithBoards(myCmd, myConn, UserName, SystemSerialNumber.Text, serialNumbers, CB_SystemType.SelectedValue.ToString, CB_Extras.SelectedValue.ToString, result, slimModel) = False Then
		'	MsgBox(result)
		'	Return False
		'End If

		If sqlapi.AddSystemWithBoards(myCmd, myConn, SystemSerialNumber.Text.ToUpper(), serialNumbers, CB_SystemType.SelectedValue.ToString, result, slimModel) = False Then
			MsgBox(result)
			Return False
		End If

		ResultStatus.Text = "Updated " + SystemSerialNumber.Text
        SystemSerialNumber.Focus()
        Return True
    End Function

    Function GetDropDownItems() As List(Of DropDownItem)
        Dim dropDownItems = New List(Of DropDownItem)

		myCmd.CommandText = "SELECT * FROM dbo.SystemType WHERE name NOT LIKE '%Spare%' ORDER BY name"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count = 0 Then
			Return dropDownItems
		End If

		For Each row As DataRow In dt_results.Rows
			dropDownItems.Add(New DropDownItem(row("id").ToString, row("name")))
		Next
		
        Return dropDownItems
    End Function

	Private Sub CB_SystemType_SelectedValueChanged() Handles CB_SystemType.SelectedValueChanged
		If formLoaded = false Then
			Return
		End If

		' grab the system deffinitions to determin what is enabled
		myCmd.CommandText = "SELECT * from SystemDefinition where [SystemType.id] = (Select id from SystemType WHERE name = '" & CB_SystemType.Text & "')"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count = 0 Then
			For index As Integer = 0 To MAX_NB_SLOTS
				SNOInputs(index).Enabled = True
			Next
			MsgBox("You do not have a definition set up for this unit yet. Recomend setting one up soon.")
			Return
		End If

		For index As Integer = 0 To MAX_NB_SLOTS
			SNOInputs(index).Enabled = False
			SNOLabels(index).Text = "Slot " & (index + 1)
		Next

		For Each row As DataRow In dt_results.Rows
			Select Case row("SlotNumber")
				Case SLOT_0
					SNOInputs(SLOT_0).Enabled = True
					SNOLabels(SLOT_0).Text = row("Description")
				Case SLOT_1
					SNOInputs(SLOT_1).Enabled = True
					SNOLabels(SLOT_1).Text = row("Description")
				Case SLOT_2
					SNOInputs(SLOT_2).Enabled = True
					SNOLabels(SLOT_2).Text = row("Description")
				Case SLOT_3
					SNOInputs(SLOT_3).Enabled = True
					SNOLabels(SLOT_3).Text = row("Description")
				Case SLOT_4
					SNOInputs(SLOT_4).Enabled = True
					SNOLabels(SLOT_4).Text = row("Description")
				Case SLOT_5
					SNOInputs(SLOT_5).Enabled = True
					SNOLabels(SLOT_5).Text = row("Description")
				Case SLOT_6
					SNOInputs(SLOT_6).Enabled = True
					SNOLabels(SLOT_6).Text = row("Description")
				Case SLOT_7
					SNOInputs(SLOT_7).Enabled = True
					SNOLabels(SLOT_7).Text = row("Description")
				Case SLOT_8
					SNOInputs(SLOT_8).Enabled = True
					SNOLabels(SLOT_8).Text = row("Description")
				Case SLOT_9
					SNOInputs(SLOT_9).Enabled = True
					SNOLabels(SLOT_9).Text = row("Description")
				Case SLOT_10
					SNOInputs(SLOT_10).Enabled = True
					SNOLabels(SLOT_10).Text = row("Description")
				Case Else
					MsgBox("Program is not set for Slot Number:" & row("SlotNumber"))
			End Select
		Next

		My.Settings.SystemType = CB_SystemType.SelectedIndex
		My.Settings.Save()
		UpdateLB_Definitions()

		SystemSerialNumber.Focus()
		'CB_Extras.DataSource = GetDropDownExtras()

		' grab the default item
		'Dim defaultId As String = ""
		'Try
		'	myCmd.CommandText = "SELECT [Description] FROM dbo.SystemExtras WHERE [SystemType.id] = '" & CB_SystemType.SelectedValue.ToString & "' AND [Default] = 1"
		'	defaultId = myCmd.ExecuteScalar().ToString
		'Catch ex As Exception

		'End Try

		'CB_Extras.DisplayMember = "Name"
		'CB_Extras.ValueMember = "id"
		'CB_Extras.DropDownHeight = 200
		'CB_Extras.SelectedIndex = CB_Extras.FindString(defaultId)

		SystemSerialNumber.Focus()
	End Sub

	'Function GetDropDownExtras() As List(Of DropDownItem)
	'	Dim dropDownItems = New List(Of DropDownItem)
	'	Dim myReader As SqlDataReader = Nothing

	'	Try
	'		myCmd.CommandText = "SELECT * FROM dbo.SystemExtras WHERE [SystemType.id] = '" & CB_SystemType.SelectedValue.ToString & "' ORDER BY [Description]"
	'		myReader = myCmd.ExecuteReader()
	'		If myReader.HasRows = True Then
	'			While myReader.Read()
	'				dropDownItems.Add(New DropDownItem(myReader("id").ToString, myReader("Description")))
	'			End While
	'		End If
	'		myReader.Close()
	'	Catch ex As Exception
	'		If Not myReader Is Nothing Then
	'			myReader.Close()
	'		End If
	'		MsgBox(ex.Message)
	'	End Try
	'	Return dropDownItems
	'End Function

	Private Sub UpdateLB_Definitions()
		myCmd.CommandText = "SELECT 
y.SlotNumber As 'Item'
, CASE
WHEN  y.Mandatory = 1 THEN 'Y'
ELSE 'N'
END AS 'Reqire'
, s.BaseSerialNo AS 'Base SNO'
FROM dbo.SystemDefinition y LEFT JOIN dbo.BoardType s ON y.[BoardType.id] = s.id WHERE y.[SystemType.id] = '" & CB_SystemType.SelectedValue & "' ORDER BY SlotNumber"

		dim da = New SqlDataAdapter(myCmd)
		dim ds = New DataSet()

		da.Fill(ds, "TABLE")

		Deffinition_DataGridView.DataSource = ds.Tables(0)

		For Each column In Deffinition_DataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next column
    End Sub

    Public Function CheckSystemAndMandatoryBoards() As Boolean
        'Check the slots to make sure they match our system definitions.
		For index As Integer = 0 To MAX_NB_SLOTS - 1
			If sqlapi.BSG_CheckSystemDefinition(myCmd, CB_SystemType.SelectedValue, index, SNOInputs(index).Text.ToUpper()) = False Then
				Return False
			End If
		Next

		Return True
    End Function

End Class