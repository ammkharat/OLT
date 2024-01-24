using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkOrderImportDataDao : AbstractManagedDao, IWorkOrderImportDataDao
    {
        private const string INSERT_STORED_PROC = "InsertWorkOrderImportData";
        private const string DELETE_STORED_PROC = "DeleteWorkOrderImportData";
        private const string GET_BATCH_ID = "GetNewSeqVal_PermitRequestLubesImportBatchIdSequence";
        private const string QUERY_BY_BATCH_ID = "QueryWorkOrderImportDataByBatchId";

        private readonly IUserDao userDao;

        public WorkOrderImportDataDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public void Insert(WorkOrderImportData permitRequest)
        {
            SqlCommand command = ManagedCommand;            
            command.Insert(permitRequest, AddInsertParameters, INSERT_STORED_PROC);                                                 
        }

        public void Delete(long batchId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@BatchId", batchId);
            command.ExecuteNonQuery(DELETE_STORED_PROC);
        }

        public long GetBatchId()
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery(GET_BATCH_ID);

            long batchId = (long) idParameter.Value;

            return batchId;
        }

        public List<WorkOrderImportData> QueryByBatchId(long batchId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@BatchId", batchId);
            return command.QueryForListResult<WorkOrderImportData>(PopulateInstance, QUERY_BY_BATCH_ID);
        }

        private void AddInsertParameters(WorkOrderImportData importData, SqlCommand command)
        {           
            command.AddParameter("@BatchId", importData.BatchId);
            command.AddParameter("@ImportDate", importData.ImportDate.CreateDateTime(Time.MIDNIGHT));
            command.AddParameter("@BatchItemCreatedDateTime", importData.BatchItemCreatedDateTime);
            command.AddParameter("@SubmittedByUserId", importData.SubmittedByUser.IdValue);

            command.AddParameter("@ProcessStatus", importData.ProcessStatus);
            command.AddParameter("@WONumber", importData.WONumber);
            command.AddParameter("@ShortText", importData.ShortText);
            command.AddParameter("@FunctionalLocation", importData.FunctionalLocation);
            command.AddParameter("@EquipmentNumber", importData.EquipmentNumber);
            command.AddParameter("@PlantId", importData.PlantId);
            command.AddParameter("@LanguageCode", importData.LanguageCode);
            command.AddParameter("@Priority", importData.Priority);
            command.AddParameter("@PlannerGroup", importData.PlannerGroup);
            command.AddParameter("@OperationKeyNo", importData.OperationKeyNo);
            command.AddParameter("@OperationNumber", importData.OperationNumber);
            command.AddParameter("@Suboperation", importData.Suboperation);
            command.AddParameter("@EarliestStartDate", importData.EarliestStartDate);
            command.AddParameter("@EarliestStartTime", importData.EarliestStartTime);
            command.AddParameter("@EarliestFinishDate", importData.EarliestFinishDate);
            command.AddParameter("@EarliestFinishTime", importData.EarliestFinishTime);
            command.AddParameter("@LongText", importData.LongText);
            command.AddParameter("@WorkPermitType", importData.WorkPermitType);
            command.AddParameter("@WorkPermitAttrib", importData.WorkPermitAttrib);
            command.AddParameter("@WorkCenterID", importData.WorkCenterID);
            command.AddParameter("@WorkCenterName", importData.WorkCenterName);
            command.AddParameter("@WorkCenterText", importData.WorkCenterText);
        }

        private WorkOrderImportData PopulateInstance(SqlDataReader reader)
        {
            long batchId = reader.Get<long>("BatchId");
            DateTime batchCreated = reader.Get<DateTime>("BatchItemCreatedDateTime");
            DateTime importDateTime = reader.Get<DateTime>("ImportDate");

            long userId = reader.Get<long>("SubmittedByUserId");
            User user = userDao.QueryById(userId);            
            
            WorkOrderImportData result = new WorkOrderImportData(batchId, batchCreated, user);

            result.ImportDate = new Date(importDateTime);
            result.ProcessStatus = reader.Get<string>("ProcessStatus");
            result.WONumber = reader.Get<string>("WONumber");            
            result.ShortText = reader.Get<string>("ShortText");
            result.FunctionalLocation = reader.Get<string>("FunctionalLocation");
            result.EquipmentNumber = reader.Get<string>("EquipmentNumber");
            result.PlantId = reader.Get<string>("PlantId");
            result.LanguageCode = reader.Get<string>("LanguageCode");
            result.Priority = reader.Get<string>("Priority");
            result.PlannerGroup = reader.Get<string>("PlannerGroup");
            result.OperationKeyNo = reader.Get<string>("OperationKeyNo");
            result.OperationNumber = reader.Get<string>("OperationNumber");
            result.Suboperation = reader.Get<string>("Suboperation");
            result.EarliestStartDate = reader.Get<string>("EarliestStartDate");
            result.EarliestStartTime = reader.Get<string>("EarliestStartTime");
            result.EarliestFinishDate = reader.Get<string>("EarliestFinishDate");
            result.EarliestFinishTime = reader.Get<string>("EarliestFinishTime");
            result.LongText = reader.Get<string>("LongText");
            result.WorkPermitType = reader.Get<string>("WorkPermitType");
            result.WorkPermitAttrib = reader.Get<string>("WorkPermitAttrib");
            result.WorkCenterID = reader.Get<string>("WorkCenterID");
            result.WorkCenterName = reader.Get<string>("WorkCenterName");
            result.WorkCenterText = reader.Get<string>("WorkCenterText");      

            return result;
        }              
    }
}