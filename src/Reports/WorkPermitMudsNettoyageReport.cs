using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitMudsNettoyageReport : XtraReport,
        IOltReport<WorkPermitMudsNettoyageReportAdapter>
    {
        public WorkPermitMudsNettoyageReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitMudsNettoyageReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
        }
    }
}