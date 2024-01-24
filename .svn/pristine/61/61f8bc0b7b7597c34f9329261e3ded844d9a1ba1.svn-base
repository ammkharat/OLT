using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserWorkPermitDefaultTimePreferencesDao : AbstractManagedDao, IUserWorkPermitDefaultTimePreferencesDao
    {
        public UserWorkPermitDefaultTimePreferences QueryByUserId(long userid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userid);
            return command.QueryForSingleResult<UserWorkPermitDefaultTimePreferences>(PopulateInstance , "QueryUserWorkPermitDefaultTimePreferencesByUserId");
        }

        public void Insert(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertUserWorkPermitDefaultTimePreferences";
            command.CommandType = CommandType.StoredProcedure;
            AddInsertParameters(userWorkPermitDefaultTimePreferences, command);
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery();
            userWorkPermitDefaultTimePreferences.Id = long.Parse(idParameter.Value.ToString());
        }

        public void Update(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "UpdateUserWorkPermitDefaultTimePreferences";
            command.CommandType = CommandType.StoredProcedure;
            AddUpdateParameters(userWorkPermitDefaultTimePreferences, command);
            command.ExecuteNonQuery();
        }

        private static ReflectionMapper CreateUserWorkPermitDefaultTimePreferencesMapper()
        {
            return new ReflectionMapper();
        }

        private static UserWorkPermitDefaultTimePreferences PopulateInstance(SqlDataReader reader)
        {
            var userWorkPermitDefaultTimePreferences = new UserWorkPermitDefaultTimePreferences();
            CreateUserWorkPermitDefaultTimePreferencesMapper().Populate(reader, userWorkPermitDefaultTimePreferences);
            return userWorkPermitDefaultTimePreferences;
        }

        private static void AddInsertParameters(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences, SqlCommand sqlCommand)
        {
            CreateUserWorkPermitDefaultTimePreferencesMapper().IgnoreObjectProperty("Id").SetCommandParameters(userWorkPermitDefaultTimePreferences, sqlCommand);
        }

        private static void AddUpdateParameters(UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences, SqlCommand sqlCommand)
        {
            CreateUserWorkPermitDefaultTimePreferencesMapper().IgnoreObjectProperty("UserId").SetCommandParameters(userWorkPermitDefaultTimePreferences, sqlCommand);
        }
    }
}
