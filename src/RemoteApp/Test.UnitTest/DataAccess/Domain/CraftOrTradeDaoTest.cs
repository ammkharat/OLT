using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class CraftOrTradeDaoTest : AbstractDaoTest
    {
        private ICraftOrTradeDao dao;
        private Site site;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ICraftOrTradeDao>();
            site = SiteFixture.Sarnia();
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void QueryByIdWithKnownIdReturnsACraftOrTrade()
        {
            CraftOrTrade result = dao.QueryById(1);
            Assert.IsNotNull(result.Name);
        }

        [Ignore] [Test]
        public void QueryByIdNotDeletedShouldOnlyReturnACraftOrTradeMatchingTheIdAndIfItIsNotDeleted()
        {
            long? existingCraftOrTradeId = 1;
            CraftOrTrade existingCraftOrTrade = dao.QueryByIdAndNotDeleted(existingCraftOrTradeId.Value);
            Assert.IsNotNull(existingCraftOrTrade);

            dao.Remove(existingCraftOrTrade);
            Assert.IsNull(dao.QueryByIdAndNotDeleted(existingCraftOrTradeId.Value));                        
        }
        
        [Ignore] [Test]
        public void InsertShouldInsertACraftOrTrade()
        {
            CraftOrTrade craftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            dao.Insert(craftOrTrade);
            Assert.IsNotNull(craftOrTrade.Id);
        }

        [Ignore] [Test]
        public void InsertShouldInsertACraftOrTradeWithANullWorkCentre()
        {
            CraftOrTrade craftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTrade.WorkCenterCode = null;
            dao.Insert(craftOrTrade);
            Assert.IsNotNull(craftOrTrade.Id);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertCraftOrTradeWithEmptyWorkCentreId()
        {
            CraftOrTrade craftOrTrade = new CraftOrTrade("TEST", null, site.IdValue);
            CraftOrTrade insertedCraftOrTrade = dao.Insert(craftOrTrade);
            Assert.AreEqual(craftOrTrade, dao.QueryById(insertedCraftOrTrade.IdValue));
        }

        [Ignore] [Test]
        public void QueryByNameShouldQueryForACraftOrTrade()
        {
            CraftOrTrade craftOrTrade = dao.QueryById(1);
            Assert.IsNotNull(craftOrTrade);
            CraftOrTrade returnedCraftOrTrade = dao.QueryByWorkCentreNameAndSiteId(craftOrTrade.Name, craftOrTrade.SiteId);
            Assert.IsNotNull(returnedCraftOrTrade);
        }

        [Ignore] [Test]
        public void QueryByWorkCenterShouldQueryForACraftOrTrade()
        {
            CraftOrTrade craftOrTrade = dao.QueryById(1);
            Assert.IsNotNull(craftOrTrade);
            CraftOrTrade returnedCraftOrTrade = dao.QueryByWorkCentreCodeAndSiteId(craftOrTrade.WorkCenterCode, craftOrTrade.SiteId);
            Assert.IsNotNull(returnedCraftOrTrade);
            Assert.AreEqual(craftOrTrade, returnedCraftOrTrade);
        }

        [Ignore] [Test]
        public void ShouldReturnListofCraftOrTradesOfGivenSiteId()
        {
            CraftOrTrade insertedCraftOrTrade1 = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());
            CraftOrTrade insertedCraftOrTrade2 = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());
            List<CraftOrTrade> retrievedCraftOrTradeList = dao.QueryBySiteId(site.Id.Value);
            Assert.IsTrue(retrievedCraftOrTradeList.Count >= 2);

            Assert.That(retrievedCraftOrTradeList, Has.Some.EqualTo(insertedCraftOrTrade1));
            Assert.That(retrievedCraftOrTradeList, Has.Some.EqualTo(insertedCraftOrTrade2));

        }

        [Ignore] [Test]
        public void ShouldReturnListofCraftOrTradesOfGivenSiteIdInAscendingOrder()
        {
            site = SiteFixture.Denver();
            CraftOrTrade insertedCraftOrTrade2 = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("AK", site));
            CraftOrTrade insertedCraftOrTrade1 = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("AA", site));
            CraftOrTrade insertedCraftOrTrade3 = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("AZ", site));
            List<CraftOrTrade> retrievedCraftOrTradeList = dao.QueryBySiteId(site.Id.Value);
            Assert.IsTrue(retrievedCraftOrTradeList.Count >= 3);
            Assert.AreEqual(retrievedCraftOrTradeList[0], insertedCraftOrTrade1);
            Assert.AreEqual(retrievedCraftOrTradeList[1], insertedCraftOrTrade2);
            Assert.AreEqual(retrievedCraftOrTradeList[2], insertedCraftOrTrade3);
        }

        [Ignore] [Test]
        public void ShouldUpdateCraftOrTrade()
        {
            CraftOrTrade insertedCraftOrTrade = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());
            insertedCraftOrTrade.Name = "Tree digger";
            insertedCraftOrTrade.WorkCenterCode = "111111";
            dao.Update(insertedCraftOrTrade);
            CraftOrTrade retrievedCraftOrTrade = dao.QueryById(insertedCraftOrTrade.Id.Value);
            Assert.IsNotNull(retrievedCraftOrTrade);
            Assert.AreEqual(retrievedCraftOrTrade, insertedCraftOrTrade);
        }

        [Ignore] [Test]
        public void ShouldUpdateCraftOrTrade_AllowNullWorkCentre()
        {
            CraftOrTrade holeCutter = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            CraftOrTrade insertedCraftOrTrade = dao.Insert(holeCutter);
            Assert.IsNotNull(insertedCraftOrTrade.WorkCenterCode);
           
            insertedCraftOrTrade.WorkCenterCode = null;
            dao.Update(insertedCraftOrTrade);

            CraftOrTrade retrievedCraftOrTrade = dao.QueryById(insertedCraftOrTrade.Id.Value);
            Assert.IsNotNull(retrievedCraftOrTrade);
            Assert.IsNull(insertedCraftOrTrade.WorkCenterCode);
        }

        [Ignore] [Test]
        public void QueryByNameCannotRetrieveRemovedCraftOrTrade()
        {
            CraftOrTrade insertedCraftOrTrade = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());
            dao.Remove(insertedCraftOrTrade);
            CraftOrTrade retrievedCraftOrTrade = dao.QueryByWorkCentreNameAndSiteId(insertedCraftOrTrade.Name, insertedCraftOrTrade.SiteId);
            Assert.IsNull(retrievedCraftOrTrade);
        }

        [Ignore] [Test]
        public void QueryBySiteCannotRetrieveRemovedCraftOrTrades()
        {
            CraftOrTrade craftOrTradeToRemove = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade(site));
            dao.Remove(craftOrTradeToRemove);
            List<CraftOrTrade> retrievedCraftOrTrades = dao.QueryBySiteId(site.Id.Value);
            Assert.That(retrievedCraftOrTrades, Has.None.EqualTo(craftOrTradeToRemove));
        }

        [Ignore] [Test]
        public void QueryByWorkCentreIdCannotRetrieveRemovedCraftOrTrades()
        {
            CraftOrTrade craftOrTradeToRemove = dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade(site));
            dao.Remove(craftOrTradeToRemove);
            Assert.IsNull(dao.QueryByWorkCentreCodeAndSiteId(craftOrTradeToRemove.WorkCenterCode, craftOrTradeToRemove.SiteId));
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkCentreAndSiteId()
        {
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 1", "WC-ABCD1", SiteFixture.Sarnia()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 2 (sarnia)", "WC-ABCD2", SiteFixture.Sarnia()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 2 (montreal)", "WC-ABCD2", SiteFixture.Montreal()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 3", "WC-ABCD3", SiteFixture.Montreal()));

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreCodeAndSiteId("WC-ABCD1", Site.SARNIA_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 1", craftOrTrade.Name);
            }

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreCodeAndSiteId("WC-ABCD1", Site.MONTREAL_ID);
                Assert.IsNull(craftOrTrade);               
            }
                       
            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreCodeAndSiteId("WC-ABCD2", Site.SARNIA_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 2 (sarnia)", craftOrTrade.Name);
            }

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreCodeAndSiteId("WC-ABCD2", Site.MONTREAL_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 2 (montreal)", craftOrTrade.Name);
            }

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreCodeAndSiteId("WC-ABCD3", Site.MONTREAL_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 3", craftOrTrade.Name);
            }                       
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkCentreAndNameAndSiteId()
        {
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 1", "WC-ABCD1", SiteFixture.Sarnia()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 2 (sarnia)", "WC-ABCD2", SiteFixture.Sarnia()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 2 (montreal)", "WC-ABCD2", SiteFixture.Montreal()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 3", "WC-ABCD3", SiteFixture.Montreal()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 3", null, SiteFixture.Montreal()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 4", null, SiteFixture.Montreal()));
            dao.Insert(CraftOrTradeFixture.CreateNewCraftOrTrade("Work Centre 5", "ABCD", SiteFixture.Sarnia()));

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId("WC-ABCD1", "Work Centre 1", Site.SARNIA_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 1", craftOrTrade.Name);
                Assert.AreEqual("WC-ABCD1", craftOrTrade.WorkCenterCode);
            }

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId(null, "Work Centre 1", Site.MONTREAL_ID);
                Assert.IsNull(craftOrTrade);
            }

            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId("WC-ABCD2", "Work Centre 2 (sarnia)", Site.SARNIA_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 2 (sarnia)", craftOrTrade.Name);
            }
            
            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId(null, "Work Centre 3", Site.MONTREAL_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 3", craftOrTrade.Name);
                Assert.IsNull(craftOrTrade.WorkCenterCode);
            }  
                     
            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId(null, "Work Centre 4", Site.MONTREAL_ID);
                Assert.IsNotNull(craftOrTrade);
                Assert.AreEqual("Work Centre 4", craftOrTrade.Name);
                Assert.IsNull(craftOrTrade.WorkCenterCode);
            }
                       
            {
                CraftOrTrade craftOrTrade = dao.QueryByWorkCentreAndNameAndSiteId(null, "Work Centre 5", Site.SARNIA_ID);
                Assert.IsNull(craftOrTrade);               
            }                       
        }
    }
}