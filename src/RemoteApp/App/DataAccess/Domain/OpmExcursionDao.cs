using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmExcursionDao : AbstractManagedDao, IOpmExcursionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryOpmExcursionById";
        private const string QUERY_BY_OPM_EXCURSION_ID_STORED_PROCEDURE = "QueryOpmExcursionByOpmExcursionId";
        private const string INSERT_STORED_PROCEDURE = "InsertOpmExcursion";
        private const string UPDATE_STORED_PROCEDURE = "UpdateOpmExcursion";

        private const string QUERY_BY_MOST_RECENT_EXCURSION_UPDATE_DATE_TIME =
            "QueryOpmExcursionByMostRecentUpdateDateTime";

        public OpmExcursion QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public OpmExcursion QueryByOpmExcursionId(long opmExcursionId)
        {
            return ManagedCommand.QueryById(opmExcursionId, PopulateInstance, QUERY_BY_OPM_EXCURSION_ID_STORED_PROCEDURE);
        }

        public OpmExcursion QueryMostRecentExcursionUpdateDateTime()
        {
            return ManagedCommand.QueryForSingleResult(PopulateInstance, QUERY_BY_MOST_RECENT_EXCURSION_UPDATE_DATE_TIME);
        }

        public OpmExcursion Insert(OpmExcursion opmExcursion)
        {
            var command = ManagedCommand;

            var idParameter = command.AddIdOutputParameter();
            command.Insert(opmExcursion, AddInsertParameters, INSERT_STORED_PROCEDURE);
            opmExcursion.Id = (long?) idParameter.Value;
            return opmExcursion;
        }

        public void Update(OpmExcursion opmExcursion)
        {
            var command = ManagedCommand;
            command.Update(opmExcursion, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private OpmExcursion PopulateInstance(SqlDataReader reader)
        {
            var excursion = new OpmExcursion(
                reader.Get<long>("Id"),
                reader.Get<long>("OpmExcursionId"),
                reader.Get<long>("ToeVersion"),
                reader.Get<string>("HistorianTag"),
                reader.Get<string>("FunctionalLocation"),
                reader.Get<long>("FunctionalLocationId"),
                reader.Get<string>("ToeName"),
                ToeType.Get(reader.Get<int>("ToeType")),
                ExcursionStatus.Get(reader.Get<int>("Status")),
                reader.Get<DateTime>("StartDateTime"),
                reader.Get<DateTime?>("EndDateTime"),
                reader.Get<string>("UnitOfMeasure"),
                reader.Get<decimal>("Peak"),
                reader.Get<decimal>("Average"),
                reader.Get<int>("Duration"),
                reader.Get<string>("OpmTrendUrl"),
                reader.Get<long>("IlpNumber"),
                reader.Get<string>("EngineerComments"),
                reader.Get<string>("ReasonCode"),
                reader.Get<DateTime>("LastUpdatedDateTime"),
                reader.Get<decimal>("ToeLimitValue"));
            return excursion;
        }

        private static void AddInsertParameters(OpmExcursion excursion, SqlCommand command)
        {
            command.AddParameter("@OpmExcursionId", excursion.OpmExcursionId);
            command.AddParameter("@ToeVersion", excursion.ToeVersion);
            command.AddParameter("@HistorianTag", excursion.HistorianTag);
            command.AddParameter("@FunctionalLocation", excursion.FunctionalLocation);
            command.AddParameter("@FunctionalLocationId", excursion.FunctionalLocationId);
            command.AddParameter("@ToeName", excursion.ToeName);
            command.AddParameter("@ToeType", excursion.ToeType.Id);
            command.AddParameter("@StartDateTime", excursion.StartDateTime);
            command.AddParameter("@UnitOfMeasure", excursion.UnitOfMeasure);
            command.AddParameter("@ToeLimitValue", excursion.ToeLimitValue);
            SetInsertUpdateAttributes(excursion, command);
        }

        private static void AddUpdateParameters(OpmExcursion excursion, SqlCommand command)
        {
            command.AddParameter("@Id", excursion.Id);
            SetInsertUpdateAttributes(excursion, command);
        }

        private static void SetInsertUpdateAttributes(OpmExcursion excursion, SqlCommand command)
        {
            command.AddParameter("@Status", excursion.Status.Id);
            command.AddParameter("@EndDateTime", excursion.EndDateTime.ToSQLServerFriendlyDate());
            command.AddParameter("@Peak", excursion.Peak);
            command.AddParameter("@Average", excursion.Average);
            command.AddParameter("@Duration", excursion.Duration);
            command.AddParameter("@IlpNumber", excursion.IlpNumber);
            command.AddParameter("@EngineerComments", excursion.EngineerComments);
            command.AddParameter("@ReasonCode", excursion.ReasonCode);
            command.AddParameter("@LastUpdatedDateTime", excursion.LastUpdatedDateTime.ToSQLServerFriendlyDate());
            command.AddParameter("@OpmTrendUrl",
                excursion.OpmTrendUrl.IsNullOrEmptyOrWhitespace() ? string.Empty : excursion.OpmTrendUrl);
        }
    }
}