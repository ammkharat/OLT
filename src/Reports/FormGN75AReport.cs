using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN75AReport : XtraReport, IOltReport<FormGN75AReportAdapter>
    {
        public FormGN75AReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN75AReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            var reportAdapter = adapters[0];
            approvalsSubreport.ReportSource.DataSource = reportAdapter.ApprovalsReportAdapters;
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}