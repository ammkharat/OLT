using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogDefinitionHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<LogDefinitionHistory> QueryByLogDefinitionId(long logDefinitionId);

        [CachedInsertHistory]
        void Insert(LogDefinitionHistory history);
    }
}