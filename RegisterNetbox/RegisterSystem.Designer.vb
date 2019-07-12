<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterSystem
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SystemSerialNumber = New System.Windows.Forms.TextBox()
		Me.Motherboard_Label = New System.Windows.Forms.Label()
		Me.MotherboardSerialNumber = New System.Windows.Forms.TextBox()
		Me.CPUSerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot1_Label = New System.Windows.Forms.Label()
		Me.Slot2_Label = New System.Windows.Forms.Label()
		Me.Slot2SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot3_Label = New System.Windows.Forms.Label()
		Me.Slot3SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot4_Label = New System.Windows.Forms.Label()
		Me.Slot4SerialNumber = New System.Windows.Forms.TextBox()
		Me.SaveButton = New System.Windows.Forms.Button()
		Me.ClearButton = New System.Windows.Forms.Button()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Slot5_Label = New System.Windows.Forms.Label()
		Me.Slot5SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot6_Label = New System.Windows.Forms.Label()
		Me.Slot6SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot7_Label = New System.Windows.Forms.Label()
		Me.Slot7SerialNumber = New System.Windows.Forms.TextBox()
		Me.NextButton = New System.Windows.Forms.Button()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.CB_SystemType = New System.Windows.Forms.ComboBox()
		Me.ResultStatus = New System.Windows.Forms.TextBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Deffinition_DataGridView = New System.Windows.Forms.DataGridView()
		Me.Keyboard_Label = New System.Windows.Forms.Label()
		Me.Slot8SerialNumber = New System.Windows.Forms.TextBox()
		Me.LCD_Label = New System.Windows.Forms.Label()
		Me.Slot9SerialNumber = New System.Windows.Forms.TextBox()
		Me.LCDdriver_Label = New System.Windows.Forms.Label()
		Me.Slot10SerialNumber = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 59)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(186, 20)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "System Serial Number"
		'
		'SystemSerialNumber
		'
		Me.SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SystemSerialNumber.Location = New System.Drawing.Point(16, 82)
		Me.SystemSerialNumber.Name = "SystemSerialNumber"
		Me.SystemSerialNumber.Size = New System.Drawing.Size(273, 24)
		Me.SystemSerialNumber.TabIndex = 1
		'
		'Motherboard_Label
		'
		Me.Motherboard_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Motherboard_Label.AutoSize = true
		Me.Motherboard_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Motherboard_Label.Location = New System.Drawing.Point(302, 155)
		Me.Motherboard_Label.Name = "Motherboard_Label"
		Me.Motherboard_Label.Size = New System.Drawing.Size(229, 20)
		Me.Motherboard_Label.TabIndex = 8
		Me.Motherboard_Label.Text = "Motherboard Serial Number"
		'
		'MotherboardSerialNumber
		'
		Me.MotherboardSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.MotherboardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.MotherboardSerialNumber.Location = New System.Drawing.Point(302, 178)
		Me.MotherboardSerialNumber.Name = "MotherboardSerialNumber"
		Me.MotherboardSerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.MotherboardSerialNumber.TabIndex = 9
		'
		'CPUSerialNumber
		'
		Me.CPUSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.CPUSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CPUSerialNumber.Location = New System.Drawing.Point(302, 228)
		Me.CPUSerialNumber.Name = "CPUSerialNumber"
		Me.CPUSerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.CPUSerialNumber.TabIndex = 11
		'
		'Slot1_Label
		'
		Me.Slot1_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot1_Label.AutoSize = true
		Me.Slot1_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot1_Label.Location = New System.Drawing.Point(302, 205)
		Me.Slot1_Label.Name = "Slot1_Label"
		Me.Slot1_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot1_Label.TabIndex = 10
		Me.Slot1_Label.Text = "Slot 1 Serial Number"
		'
		'Slot2_Label
		'
		Me.Slot2_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot2_Label.AutoSize = true
		Me.Slot2_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot2_Label.Location = New System.Drawing.Point(302, 255)
		Me.Slot2_Label.Name = "Slot2_Label"
		Me.Slot2_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot2_Label.TabIndex = 12
		Me.Slot2_Label.Text = "Slot 2 Serial Number"
		'
		'Slot2SerialNumber
		'
		Me.Slot2SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot2SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot2SerialNumber.Location = New System.Drawing.Point(302, 278)
		Me.Slot2SerialNumber.Name = "Slot2SerialNumber"
		Me.Slot2SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot2SerialNumber.TabIndex = 13
		'
		'Slot3_Label
		'
		Me.Slot3_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot3_Label.AutoSize = true
		Me.Slot3_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot3_Label.Location = New System.Drawing.Point(302, 305)
		Me.Slot3_Label.Name = "Slot3_Label"
		Me.Slot3_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot3_Label.TabIndex = 14
		Me.Slot3_Label.Text = "Slot 3 Serial Number"
		'
		'Slot3SerialNumber
		'
		Me.Slot3SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot3SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot3SerialNumber.Location = New System.Drawing.Point(302, 328)
		Me.Slot3SerialNumber.Name = "Slot3SerialNumber"
		Me.Slot3SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot3SerialNumber.TabIndex = 15
		'
		'Slot4_Label
		'
		Me.Slot4_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot4_Label.AutoSize = true
		Me.Slot4_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot4_Label.Location = New System.Drawing.Point(302, 355)
		Me.Slot4_Label.Name = "Slot4_Label"
		Me.Slot4_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot4_Label.TabIndex = 16
		Me.Slot4_Label.Text = "Slot 4 Serial Number"
		'
		'Slot4SerialNumber
		'
		Me.Slot4SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot4SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot4SerialNumber.Location = New System.Drawing.Point(302, 378)
		Me.Slot4SerialNumber.Name = "Slot4SerialNumber"
		Me.Slot4SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot4SerialNumber.TabIndex = 17
		'
		'SaveButton
		'
		Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SaveButton.AutoSize = true
		Me.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SaveButton.Location = New System.Drawing.Point(16, 559)
		Me.SaveButton.Name = "SaveButton"
		Me.SaveButton.Size = New System.Drawing.Size(59, 30)
		Me.SaveButton.TabIndex = 26
		Me.SaveButton.Text = "Save"
		Me.SaveButton.UseVisualStyleBackColor = true
		'
		'ClearButton
		'
		Me.ClearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.ClearButton.AutoSize = true
		Me.ClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ClearButton.Location = New System.Drawing.Point(235, 559)
		Me.ClearButton.Name = "ClearButton"
		Me.ClearButton.Size = New System.Drawing.Size(61, 30)
		Me.ClearButton.TabIndex = 28
		Me.ClearButton.Text = "Clear"
		Me.ClearButton.UseVisualStyleBackColor = true
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(461, 559)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 29
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'Label7
		'
		Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = true
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label7.Location = New System.Drawing.Point(12, 469)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(119, 20)
		Me.Label7.TabIndex = 31
		Me.Label7.Text = "Result Status"
		'
		'Slot5_Label
		'
		Me.Slot5_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot5_Label.AutoSize = true
		Me.Slot5_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot5_Label.Location = New System.Drawing.Point(302, 405)
		Me.Slot5_Label.Name = "Slot5_Label"
		Me.Slot5_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot5_Label.TabIndex = 18
		Me.Slot5_Label.Text = "Slot 5 Serial Number"
		'
		'Slot5SerialNumber
		'
		Me.Slot5SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot5SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot5SerialNumber.Location = New System.Drawing.Point(302, 428)
		Me.Slot5SerialNumber.Name = "Slot5SerialNumber"
		Me.Slot5SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot5SerialNumber.TabIndex = 19
		'
		'Slot6_Label
		'
		Me.Slot6_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot6_Label.AutoSize = true
		Me.Slot6_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot6_Label.Location = New System.Drawing.Point(302, 455)
		Me.Slot6_Label.Name = "Slot6_Label"
		Me.Slot6_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot6_Label.TabIndex = 20
		Me.Slot6_Label.Text = "Slot 6 Serial Number"
		'
		'Slot6SerialNumber
		'
		Me.Slot6SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot6SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot6SerialNumber.Location = New System.Drawing.Point(302, 478)
		Me.Slot6SerialNumber.Name = "Slot6SerialNumber"
		Me.Slot6SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot6SerialNumber.TabIndex = 21
		'
		'Slot7_Label
		'
		Me.Slot7_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot7_Label.AutoSize = true
		Me.Slot7_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot7_Label.Location = New System.Drawing.Point(302, 505)
		Me.Slot7_Label.Name = "Slot7_Label"
		Me.Slot7_Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot7_Label.TabIndex = 22
		Me.Slot7_Label.Text = "Slot 7 Serial Number"
		'
		'Slot7SerialNumber
		'
		Me.Slot7SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot7SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot7SerialNumber.Location = New System.Drawing.Point(302, 528)
		Me.Slot7SerialNumber.Name = "Slot7SerialNumber"
		Me.Slot7SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot7SerialNumber.TabIndex = 23
		'
		'NextButton
		'
		Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.NextButton.AutoSize = true
		Me.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.NextButton.Location = New System.Drawing.Point(81, 559)
		Me.NextButton.Name = "NextButton"
		Me.NextButton.Size = New System.Drawing.Size(115, 30)
		Me.NextButton.TabIndex = 27
		Me.NextButton.Text = "Save + Next"
		Me.NextButton.UseVisualStyleBackColor = true
		'
		'Label11
		'
		Me.Label11.AutoSize = true
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label11.Location = New System.Drawing.Point(12, 5)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(47, 20)
		Me.Label11.TabIndex = 24
		Me.Label11.Text = "Type"
		'
		'CB_SystemType
		'
		Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_SystemType.FormattingEnabled = true
		Me.CB_SystemType.Location = New System.Drawing.Point(16, 28)
		Me.CB_SystemType.Name = "CB_SystemType"
		Me.CB_SystemType.Size = New System.Drawing.Size(273, 28)
		Me.CB_SystemType.TabIndex = 25
		'
		'ResultStatus
		'
		Me.ResultStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ResultStatus.Location = New System.Drawing.Point(16, 492)
		Me.ResultStatus.Multiline = true
		Me.ResultStatus.Name = "ResultStatus"
		Me.ResultStatus.ReadOnly = true
		Me.ResultStatus.Size = New System.Drawing.Size(280, 61)
		Me.ResultStatus.TabIndex = 32
		Me.ResultStatus.TabStop = false
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Deffinition_DataGridView)
		Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(16, 112)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(280, 353)
		Me.GroupBox1.TabIndex = 30
		Me.GroupBox1.TabStop = false
		'
		'Deffinition_DataGridView
		'
		Me.Deffinition_DataGridView.AllowUserToAddRows = false
		Me.Deffinition_DataGridView.AllowUserToDeleteRows = false
		Me.Deffinition_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Deffinition_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Deffinition_DataGridView.Location = New System.Drawing.Point(3, 19)
		Me.Deffinition_DataGridView.Name = "Deffinition_DataGridView"
		Me.Deffinition_DataGridView.ReadOnly = true
		Me.Deffinition_DataGridView.Size = New System.Drawing.Size(274, 331)
		Me.Deffinition_DataGridView.TabIndex = 1
		'
		'Keyboard_Label
		'
		Me.Keyboard_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Keyboard_Label.AutoSize = true
		Me.Keyboard_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Keyboard_Label.Location = New System.Drawing.Point(302, 5)
		Me.Keyboard_Label.Name = "Keyboard_Label"
		Me.Keyboard_Label.Size = New System.Drawing.Size(202, 20)
		Me.Keyboard_Label.TabIndex = 2
		Me.Keyboard_Label.Text = "Keyboard Serial Number"
		'
		'Slot8SerialNumber
		'
		Me.Slot8SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot8SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot8SerialNumber.Location = New System.Drawing.Point(302, 28)
		Me.Slot8SerialNumber.Name = "Slot8SerialNumber"
		Me.Slot8SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot8SerialNumber.TabIndex = 3
		'
		'LCD_Label
		'
		Me.LCD_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.LCD_Label.AutoSize = true
		Me.LCD_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.LCD_Label.Location = New System.Drawing.Point(302, 55)
		Me.LCD_Label.Name = "LCD_Label"
		Me.LCD_Label.Size = New System.Drawing.Size(162, 20)
		Me.LCD_Label.TabIndex = 4
		Me.LCD_Label.Text = "LCD Serial Number"
		'
		'Slot9SerialNumber
		'
		Me.Slot9SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot9SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot9SerialNumber.Location = New System.Drawing.Point(302, 78)
		Me.Slot9SerialNumber.Name = "Slot9SerialNumber"
		Me.Slot9SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot9SerialNumber.TabIndex = 5
		'
		'LCDdriver_Label
		'
		Me.LCDdriver_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.LCDdriver_Label.AutoSize = true
		Me.LCDdriver_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.LCDdriver_Label.Location = New System.Drawing.Point(302, 105)
		Me.LCDdriver_Label.Name = "LCDdriver_Label"
		Me.LCDdriver_Label.Size = New System.Drawing.Size(214, 20)
		Me.LCDdriver_Label.TabIndex = 6
		Me.LCDdriver_Label.Text = "LCD Driver Serial Number"
		'
		'Slot10SerialNumber
		'
		Me.Slot10SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Slot10SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Slot10SerialNumber.Location = New System.Drawing.Point(302, 128)
		Me.Slot10SerialNumber.Name = "Slot10SerialNumber"
		Me.Slot10SerialNumber.Size = New System.Drawing.Size(225, 24)
		Me.Slot10SerialNumber.TabIndex = 7
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 109)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(150, 20)
		Me.Label2.TabIndex = 53
		Me.Label2.Text = "System Definition"
		'
		'RegisterSystem
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = true
		Me.ClientSize = New System.Drawing.Size(539, 596)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.LCDdriver_Label)
		Me.Controls.Add(Me.Slot10SerialNumber)
		Me.Controls.Add(Me.LCD_Label)
		Me.Controls.Add(Me.Slot9SerialNumber)
		Me.Controls.Add(Me.Keyboard_Label)
		Me.Controls.Add(Me.Slot8SerialNumber)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.ResultStatus)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.CB_SystemType)
		Me.Controls.Add(Me.NextButton)
		Me.Controls.Add(Me.Slot7_Label)
		Me.Controls.Add(Me.Slot7SerialNumber)
		Me.Controls.Add(Me.Slot6_Label)
		Me.Controls.Add(Me.Slot6SerialNumber)
		Me.Controls.Add(Me.Slot5_Label)
		Me.Controls.Add(Me.Slot5SerialNumber)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.ClearButton)
		Me.Controls.Add(Me.SaveButton)
		Me.Controls.Add(Me.Slot4_Label)
		Me.Controls.Add(Me.Slot4SerialNumber)
		Me.Controls.Add(Me.Slot3_Label)
		Me.Controls.Add(Me.Slot3SerialNumber)
		Me.Controls.Add(Me.Slot2_Label)
		Me.Controls.Add(Me.Slot2SerialNumber)
		Me.Controls.Add(Me.Slot1_Label)
		Me.Controls.Add(Me.CPUSerialNumber)
		Me.Controls.Add(Me.MotherboardSerialNumber)
		Me.Controls.Add(Me.Motherboard_Label)
		Me.Controls.Add(Me.SystemSerialNumber)
		Me.Controls.Add(Me.Label1)
		Me.KeyPreview = true
		Me.Name = "RegisterSystem"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Register System"
		Me.GroupBox1.ResumeLayout(false)
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents SystemSerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Motherboard_Label As System.Windows.Forms.Label
	Friend WithEvents MotherboardSerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents CPUSerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Slot1_Label As System.Windows.Forms.Label
	Friend WithEvents Slot2_Label As System.Windows.Forms.Label
	Friend WithEvents Slot2SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Slot3_Label As System.Windows.Forms.Label
	Friend WithEvents Slot3SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Slot4_Label As System.Windows.Forms.Label
	Friend WithEvents Slot4SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents SaveButton As System.Windows.Forms.Button
	Friend WithEvents ClearButton As System.Windows.Forms.Button
	Friend WithEvents ExitButton As System.Windows.Forms.Button
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Slot5_Label As System.Windows.Forms.Label
	Friend WithEvents Slot5SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Slot6_Label As System.Windows.Forms.Label
	Friend WithEvents Slot6SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents Slot7_Label As System.Windows.Forms.Label
	Friend WithEvents Slot7SerialNumber As System.Windows.Forms.TextBox
	Friend WithEvents NextButton As System.Windows.Forms.Button
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents CB_SystemType As System.Windows.Forms.ComboBox
	Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents Keyboard_Label As Label
	Friend WithEvents Slot8SerialNumber As TextBox
	Friend WithEvents LCD_Label As Label
	Friend WithEvents Slot9SerialNumber As TextBox
	Friend WithEvents LCDdriver_Label As Label
	Friend WithEvents Slot10SerialNumber As TextBox
	Friend WithEvents Deffinition_DataGridView As DataGridView
	Friend WithEvents Label2 As Label
End Class
