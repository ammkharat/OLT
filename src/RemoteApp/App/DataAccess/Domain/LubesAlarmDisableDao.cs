using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LubesAlarmDisableDao : AbstractManagedDao, ILubesAlarmDisableDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormLubesAlarmDisableById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormLubesAlarmDisable";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormLubesAlarmDisable";
        private const string INSERT_FORM_APPROVAL = "InsertFormLubesAlarmDisableApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormLubesAlarmDisableApproval";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormLubesAlarmDisable";

        private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_7_DAYS =
            "QueryAllFormLubesAlarmDisableThatAreApprovedAndOutOfServiceForMoreThan7Days";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IUserDao userDao;

        public LubesAlarmDisableDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public LubesAlarmDisableForm Insert(LubesAlarmDisableForm form)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return form;
        }

        //ayman generic forms
        public LubesAlarmDisableForm QueryByIdAndSiteId(long id,long siteid)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);  // ayman disable siteid
        }
        
        
        public LubesAlarmDisableForm QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<LubesAlarmDisableForm> QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@Now", now);
            return command.QueryForListResult(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_7_DAYS);
        }

        public void Update(LubesAlarmDisableForm form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateApprovals(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
        }

        public void Remove(LubesAlarmDisableForm form)
        {
            var command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormLubesAlarmDisableId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormLubesAlarmDisable);
        }

        private void AddUpdateParameters(LubesAlarmDisableForm form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateApprovals(SqlCommand command, LubesAlarmDisableForm form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (var approval in form.Approvals)
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
            }
        }

        private void InsertApprovals(SqlCommand command, LubesAlarmDisableForm form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (var approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    var idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormLubesAlarmDisableId", form.Id);
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
            }
        }

        private void AddInsertParameters(LubesAlarmDisableForm form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private void SetCommonAttributes(LubesAlarmDisableForm form, SqlCommand command)
        {
            command.AddParameter("@FunctionalLocationId", form.FunctionalLocation.IdValue);
            command.AddParameter("@Location", form.Location);
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);
            command.AddParameter("@Alarm", form.Alarm);
            command.AddParameter("@Criticality", form.Criticality);
            command.AddParameter("@SapNotification", form.SapNotification);
            command.AddParameter("@HasBeenApproved", form.HasBeenApproved);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
        }

        private LubesAlarmDisableForm PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");

            var functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            var location = reader.Get<string>("Location");

            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            var approvals = formApprovalDao.QueryByFormLubesAlarmDisableId(id);
            var documentLinks = documentLinkDao.QueryByFormLubesAlarmDisableId(id);

            var content = reader.Get<string>("Content");
            var plainTextContent = reader.Get<string>("PlainTextContent");

            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            var alarm = reader.Get<string>("Alarm");
            var criticality = reader.Get<string>("Criticality");
            var sapNotification = reader.Get<string>("SapNotification");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var hasBeenApproved = reader.Get<bool>("HasBeenApproved");

          //  var siteid = reader.Get<long>("SiteId");    //ayman generic forms disable siteid

            var form = new LubesAlarmDisableForm(id, formStatus, validFromDateTime, validToDateTime, createdBy,
                createdDateTime)         //ayman generic forms disable siteid 
            {
                FunctionalLocation = functionalLocation,
                Location = location,
                Approvals = approvals,
                LastModifiedBy = lastModifiedBy,
                DocumentLinks = documentLinks,
                LastModifiedDateTime = lastModifiedDateTime,
                ApprovedDateTime = approvedDateTime,
                HasBeenApproved = hasBeenApproved,
                ClosedDateTime = closedDateTime,
                Content = content,
                PlainTextContent = plainTextContent,
                Alarm = alarm,
                Criticality = criticality,
                SapNotification = sapNotification,
            };

            return form;
        }
    }
}