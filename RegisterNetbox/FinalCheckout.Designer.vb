<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalCheckout
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CheckoutStatus = New System.Windows.Forms.TextBox()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.UpdateButton = New System.Windows.Forms.Button()
		Me.SerialNo = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 63)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(62, 20)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Status"
		'
		'CheckoutStatus
		'
		Me.CheckoutStatus.AcceptsTab = true
		Me.CheckoutStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.CheckoutStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CheckoutStatus.Location = New System.Drawing.Point(16, 87)
		Me.CheckoutStatus.Margin = New System.Windows.Forms.Padding(4)
		Me.CheckoutStatus.Multiline = true
		Me.CheckoutStatus.Name = "CheckoutStatus"
		Me.CheckoutStatus.ReadOnly = true
		Me.CheckoutStatus.Size = New System.Drawing.Size(318, 63)
		Me.CheckoutStatus.TabIndex = 3
		Me.CheckoutStatus.TabStop = false
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(270, 158)
		Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 5
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'UpdateButton
		'
		Me.UpdateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.UpdateButton.AutoSize = true
		Me.UpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.UpdateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.UpdateButton.Location = New System.Drawing.Point(16, 158)
		Me.UpdateButton.Margin = New System.Windows.Forms.Padding(4)
		Me.UpdateButton.Name = "UpdateButton"
		Me.UpdateButton.Size = New System.Drawing.Size(159, 30)
		Me.UpdateButton.TabIndex = 4
		Me.UpdateButton.Text = "Update and Scan"
		Me.UpdateButton.UseVisualStyleBackColor = true
		'
		'SerialNo
		'
		Me.SerialNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.SerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SerialNo.Location = New System.Drawing.Point(16, 33)
		Me.SerialNo.Margin = New System.Windows.Forms.Padding(4)
		Me.SerialNo.Name = "SerialNo"
		Me.SerialNo.Size = New System.Drawing.Size(318, 26)
		Me.SerialNo.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 9)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(122, 20)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Serial Number"
		'
		'FinalCheckout
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = true
		Me.ClientSize = New System.Drawing.Size(346, 199)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.CheckoutStatus)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.UpdateButton)
		Me.Controls.Add(Me.SerialNo)
		Me.Controls.Add(Me.Label2)
		Me.KeyPreview = true
		Me.Name = "FinalCheckout"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Final Checkout"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckoutStatus As System.Windows.Forms.TextBox
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents SerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
