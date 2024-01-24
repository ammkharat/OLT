using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractShiftHandoverQuestionnairePagePresenter :
        AbstractDeletableDomainPagePresenter
            <ShiftHandoverQuestionnaireDTO, ShiftHandoverQuestionnaire, IShiftHandoverQuestionnaireDetails,
                IShiftHandoverQuestionnairePage>
    {
        private static readonly ILog logger =
            LogManager.GetLogger(typeof (AbstractShiftHandoverQuestionnairePagePresenter));

        private readonly object detailsPresenterLockObject = new object();
        private readonly HashSet<long> idsOfHandoversReadByCurrentUser = new HashSet<long>();

        private readonly ILogService logService;
        private readonly IReportPrintManager<ShiftHandoverQuestionnaire> reportPrintManager;
        protected readonly IShiftHandoverService service;
        private readonly ISummaryLogService summaryLogService;

        private ShiftHandoverQuestionnaireDetailsPresenter detailsPresenter;

        protected AbstractShiftHandoverQuestionnairePagePresenter(IShiftHandoverQuestionnairePage page)
            : base(page)
        {
            service = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            summaryLogService = ClientServiceRegistry.Instance.GetService<ISummaryLogService>();

            var actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            var shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            var actionItemService = ClientServiceRegistry.Instance.GetService<IActionItemService>();
            var functionalLocationOperationalModeService =
                ClientServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>();
            var lubesCsdService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
   var excursionResponseService = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();

            SubscribeToEvents();

            var printActions = new ShiftHandoverQuestionnairePrintActions(
                service,
                actionItemDefinitionService,
                shiftPatternService,
                actionItemService,
                functionalLocationOperationalModeService,
                lubesCsdService,excursionResponseService);
            reportPrintManager =
                new ReportPrintManager
                    <ShiftHandoverQuestionnaire, RtfShiftHandoverQuestionnaireReport,
                        ShiftHandoverQuestionnaireReportAdapter>(printActions);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ShiftHandover; }
        }

        private void SubscribeToEvents()
        {
            page.VisibleChanged += Page_VisibleChanged;
            page.Details.MarkAsRead += MarkAsRead;
            page.Details.Print += Print;
            page.Details.Preview += PrintPreview;
            page.Details.Email += EmailwithMultipleDocument;
            page.Details.ShiftLogCustomFieldEntryClicked += ShiftLogCustomFieldEntryClicked;
            page.Details.SummaryLogCustomFieldEntryClicked += SummaryLogCustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByToggled += DetailsMarkedAsReadByToggled;
        }

        private void SummaryLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            var assignmentId = page.FirstSelectedItem.AssignmentId;
            if (assignmentId.HasValue)
            {
                CustomFieldPresenterMaker.Create(summaryLogService, customFieldEntry, assignmentId.Value,
                    page.FirstSelectedItem.AssignmentName).Run(page.MainParentForm);
            }
        }

        private void ShiftLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            var assignmentId = page.FirstSelectedItem.AssignmentId;
            if (assignmentId.HasValue)
            {
                CustomFieldPresenterMaker.Create(logService, customFieldEntry, assignmentId.Value,
                    page.FirstSelectedItem.AssignmentName).Run(page.MainParentForm);
            }
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            page.VisibleChanged -= Page_VisibleChanged;
            page.Details.MarkAsRead -= MarkAsRead;
            page.Details.Print -= Print;
            page.Details.Preview -= PrintPreview;
            page.Details.Email -= EmailwithMultipleDocument;
            page.Details.ShiftLogCustomFieldEntryClicked -= ShiftLogCustomFieldEntryClicked;
            page.Details.SummaryLogCustomFieldEntryClicked -= SummaryLogCustomFieldEntryClicked;
            page.Details.DetailsMarkedAsReadByToggled -= DetailsMarkedAsReadByToggled;
        }

        private void DetailsMarkedAsReadByToggled(ShiftHandoverQuestionnaire handover)
        {
            page.Details.MarkedAsReadBy = service.UsersThatMarkedLogAsRead(handover.IdValue);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(ShiftHandoverQuestionnaire item)
        {
            return new EditShiftHandoverQuestionnaireHistoryFormPresenter(item);
        }

        protected override void Edit(ShiftHandoverQuestionnaire domainObject)
        {
            ShiftHandoverQuestionnaireFormPresenter.ShowForm(page.ParentForm, domainObject);
        }

        protected override IForm CreateEditForm(ShiftHandoverQuestionnaire item)
        {
            return new ShiftHandoverQuestionnaireForm(item);
        }

        private void Page_VisibleChanged(object sender, EventArgs e)
        {
            if (page.Visible && detailsPresenter != null)
            {
                detailsPresenter.LoadView();
            }
        }

        protected override void ControlDetailButtons()
        {
            var user = ClientSession.GetUserContext().User;
            var userShift = ClientSession.GetUserContext().UserShift;
            var roleElements = ClientSession.GetUserContext().UserRoleElements;
            if (roleElements != null)
            {
                var selectedItems = page.SelectedItems;
                var hasSingleItemSelected = selectedItems.Count == 1;
                var hasItemsSelected = selectedItems.Count > 0;

                var firstSelectedItem = page.FirstSelectedItem;

                var details = page.Details;

                details.DeleteEnabled = hasItemsSelected &&
                                        authorized.ToDeleteShiftHandoverQuestionnaire(user, roleElements, userShift,
                                            selectedItems);
                details.EditEnabled = hasSingleItemSelected &&
                                      authorized.ToEditShiftHandoverQuestionnaire(user, roleElements, userShift,
                                          firstSelectedItem);
                details.ViewEditHistoryEnabled = hasSingleItemSelected;
                details.MarkAsReadEnabled = hasSingleItemSelected &&
                                            authorized.ToMarkShiftHandoverQuestionnairesAsRead(user, firstSelectedItem) &&
                                            !service.UserMarkedLogAsRead(page.FirstSelectedItem.IdValue, user.IdValue);
                details.PrintEnabled = hasItemsSelected;
                details.PreviewEnabled = hasSingleItemSelected;

                // Commented by Mukesh for RITM0218684
                details.EmailEnabled = page.SelectedItems.Count > 0;// hasSingleItemSelected;
            }
        }

        protected override void Delete(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaire.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Remove, questionnaire);
        }

        public override void DeleteButton_Clicked()
        {
            var shiftHandoverQuestionnaires = ConvertAllTo(page.SelectedItems);

            DeleteWithOkCancelDialog(
                service.ShiftHandoversAreMarkedAsRead(shiftHandoverQuestionnaires.ConvertAll(obj => obj.IdValue))
                    ? StringResources.DeletingItemMarkedAsReadWarning
                    : StringResources.DeleteItemDialogText);
        }

        private void MarkAsRead(object sender, EventArgs args)
        {
            var questionnaire = QueryForFirstSelectedItem();
            if (questionnaire != null)
            {
                service.MarkAsRead(questionnaire.IdValue, userContext.User.IdValue, Clock.Now);
                idsOfHandoversReadByCurrentUser.Add(questionnaire.IdValue);
                ItemUpdated(questionnaire);
                remoteEventRepeater.Dispatch(ApplicationEvent.ShiftHandoverQuestionnaireMarkedAsReadByCurrentUser,
                    questionnaire);
            }
        }

        private void repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> e)
        {
            if (page.IsDisposed || e.SelectedItem == null)
            {
                return;
            }

            page.Invoke(
                new QuestionnaireMarkedAsReadByCurrentUserDelegate(Invoked_Repeater_MarkedAsReadByCurrentUser),
                e.SelectedItem);
        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(ShiftHandoverQuestionnaire questionnaire)
        {
            if (questionnaire != null && !idsOfHandoversReadByCurrentUser.Contains(questionnaire.IdValue))
            {
                idsOfHandoversReadByCurrentUser.Add(questionnaire.IdValue);
                ItemUpdated(questionnaire);
            }
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

        private void Email(object sender, EventArgs e)
        {
            var shiftHandoverQuestionnaireDto = page.FirstSelectedItem;
            var shiftHandoverQuestionnaire = QueryByDto(shiftHandoverQuestionnaireDto);

            var emailSubject = string.Format(" - {0} - {1}", shiftHandoverQuestionnaire.CreateUser.Username,
                shiftHandoverQuestionnaireDto.ShiftDisplayName);
            reportPrintManager.Email(shiftHandoverQuestionnaire, StringResources.HandoverEmailSubjectPrefix,
                emailSubject);
        }
        // Added by Mukesh for RITM0218684
        private void EmailwithMultipleDocument(object sender, EventArgs e)
        {



            List<ShiftHandoverQuestionnaire> shiftHandoverQuestionnaires = new List<ShiftHandoverQuestionnaire>();
            foreach (var dao in page.SelectedItems)
            {
                var shiftHandoverQuestionnaire = QueryByDto(dao);
                shiftHandoverQuestionnaires.Add(shiftHandoverQuestionnaire);
            }

            var emailSubject = "";
            reportPrintManager.Email(shiftHandoverQuestionnaires, StringResources.HandoverEmailSubjectPrefix,
              emailSubject);

            
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerShiftHandoverQuestionnaireCreated += repeater_Created;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireUpdated += repeater_Updated;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireRemoved += repeater_Removed;

            remoteEventRepeater.ServerLogCreated += repeater_LogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerLogUpdated += repeater_LogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerLogRemoved += repeater_LogCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerSummaryLogCreated += repeater_SummaryLogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerSummaryLogUpdated += repeater_SummaryLogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerSummaryLogRemoved += repeater_SummaryLogCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerCokerCardCreated += repeater_CokerCardCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerCokerCardUpdated += repeater_CokerCardCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerCokerCardRemoved += repeater_CokerCardCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser +=
                repeater_MarkedAsReadByCurrentUser;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerShiftHandoverQuestionnaireCreated -= repeater_Created;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireUpdated -= repeater_Updated;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireRemoved -= repeater_Removed;

            remoteEventRepeater.ServerLogCreated -= repeater_LogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerLogUpdated -= repeater_LogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerLogRemoved -= repeater_LogCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerSummaryLogCreated -= repeater_SummaryLogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerSummaryLogUpdated -= repeater_SummaryLogCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerSummaryLogRemoved -= repeater_SummaryLogCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerCokerCardCreated -= repeater_CokerCardCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerCokerCardUpdated -= repeater_CokerCardCreatedUpdatedOrRemoved;
            remoteEventRepeater.ServerCokerCardRemoved -= repeater_CokerCardCreatedUpdatedOrRemoved;

            remoteEventRepeater.ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser -=
                repeater_MarkedAsReadByCurrentUser;
        }

        private void repeater_CokerCardCreatedUpdatedOrRemoved(object sender, DomainEventArgs<CokerCard> e)
        {
            if (e.SelectedItem != null)
            {
                RefreshDetailsIfNecessary(e.SelectedItem, e.ApplicationEventType);
            }
        }

        private void repeater_LogCreatedUpdatedOrRemoved(object sender, DomainEventArgs<Log> e)
        {
            if (e.SelectedItem != null)
            {
                RefreshDetailsIfNecessary(
                    e.SelectedItem.CreationUser,
                    e.SelectedItem.WorkAssignment,
                    e.SelectedItem.CreatedDateTime,
                    e.SelectedItem.CreatedShiftPattern,
                    e.ApplicationEventType);
            }
        }

        private void repeater_SummaryLogCreatedUpdatedOrRemoved(object sender, DomainEventArgs<SummaryLog> e)
        {
            if (e.SelectedItem != null)
            {
                RefreshDetailsIfNecessary(
                    e.SelectedItem.CreationUser,
                    e.SelectedItem.WorkAssignment,
                    e.SelectedItem.LogDateTime,
                    e.SelectedItem.CreatedShiftPattern,
                    e.ApplicationEventType);
            }
        }

        private void RefreshDetailsIfNecessary(
            User logCreateUser,
            WorkAssignment logWorkAssignment,
            DateTime logCreateDateTime,
            ShiftPattern logShift,
            ApplicationEvent applicationEventType)
        {
            if (!page.IsDisposed)
            {
                page.Invoke(
                    new RefreshDetailForLogDelegate(RefreshDetailsIfNecessaryOnUIThread),
                    logCreateUser, logWorkAssignment, logCreateDateTime, logShift, applicationEventType);
            }
        }

        private void RefreshDetailsIfNecessary(CokerCard cokerCard, ApplicationEvent applicationEventType)
        {
            if (!page.IsDisposed)
            {
                page.Invoke(new RefreshDetailsForCokerCardDelegate(RefreshDetailsIfNecessaryOnUIThreadForCokerCard),
                    cokerCard, applicationEventType);
            }
        }

        private void RefreshDetailsIfNecessaryOnUIThreadForCokerCard(CokerCard cokerCard,
            ApplicationEvent applicationEventType)
        {
            try
            {
                lock (detailsPresenterLockObject)
                {
                    if (detailsPresenter != null &&
                        detailsPresenter.Questionnaire != null &&
                        detailsPresenter.ShouldUpdateCurrentQuestionnaireOnCokerCardChange(cokerCard))
                    {
                        SetDetailData(page.Details, detailsPresenter.Questionnaire, true);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error refreshing detail on event = " + applicationEventType + ". " + exception);
            }
        }

        private void RefreshDetailsIfNecessaryOnUIThread(
            User logCreateUser,
            WorkAssignment logWorkAssignment,
            DateTime logCreateDateTime,
            ShiftPattern logShift,
            ApplicationEvent applicationEventType)
        {
            try
            {
                lock (detailsPresenterLockObject)
                {
                    if (detailsPresenter != null &&
                        detailsPresenter.Questionnaire != null &&
                        detailsPresenter.Questionnaire.MatchesLogByUserAssignmentAndShift(logCreateUser,
                            logWorkAssignment, logCreateDateTime, logShift))
                    {
                        SetDetailData(page.Details, detailsPresenter.Questionnaire, true);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error refreshing detail on event = " + applicationEventType + ". " + exception);
            }
        }

        protected override ShiftHandoverQuestionnaire QueryByDto(ShiftHandoverQuestionnaireDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(IShiftHandoverQuestionnaireDetails details,
            ShiftHandoverQuestionnaire questionnaire)
        {
            lock (detailsPresenterLockObject)
            {
                SetDetailData(details, questionnaire, false);
            }
        }

        private void SetDetailData(IShiftHandoverQuestionnaireDetails details, ShiftHandoverQuestionnaire questionnaire,
            bool forceRefresh)
        {
            if (forceRefresh ||
                detailsPresenter == null ||
                ShiftHandoverQuestionnaire.AreDifferentBasedOnIdOrAnswers(detailsPresenter.Questionnaire, questionnaire))
            {
                detailsPresenter = new ShiftHandoverQuestionnaireDetailsPresenter(details, questionnaire);
            }
            detailsPresenter.LoadView();
        }

        protected override ShiftHandoverQuestionnaireDTO CreateDTOFromDomainObject(
            ShiftHandoverQuestionnaire domainObject)
        {
            var dto = new ShiftHandoverQuestionnaireDTO(domainObject);
            dto.IsReadByCurrentUser = dto.CreateUserId == userContext.User.IdValue ||
                                      idsOfHandoversReadByCurrentUser.Contains(dto.IdValue);

            return dto;
        }

        protected override sealed IList<ShiftHandoverQuestionnaireDTO> GetDtos(Range<Date> dateRange)
        {
            var dtos = QueryDtos(dateRange);

            idsOfHandoversReadByCurrentUser.Clear();
            foreach (var dto in dtos)
            {
                if (dto.IsCreatedBy(ClientSession.GetUserContext().User))
                {
                    dto.IsReadByCurrentUser = true;
                }

                if (dto.IsReadByCurrentUser.HasValue && dto.IsReadByCurrentUser.Value)
                {
                    idsOfHandoversReadByCurrentUser.Add(dto.IdValue);
                }
            }

            return dtos;
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            var fromDate = DateRangeUtilities.GetFromDateForShiftHandovers(userContext.Site,
                userContext.SiteConfiguration, timeService);
            return new Range<Date>(fromDate, null);
        }

        protected abstract IList<ShiftHandoverQuestionnaireDTO> QueryDtos(Range<Date> dateRange);

        private delegate void QuestionnaireMarkedAsReadByCurrentUserDelegate(ShiftHandoverQuestionnaire questionnaire);

        private delegate void RefreshDetailForLogDelegate(
            User logCreateUser,
            WorkAssignment logWorkAssignment,
            DateTime logCreateDateTime,
            ShiftPattern logShift,
            ApplicationEvent applicationEventType);

        private delegate void RefreshDetailsForCokerCardDelegate(
            CokerCard cokerCard,
            ApplicationEvent applicationEventType);
    }
}