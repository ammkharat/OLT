﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestLubesDao : AbstractPermitRequestDao<PermitRequestLubes>, IPermitRequestLubesDao
    {                        
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitLubesGroupDao groupDao;
        private readonly IRoleDao roleDao;

        private readonly IPermitRequestLubesWorkOrderSourceDao workOrderSourceDao;// mergetodo

        public PermitRequestLubesDao()
        {
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            workOrderSourceDao = DaoRegistry.GetDao<IPermitRequestLubesWorkOrderSourceDao>();
        }

        protected override string QueryByIdStoredProcedure
        {
            get { return "QueryPermitRequestLubesById"; }
        }

        protected override string QueryByWorkOrderAndOperationAndSourceStoredProcedure
        {
            get { return "QueryPermitRequestLubesByWorkOrderNumberAndOperationAndSource"; }
        }

        protected override string QueryByDateRangeAndDataSourceStoredProcedure
        {
            get { return "QueryPermitRequestLubesByDateRangeAndDataSource"; }
        }

        protected override string InsertStoredProcedure
        {
            get { return "InsertPermitRequestLubes"; }
        }

        protected override string UpdateStoredProcedure
        {
            get { return "UpdatePermitRequestLubes"; }
        }

        protected override string RemoveStoredProcedure
        {
            get { return "RemovePermitRequestLubes"; }
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
            get { return "QueryPermitRequestLubesLastImportDateTime"; }
        }

        protected override PermitRequestLubes BuildPermitRequest(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            Date endDate = new Date(reader.Get<DateTime>("EndDate")); 
            string description = reader.Get<string>("Description");
            string sapDescription = reader.Get<string>("SapDescription"); 
            string company = reader.Get<string>("Company"); 

            DataSource dataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));

            long? lastImportedByUserId = reader.Get<long?>("LastImportedByUserId");
            User lastImportedBy = lastImportedByUserId != null ? userDao.QueryById(lastImportedByUserId.Value) : null;

            DateTime? lastImportedDateTime = reader.Get<DateTime?>("LastImportedDateTime");

            long? lastSubmittedByUserId = reader.Get<long?>("LastSubmittedByUserId");
            User lastSubmittedBy = lastSubmittedByUserId != null ? userDao.QueryById(lastSubmittedByUserId.Value) : null;

            DateTime? lastSubmittedDateTime = reader.Get<DateTime?>("LastSubmittedDateTime");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));          

            PermitRequestLubes permitRequest = new PermitRequestLubes(
                id, endDate, description, sapDescription, company, dataSource, lastImportedBy, lastImportedDateTime, lastSubmittedBy, lastSubmittedDateTime, createdBy,
                createdDateTime, lastModifiedBy, lastModifiedDateTime, createdByRole);

            permitRequest.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");

            List<PermitRequestWorkOrderSource> workOrderSources = workOrderSourceDao.QueryByPermitRequest(permitRequest);

            foreach (PermitRequestWorkOrderSource source in workOrderSources)
            {
                permitRequest.AddWorkOrderSource(source);
            }

            permitRequest.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            permitRequest.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            permitRequest.IssuedToCompany = reader.Get<bool>("IssuedToCompany");

            permitRequest.Trade = reader.Get<string>("Trade");
            permitRequest.SAPWorkCentre = reader.Get<string>("SAPWorkCentre");
            permitRequest.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            permitRequest.RequestedByGroup = groupDao.QueryById(reader.Get<long>("RequestedByGroupId"));

            permitRequest.WorkPermitType = WorkPermitLubesType.Get(reader.Get<int>("WorkPermitTypeId"));
            permitRequest.IsVehicleEntry = reader.Get<bool>("IsVehicleEntry");

            permitRequest.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            permitRequest.Location = reader.Get<string>("Location");

            permitRequest.RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));

            DateTime? startDateTimeDay = reader.Get<DateTime?>("RequestedStartTimeDay");
            permitRequest.RequestedStartTimeDay = startDateTimeDay != null ? new Time(startDateTimeDay.Value) : null;

            DateTime? startDateTimeNight = reader.Get<DateTime?>("RequestedStartTimeNight");
            permitRequest.RequestedStartTimeNight = startDateTimeNight != null ? new Time(startDateTimeNight.Value) : null;

            permitRequest.DocumentLinks = documentLinkDao.QueryByPermitRequestLubesId(permitRequest.IdValue);

            permitRequest.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            permitRequest.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            permitRequest.RescuePlan = reader.Get<bool>("RescuePlan");
            permitRequest.ConfinedSpaceSafetyWatchChecklist = reader.Get<bool>("ConfinedSpaceSafetyWatchChecklist");

            permitRequest.SpecialWork = reader.Get<bool>("SpecialWork");
            permitRequest.SpecialWorkType = reader.Get<string>("SpecialWorkType");

            permitRequest.HighEnergy = WorkPermitSafetyFormState.GetById(reader.Get<byte>("HighEnergy"));
            permitRequest.CriticalLift = WorkPermitSafetyFormState.GetById(reader.Get<byte>("CriticalLift"));
            permitRequest.Excavation = WorkPermitSafetyFormState.GetById(reader.Get<byte>("Excavation"));

            permitRequest.EquivalencyProc = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EquivalencyProc"));
            permitRequest.TestPneumatic = WorkPermitSafetyFormState.GetById(reader.Get<byte>("TestPneumatic"));
            permitRequest.LiveFlareWork = WorkPermitSafetyFormState.GetById(reader.Get<byte>("LiveFlareWork"));
            permitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EntryAndControlPlan"));
            permitRequest.EnergizedElectrical = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergizedElectrical"));

            permitRequest.HazardHydrocarbonGas = reader.Get<bool>("HazardHydrocarbonGas");
            permitRequest.HazardHydrocarbonLiquid = reader.Get<bool>("HazardHydrocarbonLiquid");
            permitRequest.HazardHydrogenSulphide = reader.Get<bool>("HazardHydrogenSulphide");
            permitRequest.HazardInertGasAtmosphere = reader.Get<bool>("HazardInertGasAtmosphere");
            permitRequest.HazardOxygenDeficiency = reader.Get<bool>("HazardOxygenDeficiency");
            permitRequest.HazardRadioactiveSources = reader.Get<bool>("HazardRadioactiveSources");
            permitRequest.HazardUndergroundOverheadHazards = reader.Get<bool>("HazardUndergroundOverheadHazards");
            permitRequest.HazardDesignatedSubstance = reader.Get<bool>("HazardDesignatedSubstance");

            permitRequest.OtherHazardsAndOrRequirements = reader.Get<string>("OtherHazardsAndOrRequirements");

            permitRequest.OtherAreasAndOrUnitsAffected = reader.Get<bool>("OtherAreasAndOrUnitsAffected");
            permitRequest.OtherAreasAndOrUnitsAffectedArea = reader.Get<string>("OtherAreasAndOrUnitsAffectedArea");
            permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<string>("OtherAreasAndOrUnitsAffectedPersonNotified");

            permitRequest.EnergyControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergyControlPlan"));

            permitRequest.SpecificRequirementsSectionNotApplicableToJob = reader.Get<bool>("SpecificRequirementsSectionNotApplicableToJob");
            permitRequest.AttendedAtAllTimes = reader.Get<bool>("AttendedAtAllTimes");
            permitRequest.EyeProtection = reader.Get<bool>("EyeProtection");
            permitRequest.FallProtectionEquipment = reader.Get<bool>("FallProtectionEquipment");
            permitRequest.FullBodyHarnessRetrieval = reader.Get<bool>("FullBodyHarnessRetrieval");
            permitRequest.HearingProtection = reader.Get<bool>("HearingProtection");
            permitRequest.ProtectiveClothing = reader.Get<bool>("ProtectiveClothing");
            permitRequest.Other1Checked = reader.Get<bool>("Other1Checked");
            permitRequest.Other1Value = reader.Get<string>("Other1Value");

            permitRequest.EquipmentBondedGrounded = reader.Get<bool>("EquipmentBondedGrounded");
            permitRequest.FireBlanket = reader.Get<bool>("FireBlanket");
            permitRequest.FireFightingEquipment = reader.Get<bool>("FireFightingEquipment");
            permitRequest.FireWatch = reader.Get<bool>("FireWatch");
            permitRequest.HydrantPermit = reader.Get<bool>("HydrantPermit");
            permitRequest.WaterHose = reader.Get<bool>("WaterHose");
            permitRequest.SteamHose = reader.Get<bool>("SteamHose");
            permitRequest.Other2Checked = reader.Get<bool>("Other2Checked");
            permitRequest.Other2Value = reader.Get<string>("Other2Value");

            permitRequest.AirMover = reader.Get<bool>("AirMover");
            permitRequest.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");
            permitRequest.DrowningProtection = reader.Get<bool>("DrowningProtection");
            permitRequest.RespiratoryProtection = reader.Get<bool>("RespiratoryProtection");
            permitRequest.Other3Checked = reader.Get<bool>("Other3Checked");
            permitRequest.Other3Value = reader.Get<string>("Other3Value");

            permitRequest.AdditionalLighting = reader.Get<bool>("AdditionalLighting");
            permitRequest.FireBlanket = reader.Get<bool>("FireBlanket");
            permitRequest.DesignateHotOrColdCutChecked = reader.Get<bool>("DesignateHotOrColdCutChecked");
            permitRequest.DesignateHotOrColdCutValue = reader.Get<string>("DesignateHotOrColdCutValue");
            permitRequest.HoistingEquipment = reader.Get<bool>("HoistingEquipment");
            permitRequest.Ladder = reader.Get<bool>("Ladder");
            permitRequest.MotorizedEquipment = reader.Get<bool>("MotorizedEquipment");
            permitRequest.Scaffold = reader.Get<bool>("Scaffold");
            permitRequest.ReferToTipsProcedure = reader.Get<bool>("ReferToTipsProcedure");
            permitRequest.GasDetectorBumpTested = reader.Get<bool>("GasDetectorBumpTested");
            permitRequest.IsModified = reader.Get<bool>("IsModified");

            return permitRequest;            
        }

        protected override void InsertFunctionalLocations(SqlCommand command, PermitRequestLubes permitRequest)
        {
            ;
        }

        protected override void UpdateFunctionalLocations(SqlCommand command, PermitRequestLubes permitRequest)
        {
            ;
        }

        protected override void AddInsertParameters(PermitRequestLubes permitRequest, SqlCommand command)
        {
            base.AddInsertParameters(permitRequest, command);

            if (permitRequest.CreatedByRole != null)
            {
                command.AddParameter("CreatedByRoleId", permitRequest.CreatedByRole.IdValue);
            }
        }

        protected override void SetInsertUpdateAttributes(PermitRequestLubes permitRequest, SqlCommand command)
        {
            base.SetInsertUpdateAttributes(permitRequest, command);
            
            command.AddParameter("CompletionStatusId", permitRequest.CompletionStatus.IdValue);
            command.AddParameter("IssuedToSuncor", permitRequest.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", permitRequest.IssuedToCompany);
            command.AddParameter("Trade", permitRequest.Trade);
            command.AddParameter("SAPWorkCentre", permitRequest.SAPWorkCentre);
            command.AddParameter("NumberOfWorkers", permitRequest.NumberOfWorkers);
            command.AddParameter("RequestedByGroupId", permitRequest.RequestedByGroup != null ? permitRequest.RequestedByGroup.Id : null);
            command.AddParameter("WorkPermitTypeId", permitRequest.WorkPermitType.IdValue);
            command.AddParameter("IsVehicleEntry", permitRequest.IsVehicleEntry);
            command.AddParameter("FunctionalLocationId", permitRequest.FunctionalLocation.IdValue);
            command.AddParameter("Location", permitRequest.Location);
            command.AddParameter("ConfinedSpace", permitRequest.ConfinedSpace);
            command.AddParameter("ConfinedSpaceClass", permitRequest.ConfinedSpaceClass);
            command.AddParameter("RescuePlan", permitRequest.RescuePlan);
            command.AddParameter("ConfinedSpaceSafetyWatchChecklist", permitRequest.ConfinedSpaceSafetyWatchChecklist);
            command.AddParameter("SpecialWork", permitRequest.SpecialWork);
            command.AddParameter("SpecialWorkType", permitRequest.SpecialWorkType);
            command.AddParameter("RequestedStartDate", permitRequest.RequestedStartDate.ToDateTimeAtStartOfDay());
            command.AddParameter("RequestedStartTimeDay", permitRequest.RequestedStartTimeDay != null ? (DateTime?)permitRequest.RequestedStartTimeDay.ToDateTime() : null);
            command.AddParameter("RequestedStartTimeNight", permitRequest.RequestedStartTimeNight != null ? (DateTime?)permitRequest.RequestedStartTimeNight.ToDateTime() : null);            

            command.AddParameter("WorkOrderNumber", permitRequest.WorkOrderNumber);

            command.AddParameter("HighEnergy", permitRequest.HighEnergy.IdValue);
            command.AddParameter("CriticalLift", permitRequest.CriticalLift.IdValue);
            command.AddParameter("Excavation", permitRequest.Excavation.IdValue);
            command.AddParameter("EnergyControlPlan", permitRequest.EnergyControlPlan.IdValue);
            command.AddParameter("EquivalencyProc", permitRequest.EquivalencyProc.IdValue);
            command.AddParameter("TestPneumatic", permitRequest.TestPneumatic.IdValue);
            command.AddParameter("LiveFlareWork", permitRequest.LiveFlareWork.IdValue);
            command.AddParameter("EntryAndControlPlan", permitRequest.EntryAndControlPlan.IdValue);
            command.AddParameter("EnergizedElectrical", permitRequest.EnergizedElectrical.IdValue);

            command.AddParameter("HazardHydrocarbonGas", permitRequest.HazardHydrocarbonGas);
            command.AddParameter("HazardHydrocarbonLiquid", permitRequest.HazardHydrocarbonLiquid);
            command.AddParameter("HazardHydrogenSulphide", permitRequest.HazardHydrogenSulphide);
            command.AddParameter("HazardInertGasAtmosphere", permitRequest.HazardInertGasAtmosphere);
            command.AddParameter("HazardOxygenDeficiency", permitRequest.HazardOxygenDeficiency);
            command.AddParameter("HazardRadioactiveSources", permitRequest.HazardRadioactiveSources);
            command.AddParameter("HazardUndergroundOverheadHazards", permitRequest.HazardUndergroundOverheadHazards);
            command.AddParameter("HazardDesignatedSubstance", permitRequest.HazardDesignatedSubstance);
            command.AddParameter("OtherHazardsAndOrRequirements", permitRequest.OtherHazardsAndOrRequirements);
            command.AddParameter("OtherAreasAndOrUnitsAffected", permitRequest.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", permitRequest.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified);
            command.AddParameter("SpecificRequirementsSectionNotApplicableToJob", permitRequest.SpecificRequirementsSectionNotApplicableToJob);
            command.AddParameter("AttendedAtAllTimes", permitRequest.AttendedAtAllTimes);
            command.AddParameter("EyeProtection", permitRequest.EyeProtection);
            command.AddParameter("FallProtectionEquipment", permitRequest.FallProtectionEquipment);
            command.AddParameter("FullBodyHarnessRetrieval", permitRequest.FullBodyHarnessRetrieval);
            command.AddParameter("HearingProtection", permitRequest.HearingProtection);
            command.AddParameter("ProtectiveClothing", permitRequest.ProtectiveClothing);
            command.AddParameter("Other1Checked", permitRequest.Other1Checked);
            command.AddParameter("Other1Value", permitRequest.Other1Value);
            command.AddParameter("EquipmentBondedGrounded", permitRequest.EquipmentBondedGrounded);
            command.AddParameter("FireBlanket", permitRequest.FireBlanket);
            command.AddParameter("FireFightingEquipment", permitRequest.FireFightingEquipment);
            command.AddParameter("FireWatch", permitRequest.FireWatch);
            command.AddParameter("HydrantPermit", permitRequest.HydrantPermit);
            command.AddParameter("WaterHose", permitRequest.WaterHose);
            command.AddParameter("SteamHose", permitRequest.SteamHose);
            command.AddParameter("Other2Checked", permitRequest.Other2Checked);
            command.AddParameter("Other2Value", permitRequest.Other2Value);
            command.AddParameter("AirMover", permitRequest.AirMover);
            command.AddParameter("ContinuousGasMonitor", permitRequest.ContinuousGasMonitor);
            command.AddParameter("DrowningProtection", permitRequest.DrowningProtection);
            command.AddParameter("RespiratoryProtection", permitRequest.RespiratoryProtection);
            command.AddParameter("Other3Checked", permitRequest.Other3Checked);
            command.AddParameter("Other3Value", permitRequest.Other3Value);
            command.AddParameter("AdditionalLighting", permitRequest.AdditionalLighting);
            command.AddParameter("DesignateHotOrColdCutChecked", permitRequest.DesignateHotOrColdCutChecked);
            command.AddParameter("DesignateHotOrColdCutValue", permitRequest.DesignateHotOrColdCutValue);
            command.AddParameter("HoistingEquipment", permitRequest.HoistingEquipment);
            command.AddParameter("Ladder", permitRequest.Ladder);
            command.AddParameter("MotorizedEquipment", permitRequest.MotorizedEquipment);
            command.AddParameter("Scaffold", permitRequest.Scaffold);
            command.AddParameter("ReferToTipsProcedure", permitRequest.ReferToTipsProcedure);
            command.AddParameter("GasDetectorBumpTested", permitRequest.GasDetectorBumpTested);
        }

        protected override void InsertPermitWorkOrderSources(SqlCommand command, PermitRequestLubes permitRequest)
        {
            workOrderSourceDao.InsertWorkOrderSourceList(command, permitRequest);
        }

        protected override void DeletePermitWorkOrderSources(SqlCommand command, PermitRequestLubes permitRequest)
        {
            workOrderSourceDao.DeleteByPermitRequestId(command, permitRequest.IdValue);
        }

        protected override void InsertDocumentLinks(SqlCommand command, PermitRequestLubes permitRequest)
        {
            documentLinkDao.InsertNewDocumentLinks(permitRequest, documentLinkDao.InsertForAssociatedPermitRequestLubes);
        }

        protected override void RemoveDocumentLinks(SqlCommand command, PermitRequestLubes permitRequest)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(permitRequest, documentLinkDao.QueryByPermitRequestLubesId);
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
            throw new NotImplementedException();
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
