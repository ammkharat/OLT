using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ActionItemDefinitionServiceTest
    {
        private ActionItemDefinitionService service;
        private ActionItemDefinition actionItemDefinition;
        private IActionItemDefinitionDao actionItemDefinitionDaoMock;
        private IActionItemDefinitionDTODao actionItemDefinitionDTODaoMock;
        private IShiftPatternDao shiftPatternDaoMock;
        private ISapWorkOrderOperationDao sapWorkOrderOperationDaoMock;
        private const long actionItemIdNonExistentId = 999876987565;
        private Mockery mock;
        private EventQueueTestWrapper eventQueue;
        private ITimeService mockTimeService;
        private IEditHistoryService mockEditHistoryService;
        private ISiteConfigurationDao mockSiteConfigurationDao;
        private IActionItemService mockActionItemService;

        public const string QUERY_BY_ID = "QueryById";
        public const string QUERY_ALL = "QueryAll";
        public const string REMOVE = "Remove";
        public const string UPDATE = "Update";
        public const string INSERT = "Insert";
        public const string REMOVE_ALL_FOR_DEFINITION = "RemoveAllUnrespondedToActionItemsForActionItemDefinition";

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            
            actionItemDefinitionDaoMock = mock.NewMock<IActionItemDefinitionDao>();
            actionItemDefinitionDTODaoMock = mock.NewMock<IActionItemDefinitionDTODao>();
            shiftPatternDaoMock = mock.NewMock<IShiftPatternDao>();
            mockSiteConfigurationDao = mock.NewMock<ISiteConfigurationDao>();
            sapWorkOrderOperationDaoMock = mock.NewMock<ISapWorkOrderOperationDao>();
            mockTimeService = mock.NewMock<ITimeService>();
            mockEditHistoryService = mock.NewMock<IEditHistoryService>();
            mockActionItemService = mock.NewMock<IActionItemService>();

            DaoRegistry.Clear();

            DaoRegistry.RegisterDaoFor(actionItemDefinitionDaoMock);
            DaoRegistry.RegisterDaoFor(actionItemDefinitionDTODaoMock);
            DaoRegistry.RegisterDaoFor(shiftPatternDaoMock);
            DaoRegistry.RegisterDaoFor(sapWorkOrderOperationDaoMock);
            DaoRegistry.RegisterDaoFor(mockSiteConfigurationDao);

            service = new ActionItemDefinitionService(
                mockTimeService, 
                mockEditHistoryService,
                mockActionItemService);
            actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();

            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();          
        }

        [Ignore] [Test]
        public void ShouldTryToSaveActionItem()
        {
            Expect.Once.On(actionItemDefinitionDaoMock).Method(INSERT);
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockEditHistoryService);

            service.Insert(actionItemDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldGetActionItemById()
        {
            Stub.On(actionItemDefinitionDaoMock).Method(INSERT).WithAnyArguments();
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockEditHistoryService);

            service.Insert(actionItemDefinition);
            Expect.Once.On(actionItemDefinitionDaoMock).Method(QUERY_BY_ID).Will(Return.Value(actionItemDefinition));

            ActionItemDefinition actual = service.QueryById(actionItemDefinition.IdValue);

            Assert.IsNotNull(actual);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldGetNullWhenActionItemIdDoesNotExistInDatabase()
        {
            Expect.Once.On(actionItemDefinitionDaoMock).Method(QUERY_BY_ID).Will(Return.Value(null));
            ActionItemDefinition actual = service.QueryById(actionItemIdNonExistentId);
            Assert.IsNull(actual);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldRemoveActionItem()
        {
            Expect.Once.On(actionItemDefinitionDaoMock).Method(QUERY_BY_ID).Will(Return.Value(null));
            Expect.Once.On(actionItemDefinitionDaoMock).Method(REMOVE);
            Stub.On(actionItemDefinitionDaoMock).Method(INSERT).WithAnyArguments();
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockEditHistoryService);
            Expect.Once.On(mockActionItemService).Method(REMOVE_ALL_FOR_DEFINITION).With(actionItemDefinition).Will(Return.Value(new List<NotifiedEvent>()));

            service.Insert(actionItemDefinition);
            service.Remove(actionItemDefinition);
            ActionItemDefinition actual = service.QueryById(actionItemDefinition.IdValue);
            Assert.IsNull(actual);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateActionItem()
        {
            Stub.On(actionItemDefinitionDaoMock).Method(INSERT).WithAnyArguments();
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(mockEditHistoryService);

            service.Insert(actionItemDefinition);
            ActionItemDefinition expected =
                ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(
                    actionItemDefinition.IdValue);

            Expect.Once.On(actionItemDefinitionDaoMock).Method(QUERY_BY_ID).Will(Return.Value(expected));
            Expect.Once.On(actionItemDefinitionDaoMock).Method(UPDATE).WithAnyArguments();

            service.Update(expected);
            ActionItemDefinition actual = service.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(expected, actual);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCallGetCountMethod()
        {
            const string expectedString = "some silly name to search";
            const long expectedSiteId = 1;
            Expect.Once.On(actionItemDefinitionDaoMock).Method("GetCountOfSAPSourced").With(expectedString, expectedSiteId).Will(
                Return.Value(1));
            service.GetCountOfSAPSourced(expectedString, expectedSiteId);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnActionItemDefinitionNameListForAGivenTargetDefinitionId()
        {
            long? targetId = 1;
            const string name1 = "Super Man";
            const string name2 = "Bat Man";

            ActionItemDefinition actionItemDefinitionOne = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinitionOne.Name = name1;
            var dto1 = new ActionItemDefinitionDTO(actionItemDefinitionOne);

            ActionItemDefinition actionItemDefinitionTwo = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinitionTwo.Name = name2;
            var dto2 = new ActionItemDefinitionDTO(actionItemDefinitionTwo);

            var dtos = new List<ActionItemDefinitionDTO> {dto1, dto2};

            Expect.Once.On(actionItemDefinitionDTODaoMock).Method("QueryByTargetDefinitionId").With(targetId).Will(
                Return.Value(dtos));

            var expectedNameList = new List<string> {name1, name2};

            List<string> actualNameList = service.QueryForActionItemNameListByTargetDefinitionId(targetId);

            Assert.AreEqual(expectedNameList, actualNameList);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void WhenInsertingShouldTakeAnEditHistorySnapshot()
        {
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(actionItemDefinitionDaoMock);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(actionItemDefinition);
            service.Insert(actionItemDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void WhenUpdatingShouldTakeAndEditHistorySnapshot()
        {
            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(DateTimeFixture.DateTimeNow));
            Stub.On(actionItemDefinitionDaoMock);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(actionItemDefinition);
            service.Update(actionItemDefinition);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}