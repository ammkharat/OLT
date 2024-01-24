using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ActionItemGridRenderer : AbstractPageGridRenderer
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ActionItemGridRenderer));

        private const string START_DATE_COLUMN_KEY = "StartDate";  //"StartDate";  // Change column name : Mingle story : 3399
        private const string START_TIME_COLUMN_KEY = "StartTime";  //"StartTime";
        private const string END_TIME_COLUMN_KEY = "EndTime";     //"EndTime";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNames";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";

        private readonly ITimerManager timerManager;

        private readonly IImageGridColumn scheduleTypeColumn;
        private readonly IImageGridColumn priorityColumn;
        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn sourceColumn;

        private readonly WindowsFormsSynchronizationContext synchronizationContext;

        public ActionItemGridRenderer() : this(new ActionItemTimerManager())
        {
        }

        public ActionItemGridRenderer(ITimerManager timerManager) : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.timerManager = timerManager;

            scheduleTypeColumn = new ScheduleTypeImageColumn<ActionItemDTO>();
            AddImageColumn(scheduleTypeColumn);

            priorityColumn = new PriorityImageColumn<ActionItemDTO>(new List<Priority>(ActionItemDefinition.Priorities));
            AddImageColumn(priorityColumn);

            statusColumn = new ActionItemStatusImageColumn();
            AddImageColumn(statusColumn);

            sourceColumn = new DataSourceImageColumn<ActionItemDTO>(new[] { DataSource.MANUAL, DataSource.SAP, DataSource.TARGET });
            AddImageColumn(sourceColumn);

            // get the synchronization context for the current thread, which is the UI thread, which results in a WindowsFormsSynchronizationContext;
            // see http://blogs.msdn.com/b/kaelr/archive/2007/09/05/synchronizationcallback.aspx?Redirected=true
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            band.Columns[scheduleTypeColumn.ColumnKey].Format(scheduleTypeColumn.ColumnCaption, column++);
            band.Columns[priorityColumn.ColumnKey].Format(priorityColumn.ColumnCaption, column++);
            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++);

            band.Columns[START_DATE_COLUMN_KEY].FormatAsDate(RendererStringResources.StartDate, column++);

            band.Columns[START_TIME_COLUMN_KEY].FormatAsTime(RendererStringResources.StartTime, column++);
            band.Columns[START_TIME_COLUMN_KEY].AllowGroupBy = DefaultableBoolean.False;

            band.Columns[END_TIME_COLUMN_KEY].FormatAsTime(RendererStringResources.EndTime, column++);

            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns["CategoryName"].Format(RendererStringResources.Category, column++);
            band.Columns["WorkAssignmentName"].Format(RendererStringResources.Assignment, column++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 260);
            band.Columns["ResponseRequired"].Format(RendererStringResources.ResponseRequired, column++, 45);

            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, column++);
            band.Columns["Name"].Format(RendererStringResources.Name, column++);

        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            // Sort so that the newest start date/times appear at the top:
            sortedColumns.Add(START_DATE_COLUMN_KEY, true);
            sortedColumns.Add(START_TIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }

        public override void SetupRow(UltraGridRow row)
        {
            base.SetupRow(row);
            RenderItem(row);
        }

        /// <summary>
        /// Sets the color for a listviewitem. Set to object so item can call self
        /// </summary>
        private void RenderItemFromBackgroundThread(object item)
        {
            // we are often in a background thread at this point but we need to manipulate the UI, so we make sure to do
            // the real work on the UI thread
            synchronizationContext.Post(RenderItem, item);
        }

        private void RenderItem(object item)
        {
            if (item == null)
            {
                return;
            }

            var row = (UltraGridRow)item;
            var actionItemDto = (ActionItemDTO)row.ListObject;

            if (actionItemDto == null)
            {
                return;
            }
            if (actionItemDto.IsInDatabase() == false)
            {
                return;
            }

            row.Appearance.ForeColor = GetColorForActionItem(actionItemDto);

            //remove the item from the timer manager if it exists
            //the rest of the code will either re-add it or the 
            // action item will have changed state
            timerManager.Unregister(actionItemDto);

            RegisterRenderTimer(actionItemDto, row);            
        }

        /// <summary>
        /// Registers a timer to render the given action item at a later time (if necessary).
        /// </summary>
        public void RegisterRenderTimer(ActionItemDTO actionItemDto, UltraGridRow row)
        {
            if (actionItemDto.StatusName == ActionItemStatus.Complete.Name)
            {
                return;
            }

            //ayman action item new status
            // we need to deal with new status IefSubmitted as complete
            if (actionItemDto.StatusName == ActionItemStatus.IefSubmitted.Name)
            {
                return;
            }

            if (actionItemDto.StatusName == ActionItemStatus.CannotComplete.Name)
            {
                return;
            }

            DateTime now = Clock.Now;
            if (actionItemDto.IsEarly(now))
            {
                TimeSpan timeUntilStartOfActionItem = actionItemDto.StartDateTime.Subtract(now);
                //spawn off a timer to update the color to black later
                SetupTimerCallback(timeUntilStartOfActionItem, actionItemDto, row);
            }
            else if (EndDateTimeHasARealValue(actionItemDto) && actionItemDto.IsCurrent(now))
            {
                TimeSpan timeUntilActionItemIsLate = actionItemDto.EndDateTime.Subtract(now);
                //spawn off a timer to update the color to red later
                SetupTimerCallback(timeUntilActionItemIsLate, actionItemDto, row);
            }
        }

        /// <summary>
        /// If the timer will fire during the shift (including the post shift padding), then set it up.
        /// </summary>
        private void SetupTimerCallback(TimeSpan differenceInTime, ActionItemDTO actionItemDto, UltraGridRow row)
        {
            TimeSpan timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
                SetupTimerForCallback(actionItemDto, differenceInTime, row);
            else
                logger.DebugFormat(
                    "Did not create Timer for ActionItem {0} because change will take place in {1} seconds",
                    actionItemDto.Id,
                    differenceInTime.Seconds);
        }

        /// <summary>
        /// The End Date Time is not DateTime.MaxValue
        /// </summary>
        private static bool EndDateTimeHasARealValue(ActionItemDTO actionItemDto)
        {
            return DateTime.MaxValue != actionItemDto.EndDate && DateTime.MaxValue != actionItemDto.EndTime;
        }

        /// <summary>
        /// Returns the color to render the given action item, based on its status, and whether it's
        /// early or late.
        /// </summary>
        public static Color GetColorForActionItem(ActionItemDTO actionItemDto)
        {
            if (actionItemDto.StatusName == ActionItemStatus.Complete.Name)
            {
                return Color.Green;
            }
            if (actionItemDto.StatusName == ActionItemStatus.IefSubmitted.Name) //IEFSubmitted changes
            {
                return Color.Green;
            }
            if (actionItemDto.StatusName == ActionItemStatus.CannotComplete.Name)
            {
                return Color.Red;
            }
            DateTime now = Clock.Now;
            if (actionItemDto.IsLate(now))
            {
                return Color.Red;
            }
            return actionItemDto.IsEarly(now) ? Color.Blue : Color.Black;
        }

        private void SetupTimerForCallback(ActionItemDTO actionItemDto, TimeSpan differenceInTime, UltraGridRow row)
        {
            try
            {
                timerManager.RegisterTimer(actionItemDto, differenceInTime, RenderItemFromBackgroundThread, row);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for action item:<" + actionItemDto.Id + ">", e);
            }
        }
    }
}
