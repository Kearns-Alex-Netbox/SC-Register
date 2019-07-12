<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSystemDefinition
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
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.B_Close = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.TB_Result = New System.Windows.Forms.TextBox()
		Me.B_Add = New System.Windows.Forms.Button()
		Me.CB_SystemType = New System.Windows.Forms.ComboBox()
		Me.CB_BoardType = New System.Windows.Forms.ComboBox()
		Me.ChB_Mandatory = New System.Windows.Forms.CheckBox()
		Me.CB_Slot = New System.Windows.Forms.ComboBox()
		Me.B_Remove = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Description_TextBox = New System.Windows.Forms.TextBox()
		Me.Deffinition_DataGridView = New System.Windows.Forms.DataGridView()
		Me.GroupBox1.SuspendLayout
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'B_Close
		'
		Me.B_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.B_Close.AutoSize = true
		Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Close.Location = New System.Drawing.Point(663, 323)
		Me.B_Close.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Close.Name = "B_Close"
		Me.B_Close.Size = New System.Drawing.Size(64, 30)
		Me.B_Close.TabIndex = 6
		Me.B_Close.Text = "Close"
		Me.B_Close.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(119, 24)
		Me.Label1.TabIndex = 8
		Me.Label1.Text = "System Type"
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 112)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(108, 24)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "Board Type"
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 46)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(119, 24)
		Me.Label3.TabIndex = 10
		Me.Label3.Text = "Item Number"
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(12, 143)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(88, 24)
		Me.Label4.TabIndex = 11
		Me.Label4.Text = "Required"
		'
		'TB_Result
		'
		Me.TB_Result.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.TB_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_Result.Location = New System.Drawing.Point(16, 178)
		Me.TB_Result.Multiline = true
		Me.TB_Result.Name = "TB_Result"
		Me.TB_Result.ReadOnly = true
		Me.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.TB_Result.Size = New System.Drawing.Size(326, 138)
		Me.TB_Result.TabIndex = 13
		Me.TB_Result.TabStop = false
		'
		'B_Add
		'
		Me.B_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.B_Add.AutoSize = true
		Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Add.Location = New System.Drawing.Point(199, 323)
		Me.B_Add.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Add.Name = "B_Add"
		Me.B_Add.Size = New System.Drawing.Size(51, 30)
		Me.B_Add.TabIndex = 4
		Me.B_Add.Text = "Add"
		Me.B_Add.UseVisualStyleBackColor = true
		'
		'CB_SystemType
		'
		Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_SystemType.FormattingEnabled = true
		Me.CB_SystemType.Location = New System.Drawing.Point(137, 12)
		Me.CB_SystemType.Name = "CB_SystemType"
		Me.CB_SystemType.Size = New System.Drawing.Size(205, 28)
		Me.CB_SystemType.TabIndex = 0
		'
		'CB_BoardType
		'
		Me.CB_BoardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_BoardType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_BoardType.FormattingEnabled = true
		Me.CB_BoardType.Location = New System.Drawing.Point(137, 112)
		Me.CB_BoardType.Name = "CB_BoardType"
		Me.CB_BoardType.Size = New System.Drawing.Size(205, 28)
		Me.CB_BoardType.TabIndex = 2
		'
		'ChB_Mandatory
		'
		Me.ChB_Mandatory.AutoSize = true
		Me.ChB_Mandatory.Checked = true
		Me.ChB_Mandatory.CheckState = System.Windows.Forms.CheckState.Checked
		Me.ChB_Mandatory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ChB_Mandatory.Location = New System.Drawing.Point(142, 150)
		Me.ChB_Mandatory.Name = "ChB_Mandatory"
		Me.ChB_Mandatory.Size = New System.Drawing.Size(15, 14)
		Me.ChB_Mandatory.TabIndex = 3
		Me.ChB_Mandatory.UseVisualStyleBackColor = true
		'
		'CB_Slot
		'
		Me.CB_Slot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_Slot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_Slot.FormattingEnabled = true
		Me.CB_Slot.Location = New System.Drawing.Point(137, 46)
		Me.CB_Slot.Name = "CB_Slot"
		Me.CB_Slot.Size = New System.Drawing.Size(205, 28)
		Me.CB_Slot.TabIndex = 1
		'
		'B_Remove
		'
		Me.B_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.B_Remove.AutoSize = true
		Me.B_Remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Remove.Location = New System.Drawing.Point(258, 323)
		Me.B_Remove.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Remove.Name = "B_Remove"
		Me.B_Remove.Size = New System.Drawing.Size(84, 30)
		Me.B_Remove.TabIndex = 5
		Me.B_Remove.Text = "Remove"
		Me.B_Remove.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Deffinition_DataGridView)
		Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(349, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(378, 304)
		Me.GroupBox1.TabIndex = 59
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "System Definition"
		'
		'Label5
		'
		Me.Label5.AutoSize = true
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label5.Location = New System.Drawing.Point(12, 81)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(102, 24)
		Me.Label5.TabIndex = 60
		Me.Label5.Text = "Information"
		'
		'Description_TextBox
		'
		Me.Description_TextBox.Font = New System.Drawing.Font("Consolas", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Description_TextBox.Location = New System.Drawing.Point(137, 80)
		Me.Description_TextBox.Name = "Description_TextBox"
		Me.Description_TextBox.Size = New System.Drawing.Size(205, 26)
		Me.Description_TextBox.TabIndex = 61
		'
		'Deffinition_DataGridView
		'
		Me.Deffinition_DataGridView.AllowUserToAddRows = false
		Me.Deffinition_DataGridView.AllowUserToDeleteRows = false
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.Deffinition_DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.Deffinition_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.Deffinition_DataGridView.DefaultCellStyle = DataGridViewCellStyle4
		Me.Deffinition_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Deffinition_DataGridView.Location = New System.Drawing.Point(3, 22)
		Me.Deffinition_DataGridView.Name = "Deffinition_DataGridView"
		Me.Deffinition_DataGridView.ReadOnly = true
		Me.Deffinition_DataGridView.Size = New System.Drawing.Size(372, 279)
		Me.Deffinition_DataGridView.TabIndex = 0
		'
		'EditSystemDefinition
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(733, 360)
		Me.Controls.Add(Me.Description_TextBox)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.B_Remove)
		Me.Controls.Add(Me.CB_Slot)
		Me.Controls.Add(Me.ChB_Mandatory)
		Me.Controls.Add(Me.CB_BoardType)
		Me.Controls.Add(Me.CB_SystemType)
		Me.Controls.Add(Me.B_Add)
		Me.Controls.Add(Me.TB_Result)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.B_Close)
		Me.KeyPreview = true
		Me.Name = "EditSystemDefinition"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Edit System Definition"
		Me.GroupBox1.ResumeLayout(false)
		CType(Me.Deffinition_DataGridView,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_Result As System.Windows.Forms.TextBox
    Friend WithEvents B_Add As System.Windows.Forms.Button
    Friend WithEvents CB_SystemType As System.Windows.Forms.ComboBox
    Friend WithEvents CB_BoardType As System.Windows.Forms.ComboBox
    Friend WithEvents ChB_Mandatory As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Slot As System.Windows.Forms.ComboBox
    Friend WithEvents B_Remove As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Description_TextBox As TextBox
	Friend WithEvents Deffinition_DataGridView As DataGridView
End Class
