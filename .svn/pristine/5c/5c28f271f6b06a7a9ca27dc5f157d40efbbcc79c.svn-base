using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SiteDaoTest : AbstractDaoTest
    {
        private ISiteDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISiteDao>();
        }

        [SetUp]
        public void Setup()
        {
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryAllSitesShouldReturnAListOfSites()
        {
            Assert.IsTrue(dao.QueryAll().Count > 0);
        }

        [Ignore] [Test]
        public void QueryByIdWithKnownIdReturnsASite()
        {
            Site site = dao.QueryById(3);
            Assert.AreEqual(3, site.Id);
            Assert.AreEqual("Oilsands", site.Name);
            Assert.AreEqual(TimeZoneFixture.GetMountainTimeZone(), site.TimeZone);
        }

        [Ignore] [Test]
        public void QueryByPlantIdWithKnownIdReturnsASite()
        {
            Site site = dao.QueryByPlantId("4000");
            Assert.IsNotNull(site);
        }

        [Ignore] [Test]
        public void QueryByActiveDirectoryKeyReturnsASite()
        {
            Site site = dao.QueryByActiveDirectoryKey("Sarnia");
            Assert.IsNotNull(site);
            Assert.AreEqual(1, site.Id);
            Assert.AreEqual("Sarnia", site.Name);
        }
    }
}