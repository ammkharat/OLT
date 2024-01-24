using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDirectiveDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(Directive directive);

        //[CachedQueryById] // Commented by Vibhor  //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        Directive QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(Directive directive);

        [CachedRemove(false, false)]
        void Remove(Directive directive);
    }
}
