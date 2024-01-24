using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardHistoryDao : IDao
    {
        List<CokerCardHistory> GetById(long cokerCardId);
        void Insert(CokerCardHistory logHistory);
    }
}