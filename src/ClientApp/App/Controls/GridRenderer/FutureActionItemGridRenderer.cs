using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FutureActionItemGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATE_COLUMN_KEY = "GroupByStartDate";
        private const string START_TIME_COLUMN_KEY = "StartTime";
        private const string END_TIME_COLUMN_KEY = "EndTime";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNames";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";
        private static readonly ILog logger = LogManager.GetLogger(typeof (FutureActionItemGridRenderer));
        private readonly IImageGridColumn priorityColumn;
        private readonly IImageGridColumn scheduleTypeColumn;
        private readonly IImageGridColumn sourceColumn;

        public FutureActionItemGridRenderer()
            : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            scheduleTypeColumn = new ScheduleTypeImageColumn<ActionItemDTO>();
            AddImageColumn(scheduleTypeColumn);

            priorityColumn = new PriorityImageColumn<ActionItemDTO>(new List<Priority>(ActionItemDefinition.Priorities));
            AddImageColumn(priorityColumn);

            sourceColumn =
                new DataSourceImageColumn<ActionItemDTO>(new[] {DataSource.MANUAL, DataSource.SAP, DataSource.TARGET});
            AddImageColumn(sourceColumn);

            // get the synchronization context for the current thread, which is the UI thread, which results in a WindowsFormsSynchronizationContext;
            // see http://blogs.msdn.com/b/kaelr/archive/2007/09/05/synchronizationcallback.aspx?Redirected=true
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var column = 0;
            band.Columns[scheduleTypeColumn.ColumnKey].Format(scheduleTypeColumn.ColumnCaption, column++);
            band.Columns[priorityColumn.ColumnKey].Format(priorityColumn.ColumnCaption, column++);
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++);

            band.Columns[START_DATE_COLUMN_KEY].FormatAsDate(RendererStringResources.StartDate, column++);

            band.Columns[START_TIME_COLUMN_KEY].FormatAsTime(RendererStringResources.StartTime, column++);
            band.Columns[START_TIME_COLUMN_KEY].AllowGroupBy = DefaultableBoolean.False;

            band.Columns[END_TIME_COLUMN_KEY].FormatAsTime(RendererStringResources.EndTime, column++);

            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns["CategoryName"].Format(RendererStringResources.Category, column++);
            band.Columns["WorkAssignmentName"].Format(RendererStringResources.Assignment, column++);
            band.Columns["ResponseRequired"].Format(RendererStringResources.ResponseRequired, column++, 45);
            band.Columns["RequiresApprovalYesNo"].Format(RendererStringResources.RequiresApproval, column++);
            band.Columns["TemporarilyInactiveYesNo"].Format(RendererStringResources.TemporarilyInnactive, column++);
            band.Columns["OperationalMode"].Format(RendererStringResources.OperationalMode, column++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 100);
            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, column++);
            band.Columns["Name"].Format(RendererStringResources.Name, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            // Sort so that the newest start date/times appear at the top:
            sortedColumns.Add(START_DATE_COLUMN_KEY, false, true);
            sortedColumns.Add(START_TIME_COLUMN_KEY, false);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> {DESCRIPTION_COLUMN_KEY};
        }

   
 }
}