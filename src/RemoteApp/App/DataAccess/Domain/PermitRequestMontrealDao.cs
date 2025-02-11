﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestMontrealDao : AbstractPermitRequestDao<PermitRequestMontreal>, IPermitRequestMontrealDao
    {
        private const string INSERT_PERMIT_REQUEST_FUNCTIONAL_LOCATION_STORED_PROCEDURE = "InsertPermitRequestMontrealFunctionalLocation";
        private const string DELETE_PERMIT_REQUEST_FUNCTIONAL_LOCATIONS_BY_PERMIT_REQUEST_ID = "DeletePermitRequestMontrealFunctionalLocationsByPermitRequestMontrealId";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitMontrealGroupDao groupDao;
        private readonly IPermitAttributeDao attributeDao; 

        public PermitRequestMontrealDao()
        {
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();
            attributeDao = DaoRegistry.GetDao<IPermitAttributeDao>();
        }

        protected override string QueryByIdStoredProcedure
        {
            get { return "QueryPermitRequestMontrealById"; }
        }

        protected override string QueryByWorkOrderAndOperationAndSourceStoredProcedure
        {
            get { return "QueryPermitRequestMontrealByWorkOrderNumberAndOperationAndSource"; }
        }

        protected override string QueryByDateRangeAndDataSourceStoredProcedure
        {
            get { return "QueryPermitRequestMontrealByDateRangeAndDataSource"; }
        }

        protected override string InsertStoredProcedure
        {
            get { return "InsertPermitRequestMontreal"; }
        }

        protected override string UpdateStoredProcedure
        {
            get { return "UpdatePermitRequestMontreal"; }
        }

        protected override string RemoveStoredProcedure
        {
            get { return "RemovePermitRequestMontreal"; }
        }

        protected override string InsertPermitAttributeAssociationStoredProcedure
        {
            get { return "InsertPermitRequestMontrealPermitAttributeAssociation"; }
        }

        protected override string DeletePermitAttributeStoredProcedure
        {
            get { return "DeletePermitRequestMontrealPermitAttributeAssociation"; }
        }

        protected override string QueryLastImportDateTimeStoredProcedure
        {
            get { return "QueryPermitRequestMontrealLastImportDateTime"; }
        }


        

        protected override void InsertPermitAttributes(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            if (permitRequest.Attributes.Count > 0)
            {
                command.CommandText = InsertPermitAttributeAssociationStoredProcedure;

                foreach (PermitAttribute attribute in permitRequest.Attributes)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@PermitRequestId",  permitRequest.Id);
                    command.AddParameter("@PermitAttributeId",  attribute.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void DeletePermitAttributes(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            command.CommandText = DeletePermitAttributeStoredProcedure;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestId",  permitRequest.Id);
            command.ExecuteNonQuery();
        }

        protected override void InsertDocumentLinks(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            documentLinkDao.InsertNewDocumentLinks(permitRequest, documentLinkDao.InsertForAssociatedPermitRequestMontreal);
        }

        protected override void RemoveDocumentLinks(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(permitRequest, documentLinkDao.QueryByPermitRequestMontrealId);
        }

        protected override PermitRequestMontreal BuildPermitRequest(SqlDataReader reader)
        {
            long? permitRequestId = reader.Get<long?>("Id");

            List<FunctionalLocation> functionalLocations = functionalLocationDao.QueryByPermitRequestMontrealId(permitRequestId.Value);

            long? requestedByGroupId = reader.Get<long?>("RequestedByGroupId");

            WorkPermitMontrealGroup requestedByGroup = null;
            if (requestedByGroupId.HasValue)
            {
                requestedByGroup = groupDao.QueryById(requestedByGroupId.Value);
            }


            PermitRequestMontreal permitRequest = new PermitRequestMontreal(
                permitRequestId,
                WorkPermitMontrealType.Get(reader.Get<int>("WorkPermitTypeId")),
                functionalLocations,
                new Date(reader.Get<DateTime>("StartDate")),
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("OperationNumber"),
                reader.Get<string>("SubOperationNumber"),
                reader.Get<string>("Trade"),
                reader.Get<string>("Description"),
                reader.Get<string>("SapDescription"),
                reader.Get<string>("Company"),
                reader.Get<string>("Supervisor"),
                reader.Get<string>("ExcavationNumber"),
                DataSource.GetById(reader.Get<int>("SourceId")),
                GetUser(reader, "LastImportedByUserId"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                GetUser(reader, "LastSubmittedByUserId"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                userDao.QueryById(reader.Get<long>("CreatedByUserId")),
                reader.Get<DateTime>("CreatedDateTime"),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"),
                requestedByGroup,
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"))) {IsModified = reader.Get<bool>("IsModified")};

            permitRequest.Attributes.AddRange(attributeDao.QueryByPermitRequestMontreal(permitRequest));
            permitRequest.DocumentLinks = documentLinkDao.QueryByPermitRequestMontrealId(permitRequestId.Value);

            return permitRequest;
        }
                      
        protected override void InsertFunctionalLocations(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            if (!permitRequest.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_PERMIT_REQUEST_FUNCTIONAL_LOCATION_STORED_PROCEDURE;
                foreach (FunctionalLocation functionalLocation in permitRequest.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@PermitRequestMontrealId",  permitRequest.Id);
                    command.AddParameter("@FunctionalLocationId",  functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
              
        protected override void UpdateFunctionalLocations(SqlCommand command, PermitRequestMontreal permitRequest)
        {
            command.CommandText = DELETE_PERMIT_REQUEST_FUNCTIONAL_LOCATIONS_BY_PERMIT_REQUEST_ID;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestMontrealId",  permitRequest.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, permitRequest);
        }

        protected override void SetInsertUpdateAttributes(PermitRequestMontreal permitRequest, SqlCommand command)
        {
            command.AddParameter("@WorkOrderNumber", permitRequest.WorkOrderNumber);
            command.AddParameter("@OperationNumber", permitRequest.OperationNumber);
            command.AddParameter("@SubOperationNumber", permitRequest.SubOperationNumber);

            command.AddParameter("@WorkPermitTypeId", permitRequest.WorkPermitType.Id);
            command.AddParameter("@RequestedByGroupId", permitRequest.RequestedByGroup == null ? null : permitRequest.RequestedByGroup.Id);
            command.AddParameter("@ExcavationNumber", permitRequest.ExcavationNumber);
            command.AddParameter("@Supervisor", permitRequest.Supervisor);
            command.AddParameter("@StartDate", permitRequest.StartDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@Trade", permitRequest.Trade);
            command.AddParameter("@CompletionStatusId", permitRequest.CompletionStatus.Id);

            base.SetInsertUpdateAttributes(permitRequest, command);
        }


        public PermitRequestEdmonton InsertTemplate(PermitRequestEdmonton permit)
        {
            return null;
        }
        public PermitRequestMontreal InsertTemplate(PermitRequestMontreal workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertPermitRequestTemplate");
            //InserttTemplateCategory(workPermit);
            return workPermit;
        }

        private static void AddInsertParametersForTemplate(PermitRequestMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.IdValue);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@IsTemplate", workPermit.IsTemplate);
            command.AddParameter("@CreatedByUser", workPermit.TemplateCreatedBy);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@WorkPermitType", workPermit.WorkPermitType.Name);
            command.AddParameter("@Description", workPermit.Description);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@SiteId", 9);
        }
        private void InserttTemplateCategory(PermitRequestMontreal workpermit)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertPermitRequestTemplateCategory";
            command.AddParameter("@Id", workpermit.IdValue);
            command.AddParameter("@SiteId", 9);
            command.AddParameter("@Categories", workpermit.Categories);
            command.ExecuteNonQuery();
        }

        public PermitRequestMontreal QueryByIdTemplateMontreal(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<PermitRequestMontreal>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryPermitRequestTemplateNameandCategory");
        }
        private PermitRequestMontreal PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");

            PermitRequestMontreal workPermitMuds = new PermitRequestMontreal(templateName, categories);

            return workPermitMuds;

        }

        public PermitRequestMuds InsertTemplate(PermitRequestMuds permit)
        {
            return null;
        }


        public PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            return null;
        }


        public PermitRequestEdmonton QueryByIdTemplateEdmonton(long id, string templateName, string categories)
        {
            return null;
        }
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**


        public void RemoveTemplate(PermitRequestMontreal workPermit)
        {
            string spname = "RemovePermitRequestTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(PermitRequestMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public PermitRequestMontreal UpdateTemplate(PermitRequestMontreal workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdatePermitRequestTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(PermitRequestMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);

        }

        public void RemoveTemplate(PermitRequestMuds permitRequest)
        {

        }


        public void RemoveTemplate(PermitRequestEdmonton permitRequest)
        {

        }



        public PermitRequestMuds UpdateTemplate(PermitRequestMuds workPermit)
        {
            return null;
        }

        public PermitRequestEdmonton UpdateTemplate(PermitRequestEdmonton workPermit)
        {
            return null;
        }
    }
}
