using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageDirectiveLogDetailsPresenter : PriorityPageDetailsPresenter<ILogDetails>
    {
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly ILogService logService;
        private readonly Log directive;
        private readonly List<CustomField> customFields;
        private readonly IEditHistoryService editHistoryService;
        private readonly ISiteConfigurationService siteConfigurationService;

        private readonly IReportPrintManager<Log> reportPrintManager;

        public PriorityPageDirectiveLogDetailsPresenter(long directiveId, IAuthorized authorized, IRemoteEventRepeater remoteEventRepeater) 
            : base(
                StringResources.DomainObjectName_DailyDirective, 
                new LogDetails())
        {
            this.remoteEventRepeater = remoteEventRepeater;
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            editHistoryService = ClientServiceRegistry.Instance.GetService<IEditHistoryService>();
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            
            directive = logService.QueryById(directiveId);
            customFields = directive.CustomFields;

            details.ShowTreePanel = false;
            details.MakeAllButtonsInvisible();
            details.MarkAsReadVisible = true;
            details.PrintVisible = true;

            details.SetDetails(directive, customFields);
            details.MarkAsReadEnabled = authorized.ToMarkLogsAsRead(userContext.User, new LogDTO(directive)) && !logService.UserMarkedLogAsRead(directiveId, userContext.User.IdValue);

            details.MarkAsRead += Details_MarkAsRead;
            details.Print += Details_Print;
            details.CustomFieldEntryClicked += Details_CustomFieldEntryClicked;
            details.DetailsMarkedAsReadByExpand += DetailsMarkedAsReadByExpand;

            reportPrintManager = new ReportPrintManager<Log, RtfGenericSingleLogReport, GenericSingleLogReportAdapter>(new LogPrintActions(logService, editHistoryService));

        }

        private void DetailsMarkedAsReadByExpand(Log log)
        {
            details.MarkedAsReadBy = logService.UsersThatMarkedLogAsRead(log.IdValue);
        }

        private void Details_CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            CustomFieldPresenterMaker.Create(logService, customFieldEntry, directive.WorkAssignment).Run(view);
        }

        protected override void UnsubscribeToEvents()
        {
            details.MarkAsRead -= Details_MarkAsRead;
            details.Print -= Details_Print;
            details.CustomFieldEntryClicked -= Details_CustomFieldEntryClicked;
            details.DetailsMarkedAsReadByExpand -= DetailsMarkedAsReadByExpand;
        }

        private void Details_MarkAsRead(object sender, EventArgs e)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            LogRead logRead = logService.MarkAsRead(directive.IdValue, userContext.User.IdValue, Clock.Now);
            details.MarkAsReadEnabled = false;
            details.AddMarkedAsReadUser(new ItemReadBy(userContext.User.FullNameWithUserName, logRead.Time));

            remoteEventRepeater.Dispatch(ApplicationEvent.LogMarkedAsReadByCurrentUser, directive);
            view.Close();
        }

        private void Details_Print(object sender, EventArgs e)
        {
            new PrintWithDialogFocus().Print(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(new List<Log>{directive});
        }
    }
}
