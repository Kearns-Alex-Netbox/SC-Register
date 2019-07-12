<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoveBoard
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
        Me.ResultStatus = New System.Windows.Forms.TextBox
        Me.RemoveBoardButton = New System.Windows.Forms.Button
        Me.BoardSerialNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ResultStatus
        '
        Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultStatus.Location = New System.Drawing.Point(17, 66)
        Me.ResultStatus.Multiline = True
        Me.ResultStatus.Name = "ResultStatus"
        Me.ResultStatus.ReadOnly = True
        Me.ResultStatus.Size = New System.Drawing.Size(216, 95)
        Me.ResultStatus.TabIndex = 62
        Me.ResultStatus.TabStop = False
        '
        'RemoveBoardButton
        '
        Me.RemoveBoardButton.AutoSize = True
        Me.RemoveBoardButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RemoveBoardButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveBoardButton.Location = New System.Drawing.Point(13, 168)
        Me.RemoveBoardButton.Margin = New System.Windows.Forms.Padding(4)
        Me.RemoveBoardButton.Name = "RemoveBoardButton"
        Me.RemoveBoardButton.Size = New System.Drawing.Size(137, 30)
        Me.RemoveBoardButton.TabIndex = 59
        Me.RemoveBoardButton.Text = "Remove Board"
        Me.RemoveBoardButton.UseVisualStyleBackColor = True
        '
        'BoardSerialNumber
        '
        Me.BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoardSerialNumber.Location = New System.Drawing.Point(17, 33)
        Me.BoardSerialNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.BoardSerialNumber.Name = "BoardSerialNumber"
        Me.BoardSerialNumber.Size = New System.Drawing.Size(182, 26)
        Me.BoardSerialNumber.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(175, 20)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Board Serial Number"
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
        Me.Cancel_Button.TabIndex = 60
        Me.Cancel_Button.Text = "Close"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'RemoveBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 206)
        Me.Controls.Add(Me.ResultStatus)
        Me.Controls.Add(Me.RemoveBoardButton)
        Me.Controls.Add(Me.BoardSerialNumber)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Name = "RemoveBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RemoveBoard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents RemoveBoardButton As System.Windows.Forms.Button
    Friend WithEvents BoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
End Class
