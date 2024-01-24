using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitCloseFormPresenterTest
    {
        private WorkPermitCloseFormPresenter presenter;
        private Mockery mockery;
        private IWorkPermitCloseFormView mockView;
        private WorkPermit selectedWorkPermit;
        private List<WorkPermit> selectedWorkPermits;
        private IWorkPermitService mockWorkPermitService;
        private UserShift userShift;
        private User user;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

            mockery = new Mockery();
            selectedWorkPermit = WorkPermitFixture.CreateWorkPermit();
            mockView = (IWorkPermitCloseFormView)mockery.NewMock(typeof(IWorkPermitCloseFormView));
            mockWorkPermitService = (IWorkPermitService)mockery.NewMock(typeof(IWorkPermitService));
                
            SetUpExpectationsForRegisterForEvents();

            selectedWorkPermits = new List<WorkPermit>(new[] {selectedWorkPermit});

            userShift = UserShiftFixture.CreateUserShift();
            UserContext userContext = ClientSession.GetUserContext();
            userContext.UserShift = userShift;
            user = Fixtures.UserFixture.CreateOperator(userContext);
            Site site = user.AvailableSites[0];
            userContext.SetSite(site, SiteConfigurationFixture.CreateSiteConfiguration());

            presenter = new WorkPermitCloseFormPresenter(mockView, selectedWorkPermits, mockWorkPermitService);
            
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void CopyToLogCheckboxShouldDefaultToUnchecked()
        {
            Stub.On(mockView).SetProperty("Author");
            Stub.On(mockView).SetProperty("CreateDateTime");
            Stub.On(mockView).SetProperty("Shift");
            Stub.On(mockView).SetProperty("Description");
            Stub.On(mockView).SetProperty("IsLogAnOperatingEngineeringLog");
            Stub.On(mockView).SetProperty("OperatingEngineerLogDisplayText");
            
            Expect.Once.On(mockView).SetProperty("CreateLogChecked").To(false);
            Expect.Once.On(mockView).SetProperty("FormTitle").To("Close Safe Work Permit");
            Expect.Once.On(mockView).SetProperty("CreateLogEnabled").To(true);

            
            presenter.LoadForm(null, EventArgs.Empty);
        }
        
        [Test]
        public void ShouldSaveWithLogOnSubmitIfLogIsChecked()
        {
            Expect.Once.On(mockWorkPermitService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockWorkPermitService).Method("InsertLog").Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockView).GetProperty("CreateLogChecked").Will(Return.Value(true)); // set checked to "true"
            Expect.Once.On(mockView).GetProperty("Comment"); // get the comment to save to the log
            Expect.Once.On(mockView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("SaveSucceededMessage");                        
            presenter.Submit(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LogShouldBeSaved()
        {
            Expect.Once.On(mockWorkPermitService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockView).GetProperty("CreateLogChecked").Will(Return.Value(true)); // set checked to "true"
            Expect.Once.On(mockView).GetProperty("Comment");
            Expect.Once.On(mockView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("SaveSucceededMessage");

            Expect.Once.On(mockWorkPermitService).Method("InsertLog")
                .Will(Return.Value(new List<NotifiedEvent>()));

            presenter.Submit(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void LoadFormShouldSetUserAndWorkPermitInformationOnCommentView()
        {
            Expect.Once.On(mockView).SetProperty("CreateLogChecked").To(false);
            Expect.Once.On(mockView).SetProperty("Author").To(user);
            Expect.Once.On(mockView).SetProperty("CreateDateTime").To(Clock.Now);
            Expect.Once.On(mockView).SetProperty("Shift").To(userShift.ShiftPatternName);
            Expect.Once.On(mockView).SetProperty("Description").To(selectedWorkPermit.Description());
            Stub.On(mockView).SetProperty("FormTitle");
            Expect.Once.On(mockView).SetProperty("CreateLogEnabled").To(true);
            Stub.On(mockView).SetProperty("IsLogAnOperatingEngineeringLog");
            Stub.On(mockView).SetProperty("OperatingEngineerLogDisplayText");

            presenter.LoadForm(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }                

        private void SetUpExpectationsForRegisterForEvents()
        {
            Expect.Once.On(mockView).EventAdd("FormClosing", Is.Anything);
            Expect.Once.On(mockView).EventAdd("Load", Is.Anything);
            Expect.Once.On(mockView).EventAdd("SubmitButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CancelButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CreateLogCheckedChanged", Is.Anything);
        }
        
        [Test]
        public void ShouldDisableOperatingLogCheckBoxForDenver()
        {
            SetUpExpectationsForRegisterForEvents();
            Site site = SiteFixture.Denver();
            UserContext userContext = ClientSession.GetUserContext();

            userContext.User = UserFixture.CreateSupervisor(site);
            userContext.UserShift = UserShiftFixture.CreateUserShift();
            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            Expect.Once.On(mockView).Method("EnableMakingAnOperatingEngineerLog").With(false);
            OltStub.On(mockView);

            presenter = new WorkPermitCloseFormPresenter(mockView, selectedWorkPermits, mockWorkPermitService);
            presenter.LoadForm(null, null);
            
            presenter.CreateLogCheckedChanged(null, null);

        }
    }
}
