using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DocumentLinkSelectionGridRender : AbstractSimpleGridRenderer
    {
        private const string PathName = "PathName";
        private const string UncPath = "Path";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.HideAllColumns();
            band.Columns[PathName].Format(RendererStringResources.Name, position++, 200);
            band.Columns[UncPath].Format(RendererStringResources.UNCPath, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(PathName, false);
            sortedColumns.Add(UncPath, false);
        }

    }
}