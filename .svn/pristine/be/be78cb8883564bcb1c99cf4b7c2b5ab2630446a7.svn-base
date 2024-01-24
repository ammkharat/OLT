using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class FormGN1History : BaseFormHistory
    {
        public FormGN1History(long id, FormStatus formStatus, string functionalLocation, string location,
            string cseLevel, string jobDescription, DateTime validFromDateTime, DateTime validToDateTime,
            string planningWorksheetContent, string rescuePlanContent, string tradeChecklists,
            string planningWorksheetApprovals, string rescuePlanApprovals, string tradeChecklistApprovals,
            string documentLinks, User lastModifiedBy, DateTime lastModifiedDateTime, DateTime? cancelledDateTime,
            DateTime? approvedDateTime)
            : base(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            Location = location;
            CSELevel = cseLevel;
            JobDescription = jobDescription;
            PlanningWorksheetPlainTextContent = planningWorksheetContent;
            RescuePlanPlainTextContent = rescuePlanContent;
            DocumentLinks = documentLinks;
            TradeChecklists = tradeChecklists;
            PlanningWorksheetApprovals = planningWorksheetApprovals;
            RescuePlanApprovals = rescuePlanApprovals;
            TradeChecklistApprovals = tradeChecklistApprovals;
            ClosedDateTime = cancelledDateTime;
            ApprovedDateTime = approvedDateTime;
        }

        public string FunctionalLocation { get; private set; }

        public string Location { get; private set; }

        public string CSELevel { get; private set; }

        public string JobDescription { get; private set; }

        public string PlanningWorksheetPlainTextContent { get; private set; }

        public string RescuePlanPlainTextContent { get; private set; }

        public string DocumentLinks { get; private set; }

        public DateTime? ClosedDateTime { get; private set; }

        public DateTime? ApprovedDateTime { get; private set; }

        public string TradeChecklists { get; private set; }

        public string PlanningWorksheetApprovals { get; private set; }

        public string RescuePlanApprovals { get; private set; }

        public string TradeChecklistApprovals { get; private set; }
    }
}