Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices

Public Class PrintLabels
	Dim myCmd As New SqlCommand("", myConn)
	Dim myreader As SqlDataReader = Nothing
	Dim templatePath As String = My.Settings.TemplatePath

	Private Sub PrintLabels_Load() Handles MyBase.Load
		CenterToParent()
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub SelectFile(ByRef path As String, ByRef systemType As String, ByRef newentry As Boolean, ByRef thiscmd As SqlCommand)
		Dim selectFile As New OpenFileDialog
		selectFile.CheckFileExists = True
		selectFile.CheckPathExists = True
		selectFile.InitialDirectory = My.Settings.TemplatePath
		selectFile.Filter = "Template (*.prn*)|*.prn*|All files (*.*)|*.*"
		If selectFile.ShowDialog() = DialogResult.OK Then
			path = selectFile.FileName

			If newentry = True Then
				thiscmd.CommandText = "INSERT INTO SystemParameters([id], [valuestring]) VALUES('" & systemType & " labelpath', '" & path & "')"
				thiscmd.ExecuteNonQuery()
			Else
				thiscmd.CommandText = "UPDATE SystemParameters SET [valuestring] = '" & path & "' WHERE [id] = '" & systemType & " labelpath'"
				thiscmd.ExecuteNonQuery()
			End If
		End If
	End Sub

	Private Sub Print_Button_Click() Handles Print_Button.Click
		Dim result As String = ""
		Dim systemType As String = ""
		Dim serialRecord As Guid 

		'Check to see that we exist and get out system type.
		If sqlapi.GetSystemCurrentType(myCmd, myreader, Serial_TextBox.Text, systemType, result) = False Then
			' check to see if we are a board
			If sqlapi.GetBoardCurrentType(myCmd, myreader, Serial_TextBox.Text, serialRecord,systemType, result) = False Then
				MsgBox(result)
				Return
			End If
		End If

		'Convert our quantity of labels to print into an integer.
		Dim quantity As Integer = 0
		Try
			quantity = CInt(Quantity_TextBox.Text)
		Catch ex As Exception
			MsgBox("Please put in a positive whole number")
			Return
		End Try

		'Check to see that we are a positive integer.
		If quantity <= 0 Then
			MsgBox("Please put in a positive whole number")
			Return
		End If

		If CheckPrinter(My.Settings.ZebraPrinter) = False Then
			Return
		End If

		PrintLabels(Serial_TextBox.Text, quantity, myCmd, My.Settings.ZebraPrinter)

		'Continue to try to delete the file once we are done with it
		Dim deleted = False
		While deleted = False
			Try
				File.Delete(My.Settings.TempFolder & "\" & Serial_TextBox.Text & ".prn")
				deleted = True
			Catch ex As Exception

			End Try
		End While
	End Sub

	Public Function PrintLabels(ByRef SNO As String, ByRef QTY As String, ByRef thiscmd As SqlCommand, ByRef printerName As String) As Boolean
		Dim result As String = ""
		Dim systemType As String = ""
		Dim serialRecord As Guid
		Dim thisReader As SqlDataReader = Nothing

		'Check to see that we exist and get out system type.
		If sqlapi.GetSystemCurrentType(thiscmd, thisReader, SNO, systemType, result) = False Then
			' check to see if we are a board
			If sqlapi.GetBoardCurrentType(myCmd, myreader, Serial_TextBox.Text, serialRecord, systemType, result) = False Then
				MsgBox(result)
				Return false
			End If
		End If

		'Get the filepath of our template.
		thiscmd.CommandText = "SELECT [valuestring] FROM SystemParameters WHERE [id] = '" & systemType & " labelpath'"
		Dim resultTable As New DataTable
		resultTable.Load(thiscmd.ExecuteReader)

		If resultTable.Rows.Count <> 0 Then
			templatePath = resultTable(0)("valuestring")
			If File.Exists(templatePath) = False Then
				Dim answer As Integer = MessageBox.Show(templatePath & " does not exist. Fix it now?", "Continue?", MessageBoxButtons.YesNo)
				If answer = DialogResult.No Then
					Return False
				Else
					SelectFile(templatePath, systemType, False, thiscmd)
				End If
			End If
		Else
			Dim answer As Integer = MessageBox.Show(systemType & " does not have the template path set up. Look for it now?", "Continue?", MessageBoxButtons.YesNo)
			If answer = DialogResult.No Then
				Return False
			Else
				SelectFile(templatePath, systemType, True, thiscmd)
			End If
		End If

		Dim fileName As String = My.Settings.TempFolder & "\" & SNO & ".prn"

		My.Computer.FileSystem.WriteAllText(fileName, My.Computer.FileSystem.ReadAllText(templatePath).Replace("[SNO]", SNO).Replace("[QTY]", QTY), False)

		If Printer.RawHelper.SendFileToPrinter(printerName, fileName) = False Then
			Return False
		End If

		Return True
	End Function

	Public Function CheckPrinter(ByVal printerName As String) As Boolean

		If printerName.Length = 0 Then
			Dim p As New PrintDialog
			p.UseEXDialog = True
			If p.ShowDialog = DialogResult.OK Then
				My.Settings.ZebraPrinter = p.PrinterSettings.PrinterName
				My.Settings.Save()
			Else
				Return False
			End If
		End If

		Return True
	End Function

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub Serial_TextBox_TextChanged() Handles Serial_TextBox.LostFocus
		If Serial_TextBox.Text.Length <> 0 Then
			Print_Button_Click()
			Serial_TextBox.Focus()
			Serial_TextBox.Text = ""
		End If
	End Sub
End Class



Namespace Printer

	Public Class RawHelper

#Region "DLLImports"

		<DllImport(“winspool.Drv”, EntryPoint:=”OpenPrinterW”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=False, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function OpenPrinter(ByVal printerName As String, ByRef printerHandle As IntPtr, ByVal printerDefault As Integer) As Long
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”ClosePrinter”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”StartDocPrinterW”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=False, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”EndDocPrinter”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”StartPagePrinter”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”EndPagePrinter”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
		End Function

		<DllImport(“winspool.Drv”, EntryPoint:=”WritePrinter”, SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
		Private Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
		End Function

#End Region

		Private Shared Function SendBytesToPrinter(ByVal printerName As String, ByVal bytesPointer As IntPtr, ByVal bufferSize As Int32) As Boolean
			Dim printerHandle As IntPtr             ' The printer handle
			Dim printerError As Int32               ' Last Error
			Dim di As New DOCINFOW                  ' Describes your document (name, port, data type)
			Dim bytesWritten As Int32               ' The number of bytes written by WritePrinter()
			Dim success As Boolean = False          ' success if true

			' Set up the DOCINFO structure
			di.DocumentName = Reflection.Assembly.GetCallingAssembly.GetName.Name
			di.PrinterDataType = “RAW”

			If OpenPrinter(printerName, printerHandle, 0) > 0 Then
				If StartDocPrinter(printerHandle, 1, di) Then
					If StartPagePrinter(printerHandle) Then
						' Write your printer-specific bytes to the printer.
						success = WritePrinter(printerHandle, bytesPointer, bufferSize, bytesWritten)
						EndPagePrinter(printerHandle)
					End If
					EndDocPrinter(printerHandle)
				End If
				ClosePrinter(printerHandle)
			End If

			If Not success Then
				printerError = Marshal.GetLastWin32Error()
				MsgBox("Could not open Printer. Error: " & printerError)
			End If

			Return success
		End Function

		Public Shared Function SendFileToPrinter(ByVal printerName As String, ByVal filePath As String) As Boolean
			Try
				' Open the file.
				Dim fs As New FileStream(filePath, FileMode.Open)
				Dim br As New BinaryReader(fs)
				Dim bufferSize As Int32 = 0

				Try
					bufferSize = Convert.ToInt32(fs.Length)
				Catch ex As Exception
					Throw New Exception(“The file size Is too big to be processed by this engine”)
				End Try

				' Dim an array of bytes large enough to hold the file’s contents.
				Dim fileData(bufferSize) As Byte
				Dim success As Boolean = False

				' Your unmanaged pointer.
				Dim memoryPointer As IntPtr

				' Read the contents of the file into the array.
				fileData = br.ReadBytes(bufferSize)

				' Allocate some unmanaged memory for those bytes.
				memoryPointer = Marshal.AllocCoTaskMem(bufferSize)

				' Copy the managed byte array into the unmanaged array.
				Marshal.Copy(fileData, 0, memoryPointer, bufferSize)

				' Send the unmanaged bytes to the printer.
				success = SendBytesToPrinter(printerName, memoryPointer, bufferSize)

				' Free the unmanaged memory that you allocated earlier.
				Marshal.FreeCoTaskMem(memoryPointer)

				Return success
			Catch ex As Exception
				Throw
			End Try

		End Function

	End Class

	<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
	Friend Structure DOCINFOW
		<MarshalAs(UnmanagedType.LPWStr)> Public DocumentName As String
		<MarshalAs(UnmanagedType.LPWStr)> Public OutputFile As String
		<MarshalAs(UnmanagedType.LPWStr)> Public PrinterDataType As String
	End Structure

End Namespace