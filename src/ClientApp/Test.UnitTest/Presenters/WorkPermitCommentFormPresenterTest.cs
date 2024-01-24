using System;
using System.Collections.Generic;
using System.Text;
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
    public class WorkPermitCommentFormPresenterTest
    {
        private WorkPermitCommentFormPresenter presenter;
        private readonly Mockery mocks = new Mockery();
        private IWorkPermitCloseFormView mockView;
        private IWorkPermitService mockService;
        private WorkPermit selectedWorkPermit;
        private List<WorkPermit> selectedWorkPermits;
        private User user;
        private Role role;
        private UserShift userShift;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

            mockService = mocks.NewMock<IWorkPermitService>();

            selectedWorkPermit = WorkPermitFixture.CreateWorkPermit();
            selectedWorkPermits = new List<WorkPermit>(new[] {selectedWorkPermit});

            mockView = (IWorkPermitCloseFormView) mocks.NewMock(typeof (IWorkPermitCloseFormView));

            SetUpExpectationsForRegisterForEvents();
            presenter = new WorkPermitCommentFormPresenter(mockView, selectedWorkPermits, mockService);

            userShift = UserShiftFixture.CreateUserShift();
            ClientSession.GetUserContext().UserShift = userShift;

            user = Fixtures.UserFixture.CreateOperator(ClientSession.GetUserContext());
            role = ClientSession.GetUserContext().Role;
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void LoadFormShouldSetUserAndWorkPermitInformationOnCommentView()
        {
            Expect.Once.On(mockView).SetProperty("Author").To(user);
            Expect.Once.On(mockView).SetProperty("CreateDateTime").To(Clock.Now);
            Expect.Once.On(mockView).SetProperty("Shift").To(userShift.ShiftPatternName);
            Expect.Once.On(mockView).SetProperty("Description").To(selectedWorkPermit.Description());

            OltStub.On(mockView);

            presenter.LoadForm(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LoadFormShouldCheckAndDisableCreateLogCheckBox()
        {
            Expect.Once.On(mockView).SetProperty("FormTitle").To("Comment For Safe Work Permit");
            Expect.Once.On(mockView).SetProperty("CreateLogChecked").To(true);
            Expect.Once.On(mockView).Method("EnableLogCreatedWithComments");
            Expect.Once.On(mockView).SetProperty("CreateLogEnabled").To(false);

            OltStub.On(mockView);
            presenter.LoadForm(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void SubmitShouldInsertGeneralLog()
        {
            const string comment = "comment";
            Expect.Once.On(mockView).GetProperty("Comment").Will(Return.Value(comment));
            Expect.Once.On(mockView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));

            string logMessage = BuildExpectedLogMessageString(comment);
            Expect.Once.On(mockService).Method("InsertLog")
                .With(Is.EqualTo(selectedWorkPermit), Is.EqualTo(user), Is.EqualTo(logMessage), Is.EqualTo(userShift.ShiftPattern),
                     Is.EqualTo(false), Is.EqualTo(selectedWorkPermit.WorkAssignment), Is.EqualTo(role))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockView).Method("SaveSucceededMessage");

            OltStub.On(mockView);
            presenter.Submit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void SubmitShouldInsertOperatingEngineerLog()
        {
            const string comment = "comment";
            Expect.Once.On(mockView).GetProperty("Comment").Will(Return.Value(comment));
            Expect.Once.On(mockView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(true));

            string logMessage = BuildExpectedLogMessageString(comment);            
            Expect.Once.On(mockService).Method("InsertLog")
                .With(Is.EqualTo(selectedWorkPermit), Is.EqualTo(user), Is.EqualTo(logMessage), Is.EqualTo(userShift.ShiftPattern),
                     Is.EqualTo(true), Is.EqualTo(selectedWorkPermit.WorkAssignment), Is.EqualTo(role))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockView).Method("SaveSucceededMessage");

            OltStub.On(mockView);
            presenter.Submit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CommentFormShouldDisableOperatingEngineerLogForDenver()
        {
            Site denverSite = SiteFixture.Denver();
            User supervisor = UserFixture.CreateSupervisor(denverSite);
            ClientSession.GetNewInstance();
            UserContext userContext = ClientSession.GetUserContext();

            userContext.User = supervisor;
            userShift = UserShiftFixture.CreateUserShift();
            userContext.UserShift = userShift;
            Site site = supervisor.AvailableSites[0];

            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            SetUpExpectationsForRegisterForEvents();

            presenter = new WorkPermitCommentFormPresenter(mockView, selectedWorkPermits, mockService);
            
            Expect.Once.On(mockView).Method("HideOperatingEngineerLogCheckbox");            
            OltStub.On(mockView);

            presenter.LoadForm(null, null);
            presenter.CreateLogCheckedChanged(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private string BuildExpectedLogMessageString(string comment)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(String.Format("New Comments: {0}", comment));
            builder.AppendLine();
            builder.Append(selectedWorkPermit.Description());

            return builder.ToString();
        }

        private void SetUpExpectationsForRegisterForEvents()
        {
            Expect.Once.On(mockView).EventAdd("FormClosing", Is.Anything);
            Expect.Once.On(mockView).EventAdd("Load", Is.Anything);
            Expect.Once.On(mockView).EventAdd("SubmitButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CancelButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CreateLogCheckedChanged", Is.Anything);
        }
    }
}