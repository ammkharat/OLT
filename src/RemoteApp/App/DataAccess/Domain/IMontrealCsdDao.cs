using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IMontrealCsdDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        MontrealCsd Insert(MontrealCsd form);

        //ayman generic forms
        //[CachedQueryByIdAndSiteId]
        //MontrealCsd QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        MontrealCsd QueryById(long id);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(MontrealCsd form);
        
        [CachedRemove(false, false)]
        void Remove(MontrealCsd form);
        
        List<MontrealCsd> QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now);
        List<MontrealCsd> QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(DateTime currentTimeAtSite);
    }
}
