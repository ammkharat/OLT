using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IConfinedSpaceDao : IDao
    {
        [CachedQueryById]
        ConfinedSpace QueryById(long id);
        
        [CachedInsertOrUpdate(false, false)]
        ConfinedSpace Insert(ConfinedSpace confinedSpace);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(ConfinedSpace confinedSpace);
        
        [CachedRemove(false, false)]
        void Remove(ConfinedSpace confinedSpace);
    }
}