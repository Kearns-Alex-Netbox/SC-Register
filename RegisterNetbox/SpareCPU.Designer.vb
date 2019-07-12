<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpareCPU
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
        Me.Label11 = New System.Windows.Forms.Label
        Me.CB_SystemType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CPUSerialNumber = New System.Windows.Forms.TextBox
        Me.SystemSerialNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_BaseIP = New System.Windows.Forms.TextBox
        Me.NextMACAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_IPAddress = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.UpdateCPUMACButton = New System.Windows.Forms.Button
        Me.ReturnedSerialNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Type"
        '
        'CB_SystemType
        '
        Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_SystemType.FormattingEnabled = True
        Me.CB_SystemType.Location = New System.Drawing.Point(12, 32)
        Me.CB_SystemType.Name = "CB_SystemType"
        Me.CB_SystemType.Size = New System.Drawing.Size(191, 28)
        Me.CB_SystemType.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "CPU Serial Number"
        '
        'CPUSerialNumber
        '
        Me.CPUSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPUSerialNumber.Location = New System.Drawing.Point(12, 136)
        Me.CPUSerialNumber.Name = "CPUSerialNumber"
        Me.CPUSerialNumber.Size = New System.Drawing.Size(191, 24)
        Me.CPUSerialNumber.TabIndex = 5
        '
        'SystemSerialNumber
        '
        Me.SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemSerialNumber.Location = New System.Drawing.Point(12, 86)
        Me.SystemSerialNumber.Name = "SystemSerialNumber"
        Me.SystemSerialNumber.ReadOnly = True
        Me.SystemSerialNumber.Size = New System.Drawing.Size(191, 24)
        Me.SystemSerialNumber.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "System Serial Number"
        '
        'TB_BaseIP
        '
        Me.TB_BaseIP.AcceptsTab = True
        Me.TB_BaseIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_BaseIP.Location = New System.Drawing.Point(12, 187)
        Me.TB_BaseIP.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_BaseIP.Name = "TB_BaseIP"
        Me.TB_BaseIP.ReadOnly = True
        Me.TB_BaseIP.Size = New System.Drawing.Size(81, 26)
        Me.TB_BaseIP.TabIndex = 7
        Me.TB_BaseIP.TabStop = False
        Me.TB_BaseIP.Text = "192.168.5."
        '
        'NextMACAddress
        '
        Me.NextMACAddress.AcceptsTab = True
        Me.NextMACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextMACAddress.Location = New System.Drawing.Point(12, 241)
        Me.NextMACAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.NextMACAddress.Name = "NextMACAddress"
        Me.NextMACAddress.ReadOnly = True
        Me.NextMACAddress.Size = New System.Drawing.Size(191, 26)
        Me.NextMACAddress.TabIndex = 10
        Me.NextMACAddress.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 217)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Next MAC Address"
        '
        'TB_IPAddress
        '
        Me.TB_IPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_IPAddress.Location = New System.Drawing.Point(106, 187)
        Me.TB_IPAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_IPAddress.Name = "TB_IPAddress"
        Me.TB_IPAddress.Size = New System.Drawing.Size(42, 26)
        Me.TB_IPAddress.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 163)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "IP Address"
        '
        'ExitButton
        '
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(139, 329)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 14
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'UpdateCPUMACButton
        '
        Me.UpdateCPUMACButton.AutoSize = True
        Me.UpdateCPUMACButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UpdateCPUMACButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateCPUMACButton.Location = New System.Drawing.Point(12, 329)
        Me.UpdateCPUMACButton.Margin = New System.Windows.Forms.Padding(4)
        Me.UpdateCPUMACButton.Name = "UpdateCPUMACButton"
        Me.UpdateCPUMACButton.Size = New System.Drawing.Size(119, 30)
        Me.UpdateCPUMACButton.TabIndex = 13
        Me.UpdateCPUMACButton.Text = "Update CPU"
        Me.UpdateCPUMACButton.UseVisualStyleBackColor = True
        '
        'ReturnedSerialNo
        '
        Me.ReturnedSerialNo.AcceptsTab = True
        Me.ReturnedSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnedSerialNo.Location = New System.Drawing.Point(12, 295)
        Me.ReturnedSerialNo.Margin = New System.Windows.Forms.Padding(4)
        Me.ReturnedSerialNo.Name = "ReturnedSerialNo"
        Me.ReturnedSerialNo.ReadOnly = True
        Me.ReturnedSerialNo.Size = New System.Drawing.Size(191, 26)
        Me.ReturnedSerialNo.TabIndex = 12
        Me.ReturnedSerialNo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 271)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Results"
        '
        'SpareCPU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(214, 369)
        Me.Controls.Add(Me.ReturnedSerialNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.UpdateCPUMACButton)
        Me.Controls.Add(Me.TB_BaseIP)
        Me.Controls.Add(Me.NextMACAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_IPAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CB_SystemType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CPUSerialNumber)
        Me.Controls.Add(Me.SystemSerialNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SpareCPU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Spare CPU"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CB_SystemType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CPUSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents SystemSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_BaseIP As System.Windows.Forms.TextBox
    Friend WithEvents NextMACAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_IPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents UpdateCPUMACButton As System.Windows.Forms.Button
    Friend WithEvents ReturnedSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
