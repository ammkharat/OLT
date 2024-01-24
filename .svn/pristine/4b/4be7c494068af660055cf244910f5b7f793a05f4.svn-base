using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class LogByAssignmentPagePresenter : AbstractLogPagePresenter
    {
        public LogByAssignmentPagePresenter()
            : base(new LogByAssignmentPage())
        {
        }

        protected override List<LogDTO> QueryDtosByFunctionalLocationsAndDateRange(Range<Date> dateRange)
        {
            return logService.GetCrossShiftLogsForDisplay(userContext.RootFlocSet, userContext.Assignment, new DateRange(dateRange), userContext.ReadableVisibilityGroupIds);
        }

        protected override List<LogDTO> GetLogsForDisplay()
        {
            return logService.GetCrossShiftLogsForDisplay(userContext.RootFlocSet, userContext.Assignment, new DateRange(GetDefaultDateRange()), userContext.ReadableVisibilityGroupIds);
        }

        protected override bool ShouldBeDisplayed(Log item)
        {
            return
                LogType.Standard == item.LogType && userContext.HasSameAssignment(item.WorkAssignment);
        }

        protected override bool AuthorizedToEditLog(LogDTO log)
        {
            return authorized.ToEditLog(log, userContext);
        }

        protected override bool AuthorizedToCopyLog(UserRoleElements userRoleElements)
        {
            return authorized.ToCopyLogs(userRoleElements);
        }

        protected override bool AuthorizedToDeleteLogs(List<LogDTO> selectedLogs)
        {
            return authorized.ToDeleteLogs(selectedLogs, userContext);
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
            get { return UserGridLayoutIdentifier.LogsByAssignment; }
        }
    }
}
