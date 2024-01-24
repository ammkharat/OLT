using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class TargetAlertGridRenderer : AbstractPageGridRenderer
    {
        private const int TWO_DIGIT_DECIMAL_COLUMN_WIDTH = 50;
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string TARGET_NAME_COLUMN_KEY = "TargetName";
        private const bool RIGHT_JUSTIFY_VALUE = true;

        public const string LOSSES_COLUMN_KEY = "LossesRounded";

        private readonly IImageGridColumn priorityColumn;
        private readonly IImageGridColumn statusColumn;
        
        public TargetAlertGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            priorityColumn = new PriorityImageColumn<TargetAlertDTO>(new List<Priority>(TargetDefinition.Priorities));
            AddImageColumn(priorityColumn);

            statusColumn = new TargetAlertStatusImageColumn();
            AddImageColumn(statusColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[priorityColumn.ColumnKey].Format(priorityColumn.ColumnCaption, column++);
            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);

            band.Columns["CreatedDateTime"].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            
            band.Columns["WorkAssignmentName"].Format(RendererStringResources.WorkAssignment, column++);

            band.Columns[TARGET_NAME_COLUMN_KEY].Format(RendererStringResources.Name, column++);
            band.Columns["CategoryName"].Format(RendererStringResources.Category, column++);
            band.Columns["TargetValue"].Format(RendererStringResources.Target, column++, RIGHT_JUSTIFY_VALUE);
            //RITM0252906-changed ActualValue by Mukesh form decimal to FormatAsDecimalThreePlaces
            band.Columns["ActualValue"].FormatAsDecimalThreePlaces(RendererStringResources.Actual, column++, TWO_DIGIT_DECIMAL_COLUMN_WIDTH, RIGHT_JUSTIFY_VALUE);
            band.Columns[LOSSES_COLUMN_KEY].FormatAsCurrencyNoCents(RendererStringResources.Losses, column++, TWO_DIGIT_DECIMAL_COLUMN_WIDTH, RIGHT_JUSTIFY_VALUE);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 220);
            band.Columns["ResponseRequired"].Format(RendererStringResources.ResponseRequired, column++, 90);
            band.Columns["LastViolatedDateTime"].FormatAsDateTime(RendererStringResources.LastViolatedDateTime, column);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(statusColumn.ColumnKey, false);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY, TARGET_NAME_COLUMN_KEY };
        }
    }
}