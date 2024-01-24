using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Security
{
    public class SummaryLogAuthorization : AbstractLogAuthorization<SummaryLogDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_SUMMARY_LOG; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_SUMMARY_LOG; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_SUMMARY_LOG; }
        }

        protected override RoleElement DeleteRoleElement
        {
            get { return RoleElement.DELETE_SUMMARY_LOG; }
        }

        public override bool ToDelete(SummaryLogDTO dto, UserContext userContext)
        {
            return base.ToDelete(dto, userContext) && !dto.HasChildren;
        }

        public static bool ToEditDORComments(UserRoleElements userRoleElements, UserShift userShift, SummaryLogDTO log, Time dorEditCutoffHour)
        {
            if (userRoleElements == null || log == null || userShift == null)
            {
                return false;
            }

            bool hasRoleElement = userRoleElements.HasRoleElement(RoleElement.EDIT_DOR_COMMENTS);
            bool logCreatedOnSameShift = IsCreatedOnSameShift(log, userShift);
            bool logCreatedWithin24HoursOfShiftStartIncludingPreShiftPaddingAndItIsCurrentlyBeforeTheNextDorCutoff =
                LogCreatedWithin24HoursOfShiftStartIncludingPreShiftPaddingAndItIsCurrentlyBeforeTheNextDorCutoff(
                        log, userShift, dorEditCutoffHour);

            return hasRoleElement &&
                   (logCreatedOnSameShift || logCreatedWithin24HoursOfShiftStartIncludingPreShiftPaddingAndItIsCurrentlyBeforeTheNextDorCutoff);
        }

        private static bool LogCreatedWithin24HoursOfShiftStartIncludingPreShiftPaddingAndItIsCurrentlyBeforeTheNextDorCutoff(
            SummaryLogDTO log, UserShift userShift, Time dorEditCutoffHour)
        {
            DateTime from = userShift.StartDateTimeWithPadding.SubtractDays(1);
            DateTime to = userShift.StartDateTime.Add(userShift.ShiftPattern.PostShiftPadding);

            return (from <= log.CreatedDateTime && log.CreatedDateTime < to) &&
                IsCurrentlyBeforeTheNextShiftCutoffTime(userShift, dorEditCutoffHour);
        }

        public static bool IsTimeInExactShift(ShiftPattern shiftPattern, Time time)
        {
            Time start = shiftPattern.StartTime;
            Time end = shiftPattern.EndTime;

            return time.InRange(start, end);
        }

        private static bool IsCurrentlyBeforeTheNextShiftCutoffTime(UserShift userShift, Time dorEditCutoffHour)
        {
            DateTime now = Clock.Now;
            DateTime cutoffDateTimeForToday = dorEditCutoffHour.ToDateTime(new Date(now.TruncateToDay()));

            DateTime nextDorCutoffDateTime;

            if (IsTimeInExactShift(userShift.ShiftPattern, dorEditCutoffHour))
            {
                nextDorCutoffDateTime = cutoffDateTimeForToday;
            }
            else
            {
                nextDorCutoffDateTime = now < cutoffDateTimeForToday ? cutoffDateTimeForToday : cutoffDateTimeForToday.AddDays(1);
            }

            return now < nextDorCutoffDateTime;
        }
    }
}
