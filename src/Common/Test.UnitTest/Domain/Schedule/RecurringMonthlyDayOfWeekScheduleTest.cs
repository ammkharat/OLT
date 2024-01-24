using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringMonthlyDayOfWeekScheduleTest
    {
        private RecurringMonthlyDayOfWeekSchedule monthlyScheduleForSecondWednesday;
        private RecurringMonthlyDayOfWeekSchedule monthlyScheduleOnLastFridayOfAllMonths;
        
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            monthlyScheduleForSecondWednesday = RecurringMonthlyScheduleFixture.CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31();
            monthlyScheduleOnLastFridayOfAllMonths = RecurringMonthlyScheduleFixture.CreateMonthlyScheduleFrom8AMTo5PMForTheLastFridayOfAllMonthsBetweenJanuary1AndDecember31();

        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldDescribeSecondWednesday()
        {
            Assert.AreEqual(WeekOfMonth.Second, monthlyScheduleForSecondWednesday.WeekOfMonth);
            Assert.AreEqual(DayOfWeek.Wednesday, monthlyScheduleForSecondWednesday.DayOfWeek);
        }

        [Test]
        public void ShouldContainMarchAndMay()
        {
            Assert.IsTrue(monthlyScheduleForSecondWednesday.ContainsMonth(Month.March));
            Assert.IsTrue(monthlyScheduleForSecondWednesday.ContainsMonth(Month.May));
        }

        [Test]
        public void ShouldNotContainApril()
        {
            Assert.IsFalse(monthlyScheduleForSecondWednesday.ContainsMonth(Month.April));
        }

        [Test]
        public void ShouldDescribeFrom9AmTo4PM()
        {
            Assert.AreEqual(new Time(9, 0), monthlyScheduleForSecondWednesday.StartTime);
            Assert.AreEqual(new Time(16, 0), monthlyScheduleForSecondWednesday.EndTime);
        }

        [Test]
        public void ShouldDescribeBetweenJanuary1stAndDecember31st()
        {
            Assert.AreEqual(new Date(2005,1,1), monthlyScheduleForSecondWednesday.StartDate);
            Assert.AreEqual(new Date(2005,12,31), monthlyScheduleForSecondWednesday.EndDate);
        }

        [Test]
        public void ShouldDescribeLastFriday()
        {
            Assert.AreEqual(WeekOfMonth.Last, monthlyScheduleOnLastFridayOfAllMonths.WeekOfMonth);
            Assert.AreEqual(DayOfWeek.Friday, monthlyScheduleOnLastFridayOfAllMonths.DayOfWeek);
        }

        [Test]
        public void ShouldContainAllTheMonths()
        {
            foreach (Month month in Month.All)
            {
                Assert.IsTrue(monthlyScheduleOnLastFridayOfAllMonths.ContainsMonth(month));
            }
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof(RecurringMonthlyDayOfWeekSchedule).IsSerializable);
        }

        [Test]
        public void TwoSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(RecurringMonthlyScheduleFixture.CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31(), RecurringMonthlyScheduleFixture.CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31());
        }

        [Test]
        public void ShouldShowToStringWithEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time toTime = new Time(15, 15);
            List<Month> monthsToInclude = new List<Month> { Month.May, Month.June };
            WeekOfMonth weekOfMonth = WeekOfMonth.First;

            DayOfWeek dayOfWeek = DayOfWeek.Friday;

            RecurringMonthlyDayOfWeekSchedule monthlyDayOfWeekSchedule =
                    new RecurringMonthlyDayOfWeekSchedule(startDate, endDate, fromTime, toTime, weekOfMonth, dayOfWeek, monthsToInclude, SiteFixture.Sarnia());

            Assert.That(monthlyDayOfWeekSchedule.ToString(true),
                        Is.EqualTo("Every Friday of the First week from 05/06/2011 to 07/08/2011 between 04:00 and 15:15 on the month(s) May, June"));
            
        }

        [Test]
        public void ShouldShowToStringWithNoEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time toTime = new Time(15, 15);
            List<Month> monthsToInclude = new List<Month> { Month.May, Month.June };
            WeekOfMonth weekOfMonth = WeekOfMonth.First;

            DayOfWeek dayOfWeek = DayOfWeek.Friday;

            RecurringMonthlyDayOfWeekSchedule monthlyDayOfWeekSchedule =
                    new RecurringMonthlyDayOfWeekSchedule(startDate, endDate, fromTime, toTime, weekOfMonth, dayOfWeek, monthsToInclude, SiteFixture.Sarnia());

            Assert.That(monthlyDayOfWeekSchedule.ToString(false),
                        Is.EqualTo("Every Friday of the First week from 05/06/2011 to 07/08/2011 at 04:00 on the month(s) May, June"));

        }

    }
}
