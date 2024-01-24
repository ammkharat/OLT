using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ActionItemDefinitionDaoTest : AbstractDaoTest
    {
        private IActionItemDefinitionDao dao;
        private ActionItemDefinition actionItemDefinition;
        private IFormGN75BDao formGN75BDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            formGN75BDao = DaoRegistry.GetDao<IFormGN75BDao>();
            actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void GetActionItemDefinitionsByIdShouldReturnAPopulatedActionItem()
        {
            actionItemDefinition = dao.QueryById(ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_WITH_2_COMMENTS_ID);
            Assert.AreEqual("Name 21", actionItemDefinition.Name);
            Assert.AreEqual(1, actionItemDefinition.Schedule.IdValue);
            Assert.AreEqual("Unit Guideline / Process", actionItemDefinition.Category.Name);
            Assert.AreEqual(1, actionItemDefinition.Status.IdValue);
            Assert.AreEqual("Id = 21 - has 2 comments", actionItemDefinition.Description);
            Assert.AreEqual(2, actionItemDefinition.LastModifiedBy.IdValue);
            Assert.AreEqual(new DateTime(2006, 1, 25, 19, 0, 0), actionItemDefinition.LastModifiedDate);
            Assert.AreEqual(OperationalMode.Constrained, actionItemDefinition.OperationalMode);
            Assert.AreEqual(1, actionItemDefinition.Assignment.Id);
            List<Comment> expectedComments =
                    CommentFixture.GetCommentsForActionItemDefinitionInDb(actionItemDefinition.IdValue);
            Assert.AreEqual(expectedComments.Count, actionItemDefinition.Comments.Count);
        }

        [Ignore] [Test]
        public void UpdateTheActionItemDefinitionsShouldUpdateTheActionItemInTheDatabase()
        {            
            ActionItemDefinition inserted = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            Assert.IsFalse(inserted.Id.HasValue);
            dao.Insert(inserted);
            Assert.IsTrue(inserted.Id.HasValue);
            ActionItemDefinition changed = dao.QueryById(inserted.IdValue);
            changed.Description = "This is a new description";            
            dao.Update(changed);
            ActionItemDefinition updated = dao.QueryById(changed.IdValue);
            Assert.AreEqual(changed, updated);
            Assert.AreEqual(inserted.Schedule, updated.Schedule);
        }

        [Ignore] [Test]
        public void UpdateActionItemDefinitionsShouldUpdateTheActionItemInTheDatabaseAndAllowBusinessCategoryToBeNull()
        {
            ActionItemDefinition inserted = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            inserted.Category = null;
            Assert.IsFalse(inserted.Id.HasValue);
            dao.Insert(inserted);            
            ActionItemDefinition changed = dao.QueryById(inserted.IdValue);
            changed.Description = "This is a new description";
            dao.Update(changed);
            ActionItemDefinition updated = dao.QueryById(changed.IdValue);
            Assert.AreEqual(changed, updated);
            Assert.AreEqual(inserted.Schedule, updated.Schedule);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(AttemptedToUpdateObjectWithoutIdException))]
        public void ShouldThrowExceptionIfUpdateCalledAndScheduleDoesNot()
        {
            ActionItemDefinition inserted = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            Assert.IsFalse(inserted.Id.HasValue);
            dao.Insert(inserted);
            Assert.IsTrue(inserted.Id.HasValue);
            ActionItemDefinition changed = dao.QueryById(inserted.IdValue);
            changed.Description = "This is a new description";
            changed.Schedule.Id = null;
            dao.Update(changed);
        }

        [Ignore] [Test]
        public void UpdateActionItemDefinitionShouldInsertNewComments()
        {
            Comment newComment = CommentFixture.CreateComment();
            Assert.IsNull(newComment.Id);
            actionItemDefinition = dao.QueryById(ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_FOR_ADDING_COMMENTS_ID);
            int oldCommentCount = actionItemDefinition.Comments.Count;
            actionItemDefinition.Comments.Add(newComment);
            dao.Update(actionItemDefinition);
            Assert.IsNotNull(newComment.Id);
            ActionItemDefinition retrievedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(oldCommentCount + 1, retrievedActionItemDefinition.Comments.Count);
        }

        [Ignore] [Test]
        public void UpdateActionItemDefinitionShouldUpdateAssignment()
        {
            WorkAssignment unitLeaderAssignment = WorkAssignmentFixture.CreateUnitLeader();            
            actionItemDefinition = dao.QueryById(ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_FOR_ADDING_COMMENTS_ID);
            Assert.IsNull(actionItemDefinition.Assignment);
            actionItemDefinition.Assignment = unitLeaderAssignment;
            dao.Update(actionItemDefinition);            
            ActionItemDefinition retrievedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(unitLeaderAssignment.Id, retrievedActionItemDefinition.Assignment.Id);
        }

        [Ignore] [Test]
        public void ShouldQueryBySapOperationId()
        {
            long sapOperationId = 55555;
            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            definition.SapOperationId = sapOperationId;
            dao.Insert(definition);
            ActionItemDefinition returnedDefinition = dao.QueryBySapOperationId(sapOperationId);
            Assert.IsNotNull(returnedDefinition);
            Assert.AreEqual(definition.SapOperationId, returnedDefinition.SapOperationId);
            dao.Remove(definition);
        }

        [Ignore] [Test]
        public void SaveActionItemShouldSetTheIdOnTheActionItem()
        {
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "SetID";
            dao.Insert(actionItemDefinition);
            Assert.IsNotNull(actionItemDefinition.IdValue);
            dao.Remove(actionItemDefinition);
        }

        [Ignore] [Test]
        public void SaveActionItemShouldAddAnActionItemInTheDatabase()
        {
            long? someFakeSapOperationId = 22334455;
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "SAVE";
            actionItemDefinition.SapOperationId = someFakeSapOperationId;
            dao.Insert(actionItemDefinition);
            ActionItemDefinition actual = dao.QueryById(actionItemDefinition.IdValue);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Schedule);
            Assert.AreEqual(someFakeSapOperationId, actual.SapOperationId);
            //      Assert.AreEqual(inserted, actual); // this can be brought back in when the save actually saves All the data
            Assert.AreEqual(actionItemDefinition.Schedule, actual.Schedule);
        }

        [Ignore] [Test]
        public void RemoveActionItemShouldPreformASoftDeletePreventingFurtherQueriesOnTheActionItem()
        {
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "PREV";
            dao.Insert(actionItemDefinition);
            ActionItemDefinition actionItemForDeletion = dao.QueryById(actionItemDefinition.IdValue);
            Assert.IsNotNull(actionItemForDeletion);
            dao.Remove(actionItemForDeletion);
            ActionItemDefinition removedActionItem = dao.QueryById(actionItemForDeletion.IdValue);
            Assert.IsTrue(removedActionItem.Deleted);
        }

        [Ignore] [Test]
        public void OnInsertDaoSavesLastModifiedUser()
        {
            User expected = UserFixture.CreateEngineeringSupport();
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "LMU";
            actionItemDefinition.LastModifiedBy = expected;
            dao.Insert(actionItemDefinition);
            User actual = dao.QueryById(actionItemDefinition.IdValue).LastModifiedBy;
            Assert.AreEqual(expected.Id, actual.Id);
            expected = UserFixture.CreateSupervisor();
            actionItemDefinition.LastModifiedBy = expected;
            dao.Update(actionItemDefinition);
            actual = dao.QueryById(actionItemDefinition.IdValue).LastModifiedBy;
            Assert.AreEqual(expected.Id, actual.Id);
            dao.Remove(actionItemDefinition);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesActionItemCategoryId()
        {            
            BusinessCategory expected = BusinessCategoryFixture.GetEnvironmentalSafetyCategory();
            actionItemDefinition.Category = expected;
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow.Ticks + " rr";
            dao.Insert(actionItemDefinition);
            BusinessCategory actual = dao.QueryById(actionItemDefinition.IdValue).Category;
            Assert.AreEqual(expected.Id, actual.Id);
            expected = BusinessCategoryFixture.GetProductionCategory();
            actionItemDefinition.Category = expected;
            dao.Update(actionItemDefinition);
            actual = dao.QueryById(actionItemDefinition.IdValue).Category;
            Assert.AreEqual(expected.Id, actual.Id);
            dao.Remove(actionItemDefinition);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesActionItemStatusId()
        {
            foreach(ActionItemDefinitionStatus expectedInsertedStatus in ActionItemDefinitionStatus.All)
            {
                actionItemDefinition.Status = expectedInsertedStatus;
                if(expectedInsertedStatus == ActionItemDefinitionStatus.Approved)
                {
                    actionItemDefinition.RequiresApproval = false;
                }
                else
                {
                    actionItemDefinition.RequiresApproval = true;
                    actionItemDefinition.Active = false;
                }
                actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "STAT";
                dao.Insert(actionItemDefinition);
                ActionItemDefinitionStatus actualInsertStatus = dao.QueryById(actionItemDefinition.IdValue).Status;
                Assert.AreEqual(expectedInsertedStatus.Id, actualInsertStatus.Id);
                foreach(ActionItemDefinitionStatus expectedUpdateStatus in ActionItemDefinitionStatus.All)
                {
                    actionItemDefinition.Status = expectedUpdateStatus;
                    if(expectedUpdateStatus == ActionItemDefinitionStatus.Approved)
                    {
                        actionItemDefinition.RequiresApproval = false;
                    }
                    else
                    {
                        actionItemDefinition.RequiresApproval = true;
                        actionItemDefinition.Active = false;
                    }
                    dao.Update(actionItemDefinition);
                    ActionItemDefinitionStatus actualUpdateStatus = dao.QueryById(actionItemDefinition.IdValue).Status;
                    Assert.AreEqual(expectedUpdateStatus.Id, actualUpdateStatus.Id);
                }
                dao.Remove(actionItemDefinition);
            }
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesFunctionalLocationId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            actionItemDefinition.FunctionalLocations.Add(floc1);
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "DAO Floc";
            dao.Insert(actionItemDefinition);

            FunctionalLocation actual = dao.QueryById(actionItemDefinition.IdValue).FunctionalLocations[0];
            Assert.AreEqual(floc1.Id, actual.Id);
            
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1();
            actionItemDefinition.FunctionalLocations.Add(floc2);
            dao.Update(actionItemDefinition);
            
            ActionItemDefinition retrievedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(2, retrievedActionItemDefinition.FunctionalLocations.Count);

            var flocs =
                new List<FunctionalLocation>(retrievedActionItemDefinition.FunctionalLocations);
            flocs.Sort();
            Assert.AreEqual(floc2.Id, flocs[0].Id);
            Assert.AreEqual(floc1.Id, flocs[1].Id);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesScheduleId()
        {
            ISchedule expected = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            actionItemDefinition.Schedule = expected;
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + " SID 812";
            dao.Insert(actionItemDefinition);
            ISchedule actual = dao.QueryById(actionItemDefinition.IdValue).Schedule;
            Assert.AreEqual(expected.Id, actual.Id);
            expected = SingleScheduleFixture.CreateSingleScheduleOnNov11From8AMTo12PM();
            actionItemDefinition.Schedule = expected;
            dao.Update(actionItemDefinition);
            actual = dao.QueryById(actionItemDefinition.IdValue).Schedule;
            Assert.AreEqual(expected.Id, actual.Id);
            dao.Remove(actionItemDefinition);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesDescriptionAndSAPOperationId()
        {
            string expectedDescription = "A Unique description";
            long? expectedSapOperationId = 11223344;
            actionItemDefinition.Description = expectedDescription;
            actionItemDefinition.SapOperationId = expectedSapOperationId;
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "DESC";
            dao.Insert(actionItemDefinition);
            ActionItemDefinition returnedDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(expectedDescription, returnedDefinition.Description);
            Assert.AreEqual(expectedSapOperationId, returnedDefinition.SapOperationId);
            expectedDescription = "Some new text to change the description";
            expectedSapOperationId = 44556677;
            returnedDefinition.Description = expectedDescription;
            returnedDefinition.SapOperationId = expectedSapOperationId;
            dao.Update(returnedDefinition);
            ActionItemDefinition updatedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(expectedDescription, updatedActionItemDefinition.Description);
            Assert.AreEqual(expectedSapOperationId, updatedActionItemDefinition.SapOperationId);
            dao.Remove(updatedActionItemDefinition);
        }

        [Ignore] [Test]
        public void OnInsertDaoSavesName()
        {
            string expected = DateTimeFixture.DateTimeNow + "NM";
            actionItemDefinition.Name = expected;
            dao.Insert(actionItemDefinition);
            string actual = dao.QueryById(actionItemDefinition.IdValue).Name;
            Assert.AreEqual(expected, actual);
            dao.Remove(actionItemDefinition);
        }

        [Ignore] [Test]
        public void ShouldInsertAssignment()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            actionItemDefinition.Assignment = assignment;
            dao.Insert(actionItemDefinition);
            ActionItemDefinition retreived = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(assignment.Id, retreived.Assignment.Id);            
        }

        [Ignore]
         [Test]
        public void ShouldQueryCountByGN75AId()
        {
            ActionItemDefinition definition1 = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            ActionItemDefinition definition2 = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            ActionItemDefinition definition3 = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(floc, floc.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                         Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8, new List<DevicePosition>(0),0,null,null);  //ayman Sarnia eip DMND0008992

            formGN75BDao.Insert(form);

            definition1.AssociatedFormGN75BId = form.IdValue;
            definition3.AssociatedFormGN75BId = form.IdValue;

            dao.Insert(definition1);
            dao.Insert(definition2);
            dao.Insert(definition3);

            Assert.AreEqual(2, dao.QueryCountByGN75BId(form.IdValue));
        }

        [Ignore] [Test]
        public void GetCountOfSAPSourcedReturnsOnlyActionItemDefinitionsCreatedBySAP()
        {
            ActionItemDefinition manualActionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            ActionItemDefinition SAPActionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();

            // Assign both definitions to Sarnia Flocs
            manualActionItemDefinition.FunctionalLocations.Clear();
            manualActionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            
            SAPActionItemDefinition.FunctionalLocations.Clear();
            SAPActionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());

            // Name both definitions the same
            const string nameInSarnia = "123-456-789";
            manualActionItemDefinition.Name = nameInSarnia;
            SAPActionItemDefinition.Name = nameInSarnia;

            // Force Manual DataSource and SAP DataSource on our test objects
            manualActionItemDefinition.Source = DataSource.MANUAL;
            SAPActionItemDefinition.Source = DataSource.SAP;

            // Insert into DB
            dao.Insert(manualActionItemDefinition);
            dao.Insert(SAPActionItemDefinition);

            // Ensure Count function only counts definitions that came from SAP
            Assert.AreEqual(1, dao.GetCountOfSAPSourced(nameInSarnia, Site.SARNIA_ID));
        }

        [Ignore] [Test]
        public void GetCountOfSAPSourcedOnlyActionItemCountsForTheSameSite()
        {
            ActionItemDefinition SAPActionItemDefinitionSarnia = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            ActionItemDefinition SAPActionItemDefinitionDenver = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();

            // Assign one definition to Sarnia Flocs
            SAPActionItemDefinitionSarnia.FunctionalLocations.Clear();
            SAPActionItemDefinitionSarnia.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());

            // Assign one definition to Denver Flocs
            SAPActionItemDefinitionDenver.FunctionalLocations.Clear();
            SAPActionItemDefinitionDenver.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1());

            // Name both definitions the same
            const string sameName = "123-456-789";
            SAPActionItemDefinitionSarnia.Name = sameName;
            SAPActionItemDefinitionDenver.Name = sameName;

            // Force SAP DataSource on our test objects
            SAPActionItemDefinitionSarnia.Source = DataSource.SAP;
            SAPActionItemDefinitionDenver.Source = DataSource.SAP;

            // Insert into DB
            dao.Insert(SAPActionItemDefinitionSarnia);
            dao.Insert(SAPActionItemDefinitionDenver);

            // Ensure Count function only counts definitions for the site passed in
            Assert.AreEqual(1, dao.GetCountOfSAPSourced(sameName, Site.SARNIA_ID));
            Assert.AreEqual(1, dao.GetCountOfSAPSourced(sameName, Site.DENVER_ID));
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesLastModifiedDate()
        {
            DateTime now = new DateTime(2005, 1, 1);
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "IUDSL";
            actionItemDefinition.LastModifiedDate = now;
            dao.Insert(actionItemDefinition);
            DateTime actual = dao.QueryById(actionItemDefinition.IdValue).LastModifiedDate;
            Assert.AreEqual(now, actual);
            now = new DateTime(2005, 1, 2);
            actionItemDefinition.LastModifiedDate = now;
            dao.Update(actionItemDefinition);
            actual = dao.QueryById(actionItemDefinition.IdValue).LastModifiedDate;
            Assert.AreEqual(now, actual);
        }

        [Ignore] [Test]
       
        public void ShouldInsertActionItemDefinitionIdIntoActionItemDefinitionTargetDefinitionTableJoinTable()
        {
            long? expectedTargetDefinitionId = -2;
            var targetDefinitionDTO =
                    new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(expectedTargetDefinitionId));
            actionItemDefinition.TargetDefinitionDTOs.Clear();
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDTO);
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "Join";
            
            dao.Insert(actionItemDefinition);
            
            List<TargetDefinitionDTO> expectedList = actionItemDefinition.TargetDefinitionDTOs;
            List<TargetDefinitionDTO> actualList = dao.QueryById(actionItemDefinition.IdValue).TargetDefinitionDTOs;
            Assert.AreEqual(expectedList.Count, actualList.Count);
            Assert.AreEqual(expectedList[0].Id, actualList[0].Id);
        }

        [Ignore] [Test]
        public void InsertActionItemDefinitionShouldInsertNewComments()
        {
            actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            actionItemDefinition.Comments.Add(CommentFixture.CreateComment());
            dao.Insert(actionItemDefinition);
            ActionItemDefinition retrievedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(actionItemDefinition.Comments.Count, retrievedActionItemDefinition.Comments.Count);
            Assert.IsNotNull(retrievedActionItemDefinition.Comments[0].Id);
            Assert.AreEqual(actionItemDefinition.Comments[0].Id, retrievedActionItemDefinition.Comments[0].Id);
        }

        [Ignore] [Test]
        public void InsertUpdateActionItemDefinitionShouldInsertNewDocumentsAndDeleteOldOnes()
        {
            actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow.Ticks + "LL";
            actionItemDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(actionItemDefinition);
            ActionItemDefinition retrievedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(actionItemDefinition.DocumentLinks.Count,
                            retrievedActionItemDefinition.DocumentLinks.Count,
                            "Insert: Number of links are not the same");
            Assert.IsNotNull(retrievedActionItemDefinition.DocumentLinks[0].Id,
                             "Insert: Live Link Document Id is null");
            Assert.AreEqual(actionItemDefinition.DocumentLinks[0].Id,
                            retrievedActionItemDefinition.DocumentLinks[0].Id,
                            "Insert: First LiveLink document ID's dont match");
            retrievedActionItemDefinition.DocumentLinks.Add(
                    DocumentLinkFixture.CreateNewDocumentLink());
            dao.Update(retrievedActionItemDefinition);
            ActionItemDefinition updatedActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(retrievedActionItemDefinition.DocumentLinks.Count,
                            updatedActionItemDefinition.DocumentLinks.Count,
                            "UPdate: Number of links are not the same");
            Assert.IsNotNull(updatedActionItemDefinition.DocumentLinks[1].Id,
                             "UPdate: Live Link Document Id is null");
            Assert.AreEqual(retrievedActionItemDefinition.DocumentLinks[1].Id,
                            updatedActionItemDefinition.DocumentLinks[1].Id,
                            "UPdate: First LiveLink document ID's dont match");
            updatedActionItemDefinition.DocumentLinks.Remove(
                    updatedActionItemDefinition.DocumentLinks[1]);
            dao.Update(updatedActionItemDefinition);
            ActionItemDefinition updatedSecondTimeActionItemDefinition = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(updatedActionItemDefinition.DocumentLinks.Count,
                            updatedSecondTimeActionItemDefinition.DocumentLinks.Count,
                            "UPdate with remove: Number of links are not the same");
            Assert.IsNotNull(updatedActionItemDefinition.DocumentLinks[0].Id,
                             "UPdate with remove: Live Link Document Id is null");
            Assert.AreEqual(updatedActionItemDefinition.DocumentLinks[0].Id,
                            updatedSecondTimeActionItemDefinition.DocumentLinks[0].Id,
                            "UPdate with remove: First LiveLink document ID's dont match");
        }

        [Ignore] [Test]
        public void ShouldRemoveFromJointTableWhenUpdatingAnActionItemDefinitionNoTargetDef()
        {
            long? expectedTargetDefinitionId = 1;
            var targetDefinitionDTO =
                    new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(expectedTargetDefinitionId));
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDTO);
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow + "SR";
            dao.Insert(actionItemDefinition);
            actionItemDefinition.TargetDefinitionDTOs.Clear();
            dao.Update(actionItemDefinition);
            ActionItemDefinition retrievedActionItem = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(0, retrievedActionItem.TargetDefinitionDTOs.Count);
        }

        [Ignore] [Test]
        public void ShouldFindActionItemDefinitionForScheduling()
        {
            long id1 = CreateDefinition(true, true, false).IdValue;
            long id2 = CreateDefinition(false, false, false).IdValue;
            long id3 = CreateDefinition(true, false, false).IdValue;
            long id4 = CreateDefinition(true, true, true).IdValue;

            List<ActionItemDefinition> actionItemDefinitions = dao.QueryAllAvailableForScheduling();
            Assert.IsTrue(actionItemDefinitions.Exists(obj => obj.Id == id1));
            Assert.IsFalse(actionItemDefinitions.Exists(obj => obj.Id == id2));
            Assert.IsFalse(actionItemDefinitions.Exists(obj => obj.Id == id3));
            Assert.IsFalse(actionItemDefinitions.Exists(obj => obj.Id == id4));

            foreach (ActionItemDefinition actionItemDef in actionItemDefinitions)
            {
                Assert.IsTrue(actionItemDef.Active);
            }
        }

        private ActionItemDefinition CreateDefinition(bool approved, bool active, bool deleted)
        {
            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();
            definition.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Equip1());

            DateTime dateTime = DateTimeFixture.DateTimeNow;

            Time time = dateTime.ToTime();
            definition.Schedule = new SingleSchedule(dateTime.ToDate(), time.AddHours(-3), time.AddHours(3), definition.FunctionalLocations[0].Site);
           
            if (approved)
            {
                definition.Approve(UserFixture.CreateSAPUser(), DateTimeFixture.DateTimeNow);
                definition.Active = active;
            }
            else
            {
                definition.WaitForApproval();
            }
            dao.Insert(definition);
            if (deleted)
            {
                dao.Remove(definition);
            }
            return definition;
        }

        [Ignore] [Test]
        public void ShouldFindContinuousActionItemDefinitionsForScheduling()
        {
            ContinuousSchedule schedule =
                    ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            schedule.EndDate = new Date(DateTime.Now.AddYears(1));

            ActionItemDefinition definition =
                    ActionItemDefinitionFixture.CreateActionItemDefinition(schedule, DateTimeFixture.DateTimeNow);
            definition.Active = true;
            definition.RequiresApproval = false;
            definition.Status = ActionItemDefinitionStatus.Approved;
            dao.Insert(definition);
            List<ActionItemDefinition> availableForScheduling = dao.QueryAllAvailableForScheduling();
            Assert.That(availableForScheduling, Has.Some.Property("Id").EqualTo(definition.Id));
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesFunctionalLocationOperationalMode()
        {
            actionItemDefinition.OperationalMode = OperationalMode.ShutDown;
            dao.Insert(actionItemDefinition);
            ActionItemDefinition actual = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(OperationalMode.ShutDown, actual.OperationalMode);
            actual.OperationalMode = OperationalMode.Constrained;
            dao.Update(actual);
            actual = dao.QueryById(actionItemDefinition.IdValue);
            Assert.AreEqual(OperationalMode.Constrained, actual.OperationalMode);
        }

        [Ignore] [Test]
        public void ShouldQueryActiveDefinitionsByParentFlocAndWorkAssignmentAndDateRange()
        {
            WorkAssignment consoleOperatorAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            WorkAssignment unitLeaderAssignment = WorkAssignmentFixture.CreateUnitLeader();

            // vary work assignment
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                var consoleOpDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, flocs);
                var unitLeaderDefinition = InsertDefinition(fromDateTime, toDateTime, unitLeaderAssignment, true, flocs);

                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(flocs), fromDateTime, null);

                Assert.IsTrue(returnedDefinitions.ExistsById(consoleOpDefinition));
                Assert.IsFalse(returnedDefinitions.ExistsById(unitLeaderDefinition));
            }

            // vary active setting
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                var activeDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, flocs);
                var inactiveDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, false, flocs);

                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(flocs), fromDateTime, null);

                Assert.IsTrue(returnedDefinitions.ExistsById(activeDefinition));
                Assert.IsFalse(returnedDefinitions.ExistsById(inactiveDefinition));                
            }

            // vary dates
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                var someDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, flocs);

                // query dates overlap schedule dates (with query endtime outside of schedule range)
                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(flocs), fromDateTime, null);
                Assert.IsTrue(returnedDefinitions.ExistsById(someDefinition));

                // query dates overlap schedule dates (with query starttime outside of schedule range)
                returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(flocs), fromDateTime, null);
                Assert.IsTrue(returnedDefinitions.ExistsById(someDefinition));
            }

            // case: definition begins and ends on the same day
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

                DateTime now = new DateTime(2010, 12, 20, 10, 0, 0);
                DateTime fromDateTime = now.AddHours(1);
                DateTime toDateTime = now.AddHours(2);

                var someDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, flocs);

                List<ActionItemDefinition> returnedDefinitions =
                    dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(flocs),
                                                                                    now,
                                                                                    null);
                Assert.IsTrue(returnedDefinitions.ExistsById(someDefinition));
            }

            // vary flocs
            {
                var hyduFloc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
                var hyduSchFloc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
                var hyduSch33cr001Floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();

                var gen3Floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                var thirdLevelDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, new List<FunctionalLocation> { hyduFloc });
                var fourthLevelDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, new List<FunctionalLocation> { hyduSchFloc });
                var fifthLevelDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, new List<FunctionalLocation> { hyduSch33cr001Floc });
                var unrelatedDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, new List<FunctionalLocation> { gen3Floc });

                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(new List<FunctionalLocation> { hyduFloc }), fromDateTime, null);
                Assert.IsTrue(returnedDefinitions.ExistsById(thirdLevelDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(fourthLevelDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(fifthLevelDefinition));
                Assert.IsFalse(returnedDefinitions.ExistsById(unrelatedDefinition));

                returnedDefinitions = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(consoleOperatorAssignment, new RootFlocSet(new List<FunctionalLocation> { hyduSchFloc, gen3Floc }), fromDateTime, null);
                Assert.IsFalse(returnedDefinitions.ExistsById(thirdLevelDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(fourthLevelDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(fifthLevelDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(unrelatedDefinition));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryActiveDefinitionsByParentFlocAndDateRangeButNotWorkAssignment()
        {
            WorkAssignment consoleOperatorAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            WorkAssignment unitLeaderAssignment = WorkAssignmentFixture.CreateUnitLeader();
           
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                ActionItemDefinition consoleOpDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, flocs);
                ActionItemDefinition unitLeaderDefinition = InsertDefinition(fromDateTime, toDateTime, unitLeaderAssignment, true, flocs);

                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByParentFunctionalLocations(new RootFlocSet(flocs), fromDateTime, null);

                Assert.IsTrue(returnedDefinitions.ExistsById(consoleOpDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(unitLeaderDefinition));
            }

            // Make sure it's distinguishing by FLOC
            {
                List<FunctionalLocation> bdofFloc = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
                List<FunctionalLocation> tkfmFloc = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM() };                  

                DateTime fromDateTime = DateTime.Now.SubtractDays(1);
                DateTime toDateTime = DateTime.Now.AddDays(1);

                ActionItemDefinition consoleOpDefinition = InsertDefinition(fromDateTime, toDateTime, consoleOperatorAssignment, true, bdofFloc);
                ActionItemDefinition unitLeaderDefinition = InsertDefinition(fromDateTime, toDateTime, unitLeaderAssignment, true, bdofFloc);
                ActionItemDefinition anotherUnitLeaderDefinition = InsertDefinition(fromDateTime, toDateTime, unitLeaderAssignment, true, tkfmFloc);

                List<ActionItemDefinition> returnedDefinitions = dao.QueryActiveDtosByParentFunctionalLocations(new RootFlocSet(bdofFloc), fromDateTime, null);

                Assert.IsTrue(returnedDefinitions.ExistsById(consoleOpDefinition));
                Assert.IsTrue(returnedDefinitions.ExistsById(unitLeaderDefinition));
                Assert.IsFalse(returnedDefinitions.ExistsById(anotherUnitLeaderDefinition));
            }

        }

        [Ignore] [Test]
        public void QueryActiveDtosByParentFunctionalLocations_VaryVisibilityGroups()
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

            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            IFlocSet flocSet = new RootFlocSet(functionalLocation);

            ActionItemDefinition def1 = InsertDefinition(new DateTime(2030, 3, 2), new DateTime(2030, 4, 12), horseAssignment, true, new[] {functionalLocation});
            ActionItemDefinition def2 = InsertDefinition(new DateTime(2030, 3, 2), new DateTime(2030, 4, 12), clothingAssignment, true, new[] {functionalLocation});
            ActionItemDefinition def3 = InsertDefinition(new DateTime(2030, 3, 2), new DateTime(2030, 4, 13), null, true, new[] {functionalLocation});

            DateTime fromDate = new DateTime(2030, 4, 8);

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };

                List<ActionItemDefinition> results1 = dao.QueryActiveDtosByParentFunctionalLocations(flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));

                List<ActionItemDefinition> results2 = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(clothingAssignment, flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == def2.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };

                List<ActionItemDefinition> results1 = dao.QueryActiveDtosByParentFunctionalLocations(flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));

                List<ActionItemDefinition> results2 = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(horseAssignment, flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == def1.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };

                List<ActionItemDefinition> results1 = dao.QueryActiveDtosByParentFunctionalLocations(flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(3, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));

                List<ActionItemDefinition> results2 = dao.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(horseAssignment, flocSet, fromDate.AddDays(1), visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == def1.Id));
            }
        }

        private ActionItemDefinition InsertDefinition(DateTime fromDateTime, DateTime toDateTime, WorkAssignment assignment, bool active, IEnumerable<FunctionalLocation> flocs)
        {
            ActionItemDefinition toInsert = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();

            toInsert.Assignment = assignment;
            
            if (active)
            {
                toInsert.Active = true;
                toInsert.RequiresApproval = false;
                toInsert.Status = ActionItemDefinitionStatus.Approved;
            }

            toInsert.Schedule =
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15();

            toInsert.Schedule.StartDate = new Date(fromDateTime);
            toInsert.Schedule.StartTime = new Time(fromDateTime);
            toInsert.Schedule.EndDate = new Date(toDateTime);
            toInsert.Schedule.EndTime = new Time(toDateTime);

            toInsert.FunctionalLocations.Clear();
            toInsert.FunctionalLocations.AddRange(flocs);

            dao.Insert(toInsert);

            return toInsert;
        }
    }
}