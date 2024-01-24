using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class PermitRequestEdmontonSAPImportDataDaoTest : AbstractDaoTest
    {
        private IPermitRequestEdmontonSAPImportDataDao dao;
        private IWorkPermitEdmontonGroupDao groupDao;        

        private FunctionalLocation flocForTesting;        
        private WorkPermitEdmontonGroup group;

        private readonly User sapUser = UserFixture.CreateSAPUser();

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestEdmontonSAPImportDataDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();

            flocForTesting = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            group = groupDao.Insert(new WorkPermitEdmontonGroup(99, "Some Group asdfa", new List<long> { 1 }, 0, false));
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            PermitRequestEdmontonSAPImportData importItem = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(flocForTesting, @group, sapUser);

            PermitRequestEdmontonSAPImportData resultFromInsert = dao.Insert(importItem);
            Assert.IsNotNull(resultFromInsert.Id);

            PermitRequestEdmontonSAPImportData retrievedValue = dao.QueryByWorkOrderInformation(importItem.WorkOrderNumber, importItem.OperationNumber, importItem.SubOperationNumber);
            Assert.IsNotNull(retrievedValue);

            Assert.AreEqual(importItem.BatchId, retrievedValue.BatchId);
            Assert.That(importItem.BatchItemCreatedAt, Is.EqualTo(retrievedValue.BatchItemCreatedAt).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(importItem.WorkOrderNumber, retrievedValue.WorkOrderNumber);
            Assert.AreEqual(importItem.OperationNumber, retrievedValue.OperationNumber);
            Assert.AreEqual(importItem.SubOperationNumber, retrievedValue.SubOperationNumber);
            Assert.AreEqual(importItem.EndDate, retrievedValue.EndDate);

            Assert.AreEqual(importItem.Description, retrievedValue.Description);
            Assert.AreEqual(importItem.Company, retrievedValue.Company);
            Assert.AreEqual(importItem.Occupation, retrievedValue.Occupation);
            Assert.AreEqual(importItem.NumberOfWorkers, retrievedValue.NumberOfWorkers);
            Assert.AreEqual(importItem.WorkPermitType, retrievedValue.WorkPermitType);
            Assert.AreEqual(importItem.AreaLabel, retrievedValue.AreaLabel);

            Assert.AreEqual(importItem.FunctionalLocation, retrievedValue.FunctionalLocation);
            Assert.AreEqual(importItem.Location, retrievedValue.Location);
            Assert.AreEqual(importItem.SpecialWorkType, retrievedValue.SpecialWorkType);
            Assert.AreEqual(importItem.RequestedStartDate, retrievedValue.RequestedStartDate);

            Assert.AreEqual(importItem.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob, retrievedValue.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            Assert.AreEqual(importItem.FaceShield, retrievedValue.FaceShield);
            Assert.AreEqual(importItem.Goggles, retrievedValue.Goggles);
            Assert.AreEqual(importItem.RubberBoots, retrievedValue.RubberBoots);
            Assert.AreEqual(importItem.RubberGloves, retrievedValue.RubberGloves);
            Assert.AreEqual(importItem.RubberSuit, retrievedValue.RubberSuit);

            Assert.AreEqual(importItem.SafetyHarnessLifeline, retrievedValue.SafetyHarnessLifeline);
            Assert.AreEqual(importItem.HighVoltagePPE, retrievedValue.HighVoltagePPE);
            Assert.AreEqual(importItem.EquipmentGrounded, retrievedValue.EquipmentGrounded);
            Assert.AreEqual(importItem.FireBlanket, retrievedValue.FireBlanket);
            Assert.AreEqual(importItem.FireExtinguisher, retrievedValue.FireExtinguisher);

            Assert.AreEqual(importItem.FireMonitorManned, retrievedValue.FireMonitorManned);
            Assert.AreEqual(importItem.FireWatch, retrievedValue.FireWatch);
            Assert.AreEqual(importItem.SewersDrainsCovered, retrievedValue.SewersDrainsCovered);
            Assert.AreEqual(importItem.SteamHose, retrievedValue.SteamHose);
            Assert.AreEqual(importItem.AirPurifyingRespirator, retrievedValue.AirPurifyingRespirator);

            Assert.AreEqual(importItem.BreathingAirApparatus, retrievedValue.BreathingAirApparatus);
            Assert.AreEqual(importItem.DustMask, retrievedValue.DustMask);
            Assert.AreEqual(importItem.LifeSupportSystem, retrievedValue.LifeSupportSystem);
            Assert.AreEqual(importItem.SafetyWatch, retrievedValue.SafetyWatch);
            Assert.AreEqual(importItem.ContinuousGasMonitor, retrievedValue.ContinuousGasMonitor);

            Assert.AreEqual(importItem.BumpTestMonitorPriorToUse, retrievedValue.BumpTestMonitorPriorToUse);
            Assert.AreEqual(importItem.AirMover, retrievedValue.AirMover);
            Assert.AreEqual(importItem.BarriersSigns, retrievedValue.BarriersSigns);
            Assert.AreEqual(importItem.AirHorn, retrievedValue.AirHorn);
            Assert.AreEqual(importItem.MechVentilationComfortOnly, retrievedValue.MechVentilationComfortOnly);

            Assert.AreEqual(importItem.AsbestosMMCPrecautions, retrievedValue.AsbestosMMCPrecautions);
            Assert.AreEqual(importItem.Group, retrievedValue.Group);

            Assert.AreEqual(importItem.AlkylationEntry, retrievedValue.AlkylationEntry);
            Assert.AreEqual(importItem.FlarePitEntry, retrievedValue.FlarePitEntry);

            Assert.AreEqual(importItem.ConfinedSpace, retrievedValue.ConfinedSpace);
            Assert.AreEqual(importItem.ConfinedSpaceClass, retrievedValue.ConfinedSpaceClass);


            Assert.AreEqual(importItem.RescuePlan, retrievedValue.RescuePlan);
            Assert.AreEqual(importItem.VehicleEntry, retrievedValue.VehicleEntry);
            Assert.AreEqual(importItem.SpecialWork, retrievedValue.SpecialWork);

            Assert.AreEqual(importItem.GN59, retrievedValue.GN59);
            Assert.AreEqual(importItem.GN7, retrievedValue.GN7);
            Assert.AreEqual(importItem.GN24, retrievedValue.GN24);
            Assert.AreEqual(importItem.GN6, retrievedValue.GN6);
            Assert.AreEqual(importItem.GN11, retrievedValue.GN11);
            Assert.AreEqual(importItem.GN27, retrievedValue.GN27);
            Assert.AreEqual(importItem.GN75A, retrievedValue.GN75A);

            Assert.AreEqual(importItem.GN75_Deprecated, retrievedValue.GN75_Deprecated);

            Assert.AreEqual(importItem.WorkersMonitorNumber, retrievedValue.WorkersMonitorNumber);
            Assert.AreEqual(importItem.RadioChannelNumber, retrievedValue.RadioChannelNumber);
            Assert.AreEqual(importItem.RadioChannel, retrievedValue.RadioChannel);
            Assert.AreEqual(importItem.WorkersMonitor, retrievedValue.WorkersMonitor);
            Assert.AreEqual(importItem.SAPWorkCentre, retrievedValue.SAPWorkCentre);

            Assert.AreEqual(importItem.DoNotMerge, retrievedValue.DoNotMerge);
        }

        [Ignore] [Test]
        public void ShouldDeleteByBatchId()
        {
            long batchId = dao.GetBatchId();

            PermitRequestEdmontonSAPImportData importItem = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(batchId, flocForTesting, group, sapUser);
            importItem.WorkOrderNumber = "3332";
            importItem.OperationNumber = "31";
            importItem.SubOperationNumber = "32";
            dao.Insert(importItem);

            PermitRequestEdmontonSAPImportData retrievedValue = dao.QueryByWorkOrderInformation(importItem.WorkOrderNumber, importItem.OperationNumber, importItem.SubOperationNumber);
            Assert.IsNotNull(retrievedValue);

            dao.Delete(batchId);

            retrievedValue = dao.QueryByWorkOrderInformation(importItem.WorkOrderNumber, importItem.OperationNumber, importItem.SubOperationNumber);
            Assert.IsNull(retrievedValue);
        }

        [Ignore] [Test]
        public void ShouldGetBatchId()
        {
            long batchId = dao.GetBatchId();
            long batchIdTwo = dao.GetBatchId();
            long batchIdThree = dao.GetBatchId();

            Assert.AreEqual(batchId + 1, batchIdTwo);
            Assert.AreEqual(batchIdTwo + 1, batchIdThree);
        }

        [Ignore] [Test]
        public void ShouldQueryByBatchId()
        {
            User someUser = UserFixture.CreateSupervisor();

            long batchId = dao.GetBatchId();
            long otherBatchId = dao.GetBatchId();

            PermitRequestEdmontonSAPImportData item1 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(batchId, flocForTesting, group, someUser);
            dao.Insert(item1);

            PermitRequestEdmontonSAPImportData item2 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(batchId, flocForTesting, group, someUser);
            dao.Insert(item2);
            
            PermitRequestEdmontonSAPImportData item3 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(otherBatchId, flocForTesting, group, someUser);
            dao.Insert(item3);

            List<PermitRequestEdmontonSAPImportData> results = dao.QueryByBatchId(batchId);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Exists(data => data.Id == item1.Id));
            Assert.IsTrue(results.Exists(data => data.Id == item2.Id));
        }
    }
}
