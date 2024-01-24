using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FunctionalLocationOperationalModeHistoryDao : AbstractManagedDao, IFunctionalLocationOperationalModeHistoryDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertFunctionalLocationOperationalModeHistory";

        public void Insert(FunctionalLocationOperationalModeHistory flocOperationalModeHistory)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter id = command.AddIdOutputParameter();
            command.Insert(flocOperationalModeHistory, AddInsertParameter, INSERT_STORED_PROCEDURE);
            flocOperationalModeHistory.Id = long.Parse(id.Value.ToString());
        }

        private static void AddInsertParameter(FunctionalLocationOperationalModeHistory flocOpModeHistory, SqlCommand command)
        {
            command.AddParameter("@UnitId",  flocOpModeHistory.UnitId);
            command.AddParameter("@OperationalModeId",  flocOpModeHistory.OperationalMode.IdValue);
            command.AddParameter("@AvailabilityReasonid",  flocOpModeHistory.AvailabilityReason.Id);
            command.AddParameter("@LastModifiedUserId",  flocOpModeHistory.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime",  flocOpModeHistory.LastModifiedDate);
        }
    }
}
