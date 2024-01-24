using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class ActionItemDTODaoTest : AbstractDaoTest
    {
        private IActionItemDTODao actionItemDTODao;
        private List<FunctionalLocation> flocList;
        private IActionItemDao actionItemDao;

        private IFormGN75BDao formGN75BDao;

        protected override void TestInitialize()
        {
            actionItemDTODao = DaoRegistry.GetDao<IActionItemDTODao>();
            actionItemDao = DaoRegistry.GetDao<IActionItemDao>();
            formGN75BDao = DaoRegistry.GetDao<IFormGN75BDao>();

            FunctionalLocation flocInDB = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            flocList = new List<FunctionalLocation>{flocInDB};
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void QueryReturnsAllActionItemsAfterMarch16_2006()
        {
            ActionItem actionItem1 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 03, 14));
            actionItem1.EndDateTime = new DateTime(2006, 03, 15);
            ActionItem actionItem2 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 03, 16));
            actionItem2.EndDateTime = DateTimeFixture.DateTimeNow;
            actionItemDao.Insert(actionItem1);
            actionItemDao.Insert(actionItem2);
            Date startDate = new Date(2006, 03, 16);
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(flocList), ActionItemStatus.AvailableForCurrentView, startDate.CreateDateTime(Time.START_OF_DAY), null, null);
            Assert.That(dtos, Is.Not.Empty);

            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem2.Id));
            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem1.Id));

            foreach(ActionItemDTO dto in dtos)
            {
                Assert.IsTrue(new Date(dto.StartDate) >= startDate);
                Assert.IsNotNull(dto.CategoryName);                
            }            
        }

        [Ignore] [Test]
        public void VariousQueries_VaryVisibilityGroups()
        {
            IWorkAssignmentDao workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            IVisibilityGroupDao visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();

            VisibilityGroup chapsVisibilityGroup = new VisibilityGroup(-1, "Chaps Department", Site.SARNIA_ID, false);
            VisibilityGroup horseshoeVisibilityGroup = new VisibilityGroup(-1, "Horseshoe Department", Site.SARNIA_ID, false);

            visibilityGroupDao.Insert(chapsVisibilityGroup);
            visibilityGroupDao.Insert(horseshoeVisibilityGroup);

            WorkAssignment horseAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Horse Supervisor"));
            WorkAssignment clothingAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Cowboy Clothing Supervisor"));

            // horse supervisor can read info about chaps and horseshoes, but can only write about horseshoes
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup1 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup2 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup3 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            // cowboy clothing supervisor can read info about chaps and horseshoes, but can only write about chaps
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup4 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup5 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup6 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup1);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup2);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup3);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup4);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup5);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup6);

            Clock.Freeze();
            Clock.Now = Clock.Now.RollBackward(new Time(10, 0, 0));
            DateTime now = Clock.Now;

            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            ActionItem actionItem1 = CreateActionItem(functionalLocation, ActionItemStatus.Current, now);
            actionItem1.EndDateTime = now.AddDays(1);
            actionItem1.Assignment = horseAssignment;
            actionItemDao.Insert(actionItem1);

            ActionItem actionItem2 = CreateActionItem(functionalLocation, ActionItemStatus.Current, now);
            actionItem2.EndDateTime = now.AddDays(1);
            actionItem2.Assignment = clothingAssignment;
            actionItemDao.Insert(actionItem2);

            ActionItem actionItem3 = CreateActionItem(functionalLocation, ActionItemStatus.Current, now);
            actionItem3.EndDateTime = now.AddDays(1);
            actionItem3.Assignment = null;
            actionItemDao.Insert(actionItem3);

            DateRange queryDateRange = new DateRange(now.AddDays(-1).ToDate(), now.AddDays(1).ToDate());
            RootFlocSet queryFlocSet = new RootFlocSet(functionalLocation);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            UserShift userShift = new UserShift(shiftPattern, now);

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };

                List<ActionItemDTO> results1 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results2 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, clothingAssignment, visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == actionItem2.Id));

                List<ActionItemDTO> results3 = actionItemDTODao.QueryByPriorityPageCriteria(queryFlocSet, new List<ActionItemStatus>(ActionItemStatus.AvailableForCurrentView), queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, queryDateRange.SqlFriendlyStart.AddDays(-1), false, null, visibilityGroupIds);
                Assert.AreEqual(2, results3.Count);
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results4 = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(queryFlocSet, queryDateRange.SqlFriendlyStart, userShift, visibilityGroupIds);
                Assert.AreEqual(2, results4.Count);
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results5 = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(queryFlocSet, clothingAssignment, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(1, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == actionItem2.Id));

                List<ActionItemDTO> results6 = actionItemDTODao.QueryByParentFunctionalLocationsAndDateRange(queryFlocSet, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(2, results6.Count);
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem3.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };
                List<ActionItemDTO> results1 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results2 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, horseAssignment, visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == actionItem1.Id));

                List<ActionItemDTO> results3 = actionItemDTODao.QueryByPriorityPageCriteria(queryFlocSet, new List<ActionItemStatus>(ActionItemStatus.AvailableForCurrentView), queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, queryDateRange.SqlFriendlyStart.AddDays(-1), false, null, visibilityGroupIds);
                Assert.AreEqual(2, results3.Count);
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results4 = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(queryFlocSet, queryDateRange.SqlFriendlyStart, userShift, visibilityGroupIds);
                Assert.AreEqual(2, results4.Count);
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results5 = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(queryFlocSet, horseAssignment, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(1, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == actionItem1.Id));

                List<ActionItemDTO> results6 = actionItemDTODao.QueryByParentFunctionalLocationsAndDateRange(queryFlocSet, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(2, results6.Count);
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };
                List<ActionItemDTO> results1 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, visibilityGroupIds);

                Assert.AreEqual(3, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results2 = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(queryFlocSet, ActionItemStatus.AvailableForCurrentView, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, clothingAssignment, visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == actionItem2.Id));

                List<ActionItemDTO> results3 = actionItemDTODao.QueryByPriorityPageCriteria(queryFlocSet, new List<ActionItemStatus>(ActionItemStatus.AvailableForCurrentView), queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, queryDateRange.SqlFriendlyStart.AddDays(-1), false, null, visibilityGroupIds);
                Assert.AreEqual(3, results3.Count);
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results4 = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(queryFlocSet, queryDateRange.SqlFriendlyStart, userShift, visibilityGroupIds);
                Assert.AreEqual(3, results4.Count);
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results3.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results4.Exists(dto => dto.Id == actionItem3.Id));

                List<ActionItemDTO> results5 = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(queryFlocSet, clothingAssignment, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(1, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == actionItem2.Id));

                List<ActionItemDTO> results6 = actionItemDTODao.QueryByParentFunctionalLocationsAndDateRange(queryFlocSet, now.AddHours(-1), now.AddHours(1), visibilityGroupIds);
                Assert.AreEqual(3, results6.Count);
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem1.Id));
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem2.Id));
                Assert.IsTrue(results6.Exists(dto => dto.Id == actionItem3.Id));
            }
        }

        [Ignore] [Test]
        public void QueryReturnsAllActionItemsAfterMarch16_2006BeforeApril15_2006()
        {
            ActionItem actionItem1 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 03, 15));
            actionItem1.EndDateTime = new DateTime(2006, 03, 15);
            ActionItem actionItem2 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 03, 16));
            actionItem2.EndDateTime = new DateTime(2006, 03, 18);
            ActionItem actionItem3 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 04, 15));
            actionItem3.EndDateTime = new DateTime(2006, 04, 17);
            ActionItem actionItem4 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 04, 16));
            actionItemDao.Insert(actionItem1);
            actionItemDao.Insert(actionItem2);
            actionItemDao.Insert(actionItem3);
            actionItemDao.Insert(actionItem4);
            Date startDate = new Date(2006, 03, 16);
            Date endDate = new Date(2006, 04, 15);
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(flocList), ActionItemStatus.AvailableForCurrentView, startDate.CreateDateTime(Time.START_OF_DAY), endDate.CreateDateTime(Time.END_OF_DAY), null);
            Assert.IsTrue(dtos.Count > 0);

            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem1.Id));
            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem2.Id));
            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem3.Id));
            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem4.Id));

            foreach(ActionItemDTO dto in dtos)
            {
                Assert.IsTrue(new Date(dto.StartDate) >= startDate);
                Assert.IsTrue(new Date(dto.StartDate) <= endDate);
            }
        }

        [Ignore] [Test]
        public void QueryReturnsAllPendingAndIncompleteActionItems()
        {
            ActionItem actionItem1 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 04, 15));
            ActionItem actionItem2 = CreateActionItem(flocList[0], ActionItemStatus.Complete, new DateTime(2006, 04, 15));
            ActionItem actionItem3 = CreateActionItem(flocList[0], ActionItemStatus.CannotComplete, new DateTime(2006, 04, 15));
            ActionItem actionItem4 = CreateActionItem(flocList[0], ActionItemStatus.Incomplete, new DateTime(2006, 04, 15));
            actionItemDao.Insert(actionItem1);
            actionItemDao.Insert(actionItem2);
            actionItemDao.Insert(actionItem3);
            actionItemDao.Insert(actionItem4);
            ActionItemStatus[] statuses = new[] {ActionItemStatus.Current, ActionItemStatus.Incomplete};
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(flocList), statuses, new DateTime(1975, 1, 1), null, null);
            Assert.IsTrue(dtos.Count > 0);

            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem1.Id));
            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem2.Id));
            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem3.Id));
            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem4.Id));

            foreach(ActionItemDTO dto in dtos)
            {
                Assert.IsTrue(new List<ActionItemStatus>(statuses).Contains(ActionItemStatus.Get(dto.StatusId)));
            }
        }

        [Ignore] [Test]
        public void QueryReturnsAllActionItemsWithSpecifiedFloc()
        {
            flocList = FunctionalLocationFixture.GetListWith2Units();
            ActionItem actionItem1 = CreateActionItem(flocList[0], ActionItemStatus.Current, new DateTime(2006, 04, 15));
            ActionItem actionItem2 = CreateActionItem(flocList[1], ActionItemStatus.Complete, new DateTime(2006, 04, 15));
            actionItemDao.Insert(actionItem1);
            actionItemDao.Insert(actionItem2);
            flocList.Remove(flocList[1]);
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(flocList), ActionItemStatus.AvailableForCurrentView, new DateTime(1975, 1, 1), null, null);
            Assert.IsTrue(dtos.Count > 0);

            Assert.IsTrue(dtos.Exists(obj => obj.Id == actionItem1.Id));
            Assert.IsFalse(dtos.Exists(obj => obj.Id == actionItem2.Id));
            Assert.IsTrue(dtos.TrueForAll(obj => obj.FunctionalLocationNames  == actionItem1.FunctionalLocationsAsCommaSeparatedFullHierarchyList));
        }

        [Ignore] [Test]
        public void ShouldReturnAllDtosWithChildFlocWhenUserIsLoggedInAt4thLevelParentFloc()
        {
            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB_02AC009();

            ActionItem actionItem = CreateActionItem(fifthLevelFloc, ActionItemStatus.Current, new DateTime(2006, 04, 15));
            actionItemDao.Insert(actionItem);
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(fourthLevelFloc), ActionItemStatus.AvailableForCurrentView, new DateTime(1975, 1, 1), null, null);

            Assert.AreEqual(1, dtos.Count);
            Assert.IsTrue(dtos.Exists(dto => dto.Id == actionItem.Id));
        }

        [Ignore] [Test]
        public void ShouldReturnAllFlocsWhenOnlyOneMatchesSearchCriteriaWhenQueryingByStatusAndDateRange()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SMF();

            ActionItem actionItem = CreateActionItem(floc1, ActionItemStatus.Current, new DateTime(2006, 04, 15));
            actionItem.FunctionalLocations.Add(floc2);
            actionItemDao.Insert(actionItem);

            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(
                new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()),
                ActionItemStatus.AvailableForCurrentView, new DateTime(1975, 1, 1), null, null);

            ActionItemDTO dto = dtos.Find(obj => obj.Id == actionItem.Id);
            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.FunctionalLocationNames.Contains(floc1.FullHierarchy));
            Assert.IsTrue(dto.FunctionalLocationNames.Contains(floc2.FullHierarchy));
        }

        [Ignore] [Test]
        public void QueryReturnsAllActionItemsWithSpecifiedFlocAndWorkAssignment()
        {
            FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal(
                    "EX1-OPLT-TOOL-SWM-LIFTING_DEVICES");

            WorkAssignment workAssignment = WorkAssignmentFixture.CreateUnitLeader();
            flocList = new List<FunctionalLocation> { unitFloc, floc1 };
            ActionItem actionItem1 = CreateActionItem(floc1, ActionItemStatus.Current, new DateTime(2006, 04, 15));
            actionItem1.Assignment = null;
            ActionItem actionItem2 = CreateActionItem(floc1, ActionItemStatus.Current, new DateTime(2006, 04, 15));            
            actionItem2.Assignment = workAssignment;
            actionItemDao.Insert(actionItem1);
            actionItemDao.Insert(actionItem2);

            List<ActionItemDTO> dtos =
                actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(
                    new RootFlocSet(flocList), ActionItemStatus.AvailableForCurrentView, new DateTime(1975, 1, 1), null, workAssignment, null);

            Assert.IsTrue(dtos.Count > 0);

            Assert.That(dtos, Has.None.Property("Id").EqualTo(actionItem1.Id));
            Assert.That(dtos, Has.Some.Property("Id").EqualTo(actionItem2.Id));            
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndStatusAndDateRangeShouldReturnPriorityForActionItem()
        {
            flocList = FunctionalLocationFixture.GetListWith2Units();
            ActionItem actionItem = CreateActionItem(flocList[0], ActionItemStatus.Current,
                                                     new DateTime(2006, 04, 15), Priority.Elevated);
            actionItemDao.Insert(actionItem);
            List<ActionItemDTO> retrievedActionItems =
                    actionItemDTODao.QueryByFunctionalLocationsAndStatusAndDateRange(new RootFlocSet(flocList), ActionItemStatus.AvailableForCurrentView, new DateTime(1975, 1, 1), null, null);

            Assert.That(retrievedActionItems, Has.Some.Property("Id").EqualTo(actionItem.Id));
            Assert.That(retrievedActionItems, Has.Some.Property("Priority").EqualTo(Priority.Elevated));
        }
        
        [Ignore] [Test]
        public void QueryByShiftOrResponseRequiredShouldReturnOnlyActionItemDTOsForCurrentShift()
        {
            flocList = FunctionalLocationFixture.GetListWith2Units();
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            ActionItem actionItem = CreateActionItem(flocList[0], shiftPattern,
                                         new Date(2005, 11, 25));
            actionItem.ResponseRequired = false;
            ActionItem actionItemFromOlderShift = CreateActionItem(flocList[0], shiftPattern,
                                            new Date(2004, 11, 23));
            actionItemFromOlderShift.ResponseRequired = false;
            DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
            Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));

            UserShift userShift = new UserShift(shiftPattern, currentDateTime);
            actionItemDao.Insert(actionItem);
            actionItemDao.Insert(actionItemFromOlderShift);
            List<ActionItemDTO> returnedDTOs = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(new RootFlocSet(flocList), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null);

            Assert.That(returnedDTOs, Has.Some.Property("Id").EqualTo(actionItem.Id));
            Assert.That(returnedDTOs, Has.None.Property("Id").EqualTo(actionItemFromOlderShift.Id));
        }

        
        [Ignore] [Test]
        public void ShouldReturnAllFlocsWhenOnlyOneMatchesSearchCriteriaWhenQueryingByShift()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SMF();

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            ActionItem actionItem = CreateActionItem(floc1, shiftPattern, new Date(2005, 11, 25));
            actionItem.FunctionalLocations.Add(floc2);
            actionItem.ResponseRequired = false;
            actionItemDao.Insert(actionItem);

            DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
            Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));
            UserShift userShift = new UserShift(shiftPattern, currentDateTime);

            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(
                new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()),
                startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null);

            ActionItemDTO dto = dtos.Find(obj => obj.Id == actionItem.Id);
            Assert.IsNotNull(dto);
            Assert.IsTrue(dto.FunctionalLocationNames.Contains(floc1.FullHierarchy));
            Assert.IsTrue(dto.FunctionalLocationNames.Contains(floc2.FullHierarchy));
        }

        [Ignore] [Test]
        public void ShouldReturnAllActionItemsWithChildFlocWhenQueryingAgainstFourthLevelParentFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB_02AC009();

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            ActionItem actionItem = CreateActionItem(floc2, shiftPattern, new Date(2005, 11, 25));
            actionItem.ResponseRequired = false;
            actionItemDao.Insert(actionItem);

            DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
            Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));
            UserShift userShift = new UserShift(shiftPattern, currentDateTime);
            
            List<ActionItemDTO> dtos = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(
                new RootFlocSet(floc1), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null);

            Assert.AreEqual(1, dtos.Count);
            Assert.IsTrue(dtos.Exists(dto => dto.Id == actionItem.Id));
        }

        [Ignore] [Test]
        public void QueryByWorkAssignmentShiftOrResponseRequiredShouldReturnOnlyActionItemDTOsForCurrentShift()
        {
            flocList = FunctionalLocationFixture.GetListWith2Units();

            // null work assignment
            {                
                ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
                ActionItem actionItem = CreateActionItem(flocList[0], shiftPattern, new Date(2005, 11, 25));
                actionItem.ResponseRequired = false;

                DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
                Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));

                UserShift userShift = new UserShift(shiftPattern, currentDateTime);
                actionItemDao.Insert(actionItem);
                List<ActionItemDTO> returnedDTOs =
                    actionItemDTODao.
                        QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
                            new RootFlocSet(flocList), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null, null);

                Assert.That(returnedDTOs, Has.Some.Property("Id").EqualTo(actionItem.Id));
            }

            // user has null work assignment, action item has assignment
            {               
                ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
                ActionItem actionItem = CreateActionItem(flocList[0], shiftPattern, new Date(2005, 11, 25));
                actionItem.ResponseRequired = false;
                actionItem.Assignment = WorkAssignmentFixture.CreateShiftEngineer();

                DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
                Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));

                UserShift userShift = new UserShift(shiftPattern, currentDateTime);
                actionItemDao.Insert(actionItem);
                List<ActionItemDTO> returnedDTOs =
                    actionItemDTODao.
                        QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
                            new RootFlocSet(flocList), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null, null);
               
                Assert.That(returnedDTOs, Has.None.Property("Id").EqualTo(actionItem.Id));
            }

            // user has assignment work assignment, action item has assignment
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.CreateShiftEngineer();
                ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
                ActionItem actionItem = CreateActionItem(flocList[0], shiftPattern, new Date(2005, 11, 25));
                actionItem.ResponseRequired = false;
                                
                actionItem.Assignment = workAssignment;

                DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
                Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(7));

                UserShift userShift = new UserShift(shiftPattern, currentDateTime);
                actionItemDao.Insert(actionItem);
                List<ActionItemDTO> returnedDTOs =
                    actionItemDTODao.
                        QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
                            new RootFlocSet(flocList), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, workAssignment, null);

                Assert.That(returnedDTOs, Has.Some.Property("Id").EqualTo(actionItem.Id));
            }
        }

        [Ignore] [Test]
        public void QueryByShiftOrResponseRequiredShouldReturnActionItemIfResponseIsRequired()
        {
            flocList = FunctionalLocationFixture.GetListWith2Units();
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            ActionItem actionItemFromOlderShiftWithResponseRequired = CreateActionItem(flocList[0], shiftPattern,
                                            new Date(2005, 10, 23));
            actionItemFromOlderShiftWithResponseRequired.ResponseRequired = true;
            DateTime currentDateTime = new DateTime(2005, 11, 25, 9, 0, 0);
            Date startDateRangeBegin = new Date(currentDateTime.SubtractDays(60));

            UserShift userShift = new UserShift(shiftPattern, currentDateTime);

            actionItemDao.Insert(actionItemFromOlderShiftWithResponseRequired);
            List<ActionItemDTO> returnedDTOs = actionItemDTODao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(new RootFlocSet(flocList), startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, null);

            Assert.That(returnedDTOs, Has.Some.Property("Id").EqualTo(actionItemFromOlderShiftWithResponseRequired.Id));
        }

        [Ignore] [Test]
        public void ShouldBeAbleToQueryByParentFloc()
        {
            FunctionalLocation sr1Plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation sr1Plt3HyduSch = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation sr1Plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            DateTime now = DateTime.Now;

            // vary flocs
            {
                ActionItem actionItemA = CreateActionItem(sr1Plt3Hydu, ActionItemStatus.Current, now);
                ActionItem actionItemB = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                ActionItem actionItemC = CreateActionItem(sr1Plt3Gen3, ActionItemStatus.Current, now);
                actionItemDao.Insert(actionItemA);
                actionItemDao.Insert(actionItemB);
                actionItemDao.Insert(actionItemC);

                List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                    new RootFlocSet(sr1Plt3Hydu),
                    null,
                    now.AddHours(-1),
                    now.AddHours(1),
                    null
                    );

                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));
                Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemC.Id));
            }

            // vary work assignment
            {
                ActionItem actionItemA = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                actionItemA.Assignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
                ActionItem actionItemB = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                actionItemB.Assignment = null;
                actionItemDao.Insert(actionItemA);
                actionItemDao.Insert(actionItemB);

                List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                    new RootFlocSet(sr1Plt3Hydu),
                    null,
                    now.AddHours(-1),
                    now.AddHours(1),
                    null
                    );

                Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));

                actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                    new RootFlocSet(sr1Plt3Hydu),
                    actionItemA.Assignment,
                    now.AddHours(-1),
                    now.AddHours(1),
                    null
                    );

                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));
            }

            // vary start datetime
            {
                ActionItem actionItemA = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                ActionItem actionItemB = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now.AddHours(2));
                actionItemDao.Insert(actionItemA);
                actionItemDao.Insert(actionItemB);

                {
                    List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                        new RootFlocSet(sr1Plt3Hydu),
                        null,
                        now.AddHours(-1),
                        now.AddHours(1),
                        null
                        );
                    Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                    Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));

                }
                {
                    List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                        new RootFlocSet(sr1Plt3Hydu),
                        actionItemA.Assignment,
                        now.AddHours(1),
                        now.AddHours(3),
                        null
                        );
                    Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                    Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));
                }
                {
                    List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                        new RootFlocSet(sr1Plt3Hydu),
                        actionItemA.Assignment,
                        actionItemA.StartDateTime,
                        actionItemA.StartDateTime.AddSeconds(1),
                        null
                        );
                    Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                }
                {
                    List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                        new RootFlocSet(sr1Plt3Hydu),
                        actionItemA.Assignment,
                        actionItemA.StartDateTime,
                        actionItemA.StartDateTime,
                        null
                        );
                    Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                }
            }
        }

        [Ignore] [Test]
        public void ShouldBeAbleToQueryByParentFlocButNotWorkAssignment()
        {
            FunctionalLocation sr1Plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation sr1Plt3HyduSch = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation sr1Plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            DateTime now = DateTime.Now;

            // vary flocs
            {
                ActionItem actionItemA = CreateActionItem(sr1Plt3Hydu, ActionItemStatus.Current, now);
                ActionItem actionItemB = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                ActionItem actionItemC = CreateActionItem(sr1Plt3Gen3, ActionItemStatus.Current, now);
                actionItemDao.Insert(actionItemA);
                actionItemDao.Insert(actionItemB);
                actionItemDao.Insert(actionItemC);

                List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndDateRange(new RootFlocSet(sr1Plt3Hydu), now.AddHours(-1), now.AddHours(1), null);

                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemA.Id));
                Assert.IsTrue(actionItemDtos.Exists(dto => dto.Id == actionItemB.Id));
                Assert.IsFalse(actionItemDtos.Exists(dto => dto.Id == actionItemC.Id));
            }

        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_VaryDates()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            ActionItemStatus status = ActionItemStatus.Current;

            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            DateTime end = new DateTime(2001, 5, 15, 13, 0, 0);
            ActionItem actionItem = InsertActionItem(start, end, status, floc);

            AssertQueryByPriorityPageCriteria_VaryDates(false, start.AddMinutes(-1), start.AddMinutes(-1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(-1), start, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(-1), start.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(-1), end.AddMinutes(-1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(-1), end, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(-1), end.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start, start, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start, start.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start, end.AddMinutes(-1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start, end, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start, end.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(1), start.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(1), end.AddMinutes(-1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(1), end, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, start.AddMinutes(1), end.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, end.AddMinutes(-1), end.AddMinutes(-1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, end.AddMinutes(-1), end, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, end.AddMinutes(-1), end.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, end, end, actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(true, end, end.AddMinutes(1), actionItem);
            AssertQueryByPriorityPageCriteria_VaryDates(false, end.AddMinutes(1), end.AddMinutes(1), actionItem);
        }

        private void AssertQueryByPriorityPageCriteria_VaryDates(bool expected, DateTime from, DateTime to, ActionItem actionItem)
        {
            List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(
                new RootFlocSet(actionItem.FunctionalLocations[0]), 
                new List<ActionItemStatus> { actionItem.Status },
                from, to, 
                actionItem.StartDateTime.AddDays(-1), false, null, null);
            Assert.AreEqual(expected, results.Exists(obj => obj.Id == actionItem.Id));
        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_VaryNoEndDate()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            ActionItemStatus status = ActionItemStatus.Current;

            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            ActionItem actionItem1 = InsertActionItem(start, DateTime.MaxValue, status, floc);
            ActionItem actionItem2 = InsertActionItem(start, null, status, floc);

            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { status },
                    start, start.AddDays(1), start.AddMinutes(-1), false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { status },
                    start, start.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { status },
                    start, start.AddDays(1), start.AddMinutes(1), false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_VaryStatus()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();

            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            DateTime end = new DateTime(2001, 5, 15, 20, 0, 0);
            ActionItem actionItem1 = InsertActionItem(start, end, ActionItemStatus.Current, floc);
            ActionItem actionItem2 = InsertActionItem(start, end, ActionItemStatus.Complete, floc);

            {
                List<ActionItemStatus> statuses = new List<ActionItemStatus> { ActionItemStatus.Current, ActionItemStatus.Complete, ActionItemStatus.CannotComplete };
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), statuses, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemStatus> statuses = new List<ActionItemStatus> { ActionItemStatus.Current, ActionItemStatus.CannotComplete };
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), statuses, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemStatus> statuses = new List<ActionItemStatus> { ActionItemStatus.Complete, ActionItemStatus.CannotComplete };
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), statuses, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemStatus> statuses = new List<ActionItemStatus> { ActionItemStatus.CannotComplete };
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), statuses, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_ByUnitFloc_VaryFlocs()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB_02AC009();

            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            DateTime end = new DateTime(2001, 5, 15, 20, 0, 0);
            ActionItem actionItem2 = InsertActionItem(start, end, ActionItemStatus.Current, floc2);
            ActionItem actionItem3 = InsertActionItem(start, end, ActionItemStatus.Current, floc3);
            ActionItem actionItem4 = InsertActionItem(start, end, ActionItemStatus.Current, floc4);

            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1, floc2, floc3 };
                RootFlocSet flocSet = new RootFlocSet(flocs);
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(flocSet, new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem4.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1 };
                RootFlocSet flocSet = new RootFlocSet(flocs);
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(flocSet, new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem4.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc2 };
                RootFlocSet flocSet = new RootFlocSet(flocs);
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(flocSet, new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem4.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc3 };
                RootFlocSet flocSet = new RootFlocSet(flocs);
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(flocSet, new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem4.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc4 };
                RootFlocSet flocSet = new RootFlocSet(flocs);
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(flocSet, new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem4.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_VaryWorkAssignment()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            DateTime end = new DateTime(2001, 5, 15, 20, 0, 0);

            WorkAssignment workAssignment1 = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment workAssignment2 = WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            ActionItem actionItem1 = InsertActionItem(null, start, end, ActionItemStatus.Current, floc);
            ActionItem actionItem2 = InsertActionItem(workAssignment1, start, end, ActionItemStatus.Current, floc);

            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start, 
                    false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start,
                    false, workAssignment1, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start,
                    false, workAssignment2, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start,
                    true, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start,
                    true, workAssignment1, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem2.Id));
            }
            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { ActionItemStatus.Current }, start.AddDays(-1), end.AddDays(1), start,
                    true, workAssignment2, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByPriorityPageCriteria_VaryDeleted()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            DateTime start = new DateTime(2001, 5, 15, 8, 0, 0);
            DateTime end = new DateTime(2001, 5, 15, 20, 0, 0);
            ActionItem actionItem = InsertActionItem(start, end, ActionItemStatus.Current, floc);

            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { actionItem.Status }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem.Id));
            }

            actionItemDao.Remove(actionItem);

            {
                List<ActionItemDTO> results = actionItemDTODao.QueryByPriorityPageCriteria(new RootFlocSet(floc), new List<ActionItemStatus> { actionItem.Status }, start.AddDays(-1), end.AddDays(1), start, false, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldGetFlocDescriptions()
        {
            FunctionalLocation sr1Plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation sr1Plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation sr1Plt3HyduSch = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation sr1Plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            DateTime now = DateTime.Now;

            {
                ActionItem actionItemA = CreateActionItem(sr1Plt3Hydu, ActionItemStatus.Current, now);
                actionItemA.FunctionalLocations.Add(sr1Plt3Gen3);
                actionItemDao.Insert(actionItemA);

                ActionItem actionItemB = CreateActionItem(sr1Plt3HyduSch, ActionItemStatus.Current, now);
                actionItemDao.Insert(actionItemB);

                List<ActionItemDTO> actionItemDtos = actionItemDTODao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                    new RootFlocSet(sr1Plt3),
                    null,
                    now.AddHours(-1),
                    now.AddHours(1),
                    null
                    );

                // With good test data this will fluctuate based on when was the last time the user did a dbInit
//                Assert.AreEqual(10, actionItemDtos.Count);

                ActionItemDTO dtoA = actionItemDtos.Find(dto => dto.Id == actionItemA.Id);
                Assert.AreEqual(String.Format("{0}, {1}", sr1Plt3Gen3.FullHierarchy, sr1Plt3Hydu.FullHierarchy), dtoA.FunctionalLocationNames);
                Assert.AreEqual(String.Format("{0}, {1}", sr1Plt3Gen3.FullHierarchyWithDescription, sr1Plt3Hydu.FullHierarchyWithDescription), dtoA.FunctionalLocationNamesWithDescription);

                ActionItemDTO dtoB = actionItemDtos.Find(dto => dto.Id == actionItemB.Id);
                Assert.AreEqual(sr1Plt3HyduSch.FullHierarchy, dtoB.FunctionalLocationNames);
                Assert.AreEqual(sr1Plt3HyduSch.FullHierarchyWithDescription, dtoB.FunctionalLocationNamesWithDescription);
            }
        }        

        private ActionItem InsertActionItem(DateTime startDateTime, DateTime? endDateTime, ActionItemStatus status, FunctionalLocation floc)
        {
            return InsertActionItem(null, startDateTime, endDateTime, status, floc);
        }

        private ActionItem InsertActionItem(WorkAssignment workAssignment, DateTime startDateTime, DateTime? endDateTime, ActionItemStatus status, FunctionalLocation floc)
        {
            ActionItem actionItem = CreateActionItem(floc, status, startDateTime, Priority.Normal);
            actionItem.EndDateTime = endDateTime;
            actionItem.Assignment = workAssignment;
            actionItemDao.Insert(actionItem);
            return actionItem;
        }

        private static ActionItem CreateActionItem(FunctionalLocation floc, ActionItemStatus status, DateTime startDateTime)
        {
            return CreateActionItem(floc, status, startDateTime, Priority.Normal);
        }

        private static ActionItem CreateActionItem(FunctionalLocation floc, ActionItemStatus status, DateTime startDateTime, Priority priority)
        {
            ActionItem actionItem = ActionItemFixture.Create(priority);
            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(floc);
            actionItem.SetStatus(status, actionItem.LastModifiedBy, actionItem.LastModifiedDate);
            actionItem.StartDateTime = startDateTime;
            return actionItem;
        }       

        private static ActionItem CreateActionItem(FunctionalLocation floc, ShiftPattern shiftPattern, Date currentDate)
        {
            return CreateActionItem(floc, shiftPattern, currentDate, null);
        }

        private static ActionItem CreateActionItem(FunctionalLocation floc, ShiftPattern shiftPattern, Date currentDate, long? gn75BId)
        {
            ActionItem actionItem = ActionItemFixture.Create(Priority.Normal, gn75BId);
            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(floc);
            actionItem.SetStatus(ActionItemStatus.Current, actionItem.LastModifiedBy, actionItem.LastModifiedDate);
            actionItem.StartDateTime = shiftPattern.StartTime.ToDateTime(currentDate);
            actionItem.EndDateTime = shiftPattern.StartTime.ToDateTime(currentDate).AddDays(1);
            return actionItem;
        }
    }
}