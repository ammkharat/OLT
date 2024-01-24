using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class SiteServiceTest
    {
        Mockery mock;
        ISiteService siteService;
        ISiteDao siteDao;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            siteDao = mock.NewMock<ISiteDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( siteDao);
            siteService = new SiteService();
        }

        [Ignore] [Test]
        public void ShouldGetAllSites()
        {
            Expect.Once.On(siteDao).Method("QueryAll").Will(Return.Value(SiteFixture.GetSites()));
            siteService.GetAll();
        }

        [Ignore] [Test]
        public void ShouldGetASiteById()
        {
            Site site = SiteFixture.Sarnia();
            Expect.Once.On(siteDao).Method("QueryById").With(site.Id.Value).Will(Return.Value(site));
            siteService.QueryById(site.Id.Value);
        }
    }
}
