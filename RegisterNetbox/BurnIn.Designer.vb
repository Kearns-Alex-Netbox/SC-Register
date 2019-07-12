<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BurnIn
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
        Me.ExitButton = New System.Windows.Forms.Button
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.SerialNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LB_Log = New System.Windows.Forms.ListBox
        Me.B_Clear = New System.Windows.Forms.Button
        Me.Queue = New System.Windows.Forms.ListBox
        Me.B_ClearQueue = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Queue"
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(226, 203)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.TabStop = False
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'UpdateButton
        '
        Me.UpdateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UpdateButton.AutoSize = True
        Me.UpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UpdateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateButton.Location = New System.Drawing.Point(17, 203)
        Me.UpdateButton.Margin = New System.Windows.Forms.Padding(4)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(78, 30)
        Me.UpdateButton.TabIndex = 1
        Me.UpdateButton.Text = "Update"
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'SerialNo
        '
        Me.SerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SerialNo.Location = New System.Drawing.Point(17, 33)
        Me.SerialNo.Margin = New System.Windows.Forms.Padding(4)
        Me.SerialNo.Name = "SerialNo"
        Me.SerialNo.Size = New System.Drawing.Size(274, 26)
        Me.SerialNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Serial Number"
        '
        'LB_Log
        '
        Me.LB_Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_Log.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Log.FormattingEnabled = True
        Me.LB_Log.HorizontalScrollbar = True
        Me.LB_Log.ItemHeight = 18
        Me.LB_Log.Location = New System.Drawing.Point(298, 12)
        Me.LB_Log.Name = "LB_Log"
        Me.LB_Log.ScrollAlwaysVisible = True
        Me.LB_Log.Size = New System.Drawing.Size(530, 184)
        Me.LB_Log.TabIndex = 18
        Me.LB_Log.TabStop = False
        '
        'B_Clear
        '
        Me.B_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Clear.AutoSize = True
        Me.B_Clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Clear.Location = New System.Drawing.Point(515, 203)
        Me.B_Clear.Margin = New System.Windows.Forms.Padding(4)
        Me.B_Clear.Name = "B_Clear"
        Me.B_Clear.Size = New System.Drawing.Size(96, 30)
        Me.B_Clear.TabIndex = 4
        Me.B_Clear.TabStop = False
        Me.B_Clear.Text = "Clear Log"
        Me.B_Clear.UseVisualStyleBackColor = True
        '
        'Queue
        '
        Me.Queue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Queue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Queue.FormattingEnabled = True
        Me.Queue.HorizontalScrollbar = True
        Me.Queue.ItemHeight = 18
        Me.Queue.Location = New System.Drawing.Point(17, 84)
        Me.Queue.Name = "Queue"
        Me.Queue.ScrollAlwaysVisible = True
        Me.Queue.Size = New System.Drawing.Size(274, 112)
        Me.Queue.TabIndex = 20
        Me.Queue.TabStop = False
        '
        'B_ClearQueue
        '
        Me.B_ClearQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_ClearQueue.AutoSize = True
        Me.B_ClearQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_ClearQueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_ClearQueue.Location = New System.Drawing.Point(101, 203)
        Me.B_ClearQueue.Margin = New System.Windows.Forms.Padding(4)
        Me.B_ClearQueue.Name = "B_ClearQueue"
        Me.B_ClearQueue.Size = New System.Drawing.Size(119, 30)
        Me.B_ClearQueue.TabIndex = 2
        Me.B_ClearQueue.TabStop = False
        Me.B_ClearQueue.Text = "Clear Queue"
        Me.B_ClearQueue.UseVisualStyleBackColor = True
        '
        'BurnIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(840, 241)
        Me.Controls.Add(Me.B_ClearQueue)
        Me.Controls.Add(Me.Queue)
        Me.Controls.Add(Me.B_Clear)
        Me.Controls.Add(Me.LB_Log)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.SerialNo)
        Me.Controls.Add(Me.Label2)
        Me.KeyPreview = True
        Me.Name = "BurnIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Burn In"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents SerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LB_Log As System.Windows.Forms.ListBox
    Friend WithEvents B_Clear As System.Windows.Forms.Button
    Friend WithEvents Queue As System.Windows.Forms.ListBox
    Friend WithEvents B_ClearQueue As System.Windows.Forms.Button
End Class
