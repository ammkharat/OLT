using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class PlantDaoTest : AbstractDaoTest
    {
        private IPlantDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPlantDao>();
        }

        protected override void Cleanup() {}
        
        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            // sarnia is used so that it will be for the siteId of 1, 
            // which will let the test pass for both IT and PlantOperations
            Site site = SiteFixture.Sarnia();
            
            List<Plant> plants = dao.QueryBySiteId(site.Id.Value);
            Assert.AreEqual(site.Plants.Count, plants.Count);
            CollectionAssert.AreEqual(site.Plants, plants);
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            List<Plant> plants = dao.QueryBySiteId(Site.OILSAND_ID);
            Plant firstPlant = plants[0];

            Plant retrievedPlant = dao.QueryById(firstPlant.Id.Value);
            Assert.AreEqual(firstPlant.Id, retrievedPlant.Id);
            Assert.AreEqual(firstPlant.Name, retrievedPlant.Name);
        }
    }
}