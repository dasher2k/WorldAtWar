Imports System.Xml, System.Linq

Public Class NationData
    Dim NationFilePath As String

    Public Sub New(ByVal FilePath As String)
        NationFilePath = FilePath
    End Sub

    Public Sub Create()

    End Sub

    Public Sub Read()
        Dim xDocument As XDocument = xDocument.Load(NationFilePath)
        'IO.File.Open(NationFilePath)
    End Sub

    Public Sub Update()

    End Sub

    Public Sub Delete()

    End Sub
End Class
