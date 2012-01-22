Imports System.Collections.ObjectModel

Public Class Nations
#Region "Properties"
    Public Property NationList As New ObservableCollection(Of Nation)
#End Region

#Region "Object Commands"
    Public Sub Clear()
        Me.NationList.Clear()
    End Sub

    Public Sub AddNation(ByVal nation As Nation)
        Me.NationList.Add(nation)
    End Sub

    Public Sub RemoveNaiton(ByVal nation As Nation)
        Me.NationList.Remove(nation)
    End Sub
#End Region

#Region "Xml Handler"
    Public Function GetXml() As XElement
        Return New XElement("Nations",
                             (From n As Nation In Me.NationList
                             Select (n.GetXml)))
    End Function

    Public Sub LoadFromXml(ByVal nationsElement As XElement)
        For Each nationElement As XElement In (From n In nationsElement.Descendants("nation")
                                             Select n)
            Dim nation As New Nation
            nation.LoadFromXml(nationElement)
            Me.AddNation(nation)
        Next
    End Sub
#End Region

    Public Function IsValid() As Boolean
        Return True
    End Function
End Class