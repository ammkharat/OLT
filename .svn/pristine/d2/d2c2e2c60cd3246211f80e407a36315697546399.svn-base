using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class SAPNotificationFormPresenterTest
    {
        private SAPNotificationFormPresenter presenter;
        private ISAPNotificationFormView viewMock;
        private ISAPNotificationService sapNotificationServiceMock;
        private ISiteConfigurationService siteConfigurationServiceMock;
        private Mockery mock;
        private SAPNotification sapNotification;

        public const string CLEAR_ERROR_PROVIDERS = "ClearErrorProviders";
        public const string COMMENTS = "Comments";
        public const string SET_DESCRIPTION_BLANK_ERROR = "SetCommentsBlankError";

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            mock = new Mockery();
            viewMock = mock.NewMock<ISAPNotificationFormView>();
            sapNotificationServiceMock = mock.NewMock<ISAPNotificationService>();
            sapNotification = SAPNotificationFixture.GetAWorkRequestFortMcMurrayNotification();

            siteConfigurationServiceMock = mock.NewMock<ISiteConfigurationService>();

            presenter = new SAPNotificationFormPresenter(viewMock, sapNotification, sapNotificationServiceMock);

            ShiftPattern shiftPattern = ShiftPatternFixture.Create8HourAfterNoonShift();

            Clock.Freeze();
            Clock.Now = new DateTime(2005, 12, 12, 14, 05, 00, 00);
            var userShift = new UserShift(shiftPattern, Clock.Now);
            ClientSession.GetNewInstance();

            UserContext userContext = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateOperatorOltUser1InFortMcMurrySite(userContext);
            userContext.UserShift = userShift;
        
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnFalseWithValidDescription()
        {
            Expect.Once.On(viewMock).GetProperty(COMMENTS).Will(Return.Value("Some valid test data"));
            Expect.Once.On(viewMock).Method(CLEAR_ERROR_PROVIDERS);
            Assert.IsFalse(presenter.ValidateViewHasError());
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldReturnTrueAndSetErrorMessageWithInvalidComments()
        {
            Expect.Once.On(viewMock).GetProperty(COMMENTS).Will(Return.Value(""));
            Expect.Once.On(viewMock).Method(CLEAR_ERROR_PROVIDERS);
            Expect.Once.On(viewMock).Method(SET_DESCRIPTION_BLANK_ERROR);
            Assert.IsTrue(presenter.ValidateViewHasError());
            mock.VerifyAllExpectationsHaveBeenMet();
        }

//        [Test]
//        public void BuildSAPNotificationShould()
//        {
//            Expect.Once.On(viewMock).GetProperty(COMMENTS).Will(Return.Value(sapNotification.Description));
//            Expect.Once.On(viewMock).GetProperty("CreateDateTime").Will(Return.Value(sapNotification.CreationDateTime));
//            presenter.BuildSAPNotification(sapNotification);
//            mock.VerifyAllExpectationsHaveBeenMet();
//        }

        [Test]
        public void TestOperatorLogButtonIsDiabledOnLoadForDenver()
        {
            Site site = SiteFixture.Denver();
            User user = UserFixture.CreateSupervisor(site);
            ShiftPattern shiftPattern = ShiftPatternFixture.Create8HourAfterNoonShift();

            Clock.Freeze();
            Clock.Now = new DateTime(2005, 12, 12, 14, 05, 00, 00);
            var userShift = new UserShift(shiftPattern, Clock.Now);
            ClientSession.GetNewInstance();

            UserContext userContext = ClientSession.GetUserContext();
            userContext.UserShift = userShift;
            userContext.User = user;
            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            presenter = new SAPNotificationFormPresenter(viewMock, sapNotification, sapNotificationServiceMock);

            //Expect.Once.On(viewMock).Method("DisableSaveAndImportAsOperatingEngineer");
            //HideSaveAndImportAsOperatingEngineer
            Stub.On(viewMock);
            presenter.HandleFormLoad(null, null);
        }
    }
}