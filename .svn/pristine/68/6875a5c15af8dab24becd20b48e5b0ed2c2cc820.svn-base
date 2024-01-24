using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ContinuousScheduleFixture
    {
        public static ContinuousSchedule CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight()
        {
            return new ContinuousSchedule(new Date(2005, 10, 17), new Date(2005, 10, 27), Time.MIDNIGHT, Time.MIDNIGHT, SiteFixture.Sarnia());
        }

        public static ContinuousSchedule CreateContinuousScheduleFromOctober17AtStartDayToOctober27AtNoon()
        {
            return new ContinuousSchedule(new Date(2005, 10, 17), new Date(2005, 10, 27), Time.START_OF_DAY, new Time(12, 0, 0), SiteFixture.Sarnia());
        }

        public static ContinuousSchedule CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight()
        {
            return new ContinuousSchedule(new Date(2005, 10, 17), Time.MIDNIGHT, SiteFixture.Sarnia());
        }

        public static ContinuousSchedule
            CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnightWithLastInvokedDateTime(
            Nullable<DateTime> nextInvokeDateTime)
        {
            return
                new ContinuousSchedule(new Date(2005, 10, 17), new Date(2005, 10, 27), Time.MIDNIGHT, Time.MIDNIGHT,
                                       nextInvokeDateTime, SiteFixture.Sarnia());
        }
    }
}