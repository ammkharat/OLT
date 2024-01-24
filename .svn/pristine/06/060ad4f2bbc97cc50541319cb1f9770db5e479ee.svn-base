using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IConfinedSpaceMudsDao : IDao
    {
        [CachedQueryById]
        ConfinedSpaceMuds QueryById(long id);
        
        [CachedInsertOrUpdate(false, false)]
        ConfinedSpaceMuds Insert(ConfinedSpaceMuds confinedSpace);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(ConfinedSpaceMuds confinedSpace);
        
        [CachedRemove(false, false)]
        void Remove(ConfinedSpaceMuds confinedSpace);

        [CachedQueryById]
        ConfinedSpaceMuds QueryByConfinedSpaceId(long id);

        //Added by ppanigrahi
        ConfinedSpaceMudSign GetConfinedSpaceMudSign(string WorkPermitId, int SiteId);
        void InserUpdateConfinedSpaceMudSign(ConfinedSpaceMudSign workPermitSign);
    }
}