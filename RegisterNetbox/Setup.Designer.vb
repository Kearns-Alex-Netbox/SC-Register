<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setup
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
		Me.Label2 = New System.Windows.Forms.Label()
		Me.NextMACAddress = New System.Windows.Forms.TextBox()
		Me.MACAddressBase = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.ParameterFolder = New System.Windows.Forms.TextBox()
		Me.BrowseDirectoryParametersButton = New System.Windows.Forms.Button()
		Me.BrowseDirectoryTempButton = New System.Windows.Forms.Button()
		Me.TempFolder = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.BrowseDirectorySearchButton = New System.Windows.Forms.Button()
		Me.SearchFolder = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.B_Save = New System.Windows.Forms.Button()
		Me.B_Cancel = New System.Windows.Forms.Button()
		Me.L_Version = New System.Windows.Forms.Label()
		Me.Printer_Button = New System.Windows.Forms.Button()
		Me.Printer_TextBox = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'Label2
		'
		Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(25, 364)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(159, 20)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Next MAC Address"
		'
		'NextMACAddress
		'
		Me.NextMACAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.NextMACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NextMACAddress.Location = New System.Drawing.Point(154, 387)
		Me.NextMACAddress.Name = "NextMACAddress"
		Me.NextMACAddress.Size = New System.Drawing.Size(75, 26)
		Me.NextMACAddress.TabIndex = 8
		'
		'MACAddressBase
		'
		Me.MACAddressBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.MACAddressBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MACAddressBase.Location = New System.Drawing.Point(29, 387)
		Me.MACAddressBase.Name = "MACAddressBase"
		Me.MACAddressBase.ReadOnly = True
		Me.MACAddressBase.Size = New System.Drawing.Size(119, 26)
		Me.MACAddressBase.TabIndex = 5
		Me.MACAddressBase.TabStop = False
		Me.MACAddressBase.Text = "70-b3-d5-85-2"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(25, 9)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(218, 20)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "Folder for Parameter Files"
		'
		'ParameterFolder
		'
		Me.ParameterFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ParameterFolder.Location = New System.Drawing.Point(29, 32)
		Me.ParameterFolder.Name = "ParameterFolder"
		Me.ParameterFolder.Size = New System.Drawing.Size(391, 26)
		Me.ParameterFolder.TabIndex = 2
		'
		'BrowseDirectoryParametersButton
		'
		Me.BrowseDirectoryParametersButton.AutoSize = True
		Me.BrowseDirectoryParametersButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BrowseDirectoryParametersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BrowseDirectoryParametersButton.Location = New System.Drawing.Point(29, 64)
		Me.BrowseDirectoryParametersButton.Name = "BrowseDirectoryParametersButton"
		Me.BrowseDirectoryParametersButton.Size = New System.Drawing.Size(155, 30)
		Me.BrowseDirectoryParametersButton.TabIndex = 3
		Me.BrowseDirectoryParametersButton.Text = "Browse Directory"
		Me.BrowseDirectoryParametersButton.UseVisualStyleBackColor = True
		'
		'BrowseDirectoryTempButton
		'
		Me.BrowseDirectoryTempButton.AutoSize = True
		Me.BrowseDirectoryTempButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BrowseDirectoryTempButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BrowseDirectoryTempButton.Location = New System.Drawing.Point(29, 240)
		Me.BrowseDirectoryTempButton.Name = "BrowseDirectoryTempButton"
		Me.BrowseDirectoryTempButton.Size = New System.Drawing.Size(155, 30)
		Me.BrowseDirectoryTempButton.TabIndex = 7
		Me.BrowseDirectoryTempButton.Text = "Browse Directory"
		Me.BrowseDirectoryTempButton.UseVisualStyleBackColor = True
		'
		'TempFolder
		'
		Me.TempFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TempFolder.Location = New System.Drawing.Point(29, 208)
		Me.TempFolder.Name = "TempFolder"
		Me.TempFolder.Size = New System.Drawing.Size(391, 26)
		Me.TempFolder.TabIndex = 6
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(25, 185)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(281, 20)
		Me.Label1.TabIndex = 10
		Me.Label1.Text = "Temp Folder for PDF Save (Local)"
		'
		'BrowseDirectorySearchButton
		'
		Me.BrowseDirectorySearchButton.AutoSize = True
		Me.BrowseDirectorySearchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BrowseDirectorySearchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BrowseDirectorySearchButton.Location = New System.Drawing.Point(29, 152)
		Me.BrowseDirectorySearchButton.Name = "BrowseDirectorySearchButton"
		Me.BrowseDirectorySearchButton.Size = New System.Drawing.Size(155, 30)
		Me.BrowseDirectorySearchButton.TabIndex = 5
		Me.BrowseDirectorySearchButton.Text = "Browse Directory"
		Me.BrowseDirectorySearchButton.UseVisualStyleBackColor = True
		'
		'SearchFolder
		'
		Me.SearchFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SearchFolder.Location = New System.Drawing.Point(29, 120)
		Me.SearchFolder.Name = "SearchFolder"
		Me.SearchFolder.Size = New System.Drawing.Size(391, 26)
		Me.SearchFolder.TabIndex = 4
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(25, 97)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(192, 20)
		Me.Label5.TabIndex = 16
		Me.Label5.Text = "Folder for Search Files"
		'
		'B_Save
		'
		Me.B_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Save.AutoSize = True
		Me.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Save.Location = New System.Drawing.Point(279, 417)
		Me.B_Save.Name = "B_Save"
		Me.B_Save.Size = New System.Drawing.Size(59, 30)
		Me.B_Save.TabIndex = 10
		Me.B_Save.Text = "Save"
		Me.B_Save.UseVisualStyleBackColor = True
		'
		'B_Cancel
		'
		Me.B_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_Cancel.AutoSize = True
		Me.B_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Cancel.Location = New System.Drawing.Point(344, 417)
		Me.B_Cancel.Name = "B_Cancel"
		Me.B_Cancel.Size = New System.Drawing.Size(74, 30)
		Me.B_Cancel.TabIndex = 11
		Me.B_Cancel.Text = "Cancel"
		Me.B_Cancel.UseVisualStyleBackColor = True
		'
		'L_Version
		'
		Me.L_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.L_Version.AutoSize = True
		Me.L_Version.Location = New System.Drawing.Point(12, 430)
		Me.L_Version.Name = "L_Version"
		Me.L_Version.Size = New System.Drawing.Size(40, 13)
		Me.L_Version.TabIndex = 17
		Me.L_Version.Text = "0.0.0.0"
		'
		'Printer_Button
		'
		Me.Printer_Button.AutoSize = True
		Me.Printer_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Printer_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Printer_Button.Location = New System.Drawing.Point(29, 328)
		Me.Printer_Button.Name = "Printer_Button"
		Me.Printer_Button.Size = New System.Drawing.Size(128, 30)
		Me.Printer_Button.TabIndex = 19
		Me.Printer_Button.Text = "Select Printer"
		Me.Printer_Button.UseVisualStyleBackColor = True
		'
		'Printer_TextBox
		'
		Me.Printer_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Printer_TextBox.Location = New System.Drawing.Point(29, 296)
		Me.Printer_TextBox.Name = "Printer_TextBox"
		Me.Printer_TextBox.Size = New System.Drawing.Size(391, 26)
		Me.Printer_TextBox.TabIndex = 18
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(25, 273)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(114, 20)
		Me.Label4.TabIndex = 20
		Me.Label4.Text = "Zebra Printer"
		'
		'Setup
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(430, 453)
		Me.Controls.Add(Me.Printer_Button)
		Me.Controls.Add(Me.Printer_TextBox)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.L_Version)
		Me.Controls.Add(Me.B_Cancel)
		Me.Controls.Add(Me.B_Save)
		Me.Controls.Add(Me.BrowseDirectorySearchButton)
		Me.Controls.Add(Me.SearchFolder)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.BrowseDirectoryTempButton)
		Me.Controls.Add(Me.TempFolder)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.BrowseDirectoryParametersButton)
		Me.Controls.Add(Me.ParameterFolder)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.MACAddressBase)
		Me.Controls.Add(Me.NextMACAddress)
		Me.Controls.Add(Me.Label2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Setup"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Setup"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NextMACAddress As System.Windows.Forms.TextBox
    Friend WithEvents MACAddressBase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ParameterFolder As System.Windows.Forms.TextBox
    Friend WithEvents BrowseDirectoryParametersButton As System.Windows.Forms.Button
    Friend WithEvents BrowseDirectoryTempButton As System.Windows.Forms.Button
    Friend WithEvents TempFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BrowseDirectorySearchButton As System.Windows.Forms.Button
    Friend WithEvents SearchFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents B_Cancel As System.Windows.Forms.Button
    Friend WithEvents L_Version As System.Windows.Forms.Label
	Friend WithEvents Printer_Button As Button
	Friend WithEvents Printer_TextBox As TextBox
	Friend WithEvents Label4 As Label
End Class
