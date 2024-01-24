using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Bootstrap;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class TargetAlertDTODaoTest : AbstractDaoTest
    {
        private ITargetAlertDTODao targetAlertDTODao;
        private ITargetAlertDao targetAlertDao;


        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            targetAlertDTODao = DaoRegistry.GetDao<ITargetAlertDTODao>();
            targetAlertDao = DaoRegistry.GetDao<ITargetAlertDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldIncludeLastViolatedFieldInDTO()
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.LastViolatedDateTime = new DateTime(2013, 1, 8);
            targetAlert = targetAlertDao.Insert(targetAlert);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetAlertStatus> statuses = new List<TargetAlertStatus> { TargetAlertStatus.StandardAlert };

            List<TargetAlertDTO> retrievedAlerts = targetAlertDTODao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(flocs), statuses, new DateRange(null, null));
            TargetAlertDTO dto = retrievedAlerts.Find(i => i.IdValue == targetAlert.IdValue);
            Assert.That(dto.LastViolatedDateTime, Is.EqualTo(targetAlert.LastViolatedDateTime).Within(1).Seconds);            
        }

        [Ignore] [Test]
        public void QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithTargetValue()
        {
            QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithCorrespondingTargetValue(
                TargetValue.CreateMinimizeTarget());
            QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithCorrespondingTargetValue(
                TargetValue.CreateMaximizeTarget());
            QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithCorrespondingTargetValue(
                TargetValue.CreateEmptyTarget());
            QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithCorrespondingTargetValue(
                TargetValue.CreateSpecifiedTarget(13.0m));
        }

        [Ignore] [Test]
        public void ShouldQueryByFunctionalLocationsAndStatuses()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetAlertStatus> statuses = new List<TargetAlertStatus> {TargetAlertStatus.StandardAlert};

            // Execute:
            List<TargetAlertDTO> retrievedAlerts = 
                targetAlertDTODao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(flocs), statuses, new DateRange(null, null));
            Assert.AreEqual(4, retrievedAlerts.Count);

            const long targetAlertWithAlertStatus = 2;
            Assert.IsTrue(retrievedAlerts.Exists(a => a.IdValue == targetAlertWithAlertStatus));
        }

        private void QueryByFLOCsAndStatusesShouldReturnTargetAlertDTOWithCorrespondingTargetValue(TargetValue targetValue)
        {
            TargetAlert targetAlert = InsertNewTargetAlert(targetValue);

            List<TargetAlertDTO> dtos =
                targetAlertDTODao.QueryByFunctionalLocationsAndStatuses(
                    new RootFlocSet(targetAlert.FunctionalLocation),
                    new List<TargetAlertStatus> { targetAlert.Status },
                    new DateRange(null, null));
            Assert.IsTrue(dtos.Count > 0);

            Assert.That(dtos, Has.Some.Property("Id").EqualTo(targetAlert.Id));
            Assert.That(dtos, Has.Some.Property("TargetValue").EqualTo(targetValue.Title));
        }

        private TargetAlert InsertNewTargetAlert(TargetValue targetValue)
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.TargetValue = targetValue;
            targetAlert = targetAlertDao.Insert(targetAlert);
            return targetAlert;
        }

        private TargetAlert InsertNewTargetAlert(Priority priority)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Unit1();

            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.StandardAlert,
                                                                            priority);
            targetAlert.FunctionalLocation = floc;

            return targetAlertDao.Insert(targetAlert);
        }

        [Ignore] [Test]
        public void ShouldQueryForExcelReport()
        {            
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetAlertStatus> statuses = new List<TargetAlertStatus> { TargetAlertStatus.StandardAlert, TargetAlertStatus.Acknowledged };
            
            List<TargetAlertExcelReportDTO> retrievedAlerts = 
                targetAlertDTODao.QueryForExcelReport(new RootFlocSet(flocs), statuses, new DateRange(null, null));
            
            Assert.AreEqual(7, retrievedAlerts.Count);

            TargetAlertExcelReportDTO dto = retrievedAlerts.Find(a => a.IdValue == 4);
            Assert.IsNotEmpty(dto.Responses);
        }

        [Ignore] [Test]
        public void QueryForExcepReportShouldIncludeAtEvaluationFields()
        {
            List<FunctionalLocation> flocsForQuery = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetAlertStatus> statusesForQuery = new List<TargetAlertStatus> { TargetAlertStatus.StandardAlert, TargetAlertStatus.Acknowledged };


            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();

            targetAlert.FunctionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            targetAlert.TypeOfViolationStatus = TargetAlertStatus.NeverToExceedAlert;
            targetAlert.LastViolatedDateTime = new DateTime(2012, 1, 8, 1, 2, 3);
            targetAlert.MaxAtEvaluation = 35;
            targetAlert.MinAtEvaluation = 36;
            targetAlert.NTEMaxAtEvaluation = 37;
            targetAlert.NTEMinAtEvaluation = 38;
            targetAlert.ActualValueAtEvaluation = 39;

            TargetAlert targetAlertFromInsert = targetAlertDao.Insert(targetAlert);

            List<TargetAlertExcelReportDTO> retrievedAlerts = 
                    targetAlertDTODao.QueryForExcelReport(new RootFlocSet(flocsForQuery), statusesForQuery, new DateRange(null, null));

            Assert.IsTrue(retrievedAlerts.Count > 0);            
        }

        [Ignore] [Test]
        public void QueryForExcelReportShouldUseTheLastViolatedDate()
        {
            Clock.Freeze();

            Clock.Now = new DateTime(2013, 1, 8, 1, 2, 3); // This is so that the fixture creates the alert with a created date of Jan 8th.

            List<FunctionalLocation> flocsForQuery = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetAlertStatus> statusesForQuery = new List<TargetAlertStatus> { TargetAlertStatus.StandardAlert, TargetAlertStatus.Acknowledged };

            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();

            targetAlert.FunctionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            targetAlert.TypeOfViolationStatus = TargetAlertStatus.NeverToExceedAlert;
            targetAlert.LastViolatedDateTime = new DateTime(2013, 2, 8, 1, 2, 3); // Note: February 8th.
            targetAlert.MaxAtEvaluation = 35;
            targetAlert.MinAtEvaluation = 36;
            targetAlert.NTEMaxAtEvaluation = 37;
            targetAlert.NTEMinAtEvaluation = 38;
            targetAlert.ActualValueAtEvaluation = 39;

            Assert.That(Clock.Now, Is.EqualTo(targetAlert.CreatedDateTime).Within(1).Seconds);
            
            TargetAlert targetAlertFromInsert = targetAlertDao.Insert(targetAlert);
            
            // Try January - result not there
            {
                List<TargetAlertExcelReportDTO> retrievedAlerts =
                    targetAlertDTODao.QueryForExcelReport(new RootFlocSet(flocsForQuery), statusesForQuery, new DateRange(new Date(2013, 1, 1), new Date(2013, 1, 31)));

                TargetAlertExcelReportDTO alertFromJanuary = retrievedAlerts.Find(thingy => thingy.IdValue == targetAlertFromInsert.IdValue);
                Assert.IsNull(alertFromJanuary);                
            }

            // Try February. Result shoudld be there
            {
                List<TargetAlertExcelReportDTO> retrievedAlerts =
                    targetAlertDTODao.QueryForExcelReport(new RootFlocSet(flocsForQuery), statusesForQuery, new DateRange(new Date(2013, 2, 1), new Date(2013, 2, 28)));

                TargetAlertExcelReportDTO alertFromJanuary = retrievedAlerts.Find(thingy => thingy.IdValue == targetAlertFromInsert.IdValue);
                Assert.IsNotNull(alertFromJanuary);                
            }

            Clock.UnFreeze();
        }

    }
}