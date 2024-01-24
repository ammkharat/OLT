using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class RoleDisplayConfigurationDaoTest : AbstractDaoTest
    {
        private IRoleDisplayConfigurationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRoleDisplayConfigurationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldDeleteAndInsertNew()
        {
            Site site = SiteFixture.Oilsands();
            Role role = RoleFixture.GetRealRoleA(site.IdValue);

            {
                List<RoleDisplayConfiguration> configurations = new List<RoleDisplayConfiguration>();
                configurations.Add(new RoleDisplayConfiguration(
                    null, role, SectionKey.ActionItemSection, null, null)); // should not insert
                configurations.Add(new RoleDisplayConfiguration(
                    null, role, SectionKey.WorkPermitSection, PageKey.ACTION_ITEM_BY_ASSIGNMENT_PAGE, null));
                configurations.Add(new RoleDisplayConfiguration(
                    null, role, SectionKey.RestrictionSection, PageKey.LAB_ALERT_PAGE, PageKey.LOG_DEFINITION_PAGE));

                dao.DeleteAllAndInsertNew(site, configurations);
            }
            {
                List<RoleDisplayConfiguration> configurations = dao.QueryBySiteAndRole(site, role);
                Assert.AreEqual(2, configurations.Count);
                Assert.IsTrue(configurations.Exists(obj => 
                    obj.Role.Id == role.Id &&
                    obj.SectionKey.Id == SectionKey.WorkPermitSection.Id &&
                    obj.PrimaryPageKey.Id == PageKey.ACTION_ITEM_BY_ASSIGNMENT_PAGE.Id &&
                    obj.SecondaryPageKey == null));
                Assert.IsTrue(configurations.Exists(obj =>
                    obj.Role.Id == role.Id &&
                    obj.SectionKey.Id == SectionKey.RestrictionSection.Id &&
                    obj.PrimaryPageKey.Id == PageKey.LAB_ALERT_PAGE.Id &&
                    obj.SecondaryPageKey.Id == PageKey.LOG_DEFINITION_PAGE.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteAndRole()
        {
            Site site = SiteFixture.Oilsands();
            Role role = RoleFixture.GetRealRoleA(site.IdValue);

            List<RoleDisplayConfiguration> configurations = dao.QueryBySiteAndRole(site, role);
            Assert.IsNotEmpty(configurations);
            foreach (RoleDisplayConfiguration configuration in configurations)
            {
                Assert.AreEqual(role.Id, configuration.Role.Id);
                Assert.IsNotNull(configuration.SectionKey);
                Assert.IsNotNull(configuration.PrimaryPageKey);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryBySite()
        {
            Site site = SiteFixture.Oilsands();

            List<RoleDisplayConfiguration> configurations = dao.QueryBySite(site);
            Assert.IsNotEmpty(configurations);
            foreach (RoleDisplayConfiguration configuration in configurations)
            {
                Assert.IsNotNull(configuration.SectionKey);
                Assert.IsNotNull(configuration.PrimaryPageKey);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryBySite_NotReturnConfigurationForDeletedRole()
        {
            Site site = SiteFixture.Oilsands();
            Role role = RoleFixture.GetRealRoleA(site.IdValue);

            {
                List<RoleDisplayConfiguration> configurations = dao.QueryBySiteAndRole(site, role);
                Assert.IsNotEmpty(configurations);
            }
            TestDataAccessUtil.ExecuteExpression("update Role set Deleted = 1 where id = " + role.Id);
            {
                List<RoleDisplayConfiguration> configurations = dao.QueryBySiteAndRole(site, role);
                Assert.IsEmpty(configurations);
            }

        }
    }
}
