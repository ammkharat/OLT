using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class RestrictionDefinitionDTODaoTest : AbstractDaoTest
    {
        private IRestrictionDefinitionDao domainObjectDao;
        private IRestrictionDefinitionDTODao dao;
        private IFunctionalLocationDao flocDao;
        private TagInfo tag;

        protected override void TestInitialize()
        {
            domainObjectDao = DaoRegistry.GetDao<IRestrictionDefinitionDao>();
            dao = DaoRegistry.GetDao<IRestrictionDefinitionDTODao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();

            ITagDao tagDao = DaoRegistry.GetDao<ITagDao>();
            List<TagInfo> tags = tagDao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Oilsands().IdValue, "P86_REST_MASS_TARGET");
            tag = tags[0];
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocIds()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();

            RestrictionDefinition definition1 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc1, tag));
            RestrictionDefinition definition2 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc2, tag));
            RestrictionDefinition definition3 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc2, tag));
            DateRange dateRange = new DateRange(null, null);
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1, floc2 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
            }
            {
                FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeletedWhenQueryingByFlocId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            RestrictionDefinition definition1 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc1, tag));
            RestrictionDefinition definition2 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc1, tag));

            domainObjectDao.Remove(definition1);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                DateRange dateRange = new DateRange(null, null);
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocUnitId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            RestrictionDefinition definition1 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc1, tag));

            {
                FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_DN1_3003_0000();
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { unitFloc };
                DateRange dateRange = new DateRange(null, null);
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDivisionOrSection()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.CreateNew("a");
            flocDao.Insert(floc1);

            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("a-b");
            flocDao.Insert(floc2);

            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("a-b-c");
            flocDao.Insert(floc3);

            FunctionalLocation floc4 = FunctionalLocationFixture.CreateNew("a-b-c-d");
            flocDao.Insert(floc4);

            FunctionalLocation floc5 = FunctionalLocationFixture.CreateNew("a-b-c-d-e");
            flocDao.Insert(floc5);

            RestrictionDefinition definition1 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc1, tag));
            RestrictionDefinition definition2 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc2, tag));
            RestrictionDefinition definition3 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc3, tag));
            RestrictionDefinition definition4 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc4, tag));
            RestrictionDefinition definition5 = domainObjectDao.Insert(RestrictionDefinitionFixture.CreateDefinition(floc5, tag));

            DateRange dateRange = new DateRange(null, null);
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc5 };
                List<RestrictionDefinitionDTO> results = dao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(new RootFlocSet(functionalLocations), dateRange);
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
        }
    }
}
