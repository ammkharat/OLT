using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDefinitionCustomFieldEntryHistoryDao : AbstractManagedDao, ILogDefinitionCustomFieldEntryHistoryDao
    {
        private const string QUERY_BY_ID = "QueryLogDefinitionCustomFieldEntryHistoriesByHistoryId";
        private const string INSERT = "InsertLogDefinitionCustomFieldEntryHistory";

        public List<CustomFieldEntryHistory> GetByHistoryId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogDefinitionHistoryId", id);

            FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = command.QueryForSingleResult<FlattenedCustomFieldEntryHistory>(PopulateInstance, QUERY_BY_ID);
            return flattenedCustomFieldEntryHistory != null ? flattenedCustomFieldEntryHistory.EntryHistories : new List<CustomFieldEntryHistory>(0);
        }

        public void Insert(List<CustomFieldEntryHistory> histories)
        {
            if (histories.Count > 0)
            {
                FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(histories[0].HistoryId, histories);

                SqlCommand command = ManagedCommand;
                command.Insert(flattenedCustomFieldEntryHistory, AddInsertParameters, INSERT);
            }
        }

        private static FlattenedCustomFieldEntryHistory PopulateInstance(SqlDataReader reader)
        {
            FlattenedCustomFieldEntryHistory history = new FlattenedCustomFieldEntryHistory(
                reader.Get<long>("LogDefinitionHistoryId"),
                reader.Get<string>("CustomFields"));

            return history;
        }

        private static void AddInsertParameters(FlattenedCustomFieldEntryHistory flattenedHistory, SqlCommand command)
        {
            command.AddParameter("@LogDefinitionHistoryId", flattenedHistory.HistoryId);
            command.AddParameter("@CustomFields", flattenedHistory.FlattenedEntryHistories);
        }
    }
}