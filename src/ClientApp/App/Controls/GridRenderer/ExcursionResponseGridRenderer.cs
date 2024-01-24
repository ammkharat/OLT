using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ExcursionResponseGridRenderer : AbstractPageGridRenderer
    {
        private const string ID_COLUMN_KEY = "OpmExcursionId";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocation";
        private const string TOE_NAME_COLUMN_KEY = "ToeName";
        private const string STATUS_COLUMN_KEY = "Status";
        private const string TOE_TYPE_COLUMN_KEY = "ToeType";
        private const string START_DATE_TIME_COLUMN_KEY = "StartDateTime";
        private const string HAS_ANSWER_COLUMN_KEY = "HasResponse";
        private const string END_DATE_TIME_COLUMN_KEY = "EndDateTime";
        private const string UNIT_OF_MEASURE_COLUMN_KEY = "UnitOfMeasure";
        private const string PEAK_COLUMN_KEY = "Peak";
        private const string AVERAGE_COLUMN_KEY = "Average";
        private const string DURATION_COLUMN_KEY = "Duration";
        private const string ILP_NUMBER_COLUMN_KEY = "IlpNumber";
        private const string ENGINEER_COMMENTS_COLUMN_KEY = "EngineerComments";
        private const string OLT_OPERATOR_RESPONSE_COLUMN_KEY = "OltOperatorResponse";
        private const string REASON_CODE_COLUMN_KEY = "ReasonCode";
        private const string RESPONSE_LAST_UPDATED_COLUMN_KEY = "ResponseLastUpdatedDateTime";
        private const string RESPONSE_LAST_UPDATED_BY_COLUMN_KEY = "ResponseLastUpdatedBy";
        private const string TOE_LIMIT_VALUE_COLUMN_KEY = "ToeLimitValue";
        private readonly ToeTypeImageColumn statusImageColumn;

        public ExcursionResponseGridRenderer()
            : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            statusImageColumn = new ToeTypeImageColumn();
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var position = 0;

            band.Columns[ID_COLUMN_KEY].Format("#", position++,50);
            band.Columns[TOE_NAME_COLUMN_KEY].Format(RendererStringResources.Name, position++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, position++, 50);
            band.Columns[HAS_ANSWER_COLUMN_KEY].Format("Answered", position++,50);
            band.Columns[START_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.StartTime, position++,105);
            band.Columns[END_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.EndTime, position++,105);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns[TOE_LIMIT_VALUE_COLUMN_KEY].FormatAsDecimalThreePlaces(RendererStringResources.Limit, position++, 80, true);
            band.Columns[STATUS_COLUMN_KEY].Format(RendererStringResources.Status, position++,50);
            band.Columns[PEAK_COLUMN_KEY].FormatAsDecimalThreePlaces("Peak/Valley", position++, 80, true);
            band.Columns[ILP_NUMBER_COLUMN_KEY].Format("ILP #", position++,50);
            band.Columns[OLT_OPERATOR_RESPONSE_COLUMN_KEY].Format("Response", position++);
            band.Columns[ENGINEER_COMMENTS_COLUMN_KEY].Format("Engineer Comments", position++);
            band.Columns[REASON_CODE_COLUMN_KEY].Format("Reason Code", position++);
            band.Columns[RESPONSE_LAST_UPDATED_BY_COLUMN_KEY].Format(RendererStringResources.LastModifiedBy, position++);
            band.Columns[RESPONSE_LAST_UPDATED_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified,
                position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(TOE_NAME_COLUMN_KEY, false, true);
//            sortedColumns.Add(statusImageColumn.ColumnKey, false, true);
            sortedColumns.Add(START_DATE_TIME_COLUMN_KEY, true);
        }

        public override void SetupRow(UltraGridRow row)
        {
            if (row == null) return;

            base.SetupRow(row);
            var opmExcursionResponseDTO = row.ListObject as OpmExcursionResponseDTO;

            if (opmExcursionResponseDTO != null)
            {
                if (opmExcursionResponseDTO.Status == ExcursionStatus.Open)
                {
                    row.Appearance.ForeColor = Color.Red;
                }
            }
        }
    }
}