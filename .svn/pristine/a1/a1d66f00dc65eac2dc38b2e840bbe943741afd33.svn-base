using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class FormOP14History : BaseFormHistory
    {
        public FormOP14History(long id, FormStatus formStatus, string functionalLocations, string plainTextContent,
            DateTime validFromDateTime, DateTime validToDateTime, string approvals, User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime, DateTime? closedDateTime, FormOP14Department department,
            bool isTheCSDForAPressureSafetyValve, string criticalSystemDefeated, string documentLinks)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocations = functionalLocations;
            PlainTextContent = plainTextContent;
            ApprovedDateTime = approvedDateTime;
            ClosedDateTime = closedDateTime;
            Department = department;
            IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
            CriticalSystemDefeated = criticalSystemDefeated;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public DateTime? ApprovedDateTime { get; private set; }
        public DateTime? ClosedDateTime { get; private set; }

        public FormOP14Department Department { get; private set; }
        public bool IsTheCSDForAPressureSafetyValve { get; private set; }
        public string CriticalSystemDefeated { get; private set; }
        public string DocumentLinks { get; private set; }
        public string PlainTextContent { get; private set; }
        public string FunctionalLocations { get; set; }
        public string Approvals { get; set; }

        //DMND0010261-SELC CSD EdmontonPipeline
        public bool IsSCADASupport { get; set; }
    }
}