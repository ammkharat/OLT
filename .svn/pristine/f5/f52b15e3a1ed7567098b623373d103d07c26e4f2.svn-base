using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LogTemplateAssignmentGridRenderer : AbstractPageGridRenderer
    {
        public const string EDIT_COLUMN = "AutoInsert";
        private const string WORK_ASSIGNMENT_NAME = "WorkAssignmentName";

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            int position = 0;

            band.Columns[WORK_ASSIGNMENT_NAME].Format(RendererStringResources.Assignment, position++, 325);
            band.Columns[EDIT_COLUMN].Format(RendererStringResources.AutoInsertTheLogTemplateForThisAssignment, position++, 200);

            foreach (UltraGridColumn column in band.Columns)
            {
                column.CellActivation = column.Key != EDIT_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(WORK_ASSIGNMENT_NAME, false);
        }
    }
}