using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class FunctionalLocationServiceTest
    {
        private IFunctionalLocationService functionalLocationService;
        private IFunctionalLocationDao functionalLocationDao;
        private ITimeDao timeDao;
        private IFunctionalLocationOperationalModeDao operationalModeDao;

        public const string QUERY_BY_ID = "QueryById";
        public const string QUERY_ALL = "QueryAll";
        public const string UPDATE_OUTOFSERIVCE = "UpdateOutOfService";

        private Mockery mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            functionalLocationDao = mock.NewMock<IFunctionalLocationDao>();
            operationalModeDao = mock.NewMock<IFunctionalLocationOperationalModeDao>();
            timeDao = mock.NewMock<ITimeDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( functionalLocationDao);
            DaoRegistry.RegisterDaoFor( operationalModeDao);
            DaoRegistry.RegisterDaoFor( timeDao);
            functionalLocationService = new FunctionalLocationService();
        }

        [Ignore] [Test]
        public void ShouldGetAFunctionalLocationById()
        {
            Expect.Once.On(functionalLocationDao).Method(QUERY_BY_ID);
            functionalLocationService.QueryById(1);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void ShouldFindSectionFLOCFromEquipment2FLOC()
        {
            FunctionalLocation functionalLocation =
                FunctionalLocationFixture.GetAny_Equip2();
            Expect.Once.On(functionalLocationDao).Method(
                "QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation").With(functionalLocation);
            Expect.Never.On(functionalLocationDao).Method(
                "QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations").With(functionalLocation);
            List<FunctionalLocation> functionalLocations =
                functionalLocationService.GetSectionLevelFunctionalLocation(functionalLocation);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void ShouldFindSectionFLOCFromEquipment1FLOC()
        {
            FunctionalLocation functionalLocation =
                FunctionalLocationFixture.GetAny_Equip1();
            Expect.Once.On(functionalLocationDao).Method(
                "QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation").With(functionalLocation);
            Expect.Never.On(functionalLocationDao).Method(
                "QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations").With(functionalLocation);
            List<FunctionalLocation> functionalLocations =
                functionalLocationService.GetSectionLevelFunctionalLocation(functionalLocation);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void ShouldFindSectionFLOCFromUnitFLOC()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            Expect.Once.On(functionalLocationDao).Method(
                "QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation").With(functionalLocation);
            Expect.Never.On(functionalLocationDao).Method(
                "QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations").With(functionalLocation);
            List<FunctionalLocation> functionalLocations =
                functionalLocationService.GetSectionLevelFunctionalLocation(functionalLocation);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void ShouldFindSectionFLOCFromSectionFLOC()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Section();
            Expect.Never.On(functionalLocationDao).Method(
                "QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation").With(functionalLocation);
            Expect.Never.On(functionalLocationDao).Method(
                "QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations").With(functionalLocation);
            List<FunctionalLocation> functionalLocations =
                functionalLocationService.GetSectionLevelFunctionalLocation(functionalLocation);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void ShouldFindSectionFLOCFromDivisionFLOC()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Division();
            Expect.Never.On(functionalLocationDao).Method(
                "QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation").With(functionalLocation);
            Expect.Once.On(functionalLocationDao).Method(
                "QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations").With(functionalLocation);
            List<FunctionalLocation> functionalLocations =
                functionalLocationService.GetSectionLevelFunctionalLocation(functionalLocation);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        // TODO: Shouldn't we assert something?
        public void RemoveByFullHierarchyShouldFindTheFunctionalLocationAndCallTheRemove()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

            Expect.Once.On(functionalLocationDao).Method("QueryByFullHierarchy").With(
                functionalLocation.FullHierarchy, functionalLocation.Site.Id).Will(Return.Value(functionalLocation));
            Expect.Once.On(functionalLocationDao).Method("RemoveAndAllDescendants").With(functionalLocation);

            functionalLocationService.RemoveByFullHierarchy(functionalLocation);

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}