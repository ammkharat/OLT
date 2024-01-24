using System;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [TearDown]
        public void TearDown()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();
        }

        [Test]
        public void RollBackwardShouldReturnDesiredDateTimeOnPreviousDay()
        {
            Assert.AreEqual(new DateTime(1977, 5, 22, 23, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollBackward(new Time(23, 00)));
        }

        [Test]
        public void RollBackwardShouldReturnDesiredDateTimeOnSameDay()
        {
            Assert.AreEqual(new DateTime(1977, 5, 23, 17, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollBackward(new Time(17, 00)));
        }

        [Test]
        public void RollBackwardShouldReturnSameDateTimeGivenDesiredTimeBeingTheSameTime()
        {
            Assert.AreEqual(new DateTime(1977, 5, 23, 18, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollBackward(new Time(18, 00)));
        }

        [Test]
        public void RollForwardShouldReturnDesiredDateTimeOnNextDay()
        {
            Assert.AreEqual(new DateTime(1977, 5, 24, 02, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollForward(new Time(02, 00)));
        }

        [Test]
        public void RollForwardShouldReturnDesiredDateTimeOnSameDay()
        {
            Assert.AreEqual(new DateTime(1977, 5, 23, 19, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollForward(new Time(19, 00)));
        }

        [Test]
        public void RollForwardShouldReturnSameDateTimeGivenDesiredTimeBeingTheSameTime()
        {
            Assert.AreEqual(new DateTime(1977, 5, 23, 18, 00, 00),
                new DateTime(1977, 5, 23, 18, 00, 00).RollForward(new Time(18, 00)));
        }

        [Test]
        public void ShouldGetEachDayFromRange()
        {
            var start = DateTime.Now;
            var end = start.AddDays(20);

            var daysList = start.EachDay(end).ToList();
            Assert.IsNotNull(daysList);
            Assert.AreEqual(daysList.Count, 21);
        }

        [Test]
        public void ShouldGetFormatsFromStringResources()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            {
                var dateTime = new DateTime(2011, 07, 10, 11, 14, 13);
                Assert.That(dateTime.ToShortDateAndTimeString(), Is.EqualTo("07/10/2011 11:14"));
            }

            {
                var dateTime = new DateTime(2011, 07, 10, 15, 14, 13);
                Assert.That(dateTime.ToShortDateAndTimeString(), Is.EqualTo("07/10/2011 15:14"));
            }
        }

        [Test]
        public void ShouldGetLongDateTimeStringFromFrenchStringResources()
        {
            CultureInfoTestHelper.SetFormatsForFrenchFromResourceFile();

            var dateTime = new DateTime(2011, 07, 10, 02, 14, 13);
            Assert.That(dateTime.ToLongDateAndTimeString(), Is.EqualTo("dim. 2011-07-10 02:14"));
        }

        [Test]
        public void ShouldGetLongDateTimeStringFromStringResources()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var aDateTime = new DateTime(1977, 5, 23, 1, 13, 45);
            const string expected = "Mon 05/23/1977 01:13";
            Assert.AreEqual(expected, aDateTime.ToLongDateAndTimeString());
        }

        [Test]
        public void ShouldGetLongDateTimeStringFromThreadForFrench()
        {
            CultureInfoTestHelper.SetFormatsForFrenchFromResourceFile();

            var dateTime = new DateTime(2011, 07, 10, 02, 14, 13);
            Assert.That(dateTime.ToShortDateAndTimeString(), Is.EqualTo("2011-07-10 02:14"));
        }

        [Test]
        public void ShouldGetNetworkPortable()
        {
            var localDateTime = DateTime.Now;

            // Sanity check
            Assert.AreEqual(DateTimeKind.Local, localDateTime.Kind);

            var unspecified = localDateTime.GetNetworkPortable();
            Assert.AreEqual(localDateTime.Ticks, unspecified.Ticks);
            Assert.AreEqual(DateTimeKind.Unspecified, unspecified.Kind);
        }

        [Test]
        public void ShouldGetShortDateAndTimeStringAsEmptyString()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            {
                DateTime? dateTime = new DateTime(2011, 07, 10, 11, 14, 13);
                Assert.That(dateTime.ToShortDateAndTimeStringOrEmptyString(), Is.EqualTo("07/10/2011 11:14"));
            }

            {
                DateTime? dateTime = null;
                Assert.That(dateTime.ToShortDateAndTimeStringOrEmptyString(), Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public void ShouldParseDateTimeStrings()
        {

            {
                var date = "2013-01-20";
                var time = "23:59:59";

                DateTime dateTime;
                var result = DateTimeExtensions.TryParse(date, time, out dateTime);

                Assert.That(result, Is.True);
                Assert.That(dateTime, Is.EqualTo(new DateTime(2013, 01, 20, 23, 59, 59)));
            }

            {
                var date = "2013-01-20";
                var time = "00:00:00";

                DateTime dateTime;
                var result = DateTimeExtensions.TryParse(date, time, out dateTime);

                Assert.That(result, Is.True);
                Assert.That(dateTime, Is.EqualTo(new DateTime(2013, 01, 20, 00, 00, 00)));
            }

            {
                var date = "2013-01-20";
                var time = "24:00:00";

                DateTime dateTime;
                var result = DateTimeExtensions.TryParse(date, time, out dateTime);

                Assert.That(result, Is.False);
            }

            {
                var date = "2012-03-24";
                var time = "12:00:01";

                DateTime dateTime;
                var parsed = DateTimeExtensions.TryParse(date, time, out dateTime);
                Assert.That(parsed, Is.True);
            }
            {
                var date = "2012-02-30";
                var time = "12:00:01";

                DateTime dateTime;
                var parsed = DateTimeExtensions.TryParse(date, time, out dateTime);
                Assert.That(parsed, Is.False);
            }
            {
                var date = "2012-02-27";
                string time = null;

                DateTime dateTime;
                var parsed = DateTimeExtensions.TryParse(date, time, out dateTime);
                Assert.That(parsed, Is.False);
            }
            {
                var date = "2012-02-27";
                var time = string.Empty;

                DateTime dateTime;
                var parsed = DateTimeExtensions.TryParse(date, time, out dateTime);
                Assert.That(parsed, Is.False);
            }

            {
                string date = null;
                var time = "12:00:01";

                DateTime dateTime;
                var parsed = DateTimeExtensions.TryParse(date, time, out dateTime);
                Assert.That(parsed, Is.False);
            }
        }
    }
}