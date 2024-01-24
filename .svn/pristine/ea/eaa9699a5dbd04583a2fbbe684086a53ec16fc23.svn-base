using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN59ChecklistReport : XtraReport, IOltReport<FormGN59ChecklistReportAdapter>
    {
        public FormGN59ChecklistReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN59ChecklistReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}