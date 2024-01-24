using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN24Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(FormGN24 form);
        
        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN24 QueryByIdAndSiteId(long id,long siteid);
        
        [CachedQueryById]
        FormGN24 QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN24 form);
        [CachedRemove(false, false)]
        void Remove(FormGN24 form);
    }
}
