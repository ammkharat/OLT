using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class QuestionGridRenderer : AbstractSimpleGridRenderer
    {
        private const string DISPLAY_ORDER = "DisplayOrder";
        private const string TEXT_FIELD = "QuestionText";
        private const string WEIGHT_FIELD = "Weight";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[DISPLAY_ORDER].FormatAsInt(RendererStringResources.DisplayOrder, 0, 25, false);
            band.Columns[TEXT_FIELD].Format(RendererStringResources.Questions, 1, 340);
            band.Columns[WEIGHT_FIELD].FormatAsInt(RendererStringResources.Weight, 2, 20, true);
        }
    } 
}
