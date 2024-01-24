using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class ShiftHandoverConfigurationDTOGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_FIELD = "Name";
        private const string ASSIGNMENT_LIST_FIELD = "AssignmentListString";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Columns[NAME_FIELD].Format(RendererStringResources.Name, 0, 150);
            band.Columns[ASSIGNMENT_LIST_FIELD].Format(RendererStringResources.WorkAssignments, 1, 150);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_FIELD, false);
        }
    }
}
