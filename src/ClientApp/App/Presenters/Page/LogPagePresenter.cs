using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class LogPagePresenter : AbstractLogPagePresenter
    {
        public LogPagePresenter() : this(
            new LogPage(), 
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<IEditHistoryService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected LogPagePresenter(
            ILogPage page,
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ILogService logService,
            IEditHistoryService editHistoryService,
            ITimeService timeService,
            IUserService userService)
            : base(
                page,
                authorized,
                remoteEventRepeater,
                objectLockingService,
                logService, 
                editHistoryService,
                timeService,
                userService)
        {
        }

        protected override List<LogDTO> QueryDtosByFunctionalLocationsAndDateRange(Range<Date> range)
        {
            return logService.GetLogsForDisplay(userContext.RootFlocSet, new DateRange(range), userContext.ReadableVisibilityGroupIds, userContext.Role.IdValue);
        }

        protected override List<LogDTO> GetLogsForDisplay()
        {
            Range<Date> defaultDateRange = GetDefaultDateRange();
            return logService.GetLogsForDisplay(userContext.RootFlocSet, new DateRange(defaultDateRange), userContext.ReadableVisibilityGroupIds, userContext.Role.IdValue);
        }

        protected override bool ShouldBeDisplayed(Log item)
        {
            return LogType.Standard == item.LogType;
        }

        protected override bool AuthorizedToEditLog(LogDTO log)
        {
            // By Vibhor : RITM0272920
            if (userContext.Role.IsAdministratorRole && ClientSession.GetUserContext().SiteConfiguration.AllowAdminToCreateAndEditPastDateLog)
            {
                return true;
            }
            //END
            return authorized.ToEditLog(log, userContext);
        }

        protected override bool AuthorizedToDeleteLogs(List<LogDTO> selectedLogs)
        {
            return authorized.ToDeleteLogs(selectedLogs, userContext);
        }

        protected override bool AuthorizedToCopyLog(UserRoleElements userRoleElements)
        {
            return authorized.ToCopyLogs(userRoleElements);
        }

        protected override bool AuthorizedToReplyToLogs(UserRoleElements userRoleElements)
        {
            return authorized.ToReplyToLog(userRoleElements);
        }

        protected override IForm GetUpdateForm(Log logToUpdate)
        {
            return LogForm.CreateForUpdate(logToUpdate);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.Logs; }
        }
    }
}
