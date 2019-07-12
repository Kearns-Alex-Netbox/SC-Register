<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSystemType
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
        Me.B_Close = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_SystemName = New System.Windows.Forms.TextBox
        Me.TB_BaseSerialNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.B_Add = New System.Windows.Forms.Button
        Me.TB_Result = New System.Windows.Forms.TextBox
        Me.TB_ServerModel = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'B_Close
        '
        Me.B_Close.AutoSize = True
        Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Close.Location = New System.Drawing.Point(207, 251)
        Me.B_Close.Margin = New System.Windows.Forms.Padding(4)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(64, 30)
        Me.B_Close.TabIndex = 4
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "System Name"
        '
        'TB_SystemName
        '
        Me.TB_SystemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_SystemName.Location = New System.Drawing.Point(12, 40)
        Me.TB_SystemName.Name = "TB_SystemName"
        Me.TB_SystemName.Size = New System.Drawing.Size(174, 26)
        Me.TB_SystemName.TabIndex = 0
        '
        'TB_BaseSerialNumber
        '
        Me.TB_BaseSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_BaseSerialNumber.Location = New System.Drawing.Point(12, 96)
        Me.TB_BaseSerialNumber.Name = "TB_BaseSerialNumber"
        Me.TB_BaseSerialNumber.Size = New System.Drawing.Size(174, 26)
        Me.TB_BaseSerialNumber.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Base Serial Number"
        '
        'B_Add
        '
        Me.B_Add.AutoSize = True
        Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_Add.Location = New System.Drawing.Point(12, 251)
        Me.B_Add.Margin = New System.Windows.Forms.Padding(4)
        Me.B_Add.Name = "B_Add"
        Me.B_Add.Size = New System.Drawing.Size(51, 30)
        Me.B_Add.TabIndex = 3
        Me.B_Add.Text = "Add"
        Me.B_Add.UseVisualStyleBackColor = True
        '
        'TB_Result
        '
        Me.TB_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Result.Location = New System.Drawing.Point(12, 184)
        Me.TB_Result.Multiline = True
        Me.TB_Result.Name = "TB_Result"
        Me.TB_Result.ReadOnly = True
        Me.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_Result.Size = New System.Drawing.Size(260, 60)
        Me.TB_Result.TabIndex = 12
        Me.TB_Result.TabStop = False
        '
        'TB_ServerModel
        '
        Me.TB_ServerModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_ServerModel.Location = New System.Drawing.Point(16, 152)
        Me.TB_ServerModel.Name = "TB_ServerModel"
        Me.TB_ServerModel.Size = New System.Drawing.Size(174, 26)
        Me.TB_ServerModel.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Server Model"
        '
        'AddSystemType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 289)
        Me.Controls.Add(Me.TB_ServerModel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_Result)
        Me.Controls.Add(Me.B_Add)
        Me.Controls.Add(Me.TB_BaseSerialNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_SystemName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_Close)
        Me.KeyPreview = True
        Me.Name = "AddSystemType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add System Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_SystemName As System.Windows.Forms.TextBox
    Friend WithEvents TB_BaseSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_Add As System.Windows.Forms.Button
    Friend WithEvents TB_Result As System.Windows.Forms.TextBox
    Friend WithEvents TB_ServerModel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
