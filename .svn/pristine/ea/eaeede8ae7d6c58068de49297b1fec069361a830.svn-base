using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands
{
    public abstract class AbstractScheduledJob : IScheduledJob
    {
        protected AbstractScheduledJob(ISchedule scheduleForJob)
        {
            Schedule = scheduleForJob;
        }

        public abstract void Execute();
        public abstract string Name { get; }
        public ISchedule Schedule { get; set; }
    }
}