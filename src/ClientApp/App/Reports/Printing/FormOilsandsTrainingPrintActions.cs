using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting.Drawing;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class FormOilsandsTrainingPrintActions : PrintActions<FormOilsandsTraining, FormOilsandsTrainingReport, FormOilsandsTrainingReportAdapter>
    {
        protected override FormOilsandsTrainingReport CreateSpecificReport()
        {
            return new FormOilsandsTrainingReport();
        }

        protected override List<FormOilsandsTrainingReportAdapter> CreateReportAdapter(FormOilsandsTraining domainObject)
        {
            return new List<FormOilsandsTrainingReportAdapter> {new FormOilsandsTrainingReportAdapter(domainObject)};
        }

        public override string ReportTitle(FormOilsandsTraining domainObject)
        {
            return StringResources.DomainObjectName_FormOilsandsTraining;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormOilsandsTrainingReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }

        protected override void AddPageSpecificWatermarks(FormOilsandsTrainingReport report, IEnumerable<FormOilsandsTrainingReportAdapter> adapters)
        {
            foreach (FormOilsandsTrainingReportAdapter adapter in adapters)
            {
                Watermark textWatermark = CreateTextWatermark(adapter.WatermarkText);
                foreach (DevExpress.XtraPrinting.Page page in report.Pages)
                {
                    page.AssignWatermark(textWatermark);
                }
            }
        }
    }
}
 