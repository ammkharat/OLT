using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.DocumentSuggestion;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class DocumentSuggestionReport : XtraReport,
        IOltReport<DocumentSuggestionReportAdapter>
    {
        public DocumentSuggestionReport()
        {
            InitializeComponent();
            approvalsSubreport.BeforePrint += HandleApprovalSubreportBeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<DocumentSuggestionReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
            {
                return;
            }

            DataSource = adapters;

            var functionalLocationReportAdapters =
                new List<FunctionalLocationReportAdapter>();
            adapters.ForEach(a => functionalLocationReportAdapters.AddRange(a.FunctionalLocationReportAdapters));
            flocSubreport.ReportSource.DataSource = functionalLocationReportAdapters;

            var extensionReasonReportAdapters = new List<ExtensionReasonReportAdapter>();
            adapters.ForEach(adapter => extensionReasonReportAdapters.AddRange(adapter.ExtensionReasonComments));
            extensionReasonSubreport.ReportSource.DataSource = extensionReasonReportAdapters;

            var approvalReportAdapters = new List<ApprovalReportAdapter>();
            adapters.ForEach(adapter => approvalReportAdapters.AddRange(adapter.ApprovalReportAdapters));
            approvalsSubreport.ReportSource.DataSource = approvalReportAdapters;
               
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void HandleApprovalSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var formId = GetCurrentColumnValue<long>("FormId");
            var subReport =
                (ApprovalSubReport) approvalsSubreport.ReportSource;
            subReport.ParentIdParam.Value = formId;
        }

    }
}