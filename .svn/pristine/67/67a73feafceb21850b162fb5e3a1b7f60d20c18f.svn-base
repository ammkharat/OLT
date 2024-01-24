using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class SiteCommunicationDaoTest : AbstractDaoTest
    {
        private ISiteCommunicationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISiteCommunicationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            SiteCommunication siteCommunication1 = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia!", Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now);
            SiteCommunication siteCommunication2 = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia again!", Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now);
            SiteCommunication siteCommunication3 = new SiteCommunication(null, Site.EDMONTON_ID,null, "Edmo!", Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now);

            dao.Insert(siteCommunication1);
            dao.Insert(siteCommunication2);
            dao.Insert(siteCommunication3);

            List<SiteCommunication> sarniaSiteCommunications = dao.QueryBySite(Site.SARNIA_ID);
            Assert.AreEqual(2, sarniaSiteCommunications.Count);
            Assert.IsTrue(sarniaSiteCommunications.ExistsById(siteCommunication1));
            Assert.IsTrue(sarniaSiteCommunications.ExistsById(siteCommunication2));

            List<SiteCommunication> edmoSiteCommunications = dao.QueryBySite(Site.EDMONTON_ID);
            Assert.AreEqual(1, edmoSiteCommunications.Count);
            Assert.IsTrue(edmoSiteCommunications.ExistsById(siteCommunication3));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            SiteCommunication siteCommunication = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia!", Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now);
            dao.Insert(siteCommunication);

            const string newMessage = "new message";
            DateTime newStartDateTime = new DateTime(2013, 8, 2, 13, 55, 0);
            DateTime newEndDateTime = new DateTime(2013, 8, 3, 14, 12, 0);                       

            SiteCommunication requeriedSiteCommunication = dao.QueryBySite(Site.SARNIA_ID)[0];
            requeriedSiteCommunication.Message = newMessage;
            requeriedSiteCommunication.StartDateTime = newStartDateTime;
            requeriedSiteCommunication.EndDateTime = newEndDateTime;

            dao.Update(requeriedSiteCommunication);

            requeriedSiteCommunication = dao.QueryBySite(Site.SARNIA_ID)[0];
            Assert.AreEqual(newMessage, requeriedSiteCommunication.Message);
            Assert.AreEqual(newStartDateTime, requeriedSiteCommunication.StartDateTime);
            Assert.AreEqual(newEndDateTime, requeriedSiteCommunication.EndDateTime);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            SiteCommunication siteCommunication = new SiteCommunication(null, Site.SARNIA_ID,null, "Sarnia!", Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now);
            dao.Insert(siteCommunication);

            SiteCommunication requeriedSiteCommunication = dao.QueryBySite(Site.SARNIA_ID)[0];
            Assert.AreEqual(siteCommunication.IdValue, requeriedSiteCommunication.IdValue);

            dao.Remove(requeriedSiteCommunication);

            List<SiteCommunication> siteCommunications = dao.QueryBySite(Site.SARNIA_ID);
            Assert.IsEmpty(siteCommunications);
        }

    }
}

