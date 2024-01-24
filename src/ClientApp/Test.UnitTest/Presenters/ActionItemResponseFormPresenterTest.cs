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

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ActionItemResponseFormPresenterTest
    {
        private Mockery mocks;
        private ActionItemResponseFormPresenter presenter;

        private ActionItem respondTo;
        private IActionItemService mockActionItemService;
        private ILogService mockLogService;        
        private IActionItemResponseFormView mockActionItemResponseFormView;

        private const string ACTION_SERVICE_UPDATE = "Update";
        private const string SELECTED_STATUS = "SelectedStatus";
        private const string SAVE_SUCCEEDED_MESSAGE = "SaveSucceededMessage";

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();
            mocks = new Mockery();
            mockActionItemResponseFormView = mocks.NewMock<IActionItemResponseFormView>();

            mockActionItemService = mocks.NewMock<IActionItemService>();            
            mockLogService = mocks.NewMock<ILogService>();

            respondTo = ActionItemFixture.CreateAPendingActionItemWithIdPassedIn(1);
            UserContext userContext = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateOperator(1, "Eric Liu", userContext);
            userContext.UserShift = UserShiftFixture.CreateUserShift();
            
            Site siteWideServices = SiteFixture.SiteWideServices();
            userContext.SetSite(siteWideServices, SiteConfigurationFixture.CreateDefaultSiteConfiguration(siteWideServices));
            
            Stub.On(mockActionItemResponseFormView).Method("ClearErrors");
            Stub.On(mockActionItemResponseFormView).SetProperty("DialogResult");
            
            //presenter = new ActionItemResponseFormPresenter(
            //    mockActionItemResponseFormView,
            //    respondTo,
            //    mockActionItemService, 
            //    mockLogService) {View = mockActionItemResponseFormView};
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
            public void SaveRoutineSavesActionItemAndALogWhenCommentOnlySetToFalseAndCommentIsNotNull()
        {
            Expect.Once.On(mockActionItemResponseFormView).GetProperty(SELECTED_STATUS).Will(
                Return.Value(ActionItemStatus.Complete));
            Expect.AtLeast(1).On(mockActionItemResponseFormView).GetProperty("Comment").Will(
                Return.Value("Comment for changing the status"));
            
            Expect.AtLeast(1).On(mockActionItemResponseFormView).GetProperty("CommentOnly").Will(Return.Value(false));
            Expect.Once.On(mockActionItemResponseFormView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));
            Expect.Once.On(mockActionItemResponseFormView).Method(SAVE_SUCCEEDED_MESSAGE);
            Expect.Once.On(mockActionItemResponseFormView).Method("Close");

            Expect.Once.On(mockActionItemService).Method(ACTION_SERVICE_UPDATE)
                .Will(Return.Value(new List<NotifiedEvent>()));

            presenter.HandleSubmitButtonClick(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();            
        }

        [Test]
        public void ShouldBuildStatusMessageWithCorrectActionItemStatus()
        {
            Stub.On(mockActionItemResponseFormView).GetProperty(SELECTED_STATUS).Will(Return.Value(ActionItemStatus.Complete));
            Stub.On(mockActionItemResponseFormView).GetProperty("Comment").Will(Return.Value("Comment for changing the status"));
            Stub.On(mockActionItemResponseFormView).GetProperty("CommentOnly").Will(Return.Value(false));
            Stub.On(mockActionItemResponseFormView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));
            Stub.On(mockActionItemResponseFormView).Method(SAVE_SUCCEEDED_MESSAGE);
            Stub.On(mockActionItemResponseFormView).Method("Close");

            Assert.AreEqual(ActionItemStatus.Current, respondTo.Status);
            const string expectedMessage = @"Action Item Name: This is my name
Status: Complete
Comments: Comment for changing the status
Description: Test Action Item Instance Pending
";


            /*
             * "Action Item Name: This is my name
            Status: Complete
            Comments: Comment for changing the status
            Description: Test Action Item Instance Pending
            ", 
             */

            Expect.Once.On(mockActionItemService).Method(ACTION_SERVICE_UPDATE).With(
                new AlwaysTrueMatcher(),
                new EqualMatcher(expectedMessage),
                new AlwaysTrueMatcher(),
                new AlwaysTrueMatcher(),
                new AlwaysTrueMatcher(),
                new AlwaysTrueMatcher())
                .Will(Return.Value(new List<NotifiedEvent>()));

            presenter.HandleSubmitButtonClick(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void SaveRoutineSavesALogWhenCommentOnlySetToTrueAndCommentIsNotNull()
        {
            Expect.AtLeast(1).On(mockActionItemResponseFormView).GetProperty("Comment").Will(
                Return.Value("Comment for changing the status"));
            
            Expect.AtLeast(1).On(mockActionItemResponseFormView).GetProperty("CommentOnly").Will(Return.Value(true));
            Expect.Once.On(mockActionItemResponseFormView).GetProperty("IsLogAnOperatingEngineeringLog").Will(Return.Value(false));
            Expect.Once.On(mockLogService).Method("InsertForActionItem")
                .With(new OltPropertyMatcher<Log>("RtfComments", TestUtil.IsStringContaining(                    
                     respondTo.Name,                                                                                   
                     respondTo.Description)),
                      new OltPropertyMatcher<ActionItem>("Id", respondTo.Id))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockActionItemResponseFormView).Method(SAVE_SUCCEEDED_MESSAGE);
            Expect.Once.On(mockActionItemResponseFormView).Method("Close");

            presenter.HandleSubmitButtonClick(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldForceCreateLogAndLockStatusDropdownWhenCommentOnlyChecked()
        {
            // Simulate checking 'Comment Only':
            Expect.Once.On(mockActionItemResponseFormView)
                .GetProperty("CommentOnly").Will(Return.Value(true));

            // When the user checks 'Comment Only', we force them to have to create a log entry,
            // without affecting the current status.

            // Create log should be forced to true and then disabled:
            Expect.Once.On(mockActionItemResponseFormView).SetProperty("CreateLogChecked").To(true);
            Expect.Once.On(mockActionItemResponseFormView).SetProperty("CreateLogEnabled").To(false);

            // User must be able to type in comments:
            Expect.Once.On(mockActionItemResponseFormView).Method("EnableLogCreatedWithComments");
            Expect.Once.On(mockActionItemResponseFormView).Method("EnableOperatingEngineerLogCheckbox");
            Expect.Once.On(mockActionItemResponseFormView).SetProperty("OperatingEngineerLogDisplayText").To(
                new AlwaysTrueMatcher());


            // Status must be reset to original and locked down:
            Expect.Once.On(mockActionItemResponseFormView).SetProperty("SelectedActionItemStatus").To(respondTo.Status);
            Expect.Once.On(mockActionItemResponseFormView).Method("DisableReasonCodeDropDown");

            // Execute:
            presenter.HandleCommentOnlyCheckedChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAllowCreateLogAndEnableStatusDropdownWhenCommentOnlyUnchecked()
        {
            // Simulate un-checking 'Comment Only':
            Expect.Once.On(mockActionItemResponseFormView)
                .GetProperty("CommentOnly").Will(Return.Value(false));

            Expect.Once.On(mockActionItemResponseFormView).SetProperty("CreateLogEnabled").To(true);
            Expect.Once.On(mockActionItemResponseFormView).Method("EnableReasonCodeDropDown");
            Expect.Once.On(mockActionItemResponseFormView).Method("EnableOperatingEngineerLogCheckbox");
            Expect.Once.On(mockActionItemResponseFormView).SetProperty("OperatingEngineerLogDisplayText").To(
                new AlwaysTrueMatcher());

            // Execute:
            presenter.HandleCommentOnlyCheckedChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldShowErrorIfNoCommentSuppliedWhenCommentOnlyChecked()
        {
            Expect.Once.On(mockActionItemResponseFormView)
                .GetProperty("CommentOnly").Will(Return.Value(true));
            Expect.Once.On(mockActionItemResponseFormView)
                .GetProperty("Comment").Will(Return.Value(string.Empty));

            // Expect an error:
            Expect.Once.On(mockActionItemResponseFormView).Method("ShowCommentOnlyError");

            // Execute:
            presenter.HandleSubmitButtonClick(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
