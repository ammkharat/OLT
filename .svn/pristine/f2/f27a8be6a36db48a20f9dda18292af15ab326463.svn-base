using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    /*
        Use this query to populate the OpMode table until the build runs it properly.

        Insert into FunctionalLocationOperationalMode (UnitId, OperationalModeId, AvailabilityReasonId)
            Select Id, 0, 0
             FROM FunctionalLocation Where Unit is not null and Equipment1 is null	  
    */
    [TestFixture] [Category("Database")]
    public class FunctionalLocationOperationalModeDTODaoTest : AbstractDaoTest
    {
        IFunctionalLocationOperationalModeDTODao dao;

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            dao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeDTODao>();

        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldGetAllOperationalModesBySiteId()
        {
            List<FunctionalLocationOperationalModeDTO> list = dao.GetAllBySite(1);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }
        
        [Ignore] [Test]        
        public void ShouldGetOperationalModeForFlocAtLevelThree()
        {
            
            FunctionalLocationOperationalModeDTO dto = dao.GetForLevel3AndBelowFloc(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF().IdValue);
            Assert.IsNotNull(dto);
            Assert.IsNotNull(dto.FullHierarchy);
            Assert.IsNotNull(dto.Description);
            Assert.IsNotNull(dto.OperationalMode);
            Assert.IsNotNull(dto.AvailabilityReason);
        }

        [Ignore] [Test]
        public void ShouldGetOperationalModeForFlocAtLevelFour()
        {
            FunctionalLocationOperationalModeDTO dto = dao.GetForLevel3AndBelowFloc(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB().IdValue);
            Assert.IsNotNull(dto);
            Assert.IsNotNull(dto.FullHierarchy);
            Assert.IsNotNull(dto.Description);
            Assert.IsNotNull(dto.OperationalMode);
            Assert.IsNotNull(dto.AvailabilityReason);
        }

        [Ignore] [Test]
        public void ShouldGetSameOperationalModeForFlocAtLevelThreeOrFourOrFive()
        {
            FunctionalLocationOperationalModeDTO dto1 = dao.GetForLevel3AndBelowFloc(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF().IdValue);
            Assert.IsNotNull(dto1);

            FunctionalLocationOperationalModeDTO dto2 = dao.GetForLevel3AndBelowFloc(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB().IdValue);
            Assert.IsNotNull(dto2);

            FunctionalLocationOperationalModeDTO dto3 = dao.GetForLevel3AndBelowFloc(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB().IdValue);
            Assert.IsNotNull(dto3);

            Assert.AreEqual(dto1.Id, dto2.Id);
            Assert.AreEqual(dto2.Id, dto3.Id);
        }
    }
}
