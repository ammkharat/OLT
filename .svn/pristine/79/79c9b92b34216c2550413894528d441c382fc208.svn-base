using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class LogDefinitionServiceTest
    {
        private Mockery mock;

        private LogDefinitionService logDefinitionService;
        private ILogDefinitionDao logDefinitionDao;
        private ILogDefinitionDTODao logDefinitionDTODao;
        private ILogDefinitionCustomFieldEntryDao customFieldEntryDao;
         
        private IEditHistoryService editHistoryService;
        private EventQueueTestWrapper eventQueue;
        private IScheduleService scheduleService;

        public const string REMOVE = "Remove";
        public const string INSERT = "Insert";

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            logDefinitionDao = mock.NewMock<ILogDefinitionDao>();
            logDefinitionDTODao = mock.NewMock<ILogDefinitionDTODao>();
            customFieldEntryDao = mock.NewMock<ILogDefinitionCustomFieldEntryDao>();
            editHistoryService = mock.NewMock<IEditHistoryService>();
            scheduleService = mock.NewMock<IScheduleService>();

            logDefinitionService = new LogDefinitionService(logDefinitionDao, logDefinitionDTODao, customFieldEntryDao, editHistoryService, scheduleService);
            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();            
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldCallInsertWithRecurringWeeklySchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);
            
            logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallInsertWithRecurringDailySchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);
            
            logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallInsertWithRecurringMonthlySchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);
            
            logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallInsertWithRecurringMinutesSchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule = RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25OnJan12000();
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);

            logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnTrueWithSuccessfulInsertOnBothLogDefintionAndSchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            schedule.Id = 1;
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Id = 1;
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);

            List<NotifiedEvent> notifiedEvents = logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            Assert.AreEqual(ApplicationEvent.LogDefinitionCreate, notifiedEvents[0].ApplicationEvent);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseWithNonSuccessfulInsertOnLogDefintion()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            schedule.Id = null;
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Id = 1;
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);

            List<NotifiedEvent> notifiedEvents = logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            Assert.IsEmpty(notifiedEvents);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseWithNonSuccessfulInsertOnSchdule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            schedule.Id = 1;
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Id = null;
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);

            List<NotifiedEvent> notifiedEvents = logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            Assert.IsEmpty(notifiedEvents);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseWithNonSuccessfulInsertOnBothLogDefintionAndSchedule()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            schedule.Id = null;
            LogDefinition logDefintion = LogDefinitionFixture.CreateLogDefinition(1);
            logDefintion.Id = null;
            logDefintion.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(INSERT).WithAnyArguments().Will(Return.Value(logDefintion));
            Stub.On(editHistoryService);

            List<NotifiedEvent> notifiedEvents = logDefinitionService.Insert(CreateLogDefintionWithSchedule(newLog, schedule));
            Assert.IsEmpty(notifiedEvents);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void InsertLogDefinitionShouldTakeSnapshotForHistoryAfterInsert()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition();

            using (mock.Ordered)
            {
                Stub.On(logDefinitionDao).Method("Insert").Will(Return.Value(logDefinition));
                Expect.Once.On(editHistoryService).Method("TakeSnapshot").With(logDefinition);
            }

            logDefinitionService.Insert(logDefinition);
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UnsuccessfulInsertShouldNotTakeSnapshotForHistory()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition();

            LogDefinition logDefinitionWithoutId = LogDefinitionFixture.CreateLogDefinition(null);
            Expect.Once.On(logDefinitionDao).Method("Insert").Will(Return.Value(logDefinitionWithoutId));
            Expect.Never.On(editHistoryService);

            logDefinitionService.Insert(logDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCancelARecurringLog()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(1);
            RecurringWeeklySchedule schedule = RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            logDefinition.Schedule = schedule;

            Expect.Once.On(logDefinitionDao).Method(REMOVE).With(Is.Same(logDefinition));
            Expect.Once.On(editHistoryService).Method("TakeSnapshot").With(new TypeMatcher(typeof(LogDefinition)));

            var cancelledSchedule = (RecurringWeeklySchedule)schedule.Clone();
            DateTime now = DateTimeFixture.DateTimeNow;
            cancelledSchedule.EndDate = now.ToDate();
            cancelledSchedule.EndTime = new Time(now);
            Expect.Once.On(scheduleService).Method("Update").With(cancelledSchedule);

            logDefinitionService.Cancel(logDefinition, now);
            mock.VerifyAllExpectationsHaveBeenMet();

            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(logDefinition, queueItems[0].DomainObject);
            Assert.AreEqual(ApplicationEvent.LogDefinitionCancelRecurring, queueItems[0].ApplicationEvent);
        }

        [Ignore] [Test]
        public void ShouldInsertEventToQueueWhenLogCancelled()
        {
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(1);
            logDefinition.Schedule = schedule;
            newLog.LogDefinition = logDefinition;

            RecurringWeeklySchedule cancelledSchedule = RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            DateTime now = DateTimeFixture.DateTimeNow;
            cancelledSchedule.EndDate = now.ToDate();
            cancelledSchedule.EndTime = new Time(now);
            Expect.Once.On(scheduleService).Method("Update").With(cancelledSchedule);

            Expect.Once.On(logDefinitionDao).Method(REMOVE).With(Is.Same(logDefinition));
            Expect.Once.On(editHistoryService).Method("TakeSnapshot").With(new TypeMatcher(typeof(LogDefinition)));

            logDefinitionService.Cancel(logDefinition, now);
            mock.VerifyAllExpectationsHaveBeenMet();

            List<EventQueueItem> queueItems = eventQueue.EventQueue;

            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(logDefinition, queueItems[0].DomainObject);
            Assert.AreEqual(ApplicationEvent.LogDefinitionCancelRecurring, queueItems[0].ApplicationEvent);
        }

        [Ignore] [Test]
        public void UpdateLogDefinitionShouldUpdateUsingDataAccess()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition();

            Expect.Once.On(logDefinitionDao).Method("Update").With(logDefinition);
            Stub.On(editHistoryService);

            logDefinitionService.Update(logDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateLogDefinitionShouldInsertEventIntoQueue()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition();

            Stub.On(logDefinitionDao);
            Stub.On(editHistoryService);

            logDefinitionService.Update(logDefinition);

            List<EventQueueItem> queueItems = eventQueue.EventQueue;

            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(logDefinition, queueItems[0].DomainObject);
            Assert.AreEqual(ApplicationEvent.LogDefinitionUpdate, queueItems[0].ApplicationEvent);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateLogDefinitionShouldTakeSnapshotForHistory()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition();

            Stub.On(logDefinitionDao);
            Expect.Once.On(editHistoryService).Method("TakeSnapshot").With(logDefinition);

            logDefinitionService.Update(logDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        private static LogDefinition CreateLogDefintionWithSchedule(Log log, ISchedule schedule)
        {           
            return new LogDefinition(schedule,
                                     log.FunctionalLocations,
                                     log.InspectionFollowUp,
                                     log.ProcessControlFollowUp,
                                     log.OperationsFollowUp,
                                     log.SupervisionFollowUp,
                                     log.EnvironmentalHealthSafetyFollowUp,
                                     log.OtherFollowUp,
                                     log.IsOperatingEngineerLog,
                                     log.CreatedByRole,
                                     log.LogDateTime,
                                     log.CreationUser,
                                     log.LastModifiedBy,
                                     log.LastModifiedDate,
                                     new List<DocumentLink>(),                                     
                                     log.RtfComments,
                                     log.PlainTextComments,
                                     LogType.Standard,
                                     log.WorkAssignment,
                                     true,
                                     null,
                                     null,
                                     true);
        }
    }
}
