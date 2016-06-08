Imports GroupDocs.Annotation.Data.Contracts.Repositories
Imports GroupDocs.Annotation.Data.Contracts.DataObjects

Public Class AnnotationCollaboratorRepository
    Inherits JsonRepository(Of AnnotationCollaborator)
    Implements IAnnotationCollaboratorRepository
    Private Const _repoName As String = "GroupDocs.annotation.collaborators.json"

    Public Sub New(pathFinder As IRepositoryPathFinder)
        MyBase.New(pathFinder.Find(_repoName))
    End Sub

    Public Sub New(filePath As String)
        MyBase.New(filePath)
    End Sub

    Public Function GetDocumentCollaborators(documentId As Long) As AnnotationCollaborator() Implements IAnnotationCollaboratorRepository.GetDocumentCollaborators
        SyncLock _syncRoot
            Try
                Return Data.Where(Function(x) x.DocumentId = documentId).ToArray()
            Catch e As Exception
                Throw New DataJsonException("Failed to get document collaborators.", e)
            End Try
        End SyncLock
    End Function
End Class
