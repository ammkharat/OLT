using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IRestrictionLocationDao : IDao
    {
        //[CachedQueryAll]
        List<RestrictionLocation> QueryAll(long siteid);    //ayman restriction
       
        //[CachedInsertOrUpdate(false, true)]
        void Insert(RestrictionLocation location);

        //[CachedInsertOrUpdate(false, true)]
        void Update(RestrictionLocation location);
        
        //[CachedRemove(false, true)]
        void Remove(RestrictionLocation restrictionLocation);

       // [CachedQueryById]
        RestrictionLocation QueryById(long id);           //ayman restriction

        // This just gets the Id of the Restriction Location so that we can then used the cached version via QueryById.
        long QueryRestrictionLocationIdByWorkAssignment(long workAssignmentId);
        
        long GetNextLocationItemSequenceNumber();
    }

    internal interface IRestrictionLocationWorkAssignmentDao : IDao
    {
        void Insert(long restrictionLocationId, WorkAssignment workAssignment);
    }

    internal interface IRestrictionLocationItemDao : IDao
    {
        void Insert(long restrictionLocationId, RestrictionLocationItem item);
        List<RestrictionLocationItem> QueryByRestrictionLocation(long restrictionLocationId);
        void Update(RestrictionLocationItem item);
        RestrictionLocationItem QueryById(long id);
        void Remove(long itemId);
    }

}