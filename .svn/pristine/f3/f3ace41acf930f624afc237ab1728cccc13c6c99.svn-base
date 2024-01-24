using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports.Printing;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EmailPresenter
    {       
        private static readonly ILog logger = LogManager.GetLogger(typeof(EmailPresenter));

        private readonly IEmailClient emailClient;
        private readonly string baseDirectory;

        public EmailPresenter() : this(new EmailClient(), Application.LocalUserAppDataPath)
        {
        }

        public EmailPresenter(IEmailClient emailClient, string baseDirectory)
        {
            this.emailClient = emailClient;
            this.baseDirectory = baseDirectory;

            logger.Info("Email presenter base directory is: " + baseDirectory);
        }

        //ayman action item email
        public void Email(IOltReport report, string emailSubjectPrefix, string emailSubject,string toRecipients)
        {
            DeleteOldAttachments(emailSubjectPrefix);
            string fileName = GetUniqueFileName(emailSubjectPrefix, emailSubject);

            try
            {
                string emailBodyText = String.Format("{0}", StringResources.EmailBodyText);

                report.ExportToPdf(fileName);
                emailClient.SendEmail(emailSubjectPrefix + emailSubject, emailBodyText, fileName, false,toRecipients);
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Error emailing file {0}: ", fileName) + e);
                ShowEmailErrorMessageBox();
            }


        }

        public void Email(IOltReport report, string emailSubjectPrefix, string emailSubject)
        {
            DeleteOldAttachments(emailSubjectPrefix);
            string fileName = GetUniqueFileName(emailSubjectPrefix, emailSubject);

            try
            {
                string emailBodyText = String.Format("{0}", StringResources.EmailBodyText);

                report.ExportToPdf(fileName);
                emailClient.SendEmail(emailSubjectPrefix + emailSubject, emailBodyText, fileName, false);
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Error emailing file {0}: ", fileName) + e);
                ShowEmailErrorMessageBox();
            }
           

        }

        public void Email(string emailSubject, string emailBody, bool useHtmlBody = false, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
        {
            try
            {
                emailClient.SendEmail(emailSubject, emailBody, useHtmlBody, toSemiColonDelimitedRecipientList, ccSemiColonDelimitedRecipientList);
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Error sending email with subject {0}: ", emailSubject) + e);
                ShowEmailErrorMessageBox();
            }
        }

        private static void ShowEmailErrorMessageBox()
        {
            OltMessageBox.Show(
                null,
                StringResources.EmailError,
                StringResources.EmailErrorTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                ContentAlignment.MiddleLeft);
        }

        private string GetUniqueFileName(string emailSubjectPrefix, string emailSubject)
        {
            string fileName = GetFileName(emailSubjectPrefix, emailSubject);
            if (File.Exists(fileName))
            {
                fileName = GetFileName(emailSubjectPrefix, emailSubject + " " + Guid.NewGuid());
            }
            return fileName;
        }

        private string GetFileName(string emailSubjectPrefix, string emailSubject)
        {
            string fileName = emailSubjectPrefix + emailSubject.ToCleanFileName();
            fileName = Regex.Replace(fileName, @"[^0-9a-zA-Z]+", ""); //INC0427353 Added by Aarti
            fileName = fileName + ".pdf";
           
            fileName = Path.Combine(baseDirectory, fileName);
            return fileName;
        }

        private void DeleteOldAttachments(string fileNamePrefix)
        {
            try
            {
                string[] files = Directory.GetFiles(baseDirectory, fileNamePrefix.ToCleanFileName() + "*.pdf");
                foreach (string file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception e)
                    {
                        logger.Error(string.Format("Error deleting file {0}: ", file) + e);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Error deleting files with prefix {0}: ", fileNamePrefix) + e);
            }
        }

        // Added by Mukesh for RITM0218684
        public void Email(System.Collections.Generic.List<IOltReport> report, string emailSubjectPrefix, string emailSubject,System.Collections.Generic.List<string> fileNames )
        {
            DeleteOldAttachments(emailSubjectPrefix);
         
           // System.Collections.Generic.List<string> fileNames = new System.Collections.Generic.List<string>();
            try
            {
                string emailBodyText = String.Format("{0}", StringResources.EmailBodyText);
                int i=0;
                foreach (var rpt in report)
                {


                    string fileName = fileNames != null ? GetUniqueFileName("", fileNames[i]) : GetUniqueFileName(emailSubjectPrefix, emailSubject);
                    fileNames[i] = fileName;    
                    rpt.ExportToPdf(fileName);

                    i++; 
                }
                emailClient.SendEmailwithMultipleAttachment(emailSubjectPrefix + emailSubject, emailBodyText, fileNames, false);
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Error emailing file {0}: ", fileNames[0].ToString() + e));
                ShowEmailErrorMessageBox();
            }


        }
    }
}