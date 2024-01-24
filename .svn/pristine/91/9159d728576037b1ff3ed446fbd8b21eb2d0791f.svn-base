using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class WorkAssignmentDTODaoTest : AbstractDaoTest
    {
        private ISiteDao siteDao;
        private IWorkAssignmentDao workAssignmentDao;        
        private IWorkAssignmentDTODao workAssignmentDTODao;

        protected override void TestInitialize()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            workAssignmentDTODao = DaoRegistry.GetDao<IWorkAssignmentDTODao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryBySite()
        {
            Site oilsandsSite = siteDao.QueryById(Site.OILSAND_ID);

            List<WorkAssignmentDTO> dtoList = workAssignmentDTODao.QueryBySiteId(3);

            Assert.IsNotEmpty(dtoList);

            dtoList.ForEach(dto => Assert.AreEqual(oilsandsSite.Name, dto.Site));
        }
    }
}
