using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
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
    public class ActionItemDefinitionCommentsFormPresenterTest
    {
        private ICommentsFormView mockCommentsFormView;
        private Mockery mocks;
        private ActionItemDefinitionCommentsFormPresenter presenter;
        private ActionItemDefinition respondTo;
        private IActionItemDefinitionService mockActionItemService;
        private ILogService mockLogService;        

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();
            mocks = new Mockery();
            mockCommentsFormView = mocks.NewMock<ICommentsFormView>();
            mockActionItemService = mocks.NewMock<IActionItemDefinitionService>();
            mockLogService = mocks.NewMock<ILogService>();            

            respondTo = ActionItemDefinitionFixture.CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(1);
            UserContext userContext = ClientSession.GetUserContext();
            userContext.User = respondTo.LastModifiedBy;
            userContext.UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            userContext.SetRole(RoleFixture.CreateSupervisorRole(), null, new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            userContext.SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia()));

            Expect.Once.On(mockCommentsFormView).EventAdd("Load", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("FormClosing", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("SubmitButtonClick", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("CancelButtonClick", Is.Anything);
            Expect.Once.On(mockCommentsFormView).EventAdd("CreateLogCheckedChanged", Is.Anything);

        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void SubmitButtonShouldUpdateActionItemDefinitionWithoutCreatingALog()
        {            
            presenter = new ActionItemDefinitionCommentsFormPresenter(mockCommentsFormView, respondTo, mockActionItemService, mockLogService);

            Expect.Once.On(mockCommentsFormView).GetProperty("UserComments")
                .Will(Return.Value("Comment for changing the status"));
            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(false));
            Expect.Once.On(mockCommentsFormView).Method("SaveSucceededMessage");

            Expect.Once.On(mockActionItemService).Method("Update").With(ActionItemDefinitionWithId(respondTo.Id))
                .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            presenter.HandleSubmitButtonClick(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void SubmitButtonShouldCallUpdateMethodForServiceAndCreateALogWithAssociationToActionItemDefn()
        {            
            presenter = new ActionItemDefinitionCommentsFormPresenter(mockCommentsFormView, respondTo, mockActionItemService, 
                mockLogService);

            const string comment = "Comment for changing the status";
            Expect.AtLeast(2).On(mockCommentsFormView).GetProperty("UserComments").Will(Return.Value(comment));

            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(true));
            Expect.Once.On(mockCommentsFormView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(true));
            Expect.Once.On(mockCommentsFormView).Method("SaveSucceededMessage");

            Expect.Once.On(mockActionItemService).Method("Update").With(ActionItemDefinitionWithId(respondTo.Id))
                .Will(Return.Value(new List<NotifiedEvent>()));

            Expect.Once.On(mockLogService).Method("InsertActionItemDefinition")
                .With(LogWithComment(comment), ActionItemDefinitionWithId(respondTo.Id))
                .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            presenter.HandleSubmitButtonClick(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnFormLoadIfSiteConfigurationDoesNotAllowOperatingEngineerLogsThenDisableCheckBox()
        {
            Stub.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(true));
            Stub.On(mockCommentsFormView);

            respondTo = ActionItemDefinitionFixture.CreatePendingActionItemDefinitionForDenver();
            ClientSession.GetUserContext().User = respondTo.LastModifiedBy;
            ClientSession.GetUserContext().UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();

            Expect.Once.On(mockCommentsFormView).SetProperty("IsLogAnOperatingEngineeringLog").To(false);

            presenter =
                new ActionItemDefinitionCommentsFormPresenter(mockCommentsFormView, respondTo, mockActionItemService, mockLogService);

            presenter.HandleFormLoad(null, null);
        }

        [Test]
        public void OnFormLoadIfSiteConfigurationAllowsOperatingEngineerLogsThenEnableCheckBox()
        {
            Stub.On(mockCommentsFormView).GetProperty("IsLogRequired").Will(Return.Value(true));
            Stub.On(mockCommentsFormView);

            respondTo = ActionItemDefinitionFixture.CreatePendingActionItemDefinitionForDenver();
            ClientSession.GetUserContext().User = respondTo.LastModifiedBy;
            ClientSession.GetUserContext().UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();

            Expect.Once.On(mockCommentsFormView).SetProperty("IsLogAnOperatingEngineeringLog").To(true);

            presenter =
                new ActionItemDefinitionCommentsFormPresenter(mockCommentsFormView, respondTo, mockActionItemService, mockLogService);

            presenter.HandleFormLoad(null, null);
        }

        private static Matcher ActionItemDefinitionWithId(long? id)
        {
            return new OltIdMatcher<ActionItemDefinition>(id.Value);
        }

        private static Matcher LogWithComment(string comment)
        {
            return new OltPropertyMatcher<Log>("RtfComments", new StringContainsMatcher(comment));
        }
    }
}