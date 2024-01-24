using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public interface ISchedulingService
    {
        string ScheduleName { get; }
        void LoadScheduler();
        void StopService();
    }

    public interface IScheduleHandler
    {
        void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime);
    }

    public interface IBatchHandler
    {
        void OnBatchTrigger(string batchingKey, List<ISchedule> schedules);
    }
}