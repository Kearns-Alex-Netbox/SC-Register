Imports System.Data.SqlClient

Public Class ViewSystemExtrasInfo
	Dim myCmd As New SqlCommand("", myConn)

	Dim da As SqlDataAdapter
	Dim ds As DataSet

	Dim systemExtraName As String = ""

	Public Sub New(ByRef passName As String)
		InitializeComponent()
		systemExtraName = passName
	End Sub

	Private Sub ViewSystemExtrasInfo_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		KeyPreview = True
		L_Name.Text = systemExtraName

		RetrieveData()
	End Sub

	Private Sub RetrieveData()
		Dim result As String = ""
		Try
			myCmd.CommandText = "SELECT ec.[Description], ec.[Qty], ec.[DateOfService] FROM SystemExtrasMap map JOIN ExtraComponents ec ON ec.id = map.[ExtraComponents.id]
WHERE map.[SystemExtras.id] = (SELECT id from SystemExtras where [Description] ='" & systemExtraName & "')"
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			da.Fill(ds, "TABLE")

			DataGridView1.DataSource = ds.Tables(0)
			DataGridView1.Focus()

			DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		If ChkB_Default.Checked = True Then
			' update this record to be our defalut.

			' select the system type id
			myCmd.CommandText = "SELECT [SystemType.id] FROM SystemExtras WHERE [Description] = '" & systemExtraName & "'"
			Dim typeID As String = myCmd.ExecuteScalar().ToString()

			myCmd.CommandText = "UPDATE systemExtras SET [Default] = 0 WHERE [SystemType.id] = '" & typeID & "'"
			myCmd.ExecuteNonQuery()

			myCmd.CommandText = "UPDATE systemExtras SET [Default] = 1 WHERE [Description] = '" & systemExtraName & "'"
			myCmd.ExecuteNonQuery()
		End If
		Me.Close()
	End Sub

End Class