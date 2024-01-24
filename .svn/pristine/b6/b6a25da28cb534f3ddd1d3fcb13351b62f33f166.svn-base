using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class SingleScheduleFixture
    {
        public static SingleSchedule CreateSingleScheduleOnOctober17From8AMTo12PM()
        {
            return new SingleSchedule(1, new Date(2005, 10, 17), new Time(8, 0), new Time(12, 0), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule CreateSingleScheduleOnNov11From8AMTo12PM()
        {
            return new SingleSchedule(1, new Date(2005, 11, 11), new Time(8, 0), new Time(12, 0), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule Create2000Jan1AM1MinTo2Min()
        {
            return new SingleSchedule(1, new Date(2000, 1, 1), new Time(1, 1), new Time(1, 2), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule Create2000Jan1AM1MinTo5Min()
        {
            return new SingleSchedule(4, new Date(2000, 1, 1), new Time(1, 1), new Time(1, 5), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule Create2000Jan1AM15MinTo30Min()
        {
            return new SingleSchedule(2, new Date(2000, 1, 1), new Time(1, 15), new Time(1, 30), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule Create2000Jan1AM7MinTo30Min()
        {
            return new SingleSchedule(3, new Date(2000, 1, 1), new Time(1, 7), new Time(1, 30), null, SiteFixture.Sarnia());
        }

        public static SingleSchedule Create2000Jan2AM15MinTo30Min()
        {
            return new SingleSchedule(5, new Date(2000, 1, 1), new Time(2, 15), new Time(2, 30), null, SiteFixture.Sarnia());
        }


        public static ISchedule CreateFarFarAwaySingleSchedule()
        {
            return new SingleSchedule(6, new Date(2200, 1, 1), new Time(2, 15), new Time(2, 30), null, SiteFixture.Sarnia());
        }
    }
}