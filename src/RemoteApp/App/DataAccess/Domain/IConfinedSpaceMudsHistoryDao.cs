using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IConfinedSpaceMudsHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<ConfinedSpaceHistoryMuds> GetById(long id);
        
        [CachedInsertHistory]
        void Insert(ConfinedSpaceHistoryMuds history);


        List<ConfinedSpaceMudsSignHistory> GetBySignId(string id);
    }
}