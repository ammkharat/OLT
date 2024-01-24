using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NMock2.Syntax;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetDefinitionFormPresenterTest
    {
        private const string NAME_PROP = "Name";
        private const string FUNCTIONAL_LOCATION_PROP = "FunctionalLocation";
        private const string DESCRIPTION_PROP = "Description";
        private const string TAGINFO_PROP = "TagInfo";
        private const string MAXVALUE_PROP = "MaxValue";
        private const string MINVALUE_PROP = "MinValue";
        private const string NTEMAXVALUE_PROP = "NeverToExceedMaximum";
        private const string NTEMINVALUE_PROP = "NeverToExceedMinimum";
        private const string HAS_SCHEDULE_ERROR_PROP = "HasScheduleError";
        private const string CLEAR_ERRORS_METHOD = "ClearErrorProviders";
        private const string SHOW_DESCRIPTION_IS_EMPTY_ERROR = "ShowDescriptionIsEmptyError";
        private const string SHOW_NAME_IS_EMPTY_ERROR = "ShowNameIsEmptyError";
        private const string SHOW_NO_FLOC_SELECTED_ERROR = "ShowNoFunctionalLocationsSelectedError";
        private const string SHOW_NAME_ERROR = "ShowNameError";
        private const string SHOW_NO_TAGINFO_SELECTED_ERROR = "ShowNoTagInfoSelectedError";
        private const string SHOW_ALL_VALUES_ARE_EMPTY_ERROR = "ShowAllValuesAreEmptyError";
        private const string SHOW_MAX_SHOULD_BE_GREATER_THAN_MIN_ERROR = "ShowMaxValueShouldBeGreaterThanMinValueError";

        private const string SHOW_MAX_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR =
            "ShowMaxValueShouldBeGreaterThanNTEMinValueError";

        private const string SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR =
            "ShowNTEMaxValueShouldBeGreaterThanNTEMinValueError";

        private const string SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_MAX_ERROR =
            "ShowNTEMaxValueShouldBeGreaterThanMaxError";

        private const string SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_MIN_ERROR =
            "ShowNTEMaxValueShouldBeGreaterThanMinError";

        private const string SHOW_MIN_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR =
            "ShowMinValueShouldBeGreaterThanNTEMinError";

        private const string REQUIRES_APPROVAL = "RequiresApproval";
        private const string IS_ACTIVE_CHECK_BOX_ENABLED = "IsActiveCheckBoxEnabled";
        private const string IS_ACTIVE = "IsActive";
        private const string REQUIRES_RESPONSE_WHEN_ALERTED = "RequiresResponseWhenAlerted";
        private const string IS_ALERT_REQUIRED = "IsAlertRequired";
        private const string SUPPRESS_ALERT_CHECKBOX_ENABLED = "SuppressAlertCheckBoxEnabled";
        private ActionItemDefinitionGenerator actionItemDefinitionGenerator;
        private FakeTargetDefinitionFormPresenter createPresenter;
        private User currentUser;
        private FakeTargetDefinitionFormPresenter editPresenter;
        private TargetDefinition editTargetDefinition;
        private FunctionalLocation floc;
        private IPlantHistorianService mockPlantHistorianService;
        private ITargetDefinitionService mockService;
        private ITargetDefinitionFormView mockView;
        private IWorkAssignmentService mockWorkAssignmentService;
        private Mockery mocks;
        private TargetDefinition parentTargetDefinition;
        private TagInfo tagInfo;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();
            editTargetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            editTargetDefinition.DocumentLinks.AddRange(DocumentLinkFixture.CreateDocumentListOfTwo());
            editTargetDefinition.DocumentLinks[0].Id = 1;
            editTargetDefinition.DocumentLinks[1].Id = 2;

            parentTargetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2);
            parentTargetDefinition.Schedule.StartDate = editTargetDefinition.Schedule.StartDate.AddDays(2);
            parentTargetDefinition.Schedule.EndDate = parentTargetDefinition.Schedule.StartDate.AddDays(20);

            mocks = new Mockery();
            mockView = mocks.NewMock<ITargetDefinitionFormView>();
            mockService = mocks.NewMock<ITargetDefinitionService>();
            mockPlantHistorianService = mocks.NewMock<IPlantHistorianService>();
            mockWorkAssignmentService = mocks.NewMock<IWorkAssignmentService>();
            floc = FunctionalLocationFixture.GetAny_Unit1();
            tagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();

            ClientSession.GetNewInstance();
            currentUser = editTargetDefinition.LastModifiedBy;
            var userContext = ClientSession.GetUserContext();
            userContext.SetRole(RoleFixture.CreateOperatorRole(), UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            userContext.User = currentUser;
            var site = SiteFixture.Sarnia();

            userContext.SetSite(currentUser.AvailableSites[0],
                SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            actionItemDefinitionGenerator = new ActionItemDefinitionGenerator(mockService);
            createPresenter = new FakeTargetDefinitionFormPresenter(mockView,
                TargetDefinitionFormPresenter.CreateDefaultTargetDefinition(), mockService, mockPlantHistorianService,
                mockWorkAssignmentService);
            editPresenter = new FakeTargetDefinitionFormPresenter(mockView, editTargetDefinition, mockService,
                mockPlantHistorianService, mockWorkAssignmentService);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldColorAutoReApproveFieldsWhenUserCannotApproveAndEditing()
        {
            var targetDefConfig =
                ClientSession.GetUserContext().SiteConfiguration.TargetDefinitionAutoReApprovalConfiguration;

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> {WorkAssignment.NoneWorkAssignment}));

            Expect.Once.On(mockView).SetProperty("NameChangeRequiresReApproval").To(targetDefConfig.NameChange);
            Expect.Once.On(mockView).SetProperty("CategoryChangeRequiresReApproval").To(targetDefConfig.CategoryChange);
            Expect.Once.On(mockView)
                .SetProperty("OperationalModeChangeRequiresReApproval")
                .To(targetDefConfig.OperationalModeChange);
            Expect.Once.On(mockView).SetProperty("PriorityChangeRequiresReApproval").To(targetDefConfig.PriorityChange);
            Expect.Once.On(mockView)
                .SetProperty("DescriptionChangeRequiresReApproval")
                .To(targetDefConfig.DescriptionChange);
            Expect.Once.On(mockView)
                .SetProperty("DocumentLinksChangeRequiresReApproval")
                .To(targetDefConfig.DocumentLinksChange);
            Expect.Once.On(mockView)
                .SetProperty("FunctionalLocationChangeRequiresReApproval")
                .To(targetDefConfig.FunctionalLocationChange);
            Expect.Once.On(mockView).SetProperty("PHTagChangeRequiresReApproval").To(targetDefConfig.PHTagChange);
            Expect.Once.On(mockView)
                .SetProperty("TargetDependenciesChangeRequiresReApproval")
                .To(targetDefConfig.TargetDependenciesChange);
            Expect.Once.On(mockView).SetProperty("ScheduleChangeRequiresReApproval").To(targetDefConfig.ScheduleChange);
            Expect.Once.On(mockView)
                .SetProperty("GenerateActionItemChangeRequiresReApproval")
                .To(targetDefConfig.GenerateActionItemChange);
            Expect.Once.On(mockView)
                .SetProperty("RequiresResponseWhenAlertedChangeRequiresReApproval")
                .To(targetDefConfig.RequiresResponseWhenAlertedChange);
            Expect.Once.On(mockView)
                .SetProperty("SuppressAlertChangeRequiresReApproval")
                .To(targetDefConfig.SuppressAlertChange);
            Stub.On(mockView);

            editPresenter.HandleFormLoad(null, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableAndUnCheckIsActiveCheckBoxOnCheckingRequiresApproval()
        {
            Expect.Once.On(mockView).GetProperty(REQUIRES_APPROVAL).Will(Return.Value(true));
            Expect.Once.On(mockView).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(false);
            Expect.Once.On(mockView).SetProperty(IS_ACTIVE).To(false);
            createPresenter.HandleRequiresApprovalCheckBoxCheckedChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableAndUnCheckSuppressAlertCheckboxIfRequiresResponseWhenAlertedIsChecked()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty(REQUIRES_RESPONSE_WHEN_ALERTED).Will(Return.Value(true));
            Expect.Once.On(mockView).SetProperty(IS_ALERT_REQUIRED).To(true);
            Expect.Once.On(mockView).SetProperty(SUPPRESS_ALERT_CHECKBOX_ENABLED).To(true);
            createPresenter.SetStateForSuppressAlertCheckbox();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableConfigurePreApprovedTargetRangesWhenSelectedTagInfoIsNull()
        {
            const TagInfo nullTag = null;
            var dialogResultAndOutput = new DialogResultAndOutput<TagInfo>(DialogResult.OK, nullTag);
            Expect.Once.On(mockView).Method("ShowTagSelector").Will(Return.Value(dialogResultAndOutput));
            Expect.Once.On(mockView).SetProperty("ConfigurePreApprovedTargetRangesEnabled").To(false);
            Stub.On(mockView);
            editPresenter.SearchTagClickEvent(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableReadWriteConfigButtonWhenNameTextboxIsEmpty()
        {
            Expect.Once.On(mockView).GetProperty("Name").Will(Return.Value(""));
            Expect.Once.On(mockView).SetProperty("ReadWriteConfigurationEnabled").To(Is.EqualTo(false));
            editPresenter.HandleNameChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableRefreshTagValueButtonAndStateTagValueIsUnavailableWhenSelectedTagIsNotReadable()
        {
            Stub.On(mockView).Method("ShowTagSelector").Will(
                Return.Value(new DialogResultAndOutput<TagInfo>(DialogResult.OK, tagInfo)));

            Expect.Once.On(mockView).GetProperty("TagInfo").Will(Return.Value(tagInfo));
            Expect.Once.On(mockPlantHistorianService).Method("CanReadTagValue").With(tagInfo).Will(Return.Value(false));
            Expect.Once.On(mockView).SetProperty("TagValueEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("TagValue").To("Unavailable");

            Stub.On(mockView);

            editPresenter.SearchTagClickEvent(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableRefreshTagValueButtonAndStateTagValueIsUnavailableWhenSelectedTagIsNull()
        {
            const TagInfo nullTag = null;
            Stub.On(mockView)
                .Method("ShowTagSelector")
                .Will(Return.Value(new DialogResultAndOutput<TagInfo>(DialogResult.OK, nullTag)));

            Expect.Once.On(mockView).SetProperty("TagValueEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("TagValue").To("Unavailable");

            Stub.On(mockView);

            editPresenter.SearchTagClickEvent(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableViewEditHistoryForExistingTargetDefinition()
        {
            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> {WorkAssignment.NoneWorkAssignment}));

            Expect.Once.On(mockView).SetProperty("ViewEditHistoryEnabled").To(false);
            Stub.On(mockView);
            createPresenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayReadWriteConfigScreenWhenConfigButtonClickedAndNotUpdateViewIfCanceled()
        {
            var mockPHReadWriteConfigForm = mocks.NewMock<ITargetDefinitionReadWriteTagConfigurationView>();
            SetGetterExpectation(editTargetDefinition);
            Expect.Once.On(mockView)
                .Method("DisplayReadWriteConfigurationForm")
                .WithAnyArguments()
                .Will(Return.Value(mockPHReadWriteConfigForm));
            Expect.Once.On(mockPHReadWriteConfigForm).Method("ShowDialog").Will(Return.Value(DialogResult.Cancel));


            Expect.Once.On(mockView).GetProperty("HasScheduleError").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("ClearScheduleErrors");

            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));

            editPresenter.HandleConfigureReadWriteTagButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayReadWriteConfigScreenWhenConfigButtonClickedAndUpdateViewIfOkay()
        {
            var readWriteConfig =
                TargetDefinitionReadWriteTagConfigurationFixture.CreateConfigurationWithOnlyReadTypesForTagA1Values();
            var mockPHReadWriteConfigForm = mocks.NewMock<ITargetDefinitionReadWriteTagConfigurationView>();
            SetGetterExpectation(editTargetDefinition);
            Expect.Once.On(mockView)
                .Method("DisplayReadWriteConfigurationForm")
                .WithAnyArguments()
                .Will(Return.Value(mockPHReadWriteConfigForm));
            Expect.Once.On(mockPHReadWriteConfigForm).Method("ShowDialog").Will(Return.Value(DialogResult.OK));
            Expect.Once.On(mockPHReadWriteConfigForm)
                .GetProperty("ReadWriteTagsConfiguration")
                .Will(Return.Value(readWriteConfig));

            Expect.Once.On(mockView).GetProperty("HasScheduleError").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("ClearScheduleErrors");


            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));
            AssertPopulateViewForReadWriteConfigurations(readWriteConfig);
            editPresenter.HandleConfigureReadWriteTagButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableAndUnCheckedIsActiveCheckBoxOnUnCheckingRequiresApproval()
        {
            Expect.Once.On(mockView).GetProperty(REQUIRES_APPROVAL).Will(Return.Value(false));
            Expect.Once.On(mockView).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(true);
            Expect.Never.On(mockView).SetProperty(IS_ACTIVE);
            createPresenter.HandleRequiresApprovalCheckBoxCheckedChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableReadWriteConfigButtonWhenNameTextboxIsNotEmpty()
        {
            Expect.Once.On(mockView).GetProperty("Name").Will(Return.Value("Anything"));
            Expect.Once.On(mockView).SetProperty("ReadWriteConfigurationEnabled").To(Is.EqualTo(true));
            editPresenter.HandleNameChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableSuppressAlertCheckboxIfRequiresResponseWhenAlertedIsNotChecked()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty(REQUIRES_RESPONSE_WHEN_ALERTED).Will(Return.Value(false));
            Expect.Once.On(mockView).SetProperty(IS_ALERT_REQUIRED).To(true);
            Expect.Once.On(mockView).SetProperty(SUPPRESS_ALERT_CHECKBOX_ENABLED).To(false);
            createPresenter.SetStateForSuppressAlertCheckbox();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableViewEditHistoryForExistingTargetDefinition()
        {
            Expect.Once.On(mockView).SetProperty("ViewEditHistoryEnabled").To(true);
            Stub.On(mockView);
            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> {WorkAssignment.NoneWorkAssignment}));

            editPresenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailIfAllValuesAreEmpty()
        {
            string[] expectedErrorMethodNames = {SHOW_ALL_VALUES_ARE_EMPTY_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    null,
                    null,
                    null,
                    null,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfDescriptionIsEmpty()
        {
            string[] expectedErrorMethodNames = {SHOW_DESCRIPTION_IS_EMPTY_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    string.Empty,
                    true,
                    floc,
                    tagInfo,
                    2,
                    1,
                    2,
                    1,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfFLOCIsNotSet()
        {
            string[] expectedErrorMethodNames = {SHOW_NO_FLOC_SELECTED_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    null,
                    tagInfo,
                    2,
                    1,
                    2,
                    1,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfMaxIsGreaterThanNTEMax()
        {
            string[] expectedErrorMethodNames =
            {
                SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_MAX_ERROR
            };
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    200,
                    null,
                    100,
                    null,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfMaxIsLessThanMin()
        {
            string[] expectedErrorMethodNames = {SHOW_MAX_SHOULD_BE_GREATER_THAN_MIN_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    100,
                    200,
                    null,
                    null,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfMaxIsLessThanNTEMin()
        {
            string[] expectedErrorMethodNames =
            {
                SHOW_MAX_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR
            };
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    100,
                    null,
                    null,
                    200,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfMinIsLessThanNTEMin()
        {
            string[] expectedErrorMethodNames =
            {
                SHOW_MIN_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR
            };
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    null,
                    100,
                    null,
                    200,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfNTEMaxIsLessThanMin()
        {
            string[] expectedErrorMethodNames =
            {
                SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_MIN_ERROR
            };
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    null,
                    200,
                    100,
                    null,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfNTEMaxIsLessThanNTEMin()
        {
            string[] expectedErrorMethodNames =
            {
                SHOW_NTE_MAX_SHOULD_BE_GREATER_THAN_NTE_MIN_ERROR
            };
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    null,
                    null,
                    100,
                    200,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfNameIsEmpty()
        {
            string[] expectedErrorMethodNames = {SHOW_NAME_IS_EMPTY_ERROR};
            ValidateViewHasErrorTest
                (
                    string.Empty,
                    "Some Description",
                    true,
                    floc,
                    tagInfo,
                    2,
                    1,
                    2,
                    1,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfNameIsNotValid()
        {
            string[] expectedErrorMethodNames = {SHOW_NAME_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    false,
                    floc,
                    tagInfo,
                    2,
                    1,
                    2,
                    1,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldFailIfTagInfoIsNotSet()
        {
            string[] expectedErrorMethodNames = {SHOW_NO_TAGINFO_SELECTED_ERROR};
            ValidateViewHasErrorTest
                (
                    "Some Name",
                    "Some Description",
                    true,
                    floc,
                    null,
                    2,
                    1,
                    2,
                    1,
                    false,
                    expectedErrorMethodNames
                );
        }

        [Test]
        public void ShouldGrabSelectedTagAndSetWithValueAfterHandlingSearchTagClickEvent()
        {
            Expect.Once.On(mockView).Method("ShowTagSelector").Will(
                Return.Value(new DialogResultAndOutput<TagInfo>(DialogResult.OK, tagInfo)));
            Expect.Once.On(mockView).SetProperty("TagInfo").To(tagInfo);
            Expect.Once.On(mockView).SetProperty("ConfigurePreApprovedTargetRangesEnabled").To(true);
            ExpectationsForSettingTagValue();
            editPresenter.SearchTagClickEvent(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldLoadApprovedFalseRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(TargetDefinitionStatus.Approved, false, false);
        }

        [Test]
        public void ShouldLoadApprovedFalseRequiresApprovalAndTrueActive()
        {
            ShouldSetValuesToViewOnLoad(TargetDefinitionStatus.Approved, false, true);
        }

        [Test]
        public void ShouldLoadPendingTrueRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(TargetDefinitionStatus.Pending, true, false);
        }

        [Test]
        public void ShouldLoadRejectedTrueRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(TargetDefinitionStatus.Rejected, true, false);
        }

        [Test]
        public void ShouldLoadTagValueWhenEditingExistingTarget()
        {
            ExpectationsForSettingTagValue();
            Stub.On(mockView);

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> {WorkAssignment.NoneWorkAssignment}));

            editPresenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotShowTheActionItemDefinitionFormOnInsert()
        {
            editTargetDefinition.RequiresApproval = true;
            StubViewMock();
            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(new NotifiedEvent(ApplicationEvent.TargetDefinitionCreate,
                TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1)));
            Stub.On(mockService).Method("Insert").Will(Return.Value(notifiedEvents));
            Stub.On(mockService)
                .Method("QueryById")
                .Will(Return.Value(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1)));

            createPresenter.Insert(new SaveUpdateDomainObjectContainer<TargetDefinition>(editTargetDefinition));
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotShowTheActionItemDefinitionFormOnUpdate()
        {
            editTargetDefinition.RequiresApproval = true;
            StubViewMock();
            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));

            Stub.On(mockService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            editPresenter.Update(new SaveUpdateDomainObjectContainer<TargetDefinition>(editTargetDefinition));
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldPopulateViewWithDefaultsForNewTargetDefinitionOnFormLoad()
        {
            var defaultValuedTarget = TargetDefinitionFixture.CreateTargetDefinitionWithDefaultValuesForView(currentUser);
            SetOnFormLoadExpectation(defaultValuedTarget);

            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> { WorkAssignment.NoneWorkAssignment }));

            var presenter = new TargetDefinitionFormPresenter(mockView, defaultValuedTarget, mockService,
                mockPlantHistorianService, mockWorkAssignmentService);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldRefreshTagValueWhenButtonClicked()
        {
            ExpectationsForSettingTagValue();
            editPresenter.HandleRefreshTagValueButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldShowActionItemDefinitionFormOnInsertWhenAutoGenerateAIDIsSet()
        {
            editTargetDefinition.GenerateActionItem = true;
            editTargetDefinition.RequiresApproval = false;
            Stub.On(mockService)
                .Method("GetHistory")
                .With(editTargetDefinition.Id)
                .Will(Return.Value(new List<TargetDefinitionHistory>()));
            var generatedAID = actionItemDefinitionGenerator.BuildActionItemDefinition(editTargetDefinition);
            StubViewMock();
            Expect.Once.On(mockView).Method("ShowActionItemDefinitionForm").With(generatedAID);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(new NotifiedEvent(ApplicationEvent.TargetDefinitionCreate, editTargetDefinition));
            Stub.On(mockService).Method("Insert").Will(Return.Value(notifiedEvents));
            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));

            editPresenter.Insert(new SaveUpdateDomainObjectContainer<TargetDefinition>(editTargetDefinition));
            editPresenter.SaveOrUpdateComplete_Public(true);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldShowActionItemDefinitionFormOnUpdateWhenAutoGenerateAIDIsSet()
        {
            editTargetDefinition.GenerateActionItem = true;
            editTargetDefinition.RequiresApproval = false;
            Stub.On(mockService)
                .Method("GetHistory")
                .With(editTargetDefinition.Id)
                .Will(Return.Value(new List<TargetDefinitionHistory>()));
            var generatedAID = actionItemDefinitionGenerator.BuildActionItemDefinition(editTargetDefinition);
            StubViewMock();
            Expect.Once.On(mockView).Method("ShowActionItemDefinitionForm").With(generatedAID);
            Stub.On(mockService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));

            editPresenter.Update(new SaveUpdateDomainObjectContainer<TargetDefinition>(editTargetDefinition));
            editPresenter.SaveOrUpdateComplete_Public(true);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void UpdateEditTargetDefinitionFromViewOnUpdate()
        {
            SetGetterExpectation(editTargetDefinition);
            Stub.On(mockService).Method("QueryById").Will(Return.Value(editTargetDefinition));
            Expect.Once.On(mockService).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));

            var container = editPresenter.GetPopulatedEditObjectToUpdate_Public();
            editPresenter.Update(container);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfTargetValueIsGreaterThanMaximum()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("TargetValue").Will(Return.Value(500.0m));
            Expect.AtLeastOnce.On(mockView).GetProperty("MaxValue").Will(Return.Value(30.0m));
            Expect.Once.On(mockService).Method("IsValidName").Will(Return.Value(Error.HasNoError));
            StubOnValidationProperties();

            var hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfTargetValueIsGreaterThanNeverToExceedMaximum()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("TargetValue").Will(Return.Value(500.0m));
            Expect.AtLeastOnce.On(mockView).GetProperty("NeverToExceedMaximum").Will(Return.Value(30.0m));
            Expect.Once.On(mockService).Method("IsValidName").Will(Return.Value(Error.HasNoError));
            StubOnValidationProperties();

            var hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfTargetValueIsLessThanMinimum()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("TargetValue").Will(Return.Value(20.0m));
            Expect.AtLeastOnce.On(mockView).GetProperty("MinValue").Will(Return.Value(30.0m));
            Expect.Once.On(mockService).Method("IsValidName").Will(Return.Value(Error.HasNoError));
            StubOnValidationProperties();

            var hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfTargetValueIsLessThanNeverToExceedMinimum()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("TargetValue").Will(Return.Value(20.0m));
            Expect.AtLeastOnce.On(mockView).GetProperty("NeverToExceedMinimum").Will(Return.Value(30.0m));
            Expect.Once.On(mockService).Method("IsValidName").Will(Return.Value(Error.HasNoError));
            StubOnValidationProperties();

            var hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldShowUserTargetValueIsOutsideOfThreshold()
        {
            Expect.AtLeastOnce.On(mockView).GetProperty("TargetValue").Will(Return.Value(20.0m));
            Expect.AtLeastOnce.On(mockView).GetProperty("NeverToExceedMinimum").Will(Return.Value(30.0m));
            Expect.Once.On(mockService).Method("IsValidName").Will(Return.Value(Error.HasNoError));
            Expect.Once.On(mockView).Method("ShowTargetValueIsOutsideOfThreshold");
            StubOnValidationProperties();

            var hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ValidateViewHasErrorTest
            (string name, string description, bool nameIsValid, FunctionalLocation functionalLocation,
                TagInfo tagInformation, decimal? maxValue, decimal? minValue, decimal? nteMax, decimal? nteMin,
                bool scheduleHasError, ICollection<string> expectedErrorMethodNames)
        {
            Expect.Once.On(mockView).Method(CLEAR_ERRORS_METHOD);
            Expect.Once.On(mockView).GetProperty(DESCRIPTION_PROP).Will(Return.Value(description));
            Expect.AtLeastOnce.On(mockView).GetProperty(NAME_PROP).Will(Return.Value(name));
            Expect.Once.On(mockView).GetProperty(FUNCTIONAL_LOCATION_PROP).Will(Return.Value(functionalLocation));
            //Expect.AtLeastOnce.On(mockService).Method(SERVICE_COUNT_METHOD).Will(Return.Value(nameCount));
            var nameValidError = nameIsValid ? Error.HasNoError : new Error("Name isn't valid.");
            Expect.AtLeastOnce.On(mockService)
                .Method("IsValidName")
                .WithAnyArguments()
                .Will(Return.Value(nameValidError));
            Expect.Once.On(mockView).GetProperty(TAGINFO_PROP).Will(Return.Value(tagInformation));
            if (maxValue.HasValue)
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(MAXVALUE_PROP).Will(Return.Value(maxValue.Value));
            }
            else
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(MAXVALUE_PROP);
            }
            if (minValue.HasValue)
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(MINVALUE_PROP).Will(Return.Value(minValue));
            }
            else
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(MINVALUE_PROP);
            }
            if (nteMax.HasValue)
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(NTEMAXVALUE_PROP).Will(Return.Value(nteMax));
            }
            else
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(NTEMAXVALUE_PROP);
            }
            if (nteMin.HasValue)
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(NTEMINVALUE_PROP).Will(Return.Value(nteMin));
            }
            else
            {
                Expect.AtLeastOnce.On(mockView).GetProperty(NTEMINVALUE_PROP);
            }
            Expect.Once.On(mockView).GetProperty(HAS_SCHEDULE_ERROR_PROP).Will(Return.Value(scheduleHasError));
            foreach (var methodName in expectedErrorMethodNames)
            {
                Expect.Once.On(mockView).Method(methodName);
            }
            OltStub.On(mockView);
            var actualHasError = createPresenter.ValidateViewHasError();
            var expectedHasError = expectedErrorMethodNames.Count > 0;
            Assert.AreEqual(expectedHasError, actualHasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetOnFormLoadExpectation(TargetDefinition targetWithValues)
        {
            //
            //  Form Initialization
            //
            Expect.Once.On(mockView).SetProperty("TargetCategories");
            Expect.Once.On(mockView).SetProperty("OperationalModes");
            Expect.Once.On(mockView).SetProperty("ScheduleTypes");
            Expect.Once.On(mockView).SetProperty("RequiresApprovalEnabled");
            // 
            // Populate Values to View
            //
            Expect.Once.On(mockView).SetProperty("Author").To(targetWithValues.LastModifiedBy);
            Expect.Once.On(mockView).SetProperty("CreateDateTime").To(targetWithValues.LastModifiedDate);
            Expect.Once.On(mockView).SetProperty("Name").To(targetWithValues.Name);
            Expect.Once.On(mockView).SetProperty("NeverToExceedMaximum").To(targetWithValues.NeverToExceedMaximum);
            Expect.Once.On(mockView).SetProperty("NeverToExceedMinimum").To(targetWithValues.NeverToExceedMinimum);
            Expect.Once.On(mockView)
                .SetProperty("NeverToExceedMinimumFrequency")
                .To(targetWithValues.NeverToExceedMinFrequency);
            Expect.Once.On(mockView)
                .SetProperty("NeverToExceedMaximumFrequency")
                .To(targetWithValues.NeverToExceedMaxFrequency);
            Expect.Once.On(mockView).SetProperty("MaxValue").To(targetWithValues.MaxValue);
            Expect.Once.On(mockView).SetProperty("MinValue").To(targetWithValues.MinValue);
            Expect.Once.On(mockView).SetProperty("MaxValueFrequency").To(targetWithValues.MaxValueFrequency);
            Expect.Once.On(mockView).SetProperty("MinValueFrequency").To(targetWithValues.MinValueFrequency);
            targetWithValues.TargetValue.Do(new SetExpectationsForSetTargetValue(mockView));
            Expect.Once.On(mockView).SetProperty("GapUnitValue").To(targetWithValues.GapUnitValue);
            Expect.Once.On(mockView).SetProperty("Description").To(targetWithValues.Description);
            Expect.Once.On(mockView).SetProperty("IsAlertRequired").To(targetWithValues.IsAlertRequired);
            Expect.Once.On(mockView).SetProperty("OperationalMode").To(targetWithValues.OperationalMode);
            AssertPopulateViewForReadWriteConfigurations(targetWithValues.ReadWriteTagsConfiguration);
            Expect.Once.On(mockView).SetProperty("Category").To(targetWithValues.Category);

            Expect.Once.On(mockView).SetProperty("TagInfo").To(targetWithValues.TagInfo);
            Expect.Once.On(mockView)
                .SetProperty("ConfigurePreApprovedTargetRangesEnabled")
                .To(targetWithValues.TagInfo != null);

            Expect.Once.On(mockView).SetProperty("GenerateActionItem").To(targetWithValues.GenerateActionItem);
            Expect.Once.On(mockView).SetProperty("FunctionalLocation").To(targetWithValues.FunctionalLocation);
            Expect.Once.On(mockView).SetProperty("RequiresApproval").To(targetWithValues.RequiresApproval);
            if (targetWithValues.RequiresApproval)
            {
                Expect.Once.On(mockView).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(false);
                Expect.AtLeastOnce.On(mockView).SetProperty("IsActive").To(false);
            }
            else
            {
                Expect.Once.On(mockView).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(true);
                Expect.AtLeastOnce.On(mockView).SetProperty("IsActive").To(targetWithValues.IsActive);
            }
            Expect.Once.On(mockView)
                .SetProperty("DependentTargetDefinitions")
                .To(IsList.Equal(targetWithValues.AssociatedTargetDTOs));
            Expect.Once.On(mockView).SetProperty("Schedule").To(targetWithValues.Schedule);
            Expect.Once.On(mockView)
                .SetProperty("RequiresResponseWhenAlerted")
                .To(targetWithValues.RequiresResponseWhenAlerted);
            Expect.Once.On(mockView)
                .SetProperty("AssociatedDocumentLinks")
                .To(IsList.Equal(targetWithValues.DocumentLinks));
            Expect.Once.On(mockView).SetProperty("PreApprovedTargetRangesWarningIsVisible").To(
                targetWithValues.PreApprovedMinValue.HasValue ||
                targetWithValues.PreApprovedMaxValue.HasValue ||
                targetWithValues.PreApprovedNeverToExceedMinimum.HasValue ||
                targetWithValues.PreApprovedNeverToExceedMaximum.HasValue);
            Expect.Never.On(mockView).SetProperty("TagValue");


            Stub.On(mockView);
        }

        private void ShouldSetValuesToViewOnLoad(TargetDefinitionStatus currentStatus, bool currentRequiresApproval,
            bool currentActive)
        {
            Expect.Once.On(mockWorkAssignmentService)
                .Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant")
                .WithAnyArguments()
                .Will(Return.Value(new List<WorkAssignment> {WorkAssignment.NoneWorkAssignment}));

            editTargetDefinition.Status = currentStatus;
            editTargetDefinition.RequiresApproval = currentRequiresApproval;
            editTargetDefinition.IsActive = currentActive;
            editTargetDefinition.ReadWriteTagsConfiguration =
                TargetDefinitionReadWriteTagConfigurationFixture.CreateConfigurationWithOnlyReadTypesForTagA1Values();
            SetOnFormLoadExpectation(editTargetDefinition);

            editPresenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetGetterExpectation(TargetDefinition expected)
        {
            Expect.Once.On(mockView).GetProperty("Name").Will(Return.Value(expected.Name));
            Expect.Once.On(mockView).GetProperty("Description").Will(Return.Value(expected.Description));
            Expect.Once.On(mockView).GetProperty("GapUnitValue").Will(Return.Value(expected.GapUnitValue));
            expected.TargetValue.Do(new SetExpectationsForGetTargetValue(mockView));
            Expect.Once.On(mockView).GetProperty("MaxValue").Will(Return.Value(expected.MaxValue));
            Expect.Once.On(mockView).GetProperty("MaxValueFrequency").Will(Return.Value(expected.MaxValueFrequency));
            Expect.Once.On(mockView).GetProperty("MinValue").Will(Return.Value(expected.MinValue));
            Expect.Once.On(mockView).GetProperty("MinValueFrequency").Will(Return.Value(expected.MinValueFrequency));
            Expect.Once.On(mockView)
                .GetProperty("NeverToExceedMaximum")
                .Will(Return.Value(expected.NeverToExceedMaximum));
            Expect.Once.On(mockView)
                .GetProperty("NeverToExceedMaximumFrequency")
                .Will(Return.Value(expected.NeverToExceedMaxFrequency));
            Expect.Once.On(mockView)
                .GetProperty("NeverToExceedMinimum")
                .Will(Return.Value(expected.NeverToExceedMinimum));
            Expect.Once.On(mockView)
                .GetProperty("NeverToExceedMinimumFrequency")
                .Will(Return.Value(expected.NeverToExceedMinFrequency));
            Expect.Once.On(mockView).GetProperty("Category").Will(Return.Value(expected.Category));
            Expect.Once.On(mockView).GetProperty("WorkAssignment").Will(Return.Value(expected.Assignment));
            Expect.Once.On(mockView).GetProperty("Priority").Will(Return.Value(expected.Priority));
            Expect.Once.On(mockView).GetProperty("TagInfo").Will(Return.Value(expected.TagInfo));
            Expect.Once.On(mockView).GetProperty("FunctionalLocation").Will(Return.Value(expected.FunctionalLocation));
            Expect.Once.On(mockView).GetProperty("GenerateActionItem").Will(Return.Value(expected.GenerateActionItem));
            Expect.Once.On(mockView).GetProperty("IsAlertRequired").Will(Return.Value(expected.IsAlertRequired));
            Expect.Once.On(mockView)
                .GetProperty("RequiresResponseWhenAlerted")
                .Will(Return.Value(expected.RequiresResponseWhenAlerted));
            Expect.Once.On(mockView).GetProperty("IsActive").Will(Return.Value(expected.IsActive));
            Expect.AtLeastOnce.On(mockView)
                .GetProperty("RequiresApproval")
                .Will(Return.Value(expected.RequiresApproval));
            Expect.Once.On(mockView)
                .GetProperty("DependentTargetDefinitions")
                .Will(Return.Value(expected.AssociatedTargetDTOs));
            Expect.Once.On(mockView).GetProperty("Schedule").Will(Return.Value(expected.Schedule));
            Expect.Once.On(mockView).GetProperty("OperationalMode").Will(Return.Value(expected.OperationalMode));
            Expect.Once.On(mockView).GetProperty("AssociatedDocumentLinks").Will(Return.Value(expected.DocumentLinks));
        }

        private void StubViewMock()
        {
            Stub.On(mockView).GetProperty("Name").Will(Return.Value(editTargetDefinition.Name));
            Stub.On(mockView).GetProperty("Description").Will(Return.Value(editTargetDefinition.Description));
            Stub.On(mockView).GetProperty("GapUnitValue").Will(Return.Value(editTargetDefinition.GapUnitValue));
            editTargetDefinition.TargetValue.Do(new SetStubsForGetTargetValue(mockView));
            Stub.On(mockView).GetProperty("MaxValue").Will(Return.Value(editTargetDefinition.MaxValue));
            Stub.On(mockView)
                .GetProperty("MaxValueFrequency")
                .Will(Return.Value(editTargetDefinition.MaxValueFrequency));
            Stub.On(mockView).GetProperty("MinValue").Will(Return.Value(editTargetDefinition.MinValue));
            Stub.On(mockView)
                .GetProperty("MinValueFrequency")
                .Will(Return.Value(editTargetDefinition.MinValueFrequency));
            Stub.On(mockView)
                .GetProperty("NeverToExceedMaximum")
                .Will(Return.Value(editTargetDefinition.NeverToExceedMaximum));
            Stub.On(mockView)
                .GetProperty("NeverToExceedMaximumFrequency")
                .Will(Return.Value(editTargetDefinition.NeverToExceedMaxFrequency));
            Stub.On(mockView)
                .GetProperty("NeverToExceedMinimum")
                .Will(Return.Value(editTargetDefinition.NeverToExceedMinimum));
            Stub.On(mockView)
                .GetProperty("NeverToExceedMinimumFrequency")
                .Will(Return.Value(editTargetDefinition.NeverToExceedMinFrequency));
            Stub.On(mockView).GetProperty("Category").Will(Return.Value(editTargetDefinition.Category));
            Stub.On(mockView).GetProperty("WorkAssignment").Will(Return.Value(editTargetDefinition.Assignment));
            Stub.On(mockView).GetProperty("Priority").Will(Return.Value(editTargetDefinition.Priority));
            Stub.On(mockView).GetProperty("TagInfo").Will(Return.Value(editTargetDefinition.TagInfo));
            Stub.On(mockView)
                .GetProperty("FunctionalLocation")
                .Will(Return.Value(editTargetDefinition.FunctionalLocation));
            Stub.On(mockView)
                .GetProperty("GenerateActionItem")
                .Will(Return.Value(editTargetDefinition.GenerateActionItem));
            Stub.On(mockView).GetProperty("IsAlertRequired").Will(Return.Value(editTargetDefinition.IsAlertRequired));
            Stub.On(mockView).GetProperty("IsActive").Will(Return.Value(editTargetDefinition.IsActive));
            Stub.On(mockView).GetProperty("RequiresApproval").Will(Return.Value(editTargetDefinition.RequiresApproval));
            Stub.On(mockView)
                .GetProperty("DependentTargetDefinitions")
                .Will(Return.Value(editTargetDefinition.AssociatedTargetDTOs));
            Stub.On(mockView).GetProperty("Schedule").Will(Return.Value(editTargetDefinition.Schedule));
            Stub.On(mockView)
                .GetProperty("RequiresResponseWhenAlerted")
                .Will(Return.Value(editTargetDefinition.RequiresResponseWhenAlerted));
            Stub.On(mockView).GetProperty("OperationalMode").Will(Return.Value(editTargetDefinition.OperationalMode));
            Stub.On(mockView)
                .GetProperty("AssociatedDocumentLinks")
                .Will(Return.Value(editTargetDefinition.DocumentLinks));
        }

        private void StubOnValidationProperties()
        {
            Stub.On(mockView).GetProperty("Description").Will(Return.Value("Something"));
            Stub.On(mockView).GetProperty("Name").Will(Return.Value("SomeName"));
            Stub.On(mockView)
                .GetProperty("FunctionalLocation")
                .Will(Return.Value(FunctionalLocationFixture.GetAny_Unit1()));
            Stub.On(mockView).GetProperty("TagInfo").Will(Return.Value(TagInfoFixture.CreateTagInfoWithoutId()));
            OltStub.On(mockView);
            OltStub.On(mockService);
        }

        private void ExpectationsForSettingTagValue()
        {
            const decimal tagValue = 24;
            Expect.Once.On(mockView).GetProperty("TagInfo").Will(Return.Value(tagInfo));
            Expect.Once.On(mockPlantHistorianService).Method("CanReadTagValue").With(tagInfo).Will(Return.Value(true));
            Expect.Once.On(mockPlantHistorianService)
                .Method("ReadTagValues")
                .WithAnyArguments()
                .Will(Return.Value(new decimal?[] {tagValue}));
            Expect.Once.On(mockView).SetProperty("TagValue").To(tagValue.ToString());
            Expect.Once.On(mockView).SetProperty("TagValueEnabled").To(true);
        }

        private void AssertPopulateViewForReadWriteConfigurations(TargetDefinitionReadWriteTagConfiguration config)
        {
            Expect.Once.On(mockView).SetProperty("MaxReadWriteDirection").To(config.MaxValue.Direction);
            Expect.Once.On(mockView).SetProperty("MinReadWriteDirection").To(config.MinValue.Direction);
            Expect.Once.On(mockView).SetProperty("TargetReadWriteDirection").To(config.TargetValue.Direction);
            Expect.Once.On(mockView).SetProperty("GapUnitReadWriteDirection").To(config.GapUnitValue.Direction);

            Expect.Once.On(mockView).SetProperty("MaxValueEnabled").To(! config.MaxValue.IsReadDirection());
            Expect.Once.On(mockView).SetProperty("MinValueEnabled").To(! config.MinValue.IsReadDirection());
            Expect.Once.On(mockView).SetProperty("TargetValueEnabled").To(!config.TargetValue.IsReadDirection());
            Expect.Once.On(mockView).SetProperty("GapUnitValueEnabled").To(! config.GapUnitValue.IsReadDirection());

            const decimal tagValue = 1;
            Stub.On(mockPlantHistorianService)
                .Method("ReadTagValues")
                .WithAnyArguments()
                .Will(Return.Value(new decimal?[] {tagValue}));
            if (config.MaxValue.IsReadDirection()) Expect.Once.On(mockView).SetProperty("MaxValue").To(Is.Anything);
            if (config.MinValue.IsReadDirection()) Expect.Once.On(mockView).SetProperty("MinValue").To(Is.Anything);
            if (config.TargetValue.IsReadDirection())
                Expect.Once.On(mockView).SetProperty("TargetValue").To(Is.Anything);
            if (config.GapUnitValue.IsReadDirection())
                Expect.Once.On(mockView).SetProperty("GapUnitValue").To(Is.Anything);
        }

        private class SetExpectationsForSetTargetValue : ITargetAction
        {
            private readonly ITargetDefinitionFormView viewMock;

            public SetExpectationsForSetTargetValue(ITargetDefinitionFormView viewMock)
            {
                this.viewMock = viewMock;
            }

            public void DoForMinimize()
            {
                Expect.Once.On(viewMock).Method("SetTargetToMinimize");
            }

            public void DoForMaximize()
            {
                Expect.Once.On(viewMock).Method("SetTargetToMaximize");
            }

            public void DoForEmpty()
            {
                Expect.Once.On(viewMock).SetProperty("TargetValue").To((object) null);
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                Expect.Once.On(viewMock).SetProperty("TargetValue").To(specifiedValue);
            }
        }

        private abstract class SetMockRequirementsForGetTargetValue : ITargetAction
        {
            protected readonly ITargetDefinitionFormView viewMock;

            protected SetMockRequirementsForGetTargetValue(ITargetDefinitionFormView viewMock)
            {
                this.viewMock = viewMock;
            }

            public void DoForMinimize()
            {
                Mock().GetProperty("TargetSetToMinimize").Will(Return.Value(true));
            }

            public void DoForMaximize()
            {
                Mock().GetProperty("TargetSetToMinimize").Will(Return.Value(false));
                Mock().GetProperty("TargetSetToMaximize").Will(Return.Value(true));
            }

            public void DoForEmpty()
            {
                Mock().GetProperty("TargetSetToMinimize").Will(Return.Value(false));
                Mock().GetProperty("TargetSetToMaximize").Will(Return.Value(false));
                Mock().GetProperty("TargetValue").Will(Return.Value(null));
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                Mock().GetProperty("TargetSetToMinimize").Will(Return.Value(false));
                Mock().GetProperty("TargetSetToMaximize").Will(Return.Value(false));
                Mock().GetProperty("TargetValue").Will(Return.Value((decimal?) specifiedValue));
            }

            protected abstract IMethodSyntax Mock();
        }

        private class SetExpectationsForGetTargetValue : SetMockRequirementsForGetTargetValue
        {
            public SetExpectationsForGetTargetValue(ITargetDefinitionFormView viewMock) : base(viewMock)
            {
            }

            protected override IMethodSyntax Mock()
            {
                return Expect.Once.On(viewMock);
            }
        }

        private class SetStubsForGetTargetValue : SetMockRequirementsForGetTargetValue
        {
            public SetStubsForGetTargetValue(ITargetDefinitionFormView viewMock) : base(viewMock)
            {
            }

            protected override IMethodSyntax Mock()
            {
                return Stub.On(viewMock);
            }
        }

        private class FakeTargetDefinitionFormPresenter : TargetDefinitionFormPresenter
        {
            public FakeTargetDefinitionFormPresenter(ITargetDefinitionFormView view) : base(view)
            {
            }

            public FakeTargetDefinitionFormPresenter(ITargetDefinitionFormView view,
                TargetDefinition editTargetDefinition) : base(view, editTargetDefinition)
            {
            }

            public FakeTargetDefinitionFormPresenter(ITargetDefinitionFormView view,
                TargetDefinition editTargetDefinition, ITargetDefinitionService service,
                IPlantHistorianService plantHistorianService,
                IWorkAssignmentService workAssignmentService)
                : base(view, editTargetDefinition, service, plantHistorianService, workAssignmentService)
            {
            }

            public void SaveOrUpdateComplete_Public(bool saveOrUpdateSucceeded)
            {
                base.SaveOrUpdateComplete(saveOrUpdateSucceeded);
            }

            public SaveUpdateDomainObjectContainer<TargetDefinition> GetPopulatedEditObjectToUpdate_Public()
            {
                return base.GetPopulatedEditObjectToUpdate();
            }
        }
    }
}