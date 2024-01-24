using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
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
    public class TargetDefinitionServiceTest
    {
        private readonly Mockery mock = new Mockery();

        private ITargetDefinitionService service;
        private TargetDefinitionService concreteService;
        private ITargetDefinitionDao mockTargetDefinitionDao;
        private ITargetAlertDao mockTargetAlertDao;
        private ITargetDefinitionDTODao mockTargetDefinitionDtoDao;
        private IActionItemDao mockActionItemDao;
        private ITargetDefinitionHistoryDao mockTargetDefinitionHistoryDao;
        private ITargetDefinitionStateDao mockTargetDefinitionStateDao;

        private ITimeService mockTimeService;
        private IUserService mockUserService;
        private IEditHistoryService mockEditHistoryService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private ITargetAlertService mockTargetAlertService;

        private TargetDefinition targetMainDefinition;
        private SiteConfiguration siteConfiguration;

        private const string QUERY_BY_ID = "QueryById";
        private const string REMOVE = "Remove";
        private const string UPDATE = "Update";
        private const string INSERT = "Insert";
        private const string QUERY_ALL_ACTIVE = "QueryActiveByName";
        private const string QUERY_FOR_PARENTS = "QueryParentTargets";
        private const string QUERY_LINKED_ACTION_ITEM_DEFINITION_COUNT = "QueryLinkedActionItemDefinitionCount";
        private const string QUERY_TARGET_ALERT_NEEDING_ATTENTION = "QueryTargetAlertNeedingAttentionByTargetDefinition";
        private EventQueueTestWrapper eventQueue;

        [SetUp]
        public void SetUp()
        {
            eventQueue = new EventQueueTestWrapper();

            mockTargetDefinitionDao = mock.NewMock<ITargetDefinitionDao>();
            mockTargetDefinitionDtoDao = mock.NewMock<ITargetDefinitionDTODao>();
            mockActionItemDao = mock.NewMock<IActionItemDao>();
            mockTargetAlertDao = mock.NewMock<ITargetAlertDao>();
            mockTargetDefinitionHistoryDao = mock.NewMock<ITargetDefinitionHistoryDao>();

            mockTimeService = mock.NewMock<ITimeService>();
            mockUserService = mock.NewMock<IUserService>();
            mockEditHistoryService = mock.NewMock<IEditHistoryService>();
            mockSiteConfigurationService = mock.NewMock<ISiteConfigurationService>();
            mockTargetAlertService = mock.NewMock<ITargetAlertService>();
            mockTargetDefinitionStateDao = mock.NewMock<ITargetDefinitionStateDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockTargetDefinitionDao);
            DaoRegistry.RegisterDaoFor( mockTargetDefinitionStateDao);
            DaoRegistry.RegisterDaoFor( mockTargetDefinitionDtoDao);
            DaoRegistry.RegisterDaoFor( mockActionItemDao);
            DaoRegistry.RegisterDaoFor( mockTargetAlertDao);
            DaoRegistry.RegisterDaoFor( mockTargetDefinitionHistoryDao);

            service = new TargetDefinitionService(
                mockTargetAlertService, 
                mockUserService, 
                mockEditHistoryService, 
                mockSiteConfigurationService, 
                mockTimeService);
            concreteService = (TargetDefinitionService)service;
            targetMainDefinition = TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();

            siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(targetMainDefinition.FunctionalLocation.Site);
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
        }

        [Ignore] [Test]
        public void ShouldCallGetCountMethod()
        {
            const string expectedString = "some silly name to search";
            const long siteId = 1;
            Expect.Once.On(mockTargetDefinitionDao).Method("GetCount").With(expectedString, siteId).Will(Return.Value(1));
            service.GetCount(expectedString, siteId);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
      
        [Ignore] [Test]
        public void NonOverlappingTargetDefinitionsShouldBeAbleToHaveSameWriteTags()
        {
            long? targetDefinitionId = null;
            TagDirection direction = TagDirection.Write;
            
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(42);
            var matchingTargetDefinitions = new List<TargetDefinition> { targetDefinition };

            ISchedule nonOverlappingSchedule =
                new SingleSchedule(targetDefinition.Schedule.EndDate.AddDays(1), new Time(1), new Time(2),
                                   SiteFixture.Sarnia());

            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionAlreadyUsingTag").
                With(targetDefinitionId, direction, targetDefinition.TagInfo.IdValue).
                Will(Return.Value(matchingTargetDefinitions));

            Assert.AreEqual(Error.HasNoError, 
                            service.IsValidWriteTag(targetDefinitionId, nonOverlappingSchedule, targetDefinition.TagInfo));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void OverlappingTargetDefinitionsShouldNotBeAbleToHaveSameWriteTags()
        {
            long? targetDefinitionId = null;
            TagDirection direction = TagDirection.Write;

            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(42);
            var matchingTargetDefinitions = new List<TargetDefinition> { targetDefinition };

            ISchedule overlappingSchedule =
                new RoundTheClockSchedule(targetDefinition.Schedule.EndDate.SubtractDays(5),
                                              targetDefinition.Schedule.EndDate.AddDays(5), new Time(1), new Time(1), 1,
                                              SiteFixture.Sarnia());
                       
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionAlreadyUsingTag").
                With(targetDefinitionId, direction, targetDefinition.TagInfo.IdValue).
                Will(Return.Value(matchingTargetDefinitions));

            Assert.AreNotEqual(Error.HasNoError, 
                               service.IsValidWriteTag(targetDefinitionId, overlappingSchedule, targetDefinition.TagInfo));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void IsValidNameShouldAllowTheSameNameIfItIsEditingItself()
        {
            Site site = SiteFixture.Sarnia();

            TargetDefinition targetDefinitionToEdit = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinitionToEdit.Id = 1;
            
            var targetDefinitions = new List<TargetDefinition> {targetDefinitionToEdit};

            string nameOfTarget = targetDefinitionToEdit.Name;
            Expect.Once.On(mockTargetDefinitionDao).Method("GetCount").With(nameOfTarget, site.Id).Will(Return.Value(1));
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryByName").With(site.Id, nameOfTarget).Will(Return.Value(targetDefinitions));

            Error error = service.IsValidName(nameOfTarget, site, targetDefinitionToEdit.Schedule, targetDefinitionToEdit);
            Assert.IsFalse(error.HasError);  
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldGetActiveTargets()
        {
            const string name = "TestDa";
            long siteId = SiteFixture.Sarnia().IdValue;
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_ALL_ACTIVE).With(siteId, name);
            service.QueryActiveByName(siteId, name);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldGetATargetById()
        {
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID);
            service.QueryById(1);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateShouldUpdateCertainTargetAlertValues()
        {
            Stub.On(mockEditHistoryService);
            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).Will(Return.Value(targetMainDefinition));
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));
            Stub.On(mockTargetDefinitionDao).Method(UPDATE);

            TargetAlert nonClosedTargetAlert = TargetAlertFixture.CreateATargetAlert();
            // set up some far out values to make sure they're set
            nonClosedTargetAlert.NeverToExceedMaximum = -123;
            nonClosedTargetAlert.MaxValue = -123;
            nonClosedTargetAlert.MinValue = -123;
            nonClosedTargetAlert.NeverToExceedMinimum = -123;
            nonClosedTargetAlert.TargetValue = TargetValue.CreateSpecifiedTarget(-123);
            nonClosedTargetAlert.GapUnitValue = -123;
            nonClosedTargetAlert.Description = "The quick brown fox jumped over the lazy dog";

            Expect.Once.On(mockTargetAlertService).Method(QUERY_TARGET_ALERT_NEEDING_ATTENTION)
                .With(targetMainDefinition)
                .Will(Return.Value(nonClosedTargetAlert));

            // since there is a non-closed alert associated with this target alert,
            // it will be updated too
            Expect.Once.On(mockTargetAlertService).Method("UpdateTargetAlert")
                .With(Is.EqualTo(nonClosedTargetAlert))
                .Will(Return.Value(new List<NotifiedEvent>()));

            Stub.On(mockTargetDefinitionStateDao);

            service.Update(targetMainDefinition, new TagChangedState());

            Assert.AreEqual(targetMainDefinition.NeverToExceedMaximum, nonClosedTargetAlert.NeverToExceedMaximum);
            Assert.AreEqual(targetMainDefinition.MaxValue, nonClosedTargetAlert.MaxValue);
            Assert.AreEqual(targetMainDefinition.MinValue, nonClosedTargetAlert.MinValue);
            Assert.AreEqual(targetMainDefinition.NeverToExceedMinimum, nonClosedTargetAlert.NeverToExceedMinimum);
            Assert.AreEqual(targetMainDefinition.TargetValue, nonClosedTargetAlert.TargetValue);
            Assert.AreEqual(targetMainDefinition.GapUnitValue, nonClosedTargetAlert.GapUnitValue);
            Assert.AreEqual(targetMainDefinition.Description, nonClosedTargetAlert.Description);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldClearTargetAlertNeedingAttentionWhenOperationalModeChanges()
        {
            TargetAlert targetAlertNeedingAttention = CreateTargetAlertNeedingAttention(TargetAlertStatus.StandardAlert);

            targetMainDefinition.OperationalMode = OperationalMode.Normal;
            TargetDefinition targetDefinitionBeforeChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(targetMainDefinition);
            targetDefinitionBeforeChanges.OperationalMode = OperationalMode.ShutDown;

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID)
                .Will(Return.Value(targetDefinitionBeforeChanges));
            Expect.Once.On(mockTargetAlertService).Method(QUERY_TARGET_ALERT_NEEDING_ATTENTION)
                .With(targetMainDefinition).Will(Return.Value(targetAlertNeedingAttention));
            Expect.Once.On(mockTargetAlertService).Method("UpdateTargetAlert")
                .With(new OltPropertyMatcher<TargetAlert>("Status", TargetAlertStatus.Cleared))
                .Will(Return.Value(new List<NotifiedEvent>()));

            Stub.On(mockEditHistoryService);
            Stub.On(mockTargetDefinitionDao);
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));


            service.Update(targetMainDefinition, new TagChangedState());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldClearTargetAlertNeedingAttentionWhenTargetDefinitionIsNowInactive()
        {
            TargetAlert targetAlertNeedingAttention = CreateTargetAlertNeedingAttention(TargetAlertStatus.NeverToExceedAlert);

            Expect.Once.On(mockTargetAlertService).Method("UpdateTargetAlert")
                .With(new OltPropertyMatcher<TargetAlert>("Status", TargetAlertStatus.Cleared))
                .Will(Return.Value(new List<NotifiedEvent>()));

            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID)
                .Will(Return.Value(targetMainDefinition));
            Stub.On(mockTargetAlertService).Method(QUERY_TARGET_ALERT_NEEDING_ATTENTION)
                .With(targetMainDefinition).Will(Return.Value(targetAlertNeedingAttention));
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));
            Stub.On(mockEditHistoryService);
            Stub.On(mockTargetDefinitionDao);
            
            targetMainDefinition.IsActive = false;
            service.Update(targetMainDefinition, new TagChangedState());
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ApproveShouldApprove()
        {
            Expect.Once.On(mockTargetDefinitionDao).Method("Update");
            Stub.On(mockTargetAlertDao);
            Stub.On(mockEditHistoryService);
            service.Approve(targetMainDefinition, targetMainDefinition.LastModifiedBy, targetMainDefinition.LastModifiedDate);
            Assert.AreEqual(TargetDefinitionStatus.Approved, targetMainDefinition.Status);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void RejectShouldReject()
        {
            Expect.Once.On(mockTargetDefinitionDao).Method("Update");
            Stub.On(mockTargetAlertDao);
            Stub.On(mockEditHistoryService);

            service.Reject(targetMainDefinition, UserFixture.CreateAdmin(), DateTimeFixture.DateTimeNow);

            Assert.AreEqual(TargetDefinitionStatus.Rejected, targetMainDefinition.Status);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void RejectShouldRecordLastModifiedUserAndDate()
        {
            User lastModifiedUser = UserFixture.CreateAdmin();
            DateTime lastModifiedDate = DateTimeFixture.DateTimeNow;

            Expect.Once.On(mockTargetDefinitionDao).Method("Update");
            Stub.On(mockTargetAlertDao);
            Stub.On(mockEditHistoryService);
            service.Reject(targetMainDefinition, lastModifiedUser, lastModifiedDate);
            
            Assert.AreEqual(lastModifiedUser, targetMainDefinition.LastModifiedBy);
            Assert.AreEqual(lastModifiedDate, targetMainDefinition.LastModifiedDate);

            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldCallUpdateEventWhenUpdateTargetIsCalled()
        {
            Stub.On(mockEditHistoryService);
            Expect.Once.On(mockTargetDefinitionDao).Method(UPDATE);
            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).Will(Return.Value(targetMainDefinition));
            Stub.On(mockTargetAlertService).Method(QUERY_TARGET_ALERT_NEEDING_ATTENTION);
            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));

            service.Update(targetMainDefinition, new TagChangedState());

            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreSame(targetMainDefinition, queueItems[0].DomainObject);
            Assert.AreEqual(ApplicationEvent.TargetDefinitionUpdate, queueItems[0].ApplicationEvent);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallInsertTarget()
        {
            Stub.On(mockEditHistoryService);
            TargetDefinition savedTarget = targetMainDefinition;
            savedTarget.Id = 10;
            Expect.Once.On(mockTargetDefinitionDao).Method(INSERT).With(targetMainDefinition).Will(Return.Value(savedTarget));
            Expect.Once.On(mockTargetDefinitionStateDao).Method(INSERT);
            service.Insert(targetMainDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldExecuteInsertEventWhenInsertIsCalled()
        {
            Stub.On(mockEditHistoryService);
            TargetDefinition savedTargetDefinition = targetMainDefinition;
            Expect.Once.On(mockTargetDefinitionDao).Method(INSERT).Will(Return.Value(savedTargetDefinition));
            Expect.Once.On(mockTargetDefinitionStateDao).Method(INSERT);
            savedTargetDefinition.Id = 10;
            service.Insert(savedTargetDefinition);

            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreSame(savedTargetDefinition, queueItems[0].DomainObject);
            Assert.AreEqual(ApplicationEvent.TargetDefinitionCreate, queueItems[0].ApplicationEvent);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void RemovingTargetShouldAlsoRemoveAllAssociatedTargetAlerts()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);

            TargetAlert targetAlert1 = TargetAlertFixture.CreateTargetAlertFromTargetDefinition(targetDefinition);
            targetAlert1.Status = TargetAlertStatus.StandardAlert;

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_FOR_PARENTS).WithAnyArguments().Will(Return.Value(new List<string>()));
            Expect.Once.On(mockTargetAlertService).Method("QueryTargetAlertNeedingAttentionByTargetDefinition").Will(Return.Value(targetAlert1));

            targetAlert1.Status = TargetAlertStatus.Cleared;
            Expect.Once.On(mockTargetAlertService).Method("UpdateTargetAlert")
                .With(Is.EqualTo(targetAlert1))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockTargetDefinitionDao).Method(REMOVE).With(targetDefinition);

            TargetDefinitionState state = new TargetDefinitionState(targetDefinition.Id, false, null);
            Stub.On(mockTargetDefinitionStateDao).Method("QueryById").With(targetDefinition.IdValue).Will(Return.Value(state));
            Stub.On(mockTargetDefinitionStateDao).Method("Update");


            service.Remove(targetDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldRemoveUpdateTargetAlertAndRemoveTargetDefinition()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithGenerateActionItemTrue();
            TargetAlert targetAlertFromDefinition = TargetAlertFixture.CreateTargetAlertFromTargetDefinition(targetDefinition);
            
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_FOR_PARENTS).WithAnyArguments()
                .Will(Return.Value(new List<string>()));
            Expect.Once.On(mockTargetAlertService).Method("QueryTargetAlertNeedingAttentionByTargetDefinition")
                .Will(Return.Value(targetAlertFromDefinition));
            targetAlertFromDefinition.Status = TargetAlertStatus.Cleared;
            Expect.Once.On(mockTargetAlertService).Method("UpdateTargetAlert")
                .With(Is.EqualTo(targetAlertFromDefinition))
                .Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockTargetDefinitionDao).Method(REMOVE);

            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetMainDefinition.Id, false, null);
            Stub.On(mockTargetDefinitionStateDao).Method("QueryById").WithAnyArguments().Will(Return.Value(targetDefinitionState));
            Stub.On(mockTargetDefinitionStateDao).Method("Update");

            service.Remove(targetDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldOnlyRemoveTargetDefinitionWhenThereAreNoTargetAlertsNeedingAttention()
        {
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_FOR_PARENTS).WithAnyArguments().Will(Return.Value(new List<string>()));
            Expect.Once.On(mockTargetAlertService).Method("QueryTargetAlertNeedingAttentionByTargetDefinition").Will(Return.Value(null));
            Expect.Once.On(mockTargetDefinitionDao).Method(REMOVE);
            
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetMainDefinition.Id, false, null);
            Stub.On(mockTargetDefinitionStateDao).Method("QueryById").WithAnyArguments().Will(Return.Value(targetDefinitionState));
            Stub.On(mockTargetDefinitionStateDao).Method("Update");

            service.Remove(targetMainDefinition);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnSameTargetWhenSaveSuccesfull()
        {
            Stub.On(mockEditHistoryService);
            //Should add some data to Target
            TargetDefinition newTarget =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            Expect.Once.On(mockTargetDefinitionDao).Method("Insert").Will(Return.Value(newTarget));
            Expect.Once.On(mockTargetDefinitionStateDao).Method("Insert");
            TargetDefinition addedTarget = (TargetDefinition)service.Insert(newTarget)[0].DomainObject;

            Assert.IsTrue(addedTarget.Equals(newTarget));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void CallingInsertShouldNotInsertANewActionItemIfGenerateActionFalseAndApproved()
        {
            Stub.On(mockEditHistoryService);
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithGenerateActionItemFalse();
            Expect.Never.On(mockActionItemDao).Method("Insert");
            Expect.Once.On(mockTargetDefinitionDao).Method("Insert").WithAnyArguments().Will(Return.Value(targetDefinition));
            Expect.Once.On(mockTargetDefinitionStateDao).Method("Insert").With(
                new OltPropertyMatcher<TargetDefinitionState>("Id", targetDefinition.Id));
            service.Insert(targetMainDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void CallingInsertShouldNotInsertANewActionItemIfGenerateActionTrueAndPending()
        {
            Stub.On(mockEditHistoryService);
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithGenerateActionItemFalse();
            Expect.Never.On(mockActionItemDao).Method("Insert");
            Expect.Once.On(mockTargetDefinitionDao).Method("Insert").WithAnyArguments().Will(Return.Value(targetDefinition));
            Expect.Once.On(mockTargetDefinitionStateDao).Method("Insert").With(
                new OltPropertyMatcher<TargetDefinitionState>("Id", targetDefinition.Id));

            service.Insert(targetMainDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void CheckNoCircularDependencyCreatedOneLevel()
        {
            List<long> childIds = TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {2, 3, 4});
            List<long> child2ChildIds = TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {5});

            TargetDefinition parent = TargetDefinitionFixture.CreateParentTargetDefintion(1, childIds);
            TargetDefinition child2 = TargetDefinitionFixture.CreateParentTargetDefintion(2, child2ChildIds);
            TargetDefinition child3 = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(3);
            TargetDefinition child4 = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(4);
            TargetDefinition childOfChild2 = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(5);

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child2.Id).Will(Return.Value(child2));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(childOfChild2.Id).Will(
                Return.Value(childOfChild2));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child3.Id).Will(Return.Value(child3));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child4.Id).Will(Return.Value(child4));

            service.CheckCircularDependencyCreated(parent);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof (LinkedTargetCircularReferenceException))]
        public void CheckCircularDependencyCreatedOneLevel()
        {
            List<long> childrenOfBaseTarget =
                TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {2, 3, 4});
            List<long> childOfTarget2 = TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {1});

            TargetDefinition parent =
                TargetDefinitionFixture.CreateParentTargetDefintion(1, childrenOfBaseTarget);
            TargetDefinition target2 = TargetDefinitionFixture.CreateParentTargetDefintion(2, childOfTarget2);

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(target2.Id).Will(Return.Value(target2));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(parent.Id).Will(Return.Value(parent));
            service.CheckCircularDependencyCreated(parent);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof (LinkedTargetCircularReferenceException))]
        public void CheckCircularDependencyCreatedTwoLevelsWithNonConnectedChild()
        {
            List<long> childOfBaseTarget =
                TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {2});
            List<long> childOf2 = TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {6});

            List<long> childOf6 = TargetDefinitionFixture.CreateAssociatedTargetIdList(new long[] {2});

            TargetDefinition parent = TargetDefinitionFixture.CreateParentTargetDefintion(1, childOfBaseTarget);
            TargetDefinition target2 = TargetDefinitionFixture.CreateParentTargetDefintion(2, childOf2);

            TargetDefinition target6 = TargetDefinitionFixture.CreateParentTargetDefintion(6, childOf6);

            Expect.Exactly(2).On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(target2.Id).Will(Return.Value(target2));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(target6.Id).Will(Return.Value(target6));

            service.CheckCircularDependencyCreated(parent);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof (ParentTargetExistsException))]
        public void AttemptToDeleteTargetThatIsAChildWillThrowException()
        {
            TargetDefinition childTarget = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            TargetDefinition parentTarget = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2);
            var parents = new List<string>(1) {parentTarget.Name};

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_FOR_PARENTS).With(childTarget.IdValue).Will(
                Return.Value(parents));
            service.Remove(childTarget);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ReturnTrueIfTargetDefinitionHasLinkedActionItemDefinition()
        {
            long? targetDefinitionId = 1;
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_LINKED_ACTION_ITEM_DEFINITION_COUNT).With(
                targetDefinitionId.Value).Will(Return.Value(1));
            const bool expected = true;
            bool actual = service.HasLinkedActionItemDefinition(targetDefinitionId);
            Assert.AreEqual(expected, actual);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ReturnFalseIfTargetDefinitionHasNoLinkedActionItemDefintion()
        {
            long? targetDefinitionId = 2;
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_LINKED_ACTION_ITEM_DEFINITION_COUNT).With(
                targetDefinitionId.Value).Will(Return.Value(0));
            const bool expected = false;
            bool actual = service.HasLinkedActionItemDefinition(targetDefinitionId);
            Assert.AreEqual(expected, actual);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateBoundaryExceededByUnitId()
        {
            Stub.On(mockEditHistoryService);
            
            var targetDefsForAUnit = new List<TargetDefinitionState>();
            TargetDefinitionState state = new TargetDefinitionState(TargetDefinitionFixture.CreateTargetDefinition().Id, false, null);
            targetDefsForAUnit.Add(state);

            const bool isExceedingBoundry = false;

            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryAllTargetDefinitionStatesUnderAUnitId").Will(Return.Value(targetDefsForAUnit));
            Expect.Once.On(mockTargetDefinitionStateDao).Method("Update").With(new TargetDefinitionState(state.Id, isExceedingBoundry, null));

            
            concreteService.UpdateBoundaryExceededByUnitId(FunctionalLocationFixture.CreateNewListOfNewItems(1), isExceedingBoundry);

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Ignore] [Test]
        public void WhenInsertingShouldTakeAnEditHistorySnapshot()
        {
            Stub.On(mockTargetDefinitionDao);

            TargetDefinitionState state = new TargetDefinitionState(targetMainDefinition.Id, false, null);

            Expect.Once.On(mockTargetDefinitionStateDao).Method(INSERT).With(
                state);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(targetMainDefinition);
            service.Insert(targetMainDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void WhenUpdatingShouldTakeAnEditHistorySnapshot()
        {
            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).Will(Return.Value(targetMainDefinition));
            Stub.On(mockTargetDefinitionDao);
            Stub.On(mockTargetAlertService);

            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));

            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(targetMainDefinition);
            service.Update(targetMainDefinition, new TagChangedState());
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void WhenUpdatingIfStateHasChangedThenTargetDefStateShouldBeReset()
        {
            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).Will(Return.Value(targetMainDefinition));
            Stub.On(mockTargetDefinitionDao);
            Stub.On(mockTargetAlertService);

            Stub.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));

            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(targetMainDefinition);
            TagChangedState tagChangedState = new TagChangedState {TagHasChanged = true};
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetMainDefinition.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method(QUERY_BY_ID).Will(Return.Value(targetDefinitionState));
            Expect.Once.On(mockTargetDefinitionStateDao).Method(UPDATE).With(
                new OltPropertyMatcher<TargetDefinitionState>("IsExceedingBoundary", false));

            service.Update(targetMainDefinition, tagChangedState);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCheckForAutoReApprovalFieldWhenUpdating()
        {
            Stub.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).Will(Return.Value(targetMainDefinition));
            Stub.On(mockTargetDefinitionDao);
            Stub.On(mockTargetAlertService);
            Stub.On(mockEditHistoryService);

            Expect.Once.On(mockSiteConfigurationService).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));
            service.Update(targetMainDefinition, new TagChangedState());
            mock.VerifyAllExpectationsHaveBeenMet();
        }
       
        [Ignore] [Test]
        public void ShouldReturnNoErrorWhenNoOtherTargetDefinitionIsWritingToATag()
        {
            const long targetDefinitionId = 1;
            TagInfo tagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
                        
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionAlreadyUsingTag")
                    .With(targetDefinitionId, TagDirection.Write, tagInfo.IdValue)
                    .Will(Return.Value(new List<TargetDefinition>()));
                              
            Error err =
                service.IsValidWriteTag(targetDefinitionId, SingleScheduleFixture.Create2000Jan1AM15MinTo30Min(),
                                        tagInfo);            
            Assert.IsFalse(err.HasError);
            mock.VerifyAllExpectationsHaveBeenMet();            
        }
        
        [Ignore] [Test]
        public void ShouldNotUpdateStatusForInvalidTagIfNoTargetDefinitionsFound()
        {
            TagInfo tag = TagInfoFixture.CreateMockTagForSarnia(1, "some tag");
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionsWithValidTag").With(tag).Will(Return.Value(new List<TargetDefinition>()));
            service.UpdateStatusForInvalidTag(tag, SiteFixture.Sarnia());
            mock.VerifyAllExpectationsHaveBeenMet();            
        }

        [Ignore] [Test]
        public void ShouldUpdateStatusForInvalidTag()
        {
            TagInfo tag = TagInfoFixture.CreateMockTagForSarnia(1, "some tag");
            User remoteUser = UserFixture.CreateRemoteAppUser();
            Stub.On(mockUserService).Method("GetRemoteAppUser").Will(Return.Value(remoteUser));

            Site site = SiteFixture.Sarnia();

            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            var targetDefinitions = new List<TargetDefinition>(new[] { targetDefinition });
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionsWithValidTag").With(tag).Will(Return.Value(targetDefinitions));
            
            DateTime now = DateTimeFixture.DateTimeNow;
            Expect.Once.On(mockTimeService).Method("GetTime").With(site.TimeZone).Will(Return.Value(now));

            targetDefinition.HasInvalidTag(remoteUser, now);

            Expect.Once.On(mockTargetDefinitionDao).Method("UpdateStatus").With(targetDefinition);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(targetDefinition);

            Stub.On(mockTargetDefinitionStateDao);

            service.UpdateStatusForInvalidTag(tag, site);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateStatusValidTag()
        {
            TagInfo tag = TagInfoFixture.CreateMockTagForSarnia(1, "some tag");
            User remoteUser = UserFixture.CreateRemoteAppUser();
            Stub.On(mockUserService).Method("GetRemoteAppUser").Will(Return.Value(remoteUser));

            Site site = SiteFixture.Sarnia();

            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            var targetDefinitions = new List<TargetDefinition>(new[] { targetDefinition });
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionsWithInvalidTag").With(tag).Will(Return.Value(targetDefinitions));

            DateTime now = DateTimeFixture.DateTimeNow;
            Expect.Once.On(mockTimeService).Method("GetTime").With(site.TimeZone).Will(Return.Value(now));

            targetDefinition.HasValidTag(remoteUser, now);

            Expect.Once.On(mockTargetDefinitionDao).Method("UpdateStatus").With(targetDefinition);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(targetDefinition);

            Stub.On(mockTargetDefinitionStateDao);

            service.UpdateStatusForValidTag(tag, site);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotUpdateStatusForValidTagIfNoTargetDefinitionsFound()
        {
            TagInfo tag = TagInfoFixture.CreateMockTagForSarnia(1, "some tag");
            Expect.Once.On(mockTargetDefinitionDao).Method("QueryTargetDefinitionsWithInvalidTag").With(tag).Will(Return.Value(new List<TargetDefinition>()));
            service.UpdateStatusForValidTag(tag, SiteFixture.Sarnia());
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        private static TargetAlert CreateTargetAlertNeedingAttention(TargetAlertStatus status)
        {
            TargetAlert targetAlertNeedingAttention = TargetAlertFixture.CreateATargetAlert();
            targetAlertNeedingAttention.Status = status;
            return targetAlertNeedingAttention;
        }
    }
}
