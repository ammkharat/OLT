using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.GNForm
{
    public partial class FormGN1TradeChecklistReport : XtraReport, IOltReport<FormGN1TradeChecklistReportAdapter>
    {
        public FormGN1TradeChecklistReport()
        {
            InitializeComponent();
            approvalsSubreport.BeforePrint += approvalsSubreport_BeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<FormGN1TradeChecklistReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;

            var approvalReportAdapters = new List<ApprovalReportAdapter>(0);
            adapters.ForEach(tradeChecklist => approvalReportAdapters.AddRange(tradeChecklist.ApprovalsReportAdapters));

            approvalsSubreport.ReportSource.DataSource = approvalReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void approvalsSubreport_BeforePrint(object sender, PrintEventArgs e)
        {
            var tradeChecklistId = GetCurrentColumnValue<long>("TradeChecklistId");

            var gnFormApprovalReport = approvalsSubreport.ReportSource as GNFormApprovalReport;
            if (gnFormApprovalReport != null)
            {
                gnFormApprovalReport.ParentIdParam.Value = tradeChecklistId;
            }
        }
    }
}