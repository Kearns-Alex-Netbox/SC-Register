<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBoxCustom
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
		Me.Three_Button = New System.Windows.Forms.Button()
		Me.Two_Button = New System.Windows.Forms.Button()
		Me.One_Button = New System.Windows.Forms.Button()
		Me.Message_RichTextBox = New System.Windows.Forms.RichTextBox()
		Me.Four_Button = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Three_Button
		'
		Me.Three_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Three_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Three_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Three_Button.Location = New System.Drawing.Point(208, 223)
		Me.Three_Button.Name = "Three_Button"
		Me.Three_Button.Size = New System.Drawing.Size(92, 30)
		Me.Three_Button.TabIndex = 12
		Me.Three_Button.Text = "3"
		Me.Three_Button.UseVisualStyleBackColor = True
		'
		'Two_Button
		'
		Me.Two_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Two_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Two_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Two_Button.Location = New System.Drawing.Point(110, 223)
		Me.Two_Button.Name = "Two_Button"
		Me.Two_Button.Size = New System.Drawing.Size(92, 30)
		Me.Two_Button.TabIndex = 11
		Me.Two_Button.Text = "2"
		Me.Two_Button.UseVisualStyleBackColor = True
		'
		'One_Button
		'
		Me.One_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.One_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.One_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.One_Button.Location = New System.Drawing.Point(12, 223)
		Me.One_Button.Name = "One_Button"
		Me.One_Button.Size = New System.Drawing.Size(92, 30)
		Me.One_Button.TabIndex = 10
		Me.One_Button.Text = "1"
		Me.One_Button.UseVisualStyleBackColor = True
		'
		'Message_RichTextBox
		'
		Me.Message_RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Message_RichTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Message_RichTextBox.Location = New System.Drawing.Point(12, 10)
		Me.Message_RichTextBox.Name = "Message_RichTextBox"
		Me.Message_RichTextBox.ReadOnly = True
		Me.Message_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
		Me.Message_RichTextBox.Size = New System.Drawing.Size(387, 207)
		Me.Message_RichTextBox.TabIndex = 13
		Me.Message_RichTextBox.TabStop = False
		Me.Message_RichTextBox.Text = ""
		'
		'Four_Button
		'
		Me.Four_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Four_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Four_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Four_Button.Location = New System.Drawing.Point(306, 223)
		Me.Four_Button.Name = "Four_Button"
		Me.Four_Button.Size = New System.Drawing.Size(92, 30)
		Me.Four_Button.TabIndex = 14
		Me.Four_Button.Text = "4"
		Me.Four_Button.UseVisualStyleBackColor = True
		'
		'MessageBoxCustom
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(412, 263)
		Me.Controls.Add(Me.Four_Button)
		Me.Controls.Add(Me.Three_Button)
		Me.Controls.Add(Me.Two_Button)
		Me.Controls.Add(Me.One_Button)
		Me.Controls.Add(Me.Message_RichTextBox)
		Me.Name = "MessageBoxCustom"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Message Box"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Three_Button As Button
	Friend WithEvents Two_Button As Button
	Friend WithEvents One_Button As Button
	Friend WithEvents Message_RichTextBox As RichTextBox
	Friend WithEvents Four_Button As Button
End Class
