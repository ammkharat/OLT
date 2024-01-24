using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitSarniaReport : XtraReport, IOltReport<WorkPermitSarniaReportAdapter>
    {
        public WorkPermitSarniaReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitSarniaReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }
    }
}