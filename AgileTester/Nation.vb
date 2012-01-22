Imports System.Linq

Public Class Nation
    Implements IValidate, IData

#Region "Properties"
    Public Property Id As String
    Public Property Name As String
    Public Property Faction As FactionType
    Public Property Allies As New Allies
#End Region

#Region "Object Commands"
    Public Sub New()
        Me.Id = Guid.NewGuid.ToString
    End Sub

    Public Sub Clear()
        Me.Name = ""
        Me.Faction = FactionType.Null
        Me.Allies.AllyList.Clear()
    End Sub
#End Region

#Region "Xml Handler"
    Public Function GetXml() As XElement Implements IData.GetXml
        Return New XElement("nation",
                                    New XAttribute("id", Me.Id),
                                    New XAttribute("name", Me.Name),
                                    New XAttribute("faction", Me.Faction.ToString),
                                    Me.Allies.GetXml
                                    )
    End Function

    Public Sub LoadFromXml(ByVal nationElement As XElement)
        Dim alliesElement As XElement

        alliesElement = (From a In nationElement.Descendants("allies") Select a).SingleOrDefault

        Me.Id = nationElement.Attribute("id").Value
        Me.Name = nationElement.Attribute("name").Value
        Me.Faction = CType([Enum].Parse(GetType(FactionType), nationElement.Attribute("faction").Value.ToString), FactionType)

        If Not alliesElement Is Nothing Then
            Me.Allies.LoadFromXml(alliesElement)
        End If
    End Sub
#End Region

    Public Function IsValid() As Boolean Implements IValidate.IsValid
        If Faction = FactionType.Null Or Name.Length = 0 Then
            Return False
        End If

        Return True
    End Function
End Class