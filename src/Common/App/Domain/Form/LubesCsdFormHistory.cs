using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class LubesCsdFormHistory : BaseFormHistory
    {
        public LubesCsdFormHistory(long id,
            FormStatus formStatus,
            string functionalLocation,
            string location,
            string plainTextContent,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            string approvals,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime,
            DateTime? closedDateTime,
            bool? isTheCSDForAPressureSafetyValve,
            string criticalSystemDefeated,
            string documentLinks)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            Location = location;
            PlainTextContent = plainTextContent;
            ApprovedDateTime = approvedDateTime;
            ClosedDateTime = closedDateTime;
            IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
            CriticalSystemDefeated = criticalSystemDefeated;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public string PlainTextContent { get; private set; }
        public DateTime? ApprovedDateTime { get; private set; }
        public DateTime? ClosedDateTime { get; private set; }
        public bool? IsTheCSDForAPressureSafetyValve { get; private set; }
        public string CriticalSystemDefeated { get; private set; }
        public string DocumentLinks { get; private set; }
        public string Approvals { get; set; }
    }
}