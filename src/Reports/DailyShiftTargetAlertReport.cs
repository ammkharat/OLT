using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class DailyShiftTargetAlertReport : XtraReport, IOltReport<DailyShiftTargetAlertReportAdapter>
    {
        public DailyShiftTargetAlertReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<DailyShiftTargetAlertReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }
    }
}