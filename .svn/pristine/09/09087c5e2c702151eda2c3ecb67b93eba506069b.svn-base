using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - Move the Configuration Id inside of the CokerCardConfigurationDrum object and find a way to clear the list cache by configuration id in order to cache insert and update
    public interface ICokerCardConfigurationDrumDao : IDao
    {
        List<CokerCardConfigurationDrum> QueryByCokerCardConfigurationId(long cokerCardConfigurationId);
        void Insert(CokerCardConfigurationDrum drum, long configurationId);
        void Update(CokerCardConfigurationDrum drum);
    }
}
