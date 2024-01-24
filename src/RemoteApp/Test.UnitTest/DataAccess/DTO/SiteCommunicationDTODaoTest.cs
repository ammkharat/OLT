using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    public class SiteCommunicationDTODaoTest : AbstractDaoTest
    {
        private ISiteCommunicationDao siteCommunicationDao;
        private ISiteCommunicationDTODao dtoDao;

        protected override void TestInitialize()
        {
            siteCommunicationDao = DaoRegistry.GetDao<ISiteCommunicationDao>();
            dtoDao = DaoRegistry.GetDao<ISiteCommunicationDTODao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteAndDateTime_VarySite()
        {
            DateTime startDateTime = new DateTime(2013, 1, 1);
            DateTime endDateTime = new DateTime(2013, 2, 1);
            User user = UserFixture.CreateUserWithGivenId(1);

            SiteCommunication siteCommunication1 = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia!", startDateTime, endDateTime, user, Clock.Now);
            SiteCommunication siteCommunication2 = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia again!", startDateTime, endDateTime, user, Clock.Now);
            SiteCommunication siteCommunication3 = new SiteCommunication(null, Site.EDMONTON_ID,null, "Edmo!", startDateTime, endDateTime, user, Clock.Now);

            siteCommunicationDao.Insert(siteCommunication1);
            siteCommunicationDao.Insert(siteCommunication2);
            siteCommunicationDao.Insert(siteCommunication3);

            List<SiteCommunicationDTO> sarniaSiteCommunications = dtoDao.QueryBySiteAndDateTime(Site.SARNIA_ID, new DateTime(2013, 1, 15));
            Assert.AreEqual(2, sarniaSiteCommunications.Count);
            Assert.IsTrue(sarniaSiteCommunications.Exists(dto => dto.Id == siteCommunication1.Id));
            Assert.IsTrue(sarniaSiteCommunications.Exists(dto => dto.Id == siteCommunication2.Id));

            List<SiteCommunicationDTO> edmoSiteCommunications = dtoDao.QueryBySiteAndDateTime(Site.EDMONTON_ID, new DateTime(2013, 1, 15));
            Assert.AreEqual(1, edmoSiteCommunications.Count);
            Assert.IsTrue(edmoSiteCommunications.Exists(dto => dto.Id == siteCommunication3.Id));
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteAndDateTime_VaryDateTime()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            long siteId = Site.SARNIA_ID;

            SiteCommunication siteCommunication1 = new SiteCommunication(null, siteId,null, "one", new DateTime(2013, 10, 1, 13, 0, 0), new DateTime(2013, 10, 1, 18, 0, 0), user, Clock.Now);
            SiteCommunication siteCommunication2 = new SiteCommunication(null, siteId,null, "two", new DateTime(2013, 10, 1, 17, 0, 0), new DateTime(2013, 10, 1, 20, 0, 0), user, Clock.Now);
            SiteCommunication siteCommunication3 = new SiteCommunication(null, siteId,null, "three", new DateTime(2013, 10, 1, 9, 0, 0), new DateTime(2013, 10, 1, 14, 0, 0), user, Clock.Now);

            siteCommunicationDao.Insert(siteCommunication1);
            siteCommunicationDao.Insert(siteCommunication2);
            siteCommunicationDao.Insert(siteCommunication3);

            {
                List<SiteCommunicationDTO> results = dtoDao.QueryBySiteAndDateTime(siteId, new DateTime(2013, 10, 1, 17, 30, 0));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == siteCommunication1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == siteCommunication2.Id));
            }

            {
                List<SiteCommunicationDTO> results = dtoDao.QueryBySiteAndDateTime(siteId, new DateTime(2013, 10, 1, 10, 0, 0));
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == siteCommunication3.Id));
            }

            {
                List<SiteCommunicationDTO> results = dtoDao.QueryBySiteAndDateTime(siteId, new DateTime(2013, 10, 2, 17, 30, 0));
                Assert.AreEqual(0, results.Count);
            }
        }


    }
}

