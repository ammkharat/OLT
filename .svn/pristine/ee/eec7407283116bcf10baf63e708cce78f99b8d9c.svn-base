using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ShiftHandoverQuestionnaireGridRenderer : AbstractPageGridRenderer
    {
        private readonly IsReadImageColumn isReadByCurrentUserColumn;
        private readonly HasYesAnswerImageColumn hasYesAnswerImageColumn;
        private const string DATE_TIME_COLUMN = "CreateDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocations";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";

        public ShiftHandoverQuestionnaireGridRenderer()
            : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            isReadByCurrentUserColumn = new IsReadImageColumn();
            AddImageColumn(isReadByCurrentUserColumn);

            hasYesAnswerImageColumn = new HasYesAnswerImageColumn();
            AddImageColumn(hasYesAnswerImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            band.Columns[isReadByCurrentUserColumn.ColumnKey].Format(isReadByCurrentUserColumn.ColumnCaption, column++);
            band.Columns[hasYesAnswerImageColumn.ColumnKey].Format(hasYesAnswerImageColumn.ColumnCaption, column++);
            band.Columns[DATE_TIME_COLUMN].FormatAsDateTime(RendererStringResources.CreatedDateTime, column++);
            band.Columns["ShiftDisplayName"].Format(RendererStringResources.Shift, column++, 100);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 150);
            band.Columns["CreateUser"].Format(RendererStringResources.CreatedBy, column++, 150);
            band.Columns["AssignmentName"].Format(RendererStringResources.Assignment, column++);
            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(DATE_TIME_COLUMN, true);
        }
    }
}
