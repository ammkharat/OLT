using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserLoginHistoryFunctionalLocationDao : AbstractManagedDao, IUserLoginHistoryFunctionalLocationDao
    {
        private readonly IFunctionalLocationDao flocDao;
        
        private const string QUERY_FLOC_STORED_PROCEDURE = "QueryUserLoginHistoryFunctionalLocation";
        private const string INSERT_FLOC_STORED_PROCEDURE = "InsertUserLoginHistoryFunctionalLocation";
        private const string DELETE_FLOC_STORED_PROCEDURE = "DeleteUserLoginHistoryFunctionalLocations";

        public UserLoginHistoryFunctionalLocationDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<FunctionalLocation> QuerySelectedFunctionalLocations(long userLoginHistoryId)
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.Clear();
            command.AddParameter("@UserLoginHistoryId", userLoginHistoryId);

            List<UserLoginHistoryFunctionalLocation> historyFunctionalLocations = 
                command.QueryForListResult<UserLoginHistoryFunctionalLocation>(PopulateInstance , QUERY_FLOC_STORED_PROCEDURE);

            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            foreach (UserLoginHistoryFunctionalLocation historyFunctionalLocation in historyFunctionalLocations)
            {
                flocs.Add(flocDao.QueryById(historyFunctionalLocation.FunctionalLocationId));
            }
            return flocs;
        }

        private static UserLoginHistoryFunctionalLocation PopulateInstance(SqlDataReader reader)
        {
            return new UserLoginHistoryFunctionalLocation(reader.Get<long>("FunctionalLocationId"));
        }

        public void InsertSelectedFunctionalLocations(UserLoginHistory userLoginHistory)
        {
            foreach (FunctionalLocation floc in userLoginHistory.SelectedFunctionalLocations)
            {
                SqlCommand command = ManagedCommand;
                command.Parameters.Clear();
                command.AddParameter("@UserLoginHistoryId",  userLoginHistory.Id);
                command.AddParameter("@FunctionalLocationId",  floc.Id);
                command.ExecuteNonQuery(INSERT_FLOC_STORED_PROCEDURE);
            }
        }

        public void DeleteFunctionalLocations(UserLoginHistory userLoginHistory)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserLoginHistoryId", userLoginHistory.Id);
            command.ExecuteNonQuery(DELETE_FLOC_STORED_PROCEDURE);
    }
    }
}