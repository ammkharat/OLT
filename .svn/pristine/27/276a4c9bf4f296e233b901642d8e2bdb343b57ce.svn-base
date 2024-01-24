using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LogGridRenderer : AbstractPageGridRenderer
    {
        private const string LOGGED_DATE_COLUMN_KEY = "LogDateTime";
        private const string SHIFT_COLUMN_KEY = "Shift";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNames";
        private const string IS_MODIFIED_COLUMN_KEY = "IsModified";
        private const string COMMENTS_COLUMN_KEY = "Comments";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";

        private readonly bool includeSourceColumn;
        private readonly bool includeMarkedAsReadColumn;
        private readonly LogType logType;        
        private readonly IImageGridColumn scheduleTypeColumn;
        private readonly IImageGridColumn threadColumn;
        private readonly IImageGridColumn sourceColumn;
        private readonly IImageGridColumn logFlagImageColumn;
        private readonly IsReadImageColumn isReadByCurrentUserColumn;

        public LogGridRenderer(bool includeSourceColumn, LogType logType, bool includeMarkedAsReadColumn)
            : this(includeSourceColumn, logType, includeMarkedAsReadColumn, ClientSession.GetUserContext().SiteConfiguration.ShowFollowupOnLogForm)
        {            
        }

        public LogGridRenderer(bool includeSourceColumn, LogType logType, bool includeMarkedAsReadColumn, bool siteUsesFollowUp) : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.logType = logType;
            this.includeMarkedAsReadColumn = includeMarkedAsReadColumn;
            this.includeSourceColumn = includeSourceColumn;            

            scheduleTypeColumn = new ScheduleTypeImageColumn<LogDTO>();
            AddImageColumn(scheduleTypeColumn);

            threadColumn = new ThreadImageColumn<LogDTO>();
            AddImageColumn(threadColumn);

            if (includeSourceColumn)
            {
                sourceColumn = new DataSourceImageColumn<LogDTO>(new[] { DataSource.MANUAL, DataSource.ACTION_ITEM, DataSource.TARGET, DataSource.PERMIT, DataSource.SAP, DataSource.LAB_ALERT, DataSource.HANDOVER, DataSource.EXCURSION, DataSource.OPERATOR_ROUND,DataSource.ACTIVE_CSD,  });
                AddImageColumn(sourceColumn);
            }

            if (includeMarkedAsReadColumn)
            {
                isReadByCurrentUserColumn = new IsReadImageColumn();
                AddImageColumn(isReadByCurrentUserColumn);
            }

            logFlagImageColumn = new LogFlagImageColumn(siteUsesFollowUp);
            AddImageColumn(logFlagImageColumn);
        }

        protected override void SetupCustomSortComparers(UltraGridBand band)
        {
            band.Columns[SHIFT_COLUMN_KEY].SortComparer = new DoublePropertyRowComparer<LogDTO, Date, string>(
                dto => dto.CreatedShiftStartDate, 
                dto => dto.CreatedShiftName);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 0;

            if (logType == LogType.DailyDirective || ClientSession.GetUserContext().SiteConfiguration.AtLeastOneRoleCanCreateLogDefinitions)
            {
                band.Columns[scheduleTypeColumn.ColumnKey].Format(scheduleTypeColumn.ColumnCaption, position++);
            }

            if (includeMarkedAsReadColumn)
            {
                band.Columns[isReadByCurrentUserColumn.ColumnKey].Format(isReadByCurrentUserColumn.ColumnCaption, position++);
            }

            band.Columns[threadColumn.ColumnKey].Format(threadColumn.ColumnCaption, position++);

            if (includeSourceColumn)
            {
                band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, position++);
            }

            if (logType == LogType.Standard && ClientSession.GetUserContext().SiteConfiguration.ShowIsModifiedColumnForLogs)
            {
                band.Columns[IS_MODIFIED_COLUMN_KEY].Format(RendererStringResources.Modified, position++,70);
            }

            string logDateTimeHeaderText = string.Empty;
            if (logType == LogType.Standard)
            {
                logDateTimeHeaderText = RendererStringResources.LogDate;
            }
            if (logType == LogType.DailyDirective)
            {
                logDateTimeHeaderText = RendererStringResources.DirectiveDateTime;
            }

            band.Columns[LOGGED_DATE_COLUMN_KEY].FormatAsDateTime(logDateTimeHeaderText, position++);
            band.Columns[SHIFT_COLUMN_KEY].Format(RendererStringResources.Shift, position++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, position++);

            band.Columns[logFlagImageColumn.ColumnKey].Format(logFlagImageColumn.ColumnCaption, position++);
           
            if(ClientSession.GetUserContext().SiteConfiguration.UseCreatedByColumnForLogs)
            {
                band.Columns["CreatedByFullnameWithUserName"].Format(RendererStringResources.CreatedBy, position++);    
            }
            else
            {
                band.Columns["LastModifiedFullNameWithUserName"].Format(RendererStringResources.EditedBy, position++);    
            }
            

            band.Columns["WorkAssignmentName"].Format(RendererStringResources.Assignment, position++);
            band.Columns[COMMENTS_COLUMN_KEY].Format(RendererStringResources.Comments, position++, 500);

            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(LOGGED_DATE_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { COMMENTS_COLUMN_KEY };
        }

    }
}
