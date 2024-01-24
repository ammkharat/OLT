using System;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LabAlertDaoTest : AbstractDaoTest
    {
        private ILabAlertDao dao;
        private ILabAlertDefinitionDao definitionDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILabAlertDao>();
            definitionDao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryById()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            LabAlertDefinition insertedLabAlertDefinition = definitionDao.Insert(definition);

            DateTime rangeFrom = new DateTime(2010, 2, 25);
            DateTime rangeTo = new DateTime(2010, 2, 28);
            DateTime lastModifiedDate = new DateTime(2010, 3, 9);
            DateTime createdDate = new DateTime(2010, 1, 15);

            LabAlert alert = LabAlertFixture.CreateAlert(rangeFrom, rangeTo, lastModifiedDate, createdDate);

            alert.LabAlertDefinitionId = insertedLabAlertDefinition.IdValue;

            LabAlert returnedFromInsert = dao.Insert(alert);
            LabAlert returnedFromQueryById = dao.QueryById(returnedFromInsert.IdValue);

            Assert.IsNotNull(returnedFromQueryById);

            Assert.AreEqual(alert.Name, returnedFromQueryById.Name);
            Assert.AreEqual(alert.Description, returnedFromQueryById.Description);
            Assert.AreEqual(alert.FunctionalLocation.IdValue, returnedFromQueryById.FunctionalLocation.IdValue);
            Assert.AreEqual(alert.TagInfo.IdValue, returnedFromQueryById.TagInfo.IdValue);
            Assert.AreEqual(alert.MinimumNumberOfSamples, returnedFromQueryById.MinimumNumberOfSamples);
            Assert.AreEqual(alert.ActualNumberOfSamples, returnedFromQueryById.ActualNumberOfSamples);
            Assert.AreEqual(alert.LabAlertTagQueryRangeFromDateTime, returnedFromQueryById.LabAlertTagQueryRangeFromDateTime);
            Assert.AreEqual(alert.LabAlertTagQueryRangeToDateTime, returnedFromQueryById.LabAlertTagQueryRangeToDateTime);
            Assert.AreEqual(alert.ScheduleDescription, returnedFromQueryById.ScheduleDescription);
            Assert.AreEqual(alert.LabAlertDefinitionId, returnedFromQueryById.LabAlertDefinitionId);
            Assert.AreEqual(alert.LastModifiedBy.IdValue, returnedFromQueryById.LastModifiedBy.IdValue);
            Assert.AreEqual(alert.LastModifiedDate, returnedFromQueryById.LastModifiedDate);
            Assert.AreEqual(alert.CreatedDateTime, returnedFromQueryById.CreatedDateTime);
            Assert.AreEqual(alert.Status, returnedFromQueryById.Status);           
        }   
        
        [Ignore] [Test]  
        public void ShouldUpdateStatusAndResponses()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            LabAlertDefinition insertedLabAlertDefinition = definitionDao.Insert(definition);

            LabAlert alert = LabAlertFixture.CreateAlert();
            alert.LabAlertDefinitionId = insertedLabAlertDefinition.IdValue;
            alert.LastModifiedDate = new DateTime(2011, 1, 1);
            alert.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            alert.Status = LabAlertStatus.NotResponded;
            alert = dao.Insert(alert);

            alert.LastModifiedDate = new DateTime(2011, 1, 2);
            alert.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
            alert.Status = LabAlertStatus.Responded;
            alert.Responses.Add(new LabAlertResponse(null, 
                alert.IdValue, 
                LabAlertStatus.NotResponded,                 
                "comment1",
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite(),
                new DateTime(2011, 2, 1)));
            alert.Responses.Add(new LabAlertResponse(null,
                alert.IdValue,
                LabAlertStatus.Responded,                 
                "comment2",
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2011, 2, 2)));

            dao.UpdateStatusAndResponses(alert);
            foreach (LabAlertResponse response in alert.Responses)
            {
                Assert.IsNotNull(response.Id);
            }

            LabAlert requeried = dao.QueryById(alert.IdValue);
            Assert.AreEqual(new DateTime(2011, 1, 2), requeried.LastModifiedDate);
            Assert.AreEqual(UserFixture.CreateOperatorOltUser1InFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(LabAlertStatus.Responded, requeried.Status);
            {
                LabAlertResponse response = requeried.Responses.Find(obj => obj.Comments == "comment1");
                Assert.IsNotNull(response);
                Assert.AreEqual(LabAlertStatus.NotResponded, response.Status);
                Assert.AreEqual(UserFixture.CreateOperatorOltUser1InFortMcMurrySite().Id, response.CreatedByUser.Id);
                Assert.AreEqual(new DateTime(2011, 2, 1), response.CreatedDateTime);
            }
            {
                LabAlertResponse response = requeried.Responses.Find(obj => obj.Comments == "comment2");
                Assert.IsNotNull(response);
                Assert.AreEqual(LabAlertStatus.Responded, response.Status);
                Assert.AreEqual(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB().Id, response.CreatedByUser.Id);
                Assert.AreEqual(new DateTime(2011, 2, 2), response.CreatedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertLabAlertRetryFailure()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            LabAlertDefinition insertedLabAlertDefinition = definitionDao.Insert(definition);

            LabAlert labAlert = LabAlert.CreateLabAlertForTagFailure(
                insertedLabAlertDefinition, definition.Schedule.StartDateTime, UserFixture.CreateUserWithGivenId(1),
                definition.Schedule.StartDateTime);

            dao.Insert(labAlert);

            LabAlert queriedLabAlert = dao.QueryById(labAlert.IdValue);

            Assert.IsNotNull(queriedLabAlert);
        }
    }
}
