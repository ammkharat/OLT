using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SAPNotificationDaoTest : AbstractDaoTest
    {
        private ISAPNotificationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISAPNotificationDao>();
        }

        protected override void Cleanup()
        {

        }

        [Ignore] [Test]
        public void InsertShouldReturnTheSAPNotification()
        {
            SAPNotification sapNotification = SAPNotificationFixture.GetAEmergencyIncidentFortMcMurrayNotification();

            Assert.IsNull(sapNotification.Id);
            sapNotification = dao.Insert(sapNotification);
            Assert.IsNotNull(sapNotification.Id);
            SAPNotification result = dao.QueryById(sapNotification.Id.Value);
            Assert.AreEqual(sapNotification.Id, result.Id);
            Assert.IsNotNull(result);
        }

        [Ignore] [Test]
        public void GetSAPNotificationByNotificationNumberShouldReturnOneRecord()
        {
            const string notificationNumber = "000004";
            SAPNotification sapNotification = SAPNotificationFixture.CreateSAPNotification(
                FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3(),
                notificationNumber,
                new DateTime(2001, 2, 3));
            sapNotification = dao.Insert(sapNotification);

            SAPNotification results = dao.QueryByNotificationNumber(notificationNumber);
            Assert.IsNotNull(results);
            Assert.AreEqual(notificationNumber, results.NotificationNumber);
            Assert.AreEqual(sapNotification.Id, results.Id);
        }

        [Ignore] [Test]
        public void GetSAPNotificationByNotificationNumberForNonExistantRecordShouldReturnNullResults()
        {
            const string notificationNumber = "99999";
            SAPNotification results = dao.QueryByNotificationNumber(notificationNumber);
            Assert.IsNull(results);
        }

        [Ignore] [Test]
        public void InsertedAndRetreivedSAPNotificationShouldBeEqual()
        {
            SAPNotification originalSAPNotification = SAPNotificationFixture.CreateSAPNotification(
                FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3(),
                "000004",
                new DateTime(2001, 2, 3));

            dao.Insert(originalSAPNotification);

            Assert.IsNotNull(originalSAPNotification.Id);

            SAPNotification queriedSAPNotification = dao.QueryById(originalSAPNotification.Id.Value);

            Assert.AreEqual(queriedSAPNotification, originalSAPNotification);
        }

        [Ignore] [Test]
        public void UpdateSAPNotificationShouldUpdateRecord()
        {
            SAPNotification sapNotification = SAPNotificationFixture.CreateSAPNotification(
                FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3(),
                "000004",
                new DateTime(2001, 2, 3));
            sapNotification = dao.Insert(sapNotification);

            sapNotification.Processed();

            dao.UpdateByNotificationNumber(sapNotification);

            SAPNotification updatedSAPNotification = dao.QueryById(sapNotification.IdValue);
            Assert.AreEqual(true, updatedSAPNotification.IsProcessed);
        }

    }
}