﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestEdmontonDao : AbstractPermitRequestDao<PermitRequestEdmonton>, IPermitRequestEdmontonDao
    {
        private const string QUERY_BY_WORK_ORDER_NUMBER_AND_SAP_WORK_CENTRE_STORED_PROCEDURE = "QueryPermitRequestEdmontonByWorkOrderNumberAndSAPWorkCentre";
        private const string QUERY_BY_FORM_GN59_ID = "QueryPermitRequestEdmontonByFormGN59Id";
        private const string QUERY_BY_FORM_GN7_ID = "QueryPermitRequestEdmontonByFormGN7Id";
        private const string QUERY_BY_FORM_GN6_ID = "QueryPermitRequestEdmontonByFormGN6Id";
        private const string QUERY_BY_FORM_GN24_ID = "QueryPermitRequestEdmontonByFormGN24Id";
        private const string QUERY_BY_FORM_GN75A_ID = "QueryPermitRequestEdmontonByFormGN75AId";
        private const string QUERY_BY_FORM_GN1_ID = "QueryPermitRequestEdmontonByFormGN1Id";

        private readonly IWorkPermitEdmontonGroupDao groupDao;
        private readonly IFormGN59Dao formGN59Dao;
        private readonly IFormGN6Dao formGN6Dao;
        private readonly IFormGN7Dao formGN7Dao;
        private readonly IFormGN24Dao formGN24Dao;
        private readonly IFormGN75ADao formGN75ADao;
        private readonly IFormGN1Dao formGN1Dao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IPermitRequestEdmontonWorkOrderSourceDao workOrderSourceDao;
        private readonly IAreaLabelDao areaLabelDao;

        public PermitRequestEdmontonDao()
        {
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            formGN59Dao = DaoRegistry.GetDao<IFormGN59Dao>();
            formGN6Dao = DaoRegistry.GetDao<IFormGN6Dao>();
            formGN7Dao = DaoRegistry.GetDao<IFormGN7Dao>();
            formGN24Dao = DaoRegistry.GetDao<IFormGN24Dao>();
            formGN75ADao = DaoRegistry.GetDao<IFormGN75ADao>();
            formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            workOrderSourceDao = DaoRegistry.GetDao<IPermitRequestEdmontonWorkOrderSourceDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        protected override string QueryByIdStoredProcedure
        {
            get { return "QueryPermitRequestEdmontonById"; }
        }

        protected override string QueryByWorkOrderAndOperationAndSourceStoredProcedure
        {
            get { return "QueryPermitRequestEdmontonByWorkOrderNumberAndOperationAndSource"; }
        }

        protected override string QueryByDateRangeAndDataSourceStoredProcedure
        {
            get { return "QueryPermitRequestEdmontonByDateRangeAndDataSource"; }
        }

        protected override string InsertStoredProcedure
        {
            get { return "InsertPermitRequestEdmonton"; }
        }

        protected override string UpdateStoredProcedure
        {
            get { return "UpdatePermitRequestEdmonton"; }
        }

        protected override string RemoveStoredProcedure
        {
            get { return "RemovePermitRequestEdmonton"; }
        }

        protected override string InsertPermitAttributeAssociationStoredProcedure
        {
            get { return "InsertPermitRequestEdmontonPermitAttributeAssociation"; }
        }

        protected override string DeletePermitAttributeStoredProcedure
        {
            get { return "DeletePermitRequestEdmontonPermitAttributeAssociation"; }
        }

        protected override string QueryLastImportDateTimeStoredProcedure
        {
            get { return "QueryPermitRequestEdmontonLastImportDateTime"; }
        }

        

        protected override PermitRequestEdmonton BuildPermitRequest(SqlDataReader reader)
        {
            Date requestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            Time startTimeDay = (reader.Get<DateTime?>("RequestedStartTimeDay")).ToTime();
            Time startTimeNight = (reader.Get<DateTime?>("RequestedStartTimeNight")).ToTime();

            long permitRequestId = reader.Get<long>("Id");

            PermitRequestEdmonton permitRequest = new PermitRequestEdmonton(permitRequestId,
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("TaskDescription"),
                reader.Get<string>("SapDescription"),
                reader.Get<string>("Company"),
                DataSource.GetById(reader.Get<int>("DataSourceId")),
                GetUser(reader, "LastImportedByUserId"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                GetUser(reader, "LastSubmittedByUserId"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                userDao.QueryById(reader.Get<long>("CreatedByUserId")),
                reader.Get<DateTime>("CreatedDateTime"),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"));

            permitRequest.Priority = Priority.GetById(reader.Get<int>("PriorityId"));
            permitRequest.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            permitRequest.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));
            permitRequest.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            permitRequest.Company = reader.Get<string>("Company");
            permitRequest.IsModified = reader.Get<bool>("IsModified");
            permitRequest.Occupation = reader.Get<String>("Occupation");
            permitRequest.SAPWorkCentre = reader.Get<string>("SAPWorkCentre");
            permitRequest.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            permitRequest.Group = groupDao.QueryById(reader.Get<long>("GroupId"));
            permitRequest.WorkPermitType = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId"));            
            permitRequest.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            permitRequest.Location = reader.Get<String>("Location");
            permitRequest.AlkylationEntryClassOfClothing = reader.Get<String>("AlkylationEntryClassOfClothing");
            permitRequest.FlarePitEntryType = reader.Get<String>("FlarePitEntryType");
            permitRequest.ConfinedSpaceCardNumber = reader.Get<String>("ConfinedSpaceCardNumber");
            permitRequest.ConfinedSpaceClass = reader.Get<String>("ConfinedSpaceClass");
            permitRequest.RescuePlanFormNumber = reader.Get<String>("RescuePlanFormNumber");
            permitRequest.VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal");
            permitRequest.VehicleEntryType = reader.Get<String>("VehicleEntryType");
            permitRequest.SpecialWorkFormNumber = reader.Get<String>("SpecialWorkFormNumber");
            permitRequest.SpecialWorkType = EdmontonPermitSpecialWorkType.FindById(reader.Get<int?>("SpecialWorkType"));
            //mangesh for RoadAccessOnPermit
            permitRequest.RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1");
            permitRequest.RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1");
            permitRequest.RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1");

            long? areaLabelId = reader.Get<long?>("AreaLabelId");
            if (areaLabelId != null)
            {
                permitRequest.AreaLabel = areaLabelDao.QueryById(areaLabelId.Value); //mangesh - Issue or Area is miising when edit
            }

            long? formGN59Id = reader.Get<long?>("FormGN59Id");
            if (formGN59Id != null)
            {
                permitRequest.FormGN59 = formGN59Dao.QueryById(formGN59Id.Value);
            }

            long? formGN7Id = reader.Get<long?>("FormGN7Id");
            if (formGN7Id != null)
            {
                permitRequest.FormGN7 = formGN7Dao.QueryById(formGN7Id.Value);
            }

            long? formGN24Id = reader.Get<long?>("FormGN24Id");
            if (formGN24Id != null)
            {
                permitRequest.FormGN24 = formGN24Dao.QueryById(formGN24Id.Value);
            }

            long? formGN6Id = reader.Get<long?>("FormGN6Id");
            if (formGN6Id != null)
            {
                permitRequest.FormGN6 = formGN6Dao.QueryById(formGN6Id.Value);
            }

            long? formGN75AId = reader.Get<long?>("FormGN75AId");
            if (formGN75AId != null)
            {
                permitRequest.FormGN75A = formGN75ADao.QueryById(formGN75AId.Value);
            }

            long? formGN1Id = reader.Get<long?>("FormGN1Id");
            if (formGN1Id != null)
            {
                permitRequest.FormGN1 = formGN1Dao.QueryById(formGN1Id.Value);
            }

            permitRequest.FormGN1TradeChecklistId = reader.Get<long?>("FormGN1TradeChecklistId");
            permitRequest.FormGN1TradeChecklistDisplayNumber = reader.Get<string>("FormGN1TradeChecklistDisplayNumber");

            permitRequest.GN59 = reader.Get<bool>("GN59");
            permitRequest.GN6 = reader.Get<bool>("GN6");
            permitRequest.GN7 = reader.Get<bool>("GN7");
            permitRequest.GN24 = reader.Get<bool>("GN24");
            permitRequest.GN75A = reader.Get<bool>("GN75A");
            permitRequest.GN1 = reader.Get<bool>("GN1");

            permitRequest.GN6_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN6_Deprecated"));
            permitRequest.GN11 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN11"));
            permitRequest.GN24_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN24_Deprecated"));
            permitRequest.GN27 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN27"));
            permitRequest.GN75_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN75_Deprecated"));

            permitRequest.DocumentLinks = documentLinkDao.QueryByPermitRequestEdmontonId(permitRequest.IdValue);

            permitRequest.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            permitRequest.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            permitRequest.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            permitRequest.RescuePlan = reader.Get<bool>("RescuePlan");
            permitRequest.VehicleEntry = reader.Get<bool>("VehicleEntry");
            permitRequest.SpecialWork = reader.Get<bool>("SpecialWork");

            permitRequest.RequestedStartDate = requestedStartDate;
            permitRequest.RequestedStartTimeDay = startTimeDay;
            permitRequest.RequestedStartTimeNight = startTimeNight;
            permitRequest.HazardsAndOrRequirements = reader.Get<String>("HazardsAndOrRequirements");
            permitRequest.OtherAreasAndOrUnitsAffectedArea = reader.Get<String>("OtherAreasAndOrUnitsAffectedArea");
            permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<String>("OtherAreasAndOrUnitsAffectedPersonNotified");
            permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<Boolean>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            permitRequest.FaceShield = reader.Get<Boolean>("FaceShield");
            permitRequest.Goggles = reader.Get<Boolean>("Goggles");
            permitRequest.RubberBoots = reader.Get<Boolean>("RubberBoots");
            permitRequest.RubberGloves = reader.Get<Boolean>("RubberGloves");
            permitRequest.RubberSuit = reader.Get<Boolean>("RubberSuit");
            permitRequest.SafetyHarnessLifeline = reader.Get<Boolean>("SafetyHarnessLifeline");
            permitRequest.HighVoltagePPE = reader.Get<Boolean>("HighVoltagePPE");
            permitRequest.Other1 = reader.Get<string>("Other1");   
            permitRequest.EquipmentGrounded = reader.Get<Boolean>("EquipmentGrounded");
            permitRequest.FireBlanket = reader.Get<Boolean>("FireBlanket");
            permitRequest.FireExtinguisher = reader.Get<Boolean>("FireExtinguisher");
            permitRequest.FireMonitorManned = reader.Get<Boolean>("FireMonitorManned");
            permitRequest.FireWatch = reader.Get<Boolean>("FireWatch");
            permitRequest.SewersDrainsCovered = reader.Get<Boolean>("SewersDrainsCovered");
            permitRequest.SteamHose = reader.Get<Boolean>("SteamHose");
            permitRequest.Other2 = reader.Get<string>("Other2");   
            permitRequest.AirPurifyingRespirator = reader.Get<Boolean>("AirPurifyingRespirator");
            permitRequest.BreathingAirApparatus = reader.Get<Boolean>("BreathingAirApparatus");
            permitRequest.DustMask = reader.Get<Boolean>("DustMask");
            permitRequest.LifeSupportSystem = reader.Get<Boolean>("LifeSupportSystem");
            permitRequest.SafetyWatch = reader.Get<Boolean>("SafetyWatch");
            permitRequest.ContinuousGasMonitor = reader.Get<Boolean>("ContinuousGasMonitor");            
            permitRequest.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            permitRequest.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            permitRequest.BumpTestMonitorPriorToUse = reader.Get<Boolean>("BumpTestMonitorPriorToUse");
            permitRequest.Other3 = reader.Get<string>("Other3");   
            permitRequest.AirMover = reader.Get<Boolean>("AirMover");
            permitRequest.BarriersSigns = reader.Get<Boolean>("BarriersSigns");            
            permitRequest.RadioChannel = reader.Get<bool>("RadioChannel");
            permitRequest.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            permitRequest.AirHorn = reader.Get<Boolean>("AirHorn");
            permitRequest.MechVentilationComfortOnly = reader.Get<Boolean>("MechVentilationComfortOnly");
            permitRequest.AsbestosMMCPrecautions = reader.Get<Boolean>("AsbestosMMCPrecautions");
            permitRequest.Other4 = reader.Get<string>("Other4");

            permitRequest.DoNotMerge = reader.Get<bool>("DoNotMerge");

            permitRequest.SpecialWorkName = IsColumnExists(reader, "SpecialWorkName")
                ? reader.Get<string>("SpecialWorkName")
                : null;//reader.Get<string>("SpecialWorkName");

            List<PermitRequestWorkOrderSource> workOrderSources = workOrderSourceDao.QueryByPermitRequest(permitRequest);

            foreach (PermitRequestWorkOrderSource source in workOrderSources)
            {
                permitRequest.AddWorkOrderSource(source);
            }
           
            return permitRequest;
        }

        //Added new to check colimn exists or not..
        private static bool IsColumnExists(System.Data.IDataReader dr, string columnName)
        {
            bool retVal = false;

            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                retVal = true;
            }
            return retVal;
        }

        protected override void AddInsertParameters(PermitRequestEdmonton permitRequest, SqlCommand command)
        {
            command.AddParameter("@SAPWorkCentre", permitRequest.SAPWorkCentre);
            command.AddParameter("@DoNotmerge", permitRequest.DoNotMerge);

            base.AddInsertParameters(permitRequest, command);
        }

        protected override void SetInsertUpdateAttributes(PermitRequestEdmonton permitRequest, SqlCommand command)
        {
            command.AddParameter("@WorkOrderNumber", permitRequest.WorkOrderNumber);
            command.AddParameter("@IssuedToSuncor", permitRequest.IssuedToSuncor);
            command.AddParameter("@Occupation", permitRequest.Occupation);            
            command.AddParameter("@NumberOfWorkers", permitRequest.NumberOfWorkers);
            command.AddParameter("@GroupId", permitRequest.Group.IdValue);
            command.AddParameter("@WorkPermitTypeId", permitRequest.WorkPermitType.IdValue);            
            command.AddParameter("@FunctionalLocationId", permitRequest.FunctionalLocation.IdValue);
            command.AddParameter("@Location", permitRequest.Location);
            command.AddParameter("@CompletionStatusId", permitRequest.CompletionStatus.IdValue);
            command.AddParameter("@PriorityId", permitRequest.Priority.IdValue);
            command.AddParameter("@AreaLabelId", permitRequest.AreaLabel != null ? permitRequest.AreaLabel.Id : null);

            command.AddParameter("@RequestedStartDate", permitRequest.RequestedStartDate.ToDateTimeAtStartOfDay());

            DateTime? startTimeDay = permitRequest.RequestedStartTimeDay != null
                                      ? (DateTime?) permitRequest.RequestedStartTimeDay.ToDateTime()
                                      : null;

            DateTime? startTimeNight = permitRequest.RequestedStartTimeNight != null
                                      ? (DateTime?)permitRequest.RequestedStartTimeNight.ToDateTime()
                                      : null;

            command.AddParameter("@RequestedStartTimeDay", startTimeDay);
            command.AddParameter("@RequestedStartTimeNight", startTimeNight);
 
            command.AddParameter("@AlkylationEntryClassOfClothing", permitRequest.AlkylationEntryClassOfClothing);
            command.AddParameter("@FlarePitEntryType", permitRequest.FlarePitEntryType);
            command.AddParameter("@ConfinedSpaceCardNumber", permitRequest.ConfinedSpaceCardNumber);
            command.AddParameter("@ConfinedSpaceClass", permitRequest.ConfinedSpaceClass);
            command.AddParameter("@SpecialWorkFormNumber", permitRequest.SpecialWorkFormNumber);

            //command.AddParameter("@SpecialWorkType", permitRequest.SpecialWorkType != null ? permitRequest.SpecialWorkType.Id : null);
            command.AddParameter("@SpecialWorkType", permitRequest.specialworktype != null ? permitRequest.specialworktype.Id : null);//mangesh for SpecialWork

            command.AddParameter("@VehicleEntryTotal", permitRequest.VehicleEntryTotal);
            command.AddParameter("@VehicleEntryType", permitRequest.VehicleEntryType);
            command.AddParameter("@RescuePlanFormNumber", permitRequest.RescuePlanFormNumber);
            command.AddParameter("@FormGN59Id", permitRequest.FormGN59 != null ? permitRequest.FormGN59.Id : null);
            command.AddParameter("@FormGN6Id", permitRequest.FormGN6 != null ? permitRequest.FormGN6.Id : null);
            command.AddParameter("@FormGN7Id", permitRequest.FormGN7 != null ? permitRequest.FormGN7.Id : null);
            command.AddParameter("@FormGN24Id", permitRequest.FormGN24 != null ? permitRequest.FormGN24.Id : null);
            command.AddParameter("@FormGN75AId", permitRequest.FormGN75A != null ? permitRequest.FormGN75A.Id : null);
            command.AddParameter("@FormGN1Id", permitRequest.FormGN1 != null ? permitRequest.FormGN1.Id : null);
            command.AddParameter("@FormGN1TradeChecklistId", permitRequest.FormGN1TradeChecklistId);
            command.AddParameter("@FormGN1TradeChecklistDisplayNumber", permitRequest.FormGN1TradeChecklistDisplayNumber);

            command.AddParameter("@GN59", permitRequest.GN59);
            command.AddParameter("@GN6", permitRequest.GN6);
            command.AddParameter("@GN7", permitRequest.GN7);
            command.AddParameter("@GN24", permitRequest.GN24);
            command.AddParameter("@GN75A", permitRequest.GN75A);
            command.AddParameter("@GN1", permitRequest.GN1);

            command.AddParameter("@GN6_Deprecated", permitRequest.GN6_Deprecated.IdValue);
            command.AddParameter("@GN11", permitRequest.GN11.IdValue);
            command.AddParameter("@GN24_Deprecated", permitRequest.GN24_Deprecated.IdValue);
            command.AddParameter("@GN27", permitRequest.GN27.IdValue);
            command.AddParameter("@GN75_Deprecated", permitRequest.GN75_Deprecated.IdValue);

            command.AddParameter("@AlkylationEntry", permitRequest.AlkylationEntry);
            command.AddParameter("@FlarePitEntry", permitRequest.FlarePitEntry);
            command.AddParameter("@ConfinedSpace", permitRequest.ConfinedSpace);
            command.AddParameter("@RescuePlan", permitRequest.RescuePlan);
            command.AddParameter("@VehicleEntry", permitRequest.VehicleEntry);
            command.AddParameter("@SpecialWork", permitRequest.SpecialWork);

            command.AddParameter("@HazardsAndOrRequirements", permitRequest.HazardsAndOrRequirements);

            command.AddParameter("@OtherAreasAndOrUnitsAffectedArea", permitRequest.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("@OtherAreasAndOrUnitsAffectedPersonNotified", permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified);

            command.AddParameter("@WorkersMinimumSafetyRequirementsSectionNotApplicableToJob", permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            command.AddParameter("@FaceShield", permitRequest.FaceShield);
            command.AddParameter("@Goggles", permitRequest.Goggles);
            command.AddParameter("@RubberBoots", permitRequest.RubberBoots);
            command.AddParameter("@RubberGloves", permitRequest.RubberGloves);
            command.AddParameter("@RubberSuit", permitRequest.RubberSuit);
            command.AddParameter("@SafetyHarnessLifeline", permitRequest.SafetyHarnessLifeline);
            command.AddParameter("@HighVoltagePPE", permitRequest.HighVoltagePPE);            
            command.AddParameter("@Other1", permitRequest.Other1);
            
            command.AddParameter("@EquipmentGrounded", permitRequest.EquipmentGrounded);
            command.AddParameter("@FireBlanket", permitRequest.FireBlanket);
            command.AddParameter("@FireExtinguisher", permitRequest.FireExtinguisher);
            command.AddParameter("@FireMonitorManned", permitRequest.FireMonitorManned);
            command.AddParameter("@FireWatch", permitRequest.FireWatch);
            command.AddParameter("@SewersDrainsCovered", permitRequest.SewersDrainsCovered);
            command.AddParameter("@SteamHose", permitRequest.SteamHose);            
            command.AddParameter("@Other2", permitRequest.Other2);

            command.AddParameter("@AirPurifyingRespirator", permitRequest.AirPurifyingRespirator);
            command.AddParameter("@BreathingAirApparatus", permitRequest.BreathingAirApparatus);
            command.AddParameter("@DustMask", permitRequest.DustMask);
            command.AddParameter("@LifeSupportSystem", permitRequest.LifeSupportSystem);
            command.AddParameter("@SafetyWatch", permitRequest.SafetyWatch);
            command.AddParameter("@ContinuousGasMonitor", permitRequest.ContinuousGasMonitor);
            command.AddParameter("@WorkersMonitor", permitRequest.WorkersMonitor);
            command.AddParameter("@WorkersMonitorNumber", permitRequest.WorkersMonitorNumber);
            command.AddParameter("@BumpTestMonitorPriorToUse", permitRequest.BumpTestMonitorPriorToUse);            
            command.AddParameter("@Other3", permitRequest.Other3);

            command.AddParameter("@AirMover", permitRequest.AirMover);
            command.AddParameter("@BarriersSigns", permitRequest.BarriersSigns);
            command.AddParameter("@RadioChannel", permitRequest.RadioChannel);
            command.AddParameter("@RadioChannelNumber", permitRequest.RadioChannelNumber);
            command.AddParameter("@AirHorn", permitRequest.AirHorn);
            command.AddParameter("@MechVentilationComfortOnly", permitRequest.MechVentilationComfortOnly);
            command.AddParameter("@AsbestosMMCPrecautions", permitRequest.AsbestosMMCPrecautions);            
            command.AddParameter("@Other4", permitRequest.Other4);

            command.AddParameter("RoadAccessOnPermit", permitRequest.RoadAccessOnPermit);
            command.AddParameter("RoadAccessOnPermitFormNumber", permitRequest.RoadAccessOnPermitFormNumber);
            command.AddParameter("RoadAccessOnPermitType", permitRequest.RoadAccessOnPermitType);

            command.AddParameter("SpecialWorkName", permitRequest.SpecialWorkName);
            
            base.SetInsertUpdateAttributes(permitRequest, command);
        }

        protected override void InsertPermitWorkOrderSources(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            workOrderSourceDao.InsertWorkOrderSourceList(command, permitRequest);
        }

        protected override void DeletePermitWorkOrderSources(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            workOrderSourceDao.DeleteByPermitRequestId(command, permitRequest.IdValue);
        }

        protected override void InsertFunctionalLocations(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            ;
        }

        protected override void UpdateFunctionalLocations(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            ;
        }

        protected override void InsertDocumentLinks(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            documentLinkDao.InsertNewDocumentLinks(permitRequest, documentLinkDao.InsertForAssociatedPermitRequestEdmonton);
        }

        protected override void RemoveDocumentLinks(SqlCommand command, PermitRequestEdmonton permitRequest)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(permitRequest, documentLinkDao.QueryByPermitRequestEdmontonId);
        }

        public List<PermitRequestEdmonton> QueryByFormGN59Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN59Id", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN59_ID);
        }

        public List<PermitRequestEdmonton> QueryByFormGN6Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN6Id", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN6_ID);
        }

        public List<PermitRequestEdmonton> QueryByFormGN7Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN7Id", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN7_ID);
        }

        public List<PermitRequestEdmonton> QueryByFormGN24Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN24Id", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN24_ID);
        }

        public List<PermitRequestEdmonton> QueryByFormGN75AId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN75AId", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN75A_ID);
        }

        public List<PermitRequestEdmonton> QueryByFormGN1Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", id);
            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_FORM_GN1_ID);
        }

        public List<PermitRequestEdmonton> QueryByWorkOrderNumberAndSAPWorkCentre(string workOrderNumber, string sapWorkCentre)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@SAPWorkCentre", sapWorkCentre);            
            command.AddParameter("@SourceId", DataSource.SAP.IdValue);

            return command.QueryForListResult<PermitRequestEdmonton>(PopulateInstance, QUERY_BY_WORK_ORDER_NUMBER_AND_SAP_WORK_CENTRE_STORED_PROCEDURE);
        }

        public PermitRequestEdmonton QueryEdmontonPermitRequestByWorkOrderNumberAndOperationAndSource(string workOrderNumber, string operationNumber, string subOperationNumber, DataSource dataSource)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);

            command.AddParameter("@SourceId", dataSource.IdValue);

            return command.QueryForSingleResult<PermitRequestEdmonton>(PopulateInstance, QueryByWorkOrderAndOperationAndSourceStoredProcedure);
        }

        public PermitRequestEdmonton InsertTemplate(PermitRequestEdmonton workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertPermitRequestTemplate");
            //InserttTemplateCategory(workPermit);
            return workPermit;
        }

        private static void AddInsertParametersForTemplate(PermitRequestEdmonton workPermit, SqlCommand command)
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
            command.AddParameter("@SiteId", workPermit.FunctionalLocation.Site.Id);

        }

        public PermitRequestEdmonton QueryByIdTemplateEdmonton(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<PermitRequestEdmonton>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryPermitRequestTemplateNameandCategory");
        }
        private PermitRequestEdmonton PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");

            PermitRequestEdmonton workPermitMuds = new PermitRequestEdmonton(templateName, categories);

            return workPermitMuds;

        }
        private void InserttTemplateCategory(PermitRequestEdmonton workpermit)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertPermitRequestTemplateCategory";
            command.AddParameter("@Id", workpermit.IdValue);
            command.AddParameter("@SiteId", workpermit.FunctionalLocation.Site.Id);
            command.AddParameter("@Categories", workpermit.Categories);
            command.ExecuteNonQuery();
        }

        public PermitRequestMontreal InsertTemplate(PermitRequestMontreal permit)
        {
            return null;
        }

        public PermitRequestMuds InsertTemplate(PermitRequestMuds permit)
        {
            return null;
        }



        public PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            return null;
        }


        public PermitRequestMontreal QueryByIdTemplateMontreal(long id, string templateName, string categories)
        {
            return null;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(PermitRequestEdmonton workPermit)
        {
            string spname = "RemovePermitRequestTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(PermitRequestEdmonton workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public PermitRequestEdmonton UpdateTemplate(PermitRequestEdmonton workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdatePermitRequestTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(PermitRequestEdmonton workPermit, SqlCommand command)
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

        public void RemoveTemplate(PermitRequestMontreal permitRequest)
        {

        }




        public PermitRequestMuds UpdateTemplate(PermitRequestMuds workPermit)
        {
            return null;
        }

        public PermitRequestMontreal UpdateTemplate(PermitRequestMontreal workPermit)
        {
            return null;
        }
    }
}