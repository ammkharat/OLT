using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Services
{
    [TestFixture]
    public class FunctionalLocationLookupTest
    {
        private Mockery mocks;
        private IFunctionalLocationInfoService flocInfoServiceMock;
        private IFunctionalLocationLookup flocInfoLookup;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            flocInfoServiceMock = mocks.NewMock<IFunctionalLocationInfoService>();
            flocInfoLookup = new FunctionalLocationLookup(flocInfoServiceMock);
        }
        
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldInvokeFlocInfoServiceToQueryDivisionsBySite()
        {
            Expect.Once.On(flocInfoServiceMock).Method("QueryDivisionsBySiteId").With(Site.SARNIA_ID);
            flocInfoLookup.GetChildrenFor(Site.SARNIA_ID);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldQueryBySingleFunctionalLocation()
        {
            FunctionalLocation division = FunctionalLocationFixture.GetAny_Division();
            Expect.Once.On(flocInfoServiceMock).Method("QueryByParentFunctionalLocation").With(division);
            flocInfoLookup.GetChildrenFor(division);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
