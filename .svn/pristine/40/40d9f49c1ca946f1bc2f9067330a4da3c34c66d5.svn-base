using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class LogServiceTest
    {
        private LogService service;
        private ILogDao mockLogDao;
        
        private Log log;
        private IShiftHandoverQuestionnaireAssociationDao mockShiftHandoverAssocDao;
        private ILogDTODao mockLogDtoDao;
        private ILogReadDao mockLogReadDao;
        private ISiteConfigurationDao mockSiteConfigurationDao;
        private ILogGuidelineDao mockLogGuidelineDao;
        private IFunctionalLocationDao mockFunctionalLocationDao;
        private IFunctionalLocationInfoDao mockFunctionalLocationInfoDao;
        private ILogCustomFieldEntryDao mockCustomFieldEntryDao;

        private ITimeService mockTimeService;
        private EventQueueTestWrapper eventQueue;
        private IEditHistoryService mockEditHistoryService;
        private IPlantHistorianService mockPlantHistorianService;
        
        private User user;

        private const string QUERY_BY_ID = "QueryById";
        private const string REMOVE = "Remove";
        private const string UPDATE = "Update";
        private const string INSERT = "Insert";

        [SetUp]
        public void SetUp()
        {
            mockLogDao = MockRepository.GenerateStub<ILogDao>();
            mockLogDtoDao = MockRepository.GenerateStub<ILogDTODao>();
            mockLogReadDao = MockRepository.GenerateStub<ILogReadDao>();
            mockSiteConfigurationDao = MockRepository.GenerateStub<ISiteConfigurationDao>();
            mockLogGuidelineDao = MockRepository.GenerateStub<ILogGuidelineDao>();
            mockFunctionalLocationDao = MockRepository.GenerateStub<IFunctionalLocationDao>();
            mockFunctionalLocationInfoDao = MockRepository.GenerateStub<IFunctionalLocationInfoDao>();
            mockCustomFieldEntryDao = MockRepository.GenerateStub<ILogCustomFieldEntryDao>();

            mockTimeService = MockRepository.GenerateStub<ITimeService>();
            mockEditHistoryService = MockRepository.GenerateStub<IEditHistoryService>();
            mockPlantHistorianService = MockRepository.GenerateStub<IPlantHistorianService>();

            mockShiftHandoverAssocDao = MockRepository.GenerateStub<IShiftHandoverQuestionnaireAssociationDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockLogDao);
            DaoRegistry.RegisterDaoFor(mockLogDtoDao);
            DaoRegistry.RegisterDaoFor(mockLogReadDao);
            DaoRegistry.RegisterDaoFor(mockSiteConfigurationDao);
            DaoRegistry.RegisterDaoFor(mockLogGuidelineDao);
            DaoRegistry.RegisterDaoFor(mockFunctionalLocationDao);
            DaoRegistry.RegisterDaoFor(mockFunctionalLocationInfoDao);
            DaoRegistry.RegisterDaoFor(mockCustomFieldEntryDao);
            DaoRegistry.RegisterDaoFor(mockShiftHandoverAssocDao);

            service = new LogService(mockTimeService, mockEditHistoryService, mockPlantHistorianService);

            log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            user = UserFixture.CreateOperator();
            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        // This is an example of the stupidest test in the world.
        // No dustin, the stupidest test in the workd is:  object myobj = new object();  Assert.That(myobj, Is.Not.Null);
        public void ShouldGetALogById()
        {
            mockLogDao.Expect(mock => mock.QueryById(1)).Return(log);
            service.QueryById(1);
        }
       
        [Ignore] [Test]
        public void ShouldCallUpdateLog()
        {
            mockTimeService.Stub(m => m.GetTime(null)).IgnoreArguments().Return(new DateTime());

            mockLogDao.Expect(m => m.Update(log));
            service.Update(log);
            
            mockLogDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldCallInsertLog()
        {
            mockLogDao.Expect(mock => mock.Insert(log)).Return(log);
            service.Insert(log);
            
            mockLogDao.VerifyAllExpectations();
        }


        [Ignore] [Test]
        public void ShouldCallRemoveLog()
        {
            mockLogDao.Expect(m => m.Remove(log));
            service.Remove(log);
            mockLogDao.VerifyAllExpectations();
        }


        [Ignore] [Test]
        public void ShouldCallInsert()
        {
            //Should add some data to Log
            Log newLog = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            mockLogDao.Expect(mock => mock.Insert(newLog)).Return(newLog);

            service.Insert(newLog);

            mockLogDao.VerifyAllExpectations();
        }
        
        [Test, ExpectedException(typeof (ApplicationException))]
        public void GetLogsForDisplayShouldThrowExceptionIfFlocSetIsNull()
        {
            service.GetLogsForDisplay(null, new DateRange(new Date(Clock.Now), null), new List<long> { 1, 2 });
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void GetLogsForDisplayShouldThrowExceptionIfFlocListIsEmpty()
        {            
            service.GetLogsForDisplay(new RootFlocSet(new List<FunctionalLocation>()), new DateRange(new Date(Clock.Now), null), new List<long> { 1, 2 });
        }
        
        [Ignore] [Test]
        public void QueryDTOsByFunctionalLocationsAndDateRangeShouldReturnExepectedDtos()
        {
            List<FunctionalLocation> flocs = FunctionalLocationFixture.GetListWith3Units();
            RootFlocSet flocSet = new RootFlocSet(flocs);

            Date now = new Date(DateTimeFixture.DateTimeNow);
            Range<Date> range = new Range<Date>(now, now);

            mockLogDtoDao.Expect(m => m.QueryByFunctionalLocations(flocSet, new DateRange(range), null));

            service.GetLogsForDisplay(flocSet, new DateRange(range), null);
                        
            mockLogDtoDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void WhenInsertingShouldTakeAnEditHistorySnapshot()
        {
            mockEditHistoryService.Expect(m => m.TakeSnapshot(log));
            service.Insert(log);
            mockEditHistoryService.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void WhenUpdatingShouldSetLastModifiedDateToCurrentTime()
        {
            User lastModifiedBy = UserFixture.CreateOperator();
            log.LastModifiedBy = lastModifiedBy;

            var currentTime = new DateTime(2006, 1, 13);
            mockTimeService.Expect(mock => mock.GetTime(null)).IgnoreArguments().Return(currentTime);
            mockLogDao.Expect(mock => mock.Update(Arg<Log>.Matches(l => l.LastModifiedDate == currentTime)));
            
            service.Update(log);
            mockLogDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void WhenUpdatingShouldTakeAnEditHistorySnapshot()
        {
            mockTimeService.Stub(s => s.GetTime(null)).IgnoreArguments().Return(new DateTime());

            mockEditHistoryService.Expect(s => s.TakeSnapshot(log));
            service.Update(log);
            mockEditHistoryService.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldMarkAsReadIfNotAlreadyRead()
        {
            log = LogFixture.CreateLogItemGoofySarnia();

            mockLogReadDao.Expect(mock => mock.UserMarkedLogAsRead(log.IdValue, user.IdValue)).Return(null);
            DateTime now = DateTimeFixture.DateTimeNow;
            LogRead logRead = new LogRead(log.IdValue, user.IdValue, now);
            mockLogReadDao.Expect(m => m.Insert(logRead)).Return(logRead);
            
            service.MarkAsRead(log.IdValue, user.IdValue, now);
            
            mockLogReadDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldNotMarkAsReadIfAlreadyRead()
        {            
            log = LogFixture.CreateLogItemGoofySarnia();
            DateTime now = DateTimeFixture.DateTimeNow;
            LogRead logRead = new LogRead(log.IdValue, user.IdValue, now);

            mockLogReadDao.Expect(mock => mock.UserMarkedLogAsRead(log.IdValue, user.IdValue)).Return(logRead);
            mockLogReadDao.AssertWasNotCalled(m => m.Insert(Arg<LogRead>.Is.Anything));
            
            service.MarkAsRead(log.IdValue, user.IdValue, now);
            mockLogReadDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetUsersThatMarkedLogAsRead()
        {
            log.Id = 42;
            mockLogReadDao.Expect(m => m.UsersThatMarkedLogAsRead(log.IdValue));
            service.UsersThatMarkedLogAsRead(log.IdValue);
            mockLogReadDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldQueryOperatingEngineerDTOsUsingADateRangeThatHasNoEndDate()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            RootFlocSet rootFlocSet = new RootFlocSet(floc);

            Range<Date> range = new Range<Date>(new Date(2012, 5, 22), null);
            mockLogDtoDao.Expect(m => m.QueryOpEngLogsByFunctionalLocations(rootFlocSet, new DateRange(range).SqlFriendlyStart, new DateRange(range).SqlFriendlyEnd, null));
            service.QueryOperatingEngineerDTOsByFunctionalLocationsAndDateRange(rootFlocSet, range, null);
            mockLogDtoDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUpdateParentLogWhenLogIsAReplyToAnother()
        {
            log = LogFixture.CreateLog(false);
            log.ReplyToLogId = 1000;

            Log parentLog = LogFixture.CreateLog(false);
            parentLog.Id = log.ReplyToLogId;
            parentLog.HasChildren = false;

            mockLogDao.Expect(m => m.QueryById(log.ReplyToLogId.Value)).Return(parentLog);
            mockLogDao.Expect(m => m.Update(Arg<Log>.Matches(l => l.HasChildren)));
            service.Insert(log);

            mockLogDao.VerifyAllExpectations();
        }
    }
}