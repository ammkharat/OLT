using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITemporaryInstallationsMudsDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        TemporaryInstallationsMUDS Insert(TemporaryInstallationsMUDS form);

        //ayman generic forms
        //[CachedQueryByIdAndSiteId]
        //MontrealCsd QueryByIdAndSiteId(long id,long siteid); 
        
        
        [CachedQueryById]
        TemporaryInstallationsMUDS QueryById(long id);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(TemporaryInstallationsMUDS form);
        
        [CachedRemove(false, false)]
        void Remove(TemporaryInstallationsMUDS form);

        List<TemporaryInstallationsMUDS> QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now);
        List<TemporaryInstallationsMUDS> QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(DateTime currentTimeAtSite);
    }
}
