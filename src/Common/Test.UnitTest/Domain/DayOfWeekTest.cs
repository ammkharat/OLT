using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for DayOfWeekTest
    /// </summary>
    [TestFixture]
    public class DayOfWeekTest
    {
        [Test]
        public void DayOfWeekShouldContainMondayAndItShouldBeTheSameObject()
        {
            Assert.AreSame(DayOfWeek.Monday, DayOfWeek.Monday);
        }

        [Test]
        public void ToStringShouldReturnAFriendlyVersionOfTheDayOfWeekName()
        {
            Assert.AreEqual("Tuesday", DayOfWeek.Tuesday.ToString());
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof(DayOfWeek).IsSerializable);
        }

        [Test]
        public void GetDayOfWeekByStringShouldReturnTheCorrectDayOfWeek()
        {
            Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Get(1));
        }

        [Test]
        public void AllShouldReturnAllDaysOfWeekInChronologicalOrder()
        {
            Assert.AreEqual(7, DayOfWeek.All.Count);
            Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.All[0]);
            Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.All[1]);
            Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.All[2]);
            Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.All[3]);
            Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.All[4]);
            Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.All[5]);
            Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.All[6]);
        }

        [Test]
        public void TwoSameDaysOfWeekShouldBeEqual()
        {
            Assert.IsTrue(DayOfWeek.Friday.Equals(DayOfWeek.Friday));
        }

        [Test]
        public void DifferentDaysOfMonthsShouldBeNotEqual()
        {
            Assert.IsFalse(DayOfWeek.Friday.Equals(DayOfWeek.Thursday));
        }



        [Test]
        public void DayOfWeeksShouldReturnFalseWhenComparedWithObject()
        {
            Assert.IsFalse(DayOfWeek.Friday.Equals(new Object()));
        }

        [Test]
        public void DayOfWeeksShouldReturnFalseWhenComparedWithNullObject()
        {
            Assert.IsFalse(DayOfWeek.Friday.Equals(null));
        }

        [Test]
        public void DifferenceBetweenWednesdayAndMondayShouldBe2()
        {
            Assert.AreEqual(2, DayOfWeek.Wednesday - DayOfWeek.Monday);
        }

        [Test]
        public void DifferenceBetweenMondayAndWednesdayShouldBe5()
        {
            Assert.AreEqual(5, DayOfWeek.Monday - DayOfWeek.Wednesday);
        }

        [Test]
        public void ClosestDayToFridayAndMondayForwardForTuesdayShouldBeFriday()
        {
            List<DayOfWeek> checkList = new List<DayOfWeek>();
            checkList.Add(DayOfWeek.Monday);
            checkList.Add(DayOfWeek.Friday);

            Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Tuesday.GetClosestForwardDayOfWeekIn(checkList));
        }

        [Test]
        public void ClosestDayToFridayAndMondayForwardForWednesdayShouldBeFriday()
        {
            List<DayOfWeek> checkList = new List<DayOfWeek>();
            checkList.Add(DayOfWeek.Monday);
            checkList.Add(DayOfWeek.Friday);

            Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Wednesday.GetClosestForwardDayOfWeekIn(checkList));
        }

        [Test]
        public void ClosestDayToFridayAndMondayForwardForSaturdayShouldBeMonday()
        {
            List<DayOfWeek> checkList = new List<DayOfWeek>();
            checkList.Add(DayOfWeek.Monday);
            checkList.Add(DayOfWeek.Friday);

            Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Saturday.GetClosestForwardDayOfWeekIn(checkList));
        }

        [Test]
        public void ClosestDayToMondayAndThursdayForwardForTuesdayShouldBeThursday()
        {
            List<DayOfWeek> checkList = new List<DayOfWeek>();
            checkList.Add(DayOfWeek.Monday);
            checkList.Add(DayOfWeek.Thursday);

            Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.Tuesday.GetClosestForwardDayOfWeekIn(checkList));
        }

        [Test]
        public void GetClosestForwardDayOfWeekInListShouldReturnClosestForwardDayRegardlessOfListOrder()
        {
            DayOfWeek[] daysOfWeek = { DayOfWeek.Thursday, DayOfWeek.Wednesday };
            Assert.AreEqual(DayOfWeek.Wednesday,
                            DayOfWeek.Tuesday.GetClosestForwardDayOfWeekIn(new List<DayOfWeek>(daysOfWeek)));
        }

        [Test]
        public void FridayShouldBeLastDayInTheListOfMondayAndFriday()
        {
            List<DayOfWeek> checkList = new List<DayOfWeek>();
            checkList.Add(DayOfWeek.Monday);
            checkList.Add(DayOfWeek.Friday);

            Assert.IsTrue(DayOfWeek.Friday.IsLastDayOfWeekIn(checkList));
        }

        [Test]
        public void ShouldConvertStringToDayOfWeek()
        {
            Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.ConvertFromString("Monday"));
            Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.ConvertFromString("Tuesday"));
            Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.ConvertFromString("Wednesday"));
            Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.ConvertFromString("Thursday"));
            Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.ConvertFromString("Friday"));
            Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.ConvertFromString("Saturday"));
            Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.ConvertFromString("Sunday"));
        }

        [Test]
        [ExpectedException(typeof(InvalidProgramException))]
        public void ExceptExceptionOnMalFormStringOnConvertingToDayOfWeek()
        {
            DayOfWeek dayOfWeek = DayOfWeek.ConvertFromString("Eighthday");
        }

        [Test]
        public void ConvertToDayOfWeekIsCaseInSensititive()
        {
            Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.ConvertFromString("monDay"));
            Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.ConvertFromString("tUesday"));
            Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.ConvertFromString("wEdnesday"));
            Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.ConvertFromString("thUrsday"));
            Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.ConvertFromString("fridaY"));
            Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.ConvertFromString("SatUrday"));
            Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.ConvertFromString("SUnday"));
        }

        [Test]
        public void ShouldReturnNullIfNullIsPassedIn()
        {
            Assert.IsNull(DayOfWeek.Thursday.GetClosestForwardDayOfWeekIn(null));
        }

        [Test]
        public void ShouldReturnNullIfEmptyListIsPassedIn()
        {
            Assert.IsNull(DayOfWeek.Thursday.GetClosestForwardDayOfWeekIn(new List<DayOfWeek>()));
        }

        [Test]
        public void CompareToShouldCompareChronologically()
        {
            Assert.AreEqual(-1, DayOfWeek.Monday.CompareTo(DayOfWeek.Tuesday));
            Assert.AreEqual(1, DayOfWeek.Tuesday.CompareTo(DayOfWeek.Monday));
            Assert.AreEqual(0, DayOfWeek.Monday.CompareTo(DayOfWeek.Monday));
        }

        [Test]
        public void CompareToShouldEvaluateSundayToBeGreatestDayOfWeek()
        {
            Assert.AreEqual(1, DayOfWeek.Sunday.CompareTo(DayOfWeek.Monday));
            Assert.AreEqual(1, DayOfWeek.Sunday.CompareTo(DayOfWeek.Saturday));
        }
    }
}
