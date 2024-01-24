using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IGenericCsdDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        GenericCsd Insert(GenericCsd form);

        //ayman generic forms
        //[CachedQueryByIdAndSiteId]
        //MontrealCsd QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        GenericCsd QueryById(long id);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(GenericCsd form);
        
        [CachedRemove(false, false)]
        void Remove(GenericCsd form);

        List<GenericCsd> QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now);
        List<GenericCsd> QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(DateTime currentTimeAtSite);
    }
}
