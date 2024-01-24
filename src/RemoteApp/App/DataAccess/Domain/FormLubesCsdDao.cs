using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormLubesCsdDao : AbstractManagedDao, IFormLubesCsdDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormLubesCsdById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormLubesCsd";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormLubesCsd";
        private const string INSERT_FORM_APPROVAL = "InsertFormLubesCsdApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormLubesCsdApproval";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormLubesCsd";

        private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_7_DAYS =
            "QueryAllFormLubesCsdThatAreApprovedAndOutOfServiceForMoreThan7Days";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IUserDao userDao;

        public FormLubesCsdDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public LubesCsdForm Insert(LubesCsdForm form)
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
        public LubesCsdForm QueryByIdAndSiteId(long id,long siteid)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE); //ayman disable siteid
        }
        
        
        public LubesCsdForm QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<LubesCsdForm> QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@Now", now);
            return command.QueryForListResult(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_7_DAYS);
        }

        public void Update(LubesCsdForm form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateApprovals(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
        }

        public void Remove(LubesCsdForm form)
        {
            var command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormLubesCsdId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormLubesCsd);
        }

        private void AddUpdateParameters(LubesCsdForm form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateApprovals(SqlCommand command, LubesCsdForm form)
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

        private void InsertApprovals(SqlCommand command, LubesCsdForm form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (var approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    var idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormLubesCsdId", form.Id);
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

        private void AddInsertParameters(LubesCsdForm form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private void SetCommonAttributes(LubesCsdForm form, SqlCommand command)
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
            command.AddParameter("@IsTheCSDForAPressureSafetyValve", form.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("@CriticalSystemDefeated", form.CriticalSystemDefeated);
            command.AddParameter("@HasBeenApproved", form.HasBeenApproved);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
        }

        private LubesCsdForm PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");

            var functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            var location = reader.Get<string>("Location");

            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            var approvals = formApprovalDao.QueryByFormLubesCsdId(id);
            var documentLinks = documentLinkDao.QueryByFormLubesCsdId(id);

            var content = reader.Get<string>("Content");
            var plainTextContent = reader.Get<string>("PlainTextContent");


            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            var isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            var criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
        //  var siteid = reader.Get<long>("SiteId");    //ayman generic forms  disable siteid

            bool hasBeenApproved = reader.Get<bool>("HasBeenApproved");
            var form = new LubesCsdForm(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)   // ayman disable siteid
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
                IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve,
                CriticalSystemDefeated = criticalSystemDefeated
            };

            return form;
        }
    }
}