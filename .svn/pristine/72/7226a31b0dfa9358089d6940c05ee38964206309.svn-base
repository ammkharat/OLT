using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class RestrictionDefinitionGridRenderer : AbstractPageGridRenderer
    {
        private const string NAME_COLUMN_KEY = "Name";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";
        private const string DESCRIPTION_COLUMN_KEY = "Description";

        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn isActiveColumn;
        private readonly IImageGridColumn isOnlyVisibleOnReportsColumn;

        public RestrictionDefinitionGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            statusColumn = new RestrictionDefinitionStatusImageColumn();
            AddImageColumn(statusColumn);

            isActiveColumn = new IsActiveImageColumn<RestrictionDefinitionDTO>();
            AddImageColumn(isActiveColumn);

            isOnlyVisibleOnReportsColumn = new IsOnlyVisibleOnReportsImageColumn<RestrictionDefinitionDTO>();
            AddImageColumn(isOnlyVisibleOnReportsColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString(statusColumn.ColumnKey, statusColumn.ColumnCaption, 62);
            columnFormatter.FormatAsString(isActiveColumn.ColumnKey, isActiveColumn.ColumnCaption, 62);
            columnFormatter.FormatAsString(isOnlyVisibleOnReportsColumn.ColumnKey, isOnlyVisibleOnReportsColumn.ColumnCaption, 62);

            columnFormatter.FormatAsString(FUNCTIONAL_LOCATION_COLUMN_KEY, RendererStringResources.Floc, 90);
            columnFormatter.FormatAsString(NAME_COLUMN_KEY, RendererStringResources.Name);
            columnFormatter.FormatAsString("MeasurementTagName", RendererStringResources.MeasurementTag);
            columnFormatter.FormatAsString("ProductionTarget", RendererStringResources.ProductionTarget);
            columnFormatter.FormatAsString(DESCRIPTION_COLUMN_KEY, RendererStringResources.Description, 145);
            columnFormatter.FormatAsString("LastModifiedFullNameWithUserName", RendererStringResources.EditedBy);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }
    }
}