Imports System.Xml.Serialization

Public Class Agile
    Sub New()

    End Sub
End Class

Public Class NationData
    Implements IDataModel

    <XmlElement("Nations", GetType(Nations))>
    Public Property nation As Nations
End Class

<XmlRoot(ElementName:="Nations")>
Public Class Nations
    <XmlElement("Nation", GetType(Nation))>
    Public Property Nations As New List(Of Nation)

    Public Sub AddNation(ByVal nation As Nation)
        Nations.Add(nation)
    End Sub
End Class

<XmlRoot(ElementName:="Nation")>
Public Class Nation
    <XmlAttributeAttribute(datatype:="string")>
    Public Property Id As String

    <XmlAttributeAttribute(datatype:="string")>
    Public Property Name As String

    <XmlAttributeAttribute(datatype:="string")>
    Public Property Faction As String

    <XmlArray("Allies")> <XmlArrayItem("Ally", GetType(Ally))>
    Public Property Allies As List(Of Ally)

    Public Sub AddAlly(ByVal ally As Ally)
        Allies.Add(ally)
    End Sub

    Public Function GetXml() As XElement
        Dim xml As XElement = New XElement("")

        Return xml
    End Function
End Class

<XmlRoot(elementname:="Ally")>
Public Class Ally
    <XmlAttributeAttribute()>
    Public Property Id As String
End Class
'Public Class Agile

'End Class

'Public Class NationModel
'    Public Property Id As String
'    Public Property Name As String
'    Public Property Faction As String
'    Public Property Allies As List(Of AllyModel)

'    Public Sub New()

'    End Sub

'    Public Function GetXml() As XElement
'        Dim xEle As XElement = New XElement("Nation",
'              New XAttribute("CustomerID", Id),
'              New XElement("CompanyName", Name),
'              New XElement("ContactName", Faction),
'              New XElement("Allies",
'                           From a As AllyModel In Allies
'                           Select New XElement("Allies", a.GetXml()
'                           )))

'        Return xEle
'    End Function
'End Class

'Public Class AllyModel
'    Public Property Id As String

'    Public Sub New()

'    End Sub

'    Public Function GetXml() As XElement
'        Dim xEle As XElement = New XElement("Ally",
'                                            New XElement("Id", Id))

'        Return xEle
'    End Function
'End Class