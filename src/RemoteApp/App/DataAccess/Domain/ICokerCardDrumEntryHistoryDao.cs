using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardDrumEntryHistoryDao : IDao
    {
        List<CokerCardDrumEntryHistory> GetDrumEntryHistoryByCokerCardHistoryId(long cokerCardHistoryId);
    }
}