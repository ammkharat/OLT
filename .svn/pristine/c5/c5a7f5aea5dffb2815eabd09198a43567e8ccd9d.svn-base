using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class DeviationAlertResponseDaoTest : AbstractDaoTest
    {
        private IDeviationAlertResponseDao deviationAlertResponseDao;

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            deviationAlertResponseDao = DaoRegistry.GetDao<IDeviationAlertResponseDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryById()
        {
            DeviationAlertResponse deviationAlertResponse = DeviationAlertResponseFixture.CreateNewResponse();
            DeviationAlertResponse responseReturnedFromInsert = deviationAlertResponseDao.Insert(deviationAlertResponse);

            DeviationAlertResponse queriedResponse = deviationAlertResponseDao.QueryById(responseReturnedFromInsert.IdValue);

            Assert.IsNotNull(queriedResponse);
            Assert.That(deviationAlertResponse.CreatedDateTime, Is.EqualTo(queriedResponse.CreatedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.That(deviationAlertResponse.LastModifiedDateTime, Is.EqualTo(queriedResponse.LastModifiedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(deviationAlertResponse.LastModifiedBy.Id, queriedResponse.LastModifiedBy.Id);
        }

        [Ignore] [Test]
        public void ShouldLoadDeviationAlertResponseReasonCodeAssignments()
        {
            DeviationAlertResponse deviationAlertResponse = deviationAlertResponseDao.QueryById(1);
            Assert.IsTrue(deviationAlertResponse.ReasonCodeAssignments.Count >= 2);
        }

        [Ignore] [Test]
        public void ShouldInsertDeviationAlertResponseReasonCodeAssignments()
        {
            DeviationAlertResponse deviationAlertResponse = DeviationAlertResponseFixture.CreateNewResponse();

            User user = UserFixture.CreateUserWithGivenId(1);

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("SR1-PLT1");

            RestrictionReasonCode code1 = RestrictionReasonCodeFixture.GetRestrictionReasonCode(600, "CODE1");
            RestrictionReasonCode code2 = RestrictionReasonCodeFixture.GetRestrictionReasonCode(600, "CODE2");

            RestrictionLocationItem restrictionLocationItem1 = RestrictionLocationItemFixture.CreateWithReasonCodes(floc1, code1);
            RestrictionLocationItem restrictionLocationItem2 = RestrictionLocationItemFixture.CreateWithReasonCodes(floc2, code2);

            DeviationAlertResponseReasonCodeAssignment assignment1 =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem1, floc1, code1, "Shutdown", 20, "Comments", user, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);

            DeviationAlertResponseReasonCodeAssignment assignment2 =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem2, floc2, code2, "Shutdown", 80, "Comments", user, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);

            deviationAlertResponse.ReasonCodeAssignments.Add(assignment1);
            deviationAlertResponse.ReasonCodeAssignments.Add(assignment2);

            deviationAlertResponseDao.Insert(deviationAlertResponse);

            DeviationAlertResponse responseFromDB = deviationAlertResponseDao.QueryById(deviationAlertResponse.IdValue);
            Assert.AreEqual(2, responseFromDB.ReasonCodeAssignments.Count);            
        }

        [Ignore] [Test]
        public void ShouldUpdateAnExistingResponseWithNoAssignments()
        {
            DeviationAlertResponse deviationAlertResponse = DeviationAlertResponseFixture.CreateNewResponse();

            User user = UserFixture.CreateUserWithGivenId(1);
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            RestrictionReasonCode code1 = RestrictionReasonCodeFixture.GetRestrictionReasonCode(600, "CODE1");

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(floc1, code1);
            DeviationAlertResponseReasonCodeAssignment assignment1 =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, floc1, code1, "Shutdown", 20, "Comments", user, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            deviationAlertResponse.ReasonCodeAssignments.Add(assignment1);

            deviationAlertResponseDao.Insert(deviationAlertResponse);
            {
                DeviationAlertResponse response = deviationAlertResponseDao.QueryById(deviationAlertResponse.IdValue);
                Assert.AreEqual(1, response.ReasonCodeAssignments.Count);
            }

            deviationAlertResponse.ReasonCodeAssignments.Clear();
            deviationAlertResponseDao.UpdateResponseCodeAssignments(deviationAlertResponse);
            {
                DeviationAlertResponse response = deviationAlertResponseDao.QueryById(deviationAlertResponse.IdValue);
                Assert.AreEqual(0, response.ReasonCodeAssignments.Count);
            }
        }
    }
}