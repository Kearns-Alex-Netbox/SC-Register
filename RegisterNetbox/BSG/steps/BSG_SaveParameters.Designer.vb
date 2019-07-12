<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_SaveParameters
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
		Me.BrowseFile = New System.Windows.Forms.Button()
		Me.JSONFileName = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ParamDescription = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.B_Save = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.TB_Model = New System.Windows.Forms.TextBox()
		Me.TB_Version = New System.Windows.Forms.TextBox()
		Me.Date_DTP = New System.Windows.Forms.DateTimePicker()
		Me.SuspendLayout
		'
		'BrowseFile
		'
		Me.BrowseFile.AutoSize = true
		Me.BrowseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BrowseFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.BrowseFile.Location = New System.Drawing.Point(294, 30)
		Me.BrowseFile.Name = "BrowseFile"
		Me.BrowseFile.Size = New System.Drawing.Size(112, 30)
		Me.BrowseFile.TabIndex = 2
		Me.BrowseFile.Text = "Browse File"
		Me.BrowseFile.UseVisualStyleBackColor = true
		'
		'JSONFileName
		'
		Me.JSONFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.JSONFileName.Location = New System.Drawing.Point(12, 32)
		Me.JSONFileName.Name = "JSONFileName"
		Me.JSONFileName.Size = New System.Drawing.Size(276, 26)
		Me.JSONFileName.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(208, 20)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "JSON File Name (.JSON)"
		'
		'ParamDescription
		'
		Me.ParamDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ParamDescription.Location = New System.Drawing.Point(12, 138)
		Me.ParamDescription.Multiline = true
		Me.ParamDescription.Name = "ParamDescription"
		Me.ParamDescription.Size = New System.Drawing.Size(394, 72)
		Me.ParamDescription.TabIndex = 10
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 115)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(190, 20)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "JSON Description Text"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.AutoSize = true
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(332, 216)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(74, 30)
		Me.Cancel_Button.TabIndex = 12
		Me.Cancel_Button.Text = "Cancel"
		'
		'B_Save
		'
		Me.B_Save.AutoSize = true
		Me.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.B_Save.Location = New System.Drawing.Point(267, 216)
		Me.B_Save.Name = "B_Save"
		Me.B_Save.Size = New System.Drawing.Size(59, 30)
		Me.B_Save.TabIndex = 11
		Me.B_Save.Text = "Save"
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 63)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(114, 20)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "Server Model"
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(140, 63)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(48, 20)
		Me.Label4.TabIndex = 5
		Me.Label4.Text = "Date"
		'
		'Label5
		'
		Me.Label5.AutoSize = true
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label5.Location = New System.Drawing.Point(266, 63)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(139, 20)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "Version (V#.#.#)"
		'
		'TB_Model
		'
		Me.TB_Model.Enabled = false
		Me.TB_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_Model.Location = New System.Drawing.Point(12, 86)
		Me.TB_Model.Name = "TB_Model"
		Me.TB_Model.Size = New System.Drawing.Size(126, 26)
		Me.TB_Model.TabIndex = 4
		'
		'TB_Version
		'
		Me.TB_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_Version.Location = New System.Drawing.Point(270, 86)
		Me.TB_Version.Name = "TB_Version"
		Me.TB_Version.Size = New System.Drawing.Size(136, 26)
		Me.TB_Version.TabIndex = 8
		'
		'Date_DTP
		'
		Me.Date_DTP.CalendarFont = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Date_DTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Date_DTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.Date_DTP.Location = New System.Drawing.Point(144, 86)
		Me.Date_DTP.Name = "Date_DTP"
		Me.Date_DTP.Size = New System.Drawing.Size(120, 26)
		Me.Date_DTP.TabIndex = 6
		Me.Date_DTP.Value = New Date(2019, 4, 9, 8, 52, 40, 0)
		'
		'BSG_SaveParameters
		'
		Me.AcceptButton = Me.B_Save
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = true
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(419, 256)
		Me.Controls.Add(Me.Date_DTP)
		Me.Controls.Add(Me.TB_Version)
		Me.Controls.Add(Me.TB_Model)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.B_Save)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ParamDescription)
		Me.Controls.Add(Me.BrowseFile)
		Me.Controls.Add(Me.JSONFileName)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "BSG_SaveParameters"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "BSG Save Parameters"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents BrowseFile As System.Windows.Forms.Button
    Friend WithEvents JSONFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ParamDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Model As System.Windows.Forms.TextBox
    Friend WithEvents TB_Version As System.Windows.Forms.TextBox
	Friend WithEvents Date_DTP As DateTimePicker
End Class
