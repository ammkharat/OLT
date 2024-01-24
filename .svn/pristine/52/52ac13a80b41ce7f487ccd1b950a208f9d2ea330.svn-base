using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitEdmontonGroupDaoTest : AbstractDaoTest
    {
        private IWorkPermitEdmontonGroupDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
        }

        protected override void Cleanup()
        {            
        }

        [Ignore] [Test]
        public void ShouldQueryAll()
        {
            dao.Insert(new WorkPermitEdmontonGroup(-1, "Whatever", new List<long> {2, 3}, 1, false));
            dao.Insert(new WorkPermitEdmontonGroup(-1, "Heyo", new List<long> { 4 }, 1, false));

            List<WorkPermitEdmontonGroup> groups = dao.QueryAll();
            Assert.That(groups.Count >= 2);

            List<WorkPermitEdmontonGroup> groupsNamedWhatever = groups.FindAll(group => group.Name == "Whatever");
            Assert.AreEqual(1, groupsNamedWhatever.Count);
            Assert.AreEqual(2, groupsNamedWhatever[0].SAPImportPriorityList.Count);
            Assert.IsTrue(groupsNamedWhatever[0].SAPImportPriorityList.Contains(2));
            Assert.IsTrue(groupsNamedWhatever[0].SAPImportPriorityList.Contains(3));
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            WorkPermitEdmontonGroup insertedGroup = dao.Insert(new WorkPermitEdmontonGroup(-1, "Whatever", new List<long> {2, 3}, 1, false));

            WorkPermitEdmontonGroup requeried = dao.QueryById(insertedGroup.IdValue);
            Assert.AreEqual(insertedGroup.Id, requeried.Id);
            Assert.AreEqual(2, insertedGroup.SAPImportPriorityList.Count);
            Assert.IsTrue(insertedGroup.SAPImportPriorityList.Contains(2));
            Assert.IsTrue(insertedGroup.SAPImportPriorityList.Contains(3));
        }
    }
}
