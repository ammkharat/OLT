using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitUSPipelineReport : XtraReport, IOltReport<WorkPermitUSPipelineReportAdapter>
    {
        public WorkPermitUSPipelineReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitUSPipelineReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;

            if (adapters.Count > 0)
            {
                precautionsTooLongLabel.Visible = adapters[0].SpecialPrecautionsOrConsiderationsTooLong;
            }
        }

        public bool StringWillFitIntoSpecialPrecautionsOrConsiderationsField(string hazardsAndOrRequirements)
        {
            return DevExpressMeasurementUtility.StringWillFitIntoField(GetAttributesForPrecautionsLabel(),
                hazardsAndOrRequirements);
        }

        public LabelAttributes GetAttributesForPrecautionsLabel()
        {
            return Precautions1.CreateLabelAttributes();
        }
    }
}