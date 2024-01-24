using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetDefinitionCommentsFormPresenterTest
    {
        private ICommentsFormView mockCommentsFormView;
        private Mockery mocks;
        private TargetDefinitionCommentsFormPresenter presenter;
        private TargetDefinition respondTo;
        private ITargetDefinitionService mockService;
        private ILogService mockLogService;        

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();
            mocks = new Mockery();
            mockCommentsFormView = mocks.NewMock<ICommentsFormView>();
            mockService = mocks.NewMock<ITargetDefinitionService>();
            mockLogService = mocks.NewMock<ILogService>();

            ClientSession.GetUserContext().User = UserFixture.CreateSupervisor();
            ClientSession.GetUserContext().UserShift = CreateTestUserShift();
            ClientSession.GetUserContext().SetRole(RoleFixture.CreateOperatorRole(), null, new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            ClientSession.GetUserContext().SetSite(SiteFixture.Oilsands(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Oilsands()));

            respondTo = TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            respondTo.Id = 5; //fake the save

            Expect.Once.On(mockCommentsFormView).EventAdd("Load", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("FormClosing", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("SubmitButtonClick", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("CancelButtonClick", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("CreateLogCheckedChanged", Is.Anything);
                              
            presenter = new TargetDefinitionCommentsFormPresenter(
                mockCommentsFormView, 
                respondTo,
                mockService, 
                mockLogService);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldSetSummaryViewOnFormLoad()
        {
            bool isLogRequired = false;
            Stub.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(isLogRequired));

            Expect.Once.On(mockCommentsFormView).SetProperty("Title").To(
                TargetDefinitionCommentsFormPresenter.FORM_TITLE);
            Expect.Once.On(mockCommentsFormView).SetProperty("Author").To(ClientSession.GetUserContext().User);
            Expect.Once.On(mockCommentsFormView).SetProperty("CreateDateTime").To(Clock.Now);
            Expect.Once.On(mockCommentsFormView).SetProperty("ShiftName").To(
                ClientSession.GetUserContext().UserShift.ShiftPatternName);
            Expect.Once.On(mockCommentsFormView).SetProperty("SummaryView")
                .To(new TypeMatcher(typeof (ITargetSummaryView)));
            Expect.Once.On(mockCommentsFormView).SetProperty("IsLogAnOperatingEngineeringLog").To(false);

            presenter.HandleFormLoad(null, EventArgs.Empty);
        }

        [Test]
        public void SubmitButtonShouldCallUpdateMethodForServiceWithoutCreatingALog()
        {
            Expect.Once.On(mockCommentsFormView).GetProperty("UserComments").Will(Return.Value("Some Comments"));
            Expect.Once.On(mockService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(false));
            Expect.Once.On(mockCommentsFormView).Method("SaveSucceededMessage");
            presenter.HandleSubmitButtonClick(null, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void SubmitButtonShouldCallUpdateMethodForServiceAndCreateALog()
        {
            string comment = "Comment for changing the status";

            Expect.AtLeast(2).On(mockCommentsFormView).GetProperty("UserComments").Will(
                Return.Value(comment));
            
            Expect.Once.On(mockService).Method("Update")
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(true));
            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(true));
            Expect.Once.On(mockCommentsFormView).Method("SaveSucceededMessage");
//            Expect.Once.On(mockShiftService).Method("GetShiftBySiteAndDateTime").With(respondTo.FunctionLocation, Clock.TimeNow);
            Expect.Once.On(mockLogService).Method("Insert")
                .With(new OltPropertyMatcher<Log>("RtfComments", new StringContainsMatcher(comment)))
                .Will(Return.Value(new List<NotifiedEvent>()));

            presenter.HandleSubmitButtonClick(null, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        private UserShift CreateTestUserShift()
        {
            return new UserShift(ShiftPatternFixture.Create8HourDayShift(), new DateTime(2006, 1, 1, 8, 0, 0));
        }
    }
}
