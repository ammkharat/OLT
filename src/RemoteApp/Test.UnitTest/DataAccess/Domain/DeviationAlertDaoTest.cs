using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class DeviationAlertDaoTest : AbstractDaoTest
    {
        private IRestrictionDefinitionDao restrictionDefinitionDao;
        private IDeviationAlertDao deviationAlertDao;
        private IDeviationAlertResponseDao deviationAlertResponseDao;
        private TagInfo tag;

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            restrictionDefinitionDao = DaoRegistry.GetDao<IRestrictionDefinitionDao>();
            deviationAlertDao = DaoRegistry.GetDao<IDeviationAlertDao>();
            deviationAlertResponseDao = DaoRegistry.GetDao<IDeviationAlertResponseDao>();

            ITagDao tagDao = DaoRegistry.GetDao<ITagDao>();
            List<TagInfo> tags = tagDao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Oilsands().IdValue, "P86_REST_MASS_TARGET");
            tag = tags[0];
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            DeviationAlert alert = CreatePopulated(TagInfoFixture.CreateTagInfoWithId2FromDB(), DeviationAlertResponseFixture.CreateNewResponse());
            alert.Id = null;
            DeviationAlert saved = deviationAlertDao.Insert(alert);
            Assert.IsNotNull(saved.Id);

            DeviationAlert requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            AssertPopulatedFieldsAreEqual(requeried);
            Assert.IsNotNull(requeried.DeviationAlertResponse);

            DeviationAlertResponse responseFromDB = deviationAlertResponseDao.QueryById(requeried.DeviationAlertResponse.IdValue);
            Assert.IsNotNull(responseFromDB);
        }

        private DeviationAlert CreatePopulated(TagInfo productionTargetTag, DeviationAlertResponse response)
        {
            SchedulingList<RestrictionDefinition, OLTException> definitions = restrictionDefinitionDao.QueryAllAvailableForScheduling();
            RestrictionDefinition definition = definitions.DomainObjectList[0];

            DeviationAlert alert = new DeviationAlert(
               definition,
               "abc",
               "some description",
               response,
               productionTargetTag,
               TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC(),
               123,
               456,
               new DateTime(2010, 1, 1, 2, 0, 0),
               new DateTime(2010, 1, 1, 3, 0, 0),
               FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3(),
               UserFixture.CreateUserWithGivenId(1),
               DateTimeFixture.DateTimeNow,
               DateTimeFixture.DateTimeNow) { Comments = "Here are some comments" };

            return alert;
        }

        private static void AssertPopulatedFieldsAreEqual(DeviationAlert alert)
        {
            Assert.AreEqual("abc", alert.RestrictionDefinitionName);
            Assert.AreEqual("some description", alert.RestrictionDefinitionDescription);
            Assert.AreEqual(TagInfoFixture.CreateTagInfoWithId2FromDB().Id, alert.ProductionTargetTag.Id);
            Assert.AreEqual(TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC().Id, alert.MeasurementTag.Id);
            Assert.AreEqual(123, alert.ProductionTargetValue);
            Assert.AreEqual(456, alert.MeasurementValue);
            Assert.AreEqual(new DateTime(2010, 1, 1, 2, 0, 0), alert.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 1, 1, 3, 0, 0), alert.EndDateTime);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3().Id, alert.FunctionalLocation.Id);
            Assert.AreEqual(1, alert.LastModifiedBy.Id);
            Assert.AreEqual("Here are some comments", alert.Comments);
        }

        [Ignore] [Test]
        public void ShouldInsertNullProductionTargetTag()
        {
            DeviationAlert alert = CreatePopulated(null, null);
            alert.Id = null;
            DeviationAlert saved = deviationAlertDao.Insert(alert);
            Assert.IsNotNull(saved.Id);

            DeviationAlert requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            Assert.IsNull(requeried.ProductionTargetTag);
        }

        [Ignore] [Test]
        public void ShouldUpdateResponse_InsertNewResponse()
        {
            DeviationAlert alert = CreatePopulated(TagInfoFixture.CreateTagInfoWithId2FromDB(), null);
            alert.Id = null;
            DeviationAlert saved = deviationAlertDao.Insert(alert);
            Assert.IsNotNull(saved.Id);

            DeviationAlert requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            AssertPopulatedFieldsAreEqual(requeried);
            Assert.IsNull(requeried.DeviationAlertResponse);

            requeried.DeviationAlertResponse = DeviationAlertResponseFixture.CreateNewResponse();
            deviationAlertDao.UpdateDeviationAlertResponse(requeried);

            requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried.DeviationAlertResponse);
        }


        [Ignore] [Test]
        public void ShouldUpdateResponse_UpdateExistingResponse()
        {
            DeviationAlert alert = CreatePopulated(TagInfoFixture.CreateTagInfoWithId2FromDB(), DeviationAlertResponseFixture.CreateNewResponse());
            alert.Id = null;
            DeviationAlert saved = deviationAlertDao.Insert(alert);
            DeviationAlert requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried.DeviationAlertResponse);

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            requeried.DeviationAlertResponse.ReasonCodeAssignments.Add(GetReasonCodeAssignment(floc1, 1, "TEST1"));

            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            requeried.DeviationAlertResponse.ReasonCodeAssignments.Add(GetReasonCodeAssignment(floc2, 2, "TEST2"));

            requeried.DeviationAlertResponse.LastModifiedBy = UserFixture.CreateUserWithGivenId(2);
            requeried.DeviationAlertResponse.LastModifiedDateTime = new DateTime(2010, 6, 18);

            deviationAlertDao.UpdateDeviationAlertResponse(requeried);

            requeried = deviationAlertDao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried.DeviationAlertResponse);
            Assert.AreEqual(2, requeried.DeviationAlertResponse.ReasonCodeAssignments.Count);
            Assert.AreEqual(2, requeried.DeviationAlertResponse.LastModifiedBy.Id);
            Assert.AreEqual(18, requeried.DeviationAlertResponse.LastModifiedDateTime.Day);
            Assert.AreEqual(6, requeried.DeviationAlertResponse.LastModifiedDateTime.Month);
        }

        [Ignore] [Test]
        public void ShouldUpdateComments()
        {
            {
                DeviationAlert alert = CreatePopulated(TagInfoFixture.CreateTagInfoWithId2FromDB(), null);
                alert.Id = null;
                DeviationAlert saved = deviationAlertDao.Insert(alert);
                DeviationAlert requeried = deviationAlertDao.QueryById(saved.Id.Value);

                requeried.Comments = "These are comments, yo.";
                deviationAlertDao.UpdateDeviationAlertComment(requeried);

                DeviationAlert rerequeried = deviationAlertDao.QueryById(saved.Id.Value);
                Assert.AreEqual(requeried.Comments, rerequeried.Comments);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateCommentsToNull()
        {
            {
                DeviationAlert alert = CreatePopulated(TagInfoFixture.CreateTagInfoWithId2FromDB(), null);
                alert.Id = null;
                DeviationAlert saved = deviationAlertDao.Insert(alert);
                DeviationAlert requeried = deviationAlertDao.QueryById(saved.Id.Value);

                requeried.Comments = null;
                deviationAlertDao.UpdateDeviationAlertComment(requeried);

                DeviationAlert rerequeried = deviationAlertDao.QueryById(saved.Id.Value);
                Assert.AreEqual(requeried.Comments, rerequeried.Comments);
            }
        }

        private static DeviationAlertResponseReasonCodeAssignment GetReasonCodeAssignment(FunctionalLocation floc, long reasonCodeId, string reasonCodeName)
        {
            RestrictionReasonCode reasonCode = RestrictionReasonCodeFixture.GetRestrictionReasonCode(reasonCodeId, reasonCodeName);

            const int assignedAmount = 12345;
            User lastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            DateTime lastModified = DateTimeFixture.DateTimeNow;
            DateTime created = DateTimeFixture.DateTimeNow;

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCode);
            DeviationAlertResponseReasonCodeAssignment assignment =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, floc, reasonCode, "Shutdown", assignedAmount, "Comments", lastModifiedBy, lastModified, created);

            return assignment;
        }

        [Ignore] [Test]
        public void ShouldNotFindLastRespondedToAlertWhenNoAlertsExist()
        {
            RestrictionDefinition definition = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));
            DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition);
            Assert.IsNull(lastRespondedToAlert);
        }

        [Ignore] [Test]
        public void ShouldNotFindLastRespondedToAlertWhenNoResponsesExist()
        {
            RestrictionDefinition definition = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));

            DeviationAlert alert = DeviationAlertFixture.Create(definition);
            alert.DeviationAlertResponse = null;
            deviationAlertDao.Insert(alert);

            DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition);
            Assert.IsNull(lastRespondedToAlert);
        }

        [Ignore] [Test]
        public void ShouldFindLastRespondedToAlert()
        {
            RestrictionDefinition definition = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));

            long alertId1 = CreateAlertWithResponse(definition, new DateTime(2001, 3, 20), "comments1");
            long alertId2 = CreateAlertWithResponse(definition, new DateTime(2001, 3, 21), "comments2");
            long alertId3 = CreateAlertWithResponse(definition, new DateTime(2001, 3, 19), "comments3");

            DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition);
            Assert.IsNotNull(lastRespondedToAlert);
            Assert.AreEqual(alertId2, lastRespondedToAlert.Id);
        }

        [Ignore] [Test]
        public void ShouldFindLastRespondedToAlertByDefinition()
        {
            RestrictionDefinition definition1 = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));
            RestrictionDefinition definition2 = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));
            RestrictionDefinition definition3 = restrictionDefinitionDao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));

            long alertId1 = CreateAlertWithResponse(definition1, new DateTime(2001, 3, 20), "comments1");
            long alertId2 = CreateAlertWithResponse(definition2, new DateTime(2001, 3, 21), "comments2");
            long alertId3 = CreateAlertWithResponse(definition2, new DateTime(2001, 3, 19), "comments3");

            {
                DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition1);
                Assert.IsNotNull(lastRespondedToAlert);
                Assert.AreEqual(alertId1, lastRespondedToAlert.Id);
            }
            {
                DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition2);
                Assert.IsNotNull(lastRespondedToAlert);
                Assert.AreEqual(alertId2, lastRespondedToAlert.Id);
            }
            {
                DeviationAlert lastRespondedToAlert = deviationAlertDao.GetLastRespondedToAlert(definition3);
                Assert.IsNull(lastRespondedToAlert);
            }
        }

        private long CreateAlertWithResponse(RestrictionDefinition definition, DateTime responseLastModifiedDate, string comments)
        {
            DeviationAlert alert = DeviationAlertFixture.Create(definition);
            alert = deviationAlertDao.Insert(alert);

            alert.DeviationAlertResponse = new DeviationAlertResponse(comments,
                UserFixture.CreateUserWithGivenId(2), responseLastModifiedDate, new DateTime(1998, 2, 1))
            {
                LastModifiedBy = UserFixture.CreateUserWithGivenId(2)
            };
            alert.LastModifiedBy = UserFixture.CreateDBInsertableUser();
            deviationAlertDao.UpdateDeviationAlertResponse(alert);

            return alert.IdValue;
        }
    }
}
