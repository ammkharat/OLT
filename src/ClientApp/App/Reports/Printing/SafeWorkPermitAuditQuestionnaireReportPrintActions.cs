using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class SafeWorkPermitAuditQuestionnaireReportPrintActions :
        PrintActions
            <PermitAssessment, SafeWorkPermitAuditQuestionnaireReport, SafeWorkPermitAuditQuestionnaireReportAdapter>
    {
        protected override SafeWorkPermitAuditQuestionnaireReport CreateSpecificReport()
        {
            return new SafeWorkPermitAuditQuestionnaireReport();
        }

        protected override List<SafeWorkPermitAuditQuestionnaireReportAdapter> CreateReportAdapter(
            PermitAssessment domainObject)
        {
            return new List<SafeWorkPermitAuditQuestionnaireReportAdapter>
            {
                new SafeWorkPermitAuditQuestionnaireReportAdapter(domainObject)
            };
        }

        public override string ReportTitle(PermitAssessment domainObject)
        {
            return StringResources.SafeWorkPermitAssessmentReportTitle;
        }
        protected override void AddPageSpecificWatermarks(SafeWorkPermitAuditQuestionnaireReport report, IEnumerable<SafeWorkPermitAuditQuestionnaireReportAdapter> adapters)
        {
            foreach (var adapter in adapters)
            {
                var textWatermark = CreateTextWatermark(adapter.WatermarkText);
                foreach (Page page in report.Pages)
                {
                    page.AssignWatermark(textWatermark);
                }
            }
        }
        protected override ReportPrintPreference CreateReportPrintPreference(
            SafeWorkPermitAuditQuestionnaireReport report,
            UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}