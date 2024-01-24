using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class WorkPermitMontrealGroupDaoTest : AbstractDaoTest
    {
        private IWorkPermitMontrealGroupDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateAndDelete()
        {
            const string groupName = "This is a new group";
            const int displayOrder = 55;

            const string newNameForNewGroup = "Name 2";
            const int newDisplayOrder = 42;

            long id;

            {
                WorkPermitMontrealGroup newGroup = new WorkPermitMontrealGroup(groupName, displayOrder);
                dao.Insert(newGroup);
                id = newGroup.IdValue;
            }

            WorkPermitMontrealGroup groupQueriedById = null;

            {
                groupQueriedById = dao.QueryById(id);
                Assert.IsNotNull(groupQueriedById);
                Assert.AreEqual(groupName, groupQueriedById.Name);
                Assert.AreEqual(displayOrder, groupQueriedById.DisplayOrder);                
            }

            {
                groupQueriedById.Name = newNameForNewGroup;
                groupQueriedById.DisplayOrder = newDisplayOrder;
                dao.Update(groupQueriedById);           
            }

            {
                WorkPermitMontrealGroup updatedGroup = dao.QueryById(id);
                Assert.AreEqual(newNameForNewGroup, updatedGroup.Name);
                Assert.AreEqual(newDisplayOrder, updatedGroup.DisplayOrder);
            }

            {
                WorkPermitMontrealGroup groupToDelete = dao.QueryById(id);
                List<WorkPermitMontrealGroup> allGroupsWithTheDeletedOneBecauseItHasntBeenDeletedYet = dao.QueryAll();
                Assert.IsNotNull(allGroupsWithTheDeletedOneBecauseItHasntBeenDeletedYet.Find(g => g.IdValue == groupToDelete.IdValue));

                dao.Remove(groupToDelete);

                List<WorkPermitMontrealGroup> allGroupsWithoutTheDeletedOneBecauseItsDeleted = dao.QueryAll();
                Assert.IsNull(allGroupsWithoutTheDeletedOneBecauseItsDeleted.Find(g => g.IdValue == groupToDelete.IdValue));
            }
        }
    }
}
