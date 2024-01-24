using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class VisibilityGroupDaoTest : AbstractDaoTest
    {
        private IVisibilityGroupDao dao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldGetOperationsGroupForSite()
        {            
            List<VisibilityGroup> groups = dao.QueryAll(SiteFixture.Edmonton().IdValue);
            Assert.That(groups.Exists(g => g.Name.Equals("Running Unit Operations")), Is.True);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {            
            VisibilityGroup visibilityGroup = new VisibilityGroup(null, "Horses", SiteFixture.Edmonton().IdValue, false);
            dao.Insert(visibilityGroup);

            Assert.IsNotNull(visibilityGroup.Id);

            List<VisibilityGroup> groups = dao.QueryAll(SiteFixture.Edmonton().IdValue);

            List<VisibilityGroup> returnedGroups = groups.FindAll(g => g.Id == visibilityGroup.Id);
            Assert.AreEqual(1, returnedGroups.Count);
            Assert.AreEqual("Horses", returnedGroups[0].Name);
        }

        [Ignore] [Test]
        public void ShouldDetermineIfAssociatedToWorkAssignment()
        {
            List<WorkAssignment> assignmentsForSite = workAssignmentDao.QueryBySiteId(Site.EDMONTON_ID);

            if (assignmentsForSite.Count == 0)
            {
                throw new Exception("This test needs at least 1 work assignment");
            }

            VisibilityGroup visibilityGroup = new VisibilityGroup(null, "Horses", SiteFixture.Edmonton().IdValue, false);
            VisibilityGroup insertedGroup = dao.Insert(visibilityGroup);

            WorkAssignment assignment = assignmentsForSite[0];
            assignment.AddVisibilityGroup(new WorkAssignmentVisibilityGroup(null, assignment.Id, insertedGroup.IdValue, insertedGroup.Name, VisibilityType.Write));
            workAssignmentDao.Update(assignment);

            Assert.IsFalse(dao.IsAssociatedToWorkAssignments(visibilityGroup, VisibilityType.Read));
            Assert.IsTrue(dao.IsAssociatedToWorkAssignments(visibilityGroup, VisibilityType.Write));
        }
    }
}