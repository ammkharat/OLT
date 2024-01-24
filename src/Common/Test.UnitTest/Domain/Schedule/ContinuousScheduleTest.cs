using System;
using System.Linq;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class ContinuousScheduleTest
    {
        [Test]
        public void ContinueScheduleShouldContainStartDateAndEndDate()
        {
            var startDate = new Date(2000, 1, 1);
            var endDate = new Date(2001, 1, 1);
            var continueSchedule =
                new ContinuousSchedule(startDate, endDate, Time.MIDNIGHT, Time.MIDNIGHT, SiteFixture.Sarnia());
            Assert.AreEqual(startDate, continueSchedule.StartDate);
            Assert.AreEqual(endDate, continueSchedule.EndDate);
        }

        [Test]
        public void ContinueScheduleShouldContainStartDateAndNoEndDate()
        {
            var startDate = new Date(2000, 1, 1);
            var continueSchedule = new ContinuousSchedule(startDate, Time.MIDNIGHT, SiteFixture.Sarnia());
            Assert.AreEqual(startDate, continueSchedule.StartDate);
            Assert.IsFalse(continueSchedule.HasEndDate);
        }

        [Test]
        public void ContinuousScheduleShouldBeScheduleTypeContinuous()
        {
            var schedule =
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            Assert.AreEqual(ScheduleType.Continuous, schedule.Type);
        }

        [Test]
        public void ContinuousScheduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof (ContinuousSchedule).IsSerializable);
        }

        [Test]
        public void ContinuousScheduleShouldImplementISchedule()
        {
            var startDate = new Date(2000, 1, 1);
            var continueSchedule = new ContinuousSchedule(startDate, Time.MIDNIGHT, SiteFixture.Sarnia());
            Assert.IsTrue(continueSchedule is ISchedule);
        }


        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleIsFullyInsideWindow()
        {
            var startDate = new Date(2000, 1, 2);
            var endDate = new Date(2000, 1, 10);
            var continueSchedule =
                new ContinuousSchedule(startDate, endDate, Time.MIDNIGHT, Time.MIDNIGHT, SiteFixture.Sarnia());
            var queryWindow = new Range<DateTime>(new DateTime(2000, 1, 1, 0, 0, 0),
                new DateTime(2000, 1, 30, 0, 0, 0));
      
            var scheduledOccurencesWithin = continueSchedule.ScheduledOccurencesWithin(queryWindow);
            
            Assert.AreEqual(1,
                scheduledOccurencesWithin.Count);
            Assert.AreEqual(new DateTime(2000, 1, 2, 0, 0, 0), scheduledOccurencesWithin.First().LowerBound);
            Assert.AreEqual(new DateTime(2000, 1, 10, 0, 0, 0), scheduledOccurencesWithin.First().UpperBound);
        }

        [Test]
        public void ToStringWithIncludeTime()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 07, 06);
            var endDate = new Date(2011, 07, 08);
            var startTime = new Time(14, 00);
            var endTime = new Time(17, 00);
            var schedule = new ContinuousSchedule(startDate, endDate, startTime,
                endTime, null, SiteFixture.Sarnia());

            var result = schedule.ToString();

            Assert.That(result, Is.EqualTo("Continuous from 07/06/2011 at 14:00 to 07/08/2011 at 17:00"));
        }

        [Test]
        public void ToStringWithNotIncludeTime()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 07, 06);
            var startTime = new Time(14, 00);
            var endTime = new Time(17, 00);
            var schedule = new ContinuousSchedule(startDate, null, startTime,
                endTime, null, SiteFixture.Sarnia());

            var result = schedule.ToString();

            Assert.That(result, Is.EqualTo("Continuous from 07/06/2011 at 14:00"));
        }

        [Test]
        public void TwoContinuousSchedulesWithEqualValuesShouldBeEqual()
        {
            Assert.AreEqual(
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight(),
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight());
        }

        [Test]
        public void TypeNameShouldReturnContinuous()
        {
            Assert.AreEqual(ScheduleType.Continuous,
                ContinuousScheduleFixture.
                    CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight().Type);
        }
    }
}