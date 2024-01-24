using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<WorkPermitHistory> GetById(long id);


        List<WorkPermitSignHistory> GetBySignId(string id);

        [CachedInsertHistory]
        void Insert(WorkPermitHistory workPermitHistory);   
    }
}