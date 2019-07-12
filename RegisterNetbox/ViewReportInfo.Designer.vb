<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReportInfo
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.B_Close = New System.Windows.Forms.Button
        Me.B_Previous = New System.Windows.Forms.Button
        Me.B_Next = New System.Windows.Forms.Button
        Me.B_First = New System.Windows.Forms.Button
        Me.B_Last = New System.Windows.Forms.Button
        Me.B_Refresh = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.RB_DescendingSort = New System.Windows.Forms.RadioButton
        Me.RB_AscendingSort = New System.Windows.Forms.RadioButton
        Me.B_Sort = New System.Windows.Forms.Button
        Me.CB_Sort = New System.Windows.Forms.ComboBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.B_Forward = New System.Windows.Forms.Button
        Me.B_Back = New System.Windows.Forms.Button
        Me.TB_Search = New System.Windows.Forms.TextBox
        Me.B_Search = New System.Windows.Forms.Button
        Me.CB_Search = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.L_Results = New System.Windows.Forms.Label
        Me.CB_Display = New System.Windows.Forms.ComboBox
        Me.B_CreateExcel = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
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
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(13, 93)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.Size = New System.Drawing.Size(717, 448)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'B_Close
        '
        Me.B_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.B_Close.AutoSize = True
        Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Close.Location = New System.Drawing.Point(671, 547)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(59, 30)
        Me.B_Close.TabIndex = 6
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'B_Previous
        '
        Me.B_Previous.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Previous.AutoSize = True
        Me.B_Previous.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Previous.Enabled = False
        Me.B_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Previous.Location = New System.Drawing.Point(69, 547)
        Me.B_Previous.Name = "B_Previous"
        Me.B_Previous.Size = New System.Drawing.Size(47, 30)
        Me.B_Previous.TabIndex = 3
        Me.B_Previous.Text = "<<--"
        Me.B_Previous.UseVisualStyleBackColor = True
        '
        'B_Next
        '
        Me.B_Next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Next.AutoSize = True
        Me.B_Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Next.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Next.Location = New System.Drawing.Point(122, 547)
        Me.B_Next.Name = "B_Next"
        Me.B_Next.Size = New System.Drawing.Size(47, 30)
        Me.B_Next.TabIndex = 4
        Me.B_Next.Text = "-->>"
        Me.B_Next.UseVisualStyleBackColor = True
        '
        'B_First
        '
        Me.B_First.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_First.AutoSize = True
        Me.B_First.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_First.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_First.Location = New System.Drawing.Point(13, 547)
        Me.B_First.Name = "B_First"
        Me.B_First.Size = New System.Drawing.Size(50, 30)
        Me.B_First.TabIndex = 2
        Me.B_First.Text = "First"
        Me.B_First.UseVisualStyleBackColor = True
        '
        'B_Last
        '
        Me.B_Last.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Last.AutoSize = True
        Me.B_Last.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Last.Location = New System.Drawing.Point(175, 547)
        Me.B_Last.Name = "B_Last"
        Me.B_Last.Size = New System.Drawing.Size(50, 30)
        Me.B_Last.TabIndex = 5
        Me.B_Last.Text = "Last"
        Me.B_Last.UseVisualStyleBackColor = True
        '
        'B_Refresh
        '
        Me.B_Refresh.AutoSize = True
        Me.B_Refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Refresh.Location = New System.Drawing.Point(654, 48)
        Me.B_Refresh.Name = "B_Refresh"
        Me.B_Refresh.Size = New System.Drawing.Size(76, 30)
        Me.B_Refresh.TabIndex = 1
        Me.B_Refresh.Text = "Refresh"
        Me.B_Refresh.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.RB_DescendingSort)
        Me.TabPage2.Controls.Add(Me.RB_AscendingSort)
        Me.TabPage2.Controls.Add(Me.B_Sort)
        Me.TabPage2.Controls.Add(Me.CB_Sort)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(625, 39)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Sort"
        '
        'RB_DescendingSort
        '
        Me.RB_DescendingSort.AutoSize = True
        Me.RB_DescendingSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_DescendingSort.Location = New System.Drawing.Point(341, 9)
        Me.RB_DescendingSort.Name = "RB_DescendingSort"
        Me.RB_DescendingSort.Size = New System.Drawing.Size(122, 24)
        Me.RB_DescendingSort.TabIndex = 2
        Me.RB_DescendingSort.TabStop = True
        Me.RB_DescendingSort.Text = "Descending"
        Me.RB_DescendingSort.UseVisualStyleBackColor = True
        '
        'RB_AscendingSort
        '
        Me.RB_AscendingSort.AutoSize = True
        Me.RB_AscendingSort.Checked = True
        Me.RB_AscendingSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_AscendingSort.Location = New System.Drawing.Point(224, 9)
        Me.RB_AscendingSort.Name = "RB_AscendingSort"
        Me.RB_AscendingSort.Size = New System.Drawing.Size(111, 24)
        Me.RB_AscendingSort.TabIndex = 1
        Me.RB_AscendingSort.TabStop = True
        Me.RB_AscendingSort.Text = "Ascending"
        Me.RB_AscendingSort.UseVisualStyleBackColor = True
        '
        'B_Sort
        '
        Me.B_Sort.AutoSize = True
        Me.B_Sort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Sort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Sort.Location = New System.Drawing.Point(570, 6)
        Me.B_Sort.Name = "B_Sort"
        Me.B_Sort.Size = New System.Drawing.Size(49, 30)
        Me.B_Sort.TabIndex = 3
        Me.B_Sort.Text = "Sort"
        Me.B_Sort.UseVisualStyleBackColor = True
        '
        'CB_Sort
        '
        Me.CB_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Sort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Sort.FormattingEnabled = True
        Me.CB_Sort.Location = New System.Drawing.Point(6, 8)
        Me.CB_Sort.Name = "CB_Sort"
        Me.CB_Sort.Size = New System.Drawing.Size(212, 28)
        Me.CB_Sort.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.B_Forward)
        Me.TabPage1.Controls.Add(Me.B_Back)
        Me.TabPage1.Controls.Add(Me.TB_Search)
        Me.TabPage1.Controls.Add(Me.B_Search)
        Me.TabPage1.Controls.Add(Me.CB_Search)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(625, 39)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Search"
        '
        'B_Forward
        '
        Me.B_Forward.AutoSize = True
        Me.B_Forward.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Forward.Enabled = False
        Me.B_Forward.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Forward.Location = New System.Drawing.Point(37, 6)
        Me.B_Forward.Name = "B_Forward"
        Me.B_Forward.Size = New System.Drawing.Size(28, 30)
        Me.B_Forward.TabIndex = 4
        Me.B_Forward.TabStop = False
        Me.B_Forward.Text = ">"
        Me.B_Forward.UseVisualStyleBackColor = True
        '
        'B_Back
        '
        Me.B_Back.AutoSize = True
        Me.B_Back.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Back.Enabled = False
        Me.B_Back.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Back.Location = New System.Drawing.Point(3, 6)
        Me.B_Back.Name = "B_Back"
        Me.B_Back.Size = New System.Drawing.Size(28, 30)
        Me.B_Back.TabIndex = 3
        Me.B_Back.TabStop = False
        Me.B_Back.Text = "<"
        Me.B_Back.UseVisualStyleBackColor = True
        '
        'TB_Search
        '
        Me.TB_Search.Location = New System.Drawing.Point(289, 8)
        Me.TB_Search.Name = "TB_Search"
        Me.TB_Search.Size = New System.Drawing.Size(254, 26)
        Me.TB_Search.TabIndex = 1
        '
        'B_Search
        '
        Me.B_Search.AutoSize = True
        Me.B_Search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Search.Location = New System.Drawing.Point(549, 6)
        Me.B_Search.Name = "B_Search"
        Me.B_Search.Size = New System.Drawing.Size(70, 30)
        Me.B_Search.TabIndex = 2
        Me.B_Search.Text = "Search"
        Me.B_Search.UseVisualStyleBackColor = True
        '
        'CB_Search
        '
        Me.CB_Search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Search.FormattingEnabled = True
        Me.CB_Search.Location = New System.Drawing.Point(71, 7)
        Me.CB_Search.Name = "CB_Search"
        Me.CB_Search.Size = New System.Drawing.Size(212, 28)
        Me.CB_Search.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(13, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(633, 75)
        Me.TabControl1.TabIndex = 0
        '
        'L_Results
        '
        Me.L_Results.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.L_Results.AutoSize = True
        Me.L_Results.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Results.Location = New System.Drawing.Point(306, 552)
        Me.L_Results.Name = "L_Results"
        Me.L_Results.Size = New System.Drawing.Size(151, 20)
        Me.L_Results.TabIndex = 7
        Me.L_Results.Text = "Number of results"
        '
        'CB_Display
        '
        Me.CB_Display.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_Display.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Display.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Display.FormattingEnabled = True
        Me.CB_Display.Items.AddRange(New Object() {"25", "50", "75"})
        Me.CB_Display.Location = New System.Drawing.Point(231, 548)
        Me.CB_Display.Name = "CB_Display"
        Me.CB_Display.Size = New System.Drawing.Size(69, 28)
        Me.CB_Display.TabIndex = 4
        '
        'B_CreateExcel
        '
        Me.B_CreateExcel.AutoSize = True
        Me.B_CreateExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_CreateExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_CreateExcel.Location = New System.Drawing.Point(621, 11)
        Me.B_CreateExcel.Name = "B_CreateExcel"
        Me.B_CreateExcel.Size = New System.Drawing.Size(109, 30)
        Me.B_CreateExcel.TabIndex = 8
        Me.B_CreateExcel.Text = "Create Excel"
        Me.B_CreateExcel.UseVisualStyleBackColor = True
        '
        'ViewReportInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(739, 585)
        Me.Controls.Add(Me.B_CreateExcel)
        Me.Controls.Add(Me.CB_Display)
        Me.Controls.Add(Me.L_Results)
        Me.Controls.Add(Me.B_Refresh)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.B_Last)
        Me.Controls.Add(Me.B_First)
        Me.Controls.Add(Me.B_Next)
        Me.Controls.Add(Me.B_Previous)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ViewReportInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Info"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents B_Previous As System.Windows.Forms.Button
    Friend WithEvents B_Next As System.Windows.Forms.Button
    Friend WithEvents B_First As System.Windows.Forms.Button
    Friend WithEvents B_Last As System.Windows.Forms.Button
    Friend WithEvents B_Refresh As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RB_AscendingSort As System.Windows.Forms.RadioButton
    Friend WithEvents B_Sort As System.Windows.Forms.Button
    Friend WithEvents CB_Sort As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TB_Search As System.Windows.Forms.TextBox
    Friend WithEvents B_Search As System.Windows.Forms.Button
    Friend WithEvents CB_Search As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents RB_DescendingSort As System.Windows.Forms.RadioButton
    Friend WithEvents B_Back As System.Windows.Forms.Button
    Friend WithEvents B_Forward As System.Windows.Forms.Button
    Friend WithEvents L_Results As System.Windows.Forms.Label
    Friend WithEvents CB_Display As System.Windows.Forms.ComboBox
    Friend WithEvents B_CreateExcel As System.Windows.Forms.Button
End Class
