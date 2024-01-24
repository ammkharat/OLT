using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.GNForm;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN1Report : XtraReport, IOltReport<FormGN1ReportAdapter>
    {
        public FormGN1Report()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN1ReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            var formReportAdapter = adapters[0];

            var formGn1PlanningWorksheetReport =
                planningWorksheetSubreport.ReportSource as FormGN1PlanningWorksheetReport;
            if (formGn1PlanningWorksheetReport != null)
            {
                formGn1PlanningWorksheetReport.SetMasterAndSubReportDataSource(adapters, currentTimeInSite);
            }

            var formGn1LogSheetReport = logSheetSubreport.ReportSource as FormGN1LogSheetReport;
            if (formGn1LogSheetReport != null)
            {
                formGn1LogSheetReport.SetMasterAndSubReportDataSource(adapters, currentTimeInSite);
            }

            var formGn1TradeChecklistReport = tradeCheckListSubreport.ReportSource as FormGN1TradeChecklistReport;
            if (formGn1TradeChecklistReport != null)
            {
                formGn1TradeChecklistReport.SetMasterAndSubReportDataSource(formReportAdapter.TradeAdapters,
                    currentTimeInSite);
            }

            var formGn1TechnicalRescuePlanReport =
                technicalRescuePlanSubreport.ReportSource as FormGN1TechnicalRescuePlanReport;
            if (formGn1TechnicalRescuePlanReport != null)
            {
                formGn1TechnicalRescuePlanReport.SetMasterAndSubReportDataSource(
                    formReportAdapter.RescuePlanReportAdapters, currentTimeInSite);
            }
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}