
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ConfiguredDocumentLinkGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            int column = 0;

            band.HideAllColumns();
            band.Columns["Title"].Format(StringResources.TitleGridColumnHeader, column++);
            band.Columns["Link"].Format(StringResources.LinkGridColumnHeader, column++);
        }
    }
}
