using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormGN75BReport : XtraReport, IOltReport<FormGN75BReportAdapter>
    {
        public FormGN75BReport()
        {
            InitializeComponent();

            //xrTableCell4.ForeColor = Color.FromArgb(150, 204, 204, 204);          
        }

        public void SetMasterAndSubReportDataSource(List<FormGN75BReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;

            DataSource = adapters;
            var formGn75BReportAdapter = adapters[0];
            isolationsSubreport.ReportSource.DataSource = formGn75BReportAdapter.IsolationReportAdapters;
            if (adapters[0].OperatorLabel != null)
            {
                operatorLabel.Text = adapters[0].OperatorLabel;
                    //RITM0468037EN50 : OLT:: Edmonton:: GN75B changes Aarti 
            }
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}