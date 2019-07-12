Imports System.Data.SqlClient

Public Module Variables
	Public Const TIMEOUT As Integer = 1800000    '1 second = 1000    1 minute = 60000    1/2 hour = 1800000    1 hour = 3600000

    Public		 WorkingSystemSerialNumber As	  String  = ""
    Public		 WorkingIP				   As	  String  = ""
	
	Public		 checkoutLocations()	   As	  String  = { "\\Server1\Production\checkoutsheets\", 
															  "C:\Temp\checkoutsheets\", 
															  "\\Server1\Production\checkoutsheets\BSG\",
															  "C:\Temp\checkoutsheets\BSG\" }
	Public		 Databases()			   As	  String  = { "Production",
															  "Devel", 
															  "BlueSkyProduction", 
															  "BlueSkyDevel" }
	Public		 BASE_MAC()				   As	  String  = { "70-b3-d5-85-2",
															  "70-b3-d5-85-2",
															  "70-83-d5-1d-8",
															  "70-83-d5-1d-8" }
	Public Const NB_PRODUCTION			   As	  Integer = 0
	Public Const NB_DEVEL				   As	  Integer = 1
	Public Const BSG_PRODUCTION			   As	  Integer = 2
	Public Const BSG_DEVEL				   As	  Integer = 3

	public		 CurrentIndex			   As	  Integer = NB_DEVEL
	Public		 CurrentDatabase		   As	  String  = Databases(CurrentIndex)
	Public		 CurrentCheckout		   As	  String  = checkoutLocations(CurrentIndex)

	Public Const MAX_NB_SLOTS			   As	  Integer = 10
	Public Const MAX_BSG_SLOTS			   As	  Integer = 5

	Public		 myConn					   As     SqlConnection
	Public		 sqlapi					   As New SQL_API()
	'Public		 BSG_sqlapi				   As New BSG_SQL_API()
End Module

Public Class Login

	Private Sub Login_Load() Handles MyBase.Load
		L_Version.Text = "V:" & Application.ProductVersion
		Dim Success As Boolean

		' find out what database we are going to connect to
		Select Case CurrentDatabase
			Case Databases(NB_PRODUCTION)
				L_Database.Text = "NB"

			Case Databases(NB_DEVEL)
				L_Database.Text = "NB Devel"

			Case Databases(BSG_PRODUCTION)
				L_Database.Text = "BSG"

			Case Databases(BSG_DEVEL)
				L_Database.Text = "BSG Devel"

			Case Else
				L_Database.Text = "NOT KNOWN"

		End Select

		' close all other windows associated with the program. this is required for our timeout feature.
		Do
			Success = True
			Try
				For Each f As Form In My.Application.OpenForms
					If String.Compare(f.Name, "Login") <> 0 Then
						f.Close()
					End If
				Next f
			Catch ex As Exception
				Success = False
			End Try
		Loop Until Success
	End Sub

	Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyCode.Equals(Keys.Enter) Then
			Call B_Login_Click()
		End If
	End Sub

	Private Sub B_Login_Click() Handles B_Login.Click
		sqlapi._Username = TB_User.Text
		sqlapi._Password = TB_Password.Text
		Dim result As String = ""

		If sqlapi.OpenDatabase(myConn, result) = False Then
			MsgBox(result)
			Return
		End If

		Select Case CurrentDatabase
			Case Databases(NB_PRODUCTION)
				Dim DoMainForm As New MenuMain
				DoMainForm.Show()
			Case Databases(NB_DEVEL)
				Dim DoMainForm As New MenuMain
				DoMainForm.Show()

			Case Databases(BSG_PRODUCTION)
				Dim DoMainForm As New BSG_MenuMain
				DoMainForm.Show()
			Case Databases(BSG_DEVEL)
				Dim DoMainForm As New BSG_MenuMain
				DoMainForm.Show()

			Case Else
				MsgBox("We do know know how to handle " & CurrentDatabase)
				Return
		End Select

		Close()
	End Sub

	Private Sub B_Exit_Click() Handles B_Exit.Click
		Application.Exit()
	End Sub

End Class