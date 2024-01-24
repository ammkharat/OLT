using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WeekOfMonthTest
    {
        [Test]
        public void ShouldDescribeFirstWeekOfMonthAndShouldHaveAnIndexOfOne()
        {
            Assert.AreEqual(1, WeekOfMonth.First.Value);
        }

        [Test]
        public void ShouldDescribeSecondWeekOfMonthAndShouldHaveAnIndexOfTwo()
        {
            Assert.AreEqual(2, WeekOfMonth.Second.Value);
        }

        [Test]
        public void ShouldDescribeThirdWeekOfMonthAndShouldHaveAnIndexOfThree()
        {
            Assert.AreEqual(3, WeekOfMonth.Third.Value);
        }

        [Test]
        public void ShouldDescribeFourthWeekOfMonthAndShouldHaveAnIndexOfFour()
        {
            Assert.AreEqual(4, WeekOfMonth.Fourth.Value);
        }

        [Test]
        public void ShouldDescribeLastWeekOfMonthAndShouldHaveAnArbitraryGretzkyIndex()
        {
            Assert.AreEqual(99, WeekOfMonth.Last.Value);
        }

        [Test]
        public void ToStringShouldReturnFirstWeekForFirstWeek()
        {
            Assert.AreEqual("First", WeekOfMonth.First.ToString());
        }

        [Test]
        public void ToStringShouldReturnSecondWeekForSecondWeek()
        {
            Assert.AreEqual("Second", WeekOfMonth.Second.ToString());
        }

        [Test]
        public void ToStringShouldReturnThirdWeekForThirdWeek()
        {
            Assert.AreEqual("Third", WeekOfMonth.Third.ToString());
        }

        [Test]
        public void ToStringShouldReturnFourthWeekForFourthWeek()
        {
            Assert.AreEqual("Fourth", WeekOfMonth.Fourth.ToString());
        }

        [Test]
        public void ToStringShouldReturnLastWeekForLastWeek()
        {
            Assert.AreEqual("Last", WeekOfMonth.Last.ToString());
        }

        [Test]
        public void ShouldBeAbleToDoAForeachOnTheWeekOfMonthItems()
        {
            Assert.AreEqual(6, WeekOfMonth.All.Count);
        }

        [Test]
        public void AllWeeksShouldReturnTheLastWeekAtTheEnd()
        {
            Assert.AreEqual(WeekOfMonth.Last, WeekOfMonth.All[WeekOfMonth.All.Count-1]);
        }

        [Test]
        public void Week1ShouldReturnTheFirstWeekOfTheMonth()
        {
            Assert.AreEqual(WeekOfMonth.First, WeekOfMonth.Week(1));
        }

        [Test]
        public void Week1ShouldReturnTheFirstWeekOfTheMonthByIndex()
        {
            Assert.AreEqual(WeekOfMonth.First, WeekOfMonth.Week(1));
        }

        [Test]
        public void Week99ShouldReturnTheLastWeekOfTheMonth()
        {
            Assert.AreEqual(WeekOfMonth.Last, WeekOfMonth.Week(99));
        }

        [Test]
        public void TwoSameWeeksOfMonthsShouldBeEqual()
        {
            //Assert.AreEqual(WeekOfMonth.Last, WeekOfMonth.Last );
            Assert.IsTrue(WeekOfMonth.Last.Equals(WeekOfMonth.Last));
        }

        [Test]
        public void DifferentWeeksOfMonthsShouldBeNotEqual()
        {
            Assert.IsFalse(WeekOfMonth.First.Equals(WeekOfMonth.Last));
        }

        [Test]
        public void WeekOfMonthsShouldReturnFalseWhenComparedWithObject()
        {
            Assert.IsFalse(WeekOfMonth.Last.Equals(new Object()));
        }

        [Test]
        public void WeekOfMonthsShouldReturnFalseWhenComparedWithNullObject()
        {
            Assert.IsFalse(WeekOfMonth.Last.Equals(null));
        }


    }
}
