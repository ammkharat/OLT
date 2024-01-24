
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormEdmontonGN24GridRenderer : AbstractPageGridRenderer
    {        
        private readonly FormStatusImageColumn statusImageColumn;
        
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocationNames";
        private const string FORM_NUMBER_COLUMN_KEY = "FormNumber";
        private const string VALID_FROM_COLUMN_KEY = "ValidFrom";
        private const string VALID_TO_COLUMN_KEY = "ValidTo";
        private const string PSV_COLUMN_KEY = "PSVResponseText";
        private const string CREATED_BY_COLUMN_KEY = "CreatedByFullNameWithUserName";
        private const string REMAINING_APPROVALS_COLUMN_KEY = "RemainingApprovalsString";
        private const string APPROVED_DATE_TIME_COLUMN_KEY = "ApprovedDateTime";
        private const string CLOSED_DATE_TIME_COLUMN_KEY = "ClosedDateTime";
        private const string CREATED_DATE_TIME_COLUMN_KEY = "CreatedDateTime";
        private const string LAST_MODIFIED_COLUMN_KEY = "LastModifiedDateTime";

        public FormEdmontonGN24GridRenderer()
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
            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Start, column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime(RendererStringResources.End, column++);

            band.Columns[PSV_COLUMN_KEY].Format(RendererStringResources.PSV, column++);

            band.Columns[CREATED_BY_COLUMN_KEY].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[REMAINING_APPROVALS_COLUMN_KEY].Format(RendererStringResources.RemainingApprovals, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[APPROVED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Closed, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Closed, column++);
            band.Columns[LAST_MODIFIED_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified, column++);
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
