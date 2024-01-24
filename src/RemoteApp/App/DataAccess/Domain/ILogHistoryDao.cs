using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<LogHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(LogHistory logHistory);
    }
}