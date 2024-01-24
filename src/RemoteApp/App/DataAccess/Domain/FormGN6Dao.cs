using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN6Dao : AbstractManagedDao, IFormGN6Dao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFormTemplateDao formTemplateDao;
        
        //ayman generic forms
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGN6ByIdAndSiteId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGN6ById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormGN6";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGN6";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGN6";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormGN6FunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormGN6FunctionalLocationsByFormGN6Id";
        private const string INSERT_FORM_APPROVAL = "InsertFormGN6Approval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormGN6Approval";

        public FormGN6Dao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            formTemplateDao = DaoRegistry.GetDao<IFormTemplateDao>();
        }

        //ayman generic forms
        public FormGN6 QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN6>(id,siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }
        
        
        public FormGN6 QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN6>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public string WorkersResponsibilitiesTemplateText()
        {
            var workerResponsiblitiesTemplateId = GetWorkerResponsiblitiesTemplateId();
            var formTemplate = formTemplateDao.QueryById(workerResponsiblitiesTemplateId);
            var workerResponsibiltiesTemplateText = formTemplate.Template;
            return workerResponsibiltiesTemplateText;
        }

        public void Insert(FormGN6 form)
        {
            long workerResponsiblitiesTemplateId = GetWorkerResponsiblitiesTemplateId();
            
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@WorkerResponsiblitiesTemplateId", workerResponsiblitiesTemplateId);

            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        public void Update(FormGN6 form)
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

        public void Remove(FormGN6 form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);         
        }

        private FormGN6 PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormGN6Id(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormGN6Id(id);

            string jobDescription = reader.Get<string>("JobDescription");
            string reasonForCriticalLift = reader.Get<string>("ReasonForCriticalLift");

            string section1Content = reader.Get<string>("Section1Content");
            string section1PlainTextContent = reader.Get<string>("Section1PlainTextContent");
            bool section1NotApplicableToJob = reader.Get<bool>("Section1NotApplicableToJob");

            string section2Content = reader.Get<string>("Section2Content");
            string section2PlainTextContent = reader.Get<string>("Section2PlainTextContent");
            bool section2NotApplicableToJob = reader.Get<bool>("Section2NotApplicableToJob");

            string section3Content = reader.Get<string>("Section3Content");
            string section3PlainTextContent = reader.Get<string>("Section3PlainTextContent");
            bool section3NotApplicableToJob = reader.Get<bool>("Section3NotApplicableToJob");

            string section4Content = reader.Get<string>("Section4Content");
            string section4PlainTextContent = reader.Get<string>("Section4PlainTextContent");
            bool section4NotApplicableToJob = reader.Get<bool>("Section4NotApplicableToJob");

            string section5Content = reader.Get<string>("Section5Content");
            string section5PlainTextContent = reader.Get<string>("Section5PlainTextContent");
            bool section5NotApplicableToJob = reader.Get<bool>("Section5NotApplicableToJob");

            string section6Content = reader.Get<string>("Section6Content");
            string section6PlainTextContent = reader.Get<string>("Section6PlainTextContent");
            bool section6NotApplicableToJob = reader.Get<bool>("Section6NotApplicableToJob");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string preJobMeetingSignatures = reader.Get<string>("PreJobMeetingSignatures");
            string plainTextPreJobMeetingSignatures = reader.Get<string>("PlainTextPreJobMeetingSignatures");
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGN6Id(id);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            bool isDeleted = reader.Get<bool>("Deleted");

            FormTemplate formTemplate = formTemplateDao.QueryById(reader.Get<long>("WorkerResponsiblitiesTemplateId"));
            string workerResponsibiltiesTemplateText = formTemplate.Template;
            
            long siteid = reader.Get<long>("SiteId");    //ayman generic forms

            FormGN6 form = new FormGN6(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime,siteid);
            form.FunctionalLocations = functionalLocations;
            form.Approvals = approvals;
            form.LastModifiedBy = lastModifiedBy;
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.ApprovedDateTime = approvedDateTime;
            form.ClosedDateTime = closedDateTime;
            form.JobDescription = jobDescription;
            form.ReasonForCriticalLift = reasonForCriticalLift;

            form.Section1Content = section1Content;
            form.Section1PlainTextContent = section1PlainTextContent;
            form.Section1NotApplicableToJob = section1NotApplicableToJob;

            form.Section2Content = section2Content;
            form.Section2PlainTextContent = section2PlainTextContent;
            form.Section2NotApplicableToJob = section2NotApplicableToJob;

            form.Section3Content = section3Content;
            form.Section3PlainTextContent = section3PlainTextContent;
            form.Section3NotApplicableToJob = section3NotApplicableToJob;

            form.Section4Content = section4Content;
            form.Section4PlainTextContent = section4PlainTextContent;
            form.Section4NotApplicableToJob = section4NotApplicableToJob;

            form.Section5Content = section5Content;
            form.Section5PlainTextContent = section5PlainTextContent;
            form.Section5NotApplicableToJob = section5NotApplicableToJob;

            form.Section6Content = section6Content;
            form.Section6PlainTextContent = section6PlainTextContent;
            form.Section6NotApplicableToJob = section6NotApplicableToJob;

            form.DocumentLinks = documentLinks;
            form.PreJobMeetingSignatures = preJobMeetingSignatures;
            form.PlainTextPreJobMeetingSignatures = plainTextPreJobMeetingSignatures;

            form.WorkerResponsibiltiesTemplateText = workerResponsibiltiesTemplateText;
            form.IsDeleted = isDeleted;

            return form;
        }

        private void AddInsertParameters(FormGN6 form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private long GetWorkerResponsiblitiesTemplateId()
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryActiveResponsbilitiesTemplate";
            command.CommandType = CommandType.StoredProcedure;
            return (long) command.ExecuteScalar();
        }

        private static void AddUpdateParameters(FormGN6 form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void SetCommonAttributes(FormGN6 form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);

            command.AddParameter("@JobDescription", form.JobDescription);
            command.AddParameter("@ReasonForCriticalLift", form.ReasonForCriticalLift);

            command.AddParameter("@Section1Content", form.Section1Content);
            command.AddParameter("@Section1PlainTextContent", form.Section1PlainTextContent);
            command.AddParameter("@Section1NotApplicableToJob", form.Section1NotApplicableToJob);

            command.AddParameter("@Section2Content", form.Section2Content);
            command.AddParameter("@Section2PlainTextContent", form.Section2PlainTextContent);
            command.AddParameter("@Section2NotApplicableToJob", form.Section2NotApplicableToJob);

            command.AddParameter("@Section3Content", form.Section3Content);
            command.AddParameter("@Section3PlainTextContent", form.Section3PlainTextContent);
            command.AddParameter("@Section3NotApplicableToJob", form.Section3NotApplicableToJob);

            command.AddParameter("@Section4Content", form.Section4Content);
            command.AddParameter("@Section4PlainTextContent", form.Section4PlainTextContent);
            command.AddParameter("@Section4NotApplicableToJob", form.Section4NotApplicableToJob);

            command.AddParameter("@Section5Content", form.Section5Content);
            command.AddParameter("@Section5PlainTextContent", form.Section5PlainTextContent);
            command.AddParameter("@Section5NotApplicableToJob", form.Section5NotApplicableToJob);

            command.AddParameter("@Section6Content", form.Section6Content);
            command.AddParameter("@Section6PlainTextContent", form.Section6PlainTextContent);
            command.AddParameter("@Section6NotApplicableToJob", form.Section6NotApplicableToJob);

            command.AddParameter("PreJobMeetingSignatures", form.PreJobMeetingSignatures);
            command.AddParameter("PlainTextPreJobMeetingSignatures", form.PlainTextPreJobMeetingSignatures);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid",form.SiteId);  //ayman generic forms
        }

        private static void InsertFunctionalLocations(SqlCommand command, FormGN6 form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormGN6Id", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertApprovals(SqlCommand command, FormGN6 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN6Id", form.Id);
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

        private void UpdateFunctionalLocations(SqlCommand command, FormGN6 form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormGN6Id", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void UpdateApprovals(SqlCommand command, FormGN6 form)
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
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN6Id);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGN6);
        }
    }
}
