using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class SiteConfigurationDefaultsDaoTest : AbstractDaoTest
    {
        ISiteConfigurationDefaultsDao dao;
        ISiteDao siteDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISiteConfigurationDefaultsDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        protected override void Cleanup()
        {

        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            {
                SiteConfigurationDefaults defaults = dao.QueryBySiteId(3);
                Assert.IsNotNull(defaults);
                Assert.IsFalse(defaults.CopyTargetAlertResponseToLog);                
            }

            {
                SiteConfigurationDefaults defaults = dao.QueryBySiteId(1);
                Assert.IsNotNull(defaults);
                Assert.IsTrue(defaults.CopyTargetAlertResponseToLog);                
            }
        }

        [Ignore] [Test]
        public void AllSitesShouldHaveAnEntryInTheTable()
        {
            List<Site> sites = siteDao.QueryAll();

            foreach (Site site in sites)
            {
                SiteConfigurationDefaults defaults = dao.QueryBySiteId(site.IdValue);                
                Assert.IsNotNull(defaults, "There is no SiteConfigurationDefaults entry for site: " + site.Name);
            }
        }
    }
}
