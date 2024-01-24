using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RecurringDailyScheduleFixture
    {
        public static RecurringDailySchedule CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15()
        {
            Time fromTime = new Time(17, 0);
            Time toTime = new Time(18, 0);
            Date startDate = new Date(2006, 6, 15);

            int frequency = 1;
            RecurringDailySchedule recurringDailySchedule =
                new RecurringDailySchedule(201, startDate, null, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringDailySchedule;
        }

        public static RecurringDailySchedule CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(Site site)
        {
            Time fromTime = new Time(10, 12);
            Time toTime = new Time(19, 11);
            Date startDate = new Date(2000, 1, 10);
            Date endDate = new Date(2000, 10, 21);
            int frequency = 2;
            RecurringDailySchedule recurringDailySchedule =
                new RecurringDailySchedule(201, startDate, endDate, fromTime, toTime, frequency, null, site);
            return recurringDailySchedule;

        }

        public static RecurringDailySchedule CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000()
        {
            return CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(SiteFixture.Sarnia());
        }

        public static RecurringDailySchedule CreateEvery2DaysFrom10AM12To07PM11FromJan10Onward()
        {
            Time fromTime = new Time(10, 12);
            Time toTime = new Time(19, 11);
            Date startDate = new Date(2000, 1, 10);
            int frequency = 2;
            RecurringDailySchedule recurringDailySchedule =
                new RecurringDailySchedule(202, startDate, null, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringDailySchedule;
        }


        public static RecurringDailySchedule CreateEvery2DaysFrom2AMTo10AM11BetweenJan1AndJan5In2000()
        {
            Time fromTime = new Time(2, 0);
            Time toTime = new Time(10, 0);
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 1, 5);
            int frequency = 2;
            RecurringDailySchedule recurringDailySchedule =
                new RecurringDailySchedule(203, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringDailySchedule;
        }

        public static RecurringDailySchedule CreateRecurringDailyScheduleBetweenMar30AndMay1From8amTo12pm()
        {
            return
                new RecurringDailySchedule(204, new Date(2006, 03, 30), new Date(2006, 05, 01), new Time(8, 00),
                                           new Time(12, 00), 1, null, SiteFixture.Sarnia());
        }

        public static RecurringDailySchedule CreateRecurringDailyScheduleBetweenMar30AndMay1From1pmTo1am()
        {
            return
                new RecurringDailySchedule(204, new Date(2006, 03, 30), new Date(2006, 05, 01), new Time(13, 00),
                                           new Time(01, 00), 1, null, SiteFixture.Sarnia());
        }

        public static RecurringDailySchedule CreateRecurringDailySchedule(Date startDate, Date endDate, Time startTime,
                                                                          Time endTime)
        {
            return CreateRecurringDailySchedule(startDate, endDate, startTime, endTime, 1, null);
        }

        public static RecurringDailySchedule CreateRecurringDailySchedule(Date startDate, Date endDate, Time startTime,
                                                                          Time endTime, int frequency, DateTime? lastInvokedDateTime)
        {
            return new RecurringDailySchedule(205, startDate, endDate, startTime, endTime, frequency, lastInvokedDateTime, SiteFixture.Sarnia());
        }

        public static RecurringDailySchedule CreateRecurringDailyScheduleFromJan1200610Hour1Min55SecAMTo4PM()
        {
            Date startDate = new Date(2006, 01, 01);
            Date endDate = new Date(2006, 01, 01);
            Time startTime = new Time(10, 1, 55);
            Time endTime = new Time(16, 0, 00);
            return new RecurringDailySchedule(205, startDate, endDate, startTime, endTime, 1, null, SiteFixture.Sarnia());
        }
    }
}