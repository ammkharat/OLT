using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestFortHillsHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<PermitRequestFortHillsHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(PermitRequestFortHillsHistory history);
    }
}