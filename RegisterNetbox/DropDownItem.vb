Public Class DropDownItem

    Public Sub New(ByVal id As String, ByVal name As String)
        mID = id
        mName = name
    End Sub

    Private mID As String
    Public Property ID() As String
        Get
            Return mID
        End Get
        Set(ByVal value As String)
            mID = value
        End Set
    End Property

    Private mName As String
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

End Class