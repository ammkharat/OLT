using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using iTextSharp.text;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
namespace Com.Suncor.Olt.Client.Presenters
{
    class ScanPdfFormPresenter
    {

        private readonly IWorkPermitEdmontonService formService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();


        public void InsertWorkPermitScan(List<WorkpermitScan> lstScan, bool permitSpecific)
        {
            UploadDocument(lstScan,permitSpecific);
            foreach (WorkpermitScan Scan in lstScan)
            {
                Scan.SiteId = ClientSession.GetUserContext().Site.Id;
                Scan.CreatedBy = ClientSession.GetUserContext().User;
                Scan.CreatedDate = Clock.Now;
                formService.InsertWorkpermitScan(Scan);
            }

        }

        public void UploadDocument(List<WorkpermitScan> lstScan,bool permitSpecific)
        {
            ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
            ScanCOnfiguration ScanConfiguration = scanPdfFormPresenter.GetScanCOnfiguration();
            string scanSharedPath = ScanConfiguration.SharedPath;
            if (lstScan.Count < 1)
            {
                return;
            }
            string directory = Path.GetDirectoryName(lstScan[0].DocumentPath);
            foreach(WorkpermitScan Scan in lstScan)
            {
              string filename = Path.GetFileName(Scan.DocumentPath);
              
              if(File.Exists(Scan.DocumentPath))
              {
                  string newFilename = scanSharedPath + DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + filename;
                  File.Copy(Scan.DocumentPath,newFilename);
                  Scan.DocumentPath = newFilename;
              }



            }
            if (!permitSpecific)
            {
                if (Directory.Exists(directory))
                {
                    DeleteDirectory(directory);
                }
            }
        }

        public List<WorkpermitScan> GetWorkPermitScan(string WorkpermitId)
        {
            return formService.GetWorkpermitScan(WorkpermitId,Convert.ToInt32(ClientSession.GetUserContext().Site.Id));

        }
        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        #region "SCan PDF"
        public static List<ScanINdexDocument> ExtractTextFromPdf(string path)
        {


            using (PdfReader reader = new PdfReader(path))
            {
                string[,] arrPageIndex = new string[reader.NumberOfPages, 3];
                string PermitNumer = "0";
                string DocumentType="";
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    // text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    text = new StringBuilder(PdfTextExtractor.GetTextFromPage(reader, i));
                    int index = text.ToString().IndexOf("Perm No:");

                    int TOindex = text.ToString().IndexOf("##"); //IndexOfSecond(text.ToString(), "#");
                    OccureneceIndex(text, "Perm No:", "##",out index,out TOindex);
                    
                    string str = "";
                    if (index > -1)
                    {
                        str = text.ToString().Substring(index + 8, TOindex - (index + 8));
                        DocumentType = str.Substring(str.Length - 1);
                        if (DocumentType=="1")
                        {
                            DocumentType = "I";
                        }
                        str = str.Substring(0, str.Length - 2);
                       

                    }
                    if (str == "")
                    {
                        DocumentType = "O";
                    }
                    else
                    {
                        //if permit is exist 
                        long test;
                        ScanPdfFormPresenter Present = new ScanPdfFormPresenter();
                        //if (long.TryParse(str, out test))//&& Present.IsWorkpermitExist(str)
                        {
                            PermitNumer = str.Replace(".","");
                            PermitNumer = str.Replace(" ", "");
                        }
                    }
                    arrPageIndex[i - 1, 0] = PermitNumer;
                    arrPageIndex[i - 1, 1] = i.ToString();
                    arrPageIndex[i - 1, 2] = DocumentType;


                }

                //Logic to form PermitId and Pages
                List<string[,]> lst = new List<string[,]>();
                string Key = "0";
                for (int i = 0; i < arrPageIndex.GetLength(0); i++)
                {
                    if (Key != arrPageIndex[i, 0])
                    {
                        Key = arrPageIndex[i, 0];
                        lst.Add(new string[1, 3]);
                        lst[lst.Count - 1][0, 0] = Key;
                    }
                    if(lst.Count<=0)
                    {
                        continue;
                    }
                    string strVal = lst[lst.Count - 1][0, 1];
                    strVal = strVal + "," + arrPageIndex[i, 1];
                    lst[lst.Count - 1][0, 1] = strVal;

                    string strdocumentType = lst[lst.Count - 1][0, 2];
                    strdocumentType=strdocumentType+ "," + arrPageIndex[i, 2];
                    lst[lst.Count - 1][0, 2] = strdocumentType;

                }
                //end

                //save Loic
                
                List<ScanINdexDocument> Final = new List<ScanINdexDocument>();
                string Temp = System.IO.Path.GetTempPath() + @"\WorkPermit_"+ DateTime.Now.ToString("ddMMyyyyhhmm")+@"\";
                
                Directory.CreateDirectory(Temp );
                string FilePath = Temp ;
                foreach (string[,] strlst in lst)
                {
                    for (int i = 0; i < strlst.GetLength(0); i++)
                    {
                        int length = strlst[0, 1].Split(',').Length - 1;
                        int[] pages = new int[length];
                        int j = 0;
                        foreach (string str in strlst[0, 1].Split(','))
                        {
                            if (str != "")
                            {

                                pages[j] = Convert.ToInt16(str);
                                j++;
                            }

                        }
                       

                        ExtractPages(path, FilePath + strlst[0, 0] + ".pdf", pages);
                     

                        ScanINdexDocument ScanDoc = new ScanINdexDocument();
                        ScanDoc.DcoumentType = strlst[0, 2].Replace(","," ");
                        ScanDoc.Key = strlst[0, 0];
                        ScanDoc.Value = FilePath + strlst[0, 0] + ".pdf";
                        Final.Add(ScanDoc);
                        
                    }


                }

                //end save pdf logic

                return Final;
               // return text.ToString();
            }
        }
        public static IEnumerable<int> IndexOfAll(string sourceString, string subString)
        {
            return Regex.Matches(sourceString, subString).Cast<Match>().Select(m => m.Index);
        }
        public static int IndexOfSecond(string theString, string toFind)
        {
            int first = theString.IndexOf(toFind);

            if (first == -1) return -1;

            // Find the "next" occurrence by starting just past the first
            return theString.IndexOf(toFind, first + 1);
        }

