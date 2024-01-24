using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LubesAlarmDisableFormGridRenderer : FormEdmontonGridRenderer
    {
        private const string ALARM_COLUMN_KEY = "Alarm";
        private const string CRITICALITY_COLUMN_KEY = "Criticality";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedBy";

        private readonly OP14FormStatusImageColumn statusImageColumn;

        public LubesAlarmDisableFormGridRenderer()
        {
            statusImageColumn = new OP14FormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var column = 0;

            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);

            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);

            band.Columns[ALARM_COLUMN_KEY].Format(RendererStringResources.Alarm, column++, 245);
            
            var fromDateCaption = RendererStringResources.DisableOn;
            var toDateCaption = RendererStringResources.Expiry;

            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime(fromDateCaption, column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime(toDateCaption, column++);
            band.Columns[REMAINING_APPROVALS_COLUMN_KEY].Format(RendererStringResources.RemainingApprovals, column++);
            band.Columns[CRITICALITY_COLUMN_KEY].Format(RendererStringResources.Criticality, column++, 50);
            band.Columns[CREATED_BY_COLUMN_KEY].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[APPROVED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Closed, column++);
            band.Columns[LAST_MODIFIED_BY_COLUMN_KEY].Format(RendererStringResources.LastModified, column++);
        }
    }
}