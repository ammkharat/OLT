using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class SiteConfigurationServiceTest
    {
        Mockery mocks;
        ISiteConfigurationDao mockDao;
        ISiteConfigurationDefaultsDao mockDefaultsDao;
        ISapAutoImportConfigurationDao mockAutoImportConfigurationDao;
        ISiteDao mockSiteDao;
        ITimeDao mockTimeDao;

        ISiteConfigurationService service;
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockDao = mocks.NewMock<ISiteConfigurationDao>();
            mockDefaultsDao = mocks.NewMock<ISiteConfigurationDefaultsDao>();
            mockAutoImportConfigurationDao = mocks.NewMock<ISapAutoImportConfigurationDao>();
            mockSiteDao = mocks.NewMock<ISiteDao>();
            mockTimeDao = mocks.NewMock<ITimeDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockDao);
            DaoRegistry.RegisterDaoFor(mockDefaultsDao);
            DaoRegistry.RegisterDaoFor(mockAutoImportConfigurationDao);
            DaoRegistry.RegisterDaoFor(mockSiteDao);
            DaoRegistry.RegisterDaoFor(mockTimeDao);

            service = new SiteConfigurationService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldDelegateTaskToDaoOnUpdateWorkPermitArchivalProcess()
        {
            const long siteId = 1;
            const int expectedDaysBeforeArchivingClosedWorkPermits = 10;
            const int expectedDaysBeforeDeletingPendingWorkPermits = 20;
            const int expectedDaysBeforeClosingIssuedWorkPermits = 30;

            Expect.Once.On(mockDao).Method("UpdateWorkPermitArchivalProcess")
                .With(
                        siteId,
                        expectedDaysBeforeArchivingClosedWorkPermits,
                        expectedDaysBeforeDeletingPendingWorkPermits,
                        expectedDaysBeforeClosingIssuedWorkPermits
                    );

            service.UpdateWorkPermitArchivalProcess(siteId,
                                                    expectedDaysBeforeArchivingClosedWorkPermits,
                                                    expectedDaysBeforeDeletingPendingWorkPermits,
                                                    expectedDaysBeforeClosingIssuedWorkPermits);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
       
        [Ignore] [Test]
        public void ShouldDelegateToDaoOnUpdatingTargetDefinitionAutoReApprovalConfig()
        {
            const long siteId = 1;
            TargetDefinitionAutoReApprovalConfiguration targetDefConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateSampleTargetDefAutoReApprovalConfig(siteId);
            Expect.Once.On(mockDao).Method("UpdateTargetDefinitionAutoReApprovalConfiguration").With(targetDefConfig);
            service.UpdateTargetDefinitionAutoReApprovalConfiguration(targetDefConfig);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDaoOnUpdatingActionItemDefinitionAutoReApprovalConfig()
        {
            const long siteId = 1;
            ActionItemDefinitionAutoReApprovalConfiguration actionItemDefConfig = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSampleActionItemDefAutoReApprovalConfig(siteId);
            Expect.Once.On(mockDao).Method("UpdateActionItemDefinitionAutoReApprovalConfiguration").With(actionItemDefConfig);
            service.UpdateActionItemDefinitionAutoReApprovalConfiguration(actionItemDefConfig);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
