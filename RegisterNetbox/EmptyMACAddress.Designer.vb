<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmptyMACAddress
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
        Me.ExitButton = New System.Windows.Forms.Button
        Me.LB_Addresses = New System.Windows.Forms.ListBox
        Me.B_5Addresses = New System.Windows.Forms.Button
        Me.B_10Addresses = New System.Windows.Forms.Button
        Me.B_25Addresses = New System.Windows.Forms.Button
        Me.B_50Addresses = New System.Windows.Forms.Button
        Me.B_100Addresses = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(439, 209)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'LB_Addresses
        '
        Me.LB_Addresses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Addresses.FormattingEnabled = True
        Me.LB_Addresses.HorizontalScrollbar = True
        Me.LB_Addresses.ItemHeight = 20
        Me.LB_Addresses.Location = New System.Drawing.Point(248, 13)
        Me.LB_Addresses.Name = "LB_Addresses"
        Me.LB_Addresses.ScrollAlwaysVisible = True
        Me.LB_Addresses.Size = New System.Drawing.Size(255, 184)
        Me.LB_Addresses.TabIndex = 5
        '
        'B_5Addresses
        '
        Me.B_5Addresses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_5Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_5Addresses.Location = New System.Drawing.Point(13, 13)
        Me.B_5Addresses.Margin = New System.Windows.Forms.Padding(4)
        Me.B_5Addresses.Name = "B_5Addresses"
        Me.B_5Addresses.Size = New System.Drawing.Size(225, 30)
        Me.B_5Addresses.TabIndex = 0
        Me.B_5Addresses.Text = "Grab Next 5 Addresses"
        Me.B_5Addresses.UseVisualStyleBackColor = True
        '
        'B_10Addresses
        '
        Me.B_10Addresses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_10Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_10Addresses.Location = New System.Drawing.Point(13, 51)
        Me.B_10Addresses.Margin = New System.Windows.Forms.Padding(4)
        Me.B_10Addresses.Name = "B_10Addresses"
        Me.B_10Addresses.Size = New System.Drawing.Size(225, 30)
        Me.B_10Addresses.TabIndex = 1
        Me.B_10Addresses.Text = "Grab Next 10 Addresses"
        Me.B_10Addresses.UseVisualStyleBackColor = True
        '
        'B_25Addresses
        '
        Me.B_25Addresses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_25Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_25Addresses.Location = New System.Drawing.Point(13, 89)
        Me.B_25Addresses.Margin = New System.Windows.Forms.Padding(4)
        Me.B_25Addresses.Name = "B_25Addresses"
        Me.B_25Addresses.Size = New System.Drawing.Size(225, 30)
        Me.B_25Addresses.TabIndex = 2
        Me.B_25Addresses.Text = "Grab Next 25 Addresses"
        Me.B_25Addresses.UseVisualStyleBackColor = True
        '
        'B_50Addresses
        '
        Me.B_50Addresses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_50Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_50Addresses.Location = New System.Drawing.Point(13, 127)
        Me.B_50Addresses.Margin = New System.Windows.Forms.Padding(4)
        Me.B_50Addresses.Name = "B_50Addresses"
        Me.B_50Addresses.Size = New System.Drawing.Size(225, 30)
        Me.B_50Addresses.TabIndex = 3
        Me.B_50Addresses.Text = "Grab Next 50 Addresses"
        Me.B_50Addresses.UseVisualStyleBackColor = True
        '
        'B_100Addresses
        '
        Me.B_100Addresses.AutoSize = True
        Me.B_100Addresses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_100Addresses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_100Addresses.Location = New System.Drawing.Point(13, 165)
        Me.B_100Addresses.Margin = New System.Windows.Forms.Padding(4)
        Me.B_100Addresses.Name = "B_100Addresses"
        Me.B_100Addresses.Size = New System.Drawing.Size(225, 30)
        Me.B_100Addresses.TabIndex = 4
        Me.B_100Addresses.Text = "Grab Next 100 Addresses"
        Me.B_100Addresses.UseVisualStyleBackColor = True
        '
        'EmptyMACAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 244)
        Me.Controls.Add(Me.B_100Addresses)
        Me.Controls.Add(Me.B_50Addresses)
        Me.Controls.Add(Me.B_25Addresses)
        Me.Controls.Add(Me.B_10Addresses)
        Me.Controls.Add(Me.B_5Addresses)
        Me.Controls.Add(Me.LB_Addresses)
        Me.Controls.Add(Me.ExitButton)
        Me.KeyPreview = True
        Me.Name = "EmptyMACAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Empty MAC Address"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents LB_Addresses As System.Windows.Forms.ListBox
    Friend WithEvents B_5Addresses As System.Windows.Forms.Button
    Friend WithEvents B_10Addresses As System.Windows.Forms.Button
    Friend WithEvents B_25Addresses As System.Windows.Forms.Button
    Friend WithEvents B_50Addresses As System.Windows.Forms.Button
    Friend WithEvents B_100Addresses As System.Windows.Forms.Button
End Class
