using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LabAlertResponseDaoTest : AbstractDaoTest
    {
        private ILabAlertResponseDao dao;
        private ILabAlertDao alertDao;
        private ILabAlertDefinitionDao definitionDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILabAlertResponseDao>();
            alertDao = DaoRegistry.GetDao<ILabAlertDao>();
            definitionDao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }

        private LabAlert InsertAlert()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition = definitionDao.Insert(definition);

            LabAlert alert = LabAlertFixture.CreateAlert();
            alert.LabAlertDefinitionId = definition.IdValue;

            alert = alertDao.Insert(alert);
            return alert;
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            long labAlertId = InsertAlert().IdValue;

            LabAlertResponse response = new LabAlertResponse(
                null, labAlertId, LabAlertStatus.Responded, "test comments", 
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), new DateTime(2011, 2, 10));
            response = dao.Insert(response);

            List<LabAlertResponse> requeried = dao.QueryByLabAlertId(labAlertId);
            Assert.AreEqual(1, requeried.Count);
            Assert.AreEqual(response.LabAlertId, requeried[0].LabAlertId);
            Assert.AreEqual(response.Status, requeried[0].Status);
            Assert.AreEqual(response.Comments, requeried[0].Comments);
            Assert.AreEqual(response.CreatedByUser.Id, requeried[0].CreatedByUser.Id);
            Assert.AreEqual(response.CreatedDateTime, requeried[0].CreatedDateTime);
        }

        [Ignore] [Test]
        public void ShouldQueryByLabAlertId()
        {
            long labAlertId1 = InsertAlert().IdValue;
            long labAlertId2 = InsertAlert().IdValue;

            LabAlertResponse response1 = new LabAlertResponse(
                null, labAlertId1, LabAlertStatus.Responded, "test comments",
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), new DateTime(2011, 2, 10));
            response1 = dao.Insert(response1);

            LabAlertResponse response2 = new LabAlertResponse(
                null, labAlertId2, LabAlertStatus.NotResponded, "test comments",
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), new DateTime(2011, 2, 10));
            response2 = dao.Insert(response2);

            {
                List<LabAlertResponse> requeried = dao.QueryByLabAlertId(labAlertId1);
                Assert.AreEqual(1, requeried.Count);
                Assert.AreEqual(response1.Id, requeried[0].Id);
            }
            {
                List<LabAlertResponse> requeried = dao.QueryByLabAlertId(labAlertId2);
                Assert.AreEqual(1, requeried.Count);
                Assert.AreEqual(response2.Id, requeried[0].Id);
            }
        }
    }
}
