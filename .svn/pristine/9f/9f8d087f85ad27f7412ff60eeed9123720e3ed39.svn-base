using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Controls.ToolStrips;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Presenters.Section;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;
using CommonConstants = Com.Suncor.Olt.Common.Utility.Constants;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class MainFormPresenterTest
    {
        private IMainForm mockView;
        private IMainUserStrip mockStrip;
        private MainFormPresenter presenter;
        private ISectionRegistry sectionRegistry;
        private IObjectLockingService mockObjectLockingService;
        private IRemoteEventRepeater eventRepeater;

        private ClientSession clientSession;
        private UserContext userContext;
        private IRoleElementService mockRoleElementService;
        private IRolePermissionService mockRolePermissionService;
        private IFunctionalLocationService mockFunctionalLocationService;
        private IUserLoginHistoryService mockLoginHistoryService;
        private IShiftPatternService mockShiftPatternService;
        private IApplicationService mockApplicationService;
        private IRoleDisplayConfigurationService mockRoleDisplayConfigurationService;
        private IRoleService mockRoleService;
        private IShiftHandoverService mockShiftHandoverService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private IMainFormSecurityManager mockMainFormSecurityManager;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            sectionRegistry = MockRepository.GenerateMock<ISectionRegistry>();
            mockView = MockRepository.GenerateMock<IMainForm>();
            mockStrip = MockRepository.GenerateMock<IMainUserStrip>();
            mockObjectLockingService = MockRepository.GenerateStub<IObjectLockingService>();
            eventRepeater = MockRepository.GenerateStub<IRemoteEventRepeater>();
            mockRoleElementService = MockRepository.GenerateMock<IRoleElementService>();
            mockRolePermissionService = MockRepository.GenerateMock<IRolePermissionService>();
            mockFunctionalLocationService = MockRepository.GenerateMock<IFunctionalLocationService>();
            mockLoginHistoryService = MockRepository.GenerateMock<IUserLoginHistoryService>();
            mockShiftPatternService = MockRepository.GenerateMock<IShiftPatternService>();
            mockApplicationService = MockRepository.GenerateMock<IApplicationService>();
            mockRoleDisplayConfigurationService = MockRepository.GenerateMock<IRoleDisplayConfigurationService>();
            mockRoleService = MockRepository.GenerateMock<IRoleService>();
            mockShiftHandoverService = MockRepository.GenerateMock<IShiftHandoverService>();
            mockSiteConfigurationService = MockRepository.GenerateMock<ISiteConfigurationService>();
            mockMainFormSecurityManager = MockRepository.GenerateStub<IMainFormSecurityManager>();

            List<FunctionalLocation> userSelectedFlocs 
                    = FunctionalLocationFixture.CreateNewListOfNewItems(6);

            clientSession = ClientSession.GetNewInstance();
            userContext = ClientSession.GetUserContext();

            userContext.SetSelectedFunctionalLocations(userSelectedFlocs, new List<FunctionalLocation>(), new List<FunctionalLocation>());
            User user = UserFixture.CreateUser(SiteFixture.Sarnia());
            user.Id = 1;
            userContext.User = user;

            mockView.BuildVersion = "BuildVersion";

            presenter = new MainFormPresenter(
                mockView, 
                sectionRegistry, 
                eventRepeater, 
                mockObjectLockingService, 
                mockRoleElementService, 
                mockRolePermissionService,
                mockFunctionalLocationService, 
                mockLoginHistoryService,
                mockShiftPatternService,
                mockApplicationService,
                mockRoleDisplayConfigurationService,
                mockRoleService, 
                mockShiftHandoverService,
                mockSiteConfigurationService,
                mockMainFormSecurityManager);
        }

        [TearDown]
        public void TearDown()
        {
            clientSession.CleanUpOldInstance();
            Clock.UnFreeze();
        }
       
        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsBeforeMidnight()
        {
            Clock.Now = new DateTime(2004, 2, 16, 23, 55, 55);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();
            
            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsStartOfNightShift()
        {
            Clock.Now = new DateTime(2004, 2, 16, 20, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsAfterMidnight()
        {
            Clock.Now = new DateTime(2004, 2, 17, 01, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsInNightShiftOverlap()
        {
            Clock.Now = new DateTime(2004, 2, 17, 19, 58, 00);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsDuringDayShift()
        {
            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldEnabledOperatingEngineerShiftLogReportMenuItemForSarnia()
        {
            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            Site site = SiteFixture.Sarnia();
            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldNotEnabledOperatingEngineerShiftLogReportMenuItemForDenver()
        {
            
            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;

            Site site = SiteFixture.Denver();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(user.AvailableSites[0]);
            userContext.SetSite(site, siteConfiguration);

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            userContext.User = user;
            userContext.UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            userContext.SetRole(RoleFixture.CreateOperatorRole(), userRoleElements,
                                                   new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            sectionRegistry.Expect(mock => mock.Clear());

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();

            mockStrip.FullName = user.FullName;
            mockStrip.Shift = shiftPattern.DisplayName;
            mockStrip.Site = userContext.Site.Name;
            mockStrip.Role = userContext.Role.Name;

            mockView.Expect(mock => mock.SelectedSection).Return(SectionKey.ActionItemSection);
            mockView.Expect(mock => mock.ClearNavigation());
            mockView.Expect(mock => mock.AddNavigation(SectionKey.PrioritiesSection));

            mockView.Expect(mock => mock.NavigateTo(SectionKey.ActionItemSection));

            // Execute:
            presenter.RefreshUserDataAndSecurity();

            sectionRegistry.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
            mockStrip.VerifyAllExpectations();
        }


        [Test]
        public void ClickingOnNavigationListViewShouldLoadCorrespondingPageAndChangeTitleOnView()
        {
            TestSection section = new TestSection();
            mockView.Expect(mock => mock.LoadSectionIntoMainContentPanel(section));
            mockView.Title = "who cares";

            sectionRegistry.Expect(mock => mock.GetSection(SectionKey.ActionItemSection)).Return(section);

            presenter.HandleSelectedSectionChanged(SectionKey.ActionItemSection);
        }

        [Test]
        public void ShouldLaunchMessageOnCurrentShiftHasEnded()
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.Create8HourDayShift();
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(shiftPattern);
            Clock.Now = shiftPattern.EndTime.Add(0, 2, 50).ToDateTime(Clock.DateNow);

            // Let's say shift end is at 20:00:00.
            // If the time now is 20:02:50, then with a 30 minute grace period,
            // we should have 00:27:10 left.
            mockView.Expect(mock => mock.LaunchEndOfShiftMessage(Clock.Now, new TimeSpan(0, 27, 10)));

            // Execute:
            presenter.HandleCurrentShiftHasEnded(null, EventArgs.Empty);
        }

        [Test]
        public void OnManageOpModeForUnitsToolStripMenuClickShouldOpenUpTheManageOpModeForm()
        {
            ObjectLockResult result = new ObjectLockResult(true, ClientSession.GetUserContext().User.IdValue, Clock.Now);

            mockView.Expect(mock => mock.DisplayManageOperationalModeForUnitsForm());
            mockObjectLockingService.Stub(mock => mock.GetLock(string.Empty, 0, string.Empty)).IgnoreArguments().Return(result);
            mockObjectLockingService.Stub(mock => mock.ReleaseLock(string.Empty)).IgnoreArguments();

            presenter.HandleManageOpModeForUnitsToolStripMenuClick(null, EventArgs.Empty);

            mockView.VerifyAllExpectations();
        }


        private void DisplayConfigurationFormWithLockDenied()
        {
            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            ClientSession.GetUserContext().User = currentUser;
            ObjectLockResult objectLockResult = new ObjectLockResult(false,
                                                                     currentUser.IdValue,
                                                                     currentUser.FullNameWithUserName,
                                                                     Clock.Now);
            mockObjectLockingService.Expect(mock => mock.GetLock(string.Empty, 0, string.Empty)).IgnoreArguments().Return(objectLockResult);
            mockView.Expect(mock => mock.LaunchLockDeniedMessage(string.Empty, string.Empty)).IgnoreArguments();
        }

        private void DisplayConfigurationFormWithLockAllowed(Action<IMainForm> action)
        {
            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            ClientSession.GetUserContext().User = currentUser;
            ObjectLockResult objectLockResult = new ObjectLockResult(true,
                                                                     currentUser.IdValue,
                                                                     currentUser.FullNameWithUserName,
                                                                     Clock.Now);
            mockObjectLockingService.Expect(mock => mock.GetLock(string.Empty, 0, string.Empty)).IgnoreArguments().Return(objectLockResult);

            mockView.Expect(action);
            mockObjectLockingService.Expect(mock => mock.ReleaseLock(string.Empty)).IgnoreArguments();

        }

        [Test]
        public void ShouldNotDisplayConfigGasLimitsFormWhenAnotherUserIsCurrentlyConfiguring()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigureGasTestElementInfoForm());
            presenter.HandleConfigGasTestElementInfoItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldDisplayConfigGasLimitsFormWhenNotLocked()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigGasTestElementInfoItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOpenConfigureWorkPermitArchivalProcessFormWhenItIsNotLocked()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigureWorkPermitArchivalProcessForm());
            presenter.HandleConfigureWorkPermitArchivalProcessMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();

        }

        [Test]
        public void ShouldLaunchLockingErrorWhenUnableToAcquiredLockOnConfigureWorkPermitArchivalProcess()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigureWorkPermitArchivalProcessMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOpenConfigAutoApproveSAPAIDFormWhenNotLocked()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigActionItemSettingsClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldLaunchLockingErrorWhenUnableToAcquireLockOnConfigAutoApproveSAPAIDForm()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigureActionItemsForm());
            presenter.HandleConfigActionItemSettingsClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void OnConfigureWorkPermitContractorClickShouldOpenConfigureSiteContractorForm()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigureWorkPermitContractorForm());
            presenter.HandleConfigureWorkPermitContractorClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void OnConfigureWorkPermitContractorClickShouldLaunchErrorIfConfigureSiteContractorFormLocked()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigureWorkPermitContractorClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOpenConfigurePHTagListFormOnHandleConffigurePHTagListClick()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigurePlantHistorianTagListForm());
            presenter.HandleConfigurePlantHistorianTagListMenuItemClicked(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotOpenConfigurePHTagListFormWhenLockIsNotAcquired()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigurePlantHistorianTagListMenuItemClicked(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void OnConfigureWorkCentersClickShouldOpenConfigureCraftsOrTradesForm()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayConfigureCraftOrTradeForm());
            presenter.HandleConfigureWorkCentersClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void OnConfigureWorkCentersClickShouldLaunchErrorIfConfigureSiteContractorFormLocked()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigureWorkCentersClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOpenAssignmentConfigurationFormOnHandleConfigureAssignmentMenuClick()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayAssignmentConfigurationForm());
            presenter.HandleConfigureAssignmentMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotOpenAssignmentConfigurationFormWhenLockIsNotAcquired()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigureAssignmentMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOpemAutoReApprovalByFieldIfNotLocked()
        {
            DisplayConfigurationFormWithLockAllowed(mock => mock.DisplayAssignmentConfigurationForm());
            presenter.HandleConfigureAssignmentMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotOpemAutoReApprovalByFieldIfLocked()
        {
            DisplayConfigurationFormWithLockDenied();
            presenter.HandleConfigureAssignmentMenuItemClick(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
        }


        [Test]
        public void ShouldGetSectionsForSelectedFlocs()
        {
            List<FunctionalLocation> selectedFlocs =
                new List<FunctionalLocation>
                    {
                        FunctionalLocationFixture.CreateNew("A"),
                        FunctionalLocationFixture.CreateNew("A-B"),
                        FunctionalLocationFixture.CreateNew("A-B-C"),
                        FunctionalLocationFixture.CreateNew("A-B-C-D"),
                        FunctionalLocationFixture.CreateNew("A-B-C-D-E"),
                        FunctionalLocationFixture.CreateNew("M-N-O"),
                        FunctionalLocationFixture.CreateNew("M-N-O-P"),
                        FunctionalLocationFixture.CreateNew("M-N-O-P-Q")
                    };

            const string section = "M-N";

            mockFunctionalLocationService.Expect(
                mock => mock.QueryByFullHierarchy(section, SiteFixture.Sarnia().IdValue)).Return(
                    FunctionalLocationFixture.CreateNew(section));

            List<FunctionalLocation> sections = presenter.GetSectionsForSelectedFunctionalLocations(SiteFixture.Sarnia(), selectedFlocs);
            Assert.AreEqual(2, sections.Count);
            Assert.IsTrue(sections.Exists(floc => floc.FullHierarchy == "A-B"));
            Assert.IsTrue(sections.Exists(floc => floc.FullHierarchy == section));

            mockView.VerifyAllExpectations();
        }

        private class TestSection : Control, ISection
        {
            public event Action<IItemSelectablePage> SelectedTabChanged { add { } remove { } }
            public event Action Selected { add {} remove {} }

            public bool GetSelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
            {
                return false;
            }

            public void DisposePages()
            {
            }

            public void AddPage(IItemSelectablePage page, IDomainPagePresenter pagePresenter, int defaultSelectOrder)
            {
            }

            public void SelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
            {
            }

            public void SelectSingleItem(DomainObject domainObject, bool suppressItemNotFoundMesage)
            {
            }

            public void OnSelect()
            {
            }

            public bool IsPageVisible(PageKey pageKey)
            {
                return false;
            }

            public IItemSelectablePage SelectedPage
            {
                get { return null; }
            }

            public IDomainPagePresenter SelectedPagePresenter
            {
                get { return null; }
            }
        }
    }
}
