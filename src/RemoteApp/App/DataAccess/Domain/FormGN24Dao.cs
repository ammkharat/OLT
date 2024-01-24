using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN24Dao : AbstractManagedDao, IFormGN24Dao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;

        //ayman genric forms
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGN24ByIdAndSiteId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGN24ById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormGN24";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGN24";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGN24";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormGN24FunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormGN24FunctionalLocationsByFormGN24Id";
        private const string INSERT_FORM_APPROVAL = "InsertFormGN24Approval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormGN24Approval";

        public FormGN24Dao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        //ayman generic forms
        public FormGN24 QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN24>(id, siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }
        
        
        public FormGN24 QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN24>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Insert(FormGN24 form)
        {
            SqlCommand command = ManagedCommand;            
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
        }

        public void Update(FormGN24 form)
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

        public void Remove(FormGN24 form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);         
        }

        private FormGN24 PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormGN24Id(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormGN24Id(id);

            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isTheSafeWorkPlanForPSVRemovalOrInstallation = reader.Get<bool>("IsTheSafeWorkPlanForPSVRemovalOrInstallation");
            bool isTheSafeWorkPlanForWorkInTheAlkylationUnit = reader.Get<bool>("IsTheSafeWorkPlanForWorkInTheAlkylationUnit");

            int? alkylationClassId = reader.Get<int?>("AlkylationClass");
            FormGN24AlkylationClass alkylationClass = null;
            if (alkylationClassId != null)
            {
                alkylationClass = FormGN24AlkylationClass.GetById(alkylationClassId.Value);
            }

            string preJobMeetingSignatures = reader.Get<string>("PreJobMeetingSignatures");
            string plainTextPreJobMeetingSignatures = reader.Get<string>("PlainTextPreJobMeetingSignatures");
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGN24Id(id);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            bool isDeleted = reader.Get<bool>("Deleted");
            
            long siteid = reader.Get<long>("SiteId");     //ayman generic forms

            FormGN24 form = new FormGN24(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime,siteid);
            form.FunctionalLocations = functionalLocations;
            form.Approvals = approvals;
            form.LastModifiedBy = lastModifiedBy;
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.ApprovedDateTime = approvedDateTime;
            form.ClosedDateTime = closedDateTime;
            form.Content = content;
            form.PlainTextContent = plainTextContent;
            form.IsTheSafeWorkPlanForPSVRemovalOrInstallation = isTheSafeWorkPlanForPSVRemovalOrInstallation;
            form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit = isTheSafeWorkPlanForWorkInTheAlkylationUnit;
            form.AlkylationClass = alkylationClass;
            form.DocumentLinks = documentLinks;
            form.PreJobMeetingSignatures = preJobMeetingSignatures;
            form.PlainTextPreJobMeetingSignatures = plainTextPreJobMeetingSignatures;
            form.IsDeleted = isDeleted;
            return form;
        }
        

        private static void AddInsertParameters(FormGN24 form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private static void AddUpdateParameters(FormGN24 form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void SetCommonAttributes(FormGN24 form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);

            command.AddParameter("IsTheSafeWorkPlanForPSVRemovalOrInstallation", form.IsTheSafeWorkPlanForPSVRemovalOrInstallation);
            command.AddParameter("IsTheSafeWorkPlanForWorkInTheAlkylationUnit", form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit);
            command.AddParameter("AlkylationClass", form.AlkylationClass == null ? null : form.AlkylationClass.Id);

            command.AddParameter("PreJobMeetingSignatures", form.PreJobMeetingSignatures);
            command.AddParameter("PlainTextPreJobMeetingSignatures", form.PlainTextPreJobMeetingSignatures);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid", form.SiteId);   //ayman generic forms
        }

        private static void InsertFunctionalLocations(SqlCommand command, FormGN24 form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormGN24Id", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        // DATODO: ask Mike: why isn't this done by passing the approval object to an approval dao?
        private void InsertApprovals(SqlCommand command, FormGN24 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN24Id", form.Id);
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

        private void UpdateFunctionalLocations(SqlCommand command, FormGN24 form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormGN24Id", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void UpdateApprovals(SqlCommand command, FormGN24 form)
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

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN24Id);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGN24);
        }
    }
}
