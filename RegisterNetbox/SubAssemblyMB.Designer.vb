<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubAssemblyMB
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
        Me.L_Scanned = New System.Windows.Forms.Label
        Me.BoardSerialNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ResultStatus = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.SaveButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'L_Scanned
        '
        Me.L_Scanned.AutoSize = True
        Me.L_Scanned.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Scanned.Location = New System.Drawing.Point(102, 168)
        Me.L_Scanned.Name = "L_Scanned"
        Me.L_Scanned.Size = New System.Drawing.Size(68, 16)
        Me.L_Scanned.TabIndex = 6
        Me.L_Scanned.Text = "Scanned: "
        '
        'BoardSerialNumber
        '
        Me.BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoardSerialNumber.Location = New System.Drawing.Point(12, 32)
        Me.BoardSerialNumber.Name = "BoardSerialNumber"
        Me.BoardSerialNumber.Size = New System.Drawing.Size(260, 24)
        Me.BoardSerialNumber.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Board Serial Number"
        '
        'ResultStatus
        '
        Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultStatus.Location = New System.Drawing.Point(12, 93)
        Me.ResultStatus.Multiline = True
        Me.ResultStatus.Name = "ResultStatus"
        Me.ResultStatus.ReadOnly = True
        Me.ResultStatus.Size = New System.Drawing.Size(260, 61)
        Me.ResultStatus.TabIndex = 5
        Me.ResultStatus.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Result Status"
        '
        'ExitButton
        '
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(208, 160)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 2
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.AutoSize = True
        Me.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Location = New System.Drawing.Point(12, 160)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(59, 30)
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'SubAssemblyMB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 198)
        Me.Controls.Add(Me.L_Scanned)
        Me.Controls.Add(Me.BoardSerialNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ResultStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SaveButton)
        Me.KeyPreview = True
        Me.Name = "SubAssemblyMB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sub Assembly [Motherboard]"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents L_Scanned As System.Windows.Forms.Label
    Friend WithEvents BoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
End Class
