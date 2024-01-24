using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IEdmontonPersonDao : IDao
    {
        [CachedQueryAll]
        List<EdmontonPerson> QueryAll();
        List<EdmontonPerson> QueryAllDeleted();

        [CachedInsertOrUpdate(false, true)]
        void Insert(EdmontonPerson person);
        [CachedInsertOrUpdate(false, true)]
        void UndoRemove(EdmontonPerson person);
        [CachedInsertOrUpdate(false, true)]
        void Update(EdmontonPerson person);
        [CachedRemove(false, true)]
        void Remove(EdmontonPerson person);
    }
}