using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using System;


namespace Com.Suncor.Olt.Common.Utility
{
    public class SMTPMailSender
    {
        private readonly EmailAddress fromAddress;
        private readonly int port;
        private readonly string smtpServer;
        private readonly string baseDirectory;

        public SMTPMailSender(string smtpServer, int port, EmailAddress fromAddress)
        {
            this.smtpServer = smtpServer;
            this.port = port;
            this.fromAddress = fromAddress;
        }

        public void SendEmail(EmailAddress toEmailAddress, string messageText, string subject, Stream attachmentStream,
            string attachmentFileName)
        {
            var mailMsg = new MailMessage();
            mailMsg.To.Add(toEmailAddress.ToString());

            var mailAddress = new MailAddress(fromAddress.ToString());
            mailMsg.From = mailAddress;
           

            mailMsg.Subject = subject;
            mailMsg.Body = messageText;

            if (attachmentStream != null)
            {
                var attachment = new Attachment(attachmentStream, attachmentFileName, MediaTypeNames.Application.Pdf);

                mailMsg.Attachments.Add(attachment);
            }

            var smtpClient = new SmtpClient(smtpServer, port);
            smtpClient.Send(mailMsg);
        }
        public void SendEmail(EmailAddress toEmailAddress, string messageText, string subject, Stream attachmentStream,
           string attachmentFileName,bool isBodyHtml)
        {
            var mailMsg = new MailMessage();
            mailMsg.To.Add(toEmailAddress.ToString());

            var mailAddress = new MailAddress(fromAddress.ToString());
            mailMsg.From = mailAddress;
            mailMsg.IsBodyHtml = isBodyHtml;

            mailMsg.Subject = subject;
            mailMsg.Body = messageText;

            if (attachmentStream != null)
            {
                var attachment = new Attachment(attachmentStream, attachmentFileName, MediaTypeNames.Application.Pdf);

                mailMsg.Attachments.Add(attachment);
            }

            var smtpClient = new SmtpClient(smtpServer, port);
            smtpClient.Send(mailMsg);
        }
        //Added by ppanigrahi
        public void SendEmail(string fromMail,string toEmailAddress, string messageText, string subject)
        {
            if (!(string.IsNullOrEmpty(toEmailAddress)))
            {
                MailMessage mailMsg = new MailMessage(fromMail, toEmailAddress.Replace(";", ","));
                // mailMsg.To.Add(toEmailAddress);

                // var mailAddress = new MailAddress(fromAddress.ToString());
                // mailMsg.From = mailAddress;

                mailMsg.IsBodyHtml = true;
                mailMsg.Subject = subject;
                mailMsg.Body = messageText;



                var smtpClient = new SmtpClient(smtpServer, port);
                smtpClient.Send(mailMsg);
            }
        }

        //Added by Aarti INC0482299:Outlook2016

        public void SendEmail(Stream attachmentStream, string emailSubjectPrefix, string emailSubject, string toRecipients)
        {
            if (!(string.IsNullOrEmpty(toRecipients)))
            {
                try // Added By Vibhor : INC0539686 - Email issue, try catch addedd to to fix the application crashing issue when email address is wrong.
                {

                    if (!toRecipients.ToLower().Contains("@suncor.com") && !toRecipients.Contains(";")) // Added By Vibhor : INC0539686 - Email issue, fix applied for if email is entered without "@suncor.com"
                    {
                        toRecipients = toRecipients + "@suncor.com";
                    }
                    // MailMessage mailMsg = new MailMessage("OLTSUPPORT@Suncor.com", toRecipients); // Commented By Vibhor - - INC0539359 - Email Issue
                    MailMessage mailMsg = new MailMessage("OLTSUPPORT@Suncor.com", toRecipients.Replace(";", ",")); //Added By Vibhor - INC0539359 - Email Issue
                    // mailMsg.To.Add(toEmailAddress);

                    // var mailAddress = new MailAddress(fromAddress.ToString());
                    // mailMsg.From = mailAddress;
                    string fileName = GetUniqueFileName(emailSubjectPrefix, emailSubject);

                    mailMsg.IsBodyHtml = true;
                    mailMsg.Subject = emailSubjectPrefix;
                    mailMsg.Body = emailSubject;

                    if (attachmentStream != null)
                    {
                        var attachment = new Attachment(attachmentStream, fileName, MediaTypeNames.Application.Pdf);

                        mailMsg.Attachments.Add(attachment);
                    }

                    var smtpClient = new SmtpClient(smtpServer, port);
                    smtpClient.Send(mailMsg);
                }
                catch (Exception)
                {
                    
                   
                }
                
            }
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
            fileName = Regex.Replace(fileName, @"[^0-9a-zA-Z]+", "");           
            fileName = fileName + ".pdf";
          //  fileName = Path.Combine(baseDirectory, fileName);
            return fileName;
        }

        // public void Email(IOltReport report, string emailSubjectPrefix, string emailSubject,string toRecipients)
        //{
        //    DeleteOldAttachments(emailSubjectPrefix);
        //    string fileName = GetUniqueFileName(emailSubjectPrefix, emailSubject);

        //    try
        //    {
        //        string emailBodyText = String.Format("{0}", StringResources.EmailBodyText);

        //        report.ExportToPdf(fileName);
        //        emailClient.SendEmail(emailSubjectPrefix + emailSubject, emailBodyText, fileName, false,toRecipients);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(string.Format("Error emailing file {0}: ", fileName) + e);
        //        ShowEmailErrorMessageBox();
        //    }


        //}
    }
}