using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitEdmontonFixture
    {
        public static WorkPermitEdmonton CreateForInsert(FunctionalLocation floc)
        {
            return CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);
        }

        public static WorkPermitEdmonton CreateForInsert(DateTime requestedStart, DateTime issuedDateTime, DateTime endDateTime)
        {
            return CreateForInsert(requestedStart, issuedDateTime, endDateTime, FunctionalLocationFixture.GetReal_ED1_A001_U007());
        }

        public static WorkPermitEdmonton CreateForInsert(DateTime requestedStart, DateTime endDateTime)
        {
            return CreateForInsert(requestedStart, requestedStart, endDateTime, FunctionalLocationFixture.GetReal_ED1_A001_U007());
        }

        public static WorkPermitEdmonton CreateForInsert(DateTime requestedStart, DateTime issuedDateTime, DateTime endDateTime, FunctionalLocation functionalLocation)
        {
            return CreateForInsert(functionalLocation, requestedStart, issuedDateTime, endDateTime, PermitRequestBasedWorkPermitStatus.Pending);
        }

        public static WorkPermitEdmonton CreateForInsert(FunctionalLocation floc, DateTime requestedStartDateTime, DateTime issuedDateTime, DateTime endDateTime, PermitRequestBasedWorkPermitStatus status)
        {
            User createdBy = UserFixture.CreateUserWithGivenId(1);

            WorkPermitEdmonton permit = new WorkPermitEdmonton(DataSource.MANUAL, status, WorkPermitEdmontonType.HOT_WORK, new DateTime(2012, 2, 15, 9, 0, 0), createdBy)
                                            {
                                                RequestedStartDateTime = requestedStartDateTime,
                                                IssuedDateTime = issuedDateTime,
                                                ExpiredDateTime = endDateTime,
                                                LastModifiedDateTime = new DateTime(2012, 2, 15, 9, 15, 0),
                                                LastModifiedBy = createdBy,
                                                FunctionalLocation = floc,
                                                TaskDescription = "This is an Edmo-permit"
                                            };

            SetSomeDefaultValues(permit, createdBy);

            return permit;
        }

        public static WorkPermitEdmonton CreateForInsert(FunctionalLocation floc, PermitRequestBasedWorkPermitStatus status)
        {
            return CreateForInsert(floc, Clock.Now, Clock.Now, Clock.Now.AddHours(5), status);
        }

        public static void SetSomeDefaultValues(WorkPermitEdmonton permit, User user)
        {
            permit.Priority = Priority.High;
            permit.DurationPermit = false;
            permit.IssuedToSuncor = true;
            permit.IssuedToCompany = true;
            permit.Company = "company";
            permit.Occupation = "occupation";
            permit.Group = new WorkPermitEdmontonGroup(2, "Construction", null, 0, true);
            permit.NumberOfWorkers = 42;
            permit.Location = "location";
            permit.AreaLabel = AreaLabelFixture.CreateWithExistingId();

            permit.AlkylationEntry = true;
            permit.AlkylationEntryClassOfClothing = "Class of Clothing";
            permit.FlarePitEntry = true;
            permit.FlarePitEntryType = "flare pit entry type";
            permit.ConfinedSpace = true;
            permit.ConfinedSpaceCardNumber = "CardNum";
            permit.ConfinedSpaceClass = "Class";
            permit.SpecialWork = true;
            permit.SpecialWorkFormNumber = "SWFN";
            permit.SpecialWorkType = EdmontonPermitSpecialWorkType.FreezePlug;
            permit.VehicleEntry = true;
            permit.VehicleEntryTotal = 43;
            permit.VehicleEntryType = "VET";
            permit.RescuePlan = true;
            permit.RescuePlanFormNumber = "RPFN";
            permit.GN59 = true;
            permit.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            permit.GN6 = true;
            permit.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            permit.GN7 = true;
            permit.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            permit.GN24 = true;
            permit.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();

            permit.GN11 = WorkPermitSafetyFormState.NotApplicable;
            permit.GN6_Deprecated = WorkPermitSafetyFormState.Required;
            permit.GN24_Deprecated = WorkPermitSafetyFormState.Required;
            permit.GN27 = WorkPermitSafetyFormState.Approved;
            permit.GN75_Deprecated = WorkPermitSafetyFormState.Required;

            permit.OtherAreasAndOrUnitsAffected = true;
            permit.OtherAreasAndOrUnitsAffectedArea = "area";
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = "person";

            permit.WorkOrderNumber = "WOnumber";
            permit.OperationNumber = "OPNU";
            permit.SubOperationNumber = "SUBO";
            permit.HazardsAndOrRequirements = "HazardsAndOrReq";
            permit.StatusOfPipingEquipmentSectionNotApplicableToJob = true;
            permit.ProductNormallyInPipingEquipment = "PNIPE";
            permit.IsolationValvesLocked = YesNoNotApplicable.YES;
            permit.DepressuredDrained = YesNoNotApplicable.YES;
            permit.Ventilated = YesNoNotApplicable.YES;
            permit.Purged = YesNoNotApplicable.YES;
            permit.BlindedAndTagged = YesNoNotApplicable.YES;
            permit.DoubleBlockAndBleed = YesNoNotApplicable.YES;
            permit.ElectricalLockout = YesNoNotApplicable.YES;
            permit.MechanicalLockout = YesNoNotApplicable.YES;
            permit.BlindSchematicAvailable = YesNoNotApplicable.YES;
            permit.ZeroEnergyFormNumber = "ZEFN";
            permit.LockBoxNumber = "LBN";
            permit.JobsiteEquipmentInspected = true;
            permit.ConfinedSpaceWorkSectionNotApplicableToJob = true;
            permit.QuestionOneResponse = YesNoNotApplicable.YES;
            permit.QuestionTwoResponse = YesNoNotApplicable.YES;
            permit.QuestionTwoAResponse = YesNoNotApplicable.YES;
            permit.QuestionTwoBResponse = YesNoNotApplicable.YES;
            permit.QuestionThreeResponse = YesNoNotApplicable.YES;
            permit.QuestionFourResponse = YesNoNotApplicable.YES;
            permit.GasTestsSectionNotApplicableToJob = true;
            permit.WorkerToProvideGasTestData = false;
            permit.OperatorGasDetectorNumber = "OGDN";
            permit.GasTestDataLine1CombustibleGas = "GTDL1CG";
            permit.GasTestDataLine1Oxygen = "GTDL1O";
            permit.GasTestDataLine1ToxicGas ="GTDL1TG";
            permit.GasTestDataLine1Time = new Time(4, 20);
            permit.GasTestDataLine2CombustibleGas = "GTDL2CG";
            permit.GasTestDataLine2Oxygen = "GTDL2O";
            permit.GasTestDataLine2ToxicGas = "GTDL2TG";
            permit.GasTestDataLine2Time = new Time(4, 30);
            permit.GasTestDataLine3CombustibleGas = "GTDL3CG";
            permit.GasTestDataLine3Oxygen = "GTDL3O";
            permit.GasTestDataLine3ToxicGas = "GTDL3TG";
            permit.GasTestDataLine3Time = new Time(4, 40);
            permit.GasTestDataLine4CombustibleGas = "GTDL4CG";
            permit.GasTestDataLine4Oxygen = "GTDL40";
            permit.GasTestDataLine4ToxicGas = "GTDL4TG";
            permit.GasTestDataLine4Time = new Time(4, 50);
            permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;
            permit.FaceShield = true;
            permit.Goggles = true;
            permit.RubberBoots = true;
            permit.RubberGloves = true;
            permit.RubberSuit = true;
            permit.SafetyHarnessLifeline = true;
            permit.HighVoltagePPE = true;
            permit.Other1Checked = true;
            permit.Other1 = "other1value";
            permit.EquipmentGrounded = true;
            permit.FireBlanket = true;
            permit.FireExtinguisher = true;
            permit.FireMonitorManned = true;
            permit.FireWatch = true;
            permit.SewersDrainsCovered = true;
            permit.SteamHose = true;
            permit.Other2Checked = true;
            permit.Other2 = "other2value";
            permit.AirPurifyingRespirator = true;
            permit.BreathingAirApparatus = true;
            permit.DustMask = true;
            permit.LifeSupportSystem = true;
            permit.SafetyWatch = true;
            permit.ContinuousGasMonitor = true;
            permit.WorkersMonitorNumber = "wmn";
            permit.BumpTestMonitorPriorToUse = true;
            permit.Other3Checked = true;
            permit.Other3 = "other3value";
            permit.AirMover = true;
            permit.BarriersSigns = true;
            permit.RadioChannelNumber = "rcn";
            permit.AirHorn = true;
            permit.MechVentilationComfortOnly = true;
            permit.AsbestosMMCPrecautions = true;
            permit.Other4Checked = true;
            permit.Other4 = "other4value";
            permit.UseCurrentPermitNumberForZeroEnergyFormNumber = false;

            permit.PermitAcceptor = "Permit Acceptor";
            permit.ShiftSupervisor = "Shift Supervisor";

            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
        }

        public static void ModifyValues(WorkPermitEdmonton permit, FunctionalLocation floc)
        {
            permit.Priority = Priority.Elevated;
            permit.Group = new WorkPermitEdmontonGroup(3, "Turnaround", new List<long> { 3 }, 2, false);
            permit.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
            permit.DurationPermit = !permit.DurationPermit;

            permit.RequestedStartDateTime = new DateTime(2013, 1, 1, 3, 4, 5);
            permit.IssuedDateTime = new DateTime(2013, 1, 1, 3, 4, 5);
            permit.ExpiredDateTime = new DateTime(2013, 1, 2, 4, 5, 5);

            permit.LastModifiedDateTime = new DateTime(2013, 1, 5, 3, 7, 5);
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(2);
            permit.IssuedByUser = UserFixture.CreateSupervisor(SiteFixture.Edmonton());

            permit.FunctionalLocation = floc;

            permit.TaskDescription = "This is an Edmo-permitkjkjkj";
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
            permit.IssuedToSuncor = false;
            permit.IssuedToCompany = false;
            permit.Company = "companykjkj";
            permit.Occupation = "occupationkjkj";
            permit.NumberOfWorkers = 42;
            permit.Location = "locationkjkj";
            permit.AreaLabel = null;
            permit.AlkylationEntry = false;
            permit.AlkylationEntryClassOfClothing = "Class of Clothingkjjk";
            permit.FlarePitEntry = false;
            permit.FlarePitEntryType = "blazinga";
            permit.ConfinedSpace = false;
            permit.ConfinedSpaceCardNumber = "CardNumkj";
            permit.ConfinedSpaceClass = "Classkj";
            permit.SpecialWork = false;
            permit.SpecialWorkFormNumber = "ABCD";
            permit.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;
            permit.VehicleEntry = false;
            permit.VehicleEntryTotal = 45;
            permit.VehicleEntryType = "VETkj";
            permit.RescuePlan = false;
            permit.RescuePlanFormNumber = "RPFNkjk";
            permit.GN59 = false;
            permit.FormGN59 = FormGN59Fixture.CreateAnotherFormWithExistingId();
            permit.GN6 = false;
            permit.FormGN6 = FormGN6Fixture.CreateAnotherFormWithExistingId();
            permit.GN7 = false;
            permit.FormGN7 = FormGN7Fixture.CreateAnotherFormWithExistingId();
            permit.GN24 = false;
            permit.FormGN24 = FormGN24Fixture.CreateAnotherFormWithExistingId();
            permit.OtherAreasAndOrUnitsAffected = false;
            permit.OtherAreasAndOrUnitsAffectedArea = "area2";
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = "person2";
            permit.WorkOrderNumber = "WOnumberkjkj";
            permit.OperationNumber = "OPPP";
            permit.SubOperationNumber = "AQWE";
            permit.HazardsAndOrRequirements = "HazardsAndOrReqkjkj";
            permit.StatusOfPipingEquipmentSectionNotApplicableToJob = false;
            permit.ProductNormallyInPipingEquipment = "PNIPEkjkj";
            permit.IsolationValvesLocked = YesNoNotApplicable.NO;
            permit.DepressuredDrained = YesNoNotApplicable.NO;
            permit.Ventilated = YesNoNotApplicable.NO;
            permit.Purged = YesNoNotApplicable.NO;
            permit.BlindedAndTagged = YesNoNotApplicable.NO;
            permit.DoubleBlockAndBleed = YesNoNotApplicable.NO;
            permit.ElectricalLockout = YesNoNotApplicable.NO;
            permit.MechanicalLockout = YesNoNotApplicable.NO;
            permit.BlindSchematicAvailable = YesNoNotApplicable.NO;
            permit.ZeroEnergyFormNumber = "ZEFNkjkj";
            permit.LockBoxNumber = "LBNkjkj";
            permit.JobsiteEquipmentInspected = false;
            permit.ConfinedSpaceWorkSectionNotApplicableToJob = false;
            permit.QuestionOneResponse = YesNoNotApplicable.NOT_APPLICABLE;
            permit.QuestionTwoResponse = YesNoNotApplicable.NO;
            permit.QuestionTwoAResponse = YesNoNotApplicable.NO;
            permit.QuestionTwoBResponse = YesNoNotApplicable.NO;
            permit.QuestionThreeResponse = YesNoNotApplicable.NO;
            permit.QuestionFourResponse = YesNoNotApplicable.NO;
            permit.GasTestsSectionNotApplicableToJob = false;
            permit.WorkerToProvideGasTestData = true;
            permit.OperatorGasDetectorNumber = "gas detector number";
            permit.GasTestDataLine1CombustibleGas = "combust1";
            permit.GasTestDataLine1Oxygen = "Oxygen1";
            permit.GasTestDataLine1ToxicGas = "toxic gas 1";
            permit.GasTestDataLine1Time = new Time(5, 20);
            permit.GasTestDataLine2CombustibleGas = "combust2";
            permit.GasTestDataLine2Oxygen = "Oxygen2";
            permit.GasTestDataLine2ToxicGas = "toxic gas 2";
            permit.GasTestDataLine2Time = new Time(5, 30);
            permit.GasTestDataLine3CombustibleGas = "combust3";
            permit.GasTestDataLine3Oxygen = "Oxygen3";
            permit.GasTestDataLine3ToxicGas = "toxic gas 3";
            permit.GasTestDataLine3Time = new Time(5, 40);
            permit.GasTestDataLine4CombustibleGas = "combust4";
            permit.GasTestDataLine4Oxygen = "Oxygen4";
            permit.GasTestDataLine4ToxicGas = "toxic gas 4";
            permit.GasTestDataLine4Time = new Time(5, 50);
            permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
            permit.FaceShield = false;
            permit.Goggles = false;
            permit.RubberBoots = false;
            permit.RubberGloves = false;
            permit.RubberSuit = false;
            permit.SafetyHarnessLifeline = false;
            permit.HighVoltagePPE = false;
            permit.Other1Checked = false;
            permit.Other1 = "other1valuejhjh";
            permit.EquipmentGrounded = false;
            permit.FireBlanket = false;
            permit.FireExtinguisher = false;
            permit.FireMonitorManned = false;
            permit.FireWatch = false;
            permit.SewersDrainsCovered = false;
            permit.SteamHose = false;
            permit.Other2Checked = false;
            permit.Other2 = "other2valuejhjh";
            permit.AirPurifyingRespirator = false;
            permit.BreathingAirApparatus = false;
            permit.DustMask = false;
            permit.LifeSupportSystem = false;
            permit.SafetyWatch = false;
            permit.ContinuousGasMonitor = false;
            permit.WorkersMonitorNumber = "wmn chng";
            permit.BumpTestMonitorPriorToUse = false;
            permit.Other3Checked = false;
            permit.Other3 = "other3valuejhjh";
            permit.AirMover = false;
            permit.BarriersSigns = false;
            permit.RadioChannelNumber = "rcn chng";
            permit.AirHorn = false;
            permit.MechVentilationComfortOnly = false;
            permit.AsbestosMMCPrecautions = false;
            permit.Other4Checked = false;
            permit.Other4 = "other4valuejhjh";
            permit.UseCurrentPermitNumberForZeroEnergyFormNumber = true;

            permit.DocumentLinks.Clear();
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());

            permit.PermitAcceptor = "Permit Acceptor 2";
            permit.ShiftSupervisor = "Shift Supervisor 2";
        }        
    }
}
