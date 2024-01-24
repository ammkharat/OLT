using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    /// <summary>
    /// Helps create user shifts properly, using a time that will fit into the corresponding
    /// shift pattern.
    /// </summary>
    public class UserShiftFixture
    {
        public static UserShift CreateUserShift()
        {
            return CreateUserShift(ShiftPatternFixture.CreateDayShift());
        }

        public static UserShift CreateUserShift(Time startTime, Time endTime)
        {
            return CreateUserShift(startTime, endTime, new Date(DateTimeFixture.DateTimeNow));
        }

        public static UserShift CreateUserShift(Time startTime, Time endTime, DateTime now)
        {
            return CreateUserShift(startTime, endTime, new Date(now));
        }

        public static UserShift CreateUserShift(Time startTime, Time endTime, Date startDate)
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(startTime, endTime);
            return new UserShift(shiftPattern, startDate.CreateDateTime(startTime));
        }

        public static UserShift CreateUserShift(Time startTime, Time endTime, Date startDate, TimeSpan endOfShiftPadding)
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(startTime, endTime, endOfShiftPadding);
            return new UserShift(shiftPattern, startDate.CreateDateTime(startTime));
        }

        /// <summary>
        /// Returns a new user shift that will fit with the given shift pattern time-wise.
        /// </summary>
        public static UserShift CreateUserShift(ShiftPattern shiftPattern)
        {
            return CreateUserShift(shiftPattern, shiftPattern.StartTime.ToDateTime(new Date(DateTimeFixture.DateTimeNow)));
        }

        public static UserShift CreateUserShift(ShiftPattern shiftPattern, DateTime now)
        {
            return new UserShift(shiftPattern, new Date(now).CreateDateTime(shiftPattern.StartTime));
        }
    }
}