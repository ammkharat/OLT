using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class DailyShiftTargetAlertGapReasonReport : XtraReport,
        IOltReport<DailyShiftTargetAlertGapReasonReportAdapter>
    {
        public DailyShiftTargetAlertGapReasonReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<DailyShiftTargetAlertGapReasonReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }
    }
}