using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class FunctionalLocationServiceClientTest
    {
        private IFunctionalLocationService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldFigureOutDefaultFLOCsForLogForm_NormalRoots_level2Max()
        {
            var ed11 = service.QueryByFullHierarchy("ED1-A001", Site.EDMONTON_ID);
            var ed12 = service.QueryByFullHierarchy("ED1-A002", Site.EDMONTON_ID);
            var ed13 = service.QueryByFullHierarchy("ED1-A003-U055", Site.EDMONTON_ID);

            const FunctionalLocationType flocSelectionLevel = FunctionalLocationType.Level2;

            var roots = new List<FunctionalLocation> {ed11, ed12, ed13};

            var outputList = service.GetDefaultFLOCs(flocSelectionLevel, roots);

            Assert.AreEqual(3, outputList.Count);

            Assert.IsTrue(outputList.Exists(f => f.IdValue == ed11.IdValue));
            Assert.IsTrue(outputList.Exists(f => f.IdValue == ed12.IdValue));
            Assert.IsTrue(outputList.Exists(f => f.IdValue == ed13.IdValue));
        }

        [Test][Ignore]
        public void ShouldFigureOutDefaultFLOCsForLogForm_NormalRoots_level3Max()
        {
            var ed11 = service.QueryByFullHierarchy("ED1-A001", Site.EDMONTON_ID);
            var ed12 = service.QueryByFullHierarchy("ED1-A002", Site.EDMONTON_ID);
            var ed13 = service.QueryByFullHierarchy("ED1-A003-U055", Site.EDMONTON_ID);

            const FunctionalLocationType flocSelectionLevel = FunctionalLocationType.Level3;

            var roots = new List<FunctionalLocation> {ed11, ed12, ed13};

            var outputList = service.GetDefaultFLOCs(flocSelectionLevel, roots);

            Assert.AreEqual(24, outputList.Count);
        }

        [Test][Ignore]
        public void ShouldFigureOutDefaultFLOCsForLogForm_RootIsDivision_Level2Max()
        {
            var ed1 = service.QueryByFullHierarchy("ED1", Site.EDMONTON_ID);
            const FunctionalLocationType flocSelectionLevel = FunctionalLocationType.Level2;

            var roots = new List<FunctionalLocation> {ed1};

            var outputList = service.GetDefaultFLOCs(flocSelectionLevel, roots);

            // Should be all the level 2 FLOCs
            Assert.AreEqual(6, outputList.Count);

            foreach (var functionalLocation in outputList)
            {
                Assert.AreEqual(2, functionalLocation.Level);
            }
        }

        [Test][Ignore]
        public void ShouldFigureOutDefaultFLOCsForLogForm_RootIsDivision_Level3Max()
        {
            var ed1 = service.QueryByFullHierarchy("ED1", Site.EDMONTON_ID);
            const FunctionalLocationType flocSelectionLevel = FunctionalLocationType.Level3;

            var roots = new List<FunctionalLocation> {ed1};

            var outputList = service.GetDefaultFLOCs(flocSelectionLevel, roots);

            // Should be all the level 2 FLOCs
            Assert.AreEqual(70, outputList.Count);

            foreach (var functionalLocation in outputList)
            {
                Assert.AreEqual(3, functionalLocation.Level);
            }
        }

        [Test][Ignore]
        public void ShouldHandleFlocThatDoesNotExistWhenRemovingByFullHierarchy()
        {
            var floc = new FunctionalLocation(
                SiteFixture.Sarnia(),
                "something that does not exist",
                PlantFixture.SarniaPlant.IdValue,
                "some description",
                Culture.DEFAULT_CULTURE_NAME);
            service.RemoveByFullHierarchy(floc);
        }
    }
}