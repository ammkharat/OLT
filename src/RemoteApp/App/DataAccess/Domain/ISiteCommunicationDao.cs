using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISiteCommunicationDao : IDao
    {
        [CachedQueryBySiteId]
        List<SiteCommunication> QueryBySite(long siteId);
        
        [CachedInsertOrUpdate(true, false)]
        SiteCommunication Insert(SiteCommunication siteCommunication);

        //[CachedQueryAll]
        List<SiteCommunication> QueryAll();    //ayman site communication

        //[CachedInsertOrUpdate(true,false)]
        List<SiteCommunication> InsertAllSites(SiteCommunication siteCommunication);                //ayman site communication

        [CachedInsertOrUpdate(true, false)]
        void Update(SiteCommunication siteCommunication);

        [CachedRemove(true, false)]
        void Remove(SiteCommunication siteCommunication);
    }
}
