<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBoardInfo
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
        Me.L_BoardSerialNumber = New System.Windows.Forms.Label
        Me.BoardVersion = New System.Windows.Forms.TextBox
        Me.label = New System.Windows.Forms.Label
        Me.BootloaderVersion = New System.Windows.Forms.TextBox
        Me.labell = New System.Windows.Forms.Label
        Me.BoardStatus = New System.Windows.Forms.TextBox
        Me.Labelll = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.LastUpdate = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BoardType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.HardwareVersion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MACAddress = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CPUID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.B_AddComment = New System.Windows.Forms.Button
        Me.RTB_Results = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'L_BoardSerialNumber
        '
        Me.L_BoardSerialNumber.AutoSize = True
        Me.L_BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_BoardSerialNumber.Location = New System.Drawing.Point(12, 9)
        Me.L_BoardSerialNumber.Name = "L_BoardSerialNumber"
        Me.L_BoardSerialNumber.Size = New System.Drawing.Size(259, 29)
        Me.L_BoardSerialNumber.TabIndex = 1
        Me.L_BoardSerialNumber.Text = "Board Serial Number"
        '
        'BoardVersion
        '
        Me.BoardVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoardVersion.Location = New System.Drawing.Point(12, 232)
        Me.BoardVersion.Name = "BoardVersion"
        Me.BoardVersion.ReadOnly = True
        Me.BoardVersion.Size = New System.Drawing.Size(233, 24)
        Me.BoardVersion.TabIndex = 59
        Me.BoardVersion.TabStop = False
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.Location = New System.Drawing.Point(12, 209)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(147, 20)
        Me.label.TabIndex = 58
        Me.label.Text = "Software Version"
        '
        'BootloaderVersion
        '
        Me.BootloaderVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BootloaderVersion.Location = New System.Drawing.Point(12, 182)
        Me.BootloaderVersion.Name = "BootloaderVersion"
        Me.BootloaderVersion.ReadOnly = True
        Me.BootloaderVersion.Size = New System.Drawing.Size(233, 24)
        Me.BootloaderVersion.TabIndex = 57
        Me.BootloaderVersion.TabStop = False
        '
        'labell
        '
        Me.labell.AutoSize = True
        Me.labell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labell.Location = New System.Drawing.Point(12, 159)
        Me.labell.Name = "labell"
        Me.labell.Size = New System.Drawing.Size(163, 20)
        Me.labell.TabIndex = 56
        Me.labell.Text = "Bootloader Version"
        '
        'BoardStatus
        '
        Me.BoardStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoardStatus.Location = New System.Drawing.Point(12, 82)
        Me.BoardStatus.Name = "BoardStatus"
        Me.BoardStatus.ReadOnly = True
        Me.BoardStatus.Size = New System.Drawing.Size(233, 24)
        Me.BoardStatus.TabIndex = 61
        Me.BoardStatus.TabStop = False
        '
        'Labelll
        '
        Me.Labelll.AutoSize = True
        Me.Labelll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelll.Location = New System.Drawing.Point(13, 59)
        Me.Labelll.Name = "Labelll"
        Me.Labelll.Size = New System.Drawing.Size(115, 20)
        Me.Labelll.TabIndex = 60
        Me.Labelll.Text = "Board Status"
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(412, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 20)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Board Comments"
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.AutoSize = True
        Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(653, 452)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(64, 30)
        Me.ExitButton.TabIndex = 62
        Me.ExitButton.Text = "Close"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'LastUpdate
        '
        Me.LastUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastUpdate.Location = New System.Drawing.Point(13, 432)
        Me.LastUpdate.Name = "LastUpdate"
        Me.LastUpdate.ReadOnly = True
        Me.LastUpdate.Size = New System.Drawing.Size(233, 24)
        Me.LastUpdate.TabIndex = 66
        Me.LastUpdate.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 409)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 20)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Last Update"
        '
        'BoardType
        '
        Me.BoardType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoardType.Location = New System.Drawing.Point(12, 132)
        Me.BoardType.Name = "BoardType"
        Me.BoardType.ReadOnly = True
        Me.BoardType.Size = New System.Drawing.Size(233, 24)
        Me.BoardType.TabIndex = 68
        Me.BoardType.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Board Type"
        '
        'HardwareVersion
        '
        Me.HardwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HardwareVersion.Location = New System.Drawing.Point(13, 282)
        Me.HardwareVersion.Name = "HardwareVersion"
        Me.HardwareVersion.ReadOnly = True
        Me.HardwareVersion.Size = New System.Drawing.Size(233, 24)
        Me.HardwareVersion.TabIndex = 70
        Me.HardwareVersion.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Hardware Version"
        '
        'MACAddress
        '
        Me.MACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MACAddress.Location = New System.Drawing.Point(13, 332)
        Me.MACAddress.Name = "MACAddress"
        Me.MACAddress.ReadOnly = True
        Me.MACAddress.Size = New System.Drawing.Size(233, 24)
        Me.MACAddress.TabIndex = 72
        Me.MACAddress.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 309)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "MAC Address"
        '
        'CPUID
        '
        Me.CPUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPUID.Location = New System.Drawing.Point(13, 382)
        Me.CPUID.Name = "CPUID"
        Me.CPUID.ReadOnly = True
        Me.CPUID.Size = New System.Drawing.Size(233, 24)
        Me.CPUID.TabIndex = 74
        Me.CPUID.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 359)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "CPU ID"
        '
        'B_AddComment
        '
        Me.B_AddComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_AddComment.AutoSize = True
        Me.B_AddComment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_AddComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_AddComment.Location = New System.Drawing.Point(251, 452)
        Me.B_AddComment.Name = "B_AddComment"
        Me.B_AddComment.Size = New System.Drawing.Size(132, 30)
        Me.B_AddComment.TabIndex = 75
        Me.B_AddComment.Text = "Add Comment"
        Me.B_AddComment.UseVisualStyleBackColor = True
        '
        'RTB_Results
        '
        Me.RTB_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB_Results.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_Results.Location = New System.Drawing.Point(252, 82)
        Me.RTB_Results.Name = "RTB_Results"
        Me.RTB_Results.Size = New System.Drawing.Size(466, 364)
        Me.RTB_Results.TabIndex = 76
        Me.RTB_Results.Text = ""
        '
        'ViewBoardInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(729, 489)
        Me.Controls.Add(Me.RTB_Results)
        Me.Controls.Add(Me.B_AddComment)
        Me.Controls.Add(Me.CPUID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MACAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HardwareVersion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BoardType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LastUpdate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.BoardStatus)
        Me.Controls.Add(Me.Labelll)
        Me.Controls.Add(Me.BoardVersion)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.BootloaderVersion)
        Me.Controls.Add(Me.labell)
        Me.Controls.Add(Me.L_BoardSerialNumber)
        Me.Name = "ViewBoardInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Board Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents L_BoardSerialNumber As System.Windows.Forms.Label
    Friend WithEvents BoardVersion As System.Windows.Forms.TextBox
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents BootloaderVersion As System.Windows.Forms.TextBox
    Friend WithEvents labell As System.Windows.Forms.Label
    Friend WithEvents BoardStatus As System.Windows.Forms.TextBox
    Friend WithEvents Labelll As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents LastUpdate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BoardType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HardwareVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MACAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CPUID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents B_AddComment As System.Windows.Forms.Button
    Friend WithEvents RTB_Results As System.Windows.Forms.RichTextBox
End Class
