using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOvertimeFormDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(OvertimeForm form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        OvertimeForm QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        OvertimeForm QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(OvertimeForm form);

        [CachedRemove(false, false)]
        void Remove(OvertimeForm form);
    }

    public interface IOnPremiseContractorDao : IDao
    {
        List<OnPremiseContractor> QueryByOvertimeForm(long formId);
        void Insert(OnPremiseContractor contractor);
        void RemoveAllThatAreNotInThisList(long overtimeFormId, List<OnPremiseContractor> itemsToUpdate);
        void Update(OnPremiseContractor item);
    }
}