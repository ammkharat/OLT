using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Summary description for ShiftPatternTest
    /// </summary>
    [TestFixture]
    public class ShiftPatternTest
    {
        private readonly TimeSpan shiftPadding = new TimeSpan(0, 30, 0);

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void DisplayNameShouldShowShiftNameAndTimes()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var shiftPattern =
                ShiftPatternFixture.CreateShiftPattern(new Time(22, 00), new Time(04, 00));
            Assert.AreEqual("12DA - 22:00 to 04:00", shiftPattern.DisplayName);
        }

        [Test]
        public void LengthForOverlappingStartEndTimeTest()
        {
            var shiftPattern = new ShiftPattern(1, "who cares", new Time(20, 0), new Time(2, 0),
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), shiftPadding, shiftPadding);
            Assert.AreEqual(new TimeSpan(6, 0, 0), shiftPattern.ShiftLength);
        }

        [Test]
        public void LengthForTimesNotOverlapping()
        {
            var shiftPattern = new ShiftPattern(1, "who cares", new Time(4, 0), new Time(20, 0),
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia(), shiftPadding, shiftPadding);
            Assert.AreEqual(new TimeSpan(16, 0, 0), shiftPattern.ShiftLength);
        }

        [Test]
        public void ShouldKnowIfTimeIsInA24HourShift()
        {
            var sp = ShiftPatternFixture.CreateFortHills24HourShift();

            Assert.AreEqual(new TimeSpan(23, 59, 59), sp.ShiftLength);

            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(Time.START_OF_DAY));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(0, 30)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(1, 0)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(3, 30)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(7, 0)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(12, 0)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(19, 0)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(23, 0)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(new Time(23, 30)));
            Assert.IsTrue(sp.IsTimeInShiftIncludingPadding(Time.END_OF_DAY));
        }

        [Test]
        public void ShouldKnowIfTimeIsInAShift()
        {
            var sp = ShiftPatternFixture.CreateOilsandsNightShift8pmTo8am();

            Assert.IsFalse(sp.IsTimeInShiftEndDateExclusive(new Time(11)));
            Assert.IsTrue(sp.IsTimeInShiftEndDateExclusive(new Time(5)));
            Assert.IsTrue(sp.IsTimeInShiftEndDateExclusive(new Time(20)));
            Assert.IsTrue(sp.IsTimeInShiftEndDateExclusive(new Time(7, 59, 59)));

            Assert.IsFalse(sp.IsTimeInShiftEndDateExclusive(new Time(8)));
        }
    }
}