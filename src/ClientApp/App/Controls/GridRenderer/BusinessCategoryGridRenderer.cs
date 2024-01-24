using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class BusinessCategoryGridRenderer : AbstractSimpleGridRenderer
    {
        public enum Layout
        {
            NameOnlyLayout,
            AllFieldsLayout
        }

        private const string NameColumnKey = "Name";

        private readonly Layout layout;

        public BusinessCategoryGridRenderer(Layout layout)
        {
            this.layout = layout;
        }

        protected override void SetUpColumns(UltraGridBand band)
        {
            if (layout == Layout.NameOnlyLayout)
            {
                band.Columns[NameColumnKey].Format(RendererStringResources.AllBusinessCategories, 0, 50);
            }
            else if (layout == Layout.AllFieldsLayout)
            {
                band.Columns[NameColumnKey].Format(RendererStringResources.BusinessCategory, 0, 290);
                band.Columns["ShortName"].Format(RendererStringResources.ShortName, 1, 75);

                band.Columns["IsDefaultSAPWorkOrderCategory"].Format(RendererStringResources.SAPWorkOrderDefault, 3, 150);
                band.Columns["IsDefaultSAPNotificationCategory"].Format(RendererStringResources.SAPNotificationDefault, 4, 170);
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NameColumnKey, false);
        }
    }
}