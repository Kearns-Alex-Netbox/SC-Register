<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_MenuMain
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BSG_MenuMain))
		Me.ShipUnits_Button = New System.Windows.Forms.Button()
		Me.FinalCheckout_Button = New System.Windows.Forms.Button()
		Me.SetParameters_Button = New System.Windows.Forms.Button()
		Me.RegisterMAC_Button = New System.Windows.Forms.Button()
		Me.CPUInfo_Button = New System.Windows.Forms.Button()
		Me.RegisterSystem_Button = New System.Windows.Forms.Button()
		Me.AddBoard_Button = New System.Windows.Forms.Button()
		Me.Search_Button = New System.Windows.Forms.Button()
		Me.Setup_Button = New System.Windows.Forms.Button()
		Me.Logout_Button = New System.Windows.Forms.Button()
		Me.Idle_Timer = New System.Windows.Forms.Timer(Me.components)
		Me.P_Menu = New System.Windows.Forms.Panel()
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
		Me.P_Menu.SuspendLayout
		Me.TabControl1.SuspendLayout
		Me.TabPage1.SuspendLayout
		Me.TabPage2.SuspendLayout
		Me.SuspendLayout
		'
		'ShipUnits_Button
		'
		Me.ShipUnits_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ShipUnits_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ShipUnits_Button.Location = New System.Drawing.Point(7, 235)
		Me.ShipUnits_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.ShipUnits_Button.Name = "ShipUnits_Button"
		Me.ShipUnits_Button.Size = New System.Drawing.Size(151, 30)
		Me.ShipUnits_Button.TabIndex = 6
		Me.ShipUnits_Button.Text = "Ship Units"
		Me.ShipUnits_Button.UseVisualStyleBackColor = true
		'
		'FinalCheckout_Button
		'
		Me.FinalCheckout_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.FinalCheckout_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FinalCheckout_Button.Location = New System.Drawing.Point(7, 197)
		Me.FinalCheckout_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.FinalCheckout_Button.Name = "FinalCheckout_Button"
		Me.FinalCheckout_Button.Size = New System.Drawing.Size(151, 30)
		Me.FinalCheckout_Button.TabIndex = 5
		Me.FinalCheckout_Button.Text = "Final Checkout"
		Me.FinalCheckout_Button.UseVisualStyleBackColor = true
		'
		'SetParameters_Button
		'
		Me.SetParameters_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SetParameters_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SetParameters_Button.Location = New System.Drawing.Point(7, 159)
		Me.SetParameters_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.SetParameters_Button.Name = "SetParameters_Button"
		Me.SetParameters_Button.Size = New System.Drawing.Size(151, 30)
		Me.SetParameters_Button.TabIndex = 4
		Me.SetParameters_Button.Text = "Set Parameters"
		Me.SetParameters_Button.UseVisualStyleBackColor = true
		'
		'RegisterMAC_Button
		'
		Me.RegisterMAC_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.RegisterMAC_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RegisterMAC_Button.Location = New System.Drawing.Point(7, 121)
		Me.RegisterMAC_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.RegisterMAC_Button.Name = "RegisterMAC_Button"
		Me.RegisterMAC_Button.Size = New System.Drawing.Size(151, 30)
		Me.RegisterMAC_Button.TabIndex = 3
		Me.RegisterMAC_Button.Text = "Register MAC"
		Me.RegisterMAC_Button.UseVisualStyleBackColor = true
		'
		'CPUInfo_Button
		'
		Me.CPUInfo_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.CPUInfo_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CPUInfo_Button.Location = New System.Drawing.Point(7, 83)
		Me.CPUInfo_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.CPUInfo_Button.Name = "CPUInfo_Button"
		Me.CPUInfo_Button.Size = New System.Drawing.Size(151, 30)
		Me.CPUInfo_Button.TabIndex = 2
		Me.CPUInfo_Button.Text = "CPU Info"
		Me.CPUInfo_Button.UseVisualStyleBackColor = true
		'
		'RegisterSystem_Button
		'
		Me.RegisterSystem_Button.AutoSize = true
		Me.RegisterSystem_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.RegisterSystem_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RegisterSystem_Button.Location = New System.Drawing.Point(7, 45)
		Me.RegisterSystem_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.RegisterSystem_Button.Name = "RegisterSystem_Button"
		Me.RegisterSystem_Button.Size = New System.Drawing.Size(151, 30)
		Me.RegisterSystem_Button.TabIndex = 1
		Me.RegisterSystem_Button.Text = "Register System"
		Me.RegisterSystem_Button.UseVisualStyleBackColor = true
		'
		'AddBoard_Button
		'
		Me.AddBoard_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AddBoard_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.AddBoard_Button.Location = New System.Drawing.Point(7, 7)
		Me.AddBoard_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.AddBoard_Button.Name = "AddBoard_Button"
		Me.AddBoard_Button.Size = New System.Drawing.Size(151, 30)
		Me.AddBoard_Button.TabIndex = 0
		Me.AddBoard_Button.Text = "Add Board"
		Me.AddBoard_Button.UseVisualStyleBackColor = true
		'
		'Search_Button
		'
		Me.Search_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Search_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Search_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Search_Button.Location = New System.Drawing.Point(11, 508)
		Me.Search_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Search_Button.Name = "Search_Button"
		Me.Search_Button.Size = New System.Drawing.Size(151, 30)
		Me.Search_Button.TabIndex = 7
		Me.Search_Button.Text = "Search"
		Me.Search_Button.UseVisualStyleBackColor = true
		'
		'Setup_Button
		'
		Me.Setup_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Setup_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Setup_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Setup_Button.Location = New System.Drawing.Point(11, 546)
		Me.Setup_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Setup_Button.Name = "Setup_Button"
		Me.Setup_Button.Size = New System.Drawing.Size(151, 30)
		Me.Setup_Button.TabIndex = 9
		Me.Setup_Button.Text = "Setup"
		Me.Setup_Button.UseVisualStyleBackColor = true
		'
		'Logout_Button
		'
		Me.Logout_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Logout_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Logout_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Logout_Button.Location = New System.Drawing.Point(11, 584)
		Me.Logout_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Logout_Button.Name = "Logout_Button"
		Me.Logout_Button.Size = New System.Drawing.Size(151, 30)
		Me.Logout_Button.TabIndex = 10
		Me.Logout_Button.Text = "Logout"
		Me.Logout_Button.UseVisualStyleBackColor = true
		'
		'Idle_Timer
		'
		Me.Idle_Timer.Interval = 20000
		'
		'P_Menu
		'
		Me.P_Menu.AutoScroll = true
		Me.P_Menu.BackColor = System.Drawing.Color.Silver
		Me.P_Menu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.P_Menu.Controls.Add(Me.TabControl1)
		Me.P_Menu.Controls.Add(Me.Logout_Button)
		Me.P_Menu.Controls.Add(Me.Setup_Button)
		Me.P_Menu.Controls.Add(Me.Search_Button)
		Me.P_Menu.Dock = System.Windows.Forms.DockStyle.Left
		Me.P_Menu.Location = New System.Drawing.Point(0, 0)
		Me.P_Menu.Name = "P_Menu"
		Me.P_Menu.Size = New System.Drawing.Size(180, 629)
		Me.P_Menu.TabIndex = 0
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
		Me.TabPage1.Controls.Add(Me.AddBoard_Button)
		Me.TabPage1.Controls.Add(Me.RegisterSystem_Button)
		Me.TabPage1.Controls.Add(Me.CPUInfo_Button)
		Me.TabPage1.Controls.Add(Me.RegisterMAC_Button)
		Me.TabPage1.Controls.Add(Me.ShipUnits_Button)
		Me.TabPage1.Controls.Add(Me.SetParameters_Button)
		Me.TabPage1.Controls.Add(Me.FinalCheckout_Button)
		Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabPage1.Location = New System.Drawing.Point(4, 28)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(168, 457)
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
		'BSG_MenuMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Silver
		Me.ClientSize = New System.Drawing.Size(1103, 629)
		Me.Controls.Add(Me.P_Menu)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "BSG_MenuMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "BSG Menu Main"
		Me.P_Menu.ResumeLayout(false)
		Me.TabControl1.ResumeLayout(false)
		Me.TabPage1.ResumeLayout(false)
		Me.TabPage1.PerformLayout
		Me.TabPage2.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub
	Friend WithEvents Logout_Button As Button
	Friend WithEvents Setup_Button As Button
	Friend WithEvents Search_Button As Button
	Friend WithEvents AddBoard_Button As Button
	Friend WithEvents RegisterSystem_Button As Button
	Friend WithEvents CPUInfo_Button As Button
	Friend WithEvents RegisterMAC_Button As Button
	Friend WithEvents SetParameters_Button As Button
	Friend WithEvents FinalCheckout_Button As Button
	Friend WithEvents ShipUnits_Button As Button
	Friend WithEvents Idle_Timer As Timer
	Friend WithEvents P_Menu As Panel
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
