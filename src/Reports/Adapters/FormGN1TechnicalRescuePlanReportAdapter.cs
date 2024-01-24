using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN1TechnicalRescuePlanReportAdapter : BaseEdmontonFormReportAdapter
    {
        public FormGN1TechnicalRescuePlanReportAdapter(FormGN1 form) : base(form)
        {
            JobDescription = form.JobDescription;
            FunctionalLocation = form.FunctionalLocation.FullHierarchyWithDescription;
            Location = form.Location;

            IsCseLevel1 = string.Equals(form.CSELevel, "1");
            IsCseLevel2 = string.Equals(form.CSELevel, "2");
            IsCseLevel3 = string.Equals(form.CSELevel, "3");

            RescuePlanRtf = form.RescuePlanContent;
            // Replace approvals with the Rescue Plan Approvals
            ApprovalsReportAdapters =
                form.EnabledRescuePlanApprovals.ConvertAll(approval => new ApprovalReportAdapter(approval));
        }

        public string JobDescription { get; private set; }
        public string FunctionalLocation { get; private set; }
        public string Location { get; private set; }

        public bool IsCseLevel1 { get; private set; }
        public bool IsCseLevel2 { get; private set; }
        public bool IsCseLevel3 { get; private set; }

        public string RescuePlanRtf { get; private set; }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                var functionalLocationReportAdapter = new FunctionalLocationReportAdapter(-1, FunctionalLocation);
                return new List<FunctionalLocationReportAdapter> {functionalLocationReportAdapter};
            }
        }

        public override string ValidFromLabel
        {
            get { return "Start:"; }
        }

        public override string ValidToLabel
        {
            get { return "End:"; }
        }
    }
}