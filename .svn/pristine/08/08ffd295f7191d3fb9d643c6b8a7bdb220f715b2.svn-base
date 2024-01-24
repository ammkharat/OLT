using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class TargetAlertServiceTest
    {
        private readonly Mockery mock = new Mockery();

        private ITargetDefinitionDao mockTargetDefinitionDao;
        private ITargetDefinitionStateDao mockTargetDefinitionStateDao;
        private ITargetAlertDao mockTargetAlertDao;
        private ITargetAlertDTODao mockTargetAlertDtoDao;
        private ITargetAlertResponseDao mockResponseDao;
        private ICommentDao mockCommentDao;
        private ITimeDao mockTimeDao;        
        private ITagDao tagDao;

        private ILogService mockLogService;
        private IUserService mockUserService;
        private IPlantHistorianService mockPlantHistorianService;
        private EventQueueTestWrapper eventQueue;

        private const string QUERY_BY_ID = "QueryById";

        private TargetAlertService targetAlertService;
        private IEditHistoryService mockEditHistory;

        [SetUp]
        public void SetUp()
        {
            mockTargetDefinitionDao = mock.NewMock<ITargetDefinitionDao>();
            mockTargetDefinitionStateDao = mock.NewMock<ITargetDefinitionStateDao>();
            mockTargetAlertDao = mock.NewMock<ITargetAlertDao>();
            mockTargetAlertDtoDao = mock.NewMock<ITargetAlertDTODao>();
            mockResponseDao = mock.NewMock<ITargetAlertResponseDao>();
            mockCommentDao = mock.NewMock<ICommentDao>();
            mockTimeDao = mock.NewMock<ITimeDao>();
            tagDao = mock.NewMock<ITagDao>();            
            
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockTargetDefinitionDao) ;
            DaoRegistry.RegisterDaoFor(mockTargetDefinitionStateDao);
            DaoRegistry.RegisterDaoFor(mockTargetAlertDao);
            DaoRegistry.RegisterDaoFor(mockTargetAlertDtoDao);
            DaoRegistry.RegisterDaoFor(mockResponseDao);
            DaoRegistry.RegisterDaoFor(mockCommentDao);
            DaoRegistry.RegisterDaoFor(mockTimeDao);            
            DaoRegistry.RegisterDaoFor(tagDao);
            
            mockLogService = mock.NewMock<ILogService>();
            mockUserService = mock.NewMock<IUserService>();
            mockPlantHistorianService = mock.NewMock<IPlantHistorianService>();
            mockEditHistory = mock.NewMock<IEditHistoryService>();
           
            targetAlertService = new TargetAlertService(mockLogService, mockPlantHistorianService, mockUserService, mockEditHistory);            
            Stub.On(mockEditHistory);
            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();          
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForSingleTargetExceedingBoundaries()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithGenerateActionItemTrue();
            TargetDefinitionState state = new TargetDefinitionState(targetDefinition.Id, false, null);
            bool isTargetExceedingBoundsResult = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(targetDefinition, state);
            Assert.IsFalse(isTargetExceedingBoundsResult);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnTrueForSingleTargetExceedingBoundaries()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithGenerateActionItemTrue();
            TargetDefinitionState state = new TargetDefinitionState(targetDefinition.Id, true, null);

            bool isTargetExceedingBoundsResult = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(targetDefinition, state);
            Assert.IsTrue(isTargetExceedingBoundsResult);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnTrueForAParentTargetWhichIsExceedingBoundsWithOneChildTargetWhichIsExceedingBounds()
        {
            var childTargetId = new long[] {1};

            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.
                    CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childTargetId);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition childTargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childTargetId[0]);
            TargetDefinitionState childState = new TargetDefinitionState(childTargetDefintion.Id, true, null);

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(childTargetDefintion.Id).Will(
                Return.Value(childTargetDefintion));
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(childTargetDefintion.IdValue).Will(
                Return.Value(childState));

            bool areTargetsExceedingBounds =
                targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsTrue(areTargetsExceedingBounds);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsExceedingBoundsWithOneChildTargetWhichIsNOTExceedingBounds()
        {
            var childTargetId = new long[] {1};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.
                    CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(
                        childTargetId);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition childTargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childTargetId[0]);
            TargetDefinitionState childState = new TargetDefinitionState(childTargetDefintion.Id, false, null);

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(childTargetDefintion.Id).Will(
                Return.Value(childTargetDefintion));
            
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(childTargetDefintion.IdValue).Will(
                Return.Value(childState));

            bool areTargetsExceedingBounds =
                targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsNOTExceedingBoundsWithOneChildTargetWhichIsExceedingBounds()
        {
            var childTargetId = new long[] {1};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childTargetId);
            TargetDefinition childTargetDefintion = TargetDefinitionFixture.CreateATargetWithGenerateActionItemTrue();
            childTargetDefintion.Id = childTargetId[0];
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, false, null);

            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID);
            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsExceedingBoundsWithMoreThanOneChildAndFirstChildThatIsNotExceedingBounds()
        {
            var childIds = new long[] {1, 2, 3, 4};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[0]);
            TargetDefinition child1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[1]);
            TargetDefinition child2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[2]);
            TargetDefinition child3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[3]);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, false, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child1TargetDefintion.Id).Will(Return.Value(child1TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child2TargetDefintion.Id).Will(Return.Value(child2TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child3TargetDefintion.Id).Will(Return.Value(child3TargetDefintion));

            bool areTargetsExceedingBounds =
                targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsExceedingBoundsWithMoreThanOneChildAndLastChildThatIsNotExceedingBounds()
        {
            var childIds = new long[] {1, 2, 3, 4};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[0]);
            TargetDefinition child1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[1]);
            TargetDefinition child2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[2]);
            TargetDefinition child3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[3]);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));

            TargetDefinitionState child1State = new TargetDefinitionState(child1TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child1TargetDefintion.Id).Will(Return.Value(child1State));
            
            TargetDefinitionState child2State = new TargetDefinitionState(child2TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child2TargetDefintion.Id).Will(Return.Value(child2State));

            TargetDefinitionState child3State = new TargetDefinitionState(child3TargetDefintion.Id, false, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child3TargetDefintion.Id).Will(Return.Value(child3State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child1TargetDefintion.Id).Will(Return.Value(child1TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child2TargetDefintion.Id).Will(Return.Value(child2TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child3TargetDefintion.Id).Will(Return.Value(child3TargetDefintion));

            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsNOTExceedingBoundsWithMoreThanOneChildAndAllChildernAreExceedingBounds()
        {
            var childIds = new long[] {1, 2, 3, 4};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, false, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[0]);
            TargetDefinition child1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[1]);
            TargetDefinition child2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[2]);
            TargetDefinition child3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[3]);

            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child1TargetDefintion.Id).Will(Return.Value(child1TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child2TargetDefintion.Id).Will(Return.Value(child2TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child3TargetDefintion.Id).Will(Return.Value(child3TargetDefintion));

            bool areTargetsExceedingBounds =
                targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);

            Assert.IsFalse(areTargetsExceedingBounds);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnTrueForAParentTargetWhichIsExceedingBoundsWithMoreThanOneChildAndAllChildernAreExceedingBounds()
        {
            var childIds = new long[] {1, 2, 3, 4};
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);

            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[0]);
            TargetDefinition child1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[1]);
            TargetDefinition child2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[2]);
            TargetDefinition child3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(childIds[3]);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));

            TargetDefinitionState child1State = new TargetDefinitionState(child1TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child1TargetDefintion.Id).Will(Return.Value(child1State));

            TargetDefinitionState child2State = new TargetDefinitionState(child2TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child2TargetDefintion.Id).Will(Return.Value(child2State));

            TargetDefinitionState child3State = new TargetDefinitionState(child3TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child3TargetDefintion.Id).Will(Return.Value(child3State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child1TargetDefintion.Id).Will(Return.Value(child1TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child2TargetDefintion.Id).Will(Return.Value(child2TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child3TargetDefintion.Id).Will(Return.Value(child3TargetDefintion));

            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsTrue(areTargetsExceedingBounds);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsExceedingBoundsWithOneChildAndTheFirstGrandChildIsNotExceedingBounds()
        {
            var childIds = new long[] {1};
            var grandChildernIds = new long[] {11, 12, 13};
            List<long> associatedTargets = TargetDefinitionFixture.CreateAssociatedTargetIdList(grandChildernIds);

            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);
            
            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateParentTargetDefintion(childIds[0], associatedTargets);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));


            TargetDefinition grandChild1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[0]);
            TargetDefinition grandChild2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[1]);
            TargetDefinition grandChild3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[2]);

            TargetDefinitionState grandchild1State = new TargetDefinitionState(grandChild1TargetDefintion.Id, false, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild1TargetDefintion.Id).Will(Return.Value(grandchild1State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild1TargetDefintion.Id).Will(Return.Value(grandChild1TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild2TargetDefintion.Id).Will(Return.Value(grandChild2TargetDefintion));
            Expect.Never.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild3TargetDefintion.Id).Will(Return.Value(grandChild3TargetDefintion));

            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForAParentTargetWhichIsExceedingBoundsWithOneChildAndTheLastGrandChildIsNotExceedingBounds()
        {
            var childIds = new long[] {1};
            var grandChildernIds = new long[] {11, 12, 13};
            List<long> associatedTargets = TargetDefinitionFixture.CreateAssociatedTargetIdList(grandChildernIds);

            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateParentTargetDefintion(childIds[0], associatedTargets);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));

            TargetDefinition grandChild1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[0]);
            TargetDefinition grandChild2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[1]);
            TargetDefinition grandChild3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[2]);

            TargetDefinitionState grandchild1State = new TargetDefinitionState(grandChild1TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild1TargetDefintion.Id).Will(Return.Value(grandchild1State));

            TargetDefinitionState grandchild2State = new TargetDefinitionState(grandChild2TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild2TargetDefintion.Id).Will(Return.Value(grandchild2State));

            TargetDefinitionState grandchild3State = new TargetDefinitionState(grandChild3TargetDefintion.Id, false, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild3TargetDefintion.Id).Will(Return.Value(grandchild3State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild1TargetDefintion.Id).Will(Return.Value(grandChild1TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild2TargetDefintion.Id).Will(Return.Value(grandChild2TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild3TargetDefintion.Id).Will(Return.Value(grandChild3TargetDefintion));

            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsFalse(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Ignore] [Test]
        public void ShouldReturnTrueForAParentTargetWhichIsExceedingBoundsWithOneChildAndAllGrandChildIsExceedingBounds()
        {
            var childIds = new long[] {1};
            var grandChildernIds = new long[] {11, 12, 13};

            List<long> associatedTargets = TargetDefinitionFixture.CreateAssociatedTargetIdList(grandChildernIds);
            TargetDefinition parentTargetDefintion =
                TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(childIds);
            TargetDefinitionState parentState = new TargetDefinitionState(parentTargetDefintion.Id, true, null);

            TargetDefinition child0TargetDefintion = TargetDefinitionFixture.CreateParentTargetDefintion(childIds[0], associatedTargets);

            TargetDefinitionState child0State = new TargetDefinitionState(child0TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(child0TargetDefintion.Id).Will(Return.Value(child0State));


            TargetDefinition grandChild1TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[0]);
            TargetDefinition grandChild2TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[1]);
            TargetDefinition grandChild3TargetDefintion = TargetDefinitionFixture.CreateTargetDefintion(grandChildernIds[2]);

            TargetDefinitionState grandchild1State = new TargetDefinitionState(grandChild1TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild1TargetDefintion.Id).Will(Return.Value(grandchild1State));

            TargetDefinitionState grandchild2State = new TargetDefinitionState(grandChild2TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild2TargetDefintion.Id).Will(Return.Value(grandchild2State));

            TargetDefinitionState grandchild3State = new TargetDefinitionState(grandChild3TargetDefintion.Id, true, null);
            Expect.Once.On(mockTargetDefinitionStateDao).Method("QueryById").With(grandChild3TargetDefintion.Id).Will(Return.Value(grandchild3State));

            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(child0TargetDefintion.Id).Will(Return.Value(child0TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild1TargetDefintion.Id).Will(Return.Value(grandChild1TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild2TargetDefintion.Id).Will(Return.Value(grandChild2TargetDefintion));
            Expect.Once.On(mockTargetDefinitionDao).Method(QUERY_BY_ID).With(grandChild3TargetDefintion.Id).Will(Return.Value(grandChild3TargetDefintion));

            bool areTargetsExceedingBounds = targetAlertService.IsTargetAndAllAssociatedTargetsExceedingBoundary(parentTargetDefintion, parentState);
            Assert.IsTrue(areTargetsExceedingBounds);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
       
        [Ignore] [Test]
        public void ShouldCreateTargetAlertResponseAndLogEntry()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            Stub.On(mockTimeDao).Method("GetTime").WithAnyArguments().Will(Return.Value(now));

            User currentUser = UserFixture.CreateUser();
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            const string responseText = "Some text";
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            TargetAlertResponse response = alert.CreateResponse(currentUser, responseText, now, shiftPattern);
            response.CreateLog(currentUser, false, ShiftPatternFixture.CreateDayShift(), now,RoleFixture.CreateRole(), null);

            // Expect updating the alert (which could have changed because we created an alert for it):
            Expect.Once.On(mockTargetAlertDao).Method("Update").With(TargetAlert(alert, currentUser));

            // Expect inserting the comment that goes with the response, the response itself, 
            // along with a log entry created from that response:
            Expect.Once.On(mockCommentDao).Method("InsertComment").With(response.ResponseComment).Will(Return.Value(response.ResponseComment));
            Expect.Once.On(mockResponseDao).Method("Insert").With(response).Will(Return.Value(response));
                
            //new ListElementMatcher<LogComment>(0, new OltPropertyMatcher<LogComment>("Text", Is.StringContaining(responseText)))
        
            Expect.Once.On(mockLogService).Method("InsertForTargetAlert")
                .With(new OltPropertyMatcher<Log>("RtfComments", new StringContainsMatcher(responseText)), Is.EqualTo(alert))
                .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            targetAlertService.CreateTargetAlertResponse(response, true, false, currentUser, ShiftPatternFixture.CreateDayShift(), RoleFixture.CreateRole(), null);

            AssertTargetAlertUpdateEventRaised(alert);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateTargetAlertAndFireUpdateEvent()
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();

            Expect.Once.On(mockTargetAlertDao).Method("Update").With(Is.Same(alert));

            // Execute:
            targetAlertService.UpdateTargetAlert(alert);

            AssertTargetAlertUpdateEventRaised(alert);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void QueryTargetAlertNeedingAttentionByTargetDefinitionShouldReturnNullIfNoAssociatedTargetAlerts()
        {
            TargetDefinition target = TargetDefinitionFixture.CreateTargetDefinition();
            var targetAlertList = new List<TargetAlert>();
            
            Expect.Once.On(mockTargetAlertDao).Method("QueryByTargetDefinitionAndStatuses").WithAnyArguments().Will(Return.Value(targetAlertList));
            TargetAlert alertNeedingAttention = targetAlertService.QueryTargetAlertNeedingAttentionByTargetDefinition(target);
            Assert.AreEqual(null, alertNeedingAttention);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void QueryTargetAlertNeedingAttentionByTargetDefinitionShouldReturnOneAssociatedTargetAlert()
        {
            TargetDefinition target = TargetDefinitionFixture.CreateTargetDefinition();
            TargetAlert alert = TargetAlertFixture.CreateTargetAlertFromTargetDefinition(target);
            var targetAlertList = new List<TargetAlert>(new[] { alert });

            Expect.Once.On(
                mockTargetAlertDao).Method(
                "QueryByTargetDefinitionAndStatuses").WithAnyArguments().Will(Return.Value(targetAlertList));
            TargetAlert alertNeedingAttention = targetAlertService.QueryTargetAlertNeedingAttentionByTargetDefinition(target);
            Assert.AreEqual(alert, alertNeedingAttention);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void QueryTargetAlertNeedingAttentionByTargetDefinitionShouldReturnExceptionIfMoreThanOneAssociatedTargetAlert()
        {
            TargetDefinition target = TargetDefinitionFixture.CreateTargetDefinition();
            TargetAlert alert = TargetAlertFixture.CreateTargetAlertFromTargetDefinition(target);
            var targetAlertList = new List<TargetAlert> {alert, alert};

            Expect.Once.On(mockTargetAlertDao).Method("QueryByTargetDefinitionAndStatuses").WithAnyArguments().Will(Return.Value(targetAlertList));
            targetAlertService.QueryTargetAlertNeedingAttentionByTargetDefinition(target);
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        private static Matcher TargetAlert(TargetAlert expectedAlert, User expectedLastModifiedBy)
        {
            return Is.Same(expectedAlert)
                   & new OltPropertyMatcher<TargetAlert>("LastModifiedBy", Is.Same(expectedLastModifiedBy));
        }

        private void AssertTargetAlertUpdateEventRaised(DomainObject alert)
        {
            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(ApplicationEvent.TargetAlertUpdate, queueItems[0].ApplicationEvent);
            Assert.AreEqual(alert.Id, queueItems[0].DomainObject.Id);
        }

        [Ignore] [Test]
        public void ShouldClearTargetAlertsInNeedOfAttentionWhenOperatingModeHasJustChanged()
        {
            User user = UserFixture.CreateAdmin();
            
            var targetAlerts = new List<TargetAlert>();
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            targetAlerts.Add(alert);

            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").Will(Return.Value(user));
            Expect.Once.On(mockTargetAlertDao).Method("QueryAllTargetAlertsNeedingAttention").Will(Return.Value(targetAlerts));
            Expect.Once.On(mockTargetAlertDao).Method("Update").With(Izz.Equals(alert));

            targetAlertService.ClearAllTargetAlertsAtOrBelowFlocs(FunctionalLocationFixture.CreateNewListOfNewItems(1));

            AssertTargetAlertUpdateEventRaised(alert);

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
