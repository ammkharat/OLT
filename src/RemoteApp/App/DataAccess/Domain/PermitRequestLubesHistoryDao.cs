using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestLubesHistoryDao : AbstractManagedDao, IPermitRequestLubesHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryPermitRequestLubesHistoryById";
        private const string INSERT = "InsertPermitRequestLubesHistory";

        private readonly IUserDao userDao;

        public PermitRequestLubesHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
        }

        public List<PermitRequestLubesHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<PermitRequestLubesHistory>(PopulateInstance , QUERY_HISTORIES_BY_ID);
        }

        public void Insert(PermitRequestLubesHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private PermitRequestLubesHistory PopulateInstance(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");

            PermitRequestLubesHistory history = new PermitRequestLubesHistory(id, lastModifiedBy, lastModifiedDate);

            history.WorkPermitType = WorkPermitLubesType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.IsVehicleEntry = reader.Get<bool>("IsVehicleEntry");
            history.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            history.IssuedToCompany = reader.Get<bool>("IssuedToCompany");
            history.Company = reader.Get<string>("Company");
            history.Trade = reader.Get<string>("Trade");
            history.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            history.RequestedByGroup = reader.Get<string>("RequestedByGroup");

            history.FunctionalLocation = reader.Get<string>("FunctionalLocation");
            history.Location = reader.Get<string>("Location");

            history.RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            history.RequestedStartTimeDay = (reader.Get<DateTime?>("RequestedStartTimeDay")).ToTime();
            history.RequestedStartTimeNight = (reader.Get<DateTime?>("RequestedStartTimeNight")).ToTime();
            history.EndDate = new Date(reader.Get<DateTime>("EndDate"));

            history.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            history.DocumentLinks = reader.Get<string>("DocumentLinks");

            history.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            history.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            history.RescuePlan = reader.Get<bool>("RescuePlan");
            history.ConfinedSpaceSafetyWatchChecklist = reader.Get<bool>("ConfinedSpaceSafetyWatchChecklist");
            history.SpecialWork = reader.Get<bool>("SpecialWork");
            history.SpecialWorkType = reader.Get<string>("SpecialWorkType");

            history.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            history.OperationNumber = reader.Get<string>("OperationNumber");
            history.SubOperationNumber = reader.Get<string>("SubOperationNumber");

            history.HighEnergy = WorkPermitSafetyFormState.GetById(reader.Get<byte>("HighEnergy"));
            history.CriticalLift = WorkPermitSafetyFormState.GetById(reader.Get<byte>("CriticalLift"));
            history.Excavation = WorkPermitSafetyFormState.GetById(reader.Get<byte>("Excavation"));
            history.EnergyControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergyControlPlan"));
            history.EquivalencyProc = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EquivalencyProc"));
            history.TestPneumatic = WorkPermitSafetyFormState.GetById(reader.Get<byte>("TestPneumatic"));
            history.LiveFlareWork = WorkPermitSafetyFormState.GetById(reader.Get<byte>("LiveFlareWork"));
            history.EntryAndControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EntryAndControlPlan"));
            history.EnergizedElectrical = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergizedElectrical"));

            history.Description = reader.Get<string>("Description");
            history.SapDescription = reader.Get<string>("SapDescription");

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

            history.LastImportedByUser = GetUser(reader, "LastImportedByUserId");
            history.LastImportedDateTime = reader.Get<DateTime?>("LastImportedDateTime");
            history.LastSubmittedByUser = GetUser(reader, "LastSubmittedByUserId");
            history.LastSubmittedDateTime = reader.Get<DateTime?>("LastSubmittedDateTime");

            return history;
        }

        private void AddInsertParameters(PermitRequestLubesHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);

            command.AddParameter("WorkPermitTypeId", history.WorkPermitType.IdValue);
            command.AddParameter("IsVehicleEntry", history.IsVehicleEntry);
            command.AddParameter("DocumentLinks", history.DocumentLinks);
            command.AddParameter("CompletionStatusId", history.CompletionStatus.IdValue);

            command.AddParameter("IssuedToSuncor", history.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", history.IssuedToCompany);
            command.AddParameter("Company", history.Company);
            command.AddParameter("Trade", history.Trade);
            command.AddParameter("NumberOfWorkers", history.NumberOfWorkers);
            command.AddParameter("RequestedByGroup", history.RequestedByGroup);

            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);

            command.AddParameter("ConfinedSpace", history.ConfinedSpace);
            command.AddParameter("ConfinedSpaceClass", history.ConfinedSpaceClass);
            command.AddParameter("RescuePlan", history.RescuePlan);
            command.AddParameter("ConfinedSpaceSafetyWatchChecklist", history.ConfinedSpaceSafetyWatchChecklist);
            command.AddParameter("SpecialWork", history.SpecialWork);
            command.AddParameter("SpecialWorkType", history.SpecialWorkType);

            command.AddParameter("OtherAreasAndOrUnitsAffected", history.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", history.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", history.OtherAreasAndOrUnitsAffectedPersonNotified);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("LastSubmittedByUserId", history.LastSubmittedByUser == null ? null : history.LastSubmittedByUser.Id);
            command.AddParameter("LastSubmittedDateTime", history.LastSubmittedDateTime);
            command.AddParameter("LastImportedByUserId", history.LastImportedByUser == null ? null : history.LastImportedByUser.Id);
            command.AddParameter("LastImportedDateTime", history.LastImportedDateTime);

            command.AddParameter("HighEnergy", history.HighEnergy.IdValue);
            command.AddParameter("CriticalLift", history.CriticalLift.IdValue);
            command.AddParameter("Excavation", history.Excavation.IdValue);
            command.AddParameter("EnergyControlPlan", history.EnergyControlPlan.IdValue);
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

            command.AddParameter("EndDate", history.EndDate.ToDateTimeAtStartOfDay());
            command.AddParameter("RequestedStartDate", history.RequestedStartDate.ToDateTimeAtStartOfDay());

            DateTime? startTimeDay = history.RequestedStartTimeDay != null
                                      ? (DateTime?)history.RequestedStartTimeDay.ToDateTime()
                                      : null;

            DateTime? startTimeNight = history.RequestedStartTimeNight != null
                                      ? (DateTime?)history.RequestedStartTimeNight.ToDateTime()
                                      : null;

            command.AddParameter("RequestedStartTimeDay", startTimeDay);
            command.AddParameter("RequestedStartTimeNight", startTimeNight);

            command.AddParameter("WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("OperationNumber", history.OperationNumber);
            command.AddParameter("SubOperationNumber", history.SubOperationNumber);
            command.AddParameter("Description", history.Description);
            command.AddParameter("SapDescription", history.SapDescription);
            command.AddParameter("OtherHazardsAndOrRequirements", history.OtherHazardsAndOrRequirements);

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
        }

        private User GetUser(SqlDataReader reader, string userIdColumn)
        {
            User user = null;
            {
                long? userid = reader.Get<long?>(userIdColumn);
                if (userid.HasValue)
                {
                    user = userDao.QueryById(userid.Value);
                }
            }
            return user;
        }
    }
}
