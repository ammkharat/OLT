using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    [TestFixture]
    public class ContinuousScheduleCalculatorTest
    {
        private OltTimeZoneInfo timeZone;
        private ContinuousScheduleCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            timeZone = TimeZoneFixture.GetSarniaTimeZone();

            Clock.Freeze();
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
        }

        [TearDown]
        public void TearDown()
        {          
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldGetNextInvokeDateTime()
        {
            Clock.Now = new DateTime(2005, 10, 15 ,0, 0, 0);

            DateTime startDateTime = new DateTime(2005, 10, 16, 0, 0, 0);
            DateTime endDateTime = new DateTime(2008, 10, 12, 0, 0, 0);

            calculator = new ContinuousScheduleCalculator(timeZone, startDateTime, endDateTime);

            Assert.AreEqual(startDateTime, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void ShouldGetNextInvokeDateTimeAsMaxDateTimeIfCurrentTimeIsPastScheduleEndDateTime()
        {
            Clock.Now = new DateTime(2008, 10, 12, 0, 0, 1);

            DateTime startDateTime = new DateTime(2005, 10, 16, 0, 0, 0);
            DateTime endDateTime = new DateTime(2008, 10, 12, 0, 0, 0);

            calculator = new ContinuousScheduleCalculator(timeZone, startDateTime, endDateTime);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeDateTimeShouldNotChangeUntilCurrentTimePassesScheduleEndDateTime()
        {
            Clock.Now = new DateTime(2005, 10, 16, 0, 0, 0);

            DateTime startDateTime = new DateTime(2005, 10, 16, 0, 0, 0);
            DateTime endDateTime = new DateTime(2008, 10, 12, 0, 0, 0);

            calculator = new ContinuousScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(startDateTime, calculator.GetNextInvokeDateTime());

            Clock.Now = new DateTime(2006, 10, 16, 0, 0, 0);
            calculator = new ContinuousScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(startDateTime, calculator.GetNextInvokeDateTime());

            Clock.Now = new DateTime(2008, 10, 16, 0, 0, 0);
            calculator = new ContinuousScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }
    }
}