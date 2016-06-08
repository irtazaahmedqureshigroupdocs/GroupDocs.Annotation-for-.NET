Imports GroupDocs.Annotation.Contracts
Imports GroupDocs.Annotation.Contracts.Results
Imports System.IO
Imports GroupDocs.Annotation.Data.Contracts.Repositories
Imports GroupDocs.AnnotationDataStorage

Public Class DataStorage

    ' initialize file path
    'ExStart:SourceDocFilePath
    Private Const filePath As String = "sample.pdf"
    'ExEnd:SourceDocFilePath


    ''' <summary>
    ''' Picks the annotations from document.pdf and exports them to sample.pdf
    ''' </summary>
    Public Shared Sub ExportAnnotationInFile()
        'ExStart:ExportAnnotationInFile
        Try
            ' Create instance of annotator.
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))


            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Get file stream
            Dim manifestResourceStream As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)
            Dim annotations As New List(Of AnnotationInfo)()
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' Export annotation to file stream
            Dim stream As Stream = annotator.ExportAnnotationsToDocument(document.Id, manifestResourceStream, DocumentType.Pdf)

            ' Save result stream to file.
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create)
                Dim buffer As Byte() = New Byte(stream.Length - 1) {}
                stream.Seek(0, SeekOrigin.Begin)
                stream.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
            End Using
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:ExportAnnotationInFile
    End Sub



    ''' <summary>
    ''' Creates a document data object in the storage
    ''' </summary>
    Public Shared Sub CreateDocument()
        'ExStart:CreateDocument
        Try
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))


            Console.WriteLine("Document ID : " + documentId)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:CreateDocument
    End Sub



    ''' <summary>
    ''' Assigns/sets document access rights
    ''' </summary>
    Public Shared Sub AssignAccessRights()
        'ExStart:AssignAccessRight
        Try
            ' Creat path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))


            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Set document access rights    
            annotator.SetDocumentAccessRights(documentId, AnnotationReviewerRights.All)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AssignAccessRight
    End Sub



    ''' <summary>
    ''' Maps annotations and creates dcocument data object in the storage 
    ''' </summary>
    Public Shared Sub CreateAndGetAnnotation()
        'ExStarT:CreateAndGetAnnotation
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 81.0), _
                 .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                 .Type = AnnotationType.Point, _
                 .PageNumber = 0, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            ' Add annotation to storage
            Dim createPointAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(pointAnnotation)

            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 201.0), _
                 .FieldText = "text in the box", _
                 .FontFamily = "Arial", _
                 .FontSize = 10, _
                 .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                 .PageNumber = 0, _
                 .Type = AnnotationType.TextField, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Get annotation from storage
            GetAnnotationResult result = annotator.GetAnnotation(createPointAnnotationResult.Guid)

        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:CreateAndGetAnnotation
    End Sub



    ''' <summary>
    ''' Gets annotations from the storage file
    ''' </summary>
    ''' <returns>Returns a list of annotations</returns>
    Public Shared Function GetAllDocumentAnnotation() As ListAnnotationsResult
        'ExStart:GetAllAnnotation
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Get annotation from storage
            Dim result As ListAnnotationsResult = annotator.GetAnnotations(documentId)

            Return result
        Catch exp As Exception
            Console.WriteLine(exp.Message)
            Return Nothing
        End Try
        'ExEnd:GetAllAnnotation
    End Function



    ''' <summary>
    ''' Resizes the existing annotations
    ''' </summary>
    Public Shared Sub ResizeAnnotationResult()
        'ExStart:ResizeAnnotationResult
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim areaAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 271.7), _
                 .BackgroundColor = 3355443, _
                 .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                 .PageNumber = 0, _
                 .PenColor = 3355443, _
                 .Type = AnnotationType.Area, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createAreaAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(areaAnnotation)

            'Resize annotation
            Dim resizeResult As ResizeAnnotationResult = annotator.ResizeAnnotation(createAreaAnnotationResult.Id, New AnnotationSizeInfo() With { _
                 .Height = 80, _
                 .Width = 60 _
            })
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:ResizeAnnotationResult
    End Sub



    ''' <summary>
    ''' Moves annotation marker
    ''' </summary>
    Public Shared Sub MoveAnnotationResult()
        'ExStart:MoveAnnotationResult
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim areaAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 271.7), _
                 .BackgroundColor = 3355443, _
                 .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                 .PageNumber = 0, _
                 .PenColor = 3355443, _
                 .Type = AnnotationType.Area, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createAreaAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(areaAnnotation)

            'Move annotation marker
            'NewPageNumber
            Dim moveAnnotationResult__1 As MoveAnnotationResult = annotator.MoveAnnotationMarker(createAreaAnnotationResult.Id, New Point(200, 200), 1)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:MoveAnnotationResult
    End Sub


    ''' <summary>
    ''' Sets background color of annotation
    ''' </summary>
    Public Shared Sub SetBackgroundColorResult()
        'ExStart:SetBackgroundColorResult
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 201.0), _
                 .FieldText = "text in the box", _
                 .FontFamily = "Arial", _
                 .FontSize = 10, _
                 .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                 .PageNumber = 0, _
                 .Type = AnnotationType.TextField, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Set background color of annotation
            Dim setBackgroundColorResult__1 As SaveAnnotationTextResult = annotator.SetAnnotationBackgroundColor(createTextFieldAnnotationResult.Id, 16711680)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:SetBackgroundColorResult
    End Sub



    ''' <summary>
    ''' Updates the text in the annotation
    ''' </summary>
    Public Shared Sub EditTextFieldAnnotation()
        'ExStart:EditTextFieldAnnotation
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 201.0), _
                 .FieldText = "text in the box", _
                 .FontFamily = "Arial", _
                 .FontSize = 10, _
                 .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                 .PageNumber = 0, _
                 .Type = AnnotationType.TextField, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Update text in the annotation
            Dim saveTextFieldResult As SaveAnnotationTextResult = annotator.SaveTextField(createTextFieldAnnotationResult.Id, New TextFieldInfo() With { _
                 .FieldText = "new text", _
                 .FontFamily = "Colibri", _
                 .FontSize = 12 _
            })


            ' Set text field color
            Dim saveTextFieldColorResult As SaveAnnotationTextResult = annotator.SetTextFieldColor(createTextFieldAnnotationResult.Id, 16753920)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:EditTextFieldAnnotation
    End Sub



    ''' <summary>
    ''' Removes annotations
    ''' </summary>
    Public Shared Sub RemoveAnnotation()
        'ExStart:RemoveAnnotation
        Try
            ' Create path finder 
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), New DocumentRepository(pathFinder), New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 81.0), _
                 .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                 .Type = AnnotationType.Point, _
                 .PageNumber = 0, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            ' Add annotation to storage
            CreateAnnotationResult createPointAnnotationResult = annotator.CreateAnnotation(pointAnnotation);

            ' Get all annotations from storage
            ListAnnotationsResult listAnnotationsResult = annotator.GetAnnotations(documentId);

            ' Get annotation  
            var annotation = annotator.GetAnnotation(listAnnotationsResult.Annotations[0].Guid);


            ' Delete single annotation
            var deleteAnnotationResult = annotator.DeleteAnnotation(annotation.Id);

            'Delete all annotations
            annotator.DeleteAnnotations(documentId)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:RemoveAnnotation
    End Sub



    ''' <summary>
    ''' Adds reply to the annotation, edits reply, creates child reply
    ''' </summary>
    Public Shared Sub AddAnnotationReply()
        'ExStart:AddAnnotationReply
        Try
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(New UserRepository(pathFinder), documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create document data object in storage
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 81.0), _
                 .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                 .Type = AnnotationType.Point, _
                 .PageNumber = 0, _
                 .CreatorName = "Usman Aziz", _
                 .DocumentGuid = documentId _
            }

            ' Add annotation to storage
            Dim createPointAnnotationResult = annotator.CreateAnnotation(pointAnnotation)

            ' Add simple reply to created annotation
            Dim addSimpleReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "first question")

            ' Edit created reply
            Dim editReplyResult = annotator.EditAnnotationReply(addSimpleReplyResult.ReplyGuid, "changed question")

            ' Create child reply. This reply will be linked to previously created reply.
            Dim addChildReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "answer", addSimpleReplyResult.ReplyGuid)

            ' Delete annotation reply by guid
            Dim deleteReplyResult = annotator.DeleteAnnotationReply(addChildReplyResult.ReplyGuid)

            ' Delete all replies from annotation
            annotator.DeleteAnnotationReplies(createPointAnnotationResult.Id)

            ' List of replies after deleting all replies
            Dim listRepliesResultAfterDeleteAll = annotator.ListAnnotationReplies(createPointAnnotationResult.Id)
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
        'ExEnd:AddAnnotationReply
    End Sub

    ''' <summary>
    ''' Adds document collaborator 
    ''' </summary>
    Public Shared Sub AddCollaborator()
        Try
            'ExStart:AddCollaborator
            ' Create repository path finder
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim userRepository = New UserRepository(pathFinder)

            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(userRepository, documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
			userRepository.Add(New User() With { _
				Key .FirstName = "John", _
				Key .LastName = "Doe", _
				Key .Email = "john@doe.com" _
			})
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
		Dim reviewerInfo = New ReviewerInfo() With { _
			Key .PrimaryEmail = "judy@doe.com", _
			Key .FirstName = "Judy", _
			Key .LastName = "Doe", _
			Key .AccessRights = AnnotationReviewerRights.All _
		}

            ' Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
            Dim addCollaboratorResult = annotator.AddCollaborator(documentId, reviewerInfo)
            'ExEnd:AddCollaborator  
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets document collaborator 
    ''' </summary>
    Public Shared Sub GetCollaborator()
        Try
            'ExStart:GetCollaborator
            ' Create repository path finder
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim userRepository = New UserRepository(pathFinder)

            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(userRepository, documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
			userRepository.Add(New User() With { _
				Key .FirstName = "John", _
				Key .LastName = "Doe", _
				Key .Email = "john@doe.com" _
			})
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
		Dim reviewerInfo = New ReviewerInfo() With { _
			Key .PrimaryEmail = "judy@doe.com", _
			Key .FirstName = "Judy", _
			Key .LastName = "Doe", _
			Key .AccessRights = AnnotationReviewerRights.All _
		}

            ' Get document collaborators.
            Dim getCollaboratorsResult = annotator.GetCollaborators(documentId)

            ' Get document collaborator by email
            Dim getCollaboratorsResultByEmail = annotator.GetDocumentCollaborator(documentId, reviewerInfo.PrimaryEmail)

            ' Get collaborator metadata 
            Dim user = userRepository.GetUserByEmail(reviewerInfo.PrimaryEmail)               
            Dim collaboratorMetadataResult As ReviewerInfo = annotator.GetCollaboratorMetadata(user.Guid)
            'ExEnd:GetCollaborator 
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Updates document collaborator 
    ''' </summary>
    Public Shared Sub UpdateCollaborator()
        Try
            'ExStart:UpdateCollaborator
            ' Create repository path finder
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim userRepository = New UserRepository(pathFinder)

            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(userRepository, documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
			userRepository.Add(New User() With { _
				Key .FirstName = "John", _
				Key .LastName = "Doe", _
				Key .Email = "john@doe.com" _
			})
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
		Dim reviewerInfo = New ReviewerInfo() With { _
			Key .PrimaryEmail = "judy@doe.com", _
			Key .FirstName = "Judy", _
			Key .LastName = "Doe", _
			Key .AccessRights = AnnotationReviewerRights.All _
		}
            ' Update collaborator. Only color and access rights will be updated.
            reviewerInfo.Color = 3355443        
            Dim updateCollaboratorResult = annotator.UpdateCollaborator(documentId, reviewerInfo)
            'ExEnd:UpdateCollaborator    
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Deletes document collaborator 
    ''' </summary>
    Public Shared Sub DeleteCollaborator()
        Try
            'ExStart:DeleteCollaborator
            ' Create repository path finder
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()
            Dim userRepository = New UserRepository(pathFinder)

            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(userRepository, documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
			userRepository.Add(New User() With { _
				Key .FirstName = "John", _
				Key .LastName = "Doe", _
				Key .Email = "john@doe.com" _
			})
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
		Dim reviewerInfo = New ReviewerInfo() With { _
			Key .PrimaryEmail = "judy@doe.com", _
			Key .FirstName = "Judy", _
			Key .LastName = "Doe", _
			Key .AccessRights = AnnotationReviewerRights.All _
		}

            ' Delete collaborator
            Dim deleteCollaboratorResult = annotator.DeleteCollaborator(documentId, reviewerInfo.PrimaryEmail)
            'ExEnd:DeleteCollaborator
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Manages collaborator rights 
    ''' </summary>
    Public Shared Sub ManageCollaboratorRights()
        Try
            'ExStart:ManageCollaboratorRights
            Dim pathFinder As IRepositoryPathFinder = New RepositoryPathFinder()

            Dim userRepository = New UserRepository(pathFinder)
            Dim documentRepository = New DocumentRepository(pathFinder)

            ' Create instance of annotator
            Dim annotator As IAnnotator = New Annotator(userRepository, documentRepository, New AnnotationRepository(pathFinder), New AnnotationReplyRepository(pathFinder), New AnnotationCollaboratorRepository(pathFinder))

            ' Create owner. 
            Dim johnOwner = userRepository.GetUserByEmail("john@doe.com")
            If johnOwner Is Nothing Then
			userRepository.Add(New User() With { _
				Key .FirstName = "John", _
				Key .LastName = "Doe", _
				Key .Email = "john@doe.com" _
			})
                johnOwner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Create document data object in storage
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, johnOwner.Id))

            ' Create reviewer. 

            ' Can only get view annotations
		Dim reviewerInfo = New ReviewerInfo() With { _
			Key .PrimaryEmail = "judy@doe.com", _
			Key .FirstName = "Judy", _
			Key .LastName = "Doe", _
			Key .AccessRights = AnnotationReviewerRights.CanView _
		}

            ' Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
            Dim addCollaboratorResult = annotator.AddCollaborator(documentId, reviewerInfo)

            ' Get document collaborators
            Dim getCollaboratorsResult = annotator.GetCollaborators(documentId)
            Dim judy = userRepository.GetUserByEmail("judy@doe.com")

            ' Create annotation object
		Dim pointAnnotation As New AnnotationInfo() With { _
			Key .AnnotationPosition = New Point(852.0, 81.0), _
			Key .Box = New Rectangle(212F, 81F, 142F, 0F), _
			Key .Type = AnnotationType.Point, _
			Key .PageNumber = 0, _
			Key .CreatorName = "Anonym A." _
		}

            ' John try to add annotations. User is owner of the document.
            Dim johnResult = annotator.CreateAnnotation(pointAnnotation, documentId, johnOwner.Id)

            ' Judy try to add annotations
            Try
                Dim judyResult = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id)

                'Get exceptions, because user can only view annotations
            Catch e As AnnotatorException
                Console.Write(e.Message)
                Console.ReadKey()
            End Try

            ' Allow Judy create annotations.
            reviewerInfo.AccessRights = AnnotationReviewerRights.CanAnnotate
            Dim updateCollaboratorResult = annotator.UpdateCollaborator(documentId, reviewerInfo)

            ' Now user can add annotations
            Dim judyResultCanAnnotate = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id)
            'ExEnd:ManageCollaboratorRights
        Catch exp As Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub
End Class
