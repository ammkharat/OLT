using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // Cannot cache this because UserPreferences has its own Id which isn't the same as the User id. 
    // If this was changed to match the user id, then we could cache them.
    // and there isn't much point in caching this as it will only be loaded once per session anyway
    public interface IUserPreferencesDao : IDao
    {
        UserPreferences Insert(UserPreferences preferencesToInsert);
        void Update(UserPreferences preferencesToUpdate);
        void Remove(UserPreferences preferencesToRemove);
        UserPreferences QueryByUserId(long userId);
    }
}