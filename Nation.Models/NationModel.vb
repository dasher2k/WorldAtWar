Imports Core.BaseClasses

Public Class NationModel
    Inherits ModelBase

    Property Name As String
    Property Faction As String
    Property Allies As IEnumerable(Of Object)
End Class
