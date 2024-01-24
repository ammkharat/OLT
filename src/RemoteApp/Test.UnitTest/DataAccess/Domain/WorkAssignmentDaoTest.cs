using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkAssignmentDaoTest : AbstractDaoTest
    {
        private IWorkAssignmentDao dao;
        private IFunctionalLocationDao flocDao;
        private ILogTemplateDao logTemplateDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            logTemplateDao = DaoRegistry.GetDao<ILogTemplateDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            LogTemplate logTemplate = logTemplateDao.Insert(new LogTemplate("lt", "text", new List<WorkAssignment>(), true, true, true, UserFixture.CreateAdmin(), Clock.Now, UserFixture.CreateAdmin(), Clock.Now));

            WorkAssignment initialAssignment =
                new WorkAssignment(null, "Silly Name", "Silly Description", "Silly category", 1, RoleFixture.GetRealRoleA(1), true, true, null, null, logTemplate.IdValue,true,true);

            WorkAssignment returnedAssignment = dao.Insert(initialAssignment);
            Assert.IsNotNull(initialAssignment.IdValue);

            WorkAssignment persistedAssignment = dao.QueryById(returnedAssignment.IdValue);
            Assert.IsTrue(persistedAssignment.CopyTargetAlertResponseToLog);
            Assert.IsTrue(persistedAssignment.ShowEventExcursionsOnShiftHandoverReport);
            Assert.IsTrue(persistedAssignment.ShowLubesCsdOnShiftHandoverReport);
            Assert.AreEqual(initialAssignment.Name, persistedAssignment.Name);
            Assert.AreEqual(initialAssignment.Description, persistedAssignment.Description);
            Assert.AreEqual(initialAssignment.SiteId, persistedAssignment.SiteId);
            Assert.AreEqual(initialAssignment.Role.Id, persistedAssignment.Role.Id);
            Assert.IsTrue(persistedAssignment.UseWorkAssignmentForActionItemHandoverDisplay);
            Assert.AreEqual(initialAssignment.AutoInsertLogTemplateId, persistedAssignment.AutoInsertLogTemplateId);
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteIdSortedByName()
        {
            const long siteId = 2;

            WorkAssignment assignmentToInsert1 =
                new WorkAssignment(null, "1", "A Assignment", "category 1", siteId, RoleFixture.GetRealRoleA(siteId), true, true, null, null, null,true,true);
            WorkAssignment assignmentToInsert2 =
                new WorkAssignment("2", "B Assignment", "category 2", siteId, RoleFixture.GetRealRoleB(siteId));
            dao.Insert(assignmentToInsert2);
            dao.Insert(assignmentToInsert1);

            List<WorkAssignment> assignments = dao.QueryBySiteId(siteId);
            Assert.IsNotNull(assignments);
            Assert.That(assignments.Count, Is.GreaterThan(1));

            Assert.That(assignments[0].Category, Is.EqualTo(assignmentToInsert1.Category));
            Assert.That(assignments[0], Is.EqualTo(assignmentToInsert1));

            Assert.That(assignments[1], Is.EqualTo(assignmentToInsert2));
        }

        [Ignore] [Test]
        public void ShouldQueryByFunctionalLocationsMatchExactlyOrByParentOrByChild()
        {
            FunctionalLocation floc1 = AddFloc("A");
            FunctionalLocation floc2 = AddFloc("A-B1");
            FunctionalLocation floc3 = AddFloc("A-B2");
            FunctionalLocation floc4 = AddFloc("A-B1-C1");
            FunctionalLocation floc5 = AddFloc("A-B1-C2");
            FunctionalLocation floc6 = AddFloc("A-B1-C1-D1");
            FunctionalLocation floc7 = AddFloc("A-B1-C1-D2");
            FunctionalLocation floc8 = AddFloc("A-B1-C1-D1-E1");
            FunctionalLocation floc9 = AddFloc("A-B1-C1-D1-E2");

            WorkAssignment assignment1 = AddWorkAssignment(floc1);
            WorkAssignment assignment2 = AddWorkAssignment(floc2);
            WorkAssignment assignment3 = AddWorkAssignment(floc3);
            WorkAssignment assignment4 = AddWorkAssignment(floc4);
            WorkAssignment assignment5 = AddWorkAssignment(floc5);
            WorkAssignment assignment6 = AddWorkAssignment(floc6);
            WorkAssignment assignment7 = AddWorkAssignment(floc7);
            WorkAssignment assignment8 = AddWorkAssignment(floc8);
            WorkAssignment assignment9 = AddWorkAssignment(floc9);

            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc1));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc2));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc3));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc4));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc5));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc6));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc7));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc8));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment9.Id));
            }
            {
                List<WorkAssignment> results = dao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    new RootFlocSet(floc9));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == assignment8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == assignment9.Id));
            }
        }

        private WorkAssignment AddWorkAssignment(FunctionalLocation functionalLocation)
        {
            WorkAssignment workAssignment = new WorkAssignment(
                null,
                "wa-" + functionalLocation.FullHierarchy,
                "test work assignment",
                null,
                functionalLocation.Site.IdValue,
                RoleFixture.GetRealRoleA(functionalLocation.Site.IdValue),
                true, true,
                null, null, null,true,true);

            workAssignment = dao.Insert(workAssignment);

            workAssignment.FunctionalLocations.Clear();
            workAssignment.FunctionalLocations.Add(functionalLocation);
            dao.UpdateFunctionalLocations(workAssignment);

            return workAssignment;
        }

        private FunctionalLocation AddFloc(string fullHierarchy)
        {
            FunctionalLocation floc =
                new FunctionalLocation(
                    SiteFixture.Oilsands(), fullHierarchy, PlantFixture.OilsandsPlants()[0].IdValue, fullHierarchy, Culture.DEFAULT_CULTURE_NAME);
            return flocDao.Insert(floc);
        }

        [Ignore] [Test]
        public void ShouldIncludeFunctionalLocationsWhenQueryingById()
        {
            WorkAssignment assignment =
                new WorkAssignment(null, "Silly Name", "Silly Description", "Silly category", 2, RoleFixture.GetRealRoleA(2), true, true, null, null, null,true,true);
            assignment.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1_3003_0000());
            assignment.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3());
            assignment = dao.Insert(assignment);
            dao.UpdateFunctionalLocations(assignment);

            WorkAssignment requeried = dao.QueryById(assignment.IdValue);
            List<FunctionalLocation> locations = new List<FunctionalLocation>(requeried.FunctionalLocations);
            Assert.IsNotNull(locations);
            Assert.AreEqual(2, locations.Count);
            Assert.IsTrue(locations.ExistsById(assignment.FunctionalLocations[0]));
            Assert.IsTrue(locations.ExistsById(assignment.FunctionalLocations[1]));
        }

        [Ignore] [Test]
        public void ShouldUpdateFunctionalLocations()
        {
            WorkAssignment assignment =
                new WorkAssignment(null, "Silly Name", "Silly Description", "Silly category", 2, RoleFixture.GetRealRoleA(2), false, true, null, null, null,true,true);
            assignment.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1_3003_0000());
            assignment.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3());
            assignment = dao.Insert(assignment);
            dao.UpdateFunctionalLocations(assignment);

            WorkAssignment requeried = dao.QueryById(assignment.IdValue);

            Assert.IsFalse(requeried.UseWorkAssignmentForActionItemHandoverDisplay);
            requeried.FunctionalLocations.Add(FunctionalLocationFixture.GetReal("SR1-PLT3-FRAU"));
            requeried.FunctionalLocations.Add(FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3"));
            dao.UpdateFunctionalLocations(requeried);
            requeried = dao.QueryById(assignment.IdValue);
            Assert.AreEqual(4, requeried.FunctionalLocations.Count);
        }

        [Ignore] [Test]
        public void ShouldRemoveWorkAssignment()
        {
            List<WorkAssignment> workAssignmentsInDenver = dao.QueryBySiteId(2);
            int numberOfActiveWorkAssignmentsInDenver = workAssignmentsInDenver.Count;
            Assert.That(numberOfActiveWorkAssignmentsInDenver, Is.GreaterThan(0));

            WorkAssignment toRemove = workAssignmentsInDenver[0];
            dao.Remove(toRemove);

            Assert.AreEqual(numberOfActiveWorkAssignmentsInDenver - 1, dao.QueryBySiteId(2).Count);
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkAssignment()
        {
            LogTemplate logTemplate = logTemplateDao.Insert(new LogTemplate("lt", "text", new List<WorkAssignment>(), true, true, true, UserFixture.CreateAdmin(), Clock.Now, UserFixture.CreateAdmin(), Clock.Now));

            const long idWithGoodTestData = 1;
            WorkAssignment assignment = dao.QueryById(idWithGoodTestData);
            Assert.IsNotNull(assignment);

            Assert.IsTrue(assignment.UseWorkAssignmentForActionItemHandoverDisplay);
            Assert.IsTrue(assignment.CopyTargetAlertResponseToLog);
            Assert.IsFalse(assignment.ShowLubesCsdOnShiftHandoverReport);
            Assert.IsFalse(assignment.ShowEventExcursionsOnShiftHandoverReport);
            Assert.IsNull(assignment.AutoInsertLogTemplateId);

            Role role1 = RoleFixture.GetRealRoleA(assignment.SiteId);
            Role role2 = RoleFixture.GetRealRoleB(assignment.SiteId);

            const string newName = "Changed the name";
            assignment.Name = newName;
            assignment.Role = role1;
            assignment.ShowLubesCsdOnShiftHandoverReport = true;
            assignment.ShowEventExcursionsOnShiftHandoverReport = true;
            assignment.UseWorkAssignmentForActionItemHandoverDisplay = false;
            assignment.CopyTargetAlertResponseToLog = false;
            assignment.AutoInsertLogTemplateId = logTemplate.IdValue;

            dao.Update(assignment);

            {
                WorkAssignment requeried = dao.QueryById(idWithGoodTestData);
                Assert.AreEqual(newName, requeried.Name);
                Assert.AreEqual(role1.Id, requeried.Role.Id);
                Assert.IsFalse(requeried.UseWorkAssignmentForActionItemHandoverDisplay);
                Assert.IsFalse(requeried.CopyTargetAlertResponseToLog);
                Assert.IsTrue(requeried.ShowEventExcursionsOnShiftHandoverReport);
                Assert.IsTrue(requeried.ShowLubesCsdOnShiftHandoverReport);
                Assert.IsFalse(requeried.CopyTargetAlertResponseToLog);
                Assert.AreEqual(logTemplate.IdValue, requeried.AutoInsertLogTemplateId);
            }

            assignment.Role = role2;
            assignment.UseWorkAssignmentForActionItemHandoverDisplay = true;
            assignment.CopyTargetAlertResponseToLog = true;
            assignment.AutoInsertLogTemplateId = null;
            dao.Update(assignment);

            {
                WorkAssignment requeried = dao.QueryById(idWithGoodTestData);
                Assert.IsTrue(requeried.ShowLubesCsdOnShiftHandoverReport);
                Assert.AreEqual(role2.Id, requeried.Role.Id);
                Assert.IsTrue(requeried.UseWorkAssignmentForActionItemHandoverDisplay);
                Assert.IsTrue(requeried.ShowLubesCsdOnShiftHandoverReport);
                Assert.IsNull(requeried.AutoInsertLogTemplateId);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryAndUpdateUnitsWithNullWorkAssignmentId()
        {
            WorkAssignment initialWorkAssignment =
                new WorkAssignment(null, "Silly Name", "Silly Description", "Silly Category", 1, RoleFixture.GetRealRoleA(1), true, true, null, null, null,true,true);
            WorkAssignment assignmentReturnedFromInsert = dao.Insert(initialWorkAssignment);

            WorkAssignment assignment = dao.QueryById(assignmentReturnedFromInsert.IdValue);

            assignment.Description = "Some new Description";

            dao.Update(assignment);

            WorkAssignment updatedAssignment = dao.QueryById(assignmentReturnedFromInsert.IdValue);
            Assert.AreEqual("Some new Description", updatedAssignment.Description); // Sanity check that it updated.            
        }

        [Ignore] [Test]
        public void ShouldUpdateFunctionalLocationsForWorkPermits()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            WorkAssignment assignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            AssignmentFlocConfiguration configuration = new AssignmentFlocConfiguration(assignment.IdValue, "Blazinga", "role name", "desc", "category",
                                                                                                    new List<FunctionalLocation> {floc1, floc2});

            {
                dao.UpdateFunctionalLocationsForWorkPermits(configuration);

                List<FunctionalLocation> flocs = flocDao.QueryByWorkAssignmentIdForWorkPermits(assignment.IdValue);
                Assert.AreEqual(2, flocs.Count);
                Assert.IsTrue(flocs.Exists(floc => floc.Id == floc1.Id));
                Assert.IsTrue(flocs.Exists(floc => floc.Id == floc2.Id));
            }

            {
                configuration.FunctionalLocations.Clear();
                configuration.FunctionalLocations.Add(floc1);
                dao.UpdateFunctionalLocationsForWorkPermits(configuration);

                List<FunctionalLocation> flocs = flocDao.QueryByWorkAssignmentIdForWorkPermits(assignment.IdValue);
                Assert.AreEqual(1, flocs.Count);
                Assert.IsTrue(flocs.Exists(floc => floc.Id == floc1.Id));
            }

            {
                configuration.FunctionalLocations.Clear();
                configuration.FunctionalLocations.Add(floc1);
                configuration.FunctionalLocations.Add(floc2);
                dao.UpdateFunctionalLocationsForWorkPermits(configuration);

                List<FunctionalLocation> flocs = flocDao.QueryByWorkAssignmentIdForWorkPermits(assignment.IdValue);
                Assert.AreEqual(2, flocs.Count);
                Assert.IsTrue(flocs.Exists(floc => floc.Id == floc1.Id));
                Assert.IsTrue(flocs.Exists(floc => floc.Id == floc2.Id));
            }
        }
    }
}