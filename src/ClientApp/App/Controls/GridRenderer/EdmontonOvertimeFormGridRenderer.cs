using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class EdmontonOvertimeFormGridRenderer : AbstractPageGridRenderer
    {
        private readonly EdmontonOvertimeFormStatusImageColumn statusImageColumn;

        private const string FORM_NUMBER_COLUMN_KEY = "FormNumber";
        private const string TRADE_COLUMN_KEY = "Trade";
        private const string VALID_FROM_COLUMN_KEY = "ValidFrom";
        private const string VALID_TO_COLUMN_KEY = "ValidTo";
        private const string TOTAL_HOURS_COLUMN_KEY = "TotalHours";
        private const string CREATED_BY_COLUMN_KEY = "CreatedByFullNameWithUserName";
        private const string CREATED_DATE_TIME_COLUMN_KEY = "CreatedDateTime";
        private const string APPROVED_DATE_TIME_COLUMN_KEY = "ApprovedDateTime";
        private const string CANCELLED_DATE_TIME_COLUMN_KEy = "CancelledDateTime";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedByFullNameWithUserName";
        private const string APPROVED_BY_COLUMN_KEY = "ApprovedByFullNameWithUserName";

        public EdmontonOvertimeFormGridRenderer() 
        {
            statusImageColumn = new EdmontonOvertimeFormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(VALID_FROM_COLUMN_KEY, true);
            sortedColumns.Add(FORM_NUMBER_COLUMN_KEY, false);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString(FORM_NUMBER_COLUMN_KEY, RendererStringResources.FormNumber);
            columnFormatter.FormatAsString(statusImageColumn.ColumnKey, statusImageColumn.ColumnCaption);
            columnFormatter.FormatAsString(TRADE_COLUMN_KEY, RendererStringResources.Trade);
            columnFormatter.FormatAsDateTime(VALID_FROM_COLUMN_KEY, RendererStringResources.Start);
            columnFormatter.FormatAsDateTime(VALID_TO_COLUMN_KEY, RendererStringResources.End);
            columnFormatter.FormatAsString(TOTAL_HOURS_COLUMN_KEY, RendererStringResources.TotalHours);
            columnFormatter.FormatAsString(CREATED_BY_COLUMN_KEY, RendererStringResources.CreatedBy);
            columnFormatter.FormatAsDateTime(CREATED_DATE_TIME_COLUMN_KEY, RendererStringResources.Created); 
            columnFormatter.FormatAsDateTime(APPROVED_DATE_TIME_COLUMN_KEY, RendererStringResources.Approved);
            columnFormatter.FormatAsDateTime(CANCELLED_DATE_TIME_COLUMN_KEy, RendererStringResources.Cancelled);
            columnFormatter.FormatAsDateTime(LAST_MODIFIED_BY_COLUMN_KEY, RendererStringResources.LastEditor);
            columnFormatter.FormatAsString(APPROVED_BY_COLUMN_KEY, RendererStringResources.ApprovedBy);
        }
    }
}