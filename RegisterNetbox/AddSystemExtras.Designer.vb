<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSystemExtras
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
		Me.TB_Result = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TB_Description = New System.Windows.Forms.TextBox()
		Me.B_Add = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.B_Close = New System.Windows.Forms.Button()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.CB_SystemType = New System.Windows.Forms.ComboBox()
		Me.LB_ExtraComponents = New System.Windows.Forms.ListBox()
		Me.ChkB_Default = New System.Windows.Forms.CheckBox()
		Me.B_AddtoList = New System.Windows.Forms.Button()
		Me.B_Remove = New System.Windows.Forms.Button()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TB_Result
		'
		Me.TB_Result.Enabled = False
		Me.TB_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TB_Result.Location = New System.Drawing.Point(11, 402)
		Me.TB_Result.Multiline = True
		Me.TB_Result.Name = "TB_Result"
		Me.TB_Result.ReadOnly = True
		Me.TB_Result.Size = New System.Drawing.Size(241, 114)
		Me.TB_Result.TabIndex = 18
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(11, 342)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(241, 20)
		Me.Label1.TabIndex = 24
		Me.Label1.Text = "Description of System Extras"
		'
		'TB_Description
		'
		Me.TB_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TB_Description.Location = New System.Drawing.Point(11, 365)
		Me.TB_Description.Name = "TB_Description"
		Me.TB_Description.Size = New System.Drawing.Size(242, 26)
		Me.TB_Description.TabIndex = 25
		'
		'B_Add
		'
		Me.B_Add.AutoSize = True
		Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Add.Location = New System.Drawing.Point(345, 486)
		Me.B_Add.Name = "B_Add"
		Me.B_Add.Size = New System.Drawing.Size(48, 30)
		Me.B_Add.TabIndex = 34
		Me.B_Add.Text = "Add"
		Me.B_Add.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToAddRows = False
		Me.DataGridView1.AllowUserToDeleteRows = False
		Me.DataGridView1.AllowUserToOrderColumns = True
		Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
		Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
		Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
		Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
		Me.DataGridView1.Location = New System.Drawing.Point(11, 8)
		Me.DataGridView1.MultiSelect = False
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.ReadOnly = True
		Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
		Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.DataGridView1.Size = New System.Drawing.Size(519, 274)
		Me.DataGridView1.TabIndex = 19
		Me.DataGridView1.TabStop = False
		'
		'B_Close
		'
		Me.B_Close.AutoSize = True
		Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Close.Location = New System.Drawing.Point(471, 486)
		Me.B_Close.Name = "B_Close"
		Me.B_Close.Size = New System.Drawing.Size(59, 30)
		Me.B_Close.TabIndex = 35
		Me.B_Close.Text = "Close"
		Me.B_Close.UseVisualStyleBackColor = True
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.Location = New System.Drawing.Point(11, 288)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(47, 20)
		Me.Label11.TabIndex = 47
		Me.Label11.Text = "Type"
		'
		'CB_SystemType
		'
		Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_SystemType.FormattingEnabled = True
		Me.CB_SystemType.Location = New System.Drawing.Point(11, 311)
		Me.CB_SystemType.Name = "CB_SystemType"
		Me.CB_SystemType.Size = New System.Drawing.Size(242, 28)
		Me.CB_SystemType.TabIndex = 46
		'
		'LB_ExtraComponents
		'
		Me.LB_ExtraComponents.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LB_ExtraComponents.FormattingEnabled = True
		Me.LB_ExtraComponents.ItemHeight = 19
		Me.LB_ExtraComponents.Location = New System.Drawing.Point(258, 324)
		Me.LB_ExtraComponents.Name = "LB_ExtraComponents"
		Me.LB_ExtraComponents.Size = New System.Drawing.Size(268, 156)
		Me.LB_ExtraComponents.TabIndex = 48
		'
		'ChkB_Default
		'
		Me.ChkB_Default.AutoSize = True
		Me.ChkB_Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChkB_Default.Location = New System.Drawing.Point(259, 490)
		Me.ChkB_Default.Name = "ChkB_Default"
		Me.ChkB_Default.Size = New System.Drawing.Size(80, 24)
		Me.ChkB_Default.TabIndex = 49
		Me.ChkB_Default.Text = "Default"
		Me.ChkB_Default.UseVisualStyleBackColor = True
		'
		'B_AddtoList
		'
		Me.B_AddtoList.AutoSize = True
		Me.B_AddtoList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_AddtoList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_AddtoList.Location = New System.Drawing.Point(259, 288)
		Me.B_AddtoList.Name = "B_AddtoList"
		Me.B_AddtoList.Size = New System.Drawing.Size(95, 30)
		Me.B_AddtoList.TabIndex = 50
		Me.B_AddtoList.Text = "Add to List"
		Me.B_AddtoList.UseVisualStyleBackColor = True
		'
		'B_Remove
		'
		Me.B_Remove.AutoSize = True
		Me.B_Remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Remove.Location = New System.Drawing.Point(360, 288)
		Me.B_Remove.Name = "B_Remove"
		Me.B_Remove.Size = New System.Drawing.Size(78, 30)
		Me.B_Remove.TabIndex = 51
		Me.B_Remove.Text = "Remove"
		Me.B_Remove.UseVisualStyleBackColor = True
		'
		'AddSystemExtras
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(539, 527)
		Me.Controls.Add(Me.B_Remove)
		Me.Controls.Add(Me.B_AddtoList)
		Me.Controls.Add(Me.ChkB_Default)
		Me.Controls.Add(Me.LB_ExtraComponents)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.CB_SystemType)
		Me.Controls.Add(Me.TB_Result)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TB_Description)
		Me.Controls.Add(Me.B_Add)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.B_Close)
		Me.Name = "AddSystemExtras"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "AddSystemExtras"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TB_Result As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents TB_Description As TextBox
	Friend WithEvents B_Add As Button
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents B_Close As Button
	Friend WithEvents Label11 As Label
	Friend WithEvents CB_SystemType As ComboBox
	Friend WithEvents LB_ExtraComponents As ListBox
	Friend WithEvents ChkB_Default As CheckBox
	Friend WithEvents B_AddtoList As Button
	Friend WithEvents B_Remove As Button
End Class
