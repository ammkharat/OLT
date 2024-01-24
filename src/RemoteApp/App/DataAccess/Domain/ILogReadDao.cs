using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogReadDao : IDao
    {
        LogRead Insert(LogRead logToInsert);
        List<ItemReadBy> UsersThatMarkedLogAsRead(long logId);
        LogRead UserMarkedLogAsRead(long logId, long userId);
    }
}