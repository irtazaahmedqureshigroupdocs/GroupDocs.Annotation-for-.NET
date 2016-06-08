using GroupDocs.Annotation.Contracts;
using GroupDocs.Annotation.Contracts.Results;
using GroupDocs.Annotation.Data.Contracts.DataObjects;
using GroupDocs.Data.Json;
using GroupDocs.Data.Json.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    //ExStart:DataStorageClass
    public class DataStorage
    {


        //ExStart:SourceDocFilePath
        // initialize file path
        private const string filePath = "sample.pdf";
        //ExEnd:SourceDocFilePath

        /// <summary>
        /// Picks the annotations from document.pdf and exports them to sample.pdf
        /// </summary>
        public static void ExportAnnotationInFile()
        {
            try
            {
                //ExStart:ExportAnnotationInFile
                // Create instance of annotator.
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));


                var documentRepository = new DocumentRepository(pathFinder);

                // Get file stream
                Stream manifestResourceStream = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Get document
                var document = documentRepository.GetDocument("Document.pdf");

                Stream stream = annotator.ExportAnnotationsToDocument(document.Id, manifestResourceStream, DocumentType.Pdf);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:ExportAnnotationInFile
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Creates a document data object in the storage
        /// </summary>
        public static void CreateDocument()
        {
            try
            {
                //ExStart:CreateDocument
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                Console.WriteLine("Document ID : " + documentId);
                //ExEnd:CreateDocument

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Assigns/sets document access rights
        /// </summary>
        public static void AssignAccessRights()
        {
            try
            {
                //ExStart:AssignAccessRight
                // Creat path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));


                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Set document access rights    
                annotator.SetDocumentAccessRights(documentId, AnnotationReviewerRights.All);
                //ExEnd:AssignAccessRight
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Maps annotations and creates dcocument data object in the storage 
        /// </summary>
        public static void CreateAndGetAnnotation()
        {
            try
            {
                //ExStart:CreateAndGetAnnotation
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo pointAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    Type = AnnotationType.Point,
                    PageNumber = 0,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                // Add annotation to storage
                CreateAnnotationResult createPointAnnotationResult = annotator.CreateAnnotation(pointAnnotation);

                //=============================================================================
                // Create annotation object
                AnnotationInfo textFieldAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                //Add annotation to storage
                CreateAnnotationResult createTextFieldAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation);

                // Get annotation from storage
                GetAnnotationResult result = annotator.GetAnnotation(createPointAnnotationResult.Guid);
                //ExEnd:CreateAndGetAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Gets annotations from the storage file
        /// </summary>
        /// <returns>Returns a list of annotations</returns>
        public static ListAnnotationsResult GetAllDocumentAnnotation()
        {
            try
            {
                //ExStart:GetAllAnnotation
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Get annotation from storage
                ListAnnotationsResult result = annotator.GetAnnotations(documentId);

                return result;
                //ExEnd:GetAllAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return null;
            }
        }

        /// <summary>
        /// Resizes the existing annotations
        /// </summary>
        public static void ResizeAnnotationResult()
        {
            try
            {
                //ExStart:ResizeAnnotationResult
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo areaAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 271.7),
                    BackgroundColor = 3355443,
                    Box = new Rectangle(466f, 271f, 69f, 62f),
                    PageNumber = 0,
                    PenColor = 3355443,
                    Type = AnnotationType.Area,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                //Add annotation to storage
                CreateAnnotationResult createAreaAnnotationResult = annotator.CreateAnnotation(areaAnnotation);

                //Resize annotation
                ResizeAnnotationResult resizeResult = annotator.ResizeAnnotation(createAreaAnnotationResult.Id, new AnnotationSizeInfo
                {
                    Height = 80,
                    Width = 60
                });
                //ExEnd:ResizeAnnotationResult
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Moves annotation marker
        /// </summary>
        public static void MoveAnnotationResult()
        {
            try
            {
                //ExStart:MoveAnnotationResult
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo areaAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 271.7),
                    BackgroundColor = 3355443,
                    Box = new Rectangle(466f, 271f, 69f, 62f),
                    PageNumber = 0,
                    PenColor = 3355443,
                    Type = AnnotationType.Area,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                //Add annotation to storage
                CreateAnnotationResult createAreaAnnotationResult = annotator.CreateAnnotation(areaAnnotation);

                //Move annotation marker
                MoveAnnotationResult moveAnnotationResult = annotator.MoveAnnotationMarker(createAreaAnnotationResult.Id,
                                                        new Point(200, 200),/*NewPageNumber*/1);
                //ExEnd:MoveAnnotationResult
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Sets background color of annotation
        /// </summary>
        public static void SetBackgroundColorResult()
        {
            try
            {
                //ExStart:SetBackgroundColorResult
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo textFieldAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                //Add annotation to storage
                CreateAnnotationResult createTextFieldAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation);

                // Set background color of annotation
                SaveAnnotationTextResult setBackgroundColorResult = annotator.SetAnnotationBackgroundColor(createTextFieldAnnotationResult.Id, 16711680);
                //ExEnd:SetBackgroundColorResult
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Updates the text in the annotation
        /// </summary>
        public static void EditTextFieldAnnotation()
        {
            try
            {
                //ExStart:EditTextFieldAnnotation
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo textFieldAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                //Add annotation to storage
                CreateAnnotationResult createTextFieldAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation);

                // Update text in the annotation
                SaveAnnotationTextResult saveTextFieldResult = annotator.SaveTextField(
                    createTextFieldAnnotationResult.Id,
                    new TextFieldInfo
                    {
                        FieldText = "new text",
                        FontFamily = "Colibri",
                        FontSize = 12
                    });


                // Set text field color
                SaveAnnotationTextResult saveTextFieldColorResult = annotator.SetTextFieldColor
                                        (createTextFieldAnnotationResult.Id, 16753920);
                //ExEnd:EditTextFieldAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Removes annotations
        /// </summary>
        public static void RemoveAnnotation()
        {
            try
            {
                //ExStart:RemoveAnnotation
                // Create path finder 
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    new DocumentRepository(pathFinder),
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage.
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo pointAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    Type = AnnotationType.Point,
                    PageNumber = 0,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                // Get all annotations from storage
                ListAnnotationsResult listAnnotationsResult = annotator.GetAnnotations(documentId);

                // Get annotation  
                var annotation = annotator.GetAnnotation(listAnnotationsResult.Annotations[0].Guid);


                // Delete single annotation
                var deleteAnnotationResult = annotator.DeleteAnnotation(annotation.Id);

                //Delete all annotations
                annotator.DeleteAnnotations(documentId);
                //ExEnd:RemoveAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds reply to the annotation, edits reply, creates child reply
        /// </summary>
        public static void AddAnnotationReply()
        {
            try
            {
                //ExStart:AddAnnotationReply
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    new UserRepository(pathFinder),
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create document data object in storage
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf");

                // Create annotation object
                AnnotationInfo pointAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    Type = AnnotationType.Point,
                    PageNumber = 0,
                    CreatorName = "Anonym",
                    DocumentGuid = documentId
                };

                // Add annotation to storage
                var createPointAnnotationResult = annotator.CreateAnnotation(pointAnnotation);

                // Add simple reply to created annotation
                var addSimpleReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "first question");

                // Edit created reply
                var editReplyResult = annotator.EditAnnotationReply(addSimpleReplyResult.ReplyGuid, "changed question");

                // Create child reply. This reply will be linked to previously created reply.
                var addChildReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "answer", addSimpleReplyResult.ReplyGuid);

                // Delete annotation reply by guid
                var deleteReplyResult = annotator.DeleteAnnotationReply(addChildReplyResult.ReplyGuid);

                // Delete all replies from annotation
                annotator.DeleteAnnotationReplies(createPointAnnotationResult.Id);

                // List of replies after deleting all replies
                var listRepliesResultAfterDeleteAll = annotator.ListAnnotationReplies(createPointAnnotationResult.Id);
                //ExEnd:AddAnnotationReply
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds document collaborator 
        /// </summary>
        public static void AddCollaborator()
        {
            try
            {
                //ExStart:AddCollaborator
                // Create repository path finder
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var userRepository = new UserRepository(pathFinder);

                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    userRepository,
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create a user that will be an owner.           
                // Get user from the storage 
                var owner = userRepository.GetUserByEmail("john@doe.com");

                // If user doesn’t exist in the storage then create it. 
                if (owner == null)
                {
                    userRepository.Add(new User { FirstName = "John", LastName = "Doe", Email = "john@doe.com" });
                    owner = userRepository.GetUserByEmail("john@doe.com");
                }

                // Get document data object in the storage
                var document = documentRepository.GetDocument("Document.pdf");

                // If document already created or it hasn’t owner then delete document
                if (document != null && document.OwnerId != owner.Id)
                {
                    documentRepository.Remove(document);
                    document = null;
                }

                // Get document id if document already created or create new document
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id);

                // Create reviewer. 
                var reviewerInfo = new ReviewerInfo
                {
                    PrimaryEmail = "judy@doe.com", //user email, unique identifier
                    FirstName = "Judy",
                    LastName = "Doe",
                    AccessRights = AnnotationReviewerRights.All
                };

                // Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
                var addCollaboratorResult = annotator.AddCollaborator(documentId, reviewerInfo);
                //ExEnd:AddCollaborator                
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Gets document collaborator 
        /// </summary>
        public static void GetCollaborator()
        {
            try
            {
                //ExStart:GetCollaborator
                // Create repository path finder
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var userRepository = new UserRepository(pathFinder);

                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    userRepository,
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create a user that will be an owner.           
                // Get user from the storage 
                var owner = userRepository.GetUserByEmail("john@doe.com");

                // If user doesn’t exist in the storage then create it. 
                if (owner == null)
                {
                    userRepository.Add(new User { FirstName = "John", LastName = "Doe", Email = "john@doe.com" });
                    owner = userRepository.GetUserByEmail("john@doe.com");
                }

                // Get document data object in the storage
                var document = documentRepository.GetDocument("Document.pdf");

                // If document already created or it hasn’t owner then delete document
                if (document != null && document.OwnerId != owner.Id)
                {
                    documentRepository.Remove(document);
                    document = null;
                }

                // Get document id if document already created or create new document
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id);

                // Create reviewer. 
                var reviewerInfo = new ReviewerInfo
                {
                    PrimaryEmail = "judy@doe.com", //user email, unique identifier
                    FirstName = "Judy",
                    LastName = "Doe",
                    AccessRights = AnnotationReviewerRights.All
                };

                // Get document collaborators.
                var getCollaboratorsResult = annotator.GetCollaborators(documentId);

                // Get document collaborator by email
                var getCollaboratorsResultByEmail = annotator.GetDocumentCollaborator(documentId, reviewerInfo.PrimaryEmail);

                // Get collaborator metadata 
                var user = userRepository.GetUserByEmail(reviewerInfo.PrimaryEmail);
                ReviewerInfo collaboratorMetadataResult = annotator.GetCollaboratorMetadata(user.Guid);
                //ExEnd:GetCollaborator                
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Updates document collaborator 
        /// </summary>
        public static void UpdateCollaborator()
        {
            try
            {
                //ExStart:UpdateCollaborator
                // Create repository path finder
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var userRepository = new UserRepository(pathFinder);

                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    userRepository,
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create a user that will be an owner.           
                // Get user from the storage 
                var owner = userRepository.GetUserByEmail("john@doe.com");

                // If user doesn’t exist in the storage then create it. 
                if (owner == null)
                {
                    userRepository.Add(new User { FirstName = "John", LastName = "Doe", Email = "john@doe.com" });
                    owner = userRepository.GetUserByEmail("john@doe.com");
                }

                // Get document data object in the storage
                var document = documentRepository.GetDocument("Document.pdf");

                // If document already created or it hasn’t owner then delete document
                if (document != null && document.OwnerId != owner.Id)
                {
                    documentRepository.Remove(document);
                    document = null;
                }

                // Get document id if document already created or create new document
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id);

                // Create reviewer. 
                var reviewerInfo = new ReviewerInfo
                {
                    PrimaryEmail = "judy@doe.com", //user email, unique identifier
                    FirstName = "Judy",
                    LastName = "Doe",
                    AccessRights = AnnotationReviewerRights.All
                };
                // Update collaborator. Only color and access rights will be updated.
                reviewerInfo.Color = 3355443;
                var updateCollaboratorResult = annotator.UpdateCollaborator(documentId, reviewerInfo);
                //ExEnd:UpdateCollaborator            
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Deletes document collaborator 
        /// </summary>
        public static void DeleteCollaborator()
        {
            try
            {
                //ExStart:DeleteCollaborator
                // Create repository path finder
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();
                var userRepository = new UserRepository(pathFinder);

                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    userRepository,
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create a user that will be an owner.           
                // Get user from the storage 
                var owner = userRepository.GetUserByEmail("john@doe.com");

                // If user doesn’t exist in the storage then create it. 
                if (owner == null)
                {
                    userRepository.Add(new User { FirstName = "John", LastName = "Doe", Email = "john@doe.com" });
                    owner = userRepository.GetUserByEmail("john@doe.com");
                }

                // Get document data object in the storage
                var document = documentRepository.GetDocument("Document.pdf");

                // If document already created or it hasn’t owner then delete document
                if (document != null && document.OwnerId != owner.Id)
                {
                    documentRepository.Remove(document);
                    document = null;
                }

                // Get document id if document already created or create new document
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id);

                // Create reviewer. 
                var reviewerInfo = new ReviewerInfo
                {
                    PrimaryEmail = "judy@doe.com", //user email, unique identifier
                    FirstName = "Judy",
                    LastName = "Doe",
                    AccessRights = AnnotationReviewerRights.All
                };

                // Delete collaborator
                var deleteCollaboratorResult = annotator.DeleteCollaborator(documentId, reviewerInfo.PrimaryEmail);
                //ExEnd:DeleteCollaborator
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Manages collaborator rights 
        /// </summary>
        public static void ManageCollaboratorRights()
        {
            try
            {
                //ExStart:ManageCollaboratorRights
                IRepositoryPathFinder pathFinder = new RepositoryPathFinder();

                var userRepository = new UserRepository(pathFinder);
                var documentRepository = new DocumentRepository(pathFinder);

                // Create instance of annotator
                IAnnotator annotator = new Annotator(
                    userRepository,
                    documentRepository,
                    new AnnotationRepository(pathFinder),
                    new AnnotationReplyRepository(pathFinder),
                    new AnnotationCollaboratorRepository(pathFinder));

                // Create owner. 
                var johnOwner = userRepository.GetUserByEmail("john@doe.com");
                if (johnOwner == null)
                {
                    userRepository.Add(new User { FirstName = "John", LastName = "Doe", Email = "john@doe.com" });
                    johnOwner = userRepository.GetUserByEmail("john@doe.com");
                }

                // Create document data object in storage
                var document = documentRepository.GetDocument("Document.pdf");
                long documentId = document != null ? document.Id : annotator.CreateDocument("Document.pdf", DocumentType.Pdf, johnOwner.Id);

                // Create reviewer. 
                var reviewerInfo = new ReviewerInfo
                {
                    PrimaryEmail = "judy@doe.com",
                    FirstName = "Judy",
                    LastName = "Doe",

                    // Can only get view annotations
                    AccessRights = AnnotationReviewerRights.CanView
                };

                // Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
                var addCollaboratorResult = annotator.AddCollaborator(documentId, reviewerInfo);

                // Get document collaborators
                var getCollaboratorsResult = annotator.GetCollaborators(documentId);
                var judy = userRepository.GetUserByEmail("judy@doe.com");

                // Create annotation object
                AnnotationInfo pointAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    Type = AnnotationType.Point,
                    PageNumber = 0,
                    CreatorName = "Anonym A."
                };

                // John try to add annotations. User is owner of the document.
                var johnResult = annotator.CreateAnnotation(pointAnnotation, documentId, johnOwner.Id);

                // Judy try to add annotations
                try
                {
                    var judyResult = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id);
                }

                 //Get exceptions, because user can only view annotations
                catch (AnnotatorException e)
                {
                    Console.Write(e.Message);
                    Console.ReadKey();
                }

                // Allow Judy create annotations.
                reviewerInfo.AccessRights = AnnotationReviewerRights.CanAnnotate;
                var updateCollaboratorResult = annotator.UpdateCollaborator(documentId, reviewerInfo);

                // Now user can add annotations
                var judyResultCanAnnotate = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id);
                //ExEnd:ManageCollaboratorRights
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
    //ExEnd:DataStorageClass
}
