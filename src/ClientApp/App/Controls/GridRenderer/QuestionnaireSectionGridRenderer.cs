using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class QuestionnaireSectionGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_FIELD = "Name";
        private const string PERCENT_WEIGHT_FIELD = "PercentageWeighting";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[NAME_FIELD].Format(RendererStringResources.Sections, 0, 380);
            band.Columns[PERCENT_WEIGHT_FIELD].FormatAsDecimal(RendererStringResources.PercentageWeighting, 1, 20, true);
        }
    }
}