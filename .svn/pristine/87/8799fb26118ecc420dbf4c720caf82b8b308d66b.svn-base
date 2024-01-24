using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardCycleStepEntryDao : IDao
    {
        // #3003 - Move the Configuration Id inside of the CokerCardConfigurationDrum object and find a way to clear the list cache by Coker Card id in order to cache insert and update
        List<CokerCardCycleStepEntry> QueryByCokerCardId(long cokerCardId);
        void Insert(CokerCardCycleStepEntry entry, long cokerCardId);
        void DeleteByCokerCardId(long cokerCardId);
        void UpdateEndEntry(CokerCardCycleStepEntry entry);
    }
}
