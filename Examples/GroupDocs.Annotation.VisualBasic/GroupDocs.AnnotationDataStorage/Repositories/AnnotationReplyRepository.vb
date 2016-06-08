Imports GroupDocs.Annotation.Data.Contracts.DataObjects
Imports System.IO
Imports GroupDocs.Annotation.Data.Contracts.Repositories

Public Class AnnotationReplyRepository
    Inherits JsonRepository(Of AnnotationReply)
    Implements IAnnotationReplyRepository

    Private Const _repoName As String = "GroupDocs.annotation.replies.json"

    Public Sub New(pathFinder As IRepositoryPathFinder)
        MyBase.New(pathFinder.Find(_repoName))
    End Sub

    Public Sub New(filePath As String)
        MyBase.New(filePath)
    End Sub

    Public Function GetReply(guid As String) As AnnotationReply Implements IAnnotationReplyRepository.GetReply
        SyncLock _syncRoot
            Try
                Return Data.FirstOrDefault(Function(x) x.Guid = guid)
            Catch e As Exception
                Throw New DataJsonException("Failed to get annotation reply by GUID.", e)
            End Try
        End SyncLock
    End Function

    Public Function GetReplies(annotationId As Long) As AnnotationReply() Implements IAnnotationReplyRepository.GetReplies
        SyncLock _syncRoot
            Try
                Return Data.Where(Function(x) x.AnnotationId = annotationId).OrderBy(Function(r) r.RepliedOn).ToArray()
            Catch e As Exception
                Throw New DataJsonException("Failed to get annotation replies.", e)
            End Try
        End SyncLock
    End Function

    Public Function DeleteReplyAndChildReplies(replyId As Long) As Boolean Implements IAnnotationReplyRepository.DeleteReplyAndChildReplies
        SyncLock _syncRoot
            Try
                Dim data = Me.Data
                Dim returnValue As Boolean = True

                Dim reply As AnnotationReply = data.FirstOrDefault(Function(r) r.Id = replyId)
                Dim childReplies As New List(Of AnnotationReply)()
                Dim repliesOfCurrentLevel As AnnotationReply() = data.Where(Function(r) r.ParentReplyId = replyId).ToArray()
                Dim repliesOfNextLevel As New List(Of AnnotationReply)()

                While repliesOfCurrentLevel.Length > 0
                    repliesOfNextLevel.Clear()
                    childReplies.AddRange(repliesOfCurrentLevel)

                    For i As Integer = 0 To repliesOfCurrentLevel.Length - 1
                        Dim id As Decimal = repliesOfCurrentLevel(i).Id
                        repliesOfNextLevel.AddRange(data.Where(Function(r) r.ParentReplyId = id).ToArray())
                    Next

                    repliesOfCurrentLevel = repliesOfNextLevel.ToArray()
                End While

                childReplies.Reverse()
                childReplies.ForEach(Function(x) returnValue = returnValue And MyBase.Remove(x))

                returnValue = returnValue And MyBase.Remove(reply)
                Return returnValue
            Catch e As Exception
                Throw New DataJsonException("Failed to delete annotation replies.", e)
            End Try
        End SyncLock
    End Function

End Class
