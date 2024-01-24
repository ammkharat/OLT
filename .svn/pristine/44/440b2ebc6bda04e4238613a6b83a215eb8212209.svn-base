using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class CustomFieldGroupGridRenderer : AbstractSimpleGridRenderer
    {
        private const string NAME_FIELD = "Name";
        private const string WORK_ASSIGNMENTS_FIELD = "WorkAssignmentsAsString";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int i = 0;

            band.HideAllColumns();
            band.Columns[NAME_FIELD].Format(RendererStringResources.CustomFieldGroup, i++, 300);
            band.Columns[WORK_ASSIGNMENTS_FIELD].Format(RendererStringResources.WorkAssignments, i++, 300);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_FIELD, false);
        }
    }
}
