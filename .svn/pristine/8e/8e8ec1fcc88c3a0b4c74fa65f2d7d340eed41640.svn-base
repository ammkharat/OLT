using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class UserShift : ComparableObject
    {
        private readonly DateTime endDateTime;
        private readonly ShiftPattern shiftPattern;
        private readonly DateTime startDateTime;

        public UserShift(ShiftPattern shiftPattern, Date startDate)
            : this(shiftPattern, startDate.CreateDateTime(shiftPattern.StartTime))
        {
        }

        public UserShift(ShiftPattern shiftPattern, DateTime dateTime)
        {
            this.shiftPattern = shiftPattern;

            ValidateDateTimeFallsInShift(dateTime);

            startDateTime = ConstructStartDateTime(dateTime);

            var shiftLength = this.shiftPattern.ShiftLength;

            // NOTE: Eric: The following statement only works properly across daylight-saving change
            //       boundaries because DateTime.Add(TimeSpan) is daylight-saving boundary agnostic.
            //       Otherwise, Oct 28, 2006 18:00 + 12 hours would become Oct 29, 2006 05:00,
            //       which is not what we want.
            endDateTime = startDateTime.Add(shiftLength);
        }

        public ShiftPattern ShiftPattern
        {
            get { return shiftPattern; }
        }

        public long ShiftPatternId
        {
            get { return shiftPattern.IdValue; }
        }

        public string ShiftPatternName
        {
            get { return shiftPattern.Name; }
        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }
        }

        public Date StartDate
        {
            get { return new Date(startDateTime); }
        }

        public DateTime EndDateTime
        {
            get { return endDateTime; }
        }

        public Date EndDate
        {
            get { return new Date(endDateTime); }
        }

        public DateTime StartDateTimeWithPadding
        {
            get { return startDateTime.Subtract(shiftPattern.PreShiftPadding); }
        }

        public DateTime EndDateTimeWithPadding
        {
            get { return endDateTime.Add(shiftPattern.PostShiftPadding); }
        }

        public Range<DateTime> DateTimeRangeWithPadding
        {
            get { return new Range<DateTime>(StartDateTimeWithPadding, EndDateTimeWithPadding); }
        }

        public Range<DateTime> DateTimeRangeWithoutPadding
        {
            get { return new Range<DateTime>(StartDateTime, EndDateTime); }
        }

        public string ShiftDisplayName
        {
            get { return CreateShiftDisplayName(startDateTime, shiftPattern.Name); }
        }

        public bool IsInUserShiftIncludingPadding(long shiftId, DateTime dateTime)
        {
            return shiftId == ShiftPatternId && StartDateTimeWithPadding < dateTime && dateTime < EndDateTimeWithPadding;
        }
        /*amit shukla Flexi Shift Handover RITM0185797 */
        public bool IsInUserFlexiShiftIncludingPadding(long shiftId, DateTime flexishiftstartdate, DateTime flexishiftenddate)
        {
            return  Clock.Now >= flexishiftstartdate.Date.Add(StartDateTimeWithPadding.TimeOfDay) && Clock.Now <= flexishiftenddate.Date.Add(EndDateTimeWithPadding.TimeOfDay);
        }

        private void ValidateDateTimeFallsInShift(DateTime dateTime)
        {
            if (!shiftPattern.IsDateTimeInShiftIncludingPadding(dateTime))
            {
                var site = shiftPattern.Site != null ? shiftPattern.Site.Name : null;
                var shiftName = shiftPattern.DisplayName;
                throw new ShiftOutOfBoundsException(
                    string.Format("DateTime {0} Time portion does not fall within {1} and {2}. Site: {3}. Shift: {4}",
                        dateTime, shiftPattern.StartTime,
                        shiftPattern.EndTime, site, shiftName));
            }
        }

        private DateTime ConstructStartDateTime(DateTime dateTime)
        {
            var startTime = shiftPattern.StartTime;
            var startTimeWithPadding = startTime.Subtract(shiftPattern.PreShiftPadding);

            DateTime result;
            if (shiftPattern.IsOverlappingADay)
            {
                // date is in the first day.
                if (new Time(dateTime).InRange(startTimeWithPadding, Time.END_OF_DAY))
                {
                    var currentDate = dateTime.ToDate();
                    result = currentDate.CreateDateTime(startTime);
                }
                else
                {
                    // date is in the second day, but the shift started on the first day.
                    var previousDay = dateTime.SubtractDays(1).ToDate();
                    result = previousDay.CreateDateTime(startTime);
                }
            }
            else
            {
                // the shift is non-overlapping, but the shift starts close to midnight, and because of the padding can actually log in on a previous day just before midnight.
                // This shouldn't really happen in reality, except if there is some crazy shift in Firebag or in test data.
                if (startTime < startTimeWithPadding &&
                    new Time(dateTime).InRange(startTimeWithPadding, Time.END_OF_DAY))
                {
                    var tomorrow = dateTime.ToDate().AddDays(1);
                    result = tomorrow.CreateDateTime(startTime);
                }
                else
                {
                    var currentDate = dateTime.ToDate();
                    result = currentDate.CreateDateTime(startTime);
                }
            }

            return result;
        }

        public UserShift RollToStartDate(Date startDate)
        {
            return new UserShift(shiftPattern, startDate);
        }

        public static UserShift GetLatestCompletedUserShift(List<ShiftPattern> shiftPatterns, DateTime now)
        {
            var today = new Date(now);
            var yesterday = new Date(now.SubtractDays(1));
            var dayBeforeYesterday = new Date(now.SubtractDays(2));

            var userShifts = new List<UserShift>();

            foreach (var pattern in shiftPatterns)
            {
                userShifts.Add(new UserShift(pattern, today));
                userShifts.Add(new UserShift(pattern, yesterday));
                userShifts.Add(new UserShift(pattern, dayBeforeYesterday));
            }

            var userShiftsEndingBeforeNow = userShifts.FindAll(userShift => userShift.EndDateTime < now);
            userShiftsEndingBeforeNow.Sort(
                (userShiftX, userShiftY) => userShiftX.EndDateTime.CompareTo(userShiftY.EndDateTime));

            return userShiftsEndingBeforeNow[userShiftsEndingBeforeNow.Count - 1];
        }

        // In OLT there is no concept of a 'next shift'; this is an algorithm that just picks the one that starts soonest.
        // If two start at the same time it picks the longest. 
        public UserShift ChooseNextShift(List<ShiftPattern> potentialNextShifts)
        {
            potentialNextShifts.Sort(CompareShiftPatternsByStartTimeAndLength);
            var currentShiftEndTime = new Time(endDateTime);

            foreach (var potentialNextShift in potentialNextShifts)
            {
                if (potentialNextShift.StartTime >= currentShiftEndTime)
                {
                    return new UserShift(potentialNextShift, new Date(endDateTime));
                }
            }

            throw new ApplicationException(
                "Attempted to find a shift beginning after the current shift but was not able to.");
        }

        private static int CompareShiftPatternsByStartTimeAndLength(ShiftPattern a, ShiftPattern b)
        {
            if (a.StartTime == b.StartTime)
            {
                return b.ShiftLength.CompareTo(a.ShiftLength);
            }

            return a.StartTime.CompareTo(b.StartTime);
        }

        public UserShift ChoosePreviousShift(List<ShiftPattern> allShifts)
        {
            var userShiftsForYesterdayAndTodayExcludingThisUserShift = new List<UserShift>();
            foreach (var shift in allShifts)
            {
                if (shift.IdValue == shiftPattern.IdValue)
                {
                    userShiftsForYesterdayAndTodayExcludingThisUserShift.Add(new UserShift(shift, StartDate.AddDays(-1)));
                }
                else
                {
                    userShiftsForYesterdayAndTodayExcludingThisUserShift.Add(new UserShift(shift, StartDate));
                    userShiftsForYesterdayAndTodayExcludingThisUserShift.Add(new UserShift(shift, StartDate.AddDays(-1)));
                }
            }

            userShiftsForYesterdayAndTodayExcludingThisUserShift.Sort(CompareByStartDateTimeAndLengthWithLengthAscending);
            userShiftsForYesterdayAndTodayExcludingThisUserShift.Reverse();

            foreach (var userShift in userShiftsForYesterdayAndTodayExcludingThisUserShift)
            {
                if (userShift.startDateTime < startDateTime)
                {
                    return userShift;
                }
            }

            throw new ApplicationException(
                "Attempted to find a shift beginning before the current shift but was not able to.");
        }

        private static int CompareByStartDateTimeAndLengthWithLengthAscending(UserShift a, UserShift b)
        {
            if (a.StartDateTime == b.StartDateTime)
            {
                return a.shiftPattern.ShiftLength.CompareTo(b.shiftPattern.ShiftLength);
            }

            return a.StartDateTime.CompareTo(b.StartDateTime);
        }

        public static string CreateShiftDisplayName(DateTime startDateTime, string shiftName)
        {
            return String.Format("{0} - {1}", new Date(startDateTime), shiftName);
        }

        public bool IsSameShift(long shiftId, Date shiftStartDate)
        {
            return shiftId == ShiftPatternId && shiftStartDate == StartDate;
        }
    }
}