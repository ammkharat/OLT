using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverAnswerHistoryDao : AbstractManagedDao, IShiftHandoverAnswerHistoryDao
    {
        private const string QUERY_BY_ID = "QueryShiftHandoverAnswerHistoriesByHistoryId";
        private const string INSERT = "InsertShiftHandoverAnswerHistory";

        public List<ShiftHandoverAnswerHistory> GetByHistoryId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireHistoryId", id);
            return command.QueryForListResult<ShiftHandoverAnswerHistory>(PopulateInstance , QUERY_BY_ID);
        }

        private static ShiftHandoverAnswerHistory PopulateInstance(SqlDataReader reader)
        {
            ShiftHandoverAnswerHistory history = new ShiftHandoverAnswerHistory(
                reader.Get<long>("Id"),
                reader.Get<long>("ShiftHandoverQuestionnaireHistoryId"), 
                reader.Get<long>("ShiftHandoverQuestionId"),
                reader.Get<string>("QuestionText"),
                reader.Get<bool>("Answer"),
                reader.Get<string>("Comments"));

            return history;
        }

        public void Insert(ShiftHandoverAnswerHistory history)
        {
            ManagedCommand.Insert(history, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(ShiftHandoverAnswerHistory history, SqlCommand command)
        {
            command.AddParameter("@ShiftHandoverQuestionnaireHistoryId", history.HistoryId);
            command.AddParameter("@ShiftHandoverQuestionId", history.QuestionId);
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@Answer", history.Answer);
            command.AddParameter("@Comments", history.Comments);
        }
    }
}
