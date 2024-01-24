using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitEdmontonHistoryDao : AbstractManagedDao, IWorkPermitEdmontonHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryWorkPermitEdmontonHistoryById";
        private const string INSERT = "InsertWorkPermitEdmontonHistory";

        private readonly IUserDao userDao;

        public WorkPermitEdmontonHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
        }

        public List<WorkPermitEdmontonHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<WorkPermitEdmontonHistory>(PopulateInstance , QUERY_HISTORIES_BY_ID);
        }

        public void Insert(WorkPermitEdmontonHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private WorkPermitEdmontonHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");

            WorkPermitEdmontonHistory history = new WorkPermitEdmontonHistory(id, lastModifiedBy, lastModifiedDate);

            history.DataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));
            history.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatusId"));
            history.WorkPermitType = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.Priority = Priority.GetById(reader.Get<int>("PriorityId"));
            history.DurationPermit = reader.Get<bool>("DurationPermit");

            history.PermitNumber = reader.Get<long?>("PermitNumber");
            history.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            history.IssuedToCompany = reader.Get<bool>("IssuedToCompany");
            history.Company = reader.Get<string>("Company");
            history.Occupation = reader.Get<string>("Occupation");
            history.Group = reader.Get<string>("Group");
            history.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            history.FunctionalLocation = reader.Get<string>("FunctionalLocation");
            history.Location = reader.Get<string>("Location");
            history.OtherAreasAndOrUnitsAffected = reader.Get<bool>("OtherAreasAndOrUnitsAffected");
            history.OtherAreasAndOrUnitsAffectedArea = reader.Get<string>("OtherAreasAndOrUnitsAffectedArea");
            history.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<string>("OtherAreasAndOrUnitsAffectedPersonNotified");
            history.SpecialWork = reader.Get<bool>("SpecialWork");
            history.SpecialWorkFormNumber = reader.Get<string>("SpecialWorkFormNumber");
            history.SpecialWorkType = reader.Get<string>("SpecialWorkType");
            history.VehicleEntry = reader.Get<bool>("VehicleEntry");
            history.VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal");
            history.VehicleEntryType = reader.Get<string>("VehicleEntryType");
            history.RescuePlan = reader.Get<bool>("RescuePlan");
            history.RescuePlanFormNumber = reader.Get<string>("RescuePlanFormNumber");
            history.GN59 = reader.Get<bool>("GN59");
            history.FormGN59Id = reader.Get<long?>("FormGN59Id");
            history.GN7 = reader.Get<bool>("GN7");
            history.FormGN7Id = reader.Get<long?>("FormGN7Id");
            history.GN24 = reader.Get<bool>("GN24");
            history.FormGN24Id = reader.Get<long?>("FormGN24Id");
            history.GN6 = reader.Get<bool>("GN6");
            history.FormGN6Id = reader.Get<long?>("FormGN6Id");
            history.GN75A = reader.Get<bool>("GN75A");
            history.FormGN75AId = reader.Get<long?>("FormGN75AId");
            history.GN1 = reader.Get<bool>("GN1");
            history.FormGN1TradeChecklistDisplayNumber = reader.Get<string>("FormGN1TradeChecklistDisplayNumber");

            history.GN11 = reader.Get<string>("GN11");
            history.GN6_Deprecated = reader.Get<string>("GN6_Deprecated");
            history.GN24_Deprecated = reader.Get<string>("GN24_Deprecated");
            history.GN27 = reader.Get<string>("GN27");
            history.GN75_Deprecated = reader.Get<string>("GN75_Deprecated");

            history.DocumentLinks = reader.Get<string>("DocumentLinks");
            history.AreaLabel = reader.Get<string>("AreaLabel");

            history.RequestedStartDateTime = reader.Get<DateTime>("RequestedStartDateTime");
            history.IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime");
            history.ExpiredDateTime = reader.Get<DateTime>("ExpiredDateTime");
            history.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            history.OperationNumber = reader.Get<string>("OperationNumber");
            history.SubOperationNumber = reader.Get<string>("SubOperationNumber");
            history.TaskDescription = reader.Get<string>("TaskDescription");
            history.HazardsAndOrRequirements = reader.Get<string>("HazardsAndOrRequirements");
            history.StatusOfPipingEquipmentSectionNotApplicableToJob = reader.Get<bool>("StatusOfPipingEquipmentSectionNotApplicableToJob");
            history.ProductNormallyInPipingEquipment = reader.Get<string>("ProductNormallyInPipingEquipment");
            history.IsolationValvesLocked = reader.Get<string>("IsolationValvesLocked");
            history.DepressuredDrained = reader.Get<string>("DepressuredDrained");
            history.Ventilated = reader.Get<string>("Ventilated");
            history.Purged = reader.Get<string>("Purged");
            history.BlindedAndTagged = reader.Get<string>("BlindedAndTagged");
            history.DoubleBlockAndBleed = reader.Get<string>("DoubleBlockAndBleed");
            history.ElectricalLockout = reader.Get<string>("ElectricalLockout");
            history.MechanicalLockout = reader.Get<string>("MechanicalLockout");
            history.BlindSchematicAvailable = reader.Get<string>("BlindSchematicAvailable");
            history.ZeroEnergyFormNumber = reader.Get<string>("ZeroEnergyFormNumber");
            history.LockBoxNumber = reader.Get<string>("LockBoxNumber");
            history.JobsiteEquipmentInspected = reader.Get<bool>("JobsiteEquipmentInspected");
            history.ConfinedSpaceWorkSectionNotApplicableToJob = reader.Get<bool>("ConfinedSpaceWorkSectionNotApplicableToJob");

            history.QuestionOneResponse = reader.Get<string>("QuestionOneResponse");
            history.QuestionTwoResponse = reader.Get<string>("QuestionTwoResponse");
            history.QuestionTwoAResponse = reader.Get<string>("QuestionTwoAResponse");
            history.QuestionTwoBResponse = reader.Get<string>("QuestionTwoBResponse");
            history.QuestionThreeResponse = reader.Get<string>("QuestionThreeResponse");
            history.QuestionFourResponse = reader.Get<string>("QuestionFourResponse");

            history.GasTestsSectionNotApplicableToJob = reader.Get<bool>("GasTestsSectionNotApplicableToJob");
            history.WorkerToProvideGasTestData = reader.Get<bool>("WorkerToProvideGasTestData");
            history.OperatorGasDetectorNumber = reader.Get<string>("OperatorGasDetectorNumber");
            history.GasTestDataLine1CombustibleGas = reader.Get<string>("GasTestDataLine1CombustibleGas");
            history.GasTestDataLine1Oxygen = reader.Get<string>("GasTestDataLine1Oxygen");
            history.GasTestDataLine1ToxicGas = reader.Get<string>("GasTestDataLine1ToxicGas");
            history.GasTestDataLine1Time = GetTime(reader.Get<DateTime?>("GasTestDataLine1Time"));
            history.GasTestDataLine2CombustibleGas = reader.Get<string>("GasTestDataLine2CombustibleGas");
            history.GasTestDataLine2Oxygen = reader.Get<string>("GasTestDataLine2Oxygen");
            history.GasTestDataLine2ToxicGas = reader.Get<string>("GasTestDataLine2ToxicGas");
            history.GasTestDataLine2Time = GetTime(reader.Get<DateTime?>("GasTestDataLine2Time"));
            history.GasTestDataLine3CombustibleGas = reader.Get<string>("GasTestDataLine3CombustibleGas");
            history.GasTestDataLine3Oxygen = reader.Get<string>("GasTestDataLine3Oxygen");
            history.GasTestDataLine3ToxicGas = reader.Get<string>("GasTestDataLine3ToxicGas");
            history.GasTestDataLine3Time = GetTime(reader.Get<DateTime?>("GasTestDataLine3Time"));
            history.GasTestDataLine4CombustibleGas = reader.Get<string>("GasTestDataLine4CombustibleGas");
            history.GasTestDataLine4Oxygen = reader.Get<string>("GasTestDataLine4Oxygen");
            history.GasTestDataLine4ToxicGas = reader.Get<string>("GasTestDataLine4ToxicGas");
            history.GasTestDataLine4Time = GetTime(reader.Get<DateTime?>("GasTestDataLine4Time"));
            history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<bool>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            history.FaceShield = reader.Get<bool>("FaceShield");
            history.Goggles = reader.Get<bool>("Goggles");
            history.RubberBoots = reader.Get<bool>("RubberBoots");
            history.RubberGloves = reader.Get<bool>("RubberGloves");
            history.RubberSuit = reader.Get<bool>("RubberSuit");
            history.SafetyHarnessLifeline = reader.Get<bool>("SafetyHarnessLifeline");
            history.HighVoltagePPE = reader.Get<bool>("HighVoltagePPE");
            history.Other1Checked = reader.Get<bool>("Other1Checked");
            history.Other1 = reader.Get<string>("Other1");
            history.EquipmentGrounded = reader.Get<bool>("EquipmentGrounded");
            history.FireBlanket = reader.Get<bool>("FireBlanket");
            history.FireExtinguisher = reader.Get<bool>("FireExtinguisher");
            history.FireMonitorManned = reader.Get<bool>("FireMonitorManned");
            history.FireWatch = reader.Get<bool>("FireWatch");
            history.SewersDrainsCovered = reader.Get<bool>("SewersDrainsCovered");
            history.SteamHose = reader.Get<bool>("SteamHose");
            history.Other2Checked = reader.Get<bool>("Other2Checked");
            history.Other2 = reader.Get<string>("Other2");
            history.AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator");
            history.BreathingAirApparatus = reader.Get<bool>("BreathingAirApparatus");
            history.DustMask = reader.Get<bool>("DustMask");
            history.LifeSupportSystem = reader.Get<bool>("LifeSupportSystem");
            history.SafetyWatch = reader.Get<bool>("SafetyWatch");
            history.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");
            history.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            history.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            history.BumpTestMonitorPriorToUse = reader.Get<bool>("BumpTestMonitorPriorToUse");
            history.Other3Checked = reader.Get<bool>("Other3Checked");
            history.Other3 = reader.Get<string>("Other3");
            history.AirMover = reader.Get<bool>("AirMover");
            history.BarriersSigns = reader.Get<bool>("BarriersSigns");
            history.RadioChannel = reader.Get<bool>("RadioChannel");
            history.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            history.AirHorn = reader.Get<bool>("AirHorn");
            history.MechVentilationComfortOnly = reader.Get<bool>("MechVentilationComfortOnly");
            history.AsbestosMMCPrecautions = reader.Get<bool>("AsbestosMMCPrecautions");
            history.Other4Checked = reader.Get<bool>("Other4Checked");
            history.Other4 = reader.Get<string>("Other4");
            history.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            history.AlkylationEntryClassOfClothing = reader.Get<string>("AlkylationEntryClassOfClothing");
            history.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            history.FlarePitEntryType = reader.Get<string>("FlarePitEntryType");
            history.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            history.ConfinedSpaceCardNumber = reader.Get<string>("ConfinedSpaceCardNumber");
            history.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");

            history.RequestedByUser = userDao.QueryById(reader.Get<long>("RequestedByUserId"));
            history.UseCurrentPermitNumberForZeroEnergyFormNumber = reader.Get<bool>("UseCurrentPermitNumberForZeroEnergyFormNumber");
            history.PermitAcceptor = reader.Get<string>("PermitAcceptor");
            history.ShiftSupervisor = reader.Get<string>("ShiftSupervisor");

            //Showing History for Road Access on Permit--15Dec2016
            history.RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1");
            history.RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1");
            history.RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1");

            return history;
        }

        private Time GetTime(DateTime? value)
        {
            if (value == null)
            {
                return null;
            }

            return new Time(value.Value);
        }

        private DateTime? ConvertTimeToDateTimeOrNull(Time time)
        {
            if (time == null)
            {
                return null;
            }

            return time.ToDateTime();
        }

        private void AddInsertParameters(WorkPermitEdmontonHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("WorkPermitTypeId", history.WorkPermitType.IdValue);
            command.AddParameter("DurationPermit", history.DurationPermit);
            command.AddParameter("DataSourceId", history.DataSource.IdValue);

            if (history.RequestedByUser != null)
            {
                command.AddParameter("RequestedByUserId", history.RequestedByUser.IdValue);
            }

            command.AddParameter("RequestedStartDateTime", history.RequestedStartDateTime);

            command.AddParameter("WorkPermitStatusId", history.WorkPermitStatus.IdValue);

            command.AddParameter("PriorityId", history.Priority.IdValue);
            command.AddParameter("PermitNumber", history.PermitNumber);
            command.AddParameter("IssuedToSuncor", history.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", history.IssuedToCompany);
            command.AddParameter("Company", history.Company);
            command.AddParameter("Occupation", history.Occupation);
            command.AddParameter("Group", history.Group);
            command.AddParameter("NumberOfWorkers", history.NumberOfWorkers);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);
            command.AddParameter("AreaLabel", history.AreaLabel);
            command.AddParameter("OtherAreasAndOrUnitsAffected", history.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", history.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", history.OtherAreasAndOrUnitsAffectedPersonNotified);
            command.AddParameter("SpecialWork", history.SpecialWork);
            command.AddParameter("SpecialWorkFormNumber", history.SpecialWorkFormNumber);
            command.AddParameter("SpecialWorkType", history.SpecialWorkType);
            command.AddParameter("VehicleEntry", history.VehicleEntry);
            command.AddParameter("VehicleEntryTotal", history.VehicleEntryTotal);
            command.AddParameter("VehicleEntryType", history.VehicleEntryType);
            command.AddParameter("RescuePlan", history.RescuePlan);
            command.AddParameter("RescuePlanFormNumber", history.RescuePlanFormNumber);
            command.AddParameter("GN59", history.GN59);
            command.AddParameter("FormGN59Id", history.FormGN59Id);
            command.AddParameter("GN7", history.GN7);
            command.AddParameter("FormGN7Id", history.FormGN7Id);
            command.AddParameter("GN24", history.GN24);
            command.AddParameter("FormGN24Id", history.FormGN24Id);
            command.AddParameter("GN6", history.GN6);
            command.AddParameter("FormGN6Id", history.FormGN6Id);
            command.AddParameter("GN1", history.GN1);
            command.AddParameter("FormGN1TradeChecklistDisplayNumber", history.FormGN1TradeChecklistDisplayNumber);
            command.AddParameter("GN75A", history.GN75A);
            command.AddParameter("FormGN75AId", history.FormGN75AId);
            command.AddParameter("GN11", history.GN11);
            command.AddParameter("GN24_Deprecated", history.GN24_Deprecated);
            command.AddParameter("GN6_Deprecated", history.GN6_Deprecated);
            command.AddParameter("GN27", history.GN27);
            command.AddParameter("GN75_Deprecated", history.GN75_Deprecated);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("IssuedDateTime", history.IssuedDateTime);
            command.AddParameter("ExpiredDateTime", history.ExpiredDateTime);
            command.AddParameter("WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("OperationNumber", history.OperationNumber);
            command.AddParameter("SubOperationNumber", history.SubOperationNumber);
            command.AddParameter("TaskDescription", history.TaskDescription);
            command.AddParameter("HazardsAndOrRequirements", history.HazardsAndOrRequirements);

            command.AddParameter("StatusOfPipingEquipmentSectionNotApplicableToJob", history.StatusOfPipingEquipmentSectionNotApplicableToJob);
            command.AddParameter("ProductNormallyInPipingEquipment", history.ProductNormallyInPipingEquipment);
            command.AddParameter("IsolationValvesLocked", history.IsolationValvesLocked);
            command.AddParameter("DepressuredDrained", history.DepressuredDrained);
            command.AddParameter("Ventilated", history.Ventilated);
            command.AddParameter("Purged", history.Purged);
            command.AddParameter("BlindedAndTagged", history.BlindedAndTagged);
            command.AddParameter("DoubleBlockAndBleed", history.DoubleBlockAndBleed);
            command.AddParameter("ElectricalLockout", history.ElectricalLockout);
            command.AddParameter("MechanicalLockout", history.MechanicalLockout);
            command.AddParameter("BlindSchematicAvailable", history.BlindSchematicAvailable);

            command.AddParameter("ZeroEnergyFormNumber", history.ZeroEnergyFormNumber);
            command.AddParameter("LockBoxNumber", history.LockBoxNumber);
            command.AddParameter("JobsiteEquipmentInspected", history.JobsiteEquipmentInspected);
            command.AddParameter("ConfinedSpaceWorkSectionNotApplicableToJob", history.ConfinedSpaceWorkSectionNotApplicableToJob);

            command.AddParameter("QuestionOneResponse", history.QuestionOneResponse);
            command.AddParameter("QuestionTwoResponse", history.QuestionTwoResponse);
            command.AddParameter("QuestionTwoAResponse", history.QuestionTwoAResponse);
            command.AddParameter("QuestionTwoBResponse", history.QuestionTwoBResponse);
            command.AddParameter("QuestionThreeResponse", history.QuestionThreeResponse);
            command.AddParameter("QuestionFourResponse", history.QuestionFourResponse);

            command.AddParameter("GasTestsSectionNotApplicableToJob", history.GasTestsSectionNotApplicableToJob);
            command.AddParameter("WorkerToProvideGasTestData", history.WorkerToProvideGasTestData);
            command.AddParameter("OperatorGasDetectorNumber", history.OperatorGasDetectorNumber);
            command.AddParameter("GasTestDataLine1CombustibleGas", history.GasTestDataLine1CombustibleGas);
            command.AddParameter("GasTestDataLine1Oxygen", history.GasTestDataLine1Oxygen);
            command.AddParameter("GasTestDataLine1ToxicGas", history.GasTestDataLine1ToxicGas);
            command.AddParameter("GasTestDataLine1Time", ConvertTimeToDateTimeOrNull(history.GasTestDataLine1Time));
            command.AddParameter("GasTestDataLine2CombustibleGas", history.GasTestDataLine2CombustibleGas);
            command.AddParameter("GasTestDataLine2Oxygen", history.GasTestDataLine2Oxygen);
            command.AddParameter("GasTestDataLine2ToxicGas", history.GasTestDataLine2ToxicGas);
            command.AddParameter("GasTestDataLine2Time", ConvertTimeToDateTimeOrNull(history.GasTestDataLine2Time));
            command.AddParameter("GasTestDataLine3CombustibleGas", history.GasTestDataLine3CombustibleGas);
            command.AddParameter("GasTestDataLine3Oxygen", history.GasTestDataLine3Oxygen);
            command.AddParameter("GasTestDataLine3ToxicGas", history.GasTestDataLine3ToxicGas);
            command.AddParameter("GasTestDataLine3Time", ConvertTimeToDateTimeOrNull(history.GasTestDataLine3Time));
            command.AddParameter("GasTestDataLine4CombustibleGas", history.GasTestDataLine4CombustibleGas);
            command.AddParameter("GasTestDataLine4Oxygen", history.GasTestDataLine4Oxygen);
            command.AddParameter("GasTestDataLine4ToxicGas", history.GasTestDataLine4ToxicGas);
            command.AddParameter("GasTestDataLine4Time", ConvertTimeToDateTimeOrNull(history.GasTestDataLine4Time));
            command.AddParameter("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob", history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            command.AddParameter("FaceShield", history.FaceShield);
            command.AddParameter("Goggles", history.Goggles);
            command.AddParameter("RubberBoots", history.RubberBoots);
            command.AddParameter("RubberGloves", history.RubberGloves);
            command.AddParameter("RubberSuit", history.RubberSuit);

            command.AddParameter("SafetyHarnessLifeline", history.SafetyHarnessLifeline);
            command.AddParameter("HighVoltagePPE", history.HighVoltagePPE);
            command.AddParameter("Other1Checked", history.Other1Checked);
            command.AddParameter("Other1", history.Other1);
            command.AddParameter("EquipmentGrounded", history.EquipmentGrounded);

            command.AddParameter("FireBlanket", history.FireBlanket);
            command.AddParameter("FireExtinguisher", history.FireExtinguisher);
            command.AddParameter("FireMonitorManned", history.FireMonitorManned);
            command.AddParameter("FireWatch", history.FireWatch);
            command.AddParameter("SewersDrainsCovered", history.SewersDrainsCovered);

            command.AddParameter("SteamHose", history.SteamHose);
            command.AddParameter("Other2Checked", history.Other2Checked);
            command.AddParameter("Other2", history.Other2);
            command.AddParameter("AirPurifyingRespirator", history.AirPurifyingRespirator);
            command.AddParameter("BreathingAirApparatus", history.BreathingAirApparatus);

            command.AddParameter("DustMask", history.DustMask);
            command.AddParameter("LifeSupportSystem", history.LifeSupportSystem);
            command.AddParameter("SafetyWatch", history.SafetyWatch);
            command.AddParameter("ContinuousGasMonitor", history.ContinuousGasMonitor);
            command.AddParameter("WorkersMonitor", history.WorkersMonitor);
            command.AddParameter("WorkersMonitorNumber", history.WorkersMonitorNumber);

            command.AddParameter("BumpTestMonitorPriorToUse", history.BumpTestMonitorPriorToUse);
            command.AddParameter("Other3Checked", history.Other3Checked);
            command.AddParameter("Other3", history.Other3);
            command.AddParameter("AirMover", history.AirMover);
            command.AddParameter("BarriersSigns", history.BarriersSigns);

            command.AddParameter("RadioChannel", history.RadioChannel);
            command.AddParameter("RadioChannelNumber", history.RadioChannelNumber);
            command.AddParameter("AirHorn", history.AirHorn);
            command.AddParameter("MechVentilationComfortOnly", history.MechVentilationComfortOnly);
            command.AddParameter("AsbestosMMCPrecautions", history.AsbestosMMCPrecautions);
            command.AddParameter("Other4Checked", history.Other4Checked);
            command.AddParameter("Other4", history.Other4);

            command.AddParameter("AlkylationEntry", history.AlkylationEntry);
            command.AddParameter("AlkylationEntryClassOfClothing", history.AlkylationEntryClassOfClothing);
            command.AddParameter("FlarePitEntry", history.FlarePitEntry);
            command.AddParameter("FlarePitEntryType", history.FlarePitEntryType);
            command.AddParameter("ConfinedSpace", history.ConfinedSpace);
            command.AddParameter("ConfinedSpaceCardNumber", history.ConfinedSpaceCardNumber);
            command.AddParameter("ConfinedSpaceClass", history.ConfinedSpaceClass);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("UseCurrentPermitNumberForZeroEnergyFormNumber", history.UseCurrentPermitNumberForZeroEnergyFormNumber);
            command.AddParameter("ShiftSupervisor", history.ShiftSupervisor);
            command.AddParameter("PermitAcceptor", history.PermitAcceptor);
            //mangesh for RoadAccessOnPermit & SpecialWork
            command.AddParameter("RoadAccessOnPermit", history.RoadAccessOnPermit);
            command.AddParameter("RoadAccessOnPermitFormNumber", history.RoadAccessOnPermitFormNumber);
            command.AddParameter("RoadAccessOnPermitType", history.RoadAccessOnPermitType);

            command.AddParameter("SpecialWorkName", history.SpecialWorkName);
        }
    }
}
