using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class AbstractResponseFormPresenterTest
    {
        private Mockery mocks;
        private IRespondFormView mockRespondFormView;
        private FakeRespondFormPresenter presenter;

        private const string CREATE_LOG_CHECKED = "CreateLogChecked";
        private const string DISABLE_COMMENTS_METHOD = "DisableLogCreatedWithComments";
        private const string ENABLE_COMMENTS_METHOD = "EnableLogCreatedWithComments";
        private const string SAVE_SUCCEEDED_MESSAGE ="SaveSucceededMessage";

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            mocks = new Mockery();
            mockRespondFormView = mocks.NewMock<IRespondFormView>();
            presenter = CreateFakePresenter();

            Stub.On(mockRespondFormView).SetProperty("DialogResult");
        }

        [Test]
        public void CreateLogShouldBeSetToTrueByDefaultInTheAbstractClass()
        {
            FakeRespondFormPresenter presenter = new FakeRespondFormPresenter();
            Assert.AreEqual(true, presenter.CreateLogs);
        }

        [Test]
        public void CreateLogCheckBoxInViewShouldBeSetToTrueOnLoad()
        {
            UserContext context = ClientSession.GetUserContext();
            context.UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            context.User = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            Expect.Once.On(mockRespondFormView).SetProperty(CREATE_LOG_CHECKED).To(true);
            Stub.On(mockRespondFormView).SetProperty("Author");
            Stub.On(mockRespondFormView).SetProperty("CreateDateTime");
            Stub.On(mockRespondFormView).SetProperty("Shift");

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenTheCreateLogsBooleanIsSetThenOnCreateLogCheckedChangedShouldDisableCommentsOnTheView()
        {
            Expect.Once.On(mockRespondFormView).Method(DISABLE_COMMENTS_METHOD);
            
            presenter.HandleCreateLogCheckedChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenTheCreateLogsBooleanIsNotSetThenOnCreateLogCheckedChangedShouldEnableCommentsOnTheView()
        {
            Expect.Once.On(mockRespondFormView).Method(ENABLE_COMMENTS_METHOD);

            presenter.CreateLogs = false;

            presenter.HandleCreateLogCheckedChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void IfCreateLogFlagIsTrueThenCreateALog()
        {
            FakeRespondFormPresenter presenter = CreateFakePresenter();
            presenter.CreateLogs = true;
            presenter.CreatedALog = false;
            Expect.Once.On(mockRespondFormView).Method(SAVE_SUCCEEDED_MESSAGE);
            Expect.Once.On(mockRespondFormView).Method("Close");
            presenter.HandleSubmitButtonClick(null, EventArgs.Empty);

            Assert.AreEqual(true, presenter.CreatedALog);
        }

        [Test]
        public void IfCreateLogFlagIsFalseThenDoNotCreateALog()
        {
            FakeRespondFormPresenter presenter = CreateFakePresenter();
            presenter.CreateLogs = false;
            presenter.CreatedALog = true; // just to make sure it changes
            Expect.Once.On(mockRespondFormView).Method(SAVE_SUCCEEDED_MESSAGE);
            Expect.Once.On(mockRespondFormView).Method("Close");
            presenter.HandleSubmitButtonClick(null, EventArgs.Empty);

            Assert.AreEqual(false, presenter.CreatedALog);
        }

        private FakeRespondFormPresenter CreateFakePresenter()
        {
            FakeRespondFormPresenter presenter = new FakeRespondFormPresenter {View = mockRespondFormView};
            return presenter;
        }

        class FakeRespondFormPresenter : AbstractRespondFormPresenter
        {
            public bool CreatedALog;

            public FakeRespondFormPresenter()
            {
                CreatedALog = false;
            }

            public bool CreateLogs
            {
                set { createLogs = value; }
                get { return createLogs; }
            }

            protected override bool SaveWithLog()
            {
                CreatedALog = true;
                return true;
            }

            protected override bool SaveWithoutLog()
            {
                CreatedALog = false;
                return true;
            }
        }
    }
}
