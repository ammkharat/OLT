using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IUserDTODao : IDao
    {
        List<UserDTO> QueryUsersWhoHaveCreatedOilsandsTrainingForms();
    }
}
