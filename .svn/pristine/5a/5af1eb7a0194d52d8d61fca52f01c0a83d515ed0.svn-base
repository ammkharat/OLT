using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOvertimeFormHistory : BaseFormHistory
    {
        public FormOvertimeFormHistory(long id, FormStatus formStatus, DateTime validFromDateTime,
            DateTime validToDateTime, User lastModifiedBy, DateTime lastModifiedDateTime, string functionalLocation,
            string onSitePersonnel, string tradeOccupation, string approvals, string documentLinks,
            DateTime? approvedDateTime, DateTime? cancelledDateTime)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            OnSitePersonnel = onSitePersonnel;
            TradeOccupation = tradeOccupation;
            Approvals = approvals;
            DocumentLinks = documentLinks;
            ApprovedDateTime = approvedDateTime;
            CancelledDateTime = cancelledDateTime;
        }

        public string FunctionalLocation { get; private set; }
        public string OnSitePersonnel { get; private set; }
        public string TradeOccupation { get; private set; }
        public string Approvals { get; private set; }
        public string DocumentLinks { get; private set; }
        public DateTime? ApprovedDateTime { get; private set; }
        public DateTime? CancelledDateTime { get; private set; }
    }
}