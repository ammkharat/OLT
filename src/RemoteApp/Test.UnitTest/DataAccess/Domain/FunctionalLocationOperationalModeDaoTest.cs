using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationOperationalModeDaoTest : AbstractDaoTest
    {
        private IFunctionalLocationOperationalModeDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeDao>();    
        }

        protected override void Cleanup()
        {
        }
        
        [Ignore] [Test]
        public void TestThatInsertOperationalModeWorks()
        {
            FunctionalLocation newFunctionalLocation = FunctionalLocationFixture.CreateNew("SR1-OFFS-ABCDE");
            IFunctionalLocationDao functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            functionalLocationDao.Insert(newFunctionalLocation);

            FunctionalLocationOperationalMode mode =
                new FunctionalLocationOperationalMode(newFunctionalLocation.IdValue,
                                                      OperationalMode.Normal, AvailabilityReason.None, DateTimeFixture.DateTimeNow);            
            dao.Insert(mode);

            Assert.IsNotNull(dao.QueryById(newFunctionalLocation.IdValue));
        }

        [Ignore] [Test]
        public void ShouldUpdateOperationalModeAndReason()
        {
            DateTime now = new DateTime(2006, 7, 1, 13 ,58, 59);

            DateTime newLastModifiedDate = now;
            long flocId = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF().IdValue;
            FunctionalLocationOperationalMode operationalMode =
                new FunctionalLocationOperationalMode(flocId, OperationalMode.Constrained, 
                                                      AvailabilityReason.None, newLastModifiedDate);
            dao.Update(operationalMode);

            FunctionalLocationOperationalMode changedMode = dao.QueryById(flocId);
            Assert.AreEqual(OperationalMode.Constrained, changedMode.OperationalMode);
            Assert.AreEqual(AvailabilityReason.None, changedMode.AvailabilityReason);
            Assert.AreEqual(newLastModifiedDate, changedMode.LastModifiedDateTime);

            // just to make sure (in case the original had these same params
            newLastModifiedDate.AddDays(1);
            operationalMode =
                new FunctionalLocationOperationalMode(flocId, OperationalMode.ShutDown,
                                                      AvailabilityReason.RoutineMaintenance, newLastModifiedDate);
            dao.Update(operationalMode);

            changedMode = dao.QueryById(flocId);
            Assert.AreEqual(flocId, changedMode.Id);
            Assert.AreEqual(OperationalMode.ShutDown, changedMode.OperationalMode);
            Assert.AreEqual(AvailabilityReason.RoutineMaintenance, changedMode.AvailabilityReason);
            Assert.AreEqual(newLastModifiedDate, changedMode.LastModifiedDateTime);
        }
    }
}
