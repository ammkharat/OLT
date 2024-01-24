using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class GasTestElementInfoDTODaoTest : AbstractDaoTest
    {
        private IGasTestElementInfoDTODao dao;        
        private IGasTestElementInfoDao gasTestElementInfoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IGasTestElementInfoDTODao>();
            gasTestElementInfoDao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
        }

        protected override void Cleanup()
        {
            // Do Nothing.
        }

        [Ignore] [Test]
        public void ShouldQueryStandardInfoDTOBySiteId()
        {
            List<GasTestElementInfoDTO> expected = GasTestElementInfoFixture.SarniaStandardDTOs;
            List<GasTestElementInfoDTO> actual = dao.QueryStandardInfoDTOsBySiteId(SiteFixture.Sarnia().IdValue);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                GasTestElementInfoDTO dto1 = expected[i];
                GasTestElementInfoDTO dto2 = actual[i];
                Assert.AreEqual(dto1.Name, dto2.Name);                
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateGasTestElementInfoDTO()
        {
            List<GasTestElementInfoDTO> sarniaDTOInfoList = dao.QueryStandardInfoDTOsBySiteId(SiteFixture.Sarnia().IdValue);
            GasLimitRange newColdLimit = new GasLimitRange(10, 20);
            GasLimitRange newHotLimit = new GasLimitRange(30, 40);
            GasLimitRange newCSELimit = new GasLimitRange(50, 60);
            GasLimitRange newInertCSELimit = new GasLimitRange(70, 80);
            foreach(GasTestElementInfoDTO dtoInfo in sarniaDTOInfoList)
            {
                string expectedColdLimit = newColdLimit.ToLimitString(dtoInfo.IsRangedLimit, dtoInfo.DecimalPlaceCount);
                string expectedHotLimit = newHotLimit.ToLimitString(dtoInfo.IsRangedLimit, dtoInfo.DecimalPlaceCount);
                string expectedCSELimit = newCSELimit.ToLimitString(dtoInfo.IsRangedLimit, dtoInfo.DecimalPlaceCount);
                string expectedInertCSELimit = newInertCSELimit.ToLimitString(dtoInfo.IsRangedLimit, dtoInfo.DecimalPlaceCount);
                dtoInfo.ColdLimit = expectedColdLimit;
                dtoInfo.HotLimit = expectedHotLimit;
                dtoInfo.CSELimit = expectedCSELimit;
                dtoInfo.InertCSELimit = expectedInertCSELimit;
                dao.Update(dtoInfo);
                GasTestElementInfo actual = gasTestElementInfoDao.QueryById(dtoInfo.IdValue);
                Assert.AreEqual(expectedColdLimit, actual.ColdLimit.ToLimitString(actual.IsRangedLimit, actual.DecimalPlaceCount));
                Assert.AreEqual(expectedHotLimit, actual.HotLimit.ToLimitString(actual.IsRangedLimit, actual.DecimalPlaceCount));
                Assert.AreEqual(expectedCSELimit, actual.CSELimit.ToLimitString(actual.IsRangedLimit, actual.DecimalPlaceCount));
                Assert.AreEqual(expectedInertCSELimit, actual.InertCSELimit.ToLimitString(actual.IsRangedLimit, actual.DecimalPlaceCount));
            }
        }
    }
}