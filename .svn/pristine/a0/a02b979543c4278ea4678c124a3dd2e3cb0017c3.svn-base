using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverQuestionnaireHistoryDao : AbstractManagedDao, IShiftHandoverQuestionnaireHistoryDao
    {
        private const string QUERY_BY_ID = "QueryShiftHandoverQuestionnaireHistoriesById";
        private const string INSERT = "InsertShiftHandoverQuestionnaireHistory";

        private readonly IUserDao userDao;
        private readonly IShiftHandoverAnswerHistoryDao answerHistoryDao;

        public ShiftHandoverQuestionnaireHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            answerHistoryDao = DaoRegistry.GetDao<IShiftHandoverAnswerHistoryDao>();
        }

        public List<ShiftHandoverQuestionnaireHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<ShiftHandoverQuestionnaireHistory>(PopulateInstance , QUERY_BY_ID);
        }

        private ShiftHandoverQuestionnaireHistory PopulateInstance(SqlDataReader reader)
        {
            ShiftHandoverQuestionnaireHistory history = new ShiftHandoverQuestionnaireHistory(
                reader.Get<long>("Id"),
                reader.Get<string>("FunctionalLocations"),
                answerHistoryDao.GetByHistoryId(reader.Get<long>("ShiftHandoverQuestionnaireHistoryId")),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"));

            return history;
        }

        public void Insert(ShiftHandoverQuestionnaireHistory history)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.Parameters.Add("@ShiftHandoverQuestionnaireHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(history, AddInsertParameters, INSERT);

            long historyId = (long)idParameter.Value;
            InsertAnswers(historyId, history.Answers);
        }

        private void InsertAnswers(long historyId, IEnumerable<ShiftHandoverAnswerHistory> answers)
        {
            foreach (ShiftHandoverAnswerHistory answer in answers)
            {
                answer.HistoryId = historyId;
                answerHistoryDao.Insert(answer);
            }
        }

        private static void AddInsertParameters(ShiftHandoverQuestionnaireHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
        }
    }
}
