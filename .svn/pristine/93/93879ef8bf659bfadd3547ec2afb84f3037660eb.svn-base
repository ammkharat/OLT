using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75ADao : AbstractManagedDao, IFormGN75ADao
    {
        //ayman generic forms
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGN75AByIdAndSiteId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGN75AById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormGN75A";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGN75A";
        private const string INSERT_FORM_APPROVAL = "InsertFormGN75AApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormGN75AApproval";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;

        public FormGN75ADao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        //ayman generic forms
        public FormGN75A QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN75A>(id, siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }

        public FormGN75A QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN75A>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Insert(FormGN75A form)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());            
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        private FormGN75A PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime fromDateTime = reader.Get<DateTime>("FromDateTime");
            DateTime toDateTime = reader.Get<DateTime>("ToDateTime");

            FunctionalLocation functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            List<FormApproval> approvals = formApprovalDao.QueryByFormGN75AId(id);

            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGN75AId(id);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long siteid = reader.Get<long>("SiteId");           //ayman generic forms


            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long? formGn75BId = reader.Get<long?>("AssociatedFormGN75BId");
            
            bool deleted = reader.Get<bool>("Deleted");

            FormGN75A form = new FormGN75A(id, formStatus, fromDateTime, toDateTime, createdBy, createdDateTime, siteid)        //ayman generic forms
            {
                AssociatedFormGN75BNumber = formGn75BId,
                FunctionalLocation = functionalLocation,
                Approvals = approvals,
                LastModifiedBy = lastModifiedBy,
                LastModifiedDateTime = lastModifiedDateTime,
                ApprovedDateTime = approvedDateTime,
                ClosedDateTime = closedDateTime,
                Content = content,
                PlainTextContent = plainTextContent,
                DocumentLinks = documentLinks,
                IsDeleted = deleted
            };

            return form;
        }

        private void InsertApprovals(SqlCommand command, FormGN75A form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN75AId", form.Id);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        private void UpdateApprovals(SqlCommand command, FormGN75A form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(FormGN75A form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);            
            UpdateApprovals(command, form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        public void Remove(FormGN75A form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form.IdValue, "RemoveFormGN75A");            
        }

        private static void AddInsertParameters(FormGN75A form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private static void AddUpdateParameters(FormGN75A form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void SetCommonAttributes(FormGN75A form, SqlCommand command)
        {
            command.AddParameter("@AssociatedFormGN75BId", form.AssociatedFormGN75BNumber);
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@FunctionalLocationId", form.FunctionalLocation.Id);
            command.AddParameter("@FromDateTime", form.FromDateTime);
            command.AddParameter("@ToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid",form.SiteId);    //ayman generic forms
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN75AId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGN75A);
        }
    }
}
