using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN1ReportAdapter : BaseEdmontonFormReportAdapter
    {
        public readonly List<FormGN1TechnicalRescuePlanReportAdapter> RescuePlanReportAdapters =
            new List<FormGN1TechnicalRescuePlanReportAdapter>();

        public readonly List<FormGN1TradeChecklistReportAdapter> TradeAdapters =
            new List<FormGN1TradeChecklistReportAdapter>();

        public FormGN1ReportAdapter(FormGN1 form, string meetingTemplate) : base(form)
        {
            JobDescription = form.JobDescription;
            FunctionalLocation = form.FunctionalLocation.FullHierarchyWithDescription;
            Location = form.Location;

            IsCseLevel1 = string.Equals(form.CSELevel, "1");
            IsCseLevel2 = string.Equals(form.CSELevel, "2");
            IsCseLevel3 = string.Equals(form.CSELevel, "3");

            HidePlanningWorksheet = string.Equals(form.CSELevel, "3");
            HideRescuePlan = HidePlanningWorksheet;

            PlanningWorksheet = form.PlanningWorksheetContent;
            MeetingTemplate = meetingTemplate;

            // Replace the Approvals with the Planning worksheet approvals
            ApprovalsReportAdapters =
                form.EnabledPlanningWorksheetApprovals.ConvertAll(approval => new ApprovalReportAdapter(approval));

            // Set-up Trade Checklist Report Adapters
            TradeAdapters =
                form.TradeChecklists.ConvertAll(checklist => new FormGN1TradeChecklistReportAdapter(form, checklist));

            RescuePlanReportAdapters = new List<FormGN1TechnicalRescuePlanReportAdapter>
            {
                new FormGN1TechnicalRescuePlanReportAdapter(form)
            };
        }

        public string JobDescription { get; private set; }
        public string FunctionalLocation { get; private set; }
        public string Location { get; private set; }

        public bool IsCseLevel1 { get; private set; }
        public bool IsCseLevel2 { get; private set; }
        public bool IsCseLevel3 { get; private set; }

        public bool HidePlanningWorksheet { get; private set; }
        public bool HideRescuePlan { get; private set; }

        public string PlanningWorksheet { get; private set; }
        public string MeetingTemplate { get; private set; }

        public override string ValidFromLabel
        {
            get { return "Start:"; }
        }

        public override string ValidToLabel
        {
            get { return "End:"; }
        }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                var functionalLocationReportAdapter = new FunctionalLocationReportAdapter(-1, FunctionalLocation);
                return new List<FunctionalLocationReportAdapter> {functionalLocationReportAdapter};
            }
        }
    }
}