using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RecurringHourlyScheduleFixture
    {
        public static RecurringHourlySchedule CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006()
        {
            Time fromTime = new Time(12, 00);
            Time toTime = new Time(12, 00);
            Date startDate = new Date(2006, 1, 1);
            Date endDate = new Date(2006, 12, 31);
            int frequency = 3;
            RecurringHourlySchedule recurringHourlySchedule =
                new RecurringHourlySchedule(11, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());

            return recurringHourlySchedule;
        }

        public static RecurringHourlySchedule CreateEvery6HoursFrom2AMTo3PMBetweenJan12000AndJan22000()
        {
            Time fromTime = new Time(2, 0);
            Time toTime = new Time(15, 0);
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 1, 2);
            int frequency = 6;
            RecurringHourlySchedule recurringHourlySchedule =
                new RecurringHourlySchedule(12, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringHourlySchedule;
        }

        public static RecurringHourlySchedule CreateEvery12HoursFrom4PMTo4PMBetweenJan12000AndJan22000()
        {
            Time fromTime = new Time(16, 0);
            Time toTime = new Time(16, 0);
            Date startDate = new Date(2000, 1, 1);
            Date endDate = new Date(2000, 1, 2);
            int frequency = 12;
            RecurringHourlySchedule recurringHourlySchedule =
                new RecurringHourlySchedule(13, startDate, endDate, fromTime, toTime, frequency, null, SiteFixture.Sarnia());
            return recurringHourlySchedule;
        }

        public static ISchedule CreateRecurringHourlyScheduleBetweenApr1AndApr2From11pmTo4am()
        {
            return
                new RecurringHourlySchedule(new Date(2006, 04, 01), new Date(2006, 04, 02), new Time(23, 00),
                                            new Time(4, 00), 1, SiteFixture.Sarnia());
        }
    }
}