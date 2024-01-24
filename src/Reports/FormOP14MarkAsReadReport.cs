using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormOP14MarkAsReadReport : XtraReport, IOltReport<FormOP14MarkAsReadReportAdapter>
    {
        public FormOP14MarkAsReadReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<FormOP14MarkAsReadReportAdapter> adapters, DateTime currentTimeInSite)
        {
            DataSource = adapters;
        }

    }
}

