using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormLubesCsdDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        LubesCsdForm Insert(LubesCsdForm form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        LubesCsdForm QueryByIdAndSiteId(long id,long siteid);
        
        [CachedQueryById]
        LubesCsdForm QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(LubesCsdForm form);

        [CachedRemove(false, false)]
        void Remove(LubesCsdForm form);

        List<LubesCsdForm> QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now);
    }
}