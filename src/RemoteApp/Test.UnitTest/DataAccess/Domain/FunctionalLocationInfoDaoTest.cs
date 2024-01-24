using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationInfoDaoTest : AbstractDaoTest
    {
        private IFunctionalLocationInfoDao flocInfoDao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            flocInfoDao = DaoRegistry.GetDao<IFunctionalLocationInfoDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup() { }

        [Ignore] [Test]
        public void ShouldQueryDivisionBySiteId()
        {
            List<FunctionalLocationInfo> flocInfos = flocInfoDao.QueryFunctionalLocationDivisionInfosBySiteId(Site.DENVER_ID);
            Assert.AreEqual(1, flocInfos.Count);
            Assert.AreEqual("DN1", flocInfos[0].Floc.Division);
            Assert.AreEqual(FunctionalLocationType.Level1, flocInfos[0].Floc.Type);
            Assert.IsTrue(flocInfos[0].HasChildren);
        }                                                                      

        [Ignore] [Test]
        public void ShouldReturnEmptyListIfQueryLevelByNonExistentSiteId()
        {
            Assert.IsEmpty(flocInfoDao.QueryFunctionalLocationDivisionInfosBySiteId(9999));
        }

        [Ignore] [Test]
        public void QueryByDivisionBySiteIdShouldNotReturnDivisionsWhichAreOutOfService()
        {
            List<FunctionalLocationInfo> results = flocInfoDao.QueryFunctionalLocationDivisionInfosBySiteId(Site.SARNIA_ID);

            FunctionalLocationInfo flocInfoFound = results.Find(flocInfo => flocInfo.Floc.Division == "SRo");
            Assert.IsNull(flocInfoFound, "SRo is out of service and should not have been returned.");
        }

        [Ignore] [Test]
        public void ShouldQuerySectionsByDivisionParentId()
        {
            FunctionalLocation SR1_DivisionLevelFloc = flocDao.QueryByFullHierarchy("SR1", SiteFixture.Sarnia().IdValue);
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SR1_DivisionLevelFloc.IdValue);
            var expectedSections =
                new List<string>{"OFFS", "PLT1", "PLT2", "PLT3", "PLT4"};

    
            Assert.AreEqual(5, flocInfos.Count);
            flocInfos.ForEach(delegate(FunctionalLocationInfo flocInfo)
                                  {
                                      Assert.AreEqual(FunctionalLocationType.Level2, flocInfo.Floc.Type);
                                      Assert.Contains(flocInfo.Floc.Section, expectedSections);
                                      Assert.IsTrue(flocInfo.HasChildren);
                                  });
        }

        [Ignore] [Test]
        public void ShouldQueryUnitsBySectionParentId()
        {
            FunctionalLocation SR1_PLT4_SectionLevelFloc = flocDao.QueryByFullHierarchy("SR1-PLT4", SiteFixture.Sarnia().IdValue);
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SR1_PLT4_SectionLevelFloc.IdValue);

            Assert.IsNotEmpty(flocInfos);
            flocInfos.ForEach(delegate(FunctionalLocationInfo flocInfo)
            {
                Assert.AreEqual(FunctionalLocationType.Level3, flocInfo.Floc.Type);
                Assert.IsTrue(SR1_PLT4_SectionLevelFloc.IsParentOf(flocInfo.Floc));
                Assert.IsTrue(flocInfo.HasChildren);
            });
        }

        [Ignore] [Test]
        public void ShouldQueryEquipment1ByUnitId()
        {
            FunctionalLocation SR1_PLT4_UTP4_UnitLevelFloc = flocDao.QueryByFullHierarchy("SR1-PLT4-UTP4", SiteFixture.Sarnia().IdValue); 
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SR1_PLT4_UTP4_UnitLevelFloc.IdValue);
            Assert.IsNotEmpty(flocInfos);
            flocInfos.ForEach(delegate(FunctionalLocationInfo flocInfo)
            {
                Assert.AreEqual(FunctionalLocationType.Level4, flocInfo.Floc.Type);
                Assert.IsTrue(SR1_PLT4_UTP4_UnitLevelFloc.IsParentOf(flocInfo.Floc));
                Assert.IsTrue(flocInfo.HasChildren);
            });
        }

        [Ignore] [Test]
        public void ShouldQueryEquipment2ByEquipment1Id()
        {
            FunctionalLocation SR1_PLT4_UTP4_SMP_Equipment1LevelFloc = flocDao.QueryByFullHierarchy("SR1-PLT4-UTP4-SMP", SiteFixture.Sarnia().IdValue);
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SR1_PLT4_UTP4_SMP_Equipment1LevelFloc.IdValue);
            Assert.IsNotEmpty(flocInfos);
            flocInfos.ForEach(delegate(FunctionalLocationInfo flocInfo)
            {
                Assert.AreEqual(FunctionalLocationType.Level5, flocInfo.Floc.Type);
                Assert.IsTrue(SR1_PLT4_UTP4_SMP_Equipment1LevelFloc.IsParentOf(flocInfo.Floc));
                Assert.IsFalse(flocInfo.HasChildren);
            });
        }


        [Ignore] [Test]
        public void ShouldReturnEmptyListIfParentFlocHasNoChildren()
        {
            FunctionalLocation SRX_PLT2_ChildlessFloc = flocDao.QueryById(5);
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SRX_PLT2_ChildlessFloc.IdValue);
            Assert.IsEmpty(flocInfos);
        }

        [Ignore] [Test]
        public void ShouldReturnEmptyListForFlocWithoutChildren()
        {
            FunctionalLocation SRX_PLT3_HYDU_SMP_3P001A_Equipment2LevelFloc = flocDao.QueryById(20);
            List<FunctionalLocationInfo> flocInfos =
                flocInfoDao.QueryFunctionalLocationInfosByParentFunctionalLocation(SRX_PLT3_HYDU_SMP_3P001A_Equipment2LevelFloc.IdValue);

            Assert.IsEmpty(flocInfos);
        }

        [Ignore] [Test]
        public void ShouldQueryUnitsThatAreInSite()
        {
            FunctionalLocation levelOneFloc = FunctionalLocationFixture.GetReal_MT1();

            {
                List<FunctionalLocationInfo> results = flocInfoDao.QueryFunctionalLocationUnitInfosBySiteId(levelOneFloc.Site.IdValue);

                Assert.IsTrue(results.Count > 0);
                Assert.IsTrue(results.TrueForAll(flocInfo => flocInfo.Floc.IsUnit));
                Assert.IsTrue(results.TrueForAll(flocInfo => flocInfo.Floc.IsChildOf(levelOneFloc)));
            }
        }
    }
}
