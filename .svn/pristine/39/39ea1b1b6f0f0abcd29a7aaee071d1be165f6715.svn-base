using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DomainObjectChangeSetGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns["ChangeDateTime"].FormatAsDateTime(RendererStringResources.DateTime, 0);
                
            band.Columns["UserName"].Format(RendererStringResources.UserName, 1);            
        }
    }
}
