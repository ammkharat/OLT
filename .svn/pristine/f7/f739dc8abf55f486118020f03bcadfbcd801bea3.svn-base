using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmExcursionImportStatusDTODao : AbstractManagedDao, IOpmExcursionImportStatusDTODao
    {
        private const string QUERY = "QueryOpmExcursionImportStatus";
        private const string UPDATE_AVAILABLE = "UpdateAvailableOpmExcursionImportStatus";
        private const string UPDATE_UNAVAILABLE = "UpdateUnavailableOpmExcursionImportStatus";

        public OpmExcursionImportStatusDTO QueryLastSuccessfulImport()
        {
            return ManagedCommand.QueryForSingleResult(PopulateInstance, QUERY);
        }

        public void UpdateAvailableImportStatus(DateTime? lastExcursionImportDateTime)
        {
            var command = ManagedCommand;
            command.AddParameter("@LastSuccessfulExcursionImportDateTime", lastExcursionImportDateTime);
            command.AddParameter("@LastExcursionImportDateTime", lastExcursionImportDateTime);
            command.AddParameter("@LastExcursionImportStatus", OpmExcursionImportStatus.Available.IdValue);
            command.ExecuteNonQuery(UPDATE_AVAILABLE);
        }

        public void UpdateUnavailableImportStatus(DateTime? lastExcursionImportDateTime)
        {
            var command = ManagedCommand;
            command.AddParameter("@LastExcursionImportDateTime", lastExcursionImportDateTime);
            command.AddParameter("@LastExcursionImportStatus", OpmExcursionImportStatus.Unavailable.IdValue);
            command.ExecuteNonQuery(UPDATE_UNAVAILABLE);
        }

        private OpmExcursionImportStatusDTO PopulateInstance(SqlDataReader reader)
        {
            var lastSuccessfulExcursionImportDateTime = reader.Get<DateTime?>("LastSuccessfulExcursionImportDateTime");

            return new OpmExcursionImportStatusDTO(-1, OpmExcursionImportStatus.Available, lastSuccessfulExcursionImportDateTime);
        }
    }
}