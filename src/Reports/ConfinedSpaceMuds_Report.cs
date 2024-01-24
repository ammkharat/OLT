using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class ConfinedSpaceMuds_Report : XtraReport, IOltReport<ConfinedSpaceMudsReportAdapter>
    {
        public ConfinedSpaceMuds_Report()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<ConfinedSpaceMudsReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
        }
    }
}