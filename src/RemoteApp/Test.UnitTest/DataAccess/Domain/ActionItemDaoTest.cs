using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ActionItemDaoTest : AbstractDaoTest
    {
        private IActionItemDao dao;
        private IFunctionalLocationDao functionalLocationDao;
        private IActionItemDefinitionDao actionItemDefinitionDao;
        private ActionItem actionItem;

        protected override void Cleanup() {}

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IActionItemDao>();
            actionItem = ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
        }

        [Ignore] [Test]
        public void SaveActionItemShouldSetTheIdOnTheActionItem()
        {
            dao.Insert(actionItem);
            Assert.IsNotNull(actionItem.Id);

            ActionItem requeried = dao.QueryById(actionItem.IdValue);
            Assert.IsNotNull(requeried);
            Assert.AreEqual(actionItem.FunctionalLocations.Count, requeried.FunctionalLocations.Count);
        }

        [Ignore] [Test]
        public void ShouldSaveActionItemWithNullEndDateTime()
        {
            actionItem.EndDateTime = null;
            dao.Insert(actionItem);
            ActionItem actual = dao.QueryById(actionItem.IdValue);
            Assert.IsNotNull(actual);
            Assert.IsNull(actual.EndDateTime);
        }

        [Ignore] [Test]
        public void SaveActionItemShouldAddAnActionItemInTheDatabase()
        {
            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            actionItem.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH());
            dao.Insert(actionItem);

            ActionItem actual = dao.QueryById(actionItem.IdValue);
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.FunctionalLocations.Count);
            foreach (FunctionalLocation expectedFloc in actionItem.FunctionalLocations)
            {
                Assert.IsTrue(actual.FunctionalLocations.ExistsById(expectedFloc));
            }
            Assert.AreEqual(actionItem.Id, actual.Id);
            Assert.AreEqual(actionItem.LastModifiedBy.Id, actual.LastModifiedBy.Id);
            Assert.AreEqual(actionItem.LastModifiedDate, actual.LastModifiedDate);
            Assert.AreEqual(actionItem.Description, actual.Description);
            Assert.AreEqual(actionItem.StartDateTime, actual.StartDateTime);
            Assert.AreEqual(actionItem.EndDateTime, actual.EndDateTime);
            Assert.AreEqual(actionItem.Name, actual.Name);
        }

        [Ignore] [Test]
        public void SaveActionItemShouldPersistPriority()
        {
            actionItem = ActionItemFixture.Create(Priority.Elevated);
            dao.Insert(actionItem);
            ActionItem retrievedActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(actionItem.Priority, retrievedActionItem.Priority);
        }

        [Ignore] [Test]
        public void OnInsertDaoSavesLastModifiedUser()
        {
            User expected = UserFixture.CreateEngineeringSupport();
            actionItem.LastModifiedBy = expected;
            dao.Insert(actionItem);
            User actual = dao.QueryById(actionItem.IdValue).LastModifiedBy;
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesActionItemStatusId()
        {
            ActionItemStatus expected = ActionItemStatusFixture.Pending();
            actionItem.SetStatus(expected, actionItem.LastModifiedBy, actionItem.LastModifiedDate);
            dao.Insert(actionItem);
            ActionItemStatus actual = dao.QueryById(actionItem.IdValue).Status;
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesName()
        {
            actionItem.Name = "<MyFunkyActionItemName>";
            dao.Insert(actionItem);
            ActionItem insertedActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(actionItem.Name, insertedActionItem.Name);
            insertedActionItem.Name = "<MyNewFunkyActionItemName>";
            dao.Update(insertedActionItem);
            ActionItem updatedActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(insertedActionItem.Name, updatedActionItem.Name);
        }

        [Ignore] [Test]
        public void InsertAndUpdateDaoSavesAssignment()
        {
            actionItem.Assignment = WorkAssignmentFixture.CreateUnitLeader();
            dao.Insert(actionItem);
            ActionItem insertedActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(actionItem.Assignment.Id, insertedActionItem.Assignment.Id);
            insertedActionItem.Assignment = WorkAssignmentFixture.CreateShiftEngineer();
            dao.Update(insertedActionItem);
            ActionItem updatedActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(insertedActionItem.Assignment.Id, updatedActionItem.Assignment.Id);
        }   
             
        [Ignore] [Test]
        public void OnInsertDaoSavesFunctionalLocationId()
        {
            FunctionalLocation expected1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            FunctionalLocation expected2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(expected1);
            actionItem.FunctionalLocations.Add(expected2);
            dao.Insert(actionItem);

            {
                ActionItem requeried = dao.QueryById(actionItem.IdValue);
                Assert.AreEqual(2, requeried.FunctionalLocations.Count);
                Assert.IsTrue(requeried.FunctionalLocations.ExistsById(expected1));
                Assert.IsTrue(requeried.FunctionalLocations.ExistsById(expected2));
            }
        }

        [Ignore] [Test]
        public void OnInsertDaoSavesCreatedByActionItemDefinition()
        {
            actionItem = ActionItemFixture.CreatNewActionItemWithCreatedByActionItemDefinition();
            long expectedCreatedByActionItemId = actionItem.CreatedByActionItemDefinition.IdValue;
            dao.Insert(actionItem);
            ActionItem actualActionItem = dao.QueryById(actionItem.IdValue);
            Assert.AreEqual(expectedCreatedByActionItemId, actualActionItem.CreatedByActionItemDefinition.IdValue);
        }

        [Ignore] [Test]
        public void OnUpdateDaoSavesDescription()
        {
            ActionItem item = ActionItemFixture.CreateAPendingActionItemWithIdPassedIn(1);
            dao.Insert(item);
            item = dao.QueryById(item.IdValue);

            const string expected = "A new Action Item description";
            item.Description = expected;
            dao.Update(item);
            string actual = dao.QueryById(item.IdValue).Description;
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void UpdateActionItemWithStatusChangeShouldSavePreviousStatus()
        {
            ActionItem item = ActionItemFixture.Create();
            ActionItemStatus previousStatus = item.Status;
            item.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            item.LastModifiedDate = new DateTime(2006, 06, 01);
            dao.Insert(item);
            User statusChangeUser = UserFixture.CreateUserWithGivenId(2);
            DateTime statusChangeDateTime = new DateTime(2006, 06, 02);
            item.SetStatus(ActionItemStatus.Complete, statusChangeUser, statusChangeDateTime);
            dao.Update(item);
            ActionItem retrievedItem = dao.QueryById(item.IdValue);
            ActionItemStatusModification statusModification = retrievedItem.StatusModification;
            Assert.AreEqual(previousStatus, statusModification.PreviousStatus);
            Assert.AreEqual(statusChangeUser.Id, statusModification.ModifiedUser.Id);
            Assert.AreEqual(statusChangeDateTime, statusModification.ModifiedDateTime);
        }

        [Ignore] [Test]
        public void UpdateActionItemWithNoStatusModificationShouldNotSavePreviousStatus()
        {
            ActionItem item = ActionItemFixture.Create();
            item.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            item.LastModifiedDate = new DateTime(2006, 06, 01);
            dao.Insert(item);
            dao.Update(item);
            ActionItem retrievedItem = dao.QueryById(item.IdValue);
            ActionItemStatusModification statusModification = retrievedItem.StatusModification;
            Assert.IsNull(statusModification);
        }

        [Ignore] [Test]
        public void OnInsertDaoSavesLastModifiedDate()
        {
            DateTime expected = new DateTime(2000, 1, 1);
            actionItem.LastModifiedDate = expected;
            dao.Insert(actionItem);
            DateTime actual = dao.QueryById(actionItem.IdValue).LastModifiedDate;
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void UpdateNoResponseRequiredShouldChangeActionItemToComplete()
        {
            DateTime shiftAdjusted = new DateTime(2000, 1, 1, 1, 0, 0);
            ActionItem passed = ActionItemFixture.CreateRespondNotRequiredWithShiftAdjustedDateTime(shiftAdjusted);
            ActionItemStatus previousStatus = passed.Status;
            dao.Insert(passed);
            ActionItem qPassed = dao.QueryById(passed.IdValue);
            Assert.AreEqual(ActionItemStatus.Current, qPassed.Status);
            User user = InsertNewUser();
            DateTime changeDateTime = new DateTime(2000, 1, 1, 1, 30, 0);
            dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus.Complete,
                                                                             SiteFixture.Sarnia(), changeDateTime, user);
            ActionItem qPassedUpdate = dao.QueryById(passed.IdValue);
            Assert.AreEqual(ActionItemStatus.Complete, qPassedUpdate.Status);
            
            ActionItemStatusModification statusModification = qPassedUpdate.StatusModification;
            Assert.AreEqual(previousStatus, statusModification.PreviousStatus);
            Assert.AreEqual(user, statusModification.ModifiedUser);
            Assert.AreEqual(changeDateTime, statusModification.ModifiedDateTime);
        }

        [Ignore] [Test]
        public void UpdateNoResponseRequiredShouldNotStoreStatusModificationIfStatusUnchanged()
        {
            DateTime shiftAdjusted = new DateTime(2000, 1, 1, 1, 0, 0);
            ActionItem item = ActionItemFixture.CreateRespondNotRequiredWithShiftAdjustedDateTime(shiftAdjusted);
            ActionItemStatus previousStatus = item.Status;
            dao.Insert(item);
            User user = InsertNewUser();
            DateTime changeDateTime = new DateTime(2000, 1, 1, 1, 30, 0);
            dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(previousStatus,
                                                                             SiteFixture.Sarnia(), changeDateTime, user);
            ActionItem retrievedItem = dao.QueryById(item.IdValue);
            Assert.IsNull(retrievedItem.StatusModification);
        }

        [Ignore] [Test]
        public void ShouldNotUpdateAnyActionItemsThatAreNotInTheGivenSite()
        {
            DateTime shiftAdjusted = new DateTime(2000, 1, 1, 1, 0, 0);
            ActionItem passed
                    = ActionItemFixture.CreateRespondNotRequiredWithShiftAdjustedDateTime(shiftAdjusted);
            dao.Insert(passed);
            ActionItem qPassed = dao.QueryById(passed.IdValue);
            Assert.AreEqual(ActionItemStatus.Current, qPassed.Status);
            dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus.Complete,
                                                                             SiteFixture.Denver(), new DateTime(2000, 1, 1, 1, 30, 0),
                                                                             UserFixture.CreateOperatorOltUser1InFortMcMurrySite());
            ActionItem qPassedUpdate = dao.QueryById(passed.IdValue);
            Assert.AreEqual(ActionItemStatus.Current, qPassedUpdate.Status);
        }

        [Ignore] [Test]
        public void ShouldNotUpdateDeletedActionItemsWhenShiftEndHasPassed()
        {
            DateTime shiftAdjusted = new DateTime(2000, 1, 1, 1, 0, 0);

            ActionItem removedActionItem = ActionItemFixture.CreateRespondNotRequiredWithShiftAdjustedDateTime(shiftAdjusted);
            dao.Insert(removedActionItem);
            dao.Remove(removedActionItem);
            {
                ActionItem queried = dao.QueryById(removedActionItem.IdValue);
                Assert.AreEqual(ActionItemStatus.Current, queried.Status);
            }

            ActionItem notRemovedActionItem = ActionItemFixture.CreateRespondNotRequiredWithShiftAdjustedDateTime(shiftAdjusted);
            dao.Insert(notRemovedActionItem);
            {
                ActionItem queried = dao.QueryById(notRemovedActionItem.IdValue);
                Assert.AreEqual(ActionItemStatus.Current, queried.Status);
            }

            DateTime changeDateTime = new DateTime(2000, 1, 1, 1, 30, 0);
            dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(
                ActionItemStatus.Complete, removedActionItem.FunctionalLocations[0].Site, changeDateTime, UserFixture.CreateOperatorOltUser1InFortMcMurrySite());
            {
                ActionItem queried = dao.QueryById(removedActionItem.IdValue);
                Assert.AreEqual(ActionItemStatus.Current, queried.Status);
            }
            {
                ActionItem queried = dao.QueryById(notRemovedActionItem.IdValue);
                Assert.AreEqual(ActionItemStatus.Complete, queried.Status);
            }
        }

        [Ignore] [Test]
        public void QueryAllActionItemsUnderAUnitFlocShouldReturnActionItemsToBeCleared()
        {
            FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation equipFloc1 = FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(unitFloc, "TestEquip1");
            FunctionalLocation equipFloc2 = FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(unitFloc, "TestEquip2");
            functionalLocationDao.Insert(equipFloc1);
            functionalLocationDao.Insert(equipFloc2);

            ActionItem item = ActionItemFixture.Create();
            item.Id = null;
            item.FunctionalLocations.Clear();
            item.FunctionalLocations.Add(equipFloc1);
            item.FunctionalLocations.Add(equipFloc2);
            dao.Insert(item);

            List<ActionItem> resultingList = dao.QueryAllActionItemsNeedingAttention(new List<FunctionalLocation>{unitFloc});
            ActionItem result = resultingList.FindById(item);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.FunctionalLocations.Count);
            Assert.IsTrue(result.FunctionalLocations.ExistsById(equipFloc1));
            Assert.IsTrue(result.FunctionalLocations.ExistsById(equipFloc2));
        }

        [Ignore] [Test]
        public void QueryAllActionItemsUnderAUnitFlocShouldNotReturnDeletedActionItems()
        {
            FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation persistedUnitFloc = functionalLocationDao.QueryById(unitFloc.IdValue);
            FunctionalLocation equipment1Floc = FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(persistedUnitFloc, "TestEquip1");
            functionalLocationDao.Insert(equipment1Floc);

            // insert the ActionItem linked to the equipment1 floc.
            ActionItem item = ActionItemFixture.Create();
            item.Id = null;
            item.FunctionalLocations.Clear();
            item.FunctionalLocations.Add(equipment1Floc);

            dao.Insert(item);
            {
                List<ActionItem> resultingList = dao.QueryAllActionItemsNeedingAttention(new List<FunctionalLocation>{persistedUnitFloc});
                Assert.IsTrue(resultingList.Exists(obj => obj.Id == item.Id));
            }

            dao.Remove(item);
            {
                List<ActionItem> resultingList = dao.QueryAllActionItemsNeedingAttention(new List<FunctionalLocation>{persistedUnitFloc});
                Assert.IsFalse(resultingList.Exists(obj => obj.Id == item.Id));
            }
        }

        private static User InsertNewUser()
        {
            IUserDao userDao = DaoRegistry.GetDao<IUserDao>();
            User insertedUser = userDao.Insert(UserFixture.CreateDBInsertableUser());
            return userDao.QueryById(insertedUser.IdValue);
        }

        [Ignore] [Test]
        public void ShouldQueryCurrentActionItemsForActionItemDefinitionWithSingleSchedule()
        {
            DateTime now = new DateTime(2001, 2, 3, 10, 0, 0);

            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            definition.Schedule = SingleScheduleFixture.CreateFarFarAwaySingleSchedule();
            actionItemDefinitionDao.Insert(definition);

            long id1 = Insert(ActionItemStatus.Current, false, now.SubtractDays(1), now.SubtractDays(1), definition);
            long id2 = Insert(ActionItemStatus.Current, true, now.AddDays(1), now.SubtractDays(1), definition);
            long id3 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.SubtractDays(1), definition);
            long id4 = Insert(ActionItemStatus.Current, false, null, now.SubtractDays(1), definition);
            long id5 = Insert(ActionItemStatus.Current, false, DateTime.MaxValue, now.SubtractDays(1), definition);
            
            long id6 = Insert(ActionItemStatus.Current, false, now, now.SubtractDays(1), definition);
            long id6a = Insert(ActionItemStatus.Current, true, now, now.SubtractDays(1), definition);

            long id7 = Insert(ActionItemStatus.CannotComplete, false, now.AddDays(1), now.SubtractDays(1), definition);
            long id8 = Insert(ActionItemStatus.Complete, false, now.AddDays(1), now.SubtractDays(1), definition);
            long id9 = Insert(ActionItemStatus.Cleared, false, now.AddDays(1), now.SubtractDays(1), definition);
            long id10 = Insert(ActionItemStatus.Incomplete, false, now.AddDays(1), now.SubtractDays(1), definition);

            

            List<ActionItem> results = dao.QueryCurrentActionItemsForActionItemDefinition(definition, now);
            Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            Assert.IsTrue(results.Exists(obj => obj.Id == id2));
            Assert.IsTrue(results.Exists(obj => obj.Id == id3));
            Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            Assert.IsTrue(results.Exists(obj => obj.Id == id5));

            Assert.IsFalse(results.Exists(obj => obj.Id == id6));
            Assert.IsFalse(results.Exists(obj => obj.Id == id6a));

            Assert.IsFalse(results.Exists(obj => obj.Id == id7));
            Assert.IsFalse(results.Exists(obj => obj.Id == id8));
            Assert.IsFalse(results.Exists(obj => obj.Id == id9));
            Assert.IsFalse(results.Exists(obj => obj.Id == id10));
        }

        [Ignore] [Test]
        public void ShouldQueryCurrentActionItemsForActionItemDefinitionWithDailySchedule()
        {
            DateTime now = new DateTime(2001, 2, 3, 10, 0, 0);

            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            definition.Schedule = RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                new Date(now), new Date(now.AddYears(1)), new Time(9), new Time(4));
            actionItemDefinitionDao.Insert(definition);

            long id1 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.SubtractDays(1), definition);
            long id2 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(0), definition);
            long id3 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(1), definition);

            List<ActionItem> results = dao.QueryCurrentActionItemsForActionItemDefinition(definition, now);
            Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            Assert.IsTrue(results.Exists(obj => obj.Id == id3));
        }

        [Ignore] [Test]
        public void ShouldQueryByDefinitionId()
        {
            DateTime now = new DateTime(2001, 2, 3, 10, 0, 0);

            ActionItemDefinition definition1;

            {
                definition1 = ActionItemDefinitionFixture.CreateActionItemDefinition();
                definition1.Schedule = RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(now), new Date(now.AddYears(1)), new Time(9), new Time(4));
                actionItemDefinitionDao.Insert(definition1);                
            }

            ActionItemDefinition definition2;

            {
                definition2 = ActionItemDefinitionFixture.CreateActionItemDefinition();
                definition2.Schedule = RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(now), new Date(now.AddYears(1)), new Time(9), new Time(4));
                actionItemDefinitionDao.Insert(definition2);
            }

            long id1 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.SubtractDays(1), definition1);
            long id2 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(0), definition1);
            long id3 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(1), definition1);

            long id4 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.SubtractDays(1), definition2);
            long id5 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(0), definition2);
            long id6 = Insert(ActionItemStatus.Current, false, now.AddDays(1), now.AddDays(1), definition2);

            List<ActionItem> results1 = dao.QueryUnrespondedToActionItemsByDefinitionId(definition1.IdValue);
            List<ActionItem> results2 = dao.QueryUnrespondedToActionItemsByDefinitionId(definition2.IdValue);

            Assert.IsTrue(results1.Exists(i => i.IdValue == id1));
            Assert.IsTrue(results1.Exists(i => i.IdValue == id2));
            Assert.IsTrue(results1.Exists(i => i.IdValue == id3));
            Assert.IsFalse(results1.Exists(i => i.IdValue == id4));
            Assert.IsFalse(results1.Exists(i => i.IdValue == id5));
            Assert.IsFalse(results1.Exists(i => i.IdValue == id6));

            Assert.IsFalse(results2.Exists(i => i.IdValue == id1));
            Assert.IsFalse(results2.Exists(i => i.IdValue == id2));
            Assert.IsFalse(results2.Exists(i => i.IdValue == id3));
            Assert.IsTrue(results2.Exists(i => i.IdValue == id4));
            Assert.IsTrue(results2.Exists(i => i.IdValue == id5));
            Assert.IsTrue(results2.Exists(i => i.IdValue == id6));
        }

        private long Insert(
            ActionItemStatus actionItemStatus,
            bool requiresResponse, 
            DateTime? shiftAdjustedEndDate, 
            DateTime startDateTime,
            ActionItemDefinition definition)
        {
            ActionItem item = ActionItemFixture.CreateNewActionItemWithCreatedByActionItemDefinition(definition, shiftAdjustedEndDate);
            item.SetStatus(actionItemStatus, UserFixture.CreateRemoteAppUser(), DateTimeFixture.DateTimeNow);
            item.ResponseRequired = requiresResponse;
            item.StartDateTime = startDateTime;
            dao.Insert(item);
            return item.IdValue;
        }
    }
}