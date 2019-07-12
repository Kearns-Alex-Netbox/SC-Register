<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddBoardComment
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
		Me.AddBoardCommentButton = New System.Windows.Forms.Button()
		Me.BoardComment = New System.Windows.Forms.TextBox()
		Me.BoardSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.ResultStatus = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CB_BoardStatus = New System.Windows.Forms.ComboBox()
		Me.EndingSNO_TextBox = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.BatchNote_Button = New System.Windows.Forms.Button()
		Me.RTB_Results = New System.Windows.Forms.RichTextBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'AddBoardCommentButton
		'
		Me.AddBoardCommentButton.AutoSize = true
		Me.AddBoardCommentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AddBoardCommentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.AddBoardCommentButton.Location = New System.Drawing.Point(17, 400)
		Me.AddBoardCommentButton.Margin = New System.Windows.Forms.Padding(4)
		Me.AddBoardCommentButton.Name = "AddBoardCommentButton"
		Me.AddBoardCommentButton.Size = New System.Drawing.Size(185, 30)
		Me.AddBoardCommentButton.TabIndex = 4
		Me.AddBoardCommentButton.Text = "Add Board Comment"
		Me.AddBoardCommentButton.UseVisualStyleBackColor = true
		'
		'BoardComment
		'
		Me.BoardComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BoardComment.Location = New System.Drawing.Point(17, 123)
		Me.BoardComment.Margin = New System.Windows.Forms.Padding(4)
		Me.BoardComment.Multiline = true
		Me.BoardComment.Name = "BoardComment"
		Me.BoardComment.Size = New System.Drawing.Size(359, 202)
		Me.BoardComment.TabIndex = 9
		'
		'BoardSerialNumber
		'
		Me.BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BoardSerialNumber.Location = New System.Drawing.Point(17, 33)
		Me.BoardSerialNumber.Margin = New System.Windows.Forms.Padding(4)
		Me.BoardSerialNumber.Name = "BoardSerialNumber"
		Me.BoardSerialNumber.Size = New System.Drawing.Size(184, 26)
		Me.BoardSerialNumber.TabIndex = 2
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(13, 9)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(175, 20)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Board Serial Number"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.AutoSize = true
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(312, 400)
		Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(64, 30)
		Me.Cancel_Button.TabIndex = 5
		Me.Cancel_Button.Text = "Close"
		Me.Cancel_Button.UseVisualStyleBackColor = true
		'
		'ResultStatus
		'
		Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ResultStatus.Location = New System.Drawing.Point(17, 332)
		Me.ResultStatus.Multiline = true
		Me.ResultStatus.Name = "ResultStatus"
		Me.ResultStatus.ReadOnly = true
		Me.ResultStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.ResultStatus.Size = New System.Drawing.Size(359, 61)
		Me.ResultStatus.TabIndex = 10
		Me.ResultStatus.TabStop = false
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(204, 9)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(115, 20)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Board Status"
		'
		'CB_BoardStatus
		'
		Me.CB_BoardStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_BoardStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_BoardStatus.FormattingEnabled = true
		Me.CB_BoardStatus.Location = New System.Drawing.Point(208, 33)
		Me.CB_BoardStatus.Name = "CB_BoardStatus"
		Me.CB_BoardStatus.Size = New System.Drawing.Size(168, 28)
		Me.CB_BoardStatus.TabIndex = 3
		'
		'EndingSNO_TextBox
		'
		Me.EndingSNO_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.EndingSNO_TextBox.Location = New System.Drawing.Point(17, 87)
		Me.EndingSNO_TextBox.Margin = New System.Windows.Forms.Padding(4)
		Me.EndingSNO_TextBox.Name = "EndingSNO_TextBox"
		Me.EndingSNO_TextBox.Size = New System.Drawing.Size(184, 26)
		Me.EndingSNO_TextBox.TabIndex = 7
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(13, 63)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(267, 20)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Ending Serial Number (Optional)"
		'
		'BatchNote_Button
		'
		Me.BatchNote_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BatchNote_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BatchNote_Button.Location = New System.Drawing.Point(209, 85)
		Me.BatchNote_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.BatchNote_Button.Name = "BatchNote_Button"
		Me.BatchNote_Button.Size = New System.Drawing.Size(167, 30)
		Me.BatchNote_Button.TabIndex = 8
		Me.BatchNote_Button.Text = "Add Batch Note"
		Me.BatchNote_Button.UseVisualStyleBackColor = true
		'
		'RTB_Results
		'
		Me.RTB_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.RTB_Results.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.RTB_Results.Location = New System.Drawing.Point(383, 33)
		Me.RTB_Results.Name = "RTB_Results"
		Me.RTB_Results.Size = New System.Drawing.Size(380, 364)
		Me.RTB_Results.TabIndex = 12
		Me.RTB_Results.Text = ""
		'
		'Label19
		'
		Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Label19.AutoSize = true
		Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label19.Location = New System.Drawing.Point(500, 10)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(147, 20)
		Me.Label19.TabIndex = 11
		Me.Label19.Text = "Board Comments"
		'
		'AddBoardComment
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(775, 436)
		Me.Controls.Add(Me.RTB_Results)
		Me.Controls.Add(Me.Label19)
		Me.Controls.Add(Me.BatchNote_Button)
		Me.Controls.Add(Me.EndingSNO_TextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.CB_BoardStatus)
		Me.Controls.Add(Me.ResultStatus)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.AddBoardCommentButton)
		Me.Controls.Add(Me.BoardComment)
		Me.Controls.Add(Me.BoardSerialNumber)
		Me.Controls.Add(Me.Label3)
		Me.KeyPreview = true
		Me.Name = "AddBoardComment"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Add Board Comment"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents AddBoardCommentButton As System.Windows.Forms.Button
    Friend WithEvents BoardComment As System.Windows.Forms.TextBox
    Friend WithEvents BoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_BoardStatus As System.Windows.Forms.ComboBox
    Friend WithEvents EndingSNO_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BatchNote_Button As System.Windows.Forms.Button
	Friend WithEvents RTB_Results As RichTextBox
	Friend WithEvents Label19 As Label
End Class
