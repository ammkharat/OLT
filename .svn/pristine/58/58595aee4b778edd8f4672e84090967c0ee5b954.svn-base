using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ActionItemDefinitionUpdateStatusAfterChangesTest
    {
        private delegate void AssertStatusState(ActionItemDefinition aid, bool activeBeforeStatusChange);

        ActionItemDefinition approvedAID;
        ActionItemDefinition pendingAID;
        ActionItemDefinition rejectedAID;

        ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig;
        ActionItemDefinitionAutoReApprovalConfiguration noneSelectedReApprovalConfig;

        [SetUp]
        public void SetUp()
        {
            approvedAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            approvedAID.Approve(approvedAID.LastModifiedBy, approvedAID.LastModifiedDate);

            pendingAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            pendingAID.WaitForApproval();

            rejectedAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            rejectedAID.Reject(rejectedAID.LastModifiedBy, rejectedAID.LastModifiedDate);

            Site site = SiteFixture.Denver();
            allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(site.Id.Value);
            noneSelectedReApprovalConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneAIDAutoReApprovalConfiguration(site.Id.Value);
        }

        private void UpdateStatusAfterChangesTest(bool userCanReApprove,
                                                  ActionItemDefinition beforeChanges,
                                                  ActionItemDefinitionAutoReApprovalConfiguration config,
                                                  AssertStatusState assertExpectedStatusState,
                                                  bool editedRequiredApprovalValue)
        {
            string editedNewName = "New Name That isn't the same as the old one";

            ActionItemDefinition afterChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(beforeChanges);
            afterChanges.Name = editedNewName;
            afterChanges.RequiresApproval = editedRequiredApprovalValue;

            bool activeBeforeUpdatingStatus = afterChanges.Active;
            afterChanges.UpdateStatusAfterChanges(userCanReApprove, config, beforeChanges);
            assertExpectedStatusState(afterChanges, activeBeforeUpdatingStatus);
        }

        [Test]
        public void ShouldSetToPendingWhenUserWithReApprovalPermissionEditsAndSetRequiresApproval()
        {
            bool lastModifiedUserCanAutoReApprove = true;
            bool newRequiredApproval = true;

            AssertStatusState assertForPendingState = new AssertStatusState(AssertPendingStatesOnUpdateAfterChanges);

            //
            //  Editing Approved AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);

            //
            //  Editing Pending AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         pendingAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);

            //
            // Editing Rejected AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         rejectedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);
        }

        [Test][Ignore]
        public void ShouldApproveWhenUserWithReApprovalPermissionEditsAndSetRequiresApprovalToFalse()
        {
            bool lastModifiedUserCanAutoReApprove = true;
            bool newRequiredApproval = false;
            AssertStatusState assertForApprovedState = AssertApprovedStatesOnUpdateAfterChanges;
            //
            //  Editing Approved AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForApprovedState,
                                         newRequiredApproval);

            //
            //  Editing Pending AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         pendingAID,
                                         allSelectedConfig,
                                         assertForApprovedState,
                                         newRequiredApproval);

            //
            // Editing Rejected AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         rejectedAID,
                                         allSelectedConfig,
                                         assertForApprovedState,
                                         newRequiredApproval);
        }

        [Test]
        public void ShouldNotChangeActiveWhenApprovingDuringUpdatStatusAfterChanges()
        {
            bool lastModifiedUserCanAutoReApprove = true;
            bool newRequiredApproval = false;
            AssertStatusState assertForApprovedState = AssertApprovedStatesOnUpdateAfterChanges;

            //
            //  Editing Approved and Active = true AID
            //
            approvedAID.Active = true;
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForApprovedState,
                                         newRequiredApproval);

            //
            //  Editing Approved and Active = false AID
            //
            approvedAID.Active = false;
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForApprovedState,
                                         newRequiredApproval);
        }

        [Test]
        public void ShouldChangeToPendingWhenUserWithReApprovalPermissionEditAndSetRequiresApprovalToTrue()
        {
            bool lastModifiedUserCanAutoReApprove = true;
            bool newRequiredApproval = true;
            AssertStatusState assertForPendingState = AssertPendingStatesOnUpdateAfterChanges;
            //
            //  Editing Approved AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);

            //
            //  Editing Pending AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         pendingAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);

            //
            // Editing Rejected AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         rejectedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         newRequiredApproval);
        }

        [Test]
        public void ShouldRemainApprovedWhenUserWithNoReApprovalPermissionEditsApprovedAIDFieldsThatDoesNotRequireReApproval()
        {
            bool lastModifiedUserCanAutoReApprove = false;
            AssertStatusState assertForApprovedState = AssertApprovedStatesOnUpdateAfterChanges;

            //
            // Editing Approved AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         noneSelectedReApprovalConfig,
                                         assertForApprovedState,
                                         approvedAID.RequiresApproval);
        }

        [Test]
        public void ShouldChangeToPendingWhenUserWithNoReApprovalPermissionEditsFieldsThatDoesNotRequireReApprovalButAIDIsNotYetApproved()
        {
            bool lastModifiedUserCanAutoReApprove = false;
            AssertStatusState assertForPendingState = AssertPendingStatesOnUpdateAfterChanges;
            //
            // Editing Pending AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         pendingAID,
                                         noneSelectedReApprovalConfig,
                                         assertForPendingState,
                                         pendingAID.RequiresApproval);

            //
            // Editing Rejected AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         rejectedAID,
                                         noneSelectedReApprovalConfig,
                                         assertForPendingState,
                                         rejectedAID.RequiresApproval);

        }

        [Test]
        public void ShouldChangeToPendingWhenUserWithNoReApprovalPermissionEditsFieldsThatRequriesReApproval()
        {
            bool lastModifiedUserCanAutoReApprove = false;
            AssertStatusState assertForPendingState = AssertPendingStatesOnUpdateAfterChanges;

            //
            //  Editing Approved AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         approvedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         approvedAID.RequiresApproval);

            //
            //  Editing Pending AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         pendingAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         pendingAID.RequiresApproval);

            //
            // Editing Rejected AID
            //
            UpdateStatusAfterChangesTest(lastModifiedUserCanAutoReApprove,
                                         rejectedAID,
                                         allSelectedConfig,
                                         assertForPendingState,
                                         rejectedAID.RequiresApproval);
        }

        private void AssertApprovedStatesOnUpdateAfterChanges(ActionItemDefinition aid, bool activeBeforeUpdatingStatus)
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Approved;
            bool expectedRequireApproval = false;

            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);

            Assert.AreEqual(activeBeforeUpdatingStatus, aid.Active);
        }

        private void AssertPendingStatesOnUpdateAfterChanges(ActionItemDefinition aid, bool activeBeforeUpdatingStatus)
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Pending;
            bool expectedRequireApproval = true;
            bool expectedActive = false;

            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);
            Assert.AreEqual(expectedActive, aid.Active);
        }
    }
}