<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_RegisterMAC
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
		Me.NextMACAddress = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.SerialNumber = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.UpdateSystemMACButton = New System.Windows.Forms.Button()
		Me.TB_IPAddress = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Boards_ComboBox = New System.Windows.Forms.ComboBox()
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
		Me.NextButton.Location = New System.Drawing.Point(14, 323)
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
		Me.ReturnedSerialNo.Location = New System.Drawing.Point(14, 289)
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
		Me.Label4.Location = New System.Drawing.Point(10, 265)
		Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(202, 20)
		Me.Label4.TabIndex = 20
		Me.Label4.Text = "Returned Serial Number"
		'
		'NextMACAddress
		'
		Me.NextMACAddress.AcceptsTab = true
		Me.NextMACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.NextMACAddress.Location = New System.Drawing.Point(14, 143)
		Me.NextMACAddress.Margin = New System.Windows.Forms.Padding(4)
		Me.NextMACAddress.Name = "NextMACAddress"
		Me.NextMACAddress.ReadOnly = true
		Me.NextMACAddress.Size = New System.Drawing.Size(208, 26)
		Me.NextMACAddress.TabIndex = 19
		Me.NextMACAddress.TabStop = false
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(11, 119)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(159, 20)
		Me.Label3.TabIndex = 18
		Me.Label3.Text = "Next MAC Address"
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
		Me.ExitButton.Location = New System.Drawing.Point(158, 323)
		Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 16
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = true
		'
		'UpdateSystemMACButton
		'
		Me.UpdateSystemMACButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.UpdateSystemMACButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.UpdateSystemMACButton.Location = New System.Drawing.Point(14, 231)
		Me.UpdateSystemMACButton.Margin = New System.Windows.Forms.Padding(4)
		Me.UpdateSystemMACButton.Name = "UpdateSystemMACButton"
		Me.UpdateSystemMACButton.Size = New System.Drawing.Size(208, 30)
		Me.UpdateSystemMACButton.TabIndex = 14
		Me.UpdateSystemMACButton.Text = "Update System MAC"
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
		'Label5
		'
		Me.Label5.AutoSize = true
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label5.Location = New System.Drawing.Point(11, 173)
		Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(98, 20)
		Me.Label5.TabIndex = 38
		Me.Label5.Text = "CPU Board"
		'
		'Boards_ComboBox
		'
		Me.Boards_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Boards_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Boards_ComboBox.FormattingEnabled = true
		Me.Boards_ComboBox.Location = New System.Drawing.Point(14, 196)
		Me.Boards_ComboBox.Name = "Boards_ComboBox"
		Me.Boards_ComboBox.Size = New System.Drawing.Size(208, 28)
		Me.Boards_ComboBox.TabIndex = 37
		'
		'BSG_RegisterMAC
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(233, 362)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Boards_ComboBox)
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
		Me.Name = "BSG_RegisterMAC"
		Me.ShowIcon = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "BSG Register MAC"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents TB_BaseIP As TextBox
	Friend WithEvents NextButton As Button
	Friend WithEvents ReturnedSerialNo As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents NextMACAddress As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents SerialNumber As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents ExitButton As Button
	Friend WithEvents UpdateSystemMACButton As Button
	Friend WithEvents TB_IPAddress As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Boards_ComboBox As ComboBox
End Class
