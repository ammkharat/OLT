﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraRichEdit.API.Word;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;


namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGenericTemplateDao : AbstractManagedDao, IFormGenericTemplateDao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private static IRoleDao roleDao;

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormGenericTemplateById";
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormGenericTemplateByIdAndSiteId";
        private const string INSERT_STORED_PROCEDURE = "InsertFormGenericTemplate";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGenericTemplate";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormGenericTemplateFunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormGenericTemplateFunctionalLocationsByFormGenericTemplateId";
        private const string INSERT_FORM_APPROVAL = "InsertFormGenericTemplateApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormGenericTemplateApproval";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGenericTemplate";

        private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_10_DAYS =
            "QueryAllFormGenericTemplateThatAreApprovedAndOutOfServiceForMoreThan10Days";

        private const string QUERY_GenricTemplate_BY_FLOCS_AND_OTHER_THINGS = "QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThings";
        private const string QUERY_GenricTemplate_BY_FLOCS_AND_OTHER_THINGS_PRIORITYPAGE = "QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThingsForPriorityPage";
        
        public FormGenericTemplateDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        public List<FormGenericTemplateDTO> QueryFormGenericTemplate(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange,
                long formtypeid, long  plantid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);

            //to fetch all form type records
            if (formtypeid == 0)
            {
                return GetDtos(command, QUERY_GenricTemplate_BY_FLOCS_AND_OTHER_THINGS_PRIORITYPAGE);
            }
            
            //else to fetch selected formtype record
            command.AddParameter("@GenericFormTypeID", formtypeid);
            command.AddParameter("@PlantID", plantid);
            return GetDtos(command, QUERY_GenricTemplate_BY_FLOCS_AND_OTHER_THINGS);
        }

        private static List<FormGenericTemplateDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormGenericTemplateDTO> result = new Dictionary<long, FormGenericTemplateDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        FormGenericTemplateDTO dto = result[key];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));

                        if (ApprovalStillNeeded(reader))
                        {
                            dto.AddRemainingApproval(reader.Get<string>("Approver"));
                        }
                    }
                    else
                    {
                        result.Add(key, PopulateInstance2(reader));
                    }
                }
            }

            return new List<FormGenericTemplateDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }
        private static bool ApprovalStillNeeded(SqlDataReader reader)
        {
            long? approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            return approvedByUserId == null;
        }
        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static FormGenericTemplateDTO PopulateInstance2(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            DateTime validFrom = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validTo = reader.Get<DateTime>("ValidToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            long formtypeid = reader.Get<long>("FormTypeID");
            long plantid = reader.Get<long>("PlantID");

            List<string> remainingApprovals = new List<string>();

            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FormGenericTemplateDTO result =
                new FormGenericTemplateDTO(id, new List<string> { floc }, criticalSystemDefeated, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId,
                    validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals, formtypeid, plantid);

            return result;
        }

        public FormGenericTemplate Insert(FormGenericTemplate form)    
        {
            
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            return form;
        }


        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGenericTemplateId);
        }
        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormGenericTemplate);
        }

        public FormGenericTemplate QueryByIdAndSiteId(long id, long siteid, long formtypeid, long plantid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGenericTemplate>(id, siteid, formtypeid, plantid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }


        //ayman Sarnia eip DMND0008992
        public List<FormApproval> QueryFormSarniaEipIssueApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            List<FormApproval> approvals = formApprovalDao.QueryByFormSarniaEipIssueApprover(siteid, formtypeid, plantid);
            return approvals;
        }
        //Added by ppanigrahi
        public List<FormApproval> QueryFormSarniaCsdApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            List<FormApproval> approvals = formApprovalDao.QueryByFormSarniaCsdApprover(siteid, formtypeid, plantid);
            return approvals;
        }

        public List<FormApproval> QueryByFormOP14Id(long Id)
        {
          
            return  formApprovalDao.QueryByFormOP14EmailId(Id);

        }

        public int Updatemailsentflag(long? Id, bool isMailSent)
        {

            int success = formApprovalDao.Updatemailsentflag(Id,isMailSent);
            return success;
        }
        public List<FormApproval> QueryFormGenericTemplateEFormApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            List<FormApproval> approvals = formApprovalDao.QueryByFormGenericTemplateApprover(siteid, formtypeid, plantid);
            return approvals;
        }

        public FormGenericTemplate QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGenericTemplate>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<FormGenericTemplate> QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Now", now);
            return command.QueryForListResult<FormGenericTemplate>(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_10_DAYS);
        }

        public void Update(FormGenericTemplate form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            UpdateApprovals(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
        }

        public void Remove(FormGenericTemplate form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void AddUpdateParameters(FormGenericTemplate form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateApprovals(SqlCommand command, FormGenericTemplate form)
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
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateFunctionalLocations(SqlCommand command, FormGenericTemplate form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormGenericTemplateId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void InsertApprovals(SqlCommand command, FormGenericTemplate form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGenericTemplateId", form.Id);
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

        private void InsertFunctionalLocations(SqlCommand command, FormGenericTemplate form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormGenericTemplateId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInsertParameters(FormGenericTemplate form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
            command.AddParameter("@CreatedByRoleId", form.CreatedByRole.Id);
        }

        private void SetCommonAttributes(FormGenericTemplate form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);
            command.AddParameter("@IsTheCSDForAPressureSafetyValve", form.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("@CriticalSystemDefeated", form.CriticalSystemDefeated);
            command.AddParameter("@DepartmentId", form.Department.Id);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid", form.SiteId);
            command.AddParameter("@FormTypeID", form.FormTypeId);
            command.AddParameter("@PlantID", form.PlantId);
        }

        private FormGenericTemplate PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormGenericTemplateId(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormGenericTemplateId(id);
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormGenericTemplateId(id);


            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");
          

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");
            int departmentId = reader.Get<int>("DepartmentId");
            FormOP14Department department = FormOP14Department.GetById(departmentId);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long formtypeid = reader.Get<long>("FormTypeID");
            long plantid = reader.Get<long>("PlantID");
            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));

            FormGenericTemplate form = new FormGenericTemplate(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime, 0, null, createdByRole);
            form.FunctionalLocations = functionalLocations;
            form.Approvals = approvals;
            form.LastModifiedBy = lastModifiedBy;
            form.DocumentLinks = documentLinks;
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.ApprovedDateTime = approvedDateTime;
            form.ClosedDateTime = closedDateTime;
            form.Content = content;
            form.PlainTextContent = plainTextContent;
            form.Department = department;
            form.IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
            form.CriticalSystemDefeated = criticalSystemDefeated;
            form.FormTypeId = formtypeid;
            form.PlantId = plantid;
            return form;
        }

    }


}