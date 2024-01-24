using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractLogPagePresenter : AbstractDeletableDomainPagePresenter<LogDTO, Log, ILogDetails, ILogPage> 
    {
        protected readonly ILogService logService;

        private readonly IReportPrintManager<Log> reportPrintManager;

        private readonly ILog logger = LogManager.GetLogger(typeof (AbstractLogPagePresenter));

        protected AbstractLogPagePresenter(ILogPage page) : this(
            page, 
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<IEditHistoryService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected AbstractLogPagePresenter(
            ILogPage page, 
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ILogService logService,
            IEditHistoryService editHistoryService,
            ITimeService timeService,
            IUserService userService)
            : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {

            this.logService = logService;

            page.ShowLogThread = false;
            SubscribeToEvents();

            reportPrintManager = new ReportPrintManager<Log, RtfGenericSingleLogReport, GenericSingleLogReportAdapter>(new LogPrintActions(logService, editHistoryService));
        }

        protected override void RefreshThreadedView(bool recalculateRelationships)
        {
            if (recalculateRelationships)
            {
                LogDTO.ConvertChildrenWithoutParentsToParentsAndFlag(new List<LogDTO>(page.Items));
            }
            ThreadedItemPresenterHelper.RefreshThreadedView(page, logger);
        }

        private void SubscribeToEvents()
        {
            page.Details.Reply += Reply;
            page.Details.Copy += Copy;
            page.Details.ViewThread += ViewThread;
            page.Details.MarkAsRead += MarkAsRead;
            page.Details.Print += Print;
            page.Details.Preview += PrintPreview;
            page.Details.CustomFieldEntryClicked += CustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByExpand += DetailsMarkedAsReadByExpand;
            // Added by Mukesh for RITM0218684
            page.Details.Email += Email;

            EnableThreadItemChangedEvent();
        }

        private void DetailsMarkedAsReadByExpand(Log log)
        {
            page.Details.MarkedAsReadBy = logService.UsersThatMarkedLogAsRead(log.IdValue);
        }

        private void CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            Log log = QueryForFirstSelectedItem();

            IRunnablePresenter presenter = CustomFieldPresenterMaker.Create(logService, customFieldEntry, log.WorkAssignment);
            presenter.Run(page.MainParentForm);
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            page.Details.Reply -= Reply;
            page.Details.Copy -= Copy;
            page.Details.ViewThread -= ViewThread;
            page.Details.MarkAsRead -= MarkAsRead;
            page.Details.Print -= Print;
            page.Details.Preview -= PrintPreview;
            page.Details.CustomFieldEntryClicked -= CustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByExpand -= DetailsMarkedAsReadByExpand;
            // Added by Mukesh for RITM0218684
            page.Details.Email -= Email;

            DisableThreadItemChangedEvent();
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(Log item)
        {
            return new EditLogHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(Log logToUpdate)
        {
            // The Log is a reply to another Log
            if (logToUpdate.ReplyToLogId.HasValue)
            {
                return new LogReplyForm(logToUpdate.ReplyToLogId.Value, logToUpdate);
            }
            return GetUpdateForm(logToUpdate);
        }

        protected abstract List<LogDTO> QueryDtosByFunctionalLocationsAndDateRange(Range<Date> dateRange);
        protected abstract List<LogDTO> GetLogsForDisplay();

        protected abstract bool AuthorizedToEditLog(LogDTO log);
        protected abstract bool AuthorizedToCopyLog(UserRoleElements userRoleElements);        
        protected abstract bool AuthorizedToDeleteLogs(List<LogDTO> selectedLogs);
        protected abstract bool AuthorizedToReplyToLogs(UserRoleElements userRoleElements);
        
        protected abstract IForm GetUpdateForm(Log logToUpdate);

        protected override bool IsItemInDateRange(Log log, Range<Date> dateRange)
        {
            return new DateRange(dateRange).ContainsInclusive(log.LogDateTime);
        }

        protected override void Grid_SelectedItemChanged(object sender, DomainEventArgs<LogDTO> args)
        {
            base.Grid_SelectedItemChanged(sender, args);
            if(page.ShowLogThread)
            {
                RefreshThreadedView(false);
                LogDTO logDto = page.FirstSelectedItem;
                DisableThreadItemChangedEvent();
                page.SelectThreadItem(logDto);
                page.SetIsParentMissing(logDto.ParentIsUnavailable);
                EnableThreadItemChangedEvent();
            }
        }

        private void DisableThreadItemChangedEvent()
        {
            page.Details.SelectedThreadItemChanged -= SelectedThreadItemChanged;
        }

        private void EnableThreadItemChangedEvent()
        {
            page.Details.SelectedThreadItemChanged += SelectedThreadItemChanged;
        }

        private void SelectedThreadItemChanged(object sender, DomainEventArgs<LogDTO> args)
        {
            DisableSelectedItemChangedEvent();
            page.SelectSingleItemById(args.SelectedItem.Id);
            page.SetIsParentMissing(args.SelectedItem.ParentIsUnavailable);
            ControlShowingOfDetailsPane();
            ControlDetailButtons();
            EnableSelectedItemChangedEvent();
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            User user = userContext.User;
            List<LogDTO> selectedLogs = page.SelectedItems; 
            bool hasItemsSelected = selectedLogs.Count > 0;
            bool hasSingleItemSelected = selectedLogs.Count == 1;
            ILogDetails details = page.Details;
            details.DeleteEnabled = hasItemsSelected && AuthorizedToDeleteLogs(selectedLogs);
            details.ReplyEnabled = hasSingleItemSelected && AuthorizedToReplyToLogs(userRoleElements);            
            details.EditEnabled = hasSingleItemSelected && AuthorizedToEditLog(page.FirstSelectedItem);
            details.CopyEnabled = hasSingleItemSelected && AuthorizedToCopyLog(userRoleElements);
            details.ViewThreadEnabled = hasSingleItemSelected;
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.MarkAsReadEnabled =
                hasSingleItemSelected &&
                authorized.ToMarkLogsAsRead(user, page.FirstSelectedItem) &&
                // Performing this check in the presenter and not the authorization module to prevent
                //   needless hits to the database should the log fail the above preconditions.
                !logService.UserMarkedLogAsRead(page.FirstSelectedItem.IdValue, user.IdValue);
            details.PrintEnabled = hasItemsSelected;
            details.PreviewEnabled = hasSingleItemSelected;

            // Added by Mukesh for RITM0218684
            details.EmailEnabled = page.SelectedItems.Count >0;
        }

        private void ViewThread(object sender, EventArgs args)
        {
            page.ShowLogThread = !page.ShowLogThread;
            page.SetIsParentMissing(false);
            RefreshThreadedView(false);
        }

        protected override void Delete(Log log)
        {
            SetAsModified(log);
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.Remove, log); 
            RefreshThreadedView(false);
        }

        private void Reply(object sender, EventArgs args)
        {
            LockDatabaseObjectWhileInUse(Reply, LockType.Edit);
        }

        private void Reply(Log log)
        {
            page.LaunchCreateReplyForm(log);
            RefreshThreadedView(false);
        }

        protected virtual void MarkAsRead(object sender, EventArgs args)
        {
            Log log = QueryForFirstSelectedItem();
            if (log != null)
            {
                MarkAsRead(log, userContext.User, Clock.Now);
                ItemUpdated(log);
                remoteEventRepeater.Dispatch(ApplicationEvent.LogMarkedAsReadByCurrentUser, log);
            }
        }

        protected virtual void MarkAsRead(Log log, User user, DateTime dateTime)
        {
            logService.MarkAsRead(log.IdValue, user.IdValue, dateTime);
        }

        private void Print(object sender, EventArgs args)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
        }

        private void PrintPreview(object sender, EventArgs args)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLogCreated += repeater_Created;
            remoteEventRepeater.ServerLogUpdated += repeater_Updated;
            remoteEventRepeater.ServerLogRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLogCreated -= repeater_Created;
            remoteEventRepeater.ServerLogUpdated -= repeater_Updated;
            remoteEventRepeater.ServerLogRemoved -= repeater_Removed;
        }

        protected override Log QueryByDto(LogDTO dto)
        {
            return logService.QueryById(dto.IdValue);
        }

        protected virtual void Copy(object sender, EventArgs args)
        {
            if (page.FirstSelectedItem != null)
            {
                Log log = QueryForFirstSelectedItem();
                if (log != null)
                {
                    page.LaunchCreateForm(log);
                }
            }
        }

        private static void SetAsModified(Log log)
        {
            log.LastModifiedBy = ClientSession.GetUserContext().User;
            log.LastModifiedDate = Clock.Now;
        }

        protected override void SetDetailData(ILogDetails details, Log log)
        {
            details.SetDetails(log, log.CustomFields);
        }

        protected override LogDTO CreateDTOFromDomainObject(Log item)
        {
            return new LogDTO(item) { ParentIsUnavailable = false };
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_Log; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date fromDate = DateRangeUtilities.GetFromDateForLogs(userContext.Site, userContext.SiteConfiguration, timeService);
            return new Range<Date>(fromDate, null);
        }

        protected override IList<LogDTO> GetDtos(Range<Date>dateRange)
        {
            if (dateRange == null)
            {
                List<LogDTO> dtos = GetLogsForDisplay();
                dtos.Sort(dto => dto.LogDateTime, false);
                return dtos;
            }
            else
            {
                List<LogDTO> dtos = QueryDtosByFunctionalLocationsAndDateRange(dateRange);
                dtos.Sort(dto => dto.LogDateTime, false);
                return dtos;
            }
        }


        // Added by Mukesh for RITM0218684
        private void Email(object sender, EventArgs e)
        {


            List<Log> Logs = new List<Log>();
            foreach (var dao in page.SelectedItems)
            {
                var Log = QueryByDto(dao);
                Logs.Add(Log);
            }

            // var emailSubject = string.Format(" - {0} - {1}", summaryLog.CreationUser.Username,
            //summaryLog.ShiftDisplayName);

            var emailSubject = "";

            reportPrintManager.Email(Logs, StringResources.LogEmailSubjectPrefix,
              emailSubject);
        }
    }
}