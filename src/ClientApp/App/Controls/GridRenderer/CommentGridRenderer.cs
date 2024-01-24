using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class CommentGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns["CreatedByUserName"].Format(RendererStringResources.CreatedBy, 0);
            band.Columns["CreatedDate"].Format(RendererStringResources.CreatedDate, 1);
            band.Columns["Text"].Format(RendererStringResources.Comments, 2);
        }
    }
}
