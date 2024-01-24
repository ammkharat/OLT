using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SummaryLogCustomFieldEntryHistoryDao : AbstractManagedDao, ISummaryLogCustomFieldEntryHistoryDao
    {
        private const string QUERY_BY_ID = "QuerySummaryLogCustomFieldEntryHistoriesByHistoryId";
        private const string INSERT = "InsertSummaryLogCustomFieldEntryHistory";

        public List<CustomFieldEntryHistory> GetByHistoryId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SummaryLogHistoryId", id);

            FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = command.QueryForSingleResult<FlattenedCustomFieldEntryHistory>(PopulateInstance , QUERY_BY_ID);
            if (flattenedCustomFieldEntryHistory != null)
            {
                return flattenedCustomFieldEntryHistory.EntryHistories;
            }
            else
            {
                return new List<CustomFieldEntryHistory>();
            }            
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
                reader.Get<long>("SummaryLogHistoryId"),
                reader.Get<string>("CustomFields"));

            return history;
        }

        private static void AddInsertParameters(FlattenedCustomFieldEntryHistory flattenedHistory, SqlCommand command)
        {
            command.AddParameter("@SummaryLogHistoryId", flattenedHistory.HistoryId);
            command.AddParameter("@CustomFields", flattenedHistory.FlattenedEntryHistories);
        }
    }
}
