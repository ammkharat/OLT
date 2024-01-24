using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RecurringMinuteScheduleFixture
    {
        public static RecurringMinuteSchedule CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002()
        {
            Time fromTime = new Time(5, 15);
            Time toTime = new Time(20, 05);
            Date startDate = new Date(2002, 2, 12);
            Date endDate = new Date(2002, 12, 21);
            int frequency = 10;
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(100, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringMinuteSchedule;
        }

        public static RecurringMinuteSchedule CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward(Site site)
        {
            Time fromTime = new Time(5, 15);
            Time toTime = new Time(20, 05);
            Date startDate = new Date(2002, 2, 12);
            int frequency = 10;
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(101, startDate, null, fromTime, toTime, frequency, null, site);
            return recurringMinuteSchedule;
        }

        public static RecurringMinuteSchedule CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward()
        {
            Time fromTime = new Time(5, 15);
            Time toTime = new Time(20, 05);
            Date startDate = new Date(2002, 2, 12);
            int frequency = 10;
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(101, startDate, null, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringMinuteSchedule;
        }


        public static RecurringMinuteSchedule CreateEvery2MinutesFrom1AM15To1AM25OnJan12000()
        {
            Time fromTime = new Time(1, 15);
            Time toTime = new Time(1, 25);
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 1, 1);
            int frequency = 2;
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(102, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringMinuteSchedule;
        }

        public static RecurringMinuteSchedule CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000()
        {
            Time fromTime = new Time(1, 15);
            Time toTime = new Time(1, 25);
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 1, 3);
            int frequency = 2;
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(103, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringMinuteSchedule;
        }

        public static RecurringMinuteSchedule CreateEvery30MinutesFrom1AM15To3AM00OnJan12000()
        {
            RecurringMinuteSchedule recurringMinuteSchedule =
                new RecurringMinuteSchedule(104, new Date(2000, 1, 1), new Date(2000, 1, 1), new Time(1, 15), new Time(3, 0), 30, null, SiteFixture.Sarnia());
            return recurringMinuteSchedule;
        }
    }
}