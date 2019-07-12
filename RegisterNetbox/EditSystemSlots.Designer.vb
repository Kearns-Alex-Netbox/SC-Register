<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSystemSlots
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
		Me.TB_SystemSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CB_Slot = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.LB_SystemSlots = New System.Windows.Forms.ListBox()
		Me.TB_BoardSerialNumber = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.B_Remove = New System.Windows.Forms.Button()
		Me.B_Add = New System.Windows.Forms.Button()
		Me.B_Close = New System.Windows.Forms.Button()
		Me.TB_Result = New System.Windows.Forms.TextBox()
		Me.LB_Definitions = New System.Windows.Forms.ListBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'TB_SystemSerialNumber
		'
		Me.TB_SystemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TB_SystemSerialNumber.Location = New System.Drawing.Point(215, 9)
		Me.TB_SystemSerialNumber.Name = "TB_SystemSerialNumber"
		Me.TB_SystemSerialNumber.Size = New System.Drawing.Size(193, 26)
		Me.TB_SystemSerialNumber.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(197, 24)
		Me.Label1.TabIndex = 9
		Me.Label1.Text = "System Serial Number"
		'
		'CB_Slot
		'
		Me.CB_Slot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_Slot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_Slot.FormattingEnabled = True
		Me.CB_Slot.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.CB_Slot.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
		Me.CB_Slot.Location = New System.Drawing.Point(215, 41)
		Me.CB_Slot.Name = "CB_Slot"
		Me.CB_Slot.Size = New System.Drawing.Size(193, 28)
		Me.CB_Slot.TabIndex = 1
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 41)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(115, 24)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "Slot Number"
		'
		'LB_SystemSlots
		'
		Me.LB_SystemSlots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LB_SystemSlots.FormattingEnabled = True
		Me.LB_SystemSlots.HorizontalScrollbar = True
		Me.LB_SystemSlots.ItemHeight = 20
		Me.LB_SystemSlots.Location = New System.Drawing.Point(6, 25)
		Me.LB_SystemSlots.Name = "LB_SystemSlots"
		Me.LB_SystemSlots.ScrollAlwaysVisible = True
		Me.LB_SystemSlots.Size = New System.Drawing.Size(252, 224)
		Me.LB_SystemSlots.TabIndex = 15
		Me.LB_SystemSlots.TabStop = False
		'
		'TB_BoardSerialNumber
		'
		Me.TB_BoardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TB_BoardSerialNumber.Location = New System.Drawing.Point(215, 75)
		Me.TB_BoardSerialNumber.Name = "TB_BoardSerialNumber"
		Me.TB_BoardSerialNumber.Size = New System.Drawing.Size(193, 26)
		Me.TB_BoardSerialNumber.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 75)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(186, 24)
		Me.Label2.TabIndex = 17
		Me.Label2.Text = "Board Serial Number"
		'
		'B_Remove
		'
		Me.B_Remove.AutoSize = True
		Me.B_Remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Remove.Location = New System.Drawing.Point(324, 280)
		Me.B_Remove.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Remove.Name = "B_Remove"
		Me.B_Remove.Size = New System.Drawing.Size(84, 30)
		Me.B_Remove.TabIndex = 4
		Me.B_Remove.Text = "Remove"
		Me.B_Remove.UseVisualStyleBackColor = True
		'
		'B_Add
		'
		Me.B_Add.AutoSize = True
		Me.B_Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Add.Location = New System.Drawing.Point(265, 280)
		Me.B_Add.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Add.Name = "B_Add"
		Me.B_Add.Size = New System.Drawing.Size(51, 30)
		Me.B_Add.TabIndex = 3
		Me.B_Add.Text = "Add"
		Me.B_Add.UseVisualStyleBackColor = True
		'
		'B_Close
		'
		Me.B_Close.AutoSize = True
		Me.B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_Close.Location = New System.Drawing.Point(885, 280)
		Me.B_Close.Margin = New System.Windows.Forms.Padding(4)
		Me.B_Close.Name = "B_Close"
		Me.B_Close.Size = New System.Drawing.Size(64, 30)
		Me.B_Close.TabIndex = 5
		Me.B_Close.Text = "Close"
		Me.B_Close.UseVisualStyleBackColor = True
		'
		'TB_Result
		'
		Me.TB_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TB_Result.Location = New System.Drawing.Point(16, 107)
		Me.TB_Result.Multiline = True
		Me.TB_Result.Name = "TB_Result"
		Me.TB_Result.ReadOnly = True
		Me.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.TB_Result.Size = New System.Drawing.Size(392, 166)
		Me.TB_Result.TabIndex = 21
		Me.TB_Result.TabStop = False
		'
		'LB_Definitions
		'
		Me.LB_Definitions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LB_Definitions.FormattingEnabled = True
		Me.LB_Definitions.HorizontalScrollbar = True
		Me.LB_Definitions.ItemHeight = 20
		Me.LB_Definitions.Location = New System.Drawing.Point(6, 25)
		Me.LB_Definitions.Name = "LB_Definitions"
		Me.LB_Definitions.ScrollAlwaysVisible = True
		Me.LB_Definitions.Size = New System.Drawing.Size(252, 224)
		Me.LB_Definitions.TabIndex = 22
		Me.LB_Definitions.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.LB_SystemSlots)
		Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(415, 9)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(264, 264)
		Me.GroupBox1.TabIndex = 59
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "System Details"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.LB_Definitions)
		Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(685, 9)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(264, 264)
		Me.GroupBox2.TabIndex = 60
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "System Definition"
		'
		'EditSystemSlots
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(955, 317)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.TB_Result)
		Me.Controls.Add(Me.B_Remove)
		Me.Controls.Add(Me.B_Add)
		Me.Controls.Add(Me.B_Close)
		Me.Controls.Add(Me.TB_BoardSerialNumber)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.CB_Slot)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.TB_SystemSerialNumber)
		Me.Controls.Add(Me.Label1)
		Me.KeyPreview = True
		Me.Name = "EditSystemSlots"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Edit System Slots"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TB_SystemSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Slot As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LB_SystemSlots As System.Windows.Forms.ListBox
    Friend WithEvents TB_BoardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_Remove As System.Windows.Forms.Button
    Friend WithEvents B_Add As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents TB_Result As System.Windows.Forms.TextBox
    Friend WithEvents LB_Definitions As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
