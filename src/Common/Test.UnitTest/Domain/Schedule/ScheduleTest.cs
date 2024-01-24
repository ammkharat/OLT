using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class ScheduleTest
    {
        [Test]
        public void OverlapShouldIdentifySingleScheduleOverlappingAnother()
        {
            Date startDate = new Date(2006, 2, 2);
            Site site = SiteFixture.Sarnia();
            ISchedule scheduleOne =
                new SingleSchedule(startDate, new Time(6, 0, 0), new Time(18, 0, 0), site);
            ISchedule scheduleTwo =
                new SingleSchedule(startDate, new Time(7, 0, 0), new Time(19, 0, 0), site);
            Assert.IsTrue(scheduleOne.Overlaps(scheduleTwo));
            Assert.IsTrue(scheduleTwo.Overlaps(scheduleOne));
        }

        [Test]
        public void OverlapShouldIdentifyRecurringScheduleNotOverlappingAnother()
        {
            Site site = SiteFixture.Sarnia();
            Date startDate = new Date(2006, 2, 2);
            Date endDate = new Date(2006, 4, 14);
            ISchedule scheduleOne = new RecurringHourlySchedule(startDate, endDate, new Time(12), new Time(13), 1, site);
            ISchedule scheduleTwo = new SingleSchedule(endDate, new Time(13, 0, 1), new Time(22), site);
            Assert.IsFalse(scheduleOne.Overlaps(scheduleTwo));
            Assert.IsFalse(scheduleTwo.Overlaps(scheduleOne));
        }

    }
}