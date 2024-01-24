using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
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
    public class SummaryLogPagePresenter : AbstractDeletableDomainPagePresenter<SummaryLogDTO, SummaryLog, ISummaryLogDetails, ISummaryLogPage>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SummaryLogPagePresenter));

        private readonly ISummaryLogService summaryLogService;        
        private readonly IEditHistoryService editHistoryService;

        private readonly List<FunctionalLocation> parentFlocsThatAllDisplayedSummaryLogsShouldBeAtOrUnder;
        private readonly Time dorEditCutOffHour;

        private readonly object refreshDetailLockObject = new object();
        private readonly IReportPrintManager<SummaryLog> reportPrintManager;
        

        public SummaryLogPagePresenter() : base(new SummaryLogPage())
        {
            summaryLogService = ClientServiceRegistry.Instance.GetService<ISummaryLogService>();
            editHistoryService = ClientServiceRegistry.Instance.GetService<IEditHistoryService>();

            parentFlocsThatAllDisplayedSummaryLogsShouldBeAtOrUnder =
                userContext.SiteConfiguration.SummaryLogFunctionalLocationDisplayLevel == 2
                    ? userContext.SectionsForSelectedFunctionalLocations
                    : userContext.DivisionsForSelectedFunctionalLocations;

            dorEditCutOffHour = userContext.SiteConfiguration.DorEditCutoffTime;

            page.ShowLogThread = false;

            SubscribeToEvents();

            reportPrintManager =
                new ReportPrintManager<SummaryLog, RtfGenericSingleLogReport, GenericSingleLogReportAdapter>(new SummaryLogPrintActions(summaryLogService,
                    editHistoryService));
        }
       
       

        private void SubscribeToEvents()
        {
            page.Details.MarkAsRead += MarkAsRead;
            page.Details.Print += Print;
            page.Details.Preview += PrintPreview;
            page.Details.Reply += Reply;
            page.Details.ViewThread += ViewThread;
            page.Details.CustomFieldEntryClicked += CustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByToggled += DetailsMarkedAsReadByToggled;
            // Added by Mukesh for RITM0218684
            page.Details.Email += Email;
            //Added by Aarti RITM0512605:Copy feature for Shift Summary log
            page.Details.Copy += Copy;
                
            EnableThreadItemChangedEvent();
        }

        private void DetailsMarkedAsReadByToggled(SummaryLog summaryLog)
        {
            page.Details.MarkedAsReadBy = summaryLogService.UsersThatMarkedLogAsRead(summaryLog.IdValue);
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.MarkAsRead -= MarkAsRead;
            page.Details.Print -= Print;
            page.Details.Preview -= PrintPreview;
            page.Details.Reply -= Reply;
            page.Details.ViewThread -= ViewThread;
            page.Details.CustomFieldEntryClicked -= CustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByToggled -= DetailsMarkedAsReadByToggled;
            // Added by Mukesh for RITM0218684
            page.Details.Email -= Email;
            page.Details.Copy -= Copy; //Aarti :RITM0512605:Copy feature for Shift Summary log
            DisableThreadItemChangedEvent();
        }

        private void CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            SummaryLog summaryLog = QueryForFirstSelectedItem();
            IRunnablePresenter presenter = CustomFieldPresenterMaker.Create(summaryLogService, customFieldEntry, summaryLog.WorkAssignment);
            presenter.Run(page.MainParentForm);
        }

        //Aarti RITM0512605:Copy feature for Shift Summary log
        private IForm CreateCopyForm(SummaryLog log)
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            UserShift userShift = userContext.UserShift;
            return new SummaryLogForm(log, userContext.SiteConfiguration.HideDORCommentEntry);
        }
        //Aarti RITM0512605:Copy feature for Shift Summary log
        protected void Copy(object sender, EventArgs args)
        {
            
            if (page.FirstSelectedItem != null)
            {
                SummaryLog summaryLog = QueryForFirstSelectedItem();
                summaryLog.copyClickedSumm = true;
                if (summaryLog != null)
                {
                    IForm form = CreateCopyForm(summaryLog);
                    if (form != null)
                   {
                       form.ShowDialog(page.ParentForm);
                    }
                }
            }
        }

       

        protected override EditHistoryFormPresenter CreateHistoryPresenter(SummaryLog item)
        {
            return new EditSummaryLogHistoryFormPresenter(item);
        }

        protected override void Grid_SelectedItemChanged(object sender, DomainEventArgs<SummaryLogDTO> args)
        {
            base.Grid_SelectedItemChanged(sender, args);

            if (page.ShowLogThread)
            {
                RefreshThreadedView(false);
                SummaryLogDTO logDto = page.FirstSelectedItem;
                DisableThreadItemChangedEvent();
                page.SelectThreadItem(logDto);
                page.SetIsParentMissing(logDto.ParentIsUnavailable);
                EnableThreadItemChangedEvent();
            }
        }

        private void EnableThreadItemChangedEvent()
        {
            page.Details.SelectedThreadItemChanged += SelectedThreadItemChanged;
        }

        private void DisableThreadItemChangedEvent()
        {
            page.Details.SelectedThreadItemChanged -= SelectedThreadItemChanged;
        }

        private void SelectedThreadItemChanged(object sender, DomainEventArgs<SummaryLogDTO> args)
        {
            DisableSelectedItemChangedEvent();
            page.SelectSingleItemById(args.SelectedItem.Id);
            page.SetIsParentMissing(args.SelectedItem.ParentIsUnavailable);
            ControlShowingOfDetailsPane();
            ControlDetailButtons();
            EnableSelectedItemChangedEvent();
        }

        protected override SummaryLogDTO CreateDTOFromDomainObject(SummaryLog summaryLog)
        {
            SummaryLogDTO newDto = new SummaryLogDTO(summaryLog);
            return newDto;
        }

        protected override IForm CreateEditForm(SummaryLog log)
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            UserShift userShift = userContext.UserShift;

            bool authorizedToEditDORComments = AuthorizedToEditDORComments(page.FirstSelectedItem, userRoleElements, userShift);
            bool authorizedToEditSummaryLog = AuthorizedToEditSummaryLog(page.FirstSelectedItem);
            bool onlyAllowedToEditDORComments = !authorizedToEditSummaryLog && authorizedToEditDORComments;
            bool allowedToAddShiftInformation = authorized.ToAddShiftInformation(userRoleElements);

            if (log.ReplyToLogId.HasValue)
            {
                return new LogReplyForm(log.ReplyToLogId.Value, log);
            }
            if (authorizedToEditSummaryLog || authorizedToEditDORComments)
            {
                return new SummaryLogForm(log, onlyAllowedToEditDORComments, userContext.SiteConfiguration.HideDORCommentEntry, allowedToAddShiftInformation);
            }

            return null;
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {           
            remoteEventRepeater.ServerSummaryLogCreated += repeater_Created;
            remoteEventRepeater.ServerSummaryLogUpdated += repeater_Updated;
            remoteEventRepeater.ServerSummaryLogRemoved += repeater_Removed;     
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerSummaryLogCreated -= repeater_Created;
            remoteEventRepeater.ServerSummaryLogUpdated -= repeater_Updated;
            remoteEventRepeater.ServerSummaryLogRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {          
            List<SummaryLogDTO> selectedLogs = page.SelectedItems;
            bool hasSingleItemSelected = selectedLogs.Count == 1;
            ISummaryLogDetails summaryLogDetails = page.Details;

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            User user = userContext.User;
            UserShift userShift = userContext.UserShift;
            
            bool hasItemsSelected = selectedLogs.Count > 0;
                      
            summaryLogDetails.DeleteEnabled = 
                hasItemsSelected && AuthorizedToDeleteSummaryLogs(selectedLogs);
            summaryLogDetails.EditEnabled = 
                hasSingleItemSelected && 
                (AuthorizedToEditSummaryLog(page.FirstSelectedItem) ||
                 AuthorizedToEditDORComments(page.FirstSelectedItem, userRoleElements, userShift));
            summaryLogDetails.CancelEnabled = false;
            summaryLogDetails.ViewEditHistoryEnabled = hasSingleItemSelected;
            summaryLogDetails.MarkAsReadEnabled =
                hasSingleItemSelected &&
                authorized.ToMarkSummaryLogsAsRead(user, page.FirstSelectedItem) &&
                // Performing this check in the presenter and not the authorization module to prevent
                //   needless hits to the database should the log fail the above preconditions.
                !summaryLogService.UserMarkedSummaryLogAsRead(page.FirstSelectedItem.IdValue, user.IdValue);

            summaryLogDetails.PrintEnabled = hasItemsSelected;
            summaryLogDetails.PreviewEnabled = hasSingleItemSelected;

            summaryLogDetails.ViewThreadEnabled = hasSingleItemSelected;
            summaryLogDetails.ReplyEnabled = hasSingleItemSelected && authorized.ToCreateSummaryLogs(userRoleElements);

            // Added by Mukesh for RITM0218684
            summaryLogDetails.EmailEnabled = page.SelectedItems.Count > 0;
            //Amit Shukla disable copy button if no record selected 
            summaryLogDetails.CopyButtonEnabled = hasSingleItemSelected;

        }

        protected override bool ShouldBeDisplayed(SummaryLog item)
        {
            bool atLeastOneSummaryLogFlocIsAChildOfAParentDisplayFloc = false;

            foreach (FunctionalLocation floc in item.FunctionalLocations)
            {
                if (parentFlocsThatAllDisplayedSummaryLogsShouldBeAtOrUnder.Exists(obj => obj.Id == floc.Id || obj.IsParentOf(floc)))
                {
                    atLeastOneSummaryLogFlocIsAChildOfAParentDisplayFloc = true;
                }
            }

            return atLeastOneSummaryLogFlocIsAChildOfAParentDisplayFloc;
        }

        private bool AuthorizedToEditSummaryLog(SummaryLogDTO log)
        {
            return authorized.ToEditSummaryLog(log, userContext);
        }

        private bool AuthorizedToEditDORComments(SummaryLogDTO log, UserRoleElements userRoleElements, UserShift userShift)
        {
            return authorized.ToEditDORComments(userRoleElements, userShift, log, dorEditCutOffHour);
        }

        private bool AuthorizedToDeleteSummaryLogs(List<SummaryLogDTO> selectedLogs)
        {
            return authorized.ToDeleteSummaryLogs(selectedLogs, userContext);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_SummaryLog; }
        }

        protected override SummaryLog QueryByDto(SummaryLogDTO dto)
        {
            return summaryLogService.QueryById(dto.IdValue);
        }

        private void MarkAsRead(object sender, EventArgs args)
        {
            SummaryLog log = QueryForFirstSelectedItem();
            if (log != null)
            {
                summaryLogService.MarkAsRead(log.IdValue, userContext.User.IdValue, Clock.Now);
                ItemUpdated(log);
            }
        }

        protected override void SetDetailData(ISummaryLogDetails details, SummaryLog value)
        {
            lock (refreshDetailLockObject)
            {
                SetDetailDataNoLock(details, value);
            }
        }

        private void SetDetailDataNoLock(ISummaryLogDetails details, SummaryLog value)
        {
            SummaryLog summaryLog = value;
            details.SetDetails(value, summaryLog.CustomFields);
        }

        protected override void Delete(SummaryLog log)
        {
            log.LastModifiedBy = ClientSession.GetUserContext().User;
            log.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(summaryLogService.Remove, log);
            RefreshThreadedView(false);
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

        private void Reply(object sender, EventArgs e)
        {
            LockDatabaseObjectWhileInUse(Reply, LockType.Edit);
        }

        private void Reply(SummaryLog log)
        {
            page.LaunchCreateReplyForm(log);
            RefreshThreadedView(false);
        }
        
        private void ViewThread(object sender, EventArgs e)
        {
            page.ShowLogThread = !page.ShowLogThread;
            page.SetIsParentMissing(false);
            RefreshThreadedView(false);
        }
        
        protected override Range<Date> GetDefaultDateRange()
        {
            Date fromDate = DateRangeUtilities.GetFromDateForLogs(userContext.Site, userContext.SiteConfiguration, timeService);
            return new Range<Date>(fromDate, null);
        }

        protected override IList<SummaryLogDTO> GetDtos(Range<Date> dateRange)
        {
            List<long> readableVisibilityGroupIds = ClientSession.GetUserContext().ReadableVisibilityGroupIds;

            List<SummaryLogDTO> dtos = dateRange == null
                                           ? summaryLogService.QuerySummaryLogDTOsByParentFloc(new RootFlocSet(parentFlocsThatAllDisplayedSummaryLogsShouldBeAtOrUnder),
                                                                                               readableVisibilityGroupIds)
                                           : summaryLogService.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                                               new RootFlocSet(parentFlocsThatAllDisplayedSummaryLogsShouldBeAtOrUnder), dateRange, readableVisibilityGroupIds, ClientSession.GetUserContext().Role.IdValue);

            dtos.Sort(dto => dto.LogDateTime, false);
            return dtos;
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.SummaryLogs; }
        }

        protected override void RefreshThreadedView(bool recalculateRelationships)
        {
            ThreadedItemPresenterHelper.RefreshThreadedView(page, logger);
        }

       // Added by Mukesh for RITM0218684
        private void Email(object sender, EventArgs e)
        {
              var SummaryLogDto = page.FirstSelectedItem;

              List<SummaryLog> summaryLogs = new List<SummaryLog>();
              foreach (var dao in page.SelectedItems)
              {
                  var summaryLog = QueryByDto(dao);
                  summaryLogs.Add(summaryLog);
              }

             // var emailSubject = string.Format(" - {0} - {1}", summaryLog.CreationUser.Username,
             //summaryLog.ShiftDisplayName);

              var emailSubject = "";

              reportPrintManager.Email(summaryLogs, StringResources.SummaryEmailSubjectPrefix,
                emailSubject);
        }
    }
}