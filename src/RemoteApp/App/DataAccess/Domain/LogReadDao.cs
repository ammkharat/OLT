using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogReadDao : AbstractManagedDao, ILogReadDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertLogRead";
        private const string QUERY_USERS_THAT_MARKED_LOG_AS_READ = "QueryUsersMarkedLogAsRead";
        private const string QUERY_USER_ALREADY_MARKED_LOG_AS_READ = "QueryUserMarkedLogAsRead";

        public LogRead Insert(LogRead logToInsert)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(logToInsert, AddInsertParameters, INSERT_STORED_PROCEDURE);
            return logToInsert;
        }

        public List<ItemReadBy> UsersThatMarkedLogAsRead(long logId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogId", logId);
            return command.QueryForListResult < ItemReadBy>(PopulateReadByInstance, QUERY_USERS_THAT_MARKED_LOG_AS_READ);
        }

        public LogRead UserMarkedLogAsRead(long logId, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogId", logId);
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<LogRead>(PopulateInstance, QUERY_USER_ALREADY_MARKED_LOG_AS_READ);
        }

        private static ItemReadBy PopulateReadByInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string userName = reader.Get<string>("Username");
            DateTime dateTime = reader.Get<DateTime>("DateTime");
            return new ItemReadBy(User.ToFullNameWithUserName(lastName, firstName, userName), dateTime);
        }

        private static LogRead PopulateInstance(SqlDataReader reader)
        {
            long logId = reader.Get<long>("LogId");
            long userId = reader.Get<long>("UserId");
            DateTime dateTime = reader.Get<DateTime>("DateTime");

            return new LogRead(logId, userId, dateTime);
        }

        private static void AddInsertParameters(LogRead logRead, SqlCommand command)
        {
            command.AddParameter("@UserId", logRead.ReadByUserId);
            command.AddParameter("@LogId", logRead.LogId);
            command.AddParameter("@DateTime", logRead.Time);
        }

    }
}
