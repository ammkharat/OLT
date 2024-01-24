using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    [TestFixture]
    public class OldPriorityPagePresenterTest
    {
        private Mockery mocks;
        private IOldPriorityPage mockPage;
        private IRemoteEventRepeater mockRemoteEventRepeater;
        private IActionItemService mockActionItemService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private ITargetAlertService mockTargetAlertService;
        private IWorkPermitService mockWorkPermitService;        
        private IGasTestElementInfoService mockGasTestElementInfoService;
        private IDeviationAlertService mockDeviationAlertService;
        private ILabAlertService mockLabAlertService;
        private IShiftHandoverService mockShiftHandoverService;
        private IAuthorized mockAuthorized;
        private List<TargetAlertDTO> targetAlertDtoList;
        private List<ActionItemDTO> actionItemDtoList;
        private List<WorkPermitDTO> workPermitDtoList;
        private UserRoleElements roleElementsForSupervisor;

        private UserShift currentUserShift;
        private List<FunctionalLocation> selectedFlocList;
        private OldPriorityPagePresenter presenter;
        

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            mocks = new Mockery();
            mockPage = mocks.NewMock<IOldPriorityPage>();
            mockRemoteEventRepeater = mocks.NewMock<IRemoteEventRepeater>();
            mockActionItemService = mocks.NewMock<IActionItemService>();
            mockTargetAlertService = mocks.NewMock<ITargetAlertService>();
            mockWorkPermitService = mocks.NewMock<IWorkPermitService>();            
            mockGasTestElementInfoService = mocks.NewMock<IGasTestElementInfoService>();
            mockDeviationAlertService = mocks.NewMock<IDeviationAlertService>();
            mockLabAlertService = mocks.NewMock<ILabAlertService>();
            mockAuthorized = mocks.NewMock<IAuthorized>();
            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();
            mockShiftHandoverService = mocks.NewMock<IShiftHandoverService>();

            ClientSession.GetNewInstance();
            UserContext userContext = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(userContext);
            roleElementsForSupervisor = userContext.UserRoleElements;

            currentUserShift = UserShiftFixture.CreateUserShift();
            userContext.UserShift = currentUserShift;
            selectedFlocList = FunctionalLocationFixture.CreateNewListOfNewItems(10);
            userContext.SetSelectedFunctionalLocations(selectedFlocList, new List<FunctionalLocation>(), new List<FunctionalLocation>());
            targetAlertDtoList = TargetAlertDTOFixture.CreateTargetAlertDTOList();
            actionItemDtoList = ActionItemDTOFixture.CreateActionItemDtoList();
            workPermitDtoList = WorkPermitDTOFixture.CreateWorkPermitDTOList();

            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia())));

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = ShiftHandoverQuestionnaireFixture.Create();
            shiftHandoverQuestionnaire.Id = 1;
            presenter = new OldPriorityPagePresenter(
                mockPage, 
                mockRemoteEventRepeater, 
                mockAuthorized,
                mockActionItemService, 
                mockTargetAlertService, 
                mockWorkPermitService, 
                mockGasTestElementInfoService, 
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);

            Stub.On(mockPage).GetProperty("IsDisposed").Will(Return.Value(false));
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldOnlyAllowViewingWorkPermit()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            CheckSecurityAndLoadDataTest(false, false, true, false);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldOnlyAllowViewingTargetAlert()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            CheckSecurityAndLoadDataTest(true, false, false, false);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldOnlyAllowViewingActionItem()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            CheckSecurityAndLoadDataTest(false, true, false, false);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldRemoveWorkPermitFromPageIfPermitCompleted()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            TestRemoteEventRepeater mockRepeater = new TestRemoteEventRepeater();
            presenter = new OldPriorityPagePresenter(
                mockPage, 
                mockRepeater,
                mockAuthorized,
                mockActionItemService,
                mockTargetAlertService,
                mockWorkPermitService,
                mockGasTestElementInfoService,
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);


            SetUpExpectationsForHandlingLoadEvent(false, false, true, false);
            presenter.PriorityPage_Load(this, EventArgs.Empty);
            WorkPermit completedPermit = CreatePermitWithStatus(WorkPermitStatus.Complete);
            // On recognizing that the permit is now completed, 
            // should go through same process as if the permit was removed:
            SetUpExpectationsForHandlingWorkPermitRemovedEvent();
            SetupExpectationsAuthorizeWorkPermitContextMenu();
            
            // Execute:
            mockRepeater.FireWorkPermitUpdatedEvent(completedPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldRemoveWorkPermitFromPageIfPermitRejected()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            TestRemoteEventRepeater mockRepeater = new TestRemoteEventRepeater();
            presenter = new OldPriorityPagePresenter(
                mockPage, 
                mockRepeater,
                mockAuthorized,
                mockActionItemService,
                mockTargetAlertService,
                mockWorkPermitService,
                mockGasTestElementInfoService,
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);
            SetUpExpectationsForHandlingLoadEvent(false, false, true, false);
            presenter.PriorityPage_Load(this, EventArgs.Empty);
            WorkPermit rejectedPermit = CreatePermitWithStatus(WorkPermitStatus.Rejected);
            // On recognizing that the permit has been rejected, 
            // should go through same process as if the permit was removed:
            SetUpExpectationsForHandlingWorkPermitRemovedEvent();
            SetupExpectationsAuthorizeWorkPermitContextMenu();
            // Execute:
            mockRepeater.FireWorkPermitUpdatedEvent(rejectedPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldRemoveWorkPermitFromPageIfPermitArchived()
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            TestRemoteEventRepeater mockRepeater = new TestRemoteEventRepeater();
            presenter = new OldPriorityPagePresenter(
                mockPage, 
                mockRepeater,
                mockAuthorized,
                mockActionItemService,
                mockTargetAlertService,
                mockWorkPermitService,
                mockGasTestElementInfoService,
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);
            SetUpExpectationsForHandlingLoadEvent(false, false, true, false);
            presenter.PriorityPage_Load(this, EventArgs.Empty);
            WorkPermit archivedPermit = CreatePermitWithStatus(WorkPermitStatus.Archived);
            SetUpExpectationsForHandlingWorkPermitRemovedEvent();
            SetupExpectationsAuthorizeWorkPermitContextMenu();
            
            mockRepeater.FireWorkPermitUpdatedEvent(archivedPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldAddWorkPermitToPageIfRejectedPermitIsNowApproved()
        {
            TestRemoteEventRepeater mockRepeater = new TestRemoteEventRepeater();
            presenter = new OldPriorityPagePresenter(
                mockPage, 
                mockRepeater,
                mockAuthorized,
                mockActionItemService,
                mockTargetAlertService,
                mockWorkPermitService,
                mockGasTestElementInfoService,
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);

            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            SetUpExpectationsForHandlingLoadEvent(false, false, true, false);
            presenter.PriorityPage_Load(this, EventArgs.Empty);
            WorkPermit approvedPermit = CreatePermitWithStatus(WorkPermitStatus.Approved);
            Expect.Once.On(mockPage).Method("ContainsWorkPermit").
                    With(TestUtil.HasProperty<WorkPermit>("Id", Is.EqualTo(approvedPermit.Id))).
                    Will(Return.Value(false));
            
            SetUpExpectationsForHandlingWorkPermitCreatedEvent(approvedPermit);
            SetupExpectationsAuthorizeWorkPermitContextMenu();
            // Execute:
            mockRepeater.FireWorkPermitUpdatedEvent(approvedPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldAddActionItemDependingOnWorkAssignmentAndSiteConfiguration()
        {
            WorkAssignment workAssignment1 = new WorkAssignment(string.Empty, string.Empty, string.Empty, 1, RoleFixture.CreateOperatorRole()) { Id = 1 };
            WorkAssignment workAssignment2 = new WorkAssignment(string.Empty, string.Empty, string.Empty, 1, RoleFixture.CreateOperatorRole()) { Id = 2 };
            
            AssertAddActionItem(true, true, workAssignment1, workAssignment1);
            AssertAddActionItem(true, true, null, null);
            AssertAddActionItem(false, true, workAssignment1, workAssignment2);
            AssertAddActionItem(false, true, workAssignment1, null);
            AssertAddActionItem(false, true, null, workAssignment2);

            AssertAddActionItem(true, false, workAssignment1, workAssignment1);
            AssertAddActionItem(true, false, null, null);
            AssertAddActionItem(true, false, workAssignment1, workAssignment2);
            AssertAddActionItem(true, false, workAssignment1, null);
            AssertAddActionItem(true, false, null, workAssignment2);
        }

        private void AssertAddActionItem(
            bool expectAdd, 
            bool includeAssignmentInPriorityPage,
            WorkAssignment userWorkAssignment,
            WorkAssignment actionItemWorkAssignment)
        {
            UserContext userContext = ClientSession.GetUserContext();
            userContext.Assignment = userWorkAssignment;
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia(), includeAssignmentInPriorityPage));
            
            ActionItem ai = ActionItemFixture.Create();
            ai.Assignment = actionItemWorkAssignment;

            TestRemoteEventRepeater mockRepeater = new TestRemoteEventRepeater();
            presenter = new OldPriorityPagePresenter(
                mockPage,
                mockRepeater,
                mockAuthorized,
                mockActionItemService,
                mockTargetAlertService,
                mockWorkPermitService,
                mockGasTestElementInfoService,
                mockDeviationAlertService,
                mockLabAlertService,
                mockShiftHandoverService);
            SetUpExpectationsForHandlingLoadEvent(false, true, false, false);
            presenter.PriorityPage_Load(this, EventArgs.Empty);

            if (expectAdd)
            {
                Expect.Once.On(mockPage).Method("Invoke").With(
                    Is.Anything,
                    TestUtil.HasFirstArrayElement(TestUtil.HasProperty<ActionItemDTO>("Id", Is.EqualTo(ai.Id))));
            }
            else
            {
                Expect.Never.On(mockPage).Method("Invoke");
            }

            mockRepeater.FireActionItemCreateEvent(ai);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private WorkPermit CreatePermitWithStatus(WorkPermitStatus status)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit(status);
            permit.Id = -99;
            permit.Specifics.StartDateTime = currentUserShift.StartDateTime.AddMinutes(1);
            return permit;
        }

        private void CheckSecurityAndLoadDataTest(bool allowViewTargetAlert, bool allowViewActionItem, bool allowViewWorkPermit, bool allowViewShiftHandoverQuestionnaire)
        {
            SetUpExpectationsForHandlingLoadEvent(allowViewTargetAlert, allowViewActionItem, allowViewWorkPermit, allowViewShiftHandoverQuestionnaire);
            presenter.CheckSecurityAndLoadData();
        }

        private void SetupExpectationsAuthorizeActionItemContextMenu()
        {
            List<ActionItemDTO> list = ActionItemDTOFixture.CreateActionItemDtoList();
            IActionItemActions mockActions = mocks.NewMock<IActionItemActions>();
            Expect.Once.On(mockPage).GetProperty("SelectedActionItemDTOs").Will(Return.Value(list));
            Expect.Once.On(mockPage).GetProperty("ActionItemActions").Will(Return.Value(mockActions));
            Expect.Once.On(mockAuthorized).Method("ToRespondActionItem").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("RespondEnabled").To(true);
        }

        private void SetupExpectationsAuthorizeTargetAlertContextMenu()
        {
            List<TargetAlertDTO> list = TargetAlertDTOFixture.CreateTargetAlertDTOList();
            ITargetAlertActions mockTargetAlertActions = mocks.NewMock<ITargetAlertActions>();
            Expect.Once.On(mockPage).GetProperty("SelectedTargetAlertDTOs").Will(Return.Value(list));
            Expect.Once.On(mockPage).GetProperty("TargetAlertActions").Will(Return.Value(mockTargetAlertActions));
            Expect.Once.On(mockAuthorized).Method("ToRespondToTargetAlerts").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockTargetAlertActions).SetProperty("RespondEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToAcknowledgeTargetAlerts").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockTargetAlertActions).SetProperty("AcknowledgeEnabled").To(true);
        }

        private void SetupExpectationsAuthorizeWorkPermitContextMenu()
        {
            List<WorkPermitDTO> dtos = WorkPermitDTOFixture.CreateWorkPermitDTOList();
            IWorkPermitActions mockActions = mocks.NewMock<IWorkPermitActions>();
            Expect.Once.On(mockPage).GetProperty("SelectedWorkPermitDTOs").Will(Return.Value(dtos));
            Stub.On(mockWorkPermitService).Method("QueryById").WithAnyArguments().Will(Return.Value(WorkPermitFixture.CreateWorkPermit()));
            Expect.Once.On(mockPage).GetProperty("WorkPermitActions").Will(Return.Value(mockActions));
            Expect.Once.On(mockAuthorized).Method("ToApproveWorkPermits").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockAuthorized).Method("ToFullyValidateWorkPermit").With(roleElementsForSupervisor).Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("ApproveEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToRejectWorkPermits").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("RejectEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToCloseWorkPermits").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("CloseEnabled").To(true); 
            Expect.Once.On(mockAuthorized).Method("ToCommentWorkPermit").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("CommentEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToDeleteWorkPermits").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("DeleteEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToEditWorkPermit").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("EditEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToCopyWorkPermitWithNoRestriction").WithAnyArguments().Will(Return.Value(false));
            Expect.Once.On(mockAuthorized).Method("ToCopyWorkPermitWithSomeRestrictions").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("CopyEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToCloneWorkPermitWithNoRestriction").WithAnyArguments().Will(Return.Value(false));
            Expect.Once.On(mockAuthorized).Method("ToCloneWorkPermitWithSomeRestrictions").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("CloneEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToPrintWorkPermits").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("PrintEnabled").To(true);
            Expect.Once.On(mockAuthorized).Method("ToPrintPreviewWorkPermit").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockActions).SetProperty("PrintPreviewEnabled").To(true);
        }

        private void SetUpExpectationsForHandlingLoadEvent(bool allowViewTargetAlert, bool allowViewActionItem, bool allowViewWorkPermit, bool allowViewShiftHandoverQuestionnaire)
        {
            Expect.Once.On(mockAuthorized).Method("ToViewActionItemsOnPrioritiesPage").With(roleElementsForSupervisor).Will(Return.Value(allowViewActionItem));
            if(allowViewActionItem)
            {
                Stub.On(mockActionItemService)
                    .Method("QueryDTOByFunctionalLocationsForCurrentShiftOrIfResponseRequiredWithDisplayLimits")
                    .Will(Return.Value(actionItemDtoList));
                Stub.On(mockActionItemService)
                    .Method("QueryDTOByFunctionalLocationsAndWorkAssignmentForCurrentShiftOrIfResponseRequiredWithDisplayLimits")
                    .Will(Return.Value(actionItemDtoList));
                Expect.Once.On(mockPage).SetProperty("ActionItemList").To(actionItemDtoList);
                SetupExpectationsAuthorizeActionItemContextMenu();
            }
            else
            {
                Expect.Once.On(mockPage).Method("DisableActionItemContextMenu");
                Expect.Once.On(mockPage).Method("DisableActionItemListView");
            }
            Expect.Once.On(mockAuthorized).Method("ToViewRestrictionReporting").With(roleElementsForSupervisor).Will(Return.Value(true));
            if(allowViewTargetAlert)
            {
                Expect.Once.On(mockTargetAlertService).Method("QueryByFunctionalLocationsAndStatuses").With(new PropertyMatcher("FunctionalLocations", IsList.Equal(selectedFlocList)), IsList.Equal(TargetAlertStatus.AllForPriorityDisplay)).Will(Return.Value(targetAlertDtoList));
                Expect.Once.On(mockPage).SetProperty("TargetList").To(targetAlertDtoList);
                SetupExpectationsAuthorizeTargetAlertContextMenu();
            }
            else
            {
                Expect.Once.On(mockPage).Method("DisableTargetContextMenu");
                Expect.Once.On(mockPage).Method("DisableTargetListView");
            }
            Expect.Once.On(mockAuthorized).Method("ToViewWorkPermitsOnThePrioritiesPage").With(roleElementsForSupervisor).Will(Return.Value(allowViewWorkPermit));
            if(allowViewWorkPermit)
            {
                Expect.Once.On(mockWorkPermitService).Method("QueryOldPriorityPageWorkPermits").With(new PropertyMatcher("FunctionalLocations", IsList.Equal(selectedFlocList)), new OltIdMatcher<ShiftPattern>(currentUserShift.ShiftPattern.IdValue)).Will(Return.Value(workPermitDtoList));
                Expect.Once.On(mockPage).SetProperty("WorkPermitList").To(workPermitDtoList);
                SetupExpectationsAuthorizeWorkPermitContextMenu();
            }
            else
            {
                Expect.Once.On(mockPage).Method("DisablePermitContextMenu");
                Expect.Once.On(mockPage).Method("DisablePermitListView");
            }
            Expect.Once.On(mockAuthorized).Method("ToViewShiftHandoverOnPrioritiesPage").With(roleElementsForSupervisor).Will(Return.Value(allowViewShiftHandoverQuestionnaire));
            
            Expect.Once.On(mockPage).Method("DisableShiftHandoverQuestionnaireListView");
            
            Stub.On(mockGasTestElementInfoService).Method("QueryStandardElementInfosBySiteId").Will(Return.Value(GasTestElementInfoFixture.SarniaStandardGasTestElementInfos));

            Expect.Once.On(mockAuthorized).Method("ToViewTargetsOnPrioritiesPage").With(roleElementsForSupervisor).Will(Return.Value(allowViewTargetAlert));
            Stub.On(mockDeviationAlertService).Method("QueryDTOsByFLOCAndShift");
            Stub.On(mockPage).SetProperty("DeviationAlertList");
            Stub.On(mockPage).GetProperty("SelectedDeviationAlertDTOs").Will(Return.Value(new List<DeviationAlertDTO>()));
            IDeviationAlertActions mockDeviationAlertActions = mocks.NewMock<IDeviationAlertActions>();
            Stub.On(mockDeviationAlertActions).SetProperty("RespondEnabled");
            Stub.On(mockPage).GetProperty("DeviationAlertActions").Will(Return.Value(mockDeviationAlertActions));
            Stub.On(mockPage).Method("SetPanelVisibility");

            Stub.On(mockAuthorized).Method("ToViewLabAlertDefinitionsAndLabAlerts").With(roleElementsForSupervisor).Will(Return.Value(true));
            Stub.On(mockLabAlertService).Method("QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs");
            Stub.On(mockPage).SetProperty("LabAlertList");
            Stub.On(mockPage).GetProperty("SelectedLabAlertDTOs").Will(Return.Value(new List<LabAlertDTO>()));
            ILabAlertActions mockLabAlertActions = mocks.NewMock<ILabAlertActions>();
            Stub.On(mockLabAlertActions).SetProperty("RespondEnabled");
            Stub.On(mockPage).GetProperty("LabAlertActions").Will(Return.Value(mockLabAlertActions));
        }

        private void SetUpExpectationsForHandlingWorkPermitCreatedEvent(WorkPermit permit)
        {
            Expect.Once.On(mockPage).Method("Invoke").With(Is.Anything,
                                                           TestUtil.HasFirstArrayElement(TestUtil.HasProperty<WorkPermitDTO>("Id", Is.EqualTo(permit.Id))));
        }

        private void SetUpExpectationsForHandlingWorkPermitRemovedEvent()
        {
            Expect.Once.On(mockPage).Method("Invoke");
        }
    }
}