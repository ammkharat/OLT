using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class ActionItemDefinitionDTODaoTest : AbstractDaoTest
    {
        private IActionItemDefinitionDao actionItemDefinitionDao;
        private IActionItemDefinitionDTODao dtoDao;
        private ITargetDefinitionDao targetDefinitionDao;

        [Ignore] [Test]
        public void QueryByFunctionalLocationShouldLimitByDate()
        {
            var functionalLocation = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();

            var def1 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 12), functionalLocation);
            var def2 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 12), functionalLocation);
            var def3 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 13), functionalLocation);
            var def4 = InsertDefinition(new Date(2030, 3, 21), new Date(2030, 4, 14), functionalLocation);
            var def5 = InsertDefinition(new Date(2030, 3, 2), null, functionalLocation);
            var def6 = InsertDefinition(new Date(2030, 4, 13), null, functionalLocation);

            {
                DateTime? fromDate = null;
                DateTime? toDate = null;
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);

                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def1.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def2.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def3.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def4.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def6.Id));
                Assert.AreEqual(6, returnedDefinitions.Count);
            }

            {
                var fromDate = new DateTime(2030, 4, 11);
                var toDate = new DateTime(2030, 4, 15);
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);

                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def1.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def2.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def3.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def4.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def6.Id));
                Assert.AreEqual(6, returnedDefinitions.Count);
            }

            {
                var fromDate = new DateTime(2030, 3, 1);
                var toDate = new DateTime(2030, 3, 20);
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);

                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def1.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def2.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def3.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.AreEqual(4, returnedDefinitions.Count);
            }

            {
                var fromDate = new DateTime(2030, 4, 13);
                DateTime? toDate = null;
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);

                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def3.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def4.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def6.Id));
                Assert.AreEqual(4, returnedDefinitions.Count);
            }

            {
                DateTime? fromDate = new DateTime(2030, 3, 13);
                DateTime? toDate = new DateTime(2030, 3, 20);
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);

                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def1.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def2.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def3.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.AreEqual(4, returnedDefinitions.Count);
            }

            {
                DateTime? fromDate = new DateTime(2030, 5, 10);
                DateTime? toDate = null;
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def5.Id));
                Assert.IsTrue(returnedDefinitions.Exists(def => def.Id == def6.Id));
                Assert.AreEqual(2, returnedDefinitions.Count);
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationShouldNotReturnDefinitionsThatStartAfterTheEndOfTheSearchDateRange()
        {
            var functionalLocation = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();

            InsertDefinition(new Date(2012, 12, 1), null, functionalLocation);

            {
                var fromDate = new DateTime(2012, 4, 1);
                var toDate = new DateTime(2012, 4, 30);
                var returnedDefinitions = dtoDao.QueryByFunctionalLocations(new RootFlocSet(functionalLocation),
                    fromDate, toDate, null);
                Assert.AreEqual(0, returnedDefinitions.Count);
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocation_VaryVisibilityGroups()
        {
            var workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            var visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            var workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();

            var chapsVisibilityGroup = new VisibilityGroup(-1, "Chaps Department", Site.SARNIA_ID, false);
            var horseshoeVisibilityGroup = new VisibilityGroup(-1, "Horseshoe Department", Site.SARNIA_ID, false);

            visibilityGroupDao.Insert(chapsVisibilityGroup);
            visibilityGroupDao.Insert(horseshoeVisibilityGroup);

            var horseAssignment =
                workAssignmentDao.Insert(
                    WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Horse Supervisor"));
            var clothingAssignment =
                workAssignmentDao.Insert(
                    WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Cowboy Clothing Supervisor"));

            // horse supervisor can read info about chaps and horseshoes, but can only write about horseshoes
            var workAssignmentVisibilityGroup1 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue,
                chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            var workAssignmentVisibilityGroup2 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue,
                horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Write);
            var workAssignmentVisibilityGroup3 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue,
                horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            // cowboy clothing supervisor can read info about chaps and horseshoes, but can only write about chaps
            var workAssignmentVisibilityGroup4 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue,
                chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            var workAssignmentVisibilityGroup5 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue,
                chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Write);
            var workAssignmentVisibilityGroup6 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue,
                horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup1);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup2);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup3);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup4);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup5);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup6);

            var functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            IFlocSet flocSet = new RootFlocSet(functionalLocation);

            var def1 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 12), horseAssignment, functionalLocation);
            var def2 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 12), clothingAssignment,
                functionalLocation);
            var def3 = InsertDefinition(new Date(2030, 3, 2), new Date(2030, 4, 13), functionalLocation);

            var fromDate = new DateTime(2030, 4, 8);
            var toDate = new DateTime(2030, 4, 11);

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                var visibilityGroupIds = new List<long> {chapsVisibilityGroup.IdValue};

                var results1 = dtoDao.QueryByFunctionalLocations(flocSet, fromDate, toDate, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                var visibilityGroupIds = new List<long> {horseshoeVisibilityGroup.IdValue};
                var results1 = dtoDao.QueryByFunctionalLocations(flocSet, fromDate, toDate, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                var visibilityGroupIds = new List<long> {horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue};
                var results1 = dtoDao.QueryByFunctionalLocations(flocSet, fromDate, toDate, visibilityGroupIds);

                Assert.AreEqual(3, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == def1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == def3.Id));
            }
        }

        [Ignore] [Test]
        public void QueryByLinkedTargetDefinitionShouldReturnDTOs()
        {
            var newTargetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            newTargetDefinition.Assignment = null;
            newTargetDefinition = targetDefinitionDao.Insert(newTargetDefinition);
            var targetId = newTargetDefinition.IdValue;

            var id1 = InsertWithTargetDefinition(targetId, false);
            var id2 = InsertWithTargetDefinition(targetId, false);
            var id3 = InsertWithTargetDefinition(targetId, true);

            var actualList = dtoDao.QueryByTargetDefinitionId(targetId);
            Assert.IsTrue(actualList.Exists(obj => obj.Id == id1));
            Assert.IsTrue(actualList.Exists(obj => obj.Id == id2));
            Assert.IsFalse(actualList.Exists(obj => obj.Id == id3));
        }

        [Ignore] [Test]
        public void QueryByLinkedTargetDefinitionShouldReturnEmptyListWhenNoLinkedTarget()
        {
            long? targetId = 1;
            var actualList = dtoDao.QueryByTargetDefinitionId(targetId);
            Assert.IsNotNull(actualList);
            Assert.AreEqual(0, actualList.Count);
        }

        [Ignore] [Test]
        public void QueryByLinkedTargetDefinitionShouldReturnOnlyOneDTOPerActionItemDefinitionEvenIfItHasMultipleFlocs()
        {
            var newTargetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            newTargetDefinition.Assignment = null;
            newTargetDefinition = targetDefinitionDao.Insert(newTargetDefinition);
            var targetId = newTargetDefinition.IdValue;

            var definition = ActionItemDefinitionFixture.CreateWithLinkedTargetDefinition();
            definition.FunctionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(),
                FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM()
            };
            definition.TargetDefinitionDTOs[0].Id = targetId;
            actionItemDefinitionDao.Insert(definition);

            var actualList = dtoDao.QueryByTargetDefinitionId(targetId);
            Assert.AreEqual(1, actualList.Count);
            Assert.IsTrue(actualList.Exists(obj => obj.Id == definition.Id));
        }

        [Ignore] [Test]
        public void ShouldReturnAllFunctionalLocationsWhenOnlyOneMatchesTheSearchForFlocs()
        {
            var definition = InsertDefinition(new Date(2030, 3, 2), null,
                FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(),
                FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM());

            var results = dtoDao.QueryByFunctionalLocations(
                new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM()),
                new DateTime(2030, 3, 2), null, null);

            var result = results.Find(obj => obj.Id == definition.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.GetFunctionalLocationNames().Count);
            Assert.IsTrue(
                result.GetFunctionalLocationNames()
                    .Exists(obj => obj == FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF().FullHierarchy));
            Assert.IsTrue(
                result.GetFunctionalLocationNames()
                    .Exists(obj => obj == FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM().FullHierarchy));
        }

        [Ignore] [Test]
        public void ShouldReturnDefinitionsWithChildFlocsWhenLoggedInAt4thLevelFloc()
        {
            var definition = InsertDefinition(new Date(2030, 3, 2), null,
                FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB_02AC009());

            var results = dtoDao.QueryByFunctionalLocations(
                new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB()),
                new DateTime(2030, 3, 2), null, null);

            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.Exists(dto => dto.Id == definition.Id));
        }

        protected override void TestInitialize()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 12, 1, 13, 0, 0);

            dtoDao = DaoRegistry.GetDao<IActionItemDefinitionDTODao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            targetDefinitionDao = DaoRegistry.GetDao<ITargetDefinitionDao>();
        }

        protected override void Cleanup()
        {
            Clock.UnFreeze();
        }


        public void QueryByFunctionalLocationShouldReturnDTOs()
        {
            const long id = ActionItemDefinitionFixture.ACTION_ITEM_DEFINITION_WITH_2_COMMENTS_ID;
            var expected = actionItemDefinitionDao.QueryById(id);

            var functionalLocations = FunctionalLocationFixture.GetListWith2Units();
            functionalLocations.AddRange(expected.FunctionalLocations);

            DateTime? fromDate = null;
            DateTime? toDate = null;

            var dtos =
                dtoDao.QueryByFunctionalLocations(
                    new RootFlocSet(functionalLocations), fromDate, toDate, null);
            Assert.IsNotNull(dtos);
            Assert.IsTrue(dtos.Count > 0);

            var dto = dtos.Find(obj => obj.Id == id);
            Assert.IsNotNull(dto);

            Assert.AreEqual("Name 21", dto.Name);
            Assert.IsTrue(dto.ScheduleTypeName.Contains("Single"));
            Assert.AreEqual(2, dto.CategoryId);
            Assert.AreEqual(1, dto.StatusId);
            Assert.AreEqual("Approved", dto.StatusName);
            Assert.AreEqual(true, dto.IsApproved);
            Assert.AreEqual("Id = 21 - has 2 comments", dto.Description);
            Assert.AreEqual(2, dto.LastModifiedUserId);
            Assert.AreEqual(User.ToFullNameWithUserName("Simpson", "Bartholomew", "oltuser2"),
                dto.LastModifiedFullNameWithUserName);
            Assert.IsTrue(dto.GetFunctionalLocationNames().Count > 0);
            Assert.AreEqual(Priority.Normal, dto.Priority);
            Assert.IsNotNull(dto.StartDate);
        }

        private ActionItemDefinition InsertDefinition(Date fromDate, Date toDate, params FunctionalLocation[] flocs)
        {
            return InsertDefinition(fromDate, toDate, null, flocs);
        }

        private ActionItemDefinition InsertDefinition(Date fromDate, Date toDate, WorkAssignment assignment,
            params FunctionalLocation[] flocs)
        {
            var toInsert = ActionItemDefinitionFixture.CreateActionItemDefinitionWithoutId();

            toInsert.Schedule =
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15();

            toInsert.Schedule.StartDate = fromDate;
            toInsert.Schedule.EndDate = toDate;

            toInsert.FunctionalLocations.Clear();
            toInsert.FunctionalLocations.AddRange(flocs);

            toInsert.Assignment = assignment;

            Assert.IsFalse(toInsert.Id.HasValue);
            actionItemDefinitionDao.Insert(toInsert);

            return toInsert;
        }

        private long InsertWithTargetDefinition(long targetId, bool removed)
        {
            var definition = ActionItemDefinitionFixture.CreateWithLinkedTargetDefinition();
            definition.TargetDefinitionDTOs[0].Id = targetId;
            actionItemDefinitionDao.Insert(definition);
            if (removed)
            {
                actionItemDefinitionDao.Remove(definition);
            }
            return definition.IdValue;
        }
    }
}