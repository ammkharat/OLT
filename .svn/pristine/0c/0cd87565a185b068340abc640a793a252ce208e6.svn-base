using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class ScheduleTypeTest
    {
        [Test]    
        public void ShouldBeEqual()
        {
            ScheduleType typeA = ScheduleType.GetById(1);
            ScheduleType typeB = ScheduleType.GetById(1);

            Assert.That(typeA == typeB);
        }

        [Test]
        public void ShouldNotBeEqual()
        {
            ScheduleType typeA = ScheduleType.GetById(1);
            ScheduleType typeB = ScheduleType.GetById(2);

            Assert.That(typeA != typeB);
        }
    }
}