using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - move user print preferences under the User and only update via this dao!
    public interface IUserDao : IDao
    {
        // don't cache this because the User could update their user print preferences
        User QueryByUsername(string username);

        [CachedQueryById]
        User QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        User Insert(User userToInsert);
        [CachedInsertOrUpdate(false, false)]
        void Update(User user);

        User QueryDeletedUserByUserName(string username);
        
        void Remove(User userToRemove, long lastModifiedByUserId);
        void UndoRemove(User userToUndoRemove, long lastModifiedByUserId);        
    }
}