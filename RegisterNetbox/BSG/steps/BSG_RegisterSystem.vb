Imports System.Data.SqlClient

Public Class BSG_RegisterSystem
    Const IS_FALSE As String = "0"
    Const IS_TRUE  As String = "1"

    Const ITEM_0 As String = "0"
    Const ITEM_1 As String = "1"
    Const ITEM_2 As String = "2"
    Const ITEM_3 As String = "3"
    Const ITEM_4 As String = "4"

	Dim SNOInputs() As TextBox = {}
	Dim SNOLabels() As   Label = {}

	Dim myCmd       As New SqlCommand("", myConn)
	Dim formLoaded  As Boolean = False

	Private Sub RegisterSystem_Load() Handles MyBase.Load
		' populate SystemType drop-down
		GetDropDownItems(CB_SystemType)

		SNOInputs = { MotherboardSerialNumber, CPUSerialNumber, Slot2SerialNumber, Slot3SerialNumber, Slot4SerialNumber }
		SNOLabels = {             Item1_Label,     Item2_Label,       Item3_Label,       Item4_Label,       Item5_Label }

		formLoaded = True
        CB_SystemType.SelectedIndex = My.Settings.BSG_SystemType
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

		clearInputs()
	End Sub

	Private Sub ClearButton_Click() Handles ClearButton.Click
		ResultStatus.Text = ""

		WorkingSystemSerialNumber = ""

		clearInputs()
	End Sub

	Public sub clearInputs()
		' clear our inputs
		For each snoInput In SNOInputs
			snoInput.Text = ""
		Next

		SystemSerialNumber.Text = ""

		'Set focus to system serial number again.
		SystemSerialNumber.Focus()
	End sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		WorkingSystemSerialNumber = ""
		WorkingIP = ""
		Close()
	End Sub

	Private Sub NextButton_Click() Handles NextButton.Click
		If SaveChanges() = False Then
			Return
		End If
		WorkingSystemSerialNumber = SystemSerialNumber.Text
        WorkingIP = ""

		BSG_MenuMain.CPUInfo_Button_Click()
		Close()
	End Sub

	Private Function SaveChanges() As Boolean
		Dim serialNumbers() As String = {
			MotherboardSerialNumber.Text.ToUpper(), 
			CPUSerialNumber.Text.ToUpper(), 
			Slot2SerialNumber.Text.ToUpper(), 
			Slot3SerialNumber.Text.ToUpper(), 
			Slot4SerialNumber.Text.ToUpper()
		}
		Dim result          As String = ""
		Dim SNO             As String = SystemSerialNumber.Text.ToUpper()
		Dim systemType      As String = CB_SystemType.SelectedValue.ToString
        
        ResultStatus.Text = ""

        'Check to see that the serial number has been filled in.
        If SNO.Length = 0 Then
            MsgBox("System Serial Number needs to be filled in.")
            Return False
        End If

		If CheckMandatoryBoards() = False Then
			Return False
		End If
		
		If sqlapi.BSG_AddSystemWithBoards(SNO, serialNumbers, systemType, result) = False Then
			MsgBox(result)
			Return False
		End If

		ResultStatus.Text = "Updated " + SNO
        SystemSerialNumber.Focus()
        Return True
    End Function

    Private Sub GetDropDownItems(byref combo As ComboBox)
        Dim dropDownItems = New List(Of DropDownItem)

		myCmd.CommandText = "SELECT 
id AS 'id'
,name AS 'name' 
FROM dbo.SystemType 
WHERE name NOT LIKE '%Spare%' 
ORDER BY name"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count <> 0 Then
			For Each row As DataRow In dt_results.Rows
				dropDownItems.Add(New DropDownItem(row("id").ToString, row("name")))
			Next
		End If
		
		combo.DataSource = dropDownItems
		combo.DisplayMember = "Name"
		combo.ValueMember = "ID"
		combo.DropDownHeight = 200
		combo.SelectedIndex = -1
    End Sub

	Private Sub CB_SystemType_SelectedValueChanged() Handles CB_SystemType.SelectedValueChanged
		If formLoaded = false Then
			Return
		End If

		' grab the system deffinitions to determin what is enabled
		myCmd.CommandText = "SELECT * from SystemDefinition where [SystemType.id] = (Select id from SystemType WHERE name = '" & CB_SystemType.Text & "')"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count = 0 Then
			For index As Integer = 0 To MAX_BSG_SLOTS - 1
				SNOInputs(index).Enabled = True
				SNOLabels(index).Text = "Item " & (index + 1)
			Next
			MsgBox("You do not have a definition set up for this unit yet. Recomend setting one up soon.")
			Return
		End If

		For index As Integer = 0 To MAX_BSG_SLOTS - 1
			SNOInputs(index).Enabled = False
			SNOLabels(index).Text = "Item " & (index + 1)
		Next

		For Each row As DataRow In dt_results.Rows
			Select Case row("SlotNumber")
				Case ITEM_0
					SNOInputs(ITEM_0).Enabled = True
					SNOLabels(ITEM_0).Text = row("Description")
				Case ITEM_1
					SNOInputs(ITEM_1).Enabled = True
					SNOLabels(ITEM_1).Text = row("Description")
				Case ITEM_2
					SNOInputs(ITEM_2).Enabled = True
					SNOLabels(ITEM_2).Text = row("Description")
				Case ITEM_3
					SNOInputs(ITEM_3).Enabled = True
					SNOLabels(ITEM_3).Text = row("Description")
				Case ITEM_4
					SNOInputs(ITEM_4).Enabled = True
					SNOLabels(ITEM_4).Text = row("Description")
				Case Else
					MsgBox("Program is not set for Item Number:" & row("SlotNumber"))
			End Select
		Next

		My.Settings.SystemType = CB_SystemType.SelectedIndex
		My.Settings.Save()
		UpdateLB_Definitions()

		SystemSerialNumber.Focus()
	End Sub

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

    Public Function CheckMandatoryBoards() As Boolean
        'Check the slots to make sure they match our system definitions.
		For index As Integer = 0 To MAX_BSG_SLOTS - 1
			If sqlapi.BSG_CheckSystemDefinition(myCmd, CB_SystemType.SelectedValue, index, SNOInputs(index).Text.ToUpper()) = False Then
				Return False
			End If
		Next

		Return True
    End Function

End Class