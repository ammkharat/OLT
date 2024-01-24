using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RecurringMonthlyScheduleFixture
    {
        public static RecurringMonthlyDayOfMonthSchedule
            CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31()
        {
            return
                new RecurringMonthlyDayOfMonthSchedule(new Date(2005, 1, 1), new Date(2005, 12, 31), new Time(8, 00),
                                                       new Time(12, 00), DayOfMonth.Day(15),
                                                       new List<Month>(
                                                           new[] { Month.January, Month.February }), SiteFixture.Sarnia());
        }

        public static RecurringMonthlyDayOfMonthSchedule
            CreateFrom8AMTo12PMForLastDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31()
        {
            List<Month> monthToInclude = new List<Month> {Month.January, Month.February};
            return
                new RecurringMonthlyDayOfMonthSchedule(new Date(2005, 1, 1), new Date(2005, 12, 31), new Time(8, 00),
                                                       new Time(12, 00), DayOfMonth.Last, monthToInclude, SiteFixture.Sarnia());
        }

        public static RecurringMonthlyDayOfMonthSchedule
            CreateFrom8AMTo12PMForThirdDayOfMarchAndJulyBetweenJanuary1AndDecember31()
        {
            List<Month> monthToInclude = new List<Month> {Month.March, Month.July};
            return
                new RecurringMonthlyDayOfMonthSchedule(new Date(2005, 1, 1), new Date(2005, 12, 31), new Time(8, 00),
                                                       new Time(12, 00), DayOfMonth.Day(3), monthToInclude, SiteFixture.Sarnia());
        }

        public static RecurringMonthlyDayOfWeekSchedule
            CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31()
        {
            return
                new RecurringMonthlyDayOfWeekSchedule(new Date(2005, 1, 1), new Date(2005, 12, 31), new Time(9, 00),
                                                      new Time(16, 00), WeekOfMonth.Second, DayOfWeek.Wednesday,
                                                      new List<Month>(new[] { Month.March, Month.May }), SiteFixture.Sarnia());
        }

        public static RecurringMonthlyDayOfWeekSchedule
            CreateMonthlyScheduleFrom8AMTo5PMForTheLastFridayOfAllMonthsBetweenJanuary1AndDecember31()
        {
            return
                new RecurringMonthlyDayOfWeekSchedule(new Date(2005, 1, 1), new Date(2005, 12, 31), new Time(8, 00),
                                                      new Time(17, 00), WeekOfMonth.Last, DayOfWeek.Friday, Month.All, SiteFixture.Sarnia());
        }

        internal static RecurringHourlySchedule CreateHourlyScheduleEverySixHours()
        {
            return
                new RecurringHourlySchedule(new Date(2005, 01, 01), new Date(2005, 12, 31), new Time(0, 0),
                                            new Time(23, 59), 6, SiteFixture.Sarnia());
        }

        public static ISchedule
            CreateMonthlyScheduleFrom8AMTo5PMForTheFirstSundayOfAllMonthsBetweenJanuary1AndDecember31()
        {
            return
                new RecurringMonthlyDayOfWeekSchedule(new Date(2006, 1, 1), new Date(2006, 12, 31), new Time(8, 00),
                                                      new Time(17, 00), WeekOfMonth.First, DayOfWeek.Sunday, Month.All, SiteFixture.Sarnia());
        }

        public static ISchedule CreateMonthlyScheduleFrom8AMTo5PMForTheSecondDayOfAllMonthsBetweenJanuary1AndDecember31()
        {
            return
                new RecurringMonthlyDayOfMonthSchedule(new Date(2006, 1, 1), new Date(2006, 12, 31), new Time(8, 00),
                                                       new Time(17, 00), DayOfMonth.Day(2), Month.All, SiteFixture.Sarnia());
        }

        public static ISchedule CreateMonthlyScheduleBetweenAugustAndDecemberOnThe29ThDayOfTheMonthFrom8AMTo12PM()
        {
            return
                new RecurringMonthlyDayOfMonthSchedule(new Date(2006, 8, 1), new Date(2006, 12, 31), new Time(8, 00),
                                                       new Time(12, 00), DayOfMonth.Day(29), Month.All, SiteFixture.Sarnia());
        }
    }
}