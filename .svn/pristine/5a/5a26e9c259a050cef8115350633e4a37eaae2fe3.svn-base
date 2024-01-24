using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILubesAlarmDisableDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        LubesAlarmDisableForm Insert(LubesAlarmDisableForm form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        LubesAlarmDisableForm QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        LubesAlarmDisableForm QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(LubesAlarmDisableForm form);

        [CachedRemove(false, false)]
        void Remove(LubesAlarmDisableForm form);

        List<LubesAlarmDisableForm> QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now);
    }
}