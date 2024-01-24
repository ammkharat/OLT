using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class TemporaryInstallationsMudsHistory : BaseFormHistory
    {
        public TemporaryInstallationsMudsHistory(long id, FormStatus formStatus, string functionalLocations, string plainTextContent,
            DateTime validFromDateTime, DateTime validToDateTime, string approvals, User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? approvedDateTime, DateTime? closedDateTime, bool? hasBeenCommunicated, bool? hasAttachments,
            string csdReason,
            bool? isTheCSDForAPressureSafetyValve, string criticalSystemDefeated, string documentLinks)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocations = functionalLocations;
            PlainTextContent = plainTextContent;
            ApprovedDateTime = approvedDateTime;
            ClosedDateTime = closedDateTime;
            HasBeenCommunicated = hasBeenCommunicated;
            HasAttachments = hasAttachments;
            CsdReason = csdReason;
            IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
            CriticalSystemDefeated = criticalSystemDefeated;
            DocumentLinks = documentLinks;
            Approvals = approvals;
        }

        public DateTime? ApprovedDateTime { get; private set; }
        public DateTime? ClosedDateTime { get; private set; }
        public bool? HasBeenCommunicated { get; private set; }
        public bool? HasAttachments { get; private set; }
        public string CsdReason { get; private set; }
        public bool? IsTheCSDForAPressureSafetyValve { get; private set; }
        public string CriticalSystemDefeated { get; private set; }
        public string DocumentLinks { get; private set; }
        public string PlainTextContent { get; private set; }
        public string FunctionalLocations { get; set; }
        public string Approvals { get; set; }
    }
}