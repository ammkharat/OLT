using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IExcursionResponseHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<ExcursionResponseHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(ExcursionResponseHistory history);
    }
}