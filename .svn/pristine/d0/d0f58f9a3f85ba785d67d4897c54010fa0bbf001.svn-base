using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogCustomFieldEntryHistoryDao : AbstractManagedDao, ILogCustomFieldEntryHistoryDao
    {
        private const string QueryByIdStoredProcedure = "QueryLogCustomFieldEntryHistoriesByHistoryId";
        private const string InsertStoredProcedure = "InsertLogCustomFieldEntryHistory";

        public List<CustomFieldEntryHistory> GetByHistoryId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogHistoryId", id);

            FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = command.QueryForSingleResult<FlattenedCustomFieldEntryHistory>(PopulateInstance, QueryByIdStoredProcedure);
            if (flattenedCustomFieldEntryHistory != null)
            {
                return flattenedCustomFieldEntryHistory.EntryHistories;    
            }
            return new List<CustomFieldEntryHistory>();
        }

        public void Insert(List<CustomFieldEntryHistory> histories)
        {
            if (histories.Count > 0)
            {
                FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(histories[0].HistoryId, histories);

                SqlCommand command = ManagedCommand;
                command.Insert(flattenedCustomFieldEntryHistory, AddInsertParameters, InsertStoredProcedure);
            }
        }

        private static FlattenedCustomFieldEntryHistory PopulateInstance(SqlDataReader reader)
        {
            FlattenedCustomFieldEntryHistory history = new FlattenedCustomFieldEntryHistory(
                reader.Get<long>("LogHistoryId"),
                reader.Get<string>("CustomFields"));

            return history;
        }

        private static void AddInsertParameters(FlattenedCustomFieldEntryHistory flattenedHistory, SqlCommand command)
        {
            command.AddParameter("@LogHistoryId", flattenedHistory.HistoryId);
            command.AddParameter("@CustomFields", flattenedHistory.FlattenedEntryHistories);
        }
    }
}