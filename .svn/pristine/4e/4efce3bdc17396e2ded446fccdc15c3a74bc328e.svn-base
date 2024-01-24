using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    [TestFixture]
    public class ActionItemDefinitionFLOCShiftAdjustedScheduleTest
    {
        private Mockery mock;
        private IShiftPatternService shiftPatternServiceMock;

        [SetUp]
        public void SetUp()
        {
            Clock.TimeZone = TimeZoneFixture.GetSarniaTimeZone();
            mock = new Mockery();
            shiftPatternServiceMock = mock.NewMock<IShiftPatternService>();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldCalculateNextInvokeTime()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 01, 09, 10, 0, 0);
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();

            var floc = FunctionalLocationFixture.GetAny_Unit1();
            var correspondingShiftDay =
                ShiftPatternFixture.CreateShiftPattern(new Time(recurringDailySchedule.StartDateTime),
                    new Time(recurringDailySchedule.EndDateTime));

            var shift = new UserShift(correspondingShiftDay, Clock.Now);

            var startScheduleTime = recurringDailySchedule.NextInvokeDateTime;
            Assert.AreEqual(new DateTime(2000, 01, 10, 10, 12, 00), startScheduleTime);
            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);

            Stub.On(shiftPatternServiceMock)
                .Method("GetShiftBySiteAndDateTime")
                .WithAnyArguments()
                .Will(Return.Value(correspondingShiftDay));

            Assert.AreEqual(shift.StartDateTimeWithPadding.ToTime(), new Time(schedule.NextInvokeDateTime));

            Assert.AreEqual(shift.StartDateTimeWithPadding.ToTime(), new Time(schedule.NextInvokeDateTime));

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDelegateEvaluationOfCrossesDayBoundaryToActualSchedule()
        {
            var actualSchedule = mock.NewMock<ISchedule>();
            Expect.Once.On(actualSchedule).GetProperty("CrossesDayBoundary").Will(Return.Value(true));

            Stub.On(actualSchedule).GetProperty("EndDateTime").Will(Return.Value(DateTime.MinValue));
            var adjustedSchedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(actualSchedule, null, -99, shiftPatternServiceMock);

            // Execute:
            Assert.IsTrue(adjustedSchedule.CrossesDayBoundary);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test] // Talk to Troy or Mike Hesse if you don't understand this test and want to make a change.
        public void ShouldFireDailyScheduleOnceEachDay()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 6, 15, 16, 0, 0);
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15();

            var floc = FunctionalLocationFixture.GetAny_Unit1();

            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);

            var correspondingShiftDay =
                ShiftPatternFixture.CreateShiftPattern(new Time(6, 0, 0),
                    new Time(18, 0, 0));

            Stub.On(shiftPatternServiceMock)
                .Method("GetShiftBySiteAndDateTime")
                .WithAnyArguments()
                .Will(Return.Value(correspondingShiftDay));

            var nextInvokeDateTime = schedule.NextInvokeDateTime;
            var expectedNextInvokeDateTime = new DateTime(2006, 6, 15, 5, 30, 0);
            Assert.AreEqual(expectedNextInvokeDateTime, nextInvokeDateTime);

            schedule.LastInvokedDateTime = Clock.Now;

            nextInvokeDateTime = schedule.NextInvokeDateTime;
            expectedNextInvokeDateTime = new DateTime(2006, 6, 16, 5, 30, 0);
            Assert.AreEqual(expectedNextInvokeDateTime, nextInvokeDateTime);
        }

        [Test]
        public void ShouldInitializeNewAdjustedShiftDateTimeAsNextInvokeTime()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 01, 09, 10, 0, 0);

            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            var shift = new UserShift(correspondingShift, Clock.Now);

            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);

            Expect.Once.On(shiftPatternServiceMock)
                .Method("GetShiftBySiteAndDateTime")
                .With(floc.Site, recurringDailySchedule.NextInvokeDateTime)
                .Will(Return.Value(correspondingShift));

            var nextInvokeTime = schedule.NextInvokeDateTime;

            Assert.AreNotEqual(recurringDailySchedule.NextInvokeDateTime, nextInvokeTime);
            Assert.AreEqual(shift.StartDateTimeWithPadding.ToTime(), new Time(nextInvokeTime));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldMimicDecorateActionItemDefintionSchedule()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 01, 10, 1, 0, 0);
            ISchedule hourlySchedule =
                RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
            var floc = FunctionalLocationFixture.GetAny_Unit1();

            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(hourlySchedule, floc, 1, shiftPatternServiceMock);

            Assert.AreEqual(hourlySchedule.EndDate, schedule.EndDate);
            Assert.AreEqual(hourlySchedule.EndDateTime, schedule.EndDateTime);
            Assert.AreEqual(hourlySchedule.HasEndDate, schedule.HasEndDate);
            Assert.AreEqual(hourlySchedule.Id, schedule.Id);
            Assert.AreEqual(hourlySchedule.IsNextScheduledTimeValid, schedule.IsNextScheduledTimeValid);
            Assert.AreEqual(hourlySchedule.StartDate, schedule.StartDate);
            Assert.AreEqual(hourlySchedule.StartDateTime, schedule.StartDateTime);
            Assert.AreEqual(hourlySchedule.Type, schedule.Type);
        }

        [Test]
        public void ShouldReturnFunctionalLocationId()
        {
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();

            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);
            Assert.AreEqual(floc.Id, schedule.FunctionalLocationId);
        }

        [Test]
        public void ShouldTestIfScheduleWillFire()
        {
            var schedule =
                CreateScheduleForTestingWillFire(new DateTime(2000, 01, 09, 10, 0, 0),
                    new DateTime(2000, 1, 10, 10, 12, 0),
                    new DateTime(2000, 10, 21, 19, 11, 0));

            Assert.IsTrue(schedule.IsNextScheduledTimeValid, "Schedule should fire as the next invoke time " +
                                                             "(2000/01/10 09:57) is still before schedule end (2000/10/21 19:11).");

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldTestIfScheduleWillNotFire()
        {
            var schedule =
                CreateScheduleForTestingWillFire(new DateTime(2000, 01, 09, 10, 0, 0),
                    new DateTime(2000, 10, 22, 10, 12, 0),
                    new DateTime(2000, 10, 21, 19, 11, 0));

            Assert.IsFalse(schedule.IsNextScheduledTimeValid,
                "Schedule should not fire because schedule start is after schedule end.");

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ToStringShouldDelegateToDecoratedSchedule()
        {
            var mockSchedule = mock.NewMock<ISchedule>();
            var floc = FunctionalLocationFixture.GetAny_Unit1();

            Stub.On(mockSchedule).GetProperty("EndDateTime").Will(Return.Value(new DateTime()));
            Expect.Once.On(mockSchedule).Method("ToString").Will(Return.Value(string.Empty));
            new ActionItemDefinitionFLOCShiftAdjustedSchedule(mockSchedule, floc, 1, shiftPatternServiceMock).ToString();

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ToStringWithEndDateShouldDelegateToDecoratedSchedule()
        {
            var mockSchedule = mock.NewMock<ISchedule>();
            var floc = FunctionalLocationFixture.GetAny_Unit1();

            Stub.On(mockSchedule).GetProperty("EndDateTime").Will(Return.Value(new DateTime()));
            Expect.Once.On(mockSchedule).Method("ToString").With(true).Will(Return.Value(string.Empty));
            new ActionItemDefinitionFLOCShiftAdjustedSchedule(mockSchedule, floc, 1, shiftPatternServiceMock).ToString(
                true);

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        private ActionItemDefinitionFLOCShiftAdjustedSchedule CreateScheduleForTestingWillFire(DateTime now,
            DateTime scheduleStart,
            DateTime scheduleEnd)
        {
            Clock.Freeze();
            Clock.Now = now;

            var recurringDailySchedule = CreateRecurringSchedule(scheduleStart, scheduleEnd);

            var floc = FunctionalLocationFixture.GetAny_Unit1();
            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);

            return schedule;
        }

        private static ISchedule CreateRecurringSchedule(DateTime start, DateTime end)
        {
            return new RecurringDailySchedule(201,
                new Date(start), new Date(end), new Time(start), new Time(end), 2, null,
                SiteFixture.Sarnia());
        }
    }
}