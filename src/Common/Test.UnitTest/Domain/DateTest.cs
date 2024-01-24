using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class DateTest
    {
        [Test]
        public void ShouldBuildADateFromADateTime()
        {
            DateTime sourceDateTime = new DateTime(1975, 3, 9, 8, 30, 15);

            Date date = new Date(sourceDateTime);

            Assert.AreEqual(sourceDateTime.Year, date.Year);
            Assert.AreEqual(sourceDateTime.Month, date.Month);
            Assert.AreEqual(sourceDateTime.Day, date.Day);
        }

        [Test]
        public void ShouldCreateADateTimeThatCombinesDateWithTime()
        {
            Date date = new Date(1975, 03, 09);
            Time time = new Time(14, 15, 25);

            DateTime resultingDateTime = date.CreateDateTime(time);

            Assert.AreEqual(1975, resultingDateTime.Year);
            Assert.AreEqual(3, resultingDateTime.Month);
            Assert.AreEqual(9, resultingDateTime.Day);

            Assert.AreEqual(14, resultingDateTime.Hour);
            Assert.AreEqual(15, resultingDateTime.Minute);
            Assert.AreEqual(25, resultingDateTime.Second);
        }

        [Test]
        public void ShouldGetNextNonWeekendDate()
        {
            {
                Date date = new Date(2012, 1, 6); // Friday
                Date nextNonWeekendDate = date.NextNonWeekendDate;
                Assert.AreEqual(new Date(2012, 1, 9), nextNonWeekendDate); // Monday                
            }

            {
                Date date = new Date(2012, 1, 5); // Thursday
                Date nextNonWeekendDate = date.NextNonWeekendDate;
                Assert.AreEqual(new Date(2012, 1, 6), nextNonWeekendDate); // Friday                
            }

            {
                Date date = new Date(2011, 9, 20); // Sunday
                Date nextNonWeekendDate = date.NextNonWeekendDate;
                Assert.AreEqual(new Date(2011, 9, 21), nextNonWeekendDate); // Monday                
            }
        }

        [Test]
        public void ShouldGetDateInFormatRequiredForWebMethodsWorkOrderRequest()
        {
            Date date = new Date(2012, 01, 23);
            string dateAsString = date.ToDateTimeAtStartOfDay().ToString("yyyyMMdd");
            Assert.That(dateAsString, Is.EqualTo("20120123"));
        }

        [Test]
        public void ShouldBeEqual()
        {
            Date dateA = new Date(2011, 05, 01);
            Date dateB = new Date(2011, 05, 01);

            Assert.That(dateA == dateB);
        }

        [Test]
        public void ShouldBeEqualDates()
        {
            Date dateA = new Date(new DateTime(2011, 05, 01, 5, 3, 1));
            Date dateB = new Date(2011, 05, 01);

            Assert.That(dateA == dateB);
        }

        [Test]
        public void ShouldBeEqualDatesWithDateTimes()
        {
            Date dateA = new Date(new DateTime(2011, 05, 01, 5, 3, 1));
            Date dateB = new Date(new DateTime(2011, 05, 01, 6, 4, 2));

            Assert.That(dateA == dateB);
        }

        [Test]
        public void ShouldNotBeEqual()
        {
            Date dateA = new Date(new DateTime(2011, 05, 02, 0, 0, 0));
            Date dateB = new Date(new DateTime(2011, 05, 01, 0, 0, 0));

            Assert.That(dateA != dateB);
        }

    }
}
