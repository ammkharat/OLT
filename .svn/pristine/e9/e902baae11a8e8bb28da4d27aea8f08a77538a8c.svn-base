using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDefinitionHistoryDao : AbstractManagedDao, ILogDefinitionHistoryDao
    {
        private const string QUERY_LOG_DEFINITION_HISTORY_BY_ID = "QueryLogDefinitionHistoryById";
        private const string INSERT_STORED_PROC = "InsertLogDefinitionHistory";
        
        private readonly IUserDao userDao;        
        private readonly ILogDefinitionCustomFieldEntryHistoryDao customFieldEntryHistoryDao;

        public LogDefinitionHistoryDao()
        {            
            userDao = DaoRegistry.GetDao<IUserDao>();            
            customFieldEntryHistoryDao = DaoRegistry.GetDao<ILogDefinitionCustomFieldEntryHistoryDao>();
        }

        public List<LogDefinitionHistory> QueryByLogDefinitionId(long logDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", logDefinitionId);
            return command.QueryForListResult<LogDefinitionHistory>(PopulateInstance, QUERY_LOG_DEFINITION_HISTORY_BY_ID);
        }

        public void Insert(LogDefinitionHistory history)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.Parameters.Add("@LogDefinitionHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.AddParameter("@Id", history.IdValue);
            command.AddParameter("@PlainTextComments", history.PlainTextComments);
            command.AddParameter("@LastModifiedUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("@Schedule", history.Schedule);
            command.AddParameter("@FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@InspectionFollowUp", history.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", history.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", history.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", history.SupervisionFollowUp);
            command.AddParameter("@EnvironmentalHealthSafetyFollowUp", history.EnvironmentalHealthSafetyFollowUp);
            command.AddParameter("@OtherFollowUp", history.OtherFollowUp);
            command.AddParameter("@Deleted", history.Deleted);
            command.AddParameter("@Active", history.Active);

            command.ExecuteNonQuery(INSERT_STORED_PROC);

            long historyId = (long)idParameter.Value;
            
            InsertCustomFieldHistories(historyId, history.CustomFieldEntries);
        }

        private void InsertCustomFieldHistories(long historyId, List<CustomFieldEntryHistory> customFieldEntryHistories)
        {
            customFieldEntryHistories.ForEach(history => history.HistoryId = historyId);
            customFieldEntryHistoryDao.Insert(customFieldEntryHistories);
        }
       
        private LogDefinitionHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string plainTextComments = reader.Get<string>("PlainTextComments");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            string schedule = reader.Get<string>("Schedule");
            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string documentLinks = reader.Get<string>("DocumentLinks");
            bool inspectionFollowUp = reader.Get<bool>("InspectionFollowUp");
            bool processControlFollowUp = reader.Get<bool>("ProcessControlFollowUp");
            bool operationsFollowUp = reader.Get<bool>("OperationsFollowUp");
            bool supervisionFollowUp = reader.Get<bool>("SupervisionFollowUp");
            bool environmentalHealthSafetyFollowUp = reader.Get<bool>("EnvironmentalHealthSafetyFollowUp");
            bool otherFollowUp = reader.Get<bool>("OtherFollowUp");
            bool deleted = reader.Get<bool>("Deleted");
            bool active = reader.Get<bool>("Active");
            
            List<CustomFieldEntryHistory> entryHistories = customFieldEntryHistoryDao.GetByHistoryId(reader.Get<long>("LogDefinitionHistoryId"));

            LogDefinitionHistory history = new LogDefinitionHistory(
                id, 
                lastModifiedDateTime, 
                lastModifiedUser, 
                schedule,
                functionalLocations, 
                documentLinks, 
                inspectionFollowUp, 
                processControlFollowUp,
                operationsFollowUp, 
                supervisionFollowUp, 
                environmentalHealthSafetyFollowUp,
                otherFollowUp,
                deleted,
                plainTextComments,
                active,
                entryHistories);

            return history;
        }
    }
}