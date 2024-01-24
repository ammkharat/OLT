using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN1HistoryDao : AbstractManagedDao, IFormGN1HistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN1HistoryById";
        private const string INSERT = "InsertFormGN1History";

        private readonly IUserDao userDao;

        public FormGN1HistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormGN1History> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormGN1History>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormGN1History history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);            
        }

        private void AddInsertParameters(FormGN1History history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);
            command.AddParameter("CSELevel", history.CSELevel);
            command.AddParameter("JobDescription", history.JobDescription);            
            command.AddParameter("FromDateTime", history.ValidFromDateTime);
            command.AddParameter("ToDateTime", history.ValidToDateTime);

            command.AddParameter("PlanningWorksheetPlainTextContent", history.PlanningWorksheetPlainTextContent);
            command.AddParameter("RescuePlanPlainTextContent", history.RescuePlanPlainTextContent);

            command.AddParameter("PlanningWorksheetApprovals", history.PlanningWorksheetApprovals);
            command.AddParameter("RescuePlanApprovals", history.RescuePlanApprovals);
            command.AddParameter("TradeChecklistApprovals", history.TradeChecklistApprovals);

            command.AddParameter("TradeChecklists", history.TradeChecklists);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);                        
        }

        private FormGN1History PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);
            
            string functionalLocation = reader.Get<string>("FunctionalLocation");
            string location = reader.Get<string>("Location");

            string cseLevel = reader.Get<string>("CSELevel");
            string jobDescription = reader.Get<string>("JobDescription");

            DateTime validFromDateTime = reader.Get<DateTime>("FromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ToDateTime");

            string planningWorksheetPlainTextContent = reader.Get<string>("PlanningWorksheetPlainTextContent");
            string rescuePlanPlainTextContent = reader.Get<string>("RescuePlanPlainTextContent");

            string tradeChecklists = reader.Get<string>("TradeChecklists");

            string planningWorksheetApprovals = reader.Get<string>("PlanningWorksheetApprovals");
            string rescuePlanApprovals = reader.Get<string>("RescuePlanApprovals");
            string tradeChecklistApprovals = reader.Get<string>("TradeChecklistApprovals");

            string documentLinks = reader.Get<string>("DocumentLinks");
                        
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
                                   
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
                                    
            return new FormGN1History(id, formStatus, functionalLocation, location, cseLevel, jobDescription, validFromDateTime, validToDateTime, planningWorksheetPlainTextContent, rescuePlanPlainTextContent,
                tradeChecklists, planningWorksheetApprovals, rescuePlanApprovals, tradeChecklistApprovals, documentLinks, lastModifiedBy, lastModifiedDateTime, closedDateTime, approvedDateTime);
        }
    }
}
