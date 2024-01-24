using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DirectiveGridRenderer : AbstractPageGridRenderer
    {
        private readonly DirectiveStatusImageColumn statusImageColumn;
        private readonly IsReadImageColumn isReadByCurrentUserColumn;

        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocations";
        private const string WORK_ASSIGNMENT_COLUMN_KEY = "WorkAssignments";
        private const string ACTIVE_FROM_DATE_TIME = "ActiveFromDateTime";
        private const string ACTIVE_TO_DATE_TIME = "ActiveToDateTime";
        private const string CONTENT_COLUMN_KEY = "Content";
        private const string CREATED_BY_KEY = "CreatedByFullNameWithUsername";
        private const string LAST_MODIFIED_BY_KEY = "LastModifiedByFullNameWithUsername";
        private const string CREATED_BY_WORK_ASSIGNMENT_KEY = "CreatedByWorkAssignmentName";

        public DirectiveGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            statusImageColumn = new DirectiveStatusImageColumn();
            AddImageColumn(statusImageColumn);

            isReadByCurrentUserColumn = new IsReadImageColumn();
            AddImageColumn(isReadByCurrentUserColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 0;

            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, position++, 40);
            band.Columns[isReadByCurrentUserColumn.ColumnKey].Format(isReadByCurrentUserColumn.ColumnCaption, position++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns[WORK_ASSIGNMENT_COLUMN_KEY].Format(RendererStringResources.Assignment, position++);
            band.Columns[ACTIVE_FROM_DATE_TIME].FormatAsDateTime(RendererStringResources.ActiveFrom, position++);
            band.Columns[ACTIVE_TO_DATE_TIME].FormatAsDateTime(RendererStringResources.ActiveTo, position++);
            band.Columns[CONTENT_COLUMN_KEY].Format(RendererStringResources.Comments, position++, 500);
            band.Columns[CREATED_BY_KEY].Format(RendererStringResources.CreatedBy, position++);
            band.Columns[LAST_MODIFIED_BY_KEY].Format(RendererStringResources.LastModifiedBy, position++);
            band.Columns[CREATED_BY_WORK_ASSIGNMENT_KEY].Format(RendererStringResources.CreatedAssignment, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(statusImageColumn.ColumnKey, false, true);
            sortedColumns.Add(ACTIVE_FROM_DATE_TIME, true);
        }
    }
}
