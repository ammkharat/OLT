using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.GNForm
{
    public partial class FormGN1LogSheetReport : XtraReport, IOltReport<FormGN1ReportAdapter>
    {
        public FormGN1LogSheetReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN1ReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}