using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    /// <summary>
    /// Summary description for RecurringMonthlyScheduleeTest
    /// </summary>
    [TestFixture]
    public class RecurringMonthlyDayOfMonthScheduleTest
    {
        private RecurringMonthlyDayOfMonthSchedule monthlyScheduleOn15th;
        private RecurringMonthlyDayOfMonthSchedule monthlyScheduleOnLastDayOfMonth;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            monthlyScheduleOn15th =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            monthlyScheduleOnLastDayOfMonth =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMForLastDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldDescribeFifteenthDayOfMonth()
        {
            Assert.AreEqual(DayOfMonth.Day(15), monthlyScheduleOn15th.DayOfMonth);
        }

        [Test]
        public void ShouldContainJanuaryAndFebruary()
        {
            Assert.IsTrue(monthlyScheduleOn15th.ContainsMonth(Month.January));
            Assert.IsTrue(monthlyScheduleOn15th.ContainsMonth(Month.February));
        }

        [Test]
        public void ShouldNotContainMarch()
        {
            Assert.IsFalse(monthlyScheduleOn15th.ContainsMonth(Month.March));
        }

        [Test]
        public void ShouldDescribeStartDateAsJan1st2005AndEndDateAs2005Dec31st()
        {
            Assert.AreEqual(new Date(2005, 1, 1), monthlyScheduleOn15th.StartDate);
            Assert.AreEqual(new Date(2005, 12, 31), monthlyScheduleOn15th.EndDate);
        }

        [Test]
        public void ShouldDescribeFromTimeAs8AmAndToTimeAs12PM()
        {
            Assert.AreEqual(new Time(8, 0), monthlyScheduleOn15th.StartTime);
            Assert.AreEqual(new Time(12, 0), monthlyScheduleOn15th.EndTime);
        }

        [Test]
        public void ShouldDescribeLastDayOfMonth()
        {
            Assert.AreEqual(DayOfMonth.Last, monthlyScheduleOnLastDayOfMonth.DayOfMonth);
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof (RecurringMonthlyDayOfMonthSchedule).IsSerializable);
        }

        [Test]
        public void TwoSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31(),
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31());
        }

        [Test]
        public void ShouldShowToStringWithEndTime()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time time = new Time(15, 15);
            List<Month> monthsToInclude = new List<Month> {Month.May, Month.June};
            DayOfMonth dayOfMonth = DayOfMonth.Day(7);

            RecurringMonthlyDayOfMonthSchedule recurringMonthlyDayOfMonthSchedule = 
                    new RecurringMonthlyDayOfMonthSchedule(startDate, endDate, fromTime, time, dayOfMonth, monthsToInclude, SiteFixture.Sarnia());

            Assert.That(recurringMonthlyDayOfMonthSchedule.ToString(true), 
                        Is.EqualTo("Every 7th day from 05/06/2011 to 07/08/2011 between 04:00 and 15:15 on the month(s) May, June"));
        }

        [Test]
        public void ShouldShowToStringWithNoEndTime()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time time = new Time(15, 15);
            List<Month> monthsToInclude = new List<Month> { Month.May, Month.June };
            DayOfMonth dayOfMonth = DayOfMonth.Day(7);

            RecurringMonthlyDayOfMonthSchedule recurringMonthlyDayOfMonthSchedule =
                    new RecurringMonthlyDayOfMonthSchedule(startDate, endDate, fromTime, time, dayOfMonth, monthsToInclude, SiteFixture.Sarnia());

            Assert.That(recurringMonthlyDayOfMonthSchedule.ToString(false),
                        Is.EqualTo("Every 7th day from 05/06/2011 to 07/08/2011 at 04:00 on the month(s) May, June"));
        }

    }
}