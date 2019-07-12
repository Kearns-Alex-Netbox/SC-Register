<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_SerialNumber = New System.Windows.Forms.TextBox
        Me.CB_Reports = New System.Windows.Forms.ComboBox
        Me.B_SearchSerialNumber = New System.Windows.Forms.Button
        Me.B_SearchReport = New System.Windows.Forms.Button
        Me.B_Close = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Serial Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Search Report"
        '
        'TB_SerialNumber
        '
        Me.TB_SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_SerialNumber.Location = New System.Drawing.Point(17, 36)
        Me.TB_SerialNumber.Name = "TB_SerialNumber"
        Me.TB_SerialNumber.Size = New System.Drawing.Size(287, 26)
        Me.TB_SerialNumber.TabIndex = 0
        '
        'CB_Reports
        '
        Me.CB_Reports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Reports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Reports.FormattingEnabled = True
        Me.CB_Reports.Location = New System.Drawing.Point(17, 124)
        Me.CB_Reports.Name = "CB_Reports"
        Me.CB_Reports.Size = New System.Drawing.Size(287, 28)
        Me.CB_Reports.TabIndex = 2
        '
        'B_SearchSerialNumber
        '
        Me.B_SearchSerialNumber.AutoSize = True
        Me.B_SearchSerialNumber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_SearchSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_SearchSerialNumber.Location = New System.Drawing.Point(228, 68)
        Me.B_SearchSerialNumber.Name = "B_SearchSerialNumber"
        Me.B_SearchSerialNumber.Size = New System.Drawing.Size(76, 30)
        Me.B_SearchSerialNumber.TabIndex = 1
        Me.B_SearchSerialNumber.Text = "Search"
        Me.B_SearchSerialNumber.UseVisualStyleBackColor = True
        '
        'B_SearchReport
        '
        Me.B_SearchReport.AutoSize = True
        Me.B_SearchReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_SearchReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_SearchReport.Location = New System.Drawing.Point(228, 158)
        Me.B_SearchReport.Name = "B_SearchReport"
        Me.B_SearchReport.Size = New System.Drawing.Size(76, 30)
        Me.B_SearchReport.TabIndex = 3
        Me.B_SearchReport.Text = "Search"
        Me.B_SearchReport.UseVisualStyleBackColor = True
        '
        'B_Close
        '
        Me.B_Close.AutoSize = True
        Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Close.Location = New System.Drawing.Point(240, 194)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(64, 30)
        Me.B_Close.TabIndex = 4
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(323, 233)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_SearchReport)
        Me.Controls.Add(Me.B_SearchSerialNumber)
        Me.Controls.Add(Me.CB_Reports)
        Me.Controls.Add(Me.TB_SerialNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents CB_Reports As System.Windows.Forms.ComboBox
    Friend WithEvents B_SearchSerialNumber As System.Windows.Forms.Button
    Friend WithEvents B_SearchReport As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
End Class
