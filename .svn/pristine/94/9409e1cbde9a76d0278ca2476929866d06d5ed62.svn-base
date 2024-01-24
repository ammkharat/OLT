using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISummaryLogReadDao : IDao
    {
        SummaryLogRead Insert(SummaryLogRead logToInsert);
        List<SummaryLogRead> SummaryLogsAlreadyRead(List<SummaryLogDTO> list, User user);        
        List<ItemReadBy> UsersThatMarkedSummaryLogAsRead(long summaryLogId);
        SummaryLogRead UserMarkedSummaryLogAsRead(long summaryLogId, long userId);
    }
}