Imports GroupDocs.Annotation.Contracts
Imports System.IO

'ExStart:CommonUtilities
Public Class CommonUtilities

    'ExStart:CommonProperties
    Private Const SourceFolderPath As String = "../../../../../Data/Samples/"
    Private Const DestinationFolderPath As String = "../../../../../Data/Output/"
    Private Const LicenseFilePath As String = "Groupdocs.Annotation.lic"
    'ExEnd:CommonProperties

    'ExStart:MapSourceFilePath
    ''' <summary>
    ''' Maps source file path
    ''' </summary>
    ''' <param name="SourceFileName">Source File Name</param>
    ''' <returns>Returns complete path of source file</returns>
    Public Shared Function MapSourceFilePath(SourceFileName As String) As String
        Try
            Return SourceFolderPath & SourceFileName
        Catch exp As Exception
            Console.WriteLine(exp.Message)
            Return exp.Message
        End Try
    End Function
    'ExEnd:MapSourceFilePath
    'ExStart:MapDestinationFilePath
    ''' <summary>
    ''' Maps destination file path
    ''' </summary>
    ''' <param name="DestinationFileName">Destination File Name</param>
    ''' <returns>Returns complete path of destination file</returns>
    Public Shared Function MapDestinationFilePath(DestinationFileName As String) As String
        Try
            Return DestinationFolderPath & DestinationFileName
        Catch exp As Exception
            Console.WriteLine(exp.Message)
            Return exp.Message
        End Try
    End Function
    'ExEnd:MapDestinationFilePath

    ''' <summary>
    ''' Saves output document
    ''' </summary>
    Public Shared Sub SaveOutputDocument(inputFile As Stream, annotations As List(Of AnnotationInfo), type As DocumentType)
        Try
            'ExStart:SaveOutputDocument
            Dim annotator As IAnnotator = New Annotator()
            Dim result As Stream = annotator.ExportAnnotationsToDocument(inputFile, annotations, DocumentType.Pdf)

            ' Save result stream to file.
            Using fileStream As New FileStream(MapDestinationFilePath("Annotated.pdf"), FileMode.Create)
                Dim buffer As Byte() = New Byte(result.Length - 1) {}
                result.Seek(0, SeekOrigin.Begin)
                result.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
                'ExEnd:SaveOutputDocument
            End Using
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    'ExStart:ApplyLicense
    ''' <summary>
    ''' Applies product license
    ''' </summary>
    Public Shared Sub ApplyLicense()
        Try
            ' initialize License
            Dim lic As New License()
            ' apply license
            lic.SetLicense(LicenseFilePath)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub
    'ExEnd:ApplyLicense

End Class
'ExEnd:CommonUtilities