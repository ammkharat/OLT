using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SummaryLogReadDao : AbstractManagedDao, ISummaryLogReadDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertSummaryLogRead";
        private const string QUERY_LOGS_READ_BY_USER = "QuerySummaryLogsReadByUser";
        private const string QUERY_USERS_THAT_MARKED_LOG_AS_READ = "QueryUsersMarkedSummaryLogAsRead";
        private const string QUERY_USER_ALREADY_MARKED_LOG_AS_READ = "QueryUserMarkedSummaryLogAsRead";

        public SummaryLogRead Insert(SummaryLogRead logToInsert)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(logToInsert, AddInsertParameters, INSERT_STORED_PROCEDURE);
            return logToInsert;
        }

        public List<SummaryLogRead> SummaryLogsAlreadyRead(List<SummaryLogDTO> list, User user)
        {
            string logIds = list.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_LOGS_READ_BY_USER;
            command.AddParameter("@SummaryLogIds", logIds);
            command.AddParameter("@UserId", user.IdValue);

            return command.QueryForListResult<SummaryLogRead>(PopulateInstance, QUERY_LOGS_READ_BY_USER);
        }

        public List<ItemReadBy> UsersThatMarkedSummaryLogAsRead(long summaryLogId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SummaryLogId", summaryLogId);
            return command.QueryForListResult<ItemReadBy>(PopulateReadByInstance, QUERY_USERS_THAT_MARKED_LOG_AS_READ);
        }

        public SummaryLogRead UserMarkedSummaryLogAsRead(long summarylogId, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SummaryLogId", summarylogId);
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<SummaryLogRead>(PopulateInstance, QUERY_USER_ALREADY_MARKED_LOG_AS_READ);
        }

        private static ItemReadBy PopulateReadByInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string userName = reader.Get<string>("Username");
            DateTime dateTime = reader.Get<DateTime>("DateTime");
            return new ItemReadBy(
                User.ToFullNameWithUserName(lastName, firstName, userName),
                dateTime);
        }

        private static SummaryLogRead PopulateInstance(SqlDataReader reader)
        {
            long logId = reader.Get<long>("SummaryLogId");
            long userId = reader.Get<long>("UserId");
            DateTime dateTime = reader.Get<DateTime>("DateTime");

            return new SummaryLogRead(logId, userId, dateTime);
        }

        private static void AddInsertParameters(SummaryLogRead logRead, SqlCommand command)
        {
            command.AddParameter("@UserId", logRead.ReadByUserId);
            command.AddParameter("@SummaryLogId", logRead.SummaryLogId);
            command.AddParameter("@DateTime", logRead.Time);
        }

    }
}
