Imports System.Data.SqlClient

Public Class HardwareVersions
    Const ENTRIES_TO_SHOW As Integer = 10

	Dim myCmd As New SqlCommand("", myConn)
	Dim myReader As SqlDataReader = Nothing

	Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim scrollVal As Integer
    Dim numberOfRecords As Integer

	Private Sub HardwareVersions_Load() Handles MyBase.Load
		Text &= "  (" & sqlapi._Username & ")"

		RetrieveData()
	End Sub

	Private Sub RetrieveData()
        Dim result As String = ""
        Try
            sqlapi.GetNumberOfRecords(myCmd, myReader, "SELECT COUNT(*) FROM dbo.BoardType", numberOfRecords, result)
            myCmd.CommandText = "SELECT name, BaseSerialNo, HardwareVersion FROM dbo.boardType ORDER BY name"
            da = New SqlDataAdapter(myCmd)
            ds = New DataSet()

            scrollVal = 0
            da.Fill(ds, scrollVal, ENTRIES_TO_SHOW, "TABLE")

            B_Previous.Enabled = False
            B_Next.Enabled = True

            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Focus()

            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

	Private Sub B_Update_Click() Handles B_Update.Click
		Try
			myCmd.CommandText = ("UPDATE dbo.BoardType SET HardwareVersion = @HardwareVersion WHERE BaseSerialNo = @BaseSerialNo")
			myCmd.Parameters.Add("@HardwareVersion", SqlDbType.VarChar, 50, "HardwareVersion")
			myCmd.Parameters.Add("@BaseSerialNo", SqlDbType.VarChar, 50, "BaseSerialNo")
			da.UpdateCommand = myCmd

			da.Update(ds, "TABLE")
			myCmd.Parameters.RemoveAt("@BaseSerialNo")
			myCmd.Parameters.RemoveAt("@HardwareVersion")

			RetrieveData()

			TB_Result.Text = "Updated successfully."
		Catch ex As Exception
			TB_Result.Text = "Could not update the harware version." & ex.Message
		End Try
	End Sub

	Private Sub B_Add_Click() Handles B_Add.Click
		If TB_Name.Text.Length <> 0 And TB_SerialNumber.Text.Length <> 0 And TB_Version.Text.Length <> 0 Then
			Try
				myCmd.CommandText = ("INSERT INTO dbo.BoardType(id,name,BaseSerialNo,HardwareVersion) VALUES(NEWID(), '" & TB_Name.Text & "','" & TB_SerialNumber.Text & "','" & TB_Version.Text & "')")
				myCmd.ExecuteNonQuery()
				RetrieveData()
				TB_Result.Text = "Added " & TB_Name.Text & " with Base Serial Number of " & TB_SerialNumber.Text & " starting with Version " & TB_Version.Text & " successfully."
			Catch ex As Exception
				TB_Result.Text = "Could not add new board type to the database." & ex.Message
			End Try
			TB_Name.Focus()
		Else
			MsgBox("Please fill in each textbox before trying to add a new board type.")
		End If
	End Sub

	Private Sub B_Close_Click() Handles B_Close.Click
		Close()
	End Sub

End Class