using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestMudsDao : AbstractPermitRequestDao<PermitRequestMuds>, IPermitRequestMudsDao
    {
        private const string INSERT_PERMIT_REQUEST_FUNCTIONAL_LOCATION_STORED_PROCEDURE = "InsertPermitRequestMudsFunctionalLocation";
        private const string DELETE_PERMIT_REQUEST_FUNCTIONAL_LOCATIONS_BY_PERMIT_REQUEST_ID = "DeletePermitRequestMudsFunctionalLocationsByPermitRequestMudsId";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitMudsGroupDao groupDao;
        private readonly IPermitAttributeDao attributeDao; 

        public PermitRequestMudsDao()
        {
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitMudsGroupDao>();
            attributeDao = DaoRegistry.GetDao<IPermitAttributeDao>();
        }

        protected override string QueryByIdStoredProcedure
        {
            get { return "QueryPermitRequestMudsById"; }
        }

        protected override string QueryByWorkOrderAndOperationAndSourceStoredProcedure
        {
            get { return "QueryPermitRequestMudsByWorkOrderNumberAndOperationAndSource"; }
        }

        protected override string QueryByDateRangeAndDataSourceStoredProcedure
        {
            get { return "QueryPermitRequestMudsByDateRangeAndDataSource"; }
        }

        protected override string InsertStoredProcedure
        {
            get { return "InsertPermitRequestMuds"; }
        }

        protected override string UpdateStoredProcedure
        {
            get { return "UpdatePermitRequestMuds"; }
        }

        protected override string RemoveStoredProcedure
        {
            get { return "RemovePermitRequestMuds"; }
        }

        protected override string InsertPermitAttributeAssociationStoredProcedure
        {
            get { return "InsertPermitRequestMudsPermitAttributeAssociation"; }
        }

        protected override string DeletePermitAttributeStoredProcedure
        {
            get { return "DeletePermitRequestMudsPermitAttributeAssociation"; }
        }

        protected override string QueryLastImportDateTimeStoredProcedure
        {
            get { return "QueryPermitRequestMudsLastImportDateTime"; }
        }

        protected override void InsertPermitAttributes(SqlCommand command, PermitRequestMuds permitRequest)
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

        protected override void DeletePermitAttributes(SqlCommand command, PermitRequestMuds permitRequest)
        {
            command.CommandText = DeletePermitAttributeStoredProcedure;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestId",  permitRequest.Id);
            command.ExecuteNonQuery();
        }

        protected override void InsertDocumentLinks(SqlCommand command, PermitRequestMuds permitRequest)
        {
            documentLinkDao.InsertNewDocumentLinks(permitRequest, documentLinkDao.InsertForAssociatedPermitRequestMuds);
        }

        protected override void RemoveDocumentLinks(SqlCommand command, PermitRequestMuds permitRequest)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(permitRequest, documentLinkDao.QueryByPermitRequestMudsId);
        }

        protected override PermitRequestMuds BuildPermitRequest(SqlDataReader reader)
        {
            long? permitRequestId = reader.Get<long?>("Id");

            List<FunctionalLocation> functionalLocations = functionalLocationDao.QueryByPermitRequestMudsId(permitRequestId.Value);

            //long? requestedByGroupId = reader.Get<long?>("RequestedByGroupId");

            WorkPermitMudsGroup requestedByGroup = null;
            //if (requestedByGroupId.HasValue)
            //{
            //    requestedByGroup = groupDao.QueryById(requestedByGroupId.Value);
            //}
            
            string requestedByGroupIdText = reader.Get<string>("RequestedByGroupId");

            PermitRequestMuds permitRequest = new PermitRequestMuds(
                permitRequestId,
                WorkPermitMudsType.Get(reader.Get<int>("WorkPermitTypeId")),
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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                reader.Get<string>("Company_1"),
                reader.Get<string>("Company_2"),
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
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId")), requestedByGroupIdText,
                reader.Get<string>("NbTravail"), reader.Get<bool>("FormationCheck"), reader.Get<string>("NomsEnt"),
                reader.Get<string>("NomsEnt_1"), reader.Get<string>("NomsEnt_2"), reader.Get<string>("NomsEnt_3"), reader.Get<string>("Surveilant"),
                reader.Get<DateTime>("StartDateTime"), reader.Get<DateTime>("EndDateTime"),
                reader.Get<bool>("Analyse_Attribute_CheckBox"), reader.Get<bool>("Cadenassage_multiple_Attribute_CheckBox"), reader.Get<bool>("Cadenassage_simple_Attribute_CheckBox"), 
                reader.Get<bool>("Procédure_Attribute_CheckBox"), reader.Get<bool>("Espace_clos_Attribute_CheckBox")
                
                ) { IsModified = reader.Get<bool>("IsModified") }; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            permitRequest.Attributes.AddRange(attributeDao.QueryByPermitRequestMuds(permitRequest));
            permitRequest.DocumentLinks = documentLinkDao.QueryByPermitRequestMudsId(permitRequestId.Value);

            return permitRequest;
        }
                      
        protected override void InsertFunctionalLocations(SqlCommand command, PermitRequestMuds permitRequest)
        {
            if (!permitRequest.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_PERMIT_REQUEST_FUNCTIONAL_LOCATION_STORED_PROCEDURE;
                foreach (FunctionalLocation functionalLocation in permitRequest.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@PermitRequestMudsId",  permitRequest.Id);
                    command.AddParameter("@FunctionalLocationId",  functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
              
        protected override void UpdateFunctionalLocations(SqlCommand command, PermitRequestMuds permitRequest)
        {
            command.CommandText = DELETE_PERMIT_REQUEST_FUNCTIONAL_LOCATIONS_BY_PERMIT_REQUEST_ID;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestMudsId",  permitRequest.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, permitRequest);
        }

        protected override void SetInsertUpdateAttributes(PermitRequestMuds permitRequest, SqlCommand command)
        {
            command.AddParameter("@WorkOrderNumber", permitRequest.WorkOrderNumber);
            command.AddParameter("@OperationNumber", permitRequest.OperationNumber);
            command.AddParameter("@SubOperationNumber", permitRequest.SubOperationNumber);

            command.AddParameter("@WorkPermitTypeId", permitRequest.WorkPermitType.Id);
            //command.AddParameter("@RequestedByGroupId", permitRequest.RequestedByGroup == null ? null : permitRequest.RequestedByGroup);
            command.AddParameter("@RequestedByGroupId", permitRequest.RequestedByGroupText);
            command.AddParameter("@ExcavationNumber", permitRequest.ExcavationNumber);
            command.AddParameter("@Supervisor", permitRequest.Supervisor);
            command.AddParameter("@StartDate", permitRequest.StartDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@Trade", permitRequest.Trade);
            command.AddParameter("@CompletionStatusId", permitRequest.CompletionStatus.Id);


            command.AddParameter("@NbTravail", permitRequest.NbTravail);
            command.AddParameter("@FormationCheck", permitRequest.Formation);
            command.AddParameter("@NomsEnt", permitRequest.Noms);
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            command.AddParameter("@NomsEnt_1", permitRequest.Noms_1);
            command.AddParameter("@NomsEnt_2", permitRequest.Noms_2);
            command.AddParameter("@NomsEnt_3", permitRequest.Noms_3);
            command.AddParameter("@Surveilant", permitRequest.Surveilant);

            //command.AddParameter("StartDateTime", permitRequest.StartDateTime);
            //command.AddParameter("EndDateTime", permitRequest.EndDateTime);
            
            command.AddParameter("@Analyse_Attribute_CheckBox", permitRequest.Analyse_Attribute_CheckBox);
            command.AddParameter("@Cadenassage_multiple_Attribute_CheckBox", permitRequest.Cadenassage_multiple_Attribute_CheckBox);
            command.AddParameter("@Cadenassage_simple_Attribute_CheckBox", permitRequest.Cadenassage_simple_Attribute_CheckBox);
            command.AddParameter("@Procédure_Attribute_CheckBox", permitRequest.Procédure_Attribute_CheckBox);
            command.AddParameter("@Espace_clos_Attribute_CheckBox", permitRequest.Espace_clos_Attribute_CheckBox);

            command.AddParameter("@StartDateTime", permitRequest.StartDateTime);
            command.AddParameter("@EndDateTime", permitRequest.EndDateTime);

            base.SetInsertUpdateAttributes(permitRequest, command);
        }


        public PermitRequestEdmonton InsertTemplate(PermitRequestEdmonton permit)
        {
            return null;

        }
        public PermitRequestMontreal InsertTemplate(PermitRequestMontreal permit)
        {
            return null;
        }

        public PermitRequestMuds InsertTemplate(PermitRequestMuds workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertPermitRequestTemplate");
           // InserttTemplateCategory(workPermit);

            return workPermit;
        }

        private static void AddInsertParametersForTemplate(PermitRequestMuds workPermit, SqlCommand command)
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
            command.AddParameter("@SiteId", 16);
        }

        public PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<PermitRequestMuds>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryPermitRequestTemplateNameandCategory");
        }

        private PermitRequestMuds PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");

            PermitRequestMuds workPermitMuds = new PermitRequestMuds(templateName, categories);

            return workPermitMuds;

        }

        private void InserttTemplateCategory(PermitRequestMuds workpermit)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertPermitRequestTemplateCategory";
            command.AddParameter("@Id", workpermit.IdValue);
            command.AddParameter("@SiteId", 16);
            command.AddParameter("@Categories", workpermit.Categories);
            command.ExecuteNonQuery();
        }



        public PermitRequestEdmonton QueryByIdTemplateEdmonton(long id, string templateName, string categories)
        {
            return null;
        }

        public PermitRequestMontreal QueryByIdTemplateMontreal(long id, string templateName, string categories)
        {
            return null;
        }
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(PermitRequestMuds workPermit)
        {
            string spname = "RemovePermitRequestTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(PermitRequestMuds workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public PermitRequestMuds UpdateTemplate(PermitRequestMuds workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdatePermitRequestTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(PermitRequestMuds workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);

        }

       

        public void RemoveTemplate(PermitRequestMontreal permitRequest)
        {

        }

        public void RemoveTemplate(PermitRequestEdmonton permitRequest)
        {

        }


        public PermitRequestEdmonton UpdateTemplate(PermitRequestEdmonton workPermit)
        {
            return null;
        }

        public PermitRequestMontreal UpdateTemplate(PermitRequestMontreal workPermit)
        {
            return null;
        }
    }
}
