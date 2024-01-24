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
    public class DeleteRejectedWorkPermitJobTest
    {
        private DeleteRejectedWorkPermitsJob job;
        private Mockery mock;
        private ILog mockLogger;
        private IWorkPermitService mockWorkPermitService;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockWorkPermitService = mock.NewMock<IWorkPermitService>();

            mockLogger = mock.NewMock<ILog>();

            job =
                new DeleteRejectedWorkPermitsJob(
                    RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                    mockWorkPermitService, mockLogger);
        }

        [Test]
        public void ShouldBeIScheduledJob()
        {
            Assert.That(job, Is.InstanceOf(typeof (IScheduledJob)));
        }

        [Test]
        public void ShouldMarkRejectedWorkPermitsAsDeleted()
        {
            Expect.Once.On(mockWorkPermitService).Method("DeleteRejectedWorkPermits");
            Stub.On(mockLogger);

            job.Execute();
            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}