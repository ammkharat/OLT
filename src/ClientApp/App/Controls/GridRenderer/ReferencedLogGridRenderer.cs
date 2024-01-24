using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ReferencedLogGridRenderer : AbstractSimpleGridRenderer
    {
        private const string LOGGED_DATE_TIME_COLUMN_KEY = "LoggedDate";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int column = 0;

            band.HideAllColumns();
            band.Columns[LOGGED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LogDate, column++);
            band.Columns["Assignment"].Format(RendererStringResources.Assignment, column++, 100);
            band.Columns["CreatedByUser"].Format(RendererStringResources.CreatedBy, column++, 100);
            band.Columns["AllComments"].Format(RendererStringResources.Comments, column, 100); 
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(LOGGED_DATE_TIME_COLUMN_KEY, false);
        }
    }
}
