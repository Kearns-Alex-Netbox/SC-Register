<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PrintLabels
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Quantity_TextBox = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Serial_TextBox = New System.Windows.Forms.TextBox()
		Me.Print_Button = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Quantity_TextBox
		'
		Me.Quantity_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Quantity_TextBox.Location = New System.Drawing.Point(16, 32)
		Me.Quantity_TextBox.Name = "Quantity_TextBox"
		Me.Quantity_TextBox.Size = New System.Drawing.Size(110, 26)
		Me.Quantity_TextBox.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 9)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(68, 20)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Quantity"
		'
		'ExitButton
		'
		Me.ExitButton.AutoSize = True
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ExitButton.Location = New System.Drawing.Point(301, 65)
		Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 5
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(130, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(109, 20)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Serial Number"
		'
		'Serial_TextBox
		'
		Me.Serial_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Serial_TextBox.Location = New System.Drawing.Point(132, 32)
		Me.Serial_TextBox.Name = "Serial_TextBox"
		Me.Serial_TextBox.Size = New System.Drawing.Size(235, 26)
		Me.Serial_TextBox.TabIndex = 3
		'
		'Print_Button
		'
		Me.Print_Button.AutoSize = True
		Me.Print_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Print_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Print_Button.Location = New System.Drawing.Point(132, 65)
		Me.Print_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Print_Button.Name = "Print_Button"
		Me.Print_Button.Size = New System.Drawing.Size(56, 30)
		Me.Print_Button.TabIndex = 4
		Me.Print_Button.Text = "Print"
		Me.Print_Button.UseVisualStyleBackColor = True
		'
		'PrintLabels
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(373, 102)
		Me.Controls.Add(Me.Print_Button)
		Me.Controls.Add(Me.Quantity_TextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Serial_TextBox)
		Me.Name = "PrintLabels"
		Me.Text = "PrintLabels"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Quantity_TextBox As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents ExitButton As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Serial_TextBox As TextBox
	Friend WithEvents Print_Button As Button
End Class
