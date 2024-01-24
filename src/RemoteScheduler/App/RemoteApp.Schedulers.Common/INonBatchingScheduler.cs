using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public interface INonBatchingScheduler : IScheduler
    {
        List<TimeZoneConvertedSchedule> Schedules { get; }
        IScheduleHandler ScheduleHandler { set; }

        void RemoveMatchingSchedules(Predicate<TimeZoneConvertedSchedule> predicate);

        void DumpScheduleListToLog();

        OltTimeZoneInfo GetSchedulerTimeZone();
    }
}