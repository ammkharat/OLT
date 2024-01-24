using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ManageOpModeForUnitLevelGridRenderer : AbstractSimpleGridRenderer
    {
        private const int FLOC_DESC_WIDTH = 240;

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();

            band.Columns["FullHierarchyAndDescription"].Format(RendererStringResources.FlocDescription, 0, FLOC_DESC_WIDTH);
            band.Columns["FunctionalLocationOperatinalModeName"].Format(RendererStringResources.OperationalMode, 1);
            band.Columns["OperationalModeAvailabilityReasonName"].Format(RendererStringResources.AvailabilityReason, 2);
        }
    }
}
