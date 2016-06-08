using GroupDocs.Annotation.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    //ExStart:CommonUtilities
    class CommonUtilities
    {
        //ExStart:CommonProperties
        private const string SourceFolderPath = "../../../../../Data/Samples/";
        private const string DestinationFolderPath = "../../../../../Data/Output/";
        private const string LicenseFilePath = "Groupdocs.Annotation.lic";
        //ExEnd:CommonProperties

        //ExStart:MapSourceFilePath
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="SourceFileName">Source File Name</param>
        /// <returns>Returns complete path of source file</returns>
        public static string MapSourceFilePath(string SourceFileName)
        {
            try
            {
                return SourceFolderPath + SourceFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapSourceFilePath
        //ExStart:MapDestinationFilePath
        /// <summary>
        /// Maps destination file path
        /// </summary>
        /// <param name="DestinationFileName">Destination File Name</param>
        /// <returns>Returns complete path of destination file</returns>
        public static string MapDestinationFilePath(string DestinationFileName)
        {
            try
            {
                return DestinationFolderPath + DestinationFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapDestinationFilePath

        /// <summary>
        /// Saves output document
        /// </summary>
        public static void SaveOutputDocument(Stream inputFile, List<AnnotationInfo> annotations, DocumentType type)
        {
            try
            {
                //ExStart:SaveOutputDocument
                IAnnotator annotator = new Annotator();
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations, DocumentType.Pdf);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(MapDestinationFilePath("Annotated.pdf"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:SaveOutputDocument
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        //ExStart:ApplyLicense
        /// <summary>
        /// Applies product license
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                // initialize License
                License lic = new License();
                // apply license
                lic.SetLicense(LicenseFilePath);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        //ExEnd:ApplyLicense
    }
    //ExEnd:CommonUtilities
}
