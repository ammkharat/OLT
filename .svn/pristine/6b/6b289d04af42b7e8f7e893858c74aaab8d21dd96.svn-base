using System;
using System.Globalization;
using System.Threading;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;



namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class TimeTest
    {
        [Test]
        public void TimeShouldHaveHourMinute()
        {
            Time time = new Time(13, 15);
            Assert.AreEqual(13, time.Hour);
            Assert.AreEqual(15, time.Minute);
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeShouldThrowExceptionWhenHourIsGreaterThan23()
        {
            Time time = new Time(24, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeShouldThrowExceptionWhenHourIsLessThan0()
        {
            Time time = new Time(-1, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeShouldThrowExceptionWhenMinuteIsGreaterThan59()
        {
            Time time = new Time(10, 60);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeShouldThrowExceptionWhenMinuteIsLessThan0()
        {
            Time time = new Time(10, -1);
        }


        [Test]
        public void To24HrStringShouldPrintTheTimeIn24HourFormat()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Assert.AreEqual("13:15:00", new Time(13, 15).ToStringWithSeconds());
        }


        [Test]
        public void TimeShouldBeSerializable()
        {
            Assert.IsTrue(typeof(Time).IsSerializable);
        }
        
        [Test]
        public void EqualsShouldReturnTrueIfHoursAndMinutesAreTheSame()
        {
            Assert.AreEqual(new Time(13, 15), new Time(13, 15));
        }

        [Test]
        public void EqualsShouldReturnFalseIfMinutesAreDifferent()
        {
            Assert.AreNotEqual(new Time(13, 15), new Time(13, 16));
        }

        [Test]
        public void EqualsShouldReturnFalseIfHoursAreDifferent()
        {
            Assert.AreNotEqual(new Time(13, 15), new Time(14, 16));
        }

        [Test]
        public void EqualsShouldReturnFalseIfComparedToNull()
        {
            Assert.IsFalse(new Time(13, 15).Equals(null));
        }

        [Test]
        public void EqualsShouldReturnFalseIfComparedToNonTimeObject()
        {
            Assert.IsFalse(new Time(13, 15).Equals("Hi!"));
        }

        [Test]
        public void IfTimeObjectsAreEqualHashcodeShouldAlsoBeEqual()
        {
            Assert.AreEqual(new Time(13, 15).GetHashCode(), new Time(13, 15).GetHashCode());
        }

        [Test]
        public void ShouldBeAbleToCreateATimeObjectFromDateTime()
        {
            DateTime dateTime = new DateTime(2004, 1, 1, 13, 15, 31);
            Time time = new Time(dateTime);
            Assert.AreEqual(new Time(13, 15,31), time);
        }

        [Test]
        public void ToDateTimeShouldReturnDatePortionAsMinimumValueValidInDateTimePickerControl()
        {
            Time time = new Time(13, 15,0);
            DateTime expectedDateTime = new DateTime(1900, 1, 1, 13, 15, 00);
            Assert.AreEqual(expectedDateTime, time.ToDateTime());
        }

        [Test]
        public void To24HrStringShouldFormatSingleDigitsWithAPaddedSpace()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Assert.AreEqual("01:05:00", new Time(1, 5).ToStringWithSeconds());
        }

        [Test]
        public void IfHourIsGreaterThenTimeIsGreater()
        {
            Time t1 = new Time(10, 1);
            Time t2 = new Time(1, 2);
            Assert.IsTrue(t1 > t2);
            Assert.IsTrue(t2 < t1);
        }

        [Test]
        public void IfHourAreEqualButMinuteIsGreaterThenTimeIsGreater()
        {
            Time t1 = new Time(10, 10);
            Time t2 = new Time(10, 2);
            Assert.IsTrue(t1 > t2);
            Assert.IsTrue(t2 < t1);
        }

        [Test]
        public void TimesShouldBeEqual()
        {
            Time t1 = new Time(10, 9, 8);
            Time t2 = new Time(10, 9, 8);
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
        }

        [Test]
        public void TimesHourShouldBeNotEqual()
        {
            Time t1 = new Time(9, 9, 8);
            Time t2 = new Time(10, 9, 8);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1 == t2);
        }

        [Test]
        public void NullTimeShouldBeEqual()
        {
            Time t1 = null;
            Time t2 = null;
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
        }

        [Test]
        public void OneNullTimeShouldNotBeEqual()
        {
            Time t1 = null;
            Time t2 = new Time(10, 9, 8);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1 == t2);
        }

        [Test]
        public void TimesMinutesShouldBeNotEqual()
        {
            Time t1 = new Time(10, 11, 8);
            Time t2 = new Time(10, 9, 8);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1 == t2);
        }

        [Test]
        public void TimesSecondsShouldBeNotEqual()
        {
            Time t1 = new Time(10, 9, 11);
            Time t2 = new Time(10, 9, 8);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1 == t2);
        }

        [Test]
        public void IfHourAndMinuteAreEqualThenTimeIsNotGreaterOrLesser()
        {
            Time t1 = new Time(10, 2);
            Time t2 = new Time(10, 2);
            Assert.IsFalse(t1 > t2);
            Assert.IsFalse(t2 < t1);
        }

        [Test]
        public void TimeDuringtheSameDayIsInRange()
        {
            Time fromTime = new Time(11, 0);
            Time endTime = new Time(17, 0);

            Assert.IsTrue(new Time(14, 14).InRange(fromTime, endTime));
            Assert.IsFalse(new Time(18, 14).InRange(fromTime, endTime));
        }

        [Test]
        public void TimeDuringFirstDayAndInRangeOnOverlappingDay()
        {
            Time fromTime = new Time(22, 0);
            Time endTime = new Time(2, 0);

            Time testTime = new Time(23, 30);
            Assert.IsTrue(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void TimeDuringSecondDayAndInRangeOnOverlappingDay()
        {
            Time fromTime = new Time(22, 0);
            Time endTime = new Time(2, 0);

            Time testTime = new Time(1, 00);
            Assert.IsTrue(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void TimeBeforeRangeOnSameDay()
        {
            Time fromTime = new Time(5, 0);
            Time endTime = new Time(22, 0);

            Time testTime = new Time(4, 0);
            Assert.IsFalse(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void TimeAfterRangeInSameDay()
        {
            Time fromTime = new Time(2, 0);
            Time endTime = new Time(4, 0);

            Time testTime = new Time(4, 30);
            Assert.IsFalse(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void TimeAfterRangeOnOverlappingDay()
        {
            Time fromTime = new Time(23, 0);
            Time endTime = new Time(4, 0);

            Time testTime = new Time(4, 30);
            Assert.IsFalse(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void TimeBeforeRangeOnOverlappingDay()
        {
            Time fromTime = new Time(23, 0);
            Time endTime = new Time(4, 0);

            Time testTime = new Time(22, 00);
            Assert.IsFalse(testTime.InRange(fromTime, endTime));
        }

        [Test]
        public void AddHourShouldAddAppropriateTimeToTimeObject()
        {
            Time time = new Time(1);
            Time newtime = time.Add(new TimeSpan(1, 0, 0));

            Assert.AreEqual(time.Hour + 1, newtime.Hour);
            Assert.AreEqual(time.Second, newtime.Second);
            Assert.AreEqual(time.Minute, newtime.Minute);
        }

        [Test]
        public void AddHourMinuteShouldAddAppropriateTimeToTimeObject()
        {
            Time time = new Time(14,2);
            Time newtime = time.Add(new TimeSpan(1, 1, 0));

            Assert.AreEqual(time.Hour + 1, newtime.Hour, "Hours dont match");
            Assert.AreEqual(time.Second , newtime.Second, "Seconds dont match");
            Assert.AreEqual(time.Minute + 1, newtime.Minute, "Minutes dont match");
        }

        [Test]
        public void AddHourMinuteSecondShouldAddAppropriateTimeToTimeObject()
        {
            Time time = new Time(20, 20,20);
            Time newtime = time.Add(new TimeSpan(1, 1, 1));

            Assert.AreEqual(time.Hour + 1, newtime.Hour);
            Assert.AreEqual(time.Second + 1, newtime.Second);
            Assert.AreEqual(time.Minute+ 1, newtime.Minute);
        }
        [Test]
        public void AddHourAcross24ClockShouldAddAppropriateTimeToTimeObject()
        {
            Time originaltime = new Time(23,5,5);
            Time expectedTime = new Time(1, 6, 5);
            Time  newtime= originaltime.Add(new TimeSpan(2, 1, 0));

            Assert.AreNotEqual(originaltime, newtime);
            Assert.AreEqual(newtime, expectedTime );

        }

        [Test]
        public void AddMinutesOver60ShouldAddAppropriateHourToTimeObject()
        {
            Time originaltime = new Time(1, 59, 5);
            Time expectedTime = new Time(2, 5, 5);
            Time newtime = originaltime.Add(new TimeSpan(0, 6, 0));
            
            Assert.AreEqual(newtime, expectedTime);
        }

        [Test]
        public void AddSecondsOver60ShouldAddAppropriateMinuteToTimeObject()
        {
            Time originaltime = new Time(1, 57, 59);
            Time expectedTime = new Time(1, 59, 19);
            Time newtime = originaltime.Add(0, 1, 20);

            Assert.AreEqual(newtime, expectedTime);
        }

        [Test]
        public void TotalMinutesShouldReturnTotalMintues()
        {
            Time time = new Time(1, 5);
            Assert.AreEqual(65, time.TotalMinutes);

            Time newTime = time.Add(-1); //subtract an hour
            Assert.AreEqual(5, newTime.TotalMinutes);
        }

        [Test]
        public void TestMinutesReturnsCorrectValueForNewTime()
        {
            Time time = new Time(5, 35, 7);
            Assert.AreEqual(time.Minute, 35);
        }

        [Test]
        public void SubtractReturnsCorrectResultWhenFirstIsBeforeTheSecond()
        {
            Time startTime = new Time(5, 0);
            Time endTime = new Time(12, 0);

            TimeSpan difference = endTime - startTime;

            Assert.AreEqual(7, difference.Hours);
        }

        [Test]
        public void ShouldGetToStringProperlyForCurrentCulture()
        {
            Time time = new Time(05, 00, 00);
            Assert.That(time.ToDateTime().ToString("t", CultureInfo.CurrentCulture), Is.EqualTo("5:00 AM"));
        }

        [Test]
        public void ShouldGetToStringProperlyForNoCultureWhichDefaultsToEnUS()
        {
            Time time = new Time(05, 00, 00);
            Assert.That(time.ToDateTime().ToString("t"), Is.EqualTo("5:00 AM"));
        }

        [Test]
        public void ShouldGetToStringProperlyForFrenchCulture()
        {
            Time time = new Time(05, 00, 00);
            Assert.That(time.ToDateTime().ToString("t", CultureInfo.CreateSpecificCulture("fr")), Is.EqualTo("05:00"));
            Assert.That(time.ToDateTime().ToString("t", CultureInfo.CreateSpecificCulture("fr-CA")), Is.EqualTo("05:00"));
        }

        [Test]
        public void ShouldGetTimeSpecificToWhatIsSetOnCurrentThread()
        {
            Time time = new Time(05, 00, 00);

            CultureInfo clone = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            clone.DateTimeFormat.ShortTimePattern = "HH#mm";

            Thread.CurrentThread.CurrentCulture = clone;
            Assert.That(time.ToDateTime().ToString("t"), Is.EqualTo("05#00"));
        }

        [Test]
        public void ShouldCheckInRangeExclusiveToEndTime()
        {
            // A night shift, for instance
            Time start = new Time(20);
            Time end = new Time(8);

            Assert.IsTrue(new Time(5).InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(20).InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(7, 59, 59).InRangeEndTimeExclusive(start, end));

            Assert.IsFalse(new Time(19, 59, 59).InRangeEndTimeExclusive(start, end));
            Assert.IsFalse(new Time(8).InRangeEndTimeExclusive(start, end));
            Assert.IsFalse(new Time(11).InRangeEndTimeExclusive(start, end));
        }

        [Test]
        public void ShouldCheckIn24HourRangeExclusiveToEndTime()
        {
            // A Fort Hills 24H shift, for instance
            Time start = Time.START_OF_DAY;
            Time end = Time.END_OF_DAY;

            Assert.IsTrue(Time.START_OF_DAY.InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(5).InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(11).InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(20).InRangeEndTimeExclusive(start, end));
            Assert.IsTrue(new Time(7, 59, 59).InRangeEndTimeExclusive(start, end));

            Assert.IsFalse(Time.END_OF_DAY.InRangeEndTimeExclusive(start, end));
        }

        [Test]
        public void ShouldCheckIn24HourRange()
        {
            // A Fort Hills 24H shift, for instance
            Time start = Time.START_OF_DAY;
            Time end = Time.END_OF_DAY;

            Assert.IsTrue(Time.START_OF_DAY.InRange(start, end));
            Assert.IsTrue(new Time(5).InRange(start, end));
            Assert.IsTrue(new Time(11).InRange(start, end));
            Assert.IsTrue(new Time(20).InRange(start, end));
            Assert.IsTrue(new Time(7, 59, 59).InRange(start, end));
            Assert.IsTrue(Time.END_OF_DAY.InRange(start, end));
        }

        [Test]
        public void ShouldCheckIn24HourRangeWithNoPadding()
        {
            // A Fort Hills 24H shift, for instance
            Time start = Time.START_OF_DAY;
            Time end = Time.END_OF_DAY;

            var padding = new TimeSpan(0, 0, 0);

            var startTimeWithPadding = start.Subtract(padding);
            var endTimeWithPadding = end.Add(padding);

            Assert.IsTrue(Time.START_OF_DAY.InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(new Time(5).InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(new Time(7).InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(new Time(11).InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(new Time(20).InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(new Time(7, 59, 59).InRange(startTimeWithPadding, endTimeWithPadding));
            Assert.IsTrue(Time.END_OF_DAY.InRange(startTimeWithPadding, endTimeWithPadding));
        }
    }
}
