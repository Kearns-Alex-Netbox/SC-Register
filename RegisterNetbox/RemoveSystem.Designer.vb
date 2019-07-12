<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoveSystem
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
        Me.RemoveSystemButton = New System.Windows.Forms.Button
        Me.SystemSerialNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.ResultStatus = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'RemoveSystemButton
        '
        Me.RemoveSystemButton.AutoSize = True
        Me.RemoveSystemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RemoveSystemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveSystemButton.Location = New System.Drawing.Point(13, 168)
        Me.RemoveSystemButton.Margin = New System.Windows.Forms.Padding(4)
        Me.RemoveSystemButton.Name = "RemoveSystemButton"
        Me.RemoveSystemButton.Size = New System.Drawing.Size(148, 30)
        Me.RemoveSystemButton.TabIndex = 1
        Me.RemoveSystemButton.Text = "Remove System"
        Me.RemoveSystemButton.UseVisualStyleBackColor = True
        '
        'SystemSerialNumber
        '
        Me.SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemSerialNumber.Location = New System.Drawing.Point(17, 33)
        Me.SystemSerialNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.SystemSerialNumber.Name = "SystemSerialNumber"
        Me.SystemSerialNumber.Size = New System.Drawing.Size(182, 26)
        Me.SystemSerialNumber.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 20)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "System Serial Number"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.AutoSize = True
        Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(169, 168)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(64, 30)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Close"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'ResultStatus
        '
        Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultStatus.Location = New System.Drawing.Point(17, 66)
        Me.ResultStatus.Multiline = True
        Me.ResultStatus.Name = "ResultStatus"
        Me.ResultStatus.ReadOnly = True
        Me.ResultStatus.Size = New System.Drawing.Size(216, 95)
        Me.ResultStatus.TabIndex = 57
        Me.ResultStatus.TabStop = False
        '
        'RemoveSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 206)
        Me.Controls.Add(Me.ResultStatus)
        Me.Controls.Add(Me.RemoveSystemButton)
        Me.Controls.Add(Me.SystemSerialNumber)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Cancel_Button)
        Me.KeyPreview = True
        Me.Name = "RemoveSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remove System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RemoveSystemButton As System.Windows.Forms.Button
    Friend WithEvents SystemSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
End Class
