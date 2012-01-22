Imports System.Collections.ObjectModel

Public Class Allies

#Region "Properties"
    Public Property AllyList As New ObservableCollection(Of Ally)
#End Region

#Region "Object Commands"
    Public Sub Clear()
        Me.AllyList.Clear()
    End Sub

    Public Sub AddAlly(ByVal ally As Ally)
        Me.AllyList.Add(ally)
    End Sub

    Public Sub RemoveAlly(ByVal ally As Ally)
        Me.AllyList.Remove(ally)
    End Sub
#End Region

#Region "Xml Handler"
    Public Function GetXml() As XElement
        If Me.AllyList.Count = 0 Then
            Return Nothing
        End If

        Return New XElement("allies",
                             (From n As Ally In Me.AllyList
                             Select (n.GetXml)))
    End Function

    Public Sub LoadFromXml(ByVal alliesElement As XElement)
        For Each allyElement As XElement In (From a In alliesElement.Descendants("ally")
                                             Select a)
            Dim ally As New Ally
            ally.LoadFromXml(allyElement)
            Me.AddAlly(ally)
        Next
    End Sub
#End Region

    Public Function IsValid() As Boolean
        Return True
    End Function
End Class
