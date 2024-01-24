using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class SiteCommunicationGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.Columns["TimeUntilActive"].Format(StringResources.SiteCommunicationTimeUntilActive, position++, 175);
            band.Columns["Message"].Format(RendererStringResources.Message, position++, 250);
            band.Columns["StartDateTime"].FormatAsDateTime(RendererStringResources.Start, position++);
            band.Columns["EndDateTime"].FormatAsDateTime(RendererStringResources.End, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }
    }
}
