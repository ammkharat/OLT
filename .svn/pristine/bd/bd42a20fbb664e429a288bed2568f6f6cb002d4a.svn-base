using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IUserLoginHistoryService
    {
        [OperationContract]
        UserLoginHistory GetLastLogin(User user);

        [OperationContract]
        UserLoginHistory SaveLoginHistory(UserLoginHistory history);

        [OperationContract]
        void ReplaceLoginFlocs(UserLoginHistory history);
    }
}