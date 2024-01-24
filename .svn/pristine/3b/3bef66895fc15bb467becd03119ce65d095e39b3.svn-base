using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ActionItemDefinitionFormPresenterTest
    {
        private Mockery mocks;
        private FakeActionItemDefinitionFormPresenter createPresenter;
        private FakeActionItemDefinitionFormPresenter editPresenter;
        private IActionItemDefinitionFormView viewMock;
        private IActionItemDefinitionService serviceMock;
        private ISiteConfigurationService siteConfigurationServiceMock;
        private IBusinessCategoryService businessCategoryServiceMock;
        private IWorkAssignmentService workAssignmentServiceMock;
        private IActionItemService actionItemServiceMock;
        private IFormEdmontonService formServiceMock;
        private IUserService userServiceMock;
        
        private ActionItemDefinition editActionItemDefinition;
        private User currentUser;
        
        private const string NOT_EMPTY_STRING = "NotEmptyString";
        private const string NAME_PROP = "ActionItemDefinitionName";
        private const string FUNCTIONAL_LOCATION_PROP = "AssociatedFunctionalLocations";
        private const string DESCRIPTION_PROP = "Description";
        private const string CATEGORY_PROP = "Category";
        private const string HAS_SCHEDULE_ERROR_PROP = "HasScheduleError";
        private BusinessCategory STUB_CATEGORY;

        private const string CLEAR_ERRORS_METHOD = "ClearErrorProviders";
        private const string SHOW_DESCRIPTION_ERROR = "ShowDescriptionIsEmptyError";
        private const string SHOW_NAME_ERROR = "ShowNameIsEmptyError";
        private const string SHOW_FLOC_ERROR = "ShowNoFunctionalLocationsSelectedError";
        private const string SHOW_NAME_NOT_UNIQUE_ERROR = "ShowNameIsNotUniqueError";
        private const string REQUIRES_APPROVAL = "RequiresApproval";
        private const string IS_ACTIVE_CHECK_BOX_ENABLED = "IsActiveCheckBoxEnabled";
        private const string IS_ACTIVE = "IsActive";
        private const string SERVICE_COUNT_METHOD = "GetCountOfSAPSourced";

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

            STUB_CATEGORY = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();

            currentUser = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            UserContext userContext = ClientSession.GetUserContext();
            userContext.SetRole(RoleFixture.CreateOperatorRole(), UserRoleElementsFixture.CreateRoleElementsForOperator(), new List<RoleDisplayConfiguration>(), new List<RolePermission>());
            userContext.User = currentUser;
            Site site = currentUser.AvailableSites[0];

            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            editActionItemDefinition = ActionItemDefinitionFixture.CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(1);
            editActionItemDefinition.Name = NOT_EMPTY_STRING;

            mocks = new Mockery();
            viewMock = mocks.NewMock<IActionItemDefinitionFormView>();
            serviceMock = mocks.NewMock<IActionItemDefinitionService>();
            siteConfigurationServiceMock = mocks.NewMock<ISiteConfigurationService>();
            businessCategoryServiceMock = mocks.NewMock<IBusinessCategoryService>();
            workAssignmentServiceMock = mocks.NewMock<IWorkAssignmentService>();
            actionItemServiceMock = mocks.NewMock<IActionItemService>();
            formServiceMock = mocks.NewMock<IFormEdmontonService>();
            userServiceMock = mocks.NewMock<IUserService>();

            createPresenter = new FakeActionItemDefinitionFormPresenter(viewMock, null, serviceMock, businessCategoryServiceMock, workAssignmentServiceMock, actionItemServiceMock, formServiceMock,userServiceMock);
            editPresenter = new FakeActionItemDefinitionFormPresenter(viewMock, editActionItemDefinition, serviceMock, businessCategoryServiceMock, workAssignmentServiceMock, actionItemServiceMock, formServiceMock,userServiceMock);

            Stub.On(businessCategoryServiceMock).Method("QueryUniqueCategoriesByFunctionalLocationList").Will(Return.Value(new List<BusinessCategory>()));
            Stub.On(viewMock).GetProperty("Categories").Will(Return.Value(new List<BusinessCategory>()));
            Stub.On(viewMock).GetProperty("CreateAnActionItemForEachFunctionalLocation").Will(Return.Value(true));
            Stub.On(viewMock).SetProperty("CreateAnActionItemForEachFunctionalLocation");            
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        private void SetOnFormLoadExpectation(ActionItemDefinition aid)
        {
            //
            // Form Initialization
            //
            Expect.Once.On(viewMock).SetProperty("Categories");
            Expect.Once.On(viewMock).SetProperty("ScheduleTypes");

            if ( aid.Is(ActionItemDefinitionStatus.Approved) )
                Expect.Once.On(viewMock).SetProperty("RequiresApprovalCheckBoxEnabled").To(false);
            else
                Expect.Once.On(viewMock).SetProperty("RequiresApprovalCheckBoxEnabled");

            //
            // Populating view with values
            //
            Expect.Once.On(viewMock).SetProperty("Author").To(aid.LastModifiedBy);
            Expect.Once.On(viewMock).SetProperty("CreateDateTime").To(aid.LastModifiedDate);
            Expect.Once.On(viewMock).SetProperty("ActionItemDefinitionName").To(aid.Name);
            Expect.Once.On(viewMock).SetProperty("Description").To(aid.Description);
            Stub.On(viewMock).SetProperty("Category").To(aid.Category);
            Expect.Once.On(viewMock).SetProperty("OperationalMode").To(OperationalMode.Normal);
            Expect.AtLeastOnce.On(viewMock).SetProperty("RequiresApproval").To(aid.RequiresApproval);

            if (aid.RequiresApproval)
            {
                Expect.AtLeastOnce.On(viewMock).SetProperty("IsActiveCheckBoxEnabled").To(false);
                Expect.AtLeastOnce.On(viewMock).SetProperty("IsActive").To(false);
            }
            else
            {
                Expect.AtLeastOnce.On(viewMock).SetProperty("IsActiveCheckBoxEnabled").To(true);
                Expect.AtLeastOnce.On(viewMock).SetProperty("IsActive").To(aid.Active);
            }

            Expect.Once.On(viewMock).SetProperty("AssociatedFunctionalLocations").To(IsList.Equal(aid.FunctionalLocations));
            Expect.Once.On(viewMock).SetProperty("Schedule").To(aid.Schedule);
            Expect.Once.On(viewMock).SetProperty("ResponseRequired").To(aid.ResponseRequired);
            Expect.Once.On(viewMock).SetProperty("AssociatedTargetDefinitionDto").To(IsList.Equal(aid.TargetDefinitionDTOs));
            Expect.Once.On(viewMock).SetProperty("AssociatedDocumentLinks").To(IsList.Equal(aid.DocumentLinks));
            Expect.Once.On(viewMock).SetProperty("Source").To(aid.Source);

            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(new List<WorkAssignment>()));
            Stub.On(siteConfigurationServiceMock).Method("QueryBySiteId").Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentUser.AvailableSites[0])));            
            Stub.On(viewMock);
        }

        [Test]
        public void ShouldSetValuesToViewOnLoadForCreating()
        {
            ActionItemDefinition defaultAID = ActionItemDefinitionFixture.CreateActionItemDefinitionWithDefaultValuesForView(currentUser);
            SetOnFormLoadExpectation(defaultAID);

            ActionItemDefinitionFormPresenter presenter = new ActionItemDefinitionFormPresenter(
                viewMock, 
                defaultAID, 
                serviceMock, 
                businessCategoryServiceMock, 
                null,
                workAssignmentServiceMock,
                actionItemServiceMock,
                formServiceMock,userServiceMock);
            presenter.SetDefaultActionItemDefinitionData(defaultAID);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void ShouldSetValuesToViewOnLoad(ActionItemDefinitionStatus status, bool requiresApproval, bool active)
        {
            Debug.Assert(
                            (requiresApproval && active == false && status != ActionItemDefinitionStatus.Approved) ||
                            (requiresApproval == false && status == ActionItemDefinitionStatus.Approved)
                        );

            if (requiresApproval == false)
                editActionItemDefinition.Status = ActionItemDefinitionStatus.Approved;

            editActionItemDefinition.RequiresApproval = requiresApproval;
            editActionItemDefinition.Active = active;

            SetOnFormLoadExpectation(editActionItemDefinition);
            editPresenter.HandleFormLoad(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldLoadPendingTrueRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(ActionItemDefinitionStatus.Pending, true, false);
        }

        [Test]
        public void ShouldLoadRejectedTrueRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(ActionItemDefinitionStatus.Rejected, true, false);
        }

        [Test]
        public void ShouldLoadApprovedFalseRequiresApprovalAndFalseActive()
        {
            ShouldSetValuesToViewOnLoad(ActionItemDefinitionStatus.Approved, false, false);
        }

        [Test]
        public void ShouldLoadApprovedFalseRequiresApprovalAndTrueActive()
        {
            ShouldSetValuesToViewOnLoad(ActionItemDefinitionStatus.Approved, false, true);
        }

        [Test]
        public void ShouldDisableAndUnCheckIsActiveCheckBoxOnCheckingRequiresApproval()
        {
            Expect.Once.On(viewMock).GetProperty(REQUIRES_APPROVAL).Will(Return.Value(true));
            Expect.Once.On(viewMock).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(false);
            Expect.Once.On(viewMock).SetProperty(IS_ACTIVE).To(false);
            createPresenter.HandleRequiresApprovalCheckBoxCheckedChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableAndUnCheckedIsActiveCheckBoxOnUnCheckingRequiresApproval()
        {
            Expect.Once.On(viewMock).GetProperty(REQUIRES_APPROVAL).Will(Return.Value(false));
            Expect.Once.On(viewMock).SetProperty(IS_ACTIVE_CHECK_BOX_ENABLED).To(true);
            Expect.Never.On(viewMock).SetProperty(IS_ACTIVE);
            createPresenter.HandleRequiresApprovalCheckBoxCheckedChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetupUpdateExpectations(ActionItemDefinition aidExpectation)
        {
            Expect.Once.On(viewMock).GetProperty("ActionItemDefinitionName").Will(Return.Value(aidExpectation.Name));
            Expect.Once.On(viewMock).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(aidExpectation.FunctionalLocations));
            Expect.Once.On(viewMock).GetProperty("Category").Will(Return.Value(aidExpectation.Category));
            Expect.Once.On(viewMock).GetProperty("Priority").Will(Return.Value(aidExpectation.Priority));
            Expect.Once.On(viewMock).GetProperty("Description").Will(Return.Value(aidExpectation.Description));
            Expect.Once.On(viewMock).GetProperty("IsActive").Will(Return.Value(aidExpectation.Active));
            Expect.Once.On(viewMock).GetProperty("RequiresApproval").Will(Return.Value(aidExpectation.RequiresApproval));
            Expect.Once.On(viewMock).GetProperty("ResponseRequired").Will(Return.Value(aidExpectation.ResponseRequired));
            Expect.Once.On(viewMock).GetProperty("Schedule").Will(Return.Value(aidExpectation.Schedule));
            Expect.Once.On(viewMock).GetProperty("AssociatedTargetDefinitionDto").Will(Return.Value(aidExpectation.TargetDefinitionDTOs));
            Expect.Once.On(viewMock).GetProperty("AssociatedDocumentLinks").Will(Return.Value(aidExpectation.DocumentLinks));
            Expect.Once.On(viewMock).GetProperty("CreateDateTime").Will(Return.Value(aidExpectation.LastModifiedDate));
            Expect.Once.On(viewMock).GetProperty("Source").Will(Return.Value(aidExpectation.Source));
            Expect.Once.On(viewMock).GetProperty("OperationalMode").Will(Return.Value(OperationalMode.Normal));
            Expect.AtLeastOnce.On(viewMock).GetProperty("FormGn75BId").Will(Return.Value(aidExpectation.AssociatedFormGN75BId));

            Stub.On(siteConfigurationServiceMock).Method("QueryBySiteId")
                .Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia())));
            Stub.On(serviceMock).Method("QueryById").Will(Return.Value(editActionItemDefinition));
            Stub.On(viewMock).SetProperty("Assignment");
            Stub.On(viewMock).GetProperty("Assignment");
        }

        [Test][Ignore]
        public void ShouldGetValuesFromViewOnUpdate()
        {
            ActionItemDefinition aidExpectation = ActionItemDefinitionFixture.CreateActionItemDefinition();
            aidExpectation.AssociatedFormGN75BId = -9;

            SetupUpdateExpectations(aidExpectation);

            editPresenter.SetEditObject(aidExpectation);

            // this gets called before the update happens
            editPresenter.GetPopulatedEditObjectToUpdateDespiteMethodBeingProtected();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void StubMocks(string name, string description, BusinessCategory businessCategory, int nameCount, List<FunctionalLocation> flocs)
        {
            Stub.On(viewMock).Method(CLEAR_ERRORS_METHOD);
            Stub.On(serviceMock).Method(SERVICE_COUNT_METHOD).Will(Return.Value(nameCount));

            Stub.On(viewMock).GetProperty(DESCRIPTION_PROP).Will(Return.Value(description));
            Stub.On(viewMock).GetProperty(NAME_PROP).Will(Return.Value(name));
            Stub.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_PROP).Will(Return.Value(flocs));
            Stub.On(viewMock).GetProperty(HAS_SCHEDULE_ERROR_PROP).Will(Return.Value(false));
            Stub.On(viewMock).GetProperty(HAS_SCHEDULE_ERROR_PROP).Will(Return.Value(false));
            Stub.On(viewMock).GetProperty(CATEGORY_PROP).Will(Return.Value(businessCategory));

            Stub.On(viewMock).Method("ShowCategoryNotSelectedError");
        }

        [Test]
        public void ValidateShouldPassIfAllFieldsHaveValidData()
        {
            StubMocks(NOT_EMPTY_STRING, NOT_EMPTY_STRING, STUB_CATEGORY, 0,
                      FunctionalLocationFixture.GetListWith2Units());
            Stub.On(viewMock).Method(SHOW_NAME_ERROR);

            bool hasError = createPresenter.ValidateViewHasError();
            Assert.IsFalse(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfDescriptionIsEmpty()
        {
            StubMocks(NOT_EMPTY_STRING, string.Empty, STUB_CATEGORY, 0,
                      FunctionalLocationFixture.GetListWith2Units());
            Stub.On(viewMock).Method(SHOW_DESCRIPTION_ERROR);

            bool hasError = createPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfNameIsEmpty()
        {
            StubMocks(string.Empty, NOT_EMPTY_STRING, STUB_CATEGORY, 0,
                      FunctionalLocationFixture.GetListWith2Units());
            Stub.On(viewMock).Method(SHOW_NAME_ERROR);

            bool hasError = createPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfFlocIsEmpty()
        {
            StubMocks(NOT_EMPTY_STRING, NOT_EMPTY_STRING, STUB_CATEGORY, 0, null);
            Stub.On(viewMock).Method(SHOW_FLOC_ERROR);

            bool hasError = createPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfNameNotUniqueWhenCreating()
        {
            StubMocks(NOT_EMPTY_STRING, NOT_EMPTY_STRING, STUB_CATEGORY,  1,
                      FunctionalLocationFixture.GetListWith2Units());
            Stub.On(viewMock).Method(SHOW_NAME_NOT_UNIQUE_ERROR);

            bool hasError = createPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFailIfNameHasChangedAndNotUniqueWhenEdit()
        {
            StubMocks("Something Else", NOT_EMPTY_STRING, STUB_CATEGORY,  1,
                      FunctionalLocationFixture.GetListWith2Units());
            Stub.On(viewMock).Method(SHOW_NAME_NOT_UNIQUE_ERROR);

            bool hasError = editPresenter.ValidateViewHasError();
            Assert.IsTrue(hasError);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldReturnTrueIfEditingObjectInTheDatabase()
        {
            Assert.IsTrue(editPresenter.IsEdit);
        }

        [Test]
        public void ShouldReturnFalseIfCreatingANewActionItemDefinition()
        {
            Assert.IsFalse(createPresenter.IsEdit);
        }

        [Test]
        public void ShouldSetTheIsEditWhenCallingTheConstructors()
        {
            Assert.IsFalse( new ActionItemDefinitionFormPresenter(viewMock, null, serviceMock, businessCategoryServiceMock,null, workAssignmentServiceMock, actionItemServiceMock, formServiceMock,userServiceMock).IsEdit);
            Assert.IsTrue(new ActionItemDefinitionFormPresenter(viewMock, editActionItemDefinition, serviceMock, businessCategoryServiceMock,null, workAssignmentServiceMock, actionItemServiceMock, formServiceMock,userServiceMock).IsEdit);
        }

        [Test]
        public void ShouldEnableViewEditHistoryForExistingActionItemDefinition()
        {
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(new List<WorkAssignment>()));
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(true);
            Stub.On(viewMock);
            Stub.On(siteConfigurationServiceMock).Method("QueryBySiteId").Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentUser.AvailableSites[0])));

            editPresenter.HandleFormLoad(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableViewEditHistoryForCreatingNewActionItemDefinition()
        {
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(new List<WorkAssignment>()));
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(false);
            Stub.On(viewMock);
            createPresenter.HandleFormLoad(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldUseAlternativeDefaultData()
        {
            ActionItemDefinition newDefaultAID = ActionItemDefinitionFixture.CreateActionItemDefinition();

            SetOnFormLoadExpectation(newDefaultAID);
            createPresenter.SetDefaultActionItemDefinitionData(newDefaultAID);
            createPresenter.HandleFormLoad(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldColorAutoReApproveFieldsWhenUserCannotApproveAndEditing()
        {
            currentUser = UserFixture.CreateEngineeringSupport();
            ClientSession.GetUserContext().User = currentUser;
            
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentUser.AvailableSites[0]);
            ActionItemDefinitionAutoReApprovalConfiguration aidConfig = siteConfiguration.ActionItemDefinitionAutoReApprovalConfiguration;

            //Expect.Once.On(siteConfigurationServiceMock).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));            

            Expect.Once.On(viewMock).SetProperty("NameChangeRequiresReApproval").To(aidConfig.NameChange);
            Expect.Once.On(viewMock).SetProperty("CategoryChangeRequiresReApproval").To(aidConfig.CategoryChange);
//            Expect.Once.On(viewMock).SetProperty("OperationalModeChangeRequiresReApproval").To(aidConfig.OperationalModeChange);
            Expect.Once.On(viewMock).SetProperty("PriorityChangeRequiresReApproval").To(aidConfig.PriorityChange);
            Expect.Once.On(viewMock).SetProperty("DescriptionChangeRequiresReApproval").To(aidConfig.DescriptionChange);
            Expect.Once.On(viewMock).SetProperty("DocumentLinksChangeRequiresReApproval").To(aidConfig.DocumentLinksChange);
            Expect.Once.On(viewMock).SetProperty("FunctionalLocationsChangeRequiresReApproval").To(aidConfig.FunctionalLocationsChange);
            Expect.Once.On(viewMock).SetProperty("TargetDependenciesChangeRequiresReApproval").To(aidConfig.TargetDependenciesChange);
            Expect.Once.On(viewMock).SetProperty("ScheduleChangeRequiresReApproval").To(aidConfig.ScheduleChange);
            Expect.Once.On(viewMock).SetProperty("RequiresResponseWhenTriggeredChangeRequiresReApproval").To(aidConfig.RequiresResponseWhenTriggeredChange);
            Stub.On(viewMock);
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").Will(Return.Value(new List<WorkAssignment>()));

            editPresenter.HandleFormLoad(null, null);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldPassCurrentFLOCSelectionToFLOCSelectorOnFLOCButtonClicked()
        {

            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();

            Stub.On(viewMock).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method("ShowFunctionalLocationSelector").With(IsList.Equal(currentFLOCSelection)).Will(Return.Value(DialogResult.OK));

            List<FunctionalLocation> newFLOCSelection = new List<FunctionalLocation>();
            Expect.Once.On(viewMock).GetProperty("UserSelectedFunctionalLocations").Will(Return.Value(newFLOCSelection));

            Stub.On(viewMock).SetProperty("AssociatedFunctionalLocations").To(IsList.Equal(newFLOCSelection));
            editPresenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldNotChangeCurrentSelectionIfUserCancels()
        {
            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();
            Stub.On(viewMock).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method("ShowFunctionalLocationSelector")
                .With(currentFLOCSelection).Will(Return.Value(DialogResult.Cancel));

            editPresenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldSetEmptyListIfUserOKsAndViewReturnNULL()
        {
            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();

            Stub.On(viewMock).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method("ShowFunctionalLocationSelector")
                .With(currentFLOCSelection).Will(Return.Value(DialogResult.OK));

            List<FunctionalLocation> newFLOCSelection = null;
            Expect.Once.On(viewMock).GetProperty("UserSelectedFunctionalLocations").Will(Return.Value(newFLOCSelection));

            List<FunctionalLocation> emptyFLOCList = new List<FunctionalLocation>();
            Expect.Once.On(viewMock).SetProperty("AssociatedFunctionalLocations").To(IsList.Equal(emptyFLOCList));
            editPresenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAddDefinitionWorkAssignmentToAssignmentListIfItDoesNotGetReturnedFromQuery()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();

            editActionItemDefinition.Assignment = workAssignment;
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").WithAnyArguments().Will(Return.Value(new List<WorkAssignment>()));
            Stub.On(viewMock).SetProperty("WorkAssignments").To(new ListMatcher<WorkAssignment>(
                new List<WorkAssignment> { workAssignment }));
            Stub.On(viewMock);
            Stub.On(siteConfigurationServiceMock).Method("QueryBySiteId").Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentUser.AvailableSites[0])));

            editPresenter.HandleFormLoad(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotAddNullWorkAssignmentToAssignmentList()
        {
            WorkAssignment workAssignment = null;

            editActionItemDefinition.Assignment = workAssignment;
            Stub.On(workAssignmentServiceMock).Method("QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant").WithAnyArguments().Will(Return.Value(new List<WorkAssignment>()));
            Stub.On(viewMock).SetProperty("WorkAssignments").To(new ListMatcher<WorkAssignment>(
                new List<WorkAssignment> ()));
            Stub.On(viewMock);
            Stub.On(siteConfigurationServiceMock).Method("QueryBySiteId").Will(Return.Value(SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentUser.AvailableSites[0])));

            editPresenter.HandleFormLoad(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldClearActionItemsOnUpdateIfCurrentActionItemsExistAndUserSaysYesToClear()
        {
            AssertClearActionItemsOnUpdate(true, true, true);
        }

        [Test]
        public void ShouldNotClearActionItemsOnUpdateIfCurrentActionItemsExistButUserSaysNoToClear()
        {
            AssertClearActionItemsOnUpdate(true, false, false);
        }

        [Test]
        public void ShouldNotClearActionItemsOnUpdateIfCurrentActionItemsDoNotExist()
        {
            AssertClearActionItemsOnUpdate(false, true, false);
        }

        private void AssertClearActionItemsOnUpdate(bool currentActionItemsExist, bool shouldClear, bool expectClear)
        {
            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            definition.CreatedBy = editActionItemDefinition.CreatedBy;
            definition.CreatedDateTime = editActionItemDefinition.CreatedDateTime;
            definition.Approve(currentUser, DateTimeFixture.DateTimeNow);
            
            string updateMethodName = (shouldClear && currentActionItemsExist) ? "UpdateAndClearCurrentActionItems" : "Update";

            Stub.On(actionItemServiceMock).Method("CurrentActionItemsExistForActionItemDefinition").Will(Return.Value(currentActionItemsExist));
            Stub.On(viewMock).GetProperty("ShouldClearCurrentActionItemsForDefinitionUpdate").Will(Return.Value(shouldClear));
                        
            Expect.Once.On(serviceMock).Method(updateMethodName).With(definition).Will(Return.Value(new List<NotifiedEvent>()));

            editPresenter.DoPreSaveOrUpdateWorkDespiteMethodBeingProtected(new SaveUpdateDomainObjectContainer<ActionItemDefinition>(definition));
            editPresenter.Update(new SaveUpdateDomainObjectContainer<ActionItemDefinition>(definition));
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        public class FakeActionItemDefinitionFormPresenter : ActionItemDefinitionFormPresenter
        {
            public FakeActionItemDefinitionFormPresenter(IActionItemDefinitionFormView view) : base(view)
            {
            }

            public FakeActionItemDefinitionFormPresenter(IActionItemDefinitionFormView view, ActionItemDefinition editActionItemDefinition) : base(view, editActionItemDefinition)
            {
            }

            public FakeActionItemDefinitionFormPresenter(IActionItemDefinitionFormView view, ActionItemDefinition editActionItemDefinition, IActionItemDefinitionService service,
                IBusinessCategoryService businessCategoryService, IWorkAssignmentService workAssignmentService, IActionItemService actionItemService,
                IFormEdmontonService formService,IUserService userService) : base(view, editActionItemDefinition, service, businessCategoryService,null, workAssignmentService, actionItemService, formService,userService)
            {
            }

            public void DoPreSaveOrUpdateWorkDespiteMethodBeingProtected(SaveUpdateDomainObjectContainer<ActionItemDefinition> objectToPersist)
            {
                DoPreSaveOrUpdateWorkBeforeShowingWaitForm(objectToPersist);
            }

            public SaveUpdateDomainObjectContainer<ActionItemDefinition> GetPopulatedEditObjectToUpdateDespiteMethodBeingProtected()
            {
                return GetPopulatedEditObjectToUpdate();
            }

            public void SetEditObject(ActionItemDefinition aid)
            {
                editObject = aid;
            }
        }
    }
}