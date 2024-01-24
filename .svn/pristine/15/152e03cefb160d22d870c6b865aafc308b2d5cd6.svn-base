using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ActionItemDefinitionFormPresenterUpdateStatusAfterChangesTest
    {
        private delegate void AssertStatusState(ActionItemDefinition aid);

        ActionItemDefinition approvedAID;
        ActionItemDefinition pendingAID;
        ActionItemDefinition rejectedAID;

        ActionItemDefinitionFormPresenterTest.FakeActionItemDefinitionFormPresenter editPresenter;

        Mockery mocks;
        IActionItemDefinitionFormView mockView;
        IActionItemDefinitionService mockActionItemDefinitionService;
        private IActionItemService mockActionItemService;
        private IFormEdmontonService mockFormService;
        private IUserService mockUserService;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();
            mocks = new Mockery();
            mockView = mocks.NewMock<IActionItemDefinitionFormView>();
            mockActionItemDefinitionService = mocks.NewMock<IActionItemDefinitionService>();
            mockActionItemService = mocks.NewMock<IActionItemService>();
            mockFormService = mocks.NewMock<IFormEdmontonService>();
            mockUserService = mocks.NewMock<IUserService>();

            approvedAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            approvedAID.Approve(approvedAID.LastModifiedBy, approvedAID.LastModifiedDate);
            
            pendingAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            pendingAID.WaitForApproval();

            rejectedAID = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            rejectedAID.Reject(rejectedAID.LastModifiedBy, rejectedAID.LastModifiedDate);

            Stub.On(mockView).SetProperty("Assignment");
            Stub.On(mockView).GetProperty("Assignment");
            Stub.On(mockView).GetProperty("CreateAnActionItemForEachFunctionalLocation").Will(Return.Value(true));
            Stub.On(mockView).SetProperty("CreateAnActionItemForEachFunctionalLocation");
        }

        private void StubGetterExpectation(ActionItemDefinition aidExpectation)
        {
            Stub.On(mockView).GetProperty("ActionItemDefinitionName").Will(Return.Value(aidExpectation.Name));
            Stub.On(mockView).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(aidExpectation.FunctionalLocations));
            Stub.On(mockView).GetProperty("Category").Will(Return.Value(aidExpectation.Category));
            Stub.On(mockView).GetProperty("Priority").Will(Return.Value(aidExpectation.Priority));
            Stub.On(mockView).GetProperty("Description").Will(Return.Value(aidExpectation.Description));
            Stub.On(mockView).GetProperty("IsActive").Will(Return.Value(aidExpectation.Active));
            Stub.On(mockView).GetProperty("RequiresApproval").Will(Return.Value(aidExpectation.RequiresApproval));
            Stub.On(mockView).GetProperty("ResponseRequired").Will(Return.Value(aidExpectation.ResponseRequired));
            Stub.On(mockView).GetProperty("Schedule").Will(Return.Value(aidExpectation.Schedule));
            Stub.On(mockView).GetProperty("AssociatedTargetDefinitionDto").Will(Return.Value(aidExpectation.TargetDefinitionDTOs));
            Stub.On(mockView).GetProperty("AssociatedDocumentLinks").Will(Return.Value(aidExpectation.DocumentLinks));
            Stub.On(mockView).GetProperty("CreateDateTime").Will(Return.Value(aidExpectation.LastModifiedDate));
            Stub.On(mockView).GetProperty("Source").Will(Return.Value(aidExpectation.Source));
            Stub.On(mockView).GetProperty("OperationalMode").Will(Return.Value(OperationalMode.Normal));
            Stub.On(mockView).GetProperty("OperationalMode").Will(Return.Value(OperationalMode.Normal));
            Stub.On(mockView).GetProperty("FormGn75BId").Will(Return.Value(aidExpectation.AssociatedFormGN75BId));
        }

        private void ShouldUpdateStatusAfterChangesTest(ActionItemDefinition editObject,
                                                        User currentUser,
                                                        UserRoleElements userRoleElements,
                                                        ActionItemDefinitionAutoReApprovalConfiguration aidConfig,
                                                        bool newRequireApproval,
                                                        AssertStatusState assertStatusState)
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.User = currentUser;
            userContext.SetRole(null, userRoleElements, new List<RoleDisplayConfiguration>(), userContext.RolePermissions);
            Site site = currentUser.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateSiteConfiguration(site, aidConfig);
            userContext.SetSite(site, siteConfiguration);

            editPresenter = new ActionItemDefinitionFormPresenterTest.FakeActionItemDefinitionFormPresenter(
                mockView, 
                editObject, 
                mockActionItemDefinitionService,
                mocks.NewMock<IBusinessCategoryService>(),
                mocks.NewMock<IWorkAssignmentService>(),
                mockActionItemService,
                mockFormService,mockUserService);

            ActionItemDefinition beforeChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(editObject);
            long id = editObject.IdValue;

            Expect.Once.On(mockActionItemDefinitionService).Method("QueryById").With(id).Will(Return.Value(beforeChanges));

            ActionItemDefinition afterChanges = ActionItemDefinitionFixture.CreateActionItemDefinition(id);
            afterChanges.Name = "Some New Name ";
            afterChanges.RequiresApproval = newRequireApproval;
            afterChanges.AssociatedFormGN75BId = -99;

            StubGetterExpectation(afterChanges);
            Stub.On(mockActionItemDefinitionService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Stub.On(mockActionItemDefinitionService);

            SaveUpdateDomainObjectContainer<ActionItemDefinition> container = editPresenter.GetPopulatedEditObjectToUpdateDespiteMethodBeingProtected();
            editPresenter.Update(container);

            assertStatusState(editObject);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldChangeToPendingWhenUserWithAutoApprovePermissionEditsApprovedAIDAndSetsRequireApprovalToTrue()
        {
            const bool newRequireApproval = true;
            User userWithAutoApprovePermission = UserFixture.CreateUserWithAutoApproveActionItemDefinitionPermission();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(userWithAutoApprovePermission.AvailableSites[0].IdValue);
            AssertStatusState assertPendingState = AssertPendingStates;

            ShouldUpdateStatusAfterChangesTest(approvedAID,
                                               userWithAutoApprovePermission,
                                               userRoleElements,
                                               allSelectedConfig,
                                               newRequireApproval,
                                               assertPendingState);
        }

        [Test][Ignore]
        public void ShouldChangeToApprovedWhenUserWithAutoApprovePermissionEditsPendingAIDAndSetsRequireApprovalToFalse()
        {
            const bool newRequireApproval = false;
            User userWithAutoApprovePermission = UserFixture.CreateUserWithAutoApproveActionItemDefinitionPermission();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            Site site = userWithAutoApprovePermission.AvailableSites[0];
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(site.IdValue);
            AssertStatusState assertApprovedStatus = AssertApprovedStates;

            ShouldUpdateStatusAfterChangesTest(pendingAID,
                                               userWithAutoApprovePermission,
                                               userRoleElements,
                                               allSelectedConfig,
                                               newRequireApproval,
                                               assertApprovedStatus);
        }

        [Test][Ignore]
        public void ShouldChangeToPendingWhenUserWithNoReApprovalPermissionEditsApprovedAIDAndEditedFieldRequiresReApproval()
        {
            const bool newRequireApproval = false;
            User userWithNoAutoApprovePermission = UserFixture.CreateUserWhoCanNotAutoApproveActionItemDefinitio();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Site site = userWithNoAutoApprovePermission.AvailableSites[0];
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(site.IdValue);
            AssertStatusState assertPendingStatus = AssertPendingStates;

            ShouldUpdateStatusAfterChangesTest(approvedAID,
                                               userWithNoAutoApprovePermission,
                                               userRoleElements,
                                               allSelectedConfig,
                                               newRequireApproval,
                                               assertPendingStatus);
        }

        [Test][Ignore]
        public void ShouldRemainApprovedWhenUserWithNoReApprovalPermissionEditsApprovedAIDAndNoFieldsRequiresReApproval()
        {
            const bool newRequireApproval = false;
            User userWithNoAutoApprovePermission = UserFixture.CreateUserWhoCanNotAutoApproveActionItemDefinitio();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Site site = userWithNoAutoApprovePermission.AvailableSites[0];
            ActionItemDefinitionAutoReApprovalConfiguration nonSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneAIDAutoReApprovalConfiguration(site.IdValue);
            AssertStatusState assertApproveStates = AssertApprovedStates;

            ShouldUpdateStatusAfterChangesTest(approvedAID,
                                               userWithNoAutoApprovePermission,
                                               userRoleElements,
                                               nonSelectedConfig,
                                               newRequireApproval,
                                               assertApproveStates);
        }
        
        [Test][Ignore]
        public void ShouldRemainPendingWhenUserWithNoReApprovalPermissionEdits()
        {
            const bool newRequireApproval = true;
            User userWithNoAutoApprovePermission = UserFixture.CreateUserWhoCanNotAutoApproveActionItemDefinitio();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Site site = userWithNoAutoApprovePermission.AvailableSites[0];
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(site.IdValue);
            AssertStatusState assertPendingStatus = AssertPendingStates;

            ShouldUpdateStatusAfterChangesTest(pendingAID,
                                               userWithNoAutoApprovePermission,
                                               userRoleElements,
                                               allSelectedConfig,
                                               newRequireApproval,
                                               assertPendingStatus);
        }

        [Test][Ignore]
        public void ShouldChangeToPendingWhenUserWithNoReApprovalPermissionEditsRejectedAID()
        {
            const bool newRequireApproval = true;
            User userWithNoAutoApprovePermission = UserFixture.CreateUserWhoCanNotAutoApproveActionItemDefinitio();
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            Site site = userWithNoAutoApprovePermission.AvailableSites[0];
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(site.IdValue);
            AssertStatusState assertPendingStatus = AssertPendingStates;

            ShouldUpdateStatusAfterChangesTest(rejectedAID,
                                               userWithNoAutoApprovePermission,
                                               userRoleElements,
                                               allSelectedConfig,
                                               newRequireApproval,
                                               assertPendingStatus);
        }
        
        private void AssertApprovedStates(ActionItemDefinition aid)
        {
            ActionItemDefinitionStatus expectedStatus = ActionItemDefinitionStatus.Approved;
            bool expectedRequireApproval = false;

            Assert.AreEqual(expectedStatus, aid.Status);
            Assert.AreEqual(expectedRequireApproval, aid.RequiresApproval);
        }

        private void AssertPendingStates(ActionItemDefinition aid)
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