using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.PlantHistorian;
using Com.Suncor.Olt.Remote.Bootstrap;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionReadWriteTagConfigurationDaoTest : AbstractDaoTest
    {
        private ITargetDefinitionReadWriteTagConfigurationDao dao;
        private IPlantHistorianGateway mockPlantHistorianGateway;
        private Mockery mocks;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ITargetDefinitionReadWriteTagConfigurationDao>();
            mocks = new Mockery();
            mockPlantHistorianGateway = mocks.NewMock<IPlantHistorianGateway>();
            // Create a new TargetDefinitionDao to allow mocking of the Plant Historian Gateway & Time Service Dao.
            Bootstrapper.CreateManagedDao<ITargetDefinitionDao>(Bootstrapper.ConnectionString, new TargetDefinitionDao(mockPlantHistorianGateway));
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            TargetDefinitionReadWriteTagConfiguration expectedFromDb = TargetDefinitionReadWriteTagConfigurationFixture.CreateTargetDefinitionTagValueConfigurationFoundInDatabase();
            TargetDefinitionReadWriteTagConfiguration found = dao.QueryByTargetDefinitionId(-1);
            
            Assert.AreEqual(expectedFromDb.Id, found.Id);
        }

     
    }
}