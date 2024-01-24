using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class CopyWorkPermitFormPresenterTest
    {
        private Mockery mocks;
        private ICopyWorkPermitFormView view;
        private IWorkPermitCopyDestinationFormView workPermitCopyDestinationFormView;
        private IAuthorized authorized;
        private User currentUser;
        private WorkPermit permit;
        private UserRoleElements userRoleElements;
        private IObjectLockingService objectLockingService;
        private IWorkPermitService workPermitService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            view = mocks.NewMock<ICopyWorkPermitFormView>();
            workPermitCopyDestinationFormView = mocks.NewMock<IWorkPermitCopyDestinationFormView>();
            authorized = mocks.NewMock<IAuthorized>();
            currentUser = new User(-234, null, null, null, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
            userRoleElements = UserRoleElementsFixture.CreateEmpty();

            objectLockingService = mocks.NewMock<IObjectLockingService>();
            workPermitService = mocks.NewMock<IWorkPermitService>();
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());

            UserContext userContext = ClientSession.GetUserContext();
            userContext.User = currentUser;
            userContext.SetSite(SiteFixture.Sarnia(), null);
            userContext.SetRole(null, userRoleElements, new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            permit = WorkPermitFixture.CreateWorkPermitWithGivenId(-789);
            // Expect presenter to listen to view's events:
            Expect.Once.On(view).EventAdd("LoadView", Is.Anything);
            Expect.Once.On(view).EventAdd("Copy", Is.Anything);
            Expect.Once.On(view).EventAdd("Cancel", Is.Anything);
            Expect.Once.On(view).EventAdd("SelectAllSections", Is.Anything);
            Expect.Once.On(view).EventAdd("DeselectAllSections", Is.Anything);
        }

        [TearDown]
        public void TearDown()
        {         
        }

        [Test]
        public void ShouldEnableAndCheckOnSectionsBasedOnPermissionOnLoadView()
        {
            // Expect checking current user's permissions:
            Expect.AtLeastOnce.On(authorized).Method("ToCopyWorkPermitWithSomeRestrictions")
                    .With(userRoleElements).Will(Return.Value(true));
            Expect.AtLeastOnce.On(authorized).Method("ToCopyWorkPermitWithNoRestriction")
                    .With(userRoleElements).Will(Return.Value(false));
            // Expect loading basic info to view:
            Expect.Once.On(view).SetProperty("ShowCommunicationMethod").To(true);
            Expect.Once.On(view).SetProperty("ShowTools").To(false);  // site for this test is Sarnia
            Expect.Once.On(view).SetProperty("ShowAsbestos").To(true);  // site for this test is Sarnia
            Expect.Once.On(view).SetProperty("ShowRadiation").To(false);  // site for this test is Sarnia

            // Expect enabling and checking-on sections based on permissions:
            Expect.Once.On(view).SetProperty("ToolsEnabled").To(true);
            Expect.Once.On(view).SetProperty("ToolsChecked").To(false);
            Expect.Once.On(view).SetProperty("FireConfinedSpaceRequirementsEnabled").To(true);
            Expect.Once.On(view).SetProperty("FireConfinedSpaceRequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("RespiratoryProtectionRequirementsEnabled").To(true);
            Expect.Once.On(view).SetProperty("RespiratoryProtectionRequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("SpecialPPERequirementsEnabled").To(true);
            Expect.Once.On(view).SetProperty("SpecialPPERequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("SpecialPrecautionsOrConsiderationsEnabled").To(true);
            Expect.Once.On(view).SetProperty("SpecialPrecautionsOrConsiderationsChecked").To(true);
            Expect.Once.On(view).SetProperty("NotificationAuthorizationEnabled").To(true);
            Expect.Once.On(view).SetProperty("NotificationAuthorizationChecked").To(true);
            Expect.Once.On(view).SetProperty("MiscellaneousChecked").To(true);
            Expect.Once.On(view).SetProperty("MiscellaneousEnabled").To(true);
            Expect.Once.On(view).SetProperty("CommunicationMethodEnabled").To(true);
            Expect.Once.On(view).SetProperty("CommunicationMethodChecked").To(true);
            Expect.Once.On(view).SetProperty("EquipmentPreparationConditionEnabled").To(false);
            Expect.Once.On(view).SetProperty("EquipmentPreparationConditionChecked").To(false);
            Expect.Once.On(view).SetProperty("JobWorksitePreparationEnabled").To(false);
            Expect.Once.On(view).SetProperty("JobWorksitePreparationChecked").To(false);
            Expect.Once.On(view).SetProperty("RadiationInformationEnabled").To(false);
            Expect.Once.On(view).SetProperty("RadiationInformationChecked").To(false);
            Expect.Once.On(view).SetProperty("AsbestosEnabled").To(false);
            Expect.Once.On(view).SetProperty("AsbestosChecked").To(false);
            Expect.Once.On(view).SetProperty("GasTestsEnabled").To(false);
            Expect.Once.On(view).SetProperty("GasTestsChecked").To(false);
            Expect.Once.On(view).SetProperty("WorkPermitNumber");
            // Execute:
            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.LoadView(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableCommunicationMethodForSarnia()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            Stub.On(authorized).Method("ToCopyWorkPermitWithSomeRestrictions").With(userRoleElements).Will(Return.Value(true));
            Stub.On(authorized).Method("ToCopyWorkPermitWithNoRestriction").With(userRoleElements).Will(Return.Value(false));

            Expect.Once.On(view).SetProperty("ShowCommunicationMethod").To(true);
            Stub.On(view);

            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.LoadView(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableToolsForDenver()
        {
            Site denver = SiteFixture.Denver();
            ClientSession.GetUserContext().SetSite(denver, SiteConfigurationFixture.CreateDefaultSiteConfiguration(denver));
            Stub.On(authorized).Method("ToCopyWorkPermitWithSomeRestrictions").With(userRoleElements).Will(Return.Value(true));
            Stub.On(authorized).Method("ToCopyWorkPermitWithNoRestriction").With(userRoleElements).Will(Return.Value(false));

            Expect.Once.On(view).SetProperty("ShowTools").To(true);
            Stub.On(view);

            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.LoadView(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableCommunicationMethodSitesThatAreNotDenver()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            Stub.On(authorized).Method("ToCopyWorkPermitWithSomeRestrictions").With(userRoleElements).Will(Return.Value(true));
            Stub.On(authorized).Method("ToCopyWorkPermitWithNoRestriction").With(userRoleElements).Will(Return.Value(false));

            Expect.Once.On(view).SetProperty("ShowTools").To(false);
            Stub.On(view);

            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.LoadView(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCopySelectedSections()
        {
            // Expect asking the view for the sections selected for copying:
            Expect.Once.On(view).GetProperty("ToolsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("FireConfinedSpaceRequirementsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("RespiratoryProtectionRequirementsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("SpecialPPERequirementsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("SpecialPrecautionsOrConsiderationsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("NotificationAuthorizationChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("EquipmentPreparationConditionChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("JobWorksitePreparationChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("RadiationInformationChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("AsbestosChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("GasTestsChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("MiscellaneousChecked").Will(Return.Value(true));
            Expect.Once.On(view).GetProperty("CommunicationMethodChecked").Will(Return.Value(true));

            // Expect the section selection view to be closed if selections are OK:
            Expect.Once.On(view).Method("CloseView");

            // For use with the presenter that selects what work permits to copy to:
            IWorkPermitService workPermitService = mocks.NewMock<IWorkPermitService>();            
            IObjectLockingService objectLockingService = mocks.NewMock<IObjectLockingService>();
            
            // Execute:
            MockWorkPermitCopyDestinationFormView aselectWorkPermitView = new MockWorkPermitCopyDestinationFormView();
            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, aselectWorkPermitView, authorized, permit, objectLockingService, workPermitService);
            presenter.CopySelectedSections(null, EventArgs.Empty);
            aselectWorkPermitView.VerifyShowDialogCalled();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAlertUserIfNoSectionsSelectedForCopying()
        {
            // Expect asking the view for the sections selected for copying:
            Expect.Once.On(view).GetProperty("ToolsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("FireConfinedSpaceRequirementsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("RespiratoryProtectionRequirementsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("SpecialPPERequirementsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("SpecialPrecautionsOrConsiderationsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("NotificationAuthorizationChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("EquipmentPreparationConditionChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("JobWorksitePreparationChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("RadiationInformationChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("AsbestosChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("GasTestsChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("MiscellaneousChecked").Will(Return.Value(false));
            Expect.Once.On(view).GetProperty("CommunicationMethodChecked").Will(Return.Value(false));
            Expect.Once.On(view).Method("ShowDialog")
                    .With("Please select at least one section for copying.",
                          "No Sections Selected")
                    .Will(Return.Value(DialogResult.OK));

            IObjectLockingService objectLockingService = mocks.NewMock<IObjectLockingService>();

            // Execute:
            CopyWorkPermitFormPresenter presenter = new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.CopySelectedSections(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSelectAllAllowedSections()
        {
            // Expect checking current user's permissions:
            Expect.Once.On(authorized).Method("ToCopyWorkPermitWithSomeRestrictions")
                    .With(userRoleElements).Will(Return.Value(true));
            Expect.Once.On(authorized).Method("ToCopyWorkPermitWithNoRestriction")
                    .With(userRoleElements).Will(Return.Value(false));
            Expect.Once.On(view).SetProperty("ToolsChecked").To(false); // site for this test is Sarnia
            Expect.Once.On(view).SetProperty("FireConfinedSpaceRequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("RespiratoryProtectionRequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("SpecialPPERequirementsChecked").To(true);
            Expect.Once.On(view).SetProperty("SpecialPrecautionsOrConsiderationsChecked").To(true);
            Expect.Once.On(view).SetProperty("NotificationAuthorizationChecked").To(true);
            Expect.Once.On(view).SetProperty("MiscellaneousChecked").To(true);
            Expect.Once.On(view).SetProperty("CommunicationMethodChecked").To(true);
            Expect.Once.On(view).SetProperty("EquipmentPreparationConditionChecked").To(false);
            Expect.Once.On(view).SetProperty("JobWorksitePreparationChecked").To(false);
            Expect.Once.On(view).SetProperty("RadiationInformationChecked").To(false);
            Expect.Once.On(view).SetProperty("AsbestosChecked").To(false);
            Expect.Once.On(view).SetProperty("GasTestsChecked").To(false);
            // Execute:
            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.SelectAllSections(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDeselectAllAllowedSections()
        {
            Expect.Once.On(view).SetProperty("ToolsChecked").To(false);
            Expect.Once.On(view).SetProperty("FireConfinedSpaceRequirementsChecked").To(false);
            Expect.Once.On(view).SetProperty("RespiratoryProtectionRequirementsChecked").To(false);
            Expect.Once.On(view).SetProperty("SpecialPPERequirementsChecked").To(false);
            Expect.Once.On(view).SetProperty("SpecialPrecautionsOrConsiderationsChecked").To(false);
            Expect.Once.On(view).SetProperty("NotificationAuthorizationChecked").To(false);
            Expect.Once.On(view).SetProperty("MiscellaneousChecked").To(false);
            Expect.Once.On(view).SetProperty("EquipmentPreparationConditionChecked").To(false);
            Expect.Once.On(view).SetProperty("JobWorksitePreparationChecked").To(false);
            Expect.Once.On(view).SetProperty("RadiationInformationChecked").To(false);
            Expect.Once.On(view).SetProperty("AsbestosChecked").To(false);
            Expect.Once.On(view).SetProperty("CommunicationMethodChecked").To(false);
            Expect.Once.On(view).SetProperty("GasTestsChecked").To(false);
            // Execute:
            CopyWorkPermitFormPresenter presenter = new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.DeselectAllSections(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCloseViewWhenUserConfirmsCancel()
        {
            Expect.Once.On(view).Method("ConfirmCancelDialog").Will(Return.Value(true));
            Expect.Once.On(view).Method("CloseView");

            CopyWorkPermitFormPresenter presenter = new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.Cancel(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotCloseViewWhenUserDoesnotConfirmCancel()
        {
            Expect.Once.On(view).Method("ConfirmCancelDialog").Will(Return.Value(false));
            Expect.Never.On(view).Method("CloseView");
            CopyWorkPermitFormPresenter presenter =
                new CopyWorkPermitFormPresenter(view, workPermitCopyDestinationFormView, authorized, permit, objectLockingService, workPermitService);
            presenter.Cancel(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private class MockWorkPermitCopyDestinationFormView : IWorkPermitCopyDestinationFormView
        {
            private bool showDialogCalled;

            public DialogResult ShowDialog(IWin32Window owner)
            {
                showDialogCalled = true;
                return DialogResult.OK;
            }

            public void VerifyShowDialogCalled()
            {
                Assert.IsTrue(showDialogCalled);
            }

            public event EventHandler LoadView { add { } remove { } }
            public event EventHandler Copy { add { } remove { } }

            public string Title
            {
                set {}
            }

            public string Header
            {
                set {}
            }

            public List<WorkPermit> CandidateWorkPermits
            {
                set {}
            }

            public WorkPermit SelectedWorkPermit
            {
                get { return null; }
            }

            public List<WorkPermit> SelectedWorkPermits
            {
                get { return null; }
            }

            public DialogResult ShowMessageBox(string text, string caption)
            {
                return DialogResult.Ignore;
            }

            public DialogResult ShowWarningMessage(string text, string caption)
            {
                return DialogResult.Ignore;
            }

            public DialogResult ShowYesNoMessageBox(string text, string caption)
            {
                return DialogResult.Ignore;
            }
        }
    }
}