using System;
using System.Diagnostics;
using System.Threading;
using Castle.Core.Internal;
using log4net;
using Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class EmailClient : IEmailClient
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (EmailClient));

        public void SendEmail(string subject, string body, bool useHtmlBody = false,
            string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
        {
            SendEmail(subject, body, null, useHtmlBody, toSemiColonDelimitedRecipientList, ccSemiColonDelimitedRecipientList);
        }

        public void SendEmail(string subject, string body, string attachmentFileAndPath, bool useHtmlBody,
            string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
        {
            if (!IsOutlookRunning())
            {
                try
                {
                    Process.Start("Outlook.exe");
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    logger.Error("There was an error trying to start the Outlook.exe process.", ex);
                }
            }

            try
            {
                var oApp = new Application();
                var mail = (MailItem) oApp.CreateItem(OlItemType.olMailItem);

                if (toSemiColonDelimitedRecipientList.IsNullOrEmpty() == false)
                {
                    mail.To = toSemiColonDelimitedRecipientList;
                }

                if (ccSemiColonDelimitedRecipientList.IsNullOrEmpty() == false)
                {
                    mail.CC = ccSemiColonDelimitedRecipientList;
                }

                mail.Subject = subject;

                if (useHtmlBody)
                {
                    mail.HTMLBody = body;
                }
                else
                {
                    mail.Body = body;
                }
                if (attachmentFileAndPath != null)
                {
                    mail.Attachments.Add(attachmentFileAndPath, (int) OlAttachmentType.olByValue, Type.Missing, subject);
                }
                if (subject.Contains("Action"))
                {
                    mail.Send();
                }
                else
                {
                    mail.Display(false);
                }
               
            }
            catch (Exception ex)
            {
                logger.Error("There was an error thrown while creating an Outlook email message.", ex);
            }
        }

        private bool IsOutlookRunning()
        {
            try
            {
                var p = Process.GetProcessesByName("Outlook");
                return p.Length != 0;
            }
            catch (Exception ex)
            {
                logger.Error("There was an error trying to find the process Outlook.exe", ex);
            }
            return false;
        }

        
        // Added by Mukesh for RITM0218684
        public void SendEmailwithMultipleAttachment(string subject, string body, System.Collections.Generic.List<string> attachmentFileAndPaths, bool useHtmlBody,
           string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
        {
            if (!IsOutlookRunning())
            {
                try
                {
                    Process.Start("Outlook.exe");
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    logger.Error("There was an error trying to start the Outlook.exe process.", ex);
                }
            }

            try
            {
                var oApp = new Application();
                var mail = (MailItem)oApp.CreateItem(OlItemType.olMailItem);

                if (toSemiColonDelimitedRecipientList.IsNullOrEmpty() == false)
                {
                    mail.To = toSemiColonDelimitedRecipientList;
                }

                if (ccSemiColonDelimitedRecipientList.IsNullOrEmpty() == false)
                {
                    mail.CC = ccSemiColonDelimitedRecipientList;
                }

                mail.Subject = subject;

                if (useHtmlBody)
                {
                    mail.HTMLBody = body;
                }
                else
                {
                    mail.Body = body;
                }
                int i = 0;
                if (attachmentFileAndPaths != null)
                {
                    foreach (string strFilepath in attachmentFileAndPaths)
                    {
                        i++;
                        mail.Attachments.Add(strFilepath, (int)OlAttachmentType.olByValue, Type.Missing, strFilepath);
                    }
                }

                mail.Display(false);
            }
            catch (Exception ex)
            {
                logger.Error("There was an error thrown while creating an Outlook email message.", ex);
            }
        }
    }
}