using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LabAlertResponseGridRenderer : AbstractSimpleGridRenderer
    {
        private const string CREATED_DATETIME_COLUMN_KEY = "CreatedDateTime";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int column = 0;

            band.HideAllColumns();
            band.Columns["StatusName"].Format(RendererStringResources.Status, column++); 
            band.Columns["CreatedByUserFullNameWithUserName"].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[CREATED_DATETIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Date, column++);
            band.Columns["Comments"].Format(RendererStringResources.Comments, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(CREATED_DATETIME_COLUMN_KEY, true);
        }
    }
}