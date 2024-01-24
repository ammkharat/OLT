using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ActionItemDefinitionGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATE_COLUMN_KEY = "StartDate";   // "StartDateAsDateTime"; // Change column name : Mingle story : 3399
        private const string END_DATE_COLUMN_KEY = "EndDate";       //"EndDateAsDateTime";
        private const string START_TIME_COLUMN_KEY = "StartTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNamesCommaSeperated";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";        

        private readonly IImageGridColumn scheduleTypeColumn;
        private readonly IImageGridColumn priorityColumn;
        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn isActiveColumn;
        private readonly IImageGridColumn sourceColumn;

        public ActionItemDefinitionGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            scheduleTypeColumn = new ScheduleTypeImageColumn<ActionItemDefinitionDTO>();
            AddImageColumn(scheduleTypeColumn);

            priorityColumn = new PriorityImageColumn<ActionItemDefinitionDTO>(new List<Priority>(ActionItemDefinition.Priorities));
            AddImageColumn(priorityColumn);

            statusColumn = new ActionItemDefinitionStatusImageColumn();
            AddImageColumn(statusColumn);

            isActiveColumn = new IsActiveImageColumn<ActionItemDefinitionDTO>();
            AddImageColumn(isActiveColumn);

            sourceColumn = new DataSourceImageColumn<ActionItemDefinitionDTO>(new[] { DataSource.MANUAL, DataSource.SAP, DataSource.TARGET });
            AddImageColumn(sourceColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString(scheduleTypeColumn.ColumnKey, scheduleTypeColumn.ColumnCaption);
            columnFormatter.FormatAsString(priorityColumn.ColumnKey, priorityColumn.ColumnCaption);
            columnFormatter.FormatAsString(statusColumn.ColumnKey, statusColumn.ColumnCaption);
            columnFormatter.FormatAsString(isActiveColumn.ColumnKey, isActiveColumn.ColumnCaption);
            columnFormatter.FormatAsString(sourceColumn.ColumnKey, sourceColumn.ColumnCaption);

            columnFormatter.FormatAsDate(START_DATE_COLUMN_KEY, RendererStringResources.StartDate);
            columnFormatter.FormatAsDate(END_DATE_COLUMN_KEY, RendererStringResources.EndDate, StringResources.NoEndDate);
            
            columnFormatter.FormatAsTime(START_TIME_COLUMN_KEY, RendererStringResources.StartTime);
            columnFormatter.FormatAsTime("EndTimeAsNullableTime", RendererStringResources.EndTime, StringResources.NoEndTime);

            columnFormatter.FormatAsString(FUNCTIONAL_LOCATION_COLUMN_KEY, RendererStringResources.Floc);
            columnFormatter.FormatAsString("CategoryName", RendererStringResources.Category);
            columnFormatter.FormatAsString(DESCRIPTION_COLUMN_KEY, RendererStringResources.Description);
            columnFormatter.FormatAsString("OperationalModeName", RendererStringResources.OperationalMode);
            columnFormatter.FormatAsString("LastModifiedFullNameWithUserName", RendererStringResources.EditedBy);

            columnFormatter.FormatAsString(VISIBILITY_GROUPS_COLUMN_KEY, RendererStringResources.VisibilityGroups);
            columnFormatter.FormatAsString("Name", RendererStringResources.Name);

        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            // Sort so newest start date/times appear at the top:
            sortedColumns.Add(START_DATE_COLUMN_KEY, true);
            sortedColumns.Add(START_TIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }

        public override void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            base.BeforeRowFilterDropDown(sender, e);
            CustomizeTextOfBlankFilter(END_DATE_COLUMN_KEY, e, StringResources.NoEndDate);
        }
    }
}