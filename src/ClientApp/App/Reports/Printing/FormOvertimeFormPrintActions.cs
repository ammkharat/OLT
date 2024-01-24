using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class FormOvertimeFormPrintActions : PrintActions<OvertimeForm, FormOvertimeFormReport, FormOvertimeFormReportAdapter>
    {
        protected override FormOvertimeFormReport CreateSpecificReport()
        {
            return new FormOvertimeFormReport();
        }

        protected override List<FormOvertimeFormReportAdapter> CreateReportAdapter(OvertimeForm domainObject)
        {
            return new List<FormOvertimeFormReportAdapter> {new FormOvertimeFormReportAdapter(domainObject)};
        }

        public override string ReportTitle(OvertimeForm domainObject)
        {
            return StringResources.DomainObjectName_OvertimeForm;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormOvertimeFormReport report, UserPrintPreference userPrintPreferences)
        {
            var reportPrintPreference = new ReportPrintPreference(report, 1, true, false, string.Empty, true);
            return reportPrintPreference;
        }

        protected override void AddPageSpecificWatermarks(FormOvertimeFormReport report, IEnumerable<FormOvertimeFormReportAdapter> adapters)
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
    }
}