        public static void ExtractPages(string sourcePdfPath, string outputPdfPath, int[] extractThesePages)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the 
                // contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(extractThesePages[0]));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the array and add the page copies to the output file:
                foreach (int pageNumber in extractThesePages)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ExtractPages(string sourcePdfPath, string DestinationFolder)
        {
            int p = 0;
            try
            {
                iTextSharp.text.Document document;
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdfPath), new ASCIIEncoding().GetBytes(""));
                if (!Directory.Exists(sourcePdfPath.ToLower().Replace(".pdf", "")))
                {
                    Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                }
                else
                {
                    Directory.Delete(sourcePdfPath.ToLower().Replace(".pdf", ""), true);
                    Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                }

                for (p = 1; p <= reader.NumberOfPages; p++)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        document = new iTextSharp.text.Document();
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
                        writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_2);
                        writer.CompressionLevel = iTextSharp.text.pdf.PdfStream.BEST_COMPRESSION;
                        writer.SetFullCompression();
                        document.SetPageSize(reader.GetPageSize(p));
                        document.NewPage();
                        document.Open();
                        document.AddDocListener(writer);
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                        iTextSharp.text.pdf.PdfImportedPage pageImport = writer.GetImportedPage(reader, p);
                        int rot = reader.GetPageRotation(p);
                        if (rot == 90 || rot == 270)
                        {
                            cb.AddTemplate(pageImport, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(p).Height);
                        }
                        else
                        {
                            cb.AddTemplate(pageImport, 1.0F, 0, 0, 1.0F, 0, 0);
                        }
                        document.Close();
                        document.Dispose();
                        File.WriteAllBytes(DestinationFolder + "/" + p + ".pdf", memoryStream.ToArray());
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
            return p - 1;

        }


        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ScanINdexDocument> AttachPermitSpecificPDF(string path, string PermitNumber, string DocType)
        {
            List<ScanINdexDocument> Scans = new List<ScanINdexDocument>();
            ScanINdexDocument scan = new ScanINdexDocument();
            scan.Key = PermitNumber;
            scan.Value = path;
            scan.DcoumentType = DocType;
            Scans.Add(scan);
            return Scans;

        }

        public static void OccureneceIndex(StringBuilder strpdfvalue,string startPattern,string endPattern,out int instartindex,out int inendindex)
        {
            instartindex = -1;
            inendindex = -1;

          IEnumerable<int> StartArr = IndexOfAll(Convert.ToString(strpdfvalue), startPattern);
          IEnumerable<int> EndArr = IndexOfAll(Convert.ToString(strpdfvalue), endPattern);
          bool breakloop = false;
            foreach(int iend in EndArr)
            {
                foreach(int istart in StartArr)
                {
                    if (istart < iend)
                    {
                        instartindex = istart;
                        inendindex = iend;
                        breakloop = true;
                    }
                }
                if(breakloop)
                {
                    break;
                }

            }

        }

        public static void ConvertImageToPdf(string srcFilename, string dstFilename)
        {
            iTextSharp.text.Rectangle pageSize = null;

            using (var srcImage = new Bitmap(srcFilename))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(srcFilename);
                document.Add(image);
                document.Close();

                File.WriteAllBytes(dstFilename, ms.ToArray());
            }





        }  
        #endregion

        #region "To trigger Scan Exe"
        public static string ScanDirectory="";
        public static string Scanprocess()
        {
            try
            {
               
               ScanPdfFormPresenter scanPdfFormPresenter  = new ScanPdfFormPresenter();
                ScanCOnfiguration ScanConfiguration =scanPdfFormPresenter.GetScanCOnfiguration();
                ScanDirectory = ScanConfiguration.LocalScanPath;
                foreach (string str in Directory.GetFiles(ScanDirectory))
                {
                    File.Delete(str);
                }
                TriggerScanApplication(ScanConfiguration.ScanExePath, ScanConfiguration.ScanExeName);
                string[] strfiles = Directory.GetFiles(ScanDirectory);
                while (strfiles.Count() <= 0)
                {
                    strfiles = Directory.GetFiles(ScanDirectory);


                }
                System.Threading.Thread.Sleep(1000);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "OLT Work Permit Scan",System.Windows.Forms.MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Error);
                return "error";
            }
            return "";
        }

        /// <summary>
        /// trigger the Exe for UI autmation for HP scan application
        /// </summary>
        public static void TriggerScanApplication(string ScanExePath,string ScanExeName)
        {
            try
            {
                
                //First Kill scan exe if running and delete exe from temp folder
                KillOLTScanexeIfrunning(ScanExeName);
                if (Directory.Exists(System.IO.Path.GetTempPath() + @"\Scan\"))
                {
                    DeleteDirectory(System.IO.Path.GetTempPath() + @"\Scan\");

                }
                
              //copy exe in local folder
                DirectoryCopy(ScanExePath, System.IO.Path.GetTempPath() + @"\Scan\", false);

                //Start Scan Exe.
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = System.IO.Path.GetTempPath() + @"\Scan\"+ScanExeName+".exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                 Process proc = Process.Start(startInfo);
              
                return;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static void KillOLTScanexeIfrunning(string ScanExeName)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName(ScanExeName))
                {
                    // Temp is a document which you need to kill.
                     //if (process.MainWindowTitle.Contains(ScanExeName))
                        process.Kill();
                }
            }
            catch
            {

            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


       
        #endregion

         public bool IsWorkpermitExist(string Permitid)
        {
            try
            {
                if (Permitid == "")
                {
                    return false;
                }
                if (ClientSession.GetUserContext().IsEdmontonSite || ClientSession.GetUserContext().IsSarniaSite || ClientSession.GetUserContext().IsMontrealSulphurSite || ClientSession.GetUserContext().IsMontrealSite || ClientSession.GetUserContext().IsDenverSite)
                {

                    if (formService.isPermitnumberExist(ClientSession.GetUserContext().SiteId, Permitid)>0)
                    {
                        return true;
                    }
                }
            }
             catch
            {
                return false;
            }
                return false;
        }

         public int WorkpermitIdfromNumuber(string Permitid)
         {
             try
             {

                 return formService.isPermitnumberExist(ClientSession.GetUserContext().SiteId, Permitid);
                    
                 
             }
             catch
             {
                 return 0;
             }
            
         }

         public List<ScanDocumentType> GetDocumentType()
        {
            return formService.GetWorkPermitDocumentType(Convert.ToInt64(ClientSession.GetUserContext().Site.Id));
        }
         public ScanCOnfiguration GetScanCOnfiguration()
        {
            return formService.GetScanConfiguration(ClientSession.GetUserContext().SiteId, ClientSession.GetUserContext().User.Username);
        }

        //Functions for Search Permit funtinality

         public SearchPermitdata GetsearchPermitdata(string Permitnumber)
         {
             SearchPermitdata searchPermitdata=null;
             if (ClientSession.GetUserContext().IsEdmontonSite)
             {
               int iWorkPermitId= formService.isPermitnumberExist(ClientSession.GetUserContext().SiteId, Permitnumber);
                 if(iWorkPermitId>0)
                 {
                   WorkPermitEdmonton WorPermit=  formService.QueryById(iWorkPermitId);
                   searchPermitdata = new SearchPermitdata(WorPermit.WorkPermitStatus.Name, WorPermit.CreatedBy.Username, WorPermit.WorkPermitType.Name, WorPermit.PermitNumber.ToString(),"Work Permit");
                 }
             }
             return searchPermitdata;

         }

         public  List<string> GetAutoSearchWorkpermit()
         {
             try
             {

                 if (ClientSession.GetUserContext().Site == null)
                 {
                     return new List<string>();
                 }
                 return formService.GetAutoSearchWorkpermit(ClientSession.GetUserContext().SiteId);
             }
             catch
             {
                 return new List<string>();
             }
         }

      
    }
    
  public  class SearchPermitdata
    {
       
        public SearchPermitdata(string status, string creadtedBy, string permitType,string permitNumber,string formType)
        {
            Status = status; CreadtedBy = creadtedBy; PermitType = permitType; PermitNumber = permitNumber; FormType = formType;

        }
        public string Status { get; set; }
        public string CreadtedBy { get; set; }
        public string PermitType { get; set; }
        public string PermitNumber { get; set; }
        public string FormType { get; set; }
    }
    class ScanINdexDocument
    {
        public ScanINdexDocument()
        {

        }
        public string Key { get; set; }
        public string Value { get; set; }
        public string DcoumentType { get; set; }
    }
}
