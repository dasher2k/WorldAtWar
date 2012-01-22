Public Class Ally
    Implements IValidate, IData

#Region "Properties"
    Public Property Id As String
#End Region

#Region "Object Commands"
    Public Sub New()
        Me.Id = Guid.NewGuid.ToString
    End Sub

    Public Sub Create()
        Me.Id = Guid.NewGuid.ToString
    End Sub
#End Region

#Region "Xml Handler"
    Public Function GetXml() As XElement Implements IData.GetXml
        Return New XElement("ally",
                            New XAttribute("id", Me.Id)
                            )
    End Function

    Public Sub LoadFromXml(ByVal allyElement As XElement)
        Me.Id = allyElement.Attribute("id").Value
    End Sub
#End Region

    Public Function IsValid() As Boolean Implements IValidate.IsValid
        Return True
    End Function
End Class