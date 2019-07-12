<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_AddBoard
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
		Me.SaveButton = New System.Windows.Forms.Button()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.ResultStatus = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.BoardSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.L_Scanned = New System.Windows.Forms.Label()
		Me.BoardComment = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.EndingSNO_TextBox = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.CurrentRevision_TextBox = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'SaveButton
		'
		Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SaveButton.AutoSize = true
		Me.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SaveButton.Location = New System.Drawing.Point(12, 436)
		Me.SaveButton.Name = "SaveButton"
		Me.SaveButton.Size = New System.Drawing.Size(59, 30)
		Me.SaveButton.TabIndex = 11
		Me.SaveButton.Text = "Save"
		Me.SaveButton.UseVisualStyleBackColor = true
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(215, 436)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 12
		Me.ExitButton.TabStop = false
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'ResultStatus
		'
		Me.ResultStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ResultStatus.Location = New System.Drawing.Point(12, 369)
		Me.ResultStatus.Multiline = true
		Me.ResultStatus.Name = "ResultStatus"
		Me.ResultStatus.ReadOnly = true
		Me.ResultStatus.Size = New System.Drawing.Size(267, 61)
		Me.ResultStatus.TabIndex = 10
		Me.ResultStatus.TabStop = false
		'
		'Label7
		'
		Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = true
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label7.Location = New System.Drawing.Point(12, 346)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(119, 20)
		Me.Label7.TabIndex = 8
		Me.Label7.Text = "Result Status"
		'
		'BoardSerialNumber
		'
		Me.BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BoardSerialNumber.Location = New System.Drawing.Point(12, 32)
		Me.BoardSerialNumber.Name = "BoardSerialNumber"
		Me.BoardSerialNumber.Size = New System.Drawing.Size(267, 24)
		Me.BoardSerialNumber.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(175, 20)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Board Serial Number"
		'
		'L_Scanned
		'
		Me.L_Scanned.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.L_Scanned.AutoSize = true
		Me.L_Scanned.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.L_Scanned.Location = New System.Drawing.Point(137, 348)
		Me.L_Scanned.Name = "L_Scanned"
		Me.L_Scanned.Size = New System.Drawing.Size(68, 16)
		Me.L_Scanned.TabIndex = 9
		Me.L_Scanned.Text = "Scanned: "
		'
		'BoardComment
		'
		Me.BoardComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.BoardComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BoardComment.Location = New System.Drawing.Point(12, 185)
		Me.BoardComment.Margin = New System.Windows.Forms.Padding(4)
		Me.BoardComment.Multiline = true
		Me.BoardComment.Name = "BoardComment"
		Me.BoardComment.Size = New System.Drawing.Size(267, 157)
		Me.BoardComment.TabIndex = 7
		Me.BoardComment.TabStop = false
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 161)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(166, 20)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Comment (optional)"
		'
		'EndingSNO_TextBox
		'
		Me.EndingSNO_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
		Me.EndingSNO_TextBox.Location = New System.Drawing.Point(12, 83)
		Me.EndingSNO_TextBox.Margin = New System.Windows.Forms.Padding(4)
		Me.EndingSNO_TextBox.Name = "EndingSNO_TextBox"
		Me.EndingSNO_TextBox.Size = New System.Drawing.Size(267, 24)
		Me.EndingSNO_TextBox.TabIndex = 3
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 59)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(267, 20)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Ending Serial Number (Optional)"
		'
		'CurrentRevision_TextBox
		'
		Me.CurrentRevision_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CurrentRevision_TextBox.Location = New System.Drawing.Point(12, 134)
		Me.CurrentRevision_TextBox.Name = "CurrentRevision_TextBox"
		Me.CurrentRevision_TextBox.Size = New System.Drawing.Size(267, 24)
		Me.CurrentRevision_TextBox.TabIndex = 5
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(12, 111)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(142, 20)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "Current Revision"
		'
		'BSG_AddBoard
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(291, 476)
		Me.Controls.Add(Me.CurrentRevision_TextBox)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.EndingSNO_TextBox)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.BoardComment)
		Me.Controls.Add(Me.L_Scanned)
		Me.Controls.Add(Me.BoardSerialNumber)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ResultStatus)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.SaveButton)
		Me.KeyPreview = true
		Me.Name = "BSG_AddBoard"
		Me.ShowIcon = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "BSG Add Board"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents L_Scanned As System.Windows.Forms.Label
    Friend WithEvents BoardComment As TextBox
    Friend WithEvents Label2 As Label
	Friend WithEvents EndingSNO_TextBox As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents CurrentRevision_TextBox As TextBox
	Friend WithEvents Label4 As Label
End Class
