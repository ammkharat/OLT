using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetAlertDaoTest : AbstractDaoTest
    {
        private ITargetAlertDao dao;
        private IFunctionalLocationDao functionalLocationDao;
        private IShiftPatternDao shiftPatternDao;

        protected override void TestInitialize()
        {
            Clock.Freeze();
            dao = DaoRegistry.GetDao<ITargetAlertDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        protected override void Cleanup()
        {
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void InsertShouldReturnTheTarget()
        {
            TargetAlert targetToInsert = TargetAlertFixture.CreateATargetAlert();
            targetToInsert = dao.Insert(targetToInsert);
            Assert.IsTrue(targetToInsert.IsInDatabase());
            TargetAlert resultTarget = dao.QueryById(targetToInsert.IdValue);
            Assert.IsNotNull(resultTarget);
        }

        [Ignore] [Test]
        public void InsertWithMaxValuesOnlyShouldReturnTheTargetWithMinValueNull()
        {
            TargetAlert targetToInsert = TargetAlertFixture.CreateATargetWithNullMinValue();
            targetToInsert = dao.Insert(targetToInsert);
            Assert.IsNotNull(targetToInsert.Id);
            TargetAlert resultTarget = dao.QueryById(targetToInsert.IdValue);
            Assert.IsNotNull(resultTarget);
            Assert.IsNull(resultTarget.MinValue);
        }

        [Ignore] [Test]
        public void InsertShouldPersistPriority()
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.StandardAlert, Priority.Elevated);
            targetAlert = dao.Insert(targetAlert);
            TargetAlert retrievedTargetAlert = dao.QueryById(targetAlert.IdValue);
            Assert.AreEqual(Priority.Elevated, retrievedTargetAlert.Priority);
        }

        [Ignore] [Test]
        public void GetTargetByIdShouldReturnOneRecordIfIdEquals()
        {
            TargetAlert targetToInsert = TargetAlertFixture.CreateATargetWithNullMinValue();
            targetToInsert = dao.Insert(targetToInsert);
            Assert.IsNotNull(targetToInsert.Id);
            TargetAlert resultTarget = dao.QueryById(targetToInsert.IdValue);
            Assert.IsNotNull(resultTarget);
            Assert.AreEqual(targetToInsert.IdValue, resultTarget.IdValue);            
        }

        [Ignore] [Test]
        public void InsertedAndRetrievedTargetShouldBeEqual()
        {
            TargetAlert originalAlert = TargetAlertFixture.CreateATargetAlert();
            originalAlert.LastModifiedBy.Id = 2;
            originalAlert.RequiresResponse = true;
            originalAlert.ExceedingBoundaries = true;

            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            //
            //  Causing the Actual Value to have different value than
            // OriginalExceedingValue
            //
            TargetThresholdEvaluation evaluation = new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 320.0m, originalAlert.ActualValue.Value + 10m, 3680.0m);
            originalAlert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);
            

            dao.Insert(originalAlert);

            Assert.IsNotNull(originalAlert.Id);

            //
            // Doing it this way since fixture tag, mode objects are not the same as database versions.
            //
            TargetAlert retrievedAlert = dao.QueryById(originalAlert.IdValue);
            Assert.AreEqual(originalAlert.Tag.Id, retrievedAlert.Tag.Id);
            Assert.AreEqual(originalAlert.Status, retrievedAlert.Status);
            Assert.AreEqual(originalAlert.FunctionalLocation.Id, retrievedAlert.FunctionalLocation.Id);
            Assert.AreEqual(originalAlert.MaxValue, retrievedAlert.MaxValue);
            Assert.AreEqual(originalAlert.MinValue, retrievedAlert.MinValue);
            Assert.AreEqual(originalAlert.NeverToExceedMaximum, retrievedAlert.NeverToExceedMaximum);
            Assert.AreEqual(originalAlert.NeverToExceedMinimum, retrievedAlert.NeverToExceedMinimum);
            Assert.AreEqual(originalAlert.MaxValueFrequency, retrievedAlert.MaxValueFrequency);
            Assert.AreEqual(originalAlert.MinValueFrequency, retrievedAlert.MinValueFrequency);
            Assert.AreEqual(originalAlert.NeverToExceedMaxFrequency, retrievedAlert.NeverToExceedMaxFrequency);
            Assert.AreEqual(originalAlert.NeverToExceedMinFrequency, retrievedAlert.NeverToExceedMinFrequency);
            Assert.AreEqual(originalAlert.TargetValue, retrievedAlert.TargetValue);
            Assert.AreEqual(originalAlert.GapUnitValue, retrievedAlert.GapUnitValue);
            Assert.AreEqual(originalAlert.Category, retrievedAlert.Category);
            Assert.That(originalAlert.CreatedDateTime, Is.EqualTo(retrievedAlert.CreatedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(originalAlert.CreatedByScheduleType, retrievedAlert.CreatedByScheduleType);
            Assert.AreEqual(originalAlert.RequiresResponse, retrievedAlert.RequiresResponse);
            Assert.AreEqual(originalAlert.ExceedingBoundaries, retrievedAlert.ExceedingBoundaries);
            Assert.AreEqual(originalAlert.ActualValue, retrievedAlert.ActualValue);
            Assert.AreEqual(originalAlert.OriginalExceedingValue, retrievedAlert.OriginalExceedingValue);
            Assert.AreEqual(originalAlert.LastModifiedBy.Id, retrievedAlert.LastModifiedBy.Id);
            // Check parent target definition:
            Assert.AreEqual(originalAlert.TargetDefinition.Id, retrievedAlert.TargetDefinition.Id);
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            TargetAlert targetAlertForInsert = TargetAlertFixture.CreateATargetAlert();
            targetAlertForInsert.DocumentLinks.AddRange(DocumentLinkFixture.CreateDocumentListOfTwo());
            dao.Insert(targetAlertForInsert);
            TargetAlert retrievedAlert = dao.QueryById(targetAlertForInsert.IdValue);
            Assert.AreEqual(targetAlertForInsert.DocumentLinks.Count, retrievedAlert.DocumentLinks.Count);

            Assert.That(retrievedAlert.DocumentLinks,
                        Has.Some.EqualTo(targetAlertForInsert.DocumentLinks[0]));
            Assert.That(retrievedAlert.DocumentLinks,
                        Has.Some.EqualTo(targetAlertForInsert.DocumentLinks[1]));

        }

        [Ignore] [Test]
        public void QueryTargetAlertShouldReturnInsertedTargetAlertWithTargetValue()
        {
            QueryTargetAlertShouldReturnInsertedTargetAlertWithTargetValue(TargetValue.CreateMinimizeTarget());
            QueryTargetAlertShouldReturnInsertedTargetAlertWithTargetValue(TargetValue.CreateMaximizeTarget());
            QueryTargetAlertShouldReturnInsertedTargetAlertWithTargetValue(TargetValue.CreateEmptyTarget());
        }

        [Ignore] [Test]
        public void QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue()
        {
            QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                          TargetValue.CreateMinimizeTarget());
            QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                          TargetValue.CreateMaximizeTarget());
            QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                          TargetValue.CreateEmptyTarget());
            QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue(TargetValue.CreateMaximizeTarget(),
                                                                          TargetValue.CreateSpecifiedTarget(16.0m));
        }

        [Ignore] [Test]
        public void ShouldQueryByTargetDefinitionAndStatuses()
        {
            // Create target definition with two alerts (one new, one closed):
            TargetDefinition definition =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            definition.Assignment = null;
            definition = DaoRegistry.GetDao<ITargetDefinitionDao>().Insert(definition);
            TargetAlert newAlert = CreateAndInsertTargetAlert(definition, TargetAlertStatus.StandardAlert);
            CreateAndInsertTargetAlert(definition, TargetAlertStatus.Closed);
            // Execute:
            List<TargetAlertStatus> statuses = new List<TargetAlertStatus> { TargetAlertStatus.StandardAlert };
            List<TargetAlert> retrievedAlerts =
                    dao.QueryByTargetDefinitionAndStatuses(definition, statuses);
            Assert.AreEqual(1, retrievedAlerts.Count);
            Assert.AreEqual(newAlert.Id, retrievedAlerts[0].Id);
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndUserShiftShouldReturnAlertsUnderSameSectionAsShift()
        {
            ShiftPattern shiftPattern = InsertShiftPattern(new Time(6), new Time(18));
            TargetAlert offsiteTargetAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 12, 00, 00), "SR1-OFFS-BDOF");
            TargetAlert plant1TargetAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 12, 00, 00), "SR1-PLT1-AFTU");
            List<FunctionalLocation> flocs = 
                new List<FunctionalLocation>
                    {
                        offsiteTargetAlert.FunctionalLocation,
                        plant1TargetAlert.FunctionalLocation
                    };
            List<TargetAlert> alerts =
                    dao.QueryByFunctionalLocationsAndUserShift(new RootFlocSet(flocs),
                                                               new UserShift(shiftPattern, new DateTime(2006, 7, 3, 12, 00, 00)));
            Assert.That(alerts, Has.Some.Property("Id").EqualTo(offsiteTargetAlert.Id));
            Assert.That(alerts, Has.Some.Property("Id").EqualTo(plant1TargetAlert.Id));
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndUserShiftShouldReturnAlertsWithinShiftStartAndEnd()
        {
            ShiftPattern shiftPattern = InsertShiftPattern(new Time(6), new Time(18));
            TargetAlert earlyTargetAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 5, 59, 0), "SR1-OFFS-BDOF");
            TargetAlert insideTargetAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 7, 0, 0), "SR1-OFFS-BDOF");
            TargetAlert lateTargetAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 18, 1, 0), "SR1-OFFS-BDOF");
            List<TargetAlert> alerts =
                    dao.QueryByFunctionalLocationsAndUserShift(
                            new RootFlocSet(earlyTargetAlert.FunctionalLocation),
                            new UserShift(shiftPattern, new DateTime(2006, 7, 3, 12, 00, 00)));

            Assert.That(alerts, Has.Some.Property("Id").EqualTo(insideTargetAlert.Id));
            Assert.That(alerts, Has.None.Property("Id").EqualTo(earlyTargetAlert.Id));
            Assert.That(alerts, Has.None.Property("Id").EqualTo(lateTargetAlert.Id));
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndUserShiftShouldReturnAlertsMatchingFunctionalLocations()
        {
            ShiftPattern shiftPattern = InsertShiftPattern(new Time(6), new Time(18));
            TargetAlert frauAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 7, 0, 0), "SR1-PLT3-FRAU");
            TargetAlert hyduAlert = InsertTargetAlert(new DateTime(2006, 7, 3, 7, 0, 0), "SR1-PLT3-HYDU");
            List<TargetAlert> alerts =
                    dao.QueryByFunctionalLocationsAndUserShift(
                            new RootFlocSet(hyduAlert.FunctionalLocation),
                            new UserShift(shiftPattern, new DateTime(2006, 7, 3, 12, 00, 00)));

            Assert.That(alerts, Has.Some.Property("Id").EqualTo( hyduAlert.Id));
            Assert.That(alerts, Has.None.Property("Id").EqualTo( frauAlert.Id));

        }

        [Ignore] [Test]
        public void ShouldUpdateTargetAlert()
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.LastModifiedBy.Id = 2;
            alert.Status = TargetAlertStatus.StandardAlert;
            alert.ExceedingBoundaries = true;
            alert.ActualValue = 5.0m;
            PopulateThresholdValues(alert, -222, -111, -333, -444, -555);
            alert.GapUnitValue = 9.5m;
            alert.Description = "The quick brown fox";
            alert.ActualValueAtEvaluation = 23.2m;
            alert = dao.Insert(alert);
            // Change alert properties which can be changed:
            TargetAlertStatus newStatus = TargetAlertStatus.Acknowledged;
            alert.ExceedingBoundaries = false;
            alert.Status = newStatus;
            alert.ActualValue = alert.ActualValue + 1.0m;
            PopulateThresholdValues(alert, 222, 111, 333, 444, 555);
            alert.GapUnitValue = 10.1m;
            alert.Description = "Jumped over the lazy dog";
            alert.ActualValueAtEvaluation = alert.ActualValueAtEvaluation + 1.0m;
            // Execute:
            dao.Update(alert);
            TargetAlert retrievedAlert = dao.QueryById(alert.IdValue);
            Assert.AreEqual(false, retrievedAlert.ExceedingBoundaries);
            Assert.AreEqual(newStatus, retrievedAlert.Status);
            Assert.AreEqual(6.0m, retrievedAlert.ActualValue);
            Assert.That(alert.LastModifiedDateTime, Is.EqualTo(retrievedAlert.LastModifiedDateTime).Within(TimeSpan.FromSeconds(10)));
            AssertThresholdValues(alert, retrievedAlert);
            Assert.AreEqual(10.1m, retrievedAlert.GapUnitValue);
            Assert.AreEqual(24.2m, retrievedAlert.ActualValueAtEvaluation);
        }

        [Ignore] [Test]
        public void ShouldUpdateNullableValuesOnTargetAlert()
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.LastModifiedBy.Id = 2;
            alert.Status = TargetAlertStatus.StandardAlert;
            alert.ExceedingBoundaries = true;
            alert.ActualValue = 5.0m;
            PopulateThresholdValues(alert, -222, -111, -333, -444, -555);
            alert.Description = "The quick brown fox";
            alert = dao.Insert(alert);
            PopulateThresholdValues(alert, null, null, null, null, null);
            alert.GapUnitValue = null;
            // Execute:
            dao.Update(alert);
            TargetAlert retrievedAlert = dao.QueryById(alert.IdValue);
            AssertThresholdValues(alert, retrievedAlert);
            Assert.IsNull(retrievedAlert.GapUnitValue);
        }

        [Ignore] [Test]
        public void UpdateShouldPersistAcknowledgeUserAndDateTime()
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert = dao.Insert(alert);
            alert.AcknowledgedUser = UserFixture.CreateUserWithGivenId(1);
            alert.AcknowledgedDateTime = new DateTime(2006, 8, 25, 11, 23, 59);
            dao.Update(alert);
            TargetAlert retrievedAlert = dao.QueryById(alert.IdValue);
            Assert.AreEqual(alert.AcknowledgedUser.Id, retrievedAlert.AcknowledgedUser.Id);
            Assert.AreEqual(alert.AcknowledgedDateTime, retrievedAlert.AcknowledgedDateTime);
        }

        private static void PopulateThresholdValues(TargetAlert alert, 
                                             decimal? neverToExceedMax,
                                             decimal? max, 
                                             decimal? min, 
                                             decimal? neverToExceedMin,
                                             decimal? targetValue)
        {
            alert.MaxValue = max;
            alert.NeverToExceedMaximum = neverToExceedMax;
            alert.MinValue = min;
            alert.NeverToExceedMinimum = neverToExceedMin;
            alert.TargetValue = targetValue.HasValue ? TargetValue.CreateSpecifiedTarget(targetValue.Value) : TargetValue.CreateEmptyTarget();
        }

        private static void AssertThresholdValues(TargetAlert expected, TargetAlert actual)
        {
            Assert.AreEqual(expected.NeverToExceedMaximum, actual.NeverToExceedMaximum);
            Assert.AreEqual(expected.MaxValue, actual.MaxValue);
            Assert.AreEqual(expected.MinValue, actual.MinValue);
            Assert.AreEqual(expected.NeverToExceedMinimum, actual.NeverToExceedMinimum);
            Assert.AreEqual(expected.TargetValue, actual.TargetValue);
        }

        private TargetAlert CreateAndInsertTargetAlert(TargetDefinition definition, TargetAlertStatus status)
        {
            TargetThresholdEvaluation evaluation =
                    new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, -13.3m, -12.3m, 1.0m);
            TargetAlert newAlert = definition.CreateTargetAlert(evaluation, DateTimeFixture.DateTimeNow, UserFixture.CreateUser());
            newAlert.LastModifiedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            newAlert.Status = status;
            newAlert = dao.Insert(newAlert);
            return newAlert;
        }

        [Ignore] [Test]
        public void QueryAllTargetAlertsUnderAUnitFLOCShouldReturnAlertsToBeCleared()
        {
            FunctionalLocation unitFloc = FunctionalLocationFixture.CreateNew("SR1-OFFS-NEW");
            functionalLocationDao.Insert(unitFloc);
            // sanity check
            FunctionalLocation persistedUnitFloc = functionalLocationDao.QueryById(unitFloc.IdValue);
            // make a floc under this unit floc
            FunctionalLocation equipment1Floc = FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(persistedUnitFloc, "Equip1");
            functionalLocationDao.Insert(equipment1Floc);
            // insert the Target Alert linked to the equipment1 floc.
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.Id = null;
            targetAlert.Status = TargetAlertStatus.AllNeedingAttention[0];
            targetAlert.FunctionalLocation = equipment1Floc;
            TargetAlert insertedTargetAlert = dao.Insert(targetAlert);
            List<TargetAlert> resultingList = dao.QueryAllTargetAlertsNeedingAttention(new List<FunctionalLocation> {persistedUnitFloc}, TargetAlertStatus.AllNeedingAttention);
            Assert.IsNotNull(resultingList);
            Assert.AreEqual(1, resultingList.Count);
            Assert.AreEqual(insertedTargetAlert.Id, resultingList[0].Id);
        }

        private void QueryTargetAlertShouldReturnInsertedTargetAlertWithTargetValue(TargetValue targetValue)
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.TargetValue = targetValue;
            targetAlert = dao.Insert(targetAlert);
            TargetAlert retrievedTargetAlert = dao.QueryById(targetAlert.IdValue);
            Assert.AreEqual(targetValue, retrievedTargetAlert.TargetValue);
        }

        private void QueryTargetAlertShouldReturnUpdatedTargetAlertWithTargetValue(TargetValue oldTargetValue,
                                                                                   TargetValue newTargetValue)
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.TargetValue = oldTargetValue;
            targetAlert = dao.Insert(targetAlert);
            targetAlert.TargetValue = newTargetValue;
            dao.Update(targetAlert);
            TargetAlert retrievedTargetAlert = dao.QueryById(targetAlert.IdValue);
            Assert.AreEqual(newTargetValue, retrievedTargetAlert.TargetValue);
        }

        private TargetAlert InsertTargetAlert(DateTime createdDateTime, string functionalLoactionFullHierarchy)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.CreatedDateTime = createdDateTime;
            alert.FunctionalLocation = functionalLocationDao.QueryByFullHierarchy(functionalLoactionFullHierarchy, SiteFixture.Sarnia().IdValue);
            return dao.Insert(alert);
        }

        private ShiftPattern InsertShiftPattern(Time startTime, Time endTime)
        {
            return shiftPatternDao.Insert(ShiftPatternFixture.CreateShiftPattern(startTime, endTime));
        }
    }

}