using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN59Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        FormGN59 Insert(FormGN59 form);
        [CachedQueryById]
        FormGN59 QueryById(long id);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN59 QueryByIdAndSiteId(long id,long siteid);

        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN59 form);
        [CachedRemove(false, false)]
        void Remove(FormGN59 form);
    }
}
