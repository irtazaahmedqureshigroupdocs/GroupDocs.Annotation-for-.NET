Imports GroupDocs.Annotation.Contracts
Imports System.IO

Public Class Annotations

    ' initialize file path
    'ExStart:SourceDocFilePath
    Private Const filePath As String = "sample.pdf"
    'ExEnd:SourceDocFilePath 
    ''' <summary>
    ''' Adds text annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextAnnotation()
        'ExStart:AddTextAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Initialize text annotation.
            Dim textAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(265.44), CSng(153.86), 206, 36), _
                .PageNumber = 0, _
                .SvgPath = "[{""x"":265.44,""y"":388.83},{""x"":472.19,""y"":388.83},{""x"": 265.44,""y"":349.14},{""x"":472.19,""y"":349.14}]", _
                .Type = AnnotationType.Text, _
                .CreatorName = "Anonym A." _
            }

            ' Add annotation to list
            annotations.Add(textAnnotation)

            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddTextAnnotation
    End Sub 
    ''' <summary>
    ''' Adds area annotation with replies in PDF document
    ''' </summary>
    Public Shared Sub AddAreaAnnotationWithReplies()
        'ExStart:AddAreaAnnotationWithReplies
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Area annotation with 2 replies
            Dim areaAnnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 59.0), _
                  .Replies = New AnnotationReplyInfo() {New AnnotationReplyInfo() With { _
                      .Message = "Hello!", _
                      .RepliedOn = DateTime.Now, _
                      .UserName = "John" _
                }, New AnnotationReplyInfo() With { _
                      .Message = "Hi!", _
                      .RepliedOn = DateTime.Now, _
                      .UserName = "Judy" _
                }}, _
                  .BackgroundColor = 11111111, _
                  .Box = New Rectangle(300.0F, 200.0F, 88.0F, 37.0F), _
                  .PageNumber = 0, _
                  .PenColor = 2222222, _
                  .PenStyle = 1, _
                  .PenWidth = 1, _
                  .Type = AnnotationType.Area, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(areaAnnnotation)

            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddAreaAnnotationWithReplies
    End Sub 
    ''' <summary>
    ''' Adds point annotation in PDF document
    ''' </summary>
    Public Shared Sub AddPointAnnotation()
        'ExStart:AddPointAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Point annotation
            Dim pointAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 81.0), _
                  .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                  .PageNumber = 0, _
                  .Type = AnnotationType.Point, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(pointAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddPointAnnotation
    End Sub 
    ''' <summary>
    ''' Adds text strikeout annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextStrikeOutAnnotation()
        'ExStart:AddTextStrikeOutAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text strikeout annotation
            Dim strikeoutAnnotation As New AnnotationInfo() With { _
                  .Box = New Rectangle(CSng(101.76), CSng(688.73), CSng(321.85), 27), _
                  .PageNumber = 1, _
                  .SvgPath = "[{""x"":101.76,""y"":400.05},{""x"":255.9,""y"":400.05},{""x"":101.76,""y"":378.42},{""x"":255.91,""y"":378.42},{""x"":101.76,""y"":374.13},{""x"":423.61,""y"":374.13},{""x"":101.76,""y"":352.5},{""x"":423.61,""y"":352.5}]", _
                  .Type = AnnotationType.TextStrikeout, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(strikeoutAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddTextStrikeOutAnnotation
    End Sub 
    ''' <summary>
    ''' Adds polyline annotation in PDF document
    ''' </summary>
    Public Shared Sub AddPolylineAnnotation()
        'ExStart:AddPolylineAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Polyline annotation
            Dim polylineAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 35.0), _
                  .Box = New Rectangle(250.0F, 35.0F, 102.0F, 12.0F), _
                  .PageNumber = 0, _
                  .PenColor = 1201033, _
                  .PenWidth = 2, _
                  .SvgPath = "M250.8280751173709,48.209295774647885l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l1.3973708920187793,-0.6986854460093896l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l2.096056338028169,-1.3973708920187793l3.493427230046948,-1.3973708920187793l0.6986854460093896,-0.6986854460093896l1.3973708920187793,-1.3973708920187793l0.6986854460093896,0l1.3973708920187793,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l0,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0,-0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.096056338028169,-0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l1.3973708920187793,0l2.096056338028169,0l5.589483568075117,0l1.3973708920187793,0l2.096056338028169,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l2.096056338028169,1.3973708920187793l0.6986854460093896,0l0.6986854460093896,0l0,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0.6986854460093896l0,0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0.6986854460093896l1.3973708920187793,0.6986854460093896l3.493427230046948,0.6986854460093896l1.3973708920187793,0.6986854460093896l2.096056338028169,0.6986854460093896l1.3973708920187793,0.6986854460093896l1.3973708920187793,0l1.3973708920187793,0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.7947417840375586,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0", _
                  .Type = AnnotationType.Polyline, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(polylineAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddPolylineAnnotation
    End Sub 
    ''' <summary>
    ''' Adds text field annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextFieldAnnotation()
        'ExStart:AddTextFieldAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text field annotation
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 201.0), _
                  .FieldText = "text in the box", _
                  .FontFamily = "Arial", _
                  .FontSize = 10, _
                  .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                  .PageNumber = 0, _
                  .Type = AnnotationType.TextField, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textFieldAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddTextFieldAnnotation
    End Sub 
    ''' <summary>
    ''' Adds watermark annotation in PDF document
    ''' </summary>
    Public Shared Sub AddWatermarkAnnotation()
        'ExStart: AddWatermarkAnnotation()
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Watermark annotation
            Dim watermarkAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(100.0, 300.0), _
                  .FieldText = "TEXT STAMP", _
                  .FontFamily = "Microsoft Sans Serif", _
                  .FontSize = 10, _
                  .FontColor = 2222222, _
                  .Box = New Rectangle(430.0F, 272.0F, 66.0F, 51.0F), _
                  .PageNumber = 0, _
                  .Type = AnnotationType.Watermark, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(watermarkAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddWatermarkAnnotation
    End Sub 
    ''' <summary>
    ''' Adds text replacement annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextReplacementAnnotation()
        'ExStart:AddTextReplacementAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text replacement annotation
            Dim textReplacementAnnotation As New AnnotationInfo() With { _
                  .Box = New Rectangle(CSng(101.76), CSng(826.73), CSng(229), 27), _
                  .PageNumber = 1, _
                  .SvgPath = "[{""x"":101.76,""y"":264.69},{""x"":331,""y"":264.69},{""x"":101.76,""y"":243.06},{""x"":331,""y"":243}]", _
                  .Type = AnnotationType.TextReplacement, _
                  .CreatorName = "Anonym A.", _
                  .FieldText = "Replaced text", _
                  .FontSize = 10 _
            }
            ' Add annotation to list
            annotations.Add(textReplacementAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddTextReplacementAnnotation
    End Sub 
    ''' <summary>
    ''' Adds arrow annotation in PDF document
    ''' </summary>
    Public Shared Sub AddArrowAnnotation()
        'ExStart:AddArrowAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Arrow annotation
            Dim arrowAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 252.0), _
                  .Box = New Rectangle(279.4742F, 252.9241F, 129.9555F, -9.781596F), _
                  .PageNumber = 0, _
                  .PenColor = 1201033, _
                  .PenStyle = 0, _
                  .PenWidth = 1, _
                  .SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455", _
                  .Type = AnnotationType.Arrow, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(arrowAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddArrowAnnotation
    End Sub 
    ''' <summary>
    ''' Adds text redaction annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextRedactionAnnotation()
        'ExStart:AddTextRedactionAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text redaction annotation
            Dim textRedactionAnnotation As New AnnotationInfo() With { _
                  .Box = New Rectangle(CSng(448.56), CSng(212.4), 210, 27), _
                  .PageNumber = 0, _
                  .SvgPath = "[{""x"":448.56,""y"":326.5},{""x"":658.7,""y"":326.5},{""x"":448.56,""y"":302.43},{""x"":658.7,""y"":302.43}]", _
                  .Type = AnnotationType.TextRedaction, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textRedactionAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddTextRedactionAnnotation
    End Sub 
    ''' <summary>
    ''' Adds underline annotation in PDF document
    ''' </summary>
    Public Shared Sub AddUnderLineAnnotation()
        'ExStart:AddUnderLineAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Underline annotation
            Dim underlineAnnotation As New AnnotationInfo() With { _
                  .Box = New Rectangle(CSng(248.57), CSng(1135.78), CSng(222.67), 27), _
                  .PageNumber = 1, _
                  .SvgPath = "[{""x"":248.57,""y"":503.507},{""x"":471,""y"":503.507},{""x"":248.57,""y"":468.9},{""x"":471,""y"":468.9}]", _
                  .Type = AnnotationType.TextUnderline, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(underlineAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddUnderLineAnnotation
    End Sub  
    ''' <summary>
    ''' Adds distance annotation in PDF document
    ''' </summary>
    Public Shared Sub AddDistanceAnnotation()
        'ExStart:AddDistanceAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Distance annotation
            Dim distanceAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 287.0), _
                  .Box = New Rectangle(248.0F, 287.0F, 115.0F, 25.0F), _
                  .PageNumber = 0, _
                  .PenColor = 1201033, _
                  .PenStyle = 0, _
                  .PenWidth = 1, _
                  .SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338", _
                  .Text = vbCr & vbLf & "Anonym A.: 115px", _
                  .Type = AnnotationType.Distance, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(distanceAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddDistanceAnnotation
    End Sub 
    ''' <summary>
    ''' Adds resource redaction annotation in PDF document
    ''' </summary>
    Public Shared Sub AddResourceRedactionAnnotation()
        'ExStart:AddResourceRedactionAnnotation
        Try
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Resource redaction annotation
            Dim resourceRedactionAnnotation As New AnnotationInfo() With { _
                  .AnnotationPosition = New Point(852.0, 271.78), _
                  .BackgroundColor = 3355443, _
                  .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                  .PageNumber = 0, _
                  .PenColor = 3355443, _
                  .Type = AnnotationType.ResourcesRedaction, _
                  .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(resourceRedactionAnnotation)
            ' Export annotation and save output file
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddResourceRedactionAnnotation
    End Sub 
    ''' <summary>
    ''' Removes all annotations in PDF document
    ''' </summary>
    Public Shared Sub RemoveAllAnnotationsFromDocument()
        'ExStart:RemoveAllAnnotationsFromDocument
        Try
            ' Initialize annotator
            Dim annotator As IAnnotator = New Annotator()

            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Get output file stream
            Dim result As Stream = annotator.RemoveAnnotationStream(inputFile, DocumentType.Pdf)

            ' Save result stream to file.
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create)
                Dim buffer As Byte() = New Byte(result.Length - 1) {}
                result.Seek(0, SeekOrigin.Begin)
                result.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
            End Using
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:RemoveAllAnnotationsFromDocument
    End Sub
End Class
