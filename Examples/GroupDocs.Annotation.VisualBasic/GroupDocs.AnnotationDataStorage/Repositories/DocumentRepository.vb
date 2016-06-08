Imports GroupDocs.Annotation.Data.Contracts.DataObjects
Imports GroupDocs.Annotation.Data.Contracts.Repositories


Public Class DocumentRepository
    Inherits JsonRepository(Of Document)
    Implements IDocumentRepository
    Private Const _repoName As String = "GroupDocs.annotation.documents.json"

    Public Sub New(pathFinder As IRepositoryPathFinder)
        MyBase.New(pathFinder.Find(_repoName))
    End Sub

    Public Sub New(filePath As String)
        MyBase.New(filePath)
    End Sub

    Public Function GetDocument(name As String) As Document Implements IDocumentRepository.GetDocument
        SyncLock _syncRoot
            Try
                Return Data.Find(Function(x) x.Name = name)
            Catch e As Exception
                Throw New DataJsonException("Failed to get document by id.", e)
            End Try
        End SyncLock
    End Function
End Class

