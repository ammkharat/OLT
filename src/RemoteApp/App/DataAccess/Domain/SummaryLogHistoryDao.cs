using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SummaryLogHistoryDao : AbstractManagedDao, ISummaryLogHistoryDao
    {
        private readonly IUserDao userDao;        
        private readonly ISummaryLogCustomFieldEntryHistoryDao customFieldEntryHistoryDao;

        public SummaryLogHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
            customFieldEntryHistoryDao = DaoRegistry.GetDao<ISummaryLogCustomFieldEntryHistoryDao>();
        }

        public List<SummaryLogHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<SummaryLogHistory>(PopulateInstance , "QuerySummaryLogHistoriesById");
        }

        public void Insert(SummaryLogHistory logHistory)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.Parameters.Add("@SummaryLogHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(logHistory, AddInsertParameters, "InsertSummaryLogHistory");

            long historyId = (long)idParameter.Value;            
            InsertCustomFieldHistories(historyId, logHistory.CustomFieldEntryHistories);
        }

        private void InsertCustomFieldHistories(long historyId, List<CustomFieldEntryHistory> customFieldEntryHistories)
        {
            customFieldEntryHistories.ForEach(history => history.HistoryId = historyId);
            customFieldEntryHistoryDao.Insert(customFieldEntryHistories);
        }
        
        private SummaryLogHistory PopulateInstance(SqlDataReader reader)
        {
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            
            List<CustomFieldEntryHistory> entryHistories = customFieldEntryHistoryDao.GetByHistoryId(reader.Get<long>("SummaryLogHistoryId"));            

            var logHistory = new SummaryLogHistory(reader.Get<long>("Id"),
                                            reader.Get<string>("FunctionalLocations"),
                                            reader.Get<bool>("InspectionFollowUp"),
                                            reader.Get<bool>("ProcessControlFollowUp"),
                                            reader.Get<bool>("OperationsFollowUp"),
                                            reader.Get<bool>("SupervisionFollowUp"),
                                            reader.Get<bool>("EHSFollowup"),
                                            reader.Get<bool>("OtherFollowUp"),
                                            reader.Get<DateTime>("LogDateTime"),
                                            lastModifiedUser,
                                            reader.Get<DateTime>("LastModifiedDateTime"),
                                            reader.Get<string>("DocumentLinks"),
                                            reader.Get<string>("PlainTextComments"), 
                                            reader.Get<string>("DorComments"), 
                                            entryHistories);

            return logHistory;
        }

        private static void AddInsertParameters(SummaryLogHistory logHistory, SqlCommand command)
        {
            command.AddParameter("@Id", logHistory.Id);
            command.AddParameter("@FunctionalLocations", logHistory.FunctionalLocations);
            command.AddParameter("@InspectionFollowUp", logHistory.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", logHistory.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", logHistory.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", logHistory.SupervisionFollowUp);
            command.AddParameter("@EHSFollowup", logHistory.EnvironmentalHealthSafetyFollowUp);
            command.AddParameter("@OtherFollowUp", logHistory.OtherFollowUp);
            command.AddParameter("@LogDateTime", logHistory.LogDateTime);
            command.AddParameter("@LastModifiedUserId", logHistory.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", logHistory.LastModifiedDate);
            command.AddParameter("@DocumentLinks", logHistory.DocumentLinks);
            command.AddParameter("@PlainTextComments", logHistory.PlainTextComments);
            command.AddParameter("@DorComments", logHistory.DorComments);
        }
    }
}