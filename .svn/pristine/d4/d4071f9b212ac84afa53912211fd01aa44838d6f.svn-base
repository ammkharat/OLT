using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitEdmontonHistoryDaoTest : AbstractDaoTest
    {
        private IWorkPermitEdmontonHistoryDao historyDao;
        private IWorkPermitEdmontonDao workPermitEdmontonDao;

        protected override void TestInitialize()
        {
            historyDao = DaoRegistry.GetDao<IWorkPermitEdmontonHistoryDao>();
            workPermitEdmontonDao = DaoRegistry.GetDao<IWorkPermitEdmontonDao>();
        }

        protected override void Cleanup()
        {            
        }
        
        [Ignore] [Test]
        public void ShouldInsertAndQueryHistoryEntry()
        {
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            workPermit = workPermitEdmontonDao.Insert(workPermit, null);

            WorkPermitEdmontonHistory history = new WorkPermitEdmontonHistory(workPermit);
            history.GN1 = true;
            history.FormGN1TradeChecklistDisplayNumber = "123CBPOOPHAHA";

            historyDao.Insert(history);

            List<WorkPermitEdmontonHistory> histories = historyDao.GetById(workPermit.IdValue);
            Assert.AreEqual(1, histories.Count);

            WorkPermitEdmontonHistory requeried = histories[0];

            Assert.AreEqual(history.Id, requeried.Id);

            Assert.AreEqual(history.WorkPermitStatus, requeried.WorkPermitStatus);
            Assert.AreEqual(history.DataSource, requeried.DataSource);
            Assert.AreEqual(history.Priority, requeried.Priority);
            Assert.AreEqual(history.IssuedToSuncor, requeried.IssuedToSuncor);
            Assert.AreEqual(history.IssuedToCompany, requeried.IssuedToCompany);
            Assert.AreEqual(history.Company, requeried.Company);
            Assert.AreEqual(history.Occupation, requeried.Occupation);
            Assert.AreEqual(history.NumberOfWorkers, requeried.NumberOfWorkers);
            Assert.AreEqual(history.WorkPermitType, requeried.WorkPermitType);
            Assert.AreEqual(history.DurationPermit, requeried.DurationPermit);
            Assert.AreEqual(history.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(history.Location, requeried.Location);
            Assert.AreEqual(history.AreaLabel, requeried.AreaLabel);
            Assert.That(history.RequestedStartDateTime, Is.EqualTo(requeried.RequestedStartDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.IssuedDateTime, Is.EqualTo(requeried.IssuedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.ExpiredDateTime, Is.EqualTo(requeried.ExpiredDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.PermitNumber, requeried.PermitNumber);
            Assert.AreEqual(history.WorkOrderNumber, requeried.WorkOrderNumber);
            Assert.AreEqual(history.OperationNumber, requeried.OperationNumber);
            Assert.AreEqual(history.SubOperationNumber, requeried.SubOperationNumber);
            Assert.AreEqual(history.TaskDescription, requeried.TaskDescription);
            Assert.AreEqual(history.HazardsAndOrRequirements, requeried.HazardsAndOrRequirements);
            Assert.AreEqual(history.Group, requeried.Group);

            Assert.AreEqual(history.SpecialWork, requeried.SpecialWork);
            Assert.AreEqual(history.SpecialWorkFormNumber, requeried.SpecialWorkFormNumber);
            Assert.AreEqual(history.SpecialWorkType, requeried.SpecialWorkType);
            Assert.AreEqual(history.VehicleEntry, requeried.VehicleEntry);
            Assert.AreEqual(history.VehicleEntryTotal, requeried.VehicleEntryTotal);
            Assert.AreEqual(history.VehicleEntryType, requeried.VehicleEntryType);

            Assert.AreEqual(history.RescuePlan, requeried.RescuePlan);
            Assert.AreEqual(history.RescuePlanFormNumber, requeried.RescuePlanFormNumber);
            Assert.AreEqual(history.GN59, requeried.GN59);
            Assert.AreEqual(history.FormGN59Id, requeried.FormGN59Id);
            Assert.AreEqual(history.GN7, requeried.GN7);
            Assert.AreEqual(history.FormGN7Id, requeried.FormGN7Id);
            Assert.AreEqual(history.GN6, requeried.GN6);
            Assert.AreEqual(history.GN11, requeried.GN11);
            Assert.AreEqual(history.GN24_Deprecated, requeried.GN24_Deprecated);
            Assert.AreEqual(history.GN27, requeried.GN27);
            Assert.AreEqual(history.GN75A, requeried.GN75A);
            Assert.AreEqual(history.FormGN75AId, requeried.FormGN75AId);
            Assert.AreEqual(history.GN75_Deprecated, requeried.GN75_Deprecated);
            Assert.AreEqual(history.GN1, requeried.GN1);
            Assert.AreEqual(history.FormGN1TradeChecklistDisplayNumber, requeried.FormGN1TradeChecklistDisplayNumber);

            Assert.AreEqual(history.AlkylationEntry, requeried.AlkylationEntry);
            Assert.AreEqual(history.AlkylationEntryClassOfClothing, requeried.AlkylationEntryClassOfClothing);
            Assert.AreEqual(history.FlarePitEntry, requeried.FlarePitEntry);
            Assert.AreEqual(history.FlarePitEntryType, requeried.FlarePitEntryType);
            Assert.AreEqual(history.ConfinedSpace, requeried.ConfinedSpace);
            Assert.AreEqual(history.ConfinedSpaceCardNumber, requeried.ConfinedSpaceCardNumber);
            Assert.AreEqual(history.ConfinedSpaceClass, requeried.ConfinedSpaceClass);
            Assert.AreEqual(history.OtherAreasAndOrUnitsAffected, requeried.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(history.OtherAreasAndOrUnitsAffectedArea, requeried.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(history.OtherAreasAndOrUnitsAffectedPersonNotified, requeried.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(history.StatusOfPipingEquipmentSectionNotApplicableToJob, requeried.StatusOfPipingEquipmentSectionNotApplicableToJob);
            Assert.AreEqual(history.ProductNormallyInPipingEquipment, requeried.ProductNormallyInPipingEquipment);
            Assert.AreEqual(history.IsolationValvesLocked, requeried.IsolationValvesLocked);
            Assert.AreEqual(history.DepressuredDrained, requeried.DepressuredDrained);
            Assert.AreEqual(history.Ventilated, requeried.Ventilated);
            Assert.AreEqual(history.Purged, requeried.Purged);
            Assert.AreEqual(history.BlindedAndTagged, requeried.BlindedAndTagged);
            Assert.AreEqual(history.DoubleBlockAndBleed, requeried.DoubleBlockAndBleed);
            Assert.AreEqual(history.ElectricalLockout, requeried.ElectricalLockout);
            Assert.AreEqual(history.MechanicalLockout, requeried.MechanicalLockout);
            Assert.AreEqual(history.BlindSchematicAvailable, requeried.BlindSchematicAvailable);
            Assert.AreEqual(history.ZeroEnergyFormNumber, requeried.ZeroEnergyFormNumber);
            Assert.AreEqual(history.LockBoxNumber, requeried.LockBoxNumber);
            Assert.AreEqual(history.JobsiteEquipmentInspected, requeried.JobsiteEquipmentInspected);
            Assert.AreEqual(history.ConfinedSpaceWorkSectionNotApplicableToJob, requeried.ConfinedSpaceWorkSectionNotApplicableToJob);
            Assert.AreEqual(history.QuestionOneResponse, requeried.QuestionOneResponse);
            Assert.AreEqual(history.QuestionTwoResponse, requeried.QuestionTwoResponse);
            Assert.AreEqual(history.QuestionTwoAResponse, requeried.QuestionTwoAResponse);
            Assert.AreEqual(history.QuestionTwoBResponse, requeried.QuestionTwoBResponse);
            Assert.AreEqual(history.QuestionThreeResponse, requeried.QuestionThreeResponse);
            Assert.AreEqual(history.QuestionFourResponse, requeried.QuestionFourResponse);
            Assert.AreEqual(history.GasTestsSectionNotApplicableToJob, requeried.GasTestsSectionNotApplicableToJob);
            Assert.AreEqual(history.WorkerToProvideGasTestData, requeried.WorkerToProvideGasTestData);
            Assert.AreEqual(history.OperatorGasDetectorNumber, requeried.OperatorGasDetectorNumber);
            Assert.AreEqual(history.GasTestDataLine1CombustibleGas, requeried.GasTestDataLine1CombustibleGas);
            Assert.AreEqual(history.GasTestDataLine1Oxygen, requeried.GasTestDataLine1Oxygen);
            Assert.AreEqual(history.GasTestDataLine1ToxicGas, requeried.GasTestDataLine1ToxicGas);
            Assert.AreEqual(history.GasTestDataLine1Time, requeried.GasTestDataLine1Time);
            Assert.AreEqual(history.GasTestDataLine2CombustibleGas, requeried.GasTestDataLine2CombustibleGas);
            Assert.AreEqual(history.GasTestDataLine2Oxygen, requeried.GasTestDataLine2Oxygen);
            Assert.AreEqual(history.GasTestDataLine2ToxicGas, requeried.GasTestDataLine2ToxicGas);
            Assert.AreEqual(history.GasTestDataLine2Time, requeried.GasTestDataLine2Time);
            Assert.AreEqual(history.GasTestDataLine3CombustibleGas, requeried.GasTestDataLine3CombustibleGas);
            Assert.AreEqual(history.GasTestDataLine3Oxygen, requeried.GasTestDataLine3Oxygen);
            Assert.AreEqual(history.GasTestDataLine3ToxicGas, requeried.GasTestDataLine3ToxicGas);
            Assert.AreEqual(history.GasTestDataLine3Time, requeried.GasTestDataLine3Time);
            Assert.AreEqual(history.GasTestDataLine4CombustibleGas, requeried.GasTestDataLine4CombustibleGas);
            Assert.AreEqual(history.GasTestDataLine4Oxygen, requeried.GasTestDataLine4Oxygen);
            Assert.AreEqual(history.GasTestDataLine4ToxicGas, requeried.GasTestDataLine4ToxicGas);
            Assert.AreEqual(history.GasTestDataLine4Time, requeried.GasTestDataLine4Time);
            Assert.AreEqual(history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob, requeried.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            Assert.AreEqual(history.FaceShield, requeried.FaceShield);
            Assert.AreEqual(history.Goggles, requeried.Goggles);
            Assert.AreEqual(history.RubberBoots, requeried.RubberBoots);
            Assert.AreEqual(history.RubberGloves, requeried.RubberGloves);
            Assert.AreEqual(history.RubberSuit, requeried.RubberSuit);
            Assert.AreEqual(history.SafetyHarnessLifeline, requeried.SafetyHarnessLifeline);
            Assert.AreEqual(history.HighVoltagePPE, requeried.HighVoltagePPE);
            Assert.AreEqual(history.Other1Checked, requeried.Other1Checked);
            Assert.AreEqual(history.Other1, requeried.Other1);
            Assert.AreEqual(history.EquipmentGrounded, requeried.EquipmentGrounded);
            Assert.AreEqual(history.FireBlanket, requeried.FireBlanket);
            Assert.AreEqual(history.FireExtinguisher, requeried.FireExtinguisher);
            Assert.AreEqual(history.FireMonitorManned, requeried.FireMonitorManned);
            Assert.AreEqual(history.FireWatch, requeried.FireWatch);
            Assert.AreEqual(history.SewersDrainsCovered, requeried.SewersDrainsCovered);
            Assert.AreEqual(history.SteamHose, requeried.SteamHose);
            Assert.AreEqual(history.Other2Checked, requeried.Other2Checked);
            Assert.AreEqual(history.Other2, requeried.Other2);
            Assert.AreEqual(history.AirPurifyingRespirator, requeried.AirPurifyingRespirator);
            Assert.AreEqual(history.BreathingAirApparatus, requeried.BreathingAirApparatus);
            Assert.AreEqual(history.DustMask, requeried.DustMask);
            Assert.AreEqual(history.LifeSupportSystem, requeried.LifeSupportSystem);
            Assert.AreEqual(history.SafetyWatch, requeried.SafetyWatch);
            Assert.AreEqual(history.ContinuousGasMonitor, requeried.ContinuousGasMonitor);
            Assert.AreEqual(history.WorkersMonitorNumber, requeried.WorkersMonitorNumber);
            Assert.AreEqual(history.BumpTestMonitorPriorToUse, requeried.BumpTestMonitorPriorToUse);
            Assert.AreEqual(history.Other3Checked, requeried.Other3Checked);
            Assert.AreEqual(history.Other3, requeried.Other3);
            Assert.AreEqual(history.AirMover, requeried.AirMover);
            Assert.AreEqual(history.BarriersSigns, requeried.BarriersSigns);
            Assert.AreEqual(history.RadioChannelNumber, requeried.RadioChannelNumber);
            Assert.AreEqual(history.AirHorn, requeried.AirHorn);
            Assert.AreEqual(history.MechVentilationComfortOnly, requeried.MechVentilationComfortOnly);
            Assert.AreEqual(history.AsbestosMMCPrecautions, requeried.AsbestosMMCPrecautions);
            Assert.AreEqual(history.Other4Checked, requeried.Other4Checked);
            Assert.AreEqual(history.Other4, requeried.Other4);

            Assert.AreEqual(history.DocumentLinks, requeried.DocumentLinks);
            Assert.AreEqual(history.UseCurrentPermitNumberForZeroEnergyFormNumber, requeried.UseCurrentPermitNumberForZeroEnergyFormNumber);
            Assert.AreEqual(history.ShiftSupervisor, requeried.ShiftSupervisor);
            Assert.AreEqual(history.PermitAcceptor, requeried.PermitAcceptor);
        }
    }
}
