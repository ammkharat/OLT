using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class ContractorGridRenderer : AbstractSimpleGridRenderer
    {
        private const string COMPANY_NAME_COLUMN_KEY = "CompanyName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[COMPANY_NAME_COLUMN_KEY].Format(RendererStringResources.CompanyName, 1);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(COMPANY_NAME_COLUMN_KEY, false);
        }
    }
}
