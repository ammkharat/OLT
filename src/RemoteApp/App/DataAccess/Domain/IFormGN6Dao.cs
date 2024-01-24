using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN6Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(FormGN6 form);
        
        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN6 QueryByIdAndSiteId(long id,long siteid);

        [CachedQueryById]
        FormGN6 QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN6 form);
        [CachedRemove(false, false)]
        void Remove(FormGN6 form);

        string WorkersResponsibilitiesTemplateText();
    }
}
