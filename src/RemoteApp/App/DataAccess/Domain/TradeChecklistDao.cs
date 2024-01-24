using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TradeChecklistDao : AbstractManagedDao, ITradeChecklistDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertTradeChecklist";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTradeChecklist";
        private const string QUERY_BY_FORMGN1ID_STORED_PROCEDURE = "QueryTradeChecklistByFormGN1Id";        
        private const string DELETE_BY_GN1_ID_STORED_PROCEDURE = "DeleteTradeChecklistsByFormGN1Id";
        private const string REMOVE_STORED_PROCEDURE = "RemoveTradeChecklist";
        private const string NEXT_SEQ_NUM_STORED_PROCEDURE = "GetMaxTradeChecklistSequenceNumberForFormGN1Id";

        private readonly IUserDao userDao;

        public TradeChecklistDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public void Insert(TradeChecklist tradeChecklist)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(tradeChecklist, AddInsertParameters, INSERT_STORED_PROCEDURE);
            tradeChecklist.Id = long.Parse(idParameter.Value.ToString());            
        }

        public List<TradeChecklist> QueryByGN1Id(long formGN1Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", formGN1Id);
            return command.QueryForListResult<TradeChecklist>(PopulateInstance, QUERY_BY_FORMGN1ID_STORED_PROCEDURE);
        }

        public void Update(TradeChecklist tradeChecklist)
        {
            SqlCommand command = ManagedCommand;            
            command.Update(tradeChecklist, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }     

        public void Remove(TradeChecklist tradeChecklist)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(tradeChecklist.IdValue, REMOVE_STORED_PROCEDURE);
        }

        public int? GetMaxSequenceNumber(long formGN1Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", formGN1Id);
            return command.QueryForSingleResult<int?>(PopulateIntResult, NEXT_SEQ_NUM_STORED_PROCEDURE);
        }

        private int? PopulateIntResult(SqlDataReader reader)
        {
            return reader.Get<int?>("MaxSequenceNumber");            
        }

        public void DeleteByFormGN1Id(long formGN1Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", formGN1Id);
            command.ExecuteNonQuery(DELETE_BY_GN1_ID_STORED_PROCEDURE);            
        }

        private static void AddUpdateParameters(TradeChecklist tradeChecklist, SqlCommand command)
        {
            command.AddParameter("@Id", tradeChecklist.IdValue);
            SetCommonAttributes(tradeChecklist, command);
        }

        private static void AddInsertParameters(TradeChecklist tradeChecklist, SqlCommand command)
        {
            command.AddParameter("@FormGN1Id", tradeChecklist.ParentFormNumber);
            command.AddParameter("@SequenceNumber", tradeChecklist.SequenceNumber);
            SetCommonAttributes(tradeChecklist, command);
        }

        private static void SetCommonAttributes(TradeChecklist tradeChecklist, SqlCommand command)
        {            
            command.AddParameter("@Trade", tradeChecklist.Trade);
            command.AddParameter("@Content", tradeChecklist.Content);
            command.AddParameter("@PlainTextContent", tradeChecklist.PlainTextContent);

            command.AddParameter("@ConstFieldMaintCoordApproval", tradeChecklist.ConstFieldMaintCoordApproval);
            command.AddParameter("@OpsCoordApproval", tradeChecklist.OpsCoordApproval);
            command.AddParameter("@AreaManagerApproval", tradeChecklist.AreaManagerApproval);       

            command.AddParameter("@ConstFieldMaintCoordApprovalLastModifiedId", tradeChecklist.ConstFieldMaintCoordApprover != null ? tradeChecklist.ConstFieldMaintCoordApprover.Id : null);
            command.AddParameter("@OpsCoordApprovalLastModifiedId", tradeChecklist.OpsCoordApprover != null ? tradeChecklist.OpsCoordApprover.Id : null);
            command.AddParameter("@AreaManagerApprovalLastModifiedId", tradeChecklist.AreaManagerApprover != null ? tradeChecklist.AreaManagerApprover.Id : null);

            command.AddParameter("@ConstFieldMaintCoordApprovalDateTime", tradeChecklist.ConstFieldMaintCoordApprovalDateTime);
            command.AddParameter("@OpsCoordApprovalDateTime", tradeChecklist.OpsCoordApprovalDateTime);
            command.AddParameter("@AreaManagerApprovalDateTime", tradeChecklist.AreaManagerApprovalDateTime);       
            
            command.AddParameter("@LastModifiedByUserId", tradeChecklist.LastModifiedUser.IdValue);
            command.AddParameter("@LastModifiedDateTime", tradeChecklist.LastModifiedDateTime);
        }

        private TradeChecklist PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int sequenceNumber = reader.Get<int>("SequenceNumber");
            string trade = reader.Get<string>("Trade");

            bool constFieldMaintCoordApproval = reader.Get<bool>("ConstFieldMaintCoordApproval");
            bool opsCoordApproval = reader.Get<bool>("OpsCoordApproval");
            bool areaManagerApproval = reader.Get<bool>("AreaManagerApproval");

            long? constFieldMaintCoordApprovalLastModifiedId = reader.Get<long?>("ConstFieldMaintCoordApprovalLastModifiedId");
            long? opsCoordApprovalLastModifiedId = reader.Get<long?>("OpsCoordApprovalLastModifiedId");
            long? areaManagerApprovalLastModifiedId = reader.Get<long?>("AreaManagerApprovalLastModifiedId");

            User constFieldApprover = constFieldMaintCoordApprovalLastModifiedId != null ? userDao.QueryById(constFieldMaintCoordApprovalLastModifiedId.Value) : null;
            User opsCoordApprover = opsCoordApprovalLastModifiedId != null ? userDao.QueryById(opsCoordApprovalLastModifiedId.Value) : null;
            User areaManagerApprover = areaManagerApprovalLastModifiedId != null ? userDao.QueryById(areaManagerApprovalLastModifiedId.Value) : null;

            DateTime? constFieldApprovalDateTime = reader.Get<DateTime?>("ConstFieldMaintCoordApprovalDateTime");
            DateTime? opsCoordApprovalDateTime = reader.Get<DateTime?>("OpsCoordApprovalDateTime");
            DateTime? areaManagerApprovalDateTime = reader.Get<DateTime?>("AreaManagerApprovalDateTime");

            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            User lastModifiedUser = userDao.QueryById(lastModifiedByUserId);

            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            long formGN1Id = reader.Get<long>("FormGN1Id");

            TradeChecklist tradeChecklist = new TradeChecklist
            {
                Id = id,
                ParentFormNumber = formGN1Id,
                SequenceNumber = sequenceNumber,
                Trade = trade,
                Content = content,
                PlainTextContent = plainTextContent
            };

            tradeChecklist.SetConstFieldMaintApproval(constFieldMaintCoordApproval, constFieldApprover, constFieldApprovalDateTime);
            tradeChecklist.SetOpsCoordApproval(opsCoordApproval, opsCoordApprover, opsCoordApprovalDateTime);
            tradeChecklist.SetAreaManagerApproval(areaManagerApproval, areaManagerApprover, areaManagerApprovalDateTime);
           
            tradeChecklist.LastModifiedUser = lastModifiedUser;
            tradeChecklist.LastModifiedDateTime = lastModifiedDateTime;
                      
            return tradeChecklist;
        }
    }
}
