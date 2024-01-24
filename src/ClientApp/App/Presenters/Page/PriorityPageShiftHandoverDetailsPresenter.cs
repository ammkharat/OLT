using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageShiftHandoverDetailsPresenter :
        PriorityPageDetailsPresenter<IShiftHandoverQuestionnaireDetails>
    {
        private readonly ShiftHandoverQuestionnaireDetailsPresenter detailsPresenter;
        private readonly ILogService logService;
        private readonly IRemoteEventRepeater remoteEventRepeater;

        private readonly IReportPrintManager<ShiftHandoverQuestionnaire> reportPrintManager;
        private readonly ShiftHandoverQuestionnaire shiftHandoverQuestionnaire;
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly ISummaryLogService summaryLogService;

        public PriorityPageShiftHandoverDetailsPresenter(long id, IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater)
            : base(
                StringResources.DomainObjectName_ShiftHandover,
                new ShiftHandoverQuestionnaireDetails())
        {
            this.remoteEventRepeater = remoteEventRepeater;
            shiftHandoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();

            shiftHandoverQuestionnaire = shiftHandoverService.QueryById(id);

            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            summaryLogService = ClientServiceRegistry.Instance.GetService<ISummaryLogService>();

            detailsPresenter = new ShiftHandoverQuestionnaireDetailsPresenter(details, shiftHandoverQuestionnaire);
            detailsPresenter.LoadView();

            details.MakeAllButtonsInvisible();
            details.MarkAsReadVisible = true;
            details.PrintVisible = true;

            var user = userContext.User;

            details.MarkAsReadEnabled =
                authorized.ToMarkShiftHandoverQuestionnairesAsRead(
                    user, new ShiftHandoverQuestionnaireDTO(shiftHandoverQuestionnaire)) &&
                !shiftHandoverService.UserMarkedLogAsRead(id, user.IdValue);

            details.MarkAsRead += Details_MarkAsRead;
            details.Print += Details_Print;

            details.ShiftLogCustomFieldEntryClicked += ShiftLogCustomFieldEntryClicked;
            details.SummaryLogCustomFieldEntryClicked += SummaryLogCustomFieldEntryClicked;
            details.DetailsMarkedAsReadByToggled += MarkedAsReadExpandClicked;

            var actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            var shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            var actionItemService = ClientServiceRegistry.Instance.GetService<IActionItemService>();
            var functionalLocationOperationalModeService =
                ClientServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>();
            var lubesCsdService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            var excursionResponseService = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();

            PrintActions
                <ShiftHandoverQuestionnaire, RtfShiftHandoverQuestionnaireReport,
                    ShiftHandoverQuestionnaireReportAdapter> printActions =
                        new ShiftHandoverQuestionnairePrintActions(shiftHandoverService,
                            actionItemDefinitionService,
                            shiftPatternService,
                            actionItemService,
                            
                            functionalLocationOperationalModeService,
                            lubesCsdService,
                            excursionResponseService);
            reportPrintManager =
                new ReportPrintManager
                    <ShiftHandoverQuestionnaire, RtfShiftHandoverQuestionnaireReport,
                        ShiftHandoverQuestionnaireReportAdapter>(printActions);
        }

        private void MarkedAsReadExpandClicked(ShiftHandoverQuestionnaire obj)
        {
            details.MarkedAsReadBy = shiftHandoverService.UsersThatMarkedLogAsRead(shiftHandoverQuestionnaire.IdValue);
        }

        private void ShiftLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            var assignmentId = shiftHandoverQuestionnaire.Assignment.Id;
            if (assignmentId.HasValue)
            {
                CustomFieldPresenterMaker.Create(logService, customFieldEntry, shiftHandoverQuestionnaire.Assignment)
                    .Run(view);
            }
        }

        private void SummaryLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            var assignmentId = shiftHandoverQuestionnaire.Assignment.Id;
            if (assignmentId.HasValue)
            {
                CustomFieldPresenterMaker.Create(summaryLogService, customFieldEntry,
                    shiftHandoverQuestionnaire.Assignment).Run(view);
            }
        }

        protected override void UnsubscribeToEvents()
        {
            details.MarkAsRead -= Details_MarkAsRead;
            details.Print -= Details_Print;
            details.ShiftLogCustomFieldEntryClicked -= ShiftLogCustomFieldEntryClicked;
            details.SummaryLogCustomFieldEntryClicked -= SummaryLogCustomFieldEntryClicked;
            details.DetailsMarkedAsReadByToggled -= MarkedAsReadExpandClicked;
        }

        private void Details_MarkAsRead(object sender, EventArgs e)
        {
            var dateTime = Clock.Now;
            var markAsReadWasSuccessful = shiftHandoverService.MarkAsRead(shiftHandoverQuestionnaire.IdValue,
                userContext.User.IdValue, dateTime);
            details.MarkAsReadEnabled = false;
            details.AddMarkedAsReadUser(new ItemReadBy(userContext.User.FullNameWithUserName, dateTime));
            detailsPresenter.LoadView();

            // If the handover was deleted before the user marked as read, don't dispatch the event because it will create
            // a new row for the deleted handover on the priorities page and then the app will act funny. True story.
            if (markAsReadWasSuccessful)
            {
                remoteEventRepeater.Dispatch(ApplicationEvent.ShiftHandoverQuestionnaireMarkedAsReadByCurrentUser,
                    shiftHandoverQuestionnaire);
            }

            view.Close();
        }

        private void Details_Print(object sender, EventArgs e)
        {
            new PrintWithDialogFocus().Print(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(new List<ShiftHandoverQuestionnaire> {shiftHandoverQuestionnaire});
        }
    }
}