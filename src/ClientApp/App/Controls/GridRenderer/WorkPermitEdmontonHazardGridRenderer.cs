using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitEdmontonHazardGridRenderer : AbstractPageGridRenderer
    {
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitEdmontonHazardDTO> statusImageColumn;

        private const string ISSUED_DATE_COLUMN_KEY = "IssuedDateTime";
        private const string CREATED_BY_COLUMN_KEY = "CreatedByFullnameWithUserName";
        private const string OCCUPATION_COLUMN_KEY = "Occupation";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string HAZARD_COLUMN_KEY = "Hazards";

        public WorkPermitEdmontonHazardGridRenderer()
        {
            statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitEdmontonHazardDTO>();
            AddImageColumn(statusImageColumn);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(ISSUED_DATE_COLUMN_KEY, true);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);

            band.Columns[ISSUED_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Issued, column++);
            band.Columns[CREATED_BY_COLUMN_KEY].FormatAsDateTime(RendererStringResources.CreatedBy, column++);
            band.Columns[OCCUPATION_COLUMN_KEY].Format(RendererStringResources.Occupation, column++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 200);
            band.Columns[HAZARD_COLUMN_KEY].Format(RendererStringResources.HazardsAndOrRequirements, column++, 200);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY, HAZARD_COLUMN_KEY };
        }
    }
}
