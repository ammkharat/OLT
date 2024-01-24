using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class ConfinedSpaceMontrealReport : XtraReport, IOltReport<ConfinedSpaceMontrealReportAdapter>
    {
        public ConfinedSpaceMontrealReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<ConfinedSpaceMontrealReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
        }
    }
}