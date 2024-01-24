using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;
using Is = Rhino.Mocks.Constraints.Is;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    [TestFixture]
    public class SchedulerTest
    {
        private const long MILLISECONDS_IN_MIN = 60*1000;
        private const long MILLISECONDS_IN_HR = 60*MILLISECONDS_IN_MIN;
        private const long MILLISECONDS_IN_DAY = 24*MILLISECONDS_IN_HR;
        private IStopWatch blastoffStopWatch;
        private NonBatchingScheduler nonBatchingScheduler;
        private ISchedule recurrEvery2DayFrom2AmBetweenJan1AndJan5;
        private ISchedule recurrEvery2MinFrom1Am15MinTo1Am25Min;
        private ISchedule recurrEvery30MinFrom1Am15Minto3Am;

        private ISchedule recurrEvery6HrFrom2AmTo3PmBetweenJan1AndJan2;
        private IStopWatch restartStopWatch;
        private IScheduleHandler scheduleHandler;
        private IShiftPatternService shiftPatternServiceMock;
        private ISchedule single1MinTo2Min;
        private ISchedule singleAt15Min;
        private ISchedule singleAt1MinTo5Min;
        private ISchedule singleAt2Hr15Min;
        private ISchedule singleAt7Min;
        private ISchedule singleFarFarAway;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);
            Clock.TimeZone = TimeZoneFixture.GetSarniaTimeZone();

            single1MinTo2Min = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();
            singleAt1MinTo5Min = SingleScheduleFixture.Create2000Jan1AM1MinTo5Min();
            singleAt7Min = SingleScheduleFixture.Create2000Jan1AM7MinTo30Min();
            singleAt15Min = SingleScheduleFixture.Create2000Jan1AM15MinTo30Min();
            singleAt2Hr15Min = SingleScheduleFixture.Create2000Jan2AM15MinTo30Min();
            singleFarFarAway = SingleScheduleFixture.CreateFarFarAwaySingleSchedule();

            recurrEvery2MinFrom1Am15MinTo1Am25Min =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25OnJan12000();
            recurrEvery30MinFrom1Am15Minto3Am =
                RecurringMinuteScheduleFixture.CreateEvery30MinutesFrom1AM15To3AM00OnJan12000();

            recurrEvery6HrFrom2AmTo3PmBetweenJan1AndJan2 =
                RecurringHourlyScheduleFixture.CreateEvery6HoursFrom2AMTo3PMBetweenJan12000AndJan22000();
            recurrEvery2DayFrom2AmBetweenJan1AndJan5 =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom2AMTo10AM11BetweenJan1AndJan5In2000();

            blastoffStopWatch = MockRepository.GenerateMock<IStopWatch>();
            restartStopWatch = MockRepository.GenerateMock<IStopWatch>();

            shiftPatternServiceMock = MockRepository.GenerateMock<IShiftPatternService>();

            scheduleHandler = MockRepository.GenerateMock<IScheduleHandler>();

            nonBatchingScheduler = new NonBatchingScheduler(blastoffStopWatch, restartStopWatch,
                TimeZoneFixture.GetMountainTimeZone()) {ScheduleHandler = scheduleHandler};
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void AddingAReallyFarAwayScheduleShouldFire()
        {
            Clock.Now = new DateTime(2000, 12, 31, 23, 0, 0);

            ISchedule schedule = new SingleSchedule(new Date(2003, 12, 31), new Time(23), new Time(23, 30),
                SiteFixture.Oilsands());
            const long l = 365L*3L*MILLISECONDS_IN_DAY;

            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Expect(sw => sw.CountDown(l, null)).Constraints(Is.Equal(l), Is.Anything());

            nonBatchingScheduler.AddSchedule(schedule);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void InitialLoadCompleteWithMaxIntMillisCountdownShouldAskBlastOffStopWatchToCountdownFromMax()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            nonBatchingScheduler.StartInitialLoad();

            var schedule = MockRepository.GenerateMock<ISchedule>();

            SetScheduleExpectationsForNextInvokeDateTimeOf(Clock.Now.AddMilliseconds(int.MaxValue),
                schedule);
            nonBatchingScheduler.AddSchedule(schedule);

            blastoffStopWatch.Expect(mock => mock.CountDown(int.MaxValue, Clock.Now.AddMilliseconds(int.MaxValue)));

            nonBatchingScheduler.InitialLoadComplete();

            blastoffStopWatch.VerifyAllExpectations();
            schedule.VerifyAllExpectations();
        }

        [Test]
        public void InitialLoadCompleteWithTenMillisCountdownShouldAskBlastOffStopWatchToCountdownFromTen()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            nonBatchingScheduler.StartInitialLoad();

            var schedule = MockRepository.GenerateMock<ISchedule>();

            SetScheduleExpectationsForNextInvokeDateTimeOf(Clock.Now.AddMilliseconds(10), schedule);
            nonBatchingScheduler.AddSchedule(schedule);

            blastoffStopWatch.Expect(mock => mock.CountDown(10, Clock.Now.AddMilliseconds(10)));

            nonBatchingScheduler.InitialLoadComplete();

            blastoffStopWatch.VerifyAllExpectations();
            schedule.VerifyAllExpectations();
        }

        [Test]
        public void InitialLoadCompleteWithZeroMillisCountdownShouldAskBlastOffStopWatchToCountdownFromZero()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            nonBatchingScheduler.StartInitialLoad();

            var schedule = MockRepository.GenerateMock<ISchedule>();

            SetScheduleExpectationsForNextInvokeDateTimeOf(Clock.Now, schedule);
            nonBatchingScheduler.AddSchedule(schedule);

            blastoffStopWatch.Expect(mock => mock.CountDown(0, Clock.Now));

            nonBatchingScheduler.InitialLoadComplete();
            blastoffStopWatch.VerifyAllExpectations();
            schedule.VerifyAllExpectations();
        }

        [Test]
        public void RecurringDailyScheduleShouldFireOnceADayAtTheStartOfTheDay()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();
            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0); // Server Time

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_HR), Is.Anything());
            nonBatchingScheduler.AddSchedule(recurrEvery2DayFrom2AmBetweenJan1AndJan5);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(2*MILLISECONDS_IN_DAY), Is.Anything())
                .Repeat.Times(2);

            Clock.Now = new DateTime(2000, 1, 1, 0, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(2000, 1, 3, 0, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void RecurringHourlyScheduleShouldRolloverIntoNextDayAndStartAtTheTopOfTheDayRange()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_HR), Is.Anything());
            nonBatchingScheduler.AddSchedule(recurrEvery6HrFrom2AmTo3PmBetweenJan1AndJan2);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(6*MILLISECONDS_IN_HR), Is.Anything())
                .Repeat.Times(2);

            Clock.Now = new DateTime(2000, 1, 1, 0, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(2000, 1, 1, 6, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(12*MILLISECONDS_IN_HR), Is.Anything());

            Clock.Now = new DateTime(2000, 1, 1, 12, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(6*MILLISECONDS_IN_HR), Is.Anything())
                .Repeat.Times(2);

            Clock.Now = new DateTime(2000, 1, 2, 0, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(2000, 1, 2, 6, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(2000, 1, 2, 12, 0, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void RemovedScheduleShouldNotFire()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0); // Server Time

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(15*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(recurrEvery2MinFrom1Am15MinTo1Am25Min);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(2*MILLISECONDS_IN_MIN), Is.Anything());
            Clock.Now = new DateTime(1999, 12, 31, 23, 15, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            nonBatchingScheduler.RemoveSchedule(recurrEvery2MinFrom1Am15MinTo1Am25Min);
            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBeAbleToAddActionItemDefinitionFLOCShiftAdjustedSchedule()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            var schedule = single1MinTo2Min;
            var functionalLocationSarnia = FunctionalLocationFixture.GetAny_Equip1();
            var functionalLocationFortMac =
                FunctionalLocationFixture.GetAny_Equip1();

            var shiftStartTime = new Time(schedule.StartDateTime);
            shiftStartTime = shiftStartTime.Add(-1);

            var shiftEndTime = new Time(schedule.EndDateTime);
            shiftEndTime = shiftEndTime.Add(1);

            var shiftPatternForSchedule = ShiftPatternFixture.CreateShiftPattern(shiftStartTime, shiftEndTime);

            shiftPatternServiceMock.Stub(
                mock => mock.GetShiftBySiteAndDateTime(functionalLocationSarnia.Site, schedule.NextInvokeDateTime))
                .Return(shiftPatternForSchedule);
            shiftPatternServiceMock.Stub(
                mock => mock.GetShiftBySiteAndDateTime(functionalLocationFortMac.Site, schedule.NextInvokeDateTime))
                .Return(shiftPatternForSchedule);

            ISchedule shiftAdjustedScheduleSarnia =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(SingleScheduleFixture.Create2000Jan1AM1MinTo2Min(),
                    functionalLocationSarnia, 1, shiftPatternServiceMock);
            ISchedule shiftAdjustedScheduleFortMac =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(SingleScheduleFixture.Create2000Jan1AM1MinTo2Min(),
                    functionalLocationFortMac, 1, shiftPatternServiceMock);
            shiftAdjustedScheduleFortMac.Id = shiftAdjustedScheduleSarnia.Id + 1;

            blastoffStopWatch.Stub(mock => mock.CountDown(-1, null)).IgnoreArguments();

            nonBatchingScheduler.AddSchedule(shiftAdjustedScheduleSarnia);
            nonBatchingScheduler.AddSchedule(shiftAdjustedScheduleFortMac);

            shiftPatternServiceMock.VerifyAllExpectations();
            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBeAbleToRemoveSpecificActionItemDefinitionFLOCShiftAdjustedSchedule()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);
            var schedule = single1MinTo2Min;
            var functionalLocationSarnia = FunctionalLocationFixture.GetAny_Equip1();
            var functionalLocationFortMac =
                FunctionalLocationFixture.GetAny_Equip1();

            var shift =
                ShiftPatternFixture.CreateShiftPattern(new Time(single1MinTo2Min.StartDateTime),
                    new Time(single1MinTo2Min.EndDateTime));

            shiftPatternServiceMock.Stub(
                mock => mock.GetShiftBySiteAndDateTime(functionalLocationSarnia.Site, schedule.StartDateTime))
                .Return(shift);
            shiftPatternServiceMock.Stub(
                mock => mock.GetShiftBySiteAndDateTime(functionalLocationFortMac.Site, schedule.StartDateTime))
                .Return(shift);

            ISchedule shiftAdjustedScheduleSarnia =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(SingleScheduleFixture.Create2000Jan1AM1MinTo2Min(),
                    functionalLocationSarnia, 1, shiftPatternServiceMock);

            ISchedule shiftAdjustedScheduleFortMac =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(SingleScheduleFixture.Create2000Jan1AM1MinTo2Min(),
                    functionalLocationFortMac, 1, shiftPatternServiceMock);
            shiftAdjustedScheduleFortMac.Id = shiftAdjustedScheduleSarnia.Id + 1;

            blastoffStopWatch.Stub(mock => mock.CountDown(-1, null)).IgnoreArguments();

            nonBatchingScheduler.AddSchedule(shiftAdjustedScheduleSarnia);
            nonBatchingScheduler.AddSchedule(shiftAdjustedScheduleFortMac);

            nonBatchingScheduler.RemoveSchedule(shiftAdjustedScheduleSarnia);
            Assert.AreEqual(1, nonBatchingScheduler.Count);

            shiftPatternServiceMock.VerifyAllExpectations();
            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void
            ShouldCountDown15MinsThenChangeCountDownToOneMinuteThenContinueCountingOneMinuteBecuaseSevenMinutesComesAfterOneMinute
            ()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(15*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(singleAt15Min);
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);

            blastoffStopWatch.Expect(mock => mock.CountDown(-1, null))
                .Constraints(Is.Equal(7*MILLISECONDS_IN_MIN), Is.Anything())
                .Repeat.Never();

            nonBatchingScheduler.AddSchedule(singleAt7Min);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCountDown1MinAndThenZeroIfTwoSchedulesAddedWithTheSameTimes()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);
            nonBatchingScheduler.AddSchedule(singleAt1MinTo5Min);
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null)).Constraints(Is.Equal((long) 0), Is.Anything());
            Clock.Now = new DateTime(1999, 12, 31, 23, 1, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCountDown1MinBlastOffAndThenCountDown6MinsBlastOffThenCountDown8MinsAndStop()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(15*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(singleAt15Min);
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);
            nonBatchingScheduler.AddSchedule(singleAt7Min);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(6*MILLISECONDS_IN_MIN), Is.Anything());
            Clock.Now = new DateTime(1999, 12, 31, 23, 1, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(8*MILLISECONDS_IN_MIN), Is.Anything());
            Clock.Now = new DateTime(1999, 12, 31, 23, 7, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(1999, 12, 31, 23, 15, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCountDown1MinWithOneSingleScheduleSetTo1MinFromNow()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCountDown1MinWithOneSingleScheduleSetTo1MinFromNowAndNeverFireAgain()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(1*MILLISECONDS_IN_MIN), Is.Anything());
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);

            // Move the clock up one minute
            Clock.Now = new DateTime(1999, 12, 31, 23, 1, 0);

            var intendedExecutionTime = single1MinTo2Min.StartDateTime;
            nonBatchingScheduler.BlastOffHandler(intendedExecutionTime);

            Assert.AreEqual(0, nonBatchingScheduler.Count);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldFire4RecurringSchedulesAnd2SingleSchedulesForATotalOf6Times()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);

            blastoffStopWatch.Expect(sw => sw.CountDown(75*MILLISECONDS_IN_MIN, new DateTime(2000, 01, 01, 00, 15, 00)));
            nonBatchingScheduler.AddSchedule(singleAt2Hr15Min);

            blastoffStopWatch.Expect(sw => sw.CountDown(15*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 15, 00)));
            nonBatchingScheduler.AddSchedule(singleAt15Min);

            nonBatchingScheduler.AddSchedule(recurrEvery30MinFrom1Am15Minto3Am);
                // won't cause a restart of blastoffstopwatch because it too will fire at the same time as single at 15 min schedule

            Assert.AreEqual(3, nonBatchingScheduler.Count);

            // move time to 11:15pm
            Clock.Now = new DateTime(1999, 12, 31, 23, 15, 0); // Server Time

            // expect to set the timer to zero ffor the second sechedule that is suppose to fire at 11:15pm.
            blastoffStopWatch.Expect(sw => sw.CountDown(0, new DateTime(1999, 12, 31, 23, 15, 0)));
            nonBatchingScheduler.BlastOffHandler(null);

            // re-occuring 30 minutes schedule should fire at 23:45.
            blastoffStopWatch.Expect(sw => sw.CountDown(30*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 45, 00)));
            nonBatchingScheduler.BlastOffHandler(null);

            // it's now 23:45
            Clock.Now = new DateTime(1999, 12, 31, 23, 45, 0);

            // re-occuring 30 minutes schedule should fire at 00:15.
            blastoffStopWatch.Expect(sw => sw.CountDown(30*MILLISECONDS_IN_MIN, new DateTime(2000, 01, 01, 00, 15, 00)));
            nonBatchingScheduler.BlastOffHandler(null);

            // it's now 00:15 on Jan 1st.
            Clock.Now = new DateTime(2000, 1, 1, 0, 15, 0);

            //the re-occuring one will fire and set the single 2:15am (sarnia time) to fire immediately as well. 
            blastoffStopWatch.Expect(sw => sw.CountDown(0, new DateTime(2000, 01, 01, 00, 15, 00)));
            nonBatchingScheduler.BlastOffHandler(null);

            // now the single 2:15am fires, and should set the re-occuring every 30 minutes to fire next
            blastoffStopWatch.Expect(sw => sw.CountDown(30*MILLISECONDS_IN_MIN, new DateTime(2000, 01, 01, 00, 45, 00)));
            nonBatchingScheduler.BlastOffHandler(null);

            // it's now 00:45. and the re-occuring one shouldn't fire again until "tomorrow"
            Clock.Now = new DateTime(2000, 1, 1, 0, 45, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldKnowHowLongUntilNextExecutionTimeEvenIfItFallsWithinTheDaylightSavingsHour()
        {
            {
                var rightNow = new DateTime(2012, 3, 11, 1, 30, 0);
                var intendedExecutionTime = new DateTime(2012, 3, 11, 2, 30, 0);
                    // time doesn't exist because of daylight savings 'spring forward'

                Assert.IsTrue(TimeZoneInfo.Local.IsInvalidTime(intendedExecutionTime));

                var ts = nonBatchingScheduler.TimeUntilExecution(rightNow, intendedExecutionTime);
                Assert.AreEqual(60, ts.TotalMinutes);
            }

            {
                var rightNow = new DateTime(2012, 11, 4, 1, 00, 0);
                    // time repeats twice due to daylight savings 'fall back'
                var intendedExecutionTime = new DateTime(2012, 11, 4, 2, 00, 0);

                Assert.IsTrue(TimeZoneInfo.Local.IsAmbiguousTime(rightNow));

                var ts = nonBatchingScheduler.TimeUntilExecution(rightNow, intendedExecutionTime);
                Assert.AreEqual(60, ts.TotalMinutes);
            }

            {
                var rightNow = new DateTime(2012, 11, 4, 0, 30, 0);
                var intendedExecutionTime = new DateTime(2012, 11, 4, 1, 30, 0);
                    // time repeats twice due to daylight savings 'fall back'

                var ts = nonBatchingScheduler.TimeUntilExecution(rightNow, intendedExecutionTime);
                Assert.AreEqual(60, ts.TotalMinutes);
            }

            {
                var rightNow = new DateTime(2012, 11, 4, 1, 30, 0);
                    // time repeats twice due to daylight savings 'fall back'
                var intendedExecutionTime = new DateTime(2012, 11, 4, 2, 30, 0);

                Assert.IsTrue(TimeZoneInfo.Local.IsAmbiguousTime(rightNow));

                var ts = nonBatchingScheduler.TimeUntilExecution(rightNow, intendedExecutionTime);
                Assert.AreEqual(60, ts.TotalMinutes);
            }
        }

        [Test]
        public void ShouldNotCrashIfYouTryAndRemoveAScheduleThatDoesNotExist()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            Assert.AreEqual(0, nonBatchingScheduler.Count);
            var schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            schedule.Id = -1;
            nonBatchingScheduler.RemoveSchedule(schedule);
        }

        [Test]
        public void ShouldNotFireSingleScheduleIfScheduleTimeIsBeforeCurrentTimeAndNotStillInTheCurrentShift()
        {
            Clock.Now = new DateTime(2000, 08, 15, 2, 0, 0);
            ISchedule schedule =
                new SingleSchedule(new Date(2000, 08, 14), new Time(12), new Time(17), SiteFixture.Sarnia());

            var functionalLocationSarnia = FunctionalLocationFixture.GetAny_Equip1();
            var shift = ShiftPatternFixture.CreateShiftPattern(new Time(11, 0, 0), new Time(19, 0, 0));

            shiftPatternServiceMock.Stub(mock => mock.GetShiftBySiteAndDateTime(null, Clock.Now))
                .IgnoreArguments()
                .Return(shift);

            ISchedule shiftAdjustedScheduleSarnia =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(schedule, functionalLocationSarnia, 1,
                    shiftPatternServiceMock);

            nonBatchingScheduler.AddSchedule(shiftAdjustedScheduleSarnia);
            Assert.AreEqual(0, nonBatchingScheduler.Count);

            shiftPatternServiceMock.VerifyAllExpectations();
        }


        [Test]
        public void ShouldRemoveMatchingSchedules_1()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null)).IgnoreArguments();

            nonBatchingScheduler.AddSchedule(single1MinTo2Min);
            nonBatchingScheduler.AddSchedule(singleAt15Min);
            nonBatchingScheduler.AddSchedule(singleAt2Hr15Min);
            nonBatchingScheduler.AddSchedule(singleFarFarAway);

            nonBatchingScheduler.RemoveMatchingSchedules(s => s.Id == singleAt15Min.Id);
            Assert.AreEqual(3, nonBatchingScheduler.Count);

            Assert.IsFalse(nonBatchingScheduler.Schedules.Exists(s => s.Id == singleAt15Min.Id));

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRemoveMatchingSchedules_2()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Stub(sw => sw.CountDown(-1, null)).IgnoreArguments();

            nonBatchingScheduler.AddSchedule(single1MinTo2Min);
            nonBatchingScheduler.AddSchedule(singleAt15Min);
            nonBatchingScheduler.AddSchedule(singleAt2Hr15Min);
            nonBatchingScheduler.AddSchedule(singleFarFarAway);

            nonBatchingScheduler.RemoveMatchingSchedules(s => true);
            Assert.AreEqual(0, nonBatchingScheduler.Count);


            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRemoveSchedule()
        {
            blastoffStopWatch.Expect(sw => sw.Stop());

            nonBatchingScheduler.AddSchedule(single1MinTo2Min);
            nonBatchingScheduler.AddSchedule(singleAt15Min);
            nonBatchingScheduler.AddSchedule(singleAt2Hr15Min);
            nonBatchingScheduler.AddSchedule(singleFarFarAway);

            nonBatchingScheduler.RemoveSchedule(singleAt15Min);
            Assert.AreEqual(3, nonBatchingScheduler.Count);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRemoveSingleScheduleFromListOnceBlastedOffOnceAndStop()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Expect(sw => sw.CountDown(-1, null))
                .Constraints(Is.Equal(15*MILLISECONDS_IN_MIN), Is.Anything());

            nonBatchingScheduler.AddSchedule(singleAt15Min);
            Assert.AreEqual(1, nonBatchingScheduler.Count);
            nonBatchingScheduler.BlastOffHandler(null);
            Assert.AreEqual(0, nonBatchingScheduler.Count);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldScheduleEvery2MinsForATotalOf6Times()
        {
            blastoffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);

            blastoffStopWatch.Expect(
                sw => sw.CountDown(15*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 15, 0, 0)));
            nonBatchingScheduler.AddSchedule(recurrEvery2MinFrom1Am15MinTo1Am25Min);

            Clock.Now = new DateTime(1999, 12, 31, 23, 15, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 17, 0, 0)));
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(1999, 12, 31, 23, 17, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 19, 0, 0)));
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(1999, 12, 31, 23, 19, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 21, 0, 0)));
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(1999, 12, 31, 23, 21, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 23, 0, 0)));
            nonBatchingScheduler.BlastOffHandler(null);

            Clock.Now = new DateTime(1999, 12, 31, 23, 23, 0);
            blastoffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 25, 0, 0)));
            nonBatchingScheduler.BlastOffHandler(null);


            Clock.Now = new DateTime(1999, 12, 31, 23, 25, 0);
            nonBatchingScheduler.BlastOffHandler(null);

            blastoffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldStartUpRestartStopWatchWhenSqlExceptionOccurrs()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());
            blastoffStopWatch.Stub(sw => sw.CountDown(-1, null)).IgnoreArguments();
            restartStopWatch.Stub(sw => sw.CountDown(-1, null)).IgnoreArguments();

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurrEvery30MinFrom1Am15Minto3Am,
                FunctionalLocationFixture.GetAny_Unit1(), 1,
                shiftPatternServiceMock);
            var shiftStartTime = new Time(schedule.StartDateTime);
            shiftStartTime = shiftStartTime.Add(-1);

            var shiftEndTime = new Time(schedule.EndDateTime);
            shiftEndTime = shiftEndTime.Add(1);

            var shiftPatternForSchedule = ShiftPatternFixture.CreateShiftPattern(shiftStartTime, shiftEndTime);

            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTime(null, Clock.Now))
                .IgnoreArguments()
                .Return(shiftPatternForSchedule)
                .Repeat.Times(2);

            nonBatchingScheduler.AddSchedule(schedule);
            restartStopWatch.Expect(sw => sw.Stop());

            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTime(null, Clock.Now))
                .IgnoreArguments()
                .Throw(new Exception("System.Data.SqlClient.SqlException: Login failed for user tgould"));
            nonBatchingScheduler.BlastOffHandler(Clock.Now);

            shiftPatternServiceMock.VerifyAllExpectations();
            restartStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void StopShouldStopTimers()
        {
            blastoffStopWatch.Expect(m => m.Stop());
            restartStopWatch.Expect(m => m.Stop());

            nonBatchingScheduler.StopScheduler();

            blastoffStopWatch.VerifyAllExpectations();
            restartStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void WhenAddingANewScheduleShouldResetTimerToTheDifferenceOfTheCurrentTimeAndTheScheduledTime()
        {
            blastoffStopWatch.Stub(sw => sw.Stop());

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0); // Server Time

            blastoffStopWatch.Expect(sw => sw.CountDown(15*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 15, 00)));
            nonBatchingScheduler.AddSchedule(singleAt15Min);

            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 30);
            var dueTimeInMilliSeconds = MILLISECONDS_IN_MIN/2;
            blastoffStopWatch.Expect(sw => sw.CountDown(dueTimeInMilliSeconds, new DateTime(1999, 12, 31, 23, 01, 00)));
            nonBatchingScheduler.AddSchedule(single1MinTo2Min);

            blastoffStopWatch.VerifyAllExpectations();
        }

        private static void SetScheduleExpectationsForNextInvokeDateTimeOf(DateTime nextInvokeDateTime,
            ISchedule schedule)
        {
            schedule.Expect(mock => mock.IsNextScheduledTimeValid).Return(true);
            schedule.Expect(mock => mock.NextInvokeDateTime).Return(nextInvokeDateTime).Repeat.AtLeastOnce();
            schedule.Expect(mock => mock.Site).Return(SiteFixture.Denver());
            schedule.Expect(mock => mock.Id).Return(-99).Repeat.AtLeastOnce();
        }
    }
}