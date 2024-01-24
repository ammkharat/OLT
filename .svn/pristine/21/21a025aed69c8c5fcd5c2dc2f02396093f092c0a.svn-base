using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class UserDTODao : AbstractManagedDao, IUserDTODao
    {
        private const string QUERY_WITH_OILSANDS_TRAINING_FORMS_STORED_PROCEDURE = "QueryUserDTOsThatHaveCreatedOilsandsTrainingForms";

        public List<UserDTO> QueryUsersWhoHaveCreatedOilsandsTrainingForms()
        {            
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<UserDTO>(PopulateInstance, QUERY_WITH_OILSANDS_TRAINING_FORMS_STORED_PROCEDURE);
        }

        private static UserDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string userName = reader.Get<string>("UserName");
            string firstName = reader.Get<string>("FirstName");
            string lastName = reader.Get<string>("LastName");
            
            return new UserDTO(id, userName, firstName, lastName);
        }
    }
}
