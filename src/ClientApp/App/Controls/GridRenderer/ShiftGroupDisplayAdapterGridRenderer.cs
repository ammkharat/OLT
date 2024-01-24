using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class ShiftGroupDisplayAdapterGridRenderer : AbstractSimpleGridRenderer
    {
        private const string DESCRIPTION_COLUMN_KEY = "Description";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.ShiftGroup, 1);
        }
    }
}
