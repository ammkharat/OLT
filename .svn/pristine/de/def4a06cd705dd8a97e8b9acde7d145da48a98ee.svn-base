using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ItemsForSummaryGridRenderer : AbstractPageGridRenderer
    {
        private readonly ShiftSummaryItemSourceImageColumn sourceImageColumn;

        public const string EDIT_COLUMN = "IncludeInSummary";
        private const string LOGGEDDATETIME_COLUMN = "LoggedDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN = "FunctionalLocationNames";
        private const string WORK_ASSIGNMENT_NAME = "WorkAssignmentName";

        public ItemsForSummaryGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN)
        {
            sourceImageColumn = new ShiftSummaryItemSourceImageColumn(RendererStringResources.Source);
            AddImageColumn(sourceImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            int position = 0;

            band.Columns[sourceImageColumn.ColumnKey].Format(sourceImageColumn.ColumnCaption, position++);
            band.Columns[WORK_ASSIGNMENT_NAME].Format(RendererStringResources.Assignment, position++, 225);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN].Format(RendererStringResources.Floc, position++, 225);
            band.Columns[LOGGEDDATETIME_COLUMN].FormatAsTime(RendererStringResources.LogTime, position++);
            band.Columns["CreatedBy"].Format(RendererStringResources.CreatedBy, position++);
            band.Columns["RecommendedForSummary"].Format(RendererStringResources.RecommendedForSummary, position++);
            band.Columns[EDIT_COLUMN].Format(RendererStringResources.Add, position++, 50);

            foreach (UltraGridColumn column in band.Columns)
            {
                column.CellActivation = column.Key != EDIT_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(WORK_ASSIGNMENT_NAME, false);
            sortedColumns.Add(LOGGEDDATETIME_COLUMN, true);
            sortedColumns.Add(sourceImageColumn.ColumnKey, false);
        }
    }
}