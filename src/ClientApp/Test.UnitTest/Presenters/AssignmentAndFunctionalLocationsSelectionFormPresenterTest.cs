using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class AssignmentAndFunctionalLocationsSelectionFormPresenterTest
    {
        private List<FunctionalLocation> emptyFlocList;
        private List<FunctionalLocation> flocList;
        private IUserLoginHistoryService mockUserLoginHistoryService;
        private IAssignmentAndFunctionalLocationsSelectionForm mockView;
        private IVisibilityGroupService mockVisibilityGroupService;
        private IWorkAssignmentService mockWorkAssignmentService;
        private Mockery mocks;
        private List<long> readableVisibilityGroupIds;
        private User user;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IAssignmentAndFunctionalLocationsSelectionForm>();

            mockWorkAssignmentService = mocks.NewMock<IWorkAssignmentService>();
            mockUserLoginHistoryService = mocks.NewMock<IUserLoginHistoryService>();
            mockVisibilityGroupService = mocks.NewMock<IVisibilityGroupService>();

            flocList = FunctionalLocationFixture.CreateNewListOfNewItems(3);
            readableVisibilityGroupIds = new List<long> {1, 2, 3};

            emptyFlocList = new List<FunctionalLocation>();
            user = UserFixture.CreateUserWithGivenId(1);
            ClientSession.GetUserContext().User = user;

            Stub.On(mockView).SetProperty("SelectedReadableVisibilityGroupIds");
            Stub.On(mockView)
                .GetProperty("SelectedReadableVisibilityGroupIds")
                .Will(Return.Value(new List<long> {1, 2, 3}));

            Stub.On(mockVisibilityGroupService)
                .Method("QueryAll")
                .WithAnyArguments()
                .Will(Return.Value(new List<VisibilityGroup>()));

            Stub.On(mockView).EventAdd("Load", Is.Anything);
            Stub.On(mockView).EventAdd("AcceptClicked", Is.Anything);
            Stub.On(mockView).EventAdd("CancelClicked", Is.Anything);
            Stub.On(mockView).EventAdd("LoadPreviousFlocsClicked", Is.Anything);
            Stub.On(mockView).EventAdd("NoAssignmentCheckedChanged", Is.Anything);
            Stub.On(mockView).EventAdd("ClearFlocsClicked", Is.Anything);
            Stub.On(mockView).EventAdd("SelectedAssignmentCategoryChanged", Is.Anything);
            Stub.On(mockView).EventAdd("SelectedAssignmentChanged", Is.Anything);
            Stub.On(mockView).EventRemove("SelectedAssignmentChanged", Is.Anything);
            Stub.On(mockView).EventAdd("GroupGridUpdated", Is.Anything);
            Stub.On(mockView).Method("ShowWaitScreenAndDisableForm");
            Stub.On(mockView).Method("CloseWaitScreenAndEnableForm");
            Stub.On(mockView).Method("HideVisibilityGroupArea");
            Stub.On(mockView).SetProperty("FormContentVisible");
            Stub.On(mockView).Method("SetFormVisibleState");
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ClearButtonShouldSetTreeViewPresenterWithEmptyFlocList()
        {
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations").To(IsList.Equal(emptyFlocList));
            Stub.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(null));
            var presenter = CreatePresenter();
            presenter.HandleClearFlocSelectionButtonClick();
        }

        [Test]
        public void DisableAssignmentGridAndRadioButtonWhenUserHasNoAssignmentsToChooseFrom()
        {
            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment>()));
            Expect.Once.On(mockView).Method("DisableAssignmentSelection");
            Expect.Once.On(mockView).Method("DisableSelectAssignmentOption");
            Stub.On(mockView);
            Stub.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(null));
            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void DoNotDisableAssignmentGridAndRadioButtonWhenUserHasAssignmentsToChooseFrom()
        {
            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(WorkAssignmentFixture.CreateWorkAssignmentList(3)));
            Stub.On(mockView).SetProperty("Assignments");
            Stub.On(mockView).Method("SelectFirstAssignment");
            Stub.On(mockView).SetProperty("AssignmentCategories");
            Stub.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(null));

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment");
            Expect.Once.On(mockView)
                .SetProperty("UserCheckedFunctionalLocations")
                .To(new ListMatcher<FunctionalLocation>(new List<FunctionalLocation>()));

            Expect.Never.On(mockView).Method("DisableAssignmentSelection");
            Expect.Never.On(mockView).Method("DisableSelectAssignmentOption");

            Expect.AtLeastOnce.On(mockView).SetProperty("VisibilityGroupList");
            Expect.AtLeastOnce.On(mockView).SetProperty("WriteGroupList");

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void LoadPreviousFlocsButtonShouldLoadPreviousUserFlocPreferencesAndPresentOnTreeView()
        {
            var loginHistory = UserLoginHistoryFixture.CreateWithSelectedFuctionalLocations(user, flocList);
            Expect.Once.On(mockUserLoginHistoryService)
                .Method("GetLastLogin")
                .With(user)
                .Will(Return.Value(loginHistory));

            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations").To(flocList);

            var presenter = CreatePresenter();
            presenter.HandleLoadPreviousFlocsButtonClick();
        }

        [Test]
        public void LoadPreviousFlocsButtonShouldNotPresentOnTreeViewIfNoPreviousFlocsExist()
        {
            Expect.Once.On(mockUserLoginHistoryService).Method("GetLastLogin").With(user).Will(Return.Value(null));
            Expect.Never.On(mockView).SetProperty("UserCheckedFunctionalLocations");

            var presenter = CreatePresenter();
            presenter.HandleLoadPreviousFlocsButtonClick();
        }

        [Test]
        public void SelectingNoAssignmentShouldUncheckAllFlocsOnTreeView()
        {
            const WorkAssignment noSelectedAssignment = null;

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(noSelectedAssignment));
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations").To(new ListCountMatcher(0));
            Stub.On(mockView).SetProperty("VisibilityGroupList");
            Stub.On(mockView).SetProperty("WriteGroupList");

            Stub.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(null));
            var presenter = CreatePresenter();
            presenter.HandleSelectedAssignmentChanged();
        }

        [Test]
        public void ShouldNotShowNoAssignmentSelectedWarning()
        {
            var role = RoleFixture.CreateRole();
            role.WarnIfWorkAssignmentNotSelected = false;
            AssertWarningIfNoAssignmentSelected(false, role);
        }

        [Test]
        public void ShouldOnlyShowAssignmentsThatHaveFunctionalLocationsThatAreAPartOfTheUsersPlant()
        {
            var user = Fixtures.UserFixture.CreateUserWithPlant(100, ClientSession.GetUserContext());
            ClientSession.GetUserContext().User = user;

            var role = user.SiteRolePlants[0].Role; // I happen to know that all of the roles are the same

            var assignmentList = new List<WorkAssignment>();
            assignmentList.Add(new WorkAssignment(
                1, "assignment1", null, null, 1, role, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(100),
                    FunctionalLocationFixture.CreateNewWithPlantId(101)
                }, null, null,false,true));
            assignmentList.Add(new WorkAssignment(
                2, "assignment2", null, null, 2, role, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(102),
                    FunctionalLocationFixture.CreateNewWithPlantId(103)
                }, null, null,false,true));
            assignmentList.Add(new WorkAssignment(
                3, "assignment3", null, null, 3, role, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(100),
                    FunctionalLocationFixture.CreateNewWithPlantId(100)
                }, null, null,false,false));
            assignmentList.Add(new WorkAssignment(
                4, "assignment4", null, null, 4, role, true, true,
                new List<FunctionalLocation>(), null, null,false,false));

            Stub.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockView).SetProperty("Assignments").To(new ListMatcher<WorkAssignment>(
                new List<WorkAssignment> {assignmentList[0], assignmentList[2]}));
            Stub.On(mockView);
            Stub.On(mockUserLoginHistoryService);

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldOnlyShowAssignmentsWithAMatchingRole()
        {
            var user = Fixtures.UserFixture.CreateUserWithPlant(100, ClientSession.GetUserContext());
            ClientSession.GetUserContext().User = user;

            var role = user.SiteRolePlants[0].Role;
            var otherRole = RoleFixture.CreatePermitScreenerRole();

            Assert.AreNotEqual(role.Id, otherRole.Id);

            var assignmentList = new List<WorkAssignment>();
            assignmentList.Add(new WorkAssignment(
                1, "assignment1", null, null, 1, role, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(100),
                    FunctionalLocationFixture.CreateNewWithPlantId(101)
                }, null, null, true,true));
            assignmentList.Add(new WorkAssignment(
                2, "assignment2", null, null, 2, role, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(102),
                    FunctionalLocationFixture.CreateNewWithPlantId(103)
                }, null, null, true,true));
            assignmentList.Add(new WorkAssignment(
                3, "assignment3", null, null, 3, otherRole, true, true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(100),
                    FunctionalLocationFixture.CreateNewWithPlantId(100)
                }, null, null, true,true));
            assignmentList.Add(new WorkAssignment(
                4, "assignment4", null, null, 4, role, true, true,
                new List<FunctionalLocation>(), null, null,false,false));

            Stub.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockView).SetProperty("Assignments").To(new ListMatcher<WorkAssignment>(
                new List<WorkAssignment> {assignmentList[0]}));
            Stub.On(mockView);
            Stub.On(mockUserLoginHistoryService);

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldSelectFirstAssignmentIfNoUserPreferenceExists()
        {
            var assignmentList = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            UserLoginHistory noLoginHistory = null;

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockUserLoginHistoryService)
                .Method("GetLastLogin")
                .With(user)
                .Will(Return.Value(noLoginHistory));
            Expect.Never.On(mockView).SetProperty("SelectedAssignment");
            Expect.Once.On(mockView).Method("SelectFirstAssignment");
            Stub.On(mockView).SetProperty("Assignments");
            Stub.On(mockView).SetProperty("AssignmentCategories");

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment");
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations");

            Expect.AtLeastOnce.On(mockView).SetProperty("VisibilityGroupList");
            Expect.AtLeastOnce.On(mockView).SetProperty("WriteGroupList");

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldSelectFirstAssignmentIfUserPreferenceAppliesToADifferentSiteThanUserIsLoggedInWith()
        {
            // log in under some site
            var siteLoggedInUnder = SiteFixture.Sarnia();
            var userContext = ClientSession.GetUserContext();
            userContext.SetSite(siteLoggedInUnder, null);

            // create preferred assignment, which is not part of the list shown on screen
            var siteOfPreferredAssignment = SiteFixture.Firebag();
            Assert.AreNotEqual(siteOfPreferredAssignment.Id, siteLoggedInUnder.Id);
            var preferredAssignment = WorkAssignmentFixture.CreateConsoleOperator(siteOfPreferredAssignment.IdValue);
            var loginHistory = UserLoginHistoryFixture.Create(user, preferredAssignment);

            // create list of assignments that are shown on screen
            var assignmentForSiteLoggedInUnder = new WorkAssignment(
                1, "Console Operator", null, null, siteLoggedInUnder.IdValue, RoleFixture.CreateOperatorRole(), true,
                true,
                new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNewWithPlantId(PlantFixture.SarniaPlant.IdValue)
                }, null, null, true,true);
            var assignmentList = new List<WorkAssignment> {assignmentForSiteLoggedInUnder};

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockView).SetProperty("Assignments").To(new ListMatcher<WorkAssignment>(assignmentList));
            Expect.Once.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(loginHistory));

            Expect.Once.On(mockView).Method("SelectFirstAssignment");
            Stub.On(mockView).SetProperty("AssignmentCategories");

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment");
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations");

            Expect.AtLeastOnce.On(mockView).SetProperty("VisibilityGroupList");
            Expect.AtLeastOnce.On(mockView).SetProperty("WriteGroupList");

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldSetGridToAssignmentOnLoad()
        {
            var assignmentList = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            var preferredAssignment = assignmentList[0];
            var loginHistory = UserLoginHistoryFixture.Create(user, preferredAssignment);

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockUserLoginHistoryService)
                .Method("GetLastLogin")
                .With(user)
                .Will(Return.Value(loginHistory));
            Expect.Once.On(mockView).SetProperty("SelectedAssignment").To(preferredAssignment);
            Expect.Never.On(mockView).Method("SelectFirstAssignment");
            Stub.On(mockView).SetProperty("Assignments");
            Stub.On(mockView).SetProperty("AssignmentCategories");
            Stub.On(mockView).SetProperty("SelectedAssignmentCategory");

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment");
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations");

            Expect.AtLeastOnce.On(mockView).SetProperty("VisibilityGroupList");
            Expect.AtLeastOnce.On(mockView).SetProperty("WriteGroupList");

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldSetNoAssignmentRadioButtonIfThatIsUserPreference()
        {
            var assignmentList = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            WorkAssignment noPreferredAssignment = null;
            var loginHistory = UserLoginHistoryFixture.Create(user, noPreferredAssignment);

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));
            Expect.Once.On(mockUserLoginHistoryService)
                .Method("GetLastLogin")
                .With(user)
                .Will(Return.Value(loginHistory));
            Expect.Once.On(mockView).SetProperty("SelectedAssignment").To(noPreferredAssignment);
            Expect.Never.On(mockView).Method("SelectFirstAssignment");
            Stub.On(mockView).SetProperty("Assignments");
            Stub.On(mockView).SetProperty("AssignmentCategories");
            Stub.On(mockView).SetProperty("SelectedAssignmentCategory");

            Expect.AtLeastOnce.On(mockView).GetProperty("SelectedAssignment");
            Expect.Once.On(mockView).SetProperty("UserCheckedFunctionalLocations");

            Expect.AtLeastOnce.On(mockView).SetProperty("VisibilityGroupList");
            Expect.AtLeastOnce.On(mockView).SetProperty("WriteGroupList");

            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void ShouldShowNoAssignmentSelectedWarning()
        {
            var role = RoleFixture.CreateRole();
            role.WarnIfWorkAssignmentNotSelected = true;
            AssertWarningIfNoAssignmentSelected(true, role);
        }

        private AssignmentAndFunctionalLocationsSelectionFormPresenter CreatePresenter()
        {
            return new TestableAssignmentAndFunctionalLocationFormPresenter(
                mockView,
                mockWorkAssignmentService,
                mockUserLoginHistoryService,
                mockVisibilityGroupService,
                false);
        }

        private void AssertWarningIfNoAssignmentSelected(bool expectWarning, Role role)
        {
            var userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Oilsands(), null);
            userContext.User = UserFixture.CreateUser();
            userContext.User.SiteRolePlants.Clear();
            userContext.User.SiteRolePlants.Add(new SiteRolePlant(userContext.Site, role, 0));

            Stub.On(mockView).GetProperty("AllCheckedFunctionalLocations").Will(Return.Value(flocList));
            Stub.On(mockView)
                .GetProperty("SelectedReadableVisibilityGroupIds")
                .Will(Return.Value(readableVisibilityGroupIds));
            var visibilityGroupLoginDisplayAdapters =
                readableVisibilityGroupIds.ConvertAll(
                    id => new VisibilityGroupLoginDisplayAdapter(id, "whatever", true, true));
            Stub.On(mockView).GetProperty("VisibilityGroupList").Will(Return.Value(visibilityGroupLoginDisplayAdapters));

            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(null));
            if (expectWarning)
            {
                Expect.Once.On(mockView).Method("ShowNoAssignmentSelectedWarning").Will(Return.Value(DialogResult.OK));
            }
            else
            {
                Expect.Never.On(mockView).Method("ShowNoAssignmentSelectedWarning");
            }
            Expect.Once.On(mockView).Method("CloseForm");
            Stub.On(mockUserLoginHistoryService).Method("SaveLoginHistory");
            Stub.On(mockView);

            var assignmentList = WorkAssignmentFixture.CreateWorkAssignmentList(3);
            Stub.On(mockWorkAssignmentService)
                .Method("QueryByUserAndSite")
                .WithAnyArguments()
                .Will(Return.Value(assignmentList));

            Stub.On(mockUserLoginHistoryService).Method("GetLastLogin").Will(Return.Value(null));
            var presenter = CreatePresenter();
            presenter.HandleFormLoad(null, EventArgs.Empty);
            presenter.HandleAccept();
        }


        private class TestableAssignmentAndFunctionalLocationFormPresenter :
            AssignmentAndFunctionalLocationsSelectionFormPresenter
        {
            public TestableAssignmentAndFunctionalLocationFormPresenter(
                IAssignmentAndFunctionalLocationsSelectionForm assignmentAndFunctionalLocationsSelectionForm,
                bool changeActiveFlocsMode)
                : base(assignmentAndFunctionalLocationsSelectionForm, changeActiveFlocsMode)
            {
            }

            public TestableAssignmentAndFunctionalLocationFormPresenter(
                IAssignmentAndFunctionalLocationsSelectionForm assignmentAndFunctionalLocationsSelectionForm,
                IWorkAssignmentService assignmentService, IUserLoginHistoryService loginHistoryService,
                IVisibilityGroupService visibilityGroupService, bool changeActiveFlocsMode)
                : base(
                    assignmentAndFunctionalLocationsSelectionForm, assignmentService, loginHistoryService,
                    visibilityGroupService, changeActiveFlocsMode)
            {
            }

            protected override void LoadData(List<Action> loadDataDelegates)
            {
                foreach (var loadDataDelegate in loadDataDelegates)
                {
                    loadDataDelegate();
                }

                AfterDataLoad();
            }
        }
    }
}