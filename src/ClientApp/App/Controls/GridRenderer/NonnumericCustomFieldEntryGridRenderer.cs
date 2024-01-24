using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class NonnumericCustomFieldEntryGridRenderer : AbstractSimpleGridRenderer
    {
        private const string DateTimeColumnKey = "DateTime";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            int position = 0;

            band.Columns[DateTimeColumnKey].FormatAsDateTime(RendererStringResources.DateTime, position++, 200);
            band.Columns["Value"].Format(RendererStringResources.Entry, position++, 250);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(DateTimeColumnKey, true);
        }
    }
}
