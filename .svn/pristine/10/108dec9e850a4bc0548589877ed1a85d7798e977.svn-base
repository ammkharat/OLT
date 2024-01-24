using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILubesAlarmDisableHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<LubesAlarmDisableFormHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(LubesAlarmDisableFormHistory history);
    }
}