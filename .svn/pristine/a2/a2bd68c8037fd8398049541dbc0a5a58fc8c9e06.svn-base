
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormEdmontonGN6GridRenderer : AbstractPageGridRenderer
    {        
        private readonly FormStatusImageColumn statusImageColumn;
        
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocationNames";
        private const string FORM_NUMBER_COLUMN_KEY = "FormNumber";
        private const string VALID_FROM_COLUMN_KEY = "ValidFrom";
        private const string VALID_TO_COLUMN_KEY = "ValidTo";
        private const string CREATED_BY_COLUMN_KEY = "CreatedByFullNameWithUserName";
        private const string REMAINING_APPROVALS_COLUMN_KEY = "RemainingApprovalsString";
        private const string APPROVED_DATE_TIME_COLUMN_KEY = "ApprovedDateTime";
        private const string CLOSED_DATE_TIME_COLUMN_KEy = "ClosedDateTime";
        private const string CREATED_DATE_TIME_COLUMN_KEY = "CreatedDateTime";

        private const string APPLICABLE_SECTIONS_COLUMN_KEY = "ApplicableSections";
        private const string LAST_MODIFIED_DATE_TIME_COLUMN_KEY = "LastModifiedDateTime";
        private const string JOB_DESCRIPTION_COLUMN_KEY = "JobDescription";

        public FormEdmontonGN6GridRenderer()
            : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            statusImageColumn = new FormStatusImageColumn();
            AddImageColumn(statusImageColumn);       
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            
            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime(RendererStringResources.ValidFrom, column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime(RendererStringResources.ValidTo, column++);
            band.Columns[APPLICABLE_SECTIONS_COLUMN_KEY].Format(RendererStringResources.ApplicableSections, column++);

            band.Columns[CREATED_BY_COLUMN_KEY].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[REMAINING_APPROVALS_COLUMN_KEY].Format(RendererStringResources.RemainingApprovals, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[APPROVED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEy].FormatAsDateTime(RendererStringResources.Closed, column++);
            band.Columns[LAST_MODIFIED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified, column++);
            band.Columns[JOB_DESCRIPTION_COLUMN_KEY].FormatAsDateTime(RendererStringResources.JobDescription, column++);
        }

        public virtual bool ShowFormTypeColumn()
        {
            return true;
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(VALID_FROM_COLUMN_KEY, true);
        }
    }
}
