using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DeviationAlertGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATE_TIME_COLUMN_KEY = "StartDateTime";
        private const string NAME_COLUMN_KEY = "RestrictionDefinitionName";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";

        private const bool RIGHT_JUSTIFY_VALUE = true;

        private readonly bool sortByStatus;
        private readonly IImageGridColumn statusColumn;
        
        public DeviationAlertGridRenderer(bool sortByStatus) : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.sortByStatus = sortByStatus;

            statusColumn = new DeviationAlertStatusImageColumn();
            AddImageColumn(statusColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);

            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.RestrictionDefinition, column++);
            band.Columns["MeasurementValue"].FormatAsInt(RendererStringResources.Measurement, column++, 100, RIGHT_JUSTIFY_VALUE);
            band.Columns["ProductionTargetValue"].FormatAsInt(RendererStringResources.Target, column++, 100, RIGHT_JUSTIFY_VALUE);
            band.Columns["DeviationValue"].FormatAsInt(RendererStringResources.Deviation, column++, 80, RIGHT_JUSTIFY_VALUE);
            band.Columns[START_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Start, column++);
            band.Columns["EndDateTime"].FormatAsDateTime(RendererStringResources.End, column++);                 
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            if (sortByStatus)
            {
                sortedColumns.Add(statusColumn.ColumnKey, false);
            }
            sortedColumns.Add(START_DATE_TIME_COLUMN_KEY, false);
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }

        
    }
}