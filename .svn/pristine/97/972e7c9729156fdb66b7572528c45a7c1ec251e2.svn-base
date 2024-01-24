using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class LogGuidelineFunctionalLocationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string FULL_HIERARCHY = "FullHierarchyWithDescription";        

        protected override void SetUpColumns(UltraGridBand band)
        {           
            band.HideAllColumns();
            band.Columns[FULL_HIERARCHY].Format(RendererStringResources.FunctionalLocation, 0);            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(FULL_HIERARCHY, false);
        }
    }
}
