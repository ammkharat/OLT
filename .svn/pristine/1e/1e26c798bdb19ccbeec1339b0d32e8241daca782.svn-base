using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // Cannot cache this because UserWorkPermitDefaultTimePreferences has its own Id which isn't the same as the User id. 
    // If this was changed to match the user id, then we could cache them.
    public interface IUserWorkPermitDefaultTimePreferencesDao : IDao
    {

        
        void Insert(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences);
        void Update(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences);
        UserWorkPermitDefaultTimePreferences QueryByUserId(long userId); //Story : #3219 Update for Default time preferences not working, so change this line number
    }
}
