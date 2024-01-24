using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardDrumEntryDao :AbstractManagedDao, ICokerCardDrumEntryDao
    {
        private const string QUERY_BY_COKER_CARD_ID = "QueryCokerCardDrumEntryByCokerCardId";
        private const string INSERT = "InsertCokerCardDrumEntry";
        private const string DELETE_BY_COKER_CARD_ID = "DeleteCokerCardDrumEntryByCokerCardId";

        public List<CokerCardDrumEntry> QueryByCokerCardId(long cokerCardId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardId",  cokerCardId);
            return command.QueryForListResult < CokerCardDrumEntry>(PopulateInstance, QUERY_BY_COKER_CARD_ID);      
        }

        private static CokerCardDrumEntry PopulateInstance(SqlDataReader reader)
        {
            return new CokerCardDrumEntry(
                reader.Get<long>("Id"),
                reader.Get<long>("CokerCardConfigurationDrumId"),
                reader.Get<long?>("CokerCardConfigurationLastCycleStepId"),
                reader.Get<decimal?>("HoursIntoLastCycle"),
                reader.Get<string>("Comments"));
        }

        public void Insert(CokerCardDrumEntry entry, long cokerCardId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@CokerCardId", cokerCardId);
            command.Insert(entry, AddInsertParameters, INSERT);
            entry.Id = (long?)idParameter.Value;
        }

        private static void AddInsertParameters(CokerCardDrumEntry entry, SqlCommand command)
        {
            command.AddParameter("@CokerCardConfigurationDrumId", entry.DrumId);
            command.AddParameter("@CokerCardConfigurationLastCycleStepId", entry.LastCycleStepId);
            command.AddParameter("@HoursIntoLastCycle", entry.HoursIntoLastCycle);
            command.AddParameter("@Comments", entry.Comments);
        }

        public void DeleteByCokerCardId(long cokerCardId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardId",  cokerCardId);
            command.ExecuteNonQuery(DELETE_BY_COKER_CARD_ID);
        }
    }
}