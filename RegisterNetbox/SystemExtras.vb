Imports System.Data.SqlClient

Public Class SystemExtras
	Const ENTRIES_TO_SHOW As Integer = 10

	Dim myCmd As New SqlCommand("", myConn)

	Dim da As SqlDataAdapter
	Dim ds As DataSet
	Dim scrollVal As Integer
	Dim numberOfRecords As Integer

	Private Sub SystemExtras_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		KeyPreview = True

		DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Description", .Name = "Description"})
		DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "System", .Name = "System"})
		DataGridView1.Columns.Add(New DataGridViewCheckBoxColumn With {.DataPropertyName = "Default", .Name = "Default"})
		RetrieveData()
	End Sub

	Private Sub RetrieveData()
		Dim result As String = ""
		Try
			myCmd.CommandText = "SELECT COUNT(*) FROM SystemExtras"
			numberOfRecords = myCmd.ExecuteScalar
			myCmd.CommandText = "SELECT [Description], SystemType.name as 'System', [Default] FROM SystemExtras join SystemType on SystemExtras.[SystemType.id] = SystemType.id ORDER BY [Description]"
			da = New SqlDataAdapter(myCmd)
			ds = New DataSet()

			scrollVal = 0
			da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")

			B_Previous.Enabled = False
			B_Next.Enabled = True

			DataGridView1.DataSource = ds.Tables(0)
			DataGridView1.Focus()

			DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_First_Click() Handles B_First.Click
		scrollVal = 0
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = False
		B_Next.Enabled = True
	End Sub

	Private Sub B_Previous_Click() Handles B_Previous.Click
		scrollVal = scrollVal - ENTRIES_TO_SHOW
		If scrollVal <= 0 Then
			scrollVal = 0
			B_Previous.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Next.Enabled = True
	End Sub

	Private Sub B_Next_Click() Handles B_Next.Click
		scrollVal = scrollVal + ENTRIES_TO_SHOW
		If scrollVal > numberOfRecords Then
			scrollVal = numberOfRecords - ENTRIES_TO_SHOW
			If scrollVal < 0 Then
				scrollVal = 0
			End If
			B_Next.Enabled = False
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		'Check to see if we can keep scrolling or if we are at the end of the table.
		If scrollVal + ENTRIES_TO_SHOW >= numberOfRecords Then
			B_Next.Enabled = False
		End If
		DataGridView1.Focus()
		B_Previous.Enabled = True
	End Sub

	Private Sub B_Last_Click() Handles B_Last.Click
		scrollVal = numberOfRecords - ENTRIES_TO_SHOW
		If scrollVal < 0 Then
			scrollVal = 0
		End If
		ds.Clear()
		da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")
		DataGridView1.Focus()
		B_Previous.Enabled = True
		B_Next.Enabled = False
	End Sub

	Private Sub B_Details_Click() Handles B_Details.Click
		If DataGridView1.SelectedRows.Count = 1 Then
			'Get the name
			Dim selectedRow As Integer = DataGridView1.SelectedCells.Item(0).RowIndex
			Dim name = DataGridView1(0, selectedRow).Value

			'Open up our details
			Dim DoViewSystemExtras As New ViewSystemExtrasInfo(name)
			DoViewSystemExtras.ShowDialog()

			RetrieveData()
		Else
			MsgBox("Please select 1 row.")
		End If
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		Dim DoAddSystemExtras As New AddSystemExtras()
		DoAddSystemExtras.ShowDialog()

		RetrieveData()
	End Sub

	Private Sub DataGridView1_CellEnter() Handles DataGridView1.CellMouseDoubleClick
		Try
			B_Details_Click()
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

End Class