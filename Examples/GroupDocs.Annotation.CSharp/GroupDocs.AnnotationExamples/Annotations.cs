using GroupDocs.Annotation.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    //ExStart:AllAnnotations
    public class Annotations
    {
        // initialize file path
        //ExStart:SourceDocFilePath
        private const string filePath = "sample.pdf";
        //ExEnd:SourceDocFilePath

        /// <summary>
        /// Adds text annotation in PDF document
        /// </summary>
        public static void AddTextAnnotation()
        {
            try
            {
                //ExStart:AddTextAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)265.44, (float)153.86, 206, 36),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":265.44,\"y\":388.83},{\"x\":472.19,\"y\":388.83},{\"x\": 265.44,\"y\":349.14},{\"x\":472.19,\"y\":349.14}]",
                    Type = AnnotationType.Text,
                    CreatorName = "Anonym A."
                };

                // Add annotation to list
                annotations.Add(textAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddTextAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds area annotation with replies in PDF document
        /// </summary>
        public static void AddAreaAnnotationWithReplies()
        {
            try
            {
                //ExStart:AddAreaAnnotationWithReplies
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Area annotation with 2 replies
                AnnotationInfo areaAnnnotation = new AnnotationInfo()
                {
                    AnnotationPosition = new Point(852.0, 59.0),
                    Replies = new AnnotationReplyInfo[]
                {
                    new AnnotationReplyInfo
                    {
                        Message = "Hello!",
                        RepliedOn = DateTime.Now,
                        UserName = "John"
                    },
                    new AnnotationReplyInfo
                    {
                        Message = "Hi!",
                        RepliedOn = DateTime.Now,
                        UserName = "Judy"
                    }
                },
                    BackgroundColor = 11111111,
                    Box = new Rectangle(300f, 200f, 88f, 37f),
                    PageNumber = 0,
                    PenColor = 2222222,
                    PenStyle = 1,
                    PenWidth = 1,
                    Type = AnnotationType.Area,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(areaAnnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddAreaAnnotationWithReplies
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds point annotation in PDF document
        /// </summary>
        public static void AddPointAnnotation()
        {
            try
            {
                //ExStart:AddPointAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Point annotation
                AnnotationInfo pointAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    PageNumber = 0,
                    Type = AnnotationType.Point,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(pointAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddPointAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text strikeout annotation in PDF document
        /// </summary>
        public static void AddTextStrikeOutAnnotation()
        {
            try
            {
                //ExStart:AddTextStrikeOutAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text strikeout annotation
                AnnotationInfo strikeoutAnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)688.73, (float)321.85, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":400.05},{\"x\":255.9,\"y\":400.05},{\"x\":101.76,\"y\":378.42},{\"x\":255.91,\"y\":378.42},{\"x\":101.76,\"y\":374.13},{\"x\":423.61,\"y\":374.13},{\"x\":101.76,\"y\":352.5},{\"x\":423.61,\"y\":352.5}]",
                    Type = AnnotationType.TextStrikeout,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(strikeoutAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddTextStrikeOutAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds polyline annotation in PDF document
        /// </summary>
        public static void AddPolylineAnnotation()
        {
            try
            {
                //ExStart:AddPolylineAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Polyline annotation
                AnnotationInfo polylineAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 35.0),
                    Box = new Rectangle(250f, 35f, 102f, 12f),
                    PageNumber = 0,
                    PenColor = 1201033,
                    PenWidth = 2,
                    SvgPath = "M250.8280751173709,48.209295774647885l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l1.3973708920187793,-0.6986854460093896l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l2.096056338028169,-1.3973708920187793l3.493427230046948,-1.3973708920187793l0.6986854460093896,-0.6986854460093896l1.3973708920187793,-1.3973708920187793l0.6986854460093896,0l1.3973708920187793,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l0,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0,-0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.096056338028169,-0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l1.3973708920187793,0l2.096056338028169,0l5.589483568075117,0l1.3973708920187793,0l2.096056338028169,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l2.096056338028169,1.3973708920187793l0.6986854460093896,0l0.6986854460093896,0l0,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0.6986854460093896l0,0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0.6986854460093896l1.3973708920187793,0.6986854460093896l3.493427230046948,0.6986854460093896l1.3973708920187793,0.6986854460093896l2.096056338028169,0.6986854460093896l1.3973708920187793,0.6986854460093896l1.3973708920187793,0l1.3973708920187793,0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.7947417840375586,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0",
                    Type = AnnotationType.Polyline,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(polylineAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddPolylineAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text field annotation in PDF document
        /// </summary>
        public static void AddTextFieldAnnotation()
        {
            try
            {
                //ExStart:AddTextFieldAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text field annotation
                AnnotationInfo textFieldAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textFieldAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddTextFieldAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark annotation in PDF document
        /// </summary>
        public static void AddWatermarkAnnotation()
        {
            try
            {
                //ExStart:AddWatermarkAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Watermark annotation
                AnnotationInfo watermarkAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(100.0, 300.0),
                    FieldText = "TEXT STAMP",
                    FontFamily = "Microsoft Sans Serif",
                    FontSize = 10,
                    FontColor = 2222222,
                    Box = new Rectangle(430f, 272f, 66f, 51f),
                    PageNumber = 0,
                    Type = AnnotationType.Watermark,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(watermarkAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddWatermarkAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text replacement annotation in PDF document
        /// </summary>
        public static void AddTextReplacementAnnotation()
        {
            try
            {

                //ExStart:AddTextReplacementAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text replacement annotation
                AnnotationInfo textReplacementAnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)826.73, (float)229, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":264.69},{\"x\":331,\"y\":264.69},{\"x\":101.76,\"y\":243.06},{\"x\":331,\"y\":243}]",
                    Type = AnnotationType.TextReplacement,
                    CreatorName = "Anonym A.",
                    FieldText = "Replaced text",
                    FontSize = 10
                };
                // Add annotation to list
                annotations.Add(textReplacementAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddTextReplacementAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds arrow annotation in PDF document
        /// </summary>
        public static void AddArrowAnnotation()
        {
            try
            {
                //ExStart:AddArrowAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Arrow annotation
                AnnotationInfo arrowAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 252.0),
                    Box = new Rectangle(279.4742f, 252.9241f, 129.9555f, -9.781596f),
                    PageNumber = 0,
                    PenColor = 1201033,
                    PenStyle = 0,
                    PenWidth = 1,
                    SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455",
                    Type = AnnotationType.Arrow,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(arrowAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddArrowAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text redaction annotation in PDF document
        /// </summary>
        public static void AddTextRedactionAnnotation()
        {
            try
            {
                //ExStart:AddTextRedactionAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text redaction annotation
                AnnotationInfo textRedactionAnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)448.56, (float)212.4, 210, 27),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":448.56,\"y\":326.5},{\"x\":658.7,\"y\":326.5},{\"x\":448.56,\"y\":302.43},{\"x\":658.7,\"y\":302.43}]",
                    Type = AnnotationType.TextRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textRedactionAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddTextRedactionAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds underline annotation in PDF document
        /// </summary>
        public static void AddUnderLineAnnotation()
        {
            try
            {
                //ExStart:AddUnderLineAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Underline annotation
                AnnotationInfo underlineAnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)248.57, (float)1135.78, (float)222.67, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":248.57,\"y\":503.507},{\"x\":471,\"y\":503.507},{\"x\":248.57,\"y\":468.9},{\"x\":471,\"y\":468.9}]",
                    Type = AnnotationType.TextUnderline,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(underlineAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddUnderLineAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds distance annotation in PDF document
        /// </summary>
        public static void AddDistanceAnnotation()
        {
            try
            {
                //ExStart:AddDistanceAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Distance annotation
                AnnotationInfo distanceAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 287.0),
                    Box = new Rectangle(248f, 287f, 115f, 25f),
                    PageNumber = 0,
                    PenColor = 1201033,
                    PenStyle = 0,
                    PenWidth = 1,
                    SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338",
                    Text = "\r\nAnonym A.: 115px",
                    Type = AnnotationType.Distance,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(distanceAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddDistanceAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds resource redaction annotation in PDF document
        /// </summary>
        public static void AddResourceRedactionAnnotation()
        {
            try
            {
                //ExStart:AddResourceRedactionAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Resource redaction annotation
                AnnotationInfo resourceRedactionAnnotation = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 271.78),
                    BackgroundColor = 3355443,
                    Box = new Rectangle(466f, 271f, 69f, 62f),
                    PageNumber = 0,
                    PenColor = 3355443,
                    Type = AnnotationType.ResourcesRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(resourceRedactionAnnotation);
                
                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf);
                //ExEnd:AddResourceRedactionAnnotation
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Removes all annotations in PDF document
        /// </summary>
        public static void RemoveAllAnnotationsFromDocument()
        {

            try
            {
                //ExStart:RemoveAllAnnotationsFromDocument
                // Initialize annotator
                IAnnotator annotator = new Annotator();
                
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                
                // Get output file stream
                Stream result = annotator.RemoveAnnotationStream(inputFile, DocumentType.Pdf);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:RemoveAllAnnotationsFromDocument
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
    //ExEnd:AllAnnotations
}
