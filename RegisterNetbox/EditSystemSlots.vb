Imports System.Data.SqlClient

Public Class EditSystemSlots
    Const IS_TRUE As String = "1"
    Const IS_FALSE As String = "0"

	Dim myCmd As New SqlCommand("", myConn)

	Private Sub EditSystemSlots_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		If TB_SystemSerialNumber.Text.Length = 0 Then
			MsgBox("Please put in a System Serial Number.")
			Return
		End If
		If CB_Slot.Text.Length = 0 Then
			MsgBox("Please select a slot number.")
			Return
		End If
		If TB_BoardSerialNumber.Text.Length = 0 Then
			MsgBox("Please put in a Board Serial Number.")
			Return
		End If

		Dim myReader As SqlDataReader = Nothing
		Dim result As String = ""
		Dim typeName As String = ""
		Dim typeGUID As String = ""

		If sqlapi.GetSystemCurrentType(myCmd, myReader, TB_SystemSerialNumber.Text, typeName, result) = False Then
			MsgBox(result)
			Return
		End If

		If sqlapi.GetSystemType(myCmd, myReader, typeName, typeGUID, result) = False Then
			MsgBox(result)
			Return
		End If

		If sqlapi.CheckSystemDefinition(myCmd, typeGUID, CB_Slot.Text, TB_BoardSerialNumber.Text) = False Then
			Return
		End If

		If sqlapi.AddBoardToExistingSystem(myCmd, myConn, myReader, TB_SystemSerialNumber.Text, TB_BoardSerialNumber.Text, CB_Slot.Text, "") = False Then
			Return
		End If

		TB_Result.Text = "Board " & TB_BoardSerialNumber.Text & " was added to system " & TB_SystemSerialNumber.Text & " " & CB_Slot.Text
		TB_BoardSerialNumber.Text = ""
		TB_SystemSerialNumber.Focus()

		UpdateLB_Definitions()
	End Sub

	Private Sub B_Remove_Click() Handles B_Remove.Click
		If TB_SystemSerialNumber.Text.Length = 0 Then
			MsgBox("Please put in a System Serial Number.")
			Return
		End If
		If CB_Slot.Text.Length = 0 Then
			MsgBox("Please select a slot number.")
			Return
		End If

		Dim myReader As SqlDataReader = Nothing
		Dim result As String = ""
		Dim boardSerialNumber As String = ""

		If sqlapi.RemoveBoardFromExistingSystem(myCmd, myConn, myReader, TB_SystemSerialNumber.Text, boardSerialNumber, CB_Slot.Text, result) = False Then
			Return
		End If

		TB_Result.Text = "Board " & boardSerialNumber & " was removed from system " & TB_SystemSerialNumber.Text & " " & CB_Slot.Text
		TB_BoardSerialNumber.Text = ""
		TB_SystemSerialNumber.Focus()

		UpdateLB_Definitions()
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

	Private Sub TB_SystemSerialNumber_LostFocus() Handles TB_SystemSerialNumber.LostFocus
		UpdateLB_Definitions()
	End Sub

	Private Sub UpdateLB_Definitions()
        Dim myReader As SqlDataReader = Nothing
        Dim result As String = ""
        LB_SystemSlots.Items.Clear()

        If B_Close.Focused Then
            Return
        End If

        If TB_SystemSerialNumber.Text.Length = 0 Then
            Return
        End If

        If sqlapi.FindSystemSerialNumber(myCmd, myReader, TB_SystemSerialNumber.Text, result) = False Then
            MsgBox(result)
            Return
        End If

        If sqlapi.GetSystemBoards(myCmd, myReader, TB_SystemSerialNumber.Text, LB_SystemSlots, result) = False Then
            MsgBox(result)
            Return
        End If

        Dim typeName As String = ""
        Dim typeGUID As String = ""

        If sqlapi.GetSystemCurrentType(myCmd, myReader, TB_SystemSerialNumber.Text, typeName, result) = False Then
            MsgBox(result)
            Return
        End If

        If sqlapi.GetSystemType(myCmd, myReader, typeName, typeGUID, result) = False Then
            MsgBox(result)
            Return
        End If

        LB_Definitions.Items.Clear()
        LB_Definitions.Items.Add(typeName)
        myCmd.CommandText = "SELECT y.SlotNumber, y.Mandatory, s.BaseSerialNo FROM dbo.SystemDefinition y LEFT JOIN dbo.BoardType s ON y.[BoardType.id] = s.id WHERE y.[SystemType.id] = '" & typeGUID & "' ORDER BY SlotNumber"

        myReader = myCmd.ExecuteReader

        If myReader.HasRows = True Then
            While myReader.Read
                If myReader("Mandatory") = IS_FALSE Then
                    LB_Definitions.Items.Add("Slot " & myReader("SlotNumber") & "   N   " & myReader("BaseSerialNo"))
                Else
                    LB_Definitions.Items.Add("Slot " & myReader("SlotNumber") & "   Y   " & myReader("BaseSerialNo"))
                End If
            End While
        Else
            LB_Definitions.Items.Add("There are no definitions for this system yet.")
        End If
        myReader.Close()
    End Sub

End Class