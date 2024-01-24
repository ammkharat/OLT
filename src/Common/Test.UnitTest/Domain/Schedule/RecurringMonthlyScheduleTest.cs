using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringMonthlyScheduleTest
    {
        private RecurringMonthlySchedule recurringMonthlySchedule;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            recurringMonthlySchedule =
                RecurringMonthlyScheduleFixture.CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void RecurringWeeklyScheduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof(RecurringMonthlySchedule).IsSerializable);
        }

        [Test]
        public void RecurringMonthlyScheduleShouldContainJanuaryAndFebruary()
        {
            Assert.IsTrue(recurringMonthlySchedule.ContainsMonth(Month.January));
            Assert.IsTrue(recurringMonthlySchedule.ContainsMonth(Month.February));
        }

        [Test]
        public void RecurringMonthlyScheduleShouldDescribeFrom8AMTO2PM()
        {
            Assert.AreEqual(new Time(8, 00), recurringMonthlySchedule.StartTime);
            Assert.AreEqual(new Time(12, 00), recurringMonthlySchedule.EndTime);
        }

        [Test]
        public void RecurringMonthlyScheduleShouldDescribeDateBoundariesWithin2005Jan1stand2005Dec31st()
        {
            Assert.AreEqual(new Date(2005, 1, 1), recurringMonthlySchedule.StartDate);
            Assert.AreEqual(new Date(2005, 12, 31), recurringMonthlySchedule.EndDate);
        }
        
        [Test]
        public void RecurringMonthlyScheduleShouldHaveWeeklyFrequencyOfOne()
        {
            Assert.AreEqual(1, recurringMonthlySchedule.Frequency);
        }

        [Test]
        public void RecurringMonthlyScheduleShouldImplementISchedule()
        {
            Assert.IsTrue(recurringMonthlySchedule is ISchedule);
        }


        [Test]
        public void TwoSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(
                RecurringMonthlyScheduleFixture.CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31(),
                RecurringMonthlyScheduleFixture.CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31());
        }
        
        [Test]
        public void ShouldDeterminePreviousOccurrenceGivenDateTime()
        {
            DateTime someTime = new DateTime(2006, 5, 12, 12, 59, 59);
            Assert.AreEqual(someTime.AddMonths(-1), recurringMonthlySchedule.GetPreviousOccurrence(someTime));
        }
    }
}
