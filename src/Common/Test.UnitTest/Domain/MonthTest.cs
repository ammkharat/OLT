using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for MonthTest
    /// </summary>
    [TestFixture]
    public class MonthTest
    {

        [Test]
        public void MonthShouldContainJanuaryAndItShouldBeTheSameObject()
        {
            Assert.AreSame(Month.January, Month.January);
        }

        [Test]
        public void ToStringShouldReturnAFriendlyVersionOfTheMonthName()
        {
            Assert.AreEqual("December", Month.December.ToString());
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof(Month).IsSerializable);
        }

        [Test]
        public void ShouldBeAbleToRetrieveAbbreviationForEachMonth()
        {
            Assert.AreEqual("Apr", Month.April.Abbreviation);
        }

        [Test]
        public void AllShouldReturnAllMonthsInChronologicalOrder()
        {
            Assert.AreEqual(12, Month.All.Count);
            Assert.AreEqual(Month.January, Month.All[0]);
            Assert.AreEqual(Month.February, Month.All[1]);
            Assert.AreEqual(Month.March, Month.All[2]);
            Assert.AreEqual(Month.April, Month.All[3]);
            Assert.AreEqual(Month.May, Month.All[4]);
            Assert.AreEqual(Month.June, Month.All[5]);
            Assert.AreEqual(Month.July, Month.All[6]);
            Assert.AreEqual(Month.August, Month.All[7]);
            Assert.AreEqual(Month.September, Month.All[8]);
            Assert.AreEqual(Month.October, Month.All[9]);
            Assert.AreEqual(Month.November, Month.All[10]);
            Assert.AreEqual(Month.December, Month.All[11]);
        }


        [Test]
        public void ShouldBeEqualWhenCompareSameMonth()
        {
            Assert.AreEqual(Month.January, Month.January);
        }

        [Test]
        public void TwoMonthsShouldBeEqual()
        {
            //Assert.AreEqual(DayOfMonth.Last, DayOfMonth.Last );
            Assert.IsTrue(Month.December.Abbreviation.Equals(Month.December.Abbreviation));
        }

        [Test]
        public void TwoDifferentMonthsShouldNotBeEqual()
        {
            //Assert.AreEqual(DayOfMonth.Last, DayOfMonth.Last );
            Assert.IsFalse(Month.November.Abbreviation.Equals(Month.December.Abbreviation));
        }


        [Test]
        public void MonthShouldReturnFalseWhenComparedWithObject()
        {
            Assert.IsFalse(Month.December.Equals(new Object()));
        }

        [Test]
        public void MonthShouldReturnFalseWhenComparedWithNullObject()
        {
            Assert.IsFalse(Month.December.Equals(null));
        }

        [Test]
        public void NextMonthAfterJanShouldBeFeb()
        {
            List<Month> checkList = new List<Month> {Month.January, Month.February, Month.July};

            Assert.AreEqual(Month.February, Month.January.GetNextMonthIn(checkList));
        }

        [Test]
        public void NextMonthAfterFebruaryShouldBeMarch()
        {
            List<Month> checkList = Month.All;
            Assert.AreEqual(Month.March, Month.February.GetNextMonthIn(checkList));
        }

        [Test]
        public void NextMonthAfterDecemberShouldBeJanuary()
        {
            List<Month> checkList = Month.All;
            Assert.AreEqual(Month.January, Month.December.GetNextMonthIn(checkList));
        }

        [Test]
        public void LastDayInJan2005Is31()
        {
            Assert.AreEqual(DayOfMonth.Day(31), Month.January.GetLastDay(2005));
        }

        [Test]
        public void LastDayInFeb2005Is28()
        {
            Assert.AreEqual(DayOfMonth.Day(28), Month.February.GetLastDay(2005));
        }

        [Test]
        public void SecondWednesdayInMarch2005ShouldBeThe9()
        {
            DayOfMonth day = Month.March.GetByDayOfWeekWeekOfMonth(WeekOfMonth.Second, DayOfWeek.Wednesday, 2005);
            Assert.AreEqual(DayOfMonth.Day(9), day);
        }

        [Test]
        public void LastWednesdayInDec2005ShouldBe28()
        {
            DayOfMonth day = Month.December.GetByDayOfWeekWeekOfMonth(WeekOfMonth.Last, DayOfWeek.Wednesday, 2005);
            Assert.AreEqual(DayOfMonth.Day(28), day);
        }

        [Test]
        public void LastDayInFeb2004Is29()
        {
            Assert.AreEqual(DayOfMonth.Day(29), Month.February.GetLastDay(2004));
        }

        [Test]
        public void GetFirstMonthInMonthListShouldReturnEarliestMonthRegardlessOfListOrder()
        {
            Month[] months = { Month.December, Month.June };
            Assert.AreEqual(Month.June, Month.GetFirstMonthIn(new List<Month>(months)));
        }

        [Test]
        public void IsLastMonthInListShouldEvaluateRegardlessOfListOrder()
        {
            Month[] months = { Month.December, Month.June };
            Assert.IsTrue(Month.December.IsLastMonthIn(new List<Month>(months)));
        }

        [Test]
        public void GetNextMonthInMonthListShouldFindNextMonthRegardlessOfListOrder()
        {
            Month[] months = { Month.December, Month.August, Month.June };
            Assert.AreEqual(Month.August, Month.June.GetNextMonthIn(new List<Month>(months)));
        }

        [Test]
        public void ShouldSortMonthsByMonthId()
        {
            List<Month> testMonthToIncludes = new List<Month> {Month.December, Month.August, Month.January};

            testMonthToIncludes.Sort();

            Assert.AreEqual(Month.January, testMonthToIncludes[0]);
            Assert.AreEqual(Month.August, testMonthToIncludes[1]);
            Assert.AreEqual(Month.December, testMonthToIncludes[2]);
        }
    }
}
