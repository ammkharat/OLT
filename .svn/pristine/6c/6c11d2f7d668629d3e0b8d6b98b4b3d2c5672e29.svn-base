using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for DurationTest
    /// </summary>
    [TestFixture]
    public class DurationTest
    {
        Date today = new Date(2006, 06, 05);
        
        [Test]
        public void CalculateOneYearAgo()
        {
            Assert.AreEqual(new Date(2005, 06, 05), Duration.OneYear.Before(today));
        }
        
        [Test]
        public void CalculateOneMonthAgo()
        {
            Assert.AreEqual(new Date(2006, 05, 05), Duration.OneMonth.Before(today));
        }

        [Test]
        public void CalculateThreeMonthsAgo()
        {
            Assert.AreEqual(new Date(2006, 03, 05), Duration.ThreeMonths.Before(today));
        }

        [Test]
        public void CalculateSixMonthsAgo()
        {
            Assert.AreEqual(new Date(2005, 12, 05), Duration.SixMonths.Before(today));
        }

        [Test]
        public void CalculateOneWeekAgo()
        {
            Assert.AreEqual(new Date(2006, 05, 29), Duration.OneWeek.Before(today));
        }
        
        [Test]
        public void GetOneYearByName()
        {
            Assert.AreEqual(Duration.OneYear, Duration.Get("1 Year"));
        }

        [Test]
        public void GetOneWeekByName()
        {
            Assert.AreEqual(Duration.OneWeek, Duration.Get("1 Week"));
        }

        [Test]
        public void GetOneMonthByName()
        {
            Assert.AreEqual(Duration.OneMonth, Duration.Get("1 Month"));
        }

        [Test]
        public void GetThreeMonthsByName()
        {
            Assert.AreEqual(Duration.ThreeMonths, Duration.Get("3 Months"));
        }

        [Test]
        public void GetSixMonthsByName()
        {
            Assert.AreEqual(Duration.SixMonths, Duration.Get("6 Months"));
        }
    }
}
