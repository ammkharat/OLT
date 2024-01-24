
namespace Com.Suncor.Olt.Client.Utilities
{
    public interface IEmailClient
    {
        void SendEmail(string subject, string body, bool useHtmlBody = false, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null);
        void SendEmail(string subject, string body, string attachmentFileAndPath, bool useHtmlBody, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null);
        // Added by Mukesh for RITM0218684
        void SendEmailwithMultipleAttachment(string subject, string body, System.Collections.Generic.List<string> attachmentFileAndPath, bool useHtmlBody, string toSemiColonDelimitedRecipientList = null, string ccSemiColonDelimitedRecipientList = null);

    }
}
