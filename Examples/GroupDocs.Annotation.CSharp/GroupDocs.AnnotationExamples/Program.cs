using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Data.Json;
using GroupDocs.Annotation.Contracts;
using GroupDocs.Data.Json.Repositories;
using GroupDocs.Annotation.Contracts.Results;
using System.IO;

namespace GroupDocs.Annotation.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Apply product license
             * Uncomment following function if you have product license
             * */
            //CommonUtilities.ApplyLicense();

            #region Annotation Functions

            ////Add text annotation
            //Annotations.AddTextAnnotation();

            ////Add area annotation with replies 
            //Annotations.AddAreaAnnotationWithReplies();

            ////Add point annotation
            //Annotations.AddPointAnnotation();

            ////Add text strike out annotation
            //Annotations.AddTextStrikeOutAnnotation();

            ////Add polyline annotation
            //Annotations.AddPolylineAnnotation();

            ////Add text field annotation
            //Annotations.AddTextFieldAnnotation();

            ////Add watermark annotation
            //Annotations.AddWatermarkAnnotation();

            ////Add text replacement annotation
            //Annotations.AddTextReplacementAnnotation();

            ////Add arrow annotation
            //Annotations.AddArrowAnnotation();

            ////Add text redaction annotation
            //Annotations.AddTextRedactionAnnotation();

            ////Add underline annotation
            //Annotations.AddUnderLineAnnotation();

            ////Add distance annotation
            //Annotations.AddDistanceAnnotation();

            ////Add resource redaction annotation
            //Annotations.AddResourceRedactionAnnotation();

            ////Remove all annotations
            //Annotations.RemoveAllAnnotationsFromDocument();

            #endregion

            #region DataStorage Functions

            ////Create document
            //DataStorage.CreateDocument();

            ////Assign access rights
            //DataStorage.AssignAccessRights();

            ////Create and get annotation
            //DataStorage.CreateAndGetAnnotation();

            ////Get all annotation of a document
            //DataStorage.GetAllDocumentAnnotation();

            ////Resize annotation 
            //DataStorage.ResizeAnnotationResult();

            ////Move an anotation 
            //DataStorage.MoveAnnotationResult();

            ////Set background color
            //DataStorage.SetBackgroundColorResult();

            ////Edit annotation
            //DataStorage.EditTextFieldAnnotation();

            ////Remove annotation
            //DataStorage.RemoveAnnotation();

            ////Add annotation reply
            //DataStorage.AddAnnotationReply();

            ////Add document collaborator
            //DataStorage.AddCollaborator();

            ////Get document collaborator
            //DataStorage.GetCollaborator();

            ////Update document collaborator
            //DataStorage.UpdateCollaborator();

            ////Delete document collaborator
            //DataStorage.DeleteCollaborator();

            ////Delete document collaborator
            //DataStorage.ManageCollaboratorRights();

            ////Export annotation to document
            //DataStorage.ExportAnnotationInFile();

            #endregion

            Console.ReadKey();
            
        }

        
    }
}
