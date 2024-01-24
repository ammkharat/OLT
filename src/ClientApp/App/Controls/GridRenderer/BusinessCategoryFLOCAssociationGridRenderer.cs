using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class BusinessCategoryFLOCAssociationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string BUSINESS_CATEGORY_NAME_KEY = "BusinessCategoryName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[BUSINESS_CATEGORY_NAME_KEY].Format(RendererStringResources.AssociatedBusinessCategories, 0, 200);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(BUSINESS_CATEGORY_NAME_KEY, false);
        }
    }
}