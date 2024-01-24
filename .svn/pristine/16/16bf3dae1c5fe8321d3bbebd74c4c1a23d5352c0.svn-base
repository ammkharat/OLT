using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ProcedureDeviationReportPrintActions :
        PrintActions
            <ProcedureDeviation, ProcedureDeviationReport, ProcedureDeviationReportAdapter>
    {
        protected override ProcedureDeviationReport CreateSpecificReport()
        {
            return new ProcedureDeviationReport();
        }


        protected override List<ProcedureDeviationReportAdapter> CreateReportAdapter(
            ProcedureDeviation domainObject)
        {
            return new List<ProcedureDeviationReportAdapter>
            {
                new ProcedureDeviationReportAdapter(domainObject)
            };
        }

        public override string ReportTitle(ProcedureDeviation domainObject)
        {
            return StringResources.SafeWorkPermitAssessmentReportTitle;
        }
        protected override void AddPageSpecificWatermarks(ProcedureDeviationReport report, IEnumerable<ProcedureDeviationReportAdapter> adapters)
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
            ProcedureDeviationReport report,
            UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}