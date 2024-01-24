using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class CloseAllIssuedWorkPermitsJobTest
    {
        private CloseAllIssuedWorkPermitsJob job;
        private Mockery mock;
        private ILog mockLogger;
        private ISiteService mockSiteService;
        private IWorkPermitService mockWorkPermitService;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockSiteService = mock.NewMock<ISiteService>();
            mockWorkPermitService = mock.NewMock<IWorkPermitService>();
            mockLogger = mock.NewMock<ILog>();
            job =
                new CloseAllIssuedWorkPermitsJob(
                    RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                    mockSiteService, mockWorkPermitService, mockLogger);
        }

        [Test]
        public void ShouldBeIScheduledJob()
        {
            Assert.That(job, Is.InstanceOf(typeof (IScheduledJob)));
        }

        [Test]
        public void ShouldExecuteDeleteInactivePendingWorkPermits()
        {
            var sites = SiteFixture.GetSites();
            Expect.Once.On(mockSiteService).Method("GetAll").Will(Return.Value(sites));
            Stub.On(mockLogger);

            foreach (var testSite in sites)
            {
                Expect.Once.On(mockWorkPermitService)
                    .Method("CloseInactiveIssuedWorkPermitsBySiteConfiguration")
                    .With(testSite);
            }
            job.Execute();

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}