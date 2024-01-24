using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMudsTemplateDao : IDao
    {
        [CachedInsertOrUpdate(false, true)]        
        WorkPermitMudsTemplate Insert(WorkPermitMudsTemplate workPermitMudsTemplate);
        [CachedQueryById]
        WorkPermitMudsTemplate QueryById(long id);
        [CachedRemove(false, true)]
        void Delete(WorkPermitMudsTemplate workPermitMudsTemplate);
        [CachedInsertOrUpdate(false, true)]
        void Update(WorkPermitMudsTemplate workPermitMudsTemplate);

        WorkPermitMudsTemplate QueryByIdToMapPermit(long templateId, long permitId);

        List<WorkPermitMudsTemplate> QueryAllNotDeleted();
        [CachedQueryAll]
        List<WorkPermitMudsTemplate> QueryAll();
    }
}
