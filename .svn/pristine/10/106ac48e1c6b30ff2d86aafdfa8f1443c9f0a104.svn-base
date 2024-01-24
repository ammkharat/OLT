using System.Collections.Generic;
using System.Collections.ObjectModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkAssignmentVisibilityGroupDaoTest : AbstractDaoTest
    {
        private IWorkAssignmentVisibilityGroupDao dao;
        private IVisibilityGroupDao visibilityGroupDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();
            visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            List<VisibilityGroup> visibilityGroups = visibilityGroupDao.QueryAll(SiteFixture.Sarnia().IdValue);
            VisibilityGroup visibilityGroup = visibilityGroups[0];

            WorkAssignment workAssignment = WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Some Assignment");
            DaoRegistry.GetDao<IWorkAssignmentDao>().Insert(workAssignment);

            WorkAssignmentVisibilityGroup wavg1 = new WorkAssignmentVisibilityGroup(null, workAssignment.IdValue, visibilityGroup.IdValue, visibilityGroup.Name, VisibilityType.Read);
            WorkAssignmentVisibilityGroup wavg2 = new WorkAssignmentVisibilityGroup(null, workAssignment.IdValue, visibilityGroup.IdValue, visibilityGroup.Name, VisibilityType.Write);

            dao.Insert(wavg1);
            dao.Insert(wavg2);

            Assert.IsNotNull(wavg1.Id);
            Assert.IsNotNull(wavg2.Id);

            List<WorkAssignmentVisibilityGroup> queriedWorkAssignmentVisibilityGroups = dao.QueryByWorkAssignmentId(workAssignment.IdValue);
            Assert.AreEqual(2, queriedWorkAssignmentVisibilityGroups.Count);

            WorkAssignmentVisibilityGroup queriedWavg1 = queriedWorkAssignmentVisibilityGroups.Find(g => g.Id == wavg1.Id);
            Assert.AreEqual(visibilityGroup.IdValue, queriedWavg1.VisibilityGroupId);
            Assert.AreEqual(visibilityGroup.Name, queriedWavg1.VisibilityGroupName);
            Assert.AreEqual(VisibilityType.Read, queriedWavg1.VisibilityType);

            WorkAssignmentVisibilityGroup queriedWavg2 = queriedWorkAssignmentVisibilityGroups.Find(g => g.Id == wavg2.Id);
            Assert.AreEqual(visibilityGroup.IdValue, queriedWavg2.VisibilityGroupId);
            Assert.AreEqual(visibilityGroup.Name, queriedWavg2.VisibilityGroupName);
            Assert.AreEqual(VisibilityType.Write, queriedWavg2.VisibilityType);
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            List<WorkAssignment> workAssignments = workAssignmentDao.QueryBySiteId(SiteFixture.Edmonton().IdValue);
            Assert.That(workAssignments.Count, Is.GreaterThan(0));

            WorkAssignment workAssignment = workAssignments.Find(wa => !wa.WorkAssignmentVisibilityGroups.IsEmpty());
            ReadOnlyCollection<WorkAssignmentVisibilityGroup> groups = workAssignment.WorkAssignmentVisibilityGroups;
            Assert.That(groups.Count, Is.GreaterThan(0));

            foreach(WorkAssignmentVisibilityGroup group in groups)
            {
                dao.Remove(group);
            }

            //re-get the work assignment and make sure there are no groups attached now.
            workAssignment = workAssignmentDao.QueryById(workAssignment.IdValue);
            Assert.That(workAssignment, Is.Not.Null);
            Assert.That(workAssignment.WorkAssignmentVisibilityGroups.Count, Is.EqualTo(0));
        }

        [Ignore] [Test]
        public void ShouldQueryByVisibilityGroupId()
        {
            List<WorkAssignmentVisibilityGroup> result = dao.QueryByVisibilityGroupId(1);
            Assert.That(result, Is.Not.Null.And.Count.GreaterThan(0));
        }
    }
}
