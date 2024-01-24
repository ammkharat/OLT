using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class ShiftHandoverQuestionGridRenderer : AbstractSimpleGridRenderer
    {
        private const string TEXT_FIELD = "Text";
        private const string HELP_TEXT_FIELD = "HelpText";
        private const string YES_NO_TEXT_FIELD = "YesNoValue";//Added by ppanigrahi

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[TEXT_FIELD].Format(RendererStringResources.QuestionText, 0, 250);
            band.Columns[HELP_TEXT_FIELD].Format(RendererStringResources.HelpText, 1,200);
            band.Columns[YES_NO_TEXT_FIELD].Format(RendererStringResources.YesNo, 2);//Added by ppanigrahi
        }
    } 
}
