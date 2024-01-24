using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class OnPremisePersonnelShiftReport : XtraReport,
        IOltReport<OnPremisePersonnelShiftReportAdapter>
    {
        public OnPremisePersonnelShiftReport()
        {
            InitializeComponent();
            reportTitle.Text = StringResources.OnPremisePersonnelShiftReportTitle;
            reportTitle.NullValueText = StringResources.OnPremisePersonnelShiftReportTitle;
        }

        public void SetMasterAndSubReportDataSource(List<OnPremisePersonnelShiftReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
            {
                return;
            }
            DataSource = adapters;

            var onPremisePersonnelShiftReportDetailsAdapters =
                new List<OnPremisePersonnelShiftReportDetailsAdapter>();
            adapters.ForEach(
                a =>
                    onPremisePersonnelShiftReportDetailsAdapters.AddRange(a.OnPremisePersonnelShiftReportDetailsAdapters));
            onPremisePersonnelShiftSubreport.ReportSource.DataSource = onPremisePersonnelShiftReportDetailsAdapters;
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}