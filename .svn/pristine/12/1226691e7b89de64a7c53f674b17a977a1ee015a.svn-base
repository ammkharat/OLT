using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class SnapshotToChangeSetConverterTest
    {

        [Test]
        public void GetActionItemDefintionChangeSetsShouldRetrieveSnapshotsAndConvertThemToChangeSetsWhereTheChangeSetDifferencesCorrectlyReflectTheDifferencesBetweenEachAdjacentSnapshot()
        {
            List<ActionItemDefinitionHistory> histories = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistories();
            List<DomainObjectChangeSet> changeSets = histories.ConvertToChangeSet();
            Assert.AreEqual(3, changeSets.Count);
            
            Assert.AreEqual(1, changeSets[1].PropertyChanges.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(ActionItemDefinitionHistory), "Description", string.Empty, "description", "descriptionChanged"), changeSets[1].PropertyChanges[0]);

            Assert.AreEqual(1, changeSets[2].PropertyChanges.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(ActionItemDefinitionHistory), "Status", string.Empty, ActionItemDefinitionStatus.Pending, ActionItemDefinitionStatus.Approved), changeSets[2].PropertyChanges[0]);

        }

        [Test]
        public void GetTargetDefinitionChangeSetsShouldRetrieveSnapshotsAndConvertThemToChangeSetsWhereTheChangeSetDifferencesCorrectlyReflectTheDifferencesBetweenEachAdjacentSnapshot()
        {
            List<TargetDefinitionHistory> histories = TargetDefinitionHistoryFixture.CreateTargetDefinitionHistories();
            List<DomainObjectChangeSet> changeSets = histories.ConvertToChangeSet();
         
            Assert.AreEqual(1, changeSets[1].PropertyChanges.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(TargetDefinitionHistory), "Description", string.Empty, "description", "descriptionChanged"), changeSets[1].PropertyChanges[0]);
            
            Assert.AreEqual(1, changeSets[2].PropertyChanges.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(TargetDefinitionHistory), "MaxValue", string.Empty, (decimal)70, (decimal)120), changeSets[2].PropertyChanges[0]);
        }
        
        [Test]
        public void GetActionItemDefintionChangeSetsShouldRetrieveSnapshotsAndConvertThemToChangeSetsWhereTheUserAndDateMatchTheSnapshots()
        {
            List<ActionItemDefinitionHistory> histories = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistories();
            List<DomainObjectChangeSet> changeSets = histories.ConvertToChangeSet();
            Assert.AreEqual(histories.Count, changeSets.Count);
            Assert.AreEqual(histories[2].LastModifiedDate, changeSets[2].ChangeDateTime);
            Assert.AreEqual(histories[2].LastModifiedBy.FullNameWithUserName, changeSets[2].UserName);
        }

        [Test]
        public void GetActionItemDefintionChangeSetsShouldRetrieveSnapshotsAndConvertThemToChangeSetsWhereTheFirstChangeSetShouldHaveActionSetToCreatedAndAnEmptyListOfFieldChanges()
        {
            List<ActionItemDefinitionHistory> histories = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistories();
            List<DomainObjectChangeSet> changeSets = histories.ConvertToChangeSet();
            AssertChangeSetForCreation(changeSets[0]);
        }


        [Test]
        public void OneGasTestElementInfoConfigurationHistoryReturnsOneChangeSetWithNoChanges()
        {
            GasTestElementInfoConfigurationHistoryList snapshot = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistoryList;
            var snapshots =
                new List<GasTestElementInfoConfigurationHistoryList> {snapshot};
            List<DomainObjectChangeSet> changeSets = snapshots.ConvertGasTestElementInfoConfigurationHistories();
            AssertChangeSetForCreation(changeSets[0]);
        }

        private static void AssertChangeSetForCreation(DomainObjectChangeSet changeSet)
        {
            Assert.AreEqual(0, changeSet.PropertyChanges.Count);
        }

        [Test]
        public void TwoGasTestElementInfoConfigurationHistoriesShouldReturnTwoChangeSetsWhereTheUserAndDateMatchTheSnapshots()
        {
            var histories =
                new List<GasTestElementInfoConfigurationHistoryList>();

            GasTestElementInfoConfigurationHistoryList snapshot1 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistoryList;
            histories.Add(snapshot1);
            GasTestElementInfoConfigurationHistoryList snapshot2 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistoryList;
            snapshot2[0].CSELimit = "75.0-100.0";
            histories.Add(snapshot2);
            
            List<DomainObjectChangeSet> changeSets = histories.ConvertGasTestElementInfoConfigurationHistories();
            
            Assert.AreEqual(2, changeSets.Count); // 1 create + 1 update
            Assert.AreEqual(histories[1][0].LastModifiedDate, changeSets[1].ChangeDateTime);
            Assert.AreEqual(histories[1][0].LastModifiedBy.FullNameWithUserName, changeSets[1].UserName);
            Assert.AreEqual(1, changeSets[1].PropertyChanges.Count);
        }
        
        [Test]
        public void GetGasTestElementInfoConfigurationHistoryChangeSetsShouldRetrieveSnapshotsAndConvertThemToChangeSetsWhereTheChangeSetDifferencesCorrectlyReflectTheDifferencesBetweenEachAdjacentSnapshot()
        {
            var snapshots =
                new List<GasTestElementInfoConfigurationHistoryList>();
            
            GasTestElementInfoConfigurationHistoryList snapshot1 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistoryList;
            snapshots.Add(snapshot1);
            GasTestElementInfoConfigurationHistoryList snapshot2 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistoryList;
            const string newCseLimit = "75.0-100.0";
            snapshot2[0].CSELimit = newCseLimit;
            const string newHotLimit = "33.00";
            snapshot2[1].HotLimit = newHotLimit;
            snapshots.Add(snapshot2);

            List<DomainObjectChangeSet> changeSets = snapshots.ConvertGasTestElementInfoConfigurationHistories();

            Assert.AreEqual(2, changeSets.Count); // 1 create + 1 update
            
            Assert.AreEqual(2, changeSets[1].PropertyChanges.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(GasTestElementInfoConfigurationHistory), "CSELimit", "Oxygen", "0.0-200.0", newCseLimit), changeSets[1].PropertyChanges[0]);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(GasTestElementInfoConfigurationHistory), "HotLimit", "LEL", "100.00", newHotLimit), changeSets[1].PropertyChanges[1]);
        }
    }
}