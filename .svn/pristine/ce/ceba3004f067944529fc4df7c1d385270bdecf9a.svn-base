using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // Cannot cache this because UserPrintPreference has its own Id which isn't the same as the User id. 
    // If this was changed to match the user id, then we could cache them.
    public interface IUserPrintPreferenceDao : IDao
    {
        UserPrintPreference Insert(UserPrintPreference preferenceToInsert);
        void Update(UserPrintPreference preferenceToUpdate);
        void Remove(UserPrintPreference preferenceToRemove);
        UserPrintPreference QueryByUserId(long userId);
    }
}