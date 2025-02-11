using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using System.Transactions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitDao : AbstractManagedDao, IWorkPermitDao
    {
        private readonly ILog logger = GenericLogManager.GetLogger<WorkPermitDao>();

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryWorkPermitById";
        private const string QUERY_BY_ID_FORUSPIPELINE_STORED_PROCEDURE = "QueryWorkPermitByIdForUSPipeline";        //ayman USPipeline workpermit

        private const string QUERY_BY_FLOCS_AND_STATUSES_STORED_PROCEDURE = "QueryWorkPermitsByFlocIdsAndStatusIds";
        private const string QUERY_BY_FLOCS_AND_STATUSES_FORUSPIPELINE_STORED_PROCEDURE = "QueryWorkPermitsByFlocIdsAndStatusIdsForUSPipeline";     //ayman USPipeline workpermit

        private const string QUERY_BY_SAP_OPERATION_KEYS_STORED_PROCEDURE = "QueryWorkPermitBySAPWorkOrderOperationKeys";
        private const string QUERY_BY_SAP_OPERATION_KEYS_FORUSPIPELINE_STORED_PROCEDURE = "QueryWorkPermitBySapWorkOrderOperationKeysForUSPipeline";       //ayman USPipeline workpermit

        private const string INSERT_STORED_PROCEDURE = "InsertWorkPermit";
        private const string INSERT_STORED_PROCEDURE_USPIPELINE = "InsertWorkPermitUSPipeline";       //ayman USPipeline workpermit
        private const string REMOVE_STORED_PROCEDURE = "RemoveWorkPermit";
        private const string UPDATE_STORED_PROCEDURE = "UpdateWorkPermit";

        private const string QUERY_ALL_WORKPERMITS_BY_REQUESTED_DATETIME_SITE_AND_STATUS_STORED_PROCEDURE = "QueryAllWorkPermitsLessThanAndEqualToRequestDateTimeBySiteAndStatus";
        private const string QUERY_ALL_WORKPERMITS_BY_STATUS = "QueryAllWorkPermitsByStatus";
        private const string UPDATE_WORK_PERMITS_ASSOCIATED_WITH_DELETED_CRAFT_OR_TRADE = "UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;
        private readonly IGasTestElementDao gasTestElementDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        public static bool IsSarnia = true;
        public static bool isDenver = true; // Added by Vibhor : DMND0011077 - Work Permit Clone History
        public static bool isUsPipeLine = false; 

        public WorkPermitDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            craftOrTradeDao = DaoRegistry.GetDao<ICraftOrTradeDao>();
            gasTestElementDao = DaoRegistry.GetDao<IGasTestElementDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();

            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public WorkPermit QueryById(long id)
        {
            return ManagedCommand.QueryById<WorkPermit>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public WorkPermit QueryByIdTemplate(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<WorkPermit>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryWorkPermitTemplateNameandCategory");
        }
        private WorkPermit PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            WorkPermit workPermit = new WorkPermit(templateName, categories);

            return workPermit;

        }


        //ayman USPipeline workpermit
        public WorkPermit QueryByIdForUSPipeline(long id)
        {
            IsSarnia = false;
            isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            return ManagedCommand.QueryById<WorkPermit>(id, PopulateInstance, QUERY_BY_ID_FORUSPIPELINE_STORED_PROCEDURE);
        }

        /// <summary>
        /// Query All All active (not deleted and not archived) and WorkPermitStatusId is set to pending
        /// and return All of these work permits prior to the requested date.
        /// </summary>
        /// <returns></returns>
        public List<WorkPermit> QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(DateTime requestDateTime, long siteId, WorkPermitStatus status)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RequestedDateTime", requestDateTime);
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@WorkPermitStatusId", status.IdValue);

            return command.QueryForListResult<WorkPermit>(PopulateInstance, QUERY_ALL_WORKPERMITS_BY_REQUESTED_DATETIME_SITE_AND_STATUS_STORED_PROCEDURE);
        }

        public List<WorkPermit> QueryAllWorkPermitsByStatus(WorkPermitStatus status)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStatusId", status.IdValue);

            return command.QueryForListResult<WorkPermit>(PopulateInstance, QUERY_ALL_WORKPERMITS_BY_STATUS);
        }

        public void UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade(long? craftOrTradeId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CraftOrTradeId", craftOrTradeId);
            command.ExecuteNonQuery(UPDATE_WORK_PERMITS_ASSOCIATED_WITH_DELETED_CRAFT_OR_TRADE);
        }

        public List<WorkPermit> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet, WorkPermitStatus[] statuses)
        {
            string flocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            var domainObjects = new List<WorkPermitStatus>(statuses);
            string statusIds = domainObjects.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocIds);
            command.AddParameter("@CsvStatusIds", statusIds);

            //ayman USPipeline workpermit
            string queryname = string.Empty;
            if (flocSet.FunctionalLocations[0].Site.IdValue == Site.USPipeline_ID || 
                flocSet.FunctionalLocations[0].Site.IdValue == Site.SELC_ID)  // mangesh uspipeline to selc
            {
                IsSarnia = false;
                isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
                queryname = "QueryWorkPermitsByFlocIdsAndStatusIdsForUSPipeline";
            }
            else
            {
                queryname = "QueryWorkPermitsByFlocIdsAndStatusIds";
            }
            return command.QueryForListResult<WorkPermit>(PopulateInstance, queryname);
        }


        //ayman USPipeline workpermit
        public WorkPermit QueryBySapWorkOrderOperationKeysForUSPipeline(string workOrderNumber, string operationNumber,
                                                         string subOperation)
        {
            IsSarnia = false;
            isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SAPOperationType", SapOperationType.WorkPermit.Name);

            if (subOperation != null)
            {
                command.AddParameter("@SubOperation", subOperation);
            }

            return
                command.QueryForSingleResult<WorkPermit>(PopulateInstance, QUERY_BY_SAP_OPERATION_KEYS_FORUSPIPELINE_STORED_PROCEDURE);
        }

        public WorkPermit QueryBySapWorkOrderOperationKeys(string workOrderNumber, string operationNumber,
                                                           string subOperation)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SAPOperationType", SapOperationType.WorkPermit.Name);

            if (subOperation != null)
            {
                command.AddParameter("@SubOperation", subOperation);
            }

            return
                command.QueryForSingleResult<WorkPermit>(PopulateInstance, QUERY_BY_SAP_OPERATION_KEYS_STORED_PROCEDURE);
        }

        private WorkPermit PopulateInstance(SqlDataReader reader)
        {
            FunctionalLocation floc = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            WorkPermit result = new WorkPermit(floc.Site)
                {
                    Id = (reader.Get<long>("Id")),
                    LastModifiedDate = (reader.Get<DateTime>("LastModifiedDate")),
                    Version = new Version(reader.Get<string>("Version"))
                };

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            bool isOperations = reader.Get<bool>("IsOperations");
            result.SetCreatedBy(createdBy, isOperations);

            long? lastModifiedUserId = reader.Get<long?>("LastModifiedUserId");
            result.LastModifiedBy = !lastModifiedUserId.HasValue ? null : userDao.QueryById(lastModifiedUserId.Value);

            long? approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            User approvedByUser = !approvedByUserId.HasValue ? null : userDao.QueryById(approvedByUserId.Value);

            WorkPermitStatus workPermitStatus = WorkPermitStatus.Get(reader.Get<long>("WorkPermitStatusId"));
            result.SetWorkPermitStatusAndApprover(workPermitStatus, approvedByUser);

            result.SapOperationId = reader.Get<long?>("SapOperationId");

            result.PermitNumber = reader.Get<string>("PermitNumber");

            result.WorkPermitType = WorkPermitType.Get(reader.Get<long>("WorkPermitTypeId"));

            result.PermitValidDateTime = reader.Get<DateTime?>("PermitValidDateTime");

            long? workPermitTypeClassificationId = reader.Get<long?>("WorkPermitTypeClassificationId");

            result.WorkPermitTypeClassification = !workPermitTypeClassificationId.HasValue ? null : WorkPermitTypeClassification.Get(workPermitTypeClassificationId.Value);

            PopulateWorkPermitSpecifics(result.Specifics, floc, reader);
            PopulateWorkPermitAttributes(result.Attributes, reader);

            result.SpecialPrecautionsOrConsiderations =
                reader.Get<string>("SpecialPrecautionsOrConsiderationsDescription");

            result.IsCoauthorizationRequired = reader.Get<bool?>("CoAuthorizationRequired");
            if (IsSarnia || isDenver)
            {
                result.IsControlRoomContacted = reader.Get<bool?>("ControlRoomContacted");    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia   

                result.ClonedFormDetailSarnia = reader.Get<string>("ClonedFormDetailSarnia"); // Added by Vibhor : DMND0011077 - Work Permit Clone History

                result.RevalidationDateTime = reader.Get<DateTime?>("RevalidationDateTime"); //Added by ppanigrahi
                result.ExtensionDateTime = reader.Get<DateTime?>("ExtensionDateTime");//Added by ppanigrahi
                result.ExtensionRevalidationDateTime = reader.Get<DateTime?>("ExtensionRevalidationDateTime");//Added by ppanigrahi
                result.Revalidation = reader.Get<int?>("Revalidation");//Added by ppanigrahi
                result.ExtensionTimeIssuer = reader.Get<DateTime?>("ExtensionTimeIssuer");
                result.ExtensionTimeNonIssuer = reader.Get<DateTime?>("ExtensionTimeNonIssuer");
                result.ISSUER_SOURCEXTENSION = reader.Get<string>("ISSUER_SOURCEXTENSION");
                result.ExtensionEnable = reader.Get<bool>("ExtensionEnable");
                result.RevalidationEnable = reader.Get<bool>("RevalidationEnable");
                result.BeforeExtensionDateTime = reader.Get<DateTime?>("BeforeExtensionDateTime");      
                result.Extension = reader.Get<int?>("Extension");
                result.MidExtensionvaluenonIssuer = reader.Get<DateTime?>("MidExtensionvaluenonIssuer");
                result.MidExtensionvalueIssuer = reader.Get<DateTime?>("MidExtensionvalueIssuer");

            }
            if (isDenver) // Added by Vibhor : DMND0011077 - Work Permit Clone History
            {
                result.ClonedFormDetailDenver = reader.Get<string>("ClonedFormDetailDenver");
            }

            //result.TemplateName = reader.Get<string>("TemplateName");
            //result.IsTemplate = reader.Get<bool>("IsTemplate");
            
            
            result.CoauthorizationDescription = reader.Get<string>("CoAuthorizationDescription");
            result.Source = DataSource.GetById(reader.Get<int>("SourceId"));

            if (floc.Site.id == Site.SELC_ID) // Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue
            {
                result.AdditionItemsRequired = PopulateWorkPermitAdditionalItemsRequiredForSELC(reader);
            }
            else
            {
                result.AdditionItemsRequired = PopulateWorkPermitAdditionalItemsRequired(reader);
            }
            


            result.Tools = PopulateWorkPermitTools(reader);
            PopulateWorkPermitEquipmentPreparationCondition(result.EquipmentPreparationCondition, reader);
            PopulateAsbestos(result.Asbestos, reader);
            result.JobWorksitePreparation = PopulateWorkPermitJobWorksitePreparation(reader);
            result.RadiationInformation = PopulateWorkPermitRadiationInformation(reader);
            result.GasTests = PopulateWorkPermitGasTests(reader, result.Id.GetValueOrDefault());
            result.FireConfinedSpaceRequirements = PopulateWorkPermitFireConfinedSpaceRequirements(reader);
            result.RespiratoryProtectionRequirements = PopulateWorkPermitRespiratoryProtectionRequirements(reader);
            result.SpecialProtectionRequirements = PopulateWorkPermitSpecialPPERequirements(reader);
            result.DocumentLinks = documentLinkDao.QueryByWorkPermitId(result.IdValue);
            result.Deleted = reader.Get<bool>("Deleted");
            
            return result;
        }

        private void PopulateWorkPermitSpecifics(WorkPermitSpecifics result, FunctionalLocation floc, SqlDataReader reader)
        {
            // We already got the floc from the reader for the constructor of the Work Permit, so just user it. 
            result.FunctionalLocation = floc;

            result.EndDateTime = reader.Get<DateTime?>("EndDateTime");
            result.StartDateTime = reader.Get<DateTime>("StartDateTime");
            result.StartTimeNotApplicable = reader.Get<bool>("StartTimeNotApplicable");
            result.StartAndOrEndTimesFinalized = reader.Get<bool>("StartAndOrEndTimesFinalized");
            result.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            result.WorkOrderDescription = reader.Get<string>("WorkOrderDescription");
            result.JobStepDescription = reader.Get<string>("JobStepDescription").NullToEmpty();
            result.Communication = PopulateWorkPermitCommunication(reader);
            result.CraftOrTrade = ReadCraftOrTrade(reader);
            result.ContractorCompanyName = reader.Get<string>("ContractorCompanyName");
            result.ContactName = reader.Get<string>("ContactPersonnel");

            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            result.WorkAssignment = workAssignmentId != null ? workAssignmentDao.QueryById(workAssignmentId.Value) : null;
        }

        private ICraftOrTrade ReadCraftOrTrade(SqlDataReader reader)
        {
            var craftOrTradeId = reader.Get<long?>("CraftOrTradeID");

            if (craftOrTradeId.HasValue)
            {
                return craftOrTradeDao.QueryById(craftOrTradeId.Value);
            }
            return new UserSpecifiedCraftOrTrade(reader.Get<string>("CraftOrTradeOther"));
        }

        private static void PopulateWorkPermitAttributes(WorkPermitAttributes result, SqlDataReader reader)
        {
            result.IsRadiationSealed = reader.Get<bool>("PermitRadiationSealed");
            result.IsRadiationRadiography = reader.Get<bool>("PermitRadiationRadiography");
            if (IsSarnia || isDenver)
            {
                result.IsFreshAir = reader.Get<bool>("PermitFreshAir");// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }
            
            result.IsAsbestos = reader.Get<bool>("PermitAsbestos");
            result.IsExcavation = reader.Get<bool>("PermitExcavation");
            result.IsElectricalWork = reader.Get<bool>("PermitElectricalWork");
            result.IsCriticalLift = reader.Get<bool>("PermitCriticalLift");
            result.IsSystemEntry = reader.Get<bool>("PermitSystemEntry");
            result.IsBurnOrOpenFlame = reader.Get<bool>("PermitBurnOrOpenFlame");
            result.IsHotTap = reader.Get<bool>("PermitHotTap");
            result.IsVehicleEntry = reader.Get<bool>("PermitVehicleEntry");
            result.IsBreathingAirOrSCBA = reader.Get<bool>("PermitBreathingAirOrSCBA");
            result.IsConfinedSpaceEntry = reader.Get<bool>("PermitConfinedSpaceEntry");
            result.IsInertConfinedSpaceEntry = reader.Get<bool>("PermitInertConfinedSpaceEntry");
            result.IsLeadAbatement = reader.Get<bool>("PermitLeadAbatement");
        }

        public WorkPermit Insert(WorkPermit workPermit)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();

            

            SqlParameter permitNumberParameter = command.Parameters.Add("@PermitNumber", SqlDbType.VarChar);
            permitNumberParameter.Direction = ParameterDirection.Output;
            permitNumberParameter.Size = 50;

            command.Insert(workPermit, AddInsertParameters, INSERT_STORED_PROCEDURE);
            workPermit.Id = (long?) idParameter.Value;

            workPermit.PermitNumber = (string) permitNumberParameter.Value;

            foreach (GasTestElement element in workPermit.GasTests.Elements)
            {
                gasTestElementDao.Insert(element, workPermit.Id.GetValueOrDefault());
            }

            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return workPermit;
        }

        public WorkPermit InsertTemplate(WorkPermit workPermit)
        {
            SqlCommand command = ManagedCommand;

           command.Insert(workPermit, AddInsertParametersForTemplate, "InsertWorkPermitTemplate");
           //InserttTemplateCategory(workPermit);

            return workPermit;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public WorkPermit UpdateTemplate(WorkPermit workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdateWorkPermitTemplate");
            
            return workPermit;
        }

        private static void UpdateParametersForTemplate(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDate);

        }

        //ayman USPipeline Workpermit
        public WorkPermit InsertUSPipeline(WorkPermit workPermit)
        {
            IsSarnia = false;
            isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();

            SqlParameter permitNumberParameter = command.Parameters.Add("@PermitNumber", SqlDbType.VarChar);
            permitNumberParameter.Direction = ParameterDirection.Output;
            permitNumberParameter.Size = 50;

            command.Insert(workPermit, AddInsertParameters, INSERT_STORED_PROCEDURE_USPIPELINE);
            workPermit.Id = (long?)idParameter.Value;
            workPermit.PermitNumber = (string)permitNumberParameter.Value;

            foreach (GasTestElement element in workPermit.GasTests.Elements)
            {
                gasTestElementDao.Insert(element, workPermit.Id.GetValueOrDefault());
            }

            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return workPermit;
        }

        public void Update(WorkPermit workPermit)
        {
            SqlCommand command = ManagedCommand;

            //ayman USPipeline workpermit
            string spname = string.Empty;
            if (workPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID 
                || workPermit.FunctionalLocation.Site.Id == Site.SELC_ID) //mangesh uspipeline to selc
            {
                IsSarnia = false;
                isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
                isUsPipeLine = true;
                spname = "UpdateWorkPermitForUSPipeline";
            }
            else
            {
                spname = "UpdateWorkPermit";
            }
            int records = command.Update(workPermit, AddUpdateParameters, spname);

            if (records > 1)
            {
                logger.Error("More than one Work Permit was updated when only one should have been updated for id " + workPermit.Id);
            }

            foreach (GasTestElement element in workPermit.GasTests.Elements)
            {
                if (element.Id == null)
                    gasTestElementDao.Insert(element, workPermit.Id.GetValueOrDefault());
                else
                    gasTestElementDao.Update(element);
            }
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
        }


        /// <summary>
        /// Remove Deleted Document Links
        /// </summary>
        private void RemoveDeletedDocumentLinks(IDocumentLinksObject workPermit)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(workPermit, documentLinkDao.QueryByWorkPermitId);
        }

        /// <summary>
        /// Inserts new (no id) document links associated with the Action Item definition
        /// </summary>
        private void InsertNewDocumentLinks(IDocumentLinksObject workPermit)
        {
            documentLinkDao.InsertNewDocumentLinks(workPermit, documentLinkDao.InsertForAssociatedWorkPermit);
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(WorkPermit workPermit)
        {
            string spname = "RemoveWorkPermitTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDate);
        }

        public void Remove(WorkPermit workPermit)
        {
            //ayman USPipeline workpermit
            string spname = string.Empty;
            if (workPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID 
                || workPermit.FunctionalLocation.Site.Id == Site.SELC_ID) // mangesh uspipeline to selc
            {
                IsSarnia = false;
                isDenver = false; // Added by Vibhor : DMND0011077 - Work Permit Clone History
                spname = "RemoveWorkPermitForUSPipeline";
            }
            else
            {
                spname = "RemoveWorkPermit";
            }
            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveParameters);
        }

        private static void AddInsertParametersForTemplate(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.IdValue);
            command.AddParameter("@PermitNumber", workPermit.PermitNumber);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@IsTemplate", workPermit.IsTemplate);
            command.AddParameter("@CreatedByUser", workPermit.TemplateCreatedBy);

            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@WorkPermitType", workPermit.WorkPermitType.Name);
            command.AddParameter("@Description", workPermit.WorkOrderDescription);

            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);

            command.AddParameter("@SiteId", workPermit.FunctionalLocation.Site.Id);

        }

        private static void AddInsertParameters(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@CreatedByUserId", workPermit.CreatedBy.Id);
            command.AddParameter("@IsOperations", workPermit.IsOperations);
            if (workPermit.FunctionalLocation.Site.IdValue == Site.DENVER_ID) // Added by Vibhor : DMND0011077 - Work Permit Clone History
            {
                
                //IsSarnia = false;
                command.AddParameter("@ClonedFormDetailDenver",
                                                   workPermit.ClonedFormDetailDenver); 
            }
            if (workPermit.FunctionalLocation.Site.IdValue == Site.SARNIA_ID)
            {
                command.AddParameter("@ClonedFormDetailSarnia",
                                                  workPermit.ClonedFormDetailSarnia);  
            }
            
            
            SetCommonAttributes(workPermit, command);
        }

        private static void AddUpdateParameters(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@id", workPermit.Id);
            command.AddParameter("@PermitNumber", workPermit.PermitNumber);


//if (isUsPipeLine)
//            {
//                command.AddParameter("@TemplateName", workPermit.TemplateName);
//                command.AddParameter("@IsTemplate", workPermit.IsTemplate);
//                command.AddParameter("@IsActiveTemplate", workPermit.IsActiveTemplate);
//            }
           
            
//Added by ppanigrahi
            if (workPermit.FunctionalLocation.Site.Id == Site.SARNIA_ID)
            {
                if (workPermit.RevalidationDateTime != null)
                {
                    command.AddParameter("@RevalidationDateTime", workPermit.RevalidationDateTime);
                }
                if (workPermit.ExtensionDateTime != null)
                {
                    command.AddParameter("@RevalidationDateTime", workPermit.ExtensionDateTime);
                }
                if (workPermit.ExtensionRevalidationDateTime != null)
                {
                    command.AddParameter("@ExtensionRevalidationDateTime", workPermit.ExtensionRevalidationDateTime);
                }
                if (workPermit.Revalidation != null)
                {

                    command.AddParameter("@Revalidation", workPermit.Revalidation);
                }
                if (workPermit.Extension != null)
                {

                    command.AddParameter("@Extension", workPermit.Extension);
                }
                if (workPermit.ExtensionTimeIssuer != null)
                {
                    command.AddParameter("@ExtensionTimeIssuer", workPermit.ExtensionTimeIssuer);
                }
                if (workPermit.ExtensionTimeNonIssuer != null)
                {
                    command.AddParameter("@ExtensionTimeNonIssuer", workPermit.ExtensionTimeNonIssuer);
                }
                if (workPermit.ISSUER_SOURCEXTENSION != null)
                {
                    command.AddParameter("@ISSUER_SOURCEXTENSION", workPermit.ISSUER_SOURCEXTENSION);

                }
                //if (workPermit.ExtensionEnable != null)
                //{
                //    command.AddParameter("@ExtensionEnable", workPermit.ExtensionEnable);
                //}
                //if (workPermit.RevalidationEnable != null)
                //{
                //    command.AddParameter("@RevalidationEnable", workPermit.RevalidationEnable);
                //}
                if (workPermit.BeforeExtensionDateTime != null)
                {
                    command.AddParameter("@BeforeExtensionDateTime", workPermit.BeforeExtensionDateTime);
                }

                if (workPermit.MidExtensionvaluenonIssuer != null)
                {
                    command.AddParameter("@MidExtensionvaluenonIssuer", workPermit.MidExtensionvaluenonIssuer);
                }
                if (workPermit.MidExtensionvalueIssuer != null)
                {
                    command.AddParameter("@MidExtensionvalueIssuer", workPermit.MidExtensionvalueIssuer);
                }
               
                
            }
if (workPermit.ExtensionEnable != null)
            {
                command.AddParameter("@ExtensionEnable", workPermit.ExtensionEnable);
            }
            if (workPermit.RevalidationEnable != null)
            {
                command.AddParameter("@RevalidationEnable", workPermit.RevalidationEnable);
            }            SetCommonAttributes(workPermit, command);
        }

        private static void AddRemoveParameters(WorkPermit workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.Id);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDate);
        }

        private static void SetCommonAttributes(WorkPermit workPermit, SqlCommand command)
        {
            //if (IsSarnia)
            //{
            //    command.AddParameter("@TemplateName", workPermit.TemplateName);
            //    command.AddParameter("@IsTemplate", workPermit.IsTemplate);
                
            //}

            command.AddParameter("@Version", workPermit.Version.ToString(2));

            if (workPermit.LastModifiedBy != null)
                command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);

            if (workPermit.ApprovedBy != null)
                command.AddParameter("@ApprovedByUserId", workPermit.ApprovedBy.Id);

            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDate);
            command.AddParameter("@SourceId", workPermit.Source.Id);

            //
            //  SpecialRescueOrFall
            //
            command.AddParameter("@SpecialRescueOrFallNotApplicable",
                                            workPermit.SpecialProtectionRequirements.IsRescueOrFallNotApplicable);
            command.AddParameter("@SpecialRescueOrFallOtherDescription",
                                            workPermit.SpecialProtectionRequirements.RescueOrFallOtherDescription);
            command.AddParameter("@SpecialRescueOrFallRescueDevice",
                                            workPermit.SpecialProtectionRequirements.IsRescueOrFallRescueDevice);
            command.AddParameter("@SpecialRescueOrFallYoYo",
                                            workPermit.SpecialProtectionRequirements.IsRescueOrFallYoYo);
            command.AddParameter("@SpecialRescueOrFallLifeline",
                                            workPermit.SpecialProtectionRequirements.IsRescueOrFallLifeline);
            command.AddParameter("@SpecialRescueOrFallBodyHarness",
                                            workPermit.SpecialProtectionRequirements.IsRescueOrFallBodyHarness);

            command.AddParameter("@SpecialFallOtherDescription",
                    workPermit.SpecialProtectionRequirements.FallOtherDescription);
            command.AddParameter("@SpecialFallRestraint",
                    workPermit.SpecialProtectionRequirements.FallRestraint);
            command.AddParameter("@SpecialFallSelfRetractingDevice",
                    workPermit.SpecialProtectionRequirements.FallSelfRetractingDevice);
            command.AddParameter("@SpecialFallTieoffRequired",
                    workPermit.SpecialProtectionRequirements.FallTieoffRequired);

            //
            //  SpecialHandProtection
            //
            command.AddParameter("@SpecialHandProtectionNotApplicable",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionNotApplicable);
            command.AddParameter("@SpecialHandProtectionOtherDescription",
                                            workPermit.SpecialProtectionRequirements.HandProtectionOtherDescription);
            command.AddParameter("@SpecialHandProtectionChemicalGloves",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionChemicalGloves);
            command.AddParameter("@SpecialHandProtectionLeather",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionLeather);
            command.AddParameter("@SpecialHandProtectionWelding",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionWelding);
            command.AddParameter("@SpecialHandProtectionHighVoltage",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionHighVoltage);
            command.AddParameter("@SpecialHandProtectionPVC",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionPVC);
            command.AddParameter("@SpecialHandProtectionNitrile",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionNitrile);
            command.AddParameter("@SpecialHandProtectionNaturalRubber",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionNaturalRubber);
            command.AddParameter("@SpecialHandProtectionChemicalNeprene",
                                            workPermit.SpecialProtectionRequirements.IsHandProtectionChemicalNeoprene);

            //
            //  SpecialProtectiveFootwear
            //
            command.AddParameter("@SpecialProtectiveFootwearNotApplicable",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable);
            command.AddParameter("@SpecialProtectiveFootwearOtherDescription",
                                            workPermit.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription);
            command.AddParameter("@SpecialProtectiveFootwearToeGuard",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveFootwearToeGuard);
            command.AddParameter("@SpecialProtectiveFootwearChemicalImperviousBoots",
                                            workPermit.SpecialProtectionRequirements.
                                                IsProtectiveFootwearChemicalImperviousBoots);
            command.AddParameter("@SpecialProtectiveFootwearMetatarsalGuard",
                                            workPermit.SpecialProtectionRequirements.
                                                IsProtectiveFootwearMetatarsalGuard);

            //
            //  SpecialProtectiveClothingType
            //
            command.AddParameter("@SpecialProtectiveClothingTypeNotApplicable",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable);
            command.AddParameter("@SpecialProtectiveClothingTypeOtherDescripton",
                                            workPermit.SpecialProtectionRequirements.
                                                ProtectiveClothingTypeOtherDescription);
            command.AddParameter("@SpecialProtectiveClothingTypeCausticWear",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeCausticWear);
            command.AddParameter("@SpecialProtectiveClothingTypePaperCoveralls",
                                            workPermit.SpecialProtectionRequirements.
                                                IsProtectiveClothingTypePaperCoveralls);
            command.AddParameter("@SpecialProtectiveClothingTypeTyvekSuit",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeTyvekSuit);
            command.AddParameter("@SpecialProtectiveClothingTypeKapplerSuit",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeKapplerSuit);
            command.AddParameter("@SpecialProtectiveClothingTypeElectricalFlashGear",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeElectricalFlashGear);
            command.AddParameter("@SpecialProtectiveClothingTypeCorrosiveClothing",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeCorrosiveClothing);

            command.AddParameter("@SpecialProtectiveClothingTypeAcidClothingTypeID",
                                 workPermit.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType != null
                                     ? workPermit.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType.Id
                                     : null);

            command.AddParameter("@SpecialProtectiveClothingTypeAcidClothing",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeAcidClothing);
            command.AddParameter("@SpecialProtectiveClothingTypeRainPants",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainPants);
            command.AddParameter("@SpecialProtectiveClothingTypeRainCoat",
                                            workPermit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainCoat);
            //
            //  SpecialEyeOrFaceProtection
            //
            command.AddParameter("@SpecialEyeOrFaceProtectionNotApplicable",
                                            workPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable);
            command.AddParameter("@SpecialEyeOrFaceProtectionOtherDescription",
                                            workPermit.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription);
            command.AddParameter("@SpecialEyeOrFaceProtectionFaceshield",
                                            workPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield);
            command.AddParameter("@SpecialEyeOrFaceProtectionGoggles",
                                            workPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionGoggles);

            //
            //  RespitoryProtectionRequirements
            //
            command.AddParameter("@RespitoryProtectionRequirementsNotApplicable",
                                            workPermit.RespiratoryProtectionRequirements.IsNotApplicable);
            command.AddParameter("@RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription",
                                            workPermit.RespiratoryProtectionRequirements.CartridgeTypeDescription);
            command.AddParameter("@RespitoryProtectionRequirementsOtherDescription",
                                            workPermit.RespiratoryProtectionRequirements.OtherDescription);
            command.AddParameter("@RespitoryProtectionRequirementsAirHood",
                                            workPermit.RespiratoryProtectionRequirements.IsAirHood);
            command.AddParameter("@RespitoryProtectionRequirementsDustMask",
                                            workPermit.RespiratoryProtectionRequirements.IsDustMask);
            command.AddParameter("@RespitoryProtectionRequirementsFullFaceRespirator",
                                            workPermit.RespiratoryProtectionRequirements.IsFullFaceRespirator);
            command.AddParameter("@RespitoryProtectionRequirementsHalfFaceRespirator",
                                            workPermit.RespiratoryProtectionRequirements.IsHalfFaceRespirator);
            command.AddParameter("@RespitoryProtectionRequirementsSCBA",
                                            workPermit.RespiratoryProtectionRequirements.IsSCBA);
            command.AddParameter("@RespitoryProtectionRequirementsAirCartOrAirLine",
                                            workPermit.RespiratoryProtectionRequirements.IsAirCartorAirLine);

            if (workPermit.RespiratoryProtectionRequirements.CartridgeType != null)
            {
                command.AddParameter("@RespitoryProtectionRequirementsRespiratoryCartridgeTypeId",
                                                workPermit.RespiratoryProtectionRequirements.CartridgeType.Id);
            }
            else
            {
                command.AddParameter("@RespitoryProtectionRequirementsRespiratoryCartridgeTypeId", DBNull.Value);
            }
            command.AddParameter("@FireConfinedSpaceNotApplicable",
                                            workPermit.FireConfinedSpaceRequirements.IsNotApplicable);
            command.AddParameter("@FireConfinedSpaceOtherDescription",
                                            workPermit.FireConfinedSpaceRequirements.OtherDescription);
            command.AddParameter("@FireConfinedSpaceHoleWatchNumber",
                                            workPermit.FireConfinedSpaceRequirements.HoleWatchNumber);
            command.AddParameter("@FireConfinedSpaceFireWatchNumber",
                                workPermit.FireConfinedSpaceRequirements.FireWatchNumber);
            command.AddParameter("@FireConfinedSpaceSpotterNumber",
                                            workPermit.FireConfinedSpaceRequirements.SpotterNumber);
            command.AddParameter("@FireConfinedSpaceWatchmen",
                                            workPermit.FireConfinedSpaceRequirements.IsWatchmen);
            command.AddParameter("@FireConfinedSpaceSteamHose",
                                            workPermit.FireConfinedSpaceRequirements.IsSteamHose);
            command.AddParameter("@FireConfinedSpaceWaterHose",
                                            workPermit.FireConfinedSpaceRequirements.IsWaterHose);
            command.AddParameter("@FireConfinedSpaceSparkContainment",
                                            workPermit.FireConfinedSpaceRequirements.IsSparkContainment);
            command.AddParameter("@FireConfinedSpaceFireResistantTarp",
                                            workPermit.FireConfinedSpaceRequirements.IsFireResistantTarp);
            command.AddParameter("@FireConfinedSpaceC02Extinguisher",
                                            workPermit.FireConfinedSpaceRequirements.IsC02Extinguisher);
            command.AddParameter("@FireConfinedSpace20ABCorDryChemicalExtinguisher",
                                            workPermit.FireConfinedSpaceRequirements.
                                                IsTwentyABCorDryChemicalExtinguisher);
            command.AddParameter("@GasTestConstantMonitoringRequired", workPermit.GasTests.ConstantMonitoringRequired);
            command.AddParameter("@GasTestForkliftNotUsed", workPermit.GasTests.ForkliftNotUsed);
                                            

            if (workPermit.GasTests.ImmediateAreaTestTime == null)
            {
                command.AddParameter("@GasTestTestTime",  null);
            }
            else
            {
                command.AddParameter("@GasTestTestTime",  workPermit.GasTests.ImmediateAreaTestTime.ToDateTime());
            }


            if (workPermit.GasTests.ConfinedSpaceTestTime == null)
            {
                command.AddParameter("@GasTestConfinedSpaceTestTime",  null);
            }
            else
            {
                command.AddParameter("@GasTestConfinedSpaceTestTime",  workPermit.GasTests.ConfinedSpaceTestTime.ToDateTime());
            }


            if (workPermit.GasTests.SystemEntryTestTime == null)
            {
                command.AddParameter("@GasTestSystemEntryTestTime",  null);
            }
            else
            {
                command.AddParameter("@GasTestSystemEntryTestTime",  workPermit.GasTests.SystemEntryTestTime.ToDateTime());
            }


            command.AddParameter("@GasTestFrequencyOrDuration", workPermit.GasTests.FrequencyOrDuration);
            command.AddParameter("@RadiationSealedSourceIsolationNumberOfSources",
                                            workPermit.RadiationInformation.SealedSourceIsolationNumberOfSources);
            command.AddParameter("@RadiationSealedSourceIsolationOpen",
                                            workPermit.RadiationInformation.IsSealedSourceIsolationOpen);
            command.AddParameter("@RadiationSealedSourceIsolationLOTO",
                                            workPermit.RadiationInformation.IsSealedSourceIsolationLOTO);
            command.AddParameter("@RadiationSealedSourceIsolationNotApplicable",
                                            workPermit.RadiationInformation.IsSealedSourceIsolationNotApplicable);
            command.AddParameter("@JobSitePreparationLightingElectricalRequirementOtherDescription",
                                            workPermit.JobWorksitePreparation.
                                                LightingElectricalRequirementOtherDescription);
            command.AddParameter("@JobSitePreparationLightingElectricalRequirementGeneratorLights",
                                            workPermit.JobWorksitePreparation.
                                                IsLightingElectricalRequirementGeneratorLights);
            command.AddParameter("@JobSitePreparationLightingElectricalRequirement110VWithGFCI",
                                            workPermit.JobWorksitePreparation.
                                                IsLightingElectricalRequirement110VWithGFCI);
            command.AddParameter("@JobSitePreparationLightingElectricalRequirementLowVoltage12V",
                                            workPermit.JobWorksitePreparation.
                                                IsLightingElectricalRequirementLowVoltage12V);
            command.AddParameter("@JobSitePreparationLightingElectricalRequirementNotApplicable",
                                            workPermit.JobWorksitePreparation.
                                                IsLightingElectricalRequirementNotApplicable);
            command.AddParameter("@JobSitePreparationAreaPreparationOtherDescription",
                                            workPermit.JobWorksitePreparation.AreaPreparationOtherDescription);
            command.AddParameter("@JobSitePreparationAreaPreparationPreopBoundaryRopeTape",
                                            workPermit.JobWorksitePreparation.IsAreaPreparationBoundaryRopeTape);
            command.AddParameter("@JobSitePreparationAreaPreparationRadiationRope",
                                            workPermit.JobWorksitePreparation.IsAreaPreparationRadiationRope);
            command.AddParameter("@JobSitePreparationAreaPreparationNonEssentialEvac",
                                            workPermit.JobWorksitePreparation.IsAreaPreparationNonEssentialEvac);
            command.AddParameter("@JobSitePreparationAreaPreparationBarricade",
                                            workPermit.JobWorksitePreparation.IsAreaPreparationBarricade);
            command.AddParameter("@JobSitePreparationAreaPreparationNotApplicable",
                                            workPermit.JobWorksitePreparation.IsAreaPreparationNotApplicable);
           
            command.AddParameter("@JobSitePreparationSewerIsolationMethodOtherDescription",
                                            workPermit.JobWorksitePreparation.SewerIsolationMethodOtherDescription);
            command.AddParameter("@JobSitePreparationSewerIsolationMethodBlindedOrBlanked",
                                            workPermit.JobWorksitePreparation.IsSewerIsolationMethodBlindedOrBlanked);
            command.AddParameter("@JobSitePreparationSewerIsolationMethodPlugged",
                                            workPermit.JobWorksitePreparation.IsSewerIsolationMethodPlugged);
            command.AddParameter("@JobSitePreparationSewerIsolationMethodSealedOrCovered",
                                            workPermit.JobWorksitePreparation.IsSewerIsolationMethodSealedOrCovered);
            command.AddParameter("@JobSitePreparationSewerIsolationMethodNotApplicable",
                                            workPermit.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable);
            command.AddParameter("@JobSitePreparationPermitReceiverFieldOrEquipmentOrientation",
                                            workPermit.JobWorksitePreparation.
                                                IsPermitReceiverFieldOrEquipmentOrientation);
            if (IsSarnia || isDenver)
            {

                command.AddParameter("@IsControlRoomContactedOrNot",
                    workPermit.JobWorksitePreparation.
                        IsControlRoomContactedOrNot);
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }


            command.AddParameter("@JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable",
                                            workPermit.JobWorksitePreparation.
                                                IsPermitReceiverFieldOrEquipmentOrientationNotApplicable);
            command.AddParameter("@JobSitePreparationVestedBuddySystemInEffect",
                                            workPermit.JobWorksitePreparation.IsVestedBuddySystemInEffect);
            command.AddParameter("@JobSitePreparationVestedBuddySystemInEffectNotApplicable",
                                            workPermit.JobWorksitePreparation.IsVestedBuddySystemInEffectNotApplicable);
            command.AddParameter("@JobSitePreparationSurroundingConditionsAffectOrContaminated",
                                            workPermit.JobWorksitePreparation.
                                                IsSurroundingConditionsAffectOrContaminated);
            command.AddParameter("@JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable",
                                            workPermit.JobWorksitePreparation.
                                                IsSurroundingConditionsAffectOrContaminatedNotApplicable);
            command.AddParameter("@JobSitePreparationCriticalConditionRemainJobSite",
                                            workPermit.JobWorksitePreparation.IsCriticalConditionRemainJobSite);
            command.AddParameter("@JobSitePreparationCriticalConditionRemainJobSiteNotApplicable",
                                            workPermit.JobWorksitePreparation.
                                                IsCriticalConditionRemainJobSiteNotApplicable);
            if (IsSarnia || isDenver)
            {
                command.AddParameter("@ControlRoomContactedNotApplicable",
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                    workPermit.JobWorksitePreparation.
                        IsControlRoomContactedNotApplicable);
            }

            command.AddParameter("@JobSitePreparationWeldingGroundWireInTestArea",
                                            workPermit.JobWorksitePreparation.IsWeldingGroundWireInTestArea);
            command.AddParameter("@JobSitePreparationWeldingGroundWireInTestAreaNotApplicable",
                                            workPermit.JobWorksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable);
            command.AddParameter("@JobSitePreparationBondingOrGroundingRequired",
                                            workPermit.JobWorksitePreparation.IsBondingOrGroundingRequired);
            command.AddParameter("@JobSitePreparationBondingOrGroundingRequiredNotApplicable",
                                            workPermit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable);
            command.AddParameter("@JobSitePreparationFlowRequiredForJobNotApplicable",
                                            workPermit.JobWorksitePreparation.IsFlowRequiredForJobNotApplicable);
            command.AddParameter("@JobSitePreparationFlowRequiredForJob",
                                            workPermit.JobWorksitePreparation.IsFlowRequiredForJob);

            command.AddParameter("@JobSitePreparationFlowRequiredComments",
                                            workPermit.JobWorksitePreparation.FlowRequiredComments);
            command.AddParameter("@JobSitePreparationBondingGroundingNotRequiredComments",
                                            workPermit.JobWorksitePreparation.BondingGroundingNotRequiredComments);
            command.AddParameter("@JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments",
                                            workPermit.JobWorksitePreparation.
                                                WeldingGroundWireNotWithinGasTestAreaComments);
            command.AddParameter("@JobSitePreparationSurroundingConditionsAffectAreaComments",
                                            workPermit.JobWorksitePreparation.SurroundingConditionsAffectAreaComments);
            command.AddParameter("@JobSitePreparationCriticalConditionsComments",
                                            workPermit.JobWorksitePreparation.CriticalConditionsComments);

            //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            //if (workPermit.Attributes.CommentsPanelVisiblity == false)
            //{
            //    command.AddParameter("@JobSitePreparationPermitReceiverRequiresOrientationComments",
            //                                null);
            //}
            //else
            //{
                command.AddParameter("@JobSitePreparationPermitReceiverRequiresOrientationComments",
                                             workPermit.JobWorksitePreparation.PermitReceiverRequiresOrientationComments);
            //}



            command.AddParameter("@EquipmentIsolationMethodOtherDescription",
                                            workPermit.EquipmentPreparationCondition.IsolationMethodOtherDescription);
            command.AddParameter("@EquipmentIsolationMethodLOTO",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodLOTO);
            command.AddParameter("@EquipmentIsolationMethodMudderPlugs",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodMudderPlugs);
            command.AddParameter("@EquipmentIsolationMethodSeparation",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodSeparation);
            command.AddParameter("@EquipmentIsolationMethodBlindedorBlanked",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodBlindedorBlanked);
            command.AddParameter("@EquipmentIsolationMethodBlockedIn",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodBlockedIn);
            command.AddParameter("@EquipmentIsolationMethodCarBer",
                                workPermit.EquipmentPreparationCondition.IsIsolationMethodCarBer);
            command.AddParameter("@EquipmentIsolationMethodNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsIsolationMethodNotApplicable);
            command.AddParameter("@EquipmentPreviousContentsOtherDescription",
                                            workPermit.EquipmentPreparationCondition.PreviousContentsOtherDescription);
            command.AddParameter("@EquipmentPreviousContentsH2S",
                                            workPermit.EquipmentPreparationCondition.IsPreviousContentsH2S);
            command.AddParameter("@EquipmentPreviousContentsCaustic",
                                            workPermit.EquipmentPreparationCondition.IsPreviousContentsCaustic);
            command.AddParameter("@EquipmentPreviousContentsAcid",
                                            workPermit.EquipmentPreparationCondition.IsPreviousContentsAcid);
            command.AddParameter("@EquipmentPreviousContentsHydrocarbon",
                                            workPermit.EquipmentPreparationCondition.IsPreviousContentsHydrocarbon);
            command.AddParameter("@EquipmentPreviousContentsNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsPreviousContentsNotApplicable);
            command.AddParameter("@EquipmentConditionPurgedDescription",
                                            workPermit.EquipmentPreparationCondition.ConditionPurgedDescription);
            command.AddParameter("@EquipmentConditionPurged",
                                            workPermit.EquipmentPreparationCondition.IsConditionPurged);
            command.AddParameter("@EquipmentConditionOtherDescription",
                                            workPermit.EquipmentPreparationCondition.ConditionOtherDescription);
            command.AddParameter("@EquipmentConditionPurgedN2",
                                            workPermit.EquipmentPreparationCondition.IsConditionPurgedN2);
            command.AddParameter("@EquipmentConditionPurgedSteamed",
                                            workPermit.EquipmentPreparationCondition.IsConditionPurgedSteamed);
            command.AddParameter("@EquipmentConditionPurgedAir",
                                            workPermit.EquipmentPreparationCondition.IsConditionPurgedAir);
            command.AddParameter("@EquipmentConditionNeutralized",
                                            workPermit.EquipmentPreparationCondition.IsConditionNeutralized);
            command.AddParameter("@EquipmentConditionH20Washed",
                                            workPermit.EquipmentPreparationCondition.IsConditionH20Washed);
            command.AddParameter("@EquipmentConditionVentilated",
                                            workPermit.EquipmentPreparationCondition.IsConditionVentilated);
            command.AddParameter("@EquipmentConditionCleaned",
                                            workPermit.EquipmentPreparationCondition.IsConditionCleaned);
            if (IsSarnia || isDenver)
            {

                command.AddParameter("@EquipmentConditionPurgedChecked",
                                                workPermit.EquipmentPreparationCondition.IsConditionPurgedCheckbox); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia    
            }


            command.AddParameter("@EquipmentConditionDrained",
                                            workPermit.EquipmentPreparationCondition.IsConditionDrained);
            command.AddParameter("@EquipmentConditionDepressured",
                                            workPermit.EquipmentPreparationCondition.IsConditionDepressured);
            command.AddParameter("@EquipmentConditionNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsConditionNotApplicable);



            command.AddParameter("@EquipmentAsbestosGasketsNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsAsbestosGasketsNotApplicable);
            command.AddParameter("@EquipmentAsbestosGaskets",
                                workPermit.EquipmentPreparationCondition.IsAsbestosGaskets);
           
            command.AddParameter("@EquipmentIsOutOfService",
                                            workPermit.EquipmentPreparationCondition.IsOutOfService);
            command.AddParameter("@EquipmentLeakingValves",
                                            workPermit.EquipmentPreparationCondition.IsLeakingValves);
            command.AddParameter("@EquipmentLeakingValvesNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsLeakingValvesNotApplicable);

            command.AddParameter("@EquipmentStillContainsResidualComments",
                                            workPermit.EquipmentPreparationCondition.StillContainsResidualComments);
            command.AddParameter("@EquipmentInServiceComments",
                                            workPermit.EquipmentPreparationCondition.InServiceComments);
            if (IsSarnia || isDenver)
            {
                //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes -- If condition added
                if (workPermit.Asbestos.HazardsConsidered.HasFalseValue())
                {
                    command.AddParameter("@EquipmentInAsbestosHazardPresentComments",
                                            null);
                }
                else
                {
                    command.AddParameter("@EquipmentInAsbestosHazardPresentComments",
                                            workPermit.EquipmentPreparationCondition.InAsbestosHazardPresentComments);  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                }
                
            }

             

            command.AddParameter("@EquipmentNoElectricalTestBumpComments",
                                            workPermit.EquipmentPreparationCondition.NoElectricalTestBumpComments);
            command.AddParameter("@EquipmentLeakingValvesComments",
                                            workPermit.EquipmentPreparationCondition.LeakingValvesComments);

            command.AddParameter("@EquipmentStillContainsResidual",
                                            workPermit.EquipmentPreparationCondition.IsStillContainsResidual);
            command.AddParameter("@EquipmentStillContainsResidualNotApplicable",
                                            workPermit.EquipmentPreparationCondition.
                                                IsStillContainsResidualNotApplicable);

            command.AddParameter("@EquipmentVentilationMethodForced",
                                           workPermit.EquipmentPreparationCondition.IsVentilationMethodForced);
            command.AddParameter("@EquipmentVentilationMethodLocalExhaust",
                                            workPermit.EquipmentPreparationCondition.IsVentilationMethodLocalExhaust);
            command.AddParameter("@EquipmentVentilationMethodNaturalDraft",
                                            workPermit.EquipmentPreparationCondition.IsVentilationMethodNaturalDraft);
            command.AddParameter("@EquipmentVentilationMethodNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsVentilationMethodNotApplicable);
            
            command.AddParameter("@ElectricTestBump", workPermit.EquipmentPreparationCondition.IsTestBump);
            command.AddParameter("@ElectricTestBumpNotApplicable",
                                            workPermit.EquipmentPreparationCondition.IsTestBumpNotApplicable);
            command.AddParameter("@ElectricIsolationMethodWiring",
                                            workPermit.EquipmentPreparationCondition.IsElectricalIsolationMethodWiring);
            command.AddParameter("@ElectricIsolationMethodLOTO",
                                            workPermit.EquipmentPreparationCondition.IsElectricalIsolationMethodLOTO);
            command.AddParameter("@ElectricIsolationMethodNotApplicable",
                                            workPermit.EquipmentPreparationCondition.
                                                IsElectricalIsolationMethodNotApplicable);

            command.AddParameter("@EquipmentIsHazardousEnergyIsolationRequiredNotApplicable", workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable);
            command.AddParameter("@EquipmentIsHazardousEnergyIsolationRequired", workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired);
            if (workPermit.EquipmentPreparationCondition.LockOutMethod != null)
            {
                command.AddParameter("@EquipmentLockOutMethodId", workPermit.EquipmentPreparationCondition.LockOutMethod.Id);
            }
            command.AddParameter("@EquipmentLockOutMethodComments", workPermit.EquipmentPreparationCondition.LockOutMethodComments);
            command.AddParameter("@EquipmentEnergyIsolationPlanNumber", workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber);
            command.AddParameter("@EquipmentConditionsOfEIPSatisfied", workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied);
            command.AddParameter("@EquipmentConditionsOfEIPNotSatisfiedComments", workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments);
            command.AddParameter("@AsbestosHazardsConsideredNotApplicable", workPermit.Asbestos.HazardsConsideredNotApplicable);
            command.AddParameter("@AsbestosHazardsConsidered", workPermit.Asbestos.HazardsConsidered);

            command.AddParameter("@ToolsOtherToolsDescription", workPermit.Tools.OtherToolsDescription);
            command.AddParameter("@ToolsChemicals", workPermit.Tools.IsChemicals);
            command.AddParameter("@ToolsWelder", workPermit.Tools.IsWelder);
            command.AddParameter("@ToolsTorch", workPermit.Tools.IsTorch);
            command.AddParameter("@ToolsPortLighting", workPermit.Tools.IsPortLighting);
            command.AddParameter("@ToolsHotTapMachine", workPermit.Tools.IsHotTapMachine);
            command.AddParameter("@ToolsTamper", workPermit.Tools.IsTamper);
            command.AddParameter("@ToolsManlift", workPermit.Tools.IsManlift);
            command.AddParameter("@ToolsHEPAVacuum", workPermit.Tools.IsHEPAVacuum);
            command.AddParameter("@ToolsForklift", workPermit.Tools.IsForklift);
            command.AddParameter("@ToolsCompressor", workPermit.Tools.IsCompressor);
            command.AddParameter("@ToolsVehicle", workPermit.Tools.IsVehicle);
            command.AddParameter("@ToolsScaffolding", workPermit.Tools.IsScaffolding);
            command.AddParameter("@ToolsLanda", workPermit.Tools.IsLanda);
            command.AddParameter("@ToolsHeavyEquipment", workPermit.Tools.IsHeavyEquipment);
            command.AddParameter("@ToolsElectricTools", workPermit.Tools.IsElectricTools);
            command.AddParameter("@ToolsCementSaw", workPermit.Tools.IsCementSaw);
            command.AddParameter("@ToolsVacuumTruck", workPermit.Tools.IsVacuumTruck);
            command.AddParameter("@ToolsJackhammer", workPermit.Tools.IsJackhammer);
            command.AddParameter("@ToolsHandTools", workPermit.Tools.IsHandTools);
            command.AddParameter("@ToolsCraneOrCarrydeck", workPermit.Tools.IsCraneOrCarrydeck);
            command.AddParameter("@ToolsAirTools", workPermit.Tools.IsAirTools);
            command.AddParameter("@CoAuthorizationRequired", workPermit.IsCoauthorizationRequired);

            if (IsSarnia || isDenver)
            {
                command.AddParameter("@ControlRoomContacted", workPermit.IsControlRoomContacted);   // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }

            

            
            command.AddParameter("@CoAuthorizationDescription", workPermit.CoauthorizationDescription);

            command.AddParameter("@AdditionalOtherFormsOrAssessmentsOrAuthorizations",
                                            workPermit.AdditionItemsRequired.OtherItemDescription);
            command.AddParameter("@AdditionalMSDS", workPermit.AdditionItemsRequired.IsMSDS);
            command.AddParameter("@AdditionalWaiverOrDeviation",
                                            workPermit.AdditionItemsRequired.IsWaiverOrDeviation);
            command.AddParameter("@AdditionalWaiverOrDeviationDescription",
                                            workPermit.AdditionItemsRequired.WaiverOrDeviationDescription);
            command.AddParameter("@AdditionalBurnOrOpenFlameAssessment",
                                            workPermit.AdditionItemsRequired.IsBurnOrOpenFlameAssessment);
            command.AddParameter("@AdditionalBurnOrOpenFlameAssessmentDescription",
                                workPermit.AdditionItemsRequired.BurnOrOpenFlameAssessmentDescription);
            command.AddParameter("@AdditionalElectrical", workPermit.AdditionItemsRequired.IsElectrical);
            command.AddParameter("@AdditionalElectricalDescription", workPermit.AdditionItemsRequired.ElectricalDescription);
            command.AddParameter("@AdditionalRoadClosure", workPermit.AdditionItemsRequired.IsRoadClosure);
            command.AddParameter("@AdditionalAsbestosHandling",
                                            workPermit.AdditionItemsRequired.IsAsbestosHandling);
            command.AddParameter("@AdditionalAsbestosHandlingDescription",
                                workPermit.AdditionItemsRequired.AsbestosHandlingDescription);
            command.AddParameter("@AdditionalPJSROrSafetyPause",
                                            workPermit.AdditionItemsRequired.IsPJSROrSafetyPause);
            command.AddParameter("@AdditionalBlankOrBlindLists",
                                            workPermit.AdditionItemsRequired.IsBlankOrBlindLists);
            command.AddParameter("@AdditionalSpecialWasteDisposal",
                                            workPermit.AdditionItemsRequired.IsSpecialWasteDisposal);
            command.AddParameter("@AdditionalHotTap", workPermit.AdditionItemsRequired.IsHotTap);
            command.AddParameter("@AdditionalExcavation", workPermit.AdditionItemsRequired.IsExcavation);
            command.AddParameter("@AdditionalExcavationDescription", workPermit.AdditionItemsRequired.ExcavationDescription);
            command.AddParameter("@AdditionalCriticalLift", workPermit.AdditionItemsRequired.IsCriticalLift);
            command.AddParameter("@AdditionalCriticalLiftDescription", workPermit.AdditionItemsRequired.CriticalLiftDescription);
            command.AddParameter("@AdditionalFlareEntry", workPermit.AdditionItemsRequired.IsFlareEntry);
            command.AddParameter("@AdditionalCSEAssessmentOrAuthorization",
                                            workPermit.AdditionItemsRequired.IsCSEAssessmentOrAuthorization);
            command.AddParameter("@AdditionalCSEAssessmentOrAuthorizationDescription",
                                            workPermit.AdditionItemsRequired.CSEAssessmentOrAuthorizationDescription);
            command.AddParameter("@AdditionalRadiationApproval",
                                            workPermit.AdditionItemsRequired.IsRadiationApproval);
            command.AddParameter("@AdditionalOnlineLeakRepairForm",
                                            workPermit.AdditionItemsRequired.IsOnlineLeakRepairForm);
            command.AddParameter("@AdditionalIsEnergizedElectricalForm", workPermit.AdditionItemsRequired.IsEnergizedElectricalForm);
            command.AddParameter("@AdditionalIsNotApplicable", workPermit.AdditionItemsRequired.IsNotApplicable);

            if (isDenver || IsSarnia)  //Added By Vibhor : RITM0627539 - Denver Site upgrades
            {
                command.AddParameter("@PreExcavationAuthorization", workPermit.AdditionItemsRequired.PreExcavationAuthorization);
                command.AddParameter("@SuspendedWorkPlatform", workPermit.AdditionItemsRequired.SuspendedWorkPlatform);
                command.AddParameter("@HotTurnoverApproval", workPermit.AdditionItemsRequired.HotTurnoverApproval);
                command.AddParameter("@ConfinedSpaceEntryAuthorizationForm", workPermit.AdditionItemsRequired.ConfinedSpaceEntryAuthorizationForm);
                command.AddParameter("@PreExcavationAuthorizationForm", workPermit.AdditionItemsRequired.PreExcavationAuthorizationForm);
                command.AddParameter("@SupplementalJobSiteSignInForm", workPermit.AdditionItemsRequired.SupplementalJobSiteSignInForm);
                command.AddParameter("@SystemEntryGasTestLogFrom", workPermit.AdditionItemsRequired.SystemEntryGasTestLogFrom);
                command.AddParameter("@HeatStressMonitoringForm", workPermit.AdditionItemsRequired.HeatStressMonitoringForm);
                command.AddParameter("@CriticalLiftApprovalForm", workPermit.AdditionItemsRequired.CriticalLiftApprovalForm);
                command.AddParameter("@PjsrSecondSection", workPermit.AdditionItemsRequired.PjsrSecondSection);
                command.AddParameter("@DeviationRequestForm", workPermit.AdditionItemsRequired.DeviationRequestForm);
                command.AddParameter("@RoadClosureform", workPermit.AdditionItemsRequired.RoadClosureform);
                command.AddParameter("@RadiographyApprovalForm", workPermit.AdditionItemsRequired.RadiographyApprovalForm);
                command.AddParameter("@ConfinedSpaceEntryTrackingLog", workPermit.AdditionItemsRequired.ConfinedSpaceEntryTrackingLog);
                command.AddParameter("@FlareLineChecklists", workPermit.AdditionItemsRequired.FlareLineChecklists);
                command.AddParameter("@HotTurnoverApprovalForm", workPermit.AdditionItemsRequired.HotTurnoverApprovalForm);
                command.AddParameter("@IndustrialHygieneAreaRealTimeSamplingForm", workPermit.AdditionItemsRequired.IndustrialHygieneAreaRealTimeSamplingForm);
                command.AddParameter("@CraneSuspendedWorkPlatformChecklist", workPermit.AdditionItemsRequired.CraneSuspendedWorkPlatformChecklist);
                command.AddParameter("@ConfinedSpaceEntryAuthorizationFormSecondSection", workPermit.AdditionItemsRequired.ConfinedSpaceEntryAuthorizationFormSecondSection);
                command.AddParameter("@NASecondSection", workPermit.AdditionItemsRequired.NASecondSection);
            }
            
            
            
            SetWorkPermitAttributes(command, workPermit.Attributes);
            SetWorkPermitSpecifics(command, workPermit.Specifics);

            command.AddParameter("@SpecialPrecautionsOrConsiderationsDescription",
                                            workPermit.SpecialPrecautionsOrConsiderations);

            if (workPermit.WorkPermitTypeClassification != null)
            {
                command.AddParameter("@WorkPermitTypeClassificationId",
                                                workPermit.WorkPermitTypeClassification.Id);
            }
            else
            {
                command.AddParameter("@WorkPermitTypeClassificationId", DBNull.Value);
            }

            command.AddParameter("@WorkPermitTypeId", workPermit.WorkPermitType.Id);
            command.AddParameter("@PermitValidDateTime", workPermit.PermitValidDateTime);
            command.AddParameter("@WorkPermitStatusId", workPermit.WorkPermitStatus.Id);
            command.AddParameter("@SapOperationId", workPermit.SapOperationId);
        }

        private static void SetWorkPermitSpecifics(SqlCommand command, WorkPermitSpecifics specifics)
        {
            command.AddParameter("@CommunicationByRadio", specifics.Communication.ByRadio);
            command.AddParameter("@CommunicationByOtherDescription", specifics.Communication.Description);
            command.AddParameter("@CommunicationRadioColor", specifics.Communication.RadioColor);
            command.AddParameter("@CommunicationRadioChannelOrBand", specifics.Communication.RadioChannel);
            command.AddParameter("@IsWorkPermitCommunicationNotApplicable",
                                            specifics.Communication.IsWorkPermitCommunicationNotApplicable);

            command.AddParameter("@JobStepDescription", specifics.JobStepDescription);

            if (specifics.CraftOrTrade == null)
            {
                command.AddParameter("@CraftOrTradeID", null);
            }
            else
            {
                specifics.CraftOrTrade.PerformAction(() =>
                                                         {
                                                             var craftOrTrade = (CraftOrTrade) specifics.CraftOrTrade;
                                                             command.AddParameter("@CraftOrTradeID",
                                                                                             craftOrTrade.Id);
                                                             command.AddParameter("@CraftOrTradeOther", null);
                                                         },
                                                     () =>
                                                         {
                                                             command.AddParameter("@CraftOrTradeID", null);
                                                             command.AddParameter("@CraftOrTradeOther",
                                                                                             specifics.CraftOrTrade.Name);
                                                         });
            }

            command.AddParameter("@ContractorCompanyName", specifics.ContractorCompanyName);
            command.AddParameter("@ContactPersonnel", specifics.ContactName);
            command.AddParameter("@WorkOrderDescription", specifics.WorkOrderDescription);
            command.AddParameter("@EndDateTime", specifics.EndDateTime);
            command.AddParameter("@StartDateTime", specifics.StartDateTime);
            command.AddParameter("@StartTimeNotApplicable", specifics.StartTimeNotApplicable);
            command.AddParameter("@StartAndOrEndTimesFinalized", specifics.StartAndOrEndTimesFinalized);
            command.AddParameter("@WorkOrderNumber", specifics.WorkOrderNumber);
            command.AddParameter("@FunctionalLocationId", specifics.FunctionalLocation.Id);

            long? workAssignmentId = specifics.WorkAssignment != null ? specifics.WorkAssignment.Id : null;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
        }

        private static void SetWorkPermitAttributes(SqlCommand command, WorkPermitAttributes attributes)
        {
            command.AddParameter("@PermitRadiationSealed", attributes.IsRadiationSealed);
            command.AddParameter("@PermitRadiationRadiography", attributes.IsRadiationRadiography);
            if (IsSarnia || isDenver)
            {
                command.AddParameter("@PermitFreshAir", attributes.IsFreshAir);// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }
            
            command.AddParameter("@PermitAsbestos", attributes.IsAsbestos);
            command.AddParameter("@PermitExcavation", attributes.IsExcavation);
            command.AddParameter("@PermitElectricalWork", attributes.IsElectricalWork);
            command.AddParameter("@PermitCriticalLift", attributes.IsCriticalLift);
            command.AddParameter("@PermitSystemEntry", attributes.IsSystemEntry);
            command.AddParameter("@PermitBurnOrOpenFlame", attributes.IsBurnOrOpenFlame);
            command.AddParameter("@PermitHotTap", attributes.IsHotTap);
            command.AddParameter("@PermitVehicleEntry", attributes.IsVehicleEntry);
            command.AddParameter("@PermitBreathingAirOrSCBA", attributes.IsBreathingAirOrSCBA);
            command.AddParameter("@PermitConfinedSpaceEntry", attributes.IsConfinedSpaceEntry);
            command.AddParameter("@PermitInertConfinedSpaceEntry", attributes.IsInertConfinedSpaceEntry);
            command.AddParameter("@PermitLeadAbatement", attributes.IsLeadAbatement);
        }

        private static WorkPermitCommunication PopulateWorkPermitCommunication(SqlDataReader reader)
        {
            var result = new WorkPermitCommunication
                             {
                                 RadioChannel = reader.Get<string>("CommunicationRadioChannelOrBand"),
                                 RadioColor = reader.Get<string>("CommunicationRadioColor"),
                                 ByRadio = reader.Get<bool?>("CommunicationByRadio"),
                                 Description = reader.Get<string>("CommunicationByOtherDescription"),
                                 IsWorkPermitCommunicationNotApplicable =
                                     reader.Get<bool>("IsWorkPermitCommunicationNotApplicable")
                             };
            return result;
        }

        /// <summary>
        /// Pull out the acid clothing type object if it exists (nullable)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static AcidClothingType PopulateAcidClothingType(SqlDataReader reader)
        {
            AcidClothingType result = null;

            int? specialProtectiveClothingTypeId = reader.Get<int?>("SpecialProtectiveClothingTypeAcidClothingTypeID");
            if (specialProtectiveClothingTypeId.HasValue)
            {
                result = AcidClothingType.Get(specialProtectiveClothingTypeId.Value);
            }

            return result;
        }

        private static WorkPermitAdditionalItemsRequired PopulateWorkPermitAdditionalItemsRequired(SqlDataReader reader)
        {
            WorkPermitAdditionalItemsRequired result = new WorkPermitAdditionalItemsRequired
                             {
                                 IsHotTap = reader.Get<bool>("AdditionalHotTap"),
                                 IsExcavation = reader.Get<bool>("AdditionalExcavation"),
                                 ExcavationDescription = reader.Get<string>("AdditionalExcavationDescription"),
                                 IsCriticalLift = reader.Get<bool>("AdditionalCriticalLift"),
                                 CriticalLiftDescription = reader.Get<string>("AdditionalCriticalLiftDescription"),
                                 IsFlareEntry = reader.Get<bool>("AdditionalFlareEntry"),
                                 IsCSEAssessmentOrAuthorization = reader.Get<bool>("AdditionalCSEAssessmentOrAuthorization"),
                                 CSEAssessmentOrAuthorizationDescription = reader.Get<string>("AdditionalCSEAssessmentOrAuthorizationDescription"),
                                 IsMSDS = reader.Get<bool>("AdditionalMSDS"),
                                 IsWaiverOrDeviation = reader.Get<bool>("AdditionalWaiverOrDeviation"),
                                 WaiverOrDeviationDescription = reader.Get<string>("AdditionalWaiverOrDeviationDescription"),
                                 IsBurnOrOpenFlameAssessment = reader.Get<bool>("AdditionalBurnOrOpenFlameAssessment"),
                                 BurnOrOpenFlameAssessmentDescription = reader.Get<string>("AdditionalBurnOrOpenFlameAssessmentDescription"),
                                 IsElectrical = reader.Get<bool>("AdditionalElectrical"),
                                 ElectricalDescription = reader.Get<string>("AdditionalElectricalDescription"),
                                 IsRoadClosure = reader.Get<bool>("AdditionalRoadClosure"),
                                 IsAsbestosHandling = reader.Get<bool>("AdditionalAsbestosHandling"),
                                 AsbestosHandlingDescription = reader.Get<string>("AdditionalAsbestosHandlingDescription"),
                                 IsPJSROrSafetyPause = reader.Get<bool>("AdditionalPJSROrSafetyPause"),
                                 IsBlankOrBlindLists = reader.Get<bool>("AdditionalBlankOrBlindLists"),
                                 IsSpecialWasteDisposal = reader.Get<bool>("AdditionalSpecialWasteDisposal"),
                                 IsRadiationApproval = reader.Get<bool>("AdditionalRadiationApproval"),
                                 IsOnlineLeakRepairForm = reader.Get<bool>("AdditionalOnlineLeakRepairForm"),
                                 IsEnergizedElectricalForm = reader.Get<bool>("AdditionalIsEnergizedElectricalForm"),
                                 IsNotApplicable = reader.Get<bool>("AdditionalIsNotApplicable"),
                                 OtherItemDescription =
                                     reader.Get<string>("AdditionalOtherFormsOrAssessmentsOrAuthorizations"),
                                 NASecondSection = reader.Get<bool>("NASecondSection"),

                                     
//Added By Vibhor : RITM0627539 - Denver Site upgrades

                                 PreExcavationAuthorization = reader.Get<bool>("PreExcavationAuthorization"),
                                 SuspendedWorkPlatform = reader.Get<bool>("SuspendedWorkPlatform"),
                                 HotTurnoverApproval = reader.Get<bool>("HotTurnoverApproval"),
                                 ConfinedSpaceEntryAuthorizationForm = reader.Get<bool>("ConfinedSpaceEntryAuthorizationForm"),
                                 PreExcavationAuthorizationForm = reader.Get<bool>("PreExcavationAuthorizationForm"),
                                 SupplementalJobSiteSignInForm = reader.Get<bool>("SupplementalJobSiteSignInForm"),
                                 SystemEntryGasTestLogFrom = reader.Get<bool>("SystemEntryGasTestLogFrom"),
                                 HeatStressMonitoringForm = reader.Get<bool>("HeatStressMonitoringForm"),
                                 CriticalLiftApprovalForm = reader.Get<bool>("CriticalLiftApprovalForm"),
                                 PjsrSecondSection = reader.Get<bool>("PjsrSecondSection"),
                                 DeviationRequestForm = reader.Get<bool>("DeviationRequestForm"),
                                 RoadClosureform = reader.Get<bool>("RoadClosureform"),
                                 RadiographyApprovalForm = reader.Get<bool>("RadiographyApprovalForm"),
                                 ConfinedSpaceEntryTrackingLog = reader.Get<bool>("ConfinedSpaceEntryTrackingLog"),
                                 FlareLineChecklists = reader.Get<bool>("FlareLineChecklists"),
                                 HotTurnoverApprovalForm = reader.Get<bool>("HotTurnoverApprovalForm"),
                                 IndustrialHygieneAreaRealTimeSamplingForm = reader.Get<bool>("IndustrialHygieneAreaRealTimeSamplingForm"),
                                 CraneSuspendedWorkPlatformChecklist = reader.Get<bool>("CraneSuspendedWorkPlatformChecklist"),
                                 ConfinedSpaceEntryAuthorizationFormSecondSection = reader.Get<bool>("ConfinedSpaceEntryAuthorizationFormSecondSection")



                             };
            return result;
        }

// Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue

            private static WorkPermitAdditionalItemsRequired PopulateWorkPermitAdditionalItemsRequiredForSELC(SqlDataReader reader)
        {
            WorkPermitAdditionalItemsRequired result = new WorkPermitAdditionalItemsRequired
                             {
                                 IsHotTap = reader.Get<bool>("AdditionalHotTap"),
                                 IsExcavation = reader.Get<bool>("AdditionalExcavation"),
                                 ExcavationDescription = reader.Get<string>("AdditionalExcavationDescription"),
                                 IsCriticalLift = reader.Get<bool>("AdditionalCriticalLift"),
                                 CriticalLiftDescription = reader.Get<string>("AdditionalCriticalLiftDescription"),
                                 IsFlareEntry = reader.Get<bool>("AdditionalFlareEntry"),
                                 IsCSEAssessmentOrAuthorization = reader.Get<bool>("AdditionalCSEAssessmentOrAuthorization"),
                                 CSEAssessmentOrAuthorizationDescription = reader.Get<string>("AdditionalCSEAssessmentOrAuthorizationDescription"),
                                 IsMSDS = reader.Get<bool>("AdditionalMSDS"),
                                 IsWaiverOrDeviation = reader.Get<bool>("AdditionalWaiverOrDeviation"),
                                 WaiverOrDeviationDescription = reader.Get<string>("AdditionalWaiverOrDeviationDescription"),
                                 IsBurnOrOpenFlameAssessment = reader.Get<bool>("AdditionalBurnOrOpenFlameAssessment"),
                                 BurnOrOpenFlameAssessmentDescription = reader.Get<string>("AdditionalBurnOrOpenFlameAssessmentDescription"),
                                 IsElectrical = reader.Get<bool>("AdditionalElectrical"),
                                 ElectricalDescription = reader.Get<string>("AdditionalElectricalDescription"),
                                 IsRoadClosure = reader.Get<bool>("AdditionalRoadClosure"),
                                 IsAsbestosHandling = reader.Get<bool>("AdditionalAsbestosHandling"),
                                 AsbestosHandlingDescription = reader.Get<string>("AdditionalAsbestosHandlingDescription"),
                                 IsPJSROrSafetyPause = reader.Get<bool>("AdditionalPJSROrSafetyPause"),
                                 IsBlankOrBlindLists = reader.Get<bool>("AdditionalBlankOrBlindLists"),
                                 IsSpecialWasteDisposal = reader.Get<bool>("AdditionalSpecialWasteDisposal"),
                                 IsRadiationApproval = reader.Get<bool>("AdditionalRadiationApproval"),
                                 IsOnlineLeakRepairForm = reader.Get<bool>("AdditionalOnlineLeakRepairForm"),
                                 IsEnergizedElectricalForm = reader.Get<bool>("AdditionalIsEnergizedElectricalForm"),
                                 IsNotApplicable = reader.Get<bool>("AdditionalIsNotApplicable"),
                                 OtherItemDescription =
                                     reader.Get<string>("AdditionalOtherFormsOrAssessmentsOrAuthorizations"),
                                 //NASecondSection = reader.Get<bool>("NASecondSection"),

                             };
            return result;
        }

        private static WorkPermitTools PopulateWorkPermitTools(SqlDataReader reader)
        {
            WorkPermitTools result = new WorkPermitTools
                             {
                                 OtherToolsDescription = reader.Get<string>("ToolsOtherToolsDescription"),
                                 IsWelder = reader.Get<bool>("ToolsWelder"),
                                 IsChemicals = reader.Get<bool>("ToolsChemicals"),
                                 IsTorch = reader.Get<bool>("ToolsTorch"),
                                 IsPortLighting = reader.Get<bool>("ToolsPortLighting"),
                                 IsHotTapMachine = reader.Get<bool>("ToolsHotTapMachine"),
                                 IsTamper = reader.Get<bool>("ToolsTamper"),
                                 IsManlift = reader.Get<bool>("ToolsManlift"),
                                 IsHEPAVacuum = reader.Get<bool>("ToolsHEPAVacuum"),
                                 IsForklift = reader.Get<bool>("ToolsForklift"),
                                 IsCompressor = reader.Get<bool>("ToolsCompressor"),
                                 IsVehicle = reader.Get<bool>("ToolsVehicle"),
                                 IsScaffolding = reader.Get<bool>("ToolsScaffolding"),
                                 IsLanda = reader.Get<bool>("ToolsLanda"),
                                 IsHeavyEquipment = reader.Get<bool>("ToolsHeavyEquipment"),
                                 IsElectricTools = reader.Get<bool>("ToolsElectricTools"),
                                 IsCementSaw = reader.Get<bool>("ToolsCementSaw"),
                                 IsVacuumTruck = reader.Get<bool>("ToolsVacuumTruck"),
                                 IsJackhammer = reader.Get<bool>("ToolsJackhammer"),
                                 IsHandTools = reader.Get<bool>("ToolsHandTools"),
                                 IsCraneOrCarrydeck = reader.Get<bool>("ToolsCraneOrCarrydeck"),
                                 IsAirTools = reader.Get<bool>("ToolsAirTools")
                             };
            return result;
        }

        private static void PopulateWorkPermitEquipmentPreparationCondition(WorkPermitEquipmentPreparationCondition equipment, SqlDataReader reader)
        {
            equipment.IsolationMethodOtherDescription = reader.Get<string>("EquipmentIsolationMethodOtherDescription");
            equipment.IsIsolationMethodBlockedIn = reader.Get<bool>("EquipmentIsolationMethodBlockedIn");
            equipment.IsIsolationMethodCarBer = reader.Get<bool>("EquipmentIsolationMethodCarBer");
            equipment.IsIsolationMethodMudderPlugs = reader.Get<bool>("EquipmentIsolationMethodMudderPlugs");
            equipment.IsIsolationMethodSeparation = reader.Get<bool>("EquipmentIsolationMethodSeparation");
            equipment.IsIsolationMethodBlindedorBlanked = reader.Get<bool>("EquipmentIsolationMethodBlindedorBlanked");
            equipment.IsIsolationMethodLOTO = reader.Get<bool>("EquipmentIsolationMethodLOTO");
            equipment.IsIsolationMethodNotApplicable = reader.Get<bool>("EquipmentIsolationMethodNotApplicable");
            equipment.PreviousContentsOtherDescription = reader.Get<string>("EquipmentPreviousContentsOtherDescription");
            equipment.IsPreviousContentsH2S = reader.Get<bool>("EquipmentPreviousContentsH2S");
            equipment.IsPreviousContentsCaustic = reader.Get<bool>("EquipmentPreviousContentsCaustic");
            equipment.IsPreviousContentsAcid = reader.Get<bool>("EquipmentPreviousContentsAcid");
            equipment.IsPreviousContentsHydrocarbon = reader.Get<bool>("EquipmentPreviousContentsHydrocarbon");
            equipment.IsPreviousContentsNotApplicable = reader.Get<bool>("EquipmentPreviousContentsNotApplicable");
            equipment.ConditionPurgedDescription = reader.Get<string>("EquipmentConditionPurgedDescription");
            equipment.IsConditionPurged = reader.Get<bool>("EquipmentConditionPurged");
            equipment.IsConditionPurgedN2 = reader.Get<bool>("EquipmentConditionPurgedN2");
            equipment.IsConditionPurgedSteamed = reader.Get<bool>("EquipmentConditionPurgedSteamed");
            equipment.IsConditionPurgedAir = reader.Get<bool>("EquipmentConditionPurgedAir");
            equipment.IsConditionNeutralized = reader.Get<bool>("EquipmentConditionNeutralized");
            equipment.IsConditionH20Washed = reader.Get<bool>("EquipmentConditionH20Washed");
            equipment.IsConditionVentilated = reader.Get<bool>("EquipmentConditionVentilated");
            equipment.IsConditionCleaned = reader.Get<bool>("EquipmentConditionCleaned");
            if (IsSarnia || isDenver)
            {
                equipment.IsConditionPurgedCheckbox = reader.Get<bool>("EquipmentConditionPurgedChecked"); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            }
            
            equipment.IsConditionDrained = reader.Get<bool>("EquipmentConditionDrained");
            equipment.IsConditionDepressured = reader.Get<bool>("EquipmentConditionDepressured");
            equipment.IsConditionNotApplicable = reader.Get<bool>("EquipmentConditionNotApplicable");
            equipment.ConditionOtherDescription = reader.Get<string>("EquipmentConditionOtherDescription");

            equipment.IsAsbestosGasketsNotApplicable = reader.Get<bool>("EquipmentAsbestosGasketsNotApplicable");
            equipment.IsAsbestosGaskets = reader.Get<bool?>("EquipmentAsbestosGaskets");

            equipment.IsOutOfService = reader.Get<bool?>("EquipmentIsOutOfService");
            equipment.IsLeakingValves = reader.Get<bool?>("EquipmentLeakingValves");
            equipment.IsLeakingValvesNotApplicable = reader.Get<bool>("EquipmentLeakingValvesNotApplicable");
            equipment.InServiceComments = reader.Get<string>("EquipmentInServiceComments");
            if (IsSarnia || isDenver)
            {
                
                equipment.InAsbestosHazardPresentComments = reader.Get<string>("EquipmentInAsbestosHazardPresentComments"); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                //equipment.InHazardousEnergyIsolationComments = reader.Get<string>("EquipmentInHazardousEnergyIsolationComments"); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia    
            }
            
            
            equipment.NoElectricalTestBumpComments = reader.Get<string>("EquipmentNoElectricalTestBumpComments");
            equipment.StillContainsResidualComments = reader.Get<string>("EquipmentStillContainsResidualComments");
            equipment.LeakingValvesComments = reader.Get<string>("EquipmentLeakingValvesComments");
            equipment.IsStillContainsResidual = reader.Get<bool?>("EquipmentStillContainsResidual");
            equipment.IsStillContainsResidualNotApplicable = reader.Get<bool>("EquipmentStillContainsResidualNotApplicable");
            equipment.IsVentilationMethodForced = reader.Get<bool>("EquipmentVentilationMethodForced");
            equipment.IsVentilationMethodLocalExhaust = reader.Get<bool>("EquipmentVentilationMethodLocalExhaust");
            equipment.IsVentilationMethodNaturalDraft = reader.Get<bool>("EquipmentVentilationMethodNaturalDraft");
            equipment.IsVentilationMethodNotApplicable = reader.Get<bool>("EquipmentVentilationMethodNotApplicable");
            equipment.IsTestBump = reader.Get<bool?>("ElectricTestBump");
            equipment.IsTestBumpNotApplicable = reader.Get<bool>("ElectricTestBumpNotApplicable");
            equipment.IsElectricalIsolationMethodWiring = reader.Get<bool>("ElectricIsolationMethodWiring");
            equipment.IsElectricalIsolationMethodLOTO = reader.Get<bool>("ElectricIsolationMethodLOTO");
            equipment.IsElectricalIsolationMethodNotApplicable = reader.Get<bool>("ElectricIsolationMethodNotApplicable");

            equipment.IsHazardousEnergyIsolationRequiredNotApplicable = reader.Get<bool>("EquipmentIsHazardousEnergyIsolationRequiredNotApplicable");
            equipment.IsHazardousEnergyIsolationRequired = reader.Get<bool?>("EquipmentIsHazardousEnergyIsolationRequired");
            long? lockoutMethodId = reader.Get<long?>("EquipmentLockOutMethodId");
            if(lockoutMethodId.HasValue)
            {
                equipment.LockOutMethod = WorkPermitLockOutMethodType.Get(lockoutMethodId.Value);
            }
            equipment.LockOutMethodComments = reader.Get<string>("EquipmentLockOutMethodComments");
            equipment.EnergyIsolationPlanNumber = reader.Get<string>("EquipmentEnergyIsolationPlanNumber");
            equipment.ConditionsOfEIPSatisfied = reader.Get<bool?>("EquipmentConditionsOfEIPSatisfied");
            equipment.ConditionsOfEIPNotSatisfiedComments = reader.Get<string>("EquipmentConditionsOfEIPNotSatisfiedComments");
        }

        private static void PopulateAsbestos(WorkPermitAsbestos result, SqlDataReader reader)
        {
            result.HazardsConsideredNotApplicable = reader.Get<bool>("AsbestosHazardsConsideredNotApplicable");
            result.HazardsConsidered = reader.Get<bool?>("AsbestosHazardsConsidered");
        }

        private static WorkPermitJobWorksitePreparation PopulateWorkPermitJobWorksitePreparation(SqlDataReader reader)
        {
            var result = new WorkPermitJobWorksitePreparation
                             {
                                 LightingElectricalRequirementOtherDescription =
                                     reader.Get<string>("JobSitePreparationLightingElectricalRequirementOtherDescription"),
                                 IsLightingElectricalRequirementGeneratorLights =
                                     reader.Get<bool>("JobSitePreparationLightingElectricalRequirementGeneratorLights"),
                                 IsLightingElectricalRequirement110VWithGFCI =
                                     reader.Get<bool>("JobSitePreparationLightingElectricalRequirement110VWithGFCI"),
                                 IsLightingElectricalRequirementLowVoltage12V =
                                     reader.Get<bool>("JobSitePreparationLightingElectricalRequirementLowVoltage12V"),
                                 IsLightingElectricalRequirementNotApplicable =
                                     reader.Get<bool>("JobSitePreparationLightingElectricalRequirementNotApplicable"),
                                 AreaPreparationOtherDescription =
                                     reader.Get<string>("JobSitePreparationAreaPreparationOtherDescription"),
                                 IsAreaPreparationBoundaryRopeTape =
                                     reader.Get<bool>("JobSitePreparationAreaPreparationPreopBoundaryRopeTape"),
                                 IsAreaPreparationRadiationRope =
                                     reader.Get<bool>("JobSitePreparationAreaPreparationRadiationRope"),
                                 IsAreaPreparationNonEssentialEvac =
                                     reader.Get<bool>("JobSitePreparationAreaPreparationNonEssentialEvac"),
                                 IsAreaPreparationBarricade =
                                     reader.Get<bool>("JobSitePreparationAreaPreparationBarricade"),
                                 IsAreaPreparationNotApplicable =
                                     reader.Get<bool>("JobSitePreparationAreaPreparationNotApplicable"),
                                 SewerIsolationMethodOtherDescription =
                                     reader.Get<string>("JobSitePreparationSewerIsolationMethodOtherDescription"),
                                 IsSewerIsolationMethodBlindedOrBlanked =
                                     reader.Get<bool>("JobSitePreparationSewerIsolationMethodBlindedOrBlanked"),
                                 IsSewerIsolationMethodPlugged =
                                     reader.Get<bool>("JobSitePreparationSewerIsolationMethodPlugged"),
                                 IsSewerIsolationMethodSealedOrCovered =
                                     reader.Get<bool>("JobSitePreparationSewerIsolationMethodSealedOrCovered"),
                                 IsSewerIsolationMethodNotApplicable =
                                     reader.Get<bool>("JobSitePreparationSewerIsolationMethodNotApplicable"),
                                 IsPermitReceiverFieldOrEquipmentOrientation =
                                     reader.Get<bool?>("JobSitePreparationPermitReceiverFieldOrEquipmentOrientation"),

                            
                                IsControlRoomContactedOrNot =IsSarnia || isDenver?   reader.Get<bool?>("IsControlRoomContactedOrNot"):false,  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                             
                                 

                                 IsPermitReceiverFieldOrEquipmentOrientationNotApplicable =
                                     reader.Get<bool>("JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable"),
                                 IsVestedBuddySystemInEffect =
                                     reader.Get<bool?>("JobSitePreparationVestedBuddySystemInEffect"),
                                 IsVestedBuddySystemInEffectNotApplicable =
                                     reader.Get<bool>("JobSitePreparationVestedBuddySystemInEffectNotApplicable"),
                                 IsSurroundingConditionsAffectOrContaminated =
                                     reader.Get<bool?>("JobSitePreparationSurroundingConditionsAffectOrContaminated"),
                                 IsSurroundingConditionsAffectOrContaminatedNotApplicable =
                                     reader.Get<bool>("JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable"),
                                 IsCriticalConditionRemainJobSite =
                                     reader.Get<bool?>("JobSitePreparationCriticalConditionRemainJobSite"),
                                 IsCriticalConditionRemainJobSiteNotApplicable =
                                     reader.Get<bool>("JobSitePreparationCriticalConditionRemainJobSiteNotApplicable"),

                                   // if (IsSarnia)
                                        IsControlRoomContactedNotApplicable = IsSarnia || isDenver ? reader.Get<bool>("ControlRoomContactedNotApplicable") : false, // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                                     

                                 IsWeldingGroundWireInTestArea =
                                     reader.Get<bool?>("JobSitePreparationWeldingGroundWireInTestArea"),
                                 IsWeldingGroundWireInTestAreaNotApplicable =
                                     reader.Get<bool>("JobSitePreparationWeldingGroundWireInTestAreaNotApplicable"),
                                 IsBondingOrGroundingRequired =
                                     reader.Get<bool?>("JobSitePreparationBondingOrGroundingRequired"),
                                 IsBondingOrGroundingRequiredNotApplicable =
                                     reader.Get<bool>("JobSitePreparationBondingOrGroundingRequiredNotApplicable"),
                                 IsFlowRequiredForJobNotApplicable =
                                     reader.Get<bool>("JobSitePreparationFlowRequiredForJobNotApplicable"),
                                 IsFlowRequiredForJob = reader.Get<bool?>("JobSitePreparationFlowRequiredForJob"),
                                 FlowRequiredComments = reader.Get<string>("JobSitePreparationFlowRequiredComments"),
                                 BondingGroundingNotRequiredComments =
                                     reader.Get<string>("JobSitePreparationBondingGroundingNotRequiredComments"),
                                 WeldingGroundWireNotWithinGasTestAreaComments =
                                     reader.Get<string>("JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments"),
                                 SurroundingConditionsAffectAreaComments =
                                     reader.Get<string>("JobSitePreparationSurroundingConditionsAffectAreaComments"),
                                 CriticalConditionsComments =
                                     reader.Get<string>("JobSitePreparationCriticalConditionsComments"),
                                 PermitReceiverRequiresOrientationComments =
                                     reader.Get<string>("JobSitePreparationPermitReceiverRequiresOrientationComments")
                             };

            return result;
        }

        private static WorkPermitRadiationInformation PopulateWorkPermitRadiationInformation(SqlDataReader reader)
        {
            WorkPermitRadiationInformation result = new WorkPermitRadiationInformation
                             {
                                 SealedSourceIsolationNumberOfSources =
                                     reader.Get<int?>("RadiationSealedSourceIsolationNumberOfSources"),
                                 IsSealedSourceIsolationOpen = reader.Get<bool>("RadiationSealedSourceIsolationOpen"),
                                 IsSealedSourceIsolationLOTO = reader.Get<bool>("RadiationSealedSourceIsolationLOTO"),
                                 IsSealedSourceIsolationNotApplicable =
                                     reader.Get<bool>("RadiationSealedSourceIsolationNotApplicable")
                             };

            return result;
        }

        private WorkPermitGasTests PopulateWorkPermitGasTests(SqlDataReader reader, long workPermitId)
        {
            WorkPermitGasTests result = new WorkPermitGasTests
                             {
                                 ConstantMonitoringRequired = reader.Get<bool>("GasTestConstantMonitoringRequired"),
                                 FrequencyOrDuration = reader.Get<string>("GasTestFrequencyOrDuration"),
                                 ForkliftNotUsed = reader.Get<bool>("GasTestForkliftNotUsed")
                             };

            DateTime? testTime = reader.Get<DateTime?>("GasTestTestTime");
            result.ImmediateAreaTestTime = testTime.HasValue ? new Time(testTime.Value) : null;

            DateTime? confinedSpaceTestTime = reader.Get<DateTime?>("GasTestConfinedSpaceTestTime");
            result.ConfinedSpaceTestTime = confinedSpaceTestTime.HasValue ? new Time(confinedSpaceTestTime.Value) : null;

            DateTime? systemEntryTestTime = reader.Get<DateTime?>("GasTestSystemEntryTestTime");
            result.SystemEntryTestTime = systemEntryTestTime.HasValue ? new Time(systemEntryTestTime.Value) : null;
            FunctionalLocation floc = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            result.Elements = gasTestElementDao.QueryAllGasTestElementByWorkPermitIdAndSiteId(workPermitId,floc.Site.IdValue);        //ayman USPipeline workpermit

            return result;
        }

        private static WorkPermitFireConfinedSpaceRequirements PopulateWorkPermitFireConfinedSpaceRequirements(SqlDataReader reader)
        {
            var result = new WorkPermitFireConfinedSpaceRequirements
                             {
                                 IsNotApplicable = reader.Get<bool>("FireConfinedSpaceNotApplicable"),
                                 OtherDescription = reader.Get<string>("FireConfinedSpaceOtherDescription"),
                                 HoleWatchNumber = reader.Get<string>("FireConfinedSpaceHoleWatchNumber"),
                                 FireWatchNumber = reader.Get<string>("FireConfinedSpaceFireWatchNumber"),
                                 SpotterNumber = reader.Get<string>("FireConfinedSpaceSpotterNumber"),
                                 IsWatchmen = reader.Get<bool>("FireConfinedSpaceWatchmen"),
                                 IsSteamHose = reader.Get<bool>("FireConfinedSpaceSteamHose"),
                                 IsWaterHose = reader.Get<bool>("FireConfinedSpaceWaterHose"),
                                 IsSparkContainment = reader.Get<bool>("FireConfinedSpaceSparkContainment"),
                                 IsFireResistantTarp = reader.Get<bool>("FireConfinedSpaceFireResistantTarp"),
                                 IsC02Extinguisher = reader.Get<bool>("FireConfinedSpaceC02Extinguisher"),
                                 IsTwentyABCorDryChemicalExtinguisher =
                                     reader.Get<bool>("FireConfinedSpace20ABCorDryChemicalExtinguisher")
                             };
            return result;
        }

        private static WorkPermitRespiratoryProtectionRequirements PopulateWorkPermitRespiratoryProtectionRequirements(SqlDataReader reader)
        {
            long? cartridgeTypeId = reader.Get<long?>("RespitoryProtectionRequirementsRespiratoryCartridgeTypeId");
            WorkPermitRespiratoryCartridgeType cartridgeType = cartridgeTypeId.HasValue ? WorkPermitRespiratoryCartridgeType.Get(cartridgeTypeId.Value) : null;

            var result = new WorkPermitRespiratoryProtectionRequirements
                             {
                                 IsNotApplicable = reader.Get<bool>("RespitoryProtectionRequirementsNotApplicable"),
                                 CartridgeTypeDescription =
                                     reader.Get<string>("RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription"),
                                 OtherDescription = reader.Get<string>("RespitoryProtectionRequirementsOtherDescription"),
                                 IsAirHood = reader.Get<bool>("RespitoryProtectionRequirementsAirHood"),
                                 IsDustMask = reader.Get<bool>("RespitoryProtectionRequirementsDustMask"),
                                 IsFullFaceRespirator =
                                     reader.Get<bool>("RespitoryProtectionRequirementsFullFaceRespirator"),
                                 IsHalfFaceRespirator =
                                     reader.Get<bool>("RespitoryProtectionRequirementsHalfFaceRespirator"),
                                 IsSCBA = reader.Get<bool>("RespitoryProtectionRequirementsSCBA"),
                                 IsAirCartorAirLine = reader.Get<bool>("RespitoryProtectionRequirementsAirCartOrAirLine"),
                                 CartridgeType = cartridgeType
                             };
            return result;
        }

        private static WorkPermitSpecialPPERequirements PopulateWorkPermitSpecialPPERequirements(SqlDataReader reader)
        {
            var result = new WorkPermitSpecialPPERequirements
                             {
                                 IsEyeOrFaceProtectionNotApplicable =
                                     reader.Get<bool>("SpecialEyeOrFaceProtectionNotApplicable"),
                                 EyeOrFaceProtectionOtherDescription =
                                     reader.Get<string>("SpecialEyeOrFaceProtectionOtherDescription"),
                                 IsEyeOrFaceProtectionFaceshield =
                                     reader.Get<bool>("SpecialEyeOrFaceProtectionFaceshield"),
                                 IsEyeOrFaceProtectionGoggles = reader.Get<bool>("SpecialEyeOrFaceProtectionGoggles"),
                                 IsRescueOrFallNotApplicable = reader.Get<bool>("SpecialRescueOrFallNotApplicable"),
                                 RescueOrFallOtherDescription = reader.Get<string>("SpecialRescueOrFallOtherDescription"),
                                 IsRescueOrFallRescueDevice = reader.Get<bool>("SpecialRescueOrFallRescueDevice"),
                                 IsRescueOrFallYoYo = reader.Get<bool>("SpecialRescueOrFallYoYo"),
                                 IsRescueOrFallLifeline = reader.Get<bool>("SpecialRescueOrFallLifeline"),
                                 IsRescueOrFallBodyHarness = reader.Get<bool>("SpecialRescueOrFallBodyHarness"),
                                 FallOtherDescription = reader.Get<string>("SpecialFallOtherDescription"),
                                 FallRestraint = reader.Get<bool>("SpecialFallRestraint"),
                                 FallSelfRetractingDevice = reader.Get<bool>("SpecialFallSelfRetractingDevice"),
                                 FallTieoffRequired = reader.Get<bool?>("SpecialFallTieoffRequired"),
                                 IsHandProtectionNotApplicable = reader.Get<bool>("SpecialHandProtectionNotApplicable"),
                                 HandProtectionOtherDescription =
                                     reader.Get<string>("SpecialHandProtectionOtherDescription"),
                                 IsHandProtectionChemicalGloves = reader.Get<bool>("SpecialHandProtectionChemicalGloves"),
                                 IsHandProtectionLeather = reader.Get<bool>("SpecialHandProtectionLeather"),
                                 IsHandProtectionWelding = reader.Get<bool>("SpecialHandProtectionWelding"),
                                 IsHandProtectionHighVoltage = reader.Get<bool>("SpecialHandProtectionHighVoltage"),                                 
                                 IsHandProtectionPVC = reader.Get<bool>("SpecialHandProtectionPVC"),
                                 IsHandProtectionNitrile = reader.Get<bool>("SpecialHandProtectionNitrile"),
                                 IsHandProtectionNaturalRubber = reader.Get<bool>("SpecialHandProtectionNaturalRubber"),
                                 IsHandProtectionChemicalNeoprene =
                                     reader.Get<bool>("SpecialHandProtectionChemicalNeprene"),
                                 IsProtectiveFootwearNotApplicable =
                                     reader.Get<bool>("SpecialProtectiveFootwearNotApplicable"),
                                 ProtectiveFootwearOtherDescription =
                                     reader.Get<string>("SpecialProtectiveFootwearOtherDescription"),
                                 IsProtectiveFootwearToeGuard = reader.Get<bool>("SpecialProtectiveFootwearToeGuard"),
                                 IsProtectiveFootwearChemicalImperviousBoots =
                                     reader.Get<bool>("SpecialProtectiveFootwearChemicalImperviousBoots"),
                                 IsProtectiveFootwearMetatarsalGuard =
                                     reader.Get<bool>("SpecialProtectiveFootwearMetatarsalGuard"),
                                 ProtectiveClothingTypeOtherDescription =
                                     reader.Get<string>("SpecialProtectiveClothingTypeOtherDescripton"),
                                 IsProtectiveClothingTypeNotApplicable =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeNotApplicable"),
                                 IsProtectiveClothingTypeCausticWear =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeCausticWear"),
                                 IsProtectiveClothingTypeTyvekSuit =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeTyvekSuit"),
                                 IsProtectiveClothingTypeKapplerSuit =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeKapplerSuit"),
                                 IsProtectiveClothingTypeElectricalFlashGear =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeElectricalFlashGear"),
                                 IsProtectiveClothingTypeCorrosiveClothing =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeCorrosiveClothing"),
                                 IsProtectiveClothingTypePaperCoveralls =
                                     reader.Get<bool>("SpecialProtectiveClothingTypePaperCoveralls"),
                                 ProtectiveClothingTypeAcidClothingType = PopulateAcidClothingType(reader),
                                 IsProtectiveClothingTypeAcidClothing =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeAcidClothing"),
                                 IsProtectiveClothingTypeRainPants =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeRainPants"),
                                 IsProtectiveClothingTypeRainCoat =
                                     reader.Get<bool>("SpecialProtectiveClothingTypeRainCoat")                                 
                             };

            return result;
        }


        //Adde by Mukesh for WOrkpermit Sign

        public WorkPermitSign GetWorkPermitSign(string WorkPermitId, int SiteId)
        {
            

            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", WorkPermitId);
            command.AddParameter("@SiteId", SiteId);

            return command.QueryForSingleResult<WorkPermitSign>(PopulateWorkPermitSign, "GETWORKPERMITSIGN");
        }

        public static WorkPermitSign PopulateWorkPermitSign(SqlDataReader reader)
        {
            WorkPermitSign objWorkPermitSign = new WorkPermitSign();

           
            objWorkPermitSign.WorkPermitId=reader.Get<string>("WorkPermitId");

            objWorkPermitSign.ISSUER_FNAME = reader.Get<string>("ISSUER_FNAME");
            objWorkPermitSign.ISSUER_LNAME = reader.Get<string>("ISSUER_LNAME");
            objWorkPermitSign.ISSUER_BADGENUMBER = reader.Get<string>("ISSUER_BADGENUMBER");
            objWorkPermitSign.ISSUER_BADGETYPE = reader.Get<string>("ISSUER_BADGETYPE");
            objWorkPermitSign.ISSUER_SOURCE = reader.Get<string>("ISSUER_SOURCE");


            objWorkPermitSign.NEXT_LVL_ISSUER_FNAME = reader.Get<string>("NEXT_LVL_ISSUER_FNAME");
            objWorkPermitSign.NEXT_LVL_ISSUER_LNAME = reader.Get<string>("NEXT_LVL_ISSUER_LNAME");
            objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER = reader.Get<string>("NEXT_LVL_ISSUER_BADGENUMBER");
            objWorkPermitSign.NEXT_LVL_ISSUER_BADGETYPE = reader.Get<string>("NEXT_LVL_ISSUER_BADGETYPE");
            objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE = reader.Get<string>("NEXT_LVL_ISSUER_SOURCE");


            objWorkPermitSign.PERMIT_RECEIVER_FNAME = reader.Get<string>("PERMIT_RECEIVER_FNAME");
            objWorkPermitSign.PERMIT_RECEIVER_LNAME = reader.Get<string>("PERMIT_RECEIVER_LNAME");
            objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER = reader.Get<string>("PERMIT_RECEIVER_BADGENUMBER");
            objWorkPermitSign.PERMIT_RECEIVER_BADGETYPE = reader.Get<string>("PERMIT_RECEIVER_BADGETYPE");
            objWorkPermitSign.PERMIT_RECEIVER_SOURCE = reader.Get<string>("PERMIT_RECEIVER_SOURCE");



            objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME = reader.Get<string>("CROSS_ZONE_AUTHO_FNAME");
            objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME = reader.Get<string>("CROSS_ZONE_AUTHO_LNAME");
            objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER = reader.Get<string>("CROSS_ZONE_AUTHO_BADGENUMBER");
            objWorkPermitSign.CROSS_ZONE_AUTHO_BADGETYPE = reader.Get<string>("CROSS_ZONE_AUTHO_BADGETYPE");
            objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE = reader.Get<string>("CROSS_ZONE_AUTHO_SOURCE");


            objWorkPermitSign.IMMIDIATE_FNAME = reader.Get<string>("IMMIDIATE_FNAME");
            objWorkPermitSign.IMMIDIATE_LNAME = reader.Get<string>("IMMIDIATE_LNAME");
            objWorkPermitSign.IMMIDIATE_BADGENUMBER = reader.Get<string>("IMMIDIATE_BADGENUMBER");
            objWorkPermitSign.IMMIDIATE_BADGETYPE = reader.Get<string>("IMMIDIATE_BADGETYPE");
            objWorkPermitSign.IMMIDIATE_SOURCE = reader.Get<string>("IMMIDIATE_SOURCE");

            objWorkPermitSign.CONFINED_FNAME = reader.Get<string>("CONFINED_FNAME");
            objWorkPermitSign.CONFINED_LNAME = reader.Get<string>("CONFINED_LNAME");
            objWorkPermitSign.CONFINED_BADGENUMBER = reader.Get<string>("CONFINED_BADGENUMBER");
            objWorkPermitSign.CONFINED_BADGETYPE = reader.Get<string>("CONFINED_BADGETYPE");
            objWorkPermitSign.CONFINED_SOURCE = reader.Get<string>("CONFINED_SOURCE");

            objWorkPermitSign.UpdatedBy = reader.Get<int>("UpdatedBy");
            objWorkPermitSign.CreatedBy = reader.Get<int>("CreatedBy");
            objWorkPermitSign.CreatedDate =Convert.ToString(reader.Get<DateTime>("CreatedDate"));
            objWorkPermitSign.UpdatedDate = Convert.ToString(reader.Get<DateTime>("UpdatedDate"));
            //objWorkPermitSign.SiteId =Convert.ToString(reader.Get<long?>("SiteId"));
            return objWorkPermitSign;
        }


        public void InserUpdateWorkPermitSign(WorkPermitSign workPermitSign)
        {
            ManagedCommand.ExecuteNonQuery(workPermitSign, "INSERTUPDATEWORKPERMITSIGN", AddSignParameters);
        }

        private static void AddSignParameters(WorkPermitSign objWorkPermitSign, SqlCommand command)
        {
            
            command.AddParameter("@WorkPermitId",objWorkPermitSign.WorkPermitId );

            command.AddParameter("@ISSUER_FNAME", objWorkPermitSign.ISSUER_FNAME);
            command.AddParameter("@ISSUER_LNAME", objWorkPermitSign.ISSUER_LNAME);
            command.AddParameter("@ISSUER_BADGENUMBER", objWorkPermitSign.ISSUER_BADGENUMBER);
            command.AddParameter("@ISSUER_BADGETYPE", objWorkPermitSign.ISSUER_BADGETYPE);
            command.AddParameter("@ISSUER_SOURCE", objWorkPermitSign.ISSUER_SOURCE);



            command.AddParameter("@NEXT_LVL_ISSUER_FNAME",objWorkPermitSign.NEXT_LVL_ISSUER_FNAME);
            command.AddParameter("@NEXT_LVL_ISSUER_LNAME", objWorkPermitSign.NEXT_LVL_ISSUER_LNAME);
            command.AddParameter("@NEXT_LVL_ISSUER_BADGENYMBER",objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER );
            command.AddParameter("@NEXT_LVL_ISSUER_BADGETYPE", objWorkPermitSign.NEXT_LVL_ISSUER_BADGETYPE);
            command.AddParameter("@NEXT_LVL_ISSUER_SOURCE", objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE);


            command.AddParameter("@PERMIT_RECEIVER_FNAME", objWorkPermitSign.PERMIT_RECEIVER_FNAME);
            command.AddParameter("@PERMIT_RECEIVER_LNAME", objWorkPermitSign.PERMIT_RECEIVER_LNAME);
            command.AddParameter("@PERMIT_RECEIVER_BADGENYMBER",objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER);
            command.AddParameter("@PERMIT_RECEIVER_BADGETYPE", objWorkPermitSign.PERMIT_RECEIVER_BADGETYPE);
            command.AddParameter("@PERMIT_RECEIVER_SOURCE", objWorkPermitSign.PERMIT_RECEIVER_SOURCE);


            command.AddParameter("@CROSS_ZONE_AUTHO_FNAME", objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME);
            command.AddParameter("@CROSS_ZONE_AUTHO_LNAME", objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME);
            command.AddParameter("@CROSS_ZONE_AUTHO_BADGENYMBER", objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER);
            command.AddParameter("@CROSS_ZONE_AUTHO_BADGETYPE", objWorkPermitSign.CROSS_ZONE_AUTHO_BADGETYPE);
            command.AddParameter("@CROSS_ZONE_AUTHO_SOURCE", objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE);


            command.AddParameter("@IMMIDIATE_FNAME", objWorkPermitSign.IMMIDIATE_FNAME);
            command.AddParameter("@IMMIDIATE_LNAME", objWorkPermitSign.IMMIDIATE_LNAME);
            command.AddParameter("@IMMIDIATE_BADGENYMBER", objWorkPermitSign.IMMIDIATE_BADGENUMBER);
            command.AddParameter("@IMMIDIATE_BADGETYPE", objWorkPermitSign.IMMIDIATE_BADGETYPE);
            command.AddParameter("@IMMIDIATE_SOURCE", objWorkPermitSign.IMMIDIATE_SOURCE);


            command.AddParameter("@CONFINED_FNAME", objWorkPermitSign.CONFINED_FNAME);
            command.AddParameter("@CONFINED_LNAME", objWorkPermitSign.CONFINED_LNAME);
            command.AddParameter("@CONFINED_BADGENYMBER", objWorkPermitSign.CONFINED_BADGENUMBER);
            command.AddParameter("@CONFINED_BADGETYPE", objWorkPermitSign.CONFINED_BADGETYPE);
            command.AddParameter("@CONFINED_SOURCE", objWorkPermitSign.CONFINED_SOURCE);


            command.AddParameter("@UpdatedBy", objWorkPermitSign.UpdatedBy);
            command.AddParameter("@CreatedBy", objWorkPermitSign.CreatedBy);
            command.AddParameter("@CreatedDate",objWorkPermitSign.CreatedDate);
            command.AddParameter("@UpdatedDate",objWorkPermitSign.UpdatedDate);
            command.AddParameter("@SiteId",objWorkPermitSign.SiteId);
           
        }

        public BADGE GetBadgeInfo(string Badgenumber, string strConnection, string strQuery)
        {
            BADGE objBADGE = new BADGE();
            try
            {
                TransactionOptions options = new TransactionOptions();
                   
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
                    {
                       // string strConnection = @"Data Source=SQLPRDCGY140-LS;Initial Catalog=LNLMSPRD;User Id=OLTUser;Password=OltUser@12;MultipleActiveResultSets=True;Connection Timeout=60";
                       // string strQuery = "SELECT top 1 BDG.Id,BDG.TYPE AS 'CARDTYPE',EM.FIRSTNAME,EM.LASTNAME FROM dbo.BADGE BDG JOIN EMP EM ON EM.ID=BDG.EMPID AND BDG.Id=@BadgeId AND BDG.STATUS=1";

                        SqlConnection Con = new SqlConnection(strConnection);
                        SqlCommand command = new SqlCommand(strQuery, Con);
                        Con.Open();

                        command.AddParameter("@BadgeId", Badgenumber);
                        SqlDataReader reader = command.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            objBADGE.FNAME = reader.Get<string>("FIRSTNAME");
                            objBADGE.LNAME = reader.Get<string>("LASTNAME");
                            objBADGE.BADGENYMBER = Convert.ToString(reader.Get<int?>("CARDTYPE"));

                        }
                        Con.Dispose();
                        reader.Dispose();
                    }
               
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                
            }

            return objBADGE;

        }


        public LenleConnection GetWorkPermitSignLenelConnection()
        {


            SqlCommand command = ManagedCommand;
            return command.QueryForSingleResult<LenleConnection>(PupulateLenelConnection, "GETLENELCONNECTIONANDQUERY");
        }

        public static LenleConnection PupulateLenelConnection(SqlDataReader reader)
        {
            LenleConnection objLenel = new LenleConnection();


            objLenel.LenleQuery = reader.Get<string>("QUERY");

            objLenel.Connectonstring = reader.Get<string>("Connection");
            return objLenel;

        }
    }
}