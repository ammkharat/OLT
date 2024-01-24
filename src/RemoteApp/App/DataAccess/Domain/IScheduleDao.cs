using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [CachePrefix("Schedule")]
    public interface IScheduleDao : IDao
    {
        [CachedQueryById]
        ISchedule QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Insert(ISchedule schedule);
        [CachedInsertOrUpdate(false, false)]
        void Update(ISchedule schedule);
        [CachedRemove(false, false)]
        void Delete(ISchedule schedule);
    }
}