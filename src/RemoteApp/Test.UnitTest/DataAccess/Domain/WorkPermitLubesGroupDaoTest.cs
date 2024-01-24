using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitLubesGroupDaoTest : AbstractDaoTest
    {
        private IWorkPermitLubesGroupDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
        }

        protected override void Cleanup()
        {            
        }

        [Ignore] [Test]
        public void ShouldQueryAll()
        {
            List<WorkPermitLubesGroup> groups = dao.QueryAll();
            Assert.That(groups.Count >= 2);

            List<WorkPermitLubesGroup> groupsNamedMaintenance = groups.FindAll(group => group.Name == "Maintenance");
            Assert.AreEqual(1, groupsNamedMaintenance.Count);

            List<WorkPermitLubesGroup> groupsNamedConstruction = groups.FindAll(group => group.Name == "Construction");
            Assert.AreEqual(1, groupsNamedConstruction.Count);
        }

        [Ignore] [Test]
        public void GroupsShouldHaveAssociatedPrioritiesOnQueryAll()
        {
            // This test uses existing data, sorry. When the code is written in the future to insert these things then it would be good to fix this test.
            List<WorkPermitLubesGroup> groups = dao.QueryAll();

            {
                WorkPermitLubesGroup group = groups.Find(g => g.Name == "Maintenance");
                Assert.IsNotNull(group);
                Assert.IsTrue(group.SAPImportPriorityList.Exists(p => p == 1));
                Assert.IsTrue(group.SAPImportPriorityList.Exists(p => p == 2));
            }

            {
                WorkPermitLubesGroup group = groups.Find(g => g.Name == "Construction");
                Assert.IsNotNull(group);
                Assert.IsTrue(group.SAPImportPriorityList.Count == 0);
                Assert.IsTrue(group.SAPImportPlanningGroupList.Exists(pg => pg.Equals("PE1")));
            }
        }

        [Ignore] [Test]
        public void GroupsShouldHaveAssociatedPrioritiesOnQueryById()
        {
            WorkPermitLubesGroup group = dao.QueryById(1);
            Assert.IsNotNull(group);

            Assert.IsTrue(group.SAPImportPriorityList.Exists(p => p == 1));
            Assert.IsTrue(group.SAPImportPriorityList.Exists(p => p == 2));
        }
    }
}
