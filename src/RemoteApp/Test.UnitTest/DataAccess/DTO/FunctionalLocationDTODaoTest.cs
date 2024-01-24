using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationDTODaoTest : AbstractDaoTest
    {
        private IFunctionalLocationDTODao flocDTODao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            flocDTODao = DaoRegistry.GetDao<IFunctionalLocationDTODao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldPopulateDTO()
        {
            FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Denver(), "1-2-3-4-5", PlantFixture.SarniaPlant.IdValue);
            floc.Description = "aabbccdd";
            flocDao.Insert(floc);

            List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                floc.Description, floc.Site, new List<FunctionalLocationType> { floc.Type });

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("1-2-3-4-5", results[0].FullHierarcy);
            Assert.AreEqual(FunctionalLocationType.Level5, results[0].Type);
        }

        [Ignore] [Test]
        public void ShouldFindByDescriptionSiteAndLevel()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "zzbbccc";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "yybbccc";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            long id3;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "aabbccc";
                flocDao.Insert(floc);
                id3 = floc.IdValue;
            }
            long id4;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3-4", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "bbcccdd";
                flocDao.Insert(floc);
                id4 = floc.IdValue;
            }
            long id5;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Denver(), "1-2-3-4-5", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "aabbccdd";
                flocDao.Insert(floc);
                id5 = floc.IdValue;
            }

            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level2 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level3 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level4 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Denver(), new List<FunctionalLocationType> { FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsTrue(results.Exists(obj => obj.Id == id5));
            }
        }


        [Ignore] [Test]
        public void ShouldFindByFullHierarchySiteAndLevel()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1zzbbccc", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2yybbccc", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            long id3;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3aabbccc", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id3 = floc.IdValue;
            }
            long id4;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3-4bbcccdd", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id4 = floc.IdValue;
            }
            long id5;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Denver(), "1-2-3-4-5aabbccdd", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id5 = floc.IdValue;
            }

            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level2 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level3 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level4 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "BBCC", SiteFixture.Denver(), new List<FunctionalLocationType> { FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsTrue(results.Exists(obj => obj.Id == id5));
            }
        }

        [Ignore] [Test]
        public void ShouldFindByDescriptionUsingWildCards()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "aabbccc";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3-4", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "bbcccdd";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            long id3;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Denver(), "1-2-3-4-5", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "aabbccdd";
                flocDao.Insert(floc);
                id3 = floc.IdValue;
            }

            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    " bb cc ", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "bb dd", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "aa*cc", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "asdf", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
        }

        [Ignore] [Test]
        public void ShouldFindByFullHierarchyUsingWildCards()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "aabbccc1-2-3", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2bbcccdd-3-4", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            long id3;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Denver(), "1-2-3-4-5aabbccdd", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id3 = floc.IdValue;
            }

            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    " bb cc ", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "bb dd", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "aa*cc", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "asdf", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
        }

        [Ignore] [Test]
        public void ShouldFindByDescriptionUsingNonAlphaNumericCharacters()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "a-b c@d e%f g_h i'j k[l]m n%o[p]q%r";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "1-2-3-4", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "axb cxd exf gxh ixj klm nopqr";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "a-b", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "c@d", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "e%f", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "g_h", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "i'j", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "k[l]m", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "n%o[p]q%r", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
        }

        [Ignore] [Test]
        public void ShouldFindByFullHierarchyUsingNonAlphaNumericCharacters()
        {
            long id1;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "a-b c@d e%f g_h i'j k[l]m n%o[p]q%r1-2-3", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id1 = floc.IdValue;
            }
            long id2;
            {
                FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "axb cxd exf gxh ixj klm nopqr1-2-3-4", PlantFixture.SarniaPlant.IdValue);
                floc.Description = "description x";
                flocDao.Insert(floc);
                id2 = floc.IdValue;
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "a-b", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "c@d", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "e%f", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "g_h", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "i'j", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "k[l]m", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<FunctionalLocationDTO> results = flocDTODao.QueryBySearchTextInDescriptionOrFullHierarchy(
                    "n%o[p]q%r", SiteFixture.Sarnia(), new List<FunctionalLocationType> { FunctionalLocationType.Level1, FunctionalLocationType.Level2, FunctionalLocationType.Level3, FunctionalLocationType.Level4, FunctionalLocationType.Level5 });
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
        }
    }
}
