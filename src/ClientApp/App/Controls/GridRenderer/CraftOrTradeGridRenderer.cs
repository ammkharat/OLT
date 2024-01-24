using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class CraftOrTradeGridRenderer : AbstractSimpleGridRenderer
    {
        private const string CRAFT_OR_TRADE_NAME_COLUMN_KEY = "Name";
        private const string CRAFT_OR_TRADE_WORK_CENTER_COLUMN_KEY = "WorkCenterCode";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[CRAFT_OR_TRADE_NAME_COLUMN_KEY].Format(RendererStringResources.Name, 2, 225);
            band.Columns[CRAFT_OR_TRADE_WORK_CENTER_COLUMN_KEY].Format(RendererStringResources.WorkCentre, 3);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(CRAFT_OR_TRADE_NAME_COLUMN_KEY, false);
            sortedColumns.Add(CRAFT_OR_TRADE_WORK_CENTER_COLUMN_KEY, false);
        }
    }
}
