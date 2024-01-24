using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN1Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(FormGN1 form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN1 QueryByIdAndSiteId(long id,long siteid);

        [CachedQueryById]
        FormGN1 QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN1 form);

        [CachedRemove(false, false)]
        void Remove(FormGN1 form);

        int? GetMaxTradeChecklistSequenceNumber(long formGNId);
    }
}