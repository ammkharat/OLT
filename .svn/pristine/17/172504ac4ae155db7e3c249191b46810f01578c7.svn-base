using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigureWorkPermitArchivalProcessFormPresenterTest
    {
        private Mockery mockery;
        private ISiteConfigurationService mockService;
        private IConfigureWorkPermitArchivalProcessForm mockView;
        private ConfigureWorkPermitArchivalProcessFormPresenter presenter;
        private SiteConfiguration configuration;
        private long siteId;
        
        [SetUp]
        public void SetUp()
        {
            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            Site site = currentUser.AvailableSites[0];
            siteId = site.Id.Value;
            
            ClientSession.GetUserContext().User = currentUser;
            
            configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            
            mockery = new Mockery();
            mockView = mockery.NewMock<IConfigureWorkPermitArchivalProcessForm>();
            mockService = mockery.NewMock<ISiteConfigurationService>();

            presenter = new ConfigureWorkPermitArchivalProcessFormPresenter(mockView, mockService);
            
        }
        
        [Test]
        public void ShouldLoadUpTheConfigurationData()
        {
            Expect.Once.On(mockView).SetProperty("SiteName").To(ClientSession.GetUserContext().Site.Name);
            Expect.Once.On(mockService).Method("QueryBySiteId").Will(Return.Value(configuration));

            Expect.Once.On(mockView).SetProperty("DaysBeforeArchivingClosedWorkPermits").To(configuration.DaysBeforeArchivingClosedWorkPermits);
            Expect.Once.On(mockView).SetProperty("DaysBeforeDeletingPendingWorkPermits").To(configuration.DaysBeforeDeletingPendingWorkPermits);
            Expect.Once.On(mockView).SetProperty("DaysBeforeClosingIssuedWorkPermits").To(configuration.DaysBeforeClosingIssuedWorkPermits);

            presenter.LoadForm(null, EventArgs.Empty);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldGetDataFromViewOnHandleSaveButtonClick()
        {
            Expect.Once.On(mockView).GetProperty("DaysBeforeArchivingClosedWorkPermits")
                .Will(Return.Value(configuration.DaysBeforeArchivingClosedWorkPermits));
            Expect.Once.On(mockView).GetProperty("DaysBeforeDeletingPendingWorkPermits")
                .Will(Return.Value(configuration.DaysBeforeDeletingPendingWorkPermits));
            Expect.Once.On(mockView).GetProperty("DaysBeforeClosingIssuedWorkPermits")
                .Will(Return.Value(configuration.DaysBeforeClosingIssuedWorkPermits));

            Expect.Once.On(mockService).Method("UpdateWorkPermitArchivalProcess")
                .With(
                        siteId,
                        configuration.DaysBeforeArchivingClosedWorkPermits,
                        configuration.DaysBeforeDeletingPendingWorkPermits,
                        configuration.DaysBeforeClosingIssuedWorkPermits
                    );

            Expect.Once.On(mockView).Method("Close");

            Expect.Never.On(mockView).Method("SaveFailedMessage");

            Stub.On(mockView);

            presenter.HandleSaveButtonClick(null, EventArgs.Empty);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void HandleSaveButtonClickWithZeroDaysShouldShowValidationError()
        {
            Expect.Once.On(mockView).GetProperty("DaysBeforeArchivingClosedWorkPermits").
                Will(Return.Value(0));
            Expect.Once.On(mockView).GetProperty("DaysBeforeDeletingPendingWorkPermits").
                Will(Return.Value(0));
            Expect.Once.On(mockView).GetProperty("DaysBeforeClosingIssuedWorkPermits").
                Will(Return.Value(0));

            Expect.Once.On(mockView).Method("ShowDaysBeforeArchivingClosedWorkPermitsError").
                With(StringResources.WorkPermitArchivalProcessDaysError);
            Expect.Once.On(mockView).Method("ShowDaysBeforeDeletingPendingWorkPermitsError").
                With(StringResources.WorkPermitArchivalProcessDaysError);
            Expect.Once.On(mockView).Method("ShowDaysBeforeClosingIssuedWorkPermitsError").
                With(StringResources.WorkPermitArchivalProcessDaysError);

            Stub.On(mockView);
            
            presenter.HandleSaveButtonClick(null, null);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void HandleSaveButtonClickShouldClearErrorMessagesBeforeValidation()
        {
            using (mockery.Ordered)
            {
                Expect.Once.On(mockView).GetProperty("DaysBeforeArchivingClosedWorkPermits").
                     Will(Return.Value(0));
                Expect.Once.On(mockView).Method("ClearErrorMessages");
            }

            OltStub.On(mockView);

            presenter.HandleSaveButtonClick(null, null);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldShowFailedSaveMessageWhenExceptionOccursOnSave()
        {
            Expect.Once.On(mockView).GetProperty("DaysBeforeArchivingClosedWorkPermits")
               .Will(Return.Value(configuration.DaysBeforeArchivingClosedWorkPermits));
            Expect.Once.On(mockView).GetProperty("DaysBeforeDeletingPendingWorkPermits")
                .Will(Return.Value(configuration.DaysBeforeDeletingPendingWorkPermits));
            Expect.Once.On(mockView).GetProperty("DaysBeforeClosingIssuedWorkPermits")
                .Will(Return.Value(configuration.DaysBeforeClosingIssuedWorkPermits));

            Expect.Once.On(mockService).Method("UpdateWorkPermitArchivalProcess")
                .With(
                        siteId,
                        configuration.DaysBeforeArchivingClosedWorkPermits,
                        configuration.DaysBeforeDeletingPendingWorkPermits,
                        configuration.DaysBeforeClosingIssuedWorkPermits
                    )
                .Will(Throw.Exception(new ApplicationException()));

            Expect.Never.On(mockView).Method("SaveSucceededMessage");
            Expect.Never.On(mockView).Method("Close");

            Expect.Once.On(mockView).Method("SaveFailedMessage");

            Stub.On(mockView);
            
            presenter.HandleSaveButtonClick(null, EventArgs.Empty);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCloseViewOnHandleCancelButtonClick()
        {
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleCancelButtonClick(null, EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
