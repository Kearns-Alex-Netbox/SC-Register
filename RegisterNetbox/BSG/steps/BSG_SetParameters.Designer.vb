<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BSG_SetParameters
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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Results = New System.Windows.Forms.ListBox()
		Me.TB_IPAddress = New System.Windows.Forms.TextBox()
		Me.TB_BaseIP = New System.Windows.Forms.TextBox()
		Me.SaveToFileButton = New System.Windows.Forms.Button()
		Me.ButtonExit = New System.Windows.Forms.Button()
		Me.ButtonClearList = New System.Windows.Forms.Button()
		Me.JSONComboBox = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.ButtonSetParam = New System.Windows.Forms.Button()
		Me.ButtonGetParam = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.CB_SystemType = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout
		Me.SuspendLayout
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Results)
		Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(16, 118)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(572, 369)
		Me.GroupBox1.TabIndex = 9
		Me.GroupBox1.TabStop = false
		'
		'Results
		'
		Me.Results.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Results.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Results.FormattingEnabled = true
		Me.Results.ItemHeight = 15
		Me.Results.Location = New System.Drawing.Point(3, 19)
		Me.Results.Name = "Results"
		Me.Results.Size = New System.Drawing.Size(566, 347)
		Me.Results.TabIndex = 0
		Me.Results.TabStop = false
		'
		'TB_IPAddress
		'
		Me.TB_IPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_IPAddress.Location = New System.Drawing.Point(243, 33)
		Me.TB_IPAddress.Margin = New System.Windows.Forms.Padding(4)
		Me.TB_IPAddress.Name = "TB_IPAddress"
		Me.TB_IPAddress.Size = New System.Drawing.Size(42, 26)
		Me.TB_IPAddress.TabIndex = 4
		'
		'TB_BaseIP
		'
		Me.TB_BaseIP.AcceptsTab = true
		Me.TB_BaseIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TB_BaseIP.Location = New System.Drawing.Point(154, 33)
		Me.TB_BaseIP.Margin = New System.Windows.Forms.Padding(4)
		Me.TB_BaseIP.Name = "TB_BaseIP"
		Me.TB_BaseIP.ReadOnly = true
		Me.TB_BaseIP.Size = New System.Drawing.Size(81, 26)
		Me.TB_BaseIP.TabIndex = 3
		Me.TB_BaseIP.TabStop = false
		Me.TB_BaseIP.Text = "192.168.5."
		'
		'SaveToFileButton
		'
		Me.SaveToFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.SaveToFileButton.AutoSize = true
		Me.SaveToFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SaveToFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SaveToFileButton.Location = New System.Drawing.Point(16, 493)
		Me.SaveToFileButton.Name = "SaveToFileButton"
		Me.SaveToFileButton.Size = New System.Drawing.Size(118, 30)
		Me.SaveToFileButton.TabIndex = 10
		Me.SaveToFileButton.Text = "Save To File"
		Me.SaveToFileButton.UseVisualStyleBackColor = true
		'
		'ButtonExit
		'
		Me.ButtonExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ButtonExit.AutoSize = true
		Me.ButtonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ButtonExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ButtonExit.Location = New System.Drawing.Point(524, 493)
		Me.ButtonExit.Name = "ButtonExit"
		Me.ButtonExit.Size = New System.Drawing.Size(64, 30)
		Me.ButtonExit.TabIndex = 12
		Me.ButtonExit.Text = "Close"
		Me.ButtonExit.UseVisualStyleBackColor = true
		'
		'ButtonClearList
		'
		Me.ButtonClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ButtonClearList.AutoSize = true
		Me.ButtonClearList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ButtonClearList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ButtonClearList.Location = New System.Drawing.Point(423, 493)
		Me.ButtonClearList.Name = "ButtonClearList"
		Me.ButtonClearList.Size = New System.Drawing.Size(95, 30)
		Me.ButtonClearList.TabIndex = 11
		Me.ButtonClearList.Text = "Clear List"
		Me.ButtonClearList.UseVisualStyleBackColor = true
		'
		'JSONComboBox
		'
		Me.JSONComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.JSONComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.JSONComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.JSONComboBox.FormattingEnabled = true
		Me.JSONComboBox.Location = New System.Drawing.Point(16, 86)
		Me.JSONComboBox.Name = "JSONComboBox"
		Me.JSONComboBox.Size = New System.Drawing.Size(572, 26)
		Me.JSONComboBox.TabIndex = 8
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 63)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(126, 20)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "Parameter File"
		'
		'ButtonSetParam
		'
		Me.ButtonSetParam.AutoSize = true
		Me.ButtonSetParam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ButtonSetParam.Enabled = false
		Me.ButtonSetParam.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ButtonSetParam.Location = New System.Drawing.Point(444, 30)
		Me.ButtonSetParam.Name = "ButtonSetParam"
		Me.ButtonSetParam.Size = New System.Drawing.Size(144, 30)
		Me.ButtonSetParam.TabIndex = 6
		Me.ButtonSetParam.Text = "Set Parameters"
		Me.ButtonSetParam.UseVisualStyleBackColor = true
		'
		'ButtonGetParam
		'
		Me.ButtonGetParam.AutoSize = true
		Me.ButtonGetParam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ButtonGetParam.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ButtonGetParam.Location = New System.Drawing.Point(292, 30)
		Me.ButtonGetParam.Name = "ButtonGetParam"
		Me.ButtonGetParam.Size = New System.Drawing.Size(146, 30)
		Me.ButtonGetParam.TabIndex = 5
		Me.ButtonGetParam.Text = "Get Parameters"
		Me.ButtonGetParam.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(150, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(97, 20)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "IP Address"
		'
		'Label11
		'
		Me.Label11.AutoSize = true
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label11.Location = New System.Drawing.Point(12, 9)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(47, 20)
		Me.Label11.TabIndex = 0
		Me.Label11.Text = "Type"
		'
		'CB_SystemType
		'
		Me.CB_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.CB_SystemType.FormattingEnabled = true
		Me.CB_SystemType.Location = New System.Drawing.Point(16, 32)
		Me.CB_SystemType.Name = "CB_SystemType"
		Me.CB_SystemType.Size = New System.Drawing.Size(129, 28)
		Me.CB_SystemType.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 115)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(70, 20)
		Me.Label2.TabIndex = 13
		Me.Label2.Text = "Results"
		'
		'BSG_SetParameters
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(603, 532)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.CB_SystemType)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.TB_IPAddress)
		Me.Controls.Add(Me.TB_BaseIP)
		Me.Controls.Add(Me.SaveToFileButton)
		Me.Controls.Add(Me.ButtonExit)
		Me.Controls.Add(Me.ButtonClearList)
		Me.Controls.Add(Me.JSONComboBox)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.ButtonSetParam)
		Me.Controls.Add(Me.ButtonGetParam)
		Me.Controls.Add(Me.Label1)
		Me.KeyPreview = true
		Me.Name = "BSG_SetParameters"
		Me.ShowIcon = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Set Parameters"
		Me.GroupBox1.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Results As System.Windows.Forms.ListBox
    Friend WithEvents TB_IPAddress As System.Windows.Forms.TextBox
    Friend WithEvents TB_BaseIP As System.Windows.Forms.TextBox
    Friend WithEvents SaveToFileButton As System.Windows.Forms.Button
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ButtonClearList As System.Windows.Forms.Button
    Friend WithEvents JSONComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonSetParam As System.Windows.Forms.Button
    Friend WithEvents ButtonGetParam As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CB_SystemType As System.Windows.Forms.ComboBox
	Friend WithEvents Label2 As Label
End Class
