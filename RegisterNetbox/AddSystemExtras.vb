Imports System.Data.SqlClient

Public Class AddSystemExtras

	Dim myCmd As New SqlCommand("", myConn)

	Dim da As SqlDataAdapter
	Dim ds As DataSet
	Dim scrollVal As Integer
	Dim numberOfRecords As Integer

	Private Sub AddSystemExtras_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		KeyPreview = True

		RetrieveData()

		'Populate SystemType drop-down
		CB_SystemType.DataSource = GetDropDownItems()
		CB_SystemType.DisplayMember = "Name"
		CB_SystemType.ValueMember = "ID"
		CB_SystemType.DropDownHeight = 200
	End Sub

	Private Sub RetrieveData()
		Dim result As String = ""
		Try
			myCmd.CommandText = "SELECT Description, DateOfService, Qty FROM ExtraComponents ORDER BY Description"
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

	Function GetDropDownItems() As List(Of DropDownItem)
		Dim dropDownItems = New List(Of DropDownItem)
		Dim myReader As SqlDataReader = Nothing

		Try
			myCmd.CommandText = "SELECT * FROM dbo.SystemType WHERE name NOT LIKE '%Spare%' ORDER BY name"
			myReader = myCmd.ExecuteReader()
			If myReader.HasRows = True Then
				While myReader.Read()
					dropDownItems.Add(New DropDownItem(myReader("id").ToString, myReader("name")))
				End While
			End If
			myReader.Close()
		Catch ex As Exception
			If Not myReader Is Nothing Then
				myReader.Close()
			End If
			MsgBox(ex.Message)
		End Try
		Return dropDownItems
	End Function

	Private Sub DataGridView1_CellEnter() Handles DataGridView1.CellMouseDoubleClick
		B_AddtoList_Click()
	End Sub

	Private Sub B_AddtoList_Click() Handles B_AddtoList.Click
		'Get the name
		Dim selectedRow As Integer = DataGridView1.SelectedCells.Item(0).RowIndex
		Dim name = DataGridView1(0, selectedRow).Value

		If LB_ExtraComponents.Items.Contains(name) = False Then
			LB_ExtraComponents.Items.Add(name)
		End If
	End Sub

	Private Sub B_Remove_Click() Handles B_Remove.Click
		If (LB_ExtraComponents.SelectedIndex >= 0) Then
			LB_ExtraComponents.Items.RemoveAt(LB_ExtraComponents.SelectedIndex)
		End If
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		If (TB_Description.Text.Length = 0) Then
			MsgBox("Please put in a description.")
			Return
		End If

		If (LB_ExtraComponents.Items.Count = 0) Then
			MsgBox("Please add at least one item from the component list.")
			Return
		End If

		' select the system type id
		Dim typeID As String = CB_SystemType.SelectedValue.ToString()

		' figure our if we are setting to default or not
		Dim isDefault As Integer = 0

		' this will make sure that we have at least one default per system type once they are added
		myCmd.CommandText = "SELECT COUNT(*) FROM SystemExtras WHERE [SystemType.id] = '" & typeID & "' AND [Default] = 1"
		If myCmd.ExecuteScalar = 0 Or ChkB_Default.Checked = True Then
			isDefault = 1
		End If

		Dim transaction As SqlTransaction = Nothing
		transaction = myConn.BeginTransaction("Update system status")
		myCmd.Transaction = transaction

		Try
			' if we are setting this to be our default, we need to make all others of the same system type not the default
			If isDefault = 1 Then
				myCmd.CommandText = "UPDATE systemExtras SET [Default] = 0 WHERE [SystemType.id] = '" & typeID & "'"
				myCmd.ExecuteNonQuery()
			End If

			' insert new system extra record and get id
			myCmd.CommandText = "INSERT INTO SystemExtras(id, Description, [SystemType.id], [Default], LastUpdate) values(NEWID(), '" & TB_Description.Text & "', '" & typeID & "', " & isDefault & ", GETDATE())"
			myCmd.ExecuteNonQuery()

			myCmd.CommandText = "SELECT id from SystemExtras where Description = '" & TB_Description.Text & "'"
			Dim systemExtraID As String = myCmd.ExecuteScalar.ToString()

			' step through all items and insert into extras map
			For Each item In LB_ExtraComponents.Items
				' get the id of the extra component
				myCmd.CommandText = "SELECT id from ExtraComponents where Description = '" & item & "'"
				Dim extraComponentID As String = myCmd.ExecuteScalar.ToString()

				' insert both ids into the map table
				myCmd.CommandText = "INSERT INTO SystemExtrasMap([SystemExtras.id], [ExtraComponents.id]) VALUES('" & systemExtraID & "', '" & extraComponentID & "')"
				myCmd.ExecuteNonQuery()
			Next

			transaction.Commit()

			TB_Result.Text = "Extra System " & TB_Description.Text & " was added successfuly."

			TB_Description.Text = ""
			LB_ExtraComponents.Items.Clear()
			ChkB_Default.Checked = False
		Catch ex As Exception
			Dim result As String = ""
			sqlapi.RollBack(transaction, result)
			MsgBox(ex.Message() & "::" & result)
		End Try
	End Sub

End Class