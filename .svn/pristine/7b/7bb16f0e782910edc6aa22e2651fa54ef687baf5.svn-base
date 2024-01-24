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
    public class ExpireLocksJobTest
    {
        private ExpireLocksJob job;
        private Mockery mock;
        private ILog mockLogger;
        private IObjectLockingService mockObjectLockingService;


        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockLogger = mock.NewMock<ILog>();
            mockObjectLockingService = mock.NewMock<IObjectLockingService>();

            job =
                new ExpireLocksJob(
                    RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006(), 4,
                    mockObjectLockingService, mockLogger);
        }

        [Test]
        public void ShouldBeIScheduledJob()
        {
            Assert.That(job, Is.InstanceOf(typeof (IScheduledJob)));
        }

        [Test]
        public void ShouldExecuteDeleteInactivePendingWorkPermits()
        {
            Expect.Once.On(mockObjectLockingService).Method("ExpireLocks");
            Stub.On(mockLogger);
            job.Execute();

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}