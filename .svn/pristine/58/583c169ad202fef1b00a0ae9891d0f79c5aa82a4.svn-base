using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMontrealTemplateDao : IDao
    {
        [CachedInsertOrUpdate(false, true)]        
        WorkPermitMontrealTemplate Insert(WorkPermitMontrealTemplate workPermitMontrealTemplate);
        [CachedQueryById]
        WorkPermitMontrealTemplate QueryById(long id);
        [CachedRemove(false, true)]
        void Delete(WorkPermitMontrealTemplate workPermitMontrealTemplate);
        [CachedInsertOrUpdate(false, true)]
        void Update(WorkPermitMontrealTemplate workPermitMontrealTemplate);

        List<WorkPermitMontrealTemplate> QueryAllNotDeleted();
        [CachedQueryAll]
        List<WorkPermitMontrealTemplate> QueryAll();
    }
}
