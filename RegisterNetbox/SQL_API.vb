Imports System.Data.SqlClient

Public Class SQL_API
    Private username As String = ""
    Private password As String = ""

	'Board Status'
	Public Const BS_BOARD_CHECKED As String = "Board Checked"
	Public Const BS_BOARD_REGISTERED As String = "Board Registered"
	Public Const BS_NETWORK_REGISTERED As String = "Network Registered"
	Public Const BS_BURN_IN As String = "Burn In"
	Public Const BS_QC_CHECKOUT As String = "QC Checkout"
	Public Const BS_SHIPPED As String = "Ship"
	Public Const BS_REWORK As String = "Rework"

	'System Status'
	Public Const SS_BOARDS_REGISTERED As String = "Boards Registered"
	Public Const SS_BURN_IN As String = "Burn In"
	Public Const SS_NETWORK_REGISTERED As String = "Network Registered"
	Public Const SS_QC_CHECKOUT As String = "QC Checkout"
	Public Const SS_REWORK As String = "Rework"
	Public Const SS_SCRAPPED As String = "Scrapped"
	Public Const SS_SET_PARAMETERS As String = "Set Parameters"

	'System Dates
	Public Const BARCODE_DATE As String = "BarcodeDate"
	Public Const REGISTER_DATE As String = "RegisterDate"
	Public Const PARAMETER_DATE As String = "ParameterDate"
	Public Const BURN_IN_DATE As String = "BurnInDate"
	Public Const CHECKOUT_DATE As String = "CheckoutDate"
	Public Const SHIP_DATE As String = "ShipDate"

	Dim myReader As SqlDataReader

    ''' <summary>
    ''' Either sets or returns the string value for username.
    ''' </summary>
    ''' <value>String value that you want to set username to.</value>
    ''' <returns>Returns the string value that username is currently set to.</returns>
    ''' <remarks>This is your username.</remarks>
    Public Property _Username() As String
        Get
            Return username.ToString
        End Get
        Set(ByVal value As String)
            username = value
        End Set
    End Property

    ''' <summary>
    ''' Either sets or returns the string value for password.
    ''' </summary>
    ''' <value>String value that you want to set password to.</value>
    ''' <returns>Returns the string value that password is currently set to.</returns>
    ''' <remarks>This is your passwrod.</remarks>
    Public Property _Password() As String
        Get
            Return password.ToString
        End Get
        Set(ByVal value As String)
            password = value
        End Set
    End Property

    ''' <summary>
    ''' Opens the connection to the database and saves the user who is logged in.
    ''' </summary>
    ''' <param name="myConn">The connection that you would like to make.</param>
    ''' <param name="result">OUTPUT: Error string if somethign does not go as planned.</param>
    ''' <returns>True: successful open and return username. False: unsuccessful, see result message for details.</returns>
    ''' <remarks>This needs to be called before you make anyother commands.</remarks>
    Public Function OpenDatabase(ByRef myConn As SqlConnection, ByRef result As String) As Boolean
        myConn = New SqlConnection("server=tcp:nas1,1622;Database=" & CurrentDatabase & ";User ID=" & username & ";password= " & password & ";")
        Try
            myConn.Open()
			Dim myCmd As New SqlCommand("", myConn)
            myCmd = myConn.CreateCommand

            'Get the logged in user name from the database.
            myCmd.CommandText = "SELECT ORIGINAL_LOGIN()"
            myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "Login name returned NULL."
                    Return False
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "Login name does not exist."
                Return False
            End If

            myReader.Close()
            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Closes the database connection that gets passed through.
    ''' </summary>
    ''' <param name="myConn">The connection that you want to close.</param>
    ''' <param name="result">OUTPUT: Error result if somthing does not go right.</param>
    ''' <returns>True: Successful close. False: unsuccessful close, see result message for information.</returns>
    ''' <remarks>Make sure the connection is already open first before trying to close it.</remarks>
    Public Function CloseDatabase(ByRef myConn As SqlConnection, ByRef result As String) As Boolean
        Try
            If myConn.State <> ConnectionState.Closed Then
                myConn.Close()
            End If
            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
    End Function

    '-----------------------------------'
    '                                   '
    '     A D D   F U N C T I O N S     '
    '                                   '
    '-----------------------------------'

    ''' <summary>
    ''' Adds a board entry into the database filled with all of the values that you pass throguh.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using to make this action.</param>
    ''' <param name="serialNumber">The serial number of the board.</param>
    ''' <param name="record">OUTPUT: The record number that the new entry will be assigned.</param>
    ''' <param name="result">OUTPUT: Error message if something goes wrong.</param>
    ''' <returns>True: successful entry addition, record number is returned. False: Something went wrong, see result message for more details.</returns>
    ''' <remarks></remarks>
    Public Function AddBoard(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef serialNumber As String, ByRef record As Guid,
							 ByRef result As String, ByRef withSystem As Boolean, ByRef hardwareVersion As String) As Boolean
		Dim boardType As String = ""
		Dim boardPrefix As String = ""
		Dim boardHardwareVersion As String = hardwareVersion
		Dim boardStatus As String = ""
		Dim transaction As SqlTransaction = Nothing

		If GetBoardGUIDBySerialNumber(myCmd, myReader, serialNumber, "", result) = True Then
			result = "[AddBoard1] This board is already in the database."
			Return False
		End If

		If GetBoardTypeByPrefix(myCmd, serialNumber, boardType, boardPrefix, result) = False Then
			result = "[AddBoard2] Something went wrong while trying to get a board prefix: " & result
			Return False
		End If

		Try
			' check to see if we passed in a custom hardware version or not
			If hardwareVersion.Length = 0 Then
				'Get board Hardware version
				myCmd.CommandText = "SELECT HardwareVersion FROM dbo.BoardType WHERE BaseSerialNo = '" & boardPrefix & "'"
				myReader = myCmd.ExecuteReader()
				If myReader.Read() Then
					'Check to see if we are returned a NULL value.
					If myReader.IsDBNull(0) Then
						result = "[AddBoard3] HardwareVersion for '" & boardPrefix & "' is NULL."
						myReader.Close()
						Return False
					Else
						boardHardwareVersion = myReader.GetString(0)
					End If
				Else
					'If nothing is returned then it does not exist.
					result = "[AddBoard4] HardwareVersion for '" & boardPrefix & "' does not exist."
					myReader.Close()
					Return False
				End If
				myReader.Close()
			End If

			'Get board status 'Board Registered' since we are adding the entry into the database.
			myCmd.CommandText = "SELECT id FROM dbo.BoardStatus WHERE name = '" & BS_BOARD_CHECKED & "'"
			myReader = myCmd.ExecuteReader()
			If myReader.Read() Then
				'Check to see if we are returned a NULL value.
				If myReader.IsDBNull(0) Then
					result = "[AddBoard5] Board status name '" & BS_BOARD_CHECKED & "' is NULL."
					myReader.Close()
					Return False
				Else
					boardStatus = myReader.GetGuid(0).ToString
				End If
			Else
				'If nothing is returned then it does not exist.
				result = "[AddBoard6] Board status name '" & BS_BOARD_CHECKED & "' does not exist."
				myReader.Close()
				Return False
			End If
			myReader.Close()

			If withSystem = False Then
				transaction = myConn.BeginTransaction("Add Board Transaction")
				myCmd.Connection = myConn
				myCmd.Transaction = transaction
			End If

			'Insert the board record into the board table.
			myCmd.CommandText = "INSERT INTO dbo.Board(boardid,[dbo.BoardStatus.id],[dbo.BoardType.id],SerialNumber,HardwareVersion,LastUpdate) VALUES(NEWID(),'" &
								 boardStatus & "','" & boardType & "','" & serialNumber & "','" & boardHardwareVersion & "', GETDATE())"
			myCmd.ExecuteNonQuery()

			'Create a generic comment for the new board entry.
			If AddBoardComment(myCmd, serialNumber, "Board has been added to the database.", record, result) = False Then
				result = "[AddBoard7]Something went wrong while trying to add a comment to this update: " & result
				myReader.Close()
				Return False
			End If

			If withSystem = False Then
				transaction.Commit()
			End If

			Return True
		Catch ex As Exception
			result = "[AddBoard exception] " & ex.Message
			myReader.Close()
			If Not transaction Is Nothing Then
				RollBack(transaction, result)
			End If
			Return False
		End Try
	End Function

    ''' <summary>
    ''' Adds a comment to the board serial number that is passed through.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using to make this action.</param>
    ''' <param name="serialNumber">The serial number of the board that you want to add the comment to.</param>
    ''' <param name="comment">The comment string that you want to add.</param>
    ''' <param name="record">OUTPUT: The ID associated with the board.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Comment was added successfully. False: There was a problem, see result message.</returns>
    ''' <remarks></remarks>
    Public Function AddBoardComment(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef comment As String,  _
                                    ByRef record As Guid, ByRef result As String) As Boolean
        Try
            'Get the GUID from the passed in serial number.
            myCmd.CommandText = "SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & serialNumber & "'"
            myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "[AddBoardComment1] Board serial number '" & serialNumber & "' is NULL"
                    myReader.Close()
                    Return False
                Else
                    record = myReader.GetGuid(0)
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "[AddBoardComment2] Board serial number '" & serialNumber & "' does not exist."
                myReader.Close()
                Return False
            End If
            myReader.Close()

            Dim fixedComment As String = comment
            'Replace any single qoutes with double single qoutes for SQL format.
            If comment.Contains("'"c) = True Then
                fixedComment = comment.Replace("'", "''")
            End If

            'Insert the comment corresponding to the serial number into the BoardAudit table form this user.
            myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                    & record.ToString() & "','" & fixedComment & "',GETDATE(),'" & username & "')"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = "[AddBoardComment exception] " & ex.Message
            myReader.Close()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Adds a comment to the system serial number that is passed through.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="serialNumber">The serial number of the System that you want to add the comment to.</param>
    ''' <param name="comment">The comment string that you want to add.</param>
    ''' <param name="record">OUTPUT: The ID associated with the System.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Comment was added successfully. False: There was a problem, see result message.</returns>
    ''' <remarks></remarks>
    Public Function AddSystemComment(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef comment As String,  _
                                     ByRef record As Guid, ByRef result As String) As Boolean
        Try
			'Get the GUID from the passed in serial number.
			myCmd.CommandText = "SELECT systemid FROM system where [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') and SerialNumber = '" & serialNumber & "'"
			myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "[AddSystemComment1] System serial number '" & serialNumber & "' is NULL"
                    myReader.Close()
                    Return False
                Else
                    record = myReader.GetGuid(0)
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "[AddSystemComment2] System serial number '" & serialNumber & "' does not exist."
                myReader.Close()
                Return False
            End If
            myReader.Close()

            Dim fixedComment As String = comment
            'Replace any single qoutes with double single qoutes for SQL format.
            If comment.Contains("'"c) = True Then
                fixedComment = comment.Replace("'", "''")
            End If

            'Insert the comment corresponding to the serial number into the SystemAudit table form this user.
            myCmd.CommandText = "INSERT INTO dbo.SystemAudit(id,[dbo.System.systemid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                    & record.ToString() & "','" & fixedComment & "',GETDATE(),'" & username & "')"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = "[AddSystemComment exception] " & ex.Message
            myReader.Close()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Adds a new System Type to the database.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="systemName">The name of the system that we are adding.</param>
    ''' <param name="baseSerialNumber">The base serial number of the system that we are adding.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Adding the system type was successful. False: Somthing went wrong, see result for details.</returns>
    ''' <remarks></remarks>
    Public Function AddSystemType(ByRef myCmd As SqlCommand, ByRef systemName As String, ByRef baseSerialNumber As String, ByRef serverModel As String, ByRef result As String) As Boolean
        Try
            myCmd.CommandText = "INSERT INTO dbo.SystemType(id, name, BaseSerialNumber, ServerModel) VALUES(NEWID(), '" & systemName & "', '" & baseSerialNumber & "', '" & serverModel & "')"
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Adds a new definition to a system in the database.
    ''' </summary>
    ''' <param name="systemType">The type of system we are adding a definition to.</param>
    ''' <param name="boardType">They board type.</param>
    ''' <param name="slotNumber">The slot number.</param>
    ''' <param name="mandatory">0: Not mandatory. 1: mandatory.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Adding the definition was successful. False: Somthing went wrong, see result for details.</returns>
    ''' <remarks></remarks>
    Public Function AddSystemDefinition(ByRef systemType As String, ByRef boardType As String, ByRef slotNumber As String, _
                                        ByRef mandatory As String, ByRef description As String, ByRef result As String) As Boolean
		Dim myCmd As New SqlCommand("", myConn)
        Try
            myCmd.CommandText = "INSERT INTO dbo.SystemDefinition(id, [SystemType.id], [BoardType.id], SlotNumber, Mandatory, LastChange, Description) VALUES(NEWID(), '" & systemType & "', '" & boardType & "', '" & slotNumber & "', '" & mandatory & "', GETDATE(), '" & description & "')"
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Adds a board to a system that already exists in the database.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="myConn">The SQL Connection that you will be using.</param>
    ''' <param name="myReader">The SQL Data Reader that you will be using.</param>
    ''' <param name="systemSerialNumber">The System Serial Number that you will be using.</param>
    ''' <param name="boardSerialNumber">The Board Serial Number that you will be using.</param>
    ''' <param name="slotNumber">The Slot Number that you will be using.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The board was added to the system. False: Something went wrong, see results for details.</returns>
    ''' <remarks></remarks>
    Public Function AddBoardToExistingSystem(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, _
                                             ByRef boardSerialNumber As String, ByRef slotNumber As String,  ByRef result As String) As Boolean
        Dim slot As String = ""
        Select Case slotNumber
            Case "0"
                slot = "[MotherBoard.boardid]"
            Case "1"
                slot = "[MainCPU.boardid]"
            Case "2"
                slot = "[Slot2.boardid]"
            Case "3"
                slot = "[Slot3.boardid]"
            Case "4"
                slot = "[Slot4.boardid]"
            Case "5"
                slot = "[Slot5.boardid]"
            Case "6"
                slot = "[Slot6.boardid]"
            Case "7"
                slot = "[Slot7.boardid]"
			Case "8"
                slot = "[Slot8.boardid]"
			Case "9"
                slot = "[Slot9.boardid]"
			Case "10"
                slot = "[Slot10.boardid]"
        End Select

		myCmd.CommandText = "SELECT " & slot & " FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader

        If myReader.Read() Then
            If Not myReader.IsDBNull(0) Then
                MsgBox("Please select a slot that has a NULL value.")
                myReader.Close()
                Return False
            End If
            myReader.Close()

            Dim existingRecord As String = ""
            Dim existingSystem As String = ""
            Dim boardRecord As Guid = Nothing
            Dim systemRecord As Guid = Nothing
            Dim transaction As SqlTransaction = Nothing

            Try
                transaction = myConn.BeginTransaction("Add Board To Existing")
                myCmd.Transaction = transaction

                'Check for the board record.
                If GetBoardGUIDBySerialNumber(myCmd, myReader, boardSerialNumber, existingRecord, result) = False Then
                    'Board is not in the database.
                    Dim answer As Integer = MessageBox.Show("Board SNO " & boardSerialNumber & " is not in the database. Would you like to add it at this time?", "Add Board?", MessageBoxButtons.YesNo)
                    If answer = DialogResult.Yes Then
                        If AddBoard(myCmd, myConn, boardSerialNumber,  boardRecord, result, True, "") = False Then
                            MsgBox(result)
                            RollBack(transaction, result)
                            Return False
                        End If
                    Else
                        MsgBox("User decided not to add Board " & boardSerialNumber & ". Program will not commit.")
                        RollBack(transaction, result)
                        Return False
                    End If
                    existingRecord = boardRecord.ToString
                Else
                    'Board is in the database.
                    'Check to see if the board is already part of another system.
                    If GetSystemSerialNumberByBoardGUID(myCmd, myReader, existingRecord, existingSystem, result) = True Then
                        MsgBox("Board " & boardSerialNumber & " is already part of another system: " & existingSystem & ".")
                        RollBack(transaction, result)
                        Return False
                    End If

                    'Check to make sure the board is not in the 'Rework' or 'Shipped' status.
                    Dim status As String = ""
                    If GetBoardCurrentStatus(myCmd, myReader, boardSerialNumber, status, result) = True Then
                        If String.Compare(status, BS_REWORK) = 0 Then
                            MsgBox("Board " & boardSerialNumber & " stauts is 'Rework' and cannot be added to a system until fixed.")
                            RollBack(transaction, result)
                            Return False
                        End If
						If String.Compare(status.Substring(0, 4), BS_SHIPPED) = 0 Then
							MsgBox("Board " & boardSerialNumber & " stauts is 'Shipped' and cannot be added to a system.")
							RollBack(transaction, result)
							Return False
						End If
						If String.Compare(status, SS_SCRAPPED) = 0 Then
							MsgBox("Board " & boardSerialNumber & " stauts is 'Scrapped' and cannot be added to a system.")
							RollBack(transaction, result)
							Return False
						End If
					End If
                End If

                'Grab the system GUID.
                If GetSystemGUID(myCmd, myReader, systemSerialNumber, systemRecord, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

				'Add Board to the system.
				myCmd.CommandText = "UPDATE dbo.System SET " & slot & " = '" & existingRecord & "' WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
				myCmd.ExecuteNonQuery()

                'Add Comment to the system.
                If AddSystemComment(myCmd, systemSerialNumber, "Board " & boardSerialNumber & " was added to Slot " & slotNumber & ".",  systemRecord, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                'Add Comment to the board.
                If AddBoardComment(myCmd, boardSerialNumber, "Board added to System " & systemSerialNumber & " in Slot " & slotNumber & ".",  boardRecord, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                'Update status of the system and boards.
                If UpdateSystemStatus(myCmd, myConn, SS_BOARDS_REGISTERED, systemSerialNumber,  result, False) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                transaction.Commit()
            Catch ex As Exception
                RollBack(transaction, result)
                If Not myReader Is Nothing Then
                    myReader.Close()
                End If
                MsgBox("[UpdateSystemStatus exception] " & ex.Message)
                Return False
            End Try
        End If
        Return True
    End Function

    '-----------------------------------------'
    '                                         '
    '     R E M O V E   F U N C T I O N S     '
    '                                         '
    '-----------------------------------------'

    ''' <summary>
    ''' Removes ONLY the system entry inside the database. This is not reversable.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="systemSerialNumber">The system serial number that we want to delete.</param>
    ''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
    ''' <returns>True: The system was deleted from the database. False: Something did not go as planned, see result for details.</returns>
    ''' <remarks></remarks>
    Public Function RemoveSystem(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String,  ByRef result As String) As Boolean
        Try
            Dim record As Guid = Nothing
            If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
                Return False
            End If

            If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
                Return False
            End If

            UpdateSystemBoards(myCmd, BS_BOARD_CHECKED, systemSerialNumber, "Board was removed from System " & systemSerialNumber & ".",  result)

			myCmd.CommandText = "DELETE FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			myCmd.ExecuteNonQuery()

            myCmd.CommandText = "DELETE FROM dbo.SystemAudit WHERE [dbo.System.Systemid] = '" & record.ToString & "'"
            myCmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
    End Function

	'Public Function RemoveBoard(ByRef myCmd As SqlCommand, ByRef boardSerialNumber As String, ByRef result As String) As Boolean
	'    Try
	'        Dim record As String = ""
	'        If FindBoardSerialNumber(myCmd, myReader, boardSerialNumber, result) = False Then
	'            Return False
	'        End If

	'        If GetBoardGUIDBySerialNumber(myCmd, myReader, boardSerialNumber, record, result) = False Then
	'            Return False
	'        End If

	'        Dim system As String = ""
	'        If GetSystemSerialNumberByBoardGUID(myCmd, myReader, record, system, result) = True Then
	'            result = "This board is part of a system[" & system & "]. Please remove it from the system before you delete it from the database."
	'            Return False
	'        End If

	'        myCmd.CommandText = "DELETE FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
	'        myCmd.ExecuteNonQuery()

	'        myCmd.CommandText = "DELETE FROM dbo.BoardAudit WHERE [dbo.Board.Boardid] = '" & record & "'"
	'        myCmd.ExecuteNonQuery()

	'        Return True
	'    Catch ex As Exception
	'        result = ex.Message
	'        Return False
	'    End Try
	'End Function

	''' <summary>
	''' Removes a definition from a system in the database.
	''' </summary>
	''' <param name="myCmd">The SQL Command that you will be using.</param>
	''' <param name="systemType">The type of system we are adding a definition to.</param>
	''' <param name="boardType">They board type.</param>
	''' <param name="slotNumber">The slot number.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: Removing the definition was successful. False: Something went wrong, see result for details.</returns>
	''' <remarks></remarks>
	Public Function RemoveSystemDefinition(ByRef myCmd As SqlCommand, ByRef systemType As String, ByRef boardType As String, ByRef slotNumber As String, _
                                           ByRef result As String) As Boolean
        Try
            myCmd.CommandText = "DELETE FROM dbo.SystemDefinition WHERE [SystemType.id]='" & systemType & "' and [BoardType.id]='" & boardType & "' and SlotNumber ='" & slotNumber & "'"
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Removes a board to a system that already exists in the database.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="myConn">The SQL Connection that you will be using.</param>
    ''' <param name="myReader">The SQL Data Reader that you will be using.</param>
    ''' <param name="systemSerialNumber">The System Serial Number that you will be using.</param>
    ''' <param name="boardSerialNumber">The Board Serial Number that you will be using.</param>
    ''' <param name="slotNumber">The Slot Number that you will be using.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The board was removed to the system. False: Something went wrong, see results for details.</returns>
    ''' <remarks></remarks>
    Public Function RemoveBoardFromExistingSystem(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, _
                                                  ByRef boardSerialNumber As String, ByRef slotNumber As String,  ByRef result As String) As Boolean
        Dim slot As String = ""
        Select Case slotNumber
            Case "0"
                slot = "[MotherBoard.boardid]"
            Case "1"
                slot = "[MainCPU.boardid]"
            Case "2"
                slot = "[Slot2.boardid]"
            Case "3"
                slot = "[Slot3.boardid]"
            Case "4"
                slot = "[Slot4.boardid]"
            Case "5"
                slot = "[Slot5.boardid]"
            Case "6"
                slot = "[Slot6.boardid]"
            Case "7"
                slot = "[Slot7.boardid]"
			Case "8"
                slot = "[Slot8.boardid]"
			Case "9"
                slot = "[Slot9.boardid]"
			Case "10"
                slot = "[Slot10.boardid]"
        End Select

		myCmd.CommandText = "SELECT " & slot & " FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader

        If myReader.Read() Then
            Dim boardRecord As Guid = Nothing
            Dim systemRecord As Guid = Nothing
            Dim transaction As SqlTransaction = Nothing

            If myReader.IsDBNull(0) Then
                MsgBox("Please select a slot that has a Board Serial Number value.")
                myReader.Close()
                Return False
            Else
                boardRecord = myReader.GetGuid(0)
            End If
            myReader.Close()

            Try
                transaction = myConn.BeginTransaction("Remove Board From Existing")
                myCmd.Transaction = transaction

                'Grab the board Serial Number.
                If GetBoardSerialNumberByGUID(myCmd, myReader, boardRecord.ToString, boardSerialNumber, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

				myCmd.CommandText = "UPDATE dbo.System SET " & slot & " = NULL WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
				myCmd.ExecuteNonQuery()

                'Add Comment to the system.
                If AddSystemComment(myCmd, systemSerialNumber, "Board " & boardSerialNumber & " was removed from Slot " & slotNumber & ".",  systemRecord, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                'Add Comment to the board
                If AddBoardComment(myCmd, boardSerialNumber, "Board was removed from " & systemSerialNumber & " Slot " & slotNumber & ".",  boardRecord, result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                'Update the boards status
                If UpdateBoardStatus(myCmd, BS_BOARD_CHECKED, boardSerialNumber,  result) = False Then
                    MsgBox(result)
                    RollBack(transaction, result)
                    Return False
                End If

                transaction.Commit()
            Catch ex As Exception
                RollBack(transaction, result)
                If Not myReader Is Nothing Then
                    myReader.Close()
                End If
                MsgBox("[RemoveBoardFromExistingSystem exception] " & ex.Message)
                Return False
            End Try
            Return True
        End If
    End Function

    '-----------------------------------------'
    '                                         '
    '     U P D A T E   F U N C T I O N S     '
    '                                         '
    '-----------------------------------------'

    ''' <summary>
    ''' Updates the status of the board that we pass through.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="status">The new status that we are updating to the board.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are working with.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Everything worked out. False: Something went wrong. see result for more details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateBoardStatus(ByRef myCmd As SqlCommand, ByRef status As String, ByRef boardSerialNumber As String,  _
                                      ByRef result As String) As Boolean
        Dim boardStatus As String = ""
        Dim record As Guid = Nothing
        Try
            'Get board status that is passed through.
            If GetBoardStatus(myCmd, myReader, status, boardStatus, result) = False Then
                result = "[UpdateBoardStatus1] " & result
                Return False
            End If

            myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE SerialNumber = '" & boardSerialNumber & "'"
            myCmd.ExecuteNonQuery()

            If AddBoardComment(myCmd, boardSerialNumber, "Status updated to " & status & ".",  record, result) = False Then
                result = "[UpdateBoardStatus1] " & result
                Return False
            End If

            Return True
        Catch ex As Exception
            result = "[UpdateBoardStatus exception] " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the status of the system that we pass through.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="status">The new status that we are updating to the system.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Everything worked out. False: Something went wrong. see result for more details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateSystemStatus(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef status As String, ByRef SystemSerialNumber As String,  _
                                      ByRef result As String, ByRef trans As Boolean) As Boolean
        Dim systemStatus As String = ""
        Dim boardStatus As String = ""
        Dim record As Guid = Nothing
        Dim transaction As SqlTransaction = Nothing

        Try
            'Get system status that is passed through.
            If GetSystemStatus(myCmd, myReader, status, systemStatus, result) = False Then
                result = "[UpdateSystemStatus1] " & result
                Return False
            End If

			If trans = True Then
				transaction = myConn.BeginTransaction("Update system status")
				myCmd.Transaction = transaction
			End If

			If String.Compare(status, SS_SET_PARAMETERS) = 0 Then
                If GetBoardStatus(myCmd, myReader, BS_NETWORK_REGISTERED, boardStatus, result) = False Then
                    RollBack(transaction, result)
                    Return False
                End If
            ElseIf String.Compare(status, SS_BOARDS_REGISTERED) = 0 Then
                If GetBoardStatus(myCmd, myReader, BS_BOARD_REGISTERED, boardStatus, result) = False Then
                    RollBack(transaction, result)
                    Return False
                End If
            Else
                If GetBoardStatus(myCmd, myReader, status, boardStatus, result) = False Then
                    RollBack(transaction, result)
                    Return False
                End If
            End If

            '---------------------------'
            '   M O T H E R B O A R D   '
            '---------------------------'

            'Grab the motherboard id associated with the passed in serial number.
            If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, SystemSerialNumber, "Motherboard", record, result) = False Then
                RollBack(transaction, result)
                result = "[UpdateSystemStatus2] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & "Board in: " & status & " due to System Status update.',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

            '-------------------------'
            '   M A S T E R   C P U   '
            '-------------------------'

            'Grab the Main CPU id associated with the passed in serial number.
            If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, SystemSerialNumber, "MainCPU", record, result) = False Then
                RollBack(transaction, result)
                result = "[UpdateSystemStatus3] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & "Board in: " & status & " due to System Status update.',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

			'---------------------'
			'   S L O T   2 - 10  '
			'---------------------'

			For i = 2 To 10
				'Grab the board id for the slot we are dealing with using 'i' to cycle through each slot number.
				If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, SystemSerialNumber, "Slot" & i, record, result) = False Then
					RollBack(transaction, result)
					result = "[UpdateSystemStatus4] " & result
					Return False
				End If

				'Check to see if our record got an id back or if it is empty.
				If record <> Guid.Empty Then
					'Update our board status.
					myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
					myCmd.ExecuteNonQuery()

					'Insert the comment.
					myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
							& record.ToString() & "','" & "Board in: " & status & " due to System Status update.',GETDATE(),'" & username & "')"
					myCmd.ExecuteNonQuery()
				End If
			Next i

			myCmd.CommandText = "UPDATE dbo.System SET LastUpdate=GETDATE(), [dbo.SystemStatus.id]='" & systemStatus & "' WHERE SerialNumber = '" & SystemSerialNumber & "' and
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			myCmd.ExecuteNonQuery()

			If trans = True Then
                transaction.Commit()
            End If
            Return True
        Catch ex As Exception
            RollBack(transaction, result)
            result = "[UpdateSystemStatus exception] " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the status of the boards assocciated with the system serial number that gets passed through.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="status">The board status that we want to change to.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="comment">The comment that we want to attach to the boards.</param>
    ''' <param name="result">OUTPUT: Message regarding if anything does not work.</param>
    ''' <returns>True: Everything worked out. False: Something did not work, see result message for details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateSystemBoards(ByRef myCmd As SqlCommand, ByRef status As String, ByRef systemSerialNumber As String, ByRef comment As String, _
                                        ByRef result As String) As Boolean
        Dim record As Guid = Nothing
        Dim boardStatus As String = ""
        Try
            'Get board status that is passed through.
            If GetBoardStatus(myCmd, myReader, status, boardStatus, result) = False Then
                result = "[UpdateSystemBoards1] " & result
                Return False
            End If

            '---------------------------'
            '   M O T H E R B O A R D   '
            '---------------------------'

            'Grab the motherboard id associated with the passed in serial number.
            If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNumber, "Motherboard", record, result) = False Then
                result = "[UpdateSystemBoards2] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

            '-------------------------'
            '   M A S T E R   C P U   '
            '-------------------------'

            'Grab the Main CPU id associated with the passed in serial number.
            If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNumber, "MainCPU", record, result) = False Then
                result = "[UpdateSystemBoards3] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

            '---------------------'
            '   S L O T   2 - 10  '
            '---------------------'

            For i = 2 To 10
                'Grab the board id for the slot we are dealing with using 'i' to cycle through each slot number.
                If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNumber, "Slot" & i, record, result) = False Then
                    result = "[UpdateSystemBoards4] " & result
                    Return False
                End If

                'Check to see if our record got an id back or if it is empty.
                If record <> Guid.Empty Then
                    'Update our board status.
                    myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                    myCmd.ExecuteNonQuery()

                    'Insert the comment corresponding to the board serial number into the BoardAudit table form this user.
                    myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                            & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
                    myCmd.ExecuteNonQuery()
                End If
            Next i
            Return True
        Catch ex As Exception
            result = "[UpdateSystemBoards exception] " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the Version of the board associated with the passed in serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="board">The board that we are working with.</param>
    ''' <param name="version">The version number we want to update into the database.</param>
    ''' <param name="result">OUTPUT: Message regarding if anything does not work.</param>
    ''' <returns>True: Everything worked out. False: Something did not work, see result message for details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateBoardSoftwareVersionBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef board As String, _
                                                           ByRef version As String, ByRef result As String) As Boolean
        Dim record As Guid = Nothing

        'Grab the board id associated with the passed in serial number.
        If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNumber, board, record, result) = False Then
            result = "[UpdateBoardVersionBySystemSerialNumber1] " & result
            Return False
        End If

        If record <> Guid.Empty Then
            'Update the version.
            myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), SoftwareVersion='" & version & "' WHERE boardid = '" & record.ToString & "'"
            myCmd.ExecuteNonQuery()
        End If
        Return True
    End Function

    ''' <summary>
    ''' Updates the Bootloader Version of the board associated with the passed in serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="board">The board that we are working with.</param>
    ''' <param name="version">The version number we want to update into the database.</param>
    ''' <param name="result">OUTPUT: Message regarding if anything does not work.</param>
    ''' <returns>True: Everything worked out. False: Something did not work, see result message for details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateBoardBootLoaderVersionBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef board As String, _
                                                                     ByRef version As String, ByRef result As String) As Boolean
        Dim record As Guid = Nothing

        'Grab the board id associated with the passed in serial number.
        If GetBoardGUIDBySystemSerialNumber(myCmd, myReader, systemSerialNumber, board, record, result) = False Then
            result = "[UpdateBoardVersionBySystemSerialNumber1] " & result
            Return False
        End If

        If record <> Guid.Empty Then
            'Update the version.
            myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), BootloaderVersion='" & version & "' WHERE boardid = '" & record.ToString & "'"
            myCmd.ExecuteNonQuery()
        End If
        Return True
    End Function

    ''' <summary>
    ''' Updates the next MAC Address in the database either by bumping it up by one or whatever is passed.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="MACAddress">The MAC Address that we are working with.</param>
    ''' <param name="bump">BOOLEAN: lets us know if we are going to increase the MAC Address by one or not.</param>
    ''' <param name="result">Error message if something does not go according to plan.</param>
    ''' <returns>True: MAC Address was updated. False: Something went wrong while trying to update the MAC Address in the database.</returns>
    ''' <remarks></remarks>
    Public Function UpdateNextMACAddress(ByRef myCmd As SqlCommand, ByRef MACAddress As String, ByRef bump As Boolean, ByRef result As String) As Boolean
        Try
            If bump = True Then
                Dim TempMACAddr As String = MACAddress
                Dim HighPart As Integer = Convert.ToInt32(TempMACAddr.Substring(0, 1), 16)
                Dim LowPart As Integer = Convert.ToInt32(TempMACAddr.Substring(2), 16)

                LowPart += 1
                If LowPart >= 256 Then
                    LowPart = 0
                    HighPart += 1
                End If

                MACAddress = HighPart.ToString("x") + "-" + LowPart.ToString("x2")
            End If

            myCmd.CommandText = "UPDATE dbo.SystemParameters SET valuestring = '" & MACAddress & "' WHERE id = 'MACADDR'"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = "[UpdateNextMACAddress exception] " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the hardware version of the passed in board in the database.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="boardName">The name of the board that we are working up.</param>
    ''' <param name="version">The new version that we are updating the hardware version board to.</param>
    ''' <param name="result">OUTPUT: Message regarding if anything does not work.</param>
    ''' <returns>True: Everything worked out. False: Something did not work, see result message for details.</returns>
    ''' <remarks></remarks>
    Public Function UpdateHardwareVersion(ByRef myCmd As SqlCommand, ByRef boardName As String, ByRef version As String, ByRef result As String) As Boolean
        Try
            myCmd.CommandText = "UPDATE dbo.BoardType SET HardwareVersion='" & version & "' WHERE name = '" & boardName & "'"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = ex.Message()
            Return False
        End Try
    End Function

    '-------------------------------------'
    '                                     '
    '     F I N D   F U N C T I O N S     '
    '                                     '
    '-------------------------------------'

    ''' <summary>
    ''' Checks to see if the passed system serial number exists in the database. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader"> The SQL data reader that we will be using.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function FindSystemSerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, _
                                           ByRef result As String) As Boolean
		'Check to see if the record with the passed serial number exists or not.
		myCmd.CommandText = "IF EXISTS(SELECT systemid FROM system where [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') 
