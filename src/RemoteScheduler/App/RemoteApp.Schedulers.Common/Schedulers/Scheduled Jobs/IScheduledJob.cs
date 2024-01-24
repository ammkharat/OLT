using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands
{
    public interface IScheduledJob
    {
        ISchedule Schedule { get; set; }
        string Name { get; }
        void Execute();
    }
}