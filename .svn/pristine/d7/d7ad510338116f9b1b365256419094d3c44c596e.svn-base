using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkPermitServiceTest
    {
        private IWorkPermitService service;
        private ILogService mockLogService;
        private IObjectLockingService mockObjectLockService;
        private IUserService mockUserService;
        private IEditHistoryService mockEditHistoryService;

        private IWorkPermitDao mockDao;
        private IWorkPermitDTODao mockDTODao;
        private IGasTestElementDao gasTestElementDao;
        private IGasTestElementInfoDao gasTestElementInfoDao;
        private ISapWorkOrderOperationDao sapWorkOrderOperationDao;
        private ITimeService mockTimeService;
        private ISiteConfigurationDao mockSiteConfigurationDao;
        private ICraftOrTradeDao mockCraftOrTradeDao;        

        private EventQueueTestWrapper eventQueue;
        private Mockery mocks;

        public const string QUERY_BY_ID = "QueryById";
        public const string REMOVE = "Remove";
        public const string UPDATE = "Update";

        public const string REMOVE_GAS_TEST_ELEMENT = "Remove";
        public const string REMOVE_GAS_TEST_ELEMENT_INFO = "Remove";

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            mockDao = mocks.NewMock<IWorkPermitDao>();
            mockDTODao = mocks.NewMock<IWorkPermitDTODao>();
            gasTestElementDao = mocks.NewMock<IGasTestElementDao>();
            gasTestElementInfoDao = mocks.NewMock<IGasTestElementInfoDao>();
            sapWorkOrderOperationDao = mocks.NewMock<ISapWorkOrderOperationDao>();
            mockSiteConfigurationDao = mocks.NewMock<ISiteConfigurationDao>();
            mockCraftOrTradeDao = mocks.NewMock<ICraftOrTradeDao>();            
            
            mockLogService = mocks.NewMock<ILogService>();
            mockTimeService = mocks.NewMock<ITimeService>();
            mockObjectLockService = mocks.NewMock<IObjectLockingService>();
            mockUserService = mocks.NewMock<IUserService>();
            mockEditHistoryService = mocks.NewMock<IEditHistoryService>();
            
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockDao);
            DaoRegistry.RegisterDaoFor( mockDTODao);
            DaoRegistry.RegisterDaoFor( gasTestElementDao);
            DaoRegistry.RegisterDaoFor( gasTestElementInfoDao);
            DaoRegistry.RegisterDaoFor( sapWorkOrderOperationDao);
            DaoRegistry.RegisterDaoFor( mockSiteConfigurationDao);
            DaoRegistry.RegisterDaoFor( mockCraftOrTradeDao);            
            
            service = new WorkPermitService(
                mockObjectLockService, 
                mockUserService, 
                mockLogService, 
                mockTimeService, 
                mockEditHistoryService);

            eventQueue = new EventQueueTestWrapper();            
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
            eventQueue.Cleanup();
        }

        [Ignore] [Test]
        public void ShouldMarkCompletedWorkPermitsAsArchived()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var lockResult = new ObjectLockResult(true, user.IdValue, now);

            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeArchivingClosedWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.AtLeastOnce.On(mockTimeService).Method("GetTime").Will(Return.Value(now));
            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Complete).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var matcher = new WorkPermitStatusMatcher(WorkPermitStatus.Archived);
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[1], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[2], user.IdValue);

            service.ArchiveCompletedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldMarkCompletedWorkPermitsAsArchivedIfWorkPermitsAreNotLocked()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var openLockResult = new ObjectLockResult(true, user.IdValue, now);
            var closedLockResult = new ObjectLockResult(false, user.IdValue, now);

            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeArchivingClosedWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.AtLeastOnce.On(mockTimeService).Method("GetTime").Will(Return.Value(now));
            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Complete).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var matcher = new WorkPermitStatusMatcher(WorkPermitStatus.Archived);
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(closedLockResult));

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[2], user.IdValue);

            service.ArchiveCompletedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotArchiveCompletedWorkPermitsIfSonfigurationIsSetToZero()
        {
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            siteConfiguration.DaysBeforeArchivingClosedWorkPermits = 0;

            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));

            service.ArchiveCompletedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        

        [Ignore] [Test]
        public void ShouldMarkAllRejectedWorkPermitsAsDeleted()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var openLockResult = new ObjectLockResult(true, user.IdValue, now);

            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var workpermits =
                new List<WorkPermit>(WorkPermitFixture.CreateWorkPermitListOfACertainStatus(3, WorkPermitStatus.Rejected));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsByStatus").With(WorkPermitStatus.Rejected).Will(Return.Value(workpermits));
            
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workpermits[0]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workpermits[0], user.IdValue);
            
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workpermits[1]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workpermits[1], user.IdValue);
            
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workpermits[2]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workpermits[2], user.IdValue);
            
            service.DeleteRejectedWorkPermits();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
            
        }

        [Ignore] [Test]
        public void ShouldMarkAllRejectedWorkPermitsAsDeletedIfWorkPermitIsNotLocked()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var openLockResult = new ObjectLockResult(true, user.IdValue, now);
            var closeLockResult = new ObjectLockResult(false, user.IdValue, now);

            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var workpermits =
                new List<WorkPermit>(WorkPermitFixture.CreateWorkPermitListOfACertainStatus(3, WorkPermitStatus.Rejected));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsByStatus").With(WorkPermitStatus.Rejected).Will(Return.Value(workpermits));

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workpermits[0]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workpermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(closeLockResult));

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workpermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workpermits[2]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workpermits[2], user.IdValue);

            service.DeleteRejectedWorkPermits();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldSetAllIssuedWorkPermitsToCompleted()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var lockResult = new ObjectLockResult(true, user.IdValue, now);

            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeClosingIssuedWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.AtLeastOnce.On(mockTimeService).Method("GetTime").Will(Return.Value(now));
            
            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Issued).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var matcher = new WorkPermitStatusMatcher(WorkPermitStatus.Complete);
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[1], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[2], user.IdValue);

            service.CloseInactiveIssuedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldSetAllIssuesWorkPermitsToCompletedIfWookPermitIsNotLocked()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var openLockResult = new ObjectLockResult(true, user.IdValue, now);
            var closedLockResult = new ObjectLockResult(false, user.IdValue, now);

            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeClosingIssuedWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.AtLeastOnce.On(mockTimeService).Method("GetTime").Will(Return.Value(now));
            
            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Issued).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            var matcher = new WorkPermitStatusMatcher(WorkPermitStatus.Complete);
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(closedLockResult));

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Update").With(matcher);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[2], user.IdValue);

            service.CloseInactiveIssuedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldSetNotCompletedIssuedPermitsIfSiteConfigurationIsSetToZeroDays()
        {
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            siteConfiguration.DaysBeforeClosingIssuedWorkPermits = 0;

            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));

            service.CloseInactiveIssuedWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldSetAllActivePendingPermitsToDeleted()
        {
            DateTime now = new DateTime(2005,08,01);
            User user = UserFixture.CreateOperator(1,"test");
            var lockResult = new ObjectLockResult(true, user.IdValue, now);
            
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeDeletingPendingWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.Once.On(mockTimeService).Method("GetTime").With(site.TimeZone).Will(Return.Value(now));
            
            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Pending).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));
            
            foreach (WorkPermit workPermit in workPermits)
            {
                Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermit), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(lockResult));
                Expect.Once.On(mockDao).Method("Remove").With(workPermit);
                Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermit, user.IdValue);
            }

            service.DeleteInactivePendingWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldSetActivePendingPermitsToDeletedIfTheObjectIsNotLocked()
        {
            DateTime now = new DateTime(2005, 08, 01);
            User user = UserFixture.CreateOperator(1, "test");
            var openLockResult = new ObjectLockResult(true, user.IdValue, now);
            var closeLockResult = new ObjectLockResult(false, user.IdValue, now);
            
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            DateTime requestedDateTime = now.SubtractDays(siteConfiguration.DaysBeforeDeletingPendingWorkPermits);
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitComparableList(3);

            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));
            Expect.Once.On(mockDao).Method("QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus").With(requestedDateTime, site.IdValue, WorkPermitStatus.Pending).Will(Return.Value(workPermits));
            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").WithNoArguments().Will(Return.Value(user));

            Expect.Once.On(mockTimeService).Method("GetTime").With(site.TimeZone).Will(Return.Value(now));
            
            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[0]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workPermits[0]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[0], user.IdValue);

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[1]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(closeLockResult));

            Expect.Once.On(mockObjectLockService).Method("GetLock").With(Is.EqualTo(workPermits[2]), Is.EqualTo(user.IdValue), Is.Anything).Will(Return.Value(openLockResult));
            Expect.Once.On(mockDao).Method("Remove").With(workPermits[2]);
            Expect.Once.On(mockObjectLockService).Method("ReleaseLock").With(workPermits[2], user.IdValue);

            
            service.DeleteInactivePendingWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldSetNotDeletePendingPermitsIfSiteConfigurationIsSetToZeroDays()
        {
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            siteConfiguration.DaysBeforeDeletingPendingWorkPermits = 0;

            Expect.Once.On(mockSiteConfigurationDao).Method("QueryBySiteId").With(site.IdValue).Will(Return.Value(siteConfiguration));

            service.DeleteInactivePendingWorkPermitsBySiteConfiguration(site);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldQueryEditablePermitsByFunctionalLocations()
        {
            List<FunctionalLocation> functionalLocations =
                FunctionalLocationFixture.CreateNewListOfNewItems(2);
            RootFlocSet rootFlocSet = new RootFlocSet(functionalLocations);
            Expect.Once.On(mockDao).Method("QueryByFunctionalLocationsAndStatuses").
                With(rootFlocSet, WorkPermit.EditableStatuses);
            service.QueryEditablePermitsByFunctionalLocations(rootFlocSet);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallQueryById()
        {
            const long id = 1;
            Expect.Once.On(mockDao).Method(QUERY_BY_ID).With(id);
            service.QueryById(id);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void QueryBySapOperationWorkOrderDetailsShouldQueryUsingAllDetails()
        {
            Expect.Once.On(mockDao).Method("QueryBySapWorkOrderOperationKeys").
                With("workOrderNumber", "operationNumber", "subOperation");
            service.QueryBySapOperationWorkOrderDetails("workOrderNumber", "operationNumber", "subOperation");
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void QueryBySapOperationWorkOrderDetailsWithBlankSubOperationShouldQueryWithNullSubOperation()
        {
            Expect.Once.On(mockDao).Method("QueryBySapWorkOrderOperationKeys").
                With(Is.Anything, Is.Anything, Is.Null);
            service.QueryBySapOperationWorkOrderDetails("don't care", "don't care", " ");
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallRemoveLog()
        {
            Expect.Once.On(mockDao).Method(REMOVE);
            service.Remove(WorkPermitFixture.CreateWorkPermit());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateShouldHandleRemovingGasTestElementsThatAreInTheDBButNotInTheUpdateList()
        {
            Stub.On(mockEditHistoryService);
            Stub.On(mockTimeService).Method("GetTime").Will(Return.Value(DateTimeFixture.DateTimeNow));
            
            List<GasTestElement> existingGasTestElementsInDb = BuildAGasTestElementListWithOneElement(1337);
            WorkPermit workPermitWithOneGasTestElement = WorkPermitFixture.CreateWorkPermit();
            workPermitWithOneGasTestElement.Id = 90210;

            // Getting the existing Gas Test Elements in the DB, to compare against the list from the app.
            Expect.Once.On(gasTestElementDao).Method("QueryAllGasTestElementByWorkPermitId").With(
                workPermitWithOneGasTestElement.Id).Will(Return.Value(existingGasTestElementsInDb));

            // Remove the one that's in the DB, but not in the application
            Expect.Once.On(gasTestElementDao).Method("Remove").With(existingGasTestElementsInDb[0]);

            // update the workPermit
            Expect.Once.On(mockDao).Method("Update").With(workPermitWithOneGasTestElement);
            SetupExpectationsForNonDeletedCraftOrTrade(workPermitWithOneGasTestElement);
            
            service.Update(workPermitWithOneGasTestElement);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        private static List<GasTestElement> BuildAGasTestElementListWithOneElement(long? id)
        {
            var gasTestElementInDatabase = new GasTestElement {Id = id};
            var elements = new List<GasTestElement> {gasTestElementInDatabase};

            return elements;
        }

        [Ignore] [Test]
        public void InsertLogShouldInvokeLogServiceAndAddLog()
        {
            User currentUser = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();

            Expect.Once.On(mockLogService).Method("Insert")
                .With(new OltPropertyMatcher<Log>("Source", DataSource.PERMIT))
                .Will(Return.Value(new List<NotifiedEvent>()));

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));

            service.InsertLog(workPermit, currentUser, "Super Log Comment", ShiftPatternFixture.CreateDayShift(),
                              false, WorkAssignmentFixture.CreateShiftEngineer(), RoleFixture.CreateOperatorRole());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void QueryPriorityPageWorkPermitsShouldReturnPermitsMatchingPriorityViewStatuses()
        {
            List<FunctionalLocation> userSelectedFlocs =
                FunctionalLocationFixture.CreateNewListOfNewItems(10);
            RootFlocSet rootFlocSet = new RootFlocSet(userSelectedFlocs);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();

            DateTime now = DateTimeFixture.DateTimeNow;
            
            Expect.Once.On(mockDTODao).Method("QueryByFLOCsAndShiftForThisDate")
                .With(new EqualMatcher(rootFlocSet),
                      new ListMatcher<WorkPermitStatus>(new List<WorkPermitStatus>
                                                            {
                                                                WorkPermitStatus.Pending,
                                                                WorkPermitStatus.Approved,
                                                                WorkPermitStatus.Issued
                                                            }),
                      new EqualMatcher(shiftPattern),
                      new EqualMatcher(now))
                .Will(Return.Value(WorkPermitDTOFixture.CreateWorkPermitDTOListOfAllStatus()));

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(now));
            
            service.QueryOldPriorityPageWorkPermits(rootFlocSet, shiftPattern);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCopyWorkPermitSections()
        {
            Stub.On(mockEditHistoryService);
            
            // Setup:
            User user = UserFixture.CreateUserWithGivenId(-16);
            List<WorkPermitSection> sectionsToCopy = AllWorkPermitSectionsAvailableForCopying();
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-23789);
            sourcePermit.DocumentLinks = DocumentLinkFixture.CreateDocumentLinkListWithIds(2);
            
            // Setup destination work permit to have two elements (one standard, one non-global):
            WorkPermit destinationPermit = WorkPermitFixture.CreateWorkPermit(-78923);
            destinationPermit.GasTests.Elements.Clear();
            GasTestElement destinationPermitStandardElement = GasTestElementFixture.CreateGasTestElementWithStandardElementInfo();
            destinationPermit.GasTests.Elements.Add(destinationPermitStandardElement);
            GasTestElement destinationPermitNonStandardElement = GasTestElementFixture.CreateGasTestElementWithOtherElementInfo();
            destinationPermit.GasTests.Elements.Add(destinationPermitNonStandardElement);
            GasTestElementInfo destinationPermitNonStandardElementInfo = destinationPermitNonStandardElement.ElementInfo;
            Expect.Once.On(mockDao).Method("QueryById").With(destinationPermit.Id).Will(Return.Value(destinationPermit));

            // We expect that the destination permit's gas test elements and non-standard info be removed
            // before copying gas test information over from the source permit:
            Expect.Once.On(gasTestElementDao)
                .Method(REMOVE_GAS_TEST_ELEMENT).With(destinationPermitStandardElement);
            Expect.Once.On(gasTestElementDao)
                .Method(REMOVE_GAS_TEST_ELEMENT).With(destinationPermitNonStandardElement);
            Expect.Once.On(gasTestElementInfoDao)
                .Method(REMOVE_GAS_TEST_ELEMENT_INFO).With(destinationPermitNonStandardElementInfo);

            // We expect the destination work permit to be updated:
            Expect.Once.On(mockDao)
                .Method(UPDATE).With((Matcher) new OltIdMatcher<WorkPermit>(destinationPermit.IdValue));

            DateTime now = DateTimeFixture.DateTimeNow;
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(now));
            
            // Execute:
            service.CopyWorkPermit(sourcePermit, destinationPermit, sectionsToCopy, user);

            // Verify that All of the destination permit's sections have been copied from the source:
            Assert.AreEqual(sourcePermit.Tools, destinationPermit.Tools);
            Assert.AreEqual(sourcePermit.EquipmentPreparationCondition, destinationPermit.EquipmentPreparationCondition);
            Assert.AreEqual(sourcePermit.JobWorksitePreparation, destinationPermit.JobWorksitePreparation);
            Assert.AreEqual(sourcePermit.RadiationInformation, destinationPermit.RadiationInformation);
            Assert.AreEqual(sourcePermit.FireConfinedSpaceRequirements, destinationPermit.FireConfinedSpaceRequirements);
            Assert.AreEqual(sourcePermit.RespiratoryProtectionRequirements,
                            destinationPermit.RespiratoryProtectionRequirements);
            Assert.AreEqual(sourcePermit.SpecialProtectionRequirements, destinationPermit.SpecialProtectionRequirements);
            Assert.AreEqual(sourcePermit.SpecialPrecautionsOrConsiderations,
                            destinationPermit.SpecialPrecautionsOrConsiderations);
            
            Assert.AreEqual(sourcePermit.DocumentLinks.Count, destinationPermit.DocumentLinks.Count);
            Assert.AreEqual(sourcePermit.DocumentLinks[0].Title, destinationPermit.DocumentLinks[0].Title);
            Assert.AreEqual(sourcePermit.DocumentLinks[0].TitleWithUrl, destinationPermit.DocumentLinks[0].TitleWithUrl);
            Assert.AreEqual(null, destinationPermit.DocumentLinks[0].Id);
            
            AssertWorkPermitGasTestsCopied(sourcePermit.GasTests, destinationPermit.GasTests);
            AssertNotificationAuthorizationCopied(sourcePermit, destinationPermit);

            // Verify that destination permit's last modification was updated:
            Assert.AreEqual(user, destinationPermit.LastModifiedBy);
            Assert.AreEqual(now, destinationPermit.LastModifiedDate);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof(WorkPermitNotEditableException))]
        public void OnCopyWorkPermitShouldEnsureDestinationPermitIsStillEditable()
        {
            User user = UserFixture.CreateUserWithGivenId(-16);
            List<WorkPermitSection> sectionsToCopy = AllWorkPermitSectionsAvailableForCopying();
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-23789);
            WorkPermit destinationPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-78923);

            WorkPermit uneditableDestinationPermit = 
                WorkPermitFixture.CreateWorkPermit(-78923, WorkPermitStatus.Complete);
            Expect.Once.On(mockDao).Method("QueryById").With(uneditableDestinationPermit.Id).Will(Return.Value(uneditableDestinationPermit));

            service.CopyWorkPermit(sourcePermit, destinationPermit, sectionsToCopy, user);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotRemoveGasTestElementsIfNotCopyingGasTestSection()
        {
            Stub.On(mockEditHistoryService);
            
            // Setup:
            User user = UserFixture.CreateUserWithGivenId(-16);
            var sectionsToCopy = new List<WorkPermitSection>(1) {WorkPermitSection.Tools};
            WorkPermit sourcePermit = WorkPermitFixture.CreateWorkPermitWithGivenId(-23789);

            // Setup destination work permit to have two elements (one standard, one non-global):
            WorkPermit destinationPermit = WorkPermitFixture.CreateWorkPermit(-78923);
            destinationPermit.GasTests.Elements.Clear();
            destinationPermit.GasTests.Elements.Add(GasTestElementFixture.CreateGasTestElementWithStandardElementInfo());
            Expect.Once.On(mockDao).Method("QueryById").With(destinationPermit.Id).Will(Return.Value(destinationPermit));

            // We expect the destination work permit to be updated:
            Expect.Once.On(mockDao).Method(UPDATE).With((Matcher) new OltIdMatcher<WorkPermit>(destinationPermit.IdValue));

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            
            // Execute:
            service.CopyWorkPermit(sourcePermit, destinationPermit, sectionsToCopy, user);

            // Here, we're really looking for any unexpected invocations to remove gas test elements.
            // If nothing fails, we're good.

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldQueryDTOsByFunctionalLocations()
        {
            var relevantFlocs = new List<FunctionalLocation>();
            RootFlocSet rootFlocSet = new RootFlocSet(relevantFlocs);
            var permits = new List<WorkPermitDTO>();
            var range = new Range<Date>(new Date(1999, 05, 05), new Date(DateTimeFixture.DateTimeNow));

            Expect.Once.On(mockDTODao).Method("QueryByDateRangeAndStatuses").With(
                    new EqualMatcher(rootFlocSet), 
                    new ListMatcher<WorkPermitStatus>(WorkPermitStatus.All), 
                    new EqualMatcher(range.LowerBound.CreateDateTime(Time.START_OF_DAY)),
                    new EqualMatcher(range.UpperBound.CreateDateTime(Time.END_OF_DAY)),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(permits));

            service.QueryByDateRangeAndStatuses(rootFlocSet, WorkPermitStatus.All, range, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldMoveCraftOrTradeFromCraftOrTradeToOther()
        {
            long? craftOrTradeId = 1;
            Expect.Once.On(mockDao).Method("UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade").With(craftOrTradeId);
            service.UpdateWorkPermitsOnDeletedCraftOrTrade(craftOrTradeId);
            mocks.VerifyAllExpectationsHaveBeenMet();   
        }

        private static void AssertWorkPermitGasTestsCopied(WorkPermitGasTests expected, WorkPermitGasTests actual)
        {
            Assert.IsNull(actual.Id);
            Assert.AreEqual(expected.FrequencyOrDuration, actual.FrequencyOrDuration);
            Assert.AreEqual(expected.ConstantMonitoringRequired, actual.ConstantMonitoringRequired);
            Assert.AreEqual(expected.Elements.Count, actual.Elements.Count);

            for (int i = 0; i < expected.Elements.Count; i++)
            {
                GasTestElement actualElement = actual.Elements[i];
                GasTestElement expectedElement = expected.Elements[i];

                Assert.IsNull(actualElement.Id);
                Assert.AreEqual(expectedElement.ImmediateAreaTestResult, actualElement.ImmediateAreaTestResult);
                Assert.AreEqual(expectedElement.ImmediateAreaTestRequired, actualElement.ImmediateAreaTestRequired);

                GasTestElementInfo actualInfo = actualElement.ElementInfo;
                GasTestElementInfo expectedInfo = expectedElement.ElementInfo;

                if (expectedInfo.IsStandard)
                {
                    Assert.AreEqual(expectedInfo.Id, actualInfo.Id);
                }
                else
                {
                    Assert.IsNull(actualInfo.Id);
                }

                Assert.AreEqual(expectedInfo.Name, actualInfo.Name);
                Assert.AreEqual(expectedInfo.OtherLimits, actualInfo.OtherLimits);
            }
        }

        private static void AssertNotificationAuthorizationCopied(WorkPermit expected, WorkPermit actual)
        {
            Assert.AreEqual(expected.IsCoauthorizationRequired, actual.IsCoauthorizationRequired);
            Assert.AreEqual(expected.CoauthorizationDescription, actual.CoauthorizationDescription);
        }

        private static List<WorkPermitSection> AllWorkPermitSectionsAvailableForCopying()
        {
            return new List<WorkPermitSection>(WorkPermitSection.AllAvailableForCopying);
        }

        private class WorkPermitStatusMatcher : Matcher
        {
            private readonly WorkPermitStatus status;
            public WorkPermitStatusMatcher(WorkPermitStatus status)
            {
                this.status = status;
            }

            public override bool Matches(object o)
            {
                var permit = (WorkPermit)o;
                return permit.Is(status);
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("Matching Work Permit with a Work Permit Status of: ");
                writer.Write(status.ToString());
            }
        }
      
        [Ignore] [Test]
        public void WhenInsertingShouldTakeAnEditHistorySnapshot()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);
            Stub.On(mockDao);
            SetupExpectationsForNonDeletedCraftOrTrade(workPermit);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(workPermit);
            service.Insert(workPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }        

        [Ignore] [Test]
        public void WhenUpdatingShouldTakeAnEditHistorySnapshot()
        {
            Stub.On(mockTimeService).Method("GetTime").Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(gasTestElementDao).Method("QueryAllGasTestElementByWorkPermitId").Will(Return.Value(new List<GasTestElement>()));
            Stub.On(mockDao);
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(workPermit);
            SetupExpectationsForNonDeletedCraftOrTrade(workPermit);
            service.Update(workPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void UpdatingTheWorkPermitShouldSetTheLastModifiedDateToNow()
        {
            Stub.On(gasTestElementDao).Method("QueryAllGasTestElementByWorkPermitId").Will(Return.Value(new List<GasTestElement>()));
            Stub.On(mockEditHistoryService);
            
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);
            DateTime originalLastModifiedDate = workPermit.LastModifiedDate;

            SetupExpectationsForNonDeletedCraftOrTrade(workPermit);
            Expect.Once.On(mockTimeService).Method("GetTime").Will(Return.Value(DateTimeFixture.DateTimeNow.AddMilliseconds(1000)));
            Expect.Once.On(mockDao).Method("Update").With(workPermit);

            service.Update(workPermit);
            DateTime lastModifiedDateAfterUpdate = workPermit.LastModifiedDate;

            Assert.AreNotEqual(originalLastModifiedDate, lastModifiedDateAfterUpdate);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateOfWorkPermitShouldUpdateItsCraftOrTradeIfItHasBeenDeleted()
        {
            OltStub.On(gasTestElementDao);
            OltStub.On(mockEditHistoryService);
            Stub.On(mockTimeService).Method("GetTime").Will(Return.Value(DateTimeFixture.DateTimeNow));
            
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);

            Expect.Once.On(mockCraftOrTradeDao).Method("QueryByIdAndNotDeleted").Will(Return.Value(null));
            UserSpecifiedCraftOrTrade expectedNewCraftOrTrade = new UserSpecifiedCraftOrTrade(workPermit.CraftOrTradeName);
            Expect.Once.On(mockDao).Method("Update").With(new PropertyMatcher("Specifics",
                                                                              new PropertyMatcher("CraftOrTrade",
                                                                                                  new EqualMatcher(
                                                                                                      expectedNewCraftOrTrade))));

            service.Update(workPermit);            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void InsertingOfWorkPermitShouldUpdateItsCraftOrTradeIfItHasBeenDeleted()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);
            UserSpecifiedCraftOrTrade expected = new UserSpecifiedCraftOrTrade(workPermit.CraftOrTradeName);
            OltStub.On(mockEditHistoryService);

            var craftOrTradeMatcher = new PropertyMatcher("Specifics",
                                                           new PropertyMatcher("CraftOrTrade",
                                                                               new EqualMatcher(
                                                                                   expected)));

            Expect.Once.On(mockDao).Method("Insert").With(craftOrTradeMatcher);
            Expect.Once.On(mockCraftOrTradeDao).Method("QueryByIdAndNotDeleted").Will(Return.Value(null));

            service.Insert(workPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotUpdateCraftOrTradeIfThereIsNoAssociatedCraftOfTradeObjectForThisWorkPermit()
        {
            OltStub.On(gasTestElementDao);
            OltStub.On(mockEditHistoryService);
            OltStub.On(mockTimeService);
            OltStub.On(mockDao);
            
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(9);
            workPermit.Specifics.CraftOrTrade = new UserSpecifiedCraftOrTrade("User Specified Craft or Trade");

            Expect.Never.On(mockCraftOrTradeDao).Method("QueryByIdAndNotDeleted");

            service.Update(workPermit);
            mocks.VerifyAllExpectationsHaveBeenMet();

            service.Update(workPermit);    
        }
        
        private void SetupExpectationsForNonDeletedCraftOrTrade(WorkPermit workPermit)
        {
            Expect.Once.On(mockCraftOrTradeDao).Method("QueryByIdAndNotDeleted").Will(Return.Value(workPermit.Specifics.CraftOrTrade));
        }
    }
}