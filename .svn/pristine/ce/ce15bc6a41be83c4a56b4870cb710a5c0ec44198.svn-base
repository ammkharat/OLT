using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility.Comparer;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN1Dao : AbstractManagedDao, IFormGN1Dao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertFormGN1";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGN1";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGN1ById";

        //ayman generic forms
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGN1ByIdAndSiteId";

        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGN1";
        private const string INSERT_PLANNING_WORKSHEET_APPROVAL = "InsertFormGN1PlanningWorksheetApproval";
        private const string INSERT_RESCUE_PLAN_APPROVAL = "InsertFormGN1RescuePlanApproval";
        private const string UPDATE_PLANNING_WORKSHEET_APPROVAL = "UpdateFormGN1PlanningWorksheetApproval";
        private const string UPDATE_RESCUE_PLAN_APPROVAL = "UpdateFormGN1RescuePlanApproval";

        private readonly IDocumentLinkDao documentLinkDao;

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly ITradeChecklistDao tradeChecklistDao;

        public FormGN1Dao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            tradeChecklistDao = DaoRegistry.GetDao<ITradeChecklistDao>();
        }

        public void Insert(FormGN1 form)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertPlanningWorksheetApprovals(command, form);
            InsertRescuePlanApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            InsertTradeChecklists(form);
        }

        //ayman generic forms
        public FormGN1 QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN1>(id, siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }
        
        public FormGN1 QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN1>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Update(FormGN1 form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            DeleteTradeChecklists(form);
            InsertTradeChecklists(form);
            UpdateTradeChecklists(form.TradeChecklists.FindAll(tc => tc.IsInDatabase()));

            UpdatePlanningWorksheetApprovals(command, form);
            UpdateRescuePlanApprovals(command, form);

            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }


        // Watch out - we were originally deleteing and inserting these but then history doesn't work because it inserts them with new IDs.
        // I guess we could update history every time but it's just getting weird. I think this is is better. We did the delete/insert method to 
        // help caching work properly but at this point caching is turned off for other reasons.
        private void UpdateTradeChecklists(List<TradeChecklist> tradeChecklistsToUpdate)
        {
            tradeChecklistsToUpdate.ForEach(tradeChecklistDao.Update);
        }

        private void SoftDeleteTradeChecklists(IEnumerable<TradeChecklist> tradeChecklistRemovalList)
        {
            foreach (TradeChecklist tradeChecklist in tradeChecklistRemovalList)
            {
                tradeChecklistDao.Remove(tradeChecklist);
            }
        }

        private void DeleteTradeChecklists(FormGN1 form)
        {
            // get the current list, and remove all that aren't in the current repreentation of the form.
            FormGN1 oldVersionOfFormGN1 = QueryById(form.IdValue);
            List<TradeChecklist> oldTradeCheckLists = oldVersionOfFormGN1.TradeChecklists;
            IEnumerable<TradeChecklist> tradeListsToRemove = oldTradeCheckLists.Except(form.TradeChecklists,
                new DomainObjectIdEqualityComparer<TradeChecklist>());
            SoftDeleteTradeChecklists(tradeListsToRemove);
        }

        public void Remove(FormGN1 form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
            SoftDeleteTradeChecklists(form.TradeChecklists);
        }

        public int? GetMaxTradeChecklistSequenceNumber(long formGNId)
        {
            return tradeChecklistDao.GetMaxSequenceNumber(formGNId);
        }

        private static void AddUpdateParameters(FormGN1 form, SqlCommand command)
        {
            command.AddParameter("@Id", form.IdValue);
            SetCommonAttributes(form, command);
        }

        private static void AddInsertParameters(FormGN1 form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private static void SetCommonAttributes(FormGN1 form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.IdValue);
            command.AddParameter("@FunctionalLocationId", form.FunctionalLocation.IdValue);
            command.AddParameter("@TradeChecklistNames",
                form.TradeChecklists.Distinct(TradeChecklist.TradeComparer)
                    .ToList()
                    .ConvertAll(input => input.Trade)
                    .ToCommaSeparatedString());
            command.AddParameter("@Location", form.Location);
            command.AddParameter("@CSELevel", form.CSELevel);
            command.AddParameter("@JobDescription", form.JobDescription);
            command.AddParameter("@FromDateTime", form.FromDateTime);
            command.AddParameter("@ToDateTime", form.ToDateTime);
            command.AddParameter("@PlanningWorksheetContent", form.PlanningWorksheetContent);
            command.AddParameter("@PlanningWorksheetPlainTextContent", form.PlanningWorksheetPlainTextContent);
            command.AddParameter("@RescuePlanContent", form.RescuePlanContent);
            command.AddParameter("@RescuePlanPlainTextContent", form.RescuePlanPlainTextContent);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid",form.SiteId);    // ayman generic forms
        }

        private FormGN1 PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            
            //ayman generic forms
            long siteid = reader.Get<long>("SiteId");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FunctionalLocation functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string location = reader.Get<string>("Location");

            string cseLevel = reader.Get<string>("CSELevel");
            string jobDescription = reader.Get<string>("JobDescription");

            string planningWorksheetContent = reader.Get<string>("PlanningWorksheetContent");
            string planningWorksheetPlainTextContent = reader.Get<string>("PlanningWorksheetPlainTextContent");

            string rescuePlanContent = reader.Get<string>("RescuePlanContent");
            string rescuePlanPlainTextContent = reader.Get<string>("RescuePlanPlainTextContent");

            DateTime fromDateTime = reader.Get<DateTime>("FromDateTime");
            DateTime toDateTime = reader.Get<DateTime>("ToDateTime");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            List<FormApproval> planningWorksheetApprovals =
                formApprovalDao.QueryPlanningWorksheetApprovalsByFormGN1Id(id);
            List<FormApproval> rescuePlanApprovals = formApprovalDao.QueryRescuePlanApprovalsByFormGN1Id(id);

            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGN1Id(id);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            bool deleted = reader.Get<bool>("Deleted");

            List<TradeChecklist> tradeChecklists = tradeChecklistDao.QueryByGN1Id(id);

            string tradeChecklistNames = reader.Get<String>("TradeChecklistNames");
            
            FormGN1 form = new FormGN1(id, formStatus, functionalLocation, cseLevel, fromDateTime, toDateTime, createdBy,
                createdDateTime,siteid)   //ayman generic forms
            {
                JobDescription = jobDescription,
                Location = location,
                TradeChecklistNames = tradeChecklistNames,
                PlanningWorksheetContent = planningWorksheetContent,
                PlanningWorksheetPlainTextContent = planningWorksheetPlainTextContent,
                RescuePlanContent = rescuePlanContent,
                RescuePlanPlainTextContent = rescuePlanPlainTextContent,
                ApprovedDateTime = approvedDateTime,
                ClosedDateTime = closedDateTime,
                PlanningWorksheetApprovals = planningWorksheetApprovals,
                RescuePlanApprovals = rescuePlanApprovals,
                DocumentLinks = documentLinks,
                LastModifiedBy = lastModifiedBy,
                LastModifiedDateTime = lastModifiedDateTime,
                IsDeleted = deleted,
                TradeChecklists = tradeChecklists
            };

            return form;
        }
        
        private void InsertPlanningWorksheetApprovals(SqlCommand command, FormGN1 form)
        {
            if (!form.PlanningWorksheetApprovals.IsEmpty())
            {
                command.CommandText = INSERT_PLANNING_WORKSHEET_APPROVAL;
                foreach (FormApproval approval in form.PlanningWorksheetApprovals)
                {
                    ExecuteInsertApprovalQuery(command, form, approval);
                }
            }
        }

        private void InsertRescuePlanApprovals(SqlCommand command, FormGN1 form)
        {
            if (!form.RescuePlanApprovals.IsEmpty())
            {
                command.CommandText = INSERT_RESCUE_PLAN_APPROVAL;
                foreach (FormApproval approval in form.RescuePlanApprovals)
                {
                    ExecuteInsertApprovalQuery(command, form, approval);
                }
            }
        }

        private static void ExecuteInsertApprovalQuery(SqlCommand command, FormGN1 form, FormApproval approval)
        {
            command.Parameters.Clear();
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@FormGN1Id", form.Id);
            command.AddParameter("@Approver", approval.Approver);
            command.AddParameter("@ApprovedByUserId",
                approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
            command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
            command.AddParameter("@DisplayOrder", approval.DisplayOrder);
            command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
            command.AddParameter("@Enabled", approval.Enabled);
            command.ExecuteNonQuery();
            approval.Id = long.Parse(idParameter.Value.ToString());
        }

        private void UpdatePlanningWorksheetApprovals(SqlCommand command, FormGN1 form)
        {
            if (!form.PlanningWorksheetApprovals.IsEmpty())
            {
                command.CommandText = UPDATE_PLANNING_WORKSHEET_APPROVAL;
                foreach (FormApproval approval in form.PlanningWorksheetApprovals)
                {
                    ExecuteUpdateApprovalQuery(command, approval);
                }
            }
        }

        private void UpdateRescuePlanApprovals(SqlCommand command, FormGN1 form)
        {
            if (!form.RescuePlanApprovals.IsEmpty())
            {
                command.CommandText = UPDATE_RESCUE_PLAN_APPROVAL;
                foreach (FormApproval approval in form.RescuePlanApprovals)
                {
                    ExecuteUpdateApprovalQuery(command, approval);
                }
            }
        }

        private static void ExecuteUpdateApprovalQuery(SqlCommand command, FormApproval approval)
        {
            command.Parameters.Clear();
            command.AddParameter("@Id", approval.Id);
            command.AddParameter("@ApprovedByUserId",
                approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
            command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
            command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
            command.AddParameter("@Enabled", approval.Enabled);
            command.ExecuteNonQuery();
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGN1);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN1Id);
        }

        private void InsertTradeChecklists(FormGN1 form)
        {
            List<TradeChecklist> tradeChecklistsToInsert = form.TradeChecklists.FindAll(tc => !tc.IsInDatabase());

            foreach (TradeChecklist tradeChecklist in tradeChecklistsToInsert)
            {
                tradeChecklist.ParentFormNumber = form.IdValue;
                tradeChecklistDao.Insert(tradeChecklist);
            }
        }
    }
}