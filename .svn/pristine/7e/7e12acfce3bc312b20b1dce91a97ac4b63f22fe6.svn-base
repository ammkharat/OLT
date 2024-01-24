using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMudsHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<WorkPermitMudsHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(WorkPermitMudsHistory workPermitMudsHistory);

       
        List<WorkPermitMudsSignHistory> GetBySignId(string id);
    }
}