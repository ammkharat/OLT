using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DocumentSuggestionGridRenderer : FormEdmontonGridRenderer
    {
        private const string SCHEDULED_COMPLETION_COLUMN_KEY = "ScheduledCompletionDateTime";
        private const string NUMBER_OF_EXTENSIONS_COLUMN_KEY = "NumberOfExtensions";
        private const string DOCUMENT_OWNER_COLUMN_KEY = "DocumentOwner";
        private const string DOCUMENT_NUMBER_COLUMN_KEY = "DocumentNumber";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string INITIAL_REVIEW_COLUMN_KEY = "InitialReviewApprovedDateTime";
        private const string OWNER_REVIEW_COLUMN_KEY = "OwnerReviewApprovedDateTime";
        private const string DOCUMENT_ISSUED_COLUMN_KEY = "DocumentIssuedApprovedDateTime";
        private const string DOCUMENT_ARCHIVED_COLUMN_KEY = "DocumentArchivedApprovedDateTime";
        private const string NOT_APPROVED_COLUMN_KEY = "NotApprovedDateTime";
        private const string NOT_APPROVED_REASON_COLUMN_KEY = "NotApprovedReason";
        private const string LAST_MODIFIED_DATE_TIME_COLUMN_KEY = "LastModified";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedBy";
        private readonly DocumentSuggestionFormStatusImageColumn statusImageColumn;

        public DocumentSuggestionGridRenderer()
        {
            statusImageColumn = new DocumentSuggestionFormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var column = 0;

            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);

            band.Columns[DOCUMENT_NUMBER_COLUMN_KEY].Format("Document #", column++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format("Idea/Enhancement Summary", column++);
            band.Columns[DOCUMENT_OWNER_COLUMN_KEY].Format("Document Owner", column++);

            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime("Created", column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime("Suggested Completion", column++);
            band.Columns[SCHEDULED_COMPLETION_COLUMN_KEY].FormatAsDateTime("Scheduled Completion", column++);
            band.Columns[NUMBER_OF_EXTENSIONS_COLUMN_KEY].Format("# Extensions", column++);
            band.Columns[CREATED_BY_COLUMN_KEY].FormatAsDateTime(RendererStringResources.CreatedBy, column++);

            band.Columns[INITIAL_REVIEW_COLUMN_KEY].FormatAsDateTime("Initial Review Approved", column++);
            band.Columns[OWNER_REVIEW_COLUMN_KEY].FormatAsDateTime("Owner Review Approved", column++);
            band.Columns[DOCUMENT_ISSUED_COLUMN_KEY].FormatAsDateTime("Document Issued Approved", column++);
            band.Columns[DOCUMENT_ARCHIVED_COLUMN_KEY].FormatAsDateTime("Document Archived Approved", column++);
            band.Columns[NOT_APPROVED_COLUMN_KEY].FormatAsDateTime("Not Approved", column++);
            band.Columns[NOT_APPROVED_REASON_COLUMN_KEY].Format("Not Approved Reason", column++);

            band.Columns[LAST_MODIFIED_BY_COLUMN_KEY].Format("Last Editor", column++);
            band.Columns[LAST_MODIFIED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified,
                column++);
        }
    }
}