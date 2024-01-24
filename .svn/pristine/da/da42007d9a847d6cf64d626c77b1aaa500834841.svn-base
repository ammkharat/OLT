using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class PermitRequestLubesHistoryDaoTest : AbstractDaoTest
    {
        private IPermitRequestLubesHistoryDao historyDao;
        private IPermitRequestLubesDao permitRequestDao;
        private IWorkPermitLubesGroupDao groupDao;

        protected override void TestInitialize()
        {
            historyDao = DaoRegistry.GetDao<IPermitRequestLubesHistoryDao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestLubesDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
        }

        protected override void Cleanup()
        {            
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryHistoryEntry()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(groups[0]);
            permitRequestDao.Insert(permitRequest);

            PermitRequestLubesHistory history = new PermitRequestLubesHistory(permitRequest);
            historyDao.Insert(history);

            List<PermitRequestLubesHistory> histories = historyDao.GetById(permitRequest.IdValue);
            Assert.AreEqual(1, histories.Count);

            PermitRequestLubesHistory requeried = histories[0];

            Assert.AreEqual(history.Id, requeried.Id);

            AssertFieldValues(history, requeried);        
        }

        [Ignore] [Test]
        public void ShouldNotConvertNullLastSubmittedUserToTheSAPUserWhenQuerying()
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateForInsert(groups[0]);
            permitRequest.LastSubmittedByUser = null;
            permitRequestDao.Insert(permitRequest);

            PermitRequestLubesHistory history = new PermitRequestLubesHistory(permitRequest);
            historyDao.Insert(history);

            List<PermitRequestLubesHistory> histories = historyDao.GetById(permitRequest.IdValue);
            Assert.AreEqual(1, histories.Count);

            PermitRequestLubesHistory requeried = histories[0];
            Assert.IsNull(requeried.LastSubmittedByUser);
        }

        private void AssertFieldValues(PermitRequestLubesHistory history, PermitRequestLubesHistory requeriedHistory)
        {
            Assert.That(history.LastModifiedDate, Is.EqualTo(requeriedHistory.LastModifiedDate).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.LastModifiedBy.IdValue, requeriedHistory.LastModifiedBy.IdValue);

            Assert.That(history.LastImportedDateTime, Is.EqualTo(requeriedHistory.LastImportedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.LastImportedByUser.IdValue, requeriedHistory.LastImportedByUser.IdValue);

            Assert.That(history.LastSubmittedDateTime, Is.EqualTo(requeriedHistory.LastSubmittedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.LastSubmittedByUser.IdValue, requeriedHistory.LastSubmittedByUser.IdValue);

            Assert.AreEqual(history.Status, requeriedHistory.Status);

            Assert.AreEqual(history.IssuedToSuncor, requeriedHistory.IssuedToSuncor);
            Assert.AreEqual(history.IssuedToCompany, requeriedHistory.IssuedToCompany);
            Assert.AreEqual(history.Company, requeriedHistory.Company);

            Assert.AreEqual(history.Trade, requeriedHistory.Trade);
            Assert.AreEqual(history.NumberOfWorkers, requeriedHistory.NumberOfWorkers);
            Assert.AreEqual(history.RequestedByGroup, requeriedHistory.RequestedByGroup);
            Assert.AreEqual(history.WorkPermitType, requeriedHistory.WorkPermitType);
            Assert.AreEqual(history.FunctionalLocation, requeriedHistory.FunctionalLocation);
            Assert.AreEqual(history.Location, requeriedHistory.Location);
            
            Assert.AreEqual(history.DocumentLinks, requeriedHistory.DocumentLinks);

            Assert.AreEqual(history.WorkOrderNumber, requeriedHistory.WorkOrderNumber);
            Assert.AreEqual(history.OperationNumber, requeriedHistory.OperationNumber);
            Assert.AreEqual(history.SubOperationNumber, requeriedHistory.SubOperationNumber);

            Assert.That(history.RequestedStartDate, Is.EqualTo(requeriedHistory.RequestedStartDate).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.RequestedStartTimeDay, Is.EqualTo(requeriedHistory.RequestedStartTimeDay).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.RequestedStartTimeNight, Is.EqualTo(requeriedHistory.RequestedStartTimeNight).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.EndDate, Is.EqualTo(requeriedHistory.EndDate).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(history.ConfinedSpace, requeriedHistory.ConfinedSpace);
            Assert.AreEqual(history.ConfinedSpaceClass, requeriedHistory.ConfinedSpaceClass);
            Assert.AreEqual(history.RescuePlan, requeriedHistory.RescuePlan);
            Assert.AreEqual(history.ConfinedSpaceSafetyWatchChecklist, requeriedHistory.ConfinedSpaceSafetyWatchChecklist);
            Assert.AreEqual(history.SpecialWork, requeriedHistory.SpecialWork);
            Assert.AreEqual(history.SpecialWorkType, requeriedHistory.SpecialWorkType);

            Assert.AreEqual(history.HighEnergy, requeriedHistory.HighEnergy);
            Assert.AreEqual(history.CriticalLift, requeriedHistory.CriticalLift);
            Assert.AreEqual(history.Excavation, requeriedHistory.Excavation);
            Assert.AreEqual(history.EnergyControlPlan, requeriedHistory.EnergyControlPlan);
            Assert.AreEqual(history.EquivalencyProc, requeriedHistory.EquivalencyProc);
            Assert.AreEqual(history.TestPneumatic, requeriedHistory.TestPneumatic);
            Assert.AreEqual(history.LiveFlareWork, requeriedHistory.LiveFlareWork);
            Assert.AreEqual(history.EntryAndControlPlan, requeriedHistory.EntryAndControlPlan);
            Assert.AreEqual(history.EnergizedElectrical, requeriedHistory.EnergizedElectrical);

            Assert.AreEqual(history.HazardHydrocarbonGas, requeriedHistory.HazardHydrocarbonGas);
            Assert.AreEqual(history.HazardHydrocarbonLiquid, requeriedHistory.HazardHydrocarbonLiquid);
            Assert.AreEqual(history.HazardHydrogenSulphide, requeriedHistory.HazardHydrogenSulphide);
            Assert.AreEqual(history.HazardInertGasAtmosphere, requeriedHistory.HazardInertGasAtmosphere);
            Assert.AreEqual(history.HazardOxygenDeficiency, requeriedHistory.HazardOxygenDeficiency);
            Assert.AreEqual(history.HazardRadioactiveSources, requeriedHistory.HazardRadioactiveSources);
            Assert.AreEqual(history.HazardUndergroundOverheadHazards, requeriedHistory.HazardUndergroundOverheadHazards);
            Assert.AreEqual(history.HazardDesignatedSubstance, requeriedHistory.HazardDesignatedSubstance);

            Assert.AreEqual(history.OtherHazardsAndOrRequirements, requeriedHistory.OtherHazardsAndOrRequirements);

            Assert.AreEqual(history.OtherAreasAndOrUnitsAffected, requeriedHistory.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(history.OtherAreasAndOrUnitsAffectedArea, requeriedHistory.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(history.OtherAreasAndOrUnitsAffectedPersonNotified, requeriedHistory.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(history.SpecificRequirementsSectionNotApplicableToJob, requeriedHistory.SpecificRequirementsSectionNotApplicableToJob);

            Assert.AreEqual(history.AttendedAtAllTimes, requeriedHistory.AttendedAtAllTimes);
            Assert.AreEqual(history.EyeProtection, requeriedHistory.EyeProtection);
            Assert.AreEqual(history.FallProtectionEquipment, requeriedHistory.FallProtectionEquipment);
            Assert.AreEqual(history.FullBodyHarnessRetrieval, requeriedHistory.FullBodyHarnessRetrieval);
            Assert.AreEqual(history.HearingProtection, requeriedHistory.HearingProtection);
            Assert.AreEqual(history.ProtectiveClothing, requeriedHistory.ProtectiveClothing);
            Assert.AreEqual(history.Other1Checked, requeriedHistory.Other1Checked);
            Assert.AreEqual(history.Other1Value, requeriedHistory.Other1Value);

            Assert.AreEqual(history.EquipmentBondedGrounded, requeriedHistory.EquipmentBondedGrounded);
            Assert.AreEqual(history.FireBlanket, requeriedHistory.FireBlanket);
            Assert.AreEqual(history.FireFightingEquipment, requeriedHistory.FireFightingEquipment);
            Assert.AreEqual(history.FireWatch, requeriedHistory.FireWatch);
            Assert.AreEqual(history.HydrantPermit, requeriedHistory.HydrantPermit);
            Assert.AreEqual(history.WaterHose, requeriedHistory.WaterHose);
            Assert.AreEqual(history.SteamHose, requeriedHistory.SteamHose);
            Assert.AreEqual(history.Other2Checked, requeriedHistory.Other2Checked);
            Assert.AreEqual(history.Other2Value, requeriedHistory.Other2Value);

            Assert.AreEqual(history.AirMover, requeriedHistory.AirMover);
            Assert.AreEqual(history.ContinuousGasMonitor, requeriedHistory.ContinuousGasMonitor);
            Assert.AreEqual(history.DrowningProtection, requeriedHistory.DrowningProtection);
            Assert.AreEqual(history.RespiratoryProtection, requeriedHistory.RespiratoryProtection);
            Assert.AreEqual(history.Other3Checked, requeriedHistory.Other3Checked);
            Assert.AreEqual(history.Other3Value, requeriedHistory.Other3Value);

            Assert.AreEqual(history.AdditionalLighting, requeriedHistory.AdditionalLighting);
            Assert.AreEqual(history.DesignateHotOrColdCutChecked, requeriedHistory.DesignateHotOrColdCutChecked);
            Assert.AreEqual(history.DesignateHotOrColdCutValue, requeriedHistory.DesignateHotOrColdCutValue);
            Assert.AreEqual(history.HoistingEquipment, requeriedHistory.HoistingEquipment);
            Assert.AreEqual(history.Ladder, requeriedHistory.Ladder);
            Assert.AreEqual(history.MotorizedEquipment, requeriedHistory.MotorizedEquipment);
            Assert.AreEqual(history.Scaffold, requeriedHistory.Scaffold);
            Assert.AreEqual(history.ReferToTipsProcedure, requeriedHistory.ReferToTipsProcedure);

            Assert.AreEqual(history.GasDetectorBumpTested, requeriedHistory.GasDetectorBumpTested);
        }

    }
}
