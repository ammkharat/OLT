using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDirectiveHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<DirectiveHistory> GetById(long id);
        
        [CachedInsertHistory]
        void Insert(DirectiveHistory history);
    }
}