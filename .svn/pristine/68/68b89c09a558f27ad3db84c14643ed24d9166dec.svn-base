using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class AreaLabelGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.Columns["Name"].Format(RendererStringResources.AreaLabel, position++, 150);
            band.Columns["AllowManualSelection"].Format(RendererStringResources.AllowManualSelection, position++);
            band.Columns["SapPlannerGroup"].Format(RendererStringResources.SAPPlannerGroup, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }
    }
}
