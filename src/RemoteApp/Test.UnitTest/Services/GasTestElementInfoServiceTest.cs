using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class GasTestElementInfoServiceTest
    {
        private Mockery mocks;
        private IGasTestElementInfoDao mockGasTestElementInfoDao;
        private IGasTestElementInfoDTODao mockGasTestElementInfoDTODao;

        private IGasTestElementInfoService service;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            mockGasTestElementInfoDao = mocks.NewMock<IGasTestElementInfoDao>();
            mockGasTestElementInfoDTODao = mocks.NewMock<IGasTestElementInfoDTODao>();

            DaoRegistry.RegisterDaoFor( mockGasTestElementInfoDao);
            DaoRegistry.RegisterDaoFor( mockGasTestElementInfoDTODao);
            service = new GasTestElementInfoService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDaoOnQueryStandardGasTestElementInfoListBySiteId()
        {
            Site site = SiteFixture.Sarnia();
            List<GasTestElementInfo> expectedList = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;

            Expect.Once.On(mockGasTestElementInfoDao).Method("QueryStandardInfosBySiteId")
                .With(site.IdValue).Will(Return.Value(expectedList));

            List<GasTestElementInfo> actualList = service.QueryStandardElementInfosBySiteId(site.IdValue);
            Assert.AreEqual(expectedList, actualList);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDTODaoOnQueryStandardGasTestElementInfoDTOListBySiteId()
        {
            Site site = SiteFixture.Sarnia();
            List<GasTestElementInfoDTO> expectedList = GasTestElementInfoFixture.SarniaStandardDTOs;

            Expect.Once.On(mockGasTestElementInfoDTODao).Method("QueryStandardInfoDTOsBySiteId")
                .With(site.IdValue).Will(Return.Value(expectedList));

            List<GasTestElementInfoDTO> actualList = service.QueryStandardElementInfoDTOsBySiteId(site.IdValue);
            Assert.AreEqual(expectedList, actualList);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDaoOnUpdateGasTestElementInfoList()
        {
            List<GasTestElementInfo> expectedList = GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;
            foreach (GasTestElementInfo info in expectedList)
            {
                Expect.Once.On(mockGasTestElementInfoDao).Method("Update").With(info);
            }

            service.UpdateGasTestElementInfoList(expectedList);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDTODaoOnUpdateGasTestElementInfoList()
        {
            List<GasTestElementInfoDTO> expectedList = GasTestElementInfoFixture.SarniaStandardDTOs;
            foreach (GasTestElementInfoDTO dto in expectedList)
            {
                Expect.Once.On(mockGasTestElementInfoDTODao).Method("Update").With(dto);
            }

            service.UpdateGasTestElementInfoDTOList(expectedList);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
