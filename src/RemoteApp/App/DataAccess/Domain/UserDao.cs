using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserDao : AbstractManagedDao, IUserDao
    {
        private const string QUERY_USER_BY_USERNAME_STORED_PROCEDURE = "QueryActiveUserByUsername";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryUserById";
        private const string INSERT_STORED_PROCEDURE = "InsertUser";
        private const string REMOVE_STORED_PROCEDURE = "RemoveUser";
        private const string UPDATE_STORED_PROCEDURE = "UpdateUser";
        private const string UNDO_REMOVE_STORED_PROCEDURE = "UndoRemoveUser";
        private const string QUERY_DELETED_BY_USERNAME_STORED_PROCEDURE = "QueryDeletedUserByUsername";

        private readonly IUserPrintPreferenceDao userPrintPreferenceDao;
        private readonly IUserWorkPermitDefaultTimePreferencesDao workPermitDefaultTimePreferencesDao;
        private IUserPreferencesDao userPreferencesDao;

        public UserDao()
        {
            userPreferencesDao = DaoRegistry.GetDao<IUserPreferencesDao>();
            userPrintPreferenceDao = DaoRegistry.GetDao<IUserPrintPreferenceDao>();
            workPermitDefaultTimePreferencesDao = DaoRegistry.GetDao<IUserWorkPermitDefaultTimePreferencesDao>();
        }

        public User QueryById(long id)
        {
            return ManagedCommand.QueryById<User>(id, PopulateShallowInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public User QueryByUsername(string username)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_USER_BY_USERNAME_STORED_PROCEDURE;
            command.Parameters.Clear();
            command.AddParameter("@Username", username);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    User user = PopulateInstance(reader);
                    return user;
                }
                throw new NoDataFoundException("No user found for username, " + username);
            }
        }

        public User Insert(User user)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(user, AddInsertParameters, INSERT_STORED_PROCEDURE);
            user.Id = long.Parse(idParameter.Value.ToString());
            return user;
        }
        
        public void Remove(User userToRemove, long lastModifiedByUserId)
        {
            userToRemove.LastModifiedById = lastModifiedByUserId;
            ManagedCommand.ExecuteNonQuery(userToRemove, REMOVE_STORED_PROCEDURE, AddDeleteParameters);
        }

        public void Update(User user)
        {
            ManagedCommand.Update(user, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        public User QueryDeletedUserByUserName(string username)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_DELETED_BY_USERNAME_STORED_PROCEDURE;
            command.Parameters.Clear();
            command.AddParameter("@Username", username);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    User user = PopulateInstance(reader);
                    return user;
                }
                return null;
            }
        }

        public void UndoRemove(User userToUndoRemove, long lastModifiedByUserId)
        {
            userToUndoRemove.LastModifiedById = lastModifiedByUserId;
            ManagedCommand.ExecuteNonQuery(userToUndoRemove, UNDO_REMOVE_STORED_PROCEDURE, AddDeleteParameters);
        }

        private static void AddUpdateParameters(User user, SqlCommand command)
        {
            command.AddParameter("@Id", user.Id);
            AddCommonParameters(user, command);
        }

        private static void AddDeleteParameters(User user, SqlCommand command)
        {
            command.AddParameter("@Id",  user.Id);
            command.AddParameter("@LastModifiedUserId",  user.LastModifiedById);
            command.AddParameter("@LastModifiedDateTime",  user.LastModifiedDate);
        }

        private static void AddInsertParameters(User user, SqlCommand command)
        {
            AddCommonParameters(user, command);
        }

        private static void AddCommonParameters(User user, SqlCommand command)
        {
            command.AddParameter("@UserName", user.Username);
            command.AddParameter("@FirstName", user.FirstName);
            command.AddParameter("@LastName", user.LastName);
            command.AddParameter("@SAPId", user.SAPId);
            command.AddParameter("@LastModifiedDateTime", user.LastModifiedDate);
        }

        private User PopulateShallowInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            var user = new User(id,
                                 reader.Get<string>("Username"),
                                 reader.Get<string>("Firstname"),
                                 reader.Get<string>("Lastname"),
                                 new List<SiteRolePlant>(),
                                 reader.Get<string>("SAPId"), 
                                 new UserPreferences(id), 
                                 new UserPrintPreference(id),
                                 new UserWorkPermitDefaultTimePreferences(id),
                                 reader.Get<DateTime>("LastModifiedDateTime")
                );

            return user;
        }

        private User PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            var user = new User(id,
                                 reader.Get<string>("Username"),
                                 reader.Get<string>("Firstname"),
                                 reader.Get<string>("Lastname"),
                                 new List<SiteRolePlant>(),
                                 reader.Get<string>("SAPId"), 
                                 populateUserPreferences(id),
                                 PopulateUserPrintPreference(id),
                                 PopulateUserWorkPermitDefaultTimePreference(id),
                                 reader.Get<DateTime>("LastModifiedDateTime")
                );

            return user;
        }

        private UserPreferences populateUserPreferences(long userId)
        {
            UserPreferences preferences = userPreferencesDao.QueryByUserId(userId);
            return preferences ?? new UserPreferences(userId);
        }

        private UserPrintPreference PopulateUserPrintPreference(long userid)
        {
            UserPrintPreference preference = userPrintPreferenceDao.QueryByUserId(userid);
            return preference ?? new UserPrintPreference(userid);
        }
        
        private UserWorkPermitDefaultTimePreferences PopulateUserWorkPermitDefaultTimePreference(long userid)
        {
            UserWorkPermitDefaultTimePreferences preference = workPermitDefaultTimePreferencesDao.QueryByUserId(userid);
            return preference ?? new UserWorkPermitDefaultTimePreferences(userid);
        }
    }
}
