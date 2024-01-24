using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NUnit.Framework;
using NMock2;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class FieldAutoReApprovalConfigurationFormPresenterTest
    {
        private Mockery mocks;
        private ISiteConfigurationService mockSiteConfigurationService;
        private IFieldAutoReApprovalConfigurationFormView mockView;
        private ITargetDefinitionAutoReApprovalConfigurationView mockTargetDefConfigView;
        private IActionItemDefinitionAutoReApprovalConfigurationView mockAIDConfigView;
        private FieldAutoReApprovalConfigurationFormPresenter presenter;

        private User currentUser;
        private Site currentSite;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IFieldAutoReApprovalConfigurationFormView>();
            mockTargetDefConfigView = mocks.NewMock<ITargetDefinitionAutoReApprovalConfigurationView>();
            mockAIDConfigView = mocks.NewMock<IActionItemDefinitionAutoReApprovalConfigurationView>();

            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();

            currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            currentSite = currentUser.AvailableSites[0];
            ClientSession.GetUserContext().User = currentUser;
            presenter = new FieldAutoReApprovalConfigurationFormPresenter(mockView, mockSiteConfigurationService);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldPopulateDataToViewWhenHandlingLoad()
        {
            SiteConfiguration defaultSiteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(currentSite);

            Expect.Once.On(mockView).SetProperty("SiteName").To(currentSite.Name);
            Expect.Once.On(mockSiteConfigurationService).Method("QueryBySiteIdWithNoCaching").With(currentSite.Id.Value).Will(Return.Value(defaultSiteConfiguration));

            TargetDefinitionAutoReApprovalConfiguration targetDefConfig = defaultSiteConfiguration.TargetDefinitionAutoReApprovalConfiguration;
            SetterExpectationForTargetDefConfigView(targetDefConfig);

            ActionItemDefinitionAutoReApprovalConfiguration aidConfig = defaultSiteConfiguration.ActionItemDefinitionAutoReApprovalConfiguration;
            SetterExpectationForAIDConfigView(aidConfig);

            presenter.HandleLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetAllWhenHandlingTargetDefConfigSelectAll()
        {
            TargetDefinitionAutoReApprovalConfiguration allSelectedTargetDefConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedTargetDefAutoReApprovalConfig(currentSite.Id.Value);
            SetterExpectationForTargetDefConfigView(allSelectedTargetDefConfig);
            presenter.HandleTargetDefinitionConfigSelectAll(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldUnSetAllWhenHandlingTargetDefConfigClear()
        {
            TargetDefinitionAutoReApprovalConfiguration selectedNoneConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneTargetDefAutoReApprovalConfig(currentSite.Id.Value);
            SetterExpectationForTargetDefConfigView(selectedNoneConfig);
            presenter.HandleTargetDefinitionConfigClearAll(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetAllWhenHandlingActionItemDefinitionSelectAll()
        {
            ActionItemDefinitionAutoReApprovalConfiguration allSelectedAIDConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateAllSelectedAIDAutoReApprovalConfiguration(currentSite.Id.Value);
            SetterExpectationForAIDConfigView(allSelectedAIDConfig);
            presenter.HandleActionItemDefinitionConfigSelectAll(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldClearAllWhenHandlingActionItemDefinitionClearAll()
        {
            ActionItemDefinitionAutoReApprovalConfiguration noneSelectedAIDConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneAIDAutoReApprovalConfiguration(currentSite.Id.Value);
            SetterExpectationForAIDConfigView(noneSelectedAIDConfig);
            presenter.HandleActionItemDefinitionConfigClearAll(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldGetDataFromViewAndPersistWhenHandlingSave()
        {
            TargetDefinitionAutoReApprovalConfiguration targetDefConfigFromView = TargetDefinitionAutoReApprovalConfigurationFixture.CreateSampleTargetDefAutoReApprovalConfig(currentSite.Id.Value);
            GetterExpectationForTargetDefConfigView(targetDefConfigFromView);
            Expect.Once.On(mockSiteConfigurationService).Method("UpdateTargetDefinitionAutoReApprovalConfiguration").With(targetDefConfigFromView);

            ActionItemDefinitionAutoReApprovalConfiguration aidConfigFromView = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSampleActionItemDefAutoReApprovalConfig(currentSite.Id.Value);
            GetterExpectationForAIDConfigView(aidConfigFromView);
            Expect.Once.On(mockSiteConfigurationService).Method("UpdateActionItemDefinitionAutoReApprovalConfiguration").With(aidConfigFromView);

            Expect.Once.On(mockView).Method("SaveSucceededMessage");
            Expect.Once.On(mockView).Method("Close");

            presenter.HandleSave(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCloseViewAndNothingElseWhenHandlingCancel()
        {
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleCancel(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        private void SetterExpectationForTargetDefConfigView(TargetDefinitionAutoReApprovalConfiguration targetDefConfig)
        {
            Expect.Once.On(mockView).GetProperty("TargetDefAutoReApprovalConfigView").Will(Return.Value(mockTargetDefConfigView));
            Expect.Once.On(mockTargetDefConfigView).SetProperty("NameChange").To(targetDefConfig.NameChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("CategoryChange").To(targetDefConfig.CategoryChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("OperationalModeChange").To(targetDefConfig.OperationalModeChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("PriorityChange").To(targetDefConfig.PriorityChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("DescriptionChange").To(targetDefConfig.DescriptionChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("DocumentLinksChange").To(targetDefConfig.DocumentLinksChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("FunctionalLocationChange").To(targetDefConfig.FunctionalLocationChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("PHTagChange").To(targetDefConfig.PHTagChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("TargetDependenciesChange").To(targetDefConfig.TargetDependenciesChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("ScheduleChange").To(targetDefConfig.ScheduleChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("GenerateActionItemChange").To(targetDefConfig.GenerateActionItemChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("RequiresResponseWhenAlertedChange").To(targetDefConfig.RequiresResponseWhenAlertedChange);
            Expect.Once.On(mockTargetDefConfigView).SetProperty("SuppressAlertChange").To(targetDefConfig.SuppressAlertChange);
        }

        private void GetterExpectationForTargetDefConfigView(TargetDefinitionAutoReApprovalConfiguration targetDefConfig)
        {
            Expect.Once.On(mockView).GetProperty("TargetDefAutoReApprovalConfigView").Will(Return.Value(mockTargetDefConfigView));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("NameChange").Will(Return.Value(targetDefConfig.NameChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("CategoryChange").Will(Return.Value(targetDefConfig.CategoryChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("OperationalModeChange").Will(Return.Value(targetDefConfig.OperationalModeChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("PriorityChange").Will(Return.Value(targetDefConfig.PriorityChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("DescriptionChange").Will(Return.Value(targetDefConfig.DescriptionChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("DocumentLinksChange").Will(Return.Value(targetDefConfig.DocumentLinksChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("FunctionalLocationChange").Will(Return.Value(targetDefConfig.FunctionalLocationChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("PHTagChange").Will(Return.Value(targetDefConfig.PHTagChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("TargetDependenciesChange").Will(Return.Value(targetDefConfig.TargetDependenciesChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("ScheduleChange").Will(Return.Value(targetDefConfig.ScheduleChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("GenerateActionItemChange").Will(Return.Value(targetDefConfig.GenerateActionItemChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("RequiresResponseWhenAlertedChange").Will(Return.Value(targetDefConfig.RequiresResponseWhenAlertedChange));
            Expect.Once.On(mockTargetDefConfigView).GetProperty("SuppressAlertChange").Will(Return.Value(targetDefConfig.SuppressAlertChange));
        }

        private void SetterExpectationForAIDConfigView(ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            Expect.Once.On(mockView).GetProperty("AIDAutoReApprovalConfigView").Will(Return.Value(mockAIDConfigView));
            Expect.Once.On(mockAIDConfigView).SetProperty("NameChange").To(aidConfig.NameChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("CategoryChange").To(aidConfig.CategoryChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("OperationalModeChange").To(aidConfig.OperationalModeChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("PriorityChange").To(aidConfig.PriorityChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("DescriptionChange").To(aidConfig.DescriptionChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("DocumentLinksChange").To(aidConfig.DocumentLinksChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("FunctionalLocationsChange").To(aidConfig.FunctionalLocationsChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("TargetDependenciesChange").To(aidConfig.TargetDependenciesChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("ScheduleChange").To(aidConfig.ScheduleChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("RequiresResponseWhenTriggeredChange").To(aidConfig.RequiresResponseWhenTriggeredChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("AssignmentChange").To(aidConfig.AssignmentChange);
            Expect.Once.On(mockAIDConfigView).SetProperty("ActionItemGenerationModeChange").To(aidConfig.ActionItemGenerationModeChange);
        }

        private void GetterExpectationForAIDConfigView(ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            Expect.Once.On(mockView).GetProperty("AIDAutoReApprovalConfigView").Will(Return.Value(mockAIDConfigView));
            Expect.Once.On(mockAIDConfigView).GetProperty("NameChange").Will(Return.Value(aidConfig.NameChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("CategoryChange").Will(Return.Value(aidConfig.CategoryChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("OperationalModeChange").Will(Return.Value(aidConfig.OperationalModeChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("PriorityChange").Will(Return.Value(aidConfig.PriorityChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("DescriptionChange").Will(Return.Value(aidConfig.DescriptionChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("DocumentLinksChange").Will(Return.Value(aidConfig.DocumentLinksChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("FunctionalLocationsChange").Will(Return.Value(aidConfig.FunctionalLocationsChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("TargetDependenciesChange").Will(Return.Value(aidConfig.TargetDependenciesChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("ScheduleChange").Will(Return.Value(aidConfig.ScheduleChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("RequiresResponseWhenTriggeredChange").Will(Return.Value(aidConfig.RequiresResponseWhenTriggeredChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("AssignmentChange").Will(Return.Value(aidConfig.AssignmentChange));
            Expect.Once.On(mockAIDConfigView).GetProperty("ActionItemGenerationModeChange").Will(Return.Value(aidConfig.ActionItemGenerationModeChange));
        }
    }
}
