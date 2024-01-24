using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN6Report : XtraReport, IOltReport<FormGN6ReportAdapter>
    {
        public FormGN6Report()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGN6ReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            var formReportAdapter = adapters[0];
            flocSubreport.ReportSource.DataSource = formReportAdapter.FunctionalLocationReportAdapters;
            approvalsSubreport.ReportSource.DataSource = formReportAdapter.ApprovalsReportAdapters;
            sectionsSubreport.ReportSource.DataSource = formReportAdapter.FormGN6SectionReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}