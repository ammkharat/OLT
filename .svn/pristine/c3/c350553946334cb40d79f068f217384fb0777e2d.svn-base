using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class RoleDaoTest : AbstractDaoTest
    {
        private const string ACTIVE_DIRECTORY_KEY = "RestrictionReportingAdmin";

        private IRoleDao dao;
        private ISiteDao siteDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRoleDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            List<Role> roleList = dao.QueryBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.IsNotEmpty(roleList);

            Role expected = roleList[0];
            Role actual = dao.QueryById(expected.IdValue);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.IdValue, actual.IdValue);
        }

        [Ignore] [Test]
        public void ShouldQueryByActiveDirectoryKey_ReturnTheCorrectRole()
        {
            Role role = dao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), ACTIVE_DIRECTORY_KEY);
            Assert.IsNotNull(role);
            Assert.AreEqual("Restriction Reporting Admin", role.Name);
        }

        [Ignore] [Test]
        public void ShouldQueryByActiveDirectoryKey_NotReturnDeleted()
        {
            {
                Role role = dao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), ACTIVE_DIRECTORY_KEY);
                Assert.IsNotNull(role);
                TestDataAccessUtil.ExecuteExpression("update Role set Deleted = 1 where id = " + role.Id);
            }
            {
                Role role = dao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), ACTIVE_DIRECTORY_KEY);
                Assert.IsNull(role);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryAllAvailableInSiteWithAnyRoleElement()
        {
            List<Role> roles = dao.QueryAllAvailableInSiteWithAnyRoleElement(
                SiteFixture.Oilsands().IdValue,
                new List<RoleElement>
                    {
                        RoleElement.CREATE_SHIFT_HANDOVER_QUESTIONNAIRE,
                        RoleElement.EDIT_SHIFT_HANDOVER_QUESTIONNAIRE
                    });

            Assert.IsTrue(roles.Exists(obj => obj.Name == "Supervisor"));
            Assert.IsTrue(roles.Exists(obj => obj.Name == "Operator"));
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            List<Role> sarniaRoles = dao.QueryBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.IsTrue(sarniaRoles.Exists(obj => obj.Name == "Supervisor"));
            Assert.IsTrue(sarniaRoles.Exists(obj => obj.Name == "Operations Support"));

            List<Role> oilsandsRoles = dao.QueryBySiteId(SiteFixture.Oilsands().IdValue);
            Assert.IsTrue(oilsandsRoles.Exists(obj => obj.Name == "Restriction Reporting Admin"));
            Assert.IsTrue(oilsandsRoles.Exists(obj => obj.Name == "Area Manager"));
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId_NotReturnDeleted()
        {
            List<Role> allRoles = dao.QueryBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.IsNotEmpty(allRoles);
            Role role = allRoles[0];

            TestDataAccessUtil.ExecuteExpression("update Role set Deleted = 1 where id = " + role.Id);

            {
                List<Role> requeriedRoles = dao.QueryBySiteId(SiteFixture.Sarnia().IdValue);
                Assert.IsFalse(requeriedRoles.Exists(obj => obj.Id == role.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldFindReadOnlyUserForEachSite()
        {
            List<Site> sites = siteDao.QueryAll();
            foreach (Site site in sites)
            {
                Role role = dao.QueryDefaultReadOnlyRole(site);
                Assert.IsNotNull(role);
                Assert.IsTrue(role.IsReadOnlyRole);
            }
        }

        [Ignore] [Test]
        public void ShouldFindExactlyOneDefaultReadOnlyUserForEachSite()
        {
            List<Site> sites = siteDao.QueryAll();
            foreach (Site site in sites)
            {
                List<Role> roles = dao.QueryBySiteId(site.IdValue);
                List<Role> readOnlyRoles = roles.FindAll(obj => obj.IsDefaultReadOnlyRoleForSite);
                Assert.AreEqual(1, readOnlyRoles.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkAssignmentNotSelectedWarning()
        {
            List<Role> allRoles = dao.QueryBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.IsNotEmpty(allRoles);
            Role role = allRoles[0];

            role.WarnIfWorkAssignmentNotSelected = true;
            dao.UpdateWorkAssignmentNotSelectedWarning(role);

            {
                Role requeried = dao.QueryById(role.IdValue);
                Assert.IsTrue(requeried.WarnIfWorkAssignmentNotSelected);
            }

            role.WarnIfWorkAssignmentNotSelected = false;
            dao.UpdateWorkAssignmentNotSelectedWarning(role);

            {
                Role requeried = dao.QueryById(role.IdValue);
                Assert.IsFalse(requeried.WarnIfWorkAssignmentNotSelected);
            }
        }
    }
}
