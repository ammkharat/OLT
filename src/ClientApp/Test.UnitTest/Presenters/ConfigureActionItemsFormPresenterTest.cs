using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigureActionItemsFormPresenterTest
    {
        Mockery mocks;
        IConfigureActionItemsForm mockView;
        ISiteConfigurationService mockService;
        ConfigureActionItemsFormPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IConfigureActionItemsForm>();
            mockService = mocks.NewMock<ISiteConfigurationService>();

            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            ClientSession.GetUserContext().User = currentUser;
            presenter = new ConfigureActionItemsFormPresenter(mockView, mockService);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldSetValueToViewOnLoad()
        {
            SiteConfiguration configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(ClientSession.GetUserContext().Site);

            long siteId = ClientSession.GetUserContext().Site.IdValue;

            Expect.Once.On(mockService).Method("QueryBySiteIdWithNoCaching").With(siteId).Will(Return.Value(configuration));
            Expect.Once.On(mockView).SetProperty("SiteName").To(ClientSession.GetUserContext().Site.Name);
            Expect.Once.On(mockView).SetProperty("AutoApproveWorkOrderActionItemDefinition").To(configuration.AutoApproveWorkOrderActionItemDefinition);
            Expect.Once.On(mockView).SetProperty("AutoApproveSAPAMActionItemDefinition").To(configuration.AutoApproveSAPAMActionItemDefinition);
            Expect.Once.On(mockView).SetProperty("AutoApproveSAPMCActionItemDefinition").To(configuration.AutoApproveSAPMCActionItemDefinition);
            Expect.Once.On(mockView).SetProperty("LogRequiredForActionItemResponse").To(configuration.RequireLogForActionItemResponse);
            Expect.Once.On(mockView).SetProperty("RequiresApprovalDefaultValue").To(configuration.ActionItemRequiresApprovalDefaultValue);
            Expect.Once.On(mockView).SetProperty("RequiresResponseDefaultValue").To(configuration.ActionItemRequiresResponseDefaultValue);

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldGetValueFromViewAndUpdateOnSave()
        {
            SiteConfiguration expected = SiteConfigurationFixture.CreateDefaultSiteConfiguration(ClientSession.GetUserContext().Site);

            Expect.Once.On(mockView).GetProperty("AutoApproveWorkOrderActionItemDefinition").Will(Return.Value(expected.AutoApproveWorkOrderActionItemDefinition));
            Expect.Once.On(mockView).GetProperty("AutoApproveSAPAMActionItemDefinition").Will(Return.Value(expected.AutoApproveSAPAMActionItemDefinition));
            Expect.Once.On(mockView).GetProperty("AutoApproveSAPMCActionItemDefinition").Will(Return.Value(expected.AutoApproveSAPMCActionItemDefinition));
            Expect.Once.On(mockView).GetProperty("LogRequiredForActionItemResponse").Will(Return.Value(expected.RequireLogForActionItemResponse));
            Expect.Once.On(mockView).GetProperty("RequiresApprovalDefaultValue").Will(Return.Value(expected.ActionItemRequiresApprovalDefaultValue));
            Expect.Once.On(mockView).GetProperty("RequiresResponseDefaultValue").Will(Return.Value(expected.ActionItemRequiresResponseDefaultValue));
            
            long siteId = ClientSession.GetUserContext().Site.IdValue;
            
            Expect.Once.On(mockService).Method("UpdateActionItemSettings").With(
                    siteId,
                    expected.AutoApproveWorkOrderActionItemDefinition,
                    expected.AutoApproveSAPAMActionItemDefinition,
                    expected.AutoApproveSAPMCActionItemDefinition,
                    expected.RequireLogForActionItemResponse,
                    expected.ActionItemRequiresApprovalDefaultValue,
                    expected.ActionItemRequiresResponseDefaultValue);

            Expect.Once.On(mockView).Method("Close");

            presenter.HandleSaveButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCloseViewOnCancel()
        {
            Expect.Once.On(mockView).Method("Close");

            presenter.HandleCancelButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
            
        }
    }
}
