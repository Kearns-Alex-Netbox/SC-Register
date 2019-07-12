<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterMAC
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
        Me.TB_IPAddress = New System.Windows.Forms.TextBox
        Me.UpdateSystemMACButton = New System.Windows.Forms.Button
        Me.ExitButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.SerialNumber = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.NextMACAddress = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ReturnedSerialNo = New System.Windows.Forms.TextBox
        Me.NextButton = New System.Windows.Forms.Button
        Me.TB_BaseIP = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP Address"
        '
        'TB_IPAddress
        '
        Me.TB_IPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_IPAddress.Location = New System.Drawing.Point(101, 33)
        Me.TB_IPAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_IPAddress.Name = "TB_IPAddress"
        Me.TB_IPAddress.Size = New System.Drawing.Size(42, 26)
        Me.TB_IPAddress.TabIndex = 0
        '
        'UpdateSystemMACButton
        '
        Me.UpdateSystemMACButton.AutoSize = True
        Me.UpdateSystemMACButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UpdateSystemMACButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateSystemMACButton.Location = New System.Drawing.Point(24, 175)
        Me.UpdateSystemMACButton.Margin = New System.Windows.Forms.Padding(4)
        Me.UpdateSystemMACButton.Name = "UpdateSystemMACButton"
        Me.UpdateSystemMACButton.Size = New System.Drawing.Size(185, 30)
        Me.UpdateSystemMACButton.TabIndex = 2
        Me.UpdateSystemMACButton.Text = "Update System MAC"
        Me.UpdateSystemMACButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(156, 267)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 4
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "System Serial Number"
        '
        'SerialNumber
        '
        Me.SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SerialNumber.Location = New System.Drawing.Point(12, 87)
        Me.SerialNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.SerialNumber.Name = "SerialNumber"
        Me.SerialNumber.Size = New System.Drawing.Size(208, 26)
        Me.SerialNumber.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Next MAC Address"
        '
        'NextMACAddress
        '
        Me.NextMACAddress.AcceptsTab = True
        Me.NextMACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextMACAddress.Location = New System.Drawing.Point(14, 141)
        Me.NextMACAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.NextMACAddress.Name = "NextMACAddress"
        Me.NextMACAddress.ReadOnly = True
        Me.NextMACAddress.Size = New System.Drawing.Size(206, 26)
        Me.NextMACAddress.TabIndex = 7
        Me.NextMACAddress.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 209)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Returned Serial Number"
        '
        'ReturnedSerialNo
        '
        Me.ReturnedSerialNo.AcceptsTab = True
        Me.ReturnedSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnedSerialNo.Location = New System.Drawing.Point(12, 233)
        Me.ReturnedSerialNo.Margin = New System.Windows.Forms.Padding(4)
        Me.ReturnedSerialNo.Name = "ReturnedSerialNo"
        Me.ReturnedSerialNo.ReadOnly = True
        Me.ReturnedSerialNo.Size = New System.Drawing.Size(208, 26)
        Me.ReturnedSerialNo.TabIndex = 9
        Me.ReturnedSerialNo.TabStop = False
        '
        'NextButton
        '
        Me.NextButton.AutoSize = True
        Me.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.NextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextButton.Location = New System.Drawing.Point(14, 267)
        Me.NextButton.Margin = New System.Windows.Forms.Padding(4)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(134, 30)
        Me.NextButton.TabIndex = 3
        Me.NextButton.Text = "Update + Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'TB_BaseIP
        '
        Me.TB_BaseIP.AcceptsTab = True
        Me.TB_BaseIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_BaseIP.Location = New System.Drawing.Point(12, 33)
        Me.TB_BaseIP.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_BaseIP.Name = "TB_BaseIP"
        Me.TB_BaseIP.ReadOnly = True
        Me.TB_BaseIP.Size = New System.Drawing.Size(81, 26)
        Me.TB_BaseIP.TabIndex = 10
        Me.TB_BaseIP.TabStop = False
        Me.TB_BaseIP.Text = "192.168.5."
        '
        'RegisterMAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(233, 310)
        Me.Controls.Add(Me.TB_BaseIP)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.ReturnedSerialNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NextMACAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SerialNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.UpdateSystemMACButton)
        Me.Controls.Add(Me.TB_IPAddress)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RegisterMAC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Register Network"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_IPAddress As System.Windows.Forms.TextBox
    Friend WithEvents UpdateSystemMACButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NextMACAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ReturnedSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents TB_BaseIP As System.Windows.Forms.TextBox

End Class
