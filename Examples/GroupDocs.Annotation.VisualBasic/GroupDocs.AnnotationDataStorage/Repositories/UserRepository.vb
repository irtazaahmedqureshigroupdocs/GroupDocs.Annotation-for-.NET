Imports GroupDocs.Annotation.Data.Contracts.Repositories
Imports GroupDocs.Annotation.Data.Contracts.DataObjects

Public Class UserRepository
    Inherits JsonRepository(Of User)
    Implements IUserRepository
    Private Const _repoName As String = "GroupDocs.users.json"

    Public Sub New(pathFinder As IRepositoryPathFinder)
        MyBase.New(pathFinder.Find(_repoName))
    End Sub
    Public Function GetUserByGuid(guid As String) As User Implements IUserRepository.GetUserByGuid
        SyncLock _syncRoot
            Try
                Return Data.Find(Function(x) x.Guid = guid)
            Catch e As Exception
                Throw New DataJsonException("Failed to get user by GUID.", e)
            End Try
        End SyncLock
    End Function

    Public Function GetUserByEmail(email As String) As User Implements IUserRepository.GetUserByEmail
        SyncLock _syncRoot
            Try
                Return Data.Find(Function(x) x.Email = email)
            Catch e As Exception
                Throw New DataJsonException("Failed to get user by name.", e)
            End Try
        End SyncLock
    End Function
End Class

