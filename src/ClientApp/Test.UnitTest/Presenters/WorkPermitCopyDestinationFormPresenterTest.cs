using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using Com.Suncor.Olt.Client.Security;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitCopyDestinationFormPresenterTest
    {
        private Mockery mocks;
        private IWorkPermitCopyDestinationFormView view;
        private IWorkPermitService permitService;
        private IObjectLockingService objectLockingService;
        private IAuthorized authorized;

        private User currentUser;
        private List<FunctionalLocation> flocs;

        [SetUp]
        public void Initialize()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            // Setup mocks:
            mocks = new Mockery();
            view = mocks.NewMock<IWorkPermitCopyDestinationFormView>();
            permitService = mocks.NewMock<IWorkPermitService>();
            objectLockingService = mocks.NewMock<IObjectLockingService>();
            authorized = mocks.NewMock<IAuthorized>();

            // Setup objects used for testing:
            currentUser = new User(-15, null, null, null, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
            ClientSession.GetUserContext().User = currentUser;
            flocs = FunctionalLocationFixture.GetListWith2Units();
            ClientSession.GetUserContext().SetSelectedFunctionalLocations(flocs, new List<FunctionalLocation>(), new List<FunctionalLocation>());

            // Setup event registering expectations for presenter constructor:
            Expect.Once.On(view).EventAdd("LoadView", Is.Anything);
            Expect.Once.On(view).EventAdd("Copy", Is.Anything);
                       
        }
       
        [Test]
        public void ShouldLoadView()
        {
            Stub.On(authorized).Method("ToCopyToWorkPermit").Will(Return.Value(true));

            // Setup objects used for testing:
            List<FunctionalLocation> flocList = FunctionalLocationFixture.GetListWith2Units();
            ClientSession.GetUserContext().SetSelectedFunctionalLocations(flocList, new List<FunctionalLocation>(), new List<FunctionalLocation>());
            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection>(0);
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithGivenId(1);
            List<WorkPermit> candidatePermits = new List<WorkPermit>(0);

            // Expect service to be queried for editable permits matching functional locations:
            Expect.Once.On(permitService).Method("QueryEditablePermitsByFunctionalLocations").
                With(new PropertyMatcher("Flocs", IsList.Equal(flocList))).Will(Return.Value(candidatePermits));
            
            // Expect view to be loaded by presenter:
            Expect.Once.On(view).SetProperty("Title").To(Is.StringContaining(permit.PermitNumber));
            Expect.Once.On(view).SetProperty("CandidateWorkPermits").To(Is.Same(candidatePermits));

            // Execute:
            WorkPermitCopyDestinationFormPresenter presenter =
                new WorkPermitCopyDestinationFormPresenter(view,
                                                           permit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.LoadView(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCopyToSelectedWorkPermits()
        {
            // Setup objects for testing:
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-1);
            sourcePermit.CoauthorizationDescription = "Some string";
            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection>
                                                         {WorkPermitSection.NotificationAuthorization};
            WorkPermit selectedPermit = WorkPermitWithNoData();
            List<WorkPermit> selectedPermits = new List<WorkPermit> {selectedPermit};
            ObjectLockResult objectLockResult = new ObjectLockResult(true, currentUser.IdValue, new DateTime(2006, 1, 1));

            // Expect view to be asked for the selected work permits to copy to:
            Expect.Once.On(view).GetProperty("SelectedWorkPermits").Will(Return.Value(selectedPermits));

            SetExpectationsForLockingWorkPermit(objectLockResult, selectedPermit);

            // Expect work permit service to be called to update selected permit:
            Expect.Once.On(permitService).Method("CopyWorkPermit")
                .With(new OltIdMatcher<WorkPermit>(sourcePermit.IdValue),
                      new OltIdMatcher<WorkPermit>(selectedPermit.IdValue),
                      Is.EqualTo(sectionsToCopy),
                      Is.EqualTo(currentUser))
                .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            WorkPermitCopyDestinationFormPresenter presenter =
                new WorkPermitCopyDestinationFormPresenter(view, sourcePermit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.CopyToSelectedWorkPermits(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnCopyToSelectedWorkPermitsShouldShowWarningForDestinationPermitsThatAreNowUneditable()
        {
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-1);
            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection> { WorkPermitSection.NotificationAuthorization };

            WorkPermit selectedPermit1 = WorkPermitWithNoData();
            WorkPermit selectedPermit2 = WorkPermitWithNoData();
            List<WorkPermit> selectedPermits = new List<WorkPermit>(new[] { selectedPermit1, selectedPermit2 });
            Expect.Once.On(view).GetProperty("SelectedWorkPermits").Will(Return.Value(selectedPermits));

            ObjectLockResult objectLockResult = new ObjectLockResult(true, currentUser.IdValue, new DateTime(2006, 1, 1));
            SetExpectationsForLockingWorkPermit(objectLockResult, selectedPermit1);
            SetExpectationsForLockingWorkPermit(objectLockResult, selectedPermit2);

            Expect.Once.On(permitService).Method("CopyWorkPermit").
                With(new OltIdMatcher<WorkPermit>(sourcePermit.IdValue),
                     new OltIdMatcher<WorkPermit>(selectedPermit1.IdValue),
                     Is.EqualTo(sectionsToCopy),
                     Is.EqualTo(currentUser)).
                Will(Throw.Exception(new WorkPermitNotEditableException("234789", WorkPermitStatus.Complete)));
            Expect.Once.On(permitService).Method("CopyWorkPermit").
                With(new OltIdMatcher<WorkPermit>(sourcePermit.IdValue),
                     new OltIdMatcher<WorkPermit>(selectedPermit2.IdValue),
                     Is.EqualTo(sectionsToCopy),
                     Is.EqualTo(currentUser)).
                Will(Return.Value(new List<NotifiedEvent>()));
            
            const string COPY_WORK_PERMIT_ERROR_MESSAGE = "Copying could not be completed to the following permits because the status has been changed:";

            Expect.Once.On(view).Method("ShowWarningMessage").With(Is.StringContaining(COPY_WORK_PERMIT_ERROR_MESSAGE) &
                Is.StringContaining("234789") & Is.StringContaining(WorkPermitStatus.Complete.ToString()),
                Is.EqualTo(StringResources.UnsuccessfulCopiesTitle)).Will(Return.Value(DialogResult.OK));
            
            WorkPermitCopyDestinationFormPresenter presenter =
                new WorkPermitCopyDestinationFormPresenter(view, sourcePermit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.CopyToSelectedWorkPermits(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldRemoveAnyDestinationWorkPermitsThatTheUserIsNotAuthorizedToCopyTo()
        {
            Stub.On(view).SetProperty("Title");

            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection>();
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermit(6);
            WorkPermit authorizedWorkPermit1 = WorkPermitFixture.CreateWorkPermit(1);
            WorkPermit authorizedWorkPermit2 = WorkPermitFixture.CreateWorkPermit(2);
            WorkPermit authorizedWorkPermit3 = WorkPermitFixture.CreateWorkPermit(3);
            WorkPermit unAuthorizedWorkPermit1 = WorkPermitFixture.CreateWorkPermit(4);
            WorkPermit unAuthorizedWorkPermit2 = WorkPermitFixture.CreateWorkPermit(5);

            List<WorkPermit> workPermitsMatchingFunctionalLocations = new List<WorkPermit>
                                                                                    {
                                                                                        authorizedWorkPermit1,
                                                                                        unAuthorizedWorkPermit1,
                                                                                        authorizedWorkPermit2,
                                                                                        authorizedWorkPermit3,
                                                                                        unAuthorizedWorkPermit2
                                                                                    };

            List<WorkPermit> authenticatedWorkPermitsToCopyTo = new List<WorkPermit>
                                                                              {
                                                                                  authorizedWorkPermit1,
                                                                                  authorizedWorkPermit2,
                                                                                  authorizedWorkPermit3
                                                                              };

            Expect.Once.On(permitService).Method("QueryEditablePermitsByFunctionalLocations").Will(Return.Value(workPermitsMatchingFunctionalLocations));

            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            ClientSession.GetUserContext().SetRole(null, userRoleElements, new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            Expect.Once.On(authorized).Method("ToCopyToWorkPermit").With(userRoleElements, authorizedWorkPermit1, sourcePermit).Will(Return.Value(true));
            Expect.Once.On(authorized).Method("ToCopyToWorkPermit").With(userRoleElements, authorizedWorkPermit2, sourcePermit).Will(Return.Value(true));
            Expect.Once.On(authorized).Method("ToCopyToWorkPermit").With(userRoleElements, authorizedWorkPermit3, sourcePermit).Will(Return.Value(true));
            Expect.Once.On(authorized).Method("ToCopyToWorkPermit").With(userRoleElements, unAuthorizedWorkPermit1, sourcePermit).Will(Return.Value(false));
            Expect.Once.On(authorized).Method("ToCopyToWorkPermit").With(userRoleElements, unAuthorizedWorkPermit2, sourcePermit).Will(Return.Value(false));
            
            Expect.Once.On(view).SetProperty("CandidateWorkPermits").To(IsList.Equal(authenticatedWorkPermitsToCopyTo));

            WorkPermitCopyDestinationFormPresenter presenter = new WorkPermitCopyDestinationFormPresenter(view, sourcePermit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.LoadView(null, EventArgs.Empty);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldConfirmOverwriteIfDestinationPermitAlreadyHasData()
        {
            // Setup objects for testing:
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-1);
            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection>
                                                         {WorkPermitSection.NotificationAuthorization};
            WorkPermit selectedPermit = WorkPermitWithData();
            List<WorkPermit> selectedPermits = new List<WorkPermit> {selectedPermit};

            // Expect view to be asked for the selected work permits to copy to:
            Expect.Once.On(view).GetProperty("SelectedWorkPermits").Will(Return.Value(selectedPermits));

            // Expect view to be asked to pop up confirmation message (let's answer 'no'):
            Expect.Once.On(view).Method("ShowYesNoMessageBox").With(Is.Anything, Is.EqualTo("Overwrite?")).Will(Return.Value(DialogResult.No));

            // Execute:
            WorkPermitCopyDestinationFormPresenter presenter =
                new WorkPermitCopyDestinationFormPresenter(view, sourcePermit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.CopyToSelectedWorkPermits(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAlertUserIfObjectLockNotAcquired()
        {
            // Setup objects for testing:
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-1);
            List<WorkPermitSection> sectionsToCopy = new List<WorkPermitSection>();
            WorkPermit selectedPermit = WorkPermitWithNoData();
            List<WorkPermit> selectedPermits = new List<WorkPermit> {selectedPermit};
            const string usernameForLock = "Other user";
            ObjectLockResult objectLockResult = new ObjectLockResult(false, -63, usernameForLock, new DateTime(2006, 1, 1));

            // Expect view to be asked for the selected work permits to copy to:
            Expect.Once.On(view).GetProperty("SelectedWorkPermits").Will(Return.Value(selectedPermits));

            // Expect selected work permit to be locked for updating:
            Expect.Once.On(objectLockingService).Method("GetLock")
                .With(selectedPermit, currentUser.IdValue, ClientSession.GetInstance().GuidAsString)
                .Will(Return.Value(objectLockResult));

            // Expect message box since lock wasn't acquired:
            Expect.Once.On(view).Method("ShowMessageBox")
                .With(Is.StringContaining(usernameForLock),
                      Is.EqualTo("Conflict Detected"))
                .Will(Return.Value(DialogResult.OK));

            // Execute:
            WorkPermitCopyDestinationFormPresenter presenter =
                new WorkPermitCopyDestinationFormPresenter(view, sourcePermit, sectionsToCopy, permitService, objectLockingService, authorized);
            presenter.CopyToSelectedWorkPermits(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private WorkPermit WorkPermitWithNoData()
        {
            var permit = new WorkPermit(flocs[0].Site) {Id = (-2)};
            Assert.IsFalse(permit.HasData());
            return permit;
        }

        private WorkPermit WorkPermitWithData()
        {
            var permit = new WorkPermit(flocs[0].Site) { Id = (-3), CoauthorizationDescription = "Something" };
            Assert.IsTrue(permit.HasData());
            return permit;
        }

        private void SetExpectationsForLockingWorkPermit(ObjectLockResult objectLockResult, WorkPermit selectedPermit)
        {
            Expect.Once.On(objectLockingService).Method("GetLock")
                .With(selectedPermit, currentUser.IdValue, ClientSession.GetInstance().GuidAsString)
                .Will(Return.Value(objectLockResult));
            Expect.Once.On(objectLockingService).Method("ReleaseLock")
                .With(selectedPermit, currentUser.IdValue);
        }

        
    }
}
