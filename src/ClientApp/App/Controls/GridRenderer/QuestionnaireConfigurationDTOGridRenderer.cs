using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class QuestionnaireConfigurationDTOGridRenderer : AbstractSimpleGridRenderer
    {
        private const string VERSION_FIELD = "Version";
        private const string NAME_FIELD = "Name";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[NAME_FIELD].Format(RendererStringResources.AvailableQuestionnaires, 0, 350);
            band.Columns[VERSION_FIELD].FormatAsInt(RendererStringResources.Version, 1, 50, true);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_FIELD, false);
        }
    }
}
