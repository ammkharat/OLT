using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FunctionalLocationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string FULL_HIERARCHY_NAME = "FullHierarchy";
        private const string FULL_HIERARCHY_WITH_DESCRIPTION_NAME = "FullHierarchyWithDescription";

        public enum Layout
        {
            SectionFullHierarchy,
            FullHierarchyWithDescription
        }

        private readonly Layout layout;

        public FunctionalLocationGridRenderer(Layout layout)
        {
            this.layout = layout;
        }

        protected override void SetUpColumns(UltraGridBand band)
        {
            if (layout == Layout.SectionFullHierarchy)
            {
                band.Columns[FULL_HIERARCHY_NAME].Format(RendererStringResources.SectionLevelFloc, 0);                
            }
            else if (layout == Layout.FullHierarchyWithDescription)
            {
                band.Columns[FULL_HIERARCHY_WITH_DESCRIPTION_NAME].Format(RendererStringResources.FunctionalLocation, 0, 200);                
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            if (layout == Layout.SectionFullHierarchy)
            {
                sortedColumns.Add(FULL_HIERARCHY_NAME, false);
            }
            else if (layout == Layout.FullHierarchyWithDescription)
            {
                sortedColumns.Add(FULL_HIERARCHY_WITH_DESCRIPTION_NAME, false);
            }
        }
    }
}
