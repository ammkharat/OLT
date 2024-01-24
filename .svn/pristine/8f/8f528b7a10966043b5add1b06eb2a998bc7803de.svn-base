using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN24History : BaseFormHistory
    {
        private readonly DateTime? approvedDateTime;
        private readonly DateTime? closedDateTime;

        public FormGN24History(long id, FormStatus formStatus, string functionalLocations, string plainTextContent,
            DateTime validFromDateTime, DateTime validToDateTime, string approvals, User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime, DateTime? closedDateTime, bool isTheSafeWorkPlanForPSVRemovalOrInstallation,
            bool isTheSafeWorkPlanForWorkInTheAlkylationUnit, FormGN24AlkylationClass alkylationClass,
            string documentLinks, string plainTextPreJobMeetingSignatures)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            this.approvedDateTime = approvedDateTime;
            this.closedDateTime = closedDateTime;

            FunctionalLocations = functionalLocations;
            PlainTextContent = plainTextContent;
            IsTheSafeWorkPlanForPSVRemovalOrInstallation = isTheSafeWorkPlanForPSVRemovalOrInstallation;
            IsTheSafeWorkPlanForWorkInTheAlkylationUnit = isTheSafeWorkPlanForWorkInTheAlkylationUnit;
            AlkylationClass = alkylationClass;
            PlainTextPreJobMeetingSignatures = plainTextPreJobMeetingSignatures;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public string FunctionalLocations { get; set; }

        public bool IsTheSafeWorkPlanForPSVRemovalOrInstallation { get; private set; }

        public bool IsTheSafeWorkPlanForWorkInTheAlkylationUnit { get; private set; }

        public FormGN24AlkylationClass AlkylationClass { get; private set; }

        public string PlainTextPreJobMeetingSignatures { get; private set; }

        public string DocumentLinks { get; private set; }

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
    }
}