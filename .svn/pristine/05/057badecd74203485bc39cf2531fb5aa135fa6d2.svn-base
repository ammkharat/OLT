using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class RoleElementTemplateDaoTest : AbstractDaoTest
    {
        private IRoleElementTemplateDao dao;
        private IRoleElementDao roleElementDao;
        private IRoleDao roleDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRoleElementTemplateDao>();
            roleElementDao = DaoRegistry.GetDao<IRoleElementDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            RoleElement respondToLabAlert = RoleElement.RESPOND_TO_LAB_ALERT;

            List<Role> roles = roleDao.QueryBySiteId(Site.EDMONTON_ID);
            Role role = roles[0];

            List<RoleElement> originalRoleElements = roleElementDao.QueryTemplate(role, false);
            Assert.IsFalse(originalRoleElements.Contains(respondToLabAlert));

            dao.InsertRoleElementTemplate(SiteFixture.Edmonton(), role.Name, respondToLabAlert.Name);

            List<RoleElement> updatedRoleElements = roleElementDao.QueryTemplate(role, false);
            Assert.IsTrue(updatedRoleElements.Contains(respondToLabAlert));
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            List<Role> roles = roleDao.QueryBySiteId(Site.EDMONTON_ID);
            Role role = roles[0];

            List<RoleElement> originalRoleElements = roleElementDao.QueryTemplate(role, false);
            RoleElement roleElementToDelete = originalRoleElements[0];

            dao.DeleteRoleElementTemplate(SiteFixture.Edmonton(), role.Name, roleElementToDelete.Name);

            List<RoleElement> updatedRoleElements = roleElementDao.QueryTemplate(role, false);
            Assert.IsFalse(updatedRoleElements.Contains(roleElementToDelete));
        }
    }
}
