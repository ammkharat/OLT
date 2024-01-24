using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class RoleElementDaoTest : AbstractDaoTest
    {
        private IRoleElementDao elementDao;

        protected override void TestInitialize()
        {
            elementDao = DaoRegistry.GetDao<IRoleElementDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldGetListOfRoleElementsForFirebagUsers()
        {
            Site site = SiteFixture.Firebag();

            {
                List<RoleElement> roleElements = elementDao.QueryTemplate(RoleFixture.GetRealRoleA(site.IdValue), false);
                Assert.IsNotEmpty(roleElements);
                Assert.IsTrue(roleElements.Exists(obj => obj.Id == RoleElement.VIEW_LOG.Id));
                foreach (RoleElement roleElement in roleElements)
                {
                    Assert.IsNull(roleElement.FunctionalArea);
                }
            }
            {
                List<RoleElement> roleElements = elementDao.QueryTemplate(RoleFixture.GetRealRoleB(site.IdValue), false);
                Assert.IsNotEmpty(roleElements);
                Assert.IsTrue(roleElements.Exists(obj => obj.Id == RoleElement.VIEW_LOG.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldGetFunctionalArea()
        {
            Site site = SiteFixture.Firebag();

            List<RoleElement> roleElements = elementDao.QueryTemplate(RoleFixture.GetRealRoleA(site.IdValue), true);
            Assert.IsNotEmpty(roleElements);
            foreach (RoleElement roleElement in roleElements)
            {
                Assert.IsNotNull(roleElement.FunctionalArea);
            }
        }

        [Ignore] [Test]
        public void ShouldKnowWhenASiteUsesARoleElement()
        {
            Assert.IsTrue(elementDao.IsSiteUsingRoleElement(SiteFixture.Firebag(), RoleElement.VIEW_FORM));
            Assert.IsTrue(elementDao.IsSiteUsingRoleElement(SiteFixture.Edmonton(), RoleElement.VIEW_FORM));
        }
    }
}