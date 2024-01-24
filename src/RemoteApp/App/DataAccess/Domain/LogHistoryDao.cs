using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogHistoryDao : AbstractManagedDao, ILogHistoryDao
    {
        private readonly IUserDao userDao;        
        private readonly ILogCustomFieldEntryHistoryDao customFieldEntryHistoryDao;

        public LogHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
            customFieldEntryHistoryDao = DaoRegistry.GetDao<ILogCustomFieldEntryHistoryDao>();
        }

        public List<LogHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<LogHistory>(PopulateInstance, "QueryLogHistoriesById");
        }

        public void Insert(LogHistory logHistory)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.Parameters.Add("@LogHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(logHistory, AddInsertParameters, "InsertLogHistory");

            long historyId = (long)idParameter.Value;            
            InsertCustomFieldHistories(historyId, logHistory.CustomFieldEntryHistories);
        }

        private void InsertCustomFieldHistories(long historyId, List<CustomFieldEntryHistory> customFieldEntryHistories)
        {
            customFieldEntryHistories.ForEach(history => history.HistoryId = historyId);
            customFieldEntryHistoryDao.Insert(customFieldEntryHistories);
        }
       
        private LogHistory PopulateInstance(SqlDataReader reader)
        {
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            bool isOperatingEngineerLog = reader.Get<bool>("IsOperatingEngineerLog");

            long logId = reader.Get<long>("Id");

            List<CustomFieldEntryHistory> entryHistories = customFieldEntryHistoryDao.GetByHistoryId(reader.Get<long>("LogHistoryId"));
            
            LogHistory logHistory = new LogHistory(logId,
                                            reader.Get<string>("FunctionalLocations"),
                                            reader.Get<bool>("InspectionFollowUp"),
                                            reader.Get<bool>("ProcessControlFollowUp"),
                                            reader.Get<bool>("OperationsFollowUp"),
                                            reader.Get<bool>("SupervisionFollowUp"),
                                            reader.Get<bool>("EHSFollowup"),
                                            reader.Get<bool>("OtherFollowUp"),
                                            lastModifiedUser,
                                            reader.Get<DateTime>("LastModifiedDateTime"),
                                            isOperatingEngineerLog,
                                            reader.Get<string>("DocumentLinks"),
                                            reader.Get<bool>("RecommendForShiftSummary"),
                                            reader.Get<string>("PlainTextComments"), 
                                            reader.Get<DateTime?>("ActualLoggedDateTime"),
                                            entryHistories);

            return logHistory;
        }

        private static void AddInsertParameters(LogHistory logHistory, SqlCommand command)
        {
            command.AddParameter("@Id", logHistory.Id);
            command.AddParameter("@FunctionalLocations", logHistory.FunctionalLocations);
            command.AddParameter("@InspectionFollowUp", logHistory.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", logHistory.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", logHistory.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", logHistory.SupervisionFollowUp);
            command.AddParameter("@EHSFollowup", logHistory.EnvironmentalHealthSafetyFollowUp);
            command.AddParameter("@OtherFollowUp", logHistory.OtherFollowUp);
            command.AddParameter("@LastModifiedUserId", logHistory.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", logHistory.LastModifiedDate);
            command.AddParameter("@IsOperatingEngineerLog", logHistory.IsOperatingEngineerLog);
            command.AddParameter("@DocumentLinks", logHistory.DocumentLinks);
            command.AddParameter("@RecommendForShiftSummary", logHistory.RecommendForShiftSummary);
            command.AddParameter("@ActualLoggedDateTime", logHistory.ActualLoggedDateTime);
            command.AddParameter("@PlainTextComments", logHistory.PlainTextComments);
        }
    }
}