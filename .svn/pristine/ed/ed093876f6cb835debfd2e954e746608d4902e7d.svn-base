using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class DailyShiftLogReport : XtraReport, IOltReport<DailyShiftLogReportAdapter>
    {
        public DailyShiftLogReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<DailyShiftLogReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters.Count > 0)
            {
                var adapter = adapters[0];
                subreportTags.ReportSource.DataSource = adapter.TagAdapters;
                subreportLogs.ReportSource.DataSource = adapter.CommentsAdapters;
            }
        }
    }
}