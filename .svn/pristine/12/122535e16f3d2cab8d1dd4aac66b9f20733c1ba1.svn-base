using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class LogTemplateGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_FIELD = "Name";
        private const string WORK_ASSIGNMENTS_FIELD = "WorkAssignmentsString";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int i = 0;

            band.HideAllColumns();
            band.Columns[NAME_FIELD].Format(RendererStringResources.Name, i++);
            band.Columns[NAME_FIELD].Width = 160;
            band.Columns[WORK_ASSIGNMENTS_FIELD].Format(RendererStringResources.WorkAssignments, i++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_FIELD, false);
        }
    }
}
