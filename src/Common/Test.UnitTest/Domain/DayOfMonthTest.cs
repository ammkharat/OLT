using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for DayOfMonthTest
    /// </summary>
    [TestFixture]
    public class DayOfMonthTest
    {
        [Test]
        public void FirstDayOfMonthHasIndexOfOne()
        {
            DayOfMonth day = DayOfMonth.First;
            Assert.AreEqual(1, day.Value);
        }

        [Test]
        public void FirstAndDayOneAreTheSame()
        {
            Assert.AreSame(DayOfMonth.First, DayOfMonth.Day(1));
        }

        [Test]
        public void FifteenthDayOfMonthHasIndexOf15()
        {
            DayOfMonth day = DayOfMonth.Day(15);
            Assert.AreEqual(15, day.Value);
        }

        [Test]
        public void DaysAreTheSame()
        {
            Assert.AreSame(DayOfMonth.Day(15), DayOfMonth.Day(15));
        }

        [Test]
        public void LastDaysAreTheSame()
        {
            Assert.AreSame(DayOfMonth.Last, DayOfMonth.Last);
        }

        [Test]
        public void LastDayOfMonthHasArbitraryWayneGretzkeyIndex()
        {
            DayOfMonth day = DayOfMonth.Last;
            Assert.AreEqual(99, day.Value);
        }

        [Test]
        public void ToStringShouldReturnFirstDayForDayOne()
        {
            Assert.AreEqual("First", DayOfMonth.First.ToString());
        }

        [Test]
        public void ToStringShouldReturnLastDayForTheLastDay()
        {
            Assert.AreEqual("Last", DayOfMonth.Last.ToString());
        }

        [Test]
        public void ToStringShouldReturnDay15ForTheFifteenthDay()
        {
            Assert.AreEqual("15", DayOfMonth.Day(15).ToString());
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Day32ShouldThrowExceptionBecauseItDoesNotExist()
        {
            DayOfMonth.Day(32);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Day0ShouldThrowExceptionBecauseItDoesNotExist()
        {
            DayOfMonth.Day(0);
        }

        [Test]
        public void Day99ShouldReturnTheLastDayOfTheMonth()
        {
            Assert.AreSame(DayOfMonth.Last, DayOfMonth.Day(99));
        }   

        [Test]
        public void DayOfMonthShouldBeSerializable()
        {
            Assert.IsTrue(typeof(DayOfMonth).IsSerializable);
        }

        [Test]
        public void ShouldBeAbleToDoAForeachOnTheDayOfMonthItems()
        {
            Assert.AreEqual(32, DayOfMonth.All.Count);
        }

        [Test]
        public void AllDaysShouldReturnTheLastDayOfMonthAtTheEnd()
        {
            Assert.AreEqual(DayOfMonth.Last, DayOfMonth.All[DayOfMonth.All.Count - 1]);
        }

        [Test]
        public void TwoSameDaysOfMonthsShouldBeEqual()
        {
            //Assert.AreEqual(DayOfMonth.Last, DayOfMonth.Last );
            Assert.IsTrue (DayOfMonth.Last.Equals(DayOfMonth.Last));        
        }

        [Test]
        public void DifferentDaysOfMonthsShouldBeNotEqual()
        {
            Assert.IsFalse(DayOfMonth.First.Equals(DayOfMonth.Last));
        }



        [Test]
        public void DayOfMonthsShouldReturnFalseWhenComparedWithObject()
        {
             Assert.IsFalse(DayOfMonth.Last.Equals(new Object()));
        }

        [Test]
        public void DayOfMonthsShouldReturnFalseWhenComparedWithNullObject()
        {
             Assert.IsFalse(DayOfMonth.Last.Equals(null));
        }

        [Test]
        public void ShouldReturnActualDayOfMonthGivenAMonth()
        {
            Assert.AreEqual(15, DayOfMonth.Day(15).GetActualDayOfMonth(2011, 2));
            Assert.AreEqual(28, DayOfMonth.Day(31).GetActualDayOfMonth(2011, 2));
            Assert.AreEqual(29, DayOfMonth.Day(29).GetActualDayOfMonth(2008, 2));
            Assert.AreEqual(29, DayOfMonth.Day(30).GetActualDayOfMonth(2008, 2));
        }

        [Test]
        public void ShouldGetDayOfMonthThatMakesSense()
        {
            DayOfMonth dayOfMonth = DayOfMonth.Day(31);
            DayOfMonth actualDay = dayOfMonth.GetActualDay(Month.February, 31);
            Assert.AreEqual(28, actualDay.Value);
        }
    }
}
