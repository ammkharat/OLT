using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogDefinitionDao : IDao
    {
        List<LogDefinition> QueryAllForScheduling();
        [CachedInsertOrUpdate(false, false)]
        LogDefinition Insert(LogDefinition logDefinition);
        [CachedQueryById]
        LogDefinition QueryById(long id);
        [CachedRemove(false, false)]
        void Remove(LogDefinition logDefinition);
        [CachedInsertOrUpdate(false, false)]
        void Update(LogDefinition logDefinition);

        LogDefinition QueryByScheduleId(long scheduleId);
    }
}