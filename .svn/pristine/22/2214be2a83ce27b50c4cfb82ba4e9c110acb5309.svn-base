using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class SAPNotificationDTODaoTest : AbstractDaoTest
    {
        private ISAPNotificationDTODao sapNotificationDtoDao;
        private ISAPNotificationDao sapNotificationDao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            sapNotificationDtoDao = DaoRegistry.GetDao<ISAPNotificationDTODao>();
            sapNotificationDao = DaoRegistry.GetDao<ISAPNotificationDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryByUnitLevelFunctionalLocationsAndShiftShouldReturnCorrectDTOsMatchingFunctionalLocationsAndShift()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("SR1-PLT3-GEN3");

            SAPNotification sapNotification1 = InsertSAPNotification(floc1, "1111111111");
            SAPNotification sapNotification2 = InsertSAPNotification(floc2, "2222222222");

            DateTime shiftStartDateTime = sapNotification1.CreationDateTime.AddDays(-1);
            DateTime shiftEndDateTime = sapNotification1.CreationDateTime.AddDays(1);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1, floc2 };
                List<SAPNotificationDTO> dtos = sapNotificationDtoDao.QueryByUnitLevelFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocations), shiftStartDateTime, shiftEndDateTime);
                Assert.IsTrue(dtos.Exists(obj => obj.Id == sapNotification1.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == sapNotification2.Id));
            }
        }

        [Ignore] [Test]
        public void QueryByUnitLevelFunctionalLocationsAndShiftShouldReturnSAPNotificationsForEquipment1s()
        {
            FunctionalLocation unitLevelFloc = InsertFunctionalLocation("DIV-SEC-UNIT");
            FunctionalLocation equip1 = InsertFunctionalLocation("DIV-SEC-UNIT-E1");

            SAPNotification sapNotification = InsertSAPNotification(equip1);

            List<FunctionalLocation> unitLevelFlocs = new List<FunctionalLocation>{unitLevelFloc};
            DateTime startDateTime = sapNotification.CreationDateTime.AddMinutes(-1);
            DateTime endDateTime = sapNotification.CreationDateTime.AddMinutes(1);
            
            List<SAPNotificationDTO> dtos =
                sapNotificationDtoDao.QueryByUnitLevelFunctionalLocationsAndDateRange(new RootFlocSet(unitLevelFlocs), startDateTime, endDateTime);
            
            Assert.AreEqual(1, dtos.Count);
            Assert.AreEqual(sapNotification.Id, dtos[0].Id);
        }
        
        private SAPNotification InsertSAPNotification(FunctionalLocation floc)
        {
            return InsertSAPNotification(floc, RandomString());
        }

        private SAPNotification InsertSAPNotification(FunctionalLocation floc, string notificationNumber)
        {
            SAPNotification sapNotification = SAPNotificationFixture.CreateSAPNotification(floc, notificationNumber);

            return sapNotificationDao.Insert(sapNotification);
        }
        
        private FunctionalLocation InsertFunctionalLocation( string fullHierarchy)
        {
            FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), fullHierarchy);
            flocDao.Insert(floc);
            return floc;
        }

        private static string RandomString()
        {
            string s = DateTimeFixture.DateTimeNow.Ticks.ToString();
            return s.Substring(s.Length - 10, 10);
        }
    }
}
