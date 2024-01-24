using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class PermitRequestEdmontonHistoryDaoTest : AbstractDaoTest
    {
        private IPermitRequestEdmontonHistoryDao dao;
        private IWorkPermitEdmontonGroupDao groupDao;
        private IFormGN1Dao formGN1Dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestEdmontonHistoryDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();            
        }

        protected override void Cleanup()
        {

        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());

            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), group);
            request.Id = 1234;
            request.CompletionStatus = PermitRequestCompletionStatus.Complete;
           
            PermitRequestEdmontonHistory original = request.TakeSnapshot();
            original.GN1 = true;
            original.FormGN1TradeChecklistDisplayNumber = "ABC123";

            dao.Insert(original);

            List<PermitRequestEdmontonHistory> histories = dao.GetById(original.IdValue);
            Assert.AreEqual(1, histories.Count);

            PermitRequestEdmontonHistory requeried = histories[0];

            Assert.AreEqual(original.EndDate, requeried.EndDate);
            Assert.AreEqual(original.WorkOrderNumber, requeried.WorkOrderNumber);
            Assert.AreEqual(original.OperationNumber, requeried.OperationNumber);
            Assert.AreEqual(original.SubOperationNumber, requeried.SubOperationNumber);

            Assert.AreEqual(original.Description, requeried.Description);
            Assert.AreEqual(original.Company, requeried.Company);
            Assert.AreEqual(original.SubOperationNumber, requeried.SubOperationNumber);

            Assert.AreEqual(original.LastImportedByUser.IdValue, requeried.LastImportedByUser.IdValue);
            Assert.AreEqual(original.LastImportedDateTime, requeried.LastImportedDateTime);
            Assert.AreEqual(original.LastSubmittedByUser.IdValue, requeried.LastSubmittedByUser.IdValue);

            Assert.AreEqual(original.LastSubmittedDateTime, requeried.LastSubmittedDateTime);
            Assert.AreEqual(original.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.AreEqual(original.LastModifiedDate, requeried.LastModifiedDate);

            Assert.AreEqual(original.IssuedToSuncor, requeried.IssuedToSuncor);
            Assert.AreEqual(original.Occupation, requeried.Occupation);
            Assert.AreEqual(original.NumberOfWorkers, requeried.NumberOfWorkers);
            Assert.AreEqual(original.WorkPermitType, requeried.WorkPermitType);            
            Assert.AreEqual(original.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(original.Location, requeried.Location);
            Assert.AreEqual(original.AreaLabel, requeried.AreaLabel);

            Assert.AreEqual(original.AlkylationEntryClassOfClothing, requeried.AlkylationEntryClassOfClothing);
            Assert.AreEqual(original.FlarePitEntryType, requeried.FlarePitEntryType);
            Assert.AreEqual(original.ConfinedSpaceCardNumber, requeried.ConfinedSpaceCardNumber);
            Assert.AreEqual(original.ConfinedSpaceClass, requeried.ConfinedSpaceClass);
            Assert.AreEqual(original.RescuePlanFormNumber, requeried.RescuePlanFormNumber);
            Assert.AreEqual(original.VehicleEntryTotal, requeried.VehicleEntryTotal);
            Assert.AreEqual(original.VehicleEntryType, requeried.VehicleEntryType);
            Assert.AreEqual(original.SpecialWorkFormNumber, requeried.SpecialWorkFormNumber);
            //Assert.AreEqual(original.SpecialWorkType, requeried.SpecialWorkType);
            Assert.AreEqual(original.SpecialWorkName, requeried.SpecialWorkType);

            Assert.AreEqual(original.AlkylationEntry, requeried.AlkylationEntry);
            Assert.AreEqual(original.FlarePitEntry, requeried.FlarePitEntry);
            Assert.AreEqual(original.ConfinedSpace, requeried.ConfinedSpace);

            Assert.AreEqual(original.RescuePlan, requeried.RescuePlan);
            Assert.AreEqual(original.VehicleEntry, requeried.VehicleEntry);
            Assert.AreEqual(original.SpecialWork, requeried.SpecialWork);

            Assert.AreEqual(original.FormGN59Id, requeried.FormGN59Id);
            Assert.AreEqual(original.FormGN7Id, requeried.FormGN7Id);

            Assert.AreEqual(original.GN6, requeried.GN6);
            Assert.AreEqual(original.GN11, requeried.GN11);
            Assert.AreEqual(original.GN24_Deprecated, requeried.GN24_Deprecated);

            Assert.AreEqual(original.GN27, requeried.GN27);
            Assert.AreEqual(original.GN75_Deprecated, requeried.GN75_Deprecated);
            Assert.AreEqual(original.FormGN75AId, requeried.FormGN75AId);

            Assert.AreEqual(original.GN1, requeried.GN1);
            Assert.AreEqual(original.FormGN1TradeChecklistDisplayNumber, requeried.FormGN1TradeChecklistDisplayNumber);

            Assert.AreEqual(original.RequestedStartDate, requeried.RequestedStartDate);
            Assert.AreEqual(original.RequestedStartTimeDay, requeried.RequestedStartTimeDay);
            Assert.AreEqual(original.RequestedStartTimeNight, requeried.RequestedStartTimeNight);
            Assert.AreEqual(original.HazardsAndOrRequirements, requeried.HazardsAndOrRequirements);
            Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedArea, requeried.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(original.OtherAreasAndOrUnitsAffectedPersonNotified, requeried.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(original.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob, requeried.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            Assert.AreEqual(original.FaceShield, requeried.FaceShield);
            Assert.AreEqual(original.Goggles, requeried.Goggles);
            Assert.AreEqual(original.RubberBoots, requeried.RubberBoots);
            Assert.AreEqual(original.RubberGloves, requeried.RubberGloves);
            Assert.AreEqual(original.RubberSuit, requeried.RubberSuit);
            Assert.AreEqual(original.SafetyHarnessLifeline, requeried.SafetyHarnessLifeline);
            Assert.AreEqual(original.HighVoltagePPE, requeried.HighVoltagePPE);
            Assert.AreEqual(original.Other1, requeried.Other1);

            Assert.AreEqual(original.EquipmentGrounded, requeried.EquipmentGrounded);
            Assert.AreEqual(original.FireBlanket, requeried.FireBlanket);
            Assert.AreEqual(original.FireExtinguisher, requeried.FireExtinguisher);
            Assert.AreEqual(original.FireMonitorManned, requeried.FireMonitorManned);
            Assert.AreEqual(original.FireWatch, requeried.FireWatch);
            Assert.AreEqual(original.SewersDrainsCovered, requeried.SewersDrainsCovered);
            Assert.AreEqual(original.SteamHose, requeried.SteamHose);
            Assert.AreEqual(original.Other2, requeried.Other2);

            Assert.AreEqual(original.AirPurifyingRespirator, requeried.AirPurifyingRespirator);
            Assert.AreEqual(original.BreathingAirApparatus, requeried.BreathingAirApparatus);
            Assert.AreEqual(original.DustMask, requeried.DustMask);
            Assert.AreEqual(original.LifeSupportSystem, requeried.LifeSupportSystem);
            Assert.AreEqual(original.SafetyWatch, requeried.SafetyWatch);
            Assert.AreEqual(original.ContinuousGasMonitor, requeried.ContinuousGasMonitor);
            Assert.AreEqual(original.WorkersMonitorNumber, requeried.WorkersMonitorNumber);
            Assert.AreEqual(original.BumpTestMonitorPriorToUse, requeried.BumpTestMonitorPriorToUse);
            Assert.AreEqual(original.Other3, requeried.Other3);

            Assert.AreEqual(original.AirMover, requeried.AirMover);
            Assert.AreEqual(original.BarriersSigns, requeried.BarriersSigns);
            Assert.AreEqual(original.RadioChannelNumber, requeried.RadioChannelNumber);
            Assert.AreEqual(original.AirHorn, requeried.AirHorn);
            Assert.AreEqual(original.MechVentilationComfortOnly, requeried.MechVentilationComfortOnly);
            Assert.AreEqual(original.AsbestosMMCPrecautions, requeried.AsbestosMMCPrecautions);
            Assert.AreEqual(original.Other4, requeried.Other4);

            Assert.AreEqual(StringResources.PermitRequestCompletionStatus_Complete, requeried.Status);
            Assert.AreEqual(original.DocumentLinks, requeried.DocumentLinks);
            Assert.AreEqual(original.Priority, requeried.Priority);
        }

    }
}
