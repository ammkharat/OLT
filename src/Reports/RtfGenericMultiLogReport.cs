using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class RtfGenericMultiLogReport : XtraReport, IOltReport<GenericMultiLogReportAdapter>
    {
        public RtfGenericMultiLogReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<GenericMultiLogReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null)
                return;

            DataSource = adapters;

            if (adapters.Count > 0)
            {
                var flocAdapters = new List<FunctionalLocationReportAdapter>();
                var documentLinkReportAdapters = new List<DocumentLinkReportAdapter>();
                var customFieldsReportAdapters = new List<CustomFieldsReportAdapter>();

                adapters.ForEach(a =>
                {
                    flocAdapters.AddRange(a.FlocReportAdapters);
                    documentLinkReportAdapters.AddRange(a.DocumentLinkReportAdapters);
                    customFieldsReportAdapters.AddRange(a.CustomFieldReportAdapters);
                });

                flocSubReport.ReportSource.DataSource = flocAdapters;
                documentLinksSubreport.ReportSource.DataSource = documentLinkReportAdapters;
                customFieldsSubreport.ReportSource.DataSource = customFieldsReportAdapters;
            }
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
    }
}