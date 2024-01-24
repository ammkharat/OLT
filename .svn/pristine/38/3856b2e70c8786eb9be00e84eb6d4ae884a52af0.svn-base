using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LabAlertGridRenderer : AbstractPageGridRenderer
    {
        private const string NAME_COLUMN_KEY = "Name";
        private const string CREATED_DATE_COLUMN_KEY = "CreatedDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";

        private readonly bool showNumberOfSamples = true;
        private readonly IImageGridColumn statusColumn;

        public LabAlertGridRenderer(bool showNumberOfSamples) : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.showNumberOfSamples = showNumberOfSamples;

            statusColumn = new LabAlertStatusImageColumn();
            AddImageColumn(statusColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);

            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.Name, column++, 125);
            band.Columns["TagName"].Format(RendererStringResources.Tag, column++, 125);
            if (showNumberOfSamples)
            {
                band.Columns["MinimumNumberOfSamples"].Format(RendererStringResources.MinNumber, column++, 50);
                band.Columns["ActualNumberOfSamples"].Format(RendererStringResources.ActualNumber, column++, 70);
            }
            band.Columns[CREATED_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Date, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(CREATED_DATE_COLUMN_KEY, true);
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }
    }
}