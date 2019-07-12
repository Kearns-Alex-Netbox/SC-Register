<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HardwareVersions
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.B_Close = New System.Windows.Forms.Button
        Me.B_Update = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.B_Last = New System.Windows.Forms.Button
        Me.B_First = New System.Windows.Forms.Button
        Me.B_Next = New System.Windows.Forms.Button
        Me.B_Previous = New System.Windows.Forms.Button
        Me.B_Add = New System.Windows.Forms.Button
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Version = New System.Windows.Forms.TextBox
        Me.TB_SerialNumber = New System.Windows.Forms.TextBox
        Me.TB_Result = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_Close
        '
        Me.B_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Close.AutoSize = True
        Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Close.Location = New System.Drawing.Point(473, 447)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(59, 30)
        Me.B_Close.TabIndex = 9
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'B_Update
        '
        Me.B_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Update.AutoSize = True
        Me.B_Update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Update.Location = New System.Drawing.Point(460, 287)
        Me.B_Update.Name = "B_Update"
        Me.B_Update.Size = New System.Drawing.Size(72, 30)
        Me.B_Update.TabIndex = 4
        Me.B_Update.Text = "Update"
        Me.B_Update.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 7)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.Size = New System.Drawing.Size(519, 274)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'B_Last
        '
        Me.B_Last.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Last.AutoSize = True
        Me.B_Last.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Last.Location = New System.Drawing.Point(174, 287)
        Me.B_Last.Name = "B_Last"
        Me.B_Last.Size = New System.Drawing.Size(50, 30)
        Me.B_Last.TabIndex = 3
        Me.B_Last.Text = "Last"
        Me.B_Last.UseVisualStyleBackColor = True
        '
        'B_First
        '
        Me.B_First.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_First.AutoSize = True
        Me.B_First.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_First.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_First.Location = New System.Drawing.Point(12, 287)
        Me.B_First.Name = "B_First"
        Me.B_First.Size = New System.Drawing.Size(50, 30)
        Me.B_First.TabIndex = 0
        Me.B_First.Text = "First"
        Me.B_First.UseVisualStyleBackColor = True
        '
        'B_Next
        '
        Me.B_Next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Next.AutoSize = True
        Me.B_Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Next.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Next.Location = New System.Drawing.Point(121, 287)
        Me.B_Next.Name = "B_Next"
        Me.B_Next.Size = New System.Drawing.Size(47, 30)
        Me.B_Next.TabIndex = 2
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
        Me.B_Previous.Location = New System.Drawing.Point(68, 287)
        Me.B_Previous.Name = "B_Previous"
        Me.B_Previous.Size = New System.Drawing.Size(47, 30)
        Me.B_Previous.TabIndex = 1
        Me.B_Previous.Text = "<<--"
        Me.B_Previous.UseVisualStyleBackColor = True
        '
        'B_Add
        '
        Me.B_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Add.AutoSize = True
        Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Add.Location = New System.Drawing.Point(176, 445)
        Me.B_Add.Name = "B_Add"
        Me.B_Add.Size = New System.Drawing.Size(48, 30)
        Me.B_Add.TabIndex = 8
        Me.B_Add.Text = "Add"
        Me.B_Add.UseVisualStyleBackColor = True
        '
        'TB_Name
        '
        Me.TB_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Name.Location = New System.Drawing.Point(12, 343)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(212, 26)
        Me.TB_Name.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type Name:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Base Serial Number:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Version:"
        '
        'TB_Version
        '
        Me.TB_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Version.Location = New System.Drawing.Point(12, 447)
        Me.TB_Version.Name = "TB_Version"
        Me.TB_Version.Size = New System.Drawing.Size(158, 26)
        Me.TB_Version.TabIndex = 7
        '
        'TB_SerialNumber
        '
        Me.TB_SerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_SerialNumber.Location = New System.Drawing.Point(12, 395)
        Me.TB_SerialNumber.Name = "TB_SerialNumber"
        Me.TB_SerialNumber.Size = New System.Drawing.Size(212, 26)
        Me.TB_SerialNumber.TabIndex = 6
        '
        'TB_Result
        '
        Me.TB_Result.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Result.Enabled = False
        Me.TB_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Result.Location = New System.Drawing.Point(260, 323)
        Me.TB_Result.Multiline = True
        Me.TB_Result.Name = "TB_Result"
        Me.TB_Result.ReadOnly = True
        Me.TB_Result.Size = New System.Drawing.Size(272, 118)
        Me.TB_Result.TabIndex = 14
        '
        'HardwareVersions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(539, 484)
        Me.Controls.Add(Me.TB_Result)
        Me.Controls.Add(Me.TB_SerialNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_Version)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Name)
        Me.Controls.Add(Me.B_Add)
        Me.Controls.Add(Me.B_Last)
        Me.Controls.Add(Me.B_First)
        Me.Controls.Add(Me.B_Next)
        Me.Controls.Add(Me.B_Previous)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B_Update)
        Me.Controls.Add(Me.B_Close)
        Me.KeyPreview = True
        Me.Name = "HardwareVersions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hardware Versions"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents B_Update As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents B_Last As System.Windows.Forms.Button
    Friend WithEvents B_First As System.Windows.Forms.Button
    Friend WithEvents B_Next As System.Windows.Forms.Button
    Friend WithEvents B_Previous As System.Windows.Forms.Button
    Friend WithEvents B_Add As System.Windows.Forms.Button
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Version As System.Windows.Forms.TextBox
    Friend WithEvents TB_SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents TB_Result As System.Windows.Forms.TextBox
End Class
