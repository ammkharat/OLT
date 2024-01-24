using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ConfinedSpaceGridRenderer : AbstractPageGridRenderer
    {
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocationName";
        private const string CONFINED_SPACE_NUMBER_COLUMN_KEY = "ConfinedSpaceNumberDisplayValue";
        private const string START_DATE_TIME_COLUMN_KEY = "StartDateTime";
        private const string LAST_EDITOR = "LastModifiedByFullnameWithUserName";

        protected readonly ConfinedSpaceStatusImageColumn statusImageColumn;

        public ConfinedSpaceGridRenderer()
            : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            statusImageColumn = new ConfinedSpaceStatusImageColumn();
            AddImageColumn(statusImageColumn);

        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
            band.Columns[CONFINED_SPACE_NUMBER_COLUMN_KEY].Format(RendererStringResources.Number, column++, 75);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 200);
            band.Columns[START_DATE_TIME_COLUMN_KEY].FormatAsDate(RendererStringResources.Start, column++, 125);
            band.Columns[LAST_EDITOR].FormatAsDate(RendererStringResources.LastEditor, column++, 100);

        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATE_TIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { CONFINED_SPACE_NUMBER_COLUMN_KEY };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { CONFINED_SPACE_NUMBER_COLUMN_KEY };
        }
    }
}