using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDefinitionFunctionalLocationDao : AbstractManagedDao, ILogDefinitionFunctionalLocationDao
    {
        private const string INSERT = "InsertLogDefinitionFunctionalLocation";
        private const string QUERY_BY_LOG_DEFN_ID = "QueryLogDefinitionFunctionalLocationByLogDefinitionId";
        private const string DELETE_BY_LOG_DEFINITION_ID = "DeleteLogDefinitionFunctionalLocationsByLogDefinitionId";

        public LogDefinitionFunctionalLocation Insert(LogDefinitionFunctionalLocation logFunctionalLocation)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(logFunctionalLocation, AddInsertParameters, INSERT);
            return logFunctionalLocation;
        }

        public List<LogDefinitionFunctionalLocation> QueryByLogDefinitionId(long logDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogDefinitionId",  logDefinitionId);
            return command.QueryForListResult<LogDefinitionFunctionalLocation>(PopulateInstance, QUERY_BY_LOG_DEFN_ID);
        }

        public void DeleteByLogDefinitionId(long logDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogDefinitionId",  logDefinitionId);
            command.ExecuteNonQuery(DELETE_BY_LOG_DEFINITION_ID);
        }

        private static void AddInsertParameters(LogDefinitionFunctionalLocation logDefinitionFunctionalLocation, SqlCommand command)
        {
            command.AddParameter("@LogDefinitionId", logDefinitionFunctionalLocation.LogDefinitionId);
            command.AddParameter("@FunctionalLocationId", logDefinitionFunctionalLocation.FunctionalLocationId);
        }

        private static LogDefinitionFunctionalLocation PopulateInstance(SqlDataReader reader)
        {
            LogDefinitionFunctionalLocation logDefinitionFunctionalLocation = new LogDefinitionFunctionalLocation(
                reader.Get<long>("LogDefinitionId"),
                reader.Get<long>("FunctionalLocationId"));

            return logDefinitionFunctionalLocation;
        }
    }
}