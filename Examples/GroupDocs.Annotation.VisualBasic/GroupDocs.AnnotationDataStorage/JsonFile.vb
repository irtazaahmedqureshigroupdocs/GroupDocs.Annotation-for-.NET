Imports Newtonsoft.Json
Imports System.IO

Public Class JsonFile(Of T As New)
#Region "Fields"
    Protected ReadOnly _syncRoot As New Object()

    Private _filePath As String
    Private _data As T
#End Region

    Public Sub New(filePath As String)
        If [String].IsNullOrWhiteSpace(filePath) Then
            Throw New ArgumentNullException("filePath")
        End If

        _filePath = filePath
    End Sub

    Protected Overridable Sub Serialize()
        If _data Is Nothing Then
            Return
        End If

        SyncLock _syncRoot
            If _data IsNot Nothing Then
                Try
                    Using stream = File.OpenWrite(_filePath)
                        Using writer = New StreamWriter(stream)
                            Using jwriter As JsonWriter = New JsonTextWriter(writer) With { _
                                .Formatting = Formatting.Indented _
                            }
                                Dim serializer As New JsonSerializer()
                                serializer.Serialize(jwriter, _data)
                            End Using
                        End Using
                    End Using
                Catch e As Exception
                    Throw New Exception("Failed to serialize an object to file: '{0}'.", e)
                End Try
            End If
        End SyncLock
    End Sub

    Protected Overridable Sub Deserialize()
        SyncLock _syncRoot
            Try
                If Not File.Exists(_filePath) Then
                    Dim fileStream = File.Create(_filePath)
                    fileStream.Close()
                    _data = New T()
                    Return
                End If

                Using stream = File.OpenRead(_filePath)
                    Using reader = New StreamReader(stream)
                        Using jreader As JsonReader = New JsonTextReader(reader)
                            Dim serializer As New JsonSerializer()
                            _data = serializer.Deserialize(Of T)(jreader)
                        End Using
                    End Using
                End Using
            Catch e As Exception
                Throw New Exception("Failed to deserialize an object from file: '{0}'.", e)
            End Try

            If _data Is Nothing Then
                _data = New T()
            End If
        End SyncLock
    End Sub

    Protected ReadOnly Property Data() As T
        Get
            SyncLock _syncRoot
                If _data Is Nothing Then
                    Deserialize()
                End If

                Return _data
            End SyncLock
        End Get
    End Property
End Class