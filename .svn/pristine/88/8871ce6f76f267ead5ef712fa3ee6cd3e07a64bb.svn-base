using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitMontrealReport : XtraReport, IOltReport<WorkPermitMontrealReportAdapter>
    {
        public WorkPermitMontrealReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitMontrealReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
            //xrPanel4.LocationF = new PointF(0, 2800);
        }
    }
}