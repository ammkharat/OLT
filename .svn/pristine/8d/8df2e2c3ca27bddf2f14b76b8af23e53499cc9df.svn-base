using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitLubesReport : XtraReport, IOltReport<WorkPermitLubesReportAdapter>
    {
        public WorkPermitLubesReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitLubesReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            descriptionTooLongLabel.Visible = !adapters[0].TaskDescriptionTooLongWarning.IsNullOrEmptyOrWhitespace();
            hazardsTooLongLabel.Visible = !adapters[0].HazardsTooLongWarning.IsNullOrEmptyOrWhitespace();
        }

        public bool StringWillFitIntoTaskDescriptionField(string description)
        {
            return DevExpressMeasurementUtility.StringWillFitIntoField(GetAttributesForTaskDescriptionLabel(),
                description);
        }

        public bool StringWillFitIntoHazardsField(string hazardsAndOrRequirements)
        {
            return DevExpressMeasurementUtility.StringWillFitIntoField(GetAttributesForHazardsLabel(),
                hazardsAndOrRequirements);
        }

        public LabelAttributes GetAttributesForHazardsLabel()
        {
            return otherHazardsLabel.CreateLabelAttributes();
        }

        public LabelAttributes GetAttributesForTaskDescriptionLabel()
        {
            return descriptionOfWorkLabel.CreateLabelAttributes();
        }
    }
}