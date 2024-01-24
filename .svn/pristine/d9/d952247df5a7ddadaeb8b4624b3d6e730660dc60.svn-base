using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class FormGN75AHistory : BaseFormHistory
    {
        public FormGN75AHistory(
            long id,
            string functionalLocation,
            string plainTextContent,
            long? associatedFormGN75BNumber,
            string documentLinks,
            DateTime? closedDateTime,
            DateTime? approvedDateTime,
            FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime, string approvals,
            User lastModifiedBy, DateTime lastModifiedDateTime) :
                base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            PlainTextContent = plainTextContent;
            AssociatedFormGN75BNumber = associatedFormGN75BNumber;
            DocumentLinks = documentLinks;
            ClosedDateTime = closedDateTime;
            ApprovedDateTime = approvedDateTime;
            Approvals = approvals;
        }

        public string FunctionalLocation { get; private set; }

        public string PlainTextContent { get; private set; }

        public long? AssociatedFormGN75BNumber { get; private set; }

        public string DocumentLinks { get; private set; }

        public DateTime? ClosedDateTime { get; private set; }

        public DateTime? ApprovedDateTime { get; private set; }

        public string Approvals { get; set; }
    }
}