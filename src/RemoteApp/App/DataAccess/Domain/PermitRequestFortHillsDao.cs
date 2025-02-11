﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestFortHillsDao : AbstractPermitRequestDao<PermitRequestFortHills>, IPermitRequestFortHillsDao
    {
        private const string QUERY_BY_WORK_ORDER_NUMBER_AND_SAP_WORK_CENTRE_STORED_PROCEDURE = "QueryPermitRequestFortHillsByWorkOrderNumberAndSAPWorkCentre";
        

        private readonly IWorkPermitFortHillsGroupDao groupDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IPermitRequestFortHillsWorkOrderSourceDao workOrderSourceDao;
        private readonly IAreaLabelDao areaLabelDao;

        public PermitRequestFortHillsDao()
        {
            groupDao = DaoRegistry.GetDao<IWorkPermitFortHillsGroupDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            workOrderSourceDao = DaoRegistry.GetDao<IPermitRequestFortHillsWorkOrderSourceDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        protected override string QueryByIdStoredProcedure
        {
            get { return "QueryPermitRequestFortHillsById"; }
        }

        protected override string QueryByWorkOrderAndOperationAndSourceStoredProcedure
        {
            get { return "QueryPermitRequestFortHillsByWorkOrderNumberAndOperationAndSource"; } 
        }

        protected override string QueryByDateRangeAndDataSourceStoredProcedure
        {
            get { return "QueryPermitRequestFortHillsByDateRangeAndDataSource"; }
        }

        protected override string InsertStoredProcedure
        {
            get { return "InsertPermitRequestFortHills"; }
        }

        protected override string UpdateStoredProcedure
        {
            get { return "UpdatePermitRequestFortHills"; } //
        }

        protected override string RemoveStoredProcedure
        {
            get { return "RemovePermitRequestFortHills"; }
        }

        protected override string InsertPermitAttributeAssociationStoredProcedure
        {
            get { return null; }
        }

        protected override string DeletePermitAttributeStoredProcedure
        {
            get { return null; }
        }

        protected override string QueryLastImportDateTimeStoredProcedure
        {
            get { return "QueryPermitRequestFortHillsLastImportDateTime"; }
        }

        protected override PermitRequestFortHills BuildPermitRequest(SqlDataReader reader)
        {
            Date requestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            Time requestedStartTime = (reader.Get<DateTime?>("RequestedStartDate")).ToTime();
            Time requestedEndTime = (reader.Get<DateTime?>("RequestedEndDate")).ToTime();
            //Date revalidationDate = new Date(reader.Get<DateTime>("RevalidationDate"));
            //Time revalidationTime = (reader.Get<DateTime>("RevalidationTime")).ToTime();
            //Date extensionDate = new Date(reader.Get<DateTime>("ExtensionDate"));
            //Time extensionTime = (reader.Get<DateTime?>("ExtensionTime")).ToTime();

            long permitRequestId = reader.Get<long>("Id");

            PermitRequestFortHills permitRequest = new PermitRequestFortHills(permitRequestId,
                new Date(reader.Get<DateTime>("RequestedEndDate")),
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

            permitRequest.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            permitRequest.IssuedToContractor = reader.Get<bool>("IssuedToCompany");
            permitRequest.Occupation = reader.Get<String>("Occupation");
            permitRequest.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            permitRequest.Group = groupDao.QueryById(reader.Get<long>("GroupId"));
            permitRequest.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");

            permitRequest.RequestedStartDate = requestedStartDate;
            permitRequest.RequestedStartTime = requestedStartTime;
            permitRequest.EndDate = reader.Get<DateTime>("RequestedEndDate").ToDate();
            permitRequest.RequestedEndTime = requestedEndTime;
            //permitRequest.RevalidationDate = revalidationDate;
            //permitRequest.RevalidationTime = revalidationTime;
            //permitRequest.ExtensionDate = extensionDate;
            //permitRequest.ExtensionTime = extensionTime;
            permitRequest.WorkPermitType = WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId"));
            //permitRequest.Craft = reader.Get<string>("Craft");
            //permitRequest.CrewSize = reader.Get<int>("CrewSize");
            permitRequest.JobCoordinator = reader.Get<string>("JobCoordinator");
            permitRequest.CoOrdContactNumber = reader.Get<string>("CoOrdContactNumber");
            //permitRequest.EmergencyAssemblyArea = reader.Get<string>("EmergencyAssemblyArea");
            //permitRequest.EmergencyMeetingPoint = reader.Get<string>("EmergencyMeetingPoint");
            //permitRequest.EmergencyContactNo = reader.Get<string>("EmergencyContactNumber");
            //permitRequest.LockBoxNumber = reader.Get<string>("LockNumber");
            //permitRequest.IsolationNo = reader.Get<string>("IsolationNumber");
            // permitRequest.DataSource = reader.Get<Boolean>("DataSource");

            permitRequest.EquipmentNo = reader.Get<string>("EquipmentNo");
            permitRequest.LockBoxnumberChecked = reader.Get<bool>("LockBoxnumberChecked");
            
            permitRequest.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            permitRequest.PartEWorkSectionNotApplicableToJob = reader.Get<bool>("PartEWorkSectionNotApplicable");
            permitRequest.PartDWorkSectionNotApplicableToJob = reader.Get<bool>("PartDWorkSectionNotApplicable");
            permitRequest.PartCWorkSectionNotApplicableToJob = reader.Get<bool>("PartCWorkSectionNotApplicable");
            
            permitRequest.FlameResistantWorkWear = reader.Get<bool>("FlameResistantWorkWear");
            permitRequest.ChemicalSuit = reader.Get<bool>("ChemicalSuit");
            permitRequest.FireWatch = reader.Get<bool>("FireWatch");
            permitRequest.FireBlanket = reader.Get<bool>("FireBlanket");
            permitRequest.SuppliedBreathingAir = reader.Get<bool>("SuppliedBreathingAir");
            permitRequest.AirMover = reader.Get<bool>("AirMover");
            permitRequest.PersonalFlotationDevice = reader.Get<bool>("PersonalFlotationDevice");
            permitRequest.HearingProtection = reader.Get<bool>("HearingProtection");
            permitRequest.Other1 = reader.Get<string>("Other1");
            permitRequest.MonoGoggles = reader.Get<bool>("MonoGoggles");
            permitRequest.ConfinedSpaceMoniter = reader.Get<bool>("ConfinedSpaceMoniter");
            permitRequest.FireExtinguisher = reader.Get<bool>("FireExtinguisher");
            permitRequest.SparkContainment = reader.Get<bool>("SparkContainment");
            permitRequest.BottleWatch = reader.Get<bool>("BottleWatch");
            permitRequest.StandbyPerson = reader.Get<bool>("StandbyPerson");
            permitRequest.WorkingAlone = reader.Get<bool>("WorkingAlone");
            permitRequest.SafetyGloves = reader.Get<bool>("SafetyGloves");
            permitRequest.Other2 = reader.Get<string>("Other2");
            permitRequest.FaceShield = reader.Get<bool>("FaceShield");
            permitRequest.FallProtection = reader.Get<bool>("FallProtection");
            permitRequest.ChargedFireHouse = reader.Get<bool>("ChargedFireHouse");
            permitRequest.CoveredSewer = reader.Get<bool>("CoveredSewer");
            permitRequest.AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator");
            permitRequest.SingalPerson = reader.Get<bool>("SingalPerson");
            permitRequest.CommunicationDevice = reader.Get<bool>("CommunicationDevice");
            permitRequest.ReflectiveStrips = reader.Get<bool>("ReflectiveStrips");
            permitRequest.Other3 = reader.Get<string>("Other3");
            permitRequest.HazardsAndOrRequirements = reader.Get<string>("HazardsAndOrRequirements");
            permitRequest.ConfinedSpace = reader.Get<Boolean>("ConfinedSpace");
            permitRequest.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            permitRequest.GroundDisturbance = reader.Get<bool>("GoundDisturbance");
            permitRequest.FireProtectionAuthorization = reader.Get<bool>("FireProtectionAuthorization");
            permitRequest.CriticalOrSeriousLifts = reader.Get<bool>("CriticalOrSeriousLifts");
            permitRequest.VehicleEntry = reader.Get<bool>("VehicleEntry");
            permitRequest.IndustrialRadiography = reader.Get<bool>("IndustrialRadiography");
            permitRequest.ElectricalEncroachment = reader.Get<bool>("ElectricalEncroachment");
            permitRequest.MSDS = reader.Get<bool>("MSDS");
            permitRequest.OthersPartE = reader.Get<string>("OthersPartE");
            permitRequest.MechanicallyIsolated = reader.Get<bool>("MechanicallyIsolated");
            permitRequest.BlindedOrBlanked = reader.Get<bool>("BlindedOrBlanked");
            permitRequest.DoubleBlockedandBled = reader.Get<bool>("DoubleBlockedandBled");
            permitRequest.DrainedAndDepressurised = reader.Get<bool>("DrainedAndDepressurised");
            permitRequest.PurgedorNeutralised = reader.Get<bool>("PurgedorNeutralised");
            permitRequest.ElectricallyIsolated = reader.Get<bool>("ElectricallyIsolated");
            permitRequest.TestBumped = reader.Get<bool>("TestBumped");
            permitRequest.NuclearSource = reader.Get<bool>("NuclearSource");
            permitRequest.ReceiverStafingRequirements = reader.Get<bool>("ReceiverStafingRequirements");
            permitRequest.Location = reader.Get<string>("Location");


            permitRequest.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));
            permitRequest.IsModified = reader.Get<bool>("IsModified");


            permitRequest.DocumentLinks = documentLinkDao.QueryByPermitRequestFortHillsId(permitRequest.IdValue);

            permitRequest.DoNotMerge = reader.Get<bool>("DoNotMerge");

            List<PermitRequestWorkOrderSource> workOrderSources = workOrderSourceDao.QueryByPermitRequest(permitRequest);

            foreach (PermitRequestWorkOrderSource source in workOrderSources)
            {
                permitRequest.AddWorkOrderSource(source);
            }

            return permitRequest;

            //permitRequest.Priority = Priority.GetById(reader.Get<int>("PriorityId"));
            //permitRequest.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            //permitRequest.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));
            
            //permitRequest.Company = reader.Get<string>("Company");
            //permitRequest.IsModified = reader.Get<bool>("IsModified");
            //permitRequest.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            //permitRequest.IssuedToContractor = reader.Get<bool>("@IssuedToCompany");
            //permitRequest.Occupation = reader.Get<String>("Occupation");
            //permitRequest.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            //permitRequest.Group = groupDao.QueryById(reader.Get<long>("GroupId"));
            
            //permitRequest.SAPWorkCentre = reader.Get<string>("SAPWorkCentre");
            //permitRequest.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            //permitRequest.Location = reader.Get<String>("Location");
            //permitRequest.ConfinedSpaceClass = reader.Get<String>("ConfinedSpaceClass");
            //permitRequest.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            //permitRequest.VehicleEntry = reader.Get<bool>("VehicleEntry");
            //permitRequest.AlkylationEntryClassOfClothing = reader.Get<String>("AlkylationEntryClassOfClothing");
            //permitRequest.FlarePitEntryType = reader.Get<String>("FlarePitEntryType");
            //permitRequest.ConfinedSpaceCardNumber = reader.Get<String>("ConfinedSpaceCardNumber");
            //permitRequest.RescuePlanFormNumber = reader.Get<String>("RescuePlanFormNumber");
            //permitRequest.VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal");
            //permitRequest.VehicleEntryType = reader.Get<String>("VehicleEntryType");
            //permitRequest.SpecialWorkFormNumber = reader.Get<String>("SpecialWorkFormNumber");
            //permitRequest.SpecialWorkType = FortHillsPermitSpecialWorkType.FindById(reader.Get<int?>("SpecialWorkType"));
            ////mangesh for RoadAccessOnPermit
            //permitRequest.RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1");
            //permitRequest.RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1");
            //permitRequest.RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1");
            /*
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
            permitRequest.GN75_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN75_Deprecated"));*/

            

            //permitRequest.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            //permitRequest.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            //permitRequest.RescuePlan = reader.Get<bool>("RescuePlan");
            //permitRequest.SpecialWork = reader.Get<bool>("SpecialWork");

            //permitRequest.RequestedStartDate = requestedStartDate;
            //permitRequest.RequestedStartTime = requestedStartTime;
            //permitRequest.RequestedEndTime = requestedEndTime;
            //permitRequest.HazardsAndOrRequirements = reader.Get<String>("HazardsAndOrRequirements");
            //permitRequest.OtherAreasAndOrUnitsAffectedArea = reader.Get<String>("OtherAreasAndOrUnitsAffectedArea");
            //permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<String>("OtherAreasAndOrUnitsAffectedPersonNotified");
            //permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<Boolean>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            //permitRequest.FaceShield = reader.Get<Boolean>("FaceShield");
            //permitRequest.ChemicalSuit = reader.Get<Boolean>("Goggles");
            //permitRequest.BottleWatch = reader.Get<Boolean>("RubberBoots");
            //permitRequest.ConfinedSpaceMoniter = reader.Get<Boolean>("RubberGloves");
            //permitRequest.SuppliedBreathingAir = reader.Get<Boolean>("RubberSuit");
          //  permitRequest.SafetyHarnessLifeline = reader.Get<Boolean>("SafetyHarnessLifeline");
            //permitRequest.PersonalFlotationDevice = reader.Get<Boolean>("HighVoltagePPE");
            //permitRequest.Other1 = reader.Get<string>("Other1");
            //permitRequest.MonoGoggles = reader.Get<Boolean>("EquipmentGrounded");
            //permitRequest.FireBlanket = reader.Get<Boolean>("FireBlanket");
            //permitRequest.FireExtinguisher = reader.Get<Boolean>("FireExtinguisher");
            //permitRequest.SparkContainment = reader.Get<Boolean>("FireMonitorManned");
            //permitRequest.FireWatch = reader.Get<Boolean>("FireWatch");
            //permitRequest.StandbyPerson = reader.Get<Boolean>("SewersDrainsCovered");
            //permitRequest.WorkingAlone = reader.Get<Boolean>("SteamHose");
            //permitRequest.Other2 = reader.Get<string>("Other2");   
            //permitRequest.AirPurifyingRespirator = reader.Get<Boolean>("AirPurifyingRespirator");
            //permitRequest.FallProtection = reader.Get<Boolean>("BreathingAirApparatus");
            //permitRequest.ChargedFireHouse = reader.Get<Boolean>("DustMask");
            //permitRequest.CoveredSewer = reader.Get<Boolean>("LifeSupportSystem");
            //permitRequest.AirPurifyingRespirator = reader.Get<Boolean>("SafetyWatch");
            //permitRequest.SingalPerson = reader.Get<Boolean>("ContinuousGasMonitor");
            //permitRequest.CommunicationDevice = reader.Get<bool>("WorkersMonitor");
           // permitRequest.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
           // permitRequest.BumpTestMonitorPriorToUse = reader.Get<Boolean>("BumpTestMonitorPriorToUse");
            //permitRequest.Other3 = reader.Get<string>("Other3");   
            //permitRequest.AirMover = reader.Get<Boolean>("AirMover");
            //permitRequest.GoundDisturbance = reader.Get<Boolean>("BarriersSigns");            
            //permitRequest.RadioChannel = reader.Get<bool>("RadioChannel");
            //permitRequest.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            //permitRequest.AirHorn = reader.Get<Boolean>("AirHorn");
            //permitRequest.MechVentilationComfortOnly = reader.Get<Boolean>("MechVentilationComfortOnly");
            //permitRequest.AsbestosMMCPrecautions = reader.Get<Boolean>("AsbestosMMCPrecautions");
            //permitRequest.OthersPartE = reader.Get<string>("Other4");

             

            //permitRequest.SpecialWorkName = IsColumnExists(reader, "SpecialWorkName")
            //    ? reader.Get<string>("SpecialWorkName")
            //    : null;//reader.Get<string>("SpecialWorkName");

           
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

        protected override void AddInsertParameters(PermitRequestFortHills permitRequest, SqlCommand command)
        {
            command.AddParameter("@SAPWorkCentre", permitRequest.SAPWorkCentre);
            command.AddParameter("@DoNotmerge", permitRequest.DoNotMerge);

            base.AddInsertParameters(permitRequest, command);
        }

        protected override void SetInsertUpdateAttributes(PermitRequestFortHills permitRequest, SqlCommand command)
        {
            command.AddParameter("@IssuedToSuncor", permitRequest.IssuedToSuncor);
            command.AddParameter("@IssuedToCompany", permitRequest.IssuedToContractor);
            //command.AddParameter("@Company", permitRequest.Company);// is in abstract class 
            command.AddParameter("@Occupation", permitRequest.Occupation);
            command.AddParameter("@NumberOfWorkers", permitRequest.NumberOfWorkers  != null ? (int?)permitRequest.NumberOfWorkers : null);
            command.AddParameter("@GroupId", permitRequest.Group.IdValue);
            command.AddParameter("@WorkOrderNumber", permitRequest.WorkOrderNumber);
            command.AddParameter("@WorkPermitTypeId", permitRequest.WorkPermitType.IdValue);
            command.AddParameter("@PriorityId", permitRequest.Priority.IdValue);
            command.AddParameter("@FunctionalLocationId", permitRequest.FunctionalLocation.IdValue);
            command.AddParameter("@Location", permitRequest.Location);
            command.AddParameter("@RequestedStartDate", permitRequest.RequestedStartDate.CreateDateTime(permitRequest.RequestedStartTime));
            command.AddParameter("@RequestedEndDate",permitRequest.EndDate.CreateDateTime(permitRequest.RequestedEndTime));
            command.AddParameter("@EquipmentNo", !permitRequest.EquipmentNo.IsNullOrEmptyOrWhitespace() ? permitRequest.EquipmentNo : null);
            command.AddParameter("@JobCoordinator", permitRequest.JobCoordinator);
            command.AddParameter("@CoOrdContactNumber", permitRequest.CoOrdContactNumber);
            command.AddParameter("@LockBoxnumberChecked", permitRequest.LockBoxnumberChecked);
            command.AddParameter("@PartCWorkSectionNotApplicableToJob", permitRequest.PartCWorkSectionNotApplicableToJob);
            command.AddParameter("@FlameResistantWorkWear", permitRequest.FlameResistantWorkWear);
            command.AddParameter("@ChemicalSuit", permitRequest.ChemicalSuit);
            command.AddParameter("@FireWatch", permitRequest.FireWatch);
            command.AddParameter("@FireBlanket", permitRequest.FireBlanket);
            command.AddParameter("@SuppliedBreathingAir", permitRequest.SuppliedBreathingAir);
            command.AddParameter("@AirMover", permitRequest.AirMover);
            command.AddParameter("@PersonalFlotationDevice", permitRequest.PersonalFlotationDevice);
            command.AddParameter("@HearingProtection", permitRequest.HearingProtection);
            command.AddParameter("@Other1", permitRequest.Other1);
            command.AddParameter("@MonoGoggles", permitRequest.MonoGoggles);
            command.AddParameter("@ConfinedSpaceMoniter", permitRequest.ConfinedSpaceMoniter);
            command.AddParameter("@FireExtinguisher", permitRequest.FireExtinguisher);
            command.AddParameter("@SparkContainment", permitRequest.SparkContainment);
            command.AddParameter("@BottleWatch", permitRequest.BottleWatch);
            command.AddParameter("@StandbyPerson", permitRequest.StandbyPerson);
            command.AddParameter("@WorkingAlone", permitRequest.WorkingAlone);
            command.AddParameter("@SafetyGloves", permitRequest.SafetyGloves);
            command.AddParameter("@Other2", permitRequest.Other2);

            command.AddParameter("@FaceShield", permitRequest.FaceShield);
            command.AddParameter("@FallProtection", permitRequest.FallProtection);
            command.AddParameter("@ChargedFireHouse", permitRequest.ChargedFireHouse);
            command.AddParameter("@CoveredSewer", permitRequest.CoveredSewer);
            command.AddParameter("@AirPurifyingRespirator", permitRequest.AirPurifyingRespirator);
            command.AddParameter("@SingalPerson", permitRequest.SingalPerson);
            command.AddParameter("@CommunicationDevice", permitRequest.CommunicationDevice);
            command.AddParameter("@ReflectiveStrips", permitRequest.ReflectiveStrips);
            command.AddParameter("@Other3", permitRequest.Other3);

            command.AddParameter("@PartDWorkSectionNotApplicableToJob", permitRequest.PartDWorkSectionNotApplicableToJob);
            command.AddParameter("@HazardsAndOrRequirements", permitRequest.HazardsAndOrRequirements);

            command.AddParameter("@PartEWorkSectionNotApplicableToJob", permitRequest.PartEWorkSectionNotApplicableToJob);
            command.AddParameter("@ConfinedSpace", permitRequest.ConfinedSpace);
            command.AddParameter("@ConfinedSpaceClass", permitRequest.ConfinedSpaceClass);
            command.AddParameter("@GoundDisturbance", permitRequest.GroundDisturbance);
            command.AddParameter("@FireProtectionAuthorization", permitRequest.FireProtectionAuthorization);
            command.AddParameter("@CriticalOrSeriousLifts", permitRequest.CriticalOrSeriousLifts);
            command.AddParameter("@VehicleEntry", permitRequest.VehicleEntry);
            command.AddParameter("@IndustrialRadiography", permitRequest.IndustrialRadiography);
            command.AddParameter("@ElectricalEncroachment", permitRequest.ElectricalEncroachment);
            command.AddParameter("@MSDS", permitRequest.MSDS);
            command.AddParameter("@OthersPartE", permitRequest.OthersPartE);

            command.AddParameter("@MechanicallyIsolated", permitRequest.MechanicallyIsolated);
            command.AddParameter("@BlindedOrBlanked", permitRequest.BlindedOrBlanked);
            command.AddParameter("@DoubleBlockedandBled", permitRequest.DoubleBlockedandBled);
            command.AddParameter("@DrainedAndDepressurised", permitRequest.DrainedAndDepressurised);
            command.AddParameter("@PurgedorNeutralised", permitRequest.PurgedorNeutralised);
            command.AddParameter("@ElectricallyIsolated", permitRequest.ElectricallyIsolated);
            command.AddParameter("@TestBumped", permitRequest.TestBumped);
            command.AddParameter("@NuclearSource", permitRequest.NuclearSource);
            command.AddParameter("@ReceiverStafingRequirements", permitRequest.ReceiverStafingRequirements);

            command.AddParameter("@CompletionStatusId", permitRequest.CompletionStatus.IdValue);

            command.AddParameter("@Description", permitRequest.Description);
            command.AddParameter("@SapDescription", permitRequest.SapDescription);

            command.AddParameter("@Company", permitRequest.Company);

            if (permitRequest.LastImportedByUser != null)
            {
                command.AddParameter("@LastImportedByUserId", permitRequest.LastImportedByUser.IdValue);
            }
            if (permitRequest.LastImportedDateTime.HasValue)
            {
                command.AddParameter("@LastImportedDateTime", permitRequest.LastImportedDateTime);
            }
            if (permitRequest.LastSubmittedByUser != null)
            {
                command.AddParameter("@LastSubmittedByUserId", permitRequest.LastSubmittedByUser.IdValue);
            }
            if (permitRequest.LastSubmittedDateTime.HasValue)
            {
                command.AddParameter("@LastSubmittedDateTime", permitRequest.LastSubmittedDateTime);
            }

            command.AddParameter("@LastModifiedByUserId", permitRequest.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", permitRequest.LastModifiedDateTime);

            command.AddParameter("@IsModified", permitRequest.IsModified);

            // command.AddParameter("@RequestedStartDate", permitRequest.RequestedStartDate.ToDateTimeAtStartOfDay());
            //command.AddParameter("@RequestedEndDate", permitRequest.EndDate != null ? (DateTime?)permitRequest.EndDate.ToDateTimeAtStartOfDay() : null);
            //command.AddParameter("@RevalidationDate", (permitRequest.RevalidationDate != null) && (permitRequest.RevalidationDate != DateTime.MinValue.ToDate()) ? (DateTime?)permitRequest.RevalidationDate.ToDateTimeAtStartOfDay() : null);
            //command.AddParameter("@ExtensionDate", (permitRequest.ExtensionDate != null) && (permitRequest.ExtensionDate != DateTime.MinValue.ToDate()) ? (DateTime?)permitRequest.ExtensionDate.ToDateTimeAtStartOfDay() : null);
            //command.AddParameter("@RequestedStartTime", permitRequest.RequestedStartTime != null ? (DateTime?)permitRequest.RequestedStartTime.ToDateTime() : null);
            //command.AddParameter("@RequestedEndTime", permitRequest.RequestedEndTime != null ? (DateTime?)permitRequest.RequestedEndTime.ToDateTime() : null);
            //command.AddParameter("@RevalidationTime", permitRequest.RevalidationTime != null ? (DateTime?)permitRequest.RevalidationTime.ToDateTime() : null);
            //command.AddParameter("@ExtensionTime", permitRequest.ExtensionTime != null ? (DateTime?)permitRequest.ExtensionTime.ToDateTime() : null);
            //command.AddParameter("@Craft",permitRequest.Craft != null ? permitRequest.Craft :null );    
            //command.AddParameter("@CrewSize", permitRequest.CrewSize);
            //command.AddParameter("@EmergencyMeetingPoint", permitRequest.EmergencyMeetingPoint);
            //command.AddParameter("@EmergencyContactNumber", permitRequest.EmergencyContactNo);
            //command.AddParameter("@Locknumber", permitRequest.LockBoxNumber);
            //command.AddParameter("@IsolationNumber", permitRequest.IsolationNo);
           //command.AddParameter("@EndDate", permitRequest.EndDate.CreateDateTime(permitRequest.RequestedEndTime));
           //  base.SetInsertUpdateAttributes(permitRequest, command);
        }
        protected override void InsertPermitWorkOrderSources(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            workOrderSourceDao.InsertWorkOrderSourceList(command, permitRequest);
        }

        protected override void DeletePermitWorkOrderSources(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            workOrderSourceDao.DeleteByPermitRequestId(command, permitRequest.IdValue);
        }

        protected override void InsertFunctionalLocations(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            ;
        }

        protected override void UpdateFunctionalLocations(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            ;
        }

        protected override void InsertDocumentLinks(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            documentLinkDao.InsertNewDocumentLinks(permitRequest, documentLinkDao.InsertForAssociatedPermitRequestFortHills);
        }

        protected override void RemoveDocumentLinks(SqlCommand command, PermitRequestFortHills permitRequest)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(permitRequest, documentLinkDao.QueryByPermitRequestEdmontonId);
        }

        //public List<PermitRequestFortHills> QueryByFormGN59Id(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN59Id", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN59_ID);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN6Id(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN6Id", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN6_ID);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN7Id(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN7Id", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN7_ID);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN24Id(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN24Id", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN24_ID);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN75AId(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN75AId", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN75A_ID);
        //}

        //public List<PermitRequestFortHills> QueryByFormGN1Id(long id)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@FormGN1Id", id);
        //    return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_FORM_GN1_ID);
        //}

        public List<PermitRequestFortHills> QueryByWorkOrderNumberAndSAPWorkCentre(string workOrderNumber, string sapWorkCentre)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@SAPWorkCentre", sapWorkCentre);            
            command.AddParameter("@SourceId", DataSource.SAP.IdValue);

            return command.QueryForListResult<PermitRequestFortHills>(PopulateInstance, QUERY_BY_WORK_ORDER_NUMBER_AND_SAP_WORK_CENTRE_STORED_PROCEDURE);
        }

        public PermitRequestFortHills QueryEdmontonPermitRequestByWorkOrderNumberAndOperationAndSource(string workOrderNumber, string operationNumber, string subOperationNumber, DataSource dataSource)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);

            command.AddParameter("@SourceId", dataSource.IdValue);

            return command.QueryForSingleResult<PermitRequestFortHills>(PopulateInstance, QueryByWorkOrderAndOperationAndSourceStoredProcedure);
        }


        public PermitRequestEdmonton InsertTemplate(PermitRequestEdmonton permit)
        {
            return null;
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


        public PermitRequestEdmonton QueryByIdTemplateEdmonton(long id, string templateName, string categories)
        {
            return null;
        }

        public PermitRequestMontreal QueryByIdTemplateMontreal(long id, string templateName, string categories)
        {
            return null;
        }
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**


        public void RemoveTemplate(PermitRequestMuds permitRequest)
        {
            
        }

        public void RemoveTemplate(PermitRequestMontreal permitRequest)
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

        public PermitRequestMontreal UpdateTemplate(PermitRequestMontreal workPermit)
        {
            return null;
        }
    }
}