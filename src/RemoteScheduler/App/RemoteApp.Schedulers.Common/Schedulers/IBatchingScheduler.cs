namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public interface IBatchingScheduler : IScheduler
    {
        IBatchHandler BatchHandler { set; }
    }
}