using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN75ADao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(FormGN75A form);
        
        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN75A QueryByIdAndSiteId(long id,long siteid);
        
        [CachedQueryById]
        FormGN75A QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN75A form);
        [CachedRemove(false, false)]
        void Remove(FormGN75A form);        
    }
}