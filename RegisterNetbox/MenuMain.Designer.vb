<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.Idle_Timer = New System.Windows.Forms.Timer(Me.components)
		Me.SetupButton = New System.Windows.Forms.Button()
		Me.B_Logout = New System.Windows.Forms.Button()
		Me.SearchButton = New System.Windows.Forms.Button()
		Me.ShipUnitsButton = New System.Windows.Forms.Button()
		Me.B_FinalCheckout = New System.Windows.Forms.Button()
		Me.B_BurnIn = New System.Windows.Forms.Button()
		Me.RegisterMACButton = New System.Windows.Forms.Button()
		Me.GetCPUInfoButton = New System.Windows.Forms.Button()
		Me.RegisterSystemButton = New System.Windows.Forms.Button()
		Me.B_SubAssemblyMB = New System.Windows.Forms.Button()
		Me.B_AddBoard = New System.Windows.Forms.Button()
		Me.ParametersButton = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.PrintLabel_Button = New System.Windows.Forms.Button()
		Me.RemoveBoard_Button = New System.Windows.Forms.Button()
		Me.B_SpareCPU = New System.Windows.Forms.Button()
		Me.B_HardwareVersion = New System.Windows.Forms.Button()
		Me.B_EditSystemSlots = New System.Windows.Forms.Button()
		Me.B_EditSystemDefinition = New System.Windows.Forms.Button()
		Me.B_AddSystemType = New System.Windows.Forms.Button()
		Me.AddSystemCommentButton = New System.Windows.Forms.Button()
		Me.B_EmptyMACAddress = New System.Windows.Forms.Button()
		Me.RemoveSystemButton = New System.Windows.Forms.Button()
		Me.SwapBoardsButton = New System.Windows.Forms.Button()
		Me.AddBoardCommentButton = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout
		Me.TabControl1.SuspendLayout
		Me.TabPage1.SuspendLayout
		Me.TabPage2.SuspendLayout
		Me.SuspendLayout
		'
		'Idle_Timer
		'
		Me.Idle_Timer.Interval = 20000
		'
		'SetupButton
		'
		Me.SetupButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SetupButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SetupButton.Location = New System.Drawing.Point(11, 582)
		Me.SetupButton.Margin = New System.Windows.Forms.Padding(4)
		Me.SetupButton.Name = "SetupButton"
		Me.SetupButton.Size = New System.Drawing.Size(151, 30)
		Me.SetupButton.TabIndex = 11
		Me.SetupButton.Text = "Setup"
		Me.SetupButton.UseVisualStyleBackColor = true
		'
		'B_Logout
		'
		Me.B_Logout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.B_Logout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Logout.Location = New System.Drawing.Point(11, 620)
		Me.B_Logout.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Logout.Name = "B_Logout"
		Me.B_Logout.Size = New System.Drawing.Size(151, 30)
		Me.B_Logout.TabIndex = 12
		Me.B_Logout.Text = "Logout"
		Me.B_Logout.UseVisualStyleBackColor = true
		'
		'SearchButton
		'
		Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SearchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SearchButton.Location = New System.Drawing.Point(11, 544)
		Me.SearchButton.Margin = New System.Windows.Forms.Padding(4)
		Me.SearchButton.Name = "SearchButton"
		Me.SearchButton.Size = New System.Drawing.Size(151, 30)
		Me.SearchButton.TabIndex = 9
		Me.SearchButton.Text = "Search"
		Me.SearchButton.UseVisualStyleBackColor = true
		'
		'ShipUnitsButton
		'
		Me.ShipUnitsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ShipUnitsButton.Location = New System.Drawing.Point(7, 311)
		Me.ShipUnitsButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ShipUnitsButton.Name = "ShipUnitsButton"
		Me.ShipUnitsButton.Size = New System.Drawing.Size(151, 30)
		Me.ShipUnitsButton.TabIndex = 8
		Me.ShipUnitsButton.Text = "Ship Units"
		Me.ShipUnitsButton.UseVisualStyleBackColor = true
		'
		'B_FinalCheckout
		'
		Me.B_FinalCheckout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_FinalCheckout.Location = New System.Drawing.Point(7, 273)
		Me.B_FinalCheckout.Margin = New System.Windows.Forms.Padding(4)
		Me.B_FinalCheckout.Name = "B_FinalCheckout"
		Me.B_FinalCheckout.Size = New System.Drawing.Size(151, 30)
		Me.B_FinalCheckout.TabIndex = 7
		Me.B_FinalCheckout.Text = "Final Checkout"
		Me.B_FinalCheckout.UseVisualStyleBackColor = true
		'
		'B_BurnIn
		'
		Me.B_BurnIn.Enabled = false
		Me.B_BurnIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_BurnIn.Location = New System.Drawing.Point(7, 235)
		Me.B_BurnIn.Margin = New System.Windows.Forms.Padding(4)
		Me.B_BurnIn.Name = "B_BurnIn"
		Me.B_BurnIn.Size = New System.Drawing.Size(151, 30)
		Me.B_BurnIn.TabIndex = 6
		Me.B_BurnIn.Text = "Burn In"
		Me.B_BurnIn.UseVisualStyleBackColor = true
		'
		'RegisterMACButton
		'
		Me.RegisterMACButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RegisterMACButton.Location = New System.Drawing.Point(7, 159)
		Me.RegisterMACButton.Margin = New System.Windows.Forms.Padding(4)
		Me.RegisterMACButton.Name = "RegisterMACButton"
		Me.RegisterMACButton.Size = New System.Drawing.Size(151, 30)
		Me.RegisterMACButton.TabIndex = 4
		Me.RegisterMACButton.Text = "Register MAC"
		Me.RegisterMACButton.UseVisualStyleBackColor = true
		'
		'GetCPUInfoButton
		'
		Me.GetCPUInfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GetCPUInfoButton.Location = New System.Drawing.Point(7, 121)
		Me.GetCPUInfoButton.Margin = New System.Windows.Forms.Padding(4)
		Me.GetCPUInfoButton.Name = "GetCPUInfoButton"
		Me.GetCPUInfoButton.Size = New System.Drawing.Size(151, 30)
		Me.GetCPUInfoButton.TabIndex = 3
		Me.GetCPUInfoButton.Text = "CPU Info"
		Me.GetCPUInfoButton.UseVisualStyleBackColor = true
		'
		'RegisterSystemButton
		'
		Me.RegisterSystemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RegisterSystemButton.Location = New System.Drawing.Point(7, 83)
		Me.RegisterSystemButton.Margin = New System.Windows.Forms.Padding(4)
		Me.RegisterSystemButton.Name = "RegisterSystemButton"
		Me.RegisterSystemButton.Size = New System.Drawing.Size(151, 30)
		Me.RegisterSystemButton.TabIndex = 2
		Me.RegisterSystemButton.Text = "Register System"
		Me.RegisterSystemButton.UseVisualStyleBackColor = true
		'
		'B_SubAssemblyMB
		'
		Me.B_SubAssemblyMB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_SubAssemblyMB.Enabled = false
		Me.B_SubAssemblyMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_SubAssemblyMB.Location = New System.Drawing.Point(7, 45)
		Me.B_SubAssemblyMB.Margin = New System.Windows.Forms.Padding(4)
		Me.B_SubAssemblyMB.Name = "B_SubAssemblyMB"
		Me.B_SubAssemblyMB.Size = New System.Drawing.Size(151, 30)
		Me.B_SubAssemblyMB.TabIndex = 1
		Me.B_SubAssemblyMB.Text = "S-A Motherboard"
		Me.B_SubAssemblyMB.UseVisualStyleBackColor = true
		'
		'B_AddBoard
		'
		Me.B_AddBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_AddBoard.Location = New System.Drawing.Point(7, 7)
		Me.B_AddBoard.Margin = New System.Windows.Forms.Padding(4)
		Me.B_AddBoard.Name = "B_AddBoard"
		Me.B_AddBoard.Size = New System.Drawing.Size(151, 30)
		Me.B_AddBoard.TabIndex = 0
		Me.B_AddBoard.Text = "Add Board"
		Me.B_AddBoard.UseVisualStyleBackColor = true
		'
		'ParametersButton
		'
		Me.ParametersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ParametersButton.Location = New System.Drawing.Point(7, 197)
		Me.ParametersButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ParametersButton.Name = "ParametersButton"
		Me.ParametersButton.Size = New System.Drawing.Size(151, 30)
		Me.ParametersButton.TabIndex = 5
		Me.ParametersButton.Text = "Set Parameters"
		Me.ParametersButton.UseVisualStyleBackColor = true
		'
		'Panel1
		'
		Me.Panel1.AutoScroll = true
		Me.Panel1.BackColor = System.Drawing.Color.Silver
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.TabControl1)
		Me.Panel1.Controls.Add(Me.SearchButton)
		Me.Panel1.Controls.Add(Me.SetupButton)
		Me.Panel1.Controls.Add(Me.B_Logout)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(180, 665)
		Me.Panel1.TabIndex = 1
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
		Me.TabControl1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabControl1.ItemSize = New System.Drawing.Size(96, 24)
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Multiline = true
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(176, 489)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.BackColor = System.Drawing.Color.Silver
		Me.TabPage1.Controls.Add(Me.ParametersButton)
		Me.TabPage1.Controls.Add(Me.B_AddBoard)
		Me.TabPage1.Controls.Add(Me.B_SubAssemblyMB)
		Me.TabPage1.Controls.Add(Me.RegisterSystemButton)
		Me.TabPage1.Controls.Add(Me.ShipUnitsButton)
		Me.TabPage1.Controls.Add(Me.GetCPUInfoButton)
		Me.TabPage1.Controls.Add(Me.B_FinalCheckout)
		Me.TabPage1.Controls.Add(Me.RegisterMACButton)
		Me.TabPage1.Controls.Add(Me.B_BurnIn)
		Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabPage1.Location = New System.Drawing.Point(4, 28)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(168, 433)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Steps"
		'
		'TabPage2
		'
		Me.TabPage2.BackColor = System.Drawing.Color.Silver
		Me.TabPage2.Controls.Add(Me.PrintLabel_Button)
		Me.TabPage2.Controls.Add(Me.RemoveBoard_Button)
		Me.TabPage2.Controls.Add(Me.B_SpareCPU)
		Me.TabPage2.Controls.Add(Me.B_HardwareVersion)
		Me.TabPage2.Controls.Add(Me.B_EditSystemSlots)
		Me.TabPage2.Controls.Add(Me.B_EditSystemDefinition)
		Me.TabPage2.Controls.Add(Me.B_AddSystemType)
		Me.TabPage2.Controls.Add(Me.AddSystemCommentButton)
		Me.TabPage2.Controls.Add(Me.B_EmptyMACAddress)
		Me.TabPage2.Controls.Add(Me.RemoveSystemButton)
		Me.TabPage2.Controls.Add(Me.SwapBoardsButton)
		Me.TabPage2.Controls.Add(Me.AddBoardCommentButton)
		Me.TabPage2.Location = New System.Drawing.Point(4, 28)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(168, 457)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Maintenance"
		'
		'PrintLabel_Button
		'
		Me.PrintLabel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.PrintLabel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.PrintLabel_Button.Location = New System.Drawing.Point(7, 421)
		Me.PrintLabel_Button.Name = "PrintLabel_Button"
		Me.PrintLabel_Button.Size = New System.Drawing.Size(151, 30)
		Me.PrintLabel_Button.TabIndex = 24
		Me.PrintLabel_Button.Text = "Print Label"
		Me.PrintLabel_Button.UseVisualStyleBackColor = true
		'
		'RemoveBoard_Button
		'
		Me.RemoveBoard_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.RemoveBoard_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RemoveBoard_Button.Location = New System.Drawing.Point(7, 159)
		Me.RemoveBoard_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.RemoveBoard_Button.Name = "RemoveBoard_Button"
		Me.RemoveBoard_Button.Size = New System.Drawing.Size(151, 30)
		Me.RemoveBoard_Button.TabIndex = 23
		Me.RemoveBoard_Button.Text = "Remove Board"
		Me.RemoveBoard_Button.UseVisualStyleBackColor = true
		'
		'B_SpareCPU
		'
		Me.B_SpareCPU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_SpareCPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_SpareCPU.Location = New System.Drawing.Point(7, 385)
		Me.B_SpareCPU.Name = "B_SpareCPU"
		Me.B_SpareCPU.Size = New System.Drawing.Size(151, 30)
		Me.B_SpareCPU.TabIndex = 22
		Me.B_SpareCPU.Text = "Spare CPU"
		Me.B_SpareCPU.UseVisualStyleBackColor = true
		'
		'B_HardwareVersion
		'
		Me.B_HardwareVersion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_HardwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_HardwareVersion.Location = New System.Drawing.Point(7, 349)
		Me.B_HardwareVersion.Name = "B_HardwareVersion"
		Me.B_HardwareVersion.Size = New System.Drawing.Size(151, 30)
		Me.B_HardwareVersion.TabIndex = 21
		Me.B_HardwareVersion.Text = "Hardware Versions"
		Me.B_HardwareVersion.UseVisualStyleBackColor = true
		'
		'B_EditSystemSlots
		'
		Me.B_EditSystemSlots.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_EditSystemSlots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_EditSystemSlots.Location = New System.Drawing.Point(7, 312)
		Me.B_EditSystemSlots.Margin = New System.Windows.Forms.Padding(4)
		Me.B_EditSystemSlots.Name = "B_EditSystemSlots"
		Me.B_EditSystemSlots.Size = New System.Drawing.Size(151, 30)
		Me.B_EditSystemSlots.TabIndex = 20
		Me.B_EditSystemSlots.Text = "System Slots"
		Me.B_EditSystemSlots.UseVisualStyleBackColor = true
		'
		'B_EditSystemDefinition
		'
		Me.B_EditSystemDefinition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_EditSystemDefinition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_EditSystemDefinition.Location = New System.Drawing.Point(7, 274)
		Me.B_EditSystemDefinition.Margin = New System.Windows.Forms.Padding(4)
		Me.B_EditSystemDefinition.Name = "B_EditSystemDefinition"
		Me.B_EditSystemDefinition.Size = New System.Drawing.Size(151, 30)
		Me.B_EditSystemDefinition.TabIndex = 19
		Me.B_EditSystemDefinition.Text = "System Definitions"
		Me.B_EditSystemDefinition.UseVisualStyleBackColor = true
		'
		'B_AddSystemType
		'
		Me.B_AddSystemType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_AddSystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_AddSystemType.Location = New System.Drawing.Point(7, 236)
		Me.B_AddSystemType.Margin = New System.Windows.Forms.Padding(4)
		Me.B_AddSystemType.Name = "B_AddSystemType"
		Me.B_AddSystemType.Size = New System.Drawing.Size(151, 30)
		Me.B_AddSystemType.TabIndex = 18
		Me.B_AddSystemType.Text = "Add System Type"
		Me.B_AddSystemType.UseVisualStyleBackColor = true
		'
		'AddSystemCommentButton
		'
		Me.AddSystemCommentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AddSystemCommentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.AddSystemCommentButton.Location = New System.Drawing.Point(7, 7)
		Me.AddSystemCommentButton.Margin = New System.Windows.Forms.Padding(4)
		Me.AddSystemCommentButton.Name = "AddSystemCommentButton"
		Me.AddSystemCommentButton.Size = New System.Drawing.Size(151, 30)
		Me.AddSystemCommentButton.TabIndex = 13
		Me.AddSystemCommentButton.Text = "System Comment"
		Me.AddSystemCommentButton.UseVisualStyleBackColor = true
		'
		'B_EmptyMACAddress
		'
		Me.B_EmptyMACAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_EmptyMACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_EmptyMACAddress.Location = New System.Drawing.Point(7, 198)
		Me.B_EmptyMACAddress.Margin = New System.Windows.Forms.Padding(4)
		Me.B_EmptyMACAddress.Name = "B_EmptyMACAddress"
		Me.B_EmptyMACAddress.Size = New System.Drawing.Size(151, 30)
		Me.B_EmptyMACAddress.TabIndex = 17
		Me.B_EmptyMACAddress.Text = "Empty MACs"
		Me.B_EmptyMACAddress.UseVisualStyleBackColor = true
		'
		'RemoveSystemButton
		'
		Me.RemoveSystemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.RemoveSystemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RemoveSystemButton.Location = New System.Drawing.Point(7, 121)
		Me.RemoveSystemButton.Margin = New System.Windows.Forms.Padding(4)
		Me.RemoveSystemButton.Name = "RemoveSystemButton"
		Me.RemoveSystemButton.Size = New System.Drawing.Size(151, 30)
		Me.RemoveSystemButton.TabIndex = 16
		Me.RemoveSystemButton.Text = "Remove System"
		Me.RemoveSystemButton.UseVisualStyleBackColor = true
		'
		'SwapBoardsButton
		'
		Me.SwapBoardsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SwapBoardsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SwapBoardsButton.Location = New System.Drawing.Point(7, 83)
		Me.SwapBoardsButton.Margin = New System.Windows.Forms.Padding(4)
		Me.SwapBoardsButton.Name = "SwapBoardsButton"
		Me.SwapBoardsButton.Size = New System.Drawing.Size(151, 30)
		Me.SwapBoardsButton.TabIndex = 15
		Me.SwapBoardsButton.Text = "Swap Boards"
		Me.SwapBoardsButton.UseVisualStyleBackColor = true
		'
		'AddBoardCommentButton
		'
		Me.AddBoardCommentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AddBoardCommentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.AddBoardCommentButton.Location = New System.Drawing.Point(7, 45)
		Me.AddBoardCommentButton.Margin = New System.Windows.Forms.Padding(4)
		Me.AddBoardCommentButton.Name = "AddBoardCommentButton"
		Me.AddBoardCommentButton.Size = New System.Drawing.Size(151, 30)
		Me.AddBoardCommentButton.TabIndex = 14
		Me.AddBoardCommentButton.Text = "Board Comment"
		Me.AddBoardCommentButton.UseVisualStyleBackColor = true
		'
		'MenuMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = true
		Me.BackColor = System.Drawing.Color.Silver
		Me.ClientSize = New System.Drawing.Size(1107, 665)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = true
		Me.Name = "MenuMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "NB Main Menu"
		Me.Panel1.ResumeLayout(false)
		Me.TabControl1.ResumeLayout(false)
		Me.TabPage1.ResumeLayout(false)
		Me.TabPage2.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub
    Friend WithEvents Idle_Timer As System.Windows.Forms.Timer
	Friend WithEvents SetupButton As Button
	Friend WithEvents B_Logout As Button
	Friend WithEvents SearchButton As Button
	Friend WithEvents ShipUnitsButton As Button
	Friend WithEvents B_FinalCheckout As Button
	Friend WithEvents B_BurnIn As Button
	Friend WithEvents RegisterMACButton As Button
	Friend WithEvents GetCPUInfoButton As Button
	Friend WithEvents RegisterSystemButton As Button
	Friend WithEvents B_SubAssemblyMB As Button
	Friend WithEvents B_AddBoard As Button
	Friend WithEvents ParametersButton As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents PrintLabel_Button As Button
	Friend WithEvents RemoveBoard_Button As Button
	Friend WithEvents B_SpareCPU As Button
	Friend WithEvents B_HardwareVersion As Button
	Friend WithEvents B_EditSystemSlots As Button
	Friend WithEvents B_EditSystemDefinition As Button
	Friend WithEvents B_AddSystemType As Button
	Friend WithEvents AddSystemCommentButton As Button
	Friend WithEvents B_EmptyMACAddress As Button
	Friend WithEvents RemoveSystemButton As Button
	Friend WithEvents SwapBoardsButton As Button
	Friend WithEvents AddBoardCommentButton As Button
End Class
