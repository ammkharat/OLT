using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class CokerCardConfigurationCycleStepGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {            
            band.Columns["Name"].Format(RendererStringResources.CycleStep, 0, 100);
        }
    }
}