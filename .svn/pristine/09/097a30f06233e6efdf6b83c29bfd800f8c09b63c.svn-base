using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmToeDefinitionDao : AbstractManagedDao, IOpmToeDefinitionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryOpmToeDefinitionById";
        private const string QUERY_BY_TAG_AND_VERSION_STORED_PROCEDURE = "QueryOpmToeDefinitionByTagAndVersion";
        private const string INSERT_STORED_PROCEDURE = "InsertOpmToeDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateOpmToeDefinition";

        public OpmToeDefinition QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public OpmToeDefinition Insert(OpmToeDefinition opmToeDefinition)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(opmToeDefinition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            opmToeDefinition.Id = (long?) idParameter.Value;
            return opmToeDefinition;
        }


        public OpmToeDefinition QueryByTagAndVersion(string historianTag, long toeVersion)
        {
            var command = ManagedCommand;
            command.AddParameter("@HistorianTag", historianTag);
            command.AddParameter("@ToeVersion", toeVersion);
            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_TAG_AND_VERSION_STORED_PROCEDURE);
        }

        public void Update(OpmToeDefinition opmToeDefinition)
        {
            var command = ManagedCommand;
            command.Update(opmToeDefinition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private OpmToeDefinition PopulateInstance(SqlDataReader reader)
        {
            var opmToeDefinition = new OpmToeDefinition(
                reader.Get<long>("Id"),
                reader.Get<long>("ToeVersion"),
                reader.Get<string>("HistorianTag"),
                reader.Get<DateTime>("ToeVersionPublishDate"),
                reader.Get<string>("ToeName"),
                reader.Get<string>("FunctionalLocation"),
                reader.Get<long>("FunctionalLocationId"),
                ToeType.Get(reader.Get<int>("ToeType")),
                reader.Get<decimal>("LimitValue"),
                reader.Get<string>("CausesDescription"),
                reader.Get<string>("ConsequencesDescription"),
                reader.Get<string>("CorrectiveActionDescription"),
                reader.Get<string>("ReferenceDocuments"),
                reader.Get<string>("UnitOfMeasure"),
                reader.Get<string>("OpmToeHistoryUrl"));
            return opmToeDefinition;
        }

        private static void AddUpdateParameters(OpmToeDefinition opmToeDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", opmToeDefinition.Id);
            AddInsertParameters(opmToeDefinition, command);
        }

        private static void AddInsertParameters(OpmToeDefinition opmToeDefinition, SqlCommand command)
        {
            command.AddParameter("@ToeVersion", opmToeDefinition.ToeVersion);
            command.AddParameter("@HistorianTag", opmToeDefinition.HistorianTag);
            command.AddParameter("@ToeVersionPublishDate", opmToeDefinition.ToeVersionPublishDate.ToSQLServerFriendlyDate());
            command.AddParameter("@ToeName", opmToeDefinition.ToeName);
            command.AddParameter("@FunctionalLocation", opmToeDefinition.FunctionalLocation);
            command.AddParameter("@FunctionalLocationId", opmToeDefinition.FunctionalLocationId);
            command.AddParameter("@ToeType", opmToeDefinition.ToeType.Id);
            command.AddParameter("@LimitValue", opmToeDefinition.LimitValue);
            command.AddParameter("@CausesDescription", opmToeDefinition.CausesDescription);
            command.AddParameter("@ConsequencesDescription", opmToeDefinition.ConsequencesDescription);
            command.AddParameter("@CorrectiveActionDescription", opmToeDefinition.CorrectiveActionDescription);
            command.AddParameter("@ReferenceDocuments", opmToeDefinition.ReferencesDocuments);
            command.AddParameter("@UnitOfMeasure", opmToeDefinition.UnitOfMeasure);
            command.AddParameter("@OpmToeHistoryUrl", opmToeDefinition.OpmToeHistoryUrl.TrimOrEmpty());
        }
    }
}