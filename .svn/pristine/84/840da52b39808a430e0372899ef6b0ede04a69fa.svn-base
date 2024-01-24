using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IProcedureDeviationDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        ProcedureDeviation Insert(ProcedureDeviation form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        ProcedureDeviation QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        ProcedureDeviation QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(ProcedureDeviation form);

        [CachedRemove(false, false)]
        void Remove(ProcedureDeviation form);
    }
}