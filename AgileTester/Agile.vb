'Imports Unit.Models
'Imports Framework, System.Collections, System.Xml, System.Xml.Linq, System.Xml.Serialization
'Imports DataLayer.Models, DataLayer.Core

Module Agile
    Sub Main()
        Dim nations As New Nations
        Dim nation As Nation
        Dim xmlstring As String = ""

        nation = New Nation
        nation.Name = "Germany"
        nation.Faction = FactionType.Axis
        nations.AddNation(nation)

        nation = New Nation
        nation.Name = "Japan"
        nation.Faction = FactionType.Axis
        nations.AddNation(nation)

        nation = New Nation
        nation.Name = "Uk"
        nation.Faction = FactionType.Allied
        nations.AddNation(nation)

        nation = New Nation
        nation.Name = "Russia"
        nation.Faction = FactionType.Allied
        nations.AddNation(nation)

        nation = New Nation
        nation.Name = "United States"
        nation.Faction = FactionType.Allied
        nation.Allies.AddAlly(New Ally With {.Id = Guid.NewGuid.ToString})
        nation.Allies.AddAlly(New Ally With {.Id = Guid.NewGuid.ToString})
        nation.Allies.AddAlly(New Ally With {.Id = Guid.NewGuid.ToString})
        nation.Allies.AddAlly(New Ally With {.Id = Guid.NewGuid.ToString})
        nation.Allies.AddAlly(New Ally With {.Id = Guid.NewGuid.ToString})
        nations.AddNation(nation)

        xmlstring = nations.GetXml.ToString

        nations = New Nations
        nations.LoadFromXml(XElement.Parse(xmlstring))
        xmlstring = nations.GetXml.ToString()

        'Dim emptyNations As New Nations
        'xmlstring = emptyNations.GetXml.ToString

        Console.WriteLine(xmlstring)
        Console.ReadKey()

        'Dim nations As New Nations
        'Dim nation As New Nation
        'Dim Allies As New List(Of Ally)

        'Allies.Add(New Ally With {.Id = Guid.NewGuid.ToString()})
        'Allies.Add(New Ally With {.Id = Guid.NewGuid.ToString()})

        'nation.Id = Guid.NewGuid.ToString()
        'nation.Name = "Germany"
        'nation.Faction = "Allies"
        'nation.Allies = Allies

        'nations.AddNation(nation)

        'Dim x As New NationData
        'x.nation = nations

        'Console.Write(DataLayer.Core.DataModelSerializer.SerializeModelToXElement(CType(x, NationData)))
        'Console.ReadKey()
        'Console.Clear()
        'Dim FileController As New DataModelFileController(GetType(NationData), "D:\dev\worldatwar\")
        'Dim nations As NationData = CreateMockNationsModel()

        ''FileController.Save(DataModelSerializer.SerializeModelToXElement(nations))
        'Dim serXMl As XElement = DataModelSerializer.SerializeModelToXElement(nations)

        'Console.WriteLine(serXMl)
        'Dim newNations As IDataModel = CType(DataModelSerializer.DeserializeXElementToModel(serXMl, GetType(DataLayer.Models.NationData)), DataLayer.Models.NationData)

        'serXMl = DataModelSerializer.SerializeModelToXElement(newNations)
        'Console.WriteLine(serXMl)

        'Console.ReadKey()
        'Console.Clear()

        'For Each o As String In output
        '    Console.Write(o)
        'Next

        'Console.WriteLine("press any key to continue")
        'Console.ReadKey()
        'Console.Clear()
    End Sub

    'Public Function CreateMockNationsModel() As NationData
    '    Dim nations As New NationData
    '    'nations.Nations.Add(New Nation With {.Id = Guid.NewGuid.ToString, .Faction = "Axis", .Name = "Germany"})
    '    'nations.Nations.Add(New Nation With {.Id = Guid.NewGuid.ToString, .Faction = "Allied", .Name = "Axis"})

    '    Return nations
    'End Function
End Module