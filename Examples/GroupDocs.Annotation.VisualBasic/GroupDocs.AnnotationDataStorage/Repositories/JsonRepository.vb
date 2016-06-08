Imports GroupDocs.Annotation.Data.Contracts

Public Class JsonRepository(Of TEntity As {Class, IEntity})
    Inherits JsonFile(Of List(Of TEntity))
    Implements IRepository(Of TEntity)
#Region "Fields"
    Private Shared ReadOnly _entityName As String = GetType(TEntity).Name
#End Region

    Public Sub New(filePath As String)
        MyBase.New(filePath)
    End Sub

    Public Sub Commit() Implements IRepository(Of TEntity).Commit
        Serialize()
    End Sub

    Public Sub Refresh(entity As TEntity) Implements IRepository(Of TEntity).Refresh
        Deserialize()
    End Sub

    Public Function Add(entity As TEntity) As Boolean Implements IRepository(Of TEntity).Add
        SyncLock _syncRoot
            Try
                Dim data = Me.Data

                entity.Id = GetNextId()
                data.Add(entity)

                Commit()
                Return True
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to add entity: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function Remove(entity As TEntity) As Boolean Implements IRepository(Of TEntity).Remove
        SyncLock _syncRoot
            Try
                Data.RemoveAll(Function(e) e.Id = entity.Id)
                Commit()

                Return True
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to remove entity: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function Update(entity As TEntity) As Boolean Implements IRepository(Of TEntity).Update
        SyncLock _syncRoot
            Try
                Dim data = Me.Data
                Dim index = data.FindIndex(Function(x) x.Id = entity.Id)

                If index >= 0 Then
                    data(index) = entity
                    Commit()

                    Return True
                End If

                Return False
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to update entity: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function Add(entities As IEnumerable(Of TEntity)) As Boolean Implements IRepository(Of TEntity).Add
        SyncLock _syncRoot
            Try
                Data.AddRange(entities)
                Commit()

                Return True
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to add entities: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function Remove(entities As IEnumerable(Of TEntity)) As Boolean Implements IRepository(Of TEntity).Remove
        SyncLock _syncRoot
            Try
                Dim data = Me.Data

                For Each e As TEntity In entities
                    data.Remove(e)
                Next

                Commit()
                Return True
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to remove entities: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function Update(entities As IEnumerable(Of TEntity)) As Boolean Implements IRepository(Of TEntity).Update
        SyncLock _syncRoot
            Try
                Dim data = Me.Data

                For Each e As TEntity In entities
                    Dim index = data.FindIndex(Function(x) x.Id = e.Id)
                    If index >= 0 Then
                        data(index) = e
                    End If
                Next

                Commit()
                Return True
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to update entities: {0}", _entityName), e)
            End Try
        End SyncLock
    End Function

    Public Function [Get](id As Decimal) As TEntity
        SyncLock _syncRoot
            Try
                Return Data.Find(Function(e) e.Id = id)
            Catch e As Exception
                Throw New DataJsonException([String].Format("Unable to get entity: ID = {0}", id), e)
            End Try
        End SyncLock
    End Function

    Public Function [Get](id As Long) As TEntity Implements IRepository(Of TEntity).[Get]
        Return [Get](CDec(id))
    End Function

    Protected Overridable Function GetNextId(Optional increment As Integer = 1) As Long
        Dim data__1 = Data
        Dim lastId = (If(data__1.Any(), data__1.Max(Function(e) e.Id), 0L))
        Return (lastId + increment)
    End Function

#Region "Private members"
#End Region
End Class

