'Imports Unit.Models
Imports Framework, System.Collections, System.Xml, System.Xml.Linq, System.Xml.Serialization
Imports DataLayer.Models, DataLayer.Core

Module Agile
    Sub Main()
        Dim FileController As New DataModelFileController(GetType(NationData), "D:\dev\worldatwar\")
        Dim nations As NationData = CreateMockNationsModel()

        'FileController.Save(DataModelSerializer.SerializeModelToXElement(nations))
        Dim serXMl As XElement = DataModelSerializer.SerializeModelToXElement(nations)

        Console.WriteLine(serXMl)
        Dim newNations As IDataModel = CType(DataModelSerializer.DeserializeXElementToModel(serXMl, GetType(DataLayer.Models.NationData)), DataLayer.Models.NationData)

        serXMl = DataModelSerializer.SerializeModelToXElement(newNations)
        Console.WriteLine(serXMl)

        Console.ReadKey()
        Console.Clear()

        'For Each o As String In output
        '    Console.Write(o)
        'Next

        'Console.WriteLine("press any key to continue")
        'Console.ReadKey()
        'Console.Clear()
    End Sub

    Public Function CreateMockNationsModel() As NationData
        Dim nations As New NationData
        nations.Nations.Add(New Nation With {.Id = Guid.NewGuid.ToString, .Faction = "Axis", .Name = "Germany"})
        nations.Nations.Add(New Nation With {.Id = Guid.NewGuid.ToString, .Faction = "Allied", .Name = "Axis"})

        Return nations
    End Function
End Module