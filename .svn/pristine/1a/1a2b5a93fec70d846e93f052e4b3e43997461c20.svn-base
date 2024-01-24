using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DocumentSuggestionReportPrintActions :
        PrintActions
            <DocumentSuggestion, DocumentSuggestionReport, DocumentSuggestionReportAdapter>
    {
        protected override DocumentSuggestionReport CreateSpecificReport()
        {
            return new DocumentSuggestionReport();
        }

        protected override List<DocumentSuggestionReportAdapter> CreateReportAdapter(
            DocumentSuggestion domainObject)
        {
            return new List<DocumentSuggestionReportAdapter>
            {
                new DocumentSuggestionReportAdapter(domainObject)
            };
        }

        public override string ReportTitle(DocumentSuggestion domainObject)
        {
            return StringResources.SafeWorkPermitAssessmentReportTitle;
        }
        protected override void AddPageSpecificWatermarks(DocumentSuggestionReport report, IEnumerable<DocumentSuggestionReportAdapter> adapters)
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
            DocumentSuggestionReport report,
            UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}