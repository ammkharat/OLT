using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Integration.Handlers.Fixtures;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    [TestFixture]
    public class NotificationAdapterTest
    {
        private NotificationAdapter adapter;
        private FunctionalLocation functionalLocation;
        private IActionItemDefinitionService mockActionItemDefinitionService;
        private IBusinessCategoryService mockBusinessCategoryService;
        private IFunctionalLocationService mockFunctionalLocationService;
        private ISAPNotificationService mockSapNoficationService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private ISiteService mockSiteService;
        private ITimeService mockTimeService;
        private IUserService mockUserService;
        private Mockery mocks;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockActionItemDefinitionService = mocks.NewMock<IActionItemDefinitionService>();
            mockSapNoficationService = mocks.NewMock<ISAPNotificationService>();
            mockFunctionalLocationService = mocks.NewMock<IFunctionalLocationService>();
            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();
            mockSiteService = mocks.NewMock<ISiteService>();
            mockUserService = mocks.NewMock<IUserService>();
            mockTimeService = mocks.NewMock<ITimeService>();
            mockBusinessCategoryService = mocks.NewMock<IBusinessCategoryService>();

            functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            Stub.On(mockBusinessCategoryService)
                .Method("GetDefaultSAPNotificationCategory")
                .Will(Return.Value(BusinessCategoryFixture.GetEnvironmentalSafetyCategory()));
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingIntegrateNotificationForActivityReportShouldCallInsertValidNotification()
        {
            var activityReport = NotificationDetailFixture.GetActivityReportWithDate2005Feb4_60345PM();
            var notificationDetailsArray = NotificationDetailFixture.GetArrayFromItems(activityReport);

            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            var site = SiteFixture.Sarnia();
            Expect.Once.On(mockSiteService)
                .Method("QueryByPlantId")
                .With(site.Plants[0].Id.ToString())
                .Will(Return.Value(site));

            var description = NotificationAdapter.BuildNotificationDescription(activityReport);

            var sapNotification = new SAPNotification(functionalLocation,
                description, activityReport.NotificationType,
                activityReport.ShortText, activityReport.LongText,
                activityReport.IncidentID,
                new DateTime(2005, 2, 4, 20, 3, 45),
                activityReport.NotificationNumber, false);

            const SAPNotification existingNotification = null;
            Expect.Once.On(mockSapNoficationService).Method("QueryByNotificationNumber")
                .With(notificationDetailsArray[0].NotificationNumber)
                .Will(Return.Value(existingNotification));

            Expect.Once.On(mockSapNoficationService).Method("Insert").With(sapNotification);
            Expect.Once.On(mockFunctionalLocationService).Method("QueryByFullHierarchy")
                .Will(Return.Value(functionalLocation));

            adapter.IntegrateNotificationObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingIntegrateNotificationForManagementChangeOneTaskShouldCallInsertValidActionItemDefinition()
        {
            try
            {
                var now = new DateTime(2006, 1, 1, 1, 0, 0);
                Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(now));
                var notificationDetail =
                    NotificationDetailFixture.GetManagementChangeWithOneTask2006_3_6_09_91456To2006_3_9_091500();
                var notificationDetails =
                    NotificationDetailFixture.GetArrayFromItems(notificationDetail);
                adapter = new NotificationAdapter(
                    notificationDetails,
                    mockSiteService,
                    mockFunctionalLocationService,
                    mockActionItemDefinitionService,
                    mockSapNoficationService,
                    mockTimeService,
                    mockSiteConfigurationService,
                    mockBusinessCategoryService,
                    mockUserService);
                var name = string.Format("ID: {0} - ({1})", notificationDetail.NotificationNumber, 1);

                var site = SiteFixture.Sarnia();

                Expect.Once.On(mockActionItemDefinitionService)
                    .Method("GetCountOfSAPSourced")
                    .With(name, site.IdValue)
                    .Will(
                        Return.Value(0));

                var description = "Management of Change SAP Notification Created. " +
                                  NotificationAdapter.BuildNotificationDescription(notificationDetail) +
                                  "Task Details: " +
                                  NotificationAdapter.BuildNotificationTaskDescription(notificationDetail.Tasks[0]);
                //this function tested elsewhere


                Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(site.Plants[0].Id.ToString()).Will(
                    Return.Value(site));

                var startDateTime = new DateTime(2006, 3, 6, 9, 14, 56);
                var endDateTime = new DateTime(2006, 3, 9, 9, 15, 00);
                ISchedule schedule =
                    new SingleSchedule(new Date(startDateTime), new Time(startDateTime), new Time(endDateTime), site);
                var flocList = new List<FunctionalLocation>
                {
                    functionalLocation
                }
                    ;
                var sapUser = UserFixture.CreateSAPUser();

                var category = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();

                var actionItemDefinition = new ActionItemDefinition(
                    name,
                    category,
                    ActionItemDefinitionStatus.Pending,
                    schedule,
                    description,
                    DataSource.SAP,
                    true,
                    false,
                    false,
                    sapUser,
                    now,
                    sapUser,
                    now,
                    flocList,
                    new List<TargetDefinitionDTO>(),
                    new List<DocumentLink>(),
                    OperationalMode.Normal,
                    null,
                    true, null, null,null,false,false,false,null);     //ayman visibility groups    //ayman custom fields DMND0010030

                Expect.Once.On(mockUserService).Method("GetSAPUser").Will(Return.Value(sapUser));

                var operation = new SapWorkOrderOperation(null,
                    notificationDetail.NotificationNumber,
                    "1",
                    null,
                    SapOperationType.ActionItemDefinition);

                Expect.Once.On(mockActionItemDefinitionService)
                    .Method("Insert");

                Expect.Once.On(mockFunctionalLocationService)
                    .Method("QueryByFullHierarchy")
                    .Will(Return.Value(functionalLocation));

                var siteConfiguration =
                    SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(site);

                Stub.On(mockSiteConfigurationService)
                    .Method("QueryBySiteId")
                    .With(site.IdValue)
                    .Will(Return.Value(siteConfiguration));

                adapter.IntegrateNotificationObjectToOperatorLogTool();

                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            finally
            {
            }
        }

        [Test]
        public void CallingIntegrateNotificationWithActionManagementNoTasksShouldCallInsertNotification()
        {
            var actionManagementWithNoTask = NotificationDetailFixture.GetActionManagementWithNoTask();
            const int existingAIDNameCount = 0;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithNoTask, existingAIDNameCount);
        }

        [Test]
        public void CallingIntegrateNotificationWithActionManagementWithOneTaskShouldCallInsertActionItemDefinition()
        {
            var actionManagementWithOneTask = NotificationDetailFixture.GetActionManagementWithOneTask();

            const int existingAIDNameCount = 0;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithOneTask, existingAIDNameCount);
        }

        [Test]
        public void CallingIntegrateNotificationWithActionManagementWithOneTaskShouldCallUpdateActionItemDefinition()
        {
            var actionManagementWithOneTask = NotificationDetailFixture.GetActionManagementWithOneTask();
            const int existingAIDNameCount = 1;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithOneTask, existingAIDNameCount);
        }

        [Test]
        public void
            CallingIntegrateNotificationWithActionManagementWithTWOTasksShouldCallInsertActionItemDefinitionTwice()
        {
            var actionManagementWithTwoTasks =
                NotificationDetailFixture.GetActionManagementWithTwoTasks();
            const int existingAIDNameCount = 1;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithTwoTasks, existingAIDNameCount);
        }

        [Test]
        public void CallingIntegrateNotificationWithActivityReportShouldCallInsertNotification()
        {
            var activityReport = NotificationDetailFixture.GetActivityReport();
            const SAPNotification existingNotification = null;
            Incoming_WR_EI_AR_Notification_Test(activityReport, existingNotification);
        }

        [Test]
        public void CallingIntegrateNotificationWithEmergencyIncidentShouldCallInsertNotification()
        {
            var emergencyIncident = NotificationDetailFixture.GetEmergencyIncident();
            const SAPNotification existingNotification = null;
            Incoming_WR_EI_AR_Notification_Test(emergencyIncident, existingNotification);
        }

        [Test]
        public void CallingIntegrateNotificationWithManagementChangeWithLevelOneFlocShouldBeIgnored()
        {
            var floc = FunctionalLocationFixture.GetAny_Division();

            var managementChangeWithOneTask = NotificationDetailFixture.GetManagementChangeWithOneTask();
            managementChangeWithOneTask.FunctionalLocation = floc.FullHierarchy;

            const int existingAIDNameCount = 0;
            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(SiteFixture.Sarnia());
            var notificationDetailsArray =
                NotificationDetailFixture.GetArrayFromItems(managementChangeWithOneTask);

            //
            //  It is not really important if the site matches with the one
            //  in existingNotification for this test.
            //
            var site = SiteFixture.Sarnia();
            IntegrateNotificationObjectToOLTTestCommonExpectation(site, floc);

            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            if (managementChangeWithOneTask.NotificationType == SAPNotificationType.ActionManagement ||
                managementChangeWithOneTask.NotificationType == SAPNotificationType.ManagementChange)
            {
                Stub.On(mockTimeService)
                    .Method("GetTime")
                    .WithAnyArguments()
                    .Will(Return.Value(DateTimeFixture.DateTimeNow));
                Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(site));

                if (managementChangeWithOneTask.Tasks == null || managementChangeWithOneTask.Tasks.Length == 0)
                {
                    if (managementChangeWithOneTask.NotificationType == SAPNotificationType.ActionManagement)
                        Expect.Once.On(mockSapNoficationService).Method("Insert");
                }
                else
                {
                    //
                    //  The following will for each task in incompingNotificationDetails.Tasks.Count
                    //

                    var expectedCategory = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();
                    var expectedDataSource = DataSource.SAP;

                    if (existingAIDNameCount > 0)
                    {
                        // NOTE: We should never receive an update message for SAP Notifications.
                    }
                    ActionItemDefinitionStatus expectedStatus;
                    bool expectedRequiredApproval;
                    if (
                        ShouldAutoApproveNotification(currentSiteConfiguration,
                            managementChangeWithOneTask.NotificationType))
                    {
                        expectedStatus = ActionItemDefinitionStatus.Approved;
                        expectedRequiredApproval = false;
                    }
                    else
                    {
                        expectedStatus = ActionItemDefinitionStatus.Pending;
                        expectedRequiredApproval = true;
                    }

                    const string expectedMethodName = "Insert";

                    var expectedAIDProperties =
                        OltPropertyMatcher<ActionItemDefinition>.HasProperties(
                            new OltMatcherPropertyValuePair("Category", expectedCategory),
                            new OltMatcherPropertyValuePair("Status", expectedStatus),
                            new OltMatcherPropertyValuePair("Source", expectedDataSource),
                            new OltMatcherPropertyValuePair("RequiresApproval", expectedRequiredApproval));

                    var expectedSAPWorkOrderOperationProperties =
                        OltPropertyMatcher<SapWorkOrderOperation>.HasProperties(
                            new OltMatcherPropertyValuePair("WorkOrderNumber",
                                managementChangeWithOneTask.NotificationNumber),
                            new OltMatcherPropertyValuePair("SapOperationType",
                                SapOperationType.ActionItemDefinition));

                    Expect.Never.On(mockActionItemDefinitionService).Method(expectedMethodName);

                    Expect.Never.On(mockSapNoficationService).Method("Insert");
                }

                adapter.IntegrateNotificationObjectToOperatorLogTool();
            }
            else
            {
                Assert.Fail("This is for testing Incoming ActionItemManagement or ManagementChange Notification only.");
            }
        }

        [Test]
        public void CallingIntegrateNotificationWithManagementChangeWithLevelTwoFlocShouldBeIgnored()
        {
            var floc = FunctionalLocationFixture.GetAny_Section();

            var managementChangeWithOneTask = NotificationDetailFixture.GetManagementChangeWithOneTask();
            managementChangeWithOneTask.FunctionalLocation = floc.FullHierarchy;

            const int existingAIDNameCount = 0;
            var currentSiteConfiguration =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(SiteFixture.Sarnia());
            var notificationDetailsArray =
                NotificationDetailFixture.GetArrayFromItems(managementChangeWithOneTask);

            //
            //  It is not really important if the site matches with the one
            //  in existingNotification for this test.
            //
            var site = SiteFixture.Sarnia();
            IntegrateNotificationObjectToOLTTestCommonExpectation(site, floc);

            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            if (managementChangeWithOneTask.NotificationType == SAPNotificationType.ActionManagement ||
                managementChangeWithOneTask.NotificationType == SAPNotificationType.ManagementChange)
            {
                Stub.On(mockTimeService)
                    .Method("GetTime")
                    .WithAnyArguments()
                    .Will(Return.Value(DateTimeFixture.DateTimeNow));
                Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(site));

                if (managementChangeWithOneTask.Tasks == null || managementChangeWithOneTask.Tasks.Length == 0)
                {
                    if (managementChangeWithOneTask.NotificationType == SAPNotificationType.ActionManagement)
                        Expect.Once.On(mockSapNoficationService).Method("Insert");
                }
                else
                {
                    //
                    //  The following will for each task in incompingNotificationDetails.Tasks.Count
                    //
//                    Expect.AtLeastOnce.On(mockSiteConfigurationService).Method("QueryBySiteId")
//                        .With(site.Id.Value).Will(Return.Value(currentSiteConfiguration));

                    var expectedCategory = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();
                    var expectedDataSource = DataSource.SAP;

                    if (existingAIDNameCount > 0)
                    {
                        // NOTE: We should never receive an update message for SAP Notifications.
                    }
                    ActionItemDefinitionStatus expectedStatus;
                    bool expectedRequiredApproval;
                    if (
                        ShouldAutoApproveNotification(currentSiteConfiguration,
                            managementChangeWithOneTask.NotificationType))
                    {
                        expectedStatus = ActionItemDefinitionStatus.Approved;
                        expectedRequiredApproval = false;
                    }
                    else
                    {
                        expectedStatus = ActionItemDefinitionStatus.Pending;
                        expectedRequiredApproval = true;
                    }

                    const string expectedMethodName = "Insert";

                    var expectedAIDProperties =
                        OltPropertyMatcher<ActionItemDefinition>.HasProperties(
                            new OltMatcherPropertyValuePair("Category", expectedCategory),
                            new OltMatcherPropertyValuePair("Status", expectedStatus),
                            new OltMatcherPropertyValuePair("Source", expectedDataSource),
                            new OltMatcherPropertyValuePair("RequiresApproval", expectedRequiredApproval));

                    var expectedSAPWorkOrderOperationProperties =
                        OltPropertyMatcher<SapWorkOrderOperation>.HasProperties(
                            new OltMatcherPropertyValuePair("WorkOrderNumber",
                                managementChangeWithOneTask.NotificationNumber),
                            new OltMatcherPropertyValuePair("SapOperationType",
                                SapOperationType.ActionItemDefinition));

                    Expect.Never.On(mockActionItemDefinitionService).Method(expectedMethodName);

                    Expect.Never.On(mockSapNoficationService).Method("Insert");
                }

                adapter.IntegrateNotificationObjectToOperatorLogTool();
            }
            else
            {
                Assert.Fail("This is for testing Incoming ActionItemManagement or ManagementChange Notification only.");
            }
        }

        [Test]
        public void CallingIntegrateNotificationWithManagementChangeWithOneTaskShouldCallInsertActionItemDefinition()
        {
            var managementChangeWithOneTask = NotificationDetailFixture.GetManagementChangeWithOneTask();
            const int existingAIDNameCount = 0;
            Incoming_AM_MC_SAP_NotificationTest(managementChangeWithOneTask, existingAIDNameCount);
        }

        [Test]
        public void CallingIntegrateNotificationWithWorkRequestShouldCallInsertNotification()
        {
            var workRequestNotificationDetails = NotificationDetailFixture.GetWorkRequest();
            const SAPNotification existingNotification = null;
            Incoming_WR_EI_AR_Notification_Test(workRequestNotificationDetails, existingNotification);
        }

        [Test]
        public void
            CallingIntegrateNotificationWithWorkRequestShouldNotCallInsertNotificationBecauseNotificationNumberAlreadyExistsInDatabase
            ()
        {
            var workRequestNotificationDetails = NotificationDetailFixture.GetWorkRequest();
            var existingNotification = SAPNotificationFixture.GetAWorkRequestFortMcMurrayNotification();
            Incoming_WR_EI_AR_Notification_Test(workRequestNotificationDetails, existingNotification);
        }

        [Test]
        public void CallingMultipleNotificationsShouldCallAppropriateInsertNotification()
        {
            var notificationDetailsArray = NotificationDetailFixture.GetArrayFromItems
                (
                    NotificationDetailFixture.GetActivityReport(),
                    NotificationDetailFixture.GetEmergencyIncident()
                );
            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            const SAPNotification existingNotification = null;
            Expect.Exactly(2).On(mockSapNoficationService).Method("QueryByNotificationNumber")
                .With(notificationDetailsArray[0].NotificationNumber)
                .Will(Return.Value(existingNotification));

            Expect.Exactly(2).On(mockSapNoficationService).Method("Insert");
            Expect.Exactly(2).On(mockFunctionalLocationService).Method("QueryByFullHierarchy")
                .Will(Return.Value(functionalLocation));

            var site = SiteFixture.Sarnia();
            Expect.Exactly(2)
                .On(mockSiteService)
                .Method("QueryByPlantId")
                .With(site.Plants[0].Id.ToString())
                .Will(Return.Value(site));

            adapter.IntegrateNotificationObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CreateActionItemForNotificationShouldCreateActionItem()
        {
            try
            {
                var now = new DateTime(2006, 1, 1, 1, 0, 0);
                Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(now));
                Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(SiteFixture.Sarnia()));

                var notificationDetail =
                    NotificationDetailFixture.GetManagementChangeWithOneTask2006_3_6_09_91456To2006_3_9_091500();
                var notificationDetailsArray =
                    NotificationDetailFixture.GetArrayFromItems(notificationDetail);

                adapter = new NotificationAdapter(
                    notificationDetailsArray,
                    mockSiteService,
                    mockFunctionalLocationService,
                    mockActionItemDefinitionService,
                    mockSapNoficationService,
                    mockTimeService,
                    mockSiteConfigurationService,
                    mockBusinessCategoryService,
                    mockUserService);

                var expectedAIDName = string.Format("ID: {0} - ({1})", notificationDetail.NotificationNumber, 1);

                var expectedStartDateTime = new DateTime(2006, 3, 6, 9, 14, 56);
                var expectedEndDateTime = new DateTime(2006, 3, 9, 9, 15, 00);

                ISchedule expectedSchedule = new SingleSchedule
                    (
                    new Date(expectedStartDateTime),
                    new Time(expectedStartDateTime),
                    new Time(expectedEndDateTime),
                    SiteFixture.Sarnia()
                    );

                var expectedFLOCList =
                    new List<FunctionalLocation> {functionalLocation};

                var sapUser = UserFixture.CreateSAPUser();
                Expect.Once.On(mockUserService).Method("GetSAPUser").Will(Return.Value(sapUser));

                var expectedDescription = "Management of Change SAP Notification Created. " +
                                          NotificationAdapter.BuildNotificationDescription(notificationDetail) +
                                          "Task Details: " +
                                          NotificationAdapter.BuildNotificationTaskDescription(
                                              notificationDetail.Tasks[0]);

                var category = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();

                var expectedAID = new ActionItemDefinition
                    (
                    expectedAIDName,
                    category,
                    ActionItemDefinitionStatus.Pending,
                    expectedSchedule,
                    expectedDescription,
                    DataSource.SAP,
                    true,
                    false,
                    false,
                    sapUser,
                    now,
                    sapUser,
                    now,
                    expectedFLOCList,
                    new List<TargetDefinitionDTO>(),
                    new List<DocumentLink>(),
                    OperationalMode.Normal,
                    null,
                    true, null, null,null,false,false,false,null);         //ayman visibility groups     //ayman custom fields DMND0010030

                const string returnedDescription = "Management of Change SAP Notification Created. ";
                var actualAID = adapter.CreateActionItemForNotification
                    (
                        functionalLocation,
                        SiteFixture.Sarnia(),
                        notificationDetail,
                        notificationDetail.Tasks[0],
                        returnedDescription,
                        1
                    );

                Assert.That(expectedAID, Is.EqualTo(actualAID).Using(new ReflectiveEquals<ActionItemDefinition>()));
                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            finally
            {
            }
        }

        [Test]
        public void SendToDatabaseShouldCallInsertIfActionItemDefinitionDoesNotAlreadyExist()
        {
            var actionManagementWithOneTask = NotificationDetailFixture.GetActionManagementWithOneTask();
            const int existingAIDNameCount = 0;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithOneTask, existingAIDNameCount);
        }

        [Test]
        public void SendToDatabaseShouldCallUpdateIfActionItemDefinitionAlreadyExists()
        {
            var actionManagementWithOneTask = NotificationDetailFixture.GetActionManagementWithOneTask();
            const int existingAIDNameCount = 1;
            Incoming_AM_MC_SAP_NotificationTest(actionManagementWithOneTask, existingAIDNameCount);
        }

        private void IntegrateNotificationObjectToOLTTestCommonExpectation(Site site, FunctionalLocation flocList)
        {
            Expect.Once.On(mockSiteService)
                .Method("QueryByPlantId")
                .With(site.Plants[0].Id.ToString())
                .Will(Return.Value(site));
            Expect.Once.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").Will(Return.Value(flocList));
        }

        private void Incoming_WR_EI_AR_Notification_Test(NotificationDetails incomingNotificationDetails,
            SAPNotification existingNotification)
        {
            var notificationDetailsArray =
                NotificationDetailFixture.GetArrayFromItems(incomingNotificationDetails);
            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            if (incomingNotificationDetails.NotificationType == SAPNotificationType.WorkRequest ||
                incomingNotificationDetails.NotificationType == SAPNotificationType.EmergencyIncident ||
                incomingNotificationDetails.NotificationType == SAPNotificationType.ActivityReport)
            {
                //
                //  It is not really important if the site matches with the one
                //  in existingNotification for this test.
                //
                var site = SiteFixture.Sarnia();
                IntegrateNotificationObjectToOLTTestCommonExpectation(site, functionalLocation);

                Expect.Once.On(mockSapNoficationService).Method("QueryByNotificationNumber")
                    .With(incomingNotificationDetails.NotificationNumber)
                    .Will(Return.Value(existingNotification));

                if (existingNotification != null)
                    Expect.Never.On(mockSapNoficationService).Method("Insert");
                else
                    Expect.Once.On(mockSapNoficationService).Method("Insert");

                adapter.IntegrateNotificationObjectToOperatorLogTool();
                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            else
            {
                Assert.Fail("It is only for testing WorkRequest, EmergencyIncident, ActivityReport");
            }
        }

        private void Incoming_AM_MC_SAP_NotificationTest(NotificationDetails incomingNotificationDetails,
            int existingAIDNameCount)
        {
            var site = SiteFixture.Sarnia();
            var doNotAutoApproveSAPAID =
                SiteConfigurationFixture.CreateDoNotAutoApproveSAPActionItemDefinition(site);
            var notificationDetailsArray =
                NotificationDetailFixture.GetArrayFromItems(incomingNotificationDetails);

            //
            //  It is not really important if the site matches with the one
            //  in existingNotification for this test.
            //
            IntegrateNotificationObjectToOLTTestCommonExpectation(site, functionalLocation);

            adapter = new NotificationAdapter(
                notificationDetailsArray,
                mockSiteService,
                mockFunctionalLocationService,
                mockActionItemDefinitionService,
                mockSapNoficationService,
                mockTimeService,
                mockSiteConfigurationService,
                mockBusinessCategoryService,
                mockUserService);

            if (incomingNotificationDetails.NotificationType == SAPNotificationType.ActionManagement ||
                incomingNotificationDetails.NotificationType == SAPNotificationType.ManagementChange)
            {
                Stub.On(mockTimeService)
                    .Method("GetTime")
                    .WithAnyArguments()
                    .Will(Return.Value(DateTimeFixture.DateTimeNow));
                Stub.On(mockSiteService).Method("QueryById").WithAnyArguments().Will(Return.Value(site));

                if (incomingNotificationDetails.Tasks == null || incomingNotificationDetails.Tasks.Length == 0)
                {
                    if (incomingNotificationDetails.NotificationType == SAPNotificationType.ActionManagement)
                    {
                        Expect.Once.On(mockSapNoficationService).Method("QueryByNotificationNumber")
                            .With(notificationDetailsArray[0].NotificationNumber)
                            .Will(Return.Value(null));

                        Expect.Once.On(mockSapNoficationService).Method("Insert");
                    }
                }
                else
                {
                    //
                    //  The following will for each task in incompingNotificationDetails.Tasks.Count
                    //
                    Stub.On(mockSiteConfigurationService).Method("QueryBySiteId")
                        .With(site.IdValue).Will(Return.Value(doNotAutoApproveSAPAID));

                    var expectedCategory = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();
                    var expectedDataSource = DataSource.SAP;

                    if (existingAIDNameCount > 0)
                    {
                        // NOTE: We should never receive an update message for SAP Notifications.
                    }
                    else
                    {
                        ActionItemDefinitionStatus expectedStatus;
                        bool expectedRequiredApproval;
                        if (
                            ShouldAutoApproveNotification(doNotAutoApproveSAPAID,
                                incomingNotificationDetails.NotificationType))
                        {
                            expectedStatus = ActionItemDefinitionStatus.Approved;
                            expectedRequiredApproval = false;
                        }
                        else
                        {
                            expectedStatus = ActionItemDefinitionStatus.Pending;
                            expectedRequiredApproval = true;
                        }

                        const string expectedMethodName = "Insert";

                        var expectedAIDProperties =
                            OltPropertyMatcher<ActionItemDefinition>.HasProperties(
                                new OltMatcherPropertyValuePair("Category", expectedCategory),
                                new OltMatcherPropertyValuePair("Status", expectedStatus),
                                new OltMatcherPropertyValuePair("Source", expectedDataSource),
                                new OltMatcherPropertyValuePair("RequiresApproval", expectedRequiredApproval));

                        var expectedSAPWorkOrderOperationProperties =
                            OltPropertyMatcher<SapWorkOrderOperation>.HasProperties(
                                new OltMatcherPropertyValuePair("WorkOrderNumber",
                                    incomingNotificationDetails.NotificationNumber),
                                new OltMatcherPropertyValuePair("SapOperationType",
                                    SapOperationType.ActionItemDefinition));

                        Expect.AtLeastOnce.On(mockActionItemDefinitionService).Method(expectedMethodName).With(
                            expectedAIDProperties, expectedSAPWorkOrderOperationProperties);
                    }

                    var sapUser = UserFixture.CreateSAPUser();
                    Expect.AtLeastOnce.On(mockUserService).Method("GetSAPUser").Will(Return.Value(sapUser));

                    Expect.Never.On(mockSapNoficationService).Method("Insert");

                    var name = string.Format("ID: {0} - ", incomingNotificationDetails.NotificationNumber);
                    Expect.AtLeastOnce.On(mockActionItemDefinitionService).Method("GetCountOfSAPSourced")
                        .With(
                            new AlwaysTrueMatcher(),
//                            Is.StringContaining(incomingNotificationDetails.NotificationNumber).IgnoreCase,
                            new AlwaysTrueMatcher())
//                        site.Id.Value)
                        .Will(Return.Value(existingAIDNameCount));
                }

                adapter.IntegrateNotificationObjectToOperatorLogTool();
            }
            else
            {
                Assert.Fail("This is for testing Incoming ActionItemManagement or ManagementChange Notification only.");
            }
        }

        private static bool ShouldAutoApproveNotification(SiteConfiguration siteConfiguration, string notificationType)
        {
            if (notificationType == SAPNotificationType.ActionManagement)
                return siteConfiguration.AutoApproveSAPAMActionItemDefinition;
            if (notificationType == SAPNotificationType.ManagementChange)
                return siteConfiguration.AutoApproveSAPMCActionItemDefinition;
            return false;
        }
    }
}