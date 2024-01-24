using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetDefinitionUpdateStatusOnEditingAutoReApprovalFieldTest
    {
        private delegate void AssertStatusState(TargetDefinition afterChanges, bool activeValueBeforeChanges);

        private TargetDefinition approvedTargetDef;
        private TargetDefinition pendingTargetDef;
        private TargetDefinition rejectedTargetDef;

        private TargetDefinitionAutoReApprovalConfiguration allSelectedConfig;
        private TargetDefinitionAutoReApprovalConfiguration noneSelectedConfig;

        [SetUp]
        public void SetUp()
        {
            User currentUser = UserFixture.CreateUser();

            approvedTargetDef = TargetDefinitionFixture.CreateTargetDefinition();
            approvedTargetDef.Approve(currentUser, DateTimeFixture.DateTimeNow);

            pendingTargetDef = TargetDefinitionFixture.CreateTargetDefinition();
            pendingTargetDef.WaitForApproval();

            rejectedTargetDef = TargetDefinitionFixture.CreateTargetDefinition();
            rejectedTargetDef.Reject(currentUser, DateTimeFixture.DateTimeNow);

            allSelectedConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedTargetDefAutoReApprovalConfig(currentUser.AvailableSites[0].IdValue);
            noneSelectedConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneTargetDefAutoReApprovalConfig(currentUser.AvailableSites[0].IdValue);
        }

        [TearDown]
        public void TearDown()
        {
        }

        private static void EditFieldsOnTargetDefinition(TargetDefinition targetDefToBeEdited)
        {
            targetDefToBeEdited.Name = "New Name";
            targetDefToBeEdited.Category = TargetCategory.PRODUCTION;
            targetDefToBeEdited.OperationalMode = OperationalMode.ShutDown;
            targetDefToBeEdited.Priority = Priority.High;
            targetDefToBeEdited.Description = "New Description";
            targetDefToBeEdited.DocumentLinks = new List<DocumentLink>();
            targetDefToBeEdited.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            targetDefToBeEdited.TagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            targetDefToBeEdited.AssociatedTargetDTOs = new List<TargetDefinitionDTO>();
            targetDefToBeEdited.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            targetDefToBeEdited.GenerateActionItem = true;
            targetDefToBeEdited.RequiresResponseWhenAlerted = true;
        }

        #region User Who Can Re-Approve

        private static void UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(TargetDefinition beforeChanges,
                                                                                  TargetDefinitionAutoReApprovalConfiguration config,
                                                                                  AssertStatusState assertExpectedStatusState,
                                                                                  bool editedRequiredApprovalValue)
        {
            const bool userCanReApprove = true;
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            EditFieldsOnTargetDefinition(afterChanges);
            afterChanges.RequiresApproval = editedRequiredApprovalValue;

            bool activeBeforeUpdatingStatus = afterChanges.IsActive;
            afterChanges.UpdateStatusAfterChange(userCanReApprove, beforeChanges, config);
            assertExpectedStatusState(afterChanges, activeBeforeUpdatingStatus);
        }

        [Test]
        public void ShouldSetToPendingWhenUserWithApprovalPermissionEditsAndRequireApprovalIsSet()
        {
            const bool editedRequireApproval = true;
            AssertStatusState assertForPendingStates = new AssertStatusState(AssertPendingStates);

            //
            // Editing Approved Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(approvedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForPendingStates,
                                                                         editedRequireApproval);
            //
            // Editing Pending Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(pendingTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForPendingStates,
                                                                         editedRequireApproval);
            //
            // Editing Rejected Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(rejectedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForPendingStates,
                                                                         editedRequireApproval);
        }

        [Test]
        public void ShouldSetToApprovedWhenUserWithApprovalPermissionEditsAndRequireApprovalIsNotSet()
        {
            bool editedRequireApproval = false;
            AssertStatusState assertForApprovedStates = new AssertStatusState(AssertApprovedStates);

            //
            // Editing Approved Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(approvedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForApprovedStates,
                                                                         editedRequireApproval);
            //
            // Editing Pending Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(pendingTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForApprovedStates,
                                                                         editedRequireApproval);
            //
            // Editing Rejected Target Def
            //
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(rejectedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForApprovedStates,
                                                                         editedRequireApproval);
        }

        [Test]
        public void ShouldNotChangeIsActiveWhenApprovingViaUpdateStatusAfterChanges()
        {
            bool editedRequireApproval = false;
            AssertStatusState assertForApprovedStates = new AssertStatusState(AssertApprovedStates);

            //
            // Editing Approved, IsActive = true Target Def
            //
            approvedTargetDef.IsActive = true;
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(approvedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForApprovedStates,
                                                                         editedRequireApproval);

            //
            // Editing Approved, IsActive = false Target Def
            //
            approvedTargetDef.IsActive = false;
            UpdateStatusAfterEditingFieldsForUserWhoCanEditRequireApprovalTest(approvedTargetDef,
                                                                         allSelectedConfig,
                                                                         assertForApprovedStates,
                                                                         editedRequireApproval);
        }

        #endregion

        #region User Who Can NOT Re-Approve

        private void UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(TargetDefinition beforeChanges,
                                                                          TargetDefinitionAutoReApprovalConfiguration config,
                                                                          AssertStatusState assertExpectedStatusState)
        {
            bool userCanReApprove = false;
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            EditFieldsOnTargetDefinition(afterChanges);

            bool activeBeforeUpdatingStatus = afterChanges.IsActive;
            afterChanges.UpdateStatusAfterChange(userCanReApprove, beforeChanges, config);
            assertExpectedStatusState(afterChanges, activeBeforeUpdatingStatus);
        }

        [Test]
        public void ShouldRemainApprovedWhenUserEditsFieldsThatDoesNotRequireReApproval()
        {
            AssertStatusState assertForApprovedStates = new AssertStatusState(AssertApprovedStates);
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(approvedTargetDef,
                                                                noneSelectedConfig,
                                                                assertForApprovedStates);
        }

        [Test]
        public void ShouldChangedToPendingWhenUserEditsApprovedTargetDefFieldsThatRequireReApproval()
        {
            AssertStatusState assertForPendingStates = new AssertStatusState(AssertPendingStates);
            //
            //  Editing Fields on Approved Definition
            //
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(approvedTargetDef,
                                                                allSelectedConfig,
                                                                assertForPendingStates);
        }
        
        [Test]
        public void ShouldRemainPendingWhenUserEditsPendingTargetDefRegardlessIfEditedFieldsRequireReApproval()
        {
            AssertStatusState assertForPendingStates = new AssertStatusState(AssertPendingStates);

            //
            //  Editing Fields on Pending Definition - Edits Fields Requiring re-approval
            //
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(pendingTargetDef,
                                                                allSelectedConfig,
                                                                assertForPendingStates);
            //
            //  Editing Fields on Pending Definition - Edits Fields that does not 
            //  require re-approval
            //
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(pendingTargetDef,
                                                                noneSelectedConfig,
                                                                assertForPendingStates);
        }

        [Test]
        public void ShouldChangeToPendingWhenUserEditsRejectedTargetDefinitionRegardlessIfEditedFielsRequireReApproval()
        {
            AssertStatusState assertForPendingStates = new AssertStatusState(AssertPendingStates);

            //
            //  Editing Fields on Rejected Definition - Edits Fields Requiring re-approval
            //
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(rejectedTargetDef,
                                                                allSelectedConfig,
                                                                assertForPendingStates);
            //
            //  Editing Fields on Rejected Definition - Edits Fields that does not 
            //  require re-approval
            //
            UpdateStatusAfterEditingFieldTestForUserWhoCanNotApproveTest(rejectedTargetDef,
                                                                     noneSelectedConfig,
                                                                     assertForPendingStates);
        }

        #region Editing Thresholds

        private void UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(TargetDefinition beforeChanges,
                                                                                               TargetDefinition afterChanges,
                                                                                               AssertStatusState assertExpectedtatusState)
        {
            bool userCanReApprove = false;
            //
            //  We want to make sure editing fiels that requires re-approval doesn't affect
            //  testing of editing thresholds with pre-approved limites.
            //
            afterChanges.UpdateStatusAfterChange(userCanReApprove, beforeChanges, noneSelectedConfig);
            assertExpectedtatusState(afterChanges, beforeChanges.IsActive);
        }

        [Test]
        public void ShouldChangeToPendingWhenEditsApprovedDefThresholdsToOutSideOfPreApprovedLimits()
        {
            TargetDefinition beforeChanges = approvedTargetDef;
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsOutSideApprovedLimits(afterChanges);
            AssertStatusState assertPendingStates = new AssertStatusState(AssertPendingStates);

            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertPendingStates);
        }

        [Test]
        public void ShouldRemainApprovedWhenEditsApprovedDefThresholdsAndStayWithinApprovedLimits()
        {
            TargetDefinition beforeChanges = approvedTargetDef;
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsWithinApprovedLimits(afterChanges);
            AssertStatusState assertApprovedStates = new AssertStatusState(AssertApprovedStates);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertApprovedStates);
        }

        [Test]
        public void ShouldRemainPendingWhenEditingPendingDefThresholdsRegardlessIfWithinApprovedLimits()
        {
            TargetDefinition beforeChanges = pendingTargetDef;
            AssertStatusState assertPendingStates = new AssertStatusState(AssertPendingStates);

            //
            // Edit to Within Approved Limits
            //
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsWithinApprovedLimits(afterChanges);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertPendingStates);

            //
            // Edit OutSide Approved Limits
            //
            afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsOutSideApprovedLimits(afterChanges);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertPendingStates);
        }

        [Test]
        public void ShouldChangeToPendingWhenEditsRejectedDefThresholdsRegardlessIfStayWithinApprovedLimits()
        {
            TargetDefinition beforeChanges = rejectedTargetDef;
            AssertStatusState assertPendingStates = new AssertStatusState(AssertPendingStates);

            //
            // Edit to Within Approved Limits
            //
            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsWithinApprovedLimits(afterChanges);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertPendingStates);

            //
            // Edit OutSide Approved Limits
            //
            afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            SetThresholdsOutSideApprovedLimits(afterChanges);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges, afterChanges, assertPendingStates);
        }

        [Test]
        public void ShouldChangeToPendingWhenUserEditsOtherFieldsButNotApprovedDefWithThresholdsThatAreOutSideTheLimtis()
        {
            TargetDefinition beforeChanges = approvedTargetDef;
            SetThresholdsOutSideApprovedLimits(beforeChanges);

            TargetDefinition afterChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(beforeChanges);
            afterChanges.Name = "Change to New Name";

            AssertStatusState assertPendingStates = new AssertStatusState(AssertPendingStates);
            UpdateStatusAfterEditingFieldsWithPreApprovedSetUpForUserWhoCannotApproveTest(beforeChanges,
                                                                                      afterChanges,
                                                                                      assertPendingStates);
        }

        #endregion

        #endregion
        
        private void AssertApprovedStates(TargetDefinition afterChanges, bool activeValueBeforeChanges)
        {
            TargetDefinitionStatus expectedStatus = TargetDefinitionStatus.Approved;
            bool expectedRequireApproval = false;
            bool expectedActive = activeValueBeforeChanges;
            
            Assert.AreEqual(expectedStatus, afterChanges.Status);
            Assert.AreEqual(expectedRequireApproval, afterChanges.RequiresApproval);
            Assert.AreEqual(expectedActive, afterChanges.IsActive);
        }

        private void AssertPendingStates(TargetDefinition afterChanges, bool activeValueBeforeChanges)
        {
            TargetDefinitionStatus expectedStatus = TargetDefinitionStatus.Pending;
            bool expectedRequireApproval = true;
            bool expectedActive = false;

            Assert.AreEqual(expectedStatus, afterChanges.Status);
            Assert.AreEqual(expectedRequireApproval, afterChanges.RequiresApproval);
            Assert.AreEqual(expectedActive, afterChanges.IsActive);
        }

        private void SetThresholdsWithinApprovedLimits(TargetDefinition definition)
        {
            SetThresholds(definition, null, null, null, 9);
            SetPreApprovedLimits(definition, null, null, null, 10);
        }

        private void SetThresholdsOutSideApprovedLimits(TargetDefinition definition)
        {
            SetThresholds(definition, null, null, null, 11);
            SetPreApprovedLimits(definition, null, null, null, 10);
        }
        private void SetThresholds(TargetDefinition definition,
                                   decimal? nteMin,
                                   decimal? min, 
                                   decimal? max, 
                                   decimal? nteMax)
        {
            definition.NeverToExceedMinimum = nteMin;
            definition.NeverToExceedMinFrequency = 1;
            definition.MinValue = min;
            definition.MinValueFrequency = 1;
            definition.MaxValue = max;
            definition.MaxValueFrequency = 1;
            definition.NeverToExceedMaximum = nteMax;
            definition.NeverToExceedMaxFrequency = 1;
        }

        private static void SetPreApprovedLimits(TargetDefinition definition,
                                          decimal? nteMinLimit, 
                                          decimal? minLimit, 
                                          decimal? maxLimit, 
                                          decimal? nteMaxLimit)
        {
            definition.PreApprovedNeverToExceedMinimum = nteMinLimit;
            definition.PreApprovedMinValue = minLimit;
            definition.PreApprovedMaxValue = maxLimit;
            definition.PreApprovedNeverToExceedMaximum = nteMaxLimit;
        }
    }
}