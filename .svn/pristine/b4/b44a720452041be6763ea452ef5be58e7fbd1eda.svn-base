using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class SignInFormPresenterTest
    {
        private Mockery mocks;
        private ISignInFormView mockView;
        private SignInFormPresenter presenter;
        private ISecurityService mockSecurityService;
        private IObjectLockingService mockLockService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<ISignInFormView>();
            mockSecurityService = mocks.NewMock<ISecurityService>();
            mockLockService = mocks.NewMock<IObjectLockingService>();

            Version localVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Stub.On(mockSecurityService).Method("GetAssemblyVersion").Will(Return.Value(localVersion));

            Stub.On(mockLockService).Method("ReleaseLock");

            presenter = new SignInFormPresenter(mockView, mockSecurityService, mockLockService);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ClickingTheSignInButtonShouldPassUsernameAndPasswordToTheSecurityServiceAndSetFormAuthenticationToTrueOnSuccess()
        {
            User supervisor = UserFixture.CreateSupervisor();
            Stub.On(mockSecurityService).Method("Authenticate")
                    .WithAnyArguments()
                    .Will(Return.Value(supervisor));
            Expect.Once.On(mockView).SetProperty("Authenticated").To(LoginResult.Success);
            Stub.On(mockView).GetProperty("Password").Will(Return.Value(string.Empty));
            Stub.On(mockView);
            presenter.SignInButtonClickEvent(null, new EventArgs());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetAuthenticatedToInvalidUsernamePasswordWhenNoUserIsFound()
        {
            Expect.Once.On(mockSecurityService).Method("Authenticate")
                    .WithAnyArguments()
                    .Will(Return.Value(null));

            Expect.Once.On(mockView).SetProperty("Authenticated").To(LoginResult.InvalidUsernamePassword);
            Stub.On(mockView).GetProperty("Password").Will(Return.Value(string.Empty));
            Stub.On(mockView);
            presenter.SignInButtonClickEvent(null, new EventArgs());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetAuthenicatedToIncompleteUserWhenMissingSiteRoleDataInUser()
        {
            List<SiteRolePlant> emptySiteAndRole = new List<SiteRolePlant>();
            User user = new User(1, "username", "firstname", "lastname", emptySiteAndRole, "sapId", null, null, null,
                                DateTimeFixture.DateTimeNow);

            Stub.On(mockSecurityService).Method("Authenticate")
                    .WithAnyArguments()
                    .Will(Return.Value(user));

            Expect.Once.On(mockView).SetProperty("Authenticated").To(LoginResult.IncompleteUser);
            Stub.On(mockView).GetProperty("Password").Will(Return.Value(string.Empty));
            Stub.On(mockView);

            presenter.SignInButtonClickEvent(null, new EventArgs());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }


    }
}