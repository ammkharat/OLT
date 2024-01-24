using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestEdmontonHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<PermitRequestEdmontonHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(PermitRequestEdmontonHistory history);
    }
}