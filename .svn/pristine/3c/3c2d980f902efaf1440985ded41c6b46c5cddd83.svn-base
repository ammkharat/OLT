using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGenericTemplateReport : XtraReport, IOltReport<FormGenericTemplateReportAdapter>
    {
        public FormGenericTemplateReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormGenericTemplateReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            FormReportAdapter formReportAdapter = adapters[0];
            flocSubreport.ReportSource.DataSource = formReportAdapter.FunctionalLocationReportAdapters;
            approvalsSubreport.ReportSource.DataSource = formReportAdapter.ApprovalsReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}