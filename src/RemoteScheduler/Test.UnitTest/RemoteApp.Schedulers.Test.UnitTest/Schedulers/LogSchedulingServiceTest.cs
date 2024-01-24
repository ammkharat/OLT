using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using log4net;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class LogSchedulingServiceTest
    {
        private ILogDefinitionService logDefinitionService;
        private LogSchedulingService logSchedulingService;
        private ILogService logService;
        private ILog mockLogger;
        private IRemoteEventRepeater mockRemoteEventRepeater;
        private IScheduleService mockScheduleService;
        private ITimeService mockTimeService;
        private Mockery mocks;
        private INonBatchingScheduler nonBatchingScheduler;
        private IShiftPatternService shiftPatternService;

        [SetUp]
        public void Initialize()
        {
            mocks = new Mockery();

            mockTimeService = mocks.NewMock<ITimeService>();

            Stub.On(mockTimeService).Method("GetTimeZoneInfo").WithAnyArguments().Will(
                Return.Value(TimeZoneFixture.GetMountainTimeZone()));

            nonBatchingScheduler = mocks.NewMock<INonBatchingScheduler>();

            logService = mocks.NewMock<ILogService>();
            shiftPatternService = mocks.NewMock<IShiftPatternService>();
            mockRemoteEventRepeater = mocks.NewMock<IRemoteEventRepeater>();
            logDefinitionService = mocks.NewMock<ILogDefinitionService>();
            mockScheduleService = mocks.NewMock<IScheduleService>();

            mockLogger = mocks.NewMock<ILog>();

            Stub.On(mockRemoteEventRepeater).EventAdd("ServerLogDefinitionCreated", Is.Anything);
            Stub.On(mockRemoteEventRepeater).EventAdd("ServerLogCancelledRecurringDefinition", Is.Anything);
            Stub.On(mockRemoteEventRepeater).EventAdd("ServerLogDefinitionUpdated", Is.Anything);

            Stub.On(nonBatchingScheduler)
                .SetProperty("ScheduleHandler")
                .To(new TypeMatcher(typeof (LogSchedulingService)));

            logSchedulingService = new LogSchedulingService(
                nonBatchingScheduler,
                logDefinitionService,
                logService,
                shiftPatternService,
                mockScheduleService,
                mockRemoteEventRepeater,
                mockTimeService,
                mockLogger);

            //Since If the schedulers crashs we capture the exception and do not throw it again (but instead
            //we log it) this expectation is used to confirm no errors are being thrown (and therefore logged)


            Expect.Never.On(mockLogger).Method("Error").WithAnyArguments();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
            Clock.UnFreeze();
        }

        [Test]
        public void OnScheduleTriggerShouldNotDoAnythingIfStopRequested()
        {
            var logDefinition = CreateLogDefinition(true, true, true, true, true, true);
            Expect.Once.On(nonBatchingScheduler).Method("StopScheduler");
            logSchedulingService.StopService();
            Expect.Once.On(mockLogger).Method("Debug").With("Stop Log Scheduler requested.");
            logSchedulingService.OnScheduleTrigger(logDefinition.Schedule, Clock.Now);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldContinueWithLoadEvenIfExceptionIsEncountered()
        {
            var badLogDefinition = CreateLogDefinition(false, false, false, false, false, false);
            badLogDefinition.Schedule = null;
            var definitions = new List<LogDefinition> {badLogDefinition};

            Expect.Once.On(nonBatchingScheduler).Method("StartInitialLoad");
            Expect.Once.On(nonBatchingScheduler).Method("InitialLoadComplete");
            Stub.On(logDefinitionService).Method("QueryAllForScheduling").Will(Return.Value(definitions));
            Stub.On(mockLogger);

            logSchedulingService.LoadScheduler();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldInsertDailyDirectiveLogIfDefinitionWasOfTypeDirective()
        {
            var schedule = mocks.NewMock<ISchedule>();
            const long scheduleId = -99;

            var logDefinition = LogDefinitionFixture.CreateLogDefinition(1, LogType.DailyDirective);

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(Clock.Now));
            Stub.On(logService)
                .Method("HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs")
                .WithAnyArguments()
                .Will(Return.Value(false));

            Stub.On(schedule).GetProperty("IdValue").Will(Return.Value(scheduleId));
            Stub.On(schedule).GetProperty("Id").Will(Return.Value(scheduleId));
            Expect.Once.On(logDefinitionService).Method("QueryByScheduleId")
                .With(scheduleId).Will(Return.Value(logDefinition));
            Expect.Once.On(shiftPatternService).Method("GetShiftBySiteAndDateTime")
                .Will(Return.Value(ShiftPatternFixture.Create8HourDayShift()));

            Expect.Once.On(logService).Method("Insert").With(HasProperty("LogType", LogType.DailyDirective));

            Expect.Once.On(mockScheduleService).Method("Update").WithAnyArguments();
            Expect.AtLeastOnce.On(mockLogger).Method("Debug").WithAnyArguments();
            logSchedulingService.OnScheduleTrigger(schedule, Clock.Now);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldInsertNewLogWithFieldsFromDefinitionOnScheduleTrigger_OneFloc_CreateALogForEachFloc()
        {
            var flocs = new List<FunctionalLocation> {FunctionalLocationFixture.CreateNew(1)};
            AssertInsertLogOnScheduleTrigger(flocs, 1, true);
        }

        [Test]
        public void ShouldInsertNewLogWithFieldsFromDefinitionOnScheduleTrigger_OneFloc_CreateOneLogForAllFlocs()
        {
            var flocs = new List<FunctionalLocation> {FunctionalLocationFixture.CreateNew(1)};
            AssertInsertLogOnScheduleTrigger(flocs, 1, false);
        }

        [Test]
        public void ShouldInsertNewLogWithFieldsFromDefinitionOnScheduleTrigger_TwoFlocs_CreateALogForEachFloc()
        {
            var flocs = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2)
            };
            AssertInsertLogOnScheduleTrigger(flocs, 2, true);
        }

        [Test]
        public void ShouldInsertNewLogWithFieldsFromDefinitionOnScheduleTrigger_TwoFlocs_CreateOneLogForAllFlocs()
        {
            var flocs = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2)
            };
            AssertInsertLogOnScheduleTrigger(flocs, 1, false);
        }

        private void AssertInsertLogOnScheduleTrigger(List<FunctionalLocation> flocs, int numberOfLogs,
            bool createALogForEachFunctionalLocation)
        {
            var schedule = mocks.NewMock<ISchedule>();

            const long scheduleId = -99;
            var logDefinition = LogDefinitionFixture.CreateLogDefinition(flocs, createALogForEachFunctionalLocation);
            logDefinition.Id = 1;

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(Clock.Now));
            Stub.On(logService)
                .Method("HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs")
                .WithAnyArguments()
                .Will(Return.Value(false));

            Stub.On(schedule).GetProperty("IdValue").Will(Return.Value(scheduleId));
            Stub.On(schedule).GetProperty("Id").Will(Return.Value(scheduleId));

            Expect.Once.On(logDefinitionService).Method("QueryByScheduleId")
                .With(scheduleId).Will(Return.Value(logDefinition));
            Expect.Exactly(numberOfLogs).On(shiftPatternService).Method("GetShiftBySiteAndDateTime")
                .Will(Return.Value(ShiftPatternFixture.Create8HourDayShift()));

            Expect.Exactly(numberOfLogs).On(logService).Method("Insert")
                .With(HasProperty("InspectionFollowUp", logDefinition.InspectionFollowUp)
                      & HasProperty("ProcessControlFollowUp", logDefinition.ProcessControlFollowUp)
                      & HasProperty("OperationsFollowUp", logDefinition.OperationsFollowUp)
                      & HasProperty("SupervisionFollowUp", logDefinition.SupervisionFollowUp)
                      &
                      HasProperty("EnvironmentalHealthSafetyFollowUp", logDefinition.EnvironmentalHealthSafetyFollowUp)
                      & HasProperty("OtherFollowUp", logDefinition.OtherFollowUp)
                      & HasProperty("LogType", LogType.Standard)
                      & new LinkMatcher(logDefinition.DocumentLinks));

            Expect.Once.On(mockScheduleService).Method("Update").WithAnyArguments();
            Expect.AtLeastOnce.On(mockLogger).Method("Debug").WithAnyArguments();
            logSchedulingService.OnScheduleTrigger(schedule, Clock.Now);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        private class LinkMatcher : Matcher
        {
            private readonly List<DocumentLink> expectedList;

            public LinkMatcher(List<DocumentLink> expectedList)
            {
                this.expectedList = expectedList;
            }

            public override bool Matches(object o)
            {
                var log = (Log) o;

                if (log.DocumentLinks.Count != expectedList.Count)
                {
                    return false;
                }

                foreach (var link in expectedList)
                {
                    var foundLink =
                        log.DocumentLinks.Find(l => l.Title.Equals(link.Title) && l.Url.Equals(link.Url));

                    if (foundLink == null)
                    {
                        return false;
                    }
                }

                return true;
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write(expectedList.ToString());
            }
        }


        private static LogDefinition CreateLogDefinition(bool inspectionFollowUp, bool processControlFollowUp,
            bool operationsFollowUp, bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp)
        {
            var logDefinition = LogDefinitionFixture.CreateLogDefinition();
            logDefinition.InspectionFollowUp = inspectionFollowUp;
            logDefinition.ProcessControlFollowUp = processControlFollowUp;
            logDefinition.OperationsFollowUp = operationsFollowUp;
            logDefinition.SupervisionFollowUp = supervisionFollowUp;
            logDefinition.EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            logDefinition.OtherFollowUp = otherFollowUp;
            return logDefinition;
        }

        private static Matcher HasProperty(string propertyName, object expectedValue)
        {
            return new OltPropertyMatcher<Log>(propertyName, expectedValue);
        }
    }
}