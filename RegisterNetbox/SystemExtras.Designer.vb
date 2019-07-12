<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemExtras
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.B_Add = New System.Windows.Forms.Button()
		Me.B_Last = New System.Windows.Forms.Button()
		Me.B_First = New System.Windows.Forms.Button()
		Me.B_Next = New System.Windows.Forms.Button()
		Me.B_Previous = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.B_Close = New System.Windows.Forms.Button()
		Me.B_Details = New System.Windows.Forms.Button()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'B_Add
		'
		Me.B_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Add.AutoSize = True
		Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Add.Location = New System.Drawing.Point(363, 288)
		Me.B_Add.Name = "B_Add"
		Me.B_Add.Size = New System.Drawing.Size(102, 30)
		Me.B_Add.TabIndex = 34
		Me.B_Add.Text = "Create New"
		Me.B_Add.UseVisualStyleBackColor = True
		'
		'B_Last
		'
		Me.B_Last.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Last.AutoSize = True
		Me.B_Last.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Last.Location = New System.Drawing.Point(173, 288)
		Me.B_Last.Name = "B_Last"
		Me.B_Last.Size = New System.Drawing.Size(50, 30)
		Me.B_Last.TabIndex = 23
		Me.B_Last.Text = "Last"
		Me.B_Last.UseVisualStyleBackColor = True
		'
		'B_First
		'
		Me.B_First.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_First.AutoSize = True
		Me.B_First.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_First.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_First.Location = New System.Drawing.Point(11, 288)
		Me.B_First.Name = "B_First"
		Me.B_First.Size = New System.Drawing.Size(50, 30)
		Me.B_First.TabIndex = 20
		Me.B_First.Text = "First"
		Me.B_First.UseVisualStyleBackColor = True
		'
		'B_Next
		'
		Me.B_Next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Next.AutoSize = True
		Me.B_Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Next.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Next.Location = New System.Drawing.Point(120, 288)
		Me.B_Next.Name = "B_Next"
		Me.B_Next.Size = New System.Drawing.Size(47, 30)
		Me.B_Next.TabIndex = 22
		Me.B_Next.Text = "-->>"
		Me.B_Next.UseVisualStyleBackColor = True
		'
		'B_Previous
		'
		Me.B_Previous.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Previous.AutoSize = True
		Me.B_Previous.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Previous.Enabled = False
		Me.B_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Previous.Location = New System.Drawing.Point(67, 288)
		Me.B_Previous.Name = "B_Previous"
		Me.B_Previous.Size = New System.Drawing.Size(47, 30)
		Me.B_Previous.TabIndex = 21
		Me.B_Previous.Text = "<<--"
		Me.B_Previous.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToAddRows = False
		Me.DataGridView1.AllowUserToDeleteRows = False
		Me.DataGridView1.AllowUserToOrderColumns = True
		Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
		Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
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
		Me.B_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.B_Close.AutoSize = True
		Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Close.Location = New System.Drawing.Point(471, 288)
		Me.B_Close.Name = "B_Close"
		Me.B_Close.Size = New System.Drawing.Size(59, 30)
		Me.B_Close.TabIndex = 35
		Me.B_Close.Text = "Close"
		Me.B_Close.UseVisualStyleBackColor = True
		'
		'B_Details
		'
		Me.B_Details.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Details.AutoSize = True
		Me.B_Details.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Details.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Details.Location = New System.Drawing.Point(229, 288)
		Me.B_Details.Name = "B_Details"
		Me.B_Details.Size = New System.Drawing.Size(68, 30)
		Me.B_Details.TabIndex = 36
		Me.B_Details.Text = "Details"
		Me.B_Details.UseVisualStyleBackColor = True
		'
		'SystemExtras
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(539, 327)
		Me.Controls.Add(Me.B_Details)
		Me.Controls.Add(Me.B_Add)
		Me.Controls.Add(Me.B_Last)
		Me.Controls.Add(Me.B_First)
		Me.Controls.Add(Me.B_Next)
		Me.Controls.Add(Me.B_Previous)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.B_Close)
		Me.Name = "SystemExtras"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "System Extras"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents B_Add As Button
	Friend WithEvents B_Last As Button
	Friend WithEvents B_First As Button
	Friend WithEvents B_Next As Button
	Friend WithEvents B_Previous As Button
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents B_Close As Button
	Friend WithEvents B_Details As Button
End Class
