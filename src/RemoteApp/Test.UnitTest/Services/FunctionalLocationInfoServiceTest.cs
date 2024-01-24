using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Rhino.Mocks;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class FunctionalLocationInfoServiceTest
    {
        private IFunctionalLocationInfoService functionalLocationInfoService;
        private IFunctionalLocationInfoDao mockDao;

        [SetUp]
        public void SetUp()
        {
            mockDao = MockRepository.GenerateMock<IFunctionalLocationInfoDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockDao);
            functionalLocationInfoService = new FunctionalLocationInfoService();
        }

        [Ignore] [Test]
        public void ShouldQueryDivisionsBySiteId()
        {
            mockDao.Expect(m => m.QueryFunctionalLocationDivisionInfosBySiteId(Site.SARNIA_ID));
            functionalLocationInfoService.QueryDivisionsBySiteId(Site.SARNIA_ID);
            mockDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldQueryParentFunctionalLocations()
        {
            FunctionalLocation division = FunctionalLocationFixture.GetAny_Division();
            mockDao.Expect(m => m.QueryFunctionalLocationInfosByParentFunctionalLocation(division.IdValue));
            functionalLocationInfoService.QueryByParentFunctionalLocation(division);
            mockDao.VerifyAllExpectations();
        }
    }
}