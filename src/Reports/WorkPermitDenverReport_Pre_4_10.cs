using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitDenverReport_Pre_4_10 : XtraReport, IOltReport<WorkPermitDenverReportAdapter>
    {
        public WorkPermitDenverReport_Pre_4_10()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitDenverReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }
    }
}