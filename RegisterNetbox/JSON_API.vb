Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Reflection

'Machine Information response structure.
Public Class JSON_InfoResult
    Public cpuid As String
    Public model As String
    Public version As String
    Public serial As String
    Public cpuserial As String
    Public ioversion As String
    Public blversion As String
    Public macaddress As String
End Class

Public Class JSON_API

    Public Function GetMachineInfo(ByRef IPAddress As String, ByRef WebResponse As String) As Boolean
        Dim justURI As New Uri("http://" & IPAddress)
		Dim uri     As New Uri("http://" & IPAddress & "/process_json?name=machineinfo.json")

        Dim retval  As Boolean

        retval = DoRequest(uri, justURI, "belleville", WebResponse)
        If retval = False Then
            retval = DoRequest(uri, justURI, "aquametrix", WebResponse)
		End If
		If retval = False Then
            uri = New Uri("http://" & IPAddress & "/run_json?action=systeminfo.json")

			retval = DoRequest(uri, justURI, "clearblue", WebResponse)
		End If
        Return retval
    End Function

	Public Function GetSerialNumberFromIP(ByRef IPAddress As String, ByRef SerialNo As String) As Boolean
        Dim WebResponse As String = ""

        If GetMachineInfo(IPAddress, WebResponse) Then
            Dim obj
            Try
                obj = JsonConvert.DeserializeObject(Of JSON_InfoResult)(WebResponse)
                SerialNo = obj.serial
            Catch
                MsgBox("Could not convert JSON result string")
                Return False
            End Try
        Else
            MsgBox("Could not communicate to server: " & IPAddress & vbNewLine & WebResponse)
            Return False
        End If
        Return True
    End Function

    Public Function GetRemoteParameters(ByRef IPAddress As String, ByRef WebResponse As String) As Boolean
        Dim justURI As New Uri("http://" & IPAddress)
		Dim uri     As New Uri("http://" & IPAddress & "/process_json?name=getparameters.json")

        Dim retval  As Integer

        retval = DoRequest(uri, justURI, "belleville", WebResponse)
        If retval = False Then
            retval = DoRequest(uri, justURI, "aquametrix", WebResponse)
		End If
		If retval = False Then
            uri = New Uri("http://" & IPAddress & "/run_json?action=getparameters.json")

			retval = DoRequest(uri, justURI, "clearblue", WebResponse)
		End If

        If Not retval Then
            MsgBox("Could not connect to " & IPAddress & vbNewLine & WebResponse)
        End If

        Return retval
    End Function

    Public Function SetMachineInfo(ByRef IPAddress As String, ByRef MACAddr As String, ByRef SerialNo As String, ByRef CPUSerialNo As String, ByRef WebResponse As String) As Boolean
        Dim uriJSON   As String = "process_json?name=machineinfo.json"
		Dim uriValues As String = "&macaddr=" & MACAddr & "&serialno=" & SerialNo & "&cpuserialno=" & CPUSerialNo
		Dim justURI   As New Uri("http://" & IPAddress)
        Dim uri       As New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

        Dim retval As Boolean

        retval = DoRequest(uri, justURI, "belleville", WebResponse)
        If retval = False Then
            retval = DoRequest(uri, justURI, "aquametrix", WebResponse)
		End If
		If retval = False Then
			uriJSON = "/run_json?action=systeminfo.json"
            uri = New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

			retval = DoRequest(uri, justURI, "clearblue", WebResponse)
		End If

        If Not retval Then
            MsgBox("Could not connect to " & IPAddress & vbNewLine & WebResponse)
        End If

        Return retval
    End Function

	Public Function SetParametersRequest(ByRef IPAddress As String, ByRef baseObj As Object, ByRef cpuid As String, ByRef results As ListBox, ByRef WebResponse As String) As Boolean
        Dim uriJSON   As String = "process_json?name=setparameters.json"
		Dim uriValues As String = ""
		Dim justURI   As New Uri("http://" & IPAddress)
        

        If baseObj Is Nothing Then
            MsgBox("Must perform Get Parameters first")
            Return False
        End If

        Dim basetyp As Type = baseObj.GetType()
        Dim basefields As FieldInfo() = basetyp.GetFields

        ' This must be there to guarantee we're talking to the correct box
        uriValues &= "&cpuid=" & cpuid

        ' Build up list of parameter options ("name"=value)
        For Each basefield In basefields
            If basefield.Name.Equals("value__") Then Continue For
            If IsNothing(basefield.GetValue(baseObj)) Then Continue For

            uriValues &= "&" & basefield.Name & "=" & basefield.GetValue(baseObj).ToString()
        Next

        ' Make it into a uri type
        Dim uri       As New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

        Dim retval As Integer

        retval = DoRequest(uri, justURI, "belleville", WebResponse)
        If retval = False Then
            retval = DoRequest(uri, justURI, "aquametrix", WebResponse)
		End If
		If retval = False Then
			uriJSON = "/run_json?action=setparameters.json"
            uri = New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

			retval = DoRequest(uri, justURI, "clearblue", WebResponse)
		End If

        If Not retval Then
            MsgBox("Could not connect to " & IPAddress & vbNewLine & WebResponse)
            Return False
        End If

        Dim SetCount As Integer = 0
        Dim objRes
        Try
            objRes = JsonConvert.DeserializeObject(Of JSON_Set_Results)(WebResponse)
        Catch ex As Exception
            MsgBox("Could not convert JSON result string: " & ex.ToString())
            Return False
        End Try
        If Not IsNothing(objRes) Then
            SetCount = objRes.changed
        End If

        results.Items.Add(SetCount.ToString() & " Parameters Set")
        Return True
    End Function

	Public Function RemoteReboot(ByRef IPAddress As String, ByRef WebResponse As String) As Boolean
		Dim uriJSON   As String = "process_json?name=restart.json"
		Dim uriValues As String = "&restart=yes"
		Dim justURI   As New Uri("http://" & IPAddress)
        Dim uri       As New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

        Dim retval As Boolean

        retval = DoRequest(uri, justURI, "belleville", WebResponse)
        If retval = False Then
            retval = DoRequest(uri, justURI, "aquametrix", WebResponse)
		End If
		If retval = False Then
			uriJSON = "/run_json?action=restart.json"
            uri = New Uri("http://" & IPAddress & "/" & uriJSON & uriValues)

			retval = DoRequest(uri, justURI, "clearblue", WebResponse)
		End If

        If Not retval Then
            MsgBox("Could not connect to " & IPAddress & vbNewLine & WebResponse)
        End If

		Return retval
    End Function

    Public Function DoRequest(ByRef URI As Uri, ByRef justURI As Uri, ByRef password As String, ByRef WebResponse As String) As Boolean
        Dim request As HttpWebRequest = WebRequest.Create(URI)
		request.ContentType = "application/json"
        request.Method = "GET"
        request.AllowAutoRedirect = False
        request.KeepAlive = True
        request.Timeout = 500
        request.ReadWriteTimeout = 500
        request.Accept = "application/json"
        request.Proxy = Nothing

        Dim credentialCache As CredentialCache = New CredentialCache()
		Dim netCredential As NetworkCredential = New NetworkCredential("admin", password)

		credentialCache.Add(justURI, "Digest", netCredential)
        request.Credentials = credentialCache

        Try
            Using response As WebResponse = request.GetResponse()

                Dim dataStream As Stream = response.GetResponseStream()
                Dim encode As Encoding = Encoding.GetEncoding("utf-8")
                Dim readStream As New StreamReader(dataStream, encode)
                Dim read(2048) As [Char]
                ' Read up to 512 charcters 
                Dim count As Integer = readStream.Read(read, 0, 2048)

                readStream.Close()
                response.Close()

                ' Convert into string from an array of Chars
                Dim str As New [String](read, 0, count)

                WebResponse = str
            End Using

        Catch e As WebException
			WebResponse &= "Web exception: " & e.Message & vbNewLine
            If (e.Status = WebExceptionStatus.ProtocolError) Then
				WebResponse &= "Status code: " & CType(e.Response, HttpWebResponse).StatusCode & vbNewLine & "Description: " & CType(e.Response, HttpWebResponse).StatusDescription & vbNewLine
            End If
            Return False
        Catch ex As Exception
			WebResponse &= "Exception: " & ex.Message & vbNewLine
            Return False
		End Try

		Return True
	End Function

End Class