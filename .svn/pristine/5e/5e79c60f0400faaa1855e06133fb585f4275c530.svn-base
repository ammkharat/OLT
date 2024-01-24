using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class LabAlertLogResponseDataDependentTests
    {
        private IFunctionalLocationInfoService flocInfoService;

        private FunctionalLocation sarniaDivision;

        [SetUp]
        public void SetUp()
        {
            flocInfoService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>();

            var divisions = flocInfoService.QueryDivisionsBySiteId(Site.SARNIA_ID);
            Assert.AreEqual(1, divisions.Count); // sanity check

            sarniaDivision = divisions[0].Floc;
        }

        [Test][Ignore]
        public void ShouldBuildFunctionalLocationListForResponseLog_FirstLevelFloc_SectionAllowed()
        {
            var userSelectedFLOCRoots = new List<FunctionalLocation> {sarniaDivision};

            var flocList = LabAlert.BuildFunctionalLocationListForResponseLog(userSelectedFLOCRoots, true,
                flocInfoService);

            Assert.IsNotEmpty(flocList);

            foreach (var floc in flocList)
            {
                Assert.IsTrue(floc.IsSection);
                Assert.IsTrue(floc.Division.Equals("SR1"));
            }
        }

        [Test][Ignore]
        public void ShouldBuildFunctionalLocationListForResponseLog_FirstLevelFloc_SectionNotAllowed()
        {
            var userSelectedFLOCRoots = new List<FunctionalLocation> {sarniaDivision};

            var flocList = LabAlert.BuildFunctionalLocationListForResponseLog(userSelectedFLOCRoots, false,
                flocInfoService);

            Assert.IsNotEmpty(flocList);

            foreach (var floc in flocList)
            {
                Assert.IsTrue(floc.IsUnit);
                Assert.IsTrue(floc.Division.Equals("SR1"));
            }
        }

        [Test][Ignore]
        public void ShouldBuildFunctionalLocationListForResponseLog_UnitLevelFloc()
        {
            var unitLevelFLoc = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            Assert.IsTrue(unitLevelFLoc.IsUnit);

            var userSelectedFLOCRoots = new List<FunctionalLocation> {unitLevelFLoc};

            var flocList = LabAlert.BuildFunctionalLocationListForResponseLog(userSelectedFLOCRoots, false,
                flocInfoService);
            Assert.AreEqual(1, flocList.Count);
            Assert.AreEqual(unitLevelFLoc.FullHierarchy, flocList[0].FullHierarchy);
        }
    }
}