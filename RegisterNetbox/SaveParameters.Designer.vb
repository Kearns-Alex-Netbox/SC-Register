<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveParameters
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
        Me.BrowseFile = New System.Windows.Forms.Button
        Me.JSONFileName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ParamDescription = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.B_Save = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Model = New System.Windows.Forms.TextBox
        Me.TB_Date = New System.Windows.Forms.TextBox
        Me.TB_Version = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'BrowseFile
        '
        Me.BrowseFile.AutoSize = True
        Me.BrowseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BrowseFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseFile.Location = New System.Drawing.Point(349, 30)
        Me.BrowseFile.Name = "BrowseFile"
        Me.BrowseFile.Size = New System.Drawing.Size(112, 30)
        Me.BrowseFile.TabIndex = 1
        Me.BrowseFile.Text = "Browse File"
        Me.BrowseFile.UseVisualStyleBackColor = True
        '
        'JSONFileName
        '
        Me.JSONFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JSONFileName.Location = New System.Drawing.Point(12, 32)
        Me.JSONFileName.Name = "JSONFileName"
        Me.JSONFileName.Size = New System.Drawing.Size(331, 26)
        Me.JSONFileName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "JSON File Name (.JSON)"
        '
        'ParamDescription
        '
        Me.ParamDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParamDescription.Location = New System.Drawing.Point(12, 138)
        Me.ParamDescription.Multiline = True
        Me.ParamDescription.Name = "ParamDescription"
        Me.ParamDescription.Size = New System.Drawing.Size(449, 72)
        Me.ParamDescription.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "JSON Description Text"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.AutoSize = True
        Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(387, 216)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(74, 30)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Cancel"
        '
        'B_Save
        '
        Me.B_Save.AutoSize = True
        Me.B_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Save.Location = New System.Drawing.Point(322, 216)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(59, 30)
        Me.B_Save.TabIndex = 6
        Me.B_Save.Text = "Save"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Server Model"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(140, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Date (YYYY-MM-DD)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Version (V#.#.#)"
        '
        'TB_Model
        '
        Me.TB_Model.Enabled = False
        Me.TB_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Model.Location = New System.Drawing.Point(12, 86)
        Me.TB_Model.Name = "TB_Model"
        Me.TB_Model.Size = New System.Drawing.Size(126, 26)
        Me.TB_Model.TabIndex = 2
        '
        'TB_Date
        '
        Me.TB_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Date.Location = New System.Drawing.Point(144, 86)
        Me.TB_Date.Name = "TB_Date"
        Me.TB_Date.Size = New System.Drawing.Size(175, 26)
        Me.TB_Date.TabIndex = 3
        '
        'TB_Version
        '
        Me.TB_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Version.Location = New System.Drawing.Point(325, 86)
        Me.TB_Version.Name = "TB_Version"
        Me.TB_Version.Size = New System.Drawing.Size(136, 26)
        Me.TB_Version.TabIndex = 4
        '
        'SaveParameters
        '
        Me.AcceptButton = Me.B_Save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(478, 256)
        Me.Controls.Add(Me.TB_Version)
        Me.Controls.Add(Me.TB_Date)
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
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveParameters"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Save Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents TB_Date As System.Windows.Forms.TextBox
    Friend WithEvents TB_Version As System.Windows.Forms.TextBox

End Class
