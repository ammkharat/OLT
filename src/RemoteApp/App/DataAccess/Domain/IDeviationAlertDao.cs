using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDeviationAlertDao : IDao
    {
        [CachedQueryById]
        DeviationAlert QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        DeviationAlert Insert(DeviationAlert alert);
        [CachedInsertOrUpdate(false, false)]
        void UpdateDeviationAlertComment(DeviationAlert alert);
        [CachedInsertOrUpdate(false, false)]
        void UpdateDeviationAlertResponse(DeviationAlert deviationAlert);

        DeviationAlert GetLastRespondedToAlert(RestrictionDefinition restrictionDefinition);
    }
}