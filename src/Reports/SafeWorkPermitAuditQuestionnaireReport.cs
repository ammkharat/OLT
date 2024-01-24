using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.PermitAssessment;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class SafeWorkPermitAuditQuestionnaireReport : XtraReport,
        IOltReport<SafeWorkPermitAuditQuestionnaireReportAdapter>
    {
        public SafeWorkPermitAuditQuestionnaireReport()
        {
            InitializeComponent();
            permitAssessmentAnswerSubreport.BeforePrint += HandlePermitAssessmentAnswerSubreportBeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<SafeWorkPermitAuditQuestionnaireReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
            {
                return;
            }

            DataSource = adapters;

            var permitAssessmentAnswerReportAdapters =
                new List<PermitAssessmentAnswerReportAdapter>();
            adapters.ForEach(a => permitAssessmentAnswerReportAdapters.AddRange(a.PermitAssessmentAnswers));
            var functionalLocationReportAdapters =
                new List<FunctionalLocationReportAdapter>();
            adapters.ForEach(a => functionalLocationReportAdapters.AddRange(a.FunctionalLocationReportAdapters));
            permitAssessmentAnswerSubreport.ReportSource.DataSource = permitAssessmentAnswerReportAdapters;
            flocSubreport.ReportSource.DataSource = functionalLocationReportAdapters;
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void HandlePermitAssessmentAnswerSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var safeWorkPermitAuditQuestionaireId = GetCurrentColumnValue<long>("FormId");
            var subReport =
                (PermitAssessmentAnswerSubReport) permitAssessmentAnswerSubreport.ReportSource;
            subReport.parentIdParam.Value = safeWorkPermitAuditQuestionaireId;
        }
    }
}