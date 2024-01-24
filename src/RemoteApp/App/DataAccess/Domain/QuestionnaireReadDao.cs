using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class QuestionnaireReadDao : AbstractManagedDao, IQuestionnaireReadDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertShiftHandoverQuestionnaireRead";
        private const string QUERY_USER_ALREADY_MARKED_AS_READ = "QueryUserMarkedShiftHandoverQuestionnaireAsRead";
        private const string QUERY_USERS_THAT_MARKED_QUESTIONNAIRE_AS_READ = "QueryUsersMarkedShiftHandoverQuestionnaireAsRead";

        public ItemRead<ShiftHandoverQuestionnaire> UserMarkedAsRead(long shiftHandoverQuestionnaireId, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireId", shiftHandoverQuestionnaireId);
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<ItemRead<ShiftHandoverQuestionnaire>>(PopulateInstance, QUERY_USER_ALREADY_MARKED_AS_READ);
        }

        public void Insert(ItemRead<ShiftHandoverQuestionnaire> itemRead)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(itemRead, AddInsertParameters, INSERT_STORED_PROCEDURE);
        }

        public List<ItemReadBy> UsersThatMarkedAsRead(long questionnaireId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireId", questionnaireId);
            return command.QueryForListResult < ItemReadBy>(PopulateReadByInstance, QUERY_USERS_THAT_MARKED_QUESTIONNAIRE_AS_READ);
        }

        private static ItemReadBy PopulateReadByInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string userName = reader.Get<string>("Username");
            DateTime dateTime = reader.Get<DateTime>("DateTime");
            return new ItemReadBy(User.ToFullNameWithUserName(lastName, firstName, userName),
                dateTime);
        }

        private static void AddInsertParameters(ItemRead<ShiftHandoverQuestionnaire> domainobject, SqlCommand command)
        {
            command.AddParameter("@UserId", domainobject.ReadByUserId);
            command.AddParameter("@ShiftHandoverQuestionnaireId", domainobject.ItemId);
            command.AddParameter("@DateTime", domainobject.Time);
        }

        private static ItemRead<ShiftHandoverQuestionnaire> PopulateInstance(SqlDataReader reader)
        {
            long logId = reader.Get<long>("ShiftHandoverQuestionnaireId");
            long userId = reader.Get<long>("UserId");
            DateTime dateTime = reader.Get<DateTime>("DateTime");

            return new ItemRead<ShiftHandoverQuestionnaire>(logId, userId, dateTime);
        }

    }
}