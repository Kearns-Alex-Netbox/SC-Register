<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetCPUinfo
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
		Me.TB_BaseIP = New System.Windows.Forms.TextBox()
		Me.NextButton = New System.Windows.Forms.Button()
		Me.ReturnedSerialNo = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.SerialNumber = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.UpdateSystemMACButton = New System.Windows.Forms.Button()
		Me.TB_IPAddress = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'TB_BaseIP
		'
		Me.TB_BaseIP.AcceptsTab = true
		Me.TB_BaseIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_BaseIP.Location = New System.Drawing.Point(14, 35)
		Me.TB_BaseIP.Margin = New System.Windows.Forms.Padding(4)
		Me.TB_BaseIP.Name = "TB_BaseIP"
		Me.TB_BaseIP.ReadOnly = true
		Me.TB_BaseIP.Size = New System.Drawing.Size(81, 26)
		Me.TB_BaseIP.TabIndex = 22
		Me.TB_BaseIP.TabStop = false
		Me.TB_BaseIP.Text = "192.168.5."
		'
		'NextButton
		'
		Me.NextButton.AutoSize = true
		Me.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.NextButton.Location = New System.Drawing.Point(15, 215)
		Me.NextButton.Margin = New System.Windows.Forms.Padding(4)
		Me.NextButton.Name = "NextButton"
		Me.NextButton.Size = New System.Drawing.Size(134, 30)
		Me.NextButton.TabIndex = 15
		Me.NextButton.Text = "Update + Next"
		Me.NextButton.UseVisualStyleBackColor = true
		'
		'ReturnedSerialNo
		'
		Me.ReturnedSerialNo.AcceptsTab = true
		Me.ReturnedSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ReturnedSerialNo.Location = New System.Drawing.Point(13, 181)
		Me.ReturnedSerialNo.Margin = New System.Windows.Forms.Padding(4)
		Me.ReturnedSerialNo.Name = "ReturnedSerialNo"
		Me.ReturnedSerialNo.ReadOnly = true
		Me.ReturnedSerialNo.Size = New System.Drawing.Size(208, 26)
		Me.ReturnedSerialNo.TabIndex = 21
		Me.ReturnedSerialNo.TabStop = false
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(9, 157)
		Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(202, 20)
		Me.Label4.TabIndex = 20
		Me.Label4.Text = "Returned Serial Number"
		'
		'SerialNumber
		'
		Me.SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SerialNumber.Location = New System.Drawing.Point(14, 89)
		Me.SerialNumber.Margin = New System.Windows.Forms.Padding(4)
		Me.SerialNumber.Name = "SerialNumber"
		Me.SerialNumber.Size = New System.Drawing.Size(208, 26)
		Me.SerialNumber.TabIndex = 13
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(11, 65)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(186, 20)
		Me.Label2.TabIndex = 17
		Me.Label2.Text = "System Serial Number"
		'
		'ExitButton
		'
		Me.ExitButton.AutoSize = true
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ExitButton.Location = New System.Drawing.Point(157, 215)
		Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 16
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'UpdateSystemMACButton
		'
		Me.UpdateSystemMACButton.AutoSize = true
		Me.UpdateSystemMACButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.UpdateSystemMACButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.UpdateSystemMACButton.Location = New System.Drawing.Point(8, 123)
		Me.UpdateSystemMACButton.Margin = New System.Windows.Forms.Padding(4)
		Me.UpdateSystemMACButton.Name = "UpdateSystemMACButton"
		Me.UpdateSystemMACButton.Size = New System.Drawing.Size(216, 30)
		Me.UpdateSystemMACButton.TabIndex = 14
		Me.UpdateSystemMACButton.Text = "Update CPU Information"
		Me.UpdateSystemMACButton.UseVisualStyleBackColor = true
		'
		'TB_IPAddress
		'
		Me.TB_IPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_IPAddress.Location = New System.Drawing.Point(103, 35)
		Me.TB_IPAddress.Margin = New System.Windows.Forms.Padding(4)
		Me.TB_IPAddress.Name = "TB_IPAddress"
		Me.TB_IPAddress.Size = New System.Drawing.Size(42, 26)
		Me.TB_IPAddress.TabIndex = 11
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(10, 11)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(97, 20)
		Me.Label1.TabIndex = 12
		Me.Label1.Text = "IP Address"
		'
		'NB_GetCPUinfo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(233, 253)
		Me.Controls.Add(Me.TB_BaseIP)
		Me.Controls.Add(Me.NextButton)
		Me.Controls.Add(Me.ReturnedSerialNo)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.SerialNumber)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.UpdateSystemMACButton)
		Me.Controls.Add(Me.TB_IPAddress)
		Me.Controls.Add(Me.Label1)
		Me.KeyPreview = true
		Me.Name = "NB_GetCPUinfo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "NB Get CPU Info"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents TB_BaseIP As System.Windows.Forms.TextBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents ReturnedSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents UpdateSystemMACButton As System.Windows.Forms.Button
    Friend WithEvents TB_IPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
