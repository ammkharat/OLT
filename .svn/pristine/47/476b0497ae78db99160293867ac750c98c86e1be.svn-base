using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ActionItemDefinitionTest
    {
        private ActionItemDefinition actionItemDefinition;

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof(ActionItemDefinition).IsSerializable);
        }

        [Test]
        public void ShouldBeEqualWhenCompareSameFixturesAlthoughTheyAreDifferentObject()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            ActionItemDefinition definition1 = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId(now);
            ActionItemDefinition definition2 = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId(now);
            // Name is randomized in the fixture, so in order for this test to work All the time,
            // the names have to be forced to be the same:
            definition2.Name = definition1.Name;
            Assert.AreEqual(definition1, definition2);
        }

        [Test]
        public void ShouldNotBeEqualWhenCompareDifferentFixture()
        {
            Assert.AreNotEqual(ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId(), ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(1));
        }

        [Test]
        public void ApprovedTextShouldReturnNoWhenStatusIsPending()
        {
            actionItemDefinition = ActionItemDefinitionFixture.CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(1);
            Assert.AreEqual("No", actionItemDefinition.ApprovedText);
        }

        [Test]
        public void ApprovedTextShouldReturnYesWhenStatusIsApproved()
        {
            actionItemDefinition = ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(2);
            Assert.AreEqual("Yes", actionItemDefinition.ApprovedText);
        }

        #region New Status, Current Status and RequiresApproval inter-dependency test

        private static void ChangeStatusOnRequiresApprovalChanged(ActionItemDefinitionStatus currentStatus, bool requiresApproval, ActionItemDefinitionStatus expectedStatus)
        {
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.Status = currentStatus;
            aid.RequiresApproval = requiresApproval;
            aid.Status = ActionItemDefinitionStatus.GetStatusBasedOnRequiresApproval(requiresApproval);
            Assert.AreEqual(expectedStatus, aid.Status);
        }

        [Test]
        public void ShouldChangeToPendingRegardlessOfPriorStatusWhenRequiresApprovalIsTrue()
        {
            foreach(ActionItemDefinitionStatus status in ActionItemDefinitionStatus.All)
            {
                ChangeStatusOnRequiresApprovalChanged(status, true, ActionItemDefinitionStatus.Pending);
            }
        }

        [Test]
        public void ShouldChangeToApprovedWhenRequiresApprovalIsFalseRegardlessOfPriorStatus()
        {
            foreach(ActionItemDefinitionStatus currentStatus in ActionItemDefinitionStatus.All)
            {
                ChangeStatusOnRequiresApprovalChanged(currentStatus, false, ActionItemDefinitionStatus.Approved);
            }
        }

        #endregion

        [Test]
        public void ShouldSetFalseToRequireApprovalAndTrueToActiveAfterApproving()
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Approved;
            const bool expectedRequireApproval = false;
            const bool expectedActive = true;
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.Approve(aid.LastModifiedBy, aid.LastModifiedDate);
            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);
            Assert.AreEqual(expectedActive, aid.Active);
        }

        [Test]
        public void ShouldSetLastModifiedByAndDateAfterApproving()
        {
            User expectedLastModidifedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            DateTime expectedLastModifiedDate = DateTimeFixture.DateTimeNow;
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.LastModifiedBy = null;
            aid.LastModifiedDate = new DateTime();
            aid.Approve(expectedLastModidifedBy, expectedLastModifiedDate);
            Assert.AreEqual(expectedLastModidifedBy, aid.LastModifiedBy);
            Assert.AreEqual(expectedLastModifiedDate, aid.LastModifiedDate);
        }

        [Test]
        public void ShouldSetTrueToRequireApprovalAndFalseToActiveWhenWaitingForApproval()
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Pending;
            const bool expectedRequireApproval = true;
            const bool expectedActive = false;
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.WaitForApproval();
            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);
            Assert.AreEqual(expectedActive, aid.Active);
        }

        [Test]
        public void ShouldSetTrueToRequireApprovalAndFalseToActiveAfterRejecting()
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Rejected;
            const bool expectedRequireApproval = true;
            const bool expectedActive = false;
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.Reject(aid.LastModifiedBy, aid.LastModifiedDate);
            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);
            Assert.AreEqual(expectedActive, aid.Active);
        }

        [Test]
        public void ShouldSetLastModifiedByAndDateAfterRejecting()
        {
            User expectedLastModidifedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            DateTime expectedLastModifiedDate = DateTimeFixture.DateTimeNow;
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aid.LastModifiedBy = null;
            aid.LastModifiedDate = new DateTime();
            aid.Reject(expectedLastModidifedBy, expectedLastModifiedDate);
            Assert.AreEqual(expectedLastModidifedBy, aid.LastModifiedBy);
            Assert.AreEqual(expectedLastModifiedDate, aid.LastModifiedDate);
        }

        [Test]
        public void ShouldTakActionItemDefinitionSnapShot()
        {
            ActionItemDefinition aid = ActionItemDefinitionFixture.CreateActionItemDefinition();
            ActionItemDefinitionHistory aidHistory = aid.TakeSnapshot();

            Assert.AreEqual(aid.Id, aidHistory.Id);
            Assert.AreEqual(aid.Name, aidHistory.Name);
            Assert.AreEqual(aid.Category, aidHistory.Category);
            Assert.AreEqual(aid.Status, aidHistory.Status);
            Assert.AreEqual(aid.Schedule.ToString(), aidHistory.Schedule);
            Assert.AreEqual(aid.Description, aidHistory.Description);
            Assert.AreEqual(aid.Source, aidHistory.Source);
            Assert.AreEqual(aid.ResponseRequired, aidHistory.ResponseRequired);
            Assert.AreEqual(aid.RequiresApproval, aidHistory.RequiresApproval);
            Assert.AreEqual(aid.Active, aidHistory.Active);
            Assert.AreEqual(aid.LastModifiedBy, aidHistory.LastModifiedBy);
            Assert.AreEqual(aid.LastModifiedDate, aidHistory.LastModifiedDate);

            Assert.AreEqual(aid.FunctionalLocations.AsString(floc => floc.FullHierarchy), aidHistory.FunctionalLocations);
            Assert.AreEqual(aid.TargetDefinitionDTOs.AsString(tdDto => tdDto.Name), aidHistory.TargetDefinitions);
            Assert.AreEqual(aid.DocumentLinks.AsString(link => link.TitleWithUrl), aidHistory.DocumentLinks);
            Assert.AreEqual(aid.OperationalMode, aidHistory.OperationalMode);
            Assert.AreEqual(aid.Priority, aidHistory.Priority);
            
        }
    }
}