using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitLubesHistoryDao : AbstractManagedDao, IWorkPermitLubesHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryWorkPermitLubesHistoryById";
        private const string INSERT = "InsertWorkPermitLubesHistory";

        private readonly IUserDao userDao;

        public WorkPermitLubesHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
        }

        public List<WorkPermitLubesHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<WorkPermitLubesHistory>(PopulateInstance , QUERY_HISTORIES_BY_ID);
        }

        public void Insert(WorkPermitLubesHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private WorkPermitLubesHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");

            WorkPermitLubesHistory history = new WorkPermitLubesHistory(id, lastModifiedBy, lastModifiedDate);

            history.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatus"));
            history.PermitNumber = reader.Get<long?>("PermitNumber");

            long? issuedByUserId = reader.Get<long?>("IssuedByUserId");
            if (issuedByUserId != null)
            {
                history.IssuedBy = userDao.QueryById(issuedByUserId.Value);
            }

            history.IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime");

            history.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            history.IssuedToCompany = reader.Get<bool>("IssuedToCompany");
            history.Company = reader.Get<string>("Company");
            history.Trade = reader.Get<string>("Trade");
            history.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            history.RequestedByGroup = reader.Get<string>("RequestedByGroup");

            history.WorkPermitType = WorkPermitLubesType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.IsVehicleEntry = reader.Get<bool>("IsVehicleEntry");

            history.FunctionalLocation = reader.Get<string>("FunctionalLocation");
            history.Location = reader.Get<string>("Location");

            history.DocumentLinks = reader.Get<string>("DocumentLinks");

            history.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            history.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            history.RescuePlan = reader.Get<bool>("RescuePlan");
            history.ConfinedSpaceSafetyWatchChecklist = reader.Get<bool>("ConfinedSpaceSafetyWatchChecklist");

            history.SpecialWork = reader.Get<bool>("SpecialWork");
            history.SpecialWorkType = reader.Get<string>("SpecialWorkType");
            history.HazardousWorkApproverAdvised = reader.Get<bool>("HazardousWorkApproverAdvised");
            history.AdditionalFollowupRequired = reader.Get<bool>("AdditionalFollowupRequired");

            history.StartDateTime = reader.Get<DateTime>("StartDateTime");
            history.ExpireDateTime = reader.Get<DateTime>("ExpireDateTime");

            history.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            history.OperationNumber = reader.Get<string>("OperationNumber");
            history.SubOperationNumber = reader.Get<string>("SubOperationNumber");

            history.HighEnergy = WorkPermitSafetyFormState.GetById(reader.Get<byte>("HighEnergy"));
            history.CriticalLift = WorkPermitSafetyFormState.GetById(reader.Get<byte>("CriticalLift"));
            history.Excavation = WorkPermitSafetyFormState.GetById(reader.Get<byte>("Excavation"));
            history.EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergyControlPlanFormRequirement"));
            history.EquivalencyProc = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EquivalencyProc"));
            history.TestPneumatic = WorkPermitSafetyFormState.GetById(reader.Get<byte>("TestPneumatic"));
            history.LiveFlareWork = WorkPermitSafetyFormState.GetById(reader.Get<byte>("LiveFlareWork"));
            history.EntryAndControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EntryAndControlPlan"));
            history.EnergizedElectrical = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergizedElectrical"));

            history.TaskDescription = reader.Get<string>("TaskDescription");

            history.HazardHydrocarbonGas = reader.Get<bool>("HazardHydrocarbonGas");
            history.HazardHydrocarbonLiquid = reader.Get<bool>("HazardHydrocarbonLiquid");
            history.HazardHydrogenSulphide = reader.Get<bool>("HazardHydrogenSulphide");
            history.HazardInertGasAtmosphere = reader.Get<bool>("HazardInertGasAtmosphere");
            history.HazardOxygenDeficiency = reader.Get<bool>("HazardOxygenDeficiency");
            history.HazardRadioactiveSources = reader.Get<bool>("HazardRadioactiveSources");
            history.HazardUndergroundOverheadHazards = reader.Get<bool>("HazardUndergroundOverheadHazards");
            history.HazardDesignatedSubstance = reader.Get<bool>("HazardDesignatedSubstance");

            history.OtherHazardsAndOrRequirements = reader.Get<string>("OtherHazardsAndOrRequirements");

            history.OtherAreasAndOrUnitsAffected = reader.Get<bool>("OtherAreasAndOrUnitsAffected");
            history.OtherAreasAndOrUnitsAffectedArea = reader.Get<string>("OtherAreasAndOrUnitsAffectedArea");
            history.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<string>("OtherAreasAndOrUnitsAffectedPersonNotified");

            history.WorkPreparationsCompletedSectionNotApplicableToJob = reader.Get<bool>("WorkPreparationsCompletedSectionNotApplicableToJob");
            history.ProductNormallyInPipingEquipment = reader.Get<string>("ProductNormallyInPipingEquipment");

            history.DepressuredDrained = reader.Get<string>("DepressuredDrained");
            history.WaterWashed = reader.Get<string>("WaterWashed");
            history.ChemicallyWashed = reader.Get<string>("ChemicallyWashed");
            history.Steamed = reader.Get<string>("Steamed");
            history.Purged = reader.Get<string>("Purged");
            history.Disconnected = reader.Get<string>("Disconnected");
            history.DepressuredAndVented = reader.Get<string>("DepressuredAndVented");
            history.Ventilated = reader.Get<string>("Ventilated");
            history.Blanked = reader.Get<string>("Blanked");
            history.DrainsCovered = reader.Get<string>("DrainsCovered");
            history.AreaBarricaded = reader.Get<string>("AreaBarricated");
            history.EnergySourcesLockedOutTaggedOut = reader.Get<string>("EnergySourcesLockedOutTaggedOut");

            history.EnergyControlPlan = reader.Get<string>("EnergyControlPlan");
            history.LockBoxNumber = reader.Get<string>("LockBoxNumber");
            history.OtherPreparations = reader.Get<string>("OtherPreparations");

            history.SpecificRequirementsSectionNotApplicableToJob = reader.Get<bool>("SpecificRequirementsSectionNotApplicableToJob");
            history.AttendedAtAllTimes = reader.Get<bool>("AttendedAtAllTimes");
            history.EyeProtection = reader.Get<bool>("EyeProtection");
            history.FallProtectionEquipment = reader.Get<bool>("FallProtectionEquipment");
            history.FullBodyHarnessRetrieval = reader.Get<bool>("FullBodyHarnessRetrieval");
            history.HearingProtection = reader.Get<bool>("HearingProtection");
            history.ProtectiveClothing = reader.Get<bool>("ProtectiveClothing");
            history.Other1Checked = reader.Get<bool>("Other1Checked");
            history.Other1Value = reader.Get<string>("Other1Value");

            history.EquipmentBondedGrounded = reader.Get<bool>("EquipmentBondedGrounded");
            history.FireBlanket = reader.Get<bool>("FireBlanket");
            history.FireFightingEquipment = reader.Get<bool>("FireFightingEquipment");
            history.FireWatch = reader.Get<bool>("FireWatch");
            history.HydrantPermit = reader.Get<bool>("HydrantPermit");
            history.WaterHose = reader.Get<bool>("WaterHose");
            history.SteamHose = reader.Get<bool>("SteamHose");
            history.Other2Checked = reader.Get<bool>("Other2Checked");
            history.Other2Value = reader.Get<string>("Other2Value");

            history.AirMover = reader.Get<bool>("AirMover");
            history.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");
            history.DrowningProtection = reader.Get<bool>("DrowningProtection");
            history.RespiratoryProtection = reader.Get<bool>("RespiratoryProtection");
            history.Other3Checked = reader.Get<bool>("Other3Checked");
            history.Other3Value = reader.Get<string>("Other3Value");

            history.AdditionalLighting = reader.Get<bool>("AdditionalLighting");
            history.FireBlanket = reader.Get<bool>("FireBlanket");
            history.DesignateHotOrColdCutChecked = reader.Get<bool>("DesignateHotOrColdCutChecked");
            history.DesignateHotOrColdCutValue = reader.Get<string>("DesignateHotOrColdCutValue");
            history.HoistingEquipment = reader.Get<bool>("HoistingEquipment");
            history.Ladder = reader.Get<bool>("Ladder");
            history.MotorizedEquipment = reader.Get<bool>("MotorizedEquipment");
            history.Scaffold = reader.Get<bool>("Scaffold");            
            history.ReferToTipsProcedure = reader.Get<bool>("ReferToTipsProcedure");

            history.GasDetectorBumpTested = reader.Get<bool>("GasDetectorBumpTested");
            history.AtmosphericGasTestRequired = reader.Get<bool>("AtmosphericGasTestRequired");

            return history;
        }

        private void AddInsertParameters(WorkPermitLubesHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("WorkPermitStatus", history.WorkPermitStatus.IdValue);

            command.AddParameter("DocumentLinks", history.DocumentLinks);
            command.AddParameter("PermitNumber", history.PermitNumber);

            command.AddParameter("IssuedDateTime", history.IssuedDateTime);
            command.AddParameter("IssuedByUserId", history.IssuedBy == null ? null : history.IssuedBy.Id);

            command.AddParameter("IssuedToSuncor", history.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", history.IssuedToCompany);
            command.AddParameter("Company", history.Company);
            command.AddParameter("Trade", history.Trade);
            command.AddParameter("NumberOfWorkers", history.NumberOfWorkers);
            command.AddParameter("RequestedByGroup", history.RequestedByGroup);

            command.AddParameter("WorkPermitTypeId", history.WorkPermitType.IdValue);
            command.AddParameter("IsVehicleEntry", history.IsVehicleEntry);

            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);

            command.AddParameter("ConfinedSpace", history.ConfinedSpace);
            command.AddParameter("ConfinedSpaceClass", history.ConfinedSpaceClass);
            command.AddParameter("RescuePlan", history.RescuePlan);
            command.AddParameter("ConfinedSpaceSafetyWatchChecklist", history.ConfinedSpaceSafetyWatchChecklist);

            command.AddParameter("SpecialWork", history.SpecialWork);
            command.AddParameter("SpecialWorkType", history.SpecialWorkType);
            command.AddParameter("HazardousWorkApproverAdvised", history.HazardousWorkApproverAdvised);
            command.AddParameter("AdditionalFollowupRequired", history.AdditionalFollowupRequired);

            command.AddParameter("OtherAreasAndOrUnitsAffected", history.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", history.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", history.OtherAreasAndOrUnitsAffectedPersonNotified);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("HighEnergy", history.HighEnergy.IdValue);
            command.AddParameter("CriticalLift", history.CriticalLift.IdValue);
            command.AddParameter("Excavation", history.Excavation.IdValue);
            command.AddParameter("EnergyControlPlanFormRequirement", history.EnergyControlPlanFormRequirement.IdValue);
            command.AddParameter("EquivalencyProc", history.EquivalencyProc.IdValue);
            command.AddParameter("TestPneumatic", history.TestPneumatic.IdValue);
            command.AddParameter("LiveFlareWork", history.LiveFlareWork.IdValue);
            command.AddParameter("EntryAndControlPlan", history.EntryAndControlPlan.IdValue);
            command.AddParameter("EnergizedElectrical", history.EnergizedElectrical.IdValue);

            command.AddParameter("HazardHydrocarbonGas", history.HazardHydrocarbonGas);
            command.AddParameter("HazardHydrocarbonLiquid", history.HazardHydrocarbonLiquid);
            command.AddParameter("HazardHydrogenSulphide", history.HazardHydrogenSulphide);
            command.AddParameter("HazardInertGasAtmosphere", history.HazardInertGasAtmosphere);
            command.AddParameter("HazardOxygenDeficiency", history.HazardOxygenDeficiency);
            command.AddParameter("HazardRadioactiveSources", history.HazardRadioactiveSources);
            command.AddParameter("HazardUndergroundOverheadHazards", history.HazardUndergroundOverheadHazards);
            command.AddParameter("HazardDesignatedSubstance", history.HazardDesignatedSubstance);

            command.AddParameter("StartDateTime", history.StartDateTime);
            command.AddParameter("ExpireDateTime", history.ExpireDateTime);
            command.AddParameter("WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("OperationNumber", history.OperationNumber);
            command.AddParameter("SubOperationNumber", history.SubOperationNumber);
            command.AddParameter("TaskDescription", history.TaskDescription);
            command.AddParameter("OtherHazardsAndOrRequirements", history.OtherHazardsAndOrRequirements);

            command.AddParameter("WorkPreparationsCompletedSectionNotApplicableToJob", history.WorkPreparationsCompletedSectionNotApplicableToJob);
            command.AddParameter("ProductNormallyInPipingEquipment", history.ProductNormallyInPipingEquipment);

            command.AddParameter("DepressuredDrained", history.DepressuredDrained);
            command.AddParameter("WaterWashed", history.WaterWashed);
            command.AddParameter("ChemicallyWashed", history.ChemicallyWashed);
            command.AddParameter("Steamed", history.Steamed);
            command.AddParameter("Purged", history.Purged);
            command.AddParameter("Disconnected", history.Disconnected);
            command.AddParameter("DepressuredAndVented", history.DepressuredAndVented);
            command.AddParameter("Ventilated", history.Ventilated);
            command.AddParameter("Blanked", history.Blanked);
            command.AddParameter("DrainsCovered", history.DrainsCovered);
            command.AddParameter("AreaBarricated", history.AreaBarricaded);
            command.AddParameter("EnergySourcesLockedOutTaggedOut", history.EnergySourcesLockedOutTaggedOut);

            command.AddParameter("EnergyControlPlan", history.EnergyControlPlan);
            command.AddParameter("LockBoxNumber", history.LockBoxNumber);
            command.AddParameter("OtherPreparations", history.OtherPreparations);

            command.AddParameter("SpecificRequirementsSectionNotApplicableToJob", history.SpecificRequirementsSectionNotApplicableToJob);
            command.AddParameter("AttendedAtAllTimes", history.AttendedAtAllTimes);
            command.AddParameter("EyeProtection", history.EyeProtection);
            command.AddParameter("FallProtectionEquipment", history.FallProtectionEquipment);
            command.AddParameter("FullBodyHarnessRetrieval", history.FullBodyHarnessRetrieval);
            command.AddParameter("HearingProtection", history.HearingProtection);
            command.AddParameter("ProtectiveClothing", history.ProtectiveClothing);
            command.AddParameter("Other1Checked", history.Other1Checked);
            command.AddParameter("Other1Value", history.Other1Value);

            command.AddParameter("EquipmentBondedGrounded", history.EquipmentBondedGrounded);
            command.AddParameter("FireBlanket", history.FireBlanket);
            command.AddParameter("FireFightingEquipment", history.FireFightingEquipment);
            command.AddParameter("FireWatch", history.FireWatch);
            command.AddParameter("HydrantPermit", history.HydrantPermit);
            command.AddParameter("WaterHose", history.WaterHose);
            command.AddParameter("SteamHose", history.SteamHose);
            command.AddParameter("Other2Checked", history.Other2Checked);
            command.AddParameter("Other2Value", history.Other2Value);

            command.AddParameter("AirMover", history.AirMover);
            command.AddParameter("ContinuousGasMonitor", history.ContinuousGasMonitor);
            command.AddParameter("DrowningProtection", history.DrowningProtection);
            command.AddParameter("RespiratoryProtection", history.RespiratoryProtection);
            command.AddParameter("Other3Checked", history.Other3Checked);
            command.AddParameter("Other3Value", history.Other3Value);

            command.AddParameter("AdditionalLighting", history.AdditionalLighting);
            command.AddParameter("DesignateHotOrColdCutChecked", history.DesignateHotOrColdCutChecked);
            command.AddParameter("DesignateHotOrColdCutValue", history.DesignateHotOrColdCutValue);
            command.AddParameter("HoistingEquipment", history.HoistingEquipment);
            command.AddParameter("Ladder", history.Ladder);
            command.AddParameter("MotorizedEquipment", history.MotorizedEquipment);
            command.AddParameter("Scaffold", history.Scaffold);
            command.AddParameter("ReferToTipsProcedure", history.ReferToTipsProcedure);

            command.AddParameter("GasDetectorBumpTested", history.GasDetectorBumpTested);
            command.AddParameter("AtmosphericGasTestRequired", history.AtmosphericGasTestRequired);
        }
    }
}
