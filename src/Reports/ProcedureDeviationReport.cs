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
    public partial class ProcedureDeviationReport : XtraReport,
        IOltReport<ProcedureDeviationReportAdapter>
    {
        public ProcedureDeviationReport()
        {
            InitializeComponent();
            immediateApprovalsSubreport.BeforePrint += HandleApprovalSubreportBeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<ProcedureDeviationReportAdapter> adapters,
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

            var documentLinksReportAdapters =
           new List<DocumentLinkReportAdapter>();
            adapters.ForEach(a => documentLinksReportAdapters.AddRange(a.DocumentLinkReportAdapters));
            documentLinksSubReport.ReportSource.DataSource = documentLinksReportAdapters;

            var extensionReasonReportAdapters = new List<ExtensionReasonReportAdapter>();
            adapters.ForEach(adapter => extensionReasonReportAdapters.AddRange(adapter.ExtensionReasonComments));
            extensionReasonSubreport.ReportSource.DataSource = extensionReasonReportAdapters;

            var immediateReportAdapters = new List<ApprovalReportAdapter>();
            adapters.ForEach(adapter => immediateReportAdapters.AddRange(adapter.ImmediateApprovalReportAdapters));
            immediateApprovalsSubreport.ReportSource.DataSource = immediateReportAdapters;

            var temporaryReportAdapters = new List<ApprovalReportAdapter>();
            adapters.ForEach(adapter => temporaryReportAdapters.AddRange(adapter.TemporaryApprovalReportAdapters));
            temporaryApprovalsSubReport.ReportSource.DataSource = temporaryReportAdapters;
               
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void HandleApprovalSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var formId = GetCurrentColumnValue<long>("FormId");
            var subReport =
                (ApprovalSubReport) immediateApprovalsSubreport.ReportSource;
            subReport.ParentIdParam.Value = formId;
        }

    }
}