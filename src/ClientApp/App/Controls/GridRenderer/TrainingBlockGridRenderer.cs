using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class TrainingBlockGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_COLUMN_KEY = "Name";
        private const string CODE_COLUMN_KEY = "Code";
        
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            band.HideAllColumns();

            int column = 0;
            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.TrainingBlock, column++, 300);
            band.Columns[CODE_COLUMN_KEY].Format(RendererStringResources.TrainingCode, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }
    }
}
