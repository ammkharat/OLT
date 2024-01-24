using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class WorkPermitHistoryDaoTest : AbstractDaoTest
    {
        const long fakeIdForTest = 1337;
        private IWorkPermitHistoryDao workPermitHistoryDao;
        private IUserDao userDao;

        protected override void TestInitialize()
        {
            workPermitHistoryDao = DaoRegistry.GetDao<IWorkPermitHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void GetWorkPermitHistoriesByIdShouldReturnMoreThanOneHistoryObject()
        {
            Assert.IsTrue(workPermitHistoryDao.GetById(1).Count > 1);
        }

        [Ignore] [Test]
        public void ShouldInsertAWorkPermitHistoryEntry()
        {
            WorkPermit workPermitWithRadiationInformationSetWithNoId = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID(new DateTime(2006, 07, 04, 15, 51, 00), new DateTime(2006, 07, 05, 15, 51, 00));
            workPermitWithRadiationInformationSetWithNoId.Specifics.WorkAssignment =
                    WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            var snapshotTaker =
                    new WorkPermitSnapshotTaker(workPermitWithRadiationInformationSetWithNoId);
            WorkPermitHistory workPermitHistory = snapshotTaker.CreateWorkPermitHistorySnapshot();
            workPermitHistory.Id = fakeIdForTest;
            workPermitHistory.LastModifiedBy = userDao.QueryById(1);
            workPermitHistoryDao.Insert(workPermitHistory);
            List<WorkPermitHistory> queriedWorkPermitHistories = workPermitHistoryDao.GetById(fakeIdForTest);
            WorkPermitHistory queriedWorkPermitHistory = queriedWorkPermitHistories[queriedWorkPermitHistories.Count - 1];
          
            Assert.AreEqual(workPermitHistory, queriedWorkPermitHistory);
        }

        [Ignore] [Test]
        public void ShouldInsertAWorkPermitHistoryEntry_NullWorkAssignment()
        {
            WorkPermit workPermitWithRadiationInformationSetWithNoId = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID(new DateTime(2006, 07, 04, 15, 51, 00), new DateTime(2006, 07, 05, 15, 51, 00));
            workPermitWithRadiationInformationSetWithNoId.Specifics.WorkAssignment = null;

            var snapshotTaker =
                    new WorkPermitSnapshotTaker(workPermitWithRadiationInformationSetWithNoId);
            WorkPermitHistory workPermitHistory = snapshotTaker.CreateWorkPermitHistorySnapshot();
            workPermitHistory.Id = fakeIdForTest;
            workPermitHistory.LastModifiedBy = userDao.QueryById(1);
            workPermitHistoryDao.Insert(workPermitHistory);
            List<WorkPermitHistory> queriedWorkPermitHistories = workPermitHistoryDao.GetById(fakeIdForTest);
            WorkPermitHistory queriedWorkPermitHistory = queriedWorkPermitHistories[queriedWorkPermitHistories.Count - 1];
            Assert.AreEqual(workPermitHistory, queriedWorkPermitHistory);
        }

        [Ignore] [Test]
        public void InsertShouldPersistEndTimeFinalizedFlag()
        {
            workPermitHistoryDao.Insert(CreateHistoryWithEndTimeFinalized(fakeIdForTest, true, "A1"));
            workPermitHistoryDao.Insert(CreateHistoryWithEndTimeFinalized(fakeIdForTest, false, "B2"));

            List<WorkPermitHistory> histories = workPermitHistoryDao.GetById(fakeIdForTest);
            Assert.AreEqual(2, histories.Count);

            histories.Sort(h => h.PermitNumber, true);
            Assert.IsTrue(histories[0].StartAndOrEndTimesFinalized);
            Assert.IsFalse(histories[1].StartAndOrEndTimesFinalized);
        }


        [Ignore] [Test]
        public void ShouldInsertAndRetrieveEnergyIsolationFields()
        {
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable = true;
                workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = false;
                workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER;
                workPermit.EquipmentPreparationCondition.LockOutMethodComments = "abc";
                workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = "123";
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = true;
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = "mno";

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 1";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsTrue(requeried.IsHazardousEnergyIsolationRequiredNotApplicable);
                    Assert.IsFalse(requeried.IsHazardousEnergyIsolationRequired.Value);
                    Assert.AreEqual(WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER, requeried.EquipmentLockOutMethod);
                    Assert.AreEqual("abc", requeried.EquipmentLockOutMethodComments);
                    Assert.AreEqual("123", requeried.EnergyIsolationPlanNumber);
                    Assert.IsTrue(requeried.ConditionsOfEIPSatisfied.Value);
                    Assert.AreEqual("mno", requeried.ConditionsOfEIPNotSatisfiedComments);
                }
            }
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable = true;
                workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = false;
                workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS;
                workPermit.EquipmentPreparationCondition.LockOutMethodComments = "def";
                workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = "456";
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = true;
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = "pqr";

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 2";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsTrue(requeried.IsHazardousEnergyIsolationRequiredNotApplicable);
                    Assert.IsFalse(requeried.IsHazardousEnergyIsolationRequired.Value);
                    Assert.AreEqual(WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS, requeried.EquipmentLockOutMethod);
                    Assert.AreEqual("def", requeried.EquipmentLockOutMethodComments);
                    Assert.AreEqual("456", requeried.EnergyIsolationPlanNumber);
                    Assert.IsTrue(requeried.ConditionsOfEIPSatisfied.Value);
                    Assert.AreEqual("pqr", requeried.ConditionsOfEIPNotSatisfiedComments);
                }
            }
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.COMPLEX_GROUP;

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 3";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.AreEqual(WorkPermitLockOutMethodType.COMPLEX_GROUP, requeried.EquipmentLockOutMethod);
                }
            }
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = null;
                workPermit.EquipmentPreparationCondition.LockOutMethod = null;
                workPermit.EquipmentPreparationCondition.LockOutMethodComments = null;
                workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = null;
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = null;
                workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = null;

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 4";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsNull(requeried.IsHazardousEnergyIsolationRequired);
                    Assert.IsNull(requeried.EquipmentLockOutMethod);
                    Assert.AreEqual(null, requeried.EquipmentLockOutMethodComments);
                    Assert.AreEqual(null, requeried.EnergyIsolationPlanNumber);
                    Assert.IsNull(requeried.ConditionsOfEIPSatisfied);
                    Assert.IsNull(requeried.ConditionsOfEIPNotSatisfiedComments);
                }
            }
        }


        [Ignore] [Test]
        public void ShouldInsertAndRetrieveAsbestosFields()
        {
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.Asbestos.HazardsConsideredNotApplicable = true;
                workPermit.Asbestos.HazardsConsidered = false;

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 1";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsTrue(requeried.AsbestosHazardsConsideredNotApplicable);
                    Assert.IsFalse(requeried.AsbestosHazardsConsidered.Value);
                }
            }
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.Asbestos.HazardsConsideredNotApplicable = false;
                workPermit.Asbestos.HazardsConsidered = true;

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 2";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsFalse(requeried.AsbestosHazardsConsideredNotApplicable);
                    Assert.IsTrue(requeried.AsbestosHazardsConsidered.Value);
                }

            }
            {
                WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.Asbestos.HazardsConsidered = null;

                WorkPermitHistory history = new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot();
                history.Id = fakeIdForTest;
                history.PermitNumber = "find this one again 3";
                workPermitHistoryDao.Insert(history);

                {
                    List<WorkPermitHistory> results = workPermitHistoryDao.GetById(history.IdValue);
                    WorkPermitHistory requeried = results.Find(obj => obj.PermitNumber == history.PermitNumber);
                    Assert.IsNull(requeried.AsbestosHazardsConsidered);
                }
            }
        }

        private static WorkPermitHistory CreateHistoryWithEndTimeFinalized(long id, bool endTimeFinalized, string permitNumber)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.Id = id;
            permit.PermitNumber = permitNumber;
            permit.StartAndOrEndTimesFinalized = endTimeFinalized;
            return new WorkPermitSnapshotTaker(permit).CreateWorkPermitHistorySnapshot();
        }
    }
}