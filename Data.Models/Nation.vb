Public Class Nation
    Implements IDataModel
    Public Property Id As String
    Public Property Name As String
    Public Property Faction As String
    Public Property Allies As List(Of Ally)
End Class