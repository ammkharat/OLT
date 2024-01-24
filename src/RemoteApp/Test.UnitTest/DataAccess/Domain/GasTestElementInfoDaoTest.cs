using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class GasTestElementInfoDaoTest : AbstractDaoTest
    {
        private IGasTestElementInfoDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldDeriveFromAbstractManagedDao()
        {
            Assert.AreEqual(typeof(AbstractManagedDao), typeof(GasTestElementInfoDao).BaseType);
        }

        [Ignore] [Test]
        public void ShouldQueryAllStandardGasTestElementInfosForSarnia()
        {
            List<GasTestElementInfo> expectedInfos = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;
            List<GasTestElementInfo> actualInfos = dao.QueryStandardInfosBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.AreEqual(expectedInfos.Count, actualInfos.Count);
            for(int i = 0; i < actualInfos.Count; i++)
            {
                GasTestElementInfo actual = actualInfos[i];
                GasTestElementInfo expected = expectedInfos[i];
                Assert.AreEqual(actual.Name, expected.Name);
            }
        }

        [Ignore] [Test]
        public void ShouldSortByDisplayOrderOnQueryingStandardInfosBySiteId()
        {
            List<GasTestElementInfo> infos = dao.QueryStandardInfosBySiteId(SiteFixture.Sarnia().IdValue);
            int previousDisplayOrder = 0;
            foreach(GasTestElementInfo info in infos)
            {
                Assert.IsTrue(info.DisplayOrder > previousDisplayOrder);
                previousDisplayOrder = info.DisplayOrder;
            }
        }

        [Ignore] [Test]
        public void ShouldQueryGasTestElementInfoById()
        {
            GasTestElementInfo expectedInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            expectedInfo = dao.Insert(expectedInfo);
            GasTestElementInfo actualInfo = dao.QueryById(expectedInfo.IdValue);
            Assert.AreEqual(expectedInfo, actualInfo);
        }

        [Ignore] [Test]
        public void ShouldUpdateIdOnInsert()
        {
            GasTestElementInfo elementInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            Assert.IsFalse(elementInfo.Id.HasValue);
            elementInfo = dao.Insert(elementInfo);
            Assert.IsNotNull(elementInfo.Id);
        }

        [Ignore] [Test]
        public void ShouldSetNewGasElementInfoAsNonStandardOnInsert()
        {
            GasTestElementInfo newInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            dao.Insert(newInfo);
            Assert.IsFalse(newInfo.IsStandard);
            GasTestElementInfo actual = dao.QueryById(newInfo.IdValue);
            Assert.IsFalse(actual.IsStandard);
        }

        [Ignore] [Test]
        public void ShouldAllowInsertingNullMaxMinAndUnitValue()
        {
            GasTestElementInfo infoWithNullValues = GasTestElementInfo.CreateOtherGasTestElementInfo(SiteFixture.Sarnia());
            infoWithNullValues.ColdLimit = GasLimitRange.EmptyLimitRange;
            infoWithNullValues.HotLimit = GasLimitRange.EmptyLimitRange;
            infoWithNullValues.CSELimit = GasLimitRange.EmptyLimitRange;
            infoWithNullValues.InertCSELimit = GasLimitRange.EmptyLimitRange;
            infoWithNullValues.Unit = GasLimitUnit.UNKNOWN;
            infoWithNullValues.Site = SiteFixture.Sarnia();
            dao.Insert(infoWithNullValues);
            GasTestElementInfo queriedInfo = dao.QueryById(infoWithNullValues.IdValue);
            Assert.AreEqual(infoWithNullValues, queriedInfo);
        }

        [Ignore] [Test]
        public void ShouldRemoveGasTestElementInfo()
        {
            // Setup new info for deleting:
            GasTestElementInfo newInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            newInfo = dao.Insert(newInfo);
            long? newInfoId = newInfo.Id;
            Assert.IsNotNull(newInfoId);
            // Execute:
            dao.Remove(newInfo);
            // Make sure element info removed:
            Assert.IsNull(dao.QueryById(newInfoId.Value));
        }

        [Ignore] [Test]
        public void ShouldUpdateStandardGasTestElementInfo()
        {
            GasTestElementInfo expected = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos[0];
            expected.Name = "Super Name Name";
            expected.OtherLimits = "New Other Limit";
            expected.HotLimit = new GasLimitRange(10, 20);
            expected.ColdLimit = new GasLimitRange(30, 40);
            expected.CSELimit = new GasLimitRange(50, 60);
            expected.InertCSELimit = new GasLimitRange(70, 80);
            dao.Update(expected);
            GasTestElementInfo actual = dao.QueryById(expected.IdValue);
            Assert.AreEqual(expected, actual);
        }
    }
}