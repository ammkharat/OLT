using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User QueryById(long id);

        [OperationContract]
        UserPrintPreference UpdatePrintPreferences(User user);

        [OperationContract]
        void UpdateUserPreferences(User user);

        [OperationContract]
        void UpdateWorkPermitDefaultTimesPreferences(User user);

        [OperationContract]
        User GetSAPUser();

        [OperationContract]
        User GetRemoteAppUser();

        [OperationContract]
        void SaveGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier, string xml);

        [OperationContract]
        string GetGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier);

        [OperationContract]
        void DeleteGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier);

        [OperationContract]
        void DeleteGridLayoutsForUser(long userId);

        [OperationContract]
        List<UserDTO> QueryUsersWhoHaveCreatedOilsandsTrainingForms();
    }
}