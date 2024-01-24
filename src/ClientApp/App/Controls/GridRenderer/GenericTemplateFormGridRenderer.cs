using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class OP14FormGridRenderer : FormEdmontonGridRenderer
    {
        private readonly OP14FormStatusImageColumn statusImageColumn;

        public OP14FormGridRenderer()
        {
            statusImageColumn = new OP14FormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }
    }
}