<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SwapBoards
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
        Me.Label10 = New System.Windows.Forms.Label
        Me.IssueComment = New System.Windows.Forms.TextBox
        Me.NewBoardSerialNumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.OldBoardSerialNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SystemSerialNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SwapBoardsButton = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.CB_SystemStatus = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ResultStatus = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CB_OldBoardStatus = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 171)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 20)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Old Board issue"
        '
        'IssueComment
        '
        Me.IssueComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IssueComment.Location = New System.Drawing.Point(17, 195)
        Me.IssueComment.Margin = New System.Windows.Forms.Padding(4)
        Me.IssueComment.Multiline = True
        Me.IssueComment.Name = "IssueComment"
        Me.IssueComment.Size = New System.Drawing.Size(377, 202)
        Me.IssueComment.TabIndex = 5
        '
        'NewBoardSerialNumber
        '
        Me.NewBoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewBoardSerialNumber.Location = New System.Drawing.Point(17, 141)
        Me.NewBoardSerialNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.NewBoardSerialNumber.Name = "NewBoardSerialNumber"
        Me.NewBoardSerialNumber.Size = New System.Drawing.Size(182, 26)
        Me.NewBoardSerialNumber.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 117)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(214, 20)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "New Board Serial Number"
        '
        'OldBoardSerialNumber
        '
        Me.OldBoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OldBoardSerialNumber.Location = New System.Drawing.Point(17, 87)
        Me.OldBoardSerialNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.OldBoardSerialNumber.Name = "OldBoardSerialNumber"
        Me.OldBoardSerialNumber.Size = New System.Drawing.Size(182, 26)
        Me.OldBoardSerialNumber.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 63)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(207, 20)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Old Board Serial Number"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "System Serial Number"
        '
        'SwapBoardsButton
        '
        Me.SwapBoardsButton.AutoSize = True
        Me.SwapBoardsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SwapBoardsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwapBoardsButton.Location = New System.Drawing.Point(13, 472)
        Me.SwapBoardsButton.Margin = New System.Windows.Forms.Padding(4)
        Me.SwapBoardsButton.Name = "SwapBoardsButton"
        Me.SwapBoardsButton.Size = New System.Drawing.Size(125, 30)
        Me.SwapBoardsButton.TabIndex = 6
        Me.SwapBoardsButton.Text = "Swap Boards"
        Me.SwapBoardsButton.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.AutoSize = True
        Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(332, 472)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(64, 30)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Close"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'CB_SystemStatus
        '
        Me.CB_SystemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SystemStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_SystemStatus.FormattingEnabled = True
        Me.CB_SystemStatus.Location = New System.Drawing.Point(227, 33)
        Me.CB_SystemStatus.Name = "CB_SystemStatus"
        Me.CB_SystemStatus.Size = New System.Drawing.Size(168, 28)
        Me.CB_SystemStatus.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "System Status"
        '
        'ResultStatus
        '
        Me.ResultStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultStatus.Location = New System.Drawing.Point(17, 404)
        Me.ResultStatus.Multiline = True
        Me.ResultStatus.Name = "ResultStatus"
        Me.ResultStatus.ReadOnly = True
        Me.ResultStatus.Size = New System.Drawing.Size(377, 61)
        Me.ResultStatus.TabIndex = 56
        Me.ResultStatus.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Old Board Status"
        '
        'CB_OldBoardStatus
        '
        Me.CB_OldBoardStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_OldBoardStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_OldBoardStatus.FormattingEnabled = True
        Me.CB_OldBoardStatus.Location = New System.Drawing.Point(227, 87)
        Me.CB_OldBoardStatus.Name = "CB_OldBoardStatus"
        Me.CB_OldBoardStatus.Size = New System.Drawing.Size(168, 28)
        Me.CB_OldBoardStatus.TabIndex = 4
        '
        'SwapBoards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 513)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CB_OldBoardStatus)
        Me.Controls.Add(Me.ResultStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_SystemStatus)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.SwapBoardsButton)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.IssueComment)
        Me.Controls.Add(Me.NewBoardSerialNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.OldBoardSerialNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SystemSerialNumber)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Name = "SwapBoards"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Swap Boards"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents IssueComment As System.Windows.Forms.TextBox
    Friend WithEvents NewBoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents OldBoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SystemSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SwapBoardsButton As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CB_SystemStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ResultStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_OldBoardStatus As System.Windows.Forms.ComboBox
End Class
