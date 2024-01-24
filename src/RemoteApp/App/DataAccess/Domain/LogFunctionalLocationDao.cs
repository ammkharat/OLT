using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogFunctionalLocationDao : AbstractManagedDao, ILogFunctionalLocationDao
    {
        private const string INSERT = "InsertLogFunctionalLocation";

        public void Insert(LogFunctionalLocation logFunctionalLocation)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(logFunctionalLocation, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(LogFunctionalLocation logFunctionalLocation, SqlCommand command)
        {
            command.AddParameter("@LogId", logFunctionalLocation.LogId);
            command.AddParameter("@FunctionalLocationId", logFunctionalLocation.FunctionalLocationId);
        }
    }
}