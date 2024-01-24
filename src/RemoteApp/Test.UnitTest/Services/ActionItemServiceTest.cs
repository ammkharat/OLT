using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ActionItemServiceTest
    {
        private Mockery mock;
        
        private IActionItemDao mockActionItemDao;
        private IActionItemDTODao mockActionItemDtoDao;
        private ISiteConfigurationDao mockSiteConfigurationDao;        

        private IActionItemService actionItemService;
        private ActionItem actionItem;
        private ILogService mockLogService;
        private ITimeService mockTimeService;

        private EventQueueTestWrapper eventQueue;
        private IUserService mockUserService;
        private IActionItemDefinitionDao mockActionItemDefinitionDao;

        private const string INSERT = "Insert";

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockActionItemDao = mock.NewMock<IActionItemDao>();
            mockActionItemDtoDao = mock.NewMock<IActionItemDTODao>();
            mockActionItemDefinitionDao = mock.NewMock<IActionItemDefinitionDao>();
            mockSiteConfigurationDao = mock.NewMock<ISiteConfigurationDao>();            
            
            mockLogService = mock.NewMock<ILogService>();
            mockTimeService = mock.NewMock<ITimeService>();
            mockUserService = mock.NewMock<IUserService>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockActionItemDao);
            DaoRegistry.RegisterDaoFor( mockActionItemDtoDao);
            DaoRegistry.RegisterDaoFor( mockSiteConfigurationDao);            
            DaoRegistry.RegisterDaoFor( mockActionItemDefinitionDao);            

            eventQueue = new EventQueueTestWrapper();

            actionItemService = new ActionItemService(mockLogService, mockTimeService, mockUserService);
            actionItem = ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId();            
        }

        [TearDown]
        public void TearDown()
        {            
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldCallInsertOnActionItem()
        {
            Expect.Once.On(mockActionItemDao).Method(INSERT);
            actionItemService.Insert(actionItem);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void CallingUpdateShouldUpdateActionItemRespondFormPresenterAndInsertAnAssociatedLogEntry()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            ActionItem actionitem = ActionItemFixture.CreateACompleteActionItemWithFlocListAndNoId();
            actionitem.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            actionitem.LastModifiedDate = now;

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();

            const string logComments = "Comments for log";
            Log expectedLog = LogFixture.CreateLogFromActionItem(actionitem, logComments, RoleFixture.CreateOperatorRole(), shiftPattern, now);
            expectedLog.LastModifiedDate = now;

            Expect.Once.On(mockActionItemDao).Method("Update").With(actionitem);
            Expect.Exactly(1).On(mockLogService).Method("InsertForActionItem")
                .With(expectedLog, actionitem)
                .Will(Return.Value(new List<NotifiedEvent>()));

            Stub.On(mockTimeService).Method("GetTime").WithAnyArguments().Will(Return.Value(now));
            
            actionItemService.Update(actionitem, logComments, shiftPattern,
                                     expectedLog.IsOperatingEngineerLog, null, RoleFixture.CreateOperatorRole());
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void WhenQueryingDtosByFunctionalLocationsAndDateRangesShouldSelectAllStatusActionItemDtosByDateRange()
        {
            var range = new Range<Date>(new Date(2006, 01, 01), new Date(2006, 06, 05));
            List<FunctionalLocation> relevantFlocs = new List<FunctionalLocation>();
            RootFlocSet flocSet = new RootFlocSet(relevantFlocs);
            var expectedActionItems = new List<ActionItemDTO>();

            Expect.Once.On(mockActionItemDtoDao).Method("QueryByFunctionalLocationsAndStatusAndDateRange")
                .With(flocSet, ActionItemStatus.AvailableForCurrentView, range.LowerBound.CreateDateTime(Time.START_OF_DAY), range.UpperBound.CreateDateTime(Time.END_OF_DAY), null)
                .Will(Return.Value(expectedActionItems));
            
            List<ActionItemDTO> retrievedActionItems =
                actionItemService.QueryDTOsByFunctionalLocationsAndDateRange(flocSet, ActionItemStatus.AvailableForCurrentView, range, null);

            Assert.AreEqual(expectedActionItems, retrievedActionItems);
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldClearActionItemsWhenOperatingModeHasJustChanged()
        {
            User user = UserFixture.CreateAdmin();

            var actionItems = new List<ActionItem>();
            ActionItem actionitem = ActionItemFixture.Create();
            actionItems.Add(actionitem);

            List<FunctionalLocation> flocs = FunctionalLocationFixture.CreateNewListOfNewItems(1);

            Expect.Once.On(mockUserService).Method("GetRemoteAppUser").Will(Return.Value(user));
            Expect.Once.On(mockTimeService).Method("GetTime").With(flocs[0].Site.TimeZone).Will(Return.Value(DateTimeFixture.DateTimeNow));
            Expect.Once.On(mockActionItemDao).Method("QueryAllActionItemsNeedingAttention").Will(Return.Value(actionItems));
            Expect.Once.On(mockActionItemDao).Method("Update").With(actionitem);

            actionItemService.ClearActionItemsAtOrBelowFlocs(flocs);

            AssertUpdateEventRaised(actionitem);
        }

        private static ActionItemDTO CreateActionItemDTO(long id)
        {
            ActionItemDTO dto = ActionItemDTOFixture.CreateActionItemDto();
            dto.Id = id;
            return dto;
        }

        private void AssertUpdateEventRaised(DomainObject updatedActionItem)
        {
            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(1, queueItems.Count);
            Assert.AreEqual(ApplicationEvent.ActionItemUpdate, queueItems[0].ApplicationEvent);
            Assert.AreEqual(updatedActionItem.Id, queueItems[0].DomainObject.Id);
        }
    }
}
