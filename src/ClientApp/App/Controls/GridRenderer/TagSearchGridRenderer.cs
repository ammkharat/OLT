using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class TagSearchGridRenderer : AbstractSimpleGridRenderer
    {
        private const string DESCRIPTION_OBJECT_NAME = "Description";
        private const string NAME_OBJECT_NAME = "Name";
        private const string UNITS_OBJECT_NAME = "Units";
        private const string SCADA_PROVIDER_DESCRIPTION = "ScadaProviderDescription";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[NAME_OBJECT_NAME].Format(RendererStringResources.TagName, 0, 225);
            band.Columns[DESCRIPTION_OBJECT_NAME].Format(RendererStringResources.Description, 1, 300);
            band.Columns[UNITS_OBJECT_NAME].Format(RendererStringResources.Units, 2, 60);
            band.Columns[SCADA_PROVIDER_DESCRIPTION].Format(RendererStringResources.Provider, 3, 155);
        }
    }
}