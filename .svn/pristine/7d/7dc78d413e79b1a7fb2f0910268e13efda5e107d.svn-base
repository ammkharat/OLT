using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class GasTestElementInfoConfigurationHistoryDaoTest : AbstractDaoTest
    {
        private IGasTestElementInfoConfigurationHistoryDao dao;
        private IUserDao userDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IGasTestElementInfoConfigurationHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsertAndReturnListOfGasTestElementInfoFromHistory()
        {
            long siteId = SiteFixture.Sarnia().IdValue;
            List<GasTestElementInfoConfigurationHistory> expectedGasLimitHistory = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistory;
            User user = userDao.QueryById(1);
            expectedGasLimitHistory[0].LastModifiedBy = user;
            expectedGasLimitHistory[1].LastModifiedBy = user;
            GasTestElementInfoConfigurationHistory returnedGasTestElementInfoHistory1 = dao.Insert(expectedGasLimitHistory[0], siteId);
            GasTestElementInfoConfigurationHistory returnedGasTestElementInfoHistory2 = dao.Insert(expectedGasLimitHistory[1], siteId);
            List<GasTestElementInfoConfigurationHistory> gasLimitHistory = dao.QueryAllBySiteId(siteId);
            Assert.AreEqual(returnedGasTestElementInfoHistory2, gasLimitHistory[0]);
            Assert.AreEqual(returnedGasTestElementInfoHistory1, gasLimitHistory[1]);
        }

        [Ignore] [Test]
        public void ShouldReturnListInChronologicalOrder()
        {
            long siteId = SiteFixture.Sarnia().IdValue;
            List<GasTestElementInfoConfigurationHistory> originalList1 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistory;
            List<GasTestElementInfoConfigurationHistory> originalList2 = GasTestElementInfoConfigurationHistoryFixture.SarniaGasTestElementInfoHistory;
            User user = userDao.QueryById(1);
            originalList1[0].LastModifiedBy = user;
            originalList1[1].LastModifiedBy = user;
            originalList2[0].LastModifiedBy = user;
            originalList2[1].LastModifiedBy = user;
            originalList2[0].LastModifiedDate = new DateTime(2004, 3, 2);
            originalList2[1].LastModifiedDate = new DateTime(2004, 3, 2);
            List<GasTestElementInfoConfigurationHistory> expectedList =
                    GetReturnedGasTestElementInfoHistory(originalList1, siteId);
            expectedList.AddRange(GetReturnedGasTestElementInfoHistory(originalList2, siteId));
            List<GasTestElementInfoConfigurationHistory> returnedList = dao.QueryAllBySiteId(siteId);
            Assert.IsTrue(returnedList[2].LastModifiedDate > returnedList[0].LastModifiedDate);
        }

        private List<GasTestElementInfoConfigurationHistory> GetReturnedGasTestElementInfoHistory(IList<GasTestElementInfoConfigurationHistory> expectedGasLimitHistoryList, long siteId)
        {
            List<GasTestElementInfoConfigurationHistory> list =
                    new List<GasTestElementInfoConfigurationHistory>
                        {
                            dao.Insert(expectedGasLimitHistoryList[0], siteId),
                            dao.Insert(expectedGasLimitHistoryList[0], siteId)
                        };
            return list;
        }
    }
}