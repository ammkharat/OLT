using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardDrumEntryDao : IDao
    {
        List<CokerCardDrumEntry> QueryByCokerCardId(long cokerCardId);
        void Insert(CokerCardDrumEntry entry, long cokerCardId);
        void DeleteByCokerCardId(long cokerCardId);
    }
}
