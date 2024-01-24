using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class SAPNotificationServiceTest
    {
        readonly Mockery mock = new Mockery();
        SAPNotificationService service;
        ISAPNotificationDao mockDao;
        ISAPNotificationDTODao mockDTODao;        

        ILogService mockLogService;
        IShiftPatternService mockShiftPatternService;
        private ITimeService mockTimeService;

        EventQueueTestWrapper eventQueue;
        
        [SetUp]
        public void SetUp()
        {
            mockDao = mock.NewMock<ISAPNotificationDao>();
            mockDTODao = mock.NewMock<ISAPNotificationDTODao>();
        
            mockLogService = mock.NewMock<ILogService>();
            mockShiftPatternService = mock.NewMock<IShiftPatternService>();
            mockTimeService = mock.NewMock<ITimeService>();

            eventQueue = new EventQueueTestWrapper();

            service = new SAPNotificationService(mockDao, mockDTODao, mockLogService, mockTimeService);
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
        }

        [Ignore] [Test]
        public void ShouldCallProcessNotificationAndCreateLogShouldCreateLogWithSAPNotification()
        {
            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            SAPNotification sapNotification = SAPNotificationFixture.GetAEmergencyIncidentFortMcMurrayNotification();
            SAPNotification processedSAPNotification = sapNotification;
            processedSAPNotification.Processed();

            Stub.On(mockShiftPatternService).Method("GetShiftBySiteAndDateTime");
            Expect.Once.On(mockLogService).Method("Insert")
                .With(new OltPropertyMatcher<Log>("LastModifiedBy", currentUser))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockDao).Method("UpdateByNotificationNumber").With(processedSAPNotification);

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));

            WorkAssignment workAssignment =
                WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            service.ProcessNotificationAndCreateLog(sapNotification, currentUser, ShiftPatternFixture.CreateDayShift(), false, RoleFixture.CreateSupervisorRole(), workAssignment);

            mock.VerifyAllExpectationsHaveBeenMet();

            Assert.AreEqual(1, eventQueue.EventQueue.Count);
            Assert.AreEqual(ApplicationEvent.SapNotificationProcess, eventQueue.EventQueue[0].ApplicationEvent);
            Assert.AreEqual(processedSAPNotification, eventQueue.EventQueue[0].DomainObject);
        }


        [Ignore] [Test]
        public void ShouldCallProcessNotificationAndCreatedLogShouldHaveAWorkAssignment()
        {
            User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            SAPNotification sapNotification = SAPNotificationFixture.GetAEmergencyIncidentFortMcMurrayNotification();
            SAPNotification processedSAPNotification = sapNotification;
            processedSAPNotification.Processed();

            WorkAssignment workAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
                       
            Stub.On(mockShiftPatternService).Method("GetShiftBySiteAndDateTime");

            Expect.Once.On(mockLogService).Method("Insert")
                .With(new OltPropertyMatcher<Log>("WorkAssignment", workAssignment)).Will(Return.Value(new List<NotifiedEvent>()));
            
            Expect.Once.On(mockDao).Method("UpdateByNotificationNumber").With(processedSAPNotification);

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            
            service.ProcessNotificationAndCreateLog(
                sapNotification, currentUser, ShiftPatternFixture.CreateDayShift(), 
                false, RoleFixture.CreateSupervisorRole(), workAssignment);

            mock.VerifyAllExpectationsHaveBeenMet();

            Assert.AreEqual(1, eventQueue.EventQueue.Count);
            Assert.AreEqual(ApplicationEvent.SapNotificationProcess, eventQueue.EventQueue[0].ApplicationEvent);
            Assert.AreEqual(processedSAPNotification, eventQueue.EventQueue[0].DomainObject);
        }

        [Ignore] [Test]
        public void ProcessNotificationAndCreateLogShouldUseTheShiftPatternParameterWhichIsUsuallyObtainedViaTheUserContextForTheCurrentUser()
        {
            try
            {
                User currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
                SAPNotification sapNotification = SAPNotificationFixture.GetAEmergencyIncidentFortMcMurrayNotification();
                ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
                Stub.On(mockDao).Method("UpdateByNotificationNumber");
                
                Expect.Once.On(mockLogService).Method("Insert")
                    .With(new OltPropertyMatcher<Log>("CreatedShiftPattern", shiftPattern))
                    .Will(Return.Value(new List<NotifiedEvent>()));

                Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(new DateTime(2006, 3, 20, 17, 30, 00)));

                service.ProcessNotificationAndCreateLog(sapNotification, currentUser, shiftPattern, false, RoleFixture.CreateSupervisorRole(), null);

                mock.VerifyAllExpectationsHaveBeenMet();
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}


