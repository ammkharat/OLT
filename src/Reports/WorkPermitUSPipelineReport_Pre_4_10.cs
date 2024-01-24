using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitUSPipelineReport_Pre_4_10 : XtraReport, IOltReport<WorkPermitUSPipelineReportAdapter>
    {
        public WorkPermitUSPipelineReport_Pre_4_10()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitUSPipelineReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }
    }
}