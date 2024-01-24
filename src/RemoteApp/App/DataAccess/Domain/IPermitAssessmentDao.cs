using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitAssessmentDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        PermitAssessment Insert(PermitAssessment form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        PermitAssessment QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        PermitAssessment QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(PermitAssessment form);

        [CachedRemove(false, false)]
        void Remove(PermitAssessment form);
    }
}