using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.OvertimeForm;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormOvertimeFormReport : XtraReport,
        IOltReport<FormOvertimeFormReportAdapter>
    {
        public FormOvertimeFormReport()
        {
            InitializeComponent();
            onPremiseContractorsSubreport.BeforePrint += HandleOnPremiseContractorsSubreportBeforePrint;
            approvalsSubreport.BeforePrint += HandleApprovalsSubreportBeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<FormOvertimeFormReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
            {
                return;
            }

            DataSource = adapters;

            var approvalReportAdapters = new List<ApprovalReportAdapter>();
            adapters.ForEach(a => approvalReportAdapters.AddRange(a.ApprovalReportAdapters));
            approvalsSubreport.ReportSource.DataSource = approvalReportAdapters;

            var onPremiseContractorReportAdapters =
                new List<OnPremiseContractorReportAdapter>();
            adapters.ForEach(a => onPremiseContractorReportAdapters.AddRange(a.OnPremiseContractorReportAdapters));
            onPremiseContractorsSubreport.ReportSource.DataSource = onPremiseContractorReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void HandleOnPremiseContractorsSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var trainingFormId = GetCurrentColumnValue<long>("FormId");
            var subReport =
                (OnPremiseContractorSubReport) onPremiseContractorsSubreport.ReportSource;
            subReport.parentIdParam.Value = trainingFormId;
        }

        private void HandleApprovalsSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var trainingFormId = GetCurrentColumnValue<long>("FormId");
            var subReport = (ApprovalReport) approvalsSubreport.ReportSource;
            subReport.ParentIdParam.Value = trainingFormId;
        }
    }
}