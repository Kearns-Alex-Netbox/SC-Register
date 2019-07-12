<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelCompare
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
		Me.Serial_TextBox = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label_TextBox = New System.Windows.Forms.TextBox()
		Me.Info_Label = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'Serial_TextBox
		'
		Me.Serial_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Serial_TextBox.Location = New System.Drawing.Point(12, 32)
		Me.Serial_TextBox.Name = "Serial_TextBox"
		Me.Serial_TextBox.Size = New System.Drawing.Size(162, 26)
		Me.Serial_TextBox.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(10, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(109, 20)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Serial Number"
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = True
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ExitButton.Location = New System.Drawing.Point(299, 65)
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
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(197, 9)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(48, 20)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Label"
		'
		'Label_TextBox
		'
		Me.Label_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label_TextBox.Location = New System.Drawing.Point(201, 32)
		Me.Label_TextBox.Name = "Label_TextBox"
		Me.Label_TextBox.Size = New System.Drawing.Size(162, 26)
		Me.Label_TextBox.TabIndex = 3
		'
		'Info_Label
		'
		Me.Info_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Info_Label.Location = New System.Drawing.Point(12, 61)
		Me.Info_Label.Name = "Info_Label"
		Me.Info_Label.Size = New System.Drawing.Size(280, 38)
		Me.Info_Label.TabIndex = 5
		Me.Info_Label.Text = "More Info!"
		'
		'LabelCompare
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(376, 108)
		Me.Controls.Add(Me.Info_Label)
		Me.Controls.Add(Me.Label_TextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Serial_TextBox)
		Me.Name = "LabelCompare"
		Me.Text = "LabelCompare"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Serial_TextBox As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents ExitButton As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents Label_TextBox As TextBox
	Friend WithEvents Info_Label As Label
End Class
