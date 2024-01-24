using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class DateRangeTest
    {
        [Test]
        public void ShouldOverlapDates()
        {
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.That(dateRange.Overlaps(today, today));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.That(dateRange.Overlaps(today, today.AddDays(1)));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.That(dateRange.Overlaps(today.SubtractDays(1), today));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.That(dateRange.Overlaps(today.SubtractDays(1), today.AddDays(1)));
            }
        }

        [Test]
        public void ShouldNotOverlapDates()
        {
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.IsFalse(dateRange.Overlaps(today.AddDays(1), today.AddDays(1)));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.IsFalse(dateRange.Overlaps(today.AddDays(1), today.AddDays(10)));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.IsFalse(dateRange.Overlaps(today.AddDays(-1), today.AddDays(-1)));
            }
            {
                Date today = Clock.DateNow;

                DateRange dateRange = new DateRange(today, today);
                Assert.IsFalse(dateRange.Overlaps(today.AddDays(-10), today.AddDays(-1)));
            }

        }

        [Test]
        public void ShouldLoopThroughDays()
        {
            Date today = Clock.DateNow;

            {
                DateRange dateRange = new DateRange(today, today);
                List<Date> dates = new List<Date>();
                dateRange.ForEachDay(dates.Add);

                Assert.AreEqual(1, dates.Count);
                Assert.AreEqual(today, dates[0]);
            }

            {
                Date twoDaysFromToday = today.AddDays(2);
                DateRange dateRange = new DateRange(today, twoDaysFromToday);
                List<Date> dates = new List<Date>();
                dateRange.ForEachDay(dates.Add);

                Assert.AreEqual(3, dates.Count);
                Assert.AreEqual(today, dates[0]);
                Assert.AreEqual(today.AddDays(1), dates[1]);
                Assert.AreEqual(today.AddDays(2), dates[2]);
            }            
        }


    }
}