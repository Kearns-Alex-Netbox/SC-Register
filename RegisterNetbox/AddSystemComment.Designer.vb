<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSystemComment
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
		Me.AddSystemCommentButton = New System.Windows.Forms.Button()
		Me.SystemComment = New System.Windows.Forms.TextBox()
		Me.SystemSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.ResultStatus = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CB_SystemStatus = New System.Windows.Forms.ComboBox()
		Me.BatchNote_Button = New System.Windows.Forms.Button()
		Me.EndingSNO_TextBox = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.RTB_Results = New System.Windows.Forms.RichTextBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'AddSystemCommentButton
		'
		Me.AddSystemCommentButton.AutoSize = True
		Me.AddSystemCommentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AddSystemCommentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AddSystemCommentButton.Location = New System.Drawing.Point(17, 401)
		Me.AddSystemCommentButton.Margin = New System.Windows.Forms.Padding(4)
		Me.AddSystemCommentButton.Name = "AddSystemCommentButton"
		Me.AddSystemCommentButton.Size = New System.Drawing.Size(196, 30)
		Me.AddSystemCommentButton.TabIndex = 3
		Me.AddSystemCommentButton.Text = "Add System Comment"
		Me.AddSystemCommentButton.UseVisualStyleBackColor = True
		'
		'SystemComment
		'
		Me.SystemComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SystemComment.Location = New System.Drawing.Point(17, 124)
		Me.SystemComment.Margin = New System.Windows.Forms.Padding(4)
		Me.SystemComment.Multiline = True
		Me.SystemComment.Name = "SystemComment"
		Me.SystemComment.Size = New System.Drawing.Size(359, 202)
		Me.SystemComment.TabIndex = 1
		'
		'SystemSerialNumber
		'
		Me.SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SystemSerialNumber.Location = New System.Drawing.Point(17, 33)
		Me.SystemSerialNumber.Margin = New System.Windows.Forms.Padding(4)
		Me.SystemSerialNumber.Name = "SystemSerialNumber"
		Me.SystemSerialNumber.Size = New System.Drawing.Size(184, 26)
		Me.SystemSerialNumber.TabIndex = 0
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(13, 9)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(186, 20)
		Me.Label2.TabIndex = 30
		Me.Label2.Text = "System Serial Number"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.AutoSize = True
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(312, 401)
		Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(64, 30)
		Me.Cancel_Button.TabIndex = 4
		Me.Cancel_Button.Text = "Close"
		Me.Cancel_Button.UseVisualStyleBackColor = True
		'
		'ResultStatus
		'
		Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ResultStatus.Location = New System.Drawing.Point(17, 333)
		Me.ResultStatus.Multiline = True
		Me.ResultStatus.Name = "ResultStatus"
		Me.ResultStatus.ReadOnly = True
		Me.ResultStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.ResultStatus.Size = New System.Drawing.Size(359, 61)
		Me.ResultStatus.TabIndex = 57
		Me.ResultStatus.TabStop = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(207, 9)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(126, 20)
		Me.Label1.TabIndex = 61
		Me.Label1.Text = "System Status"
		'
		'CB_SystemStatus
		'
		Me.CB_SystemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_SystemStatus.FormattingEnabled = True
		Me.CB_SystemStatus.Location = New System.Drawing.Point(208, 33)
		Me.CB_SystemStatus.Name = "CB_SystemStatus"
		Me.CB_SystemStatus.Size = New System.Drawing.Size(168, 28)
		Me.CB_SystemStatus.TabIndex = 2
		'
		'BatchNote_Button
		'
		Me.BatchNote_Button.AutoSize = True
		Me.BatchNote_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BatchNote_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatchNote_Button.Location = New System.Drawing.Point(209, 86)
		Me.BatchNote_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.BatchNote_Button.Name = "BatchNote_Button"
		Me.BatchNote_Button.Size = New System.Drawing.Size(146, 30)
		Me.BatchNote_Button.TabIndex = 65
		Me.BatchNote_Button.Text = "Add Batch Note"
		Me.BatchNote_Button.UseVisualStyleBackColor = True
		'
		'EndingSNO_TextBox
		'
		Me.EndingSNO_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.EndingSNO_TextBox.Location = New System.Drawing.Point(17, 88)
		Me.EndingSNO_TextBox.Margin = New System.Windows.Forms.Padding(4)
		Me.EndingSNO_TextBox.Name = "EndingSNO_TextBox"
		Me.EndingSNO_TextBox.Size = New System.Drawing.Size(184, 26)
		Me.EndingSNO_TextBox.TabIndex = 63
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(13, 64)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(267, 20)
		Me.Label3.TabIndex = 64
		Me.Label3.Text = "Ending Serial Number (Optional)"
		'
		'RTB_Results
		'
		Me.RTB_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.RTB_Results.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RTB_Results.Location = New System.Drawing.Point(383, 33)
		Me.RTB_Results.Name = "RTB_Results"
		Me.RTB_Results.Size = New System.Drawing.Size(380, 361)
		Me.RTB_Results.TabIndex = 79
		Me.RTB_Results.Text = ""
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label19.Location = New System.Drawing.Point(494, 10)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(158, 20)
		Me.Label19.TabIndex = 78
		Me.Label19.Text = "System Comments"
		'
		'AddSystemComment
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(775, 438)
		Me.Controls.Add(Me.RTB_Results)
		Me.Controls.Add(Me.Label19)
		Me.Controls.Add(Me.BatchNote_Button)
		Me.Controls.Add(Me.EndingSNO_TextBox)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.CB_SystemStatus)
		Me.Controls.Add(Me.ResultStatus)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.AddSystemCommentButton)
		Me.Controls.Add(Me.SystemComment)
		Me.Controls.Add(Me.SystemSerialNumber)
		Me.Controls.Add(Me.Label2)
		Me.KeyPreview = True
		Me.Name = "AddSystemComment"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "AddSystemComment"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents AddSystemCommentButton As System.Windows.Forms.Button
    Friend WithEvents SystemComment As System.Windows.Forms.TextBox
    Friend WithEvents SystemSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_SystemStatus As System.Windows.Forms.ComboBox
    Friend WithEvents BatchNote_Button As System.Windows.Forms.Button
    Friend WithEvents EndingSNO_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents RTB_Results As RichTextBox
	Friend WithEvents Label19 As Label
End Class
