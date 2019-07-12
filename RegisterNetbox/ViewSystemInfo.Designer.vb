<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSystemInfo
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
		Me.L_SytemSerialNumber = New System.Windows.Forms.Label()
		Me.MotherBoardLabel = New System.Windows.Forms.Label()
		Me.MotherboardSerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot1SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot1Label = New System.Windows.Forms.Label()
		Me.Slot2Label = New System.Windows.Forms.Label()
		Me.Slot2SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot3Label = New System.Windows.Forms.Label()
		Me.Slot3SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot4Label = New System.Windows.Forms.Label()
		Me.Slot4SerialNumber = New System.Windows.Forms.TextBox()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.Slot5Label = New System.Windows.Forms.Label()
		Me.Slot5SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot6Label = New System.Windows.Forms.Label()
		Me.Slot6SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot7Label = New System.Windows.Forms.Label()
		Me.Slot7SerialNumber = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.BarcodeDate = New System.Windows.Forms.TextBox()
		Me.RegisterDate = New System.Windows.Forms.TextBox()
		Me.ShipDate = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.CPU_Version = New System.Windows.Forms.TextBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.MACAddress = New System.Windows.Forms.TextBox()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.ParameterDate = New System.Windows.Forms.TextBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.ParameterFile = New System.Windows.Forms.TextBox()
		Me.BurnInDate = New System.Windows.Forms.TextBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.CheckoutDate = New System.Windows.Forms.TextBox()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.SystemStatus = New System.Windows.Forms.TextBox()
		Me.Labelll = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.SystemType = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LastUpdate = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.B_AddComment = New System.Windows.Forms.Button()
		Me.RTB_Results = New System.Windows.Forms.RichTextBox()
		Me.PWRAtoD_Version = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.Details = New System.Windows.Forms.TabPage()
		Me.Service = New System.Windows.Forms.TabPage()
		Me.Service_DataGridView = New System.Windows.Forms.DataGridView()
		Me.TP_Scrapped = New System.Windows.Forms.TabPage()
		Me.DGV_Scrapped = New System.Windows.Forms.DataGridView()
		Me.TP_Extras = New System.Windows.Forms.TabPage()
		Me.DGV_Extras = New System.Windows.Forms.DataGridView()
		Me.Print_Button = New System.Windows.Forms.Button()
		Me.B_CheckoutSheet = New System.Windows.Forms.Button()
		Me.L_NotMostCurrent = New System.Windows.Forms.Label()
		Me.Slot10Label = New System.Windows.Forms.Label()
		Me.Slot10SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot9Label = New System.Windows.Forms.Label()
		Me.Slot9SerialNumber = New System.Windows.Forms.TextBox()
		Me.Slot8Label = New System.Windows.Forms.Label()
		Me.Slot8SerialNumber = New System.Windows.Forms.TextBox()
		Me.TabControl1.SuspendLayout()
		Me.Details.SuspendLayout()
		Me.Service.SuspendLayout()
		CType(Me.Service_DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TP_Scrapped.SuspendLayout()
		CType(Me.DGV_Scrapped, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TP_Extras.SuspendLayout()
		CType(Me.DGV_Extras, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'L_SytemSerialNumber
		'
		Me.L_SytemSerialNumber.AutoSize = True
		Me.L_SytemSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.L_SytemSerialNumber.Location = New System.Drawing.Point(12, 9)
		Me.L_SytemSerialNumber.Name = "L_SytemSerialNumber"
		Me.L_SytemSerialNumber.Size = New System.Drawing.Size(182, 29)
		Me.L_SytemSerialNumber.TabIndex = 0
		Me.L_SytemSerialNumber.Text = "Serial Number"
		'
		'MotherBoardLabel
		'
		Me.MotherBoardLabel.AutoSize = True
		Me.MotherBoardLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MotherBoardLabel.Location = New System.Drawing.Point(323, 3)
		Me.MotherBoardLabel.Name = "MotherBoardLabel"
		Me.MotherBoardLabel.Size = New System.Drawing.Size(229, 20)
		Me.MotherBoardLabel.TabIndex = 2
		Me.MotherBoardLabel.Text = "Motherboard Serial Number"
		'
		'MotherboardSerialNumber
		'
		Me.MotherboardSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MotherboardSerialNumber.Location = New System.Drawing.Point(323, 26)
		Me.MotherboardSerialNumber.Name = "MotherboardSerialNumber"
		Me.MotherboardSerialNumber.ReadOnly = True
		Me.MotherboardSerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.MotherboardSerialNumber.TabIndex = 2
		Me.MotherboardSerialNumber.TabStop = False
		'
		'Slot1SerialNumber
		'
		Me.Slot1SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot1SerialNumber.Location = New System.Drawing.Point(323, 76)
		Me.Slot1SerialNumber.Name = "Slot1SerialNumber"
		Me.Slot1SerialNumber.ReadOnly = True
		Me.Slot1SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot1SerialNumber.TabIndex = 3
		Me.Slot1SerialNumber.TabStop = False
		'
		'Slot1Label
		'
		Me.Slot1Label.AutoSize = True
		Me.Slot1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot1Label.Location = New System.Drawing.Point(323, 53)
		Me.Slot1Label.Name = "Slot1Label"
		Me.Slot1Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot1Label.TabIndex = 5
		Me.Slot1Label.Text = "Slot 1 Serial Number"
		'
		'Slot2Label
		'
		Me.Slot2Label.AutoSize = True
		Me.Slot2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot2Label.Location = New System.Drawing.Point(323, 103)
		Me.Slot2Label.Name = "Slot2Label"
		Me.Slot2Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot2Label.TabIndex = 7
		Me.Slot2Label.Text = "Slot 2 Serial Number"
		'
		'Slot2SerialNumber
		'
		Me.Slot2SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot2SerialNumber.Location = New System.Drawing.Point(323, 126)
		Me.Slot2SerialNumber.Name = "Slot2SerialNumber"
		Me.Slot2SerialNumber.ReadOnly = True
		Me.Slot2SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot2SerialNumber.TabIndex = 4
		Me.Slot2SerialNumber.TabStop = False
		'
		'Slot3Label
		'
		Me.Slot3Label.AutoSize = True
		Me.Slot3Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot3Label.Location = New System.Drawing.Point(323, 153)
		Me.Slot3Label.Name = "Slot3Label"
		Me.Slot3Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot3Label.TabIndex = 9
		Me.Slot3Label.Text = "Slot 3 Serial Number"
		'
		'Slot3SerialNumber
		'
		Me.Slot3SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot3SerialNumber.Location = New System.Drawing.Point(323, 176)
		Me.Slot3SerialNumber.Name = "Slot3SerialNumber"
		Me.Slot3SerialNumber.ReadOnly = True
		Me.Slot3SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot3SerialNumber.TabIndex = 5
		Me.Slot3SerialNumber.TabStop = False
		'
		'Slot4Label
		'
		Me.Slot4Label.AutoSize = True
		Me.Slot4Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot4Label.Location = New System.Drawing.Point(323, 203)
		Me.Slot4Label.Name = "Slot4Label"
		Me.Slot4Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot4Label.TabIndex = 11
		Me.Slot4Label.Text = "Slot 4 Serial Number"
		'
		'Slot4SerialNumber
		'
		Me.Slot4SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot4SerialNumber.Location = New System.Drawing.Point(323, 226)
		Me.Slot4SerialNumber.Name = "Slot4SerialNumber"
		Me.Slot4SerialNumber.ReadOnly = True
		Me.Slot4SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot4SerialNumber.TabIndex = 6
		Me.Slot4SerialNumber.TabStop = False
		'
		'ExitButton
		'
		Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ExitButton.AutoSize = True
		Me.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ExitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ExitButton.Location = New System.Drawing.Point(1127, 436)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(64, 30)
		Me.ExitButton.TabIndex = 3
		Me.ExitButton.Text = "Close"
		Me.ExitButton.UseVisualStyleBackColor = True
		'
		'Slot5Label
		'
		Me.Slot5Label.AutoSize = True
		Me.Slot5Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot5Label.Location = New System.Drawing.Point(323, 253)
		Me.Slot5Label.Name = "Slot5Label"
		Me.Slot5Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot5Label.TabIndex = 20
		Me.Slot5Label.Text = "Slot 5 Serial Number"
		'
		'Slot5SerialNumber
		'
		Me.Slot5SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot5SerialNumber.Location = New System.Drawing.Point(323, 276)
		Me.Slot5SerialNumber.Name = "Slot5SerialNumber"
		Me.Slot5SerialNumber.ReadOnly = True
		Me.Slot5SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot5SerialNumber.TabIndex = 7
		Me.Slot5SerialNumber.TabStop = False
		'
		'Slot6Label
		'
		Me.Slot6Label.AutoSize = True
		Me.Slot6Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot6Label.Location = New System.Drawing.Point(558, 3)
		Me.Slot6Label.Name = "Slot6Label"
		Me.Slot6Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot6Label.TabIndex = 22
		Me.Slot6Label.Text = "Slot 6 Serial Number"
		'
		'Slot6SerialNumber
		'
		Me.Slot6SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot6SerialNumber.Location = New System.Drawing.Point(558, 26)
		Me.Slot6SerialNumber.Name = "Slot6SerialNumber"
		Me.Slot6SerialNumber.ReadOnly = True
		Me.Slot6SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot6SerialNumber.TabIndex = 21
		Me.Slot6SerialNumber.TabStop = False
		'
		'Slot7Label
		'
		Me.Slot7Label.AutoSize = True
		Me.Slot7Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot7Label.Location = New System.Drawing.Point(558, 53)
		Me.Slot7Label.Name = "Slot7Label"
		Me.Slot7Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot7Label.TabIndex = 24
		Me.Slot7Label.Text = "Slot 7 Serial Number"
		'
		'Slot7SerialNumber
		'
		Me.Slot7SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot7SerialNumber.Location = New System.Drawing.Point(558, 76)
		Me.Slot7SerialNumber.Name = "Slot7SerialNumber"
		Me.Slot7SerialNumber.ReadOnly = True
		Me.Slot7SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot7SerialNumber.TabIndex = 23
		Me.Slot7SerialNumber.TabStop = False
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(168, 3)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 20)
		Me.Label7.TabIndex = 25
		Me.Label7.Text = "Barcode Date"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.Location = New System.Drawing.Point(168, 53)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(91, 20)
		Me.Label11.TabIndex = 26
		Me.Label11.Text = "MAC Date"
		'
		'BarcodeDate
		'
		Me.BarcodeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BarcodeDate.Location = New System.Drawing.Point(168, 26)
		Me.BarcodeDate.Name = "BarcodeDate"
		Me.BarcodeDate.ReadOnly = True
		Me.BarcodeDate.Size = New System.Drawing.Size(149, 24)
		Me.BarcodeDate.TabIndex = 27
		Me.BarcodeDate.TabStop = False
		'
		'RegisterDate
		'
		Me.RegisterDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RegisterDate.Location = New System.Drawing.Point(168, 76)
		Me.RegisterDate.Name = "RegisterDate"
		Me.RegisterDate.ReadOnly = True
		Me.RegisterDate.Size = New System.Drawing.Size(149, 24)
		Me.RegisterDate.TabIndex = 28
		Me.RegisterDate.TabStop = False
		'
		'ShipDate
		'
		Me.ShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ShipDate.Location = New System.Drawing.Point(168, 276)
		Me.ShipDate.Name = "ShipDate"
		Me.ShipDate.ReadOnly = True
		Me.ShipDate.Size = New System.Drawing.Size(149, 24)
		Me.ShipDate.TabIndex = 30
		Me.ShipDate.TabStop = False
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(168, 253)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(89, 20)
		Me.Label12.TabIndex = 29
		Me.Label12.Text = "Ship Date"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.Location = New System.Drawing.Point(6, 103)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(111, 20)
		Me.Label13.TabIndex = 31
		Me.Label13.Text = "CPU Version"
		'
		'CPU_Version
		'
		Me.CPU_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CPU_Version.Location = New System.Drawing.Point(6, 126)
		Me.CPU_Version.Name = "CPU_Version"
		Me.CPU_Version.ReadOnly = True
		Me.CPU_Version.Size = New System.Drawing.Size(156, 24)
		Me.CPU_Version.TabIndex = 32
		Me.CPU_Version.TabStop = False
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(6, 203)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(118, 20)
		Me.Label14.TabIndex = 33
		Me.Label14.Text = "MAC Address"
		'
		'MACAddress
		'
		Me.MACAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MACAddress.Location = New System.Drawing.Point(6, 226)
		Me.MACAddress.Name = "MACAddress"
		Me.MACAddress.ReadOnly = True
		Me.MACAddress.Size = New System.Drawing.Size(156, 24)
		Me.MACAddress.TabIndex = 34
		Me.MACAddress.TabStop = False
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label15.Location = New System.Drawing.Point(168, 103)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(136, 20)
		Me.Label15.TabIndex = 35
		Me.Label15.Text = "Parameter Date"
		'
		'ParameterDate
		'
		Me.ParameterDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ParameterDate.Location = New System.Drawing.Point(168, 126)
		Me.ParameterDate.Name = "ParameterDate"
		Me.ParameterDate.ReadOnly = True
		Me.ParameterDate.Size = New System.Drawing.Size(149, 24)
		Me.ParameterDate.TabIndex = 36
		Me.ParameterDate.TabStop = False
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label16.Location = New System.Drawing.Point(6, 303)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(126, 20)
		Me.Label16.TabIndex = 37
		Me.Label16.Text = "Parameter File"
		'
		'ParameterFile
		'
		Me.ParameterFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ParameterFile.Location = New System.Drawing.Point(6, 326)
		Me.ParameterFile.Name = "ParameterFile"
		Me.ParameterFile.ReadOnly = True
		Me.ParameterFile.Size = New System.Drawing.Size(733, 24)
		Me.ParameterFile.TabIndex = 38
		Me.ParameterFile.TabStop = False
		'
		'BurnInDate
		'
		Me.BurnInDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BurnInDate.Location = New System.Drawing.Point(168, 176)
		Me.BurnInDate.Name = "BurnInDate"
		Me.BurnInDate.ReadOnly = True
		Me.BurnInDate.Size = New System.Drawing.Size(149, 24)
		Me.BurnInDate.TabIndex = 40
		Me.BurnInDate.TabStop = False
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label17.Location = New System.Drawing.Point(168, 153)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(112, 20)
		Me.Label17.TabIndex = 39
		Me.Label17.Text = "Burn In Date"
		'
		'CheckoutDate
		'
		Me.CheckoutDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckoutDate.Location = New System.Drawing.Point(168, 226)
		Me.CheckoutDate.Name = "CheckoutDate"
		Me.CheckoutDate.ReadOnly = True
		Me.CheckoutDate.Size = New System.Drawing.Size(149, 24)
		Me.CheckoutDate.TabIndex = 42
		Me.CheckoutDate.TabStop = False
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label18.Location = New System.Drawing.Point(168, 203)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(129, 20)
		Me.Label18.TabIndex = 41
		Me.Label18.Text = "Checkout Date"
		'
		'SystemStatus
		'
		Me.SystemStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SystemStatus.Location = New System.Drawing.Point(6, 76)
		Me.SystemStatus.Name = "SystemStatus"
		Me.SystemStatus.ReadOnly = True
		Me.SystemStatus.Size = New System.Drawing.Size(156, 24)
		Me.SystemStatus.TabIndex = 48
		Me.SystemStatus.TabStop = False
		'
		'Labelll
		'
		Me.Labelll.AutoSize = True
		Me.Labelll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Labelll.Location = New System.Drawing.Point(6, 53)
		Me.Labelll.Name = "Labelll"
		Me.Labelll.Size = New System.Drawing.Size(126, 20)
		Me.Labelll.TabIndex = 47
		Me.Labelll.Text = "System Status"
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label19.Location = New System.Drawing.Point(900, 3)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(158, 20)
		Me.Label19.TabIndex = 51
		Me.Label19.Text = "System Comments"
		'
		'SystemType
		'
		Me.SystemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SystemType.Location = New System.Drawing.Point(6, 26)
		Me.SystemType.Name = "SystemType"
		Me.SystemType.ReadOnly = True
		Me.SystemType.Size = New System.Drawing.Size(156, 24)
		Me.SystemType.TabIndex = 70
		Me.SystemType.TabStop = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(6, 3)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(111, 20)
		Me.Label1.TabIndex = 69
		Me.Label1.Text = "System Type"
		'
		'LastUpdate
		'
		Me.LastUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LastUpdate.Location = New System.Drawing.Point(10, 276)
		Me.LastUpdate.Name = "LastUpdate"
		Me.LastUpdate.ReadOnly = True
		Me.LastUpdate.Size = New System.Drawing.Size(152, 24)
		Me.LastUpdate.TabIndex = 72
		Me.LastUpdate.TabStop = False
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(6, 253)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(108, 20)
		Me.Label2.TabIndex = 71
		Me.Label2.Text = "Last Update"
		'
		'B_AddComment
		'
		Me.B_AddComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_AddComment.AutoSize = True
		Me.B_AddComment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_AddComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_AddComment.Location = New System.Drawing.Point(913, 324)
		Me.B_AddComment.Name = "B_AddComment"
		Me.B_AddComment.Size = New System.Drawing.Size(132, 30)
		Me.B_AddComment.TabIndex = 76
		Me.B_AddComment.Text = "Add Comment"
		Me.B_AddComment.UseVisualStyleBackColor = True
		'
		'RTB_Results
		'
		Me.RTB_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.RTB_Results.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RTB_Results.Location = New System.Drawing.Point(793, 26)
		Me.RTB_Results.Name = "RTB_Results"
		Me.RTB_Results.Size = New System.Drawing.Size(372, 292)
		Me.RTB_Results.TabIndex = 77
		Me.RTB_Results.Text = ""
		'
		'PWRAtoD_Version
		'
		Me.PWRAtoD_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PWRAtoD_Version.Location = New System.Drawing.Point(6, 176)
		Me.PWRAtoD_Version.Name = "PWRAtoD_Version"
		Me.PWRAtoD_Version.ReadOnly = True
		Me.PWRAtoD_Version.Size = New System.Drawing.Size(156, 24)
		Me.PWRAtoD_Version.TabIndex = 79
		Me.PWRAtoD_Version.TabStop = False
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(6, 153)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(156, 20)
		Me.Label3.TabIndex = 78
		Me.Label3.Text = "PWRAtoD Version"
		'
		'TabControl1
		'
		Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TabControl1.Controls.Add(Me.Details)
		Me.TabControl1.Controls.Add(Me.Service)
		Me.TabControl1.Controls.Add(Me.TP_Scrapped)
		Me.TabControl1.Controls.Add(Me.TP_Extras)
		Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TabControl1.Location = New System.Drawing.Point(12, 41)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(1179, 390)
		Me.TabControl1.TabIndex = 80
		'
		'Details
		'
		Me.Details.BackColor = System.Drawing.SystemColors.Control
		Me.Details.Controls.Add(Me.Slot10Label)
		Me.Details.Controls.Add(Me.Slot10SerialNumber)
		Me.Details.Controls.Add(Me.Slot9Label)
		Me.Details.Controls.Add(Me.Slot9SerialNumber)
		Me.Details.Controls.Add(Me.Slot8Label)
		Me.Details.Controls.Add(Me.Slot8SerialNumber)
		Me.Details.Controls.Add(Me.Label1)
		Me.Details.Controls.Add(Me.B_AddComment)
		Me.Details.Controls.Add(Me.RTB_Results)
		Me.Details.Controls.Add(Me.ParameterFile)
		Me.Details.Controls.Add(Me.Label16)
		Me.Details.Controls.Add(Me.PWRAtoD_Version)
		Me.Details.Controls.Add(Me.Label19)
		Me.Details.Controls.Add(Me.Label13)
		Me.Details.Controls.Add(Me.LastUpdate)
		Me.Details.Controls.Add(Me.Label3)
		Me.Details.Controls.Add(Me.Label2)
		Me.Details.Controls.Add(Me.Slot7Label)
		Me.Details.Controls.Add(Me.CPU_Version)
		Me.Details.Controls.Add(Me.Slot7SerialNumber)
		Me.Details.Controls.Add(Me.Label14)
		Me.Details.Controls.Add(Me.Slot6Label)
		Me.Details.Controls.Add(Me.CheckoutDate)
		Me.Details.Controls.Add(Me.Slot6SerialNumber)
		Me.Details.Controls.Add(Me.MACAddress)
		Me.Details.Controls.Add(Me.Slot5Label)
		Me.Details.Controls.Add(Me.Label18)
		Me.Details.Controls.Add(Me.Slot5SerialNumber)
		Me.Details.Controls.Add(Me.Labelll)
		Me.Details.Controls.Add(Me.BurnInDate)
		Me.Details.Controls.Add(Me.Slot4Label)
		Me.Details.Controls.Add(Me.SystemStatus)
		Me.Details.Controls.Add(Me.Slot4SerialNumber)
		Me.Details.Controls.Add(Me.Label17)
		Me.Details.Controls.Add(Me.Slot3Label)
		Me.Details.Controls.Add(Me.SystemType)
		Me.Details.Controls.Add(Me.Slot3SerialNumber)
		Me.Details.Controls.Add(Me.BarcodeDate)
		Me.Details.Controls.Add(Me.Slot2Label)
		Me.Details.Controls.Add(Me.Label7)
		Me.Details.Controls.Add(Me.Slot2SerialNumber)
		Me.Details.Controls.Add(Me.ParameterDate)
		Me.Details.Controls.Add(Me.Slot1Label)
		Me.Details.Controls.Add(Me.Label11)
		Me.Details.Controls.Add(Me.Slot1SerialNumber)
		Me.Details.Controls.Add(Me.Label15)
		Me.Details.Controls.Add(Me.MotherboardSerialNumber)
		Me.Details.Controls.Add(Me.MotherBoardLabel)
		Me.Details.Controls.Add(Me.RegisterDate)
		Me.Details.Controls.Add(Me.ShipDate)
		Me.Details.Controls.Add(Me.Label12)
		Me.Details.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Details.Location = New System.Drawing.Point(4, 29)
		Me.Details.Name = "Details"
		Me.Details.Padding = New System.Windows.Forms.Padding(3)
		Me.Details.Size = New System.Drawing.Size(1171, 357)
		Me.Details.TabIndex = 0
		Me.Details.Text = "Details"
		'
		'Service
		'
		Me.Service.BackColor = System.Drawing.SystemColors.Control
		Me.Service.Controls.Add(Me.Service_DataGridView)
		Me.Service.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Service.Location = New System.Drawing.Point(4, 29)
		Me.Service.Name = "Service"
		Me.Service.Padding = New System.Windows.Forms.Padding(3)
		Me.Service.Size = New System.Drawing.Size(1171, 461)
		Me.Service.TabIndex = 1
		Me.Service.Text = "Service"
		'
		'Service_DataGridView
		'
		Me.Service_DataGridView.AllowUserToAddRows = False
		Me.Service_DataGridView.AllowUserToDeleteRows = False
		Me.Service_DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Service_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.Service_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.Service_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Service_DataGridView.Location = New System.Drawing.Point(7, 7)
		Me.Service_DataGridView.Name = "Service_DataGridView"
		Me.Service_DataGridView.Size = New System.Drawing.Size(1158, 448)
		Me.Service_DataGridView.TabIndex = 0
		'
		'TP_Scrapped
		'
		Me.TP_Scrapped.BackColor = System.Drawing.SystemColors.Control
		Me.TP_Scrapped.Controls.Add(Me.DGV_Scrapped)
		Me.TP_Scrapped.Location = New System.Drawing.Point(4, 29)
		Me.TP_Scrapped.Name = "TP_Scrapped"
		Me.TP_Scrapped.Padding = New System.Windows.Forms.Padding(3)
		Me.TP_Scrapped.Size = New System.Drawing.Size(1171, 461)
		Me.TP_Scrapped.TabIndex = 2
		Me.TP_Scrapped.Text = "Scrapped"
		'
		'DGV_Scrapped
		'
		Me.DGV_Scrapped.AllowUserToAddRows = False
		Me.DGV_Scrapped.AllowUserToDeleteRows = False
		Me.DGV_Scrapped.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DGV_Scrapped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_Scrapped.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.DGV_Scrapped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_Scrapped.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.DGV_Scrapped.Location = New System.Drawing.Point(7, 7)
		Me.DGV_Scrapped.Name = "DGV_Scrapped"
		Me.DGV_Scrapped.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
		Me.DGV_Scrapped.Size = New System.Drawing.Size(1158, 448)
		Me.DGV_Scrapped.TabIndex = 1
		'
		'TP_Extras
		'
		Me.TP_Extras.BackColor = System.Drawing.SystemColors.Control
		Me.TP_Extras.Controls.Add(Me.DGV_Extras)
		Me.TP_Extras.Location = New System.Drawing.Point(4, 29)
		Me.TP_Extras.Name = "TP_Extras"
		Me.TP_Extras.Size = New System.Drawing.Size(1171, 461)
		Me.TP_Extras.TabIndex = 3
		Me.TP_Extras.Text = "Extras"
		'
		'DGV_Extras
		'
		Me.DGV_Extras.AllowUserToAddRows = False
		Me.DGV_Extras.AllowUserToDeleteRows = False
		Me.DGV_Extras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DGV_Extras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_Extras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.DGV_Extras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_Extras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.DGV_Extras.Location = New System.Drawing.Point(6, 6)
		Me.DGV_Extras.Name = "DGV_Extras"
		Me.DGV_Extras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
		Me.DGV_Extras.Size = New System.Drawing.Size(1158, 448)
		Me.DGV_Extras.TabIndex = 2
		'
		'Print_Button
		'
		Me.Print_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Print_Button.AutoSize = True
		Me.Print_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Print_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Print_Button.Location = New System.Drawing.Point(12, 436)
		Me.Print_Button.Name = "Print_Button"
		Me.Print_Button.Size = New System.Drawing.Size(104, 30)
		Me.Print_Button.TabIndex = 81
		Me.Print_Button.Text = "Print Excel"
		Me.Print_Button.UseVisualStyleBackColor = True
		'
		'B_CheckoutSheet
		'
		Me.B_CheckoutSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.B_CheckoutSheet.AutoSize = True
		Me.B_CheckoutSheet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.B_CheckoutSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.B_CheckoutSheet.Location = New System.Drawing.Point(122, 436)
		Me.B_CheckoutSheet.Name = "B_CheckoutSheet"
		Me.B_CheckoutSheet.Size = New System.Drawing.Size(148, 30)
		Me.B_CheckoutSheet.TabIndex = 82
		Me.B_CheckoutSheet.Text = "Checkout Sheet"
		Me.B_CheckoutSheet.UseVisualStyleBackColor = True
		'
		'L_NotMostCurrent
		'
		Me.L_NotMostCurrent.AutoSize = True
		Me.L_NotMostCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.L_NotMostCurrent.Location = New System.Drawing.Point(422, 18)
		Me.L_NotMostCurrent.Name = "L_NotMostCurrent"
		Me.L_NotMostCurrent.Size = New System.Drawing.Size(146, 20)
		Me.L_NotMostCurrent.TabIndex = 80
		Me.L_NotMostCurrent.Text = "Not Most Current"
		Me.L_NotMostCurrent.Visible = False
		'
		'Slot10Label
		'
		Me.Slot10Label.AutoSize = True
		Me.Slot10Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot10Label.Location = New System.Drawing.Point(558, 203)
		Me.Slot10Label.Name = "Slot10Label"
		Me.Slot10Label.Size = New System.Drawing.Size(184, 20)
		Me.Slot10Label.TabIndex = 85
		Me.Slot10Label.Text = "Slot 10 Serial Number"
		'
		'Slot10SerialNumber
		'
		Me.Slot10SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot10SerialNumber.Location = New System.Drawing.Point(558, 226)
		Me.Slot10SerialNumber.Name = "Slot10SerialNumber"
		Me.Slot10SerialNumber.ReadOnly = True
		Me.Slot10SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot10SerialNumber.TabIndex = 84
		Me.Slot10SerialNumber.TabStop = False
		'
		'Slot9Label
		'
		Me.Slot9Label.AutoSize = True
		Me.Slot9Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot9Label.Location = New System.Drawing.Point(558, 153)
		Me.Slot9Label.Name = "Slot9Label"
		Me.Slot9Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot9Label.TabIndex = 83
		Me.Slot9Label.Text = "Slot 9 Serial Number"
		'
		'Slot9SerialNumber
		'
		Me.Slot9SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot9SerialNumber.Location = New System.Drawing.Point(558, 176)
		Me.Slot9SerialNumber.Name = "Slot9SerialNumber"
		Me.Slot9SerialNumber.ReadOnly = True
		Me.Slot9SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot9SerialNumber.TabIndex = 82
		Me.Slot9SerialNumber.TabStop = False
		'
		'Slot8Label
		'
		Me.Slot8Label.AutoSize = True
		Me.Slot8Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot8Label.Location = New System.Drawing.Point(558, 103)
		Me.Slot8Label.Name = "Slot8Label"
		Me.Slot8Label.Size = New System.Drawing.Size(174, 20)
		Me.Slot8Label.TabIndex = 81
		Me.Slot8Label.Text = "Slot 8 Serial Number"
		'
		'Slot8SerialNumber
		'
		Me.Slot8SerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Slot8SerialNumber.Location = New System.Drawing.Point(558, 126)
		Me.Slot8SerialNumber.Name = "Slot8SerialNumber"
		Me.Slot8SerialNumber.ReadOnly = True
		Me.Slot8SerialNumber.Size = New System.Drawing.Size(229, 24)
		Me.Slot8SerialNumber.TabIndex = 80
		Me.Slot8SerialNumber.TabStop = False
		'
		'ViewSystemInfo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(1203, 478)
		Me.Controls.Add(Me.L_NotMostCurrent)
		Me.Controls.Add(Me.B_CheckoutSheet)
		Me.Controls.Add(Me.Print_Button)
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.L_SytemSerialNumber)
		Me.Name = "ViewSystemInfo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "System Info"
		Me.TabControl1.ResumeLayout(False)
		Me.Details.ResumeLayout(False)
		Me.Details.PerformLayout()
		Me.Service.ResumeLayout(False)
		CType(Me.Service_DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TP_Scrapped.ResumeLayout(False)
		CType(Me.DGV_Scrapped, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TP_Extras.ResumeLayout(False)
		CType(Me.DGV_Extras, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents L_SytemSerialNumber As System.Windows.Forms.Label
    Friend WithEvents MotherBoardLabel As System.Windows.Forms.Label
    Friend WithEvents MotherboardSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot1SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot1Label As System.Windows.Forms.Label
    Friend WithEvents Slot2Label As System.Windows.Forms.Label
    Friend WithEvents Slot2SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot3Label As System.Windows.Forms.Label
    Friend WithEvents Slot3SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot4Label As System.Windows.Forms.Label
    Friend WithEvents Slot4SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents Slot5Label As System.Windows.Forms.Label
    Friend WithEvents Slot5SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot6Label As System.Windows.Forms.Label
    Friend WithEvents Slot6SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Slot7Label As System.Windows.Forms.Label
    Friend WithEvents Slot7SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BarcodeDate As System.Windows.Forms.TextBox
    Friend WithEvents RegisterDate As System.Windows.Forms.TextBox
    Friend WithEvents ShipDate As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CPU_Version As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MACAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ParameterDate As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ParameterFile As System.Windows.Forms.TextBox
    Friend WithEvents BurnInDate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckoutDate As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SystemStatus As System.Windows.Forms.TextBox
    Friend WithEvents Labelll As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SystemType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LastUpdate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_AddComment As System.Windows.Forms.Button
    Friend WithEvents RTB_Results As System.Windows.Forms.RichTextBox
    Friend WithEvents PWRAtoD_Version As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents Details As TabPage
	Friend WithEvents Service As TabPage
	Friend WithEvents Service_DataGridView As DataGridView
	Friend WithEvents Print_Button As Button
	Friend WithEvents TP_Scrapped As TabPage
	Friend WithEvents DGV_Scrapped As DataGridView
	Friend WithEvents B_CheckoutSheet As Button
	Friend WithEvents L_NotMostCurrent As Label
	Friend WithEvents TP_Extras As TabPage
	Friend WithEvents DGV_Extras As DataGridView
	Friend WithEvents Slot10Label As Label
	Friend WithEvents Slot10SerialNumber As TextBox
	Friend WithEvents Slot9Label As Label
	Friend WithEvents Slot9SerialNumber As TextBox
	Friend WithEvents Slot8Label As Label
	Friend WithEvents Slot8SerialNumber As TextBox
End Class
