using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IRestrictionDefinitionHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<RestrictionDefinitionHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(RestrictionDefinitionHistory history);
    }
}