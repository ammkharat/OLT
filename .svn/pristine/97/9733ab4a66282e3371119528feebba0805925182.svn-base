using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN7Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        FormGN7 Insert(FormGN7 form);
        
        //ayman generic forms
        [CachedQueryById]
        FormGN7 QueryByIdAndSiteId(long id,long siteid);

        [CachedQueryById]
        FormGN7 QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN7 form);
        [CachedRemove(false, false)]
        void Remove(FormGN7 form);
    }
}
