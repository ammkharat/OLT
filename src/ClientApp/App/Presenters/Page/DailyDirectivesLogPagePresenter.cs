using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class DailyDirectivesLogPagePresenter : AbstractLogPagePresenter
    {
        private readonly RootFlocSet rootFlocSet;
        private readonly HashSet<long> idsOfDirectivesReadByCurrentUser = new HashSet<long>();
        private readonly ISiteConfigurationService siteConfigurationService;

        public DailyDirectivesLogPagePresenter()
            : base(new DailyDirectivesLogPage())
        {
            rootFlocSet = userContext.RootFlocSet;
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
        }

        protected override List<LogDTO> QueryDtosByFunctionalLocationsAndDateRange(Range<Date> dateRange)
        {
            return logService.GetDailyDirectivesForDisplayByUserRootFlocsAndDateRange(rootFlocSet, dateRange, userContext.User, userContext.ReadableVisibilityGroupIds);
        }

        protected override List<LogDTO> GetLogsForDisplay()
        {
            return logService.GetDailyDirectivesForDisplayByUserRootFlocs(userContext.Site, rootFlocSet, userContext.User, userContext.ReadableVisibilityGroupIds);
        }

        protected override IList<LogDTO> GetDtos(Range<Date> dateRange)
        {
            IList<LogDTO> dtos = base.GetDtos(dateRange);

            idsOfDirectivesReadByCurrentUser.Clear();
            foreach (LogDTO dto in dtos)
            {
                if (dto.IsCreatedBy(ClientSession.GetUserContext().User))
                {
                    dto.IsReadByCurrentUser = true;
                }

                if (dto.IsReadByCurrentUser.HasValue && dto.IsReadByCurrentUser.Value)
                {
                    idsOfDirectivesReadByCurrentUser.Add(dto.IdValue);
                }
            }

            return dtos;
        }

        protected override LogDTO CreateDTOFromDomainObject(Log item)
        {
            LogDTO dto = base.CreateDTOFromDomainObject(item);
            dto.IsReadByCurrentUser = dto.CreatedByUserId == userContext.User.IdValue || idsOfDirectivesReadByCurrentUser.Contains(dto.IdValue);                          
            return dto;
        }

        protected override bool ShouldBeDisplayed(Log item)
        {
            return LogType.DailyDirective == item.LogType;
        }

        protected override bool AuthorizedToEditLog(LogDTO log)
        {
            return authorized.ToEditDirectiveLogs(log, userContext);
        }

        protected override bool AuthorizedToCopyLog(UserRoleElements userRoleElements)
        {
            return authorized.ToCopyDirectiveLogs(userRoleElements);
        }

        protected override bool AuthorizedToDeleteLogs(List<LogDTO> selectedLogs)
        {
            return authorized.ToDeleteDirectiveLogs(selectedLogs, userContext);
        }

        protected override bool AuthorizedToReplyToLogs(UserRoleElements userRoleElements)
        {
            return authorized.ToReplyToDirectiveLogs(userRoleElements);
        }

        protected override IForm GetUpdateForm(Log logToUpdate)
        {
            return DirectiveLogForm.CreateForUpdate(logToUpdate);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_DailyDirective; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            base.HookToServiceEvents(remoteEventRepeater);

            remoteEventRepeater.ServerLogMarkedAsReadByCurrentUser += repeater_MarkedAsReadByCurrentUser;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            base.UnHookToServiceEvents(remoteEventRepeater);

            remoteEventRepeater.ServerLogMarkedAsReadByCurrentUser -= repeater_MarkedAsReadByCurrentUser;
        }

        private delegate void LogMarkedAsReadByCurrentUserDelegate(Log log);

        private void repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Log> e)
        {
            if (page.IsDisposed || e.SelectedItem == null)
            {
                return;
            }

            page.Invoke(
                new LogMarkedAsReadByCurrentUserDelegate(Invoked_Repeater_MarkedAsReadByCurrentUser),
                e.SelectedItem );

        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(Log log)
        {
            if (log != null && log.LogType.Equals(LogType.DailyDirective) && !idsOfDirectivesReadByCurrentUser.Contains(log.IdValue))
            {
                idsOfDirectivesReadByCurrentUser.Add(log.IdValue);
                base.ItemUpdated(log);
            }
        }

        protected override void MarkAsRead(object sender, EventArgs args)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.MarkAsRead(sender, args);
        }

        protected override void MarkAsRead(Log log, User user, DateTime dateTime)
        {
            base.MarkAsRead(log, user, dateTime);
            idsOfDirectivesReadByCurrentUser.Add(log.IdValue);
        }

        public override void DeleteButton_Clicked()
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.DeleteButton_Clicked();
        }

        protected override void Copy(object sender, EventArgs args)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.Copy(sender, args);
        }

        protected override void Edit(Log domainObject)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.Edit(domainObject);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.DailyDirectives; }
        }
    }
}