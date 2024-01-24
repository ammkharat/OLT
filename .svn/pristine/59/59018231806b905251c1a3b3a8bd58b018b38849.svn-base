using System;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [TestFixture]
    public class LabAlertCheckRangeCalculatorTest
    {
        [Test]
        public void ShouldCalculateRangeForDailySchedulesBeforeExecutionTime()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 9, 10, 21, 0);

            Time fromTime = new Time(9, 00);
            Time endTime = new Time(10, 00);

            ISchedule dailySchedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2011, 3, 1), new Date(2011, 5, 15), fromTime, endTime, 1, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = dailySchedule;
            definition.LabAlertTagQueryRange = new LabAlertTagQueryDailyRange(fromTime, endTime);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            Assert.AreEqual(new DateTime(2011, 3, 9, 9, 00, 0), calculator.FromDateTime);
            Assert.AreEqual(new DateTime(2011, 3, 9, 10, 00, 0), calculator.ToDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForDailySchedulesDuringExecutionTime()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 9, 10, 21, 0);

            Time fromTime = new Time(9, 00);
            Time endTime = new Time(12, 00);

            ISchedule dailySchedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2011, 3, 1), new Date(2011, 5, 15), fromTime, endTime, 1, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = dailySchedule;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryDailyRange(fromTime, endTime);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            Assert.AreEqual(new DateTime(2011, 3, 8, 9, 00, 0), calculator.FromDateTime);
            Assert.AreEqual(new DateTime(2011, 3, 8, 12, 00, 0), calculator.ToDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForDailySchedulesAfterExecutionTime()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 9, 10, 21, 0);

            Time fromTime = new Time(11, 00);
            Time endTime = new Time(15, 00);

            ISchedule dailySchedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2011, 3, 1), new Date(2011, 5, 15),
                                                                           fromTime, endTime, 1,
                                                                           scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = dailySchedule;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryDailyRange(fromTime, endTime);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition,
                                                                                       scheduleExecutionDateTime);

            Assert.AreEqual(new DateTime(2011, 3, 8, 11, 00, 0), calculator.FromDateTime);
            Assert.AreEqual(new DateTime(2011, 3, 8, 15, 00, 0), calculator.ToDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_BasicCase()
        {
            DateTime lastInvokedDateTime = new DateTime(2006, 4, 16, 8, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2006, 4, 13, 10, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2006, 4, 15, 16, 0, 0).GetNetworkPortable();
          
            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Thursday, new Time(10), DayOfWeekCopy.Saturday, new Time(16), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_ScheduleDaySameAsRangeDays_RangeTimeBeforeScheduleTime()
        {
            DateTime lastInvokedDateTime = new DateTime(2006, 4, 16, 8, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2006, 4, 16, 4, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2006, 4, 16, 6, 0, 0).GetNetworkPortable();
            
            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Sunday, new Time(4), DayOfWeekCopy.Sunday, new Time(6), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_ScheduleDaySameAsRangeDays_RangeTimeEndSameAsScheduleTime()
        {
            DateTime lastInvokedDateTime = new DateTime(2006, 4, 16, 8, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2006, 4, 16, 4, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2006, 4, 16, 8, 0, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Sunday, new Time(4), DayOfWeekCopy.Sunday, new Time(8), expectedFromRangeDateTime, expectedToRangeDateTime);
        }


        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_ScheduleDaySameAsRangeDays_RangeTimeEndOneMinuteAfterScheduleTime()
        {
            DateTime lastInvokedDateTime = new DateTime(2006, 4, 16, 8, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2006, 4, 9, 4, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2006, 4, 9, 8, 1, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Sunday, new Time(4), DayOfWeekCopy.Sunday, new Time(8, 1), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_CheckRangeNextDayAfterSchedule() // from Andrew's spreadsheet
        {
            DateTime lastInvokedDateTime = new DateTime(2011, 3, 7, 9, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 1, 9, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 1, 10, 0, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Tuesday, new Time(9), DayOfWeekCopy.Tuesday, new Time(10), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_EverythingSameDayAndTime() // from Andrew's spreadsheet
        {
            DateTime lastInvokedDateTime = new DateTime(2011, 3, 7, 9, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 28, 9, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 7, 9, 0, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Monday, new Time(9), DayOfWeekCopy.Monday, new Time(9), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_CheckRangeBeforeSchedule_StartCheckRangeSameDayAsSchedule() // from Andrew's spreadsheet
        {
            DateTime lastInvokedDateTime = new DateTime(2011, 3, 7, 12, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 28, 9, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 2, 10, 0, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Monday, new Time(9), DayOfWeekCopy.Wednesday, new Time(10), expectedFromRangeDateTime, expectedToRangeDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForWeeklySchedules_CheckRangeBeforeSchedule_EndCheckRangeSameDayAsSchedule() // from Andrew's spreadsheet
        {
            DateTime lastInvokedDateTime = new DateTime(2011, 3, 7, 12, 0, 0);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 2, 10, 0, 0).GetNetworkPortable();
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 7, 9, 0, 0).GetNetworkPortable();

            DoWeeklyAssertion(lastInvokedDateTime, DayOfWeekCopy.Wednesday, new Time(10), DayOfWeekCopy.Monday, new Time(9), expectedFromRangeDateTime, expectedToRangeDateTime);
        }



        private void DoWeeklyAssertion(DateTime scheduleExecutionDateTime, DayOfWeek fromDayOfWeek, Time fromTime,
                                       DayOfWeek toDayOfWeek, Time toTime, DateTime expectedFromRangeDateTime,
                                       DateTime expectedToRangeDateTime)
        {
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEverySundayFrom8AMTO2PMBetweenMar15AndDec31In2006(scheduleExecutionDateTime);
                        
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            
            definition.LabAlertTagQueryRange = new LabAlertTagQueryWeeklyRange(fromTime, toTime, fromDayOfWeek, toDayOfWeek);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void SanityCheck_ShouldSubtractOneMonthFromEndOfMarchAndGetLastDayOfFeb()
        {
            DateTime endOfMarch = new DateTime(2011, 3, 30);
            DateTime result = endOfMarch.AddMonths(-1);
            
            Assert.AreEqual(28, result.Day);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_Basic()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 15, 10, 0, 0);
            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(15));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(10), new Time(11),
                                                                            DayOfMonth.Day(4), DayOfMonth.Day(9));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 9, 11, 0, 0);
            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 4, 10, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);

        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_RangeBeforeSchedule() // From Andrew's spreadsheet
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 1, 20, 0, 0);
            ISchedule monthlyDayOfMonthScheduleFor2011 = GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(1));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(12), new Time(12),
                                                                            DayOfMonth.Day(5), DayOfMonth.Day(8));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 8, 12, 0, 0);
            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 5, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_RangeWrapsSchedule()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 7, 20, 0, 0);

            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(1));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(12), new Time(12),
                                                                            DayOfMonth.Day(1), DayOfMonth.Day(15));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 15, 12, 0, 0);
            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 1, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_RangeEndMonthHas30Days_PreviousMonthHas31()
        {
            // This test is for bug #839

            DateTime scheduleExecutionDateTime = new DateTime(2011, 4, 4, 0, 0, 0);

            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(4));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(0), new Time(0),
                                                                            DayOfMonth.Day(1), DayOfMonth.Day(31));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 31, 0, 0, 0);
            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 1, 0, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_RangeReversed()
        {
            DateTime scheduleExecutionTime = new DateTime(2011, 3, 1, 20, 0, 0);

            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionTime, DayOfMonth.Day(1));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(12), new Time(12),
                                                                            DayOfMonth.Day(15), DayOfMonth.Day(10));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionTime);
            
            DateTime expectedFromRangeDateTime = new DateTime(2011, 1, 15, 12, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 10, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_EndRangeSameAsSchedule()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 1, 20, 0, 0);

            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(1));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(12), new Time(20),
                                                                            DayOfMonth.Day(1), DayOfMonth.Day(1));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);
            
            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 1, 12, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 1, 20, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyDayOfMonthSchedule_FromRangeSameAsToRange()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 1, 20, 0, 0);

            ISchedule monthlyDayOfMonthScheduleFor2011 = 
                GetMonthlyDayOfMonthScheduleFor2011(scheduleExecutionDateTime, DayOfMonth.Day(1));

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = monthlyDayOfMonthScheduleFor2011;

            definition.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(20), new Time(20),
                                                                            DayOfMonth.Day(1), DayOfMonth.Day(1));

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);
            
            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 1, 20, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 1, 20, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_Basic()
        {
            DateTime scheduleExecutionTime = new DateTime(2011, 3, 6, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.First, DayOfWeek.Sunday, scheduleExecutionTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(12), new Time(12), WeekOfMonth.Second, WeekOfMonth.Third, DayOfWeek.Monday, DayOfWeek.Monday);


            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 14, 12, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 21, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_FifthSunday()
        {
            DateTime scheduleExecutionTime = new DateTime(2011, 7, 31, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.First, DayOfWeek.Sunday, scheduleExecutionTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(12), new Time(12), WeekOfMonth.First, WeekOfMonth.Fifth, DayOfWeek.Monday, DayOfWeek.Monday);


            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 7, 4, 12, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 7, 25, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_FifthMondayInRangeBeforeFirstMondayInSchedule()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 7, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.First, DayOfWeek.Monday, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(12), new Time(12), WeekOfMonth.First, WeekOfMonth.Fifth, DayOfWeek.Monday, DayOfWeek.Monday);


            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 7, 12, 0, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 28, 12, 0, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

       [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_ToDateInRangeIsJustAfterScheduleRun()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 16, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.Third, DayOfWeek.Wednesday, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(10, 30), new Time(9, 0, 1), WeekOfMonth.First, WeekOfMonth.Third, DayOfWeek.Tuesday, DayOfWeek.Wednesday);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 1, 10, 30, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 2, 16, 9, 0, 1);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

       [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_ToDateInRangeIsJustAfterScheduleRun_2()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 4, 20, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.Third, DayOfWeek.Wednesday, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(10, 30), new Time(9, 0, 1), WeekOfMonth.First, WeekOfMonth.Third, DayOfWeek.Tuesday, DayOfWeek.Wednesday);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 1, 10, 30, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 16, 9, 0, 1);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_ToRangeSameAsFromRange_1()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 3, 16, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.Third, DayOfWeek.Wednesday, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(10, 30), new Time(10, 30), WeekOfMonth.First, WeekOfMonth.First, DayOfWeek.Tuesday, DayOfWeek.Tuesday);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 2, 1, 10, 30, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 3, 1, 10, 30, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }

        [Test]
        public void ShouldCalculateRangeForMonthlyWeeklySchedule_ToRangeSameAsFromRange_2()
        {
            DateTime scheduleExecutionDateTime = new DateTime(2011, 4, 20, 9, 0, 0);
            ISchedule schedule = GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth.Third, DayOfWeek.Wednesday, scheduleExecutionDateTime);

            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Schedule = schedule;
            definition.LabAlertTagQueryRange =
                new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(10, 30), new Time(10, 30), WeekOfMonth.Second, WeekOfMonth.Second, DayOfWeek.Friday, DayOfWeek.Friday);

            LabAlertCheckRangeCalculator calculator = new LabAlertCheckRangeCalculator(definition, scheduleExecutionDateTime);

            DateTime expectedFromRangeDateTime = new DateTime(2011, 3, 11, 10, 30, 0);
            DateTime expectedToRangeDateTime = new DateTime(2011, 4, 8, 10, 30, 0);

            Assert.AreEqual(expectedToRangeDateTime, calculator.ToDateTime);
            Assert.AreEqual(expectedFromRangeDateTime, calculator.FromDateTime);
        }


        private ISchedule GetMonthlyDayOfMonthScheduleFor2011(DateTime lastInvokedDateTime, DayOfMonth dayOfMonth)
        {
            ISchedule schedule = new RecurringMonthlyDayOfMonthSchedule(
                -1,
                new Date(2011, 1, 1),
                new Date(2011, 12, 31),
                new Time(10),
                new Time(10),
                dayOfMonth,
                Month.All,
                lastInvokedDateTime, SiteFixture.Oilsands());

            return schedule;
        }

        private ISchedule GetMonthlyDayOfWeekScheduleFor2011(WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, DateTime lastInvokedDateTime)
        {
            ISchedule schedule = new RecurringMonthlyDayOfWeekSchedule(-1, new Date(2011, 1, 1), new Date(2011, 12, 31),
                                                                       new Time(10), new Time(10), weekOfMonth,
                                                                       dayOfWeek, Month.All, lastInvokedDateTime,
                                                                       SiteFixture.Oilsands());

            return schedule;
        }

        // This is because I had a bug on real servers with references not matching up because the other object
        // came from the server. This allows me to make a DayOfWeek with different references
        private class DayOfWeekCopy : DayOfWeek
        {
            public new static readonly DayOfWeek Sunday = new DayOfWeekCopy(7);
            public new static readonly DayOfWeek Monday = new DayOfWeekCopy(1);
            public new static readonly DayOfWeek Tuesday = new DayOfWeekCopy(2);
            public new static readonly DayOfWeek Wednesday = new DayOfWeekCopy(3);
            public new static readonly DayOfWeek Thursday = new DayOfWeekCopy(4);
            public new static readonly DayOfWeek Friday = new DayOfWeekCopy(5);
            public new static readonly DayOfWeek Saturday = new DayOfWeekCopy(6);

            public DayOfWeekCopy(int value) : base(value)
            {
            }
        }
    }
}
