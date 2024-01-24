using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardConfigurationCycleStepDao : IDao
    {
        void Insert(CokerCardConfigurationCycleStep step, long configurationId);
        void Update(CokerCardConfigurationCycleStep step);
        List<CokerCardConfigurationCycleStep> QueryByCokerCardConfigurationId(long cokerCardConfigurationId);        
    }
}
