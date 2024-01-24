using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardConfigurationDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        CokerCardConfiguration Insert(CokerCardConfiguration cokerCardConfiguration);
        [CachedInsertOrUpdate(false, false)]
        void Update(CokerCardConfiguration cokerCardConfiguration);

        [CachedQueryById]
        CokerCardConfiguration QueryById(long id);
        
        [CachedQueryById]
        CokerCardConfiguration QueryByIdWithCaching(long id);

        List<CokerCardConfiguration> QueryCokerCardConfigurationsByExactFlocMatch(ExactFlocSet flocSet);
        
        [CachedQueryBySiteId]
        List<CokerCardConfiguration> QueryCokerCardConfigurationsBySite(long siteId);
        
        List<string> QueryDistinctCokerCardConfigurationNamesBySite(Site site);
        List<long> QueryCokerCardConfigurationByName(string name);
        List<long> QueryCokerCardConfigurationByWorkAssignment(WorkAssignment workAssignment);

        [CachedRemove(true, false)]
        void Remove(CokerCardConfiguration cokerCardConfiguration);
    }
}