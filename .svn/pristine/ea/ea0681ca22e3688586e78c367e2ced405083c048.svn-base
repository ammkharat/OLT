using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.GNForm;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN1SingleTradeChecklistReport : XtraReport, IOltReport<FormGN1TradeChecklistReportAdapter>
    {
        public FormGN1SingleTradeChecklistReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN1TradeChecklistReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;

            var formGn1TradeChecklistReport = tradeCheckListSubreport.ReportSource as FormGN1TradeChecklistReport;
            if (formGn1TradeChecklistReport != null)
            {
                formGn1TradeChecklistReport.SetMasterAndSubReportDataSource(adapters, currentTimeInSite);
            }

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}