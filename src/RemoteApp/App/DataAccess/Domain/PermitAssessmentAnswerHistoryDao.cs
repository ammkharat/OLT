using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitAssessmentAnswerHistoryDao : AbstractManagedDao, IPermitAssessmentAnswerHistoryDao
    {
        private const string QUERY_BY_ID = "QueryPermitAssessmentAnswerHistoriesByHistoryId";
        private const string INSERT = "InsertPermitAssessmentAnswerHistory";

        public List<PermitAssessmentAnswerHistory> GetByHistoryId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitAssessmentHistoryId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(PermitAssessmentAnswerHistory history)
        {
            ManagedCommand.Insert(history, AddInsertParameters, INSERT);
        }

        private static PermitAssessmentAnswerHistory PopulateInstance(SqlDataReader reader)
        {
            var history = new PermitAssessmentAnswerHistory(
                reader.Get<long>("Id"),
                reader.Get<long>("PermitAssessmentHistoryId"),
                reader.Get<long>("PermitAssessmentAnswerId"),
                reader.Get<string>("QuestionText"),
                reader.Get<int>("Score"),
                reader.Get<decimal>("SectionScoredPercentage"),
                reader.Get<string>("Comments"));

            return history;
        }

        private static void AddInsertParameters(PermitAssessmentAnswerHistory history, SqlCommand command)
        {
            command.AddParameter("@PermitAssessmentHistoryId", history.HistoryId);
            command.AddParameter("@PermitAssessmentAnswerId", history.AnswerId);
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@SectionScoredPercentage", history.SectionScoredPercentage);
            command.AddParameter("@Score", history.Score);
            command.AddParameter("@Comments", history.Comments);
        }
    }
}