AND SerialNumber = '" & systemSerialNumber & "') SELECT 1 ELSE SELECT 0"
		myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.GetInt32(0) = 0 Then
                result = "[FindSystemSerialNumber1]  System serial '" & systemSerialNumber & "' number does not exist inside the database."
                myReader.Close()
                Return False
            End If
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Checks to see if the passed board serial number exists in the database. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader"> The SQL data reader that we will be using.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are checking for.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function FindBoardSerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                          ByRef result As String) As Boolean
        'Check to see if the record with the passed serial number exists or not.
        myCmd.CommandText = "IF EXISTS(SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "') SELECT 1 ELSE SELECT 0"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.GetInt32(0) = 0 Then
                result = "[FindBoardSerialNumber1]  board serial number '" & boardSerialNumber & "'does not exist."
                myReader.Close()
                Return False
            End If
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Checks to see if the passed MAC Address exists in the database. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader"> The SQL data reader that we will be using.</param>
    ''' <param name="MACAddress">The MAC Address that we are checking for.</param>
    ''' <param name="systemSerialNumber">OUTPUT: The System serial number that is associated with the MAC Address.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns system serial number. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function FindMACAddress(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef MACAddress As String, ByRef systemSerialNumber As String, _
                                   ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE MACAddress = '" & MACAddress & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[FindMACAddress1] MAC Address '" & MACAddress & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindMACAddress2] MAC Address '" & MACAddress & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Checks to see if the passed CPU ID exists in the database. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">The SQL data reader that we will be using.</param>
    ''' <param name="CPUid">The CPU ID that we are checking for.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns system serial number. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function FindCPUid(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef CPUid As String, ByRef result As String) As Boolean
        'Check to see if the record with the passed serial number exists or not.
        myCmd.CommandText = "IF EXISTS(SELECT boardid FROM dbo.Board WHERE CPUID = '" & CPUid & "') SELECT 1 ELSE SELECT 0"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.GetInt32(0) = 0 Then
                result = "[FindCPUid1] CPU ID '" & CPUid & "' is NULL."
                myReader.Close()
                Return False
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindCPUid2] CPU ID '" & CPUid & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	''' <summary>
	''' Checks to see if the passed CPU ID exists in the database. Closes the passed reader before exit.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">The SQL data reader that we will be using.</param>
	''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
	''' <returns>True: The record exists, returns system serial number. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function FindVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef SerialNumber As String, ByRef Card As String, ByRef result As String, ByRef obj As JSON_InfoResult) As Boolean
        'Check to see if the record with the passed serial number exists or not.
        Select Case Card
            Case "CPU"
                myCmd.CommandText = "IF EXISTS(SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & SerialNumber & "') SELECT * FROM dbo.Board WHERE SerialNumber = '" & SerialNumber & "' ELSE SELECT 0"
                myReader = myCmd.ExecuteReader()
                If myReader.Read() Then
                    If myReader.FieldCount <> 1 Then
                        Dim tempSW As String = ""
                        Dim tempBL As String = ""

                        If Not IsDBNull(myReader("SoftwareVersion")) Then
                            tempSW = myReader("SoftwareVersion")
                        End If

                        If Not IsDBNull(myReader("BootloaderVersion")) Then
                            tempBL = myReader("BootloaderVersion")
                        End If

                        MsgBox("BL: " & tempBL & " -> " & obj.blversion & vbCrLf & _
                               "CPU: " & tempSW & " -> " & obj.version)
                        myReader.Close()
                    End If
                Else
                    'If nothing is returned then it does not exist.
                    result = "[FindVersion1] CPU ID '" & SerialNumber & "' does not exist."
                    myReader.Close()
                    Return False
                End If

            Case "PWRA2D"
                myCmd.CommandText = "IF EXISTS(SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & SerialNumber & "') SELECT * FROM dbo.Board WHERE SerialNumber = '" & SerialNumber & "' ELSE SELECT 0"
                myReader = myCmd.ExecuteReader()
                If myReader.Read() Then
                    If myReader.FieldCount <> 1 Then
                        Dim tempSW As String = ""

                        If Not IsDBNull(myReader("SoftwareVersion")) Then
                            tempSW = myReader("SoftwareVersion")
                        End If

                        MsgBox("IO: " & tempSW & " -> " & obj.ioversion)
                        myReader.Close()
                    End If
                Else
                    'If nothing is returned then it does not exist.
                    result = "[FindVersion2] PWRA2D ID '" & SerialNumber & "' does not exist."
                    myReader.Close()
                    Return False
                End If

            Case "DANFOSS"

            Case "ETS"

        End Select

        Return True
    End Function

    ''' <summary>
    ''' Checks to see if we already have a date inside of our data table. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">The SQL data reader that we are going to be using.</param>
    ''' <param name="dateType">The date that we are going to be checking for.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
    ''' <param name="override">OUTPUT: Boolean that will give us the option to override this date.</param>
    ''' <param name="result">OUTPUT: Error result that helps us with identifying the problem.</param>
    ''' <returns>True: There is no date inside the dataTable. False: Either the serial number does not exist or there is already a date there, see result.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function FindDate(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef dateType As String, ByRef systemSerialNumber As String, _
                             ByRef override As Boolean, ByVal result As String) As Boolean
        myCmd.CommandText = "SELECT " & dateType & " FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.IsDBNull(0) Then
                'If there is nothing then we are good to continue.
            Else
                'Exit from this function and switch override to true to allow the user to choose if they want to override or not.
                result = "[FindDate1] System serial number '" & systemSerialNumber & "' already has a date inside the database."
                override = True
                myReader.Close()
                Return False
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindDate2] System serial number '" & systemSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Looks for the passed in system name inside the database.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="systemName">The name of the system that we are looking for.</param>
    ''' <returns>True: We found the record. False: We did not find the record.</returns>
    ''' <remarks></remarks>
    Public Function FindSystemName(ByRef myCmd As SqlCommand, ByRef systemName As String) As Boolean
        myCmd.CommandText = "SELECT name FROM dbo.SystemType WHERE name = '" & systemName & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            myReader.Close()
            Return True
        Else
            myReader.Close()
            Return False
        End If
    End Function

    ''' <summary>
    ''' Looks for the definition with the passed in parameters.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using.</param>
    ''' <param name="systemType">The system type that we are looking for.</param>
    ''' <param name="boardType">The board type that we are looking for.</param>
    ''' <param name="slotNumber">The slot number that we are looking for.</param>
    ''' <returns>True: We found the record. False: We did not find the record.</returns>
    ''' <remarks></remarks>
    Public Function FindSystemDefinition(ByRef myCmd As SqlCommand, ByRef systemType As String, ByRef boardType As String, ByRef slotNumber As String) As Boolean
        myCmd.CommandText = "SELECT id FROM dbo.SystemDefinition WHERE ([SystemType.id] = '" & systemType & "' AND  [BoardType.id] = '" & boardType & "' AND SlotNumber = '" & slotNumber & "')"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            myReader.Close()
            Return True
        Else
            myReader.Close()
            Return False
        End If
    End Function

    '-----------------------------------'
    '                                   '
    '     G E T   F U N C T I O N S     '
    '                                   '
    '-----------------------------------'

    '------------'
    '   SYSTEM   ' 
    '------------'

    ''' <summary>
    ''' Gets the System GUID of the passed in serial number. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">The SQL data reader that we will be using.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
    ''' <param name="record">OUTPUT: GUID variable that will hold the returned GUID.</param>
    ''' <param name="result">OUTPUT: Error report to show us what went wrong.</param>
    ''' <returns>True: System exists and record is returned. False: Either the System is NULL or does not exist, see results.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetSystemGUID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, ByRef record As Guid, _
                                  ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT systemid FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetSystemGUID1] System serial number '" & systemSerialNumber & "' is NULL."
                myReader.Close()
                Return False
            Else
                record = myReader.GetGuid(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetSystemGUID2] System serial number '" & systemSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the system status from the SQL reader that is passed throguh. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="status">Status that we are looking for.</param>
    ''' <param name="systemStatus">OUTPUT: String that will hold the GUID of the status.</param>
    ''' <param name="result">OUTPUT: Error message that will give us some insight as to what went wrong.</param>
    ''' <returns>True: Everything worked out, returns our systemStatus. False: Somethign went wrong, see result for insight.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetSystemStatus(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef status As String, ByRef systemStatus As String, _
                                    ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT id FROM dbo.SystemStatus WHERE name = '" & status & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetSystemStatus1] System status name '" & status & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemStatus = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetSystemStatus2] System status name '" & status & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the system type using the name of the system that is passed in.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="name">The name of the system type that we are working with.</param>
    ''' <param name="systemType">OUTPUT: The system type that is returned to us that is found in our database.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns the system type. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetSystemType(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef name As String, ByRef systemType As String, _
                                  ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT id FROM dbo.SystemType WHERE name = '" & name & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetSystemType1] System Type '" & name & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemType = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetSystemType2] System Type '" & name & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the System Serial Number that is associated with the passed board GUID
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardGUID">The board GUID that we are working with.</param>
    ''' <param name="systemSerialNumber">OUTPUT: The system serial number that is associated with the passed GUID.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSystemSerialNumberByBoardGUID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardGUID As String, _
                                                     ByRef systemSerialNumber As String, ByRef result As String) As Boolean
		'Check to see if the record with the passed serial number exists or not.
		myCmd.CommandText = "SELECT SerialNumber FROM dbo.System WHERE [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') and (
[MotherBoard.boardid] = '" & boardGUID & "' OR [MainCPU.boardid] = '" & boardGUID &
"' OR [Slot2.boardid] = '" & boardGUID & "' OR [Slot3.boardid] = '" & boardGUID & "' OR [Slot4.boardid] = '" & boardGUID &
"' OR [Slot5.boardid] = '" & boardGUID & "' OR [Slot6.boardid] = '" & boardGUID & "' OR [Slot7.boardid] = '" & boardGUID & "')"
		myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.IsDBNull(0) Then
                result = "[FindSystemSerialNumberByBoardGUID1] Board GUID '" & boardGUID & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindSystemSerialNumberByBoardGUID2] Board GUID '" & boardGUID & "' does not exist."
            myReader.Close()
            Return False
        End If

        myReader.Close()
        Return True
    End Function

	''' <summary>
	''' Gets the parameter file name associated with the passed system serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemID">The system serial number that we are working with.</param>
	''' <param name="record">OUTPUT: The ID associated with the board.</param>
	''' <param name="parameterFile">OUTPUT: The parameter file name.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the parameter file name. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetParameterFileNameByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
										 ByRef record As Guid, ByRef parameterFile As String, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT ParameterFile FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				parameterFile = ""
			Else
				'If not, set our string to whatever was passed back to us.
				parameterFile = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetParameterFileName1] ParameterFile/Systemid '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	''' <summary>
	''' Get the system version of the passed system serail number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemID">The system serial number that we are working with.</param>
	''' <param name="record">OUTPUT: The ID associated with the board.</param>
	''' <param name="version">OUTPUT: The version of the system.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the version. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetSystemVersionByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
									 ByRef record As Guid, ByRef version As String, ByRef result As String) As Boolean
		Dim CPUguid As String = ""

		'First grab the GUID of the CPU Serial Board associated with the system.
		myCmd.CommandText = "SELECT [MainCPU.boardid] FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[GetSystemVersion1] CPU Board ID number for '" & systemID & "' is NULL."
				myReader.Close()
				Return False
			Else
				CPUguid = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemVersion2] System serial number '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the Version for the board with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT SoftwareVersion FROM dbo.Board WHERE boardid = '" & CPUguid & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				version = ""
				myReader.Close()
				Return False
			Else
				version = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemVersion3] CPU Version for '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	''' <summary>
	''' Gets the Current status of the System.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="record">OUTPUT: The ID associated with the board.</param>
	''' <param name="stauts">OUTPUT: The current status of the system</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the status. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetSystemCurrentStatus(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String,
										   ByRef record As Guid, ByRef stauts As String, ByRef result As String) As Boolean
		Dim systemStatusGUID As String = ""

		'First grab the GUID of the CPU Serial Board associated with the system.
		myCmd.CommandText = "SELECT [dbo.SystemStatus.id] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' AND 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[GetSystemStatusInfo1] System Status for '" & systemSerialNumber & "' is NULL."
				myReader.Close()
				Return False
			Else
				systemStatusGUID = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemStatusInfo2] System serial number '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the Version for the board with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT name FROM dbo.SystemStatus WHERE id = '" & systemStatusGUID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				stauts = ""
				myReader.Close()
				Return False
			Else
				stauts = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemStatusInfo3] System Status does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	Public Function GetSystemCurrentStatusByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
										   ByRef record As Guid, ByRef stauts As String, ByRef result As String) As Boolean
		Dim systemStatusGUID As String = ""

		'First grab the GUID of the CPU Serial Board associated with the system.
		myCmd.CommandText = "SELECT [dbo.SystemStatus.id] FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[GetSystemStatusInfo1] System Status for '" & systemID & "' is NULL."
				myReader.Close()
				Return False
			Else
				systemStatusGUID = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemStatusInfo2] System serial number '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the Version for the board with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT name FROM dbo.SystemStatus WHERE id = '" & systemStatusGUID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				stauts = ""
				myReader.Close()
				Return False
			Else
				stauts = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemStatusInfo3] System Status does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	''' <summary>
	''' Gets the Current type of the System.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="type">OUTPUT: The current status of the system</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the status. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetSystemCurrentType(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String,
										 ByRef type As String, ByRef result As String) As Boolean
		Dim systemTypeGUID As String = ""

		'First grab the GUID of the System Type GUID associated with the system.
		myCmd.CommandText = "SELECT [dbo.SystemType.id] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[GetSystemCurrentType1] System Type for '" & systemSerialNumber & "' is NULL."
				myReader.Close()
				Return False
			Else
				systemTypeGUID = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemCurrentType2] System serial number '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the System type for the system with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT name FROM dbo.SystemType WHERE id = '" & systemTypeGUID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				type = ""
				myReader.Close()
				Return False
			Else
				type = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemCurrentType3] System Type does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	Public Function GetSystemCurrentTypeByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
										 ByRef type As String, ByRef result As String) As Boolean
		Dim systemTypeGUID As String = ""

		'First grab the GUID of the System Type GUID associated with the system.
		myCmd.CommandText = "SELECT [dbo.SystemType.id] FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[GetSystemCurrentType1] System Type for '" & systemID & "' is NULL."
				myReader.Close()
				Return False
			Else
				systemTypeGUID = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemCurrentType2] System serial number '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the System type for the system with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT name FROM dbo.SystemType WHERE id = '" & systemTypeGUID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				type = ""
				myReader.Close()
				Return False
			Else
				type = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetSystemCurrentType3] System Type does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	''' <summary>
	''' Gets a passed date field associated with the passed system serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="dateFeild">The Date field that we are working with.</param>
	''' <param name="dateInformation">OUTPUT: The date for the date field.</param>
	''' <param name="record">OUTPUT: The ID associated with the board.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the date associated with the date field. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetSystemDate(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String,
							ByRef dateFeild As String, ByRef dateInformation As DateTime, ByRef record As Guid, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT " & dateFeild & " FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				dateInformation = Nothing
			Else
				'If not, set our information to whatever was passed back to us.
				dateInformation = myReader.GetDateTime(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetDate1] Date '" & dateFeild & "'/SerialNumber '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	Public Function GetSystemDateByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
							ByRef dateFeild As String, ByRef dateInformation As DateTime, ByRef record As Guid, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT " & dateFeild & " FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				dateInformation = Nothing
			Else
				'If not, set our information to whatever was passed back to us.
				dateInformation = myReader.GetDateTime(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetDate1] Date '" & dateFeild & "'/systemid '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	''' <summary>
	''' Gets all of the system audit records associated with the passed system serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="RichText">The listbox that we want to put all of the information into.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the date associated with the date field. False: The record does not exists, see result for details.</returns>
	''' <remarks></remarks>
	Public Function GetSystemAudit(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, ByRef RichText As RichTextBox, ByRef result As String) As Boolean
		Dim record As Guid = Nothing

		'First we have to get the System GUID that we are working with.
		If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
			Return False
		End If

		'Next we grab the information we want form the Audit table.
		myCmd.CommandText = "SELECT LastUpdate, [User], Comment FROM dbo.SystemAudit WHERE [dbo.System.systemid] = '" & record.ToString() & "' ORDER BY LastUpdate DESC"
		myReader = myCmd.ExecuteReader()

		Do While myReader.HasRows

			Do While myReader.Read()
				RichText.Text = RichText.Text & myReader.GetDateTime(0).ToString & " | " & myReader.GetString(1) & vbNewLine
				RichText.Text = RichText.Text & myReader.GetString(2) & vbNewLine
				RichText.Text = RichText.Text & vbNewLine
			Loop
			myReader.NextResult()
		Loop

		myReader.Close()
		Return True
	End Function

	Public Function GetSystemAuditByID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String, ByRef RichText As RichTextBox, ByRef result As String) As Boolean
		Dim record As Guid = Nothing

		'Next we grab the information we want form the Audit table.
		myCmd.CommandText = "SELECT LastUpdate, [User], Comment FROM dbo.SystemAudit WHERE [dbo.System.systemid] = '" & systemID & "' ORDER BY LastUpdate DESC"
		myReader = myCmd.ExecuteReader()

		Do While myReader.HasRows

			Do While myReader.Read()
				RichText.Text = RichText.Text & myReader.GetDateTime(0).ToString & " | " & myReader.GetString(1) & vbNewLine
				RichText.Text = RichText.Text & myReader.GetString(2) & vbNewLine
				RichText.Text = RichText.Text & vbNewLine
			Loop
			myReader.NextResult()
		Loop

		myReader.Close()
		Return True
	End Function

	''' <summary>
	''' Gets all of the boards that are associated with the passed in system serial number and puts them in the passed in listbox.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="listbox">The listbos that we want to put all of the information into.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The system exists and all boards were added to the listbox. False: The system does not exist or there was an issue adding items to the listbox. see results.</returns>
	''' <remarks></remarks>
	Public Function GetSystemBoards(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, ByRef listbox As ListBox, ByRef result As String) As Boolean
        Try
			myCmd.CommandText = "SELECT s.SerialNumber, mb.SerialNumber, s1.SerialNumber, s2.SerialNumber, s3.SerialNumber, s4.SerialNumber, s5.SerialNumber, s6.SerialNumber, s7.SerialNumber FROM dbo.System s " &
								"LEFT JOIN dbo.board mb ON s.[MotherBoard.boardid] = mb.boardid LEFT JOIN dbo.board s1 ON s.[MainCPU.boardid] = s1.boardid LEFT JOIN dbo.board s2 ON s.[Slot2.boardid] = s2.boardid " &
								"LEFT JOIN dbo.board s3 ON s.[Slot3.boardid] = s3.boardid LEFT JOIN dbo.board s4 ON s.[Slot4.boardid] = s4.boardid LEFT JOIN dbo.board s5 ON s.[Slot5.boardid] = s5.boardid " &
								"LEFT JOIN dbo.board s6 ON s.[Slot6.boardid] = s6.boardid LEFT JOIN dbo.board s7 ON s.[Slot7.boardid] = s7.boardid WHERE s.SerialNumber = '" & systemSerialNumber & "' and 
								[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			myReader = myCmd.ExecuteReader()
            Do While myReader.HasRows

                Do While myReader.Read()
                    listbox.Items.Add("Serial Number: " & myReader.GetString(0))
                    If myReader.IsDBNull(1) Then
                        listbox.Items.Add("Slot 0: NULL")
                    Else
                        listbox.Items.Add("Slot 0: " & myReader.GetString(1))
                    End If
                    If myReader.IsDBNull(2) Then
                        listbox.Items.Add("Slot 1: NULL")
                    Else
                        listbox.Items.Add("Slot 1: " & myReader.GetString(2))
                    End If
                    If myReader.IsDBNull(3) Then
                        listbox.Items.Add("Slot 2: NULL")
                    Else
                        listbox.Items.Add("Slot 2: " & myReader.GetString(3))
                    End If
                    If myReader.IsDBNull(4) Then
                        listbox.Items.Add("Slot 3: NULL")
                    Else
                        listbox.Items.Add("Slot 3: " & myReader.GetString(4))
                    End If
                    If myReader.IsDBNull(5) Then
                        listbox.Items.Add("Slot 4: NULL")
                    Else
                        listbox.Items.Add("Slot 4: " & myReader.GetString(5))
                    End If
                    If myReader.IsDBNull(6) Then
                        listbox.Items.Add("Slot 5: NULL")
                    Else
                        listbox.Items.Add("Slot 5: " & myReader.GetString(6))
                    End If
                    If myReader.IsDBNull(7) Then
                        listbox.Items.Add("Slot 6: NULL")
                    Else
                        listbox.Items.Add("Slot 6: " & myReader.GetString(7))
                    End If
                    If myReader.IsDBNull(8) Then
                        listbox.Items.Add("Slot 7: NULL")
                    Else
                        listbox.Items.Add("Slot 7: " & myReader.GetString(8))
                    End If
                Loop
                myReader.NextResult()
            Loop
            myReader.Close()
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try
        Return True
    End Function

    '-----------'
    '   BOARD   '
    '-----------'

    ''' <summary>
    ''' Gets the Slot Number where the passed in board GUID is located inside the system.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="myReader">The SQL data reader that we will be using.</param>
    ''' <param name="boardGUID">The board GUID that we are working with.</param>
    ''' <param name="slotNumber">OUTPUT: The slot location where our board is located.</param>
    ''' <param name="result">OUTPUT: Error details when something does not work right.</param>
    ''' <returns>True: The board was found, returns the slot locatioin. False: The board was not found, see result for details.</returns>
    ''' <remarks></remarks>
    Public Function GetBoardSlotNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardGUID As String, _
                                                      ByRef slotNumber As String, ByRef result As String) As Boolean
        Dim slots As String() = {"MotherBoard.boardid", "MainCPU.boardid", "Slot2.boardid", "Slot3.boardid", "Slot4.boardid" _
                                , "Slot5.boardid", "Slot6.boardid", "Slot7.boardid", "Slot8.boardid", "Slot9.boardid", "Slot10.boardid"}

        For Each slot In slots
			'Check to see if the record with the passed serial number exists or not.
			myCmd.CommandText = "SELECT SerialNumber FROM dbo.System WHERE [" & slot & "] = '" & boardGUID & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') "
			myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                If myReader.IsDBNull(0) Then
                    myReader.Close()
                Else
                    slotNumber = slot
                    myReader.Close()
                    Return True
                End If
            End If
            myReader.Close()
        Next

        'If nothing is returned then it does not exist.
        result = "[GetBoardSlotNumber1] Board GUID '" & boardGUID & "' does not exist."
        myReader.Close()
        Return False
    End Function

    ''' <summary>
    ''' Gets the CPU Serial Number using the passed in System serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
    ''' <param name="CPUSerialNumber">OUTPUT: The CPU Board Serial Number that is associated with the system serial number.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns the CPU Serial Number. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetCPUSerialNumberBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, _
                                                           ByRef CPUSerialNumber As String, ByRef result As String) As Boolean
        Dim CPUguid As String = ""

		'First grab the GUID of the CPU Serial Board associated with the system.
		myCmd.CommandText = "SELECT [MainCPU.boardid] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetCPUSerialNumberBySystemSerialNumber1] CPU Board ID number is NULL."
                myReader.Close()
                Return False
            Else
                CPUguid = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetCPUSerialNumberBySystemSerialNumber2] System serial number '" & systemSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Second grab the SerialNumber for the board with the GIUD we got from the first step.
        myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE boardid = '" & CPUguid & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetCPUSerialNumberBySystemSerialNumber3] CPU serial number is NULL."
                myReader.Close()
                Return False
            Else
                CPUSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetCPUSerialNumberBySystemSerialNumber4] CPU GUID '" & CPUguid & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

	''' <summary>
	''' Gets the CPU Serial Number using the passed in System serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
	''' <param name="PWRA2DSerialNumber">OUTPUT: The CPU Board Serial Number that is associated with the system serial number.</param>
	''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
	''' <returns>True: The record exists, returns the CPU Serial Number. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetPWRA2DSerialNumberBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, _
                                                           ByRef PWRA2DSerialNumber As String, ByRef result As String) As Boolean
        Dim PWRA2Dguid As String = ""

		'First grab the GUID of the CPU Serial Board associated with the system.
		myCmd.CommandText = "SELECT [Slot2.boardid] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetPWRA2DSerialNumberBySystemSerialNumber1] PWRA2D Board ID number is NULL."
                myReader.Close()
                Return False
            Else
                PWRA2Dguid = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetPWRA2DSerialNumberBySystemSerialNumber2] System serial number '" & systemSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Second grab the SerialNumber for the board with the GIUD we got from the first step.
        myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE boardid = '" & PWRA2Dguid & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetPWRA2DSerialNumberBySystemSerialNumber3] PWRA2D serial number is NULL."
                myReader.Close()
                Return False
            Else
                PWRA2DSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetPWRA2DSerialNumberBySystemSerialNumber4] PWRA2D GUID '" & PWRA2Dguid & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the board status from the SQL reader that is passed through. Closes the passed reader before exit.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="status">Status that we are looking for.</param>
    ''' <param name="boardStatus">OUTPUT: String that will hold the GUID of the status.</param>
    ''' <param name="result">OUTPUT: Error message that will give us some insight as to what went wrong.</param>
    ''' <returns>True: Everything worked out, returns our boardStatus. False: Somethign went wrong, see result for insight.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardStatus(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef status As String, ByRef boardStatus As String, _
                                   ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT id FROM dbo.boardStatus WHERE name = '" & status & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetBoardStatus1] Board status name '" & status & "' is NULL."
                myReader.Close()
                Return False
            Else
                boardStatus = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardStatus2] Board status name '" & status & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Grabs the prefix of the serial number and then determines which board type it belongs to.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using to make this action.</param>
    ''' <param name="serialNumber">The serial number of the board</param>
    ''' <param name="boardType">OUTPUT: The type of board that is being registered.</param>
    ''' <param name="boardPrefix">OUTPUT: The prefix of the board that is passed in.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Prefix was found and matches, returns the board type. False: Prefix was not found, see error message for details.</returns>
    ''' <remarks></remarks>
    Public Function GetBoardTypeByPrefix(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef boardType As String, ByRef boardPrefix As String, ByRef result As String) As Boolean
        'Create our prefix string. Prefix is everything before the '-' in the serial number.
        Dim prefix As String = serialNumber.Substring(0, serialNumber.IndexOf("-"))
        boardPrefix = prefix

        'Check database for prefix first
        If GetBoardTypeID(myCmd, prefix, boardType, result) = False Then
            result = "Prefix for board: " & serialNumber & " Does not exist."
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Searches the database for the ID related to the prefix that is passed through.
    ''' </summary>
    ''' <param name="myCmd">The SQL Command that you will be using to make this action.</param>
    ''' <param name="prefix">The prefix that we are searching for.</param>
    ''' <param name="boardType">OUTPUT: The type of board that is being registered.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: Prefix was found, returned boardType ID. False: Something went wrong, see result message for information.</returns>
    ''' <remarks></remarks>
    Public Function GetBoardTypeID(ByRef myCmd As SqlCommand, ByRef prefix As String, ByRef boardType As String, ByRef result As String) As Boolean
        Try
            'Get the GUID from the newly inserted record.
            myCmd.CommandText = "SELECT id FROM dbo.BoardType WHERE BaseSerialNo = '" & prefix & "'"
            myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "[GetBoardTypeID1] Board perfix '" & prefix & "' is NULL."
                    myReader.Close()
                    Return False
                Else
                    boardType = myReader.GetGuid(0).ToString
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "[GetBoardTypeID2] Board prefix '" & prefix & "' does not exist."
                myReader.Close()
                Return False
            End If
            myReader.Close()
            Return True
        Catch ex As Exception
            result = ex.Message
            myReader.Close()
            Return False
        End Try
    End Function

	''' <summary>
	''' Gets all of the board audit records associated with teh passed board serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="boardSerialNumber">The board serial number that we are working with.</param>
	''' <param name="RichText">The listbox that we want to put all of the information into.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the date associated with the date field. False: The record does not exists, see result for details.</returns>
	''' <remarks></remarks>
	Public Function GetBoardAudit(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, ByRef RichText As RichTextBox, ByRef result As String) As Boolean
        Dim record As String = ""

        'First we have to get the System GUID that we are working with.
        If GetBoardGUIDBySerialNumber(myCmd, myReader, boardSerialNumber, record, result) = False Then
            Return False
        End If

        'Next we grab the information we want form the Audit table.
        myCmd.CommandText = "SELECT LastUpdate, [User], Comment FROM dbo.BoardAudit WHERE [dbo.Board.boardid] = '" & record.ToString() & "' ORDER BY LastUpdate DESC"
        myReader = myCmd.ExecuteReader()

        Do While myReader.HasRows

            Do While myReader.Read()
                RichText.Text = RichText.Text & myReader.GetDateTime(0).ToString & " | " & myReader.GetString(1) & vbNewLine
                RichText.Text = RichText.Text & myReader.GetString(2) & vbNewLine
                RichText.Text = RichText.Text & vbNewLine
            Loop
            myReader.NextResult()
        Loop

        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the last update field associated with the passed board serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are working with.</param>
    ''' <param name="dateInformation">OUTPUT: The date for the date field.</param>
    ''' <param name="record">OUTPUT: The ID associated with the board.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the date associated with the date field. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardLastUpdate(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                       ByRef dateInformation As String, ByRef record As Guid, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT LastUpdate FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            'Check to see if the Reader is empty/NULL or not.
            If myReader.IsDBNull(0) Then
                dateInformation = ""
            Else
                'If not, set our information to whatever was passed back to us.
                dateInformation = myReader.GetDateTime(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardDate1] BoardNumber '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the Current type of the Board.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are working with.</param>
    ''' <param name="record">OUTPUT: The ID associated with the board.</param>
    ''' <param name="type">OUTPUT: The current status of the system</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the status. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardCurrentType(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                           ByRef record As Guid, ByRef type As String, ByRef result As String) As Boolean
        Dim boardTypeGUID As String = ""

        'First grab the GUID of the Board Type GUID associated with the board.
        myCmd.CommandText = "SELECT [dbo.BoardType.id] FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetBoardCurrentType1] board Type for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                Return False
            Else
                boardTypeGUID = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentType2] Board serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Second grab the Type for the board with the GIUD we got from the first step.
        myCmd.CommandText = "SELECT name FROM dbo.BoardType WHERE id = '" & boardTypeGUID & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                type = ""
                myReader.Close()
                Return False
            Else
                type = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentType3] Board Type does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the Current status of the Board.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are working with.</param>
    ''' <param name="stauts">OUTPUT: The current status of the system</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the status. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardCurrentStatus(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                          ByRef stauts As String, ByRef result As String) As Boolean
        Dim systemStatusGUID As String = ""

        'First grab the GUID of the CPU Serial Board associated with the system.
        myCmd.CommandText = "SELECT [dbo.BoardStatus.id] FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetBoardCurrentStatus1] System Status for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemStatusGUID = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentStatus2] System serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Second grab the Version for the board with the GIUD we got from the first step.
        myCmd.CommandText = "SELECT name FROM dbo.BoardStatus WHERE id = '" & systemStatusGUID & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                stauts = ""
                myReader.Close()
                Return False
            Else
                stauts = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentStatus3] System Status does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the Bootloader version.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="version">OUTPUT: The version of the Bootloader.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the version. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardBootloaderVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                              ByRef version As String, ByRef result As String) As Boolean
        'Grab the Version for the board.
        myCmd.CommandText = "SELECT BootloaderVersion FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                version = ""
                myReader.Close()
            Else
                version = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetSystemVersion1] Bootloader Version for '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the Software Version of the passed in board Serial Number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="version">OUTPUT: The version of the power A to D.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the version. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardSoftwareVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                            ByRef version As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT SoftwareVersion FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                version = ""
                myReader.Close()
            Else
                version = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardVersion1] Board Version for '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the Hardware Version of the passed in board Serial Number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="version">OUTPUT: The version of the board.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the version. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardHardwareVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, _
                                            ByRef version As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT HardwareVersion FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                version = ""
                myReader.Close()
            Else
                version = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardHardwareVersion1] Board Version for '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

	''' <summary>
	''' Gets the Board Serial Number using the passed in Board ID and System serial number.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="board">Board ID that we want the serial number from.</param>
	''' <param name="record">OUTPUT: The ID associated with the board.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the Board Serial Number. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetBoardGUIDBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String,
													 ByRef board As String, ByRef record As Guid, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT [" & board & ".boardid] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				record = Guid.Empty
			Else
				'If not, set our record GUID to whatever was passed back to us.
				record = myReader.GetGuid(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetBoardGUIDBySystemSerialNumber1] Board '" & board & "'/SerialNumber '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	Public Function GetBoardGUIDBySystemID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemID As String,
													 ByRef board As String, ByRef record As Guid, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT [" & board & ".boardid] FROM dbo.System WHERE systemid = '" & systemID & "'"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				record = Guid.Empty
			Else
				'If not, set our record GUID to whatever was passed back to us.
				record = myReader.GetGuid(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetBoardGUIDBySystemSerialNumber1] Board '" & board & "'/SerialNumber '" & systemID & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	''' <summary>
	''' Gets the board serial number associated with the passed GUID.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="boardGUID">The GUID that we are working with.</param>
	''' <param name="serialNumber">OUTPUT: The serial number associated with the board GUID.</param>
	''' <param name="result">OUTPUT: Error result when things do not work.</param>
	''' <returns>True: The record exists, returns the Board Serial Number. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function GetBoardSerialNumberByGUID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardGUID As String, _
                                               ByRef serialNumber As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE boardid = '" & boardGUID & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            'Check to see if the Reader is empty/NULL or not.
            If myReader.IsDBNull(0) Then
                serialNumber = ""
            Else
                'If not, set our string to whatever was passed back to us.
                serialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardSerialNumberByGUID1] Board GUID '" & boardGUID & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the board GUID associated with the passed Serial Number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="serialNumber">The serial number associated with the board GUID.</param>
    ''' <param name="boardGUID">OUTPUT: The GUID that we are working with.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the Board Serial Number. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetBoardGUIDBySerialNumber(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef serialNumber As String, _
                                               ByRef boardGUID As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & serialNumber & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            'Check to see if the Reader is empty/NULL or not.
            If myReader.IsDBNull(0) Then
                boardGUID = ""
            Else
                'If not, set our string to whatever was passed back to us.
                boardGUID = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardGUIDBySerialNumber1] Board GUID '" & serialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    '-----------'
    '   OTHER   '
    '-----------'

    ''' <summary>
    ''' Gets the Hardware Version of the passed in board Serial Number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardName">The system serial number that we are working with.</param>
    ''' <param name="version">OUTPUT: The version of the board.</param>
    ''' <param name="result">OUTPUT: Error result when things do not work.</param>
    ''' <returns>True: The record exists, returns the version. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetCurrentHardwareVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardName As String, _
                                              ByRef version As String, ByRef result As String) As Boolean

        myCmd.CommandText = "SELECT HardwareVersion FROM dbo.BoardType WHERE name = '" & boardName & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                version = ""
                myReader.Close()
            Else
                version = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardHardwareVersion1] Board Version for '" & boardName & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the next MAC Address that is available in the database.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="MACAddress">OUTPUT: The string variable that will hold the MAC Address.</param>
    ''' <returns>True: Got the next MAC, returns the MAC. False: Somthing went wrong and could not get the MAC Address.</returns>
    ''' <remarks></remarks>
    Public Function GetNextMACAddress(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef MACAddress As String) As Boolean
        myCmd.CommandText = "SELECT valuestring FROM dbo.SystemParameters WHERE id = 'MACADDR'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                myReader.Close()
                Return False
            Else
                MACAddress = myReader.GetString(0)
            End If
        Else
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the MAC Address associated with the passed in board serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are checking for.</param>
    ''' <param name="MACAddress">OUTPUT: The MAC Address that is associated with the System serial number.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns MAC Address. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetMACAddress(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, ByRef MACAddress As String, _
                                  ByRef result As String) As Boolean

        myCmd.CommandText = "SELECT MACAddress FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetMACAddress1] MAC Address for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                MACAddress = ""
                Return False
            Else
                MACAddress = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetMACAddress2] System serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the number of records that are associated with the sql table that we are working with.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="command">SQL command. Should be 'SELECT COUNT(*) FROM ______'</param>
    ''' <param name="numberOfRecords">OUTPUT: The number of records in the table.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: We go our number of records. False: Something went wrong, see error message for information.</returns>
    ''' <remarks></remarks>
    Public Function GetNumberOfRecords(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef command As String, ByRef numberOfRecords As Integer, ByRef result As String) As Boolean
        myCmd.CommandText = command
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetNumberOfRecords1] Number of records is NULL."
                myReader.Close()
                Return False
            Else
                numberOfRecords = myReader.GetInt32(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetNumberOfRecords2] Number of records does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    ''' <summary>
    ''' Gets the current Hardware version of the passed in board name from the database.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="hardware">The hardware that we are checking the version for.</param>
    ''' <param name="version">OUTPUT: The current hardware version of the passed in board.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: We have a version, pass back the version. False: Something went wrong, see error message for information.</returns>
    ''' <remarks></remarks>
    Public Function GetHardwareVersion(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef hardware As String, _
                                       ByRef version As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT HardwareVersion FROM dbo.BoardType WHERE name = '" & hardware & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                version = ""
                myReader.Close()
            Else
                version = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetHardwareVersion1] Board Version for '" & hardware & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

    ''' <summary>
    ''' Gets the CPUID associated with the passed in Board serial number.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="boardSerialNumber">The board serial number that we are checking for.</param>
    ''' <param name="CPUID">OUTPUT: The MAC Address that is associated with the System serial number.</param>
    ''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
    ''' <returns>True: The record exists, returns MAC Address. False: The record does not exists, see result for details.</returns>
    ''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
    Public Function GetCPUID(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef boardSerialNumber As String, ByRef CPUID As String, _
                                  ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT CPUID FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetCPUID1] CPUID for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                CPUID = ""
                Return False
            Else
                CPUID = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetCPUID2] System serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

    '---------------------------------------'
    '                                       '
    '     O T H E R   F U N C T I O N S     '
    '                                       '
    '---------------------------------------'

    ''' <summary>
    ''' Checks to see if the passed in MAC Address is lower than the highest MAC Address used.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="myReader">SQL data reader that we are going to read from.</param>
    ''' <param name="workingMac">The current MAC that we are using.</param>
    ''' <returns>True: The passed MAC is lower. False: The passed MAC is higher or error.</returns>
    ''' <remarks></remarks>
    Public Function BelowHighestUsedMAC(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef workingMac As String) As Boolean
        Try
            Dim workingHighPart As Integer = Convert.ToInt32(workingMac.Substring(0, 1), 16)
            Dim workingLowPart As Integer = Convert.ToInt32(workingMac.Substring(2), 16)
            Dim maxMAC As String = ""

            myCmd.CommandText = "SELECT MAX(MACAddress) FROM dbo.Board"
            myReader = myCmd.ExecuteReader

            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    myReader.Close()
                    Return False
                Else
                    maxMAC = myReader.GetString(0).ToString
                End If
            Else
                'If nothing is returned then it does not exist.
                myReader.Close()
                Return False
            End If
            myReader.Close()

            Dim maxHighPart As Integer = Convert.ToInt32(maxMAC.Substring(maxMAC.Length - 2, 1), 16)
            Dim maxLowPart As Integer = Convert.ToInt32(maxMAC.Substring(maxMAC.Length - 1), 16)

            If workingHighPart >= maxHighPart Then
                If workingLowPart >= maxLowPart Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function

	''' <summary>
	''' Roll back the transaction so we do not commit anything into the database.
	''' </summary>
	''' <param name="transaction">The transaction that we want to roll back.</param>
	''' <param name="result">OUTPUT: If there is an issue trying to roll back the transaction.</param>
	''' <remarks></remarks>
	Public Sub RollBack(ByRef transaction As SqlTransaction, ByRef result As String)
		Try
			If Not transaction Is Nothing Then
				'Attempt to roll back the transaction. 
				transaction.Rollback()
			End If
		Catch ex As Exception
			'Handles any errors that may have occurred on the server that would cause the rollback to fail, such as a closed connection.
			result = result & " :: " & ex.Message
		End Try
	End Sub

	''' <summary>
	''' Checks the system type from the data base to the type that gets passed in.
	''' </summary>
	''' <param name="myCmd">The sql Command that will be used.</param>
	''' <param name="myReader">SQL data reader that we are going to read from.</param>
	''' <param name="systemSerialNumber">The system serial number that we are checking for.</param>
	''' <param name="systemType">The system type that we are checking against.</param>
	''' <param name="result">OUTPUT: Error message that gives us a hint on what went wrong.</param>
	''' <returns>True: The record exists, returns MAC Address. False: The record does not exists, see result for details.</returns>
	''' <remarks>Make sure the SQL reader that is being passed through is already set to the SQL command reader before calling this function.</remarks>
	Public Function CheckSystemType(ByRef myCmd As SqlCommand, ByRef myReader As SqlDataReader, ByRef systemSerialNumber As String, ByRef systemType As String, _
                                    ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT [dbo.SystemType.id] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader
        Dim currentType As String = ""

        'First grab the GUID of the SystemType.
        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[CheckSystemType1] System Type for '" & systemSerialNumber & "' is NULL."
                myReader.Close()
                Return False
            Else
                currentType = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[CheckSystemType2] System serial number '" & systemSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Next grab the ServerModel from the database.
        myCmd.CommandText = "SELECT * FROM dbo.SystemType WHERE id = '" & currentType & "'"
        myReader = myCmd.ExecuteReader

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[CheckSystemType3] System id is NULL."
                myReader.Close()
                Return False
            Else
                currentType = myReader("ServerModel")
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[CheckSystemType4] System Type does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        If String.Compare(currentType, systemType) <> 0 Then
            result = "[CheckSystemType5] System type does not match what is in the database. Database: " & currentType & " Machine: " & systemType
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Checks to see if the passed in information matches the system definitions that have been set for the system in the database.
    ''' </summary>
    ''' <param name="myCmd">The sql Command that will be used.</param>
    ''' <param name="systemTypeGUID">The GUID of the system type that will be checking.</param>
    ''' <param name="slotNumber">The slot number that will be checking.</param>
    ''' <param name="serialNumber">The serial number of the board that will grab the base SNO from that we will be checking.</param>
    ''' <returns>True: Everything matches. False: Something does not match/User dicided not to continue because of the mis-match.</returns>
    ''' <remarks>This method uses all three parts to look for the definition. All three need to match the definition in the databse.</remarks>
    Public Function CheckSystemDefinition(ByRef myCmd As SqlCommand, ByRef systemTypeGUID As String, ByRef slotNumber As String, ByRef serialNumber As String) As Boolean
        Try
            Dim boardType As String = ""
            If serialNumber.Length <> 0 Then
                GetBoardTypeByPrefix(myCmd, serialNumber, boardType, "", "")
            End If

            'Check to see if we have any system definitions for the board type.
            myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'"
            myReader = myCmd.ExecuteReader
            If myReader.HasRows = False Then
                Dim answer As Integer = MessageBox.Show("This system type does not have any system definitions." & vbCrLf & _
                                                    "Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If answer = DialogResult.No Then
                    MsgBox("User decided not to continue. Ending Transaction.")
                    myReader.Close()
                    Return False
                End If
            End If
            myReader.Close()

            'Check to see if we have a specific definition for the slot that we are working with.
            myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'AND SlotNumber = '" & slotNumber & "' AND Mandatory = '1'"
            myReader = myCmd.ExecuteReader
            If myReader.HasRows = True Then

                'We have a mandatory slot.
                If serialNumber.Length = 0 Then
                    Dim answer1 As Integer = MessageBox.Show("Slot " & slotNumber & " conflicts with system definition." & vbCrLf & _
                                                    "Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If answer1 = DialogResult.No Then
                        MsgBox("User decided not to continue. Ending Transaction.")
                        myReader.Close()
                        Return False
                    End If
                End If
                While myReader.Read()
                    If myReader("BoardType.id").ToString = boardType Then
                        myReader.Close()
                        Return True
                    End If
                End While

                'We did not match any of the Required definitions.
                Dim answer2 As Integer = MessageBox.Show("Wrong required board in slot " & slotNumber & "." & vbCrLf & _
                                                    "Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If answer2 = DialogResult.No Then
                    MsgBox("User decided not to continue. Ending Transaction.")
                    myReader.Close()
                    Return False
                End If
                myReader.Close()
            Else
                myReader.Close()
                'Check to see if we have some text in the passed serial number for an optional definition.
                If serialNumber.Length <> 0 Then
                    myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'AND SlotNumber = '" & slotNumber & "' AND Mandatory = '0'"
                    myReader = myCmd.ExecuteReader
                    If myReader.HasRows = True Then
                        While myReader.Read()
                            If myReader("BoardType.id").ToString = boardType Then
                                myReader.Close()
                                Return True
                            End If
                        End While

                        'We did not match any of the Optional definitions.
                        Dim answer3 As Integer = MessageBox.Show("Wrong optional board in slot " & slotNumber & "." & vbCrLf & _
                                                    "Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If answer3 = DialogResult.No Then
                            MsgBox("User decided not to continue. Ending Transaction.")
                            myReader.Close()
                            Return False
                        End If
                    Else
                        'We do not have a definition for this type and slot
                        Dim answer4 As Integer = MessageBox.Show("There are no deffinitions defined for this slot." & vbCrLf & _
                                                    "Do you still want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If answer4 = DialogResult.No Then
                            MsgBox("User decided not to continue. Ending Transaction.")
                            myReader.Close()
                            Return False
                        End If
                    End If
                End If

                'This slot is not mandatory.
                myReader.Close()
                Return True
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function AddSpareCPU(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection,  ByRef systemType As String, _
                                ByRef systemSerialNumber As String, ByRef CPUSerialNumber As String, ByRef result As String, ByRef obj As JSON_InfoResult, _
                                ByRef MACaddress As String, ByRef oldMAC As String) As Boolean
        Dim successful As Boolean = True
        Dim systemStatus As String = ""
        Dim thisSystemType As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim existingRecord As String = ""
        Dim existingSystem As String = ""
        Dim record As Guid = Nothing

        'Get system status 'Network Registered'.
        If GetSystemStatus(myCmd, myReader, SS_NETWORK_REGISTERED, systemStatus, result) = False Then
            Return False
        End If

        'Get system type based on what was passed in name.
        If GetSystemType(myCmd, myReader, systemType, thisSystemType, result) = False Then
            Return False
        End If

        transaction = myConn.BeginTransaction("Add System Transaction")

        Try
            'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            'Check to see if we have a valid string.
            If CPUSerialNumber.Length > 0 Then

                'Check to make sure the board exists in the system.
                If GetBoardGUIDBySerialNumber(myCmd, myReader, CPUSerialNumber, existingRecord, result) = False Then

                    'We are not in the system. Ask the user if they want to add the board.
                    Dim answer As Integer = MessageBox.Show("Board SNO " & CPUSerialNumber & " is not in the database. Would you like to add it at this time?", "Continue?", MessageBoxButtons.YesNo)
                    If answer = DialogResult.Yes Then
                        If AddBoard(myCmd, myConn, CPUSerialNumber,  record, result, True,"") = True Then
                            existingRecord = record.ToString
                        End If
                    Else
                        result = "User decided not to add Board " & CPUSerialNumber & ". Program will not commit."
                        successful = False
                    End If
                Else

                    'Check to see if the board is already part of another system.
                    If GetSystemSerialNumberByBoardGUID(myCmd, myReader, existingRecord, existingSystem, result) = True Then
                        result = "Board " & CPUSerialNumber & " is already part of another system: " & existingSystem & "."
                        successful = False
                    End If

                    'Check to make sure the board is not in the 'Rework' or 'Shipped' status.
                    Dim status As String = ""
                    If GetBoardCurrentStatus(myCmd, myReader, CPUSerialNumber, status, result) = True Then
                        If String.Compare(status, BS_REWORK) = 0 Then
                            result = "Board " & CPUSerialNumber & " stauts is 'Rework' and cannot be added to a system until fixed."
                            successful = False
                        End If
                        If String.Compare(status.Substring(0, 4), BS_SHIPPED) = 0 Then
                            result = "Board " & CPUSerialNumber & " stauts is 'Shipped' and cannot be added to a system."
                            successful = False
                        End If
                    End If
                End If
            Else
                successful = False
            End If


            If successful = True Then
                myCmd.CommandText = "INSERT INTO dbo.System(systemid,[dbo.SystemType.id],[dbo.SystemStatus.id],SerialNumber," & _
                               "[MainCPU.boardid],LastUpdate,Instance)" & _
                               "VALUES(NEWID(),'" & thisSystemType & "','" & systemStatus & "','" & systemSerialNumber & _
                               "','" & existingRecord & "', GETDATE(), 0)"

                myCmd.ExecuteNonQuery()

                'Create a generic comment for the new System entry.
                If AddSystemComment(myCmd, systemSerialNumber, "This System is a placeholder for the Spare board attached to it.",  record, result) = False Then
                    RollBack(transaction, result)
                    result = "[AddSpareCPU1] Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                    Return False
                End If

                '----------------------------'
                '   U P D A T E   B O A R D  '
                '----------------------------'

                If UpdateBoardStatus(myCmd, BS_NETWORK_REGISTERED, CPUSerialNumber,  result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to update board: " & result
                    Return False
                End If

                myCmd.CommandText = "UPDATE dbo.Board SET MACAddress = '" & MACaddress & "', CPUID = '" & obj.cpuid & "', SoftwareVersion = '" & obj.version & "', BootloaderVersion='" & obj.blversion & "' WHERE SerialNumber = '" & CPUSerialNumber & "'"
                myCmd.ExecuteNonQuery()

                If AddBoardComment(myCmd, CPUSerialNumber, _
                                   "MAC changed from " & oldMAC & " to " & MACaddress & vbCrLf & _
                                   "CPU ID: " & obj.cpuid & vbCrLf & _
                                   "CPU SW: " & obj.version & vbCrLf & _
                                   "CPU BL: " & obj.blversion,  record, result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                    Return False
                End If

                transaction.Commit()
                Return True
            Else
                result = "[AddSpareCPU2] Transaction was not successful: " & result
                RollBack(transaction, result)
                Return False
            End If
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

    '-------------------------'
    '                         '
    '     S T E P   O N E     '
    '                         '
    '-------------------------'

    ''' <summary>
    ''' Adds all of the board entires into the database and updates the Registered status of the boards.
    ''' </summary>
    ''' <param name="myCmd">The SQL command that you will be using to make this action.</param>
    ''' <param name="myConn">The connection that you would like to make.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="boardsSerialNumbers">Array of each serial number for the boards that we are going to add to the database.</param>
    ''' <param name="result">OUTPUT: Message that lets us know if we were successful or not.</param>
    ''' <returns>True: Each board was added to the database. False: One of the boards was not able to be added, errors occured.</returns>
    ''' <remarks>This is a all or nothing function. If one does not work then they all do not get added to the database.</remarks>
    Public Function AddSystemWithBoards(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection,  ByRef systemSerialNumber As String, _
                                        ByRef boardsSerialNumbers As String(), ByRef systemType As String, ByRef result As String, ByRef SlimModel As Boolean) As Boolean
        Dim successful As Boolean = True
        Dim numberOfBoards As Integer = 0
        Dim systemStatus As String = ""
        Dim boardRecordNumber As String() = {"", "", "", "", "", "", "", "", "", "", ""}
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing
        Dim existingRecord As String = ""
        Dim existingSystem As String = ""

        If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = True Then
            result = "Serial Number " & systemSerialNumber & " is already in the database."
            Return False
        End If

        'Get system status 'Boards Registered'.
        If GetSystemStatus(myCmd, myReader, SS_BOARDS_REGISTERED, systemStatus, result) = False Then
            Return False
        End If

        transaction = myConn.BeginTransaction("Add System Transaction")

        'Add each board that was passed in by the array and then assign each record number to our boardRecordNumber array.
        Try
            'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            'Go through each input string and add each board to the database.
            For Each serialNo In boardsSerialNumbers

                'Check to see if we have a valid string.
                If serialNo.Length > 0 Then

                    'Check to make sure the board exists in the system.
                    If GetBoardGUIDBySerialNumber(myCmd, myReader, serialNo, existingRecord, result) = False Then
                        Dim answer As Integer = MessageBox.Show("Board SNO " & serialNo & " is not in the database. Would you like to add it at this time?", "Continue?", MessageBoxButtons.YesNo)
                        If answer = DialogResult.Yes Then
                            If AddBoard(myCmd, myConn, serialNo,  record, result, True,"") = True Then

                                'Check to make sure we do not have the same board serial number in two different slots.
                                For Each Str As String In boardRecordNumber
                                    If Str.Contains("'" & record.ToString & "'") = True Then
                                        result = "You cannot have the same board serial number in two different slots."
                                        successful = False
                                        Exit For
                                    End If
                                Next
                                boardRecordNumber(numberOfBoards) = "'" & record.ToString & "'"
                                numberOfBoards += 1
                            End If
                        Else
                            result = "User decided not to add Board " & serialNo & ". Program will not commit."
                            successful = False
                            Exit For
                        End If
                    Else

                        'Check to see if the board is already part of another system.
                        If GetSystemSerialNumberByBoardGUID(myCmd, myReader, existingRecord, existingSystem, result) = True Then
                            result = "Board " & serialNo & " is already part of another system: " & existingSystem & "."
                            successful = False
                            Exit For
                        End If

                        'Check to make sure the board is not in the 'Rework' or 'Shipped' status.
                        Dim status As String = ""
                        If GetBoardCurrentStatus(myCmd, myReader, serialNo, status, result) = True Then
                            If String.Compare(status, BS_REWORK) = 0 Then
                                result = "Board " & serialNo & " stauts is 'Rework' and cannot be added to a system until fixed."
                                successful = False
                                Exit For
                            End If
							If String.Compare(status.Substring(0, 4), BS_SHIPPED) = 0 Then
								result = "Board " & serialNo & " stauts is 'Shipped' and cannot be added to a system."
								successful = False
								Exit For
							End If
							If String.Compare(status, SS_SCRAPPED) = 0 Then
								result = "Board " & serialNo & " stauts is 'Scrapped' and cannot be added to a system."
								successful = False
								Exit For
							End If
						End If

                        'Check to make sure we do not have the same board serial number in two different slots.
                        For Each Str As String In boardRecordNumber
                            If Str.Contains("'" & existingRecord & "'") = True Then
                                result = "You cannot have the same board serial number in two different slots."
                                successful = False
                                Exit For
                            End If
                        Next
                        boardRecordNumber(numberOfBoards) = "'" & existingRecord & "'"
                        numberOfBoards += 1
                    End If
                Else
                    boardRecordNumber(numberOfBoards) = "NULL"
                    numberOfBoards += 1
                End If
            Next

			If successful = True Then

				' Get the highest Instance available and then add 1 to it.
				myCmd.CommandText = "if exists(select * from System where SerialNumber = '" & systemSerialNumber & "') select (MAX(Instance) + 1)
from System where SerialNumber = '" & systemSerialNumber & "' else select 0"

				Dim Instance = myCmd.ExecuteScalar()

				If SlimModel = True Then
					myCmd.CommandText = "INSERT INTO dbo.System(systemid,[dbo.SystemType.id],[dbo.SystemStatus.id],SerialNumber,BarcodeDate,[MotherBoard.boardid]," &
							"[MainCPU.boardid],[Slot2.boardid],[Slot3.boardid],LastUpdate,Instance)" &
							"VALUES(NEWID(),'" & systemType & "','" & systemStatus & "','" & systemSerialNumber & "', GETDATE()," & boardRecordNumber(0) &
							"," & boardRecordNumber(0) & "," & boardRecordNumber(0) & "," & boardRecordNumber(1) & ",GETDATE(), " & Instance & ")"
				Else
					myCmd.CommandText = "INSERT INTO dbo.System(systemid,[dbo.SystemType.id],[dbo.SystemStatus.id],SerialNumber,BarcodeDate,[MotherBoard.boardid]," &
								   "[MainCPU.boardid],[Slot2.boardid],[Slot3.boardid],[Slot4.boardid],[Slot5.boardid],[Slot6.boardid],[Slot7.boardid],[Slot8.boardid],[Slot9.boardid],[Slot10.boardid],LastUpdate,Instance)" &
								   "VALUES(NEWID(),'" & systemType & "','" & systemStatus & "','" & systemSerialNumber & "', GETDATE()," & boardRecordNumber(0) &
								   "," & boardRecordNumber(1) & "," & boardRecordNumber(2) & "," & boardRecordNumber(3) & "," & boardRecordNumber(4) & "," & boardRecordNumber(5) &
								   "," & boardRecordNumber(6) & "," & boardRecordNumber(7) & "," & boardRecordNumber(8) & "," & boardRecordNumber(9) & "," & boardRecordNumber(10) & ",GETDATE(), " & Instance & ")"
				End If

				myCmd.ExecuteNonQuery()

				'Create a generic comment for the new System entry.
				If AddSystemComment(myCmd, systemSerialNumber, "System has been added to the database.",  record, result) = False Then
					RollBack(transaction, result)
					result = "[AddSystemWithBoards1] Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
					Return False
				End If

				'------------------------------'
				'   U P D A T E   B O A R D S  '
				'------------------------------'

				'Update each board that is associated with the passed in system serial number.
				If UpdateSystemBoards(myCmd, BS_BOARD_REGISTERED, systemSerialNumber, "Board has been registered to System " & systemSerialNumber & ".",  result) = False Then
					RollBack(transaction, result)
					result = "Something went wrong while trying to update boards: " & result
					Return False
				End If

				transaction.Commit()
				Return True
			Else
				result = "[AddSystemWithBoards2] Transaction was not successful: " & result
                RollBack(transaction, result)
                Return False
            End If
        Catch ex As Exception
			result = ex.Message & vbNewLine & myCmd.CommandText
			If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

	'-------------------------'
	'                         '
	'     S T E P   T W O     '
	'                         '
	'-------------------------'

	''' <summary>
	''' Registers the system passed through with the network parameters and updates the Register Network status of the system and boards.
	''' </summary>
	''' <param name="myCmd">The sql command that we will be using.</param>
	''' <param name="myConn">The sql connection that we will be using.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="CPUBoardSerialNo">The CPU board serial number that we want to add to the system.</param>
	''' <param name="MACaddress">The MAC Address that we want to add to the system.</param>
	''' <param name="oldMAC">The old MAC of the CPU board that we want to update.</param>
	''' <param name="result">OUTPUT: The error message if something does not go right.</param>
	''' <param name="override">Boolean value that lets us override an entry if we already have a date in the table.</param>
	''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
	''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
	Public Function RegisterNetwork(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, ByRef CPUBoardSerialNo As String, _
                                    ByRef MACaddress As String, ByRef oldMAC As String,  ByRef result As String, ByRef override As Boolean) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing

        Try
            If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
                Return False
            End If

			'If override = False Then
			'    'Check to see if we already set the Register Date this system.
			'    If FindDate(myCmd, myReader, "RegisterDate", systemSerialNumber, override, result) = False Then
			'        Return False
			'    End If
			'End If

			'------------------------------'
			'   U P D A T E   S Y S T E M  '
			'------------------------------'

			'Get the GUID from the passed in serial number.
			If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
                Return False
            End If

            'Get system status 'Network Registered'.
            If GetSystemStatus(myCmd, myReader, SS_NETWORK_REGISTERED, systemStatus, result) = False Then
                Return False
            End If

			'Update the corresponding record in the System table.

			myCmd.CommandText = "UPDATE dbo.System SET RegisterDate=GETDATE()," &
								"[dbo.SystemStatus.id]='" & systemStatus & "', LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and
								[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Register Network Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()

            'Create a generic comment for the new system update from the user.
            If AddSystemComment(myCmd, systemSerialNumber, "MAC changed from " & oldMAC & " to " & MACaddress & ".",  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

            '------------------------------'
            '   U P D A T E   B O A R D S  '
            '------------------------------'

            'Update each board that is associated with the passed in system serial number.
            If UpdateSystemBoards(myCmd, BS_NETWORK_REGISTERED, systemSerialNumber, "Network has been registered.",  result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to update boards: " & result
                Return False
            End If

            myCmd.CommandText = "UPDATE dbo.Board SET MACAddress = '" & MACaddress & "' WHERE SerialNumber = '" & CPUBoardSerialNo & "'"
            myCmd.ExecuteNonQuery()

            If AddBoardComment(myCmd, CPUBoardSerialNo, "MAC changed from " & oldMAC & " to " & MACaddress & ".",  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                Return False
            End If

            transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

	''' <summary>
	''' Registers the system passed through with the network parameters and updates the Register Network status of the system and boards.
	''' </summary>
	''' <param name="myCmd">The sql command that we will be using.</param>
	''' <param name="myConn">The sql connection that we will be using.</param>
	''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
	''' <param name="result">OUTPUT: The error message if something does not go right.</param>
	''' <param name="obj">JSON object with all of the info from the request.</param>
	''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
	''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
	Public Function UpdateCPUInformation(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, _
                                          ByRef result As String, ByRef obj As JSON_InfoResult) As Boolean
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing
        Dim CPUBoardSerialNo As String = ""
        Dim PWRA2DBoardSerialNo As String = ""
        Dim DanfossBoardSerialNo As String = ""

        Try
            'Check to see that the System Serial Number is in the Database.
            If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
                Return False
            End If

            '------------------------------'
            '   U P D A T E   S Y S T E M  '
            '------------------------------'

            'Get the GUID from the passed in serial number.
            If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
                Return False
            End If

            Select Case obj.model
                Case "ETS7"

                Case Else
                    'Grab the CPU Board serial number from the System serial number.
                    If GetCPUSerialNumberBySystemSerialNumber(myCmd, myReader, systemSerialNumber, CPUBoardSerialNo, result) = False Then
                        MsgBox(result)
                        Return False
                    End If

                    If FindVersion(myCmd, myReader, CPUBoardSerialNo, "CPU", result, obj) = False Then
                        Return False
                    End If

                    'Grab the CPU Board serial number from the System serial number.
                    If GetPWRA2DSerialNumberBySystemSerialNumber(myCmd, myReader, systemSerialNumber, PWRA2DBoardSerialNo, result) = False Then
                        MsgBox(result)
                        Return False
                    End If

                    If FindVersion(myCmd, myReader, PWRA2DBoardSerialNo, "PWRA2D", result, obj) = False Then
                        Return False
                    End If



                    'REM Need to add Danfoss Card checker to D7 logic

            End Select


            'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            transaction = myConn.BeginTransaction("CPU Information Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            'Create a generic comment for the new system update from the user.
            If AddSystemComment(myCmd, systemSerialNumber, "CPU information updated.",  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

            Select Case obj.model
                Case "ETS7"

				Case Else
					myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE CPUID = '" & obj.cpuid & "' AND 
[dbo.BoardStatus.id] != (Select id from BoardStatus where name = 'Scrapped' AND SerialNumber != '" & CPUBoardSerialNo & "')"

					Dim resultTable As New DataTable
					resultTable.Load(myCmd.ExecuteReader)

					If resultTable.Rows.Count <> 0 Then
						result = "CPU ID: " & obj.cpuid & " already is attached to an active board: " & resultTable(0)(0).ToString & "." & vbNewLine &
							"Unable to update."
						Return False
					End If


					myCmd.CommandText = "UPDATE dbo.Board SET CPUID = '" & obj.cpuid & "' WHERE SerialNumber = '" & CPUBoardSerialNo & "'"
                    myCmd.ExecuteNonQuery()

                    If AddBoardComment(myCmd, CPUBoardSerialNo, _
                                       "CPU ID: " & obj.cpuid & "." & vbCrLf & _
                                       "CPU SW: " & obj.version & "." & vbCrLf & _
                                       "CPU BL: " & obj.blversion & ".",  record, result) = False Then
                        RollBack(transaction, result)
                        result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                        Return False
                    End If

                    If AddBoardComment(myCmd, PWRA2DBoardSerialNo, "Slot2 SW: " & obj.ioversion & ".",  record, result) = False Then
                        RollBack(transaction, result)
                        result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                        Return False
                    End If

                    '------------------------------'
                    '   U P D A T E   B O A R D S  '
                    '------------------------------'

                    If UpdateBoardSoftwareVersionBySystemSerialNumber(myCmd, systemSerialNumber, "MainCPU", obj.version, result) = False Then
                        RollBack(transaction, result)
                        result = "Something went wrong while trying to update Main CPU board version: " & result
                        Return False
                    End If

                    If UpdateBoardBootLoaderVersionBySystemSerialNumber(myCmd, systemSerialNumber, "MainCPU", obj.blversion, result) = False Then
                        RollBack(transaction, result)
                        result = "Something went wrong while trying to update Main CPU bootloader version: " & result
                        Return False
                    End If

                    If UpdateBoardSoftwareVersionBySystemSerialNumber(myCmd, systemSerialNumber, "slot2", obj.ioversion, result) = False Then
                        RollBack(transaction, result)
                        result = "Something went wrong while trying to update AtoD board version: " & result
                        Return False
                    End If

                    'REM Need to Add in the Danfoss Card checker to D7 logic

            End Select

			myCmd.CommandText = "UPDATE dbo.System SET LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and 
[dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			myCmd.ExecuteNonQuery()

            transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

    '-----------------------------'
    '                             '
    '     S T E P   T H R E E     '
    '                             '
    '-----------------------------'

    ''' <summary>
    ''' Sets the parameters for the system that is passed through and then updates the Set Parameters status of the system (and boards).
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="myConn">The sql connection that we will be using.</param>
    ''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
    ''' <param name="parameterFileName">The name of the parameter file.</param>
    ''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
    ''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
    ''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
    Public Function SetParameters(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, ByRef parameterFileName As String, _
                                   ByRef result As String) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing
		'Dim registerDateTime As DateTime = Nothing
		'Dim stepSkipped As Boolean = False

		If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
            Return False
        End If

		'GetSystemDate(myCmd, myReader, systemSerialNumber, REGISTER_DATE, registerDateTime, record, result)

		'First check to see if we did not get any dates.
		'If registerDateTime = Nothing Then
		'	stepSkipped = True
		'End If

		'If we have found that a step was skipped, let the user know about it.
		'If stepSkipped = True Then
		'	Dim registerDate As String = "-----"

		'	If registerDateTime <> Nothing Then
		'		registerDate = registerDateTime.ToString()
		'	End If

		'	Dim answer As Integer = MessageBox.Show("System " & systemSerialNumber & " has steps done out of order:" & vbCrLf &
		'											"Register Date: " & registerDate & vbCrLf &
		'											"Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
		'	If answer = DialogResult.No Then
		'		result = "User decided not to continue due to step out of order."
		'		Return False
		'	End If
		'End If

		Try
            'Get the GUID from the passed in serial number.
            If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
                Return False
            End If

            'Get system status 'Set Parameters'.
            If GetSystemStatus(myCmd, myReader, SS_SET_PARAMETERS, systemStatus, result) = False Then
                Return False
            End If

			'Update the corresponding record in the System table.
			myCmd.CommandText = "UPDATE dbo.System SET ParameterDate=GETDATE(), ParameterFile='" & parameterFileName & "',[dbo.SystemStatus.id]='" &
								 systemStatus & "', LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and 
								 [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Set Parameters Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()

			'If we have chosen to continue with a skipped step, add a special comment to the audit record.
			'If stepSkipped = True Then
			'    If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Continued to set Parameters even though steps were done out of order.",  record, result) = False Then
			'        RollBack(transaction, result)
			'        result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
			'        Return False
			'    End If
			'Else
			'Create a generic comment for the new system update from the user.
			If AddSystemComment(myCmd, systemSerialNumber, "Parameters have been set.",  record, result) = False Then
				RollBack(transaction, result)
				result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
				Return False
			End If
			'End If

			'------------------------------'
			'   U P D A T E   B O A R D S  '
			'------------------------------'

			''Update each board that is associated with the passed in system serial number.
			'If UpdateBoards(myCmd, BS_NETWORK_REGISTERED, systemSerialNumber, "Parameters have been set",  result) = False Then
			'    RollBack(transaction, result)
			'    result = "Something went wrong while trying to update boards: " & result
			'    Return
			'End If

			transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

    '-------------------------------'
    '                               '
    '     S T E P   F O U R   A     '
    '                               '
    '-------------------------------'

    ''' <summary>
    ''' Check out steps and dates dealing with the passed in Serial Number for the Burn In step.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
    ''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
    ''' <param name="override">Option to continue with the burn in step if we already have a date in the record.</param>
    ''' <param name="stepSkipped">Option that will add a comment that this step was continued with skipped steps.</param>
    ''' <returns>True: Steps were not skipped or user decided it was okay. False: Errors occured.</returns>
    ''' <remarks></remarks>
    Public Function BurnInCheckSteps(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, _
                                     ByRef result As String, ByRef override As Boolean, ByRef stepSkipped As Boolean) As Boolean
        Dim record As Guid = Nothing
		'Dim registerDateTime As DateTime = Nothing
		'Dim parameterDateTime As DateTime = Nothing

		'If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
		'    Return False
		'End If

		'If override = False Then
		'    'Check to see if we already set the Burn In for this system.
		'    If FindDate(myCmd, myReader, BURN_IN_DATE, systemSerialNumber, override, result) = False Then
		'        Return False
		'    End If
		'End If

		'GetSystemDate(myCmd, myReader, systemSerialNumber, REGISTER_DATE, registerDateTime, record, result)
		'GetSystemDate(myCmd, myReader, systemSerialNumber, PARAMETER_DATE, parameterDateTime, record, result)

		'First check to see if we did not get any dates.
		'If registerDateTime = Nothing Or parameterDateTime = Nothing Then
		'	stepSkipped = True
		'End If

		''Second check to see that all of our dates are in order.
		'If stepSkipped = False Then
		'    'Check to see if our parameter date is smaller than our register date.
		'    If parameterDateTime > registerDateTime = False Then
		'        stepSkipped = True
		'    End If
		'End If

		'If we have found that a step was skipped, let the user know about it.
		'If stepSkipped = True Then
		'          Dim registerDate As String = "-----"
		'          Dim parameterDate As String = "-----"

		'          If registerDateTime <> Nothing Then
		'              registerDate = registerDateTime.ToString()
		'          End If
		'          If parameterDateTime <> Nothing Then
		'              parameterDate = parameterDateTime.ToString()
		'          End If

		'          Dim answer As Integer = MessageBox.Show("System " & systemSerialNumber & " has steps done out of order:" & vbCrLf & _
		'                                                  "Register Date: " & registerDate & vbCrLf & _
		'                                                  "Parameter Date: " & parameterDate & vbCrLf & _
		'                                                  "Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
		'          If answer = DialogResult.No Then
		'              result = "User decided not to continue due to steps out of order."
		'              Return False
		'          End If
		'      End If
		Return True
    End Function

    '-------------------------------'
    '                               '
    '     S T E P   F O U R   B     '
    '                               '
    '-------------------------------'

    ''' <summary>
    ''' Updates the status of the system to 'Burn In'.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="myConn">The sql connection that we will be using.</param>
    ''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
    ''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
    ''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
    ''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
    Public Function BurnIn(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String,  _
                           ByRef list As List(Of String), ByRef result As String) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing

        Try
            'Get system status 'Burn In'.
            If GetSystemStatus(myCmd, myReader, SS_BURN_IN, systemStatus, result) = False Then
                Return False
            End If

            'Update the corresponding record in the System table.
            myCmd.CommandText = "UPDATE dbo.System SET BurnInDate=GETDATE(),[dbo.SystemStatus.id]='" & systemStatus & "', LastUpdate=GETDATE()" & _
                                "WHERE SerialNumber = '" & systemSerialNumber & "'"

            'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            transaction = myConn.BeginTransaction("Set Parameters Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()

            Dim found = False

			'If we have chosen to continue with a skipped step, add a special comment to the audit record.
			'For Each SNO As String In list
			'	If String.Compare(SNO, systemSerialNumber) = 0 Then
			'		If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Continued to Burn In even though steps were done out of order.",  record, result) = False Then
			'			RollBack(transaction, result)
			'			result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
			'			Return False
			'		End If
			'		If UpdateSystemBoards(myCmd, BS_BURN_IN, systemSerialNumber, "ATTENTION: Continued to Burn In even though steps were done out of order.",  result) = False Then
			'			RollBack(transaction, result)
			'			result = "Something went wrong while trying to update boards: " & result
			'			Return False
			'			found = True
			'			Exit For
			'		End If
			'	End If
			'Next

			If found = False Then
                'Create a generic comment for the new system update from the user.
                If AddSystemComment(myCmd, systemSerialNumber, "System in Burn.",  record, result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                    Return False
                End If
                'Update each board that is associated with the passed in system serial number.
                If UpdateSystemBoards(myCmd, BS_BURN_IN, systemSerialNumber, "Board in Burn.",  result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to update boards: " & result
                    Return False
                End If
            End If

            transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

    '---------------------------'
    '                           '
    '     S T E P   F I V E     '
    '                           '
    '---------------------------'

    ''' <summary>
    ''' Adds the checkout sheet to the system that is passed through and updates the Final Checkout status for the system and boards.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="myConn">The sql connection that we will be using.</param>
    ''' <param name="systemSerialNumber">The system serial number that we are working with.</param>
    ''' <param name="checkoutFileName">The path to the checkout file.</param>
    ''' <param name="result">OUTPUT: Error message to let us know what went wrong.</param>
    ''' <param name="override">Boolean that allows us to override an entry that already has a date in the table.</param>
    ''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
    ''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
    Public Function FinalCheckout(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, ByRef checkoutFileName As String, _
                                   ByRef result As String, ByRef override As Boolean, ByRef noPDF As Boolean) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim record As Guid = Nothing
        Dim registerDateTime As DateTime = Nothing
        Dim parameterDateTime As DateTime = Nothing
        Dim burnInDateTime As DateTime = Nothing
        Dim stepSkipped As Boolean = False

        If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
            Return False
        End If

		'If override = False Then
		'    'Check to see if we already set the Checkout Date for this system.
		'    If FindDate(myCmd, myReader, "CheckoutDate", systemSerialNumber, override, result) = False Then
		'        Return False
		'    End If
		'End If

		GetSystemDate(myCmd, myReader, systemSerialNumber, REGISTER_DATE, registerDateTime, record, result)
        GetSystemDate(myCmd, myReader, systemSerialNumber, PARAMETER_DATE, parameterDateTime, record, result)
        GetSystemDate(myCmd, myReader, systemSerialNumber, BURN_IN_DATE, burnInDateTime, record, result)

        'First check to see if we did not get any dates.
        If registerDateTime = Nothing Or parameterDateTime = Nothing Or burnInDateTime = Nothing Then
            stepSkipped = True
        End If

        'Second check to see that all of our dates are in order.
        'If stepSkipped = False Then
        '    'Check to see if our burn in date is smaller than our parameter date.
        '    If burnInDateTime > parameterDateTime = False Then
        '        stepSkipped = True
        '    End If
        '    'Check to see if our parameter date is smaller than our register date.
        '    If parameterDateTime > registerDateTime = False Then
        '        stepSkipped = True
        '    End If
        'End If

        'If we have found that a step was skipped, let the user know about it.
        If stepSkipped = True Then
            Dim registerDate As String = "-----"
            Dim parameterDate As String = "-----"
            Dim burnInDate As String = "-----"

            If registerDateTime <> Nothing Then
                registerDate = registerDateTime.ToString()
            End If
            If parameterDateTime <> Nothing Then
                parameterDate = parameterDateTime.ToString()
            End If
            If burnInDateTime <> Nothing Then
                burnInDate = burnInDateTime.ToString()
            End If

			Dim answer As Integer = MessageBox.Show("System " & systemSerialNumber & " has steps that were skipped:" & vbCrLf &
													"Register Date: " & registerDate & vbCrLf &
													"Parameter Date: " & parameterDate & vbCrLf &
													"Burn In Date: " & burnInDate & vbCrLf &
													"Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
			If answer = DialogResult.No Then
                result = "User decided not to continue due to steps out of order."
                Return False
            End If
        End If

        Try
            'Get the GUID from the passed in serial number.
            If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
                Return False
            End If

            'Get system status 'CQ Checkout'.
            If GetSystemStatus(myCmd, myReader, SS_QC_CHECKOUT, systemStatus, result) = False Then
                Return False
            End If

            'Update the corresponding record in the System table.
            If noPDF = False Then
				myCmd.CommandText = "UPDATE dbo.System SET CheckoutDate=GETDATE(), AttachFilename='" & checkoutFileName & "', [dbo.SystemStatus.id]='" & systemStatus & "', 
LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			Else
				myCmd.CommandText = "UPDATE dbo.System SET CheckoutDate=GETDATE(), AttachFilename='" & username & " uploaded without PDF', [dbo.SystemStatus.id]='" & systemStatus & "', 
LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			End If

            'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            transaction = myConn.BeginTransaction("Final Checkout Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()

            'If we have chosen to continue with a skipped step, add a special comment to the audit record.
            If stepSkipped = True Then
                If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Continued to Final Checkout even though steps were done out of order.",  record, result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                    Return False
                End If
                'Update each board that is associated with the passed in system serial number.
                If UpdateSystemBoards(myCmd, BS_QC_CHECKOUT, systemSerialNumber, "ATTENTION: Continued to Final Checkout even though steps were done out of order.",  result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to update boards: " & result
                    Return False
                End If
            Else
                'Update each board that is associated with the passed in system serial number.
                If UpdateSystemBoards(myCmd, BS_QC_CHECKOUT, systemSerialNumber, "Final Checkout completed.",  result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to update boards: " & result
                    Return False
                End If
            End If

            'Create a generic comment for the new system update from the user.
            If noPDF = False Then
                If AddSystemComment(myCmd, systemSerialNumber, "Final checkout with checkout sheet uploaded.",  record, result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to add a comment to to system " & systemSerialNumber & ": " & result
                    Return False
                End If
            Else
                If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Final checkout *WHITOUT* checkout sheet uploaded.",  record, result) = False Then
                    RollBack(transaction, result)
                    result = "Something went wrong while trying to add a comment to to system " & systemSerialNumber & ": " & result
                    Return False
                End If
            End If

            transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function

    '-----------------------------'
    '                             '
    '     S T E P   S I X   A     '
    '                             '
    '-----------------------------'

    ''' <summary>
    ''' Check out steps and dates dealing with the passed in Serial Number for the Ship step.
    ''' </summary>
    ''' <param name="myCmd">The sql command that we will be using.</param>
    ''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
    ''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
    ''' <param name="override">Option to continue with the burn in step if we already have a date in the record.</param>
    ''' <param name="stepSkipped">Option that will add a comment that this step was continued with skipped steps.</param>
    ''' <returns>True: Steps were not skipped or user decided it was okay. False: Errors occured.</returns>
    ''' <remarks></remarks>
    Public Function ShipAndInvoiceCheckSteps(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, _
                                             ByRef result As String, ByRef override As Boolean, ByRef stepSkipped As Boolean) As Boolean
        Dim record As Guid = Nothing
		'Dim registerDateTime As DateTime = Nothing
		'Dim parameterDateTime As DateTime = Nothing
		'Dim burnInDateTime As DateTime = Nothing
		'Dim checkoutDateTime As DateTime = Nothing

		If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
            Return False
        End If

		'If override = False Then
		'    'Check to see if we already set the Ship Date for this system.
		'    If FindDate(myCmd, myReader, SHIP_DATE, systemSerialNumber, override, result) = False Then
		'        Return False
		'    End If
		'End If

		'GetSystemDate(myCmd, myReader, systemSerialNumber, REGISTER_DATE, registerDateTime, record, result)
		'GetSystemDate(myCmd, myReader, systemSerialNumber, PARAMETER_DATE, parameterDateTime, record, result)
		'GetSystemDate(myCmd, myReader, systemSerialNumber, BURN_IN_DATE, burnInDateTime, record, result)
		'GetSystemDate(myCmd, myReader, systemSerialNumber, CHECKOUT_DATE, checkoutDateTime, record, result)

		'First check to see if we did not get any dates.
		'If registerDateTime = Nothing Or parameterDateTime = Nothing Or burnInDateTime = Nothing Or checkoutDateTime = Nothing Then
		'	stepSkipped = True
		'End If

		'Second check to see that all of our dates are in order.
		'If stepSkipped = False Then
		'    'Check to see if our checkout date is smaller than our burn in date.
		'    If checkoutDateTime > burnInDateTime = False Then
		'        stepSkipped = True
		'    End If
		'    'Check to see if our burn in date is smaller than our parameter date.
		'    If burnInDateTime > parameterDateTime = False Then
		'        stepSkipped = True
		'    End If
		'    'Check to see if our parameter date is smaller than our register date.
		'    If parameterDateTime > registerDateTime = False Then
		'        stepSkipped = True
		'    End If
		'End If

		'If we have found that a step was skipped, let the user know about it.
		'If stepSkipped = True Then
		'          Dim registerDate As String = "-----"
		'          Dim parameterDate As String = "-----"
		'          Dim burnInDate As String = "-----"
		'          Dim checkoutDate As String = "-----"

		'          If registerDateTime <> Nothing Then
		'              registerDate = registerDateTime.ToString()
		'          End If
		'          If parameterDateTime <> Nothing Then
		'              parameterDate = parameterDateTime.ToString()
		'          End If
		'          If burnInDateTime <> Nothing Then
		'              burnInDate = burnInDateTime.ToString()
		'          End If
		'          If checkoutDateTime <> Nothing Then
		'              checkoutDate = checkoutDateTime.ToString()
		'          End If

		'          Dim answer As Integer = MessageBox.Show("System " & systemSerialNumber & " has steps done out of order:" & vbCrLf & _
		'                                                  "Register Date: " & registerDate & vbCrLf & _
		'                                                  "Parameter Date: " & parameterDate & vbCrLf & _
		'                                                  "Burn In Date: " & burnInDate & vbCrLf & _
		'                                                  "Checkout Date: " & checkoutDate & vbCrLf & _
		'                                                  "Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
		'          If answer = DialogResult.No Then
		'              result = "User decided not to continue due to steps out of order."
		'              Return False
		'          End If
		'      End If
		Return True
    End Function

	'-----------------------------'
	'                             '
	'     S T E P   S I X   B     '
	'                             '
	'-----------------------------'

	''' <summary>
	''' Updates the status of the system to 'Shipped'.
	''' </summary>
	''' <param name="myCmd">The sql command that we will be using.</param>
	''' <param name="myConn">The sql connection that we will be using.</param>
	''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
	''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
	''' <returns>True: Each board was updated in the database. False: One of the boards was not able to be updated, errors occured.</returns>
	''' <remarks>This is a all or nothing function. If one does not work then they all do not get updated to the database.</remarks>
	Public Function ShipAndInvoice(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, ByRef ship As String,
								    ByRef list As List(Of String), ByRef result As String, ByRef infoDate As Date) As Boolean
		Dim systemStatus As String = ""
		Dim transaction As SqlTransaction = Nothing
		Dim record As Guid = Nothing

		Try
			'Get the GUID from the passed in serial number.
			If GetSystemGUID(myCmd, myReader, systemSerialNumber, record, result) = False Then
				Return False
			End If

			'Get system status 'Shipped'.
			If GetSystemStatus(myCmd, myReader, ship, systemStatus, result) = False Then
				Return False
			End If

			'Update the corresponding record in the System table.
			myCmd.CommandText = "UPDATE dbo.System SET ShipDate='" & infoDate & "',[dbo.SystemStatus.id]='" & systemStatus & "', 
LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Set Parameters Transaction")
			myCmd.Connection = myConn
			myCmd.Transaction = transaction

			myCmd.ExecuteNonQuery()

			Dim found = False

			'If we have chosen to continue with a skipped step, add a special comment to the audit record.
			For Each SNO As String In list
				If String.Compare(SNO, systemSerialNumber) = 0 Then
					If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Continued to Ship even though steps were done out of order.",  record, result) = False Then
						RollBack(transaction, result)
						result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
						Return False
					End If
					If UpdateSystemBoards(myCmd, ship, systemSerialNumber, "ATTENTION: Continued to Ship even though steps were out of order.",  result) = False Then
						RollBack(transaction, result)
						result = "Something went wrong while trying to update boards: " & result
						Return False
					End If
					found = True
					Exit For
				End If
			Next

			If found = False Then
				'Create a generic comment for the new system update from the user.
				If AddSystemComment(myCmd, systemSerialNumber, "System has been shipped.",  record, result) = False Then
					RollBack(transaction, result)
					result = "Something went wrong while trying to add a comment to this update: " & result
					Return False
				End If
				'Update each board that is associated with the passed in system serial number.
				If UpdateSystemBoards(myCmd, ship, systemSerialNumber, "Board has been shipped.",  result) = False Then
					RollBack(transaction, result)
					result = "Something went wrong while trying to update boards: " & result
					Return False
				End If
			End If

			transaction.Commit()
			Return True
		Catch ex As Exception
			result = ex.Message
			If Not transaction Is Nothing Then
				RollBack(transaction, result)
			End If
			Return False
		End Try
	End Function

	'-------------------------------'
	'                               '
	'     S W A P   B O A R D S     '
	'                               '
	'-------------------------------'

	''' <summary>
	''' Swaps a board out of a system and replaces it with a new board. Also updates audits of serial numbers involved.
	''' </summary>
	''' <param name="myCmd">The sql command that we will be using.</param>
	''' <param name="myConn">The sql connection that we will be using.</param>
	''' <param name="systemSerialNumber">The serial number of the system that we are working with.</param>
	''' <param name="oldBoardSerialNumber">The board serial number that we want to replace.</param>
	''' <param name="newBoardSerialNumber">The board serial number that we are replacing with.</param>
	''' <param name="result">OUTPUT: Error message to describe what went wrong.</param>
	''' <returns>True: The board swap was successful. Flase: Unable to swap the boards, see error result for more information.</returns>
	''' <remarks></remarks>
	Public Function SwapBoards(ByRef myCmd As SqlCommand, ByRef myConn As SqlConnection, ByRef systemSerialNumber As String, ByRef oldBoardSerialNumber As String, _
                               ByRef newBoardSerialNumber As String, ByRef issue As String, ByRef newSystemStatus As String, ByRef oldBoardStatus As String,  _
                               ByRef result As String) As Boolean
        Dim record As Guid = Nothing
        Dim oldBoardGUID As String = ""
        Dim newBoardGUID As String = ""
        Dim systemSerialCheck As String = ""
        Dim slotNumber As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim systemStatus As String = ""
        Dim boardStatus As String = ""
        Dim oldBoardType As String = ""
        Dim newBoardType As String = ""

        Try
            'Check to see if the system is already in the database.
            If FindSystemSerialNumber(myCmd, myReader, systemSerialNumber, result) = False Then
                Return False
            End If

            'Grab the GUID of the old board that will be replaced [should be in the database].
            If GetBoardGUIDBySerialNumber(myCmd, myReader, oldBoardSerialNumber, oldBoardGUID, result) = False Then
                Return False
            End If

            'Grab the GUID of the new board that will replace the old board.
            If GetBoardGUIDBySerialNumber(myCmd, myReader, newBoardSerialNumber, newBoardGUID, result) = False Then
                Return False
            Else
                'Check to make sure the new board is not a part of another system.
                If GetSystemSerialNumberByBoardGUID(myCmd, myReader, newBoardGUID, systemSerialCheck, result) = True Then
                    result = "The Replacement board is already part of another system: " & systemSerialCheck & "."
                    Return False
                End If
                'Check to make sure the board is not in the 'Rework' status.
                Dim status As String = ""
                If GetBoardCurrentStatus(myCmd, myReader, newBoardSerialNumber, status, result) = True Then
                    If String.Compare(status, BS_REWORK) = 0 Then
                        result = "Board " & newBoardSerialNumber & " stauts is 'Rework' and cannot be added to a system until fixed."
                        Return False
                    End If
                End If
            End If

            'Make sure the old board is connected to the system in the database.
            If GetSystemSerialNumberByBoardGUID(myCmd, myReader, oldBoardGUID, systemSerialCheck, result) = True Then
                If systemSerialCheck <> systemSerialNumber Then
                    result = "System serial number and old board serial number are not part of the same database entry."
                    Return False
                End If
            End If

            'Check to see if the swapping boards are of the same type or not.
            GetBoardCurrentType(myCmd, myReader, oldBoardSerialNumber, record, oldBoardType, result)
            GetBoardCurrentType(myCmd, myReader, newBoardSerialNumber, record, newBoardType, result)

            If String.Compare(oldBoardType, newBoardType) <> 0 Then
                Dim answer As Integer = MessageBox.Show("The two boards are of different types. Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
                If answer = DialogResult.No Then
                    result = "Different board types. User decided not to continue."
                    Return False
                End If
            End If

            'Get the slot where the board resides
            If GetBoardSlotNumber(myCmd, myReader, oldBoardGUID, slotNumber, result) = False Then
                Return False
            End If

            transaction = myConn.BeginTransaction("Swap Boards Transaction")
            myCmd.Transaction = transaction

            '------------------------------'
            '   U P D A T E   S Y S T E M  '
            '------------------------------'

            'Get system status from the passed in Combo Box.
            If GetSystemStatus(myCmd, myReader, newSystemStatus, systemStatus, result) = False Then
                RollBack(transaction, result)
                Return False
            End If

			'Update the system with the new board and status.
			myCmd.CommandText = "UPDATE dbo.System SET LastUpdate=GETDATE(), [" & slotNumber & "] = '" & newBoardGUID & "',[dbo.SystemStatus.id]='" & systemStatus & "' 
WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
			myCmd.ExecuteNonQuery()

            If AddSystemComment(myCmd, systemSerialNumber, "ATTENTION: Board: " & oldBoardSerialNumber & " swapped with Board: " & newBoardSerialNumber & ".",  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to this update: " & result
                Return False
            End If

            '------------------------------'
            '   U P D A T E   B O A R D S  '
            '------------------------------'

            'Update Old board status.
            If UpdateBoardStatus(myCmd, oldBoardStatus, oldBoardSerialNumber,  result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to update the board status: " & result
                Return False
            End If

            'Add comment attached to the old board.
            If AddBoardComment(myCmd, oldBoardSerialNumber, "ATTENTION: Swapped out of " & systemSerialNumber & " with Board: " & newBoardSerialNumber & ": " & issue,  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to this update: " & result
                Return False
            End If

            'Grab the status for the rest of the boards in the system.
            If String.Compare(newSystemStatus, SS_SET_PARAMETERS) <> 0 Then
                If String.Compare(newSystemStatus, SS_BOARDS_REGISTERED) = 0 Then
                    boardStatus = BS_BOARD_REGISTERED
                Else
                    boardStatus = newSystemStatus
                End If
            Else
                boardStatus = BS_NETWORK_REGISTERED
            End If

            'Update the rest of the boards.
            If UpdateSystemBoards(myCmd, boardStatus, systemSerialNumber, "ATTENTION: Board in: " & newSystemStatus & " due to board swap.",  result) = False Then
                RollBack(transaction, result)
                Return False
            End If

            'Add an additional comment to the new board being swapped in.
            If AddBoardComment(myCmd, newBoardSerialNumber, "ATTENTION: Swapped into System: " & systemSerialNumber & " replacing: " & oldBoardSerialNumber & ".",  record, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to this update: " & result
                Return False
            End If

            transaction.Commit()
            Return True
        Catch ex As Exception
            result = ex.Message
            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If
            Return False
        End Try
    End Function








'**************************************************************************************************************************************************************************
' B S G   F U N C T I O N S
'**************************************************************************************************************************************************************************





#Region "BSG"

#Region "Check"
	Public Function BSG_CheckSystemDefinition(ByRef myCmd As SqlCommand, ByRef systemTypeGUID As String, ByRef slotNumber As String, ByRef serialNumber As String) As Boolean
		Try
			Dim boardType As String = ""

			' grab the board type if we have a SNO
			If serialNumber.Length <> 0 Then
				BSG_GetBoardTypeIDByPrefix(myCmd, serialNumber, boardType, "")
			End If

			' grab any system definitions
			myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'"
			Dim dt_results As New DataTable()
			dt_results.Load(myCmd.ExecuteReader())

			' grab any mandatory definitions
			myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'AND SlotNumber = '" & slotNumber & "' AND Mandatory = '1'"
			dim dt_results_m = New DataTable()
			dt_results_m.Load(myCmd.ExecuteReader())

			' grab any optional definitions
			myCmd.CommandText = "SELECT * FROM dbo.SystemDefinition WHERE [SystemType.id] = '" & systemTypeGUID & "'AND SlotNumber = '" & slotNumber & "' AND Mandatory = '0'"
			dim dt_results_o = New DataTable()
			dt_results_o.Load(myCmd.ExecuteReader())

			' check to see if we have a definition
			If dt_results.Rows.Count = 0 and serialNumber.Length <> 0 Then
				Dim answer As Integer = MessageBox.Show("This system type does not have any system definitions." & vbCrLf & _
													"Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				If answer = DialogResult.No Then
					MsgBox("User decided not to continue. Ending Transaction.")
					Return False
				End If

			' check to see if we have mandatory and no SNO
			Else If 0 < dt_results_m.Rows.Count and serialNumber.Length = 0 Then
				Dim answer1 As Integer = MessageBox.Show("Slot " & slotNumber & " conflicts with system definition." & vbCrLf & _
												"Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				If answer1 = DialogResult.No Then
					MsgBox("User decided not to continue. Ending Transaction.")
					Return False
				End If	
			
			' check to see if we have a mandatory and SNO	
			Else If 0 < dt_results_m.Rows.Count 
				' loop thorugh all of the results we got back incase we have doubled up any board types
				For Each row As DataRow In dt_results_m.Rows
					If row("BoardType.id").ToString = boardType Then
						Return True
					End If
				Next

				' we only get here if we did not match our board type
				Dim answer2 As Integer = MessageBox.Show("Wrong required board in slot " & slotNumber & "." & vbCrLf & _
													"Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				If answer2 = DialogResult.No Then
					MsgBox("User decided not to continue. Ending Transaction.")
					Return False
				End If

			' check to see if we have an optional and SNO
			Else If 0 < dt_results_o.Rows.Count and serialNumber.Length <> 0 Then
				' loop thorugh all of the results we got back incase we have doubled up any board types
				For Each row As DataRow In dt_results_o.Rows
					If row("BoardType.id").ToString = boardType Then
						Return True
					End If
				Next
	
				' we only get here if we did not match our board type
				Dim answer3 As Integer = MessageBox.Show("Wrong required board in slot " & slotNumber & "." & vbCrLf & _
													"Do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				If answer3 = DialogResult.No Then
					MsgBox("User decided not to continue. Ending Transaction.")
					Return False
				End If

			' check to see if we have no definition but a SNO
			Else If serialNumber.Length <> 0
				Dim answer4 As Integer = MessageBox.Show("There are no deffinitions defined for this slot." & vbCrLf & _
											"Do you still want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				If answer4 = DialogResult.No Then
					MsgBox("User decided not to continue. Ending Transaction.")
					Return False
				End If

			End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

		Return True
    End Function

	Public Function BSG_CheckSystemType(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef systemType As String, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT 
[ServerModel] 
FROM dbo.SystemType 
WHERE id = 
(SELECT 
[dbo.SystemType.id] 
FROM dbo.System 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped'))"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		' check to see if we got any results back
		If dt_results.Rows.Count = 0 Then
            result = "[CheckSystemType1] System serial number '" & systemSerialNumber & "' does not exist."
			Return false
		End If

		' check to see if the column is NULL
		If dt_results.Rows(0).IsNull(0) Then
			result = "[CheckSystemType2] System Type for '" & systemSerialNumber & "' is NULL."
			Return False
		End If

		' set our current type
		Dim currentType As String = dt_results.Rows(0)("ServerModel").ToString()

        If String.Compare(currentType, systemType) <> 0 Then
            result = "[CheckSystemType5] System type does not match what is in the database. Database: " & currentType & " Machine: " & systemType
            Return False
        End If

        Return True
    End Function
#End Region
	
#Region "Find"
	Public Function BSG_FindBoardSerialNumber(ByRef myCmd As SqlCommand, ByRef boardSerialNumber As String, ByRef result As String) As Boolean
        'Check to see if the record with the passed serial number exists or not.
        myCmd.CommandText = "IF EXISTS(SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "') SELECT 1 ELSE SELECT 0"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.GetInt32(0) = 0 Then
                result = "[FindBoardSerialNumber1]  board serial number '" & boardSerialNumber & "'does not exist."
                myReader.Close()
                Return False
            End If
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_FindMACAddress(ByRef myCmd As SqlCommand, ByRef MACAddress As String, ByRef systemSerialNumber As String, _
                                   ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT SerialNumber FROM dbo.Board WHERE MACAddress = '" & MACAddress & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[FindMACAddress1] MAC Address '" & MACAddress & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindMACAddress2] MAC Address '" & MACAddress & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_FindSystemSerialNumber(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef result As String) As Boolean
		'Check to see if the record with the passed serial number exists or not.
		myCmd.CommandText = "IF EXISTS(
SELECT 
systemid 
FROM system where 
[dbo.SystemStatus.id] != (
Select id from SystemStatus where name = 'Scrapped') 
AND SerialNumber = '" & systemSerialNumber & "') SELECT 1 ELSE SELECT 0"

		Dim exist As Integer = myCmd.ExecuteScalar()

		If exist = 0 Then
			result = "[BSG_FindSystemSerialNumber1]  System serial '" & systemSerialNumber & "' number does not exist inside the database."
            myReader.Close()
            Return False
		End If
		
        Return True
    End Function
#End Region

#Region "Get"
	Public Function BSG_GetBoardCurrentStatus(ByRef myCmd As SqlCommand, ByRef boardSerialNumber As String, _
                                          ByRef stauts As String, ByRef result As String) As Boolean
        Dim systemStatusGUID As String = ""

        'First grab the GUID of the CPU Serial Board associated with the system.
        myCmd.CommandText = "SELECT [dbo.BoardStatus.id] FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetBoardCurrentStatus1] System Status for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemStatusGUID = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentStatus2] System serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        'Second grab the Version for the board with the GIUD we got from the first step.
        myCmd.CommandText = "SELECT name FROM dbo.BoardStatus WHERE id = '" & systemStatusGUID & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                stauts = ""
                myReader.Close()
                Return False
            Else
                stauts = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardCurrentStatus3] System Status does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()

        Return True
    End Function

	Public Function BSG_GetBoardGUIDBySerialNumber(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef boardGUID As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & serialNumber & "'"
        myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            'Check to see if the Reader is empty/NULL or not.
            If myReader.IsDBNull(0) Then
                boardGUID = ""
            Else
                'If not, set our string to whatever was passed back to us.
                boardGUID = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardGUIDBySerialNumber1] Board GUID '" & serialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_GetBoardGUIDBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String,
													 ByRef board As String, ByRef record As Guid, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT [" & board & ".boardid] FROM dbo.System WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"
		myReader = myCmd.ExecuteReader()
		If myReader.Read() Then
			'Check to see if the Reader is empty/NULL or not.
			If myReader.IsDBNull(0) Then
				record = Guid.Empty
			Else
				'If not, set our record GUID to whatever was passed back to us.
				record = myReader.GetGuid(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[GetBoardGUIDBySystemSerialNumber1] Board '" & board & "'/SerialNumber '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()
		Return True
	End Function

	Public Function BSG_GetBoardStatus(ByRef myCmd As SqlCommand, ByRef status As String, ByRef boardStatus As String, ByRef result As String) As Boolean
        myCmd.CommandText = "SELECT id FROM dbo.boardStatus WHERE name = '" & status & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetBoardStatus1] Board status name '" & status & "' is NULL."
                myReader.Close()
                Return False
            Else
                boardStatus = myReader.GetGuid(0).ToString
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetBoardStatus2] Board status name '" & status & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_GetBoardTypeIDByPrefix(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef boardType As String, ByRef result As String) As Boolean
		Try
			' create our prefix string. Prefix is everything before the '-' in the serial number.
			Dim prefix As String = serialNumber.Substring(0, serialNumber.IndexOf("-"))

            'Get the GUID from the newly inserted record.
            myCmd.CommandText = "SELECT id FROM dbo.BoardType WHERE BaseSerialNo = '" & prefix & "'"

			Dim dt_results As New DataTable()
			dt_results.Load(myCmd.ExecuteReader())

			If dt_results.Rows.Count = 0 Then
				result = "[BSG_GetBoardTypeByPrefix1] Board prefix '" & prefix & "' does not exist."
                Return False
			End If

			' check to see if the column is NULL
			If dt_results.Rows(0).IsNull(0) = true Then
				result = "[BSG_GetBoardTypeByPrefix2] Board perfix id for '" & prefix & "' is NULL."
				Return False
			End If

			boardType = dt_results.Rows(0)("id").ToString
        Catch ex As Exception
            result = ex.Message
            Return False
        End Try

        Return True
    End Function

	Public Function BSG_GetCPUSerialNumberBySystemSerialNumber(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef CPUSerialNumber As String, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT 
SerialNumber
FROM dbo.Board 
WHERE boardid = 
(SELECT 
[MotherBoard.boardid]
FROM dbo.System 
WHERE SerialNumber = '" & systemSerialNumber & "')"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		' check to see if we got any results back
		If dt_results.Rows.Count = 0 Then
            result = "[BSG_GetCPUSerialNumberBySystemSerialNumber1] 0 results returned."
			Return false
		End If

		' check to see if the column is NULL
		If dt_results.Rows(0).IsNull(0) = True Then
			result = "[BSG_GetCPUSerialNumberBySystemSerialNumber2] Motherboard ID number is NULL."
			Return False
		End If

		' set our current type
		CPUSerialNumber = dt_results.Rows(0)("SerialNumber").ToString()

        Return True
    End Function

	Public Function BSG_GetMACAddress(ByRef myCmd As SqlCommand, ByRef boardSerialNumber As String, ByRef MACAddress As String, _
                                  ByRef result As String) As Boolean

        myCmd.CommandText = "SELECT MACAddress FROM dbo.Board WHERE SerialNumber = '" & boardSerialNumber & "'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                result = "[GetMACAddress1] MAC Address for '" & boardSerialNumber & "' is NULL."
                myReader.Close()
                MACAddress = ""
                Return False
            Else
                MACAddress = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[GetMACAddress2] System serial number '" & boardSerialNumber & "' does not exist."
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_GetNextMACAddress(ByRef myCmd As SqlCommand, ByRef MACAddress As String) As Boolean
        myCmd.CommandText = "SELECT valuestring FROM dbo.SystemParameters WHERE id = 'MACADDR'"
        myReader = myCmd.ExecuteReader()

        If myReader.Read() Then
            'Check to see if we are returned a NULL value.
            If myReader.IsDBNull(0) Then
                myReader.Close()
                Return False
            Else
                MACAddress = myReader.GetString(0)
            End If
        Else
            myReader.Close()
            Return False
        End If
        myReader.Close()
        Return True
    End Function

	Public Function BSG_GetSystemCurrentType(ByRef systemSerialNumber As String, ByRef type As String, ByRef result As String) As Boolean
		Dim systemTypeGUID As String = ""

		'First grab the GUID of the System Type GUID associated with the system.
		Dim myCmd As New SqlCommand("SELECT 
[dbo.SystemType.id] 
FROM dbo.System 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')", myConn) 

		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				result = "[BSG_GetSystemCurrentType1] System Type for '" & systemSerialNumber & "' is NULL."
				myReader.Close()
				Return False
			Else
				systemTypeGUID = myReader.GetGuid(0).ToString
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[BSG_GetSystemCurrentType2] System serial number '" & systemSerialNumber & "' does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		'Second grab the System type for the system with the GIUD we got from the first step.
		myCmd.CommandText = "SELECT name FROM dbo.SystemType WHERE id = '" & systemTypeGUID & "'"
		myReader = myCmd.ExecuteReader()

		If myReader.Read() Then
			'Check to see if we are returned a NULL value.
			If myReader.IsDBNull(0) Then
				type = ""
				myReader.Close()
				Return False
			Else
				type = myReader.GetString(0)
			End If
		Else
			'If nothing is returned then it does not exist.
			result = "[BSG_GetSystemCurrentType3] System Type does not exist."
			myReader.Close()
			Return False
		End If
		myReader.Close()

		Return True
	End Function

	Public Function BSG_GetSystemDate(ByRef systemSerialNumber As String, ByRef dateFeild As String, ByRef dateInformation As DateTime, ByRef result As String) As Boolean
		Dim myCmd As New SqlCommand("", myConn)

		myCmd.CommandText = "SELECT 
" & dateFeild & " 
FROM dbo.System 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM 
SystemStatus 
WHERE name = 'Scrapped')"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		If dt_results.Rows.Count = 0 Then
			result = "[BSG_GetSystemDate1] Date '" & dateFeild & "'/SerialNumber '" & systemSerialNumber & "' does not exist."
			Return False
		End If

		If dt_results.Rows(0).IsNull(0) = true Then
			dateInformation = Nothing
		Else
			dateInformation = dt_results.Rows(0)(dateFeild)
		End If
		
		Return True
	End Function

	Public Function BSG_GetSystemSerialNumberByBoardGUID(ByRef myCmd As SqlCommand, ByRef boardGUID As String, _
                                                     ByRef systemSerialNumber As String, ByRef result As String) As Boolean
		'Check to see if the record with the passed serial number exists or not.
		myCmd.CommandText = "SELECT SerialNumber FROM dbo.System WHERE [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') and (
[MotherBoard.boardid] = '" & boardGUID & "' OR [MainCPU.boardid] = '" & boardGUID &
"' OR [Slot2.boardid] = '" & boardGUID & "' OR [Slot3.boardid] = '" & boardGUID & "' OR [Slot4.boardid] = '" & boardGUID &
"' OR [Slot5.boardid] = '" & boardGUID & "' OR [Slot6.boardid] = '" & boardGUID & "' OR [Slot7.boardid] = '" & boardGUID &
"' OR [Slot8.boardid] = '" & boardGUID & "' OR [Slot9.boardid] = '" & boardGUID & "' OR [Slot10.boardid] = '" & boardGUID & "')"
		myReader = myCmd.ExecuteReader()
        If myReader.Read() Then
            If myReader.IsDBNull(0) Then
                result = "[FindSystemSerialNumberByBoardGUID1] Board GUID '" & boardGUID & "' is NULL."
                myReader.Close()
                Return False
            Else
                systemSerialNumber = myReader.GetString(0)
            End If
        Else
            'If nothing is returned then it does not exist.
            result = "[FindSystemSerialNumberByBoardGUID2] Board GUID '" & boardGUID & "' does not exist."
            myReader.Close()
            Return False
        End If

        myReader.Close()
        Return True
    End Function

	Public Function BSG_GetSystemStatus(ByRef myCmd As SqlCommand, ByRef status As String, ByRef systemStatus As String, ByRef result As String) As Boolean
		myCmd.CommandText = "SELECT 
id 
FROM dbo.SystemStatus 
WHERE name = '" & status & "'"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		' check to see if we got data back
		If dt_results.Rows.Count = 0 Then
            result = "[BSG_GetSystemStatus1] System status name '" & status & "' does not exist."
            Return False
		End If

		' check to see if the column is NULL
		If dt_results.Rows(0).IsNull(0) = True Then
			result = "[BSG_GetSystemStatus2] System status name '" & status & "' is NULL."
			Return False
		End If

		systemStatus = dt_results.Rows(0)("id").ToString()

        Return True
    End Function
#End Region
	
#Region "Add"
	Public Function BSG_AddBoard(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef result As String, ByRef withSystem As Boolean, ByRef hardwareVersion As String) As Boolean
		Dim boardType As String = ""
		Dim boardPrefix As String = serialNumber.Substring(0, serialNumber.IndexOf("-"))
		Dim boardHardwareVersion As String = hardwareVersion
		Dim boardStatus As String = ""
		Dim transaction As SqlTransaction = Nothing

		'Change to findboardSNO if true then fail
		If BSG_GetBoardGUIDBySerialNumber(myCmd, serialNumber, "", result) = True Then
			result = "[AddBoard1] This board is already in the database."
			Return False
		End If

		If BSG_GetBoardTypeIDByPrefix(myCmd, serialNumber, boardType, result) = False Then
			result = "[AddBoard2] Something went wrong while trying to get a board prefix: " & result
			Return False
		End If

		Try
			' check to see if we passed in a custom hardware version or not
			If hardwareVersion.Length = 0 Then
				'Get board Hardware version
				myCmd.CommandText = "SELECT HardwareVersion FROM dbo.BoardType WHERE BaseSerialNo = '" & boardPrefix & "'"
				myReader = myCmd.ExecuteReader()
				If myReader.Read() Then
					'Check to see if we are returned a NULL value.
					If myReader.IsDBNull(0) Then
						result = "[AddBoard3] HardwareVersion for '" & boardPrefix & "' is NULL."
						myReader.Close()
						Return False
					Else
						boardHardwareVersion = myReader.GetString(0)
					End If
				Else
					'If nothing is returned then it does not exist.
					result = "[AddBoard4] HardwareVersion for '" & boardPrefix & "' does not exist."
					myReader.Close()
					Return False
				End If
				myReader.Close()
			End If

			'Get board status 'Board Registered' since we are adding the entry into the database.
			myCmd.CommandText = "SELECT id FROM dbo.BoardStatus WHERE name = '" & BS_BOARD_CHECKED & "'"
			myReader = myCmd.ExecuteReader()
			If myReader.Read() Then
				'Check to see if we are returned a NULL value.
				If myReader.IsDBNull(0) Then
					result = "[AddBoard5] Board status name '" & BS_BOARD_CHECKED & "' is NULL."
					myReader.Close()
					Return False
				Else
					boardStatus = myReader.GetGuid(0).ToString
				End If
			Else
				'If nothing is returned then it does not exist.
				result = "[AddBoard6] Board status name '" & BS_BOARD_CHECKED & "' does not exist."
				myReader.Close()
				Return False
			End If
			myReader.Close()

			If withSystem = False Then
				transaction = myConn.BeginTransaction("Add Board Transaction")
				myCmd.Connection = myConn
				myCmd.Transaction = transaction
			End If

			'Insert the board record into the board table.
			myCmd.CommandText = "INSERT INTO dbo.Board(boardid,[dbo.BoardStatus.id],[dbo.BoardType.id],SerialNumber,HardwareVersion,LastUpdate) VALUES(NEWID(),'" &
								 boardStatus & "','" & boardType & "','" & serialNumber & "','" & boardHardwareVersion & "', GETDATE())"
			myCmd.ExecuteNonQuery()

			'Create a generic comment for the new board entry.
			If BSG_AddBoardComment(myCmd, serialNumber, "Board has been added to the database.",  result) = False Then
				result = "[AddBoard7]Something went wrong while trying to add a comment to this update: " & result
				myReader.Close()
				Return False
			End If

			If withSystem = False Then
				transaction.Commit()
			End If

			Return True
		Catch ex As Exception
			result = "[AddBoard exception] " & ex.Message
			myReader.Close()
			If Not transaction Is Nothing Then
				RollBack(transaction, result)
			End If
			Return False
		End Try
	End Function

	Public Function BSG_AddBoardComment(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef comment As String, ByRef result As String) As Boolean
        Try
			Dim record As New Guid

            'Get the GUID from the passed in serial number.
            myCmd.CommandText = "SELECT boardid FROM dbo.Board WHERE SerialNumber = '" & serialNumber & "'"
            myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "[AddBoardComment1] Board serial number '" & serialNumber & "' is NULL"
                    myReader.Close()
                    Return False
                Else
                    record = myReader.GetGuid(0)
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "[AddBoardComment2] Board serial number '" & serialNumber & "' does not exist."
                myReader.Close()
                Return False
            End If
            myReader.Close()
			
            'Replace any single qoutes with double single qoutes for SQL format.
             comment = comment.Replace("'", "''")

            'Insert the comment corresponding to the serial number into the BoardAudit table form this user.
            myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                    & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            result = "[AddBoardComment exception] " & ex.Message
            myReader.Close()
            Return False
        End Try

		Return True
    End Function
	
	Public Function BSG_AddSystemComment(ByRef myCmd As SqlCommand, ByRef serialNumber As String, ByRef comment As String, ByRef result As String) As Boolean
        Try
			Dim record As New Guid

			'Get the GUID from the passed in serial number.
			myCmd.CommandText = "SELECT systemid FROM system where [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped') and SerialNumber = '" & serialNumber & "'"
			myReader = myCmd.ExecuteReader()
            If myReader.Read() Then
                'Check to see if we are returned a NULL value.
                If myReader.IsDBNull(0) Then
                    result = "[BSG_AddSystemComment1] System serial number '" & serialNumber & "' is NULL"
                    myReader.Close()
                    Return False
                Else
                    record = myReader.GetGuid(0)
                End If
            Else
                'If nothing is returned then it does not exist.
                result = "[BSG_AddSystemComment2] System serial number '" & serialNumber & "' does not exist."
                myReader.Close()
                Return False
            End If
            myReader.Close()
			
            'Replace any single qoutes with double single qoutes for SQL format.
            comment = comment.Replace("'", "''")

            'Insert the comment corresponding to the serial number into the SystemAudit table form this user.
            myCmd.CommandText = "INSERT INTO dbo.SystemAudit(id,[dbo.System.systemid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                    & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = "[BSG_AddSystemComment exception] " & ex.Message
            myReader.Close()
            Return False
        End Try
    End Function
#End Region
	
#Region "Update"
	Public Function BSG_UpdateCPUInformation(ByRef myCmd As SqlCommand, ByRef systemSerialNumber As String, ByRef result As String, ByRef obj As JSON_InfoResult, byref CPUBoardSNO As string) As Boolean
        Dim transaction As SqlTransaction = Nothing

		' show the current and the new values going into the database
		myCmd.CommandText = "SELECT 
[SoftwareVersion]
,[BootloaderVersion]
FROM Board 
WHERE SerialNumber = '" & CPUBoardSNO & "'"

		Dim dt_results As New DataTable()
		dt_results.Load(myCmd.ExecuteReader())

		Dim tempSW As String = ""
        Dim tempBL As String = ""

		If dt_results.Rows(0).IsNull("SoftwareVersion") = false Then
			tempSW = dt_results.Rows(0)("SoftwareVersion").ToString
		End If

		If dt_results.Rows(0).IsNull("BootloaderVersion") = false Then
			tempBL = dt_results.Rows(0)("BootloaderVersion").ToString
		End If

		MsgBox(String.Format("SW: {0,6} -> {1}" & vbCrLf &
							 "BL: {2,6} -> {3}", tempSW, obj.version, tempBL, obj.blversion))

		Try
			transaction = myConn.BeginTransaction("CPU Information Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

			'Create a generic comment for the new system update from the user.
            If BSG_AddSystemComment(myCmd, systemSerialNumber, "CPU information updated.", result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

			myCmd.CommandText = "SELECT 
SerialNumber 
FROM Board 
WHERE CPUID = '" & obj.cpuid & "'
AND [dbo.BoardStatus.id] != (Select 
id 
FROM 
BoardStatus 
WHERE name = 'Scrapped' 
AND SerialNumber != '" & CPUBoardSNO & "')"

			Dim resultTable As New DataTable
			resultTable.Load(myCmd.ExecuteReader)

			If resultTable.Rows.Count <> 0 Then
                result = "CPU ID: " & obj.cpuid & " already is attached to an active board: " & resultTable(0)("SerialNumber").ToString & "." & vbNewLine &
                    "Unable to update."
                RollBack(transaction, result)
                Return False
			End If

			myCmd.CommandText = "UPDATE
Board SET 
SoftwareVersion='" & obj.version & "'
,BootloaderVersion='" & obj.blversion & "'
,CPUID = '" & obj.cpuid & "' 
WHERE SerialNumber = '" & CPUBoardSNO & "'"

            myCmd.ExecuteNonQuery()

			If BSG_AddBoardComment(myCmd, CPUBoardSNO, _
                                "CPU ID: " & obj.cpuid & "." & vbCrLf & _
                                "CPU SW: " & obj.version & "." & vbCrLf & _
                                "CPU BL: " & obj.blversion & ".", result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                Return False
            End If

			myCmd.CommandText = "UPDATE 
System SET 
LastUpdate = GETDATE() 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (Select 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')"

			myCmd.ExecuteNonQuery()

            transaction.Commit()
			
        Catch ex As Exception
            result = ex.Message

            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If

            Return False
        End Try

		Return True
    End Function

	Public Function BSG_UpdateNextMACAddress(ByRef myCmd As SqlCommand, ByRef MACAddress As String, ByRef bump As Boolean, ByRef result As String) As Boolean
        Try
            If bump = True Then
                Dim TempMACAddr As String = MACAddress
                Dim HighPart As Integer = Convert.ToInt32(TempMACAddr.Substring(0, 1), 16)
                Dim LowPart As Integer = Convert.ToInt32(TempMACAddr.Substring(2), 16)

                LowPart += 1
                If LowPart >= 256 Then
                    LowPart = 0
                    HighPart += 1
                End If

                MACAddress = HighPart.ToString("x") + "-" + LowPart.ToString("x2")
            End If

            myCmd.CommandText = "UPDATE dbo.SystemParameters SET valuestring = '" & MACAddress & "' WHERE id = 'MACADDR'"
            myCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            result = "[UpdateNextMACAddress exception] " & ex.Message
            Return False
        End Try
    End Function

	Public Function BSG_UpdateSystemBoards(ByRef myCmd As SqlCommand, ByRef status As String, ByRef systemSerialNumber As String, ByRef comment As String, _
                                       ByRef result As String) As Boolean
        Dim record As Guid = Nothing
        Dim boardStatus As String = ""
        Try
            'Get board status that is passed through.
            If BSG_GetBoardStatus(myCmd, status, boardStatus, result) = False Then
                result = "[UpdateSystemBoards1] " & result
                Return False
            End If

            '---------------------------'
            '   M O T H E R B O A R D   '
            '---------------------------'

            'Grab the motherboard id associated with the passed in serial number.
            If BSG_GetBoardGUIDBySystemSerialNumber(myCmd, systemSerialNumber, "Motherboard", record, result) = False Then
                result = "[UpdateSystemBoards2] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

            '-------------------------'
            '   M A S T E R   C P U   '
            '-------------------------'

            'Grab the Main CPU id associated with the passed in serial number.
            If BSG_GetBoardGUIDBySystemSerialNumber(myCmd, systemSerialNumber, "MainCPU", record, result) = False Then
                result = "[UpdateSystemBoards3] " & result
                Return False
            End If

            If record <> Guid.Empty Then
                'Update the status.
                myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
                myCmd.ExecuteNonQuery()

                'Insert the comment.
                myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
                        & record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
                myCmd.ExecuteNonQuery()
            End If

			'----------------------'
			'   S L O T   2 - MAX_BSG_SLOTS   '
			'----------------------'

			For i = 2 To MAX_BSG_SLOTS - 1
				'Grab the board id for the slot we are dealing with using 'i' to cycle through each slot number.
				If BSG_GetBoardGUIDBySystemSerialNumber(myCmd, systemSerialNumber, "Slot" & i, record, result) = False Then
					result = "[UpdateSystemBoards4] " & result
					Return False
				End If

				'Check to see if our record got an id back or if it is empty.
				If record <> Guid.Empty Then
					'Update our board status.
					myCmd.CommandText = "UPDATE dbo.Board SET LastUpdate=GETDATE(), [dbo.BoardStatus.id]='" & boardStatus & "' WHERE boardid = '" & record.ToString & "'"
					myCmd.ExecuteNonQuery()

					'Insert the comment corresponding to the board serial number into the BoardAudit table form this user.
					myCmd.CommandText = "INSERT INTO dbo.BoardAudit(id,[dbo.Board.boardid],Comment,LastUpdate, [User]) VALUES(NEWID(), '" _
							& record.ToString() & "','" & comment & "',GETDATE(),'" & username & "')"
					myCmd.ExecuteNonQuery()
				End If
			Next i
			Return True
        Catch ex As Exception
            result = "[UpdateSystemBoards exception] " & ex.Message
            Return False
        End Try
    End Function
#End Region
	
#Region "Main Steps"
	Public Function BSG_AddSystemWithBoards(ByRef systemSerialNumber As String, ByRef boardsSerialNumbers As String(), ByRef systemType As String, ByRef result As String) As Boolean
		Dim successful        As Boolean   = True
		Dim numberOfBoards    As Integer   = 0
		Dim systemStatus      As String    = ""
		Dim existingRecord    As String    = ""
		Dim existingSystem    As String    = ""
		
		Dim boardRecordNumber As String()  = {"", "", "", "", ""}

		Dim transaction         As SqlTransaction = Nothing

		Dim myCmd As New SqlCommand("", myConn)
		

		If BSG_FindSystemSerialNumber(myCmd, systemSerialNumber, result) = True Then
			result = "Serial Number " & systemSerialNumber & " is already in the database."
			Return False
		End If

		'Get system status 'Boards Registered'.
		If BSG_GetSystemStatus(myCmd, SS_BOARDS_REGISTERED, systemStatus, result) = False Then
			Return False
		End If

		transaction = myConn.BeginTransaction("Add System Transaction")

		'Add each board that was passed in by the array and then assign each record number to our boardRecordNumber array.
		Try
			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			myCmd.Connection = myConn
			myCmd.Transaction = transaction

			'Go through each input string and add each board to the database.
			For Each serialNo In boardsSerialNumbers
				Dim boardid	As String  = ""

				' check to see if we have a serial number
				If serialNo.Length <= 0 Then
					boardRecordNumber(numberOfBoards) = "NULL"
					numberOfBoards += 1
					Continue For
				End If

				' check to see that the board exists
				If BSG_GetBoardGUIDBySerialNumber(myCmd, serialNo, existingRecord, result) = False Then
					Dim answer As Integer = MessageBox.Show("Board SNO " & serialNo & " is not in the database. Would you like to add it at this time?", "Continue?", MessageBoxButtons.YesNo)

					' check to see if our answer was no
					If answer = DialogResult.No Then
						result = "User decided not to add Board " & serialNo & ". Program will not commit."
						successful = False
						Exit For
					End If

					' try to add our board
					If BSG_AddBoard(myCmd, serialNo, result, True, "") = False Then
						result = "Could not add Board " & serialNo & ". Program will not commit."
						successful = False
						Exit For
					End If

				' check to see if the board is part of another system
				ElseIf BSG_GetSystemSerialNumberByBoardGUID(myCmd, existingRecord, existingSystem, result) = false then
					'Check to make sure the board is not in the 'Rework' or 'Shipped' status.
					Dim status As String = ""
					If BSG_GetBoardCurrentStatus(myCmd, serialNo, status, result) = True Then
						If String.Compare(status, BS_REWORK) = 0 Then
							result = "Board " & serialNo & " stauts is 'Rework' and cannot be added to a system until fixed."
							successful = False
							Exit For
						End If
						If String.Compare(status.Substring(0, 4), BS_SHIPPED) = 0 Then
							result = "Board " & serialNo & " stauts is 'Shipped' and cannot be added to a system."
							successful = False
							Exit For
						End If
						If String.Compare(status, SS_SCRAPPED) = 0 Then
							result = "Board " & serialNo & " stauts is 'Scrapped' and cannot be added to a system."
							successful = False
							Exit For
						End If
					End If

				' if the last check equates to "true" then we are in another system
				Else
					result = "Board " & serialNo & " is already part of another system: " & existingSystem & "."
					successful = False
					Exit For
				End If

				if BSG_GetBoardGUIDBySerialNumber(myCmd, serialNo, boardid, result) = False Then
					result = "Retriving " & serialNo & " board id falied: " & result & ". Tansaction will not commit."
					successful = False
					Exit For
				End If

				'Check to make sure we do not have the same board serial number in two different slots.
				For Each Str As String In boardRecordNumber
					If Str.Contains("'" & boardid & "'") = True Then
						result = "You cannot have the same board serial number in two different slots."
						successful = False
						Exit For
					End If
				Next

				boardRecordNumber(numberOfBoards) = "'" & boardid & "'"
				numberOfBoards += 1
			Next

			If successful = False Then
				result = "[AddSystemWithBoards2] Transaction was not successful: " & result
				RollBack(transaction, result)
				Return False
			End If

			' Get the highest Instance available and then add 1 to it.
			myCmd.CommandText = "if exists(select * from System where SerialNumber = '" & systemSerialNumber & "') select (MAX(Instance) + 1) from System where SerialNumber = '" & systemSerialNumber & "' else select 0"

			Dim Instance = myCmd.ExecuteScalar()

			myCmd.CommandText = "INSERT INTO dbo.System(systemid,[dbo.SystemType.id],[dbo.SystemStatus.id],SerialNumber,BarcodeDate,[MotherBoard.boardid]," &
								"[MainCPU.boardid],[Slot2.boardid],[Slot3.boardid],[Slot4.boardid],LastUpdate,Instance)" &
								"VALUES(NEWID(),'" & systemType & "','" & systemStatus & "','" & systemSerialNumber & "', GETDATE()," & boardRecordNumber(0) &
								"," & boardRecordNumber(1) & "," & boardRecordNumber(2) & "," & boardRecordNumber(3) & "," & boardRecordNumber(4) & ",GETDATE(), " & Instance & ")"

			myCmd.ExecuteNonQuery()

			'Create a generic comment for the new System entry.
			If BSG_AddSystemComment(myCmd, systemSerialNumber, "System has been added to the database.", result) = False Then
				RollBack(transaction, result)
				result = "[AddSystemWithBoards1] Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
				Return False
			End If

			'------------------------------'
			'   U P D A T E   B O A R D S  '
			'------------------------------'

			'Update each board that is associated with the passed in system serial number.
			If BSG_UpdateSystemBoards(myCmd, BS_BOARD_REGISTERED, systemSerialNumber, "Board has been registered to System " & systemSerialNumber & ".", result) = False Then
				RollBack(transaction, result)
				result = "Something went wrong while trying to update boards: " & result
				Return False
			End If

			transaction.Commit()
		Catch ex As Exception
			result = ex.Message & vbNewLine & myCmd.CommandText
			If Not transaction Is Nothing Then
				RollBack(transaction, result)
			End If
			Return False
		End Try

		Return True
	End Function

	Public Function BSG_RegisterNetwork(ByRef systemSerialNumber As String, ByRef CPUBoardSerialNo As String, ByRef MACaddress As String, ByRef oldMAC As String,  ByRef result As String) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing

		Dim myCmd As New SqlCommand("", myConn)

        Try
			'------------------------------'
			'   U P D A T E   S Y S T E M  '
			'------------------------------'

            'Get system status 'Network Registered'.
            If BSG_GetSystemStatus(myCmd, SS_NETWORK_REGISTERED, systemStatus, result) = False Then
                Return False
            End If

			myCmd.CommandText = "UPDATE 
dbo.System SET 
RegisterDate = GETDATE()
,[dbo.SystemStatus.id] = '" & systemStatus & "'
, LastUpdate = GETDATE() 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Register Network Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()

            'Create a generic comment for the new system update from the user.
            If BSG_AddSystemComment(myCmd, systemSerialNumber, "MAC changed from " & oldMAC & " to " & MACaddress & ".",  result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

            '------------------------------'
            '   U P D A T E   B O A R D S  '
            '------------------------------'

            'Update each board that is associated with the passed in system serial number.
            If BSG_UpdateSystemBoards(myCmd, BS_NETWORK_REGISTERED, systemSerialNumber, "Network has been registered.",  result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to update boards: " & result
                Return False
            End If

            myCmd.CommandText = "UPDATE dbo.Board SET MACAddress = '" & MACaddress & "' WHERE SerialNumber = '" & CPUBoardSerialNo & "'"
            myCmd.ExecuteNonQuery()

            If BSG_AddBoardComment(myCmd, CPUBoardSerialNo, "MAC changed from " & oldMAC & " to " & MACaddress & ".",  result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a new comment to Main CPU board: " & result
                Return False
            End If

            transaction.Commit()
        Catch ex As Exception
            result = ex.Message

            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If

            Return False
        End Try

		Return True
    End Function	

	Public Function BSG_SetParameters(ByRef systemSerialNumber As String, ByRef parameterFileName As String, ByRef result As String) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing

		Dim myCmd As New SqlCommand("", myConn)

		If BSG_FindSystemSerialNumber(myCmd, systemSerialNumber, result) = False Then
            Return False
        End If

		Try
            'Get system status 'Set Parameters'.
            If BSG_GetSystemStatus(myCmd, SS_SET_PARAMETERS, systemStatus, result) = False Then
                Return False
            End If

			'Update the corresponding record in the System table.
			myCmd.CommandText = "UPDATE 
dbo.System SET 
ParameterDate=GETDATE()
,ParameterFile='" & parameterFileName & "'
,[dbo.SystemStatus.id]='" & systemStatus & "'
,LastUpdate=GETDATE() 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Set Parameters Transaction")
            myCmd.Connection = myConn
            myCmd.Transaction = transaction

            myCmd.ExecuteNonQuery()
			
			'Create a generic comment for the new system update from the user.
			If BSG_AddSystemComment(myCmd, systemSerialNumber, "Parameters have been set.",  result) = False Then
				RollBack(transaction, result)
				result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
				Return False
			End If

			transaction.Commit()
        Catch ex As Exception
            result = ex.Message

            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If

            Return False
        End Try

		Return True
    End Function

	Public Function BSG_FinalCheckout(ByRef systemSerialNumber As String, ByRef checkoutFileName As String, ByRef result As String) As Boolean
        Dim systemStatus As String = ""
        Dim transaction As SqlTransaction = Nothing
        Dim registerDateTime As DateTime = Nothing
        Dim parameterDateTime As DateTime = Nothing
        Dim burnInDateTime As DateTime = Nothing
        Dim stepSkipped As Boolean = False
		Dim comment As String = "Final Checkout completed." 
		Dim checkoutComment As String = "Final checkout with checkout sheet uploaded."

		Dim myCmd As New SqlCommand("", myConn)

        If BSG_FindSystemSerialNumber(myCmd, systemSerialNumber, result) = False Then
            Return False
        End If

		BSG_GetSystemDate(systemSerialNumber, REGISTER_DATE, registerDateTime, result)
        BSG_GetSystemDate(systemSerialNumber, PARAMETER_DATE, parameterDateTime, result)
        BSG_GetSystemDate(systemSerialNumber, BURN_IN_DATE, burnInDateTime, result)

        'First check to see if we did not get any dates.
        If registerDateTime = Nothing Or parameterDateTime = Nothing Or burnInDateTime = Nothing Then
            stepSkipped = True
        End If

        'If we have found that a step was skipped, let the user know about it.
        If stepSkipped = True Then
            Dim registerDate  As String = "-----"
            Dim parameterDate As String = "-----"
            Dim burnInDate    As String = "-----"

            If registerDateTime <> Nothing Then
                registerDate = registerDateTime.ToString()
            End If
            If parameterDateTime <> Nothing Then
                parameterDate = parameterDateTime.ToString()
            End If
            If burnInDateTime <> Nothing Then
                burnInDate = burnInDateTime.ToString()
            End If

			Dim answer As Integer = MessageBox.Show("System " & systemSerialNumber & " has steps that were skipped:" & vbCrLf &
													"Register Date: " & registerDate & vbCrLf &
													"Parameter Date: " & parameterDate & vbCrLf &
													"Burn In Date: " & burnInDate & vbCrLf &
													"Do you want to continue", "Continue?", MessageBoxButtons.YesNo)
			If answer = DialogResult.No Then
                result = "User decided not to continue due to steps out of order."
                Return False
            End If
        End If

        Try
            'Get system status 'CQ Checkout'.
            If BSG_GetSystemStatus(myCmd, SS_QC_CHECKOUT, systemStatus, result) = False Then
                Return False
            End If

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
            transaction = myConn.BeginTransaction("Final Checkout Transaction")
			myCmd.Connection = myConn
            myCmd.Transaction = transaction

            'Update the corresponding record in the System table.
            If checkoutFileName.Length <> 0 Then
				myCmd.CommandText = "UPDATE 
dbo.System SET 
CheckoutDate=GETDATE()
,AttachFilename='" & checkoutFileName & "'
,[dbo.SystemStatus.id]='" & systemStatus & "'
,LastUpdate=GETDATE() 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM 
SystemStatus 
WHERE name = 'Scrapped')"

				myCmd.ExecuteNonQuery()

			Else
				myCmd.CommandText = "UPDATE 
dbo.System SET 
CheckoutDate=GETDATE()
,AttachFilename='" & username & " uploaded without PDF'
,[dbo.SystemStatus.id]='" & systemStatus & "'
,LastUpdate=GETDATE() 
WHERE SerialNumber = '" & systemSerialNumber & "' 
AND [dbo.SystemStatus.id] != (SELECT 
id 
FROM SystemStatus 
WHERE name = 'Scrapped')"

				myCmd.ExecuteNonQuery()

				' update our system comment
				checkoutcomment = "ATTENTION: Final checkout *WHITOUT* checkout sheet uploaded."
			End If

			' update out comment if we skipped steps
			If stepSkipped = True Then
				comment = "ATTENTION: Continued to Final Checkout even though steps were done out of order."
			End If
           
			If BSG_AddSystemComment(myCmd, systemSerialNumber, comment, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

			If BSG_AddSystemComment(myCmd, systemSerialNumber, checkoutcomment, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to add a comment to system " & systemSerialNumber & ": " & result
                Return False
            End If

			If BSG_UpdateSystemBoards(myCmd, BS_QC_CHECKOUT, systemSerialNumber, comment, result) = False Then
                RollBack(transaction, result)
                result = "Something went wrong while trying to update boards: " & result
                Return False
            End If

            transaction.Commit()
        Catch ex As Exception
            result = ex.Message

            If Not transaction Is Nothing Then
                RollBack(transaction, result)
            End If

            Return False
        End Try

		Return True
    End Function

	Public Function BSG_ShipAndInvoice(ByRef systemSerialNumber As String, ByRef ship As String,
								    ByRef list As List(Of String), ByRef result As String, ByRef infoDate As Date) As Boolean
		Dim systemStatus As String = ""
		Dim systemComment As String = "System has been shipped."
		Dim boardComments As String = "Board has been shipped."
		Dim transaction As SqlTransaction = Nothing
		Dim myCmd As New SqlCommand("", myConn)

		Try
			'Get system status 'Shipped'.
			If BSG_GetSystemStatus(myCmd, ship, systemStatus, result) = False Then
				Return False
			End If

			'Update the corresponding record in the System table.
			myCmd.CommandText = "UPDATE dbo.System SET ShipDate='" & infoDate & "',[dbo.SystemStatus.id]='" & systemStatus & "', 
LastUpdate=GETDATE() WHERE SerialNumber = '" & systemSerialNumber & "' and [dbo.SystemStatus.id] != (Select id from SystemStatus where name = 'Scrapped')"

			'Start our transaction. Must assign both transaction object and connection to the command object for a pending local transaction.
			transaction = myConn.BeginTransaction("Set Parameters Transaction")
			myCmd.Connection = myConn
			myCmd.Transaction = transaction

			myCmd.ExecuteNonQuery()

			Dim found = False

			'If we have chosen to continue with a skipped step, add a special comment to the audit record.
			If list.Contains(systemSerialNumber) = True Then
				systemComment = "ATTENTION: Continued to Ship even though steps were done out of order."
				boardComments = "ATTENTION: Continued to Ship even though steps were done out of order."
			End If

			'Create a generic comment for the new system update from the user.
			If BSG_AddSystemComment(myCmd, systemSerialNumber, systemComment,  result) = False Then
				RollBack(transaction, result)
				result = "Something went wrong while trying to add a comment to this update: " & result
				Return False
			End If

			'Update each board that is associated with the passed in system serial number.
			If BSG_UpdateSystemBoards(myCmd, ship, systemSerialNumber, boardComments,  result) = False Then
				RollBack(transaction, result)
				result = "Something went wrong while trying to update boards: " & result
				Return False
			End If

			transaction.Commit()
		Catch ex As Exception
			result = ex.Message

			If Not transaction Is Nothing Then
				RollBack(transaction, result)
			End If

			Return False
		End Try

		Return True
	End Function
#End Region

#End Region

End Class