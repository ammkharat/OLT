using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public abstract class EdmontonFormPrintActions<TBaseEdmontonForm, TFormReport, TFormReportAdapter> :
        PrintActions<TBaseEdmontonForm, TFormReport, TFormReportAdapter>
        where TBaseEdmontonForm : BaseEdmontonForm
        where TFormReportAdapter : BaseEdmontonFormReportAdapter
        where TFormReport : XtraReport, IOltReport<TFormReportAdapter>
    {
        public override string ReportTitle(TBaseEdmontonForm domainObject)
        {
            return domainObject.FormType.GetName();
        }

        protected override void AddPageSpecificWatermarks(TFormReport report, IEnumerable<TFormReportAdapter> adapters)
        {
            foreach (var adapter in adapters)
            {
                var textWatermark = CreateTextWatermark(adapter.Status);
                foreach (Page page in report.Pages)
                {
                    page.AssignWatermark(textWatermark);
                }
            }
        }

        protected void AddPageSpecificWatermarksBasedOnDeletedAndStatus(TFormReport report, IEnumerable<TFormReportAdapter> adapters)
        {
            foreach (var adapter in adapters)
            {
                var watermarkText = adapter.IsDeleted ? "Deleted" : adapter.Status;
                var textWatermark = CreateTextWatermark(watermarkText);
                foreach (Page page in report.Pages)
                {
                    page.AssignWatermark(textWatermark);
                }
            }
        }

        protected override ReportPrintPreference CreateReportPrintPreference(TFormReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}