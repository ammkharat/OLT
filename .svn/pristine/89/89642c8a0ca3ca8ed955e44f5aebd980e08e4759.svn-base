using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.Serialization.Formatters.Binary;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class SingleScheduleTest
    {

        [SetUp]
        public void Setup()
        {
            Clock.Freeze();
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }


        [Test]
        public void SingleScheduleShouldImplementISerializable()
        {
            Assert.IsTrue(typeof (SingleSchedule).IsSerializable, "SingleSchedule does not have serializable attribute");
        }

        [Test]
        public void SingleScheduleShouldBeSerializable()
        {
            Date startDate = new Date(2000, 1, 1);
            Time startTime = new Time(12, 30);
            Time endTime = new Time(13, 15);
            SingleSchedule singleScheduleToBeSerialized =
                new SingleSchedule(startDate, startTime, endTime, SiteFixture.Sarnia());

            SingleSchedule deserializedSingleSchedule =
                TestUtil.SerializeAndDeSerialize<SingleSchedule>(singleScheduleToBeSerialized, new BinaryFormatter());

            Assert.AreEqual(singleScheduleToBeSerialized.StartDateTime, deserializedSingleSchedule.StartDateTime);
            Assert.AreEqual(singleScheduleToBeSerialized.EndDateTime, deserializedSingleSchedule.EndDateTime);
        }

        [Test]
        public void TypeNameShouldReturnSingle()
        {
            Assert.AreEqual(ScheduleType.Single,
                            SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM().Type);
        }

        [Test]
        public void TwoSingleSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM(),
                            SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM());
        }

        [Test]
        public void TwoSchedulesShouldNotBeEqualIfTheStartDateTimesAreDifferent()
        {
            SingleSchedule originalSchedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            SingleSchedule differentSchedule =
                new SingleSchedule(Clock.DateNow, originalSchedule.StartTime, originalSchedule.EndTime,
                                   SiteFixture.Sarnia());
            Assert.AreNotEqual(originalSchedule, differentSchedule);
        }

        [Test]
        public void TwoSchedulesShouldNotBeEqualIfTheEndDateTimesAreDifferent()
        {
            SingleSchedule originalSchedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            SingleSchedule differentSchedule =
                new SingleSchedule(originalSchedule.StartDate, Clock.TimeNow, Clock.TimeNow, SiteFixture.Sarnia());
            Assert.AreNotEqual(originalSchedule, differentSchedule);
        }

        [Test]
        public void HashCodeShouldBeTheSameForTwoEqualSchedules()
        {
            Assert.AreEqual(SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM().GetHashCode(),
                            SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM().GetHashCode());
        }

        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleIsFullyInsideWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(1,s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1,0,0,0),new DateTime(2000, 1, 2))).Count);
            
        }

        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleOverlapsStartOfWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(1,s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1,1,1,30),new DateTime(2000, 1, 2))).Count);
        }

        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleStartsInAndEndsAfterWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(1,s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1,1,0,30),new DateTime(2000, 1, 1,1,1,4))).Count);
        }


        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleStartsRightOnStartOfWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(1, s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1, 1, 1, 00), new DateTime(2000, 1, 1, 1, 3, 4))).Count);
            
        }
        
        [Test]
        public void ShouldHaveATimeForWindowWhenScheduleStartsRightBeforeEndOfWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(1, s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1, 1, 1, 59), new DateTime(2000, 1, 1, 1, 3, 4))).Count);
            
        }

        [Test]
        public void ShouldNotHaveATimeForWindowWhenScheduleStartsRightAfterEndOfWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(0, s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1, 1, 2, 01), new DateTime(2000, 1, 1, 1, 3, 4))).Count);
        }

        [Test]
        public void ShouldNotHaveATimeForWindowWhenScheduleEndsRightBeforeStartOfWindow()
        {
            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            Assert.AreEqual(0, s1.ScheduledOccurencesWithin(new Range<DateTime>(new DateTime(2000, 1, 1, 1, 0, 00), new DateTime(2000, 1, 1, 1, 0, 59))).Count);
        }

        [Test]
        public void ShouldSortByNextScheduleTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 0, 0, 0);
            List<ISchedule> list = new List<ISchedule>();

            ISchedule s1 = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            ISchedule s7 = SingleScheduleFixture.Create2000Jan1AM7MinTo30Min();
            ISchedule s15 = SingleScheduleFixture.Create2000Jan1AM15MinTo30Min();

            list.Add(s1);
            list.Add(s7);
            list.Add(s15);

            list.Sort(s=> s.NextInvokeDateTime);
            
            Assert.AreEqual(s1, list[0]);
            Assert.AreEqual(s7, list[1]);
            Assert.AreEqual(s15, list[2]);
        }

        [Test]
        public void IfCurrentDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            Clock.Now = new DateTime(2005, 10, 17, 17, 0, 0);
            ISchedule schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void NextInvokeDateTimesShouldOnlyReturnOneDateTime()
        {
            Clock.Now = new DateTime(2005, 10, 16, 17, 0, 0);
            ISchedule schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            List<DateTime> nextInvokeDateTimes = schedule.NextInvokeDateTimes(Clock.Now.AddDays(10));
            Assert.AreEqual(1, nextInvokeDateTimes.Count);
            Assert.AreEqual(new DateTime(2005, 10, 17, 8, 0, 0), nextInvokeDateTimes[0]);
        }

        [Test]
        public void NextInvokeDateTimesShouldNotReturnAnythingIfCurrentDateTimeIsPastScheduleEndDateTime()
        {
            Clock.Now = new DateTime(2005, 10, 17, 17, 0, 0);
            ISchedule schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);

            List<DateTime> nextInvokeDateTimes = schedule.NextInvokeDateTimes(Clock.Now.AddDays(3));
            Assert.AreEqual(0, nextInvokeDateTimes.Count);
        }

        [Test]
        public void ShouldNotGetNextInvokeDateTimeAtExactlyEndDateDate()
        {
            Clock.Now = new DateTime(2010, 12, 20, 5, 0, 0);
            DateTime now = Clock.Now;
            DateTime fiveMinutesFromNow = now.AddMinutes(5);

            SingleSchedule schedule = new SingleSchedule(new Date(now),  new Time(fiveMinutesFromNow), new Time(fiveMinutesFromNow), SiteFixture.Denver());

            List<DateTime> nextInvokeDateTimes = schedule.NextInvokeDateTimes(fiveMinutesFromNow);
            Assert.AreEqual(0, nextInvokeDateTimes.Count);
        }

        [Test]
        public void Defect_1889()
        {
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            SingleSchedule singleSchedule = new SingleSchedule(332, new Date(2006, 04, 25), new Time(18), new Time(6), new DateTime(2006, 4, 25, 18, 0, 0), SiteFixture.Sarnia());
//            Assert.That(singleSchedule.NextInvokeDateTime, Is.Not.Null);

            TimeZoneConvertedSchedule schedule = new TimeZoneConvertedSchedule(singleSchedule, TimeZoneFixture.GetMountainTimeZone());
            DateTime nextInvokeDateTime = schedule.NextInvokeDateTime;
            Assert.That(nextInvokeDateTime, Is.Not.Null);

        }
    }
}