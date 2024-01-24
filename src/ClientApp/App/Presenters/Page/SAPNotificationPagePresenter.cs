using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class SAPNotificationPagePresenter : AbstractPagePresenter<SAPNotificationDTO, SAPNotification, ISAPNotificationDetails, ISAPNotificationPage>
    {
        private readonly ISAPNotificationService service;

        public SAPNotificationPagePresenter() : base(
            new SAPNotificationPage(), 
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            service = ClientServiceRegistry.Instance.GetService<ISAPNotificationService>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.Edit += Details_Edit;
            page.Details.SubmitToLog += ApproveAndCreateLog;
            page.Details.SubmitToOperatingEngineerLog += ApproveAndCreateOperatingEngineerLog;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Edit -= Details_Edit;
            page.Details.SubmitToLog -= ApproveAndCreateLog;
            page.Details.SubmitToOperatingEngineerLog -= ApproveAndCreateOperatingEngineerLog;            
        }

        private void Details_Edit(object sender, EventArgs e)
        {
            LockDatabaseObjectWhileInUse(Edit, LockType.Edit);
        }

        private void Edit(SAPNotification sapNotification)
        {
            SAPNotificationForm newForm = new SAPNotificationForm(sapNotification);
            newForm.ShowDialog(page.ParentForm);
            newForm.Dispose();
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements roleElements = userContext.UserRoleElements;

            ISAPNotificationDetails details = page.Details;

            List<SAPNotificationDTO> selectedItems = page.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;

            bool submitToLogEnabled = hasItemsSelected && authorized.ToProcessSAPNotfications(roleElements, selectedItems);
            
            

            details.SubmitToLogEnabled = submitToLogEnabled;
            details.SubmitToOperatingEngineerLogEnabled = submitToLogEnabled && userContext.SiteConfiguration.CreateOperatingEngineerLogs;
            details.SubmitToOperatingEngineerLogText = string.Format(StringResources.SAPNotificationPagePresenter_SubmitToEngineer, userContext.SiteConfiguration.OperatingEngineerLogDisplayName);
            details.EditEnabled = hasSingleItemSelected &&  authorized.ToProcessSAPNotfication(roleElements, page.FirstSelectedItem);
        }

        private void ApproveAndCreateLog(object sender, EventArgs args)
        {
            bool confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.SAPNotificationCreateLogFromEntityMessageBoxText, StringResources.DomainObjectName_Log, DomainObjectName),
                string.Format(StringResources.SAPNotificationCreateLogFromEntityMessageBoxText, StringResources.DomainObjectName_Log, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(ApproveAndCreateLog, null);
            }
        }

        private void ApproveAndCreateLog(SAPNotification sapNotification)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.ProcessNotificationAndCreateLog,
                sapNotification, 
                userContext.User,
                userContext.UserShift.ShiftPattern,
                false, 
                userContext.Role,
                userContext.Assignment);
        }

        private void ApproveAndCreateOperatingEngineerLog(object sender, EventArgs args)
        {
            string operatingEngineerLogDisplayName = userContext.SiteConfiguration.OperatingEngineerLogDisplayName;
            bool confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.SAPNotificationCreateLogFromEntityMessageBoxText, operatingEngineerLogDisplayName, DomainObjectName),
                string.Format(StringResources.SAPNotificationCreateLogFromEntityMessageBoxText, operatingEngineerLogDisplayName, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(ApproveAndCreateOperatingEngineerLog, null);
            }
        }

        private void ApproveAndCreateOperatingEngineerLog(SAPNotification sapNotification)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.ProcessNotificationAndCreateLog,
                sapNotification, 
                userContext.User, 
                userContext.UserShift.ShiftPattern,
                true, 
                userContext.Role,
                userContext.Assignment);
        }

        protected override SAPNotification QueryByDto(SAPNotificationDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerSAPNotificationCreated += repeater_Created;
            remoteEventRepeater.ServerSAPNotificationUpdated += repeater_Updated;
            remoteEventRepeater.ServerSAPNotificationProcessed += repeater_Updated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerSAPNotificationCreated -= repeater_Created;
            remoteEventRepeater.ServerSAPNotificationUpdated -= repeater_Updated;
            remoteEventRepeater.ServerSAPNotificationProcessed -= repeater_Updated;
        }

        protected override void SetDetailData(ISAPNotificationDetails details, SAPNotification value)
        {
            details.CreateDate = value.CreationDateTime.ToDateString();
            details.StartTime = value.CreationDateTime.ToTimeString();
            details.Comments = value.Comments;
            details.Description = value.Description;
            details.NotificationType = value.NotificationType;
            details.NotificationNumber = value.NotificationNumber;
            details.FunctionalLocationString = value.FunctionalLocation.FullHierarchyWithDescription;
            details.ShortTextString = value.ShortText;
            details.IncidentIDString = value.IncidentId;
        }

        protected override SAPNotificationDTO CreateDTOFromDomainObject(SAPNotification item)
        {
            return new SAPNotificationDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_SAPNotification; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date from = Clock.DateNow.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplaySAPNotificationsBackwards);            
            return new Range<Date>(from, null);
        }

        protected override IList<SAPNotificationDTO> GetDtos(Range<Date> dateRange)
        {
            DateRange range = new DateRange(dateRange);
            return service.QueryDTOsByUnitLevelFunctionalLocationsAndDateRange(userContext.RootFlocSet, range.SqlFriendlyStart, range.SqlFriendlyEnd);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.SAPNotifications; }
        }
    }
}
