Imports System.Data.SqlClient

Public Class ViewBoardInfo

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing
	Dim boardSerialNumber As String = ""

    Public Sub New(ByRef SerialNumber As String)
        InitializeComponent()
        boardSerialNumber = SerialNumber
    End Sub

	Private Sub ViewBoardInfo_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		SetInfo(boardSerialNumber)
	End Sub

	Private Sub ExitButton_Click() Handles ExitButton.Click
		Close()
	End Sub

	Private Sub SetInfo(ByRef boardSerialNo As String)
        Dim result As String = ""
        Dim record As Guid = Nothing

        L_BoardSerialNumber.Text = boardSerialNo

        sqlapi.GetBoardBootloaderVersion(myCmd, myReader, boardSerialNo, BootloaderVersion.Text, result)

        sqlapi.GetBoardSoftwareVersion(myCmd, myReader, boardSerialNo, BoardVersion.Text, result)

        sqlapi.GetBoardLastUpdate(myCmd, myReader, boardSerialNo, LastUpdate.Text, record, result)

        sqlapi.GetBoardCurrentStatus(myCmd, myReader, boardSerialNo, BoardStatus.Text, result)

        sqlapi.GetBoardAudit(myCmd, myReader, boardSerialNo, RTB_Results, result)

        sqlapi.GetBoardCurrentType(myCmd, myReader, boardSerialNo, record, BoardType.Text, result)

        sqlapi.GetBoardHardwareVersion(myCmd, myReader, boardSerialNo, HardwareVersion.Text, result)

        sqlapi.GetMACAddress(myCmd, myReader, boardSerialNo, MACAddress.Text, result)

        sqlapi.GetCPUID(myCmd, myReader, boardSerialNo, CPUID.Text, result)
    End Sub

	Private Sub L_BoardSerialNumber_Click() Handles L_BoardSerialNumber.Click
		Dim DoAddBoardComment As New AddBoardComment(L_BoardSerialNumber.Text, False)
		DoAddBoardComment.ShowDialog()
	End Sub

	Private Sub B_AddComment_Click() Handles B_AddComment.Click
		Dim DoAddBoardComment As New AddBoardComment(L_BoardSerialNumber.Text, False)
		DoAddBoardComment.ShowDialog()
	End Sub

End Class