using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetDefinitionHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<TargetDefinitionHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(TargetDefinitionHistory targetDefinitionHistory);
    }
}