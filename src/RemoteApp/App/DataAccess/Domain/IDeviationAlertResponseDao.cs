using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDeviationAlertResponseDao : IDao
    {
        [CachedQueryById]
        DeviationAlertResponse QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        DeviationAlertResponse Insert(DeviationAlertResponse deviationAlertResponse);
        [CachedInsertOrUpdate(false, false)]
        void UpdateResponseCodeAssignments(DeviationAlertResponse deviationAlertResponse);        
    }
}
