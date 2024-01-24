using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN1TradeChecklistReportAdapter : BaseEdmontonFormReportAdapter
    {
        public FormGN1TradeChecklistReportAdapter(FormGN1 form, TradeChecklist tradeChecklist) : base(form)
        {
            TradeChecklistId = tradeChecklist.IdValue;

            FunctionalLocation = form.FunctionalLocation.FullHierarchyWithDescription;
            Location = form.Location;

            Trade = tradeChecklist.Trade;

            IsCseLevel1 = string.Equals(form.CSELevel, "1");
            IsCseLevel2 = string.Equals(form.CSELevel, "2");
            IsCseLevel3 = string.Equals(form.CSELevel, "3");

            JobDescription = form.JobDescription;

            TradeRtf = tradeChecklist.Content;

            // replace approvals from the form with the approvers of the checklist
            var areaManagerApprover = new ApprovalReportAdapter(tradeChecklist.IdValue,
                FormGN1.AreaManagerApprovalName,
                tradeChecklist.AreaManagerApprover,
                tradeChecklist.AreaManagerApprovalDateTime,
                null);
            var opsCoordinatorApprover = new ApprovalReportAdapter(tradeChecklist.IdValue,
                FormGN1.OpsCoordApprovalName,
                tradeChecklist.OpsCoordApprover,
                tradeChecklist.OpsCoordApprovalDateTime,
                null);
            var maintCoordApprover = new ApprovalReportAdapter(tradeChecklist.IdValue,
                FormGN1.ConstFieldMaintCoordApprovalName,
                tradeChecklist.ConstFieldMaintCoordApprover,
                tradeChecklist.ConstFieldMaintCoordApprovalDateTime,
                null);
            ApprovalsReportAdapters = new List<ApprovalReportAdapter>
            {
                maintCoordApprover,
                opsCoordinatorApprover,
                areaManagerApprover
            };

            TradeChecklistNumber = FormatTradeChecklistNumber(tradeChecklist);
        }

        public string FunctionalLocation { get; private set; }
        public string Location { get; private set; }

        public string Trade { get; private set; }
        public bool IsCseLevel1 { get; private set; }
        public bool IsCseLevel2 { get; private set; }
        public bool IsCseLevel3 { get; private set; }

        public string JobDescription { get; private set; }

        public string TradeRtf { get; private set; }
        public string TradeChecklistNumber { get; private set; }

        public long TradeChecklistId { get; private set; }

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

        private string FormatTradeChecklistNumber(TradeChecklist tradeChecklist)
        {
            if (tradeChecklist.ParentFormNumber != null)
            {
                return string.Format("{0}-{1}", PadFormNumber(tradeChecklist.ParentFormNumber.GetValueOrDefault(0)),
                    tradeChecklist.TradeChecklistDisplayNumber);
            }

            return tradeChecklist.TradeChecklistDisplayNumber;
        }
    }
}