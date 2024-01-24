using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class TimeZoneConverterTest
    {
        [Test]
        public void ConvertBeforeDSTFromEasternToMountain()
        {
            DateTime dateTime = new DateTime(2006, 01, 01, 10, 0, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetSarniaTimeZone(),
                                                       TimeZoneFixture.GetMountainTimeZone());
                        
            Assert.AreEqual(new DateTime(2006, 01, 01, 8, 0, 0), result);
        }

        [Test]
        public void ConvertBeforeDSTFromMountainToEastern()
        {
            DateTime dateTime = new DateTime(2006, 01, 01, 10, 0, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(
                dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());

            Assert.AreEqual(new DateTime(2006, 01, 01, 12, 0, 0, DateTimeKind.Local), result);
        }

        [Test]
        public void ConvertAfterDSTFromEasternToMountain()
        {
            DateTime dateTime = new DateTime(2006, 05, 01, 10, 0, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetSarniaTimeZone(),
                                                       TimeZoneFixture.GetMountainTimeZone());

            Assert.AreEqual(new DateTime(2006, 05, 01, 8, 0, 0), result);
        }

        [Test]
        public void ConvertAfterDSTFromMountainToEastern()
        {
            DateTime dateTime = new DateTime(2006, 05, 01, 10, 0, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());

            Assert.AreEqual(new DateTime(2006, 05, 01, 12, 0, 0), result);
        }

        // Really interesting Tests start here

        [Test]
        public void ConvertFromMountainToEasternAcrossDSTStartBoundary()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 04, 02, 1, 30, 0, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 03, 11, 1, 30, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());

            //Assert.AreEqual(new DateTime(2006, 04, 02, 04, 30, 0, DateTimeKind.Local), result);
            Assert.AreEqual(new DateTime(2007, 03, 11, 04, 30, 0), result);
        }

        [Test]
        public void ConvertFromMountainToEasternAcrossDSTEndBoundary()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 10, 29, 1, 30, 0, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 11, 04, 1, 30, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());

            //Assert.AreEqual(new DateTime(2006, 10, 29, 02, 30, 0, DateTimeKind.Local), result);
            Assert.AreEqual(new DateTime(2007, 11, 04, 03, 30, 0), result);
        }

        [Test]
        public void ConvertFromEasternToMountainAcrossDSTStartBoundary()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 04, 02, 3, 30, 0, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 03, 11, 3, 30, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetSarniaTimeZone(), TimeZoneFixture.GetMountainTimeZone());

            //Assert.AreEqual(new DateTime(2006, 04, 02, 00, 30, 0, DateTimeKind.Local), result);
            Assert.AreEqual(new DateTime(2007, 03, 11, 00, 30, 0), result);
        }

        [Test]
        public void ConvertFromEasternToMountainAcrossDSTEndBoundary()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 10, 29, 2, 30, 0, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 11, 04, 2, 30, 0);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetSarniaTimeZone(), TimeZoneFixture.GetMountainTimeZone());

            //Assert.AreEqual(new DateTime(2006, 10, 29, 1, 30, 0, DateTimeKind.Local), result);
            Assert.AreEqual(new DateTime(2007, 11, 04, 1, 30, 0), result);
        }

        [Test]
        public void TestConvertOfNonExistantDateTimeFromEasternToMountain()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 04, 02, 02, 30, 00, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 03, 11, 02, 30, 00);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetSarniaTimeZone(), TimeZoneFixture.GetMountainTimeZone());
            Assert.AreEqual(new DateTime(2007, 03, 11, 0, 30, 0), result);
        }

        [Test]
        public void TestConvertOfNonExistantDateTimeFromMountainToEastern()
        {
            //Modified by Gloria on Feb 21, 2007. DTS Start and End time is changed in 2007.
            //DateTime dateTime = new DateTime(2006, 04, 02, 02, 30, 00, DateTimeKind.Local);
            DateTime dateTime = new DateTime(2007, 03, 11, 02, 30, 00);

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());
            Assert.AreEqual(new DateTime(2007, 03, 11, 5, 30, 0), result);
        }

        [Test]
        public void TestConvertThatAddsToMaxValue()
        {
            DateTime dateTime = DateTime.MaxValue;

            DateTime result = OltTimeZoneInfo.ConvertTime(dateTime, TimeZoneFixture.GetMountainTimeZone(), TimeZoneFixture.GetSarniaTimeZone());
            
            Assert.AreEqual(DateTime.MaxValue, result);
        }
        
        [Test]
        public void TestConvertFromDSTToStandardTime()
        {
            DateTime dateTime = new DateTime(2006, 10, 29, 1, 0, 0);
            OltTimeZoneInfo calgaryStandardTime = TimeZoneFixture.GetMountainTimeZone();
            OltTimeZoneInfo sarniaStandardTime = TimeZoneFixture.GetSarniaTimeZone();
            DateTime expected = new DateTime(2006, 10, 29, 3, 0, 0);
            Assert.AreEqual(expected,
                            OltTimeZoneInfo.ConvertTime(dateTime, calgaryStandardTime,
                                                                        sarniaStandardTime));
            
        }
    }
}