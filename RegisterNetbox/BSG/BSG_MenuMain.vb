Public Class BSG_MenuMain
	Implements IMessageFilter

	Public Sub New()
        InitializeComponent()
        Application.AddMessageFilter(Me)
        Idle_Timer.Interval = TIMEOUT
		Idle_Timer.Enabled = True
	End Sub

#Region "Steps"

	Private Sub BSGMenuMain_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		IsMdiContainer = True
		KeyPreview = True

		Dim ctl As Control
		Dim ctlMDI As MdiClient

		' Loop through all of the form's controls looking for the control of type MdiClient.
		For Each ctl In Controls
			Try
				' Attempt to cast the control to type MdiClient.
				ctlMDI = CType(ctl, MdiClient)

				' Set the BackColor of the MdiClient control.
				ctlMDI.BackColor = BackColor
			Catch exc As InvalidCastException
				' Catch and ignore the error if casting failed.
			End Try
		Next

	End Sub

	Private Sub AddBoard_Button_Click() Handles AddBoard_Button.Click
		OpenForm(BSG_AddBoard)
	End Sub

	Public Sub RegisterSystem_Button_Click() Handles RegisterSystem_Button.Click
		OpenForm(BSG_RegisterSystem)
	End Sub

	Public Sub CPUInfo_Button_Click() Handles CPUInfo_Button.Click
		OpenForm(BSG_GetCPUinfo)
	End Sub

	Public Sub RegisterMAC_Button_Click() Handles RegisterMAC_Button.Click
		OpenForm(BSG_RegisterMAC)
	End Sub

	Private Sub SetParameters_Button_Click() Handles SetParameters_Button.Click
		If My.Settings.ParameterFolder.Length <> 0 Then
			OpenForm(BSG_SetParameters)
		Else
			MsgBox("Folders are not set up for this function. Taking you to the setup now.")
			Setup_Button_Click()
		End If
	End Sub

	Private Sub FinalCheckout_Button_Click() Handles FinalCheckout_Button.Click
		If My.Settings.TempFolder.Length <> 0 Then
			OpenForm(BSG_FinalCheckout)
		Else
			MsgBox("Folders are not set up for this function. Taking you to the setup now.")
			Setup_Button_Click()
		End If
	End Sub

	Private Sub ShipUnits_Button_Click() Handles ShipUnits_Button.Click
		OpenForm(BSG_Ship)
	End Sub

#End Region

#Region "Maintenance"

	Private Sub AddSystemCommentButton_Click() Handles AddSystemCommentButton.Click
		Dim DoAddSystemComment As New AddSystemComment()
		OpenForm(DoAddSystemComment)
	End Sub

	Private Sub AddBoardCommentButton_Click() Handles AddBoardCommentButton.Click
		Dim DoAddBoardComment As New AddBoardComment()
		OpenForm(DoAddBoardComment)
	End Sub

	Private Sub SwapBoardsButton_Click() Handles SwapBoardsButton.Click
		OpenForm(SwapBoards)
	End Sub

	Private Sub RemoveSystemButton_Click() Handles RemoveSystemButton.Click
		OpenForm(RemoveSystem)
	End Sub

	Private Sub RemoveBoard_Button_Click() Handles RemoveBoard_Button.Click
		OpenForm(RemoveBoard)
	End Sub

	Private Sub B_EmptyMACAddress_Click() Handles B_EmptyMACAddress.Click
		OpenForm(EmptyMACAddress)
	End Sub

	Private Sub B_AddSystemType_Click() Handles B_AddSystemType.Click
		OpenForm(AddSystemType)
	End Sub

	Private Sub B_EditSystemDefinition_Click() Handles B_EditSystemDefinition.Click
		OpenForm(EditSystemDefinition)
	End Sub

	Private Sub B_EditSystemSlots_Click() Handles B_EditSystemSlots.Click
		OpenForm(EditSystemSlots)
	End Sub

	Private Sub B_HardwareVersion_Click() Handles B_HardwareVersion.Click
		OpenForm(HardwareVersions)
	End Sub

	Private Sub B_SpareCPU_Click() Handles B_SpareCPU.Click
		OpenForm(SpareCPU)
	End Sub

	Private Sub PrintLabel_Button_Click() Handles PrintLabel_Button.Click
		OpenForm(PrintLabels)
	End Sub

#End Region

#Region "Always show"

	Private Sub Search_Button_Click() Handles Search_Button.Click
		If My.Settings.SearchFolder.Length <> 0 Then
			OpenForm(Search)
		Else
			MsgBox("Settings not set. Taking you to the setup window.")
			Setup_Button_Click()
		End If
	End Sub

	Private Sub Setup_Button_Click() Handles Setup_Button.Click
		OpenForm(Setup)
	End Sub

	Private Sub Logout_Button_Click() Handles Logout_Button.Click
		Idle_Timer.Stop()
		Idle_Timer.Enabled = False
		Dim DoLogin As New Login
		DoLogin.Show()
		Close()
	End Sub

#End Region

#Region "Extra Tools"

	Public Function OpenForm(ByRef thisForm As Form) As Boolean
		Dim indexOfMenu As Integer = 0

		Dim frmCollection = Application.OpenForms
		For i = 0 To frmCollection.Count - 1
			If frmCollection.Item(i).Name = thisForm.Name Then
				frmCollection.Item(i).Activate()
				Return True
			End If
			If frmCollection.Item(i).Name = Name Then
				indexOfMenu = i
			End If
		Next i
		thisForm.StartPosition = FormStartPosition.Manual
		thisForm.Left = 0
		thisForm.Top = 0
		thisForm.MdiParent = frmCollection.Item(indexOfMenu)
		thisForm.Show()
		thisForm.BringToFront()

		Return True
	End Function

	Public Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
		If e.Control AndAlso e.KeyCode = Keys.S
			Search_Button_Click()

		Else If Keys.D1
			'----- TESTING ----- TESTING ----- TESTING ----- TESTING ----- TESTING ----- TESTING ----- TESTING -----'
			If sqlapi._Username = "akearns" Then

			End If

		Else If Keys.D2

		End If
	End Sub

	Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        'Retrigger timer on keyboard and mouse messages
        If Idle_Timer.Enabled = True Then
            If (m.Msg >= &H100 And m.Msg <= &H109) Or (m.Msg >= &H200 And m.Msg <= &H20E) Then
                Idle_Timer.Stop()
                Idle_Timer.Start()
            End If
        End If
    End Function

    Private Sub Idle_Timer_Tick() Handles Idle_Timer.Tick
        Idle_Timer.Stop()
		Idle_Timer.Enabled = False
		Dim result As String = ""
		Try
			If sqlapi.CloseDatabase(myConn, result) = False Then
				MsgBox(result)
				End
			End If
		Catch ex As Exception

		End Try
		Dim DoLogin As New Login
        DoLogin.Show()
    End Sub

#End Region


End Class