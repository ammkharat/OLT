using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserPreferencesDao : AbstractManagedDao, IUserPreferencesDao
    {
        private const string QUERY_BY_USERID = "QueryUserPreferencesByUserId";
        private const string INSERT_STORED_PROCEDURE = "InsertUserPreferences";
        private const string UPDATE_STORED_PROCEDURE = "UpdateUserPreferences";
        private const string REMOVE_STORED_PROCEDURE = "RemoveUserPreferences";

        public UserPreferences Insert(UserPreferences preferences)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(preferences, AddInsertParameters, INSERT_STORED_PROCEDURE);
            preferences.Id = long.Parse(idParameter.Value.ToString());
            return preferences;
        }

        public void Update(UserPreferences preferencesToUpdate)
        {
            ManagedCommand.Update(preferencesToUpdate, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        public void Remove(UserPreferences preferencesToRemove)
        {
            ManagedCommand.ExecuteNonQuery(preferencesToRemove, REMOVE_STORED_PROCEDURE, AddDeleteParameters);
        }

        public UserPreferences QueryByUserId(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_USERID);
        }

        private static void AddInsertParameters(UserPreferences preferences, SqlCommand command)
        {
            command.AddParameter("@UserId", preferences.UserId);
            command.AddParameter("@ActionItemDefinitionLastUsedWorkAssignmentId",
                preferences.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        private static void AddUpdateParameters(UserPreferences preferences, SqlCommand command)
        {
            command.AddParameter("@Id", preferences.Id);
            command.AddParameter("@UserId", preferences.UserId);
            command.AddParameter("@ActionItemDefinitionLastUsedWorkAssignmentId", preferences.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        private static void AddDeleteParameters(UserPreferences preferences, SqlCommand command)
        {
            command.AddParameter("@Id", preferences.Id);
        }

        private static UserPreferences PopulateInstance(SqlDataReader reader)
        {
            var preferences = new UserPreferences(reader.Get<long>("Id"),
                reader.Get<long>("UserId"),
                reader.Get<long>("ActionItemDefinitionLastUsedWorkAssignmentId"));

            return preferences;
        }
    }
}