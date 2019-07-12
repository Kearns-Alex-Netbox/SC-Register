<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_Ship
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
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.UpdateButton = New System.Windows.Forms.Button()
		Me.SerialNo = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.B_Clear = New System.Windows.Forms.Button()
		Me.CB_ShipOption = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Queue_Label = New System.Windows.Forms.Label()
		Me.Queue_ListBox = New System.Windows.Forms.ListBox()
		Me.B_ClearQueue = New System.Windows.Forms.Button()
		Me.Boxes_DataGridView = New System.Windows.Forms.DataGridView()
		Me.TextFile_Label = New System.Windows.Forms.Label()
		Me.PreShip_Button = New System.Windows.Forms.Button()
		Me.Log_RichTextBox = New System.Windows.Forms.RichTextBox()
		Me.ShipQty_Label = New System.Windows.Forms.Label()
		Me.Print_CheckBox = New System.Windows.Forms.CheckBox()
		Me.PerBox_Label = New System.Windows.Forms.Label()
		Me.Date_DTP = New System.Windows.Forms.DateTimePicker()
		Me.PerBox_NUD = New System.Windows.Forms.NumericUpDown()
		Me.Ship_NUD = New System.Windows.Forms.NumericUpDown()
		CType(Me.Boxes_DataGridView,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.PerBox_NUD,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.Ship_NUD,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(822, 440)
		Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 19
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'UpdateButton
		'
		Me.UpdateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.UpdateButton.AutoSize = true
		Me.UpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.UpdateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.UpdateButton.Location = New System.Drawing.Point(213, 440)
		Me.UpdateButton.Margin = New System.Windows.Forms.Padding(4)
		Me.UpdateButton.Name = "UpdateButton"
		Me.UpdateButton.Size = New System.Drawing.Size(78, 30)
		Me.UpdateButton.TabIndex = 14
		Me.UpdateButton.Text = "Update"
		Me.UpdateButton.UseVisualStyleBackColor = true
		'
		'SerialNo
		'
		Me.SerialNo.Font = New System.Drawing.Font("Consolas", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SerialNo.Location = New System.Drawing.Point(17, 80)
		Me.SerialNo.Margin = New System.Windows.Forms.Padding(4)
		Me.SerialNo.Name = "SerialNo"
		Me.SerialNo.Size = New System.Drawing.Size(274, 26)
		Me.SerialNo.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(13, 57)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(122, 20)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Serial Number"
		'
		'B_Clear
		'
		Me.B_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.B_Clear.AutoSize = true
		Me.B_Clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Clear.Location = New System.Drawing.Point(718, 440)
		Me.B_Clear.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Clear.Name = "B_Clear"
		Me.B_Clear.Size = New System.Drawing.Size(96, 30)
		Me.B_Clear.TabIndex = 18
		Me.B_Clear.Text = "Clear Log"
		Me.B_Clear.UseVisualStyleBackColor = true
		'
		'CB_ShipOption
		'
		Me.CB_ShipOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_ShipOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_ShipOption.FormattingEnabled = true
		Me.CB_ShipOption.Location = New System.Drawing.Point(17, 31)
		Me.CB_ShipOption.Name = "CB_ShipOption"
		Me.CB_ShipOption.Size = New System.Drawing.Size(274, 26)
		Me.CB_ShipOption.TabIndex = 1
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(13, 9)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(71, 20)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Ship to:"
		'
		'Queue_Label
		'
		Me.Queue_Label.AutoSize = true
		Me.Queue_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Queue_Label.Location = New System.Drawing.Point(13, 116)
		Me.Queue_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Queue_Label.Name = "Queue_Label"
		Me.Queue_Label.Size = New System.Drawing.Size(62, 20)
		Me.Queue_Label.TabIndex = 5
		Me.Queue_Label.Text = "Queue"
		'
		'Queue_ListBox
		'
		Me.Queue_ListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Queue_ListBox.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Queue_ListBox.FormattingEnabled = true
		Me.Queue_ListBox.HorizontalScrollbar = true
		Me.Queue_ListBox.ItemHeight = 18
		Me.Queue_ListBox.Location = New System.Drawing.Point(17, 145)
		Me.Queue_ListBox.Name = "Queue_ListBox"
		Me.Queue_ListBox.ScrollAlwaysVisible = true
		Me.Queue_ListBox.Size = New System.Drawing.Size(274, 256)
		Me.Queue_ListBox.TabIndex = 6
		Me.Queue_ListBox.TabStop = false
		'
		'B_ClearQueue
		'
		Me.B_ClearQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.B_ClearQueue.AutoSize = true
		Me.B_ClearQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_ClearQueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_ClearQueue.Location = New System.Drawing.Point(112, 440)
		Me.B_ClearQueue.Margin = New System.Windows.Forms.Padding(4)
		Me.B_ClearQueue.Name = "B_ClearQueue"
		Me.B_ClearQueue.Size = New System.Drawing.Size(61, 30)
		Me.B_ClearQueue.TabIndex = 13
		Me.B_ClearQueue.Text = "Clear"
		Me.B_ClearQueue.UseVisualStyleBackColor = true
		'
		'Boxes_DataGridView
		'
		Me.Boxes_DataGridView.AllowUserToAddRows = false
		Me.Boxes_DataGridView.AllowUserToOrderColumns = true
		Me.Boxes_DataGridView.AllowUserToResizeRows = false
		Me.Boxes_DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Boxes_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.Boxes_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.Boxes_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Boxes_DataGridView.Location = New System.Drawing.Point(298, 13)
		Me.Boxes_DataGridView.Name = "Boxes_DataGridView"
		Me.Boxes_DataGridView.RowHeadersVisible = false
		Me.Boxes_DataGridView.Size = New System.Drawing.Size(190, 420)
		Me.Boxes_DataGridView.TabIndex = 16
		'
		'TextFile_Label
		'
		Me.TextFile_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.TextFile_Label.AutoSize = true
		Me.TextFile_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TextFile_Label.Location = New System.Drawing.Point(299, 445)
		Me.TextFile_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.TextFile_Label.Name = "TextFile_Label"
		Me.TextFile_Label.Size = New System.Drawing.Size(118, 20)
		Me.TextFile_Label.TabIndex = 15
		Me.TextFile_Label.Text = "Ship Text file:"
		'
		'PreShip_Button
		'
		Me.PreShip_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.PreShip_Button.AutoSize = true
		Me.PreShip_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.PreShip_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.PreShip_Button.Location = New System.Drawing.Point(17, 440)
		Me.PreShip_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.PreShip_Button.Name = "PreShip_Button"
		Me.PreShip_Button.Size = New System.Drawing.Size(87, 30)
		Me.PreShip_Button.TabIndex = 12
		Me.PreShip_Button.Text = "Pre Ship"
		Me.PreShip_Button.UseVisualStyleBackColor = true
		'
		'Log_RichTextBox
		'
		Me.Log_RichTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Log_RichTextBox.Font = New System.Drawing.Font("Consolas", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Log_RichTextBox.Location = New System.Drawing.Point(494, 13)
		Me.Log_RichTextBox.Name = "Log_RichTextBox"
		Me.Log_RichTextBox.ReadOnly = true
		Me.Log_RichTextBox.Size = New System.Drawing.Size(392, 420)
		Me.Log_RichTextBox.TabIndex = 17
		Me.Log_RichTextBox.Text = ""
		'
		'ShipQty_Label
		'
		Me.ShipQty_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.ShipQty_Label.AutoSize = true
		Me.ShipQty_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ShipQty_Label.Location = New System.Drawing.Point(222, 414)
		Me.ShipQty_Label.Name = "ShipQty_Label"
		Me.ShipQty_Label.Size = New System.Drawing.Size(70, 13)
		Me.ShipQty_Label.TabIndex = 11
		Me.ShipQty_Label.Text = "Ship Quantity"
		'
		'Print_CheckBox
		'
		Me.Print_CheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Print_CheckBox.AutoSize = true
		Me.Print_CheckBox.Location = New System.Drawing.Point(118, 412)
		Me.Print_CheckBox.Name = "Print_CheckBox"
		Me.Print_CheckBox.Size = New System.Drawing.Size(47, 17)
		Me.Print_CheckBox.TabIndex = 9
		Me.Print_CheckBox.Text = "Print"
		Me.Print_CheckBox.UseVisualStyleBackColor = true
		'
		'PerBox_Label
		'
		Me.PerBox_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.PerBox_Label.AutoSize = true
		Me.PerBox_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.PerBox_Label.Location = New System.Drawing.Point(68, 414)
		Me.PerBox_Label.Name = "PerBox_Label"
		Me.PerBox_Label.Size = New System.Drawing.Size(44, 13)
		Me.PerBox_Label.TabIndex = 8
		Me.PerBox_Label.Text = "Per Box"
		'
		'Date_DTP
		'
		Me.Date_DTP.CalendarFont = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Date_DTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Date_DTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.Date_DTP.Location = New System.Drawing.Point(171, 113)
		Me.Date_DTP.Name = "Date_DTP"
		Me.Date_DTP.Size = New System.Drawing.Size(120, 26)
		Me.Date_DTP.TabIndex = 4
		Me.Date_DTP.Value = New Date(2019, 4, 16, 0, 0, 0, 0)
		'
		'PerBox_NUD
		'
		Me.PerBox_NUD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.PerBox_NUD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.PerBox_NUD.Location = New System.Drawing.Point(17, 407)
		Me.PerBox_NUD.Name = "PerBox_NUD"
		Me.PerBox_NUD.Size = New System.Drawing.Size(45, 26)
		Me.PerBox_NUD.TabIndex = 7
		'
		'Ship_NUD
		'
		Me.Ship_NUD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Ship_NUD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Ship_NUD.Location = New System.Drawing.Point(171, 407)
		Me.Ship_NUD.Name = "Ship_NUD"
		Me.Ship_NUD.Size = New System.Drawing.Size(45, 26)
		Me.Ship_NUD.TabIndex = 10
		'
		'BSG_Ship
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = true
		Me.ClientSize = New System.Drawing.Size(899, 475)
		Me.Controls.Add(Me.Ship_NUD)
		Me.Controls.Add(Me.PerBox_NUD)
		Me.Controls.Add(Me.Date_DTP)
		Me.Controls.Add(Me.PerBox_Label)
		Me.Controls.Add(Me.Print_CheckBox)
		Me.Controls.Add(Me.ShipQty_Label)
		Me.Controls.Add(Me.Log_RichTextBox)
		Me.Controls.Add(Me.PreShip_Button)
		Me.Controls.Add(Me.TextFile_Label)
		Me.Controls.Add(Me.Boxes_DataGridView)
		Me.Controls.Add(Me.B_ClearQueue)
		Me.Controls.Add(Me.Queue_Label)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.CB_ShipOption)
		Me.Controls.Add(Me.B_Clear)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.UpdateButton)
		Me.Controls.Add(Me.SerialNo)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Queue_ListBox)
		Me.KeyPreview = true
		Me.Name = "BSG_Ship"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Ship"
		CType(Me.Boxes_DataGridView,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.PerBox_NUD,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.Ship_NUD,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents SerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents B_Clear As System.Windows.Forms.Button
	Friend WithEvents CB_ShipOption As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Queue_Label As System.Windows.Forms.Label
    Friend WithEvents Queue_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents B_ClearQueue As System.Windows.Forms.Button
	Friend WithEvents Boxes_DataGridView As DataGridView
	Friend WithEvents TextFile_Label As Label
	Friend WithEvents PreShip_Button As Button
	Friend WithEvents Log_RichTextBox As RichTextBox
	Friend WithEvents ShipQty_Label As Label
	Friend WithEvents Print_CheckBox As CheckBox
	Friend WithEvents PerBox_Label As Label
	Friend WithEvents Date_DTP As DateTimePicker
	Friend WithEvents PerBox_NUD As NumericUpDown
	Friend WithEvents Ship_NUD As NumericUpDown
End Class
