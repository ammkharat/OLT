using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class RestrictionReasonCodeGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_COLUMN_KEY = "Name";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.ReasonCode, 0, 50);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }
    }
}