using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN7History : BaseFormHistory
    {
        private readonly DateTime? approvedDateTime;
        private readonly DateTime? closedDateTime;

        public FormGN7History(long id, FormStatus formStatus, string functionalLocations, string plainTextContent,
            DateTime validFromDateTime, DateTime validToDateTime, string approvals, User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime, DateTime? closedDateTime, string documentLinks)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocations = functionalLocations;
            PlainTextContent = plainTextContent;
            this.approvedDateTime = approvedDateTime;
            this.closedDateTime = closedDateTime;
            Approvals = approvals;
            DocumentLinks = documentLinks;
        }

        public string FunctionalLocations { get; set; }

        public DateTime? ClosedDateTime
        {
            get { return closedDateTime; }
        }

        public DateTime? ApprovedDateTime
        {
            get { return approvedDateTime; }
        }

        public string PlainTextContent { get; private set; }

        public string Approvals { get; set; }
        public string DocumentLinks { get; private set; }
    }
}