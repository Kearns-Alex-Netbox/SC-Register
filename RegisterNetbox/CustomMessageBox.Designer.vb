<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMessageBox
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
        Me.B_UseCurrent = New System.Windows.Forms.Button
        Me.B_UseNext = New System.Windows.Forms.Button
        Me.B_No = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'B_UseCurrent
        '
        Me.B_UseCurrent.Location = New System.Drawing.Point(12, 85)
        Me.B_UseCurrent.Name = "B_UseCurrent"
        Me.B_UseCurrent.Size = New System.Drawing.Size(86, 23)
        Me.B_UseCurrent.TabIndex = 0
        Me.B_UseCurrent.Text = "Use Current"
        Me.B_UseCurrent.UseVisualStyleBackColor = True
        '
        'B_UseNext
        '
        Me.B_UseNext.Location = New System.Drawing.Point(104, 85)
        Me.B_UseNext.Name = "B_UseNext"
        Me.B_UseNext.Size = New System.Drawing.Size(86, 23)
        Me.B_UseNext.TabIndex = 1
        Me.B_UseNext.Text = "Use Next MAC"
        Me.B_UseNext.UseVisualStyleBackColor = True
        '
        'B_No
        '
        Me.B_No.Location = New System.Drawing.Point(196, 85)
        Me.B_No.Name = "B_No"
        Me.B_No.Size = New System.Drawing.Size(86, 23)
        Me.B_No.TabIndex = 2
        Me.B_No.Text = "Cancel"
        Me.B_No.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(270, 67)
        Me.TextBox1.TabIndex = 3
        '
        'CustomMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 116)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.B_No)
        Me.Controls.Add(Me.B_UseNext)
        Me.Controls.Add(Me.B_UseCurrent)
        Me.Name = "CustomMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "?????"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_UseCurrent As System.Windows.Forms.Button
    Friend WithEvents B_UseNext As System.Windows.Forms.Button
    Friend WithEvents B_No As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
