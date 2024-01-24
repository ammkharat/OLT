using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RecurringWeeklyScheduleFixture
    {
        public static RecurringWeeklySchedule CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 1;
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 10, 10);
            Time fromTime = new Time(8, 0);
            Time toTime = new Time(14, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }
        public static RecurringWeeklySchedule CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2050()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 1;
            Date startDate = new Date(2050, 1, 1);
            Date endDate = new Date(2050, 10, 10);
            Time fromTime = new Time(8, 0);
            Time toTime = new Time(14, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }

        public static RecurringWeeklySchedule CreateEveryOtherMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 2;
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 10, 10);
            Time fromTime = new Time(8, 0);
            Time toTime = new Time(14, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }


        public static RecurringWeeklySchedule CreateEveryOtherMondayAndFridayFrom10PMTO11PMBetweenJan1AndOct10In2000()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 2;
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 10, 10);
            Time fromTime = new Time(22, 0);
            Time toTime = new Time(23, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }

        public static RecurringWeeklySchedule CreateEveryOtherMondayAndFridayFrom2AMTO3amBetweenJan1AndOct10In2000()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 2;
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 10, 10);
            Time fromTime = new Time(2, 0);
            Time toTime = new Time(3, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }

        public static RecurringWeeklySchedule CreateEveryOtherMondayAndFridayFrom10pmTO2amBetweenJan1AndOct10In2000()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 2;
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 10, 10);
            Time fromTime = new Time(22, 0);
            Time toTime = new Time(2, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }

        public static ISchedule CreateEveryOtherMondayAndFridayFrom8AMTO2PMBetweenMar1AndOct10In2006()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Friday};
            int frequency = 2;
            Date startDate = new Date(2006, 3, 1);
            Date endDate = new Date(2006, 10, 10);
            Time fromTime = new Time(8, 0);
            Time toTime = new Time(14, 0);
            RecurringWeeklySchedule recurringWeeklySchedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, toTime, daysofWeek, frequency, SiteFixture.Sarnia());
            return recurringWeeklySchedule;
        }

        public static ISchedule CreateEverySundayFrom8AMTO2PMBetweenMar15AndDec31In2006()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Sunday};
            return
                new RecurringWeeklySchedule(new Date(2006, 3, 15), new Date(2006, 12, 31), new Time(8, 00),
                                            new Time(14, 00), daysofWeek, 1, SiteFixture.Sarnia());
        }

        public static ISchedule CreateEverySundayFrom8AMTO2PMBetweenOct8AndNov30In2006()
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> {DayOfWeek.Sunday};
            return
                new RecurringWeeklySchedule(new Date(2006, 10, 8), new Date(2006, 11, 30), new Time(8, 00),
                                            new Time(14, 00), daysofWeek, 1, SiteFixture.Sarnia());
        }

        public static ISchedule CreateEverySundayFrom8AMTO2PMBetweenMar15AndDec31In2006(DateTime lastInvokedDateTime)
        {
            List<DayOfWeek> daysofWeek = new List<DayOfWeek> { DayOfWeek.Sunday };
            return
                new RecurringWeeklySchedule(-1, new Date(2006, 3, 15), new Date(2006, 12, 31), new Time(8, 00),
                                            new Time(14, 00), daysofWeek, 1, lastInvokedDateTime, SiteFixture.Sarnia());
        }

    }
}