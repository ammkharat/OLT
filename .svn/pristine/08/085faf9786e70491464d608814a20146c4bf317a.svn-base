using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN6History : BaseFormHistory
    {
        private readonly DateTime? approvedDateTime;
        private readonly DateTime? closedDateTime;

        public FormGN6History(long id, FormStatus formStatus, string functionalLocations, DateTime validFromDateTime,
            DateTime validToDateTime, string approvals, User lastModifiedBy, DateTime lastModifiedDateTime,
            DateTime? approvedDateTime, DateTime? closedDateTime, string jobDescription, string reasonForCriticalLift,
            string section1PlainTextContent, bool section1NotApplicableToJob, string section2PlainTextContent,
            bool section2NotApplicableToJob, string section3PlainTextContent, bool section3NotApplicableToJob,
            string section4PlainTextContent, bool section4NotApplicableToJob, string section5PlainTextContent,
            bool section5NotApplicableToJob, string section6PlainTextContent, bool section6NotApplicableToJob,
            string documentLinks, string plainTextPreJobMeetingSignatures)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            this.approvedDateTime = approvedDateTime;
            this.closedDateTime = closedDateTime;

            FunctionalLocations = functionalLocations;
            JobDescription = jobDescription;
            ReasonForCriticalLift = reasonForCriticalLift;
            Section1PlainTextContent = section1PlainTextContent;
            Section1NotApplicableToJob = section1NotApplicableToJob;
            Section2PlainTextContent = section2PlainTextContent;
            Section2NotApplicableToJob = section2NotApplicableToJob;
            Section3PlainTextContent = section3PlainTextContent;
            Section3NotApplicableToJob = section3NotApplicableToJob;
            Section4PlainTextContent = section4PlainTextContent;
            Section4NotApplicableToJob = section4NotApplicableToJob;
            Section5PlainTextContent = section5PlainTextContent;
            Section5NotApplicableToJob = section5NotApplicableToJob;
            Section6PlainTextContent = section6PlainTextContent;
            Section6NotApplicableToJob = section6NotApplicableToJob;

            PlainTextPreJobMeetingSignatures = plainTextPreJobMeetingSignatures;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public string FunctionalLocations { get; set; }

        public string JobDescription { get; set; }
        public string ReasonForCriticalLift { get; set; }

        public string Section1PlainTextContent { get; set; }
        public bool Section1NotApplicableToJob { get; set; }

        public string Section2PlainTextContent { get; set; }
        public bool Section2NotApplicableToJob { get; set; }

        public string Section3PlainTextContent { get; set; }
        public bool Section3NotApplicableToJob { get; set; }

        public string Section4PlainTextContent { get; set; }
        public bool Section4NotApplicableToJob { get; set; }

        public string Section5PlainTextContent { get; set; }
        public bool Section5NotApplicableToJob { get; set; }

        public string Section6PlainTextContent { get; set; }
        public bool Section6NotApplicableToJob { get; set; }

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

        public string Approvals { get; set; }
    }
}