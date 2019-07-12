Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class ViewSystemInfo
    Const MOTHERBOARD As String = "MotherBoard"
    Const MAIN_CPU As String = "MainCPU"
    Const SLOT_2 As String = "Slot2"
    Const SLOT_3 As String = "Slot3"
    Const SLOT_4 As String = "Slot4"
    Const SLOT_5 As String = "Slot5"
    Const SLOT_6 As String = "Slot6"
	Const SLOT_7 As String = "Slot7"
	Const SLOT_8 As String = "Slot8"
	Const SLOT_9 As String = "Slot9"
	Const SLOT_10 As String = "Slot10"

	Const BARCODE_DATE As String = "BarcodeDate"
    Const REGISTER_DATE As String = "RegisterDate"
    Const PARAMETER_DATE As String = "ParameterDate"
    Const BURN_IN_DATE As String = "BurnInDate"
    Const CHECKOUT_DATE As String = "CheckoutDate"
    Const SHIP_DATE As String = "ShipDate"
    Const LAST_UPDATE As String = "LastUpdate"

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim boardSerialNumber As String = ""
	Dim systemSerialNumber As String = ""
	Dim systemID As String = ""

	'Table Headers from RMAs
	Public Const DB_HEADER_ID As String = "id"                                  ' RMA | RMAAddresses |          | RMABillType |          |                | RMAStatus |             |
	Public Const DB_HEADER_CUSTOMER As String = "Customer"                      ' RMA | RMAAddresses |          |             |          |                |           | RMACodeList |
	Public Const DB_HEADER_SERIAL_NUMBER As String = "Serial Number"            ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_STATUSID As String = "Status.id"                     ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_CONTACTNAME As String = "Contact Name"               ' RMA | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_CONTACTPHONE As String = "Contact Phone"             ' RMA | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_CONTACTEMAIL As String = "Contact E-mail"            ' RMA | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_C_RGA As String = "Customer RGA"                     ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_C_INVOICE As String = "Customer Invoice"             ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_SERVICEFORM As String = "Service Form"               ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_DESCRIPTION As String = "Description"                ' RMA |              |          |             | RMACodes | RMARepairItems |           |             |
	Public Const DB_HEADER_TECHNICIAN As String = "Technician"                  ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_SOFTWAREVERSION As String = "Software Version"       ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_IOVERSION As String = "IO Version"                   ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_BOOTVERSION As String = "Boot Version"               ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_SHIPID As String = "Ship.id"                         ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_TECHNICIANNOTES As String = "Technician Notes"       ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_APPROVALNOTES As String = "Approval Notes"           ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_BILLTYPEID As String = "BillType.id"                 ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_BILLID As String = "Bill.id"                         ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_C_RMAPO As String = "Customer RMA PO"                ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_INFORMATIONDATE As String = "Information Date"       ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_RECEIVEDDATE As String = "Received Date"             ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_EVALUATIONDATE As String = "Evaluation Date"         ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_SHIPDATE As String = "Ship Date"                     ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_APPROVALDATE As String = "Approval Date"             ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_LASTUPDATE As String = "Last Update"                 ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_TESTED As String = "Tested"                          ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_NB_INVOICE As String = "Netbox Invoice"              ' RMA |              |          |             |          |                |           |             |
	Public Const DB_HEADER_COMPANY As String = "Company"                        '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_ADDRESS As String = "Address"                        '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_CITY As String = "City"                              '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_STATE As String = "State"                            '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_ZIPCODE As String = "Zip Code"                       '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_COUNTRY As String = "Country"                        '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_PHONE As String = "Phone"                            '     | RMAAddresses |          |             |          |                |           |             |
	Public Const DB_HEADER_BILLTYPE As String = "Bill Type"                     '     |              |          | RMABillType |          |                |           |             |
	Public Const DB_HEADER_NEEDSADDRESS As String = "Needs Address"             '     |              |          | RMABillType |          |                |           |             |
	Public Const DB_HEADER_SAMEASSHIPPING As String = "Same as Shipping"        '     |              |          | RMABillType |          |                |           |             |
	Public Const DB_HEADER_CODE As String = "Code"                              '     |              |          |             | RMACodes |                |           |             |
	Public Const DB_HEADER_TYPE As String = "Type"                              '     |              |          |             | RMACodes |                |           |             |
	Public Const DB_HEADER_FIX As String = "Fix"                                '     |              |          |             | RMACodes |                |           |             |
	Public Const DB_HEADER_RMAID As String = "RMA.id"                           '     |              |          |             |          | RMARepairItems |           | RMACodeList |
	Public Const DB_HEADER_CHARGE As String = "Charge"                          '     |              |          |             |          | RMARepairItems |           |             |
	Public Const DB_HEADER_ISAPPROVAL As String = "Is Approval"                 '     |              |          |             |          |                | RMAStatus |             |
	Public Const DB_HEADER_STATUS As String = "Status"                          '     |              |          |             |          |                | RMAStatus |             |
	Public Const DB_HEADER_RMACODESID As String = "RMACodes.id"                 '     |              |          |             |          |                |           | RMACodeList |
	Public Const DB_HEADER_EVALUATION As String = "Evaluation"                  '     |              |          |             |          |                |           | RMACodeList |

	'Table names
	Public Const TABLE_PARAMETERS As String = "SystemParameters"
	Public Const TABLE_SYSTEM As String = "System"
	Public Const TABLE_SYSTEMTYPE As String = "SystemType"
	Public Const TABLE_BOARD As String = "Board"
	Public Const TABLE_RMA As String = "RMA"
	Public Const TABLE_RMAADDRESSES As String = "RMAAddresses"
	Public Const TABLE_RMAAUDIT As String = "RMAAudit"
	Public Const TABLE_RMABILLTYPE As String = "RMABillType"
	Public Const TABLE_RMACODES As String = "RMACodes"
	Public Const TABLE_RMAREPAIRITEMS As String = "RMARepairItems"
	Public Const TABLE_RMASTATUS As String = "RMAStatus"
	Public Const TABLE_RMACODELIST As String = "RMACodeList"

	Dim da_extras As SqlDataAdapter
	Dim ds_extras As DataSet

	Public Sub New(ByRef ID As String)
		InitializeComponent()
		systemID = ID
	End Sub

	Private Sub ViewInfo_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		myCmd.CommandText = "Select SerialNumber from system where systemid = '" & systemID & "'"

		systemSerialNumber = myCmd.ExecuteScalar

		SetInfo(systemID)

		GetServiceForms(systemSerialNumber)

		GetScrappedForms(systemSerialNumber)

		'GetExtras(systemID)
		TabControl1.TabPages.Remove(TP_Extras)

		myCmd.CommandText = "Select Instance from system where systemid = '" & systemID & "'"
		Dim instanceNumber As String = myCmd.ExecuteScalar

		L_SytemSerialNumber.Text = systemSerialNumber & " | " & instanceNumber

		myCmd.CommandText = "Select MAX(instance) from system where SerialNumber = '" & systemSerialNumber & "'"
		Dim highestInstanceNumber As String = myCmd.ExecuteScalar

		If instanceNumber <> highestInstanceNumber Then
			L_NotMostCurrent.Visible = True
		End If

		Dim newFont As New Font(MotherBoardLabel.Font.Name, MotherBoardLabel.Font.Size, FontStyle.Underline Or FontStyle.Bold)

		If MotherboardSerialNumber.Text.Length <> 0 Then
			MotherBoardLabel.Font = newFont
		End If
		If Slot1SerialNumber.Text.Length <> 0 Then
			Slot1Label.Font = newFont
		End If
		If Slot2SerialNumber.Text.Length <> 0 Then
			Slot2Label.Font = newFont
		End If
		If Slot3SerialNumber.Text.Length <> 0 Then
			Slot3Label.Font = newFont
		End If
		If Slot4SerialNumber.Text.Length <> 0 Then
			Slot4Label.Font = newFont
		End If
		If Slot5SerialNumber.Text.Length <> 0 Then
			Slot5Label.Font = newFont
		End If
		If Slot6SerialNumber.Text.Length <> 0 Then
			Slot6Label.Font = newFont
		End If
		If Slot7SerialNumber.Text.Length <> 0 Then
			Slot7Label.Font = newFont
		End If
		If Slot8SerialNumber.Text.Length <> 0 Then
			Slot8Label.Font = newFont
		End If
		If Slot9SerialNumber.Text.Length <> 0 Then
			Slot9Label.Font = newFont
		End If
		If Slot10SerialNumber.Text.Length <> 0 Then
			Slot10Label.Font = newFont
		End If
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub SetInfo(ByRef systemID As String)
		Dim result As String = ""
		Dim record As Guid = Nothing
		Dim barcodeDateTime As DateTime = Nothing
		Dim registerDateTime As DateTime = Nothing
		Dim parameterDateTime As DateTime = Nothing
		Dim burnInDateTime As DateTime = Nothing
		Dim checkoutDateTime As DateTime = Nothing
		Dim shipDateTime As DateTime = Nothing
		Dim lastUpdateTime As DateTime = Nothing


		Dim hasCPU As Boolean = False
		Dim hasPWR As Boolean = False

		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, MOTHERBOARD, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, MotherboardSerialNumber.Text, result)
				If MotherboardSerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf MotherboardSerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, MAIN_CPU, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot1SerialNumber.Text, result)
				If Slot1SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot1SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_2, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot2SerialNumber.Text, result)
				If Slot2SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot2SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_3, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot3SerialNumber.Text, result)
				If Slot3SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot3SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_4, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot4SerialNumber.Text, result)
				If Slot4SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot4SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_5, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot5SerialNumber.Text, result)
				If Slot5SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot5SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_6, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot6SerialNumber.Text, result)
				If Slot6SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot6SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_7, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot7SerialNumber.Text, result)
				If Slot7SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot7SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_8, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot8SerialNumber.Text, result)
				If Slot8SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot8SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_9, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot9SerialNumber.Text, result)
				If Slot9SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot9SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If
		If sqlapi.GetBoardGUIDBySystemID(myCmd, myReader, systemID, SLOT_10, record, result) = True Then
			If record <> Guid.Empty Then
				sqlapi.GetBoardSerialNumberByGUID(myCmd, myReader, record.ToString, Slot10SerialNumber.Text, result)
				If Slot10SerialNumber.Text.Contains("CPU") = True Then
					hasCPU = True
				ElseIf Slot10SerialNumber.Text.Contains("PWR") = True Then
					hasPWR = True
				End If
			End If
		End If

		sqlapi.GetParameterFileNameByID(myCmd, myReader, systemID, record, ParameterFile.Text, result)

		If hasCPU = True Then
			sqlapi.GetMACAddress(myCmd, myReader, Slot1SerialNumber.Text, MACAddress.Text, result)

			sqlapi.GetSystemVersionByID(myCmd, myReader, systemID, record, CPU_Version.Text, result)
		End If

		If hasPWR = True Then
			sqlapi.GetBoardSoftwareVersion(myCmd, myReader, Slot2SerialNumber.Text, PWRAtoD_Version.Text, result)
		End If

		sqlapi.GetSystemCurrentStatusByID(myCmd, myReader, systemID, record, SystemStatus.Text, result)

		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, BARCODE_DATE, barcodeDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, REGISTER_DATE, registerDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, PARAMETER_DATE, parameterDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, BURN_IN_DATE, burnInDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, CHECKOUT_DATE, checkoutDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, SHIP_DATE, shipDateTime, record, result)
		sqlapi.GetSystemDateByID(myCmd, myReader, systemID, LAST_UPDATE, lastUpdateTime, record, result)

		If barcodeDateTime <> Nothing Then
			BarcodeDate.Text = barcodeDateTime.ToString()
		End If
		If registerDateTime <> Nothing Then
			RegisterDate.Text = registerDateTime.ToString()
		End If
		If parameterDateTime <> Nothing Then
			ParameterDate.Text = parameterDateTime.ToString()
		End If
		If burnInDateTime <> Nothing Then
			BurnInDate.Text = burnInDateTime.ToString()
		End If
		If checkoutDateTime <> Nothing Then
			CheckoutDate.Text = checkoutDateTime.ToString()
		End If
		If shipDateTime <> Nothing Then
			ShipDate.Text = shipDateTime.ToString()
		End If
		If lastUpdateTime <> Nothing Then
			LastUpdate.Text = lastUpdateTime.ToString()
		End If

		sqlapi.GetSystemAuditByID(myCmd, myReader, systemID, RTB_Results, result)

		sqlapi.GetSystemCurrentTypeByID(myCmd, myReader, systemID, SystemType.Text, result)
	End Sub

	Private Sub GetServiceForms(ByRef SerialNumber As String)
		Dim serviceTable As New DataTable
		serviceTable.Columns.Add("Form #")
		serviceTable.Columns.Add("Evaluation")
		serviceTable.Columns.Add("Error Codes")
		serviceTable.Columns.Add("Current Status")

		myCmd.CommandText = "select rma.[id], rma.[Service Form], rma.[Evaluation Date], status.[status]  from rma [rma] left join RMAStatus [status] ON rma.[Status.id] = status.id where [Serial Number] = '" & SerialNumber & "'"

		Dim results As New DataTable()
		results.Load(myCmd.ExecuteReader)

		If results.Rows.Count <> 0 Then
			For Each dr As DataRow In results.Rows
				Dim codeString As String = ""

				Dim formGUID As String

				formGUID = dr("id").ToString

				myCmd.CommandText = "SELECT * FROM " & TABLE_RMACODELIST & " WHERE [" & DB_HEADER_RMAID & "] = '" & formGUID & "' AND [" & DB_HEADER_EVALUATION & "] = '1' ORDER BY [" & DB_HEADER_RMACODESID & "]"
				Dim dt_searchresults As New DataTable
				dt_searchresults.Load(myCmd.ExecuteReader)

				For Each reusltrow As DataRow In dt_searchresults.Rows
					myCmd.CommandText = "SELECT [" & DB_HEADER_CODE & "] FROM " & TABLE_RMACODES & " WHERE [" & DB_HEADER_ID & "] = '" & reusltrow(DB_HEADER_RMACODESID).ToString & "'"
					If codeString.Contains(myCmd.ExecuteScalar.ToString) = False Then
						codeString = codeString & myCmd.ExecuteScalar.ToString & ", "
					End If
				Next

				If codeString.Length <> 0 Then
					codeString = codeString.Substring(0, codeString.Length - 2)
				End If


				serviceTable.Rows.Add(dr("Service Form"), dr("Evaluation Date"), codeString, dr("status"))
			Next
		Else
			TabControl1.TabPages.Remove(Service)
			Return
		End If

		serviceTable.DefaultView.Sort = "[Form #] ASC"
		serviceTable = serviceTable.DefaultView.ToTable

		Service_DataGridView.DataSource = serviceTable

		Service_DataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)

		Service_DataGridView.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
		Service_DataGridView.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
		Service_DataGridView.Columns(2).Width = 300

		For i = 0 To Service_DataGridView.Columns.Count - 1
			Service_DataGridView.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
		Next i

	End Sub

	Private Sub GetScrappedForms(ByRef SerialNumber As String)
		Dim serviceTable As New DataTable
		myCmd.CommandText = "SELECT " &
			"count(*) 
			FROM System 
			WHERE SerialNumber = '" & SerialNumber & "' 
			AND [dbo.SystemStatus.id] = (Select id from SystemStatus where name = 'Scrapped')"

		Dim totalScrapped As Integer = myCmd.ExecuteScalar

		If myCmd.ExecuteScalar = 0 Then
			TabControl1.TabPages.Remove(TP_Scrapped)
		Else
			myCmd.CommandText = "SELECT " &
				"s.SerialNumber AS 'System Serial Number', 
				s.Instance AS 'Instance', 
				t.name AS 'System Type', 
				s.LastUpdate AS 'Last Update', 
				st.name AS 'System Status', 
				mb.SerialNumber AS 'Motherboard', 
				s1.SerialNumber AS 'Main CPU', 
				s2.SerialNumber AS 'Slot 2', 
				s3.SerialNumber AS 'Slot 3', 
				s4.SerialNumber AS 'Slot 4', 
				s5.SerialNumber AS 'Slot 5', 
				s6.SerialNumber AS 'Slot 6', 
				s7.SerialNumber AS 'Slot 7' 
				FROM dbo.System s 
				LEFT JOIN dbo.systemType t ON s.[dbo.SystemType.id] = t.id
				LEFT JOIN dbo.board mb ON s.[MotherBoard.boardid] = mb.boardid 
				LEFT JOIN dbo.board s1 ON s.[MainCPU.boardid] = s1.boardid 
				LEFT JOIN dbo.board s2 ON s.[Slot2.boardid] = s2.boardid 
				LEFT JOIN dbo.board s3 ON s.[Slot3.boardid] = s3.boardid 
				LEFT JOIN dbo.board s4 ON s.[Slot4.boardid] = s4.boardid 
				LEFT JOIN dbo.board s5 ON s.[Slot5.boardid] = s5.boardid 
				LEFT JOIN dbo.board s6 ON s.[Slot6.boardid] = s6.boardid 
				LEFT JOIN dbo.board s7 ON s.[Slot7.boardid] = s7.boardid 
				LEFT JOIN dbo.SystemStatus st ON s.[dbo.SystemStatus.id] = st.id
				WHERE s.SerialNumber = '" & SerialNumber & "'
				ORDER BY Instance DESC"

			Dim da = New SqlDataAdapter(myCmd)
			Dim ds = New DataSet()

			da.Fill(ds)

			DGV_Scrapped.DataSource = ds.Tables(0)

			For Each column In DGV_Scrapped.Columns
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			Next column
		End If


	End Sub

	Private Sub DGV_Scrapped_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGV_Scrapped.CellMouseDoubleClick
		Dim serialNumber As String = DGV_Scrapped.Rows(e.RowIndex).Cells(0).Value.ToString
		Dim instanceNumber As String = DGV_Scrapped.Rows(e.RowIndex).Cells("Instance").Value.ToString

		myCmd.CommandText = "SELECT systemid FROM system where SerialNumber = '" & serialNumber & "' AND Instance = " & instanceNumber

		Dim DoViewSystemInfo As New ViewSystemInfo(myCmd.ExecuteScalar.ToString)
		DoViewSystemInfo.ShowDialog()
	End Sub

	Private Sub MotherBoardLabel_Click() Handles MotherBoardLabel.Click
		If MotherboardSerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(MotherboardSerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot1Label_Click() Handles Slot1Label.Click
		If Slot1SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot1SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot2Label_Click() Handles Slot2Label.Click
		If Slot2SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot2SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot3Label_Click() Handles Slot3Label.Click
		If Slot3SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot3SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot4Label_Click() Handles Slot4Label.Click
		If Slot4SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot4SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot5Label_Click() Handles Slot5Label.Click
		If Slot5SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot5SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot6Label_Click() Handles Slot6Label.Click
		If Slot6SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot6SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot7Label_Click() Handles Slot7Label.Click
		If Slot7SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot7SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot8Label_Click() Handles Slot8Label.Click
		If Slot8SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot8SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot9Label_Click() Handles Slot9Label.Click
		If Slot9SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot9SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub Slot10Label_Click() Handles Slot10Label.Click
		If Slot10SerialNumber.Text.Length <> 0 Then
			Dim DoViewBoardInfo As New ViewBoardInfo(Slot10SerialNumber.Text)
			DoViewBoardInfo.ShowDialog()
		End If
	End Sub

	Private Sub L_SytemSerialNumber_Click() Handles L_SytemSerialNumber.Click
		'Dim DoAddSystemComment As New AddSystemComment(L_SytemSerialNumber.Text, False)
		'DoAddSystemComment.ShowDialog()
	End Sub

	Private Sub B_AddComment_Click() Handles B_AddComment.Click
		Dim sno As String = L_SytemSerialNumber.Text.Substring(0, L_SytemSerialNumber.Text.IndexOf(" "))
		Dim DoAddSystemComment As New AddSystemComment(sno, False)
		DoAddSystemComment.ShowDialog()
	End Sub

	Private Sub Print_Button_Click() Handles Print_Button.Click
		Try
			Dim xlApp As New Excel.Application
			Dim xlWorkBook As Excel.Workbook
			Dim xlWorkSheet As Excel.Worksheet
			Dim misValue As Object = Reflection.Missing.Value
			xlWorkBook = xlApp.Workbooks.Add(misValue)

			'Delete the other two sheets so our logic to add more sheets will work.
			xlWorkBook.Sheets("sheet2").Delete()
			xlWorkBook.Sheets("sheet3").Delete()

			'----- SHEET 1 -----'

			xlWorkSheet = xlWorkBook.Sheets("sheet1")
			xlWorkSheet.Name = "System Information"
			xlWorkSheet.PageSetup.CenterHeader = "Master Report for " & systemSerialNumber & "   " & Date.Now.Date

			'ROW 1
			Dim INDEX_row As Integer = 1
			Dim INDEX_Column As Integer = 1

			'ROW 2
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = systemSerialNumber

			'ROW 3
			INDEX_row += 1

			'ROW 4
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "System Type"

			'ROW 5
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = SystemType.Text

			'ROW 6
			INDEX_row += 1

			'ROW 7
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "System Status"

			'ROW 8
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = SystemStatus.Text

			'ROW 9
			INDEX_row += 1

			'ROW 10
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "CPU Version"

			'ROW 11
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = CPU_Version.Text

			'ROW 12
			INDEX_row += 1

			'ROW 13
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "PWRAtoD Version"

			'ROW 14
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = PWRAtoD_Version.Text

			'ROW 15
			INDEX_row += 1

			'ROW 16
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "MAC Address"

			'ROW 17
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = MACAddress.Text

			INDEX_row = 4
			INDEX_Column = 3

			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Barcode Date"

			'ROW 5
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = BarcodeDate.Text

			'ROW 6
			INDEX_row += 1

			'ROW 7
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "MAC Date"

			'ROW 8
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = RegisterDate.Text

			'ROW 9
			INDEX_row += 1

			'ROW 10
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Parameter Date"

			'ROW 11
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = ParameterDate.Text

			'ROW 12
			INDEX_row += 1

			'ROW 13
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Burn In Date"

			'ROW 14
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = BurnIn.Text

			'ROW 15
			INDEX_row += 1

			'ROW 16
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Checkout Date"

			'ROW 17
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = CheckoutDate.Text

			'ROW 18
			INDEX_row += 1

			'ROW 19
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Ship Date"

			'ROW 20
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = ShipDate.Text

			'ROW 21
			INDEX_row += 1

			'ROW 22
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Last Date"

			'ROW 23
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = LastUpdate.Text

			INDEX_row = 4
			INDEX_Column = 5

			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Motherboard"

			'ROW 5
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = MotherboardSerialNumber.Text

			'ROW 6
			INDEX_row += 1

			'ROW 7
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 1"

			'ROW 8
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot1SerialNumber.Text

			'ROW 9
			INDEX_row += 1

			'ROW 10
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 2"

			'ROW 11
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot2SerialNumber.Text

			'ROW 12
			INDEX_row += 1

			'ROW 13
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 3"

			'ROW 14
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot3SerialNumber.Text

			'ROW 15
			INDEX_row += 1

			'ROW 16
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 4"

			'ROW 17
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot4SerialNumber.Text

			'ROW 18
			INDEX_row += 1

			'ROW 19
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 5"

			'ROW 20
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot5SerialNumber.Text

			'ROW 21
			INDEX_row += 1

			'ROW 22
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 6"

			'ROW 23
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot6SerialNumber.Text

			'ROW 24
			INDEX_row += 1

			'ROW 25
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 7"

			'ROW 26
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot7SerialNumber.Text

			'ROW 27
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 8"

			'ROW 28
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot8SerialNumber.Text

			'ROW 29
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 9"

			'ROW 30
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot9SerialNumber.Text

			'ROW 31
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Slot 10"

			'ROW 32
			INDEX_row += 1
			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = Slot10SerialNumber.Text

			INDEX_row = 4
			INDEX_Column = 8

			xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "System Comments"

			INDEX_row += 1
			For Each line In RTB_Results.Lines

				xlWorkSheet.Cells(INDEX_row, INDEX_Column) = line

				INDEX_row += 1
			Next

			xlWorkSheet.Range("A1:X1").EntireColumn.AutoFit()
			xlWorkSheet.Range("A1:X1").EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

			If TabControl1.TabPages.IndexOf(Service) <> -1 Then

				Dim workingTable As New DataTable

				workingTable = Service_DataGridView.DataSource

				For Each row As DataGridViewRow In Service_DataGridView.Rows
					Dim thisSFN = row.Cells("Form #").Value.ToString

					'----- SHEET # -----'
					xlWorkSheet = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
					xlWorkSheet.Name = thisSFN
					xlWorkSheet.PageSetup.CenterHeader = "Service Form " & thisSFN & "   " & Date.Now.Date

					'Declare all of the variables that we are going to use
					Dim mycmd As New SqlCommand("SELECT * FROM " & TABLE_RMA & " WHERE [" & DB_HEADER_SERVICEFORM & "] = '" & thisSFN & "'", myConn)
					Dim dt_rmaRecord = New DataTable()
					dt_rmaRecord.Load(mycmd.ExecuteReader)

					Dim thisGUID = dt_rmaRecord(0)(DB_HEADER_ID).ToString
					Dim customer As String = dt_rmaRecord(0)(DB_HEADER_CUSTOMER).ToString
					Dim statusGUID As String = dt_rmaRecord(0)(DB_HEADER_STATUSID).ToString
					Dim contactName As String = dt_rmaRecord(0)(DB_HEADER_CONTACTNAME).ToString
					Dim contactPhone As String = dt_rmaRecord(0)(DB_HEADER_CONTACTPHONE).ToString
					Dim contactEmail As String = dt_rmaRecord(0)(DB_HEADER_CONTACTEMAIL).ToString
					Dim rga As String = dt_rmaRecord(0)(DB_HEADER_C_RGA).ToString
					Dim invoice As String = dt_rmaRecord(0)(DB_HEADER_C_INVOICE).ToString
					Dim description As String = dt_rmaRecord(0)(DB_HEADER_DESCRIPTION).ToString
					Dim technician As String = dt_rmaRecord(0)(DB_HEADER_TECHNICIAN).ToString
					Dim softwareVersion As String = dt_rmaRecord(0)(DB_HEADER_SOFTWAREVERSION).ToString
					Dim ioVersion As String = dt_rmaRecord(0)(DB_HEADER_IOVERSION).ToString
					Dim bootVersion As String = dt_rmaRecord(0)(DB_HEADER_BOOTVERSION).ToString
					Dim shipGUID As String = dt_rmaRecord(0)(DB_HEADER_SHIPID).ToString
					Dim billTypeGUID As String = dt_rmaRecord(0)(DB_HEADER_BILLTYPEID).ToString
					Dim billGUID As String = dt_rmaRecord(0)(DB_HEADER_BILLID).ToString
					Dim rmaPO As String = dt_rmaRecord(0)(DB_HEADER_C_RMAPO).ToString
					Dim netboxInvoice As String = dt_rmaRecord(0)(DB_HEADER_NB_INVOICE).ToString
					Dim informationDate As String = dt_rmaRecord(0)(DB_HEADER_INFORMATIONDATE).ToString
					Dim ReceivedDate As String = dt_rmaRecord(0)(DB_HEADER_RECEIVEDDATE).ToString
					Dim evaluationDate As String = dt_rmaRecord(0)(DB_HEADER_EVALUATIONDATE).ToString
					Dim approvalDate As String = dt_rmaRecord(0)(DB_HEADER_APPROVALDATE).ToString
					Dim shipDate As String = dt_rmaRecord(0)(DB_HEADER_SHIPDATE).ToString
					Dim lastupdate As String = dt_rmaRecord(0)(DB_HEADER_LASTUPDATE).ToString
					Dim technicianNotes As String = dt_rmaRecord(0)(DB_HEADER_TECHNICIANNOTES).ToString
					Dim testedCheck As String = dt_rmaRecord(0)(DB_HEADER_TESTED).ToString
					Dim tested As String = ""

					If testedCheck.Length = 0 Then
						tested = "No"
					ElseIf testedCheck = "False" Then
						tested = "No"
					Else
						tested = "Yes"
					End If

					'ROW 1
					INDEX_row = 1
					INDEX_Column = 1

					'ROW 2
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Status"
					mycmd.CommandText = "SELECT [" & DB_HEADER_STATUS & "] FROM  " & TABLE_RMASTATUS & " WHERE [" & DB_HEADER_ID & "] = '" & statusGUID & "'"
					Dim status As String = mycmd.ExecuteScalar.ToString
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = status

					'ROW 3
					INDEX_row += 1

					'ROW 4
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Information Date"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = informationDate

					'ROW 5
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Receive Date"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = ReceivedDate

					'ROW 6
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Evaluation Date"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = evaluationDate

					'ROW 7
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Approval Date"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = approvalDate

					'ROW 8
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Shipping Date"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = shipDate

					'ROW 9
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Last Update"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = lastupdate

					'ROW 10
					INDEX_row += 1

					'ROW 11
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Customer"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = customer

					'ROW 12
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Contact Name"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = contactName

					'ROW 13
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Contact Number"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = contactPhone

					'ROW 14
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Contact Email"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = contactEmail

					'ROW 15
					INDEX_row += 1

					'ROW 16
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Customer Tested"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = tested

					'ROW 17
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "RGA Number"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = rga

					'ROW 18
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Invoice Number"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = invoice

					'ROW 19
					INDEX_row += 1

					'ROW 20
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Description"

					'ROW 21
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = description

					INDEX_row = 2
					INDEX_Column = 4

					'ROW 4
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Software Version"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = softwareVersion

					'ROW 5
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "IO Version"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = ioVersion

					'ROW 6
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Bootloader Version"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = bootVersion

					'ROW 7
					INDEX_row += 1

					'ROW 8
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Technician"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = technician

					'ROW 9
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Codes"

					'Get all of the codes that are associated with this RMA.
					mycmd.CommandText = "SELECT * FROM " & TABLE_RMACODELIST & " WHERE [" & DB_HEADER_RMAID & "] = '" & thisGUID & "' AND [" & DB_HEADER_EVALUATION & "] = '1'"
					Dim dt_coderesults = New DataTable
					dt_coderesults.Load(mycmd.ExecuteReader)

					For Each dr As DataRow In dt_coderesults.Rows
						Try
							mycmd.CommandText = "SELECT * FROM " & TABLE_RMACODES & " WHERE [" & DB_HEADER_ID & "] = '" & dr(DB_HEADER_RMACODESID).ToString & "'"
						Catch ex As Exception
							MsgBox(ex.Message)
						End Try

						Dim dt_codeInformation As New DataTable
						dt_codeInformation.Load(mycmd.ExecuteReader)

						If dt_codeInformation.Rows.Count <> 0 Then
							xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_codeInformation(0)(DB_HEADER_CODE).ToString
						End If
						INDEX_row += 1
					Next

					If dt_coderesults.Rows.Count = 0 Then
						INDEX_row += 1
					End If

					'Seperate ourselves from the last group.
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Repair Items"

					'Get all of the repair items that are associated with this RMA.
					Dim dt_repairItems = New DataTable
					mycmd.CommandText = "SELECT [" & DB_HEADER_DESCRIPTION & "],[" & DB_HEADER_CHARGE & "] FROM " & TABLE_RMAREPAIRITEMS & " WHERE [" & DB_HEADER_RMAID & "] = '" & thisGUID & "'"
					dt_repairItems.Load(mycmd.ExecuteReader())

					For Each dr As DataRow In dt_repairItems.Rows
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dr(DB_HEADER_DESCRIPTION).ToString
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 2) = dr(DB_HEADER_CHARGE).ToString

						INDEX_row += 1
					Next

					If dt_repairItems.Rows.Count = 0 Then
						INDEX_row += 1
					End If

					'Seperate ourselves from the last group.
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Technician Notes"

					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = technicianNotes

					INDEX_row = 2
					INDEX_Column = 8

					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "RMA PO Number"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = rmaPO

					'ROW 3
					INDEX_row += 1
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Netbox Invoice"
					xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = netboxInvoice

					'ROW 4
					INDEX_row += 1

					'ROW 5
					INDEX_row += 1

					'Only add if we have a GUID for our shipping.
					If shipGUID.Length <> 0 Then
						mycmd.CommandText = "SELECT * FROM " & TABLE_RMAADDRESSES & " WHERE [" & DB_HEADER_ID & "] = '" & shipGUID & "'"
						Dim dt_Ship = New DataTable()
						dt_Ship.Load(mycmd.ExecuteReader())

						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Company"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_COMPANY).ToString

						INDEX_row += 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Address"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_ADDRESS).ToString

						INDEX_row += 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "City"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_CITY).ToString

						INDEX_row += 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "State"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_STATE).ToString

						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 2) = "Zip"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 3) = dt_Ship(0)(DB_HEADER_ZIPCODE).ToString

						INDEX_row += 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Country"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_COUNTRY).ToString

						INDEX_row += 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Phone"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Ship(0)(DB_HEADER_PHONE).ToString
					End If

					INDEX_row += 1
					INDEX_row += 1

					If billTypeGUID.Length <> 0 Then
						mycmd.CommandText = "SELECT * FROM " & TABLE_RMABILLTYPE & " WHERE [" & DB_HEADER_ID & "] = '" & billTypeGUID & "'"
						Dim dt_BillingType = New DataTable()
						dt_BillingType.Load(mycmd.ExecuteReader())

						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Billing Type"
						xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_BillingType(0)(DB_HEADER_BILLTYPE)

						'Determine how to set up the billing side of the information depending on billing type booleans.
						If dt_BillingType(0)(DB_HEADER_NEEDSADDRESS) = True Then
							If billGUID.Length <> 0 Then
								If billGUID <> shipGUID Then
									mycmd.CommandText = "SELECT * FROM " & TABLE_RMAADDRESSES & " WHERE [" & DB_HEADER_ID & "] = '" & billGUID & "'"
									Dim dt_Bill = New DataTable()
									dt_Bill.Load(mycmd.ExecuteReader())

									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Company"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_COMPANY).ToString

									INDEX_row += 1
									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Address"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_ADDRESS).ToString

									INDEX_row += 1
									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "City"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_CITY).ToString

									INDEX_row += 1
									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "State"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_STATE).ToString

									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 2) = "Zip"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 3) = dt_Bill(0)(DB_HEADER_ZIPCODE).ToString

									INDEX_row += 1
									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Country"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_COUNTRY).ToString

									INDEX_row += 1
									xlWorkSheet.Cells(INDEX_row, INDEX_Column) = "Phone"
									xlWorkSheet.Cells(INDEX_row, INDEX_Column + 1) = dt_Bill(0)(DB_HEADER_PHONE).ToString
								End If
							End If
						End If
					End If

					xlWorkSheet.Range("A1:X1").EntireColumn.AutoFit()
					xlWorkSheet.Range("A1:X1").EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
				Next

			End If

			If TabControl1.TabPages.IndexOf(TP_Scrapped) <> -1 Then
				'----- SHEET # -----'
				xlWorkSheet = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
				xlWorkSheet.Name = "Previous Units"
				xlWorkSheet.PageSetup.CenterHeader = "Previous Units   " & Date.Now.Date

				Dim workingTable As New DataTable

				'ROW 1
				INDEX_row = 1
				INDEX_Column = 1

				For Each column As DataGridViewColumn In DGV_Scrapped.Columns
					xlWorkSheet.Cells(INDEX_row, INDEX_Column) = column.HeaderText

					INDEX_Column += 1
				Next

				INDEX_row += 1
				INDEX_Column = 1

				For Each row As DataGridViewRow In DGV_Scrapped.Rows
					For i = 0 To DGV_Scrapped.Columns.Count - 1
						xlWorkSheet.Cells(INDEX_row, INDEX_Column) = row.Cells(i).Value.ToString

						INDEX_Column += 1
					Next

					INDEX_row += 1
					INDEX_Column = 1
				Next
			End If

			xlWorkBook.Sheets("System Information").Select()

			xlApp.DisplayAlerts = False
			xlApp.Visible = True

			releaseObject(xlWorkSheet)
			releaseObject(xlWorkBook)
			releaseObject(xlApp)
		Catch ex As Exception
			MsgBox("File was not written: " & ex.Message)
		End Try
	End Sub

	Private Sub releaseObject(ByVal obj As Object)
		Try
			Runtime.InteropServices.Marshal.ReleaseComObject(obj)
			obj = Nothing
		Catch ex As Exception
			obj = Nothing
		Finally
			GC.Collect()
		End Try
	End Sub

	Private Sub B_CheckoutSheet_Click() Handles B_CheckoutSheet.Click
		Dim location As String = CurrentCheckout & systemSerialNumber & ".pdf"

		If IO.File.Exists(location) = False Then
			MsgBox("There is no PDF file at location: " & location)
			Return
		End If

		Process.Start(location)
	End Sub

	Private Sub GetExtras(ByRef systemidString As String)
		Dim result As String = ""
		Try
			myCmd.CommandText = "SELECT ec.[Description], ec.[Qty], ec.[DateOfService] FROM SystemExtrasMap map JOIN ExtraComponents ec ON ec.id = map.[ExtraComponents.id]
WHERE map.[SystemExtras.id] = (SELECT [SystemExtras.id] FROM dbo.System WHERE systemid = '" & systemidString & "') ORDER by ec.[Description]"
			da_extras = New SqlDataAdapter(myCmd)
			ds_extras = New DataSet()

			da_extras.Fill(ds_extras, "TABLE")

			If ds_extras.Tables(0).Rows.Count <> 0 Then
				DGV_Extras.DataSource = ds_extras.Tables(0)
				DGV_Extras.Focus()

				DGV_Extras.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
				DGV_Extras.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
				DGV_Extras.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			Else
				TabControl1.TabPages.Remove(TP_Extras)
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub
End Class