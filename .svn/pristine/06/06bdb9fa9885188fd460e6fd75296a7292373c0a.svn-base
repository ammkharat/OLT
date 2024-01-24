using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ProcedureDeviationGridRenderer : FormEdmontonGridRenderer
    {
        private const string DEVIATION_TYPE_COLUMN_KEY = "Type";
        private const string PERMANENT_REVISION_REQUIRED_COLUMN_KEY = "PermanentRevisionRequired";
        private const string REVERTED_BACK_TO_ORIGINAL_COLUMN_KEY = "RevertedBackToOriginal";
        private const string NUMBER_OF_EXTENSIONS_COLUMN_KEY = "NumberOfExtensions";
        private const string PROCEDURE_NUMBER_COLUMN_KEY = "OperatingProcedureNumber";
        private const string PROCEDURE_LEVEL_COLUMN_KEY = "OperatingProcedureLevel";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string CAUSE_DETERMINATION_CATEGORY_COLUMN_KEY = "CauseDeterminationCategory";
        private const string CANCELLED_DATE_TIME_COLUMN_KEY = "CancelledDateTime";
        private const string CANCELLED_BY_COLUMN_KEY = "CancelledBy";
        private const string CANCELLED_REASON_COLUMN_KEY = "CancelledReason";
        private const string LAST_MODIFIED_DATE_TIME_COLUMN_KEY = "LastModified";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedBy";
        private readonly ProcedureDeviationFormStatusImageColumn statusImageColumn;

        public ProcedureDeviationGridRenderer()
        {
            statusImageColumn = new ProcedureDeviationFormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var column = 0;

            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);

            band.Columns[DEVIATION_TYPE_COLUMN_KEY].Format("Deviation Type", column++);
            band.Columns[PERMANENT_REVISION_REQUIRED_COLUMN_KEY].Format("Permanent Revision Required", column++);
            band.Columns[REVERTED_BACK_TO_ORIGINAL_COLUMN_KEY].Format("Reverted back to Original", column++);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);

            band.Columns[PROCEDURE_NUMBER_COLUMN_KEY].Format("Procedure #", column++);
            band.Columns[PROCEDURE_LEVEL_COLUMN_KEY].Format("Level", column++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format("General Comments", column++);

            band.Columns[CAUSE_DETERMINATION_CATEGORY_COLUMN_KEY].Format("Cause Determination Category", column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime("Created", column++);
            band.Columns[CANCELLED_DATE_TIME_COLUMN_KEY].FormatAsDateTime("Cancelled", column++);

            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime("Start", column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime("End", column++);
            band.Columns[NUMBER_OF_EXTENSIONS_COLUMN_KEY].Format("# Extensions", column++);

            band.Columns[CREATED_BY_COLUMN_KEY].FormatAsDateTime(RendererStringResources.CreatedBy, column++);
            band.Columns[CANCELLED_BY_COLUMN_KEY].Format("Cancelled By", column++);
            band.Columns[CANCELLED_REASON_COLUMN_KEY].Format("Cancelled Reason", column++);

            band.Columns[LAST_MODIFIED_BY_COLUMN_KEY].Format("Last Editor", column++);
            band.Columns[LAST_MODIFIED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified,
                column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Clear();
            sortedColumns.Add(CREATED_DATE_TIME_COLUMN_KEY, true);
        }

    }
}