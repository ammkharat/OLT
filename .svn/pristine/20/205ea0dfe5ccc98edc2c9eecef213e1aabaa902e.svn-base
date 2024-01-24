using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ScheduleServiceTest
    {
        private ScheduleService service;
        private Mockery mock;
        private IScheduleDao mockScheduleDao;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockScheduleDao = mock.NewMock<IScheduleDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockScheduleDao);

            service = new ScheduleService();
        }

        [Ignore] [Test]
        public void ShouldFindScheduleService()
        {
            Assert.IsNotNull(service);
        }


        [Ignore] [Test]
        public void ShouldUpdateRecurringDailySchedule()
        {
            ISchedule schedule = RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            Stub.On(mockScheduleDao).Method("Update").With(schedule);
            service.Update(schedule);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
