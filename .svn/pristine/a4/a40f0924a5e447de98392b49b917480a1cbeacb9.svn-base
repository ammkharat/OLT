using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetAlertDao : IDao
    {
        [CachedQueryById]
        TargetAlert QueryById(long id);
        List<TargetAlert> QueryByTargetDefinitionAndStatuses(TargetDefinition definition, List<TargetAlertStatus> statuses);
        List<TargetAlert> QueryAllTargetAlertsNeedingAttention(List<FunctionalLocation> functionalLocations, List<TargetAlertStatus> statuses);
        List<TargetAlert> QueryByFunctionalLocationsAndUserShift(IFlocSet flocSet, UserShift userShift);
        [CachedInsertOrUpdate(false, false)]        
        TargetAlert Insert(TargetAlert target);
        [CachedInsertOrUpdate(false, false)]
        void Update(TargetAlert alert);
    }
}