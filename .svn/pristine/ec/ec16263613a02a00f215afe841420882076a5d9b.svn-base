using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class RolePermissionDaoTest:AbstractDaoTest
    {
        private IRolePermissionDao rolePermissionDao;
        private IRoleDao roleDao;
        private ISiteDao siteDao;
        private IRoleElementDao roleElementDao;

        protected override void TestInitialize()
        {
            rolePermissionDao = DaoRegistry.GetDao<IRolePermissionDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            roleElementDao = DaoRegistry.GetDao<IRoleElementDao>();

        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryByRoleId()
        {
            List<RolePermission> rolePermissions = rolePermissionDao.QueryByRoleId(49);
            Assert.IsNotEmpty(rolePermissions);
            Assert.IsNotNull(rolePermissions[0].RoleId);
            Assert.IsNotNull(rolePermissions[0].RoleElementId);
            Assert.IsNotNull(rolePermissions[0].CreatedByRoleId);
            Assert.AreEqual(49, rolePermissions[0].RoleId);
        }

        [Ignore] [Test]
        public void ShouldOnlyHaveRolePermissionsForRoleTemplates()
        {
            List<Site> sites = siteDao.QueryAll();
            foreach (Site site in sites)
            {
                List<Role> roles = roleDao.QueryBySiteId(site.IdValue);

                foreach (Role role in roles)
                {
                    List<RolePermission> permissions = rolePermissionDao.QueryByRoleId(role.IdValue);
                    AssertNoDuplicates(permissions);

                    List<RoleElement> templates = roleElementDao.QueryTemplate(role, false);
                    AssertHasTemplate(permissions, templates);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            List<Role> roles = roleDao.QueryBySiteId(Site.SARNIA_ID);
            Role supervisorRole = roles.Find(r => r.Name == "Supervisor");
            Role administratorRole = roles.Find(r => r.Name == "Administrator");

            RolePermission rolePermission = new RolePermission(supervisorRole.IdValue, RoleElement.CREATE_FORM.IdValue, administratorRole.IdValue);

            // make sure it's not already in there, although that would be pretty unbelievable
            List<RolePermission> originalSupervisorRolePermissions = rolePermissionDao.QueryByRoleId(supervisorRole.IdValue);
            Assert.IsFalse(originalSupervisorRolePermissions.Exists(p => p.RoleId == rolePermission.RoleId && p.RoleElementId == rolePermission.RoleElementId && p.CreatedByRoleId == rolePermission.CreatedByRoleId));

            rolePermissionDao.Insert(rolePermission);

            List<RolePermission> newSupervisorRolePermissions = rolePermissionDao.QueryByRoleId(supervisorRole.IdValue);
            Assert.IsTrue(newSupervisorRolePermissions.Exists(p => p.RoleId == rolePermission.RoleId && p.RoleElementId == rolePermission.RoleElementId && p.CreatedByRoleId == rolePermission.CreatedByRoleId));
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            List<Role> roles = roleDao.QueryBySiteId(Site.SARNIA_ID);
            Role supervisorRole = roles.Find(r => r.Name == "Supervisor");

            RolePermission permission = rolePermissionDao.QueryByRoleId(supervisorRole.IdValue)[0];
            rolePermissionDao.Delete(permission);

            List<RolePermission> newSupervisorRolePermissions = rolePermissionDao.QueryByRoleId(supervisorRole.IdValue);
            Assert.IsFalse(newSupervisorRolePermissions.Exists(p => p.RoleId == permission.RoleId && p.RoleElementId == permission.RoleElementId && p.CreatedByRoleId == permission.CreatedByRoleId));
        }

        private static void AssertNoDuplicates(List<RolePermission> permissions)
        {
            foreach (RolePermission current in permissions)
            {
                List<RolePermission> duplicates = permissions.FindAll(obj =>
                    obj.CreatedByRoleId == current.CreatedByRoleId &&
                    obj.RoleElementId == current.RoleElementId &&
                    obj.RoleId == current.RoleId);
                Assert.AreEqual(1, duplicates.Count, current.ReflectionToString());
            }
        }

        private void AssertHasTemplate(List<RolePermission> permissions, List<RoleElement> templates)
        {
            foreach (RolePermission permission in permissions)
            {
                RoleElement roleElement = templates.Find(obj => obj.Id == permission.RoleElementId);
                Assert.IsNotNull(roleElement, permission.ReflectionToString());
            }
        }
    }
}
