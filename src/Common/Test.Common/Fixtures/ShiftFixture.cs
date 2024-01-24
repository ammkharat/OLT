using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ShiftPatternFixture
    {

        private static readonly TimeSpan typicalPadding = new TimeSpan(0, 30, 0);
        private static readonly TimeSpan noPadding = new TimeSpan(0, 0, 0);

        public const long SARNIA_12DA_ID = 1;
        public const long SARNIA_12e_ID = 2;
        public const long SARNIA_8d_ID = 25;
        public const long SARNIA_8e_ID = 26;
        public const long SARNIA_8n_ID = 27;
        public const long SARNIA_8am_ID = 28;
        public const long SARNIA_9am_ID = 29;

        public const long OILSANDS_DAY_ID = 15;
        public const long OILSANDS_NIGHT_ID = 16;

        public const long EDMONTON_DAY_ID = 19;
        public const long EDMONTON_NIGHT_ID = 20;

        public const long FORT_HILLS_24H_ID = 58;

        private static readonly Time dayShiftStart = new Time(6, 0, 0);
        private static readonly Time dayShiftEnd = new Time(18, 0, 0);

        private static readonly Time nightShiftStart = new Time(18, 0, 0);
        private static readonly Time nightShiftEnd = new Time(6, 0, 0);

        private static readonly Time day6amShiftStart = new Time(6, 0, 0);
        private static readonly Time day6amShiftEnd = new Time(14, 0, 0);

        private static readonly Time day630ShiftStart = new Time(6, 30, 0);
        private static readonly Time day630ShiftEnd = new Time(18, 30, 0);

        public static readonly DateTime DayShiftLoggedDate = new DateTime(2005, 11, 15, 15, 0, 0);
        public static readonly DateTime NightShiftLoggedDate = new DateTime(2005, 11, 15, 22, 0, 0);

        public static ShiftPattern CreateFortHills24HourShift()
        {
            return new ShiftPattern(FORT_HILLS_24H_ID, "24H", Time.START_OF_DAY, Time.END_OF_DAY,
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), noPadding, noPadding);
        }

        public static ShiftPattern CreateDayShift()
        {
            return CreateDayShift(Clock.Now.GetNetworkPortable());
        }

        public static ShiftPattern CreateDayShift(DateTime now)
        {
            var dayShift = new ShiftPattern(SARNIA_12DA_ID, "12DA", dayShiftStart, dayShiftEnd, now, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern CreateOilsandsNightShift8pmTo8am()
        {
            var dayShift = new ShiftPattern(OILSANDS_NIGHT_ID, "12N", new Time(20), new Time(8), 
                DateTimeFixture.DateTimeNow, SiteFixture.Oilsands(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern CreateOilsandsDayShift()
        {
            var dayShift = new ShiftPattern(OILSANDS_DAY_ID, "12DA", dayShiftStart, dayShiftEnd,
                DateTimeFixture.DateTimeNow, SiteFixture.Oilsands(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern CreateEdmontonDayShift()
        {
            ShiftPattern dayShift = new ShiftPattern(EDMONTON_DAY_ID, "D", day630ShiftStart, day630ShiftEnd,
                DateTimeFixture.DateTimeNow, SiteFixture.Edmonton(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern CreateEdmontonNightShift()
        {
            ShiftPattern shift = new ShiftPattern(EDMONTON_NIGHT_ID, "N", day630ShiftEnd, day630ShiftStart,
                DateTimeFixture.DateTimeNow, SiteFixture.Edmonton(), typicalPadding, typicalPadding);
            return shift;
        }

        public static ShiftPattern Create6am_8hour_DayShift()
        {
            var dayShift = new ShiftPattern(SARNIA_8d_ID, "8d", day6amShiftStart, day6amShiftEnd, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern Create6pmNightShift()
        {
            var dayShift = new ShiftPattern(SARNIA_9am_ID, "8d", day6amShiftEnd, day6amShiftStart, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static DateTime CreateDateTimeDuringDayShift()
        {
            return CreateDateTimeDuringDayShift(Clock.Now.GetNetworkPortable());
        }

        public static DateTime CreateDateTimeDuringDayShift(DateTime now)
        {
            return now.ToDate().CreateDateTime(dayShiftStart);
        }

        public static UserShift CreateUserShiftDuringDayShift()
        {
            return CreateUserShiftDuringDayShift(DateTimeFixture.DateTimeNow);
        }
        
        public static UserShift CreateUserShiftDuringDayShift(DateTime now)
        {
            return new UserShift(CreateDayShift(now), CreateDateTimeDuringDayShift(now));
        }

        public static UserShift CreateUserShiftDuringNightShift()
        {
            return new UserShift(CreateNightShift(), CreateDateTimeDuringNightShift());
        }

        public static DateTime CreateDateTimeDuringNightShift()
        {
            return Clock.Now.GetNetworkPortable().ToDate().CreateDateTime(nightShiftStart);
        }

        public static ShiftPattern CreateNightShift()
        {
            var nightShift = new ShiftPattern(SARNIA_12e_ID, "12e", nightShiftStart, nightShiftEnd, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return nightShift;
        }

        public static ShiftPattern CreateNotOnShift()
        {
            return null;
        }

        public static ShiftPattern Create8HourNightShift()
        {
            var nightShift = new ShiftPattern(SARNIA_8n_ID, "8n", new Time(22, 0, 0), new Time(6, 0, 0), DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return nightShift;
        }

        public static ShiftPattern Create8HourDayShift()
        {
            var dayShift = new ShiftPattern(SARNIA_8am_ID, "8d", new Time(6, 0, 0), new Time(14, 0, 0), DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return dayShift;
        }

        public static ShiftPattern Create8HourAfterNoonShift()
        {
            var afternoonShift =
                new ShiftPattern(SARNIA_8e_ID, "8e", new Time(14, 0, 0), new Time(22, 0, 0), DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
            return afternoonShift;
        }

        public static List<ShiftPattern> CreateTwentyFourHourShiftListWith8HourShifts()
        {
            var shifts = new List<ShiftPattern>
                             {
                                 Create8HourDayShift(),
                                 Create8HourAfterNoonShift(),
                                 Create8HourNightShift()
                             };
            return shifts;
        }

        public static List<ShiftPattern> CreateTwentyFourHourShiftListWith12HourShifts()
        {
            var shifts = new List<ShiftPattern> {CreateDayShift(), CreateNightShift()};
            return shifts;
        }

        public static ShiftPattern CreateShiftPattern(string name, Time startTime, Time endTime, DateTime createdDateTime, Site site)
        {
            return new ShiftPattern(1, name, startTime, endTime, createdDateTime, site, typicalPadding, typicalPadding);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime, DateTime createdDateTime, Site site)
        {
            return new ShiftPattern(SARNIA_12DA_ID, "12DA", startTime, endTime, createdDateTime, site, typicalPadding, typicalPadding);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime, DateTime createdDateTime)
        {
            return CreateShiftPattern(startTime, endTime, createdDateTime, typicalPadding);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime, DateTime createdDateTime, TimeSpan endOfShiftPadding)
        {
            return new ShiftPattern(SARNIA_12DA_ID, "12DA", startTime, endTime, createdDateTime, SiteFixture.Sarnia(), typicalPadding, endOfShiftPadding);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime)
        {
            return CreateShiftPattern(startTime, endTime, DateTimeFixture.DateTimeNow);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime, TimeSpan endOfShiftPadding)
        {
            return CreateShiftPattern(startTime, endTime, DateTimeFixture.DateTimeNow, endOfShiftPadding);
        }

        public static ShiftPattern CreateShiftPattern(Time startTime, Time endTime, long shiftPatternId)
        {
            return new ShiftPattern(shiftPatternId, "sft", startTime, endTime, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), typicalPadding, typicalPadding);
        }

        public static ShiftPattern CreateNewShiftPattern()
        {
            return CreateShiftPattern(new Time(0), new Time(12));
        }
    }
}
