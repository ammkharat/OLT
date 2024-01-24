using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class DeviationAlertServiceClientTest
    {
        private IDeviationAlertService deviationAlertService;
        private IFunctionalLocationService flocService;

        [SetUp]
        public void SetUp()
        {
            deviationAlertService = GenericServiceRegistry.Instance.GetService<IDeviationAlertService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldCreateMultipleAlerts()
        {
            var measurementTagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            int? productionTargetValue = 100;
            TagInfo productionTargetTagInfo = null;
            var newAlerts = AssertEvaluateDefinition(3, 3, measurementTagInfo, productionTargetTagInfo,
                productionTargetValue);
            Assert.AreEqual(3, newAlerts.Count);

            Assert.AreEqual(new DateTime(2010, 4, 1, 3, 00, 0), newAlerts[0].StartDateTime);
            Assert.AreEqual(new DateTime(2010, 4, 1, 4, 00, 0), newAlerts[0].EndDateTime);
            Assert.AreEqual(new DateTime(2010, 4, 1, 4, 00, 0), newAlerts[1].StartDateTime);
            Assert.AreEqual(new DateTime(2010, 4, 1, 5, 00, 0), newAlerts[1].EndDateTime);
            Assert.AreEqual(new DateTime(2010, 4, 1, 5, 00, 0), newAlerts[2].StartDateTime);
            Assert.AreEqual(new DateTime(2010, 4, 1, 6, 00, 0), newAlerts[2].EndDateTime);
        }

        [Test][Ignore]
        public void ShouldEvaluateDefinitionAndCreateAlertWithProductionTargetTag()
        {
            var measurementTagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            int? productionTargetValue = null;
            var productionTargetTagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            AssertEvaluateDefinition(1, 1, measurementTagInfo, productionTargetTagInfo, productionTargetValue);
        }

        [Test][Ignore]
        public void ShouldEvaluateDefinitionAndCreateAlertWithProductionTargetValue()
        {
            var measurementTagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            int? productionTargetValue = 100;
            TagInfo productionTargetTagInfo = null;
            var newAlerts = AssertEvaluateDefinition(1, 1, measurementTagInfo, productionTargetTagInfo,
                productionTargetValue);
            Assert.AreEqual(100, newAlerts[0].ProductionTargetValue);
        }

        [Test][Ignore]
        public void ShouldNotCreateAlertIfDefinitionIsInactive()
        {
            var now = DateTimeFixture.DateTimeNow;

            var floc = flocService.QueryByFullHierarchy("SR1-PLT3-BDP3", Site.SARNIA_ID);
            floc.Site = SiteFixture.Sarnia();

            var definition = RestrictionDefinitionFixture.CreateDefinition();
            definition.FunctionalLocation = floc;
            definition.LastInvokedDateTime = null;
            definition.IsActive = false;


            var to = now.AddDays(1);
            var from = now;
            var range = new Range<Date>(new Date(from), new Date(to));

            IList<DeviationAlertDTO> alertsBeforeEvaluate = deviationAlertService
                .QueryDTOsByFLOCAndDaysPrecedingGivenDate(
                    new RootFlocSet(floc), range);

            var lastSuccessfulAlertDateTime = deviationAlertService.EvaluateDefinition(definition, now);

            IList<DeviationAlertDTO> alertsAfterEvaluate = deviationAlertService
                .QueryDTOsByFLOCAndDaysPrecedingGivenDate(
                    new RootFlocSet(floc), range);
            Assert.AreEqual(alertsBeforeEvaluate.Count, alertsAfterEvaluate.Count);
            Assert.AreEqual(now, lastSuccessfulAlertDateTime);
        }

        [Test][Ignore]
        public void ShouldNotCreateAlertIfMeasurementValueTagCannotBeRead()
        {
            var measurementTagInfo = TagInfoFixture.CreateMockTagForSarnia(-1234, "does not exist");
            int? productionTargetValue = 100;
            TagInfo productionTargetTagInfo = null;
            AssertEvaluateDefinition(0, 1, measurementTagInfo, productionTargetTagInfo, productionTargetValue);
        }

        [Test][Ignore]
        public void ShouldNotCreateAlertIfProductionValueTagCannotBeRead()
        {
            var measurementTagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            int? productionTargetValue = null;
            var productionTargetTagInfo = TagInfoFixture.CreateMockTagForSarnia(-1234, "does not exist");
            AssertEvaluateDefinition(0, 1, measurementTagInfo, productionTargetTagInfo, productionTargetValue);
        }

        [Test][Ignore]
        public void ShouldQueryByFlocAndDaysPrecedingGivenDate()
        {
            var floc1 = deviationAlertService.QueryById(1).FunctionalLocation;
            var floc2 = deviationAlertService.QueryById(2).FunctionalLocation;
            var floc3 = deviationAlertService.QueryById(3).FunctionalLocation;

            var flocs = new List<FunctionalLocation> {floc1, floc2, floc3};

            //1. 1/15/2010 10:15:32 AM
            //2. 3/15/2010 10:15:32 AM
            //3. 5/15/2010 10:15:32 AM

            var baseDateTime = new DateTime(2010, 1, 15);
            var fromDate = baseDateTime.SubtractDays(3);
            var toDate = baseDateTime;
            var range = new Range<Date>(new Date(fromDate), new Date(toDate));

            var set1 =
                deviationAlertService.QueryDTOsByFLOCAndDaysPrecedingGivenDate(new RootFlocSet(flocs), range);

            Assert.IsTrue(set1.Exists(dto => dto.Id == 1));
            Assert.IsFalse(set1.Exists(dto => dto.Id == 2 || dto.Id == 3));

            baseDateTime = new DateTime(2010, 3, 16);
            fromDate = baseDateTime.SubtractDays(3);
            toDate = baseDateTime;
            range = new Range<Date>(new Date(fromDate), new Date(toDate));

            var set2 =
                deviationAlertService.QueryDTOsByFLOCAndDaysPrecedingGivenDate(new RootFlocSet(flocs), range);

            Assert.IsTrue(set2.Exists(dto => dto.Id == 2));
            Assert.IsFalse(set2.Exists(dto => dto.Id == 3));
            Assert.IsFalse(set2.Exists(dto => dto.Id == 1));
        }

        [Test][Ignore]
        public void ShouldQueryById()
        {
            var deviationAlert = deviationAlertService.QueryById(1);
            Assert.IsNotNull(deviationAlert);
        }

        private List<DeviationAlertDTO> AssertEvaluateDefinition(
            int expectedNewAlertCount, int numberOfHoursBack,
            TagInfo measurementTagInfo, TagInfo productionTargetTagInfo, int? productionTargetValue)
        {
            var now = new DateTime(2010, 4, 1, 6, 30, 0);

            var floc = flocService.QueryByFullHierarchy("SR1-PLT3-BDP3", Site.SARNIA_ID);
            floc.Site = SiteFixture.Sarnia();

            var definition = RestrictionDefinitionFixture.CreateDefinition();
            definition.FunctionalLocation = floc;
            definition.MeasurementTagInfo = measurementTagInfo;
            definition.ProductionTargetTagInfo = productionTargetTagInfo;
            definition.ProductionTargetValue = productionTargetValue;
            definition.LastInvokedDateTime = now.TruncateToHour().AddHours(-numberOfHoursBack);
            definition.IsActive = true;

            var queryTime = now; //DateTimeFixture.DateTimeNow;

            var to = queryTime.AddDays(1);
            var from = queryTime;
            var range = new Range<Date>(new Date(from), new Date(to));


            IList<DeviationAlertDTO> alertsBeforeEvaluate = deviationAlertService
                .QueryDTOsByFLOCAndDaysPrecedingGivenDate(
                    new RootFlocSet(floc), range);

            var lastSuccessfulAlertDateTime = deviationAlertService.EvaluateDefinition(definition, now);

            IList<DeviationAlertDTO> alertsAfterEvaluate = deviationAlertService
                .QueryDTOsByFLOCAndDaysPrecedingGivenDate(
                    new RootFlocSet(floc), range);
            if (expectedNewAlertCount > 0)
            {
                Assert.AreEqual(alertsBeforeEvaluate.Count + expectedNewAlertCount, alertsAfterEvaluate.Count);

                var newAlerts = alertsAfterEvaluate.FindAll(after => !alertsBeforeEvaluate.ExistsById(after));
                Assert.AreEqual(expectedNewAlertCount, newAlerts.Count);
                foreach (var newAlert in newAlerts)
                {
                    Assert.IsNotNull(newAlert.ProductionTargetValue);
                }

                Assert.AreEqual(now.TruncateToHour(), lastSuccessfulAlertDateTime);

                return newAlerts;
            }
            Assert.AreEqual(alertsBeforeEvaluate.Count, alertsAfterEvaluate.Count);
            Assert.IsNull(lastSuccessfulAlertDateTime);
            return null;
        }
    }
}