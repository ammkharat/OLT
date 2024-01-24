using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN7Dao : AbstractManagedDao, IFormGN7Dao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;

        //ayman generic forms
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGN7ByIdAndSiteId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGN7ById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormGN7";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGN7";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGN7";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormGN7FunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormGN7FunctionalLocationsByFormGN7Id";
        private const string INSERT_FORM_APPROVAL = "InsertFormGN7Approval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormGN7Approval";

        public FormGN7Dao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
        }

        //ayman generic forms
        public FormGN7 QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN7>(id,siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }

        public FormGN7 QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN7>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public FormGN7 Insert(FormGN7 form)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            return form;
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGN7);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN7Id);
        }

        public void Update(FormGN7 form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            UpdateApprovals(command, form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        public void Remove(FormGN7 form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private FormGN7 PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormGN7Id(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormGN7Id(id);
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGN7Id(id);

            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            long siteid = reader.Get<long>("SiteId");                //ayman generic forms


            FormGN7 formGN7 = new FormGN7(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime, siteid);     //ayman generic forms
            bool deleted = reader.Get<bool>("Deleted");
            formGN7.FunctionalLocations = functionalLocations;
            formGN7.IsDeleted = deleted;
            formGN7.Approvals = approvals;
            formGN7.LastModifiedBy = lastModifiedBy;
            formGN7.LastModifiedDateTime = lastModifiedDateTime;
            formGN7.DocumentLinks = documentLinks;
            formGN7.ApprovedDateTime = approvedDateTime;
            formGN7.ClosedDateTime = closedDateTime;
            formGN7.Content = content;
            formGN7.PlainTextContent = plainTextContent;
            
            return formGN7;
        }

        
        private static void AddInsertParameters(FormGN7 form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private static void AddUpdateParameters(FormGN7 form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void SetCommonAttributes(FormGN7 form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid", form.SiteId);
        }

        private static void InsertFunctionalLocations(SqlCommand command, FormGN7 form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormGN7Id", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertApprovals(SqlCommand command, FormGN7 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN7Id", form.Id);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ApprovedByUserId",
                        approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        private void UpdateFunctionalLocations(SqlCommand command, FormGN7 form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormGN7Id", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void UpdateApprovals(SqlCommand command, FormGN7 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId",
                        approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}