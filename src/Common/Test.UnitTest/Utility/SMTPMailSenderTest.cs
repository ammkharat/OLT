using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class SMTPMailSenderTest
    {
        [Test]     
        [Ignore("Best not to run this since it tries to actually send a real email.")]
        public void ShouldSendEmailWithAttachment()
        {
            EmailAddress sender = new EmailAddress("happy@localhost");
            
            EmailAddress to1 = new EmailAddress("zippy1@localhost"); 
            EmailAddress to2 = new EmailAddress("zippy2@localhost"); 
            EmailAddress to3 = new EmailAddress("zippy3@localhost"); 

            List<EmailAddress> emails = new List<EmailAddress> { to1, to2, to3 };

            const string attachmentPath = @"C:\dev\EDR Safe Work Permit.pdf";

            using(FileStream fileStream = File.OpenRead(attachmentPath))
            {
                foreach (EmailAddress emailAddress in emails)
                {
                    fileStream.Position = 0;
                    SMTPMailSender mailSender = new SMTPMailSender("localhost", 4001, sender);
                    mailSender.SendEmail(emailAddress, "This is some messageText", "This is the subject", fileStream, "filename.pdf");
                }                            
            }


        }
    }
}
