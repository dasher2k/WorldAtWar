Imports DataLayer.Models

Public Class DataModelFileController
    Private dataModelType As Type
    Private directoryPath As String
    Private backupDirectoryPath As String
    Private fileName As String


    Public Sub New(ByVal dataModelType As Type, ByVal directoryPath As String)
        Me.dataModelType = dataModelType
        Me.directoryPath = directoryPath
        Me.backupDirectoryPath = directoryPath + "/backup/"
        Me.fileName = GetFileName()
    End Sub


    Public Sub Save(ByVal xElement As XElement)
        Dim xDocument As XDocument

        xDocument = New XDocument(
           New XDeclaration("1.0", "utf-8", "yes"),
            xElement)

        BackupPreviousFile()

        xDocument.Save(Me.directoryPath + Me.fileName)
    End Sub


    Public Function ReadFile() As XElement
        Dim xDocument As XDocument

        xDocument = xDocument.Load(Me.directoryPath + Me.fileName)

        Return xDocument.Root
    End Function


    Private Function GetFileName() As String
        Dim fileName As String = ""

        Select Case Me.dataModelType
            'Case GetType(Abilities)
            '                fileName = "Abilities.xml"
            Case GetType(NationData)
                fileName = "Nations.xml"
                'Case Core.DataSetType.Platoon
                '    fileName = "Platoons.xml"
                'Case Core.DataSetType.Unit
                '    fileName = "Units.xml"
            Case Else
                Throw New ApplicationException("No filename set for dataset type.")
        End Select

        Return fileName
    End Function


    Private Sub BackupPreviousFile()
        Dim backupDirectoryPath As String

        backupDirectoryPath = Me.directoryPath + "/backup/"

        DeletePreviousBackUp()

        SaveBackUpFile()
    End Sub


    Private Sub DeletePreviousBackUp()
        If IO.File.Exists(Me.backupDirectoryPath + Me.fileName) Then
            IO.File.Delete(Me.backupDirectoryPath + Me.fileName)
        End If
    End Sub


    Private Sub SaveBackUpFile()
        CreateBackUpDirectory()

        If IO.File.Exists(Me.directoryPath + Me.fileName) Then
            IO.File.Copy(Me.directoryPath + Me.fileName, Me.backupDirectoryPath + Me.fileName)
        End If
    End Sub


    Private Sub CreateBackUpDirectory()
        If Not IO.Directory.Exists(Me.backupDirectoryPath) Then
            IO.Directory.CreateDirectory(Me.backupDirectoryPath)
        End If
    End Sub


    Private Sub DeleteFile()

    End Sub

    Private Sub RestoreFile()

    End Sub
    'Dim DataSetPath As String

    'Public Sub New(ByVal _DataSetPath As String)
    '    DataSetPath = _DataSetPath
    'End Sub

    'Public Function DoesPathExist() As Boolean
    '    Return IO.Directory.Exists(DataSetPath)
    'End Function

    'Public Function GetPlatoonFilePath() As String
    '    Return DataSetPath + "current/platoon.dat"
    'End Function

    'Public Function GetNationFilePath() As String
    '    Return DataSetPath + "current/nation.dat"
    'End Function

    'Public Function GetUnitFilePath() As String
    '    Return DataSetPath + "current/unit.dat"
    'End Function
End Class

'Public Enum DataSetType
'    Nation
'    Platoon
'    Unit
'    Ability
'End Enum