using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class SingleColumnGridRenderer : AbstractSimpleGridRenderer
    {
        private readonly string columnHeader;
        private readonly string columnFieldName;

        public SingleColumnGridRenderer(string columnHeader, string columnFieldName)
        {
            this.columnHeader = columnHeader;
            this.columnFieldName = columnFieldName;
        }

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[columnFieldName].Format(columnHeader, 0, 240);
        }
    }
}
