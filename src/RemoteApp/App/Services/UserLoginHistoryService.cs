using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserLoginHistoryService : IUserLoginHistoryService
    {
        private readonly IUserLoginHistoryDao userLoginHistoryDao;

        public UserLoginHistoryService()
        {
            userLoginHistoryDao = DaoRegistry.GetDao<IUserLoginHistoryDao>();
        }

        public UserLoginHistory GetLastLogin(User user)
        {
            return userLoginHistoryDao.QueryLastLoginByUserId(user.Id.Value);
        }

        public UserLoginHistory SaveLoginHistory(UserLoginHistory history)
        {
            return userLoginHistoryDao.Insert(history);    
        }

        public void ReplaceLoginFlocs(UserLoginHistory history)
        {
            userLoginHistoryDao.ReplaceLoginFlocs(history);
        }
    }
}
