using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverConfigurationDTODaoTest : AbstractDaoTest
    {
        private IShiftHandoverConfigurationDTODao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverConfigurationDTODao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            List<ShiftHandoverConfigurationDTO> dtos = dao.QueryBySiteId(3);
            Assert.IsNotEmpty(dtos);

            foreach (ShiftHandoverConfigurationDTO dto in dtos)
            {
                Assert.IsNotNullOrEmpty(dto.AssignmentListString);
            }
        }
    }
}