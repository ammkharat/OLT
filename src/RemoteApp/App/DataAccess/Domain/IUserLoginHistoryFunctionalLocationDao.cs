using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IUserLoginHistoryFunctionalLocationDao : IDao
    {
        List<FunctionalLocation> QuerySelectedFunctionalLocations(long userLoginHistoryId);
        void InsertSelectedFunctionalLocations(UserLoginHistory userLoginHistory);
        void DeleteFunctionalLocations(UserLoginHistory userLoginHistory);
    }
}
