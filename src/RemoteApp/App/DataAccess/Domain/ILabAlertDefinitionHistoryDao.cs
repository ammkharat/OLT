using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILabAlertDefinitionHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<LabAlertDefinitionHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(LabAlertDefinitionHistory history);
    }
}