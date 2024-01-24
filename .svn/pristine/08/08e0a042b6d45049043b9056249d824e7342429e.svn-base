using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Services;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public interface IReportPrintManager<TDomainObject> where TDomainObject : DomainObject
    {
        void PreviewReport(TDomainObject domainObject);
        void PrintReport(List<TDomainObject> domainObjects);

      

        void PrintEdit(TDomainObject objectsToPrint);
        void Email(TDomainObject domainObject, string emailSubjectPrefix, string emailSubject);

        // Added by Mukesh for RITM0218684
        void Email(List<TDomainObject> domainObjects, string emailSubjectPrefix, string emailSubject);

        void Email(TDomainObject domainobject, string emailSubjectprefix, string emailSubject, string toRecipients);         //ayman action item email
         void Email(TDomainObject domainObject, List<EmailAddress> toEmailAddress, string messageText, string subject, string attachmentFileName, bool isBodyHtml);

        void Email(TDomainObject domainObject, EmailAddress toEmailAddress, string messageText, string subject,
            string attachmentFileName, bool isBodyHtml);//Added by ppanigrahi
    
    }
}