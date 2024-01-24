using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestMudsHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<PermitRequestMudsHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(PermitRequestMudsHistory history);
    }
}