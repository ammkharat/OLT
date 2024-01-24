using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class TargetDefinitionGridRenderer : AbstractPageGridRenderer
    {
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";
        private const string NAME_COLUMN_KEY = "Name";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string START_DATE_COLUMN_KEY = "StartDate";
        private const string END_DATE_COLUMN_KEY = "EndDate";   //"EndDateAsDateTime"; // Change column name : Mingle story : 3399
        private const int TWO_DIGIT_DECIMAL_COLUMN_WIDTH = 50;
        private const bool RIGHT_JUSTIFY_VALUE = true;


        private readonly IImageGridColumn priorityColumn;
        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn isActiveColumn;

        public TargetDefinitionGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            priorityColumn = new PriorityImageColumn<TargetDefinitionDTO>(new List<Priority>(TargetDefinition.Priorities));
            AddImageColumn(priorityColumn);

            statusColumn = new TargetDefinitionStatusImageColumn();
            AddImageColumn(statusColumn);

            isActiveColumn = new IsActiveImageColumn<TargetDefinitionDTO>();
            AddImageColumn(isActiveColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString(priorityColumn.ColumnKey, priorityColumn.ColumnCaption);
            columnFormatter.FormatAsString(statusColumn.ColumnKey, statusColumn.ColumnCaption);
            columnFormatter.FormatAsString(isActiveColumn.ColumnKey, isActiveColumn.ColumnCaption);

            columnFormatter.FormatAsString(FUNCTIONAL_LOCATION_COLUMN_KEY, RendererStringResources.Floc);
            columnFormatter.FormatAsString("CategoryName", RendererStringResources.Category);
            columnFormatter.FormatAsString(NAME_COLUMN_KEY, RendererStringResources.Name);
            
            //columnFormatter.FormatAsDate("StartDateAsDateTime", RendererStringResources.StartDate);
            columnFormatter.FormatAsDate(START_DATE_COLUMN_KEY, RendererStringResources.StartDate);
            columnFormatter.FormatAsDate(END_DATE_COLUMN_KEY, RendererStringResources.EndDate, StringResources.NoEndDate);

            columnFormatter.FormatAsTime("StartTime", RendererStringResources.StartTime);
            columnFormatter.FormatAsTime("EndTimeAsNullableTime", RendererStringResources.EndTime, StringResources.NoEndTime);

            columnFormatter.FormatAsString("TargetValue", RendererStringResources.Target, 52, true);
            columnFormatter.FormatAsString("GapUnitValue", RendererStringResources.Guv, 50, true);
            columnFormatter.FormatAsString("WorkAssignmentName", RendererStringResources.WorkAssignment);
            columnFormatter.FormatAsString(DESCRIPTION_COLUMN_KEY, RendererStringResources.Description, 145);

            //RITM0252906-changed by Mukesh form decimal to string
            columnFormatter.FormatAsString("NeverToExceedMax", RendererStringResources.NeverToExceedMax, 88, RIGHT_JUSTIFY_VALUE);
            columnFormatter.FormatAsString("Max", RendererStringResources.Max, TWO_DIGIT_DECIMAL_COLUMN_WIDTH, RIGHT_JUSTIFY_VALUE);
            columnFormatter.FormatAsString("Min", RendererStringResources.Min, TWO_DIGIT_DECIMAL_COLUMN_WIDTH, RIGHT_JUSTIFY_VALUE);
            columnFormatter.FormatAsString("NeverToExceedMin", RendererStringResources.NeverToExceedMin, 85, RIGHT_JUSTIFY_VALUE);

            //RITM0252906 end
            columnFormatter.FormatAsString("LastModifiedFullNameWithUserName", RendererStringResources.EditedBy);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { NAME_COLUMN_KEY, DESCRIPTION_COLUMN_KEY };
        }

        public override void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            base.BeforeRowFilterDropDown(sender, e);
            CustomizeTextOfBlankFilter(END_DATE_COLUMN_KEY, e, StringResources.NoEndDate);
        }
    }
}