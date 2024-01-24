using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IUserLoginHistoryDao : IDao
    {
        UserLoginHistory QueryLastLoginByUserId(long userId);
        UserLoginHistory Insert(UserLoginHistory userLoginHistory);
        void ReplaceLoginFlocs(UserLoginHistory userLoginHistory);
    }
}