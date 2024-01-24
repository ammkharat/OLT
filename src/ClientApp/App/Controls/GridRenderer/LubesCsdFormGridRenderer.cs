using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LubesCsdFormGridRenderer : FormEdmontonGridRenderer
    {
        private const string SYSTEM_TO_BE_DEFEATED_COLUMN_KEY = "SystemDefeated";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedBy";

        private readonly OP14FormStatusImageColumn statusImageColumn;

        public LubesCsdFormGridRenderer()
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

            var fromDateCaption = RendererStringResources.SystemDefeated;
            var toDateCaption = RendererStringResources.EstimatedBackInService;

            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime(fromDateCaption, column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime(toDateCaption, column++);
            band.Columns[SYSTEM_TO_BE_DEFEATED_COLUMN_KEY].FormatAsDateTime(RendererStringResources.SystemToBeDefeated, column++,245);
            band.Columns[CREATED_BY_COLUMN_KEY].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[APPROVED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Closed, column++);
            band.Columns[LAST_MODIFIED_BY_COLUMN_KEY].Format(RendererStringResources.LastModified, column++);
            band.Columns[REMAINING_APPROVALS_COLUMN_KEY].Format(RendererStringResources.RemainingApprovals, column++);
        }
    }
}