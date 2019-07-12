<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_RegisterSystem
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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Deffinition_DataGridView = New System.Windows.Forms.DataGridView()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.CB_SystemType = New System.Windows.Forms.ComboBox()
		Me.SystemSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Item5_Label = New System.Windows.Forms.Label()
		Me.Item4_Label = New System.Windows.Forms.Label()
		Me.Slot4SerialNumber = New System.Windows.Forms.TextBox()
		Me.Item3_Label = New System.Windows.Forms.Label()
		Me.Slot3SerialNumber = New System.Windows.Forms.TextBox()
		Me.Item2_Label = New System.Windows.Forms.Label()
		Me.Slot2SerialNumber = New System.Windows.Forms.TextBox()
		Me.Item1_Label = New System.Windows.Forms.Label()
		Me.CPUSerialNumber = New System.Windows.Forms.TextBox()
		Me.MotherboardSerialNumber = New System.Windows.Forms.TextBox()
		Me.ResultStatus = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.NextButton = New System.Windows.Forms.Button()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.ClearButton = New System.Windows.Forms.Button()
		Me.SaveButton = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Deffinition_DataGridView)
		Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(16, 116)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(276, 288)
		Me.GroupBox1.TabIndex = 15
		Me.GroupBox1.TabStop = false
		'
		'Deffinition_DataGridView
		'
		Me.Deffinition_DataGridView.AllowUserToAddRows = false
		Me.Deffinition_DataGridView.AllowUserToDeleteRows = false
		Me.Deffinition_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Deffinition_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Deffinition_DataGridView.EnableHeadersVisualStyles = false
		Me.Deffinition_DataGridView.Location = New System.Drawing.Point(3, 19)
		Me.Deffinition_DataGridView.Name = "Deffinition_DataGridView"
		Me.Deffinition_DataGridView.ReadOnly = true
		Me.Deffinition_DataGridView.Size = New System.Drawing.Size(270, 266)
		Me.Deffinition_DataGridView.TabIndex = 0
		'
		'Label11
		'
		Me.Label11.AutoSize = true
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label11.Location = New System.Drawing.Point(12, 9)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(47, 20)
		Me.Label11.TabIndex = 0
		Me.Label11.Text = "Type"
		'
		'CB_SystemType
		'
		Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_SystemType.FormattingEnabled = true
		Me.CB_SystemType.Location = New System.Drawing.Point(16, 32)
		Me.CB_SystemType.Name = "CB_SystemType"
		Me.CB_SystemType.Size = New System.Drawing.Size(273, 28)
		Me.CB_SystemType.TabIndex = 1
		'
		'SystemSerialNumber
		'
		Me.SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SystemSerialNumber.Location = New System.Drawing.Point(16, 86)
		Me.SystemSerialNumber.Name = "SystemSerialNumber"
		Me.SystemSerialNumber.Size = New System.Drawing.Size(273, 24)
		Me.SystemSerialNumber.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 63)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(186, 20)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "System Serial Number"
		'
		'Item5_Label
		'
		Me.Item5_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Item5_Label.AutoSize = true
		Me.Item5_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Item5_Label.Location = New System.Drawing.Point(298, 213)
		Me.Item5_Label.Name = "Item5_Label"
		Me.Item5_Label.Size = New System.Drawing.Size(60, 20)
		Me.Item5_Label.TabIndex = 12
		Me.Item5_Label.Text = "Item 5"
		'
		'Item4_Label
		'
		Me.Item4_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Item4_Label.AutoSize = true
		Me.Item4_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Item4_Label.Location = New System.Drawing.Point(298, 163)
		Me.Item4_Label.Name = "Item4_Label"
		Me.Item4_Label.Size = New System.Drawing.Size(60, 20)
		Me.Item4_Label.TabIndex = 10
		Me.Item4_Label.Text = "Item 4"
		'
		'Slot4SerialNumber
		'
		Me.Slot4SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot4SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot4SerialNumber.Location = New System.Drawing.Point(302, 236)
		Me.Slot4SerialNumber.Name = "Slot4SerialNumber"
		Me.Slot4SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot4SerialNumber.TabIndex = 13
		'
		'Item3_Label
		'
		Me.Item3_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Item3_Label.AutoSize = true
		Me.Item3_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Item3_Label.Location = New System.Drawing.Point(298, 113)
		Me.Item3_Label.Name = "Item3_Label"
		Me.Item3_Label.Size = New System.Drawing.Size(60, 20)
		Me.Item3_Label.TabIndex = 8
		Me.Item3_Label.Text = "Item 3"
		'
		'Slot3SerialNumber
		'
		Me.Slot3SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot3SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot3SerialNumber.Location = New System.Drawing.Point(302, 186)
		Me.Slot3SerialNumber.Name = "Slot3SerialNumber"
		Me.Slot3SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot3SerialNumber.TabIndex = 11
		'
		'Item2_Label
		'
		Me.Item2_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Item2_Label.AutoSize = true
		Me.Item2_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Item2_Label.Location = New System.Drawing.Point(298, 63)
		Me.Item2_Label.Name = "Item2_Label"
		Me.Item2_Label.Size = New System.Drawing.Size(60, 20)
		Me.Item2_Label.TabIndex = 6
		Me.Item2_Label.Text = "Item 2"
		'
		'Slot2SerialNumber
		'
		Me.Slot2SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot2SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot2SerialNumber.Location = New System.Drawing.Point(302, 136)
		Me.Slot2SerialNumber.Name = "Slot2SerialNumber"
		Me.Slot2SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot2SerialNumber.TabIndex = 9
		'
		'Item1_Label
		'
		Me.Item1_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Item1_Label.AutoSize = true
		Me.Item1_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Item1_Label.Location = New System.Drawing.Point(298, 13)
		Me.Item1_Label.Name = "Item1_Label"
		Me.Item1_Label.Size = New System.Drawing.Size(60, 20)
		Me.Item1_Label.TabIndex = 4
		Me.Item1_Label.Text = "Item 1"
		'
		'CPUSerialNumber
		'
		Me.CPUSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.CPUSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CPUSerialNumber.Location = New System.Drawing.Point(302, 86)
		Me.CPUSerialNumber.Name = "CPUSerialNumber"
		Me.CPUSerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.CPUSerialNumber.TabIndex = 7
		'
		'MotherboardSerialNumber
		'
		Me.MotherboardSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.MotherboardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.MotherboardSerialNumber.Location = New System.Drawing.Point(302, 36)
		Me.MotherboardSerialNumber.Name = "MotherboardSerialNumber"
		Me.MotherboardSerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.MotherboardSerialNumber.TabIndex = 5
		'
		'ResultStatus
		'
		Me.ResultStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ResultStatus.Location = New System.Drawing.Point(298, 286)
		Me.ResultStatus.Multiline = true
		Me.ResultStatus.Name = "ResultStatus"
		Me.ResultStatus.ReadOnly = true
		Me.ResultStatus.Size = New System.Drawing.Size(225, 118)
		Me.ResultStatus.TabIndex = 17
		Me.ResultStatus.TabStop = false
		'
		'Label7
		'
		Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = true
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label7.Location = New System.Drawing.Point(298, 263)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(119, 20)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "Result Status"
		'
		'NextButton
		'
		Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.NextButton.AutoSize = true
		Me.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.NextButton.Location = New System.Drawing.Point(89, 410)
		Me.NextButton.Name = "NextButton"
		Me.NextButton.Size = New System.Drawing.Size(115, 30)
		Me.NextButton.TabIndex = 19
		Me.NextButton.Text = "Save + Next"
		Me.NextButton.UseVisualStyleBackColor = true
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(463, 410)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 21
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'ClearButton
		'
		Me.ClearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.ClearButton.AutoSize = true
		Me.ClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ClearButton.Location = New System.Drawing.Point(228, 410)
		Me.ClearButton.Name = "ClearButton"
		Me.ClearButton.Size = New System.Drawing.Size(61, 30)
		Me.ClearButton.TabIndex = 20
		Me.ClearButton.Text = "Clear"
		Me.ClearButton.UseVisualStyleBackColor = true
		'
		'SaveButton
		'
		Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SaveButton.AutoSize = true
		Me.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SaveButton.Location = New System.Drawing.Point(16, 410)
		Me.SaveButton.Name = "SaveButton"
		Me.SaveButton.Size = New System.Drawing.Size(59, 30)
		Me.SaveButton.TabIndex = 18
		Me.SaveButton.Text = "Save"
		Me.SaveButton.UseVisualStyleBackColor = true
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 113)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(150, 20)
		Me.Label2.TabIndex = 14
		Me.Label2.Text = "System Definition"
		'
		'BSG_RegisterSystem
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(539, 452)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.NextButton)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.ClearButton)
		Me.Controls.Add(Me.SaveButton)
		Me.Controls.Add(Me.ResultStatus)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.MotherboardSerialNumber)
		Me.Controls.Add(Me.Item5_Label)
		Me.Controls.Add(Me.Item4_Label)
		Me.Controls.Add(Me.Slot4SerialNumber)
		Me.Controls.Add(Me.Item3_Label)
		Me.Controls.Add(Me.Slot3SerialNumber)
		Me.Controls.Add(Me.Item2_Label)
		Me.Controls.Add(Me.Slot2SerialNumber)
		Me.Controls.Add(Me.Item1_Label)
		Me.Controls.Add(Me.CPUSerialNumber)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.CB_SystemType)
		Me.Controls.Add(Me.SystemSerialNumber)
		Me.Controls.Add(Me.Label1)
		Me.Name = "BSG_RegisterSystem"
		Me.ShowIcon = false
		Me.Text = "BSG Register System"
		Me.GroupBox1.ResumeLayout(false)
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label11 As Label
	Friend WithEvents CB_SystemType As ComboBox
	Friend WithEvents SystemSerialNumber As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Item5_Label As Label
	Friend WithEvents Item4_Label As Label
	Friend WithEvents Slot4SerialNumber As TextBox
	Friend WithEvents Item3_Label As Label
	Friend WithEvents Slot3SerialNumber As TextBox
	Friend WithEvents Item2_Label As Label
	Friend WithEvents Slot2SerialNumber As TextBox
	Friend WithEvents Item1_Label As Label
	Friend WithEvents CPUSerialNumber As TextBox
	Friend WithEvents MotherboardSerialNumber As TextBox
	Friend WithEvents ResultStatus As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents NextButton As Button
	Friend WithEvents ExitButton As Button
	Friend WithEvents ClearButton As Button
	Friend WithEvents SaveButton As Button
	Friend WithEvents Deffinition_DataGridView As DataGridView
	Friend WithEvents Label2 As Label
End Class
