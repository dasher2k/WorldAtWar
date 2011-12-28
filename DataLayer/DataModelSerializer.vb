Imports System.Xml, System.Xml.Linq, System.Xml.Serialization
Imports DataLayer.Models

Public Class DataModelSerializer
    Public Shared Function SerializeModelToXElement(ByVal dataModel As IDataModel) As XElement
        Dim dataModelXmlDocument As New XDocument()
        Dim dataModelXmlSerializer As XmlSerializer

        dataModelXmlSerializer = GetXmlSerializerWithType(dataModel.GetType())
        dataModelXmlDocument = GetSerializedXmlDocument(dataModel, dataModelXmlSerializer)

        Return dataModelXmlDocument.Root
    End Function

    Public Shared Function DeserializeXElementToModel(ByVal ModelXElement As XElement, ByVal ModelType As Type) As IDataModel
        Dim dataModelXmlDocument As New XDocument()
        Dim dataModelXmlSerializer As XmlSerializer = GetXmlSerializerWithType(ModelType)

        dataModelXmlDocument.Add(ModelXElement)

        Return CType(dataModelXmlSerializer.Deserialize(dataModelXmlDocument.CreateReader()), IDataModel)
    End Function

    Private Shared Function GetXmlSerializerWithType(ByVal objectType As Type) As XmlSerializer
        Return New XmlSerializer(objectType)
    End Function

    Private Shared Function GetSerializedXmlDocument(ByVal dataModel As IDataModel, ByVal xmlSerializer As XmlSerializer) As XDocument
        Dim xmlDocument As New XDocument()

        Using xmlWriter As XmlWriter = xmlDocument.CreateWriter()
            xmlSerializer.Serialize(xmlWriter, dataModel)
        End Using

        Return xmlDocument
    End Function
End Class