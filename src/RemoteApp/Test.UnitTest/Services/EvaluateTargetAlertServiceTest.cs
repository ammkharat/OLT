using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Is = Rhino.Mocks.Constraints.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class EvaluateTargetAlertServiceTest
    {
        private const decimal THRESHOLD_MIN = 1.0m;
        private const decimal NON_BOUNDARY_EXCEEDING_ACTUAL_VALUE = 5.0m;
        private const decimal THRESHOLD_MAX = 10.0m;
        private const decimal BOUNDARY_EXCEEDING_ACTUAL_VALUE = 11.0m;

        private TargetAlertService service;
        private ITargetDefinitionDao mockTargetDefinitionDao;
        private ITargetDefinitionStateDao mockTargetDefinitionStateDao;
        private ITargetAlertDao mockTargetAlertDao;
        private ITimeDao mockTimeDao;
        private ITagDao mockTagDao;        
        private IUserService mockUserService;
        private IPlantHistorianService mockPlantHistorianService;
        private IEditHistoryService mockEditHistory;
        
        private EventQueueTestWrapper eventQueue;

        [SetUp]
        public void SetUp()
        {
            mockTargetDefinitionDao = MockRepository.GenerateMock<ITargetDefinitionDao>();
            mockTargetDefinitionStateDao = MockRepository.GenerateMock<ITargetDefinitionStateDao>();
            mockTargetAlertDao = MockRepository.GenerateMock<ITargetAlertDao>();
            mockTimeDao = MockRepository.GenerateStub<ITimeDao>();
            mockTagDao = MockRepository.GenerateMock<ITagDao>();

            DaoRegistry.RegisterDaoFor(mockTargetDefinitionDao);
            DaoRegistry.RegisterDaoFor(mockTargetDefinitionStateDao);
            DaoRegistry.RegisterDaoFor(mockTargetAlertDao);
            DaoRegistry.RegisterDaoFor(MockRepository.GenerateStub<ITargetAlertDTODao>());
            DaoRegistry.RegisterDaoFor(MockRepository.GenerateStub<ITargetAlertResponseDao>());
            DaoRegistry.RegisterDaoFor(MockRepository.GenerateStub<ICommentDao>()); 
            DaoRegistry.RegisterDaoFor(mockTimeDao);            
            DaoRegistry.RegisterDaoFor(mockTagDao);

            mockUserService = MockRepository.GenerateMock<IUserService>();
            mockPlantHistorianService = MockRepository.GenerateMock<IPlantHistorianService>();
            mockEditHistory = MockRepository.GenerateStub<IEditHistoryService>();

            service = new TargetAlertService(MockRepository.GenerateMock<ILogService>(), mockPlantHistorianService, mockUserService, mockEditHistory);

            eventQueue = new EventQueueTestWrapper();
            
            mockUserService.Stub(mock => mock.GetRemoteAppUser()).Return(UserFixture.CreateDBInsertableUser());
            Clock.Freeze();

            mockTimeDao.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now.GetNetworkPortable());
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();  
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void EvaluateTargetDefinitionShouldCreateNewAlert()
        {
            //                           New reading 
            // Active?  Alert required?  exceeds boundary?  Existing alerts?  Outcome:
            // Yes      Yes              Yes                No                Raise new alert
            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, true, true, null);

            // Since there're no non-closed alerts, and the target is exceeding boundaries, we will
            // create a new target alert:

            mockTargetAlertDao.Expect(mock => mock.Insert(null))
                              .Constraints(new And(Property.ValueConstraint("TargetDefinition", Property.Value("IdValue", targetDefinition.IdValue)),
                                  Property.Value("ActualValue", BOUNDARY_EXCEEDING_ACTUAL_VALUE))).Return(TargetAlertFixture.CreateTargetAlertFromTargetDefinition(targetDefinition));

            // Execute:
            service.EvaluateTarget(targetDefinition);

            // Verify new alert event fired:
            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(ApplicationEvent.TargetAlertCreate, queueItems[0].ApplicationEvent);
            DomainObject targetAlert = queueItems[0].DomainObject;
            Assert.That(targetAlert, NUnit.Framework.Is.InstanceOf(typeof (TargetAlert)));

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }
         
        [Ignore] [Test]
        public void EvaluateTargetDefinitionShouldUpdateExistingAlert()
        {
            //                           New reading 
            // Active?  Alert required?  exceeds boundary?  Existing alerts?  Outcome:
            // Yes      Yes              Yes                Yes               Update existing alert
            TargetAlert existingAlert = CreateTestTargetAlert();
            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, true, true, existingAlert);

         
            // Since there is a non-closed alert, we will update it:

            mockTargetAlertDao.Expect(mock => mock.Update(existingAlert))
                              .Constraints(new And(Property.Value("ExceedingBoundaries", true), Property.Value("ActualValue", BOUNDARY_EXCEEDING_ACTUAL_VALUE)));


            // Execute:
            service.EvaluateTarget(targetDefinition);

            // Verify alert updated event fired:
            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(ApplicationEvent.TargetAlertUpdate, queueItems[0].ApplicationEvent);
            Assert.AreEqual(existingAlert.Id, queueItems[0].DomainObject.Id);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();

        }

        [Ignore] [Test]
        public void EvaluateTargetDefinitionShouldSkipInactiveDefinitions()
        {
            //                           New reading 
            // Active?  Alert required?  exceeds boundary?  Existing alerts?  Outcome:
            // No       Yes              Yes                No                Skip this target definition
            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(false, true, true, null);

            // Execute:
            service.EvaluateTarget(targetDefinition);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void EvaluateTargetDefinitionShouldOnlyTakeReadingForDefinitionNotRequiringAlerts()
        {
            //                           New reading 
            // Active?  Alert required?  exceeds boundary?  Existing alerts?  Outcome:
            // Yes      No               Yes                No                Read tag value only
            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, false, true, null);

            // Execute:
            service.EvaluateTarget(targetDefinition);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void EvaluateTargetDefinitionShouldNotCreateNewAlertIfNotExceedingBoundary()
        {
            //                           New reading 
            // Active?  Alert required?  exceeds boundary?  Existing alerts?  Outcome:
            // Yes      Yes              No                 No                Read tag value only
            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, true, false, null);

            // Execute:
            service.EvaluateTarget(targetDefinition);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldNotUpdateTargetAlertAlreadyExceedingBoundariesAndPutIntoQueueIfValueDoesNotChange()
        {
            decimal actualValue = BOUNDARY_EXCEEDING_ACTUAL_VALUE;
            User lastModifiedBy = UserFixture.CreateOperator(999, "tgould");
            DateTime lastModifiedDateTime = new DateTime(2010, 12, 10);

            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.StandardAlert);
            alert.Id = 5;
            alert.ExceedingBoundaries = true;
            alert.ActualValue = actualValue;
            alert.LastModifiedBy = lastModifiedBy;
            alert.LastModifiedDateTime = lastModifiedDateTime;          

            alert.TypeOfViolationStatus = TargetAlertStatus.StandardAlert;
            alert.LastViolatedDateTime = Clock.Now;
            alert.ActualValueAtEvaluation = actualValue;

            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, true, true, alert);

            mockTargetAlertDao.Expect(mock => mock.Update(null)).IgnoreArguments().Repeat.Never();
            
            service.EvaluateTarget(targetDefinition);

            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(0, queueItems.Count);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }
        
        [Ignore] [Test] 
        public void ShouldUpdateTargetAlertAlreadyExceedingBoundariesIfValueChanges()
        {
            decimal originalValue = 1000m;
            User lastModifiedBy = UserFixture.CreateOperator(999, "tgould");
            DateTime lastModifiedDateTime = new DateTime(2010, 12, 10);

            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.StandardAlert);
            alert.Id = 5;
            alert.ExceedingBoundaries = true;
            alert.ActualValue = originalValue;
            alert.LastModifiedBy = lastModifiedBy;
            alert.LastModifiedDateTime = lastModifiedDateTime;

            TargetDefinition targetDefinition = SetupEvaluateTargetDefinition(true, true, true, alert);

            mockTargetAlertDao.Expect(mock => mock.Update(null)).IgnoreArguments();

            service.EvaluateTarget(targetDefinition);

            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();

        }
        private static TargetAlert CreateTestTargetAlert()
        {
            TargetAlert existingAlert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.Acknowledged);
            existingAlert.Id = 649;
            existingAlert.ExceedingBoundaries = false;
            existingAlert.Tag = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();

            return existingAlert;
        }

        private TargetDefinition SetupEvaluateTargetDefinition(bool isActive, bool isAlertRequired,
                                                               bool newReadingExceedsBoundaries,
                                                               TargetAlert existingAlert)
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.ReadWriteTagsConfiguration = TargetDefinitionReadWriteTagConfiguration.CreateRead();
            targetDefinition.IsActive = isActive;
            targetDefinition.IsAlertRequired = isAlertRequired;
            targetDefinition.NeverToExceedMinimum = null;
            targetDefinition.MinValue = THRESHOLD_MIN;
            targetDefinition.MinValueFrequency = 1;
            targetDefinition.MaxValue = THRESHOLD_MAX;
            targetDefinition.MaxValueFrequency = 1;
            targetDefinition.NeverToExceedMaximum = null;
            targetDefinition.Status = TargetDefinitionStatus.Approved;

            if (existingAlert != null)
            {
                existingAlert.MaxAtEvaluation = targetDefinition.MaxValue;
                existingAlert.MinAtEvaluation = targetDefinition.MinValue;
                existingAlert.NTEMaxAtEvaluation = targetDefinition.NeverToExceedMaximum;
                existingAlert.NTEMinAtEvaluation = targetDefinition.NeverToExceedMinimum;
            }


            if (isActive == false)
            {
                return targetDefinition;
            }

            var tagInfo = new TagInfo(SiteFixture.Sarnia().Id, "don't care", "don't care", "don't care", false,null);
            targetDefinition.TagInfo = tagInfo;

            // Expect reading of the tag's value:
            mockPlantHistorianService.Expect(mock => mock.ReadTagValues(null, tagInfo, DateTimeFixture.DateTimeNow)).Constraints(
                Is.Anything(), Is.Equal(tagInfo), Is.Anything()).Return(newReadingExceedsBoundaries
                                                                                           ? new decimal?[] {BOUNDARY_EXCEEDING_ACTUAL_VALUE}
                                                                                           : new decimal?[] {NON_BOUNDARY_EXCEEDING_ACTUAL_VALUE});

            // Expect updating the target definition with new ExceedingBoundary value:

            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetDefinition.Id, existingAlert != null, null);

            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(targetDefinition.IdValue)).Return(targetDefinitionState);
            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(new PropertyConstraint("IsExceedingBoundary", Is.Equal(newReadingExceedsBoundaries)));

            if (isAlertRequired == false)
            {
                return targetDefinition;
            }

            // Expect checking for non-closed alerts for this definition:
            var existingAlerts = new List<TargetAlert>();
            if (existingAlert != null)
            {
                existingAlerts.Add(existingAlert);
            }

            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(targetDefinition, TargetAlertStatus.AllNeedingAttention))
                              .Return(new List<TargetAlert> {existingAlert});

            return targetDefinition;
        }

        [Ignore] [Test]
        public void ShouldEvaluateOneTargetDefinitionInList()
        {
            TagInfo tagInfo = new TagInfo(SiteFixture.Sarnia().Id, "don't care", "don't care", "don't care", false,null);

            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateApprovedTargetDefinition(tagInfo, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                                       true, THRESHOLD_MIN,
                                                                                                       THRESHOLD_MAX, null, null, 1, 1);

            List<TagReadRequest> requestsForTarget = targetDefinition.CreateRequestsForTarget(Clock.Now.GetNetworkPortable());

            List<TagValue> tagValues = new List<TagValue> {new TagValue(tagInfo.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE, Clock.Now.GetNetworkPortable())};

            mockPlantHistorianService.Expect(
                mock =>
                mock.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, new List<string> {tagInfo.Name}, targetDefinition.Schedule.Site,
                                   requestsForTarget[0].EvaluationTime)).Return(tagValues);

            // Expect updating the target definition with new ExceedingBoundary value:
            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();

            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(targetDefinition.Id, false, null);
            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(targetDefinition.IdValue)).Return(targetDefinitionState);

            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(Property.Value("IsExceedingBoundary", true));
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(null, null)).IgnoreArguments().Return(new List<TargetAlert>(0));

            service.EvaluateTargets(new List<TargetDefinition> {targetDefinition});

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldEvalTwoTargetDefinitionsInList()
        {
            DateTime currentTimeAtSite = Clock.Now.GetNetworkPortable();

            TagInfo tag1 = new TagInfo(SiteFixture.Sarnia().Id, "tagA", "don't care", "don't care", false,null);
            TagValue tagValue1 = new TagValue(tag1.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE, currentTimeAtSite);
            TargetDefinition target1 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag1, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                              true, THRESHOLD_MIN,
                                                                                              THRESHOLD_MAX, null, null, 1, 1);
            target1.Id = 100;
            

            TagInfo tag2 = new TagInfo(SiteFixture.Sarnia().Id, "tagB", "don't care", "don't care", false,null);
            TagValue tagValue2 = new TagValue(tag2.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE + 1, Clock.Now.GetNetworkPortable());
            TargetDefinition target2 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag2, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                                       true, THRESHOLD_MIN,
                                                                                                       THRESHOLD_MAX, null, null, 1, 1);
            target2.Id = 200;

            List<TagReadRequest> requestsForTarget = new List<TagReadRequest>();
            requestsForTarget.AddRange(target1.CreateRequestsForTarget(currentTimeAtSite));
            requestsForTarget.AddRange(target2.CreateRequestsForTarget(currentTimeAtSite));

            
            List<TagValue> tagValues = new List<TagValue> { tagValue1, tagValue2 };

            mockPlantHistorianService.Expect(
                mock =>
                mock.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, new List<string> { tag1.Name, tag2.Name }, target1.Schedule.Site,
                                   requestsForTarget[0].EvaluationTime)).Return(tagValues);

            // Expect updating the target definition with new ExceedingBoundary value:
            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();

            TargetDefinitionState targetDefState1 = new TargetDefinitionState(target1.Id, false, null);
            TargetDefinitionState targetDefState2 = new TargetDefinitionState(target2.Id, false, null);

            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target1.IdValue)).Return(targetDefState1);
            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target2.IdValue)).Return(targetDefState2);

            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(Property.Value("IsExceedingBoundary", true)).Repeat.Twice();
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(null, null)).IgnoreArguments().Return(new List<TargetAlert>(0)).Repeat.Twice();

            service.EvaluateTargets(new List<TargetDefinition> { target1, target2 });

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
            
        }

        [Ignore] [Test]
        public void ShouldEvalTwoTargetDefinitionsInListButOnlyRequestTheSameTagOnce()
        {
            DateTime currentTimeAtSite = Clock.Now.GetNetworkPortable();

            TagInfo tag1 = new TagInfo(SiteFixture.Sarnia().Id, "tag1999", "don't care", "don't care", false,null);
            
            TargetDefinition target1 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag1, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                              true, THRESHOLD_MIN,
                                                                                              THRESHOLD_MAX, null, null, 1, 1);
            target1.Id = 100;


            TagInfo tag2 = new TagInfo(SiteFixture.Sarnia().Id, "tag1999", "don't care", "don't care", false,null);
            TargetDefinition target2 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag2, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                                       true, THRESHOLD_MIN,
                                                                                                       THRESHOLD_MAX, null, null, 1, 1);
            target2.Id = 200;

            TagValue tagValue = new TagValue(tag1.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE, currentTimeAtSite);

            List<TagReadRequest> requestsForTarget = new List<TagReadRequest>();
            requestsForTarget.AddRange(target1.CreateRequestsForTarget(currentTimeAtSite));
            requestsForTarget.AddRange(target2.CreateRequestsForTarget(currentTimeAtSite));


            List<TagValue> tagValues = new List<TagValue> { tagValue};

            mockPlantHistorianService.Expect(
                mock =>
                mock.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, new List<string> { tag1.Name}, target1.Schedule.Site,
                                   requestsForTarget[0].EvaluationTime)).Return(tagValues);

            // Expect updating the target definition with new ExceedingBoundary value:
            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();

            TargetDefinitionState targetDefState1 = new TargetDefinitionState(target1.Id, false, null);
            TargetDefinitionState targetDefState2 = new TargetDefinitionState(target2.Id, false, null);

            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target1.IdValue)).Return(targetDefState1);
            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target2.IdValue)).Return(targetDefState2);

            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(Property.Value("IsExceedingBoundary", true)).Repeat.Twice();
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(null, null)).IgnoreArguments().Return(new List<TargetAlert>(0));

            service.EvaluateTargets(new List<TargetDefinition> { target1, target2 });

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldEvalTwoTargetDefinitionsInListButNotDoAnythingForFirstTargetDefinitionSinceTheTagValueWasNotRead()
        {
            DateTime currentTimeAtSite = Clock.Now.GetNetworkPortable();

            TagInfo tag1 = new TagInfo(SiteFixture.Sarnia().Id, "tagCannotBeRead", "don't care", "don't care", false,null);
            TagValue tagValue1 = new TagValue(tag1.Name, null, currentTimeAtSite);
            TargetDefinition target1 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag1, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                              true, THRESHOLD_MIN,
                                                                                              THRESHOLD_MAX, null, null, 1, 1);
            // make the Invalid Tag code not actually update Target as invalid.  don't care to test that since it's been tested elsewhere.
            target1.LastModifiedDate = currentTimeAtSite.SubtractDays(2); 
            target1.Id = 100;


            TagInfo tag2 = new TagInfo(SiteFixture.Sarnia().Id, "tagB", "don't care", "don't care", false,null);
            TagValue tagValue2 = new TagValue(tag2.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE, Clock.Now.GetNetworkPortable());
            TargetDefinition target2 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag2, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                                       true, THRESHOLD_MIN,
                                                                                                       THRESHOLD_MAX, null, null, 1, 1);
            target2.Id = 200;

            List<TagReadRequest> requestsForTarget = new List<TagReadRequest>();
            requestsForTarget.AddRange(target1.CreateRequestsForTarget(currentTimeAtSite));
            requestsForTarget.AddRange(target2.CreateRequestsForTarget(currentTimeAtSite));


            List<TagValue> tagValues = new List<TagValue> { tagValue1, tagValue2 };

            mockPlantHistorianService.Expect(
                mock =>
                mock.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, new List<string> { tag1.Name, tag2.Name }, target1.Schedule.Site,
                                   requestsForTarget[0].EvaluationTime)).Return(tagValues);

            // Expect updating the target definition with new ExceedingBoundary value:
            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();

            TargetDefinitionState targetDefState1 = new TargetDefinitionState(target1.Id, false, null);
            TargetDefinitionState targetDefState2 = new TargetDefinitionState(target2.Id, false, null);

            mockTargetDefinitionStateDao.Expect(mock => mock.QueryById(target1.IdValue)).Return(targetDefState1);
            mockTargetDefinitionStateDao.Expect(mock => mock.QueryById(target2.IdValue)).Return(targetDefState2);

            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(new And(Property.Value("IsExceedingBoundary", true), Property.Value("IdValue", target2.IdValue)));
            
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(target1, null)).Constraints(Is.Equal(target1), Is.Anything()).Return(new List<TargetAlert>(0)).Repeat.Never();
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(null, null)).Constraints(Property.Value("IdValue", target2.IdValue), Is.Anything()).Return(new List<TargetAlert>(0));
            
            service.EvaluateTargets(new List<TargetDefinition> { target1, target2 });

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();

        }

        [Ignore] [Test]
        public void ShouldReadTagValuesForReadConfiguration()
        {
            DateTime currentTimeAtSite = Clock.Now.GetNetworkPortable();

            TagInfo tag1 = new TagInfo(SiteFixture.Sarnia().Id, "tagA", "don't care", "don't care", false,null);
            TagValue tagValue1 = new TagValue(tag1.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE, currentTimeAtSite);
            TargetDefinitionReadWriteTagConfiguration targetDefinitionReadWriteTagConfiguration = TargetDefinitionReadWriteTagConfiguration.CreateRead();
            
            TagInfo minReadTag = new TagInfo(SiteFixture.Sarnia().Id, "readTag1", "don't care", "don't care", false,null);
            TagValue tagValueMin = new TagValue(minReadTag.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE - 10, currentTimeAtSite);
            
            TagInfo maxReadTag = new TagInfo(SiteFixture.Sarnia().Id, "readTag2", "don't care", "don't care", false,null);
            TagValue tagValueMax = new TagValue(maxReadTag.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE - 1, currentTimeAtSite);
            
            targetDefinitionReadWriteTagConfiguration.MinValue.Tag = minReadTag;
            targetDefinitionReadWriteTagConfiguration.MinValue.Direction = TagDirection.Read;
            targetDefinitionReadWriteTagConfiguration.MaxValue.Tag = maxReadTag;
            targetDefinitionReadWriteTagConfiguration.MaxValue.Direction = TagDirection.Read;
            targetDefinitionReadWriteTagConfiguration.GapUnitValue.Direction = TagDirection.None;
            targetDefinitionReadWriteTagConfiguration.TargetValue.Direction = TagDirection.None;

            TargetDefinition target1 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag1, targetDefinitionReadWriteTagConfiguration, true,
                                                                                              true, THRESHOLD_MIN,
                                                                                              THRESHOLD_MAX, null, null, 1, 1);
            target1.Id = 100;


            TagInfo tag2 = new TagInfo(SiteFixture.Sarnia().Id, "tagB", "don't care", "don't care", false,null);
            TagValue tagValue2 = new TagValue(tag2.Name, BOUNDARY_EXCEEDING_ACTUAL_VALUE + 1, Clock.Now.GetNetworkPortable());
            TargetDefinition target2 = TargetDefinitionFixture.CreateApprovedTargetDefinition(tag2, TargetDefinitionReadWriteTagConfiguration.CreateDefault(), true,
                                                                                                       true, THRESHOLD_MIN,
                                                                                                       THRESHOLD_MAX, null, null, 1, 1);
            target2.Id = 200;

            List<TagReadRequest> requestsForTarget = new List<TagReadRequest>();
            requestsForTarget.AddRange(target1.CreateRequestsForTarget(currentTimeAtSite));
            requestsForTarget.AddRange(target2.CreateRequestsForTarget(currentTimeAtSite));


            List<TagValue> tagValues = new List<TagValue> { tagValue1, tagValueMin, tagValueMax, tagValue2 };

            List<string> tagsToRead = requestsForTarget.ConvertAll(req => req.TagName);


            DateTime readTime = target1.GetReadTimesToEvaluateTarget(currentTimeAtSite)[0];

            mockPlantHistorianService.Expect(
                mock =>
                mock.ReadTagValues(
                    PlantHistorianOrigin.TargetAlertService_Evaluation, new List<string>{"tagA", "readTag2", "readTag1", "tagB"}, target1.Schedule.Site, readTime)).Return(tagValues);

            // Expect updating the target definition with new ExceedingBoundary value:
            mockTargetDefinitionDao.Stub(mock => mock.WriteTagValues(null)).IgnoreArguments();

            TargetDefinitionState targetDefState1 = new TargetDefinitionState(target1.Id, false, null);
            TargetDefinitionState targetDefState2 = new TargetDefinitionState(target2.Id, false, null);

            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target1.IdValue)).Return(targetDefState1);
            mockTargetDefinitionStateDao.Stub(mock => mock.QueryById(target2.IdValue)).Return(targetDefState2);

            mockTargetDefinitionStateDao.Expect(mock => mock.Update(null)).Constraints(Property.Value("IsExceedingBoundary", true)).Repeat.Twice();
            mockTargetAlertDao.Expect(mock => mock.QueryByTargetDefinitionAndStatuses(null, null)).IgnoreArguments().Return(new List<TargetAlert>(0)).Repeat.Twice();

            service.EvaluateTargets(new List<TargetDefinition> { target1, target2 });

            mockTargetAlertDao.VerifyAllExpectations();
            mockPlantHistorianService.VerifyAllExpectations();
            mockTargetDefinitionStateDao.VerifyAllExpectations();
        }
    }
}