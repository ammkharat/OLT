using System;
using System.IO;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports.Printing;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class EmailPresenterTest
    {
        private const string EXISTING_FILE_NAME = "existingTestFile";
        private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string existingFileFullPath = Path.Combine(baseDirectory, EXISTING_FILE_NAME + ".pdf");
        private FileStream fileStream;

        [SetUp]
        public void SetUp()
        {
            fileStream = File.Open(existingFileFullPath, FileMode.OpenOrCreate);
        }

        [TearDown]
        public void TearDown()
        {
            fileStream.Close();
        }

        [Test]
        public void ShouldSendEmail()
        {
            MockEmailClient emailClient = new MockEmailClient();
            MockReport mockReport = new MockReport();
            EmailPresenter emailPresenter = new EmailPresenter(emailClient, baseDirectory);

            string emailBodyText = String.Format("{0}", StringResources.EmailBodyText);

            emailPresenter.Email(mockReport, "abc", "def");

            Assert.AreEqual("abcdef", emailClient.Subject);
            Assert.AreEqual(emailBodyText, emailClient.Body);
            Assert.AreEqual(Path.Combine(baseDirectory, "abcdef.pdf"), emailClient.Attachment);
            Assert.AreEqual(emailClient.Attachment, mockReport.ExportToPdfFileName);
        }

        [Test]
        public void ShouldCreateUniqueAttachmentFileNameIfNameAlreadyExists()
        {
            MockEmailClient emailClient = new MockEmailClient();
            MockReport mockReport = new MockReport();
            EmailPresenter emailPresenter = new EmailPresenter(emailClient, baseDirectory);

            emailPresenter.Email(mockReport, string.Empty, EXISTING_FILE_NAME);

            Assert.AreNotEqual(existingFileFullPath, emailClient.Attachment);
            Assert.IsTrue(emailClient.Attachment.Contains(existingFileFullPath.Replace(".pdf", "")));
            Assert.AreEqual(emailClient.Attachment, mockReport.ExportToPdfFileName);
        }

        private class MockEmailClient : IEmailClient
        {
            public string Subject { get; set; }
            public string Body { get; set; }
            public string Attachment { get; set; }

            public void SendEmail(string subject, string body, bool useHtmlBody = false, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
            {
                Subject = subject;
                Body = body;
            }

            public void SendEmail(string subject, string body, string attachmentFileAndPath, bool useHtmlBody, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
            {
                Subject = subject;
                Body = body;
                Attachment = attachmentFileAndPath;
            }

            public void SendEmailwithMultipleAttachment(string subject, string body, System.Collections.Generic.List<string> attachmentFileAndPath, bool useHtmlBody, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null)
            { }

        }

        private class MockReport : IOltReport
        {
            public string ExportToPdfFileName { get; set; }

            public void CreateDocument()
            {
            }

            public void ExportToPdf(string filename)
            {
                ExportToPdfFileName = filename;
            }

        }
    }
}
