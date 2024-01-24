using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using NUnit.Framework;

namespace Reports.Tests.Adapters
{
    [TestFixture]
    public class OnPremisePersonnelShiftReportAdapterTest
    {
        [Test]
        public void ShouldCreateAdaptersForOnlyThePeriodOfTheReportNotTheEntirePeriodOfTheOnPremisePersonnelsVisit()
        {
            var start = new DateTime(2014, 7, 1, 18, 30, 0);
            var end = new DateTime(2014, 7, 3, 18, 31, 0);
            var reportingPeriod = new Range<DateTime>(start, end);
            var edmontonShiftPatterns = new List<ShiftPattern>
            {
                ShiftPatternFixture.CreateEdmontonDayShift(),
                ShiftPatternFixture.CreateEdmontonNightShift()
            };
            var onPremisePersonnelShiftReportAdapter =
                new OnPremisePersonnelShiftReportAdapter(
                    new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                        edmontonShiftPatterns,
                        new List<OnPremisePersonnelShiftReportDetailDTO>
                        {
                            new OnPremisePersonnelShiftReportDetailDTO(0,
                                "Trade",
                                "Some Name",
                                "Some Location",
                                true,
                                true,
                                start,
                                end.AddDays(10),
                                "403 123 4567",
                                "R21",
                                "Co Name",
                                "This is the description")
                        }));

            var adapters = onPremisePersonnelShiftReportAdapter.OnPremisePersonnelShiftReportDetailsAdapters;

            Assert.AreEqual("Shift: 7/1/2014 - N", adapters[0].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - D", adapters[1].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - N", adapters[2].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - D", adapters[3].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - N", adapters[4].ShiftLabel);
            Assert.IsTrue(adapters.Count == 5);
        }

        [Test]
        public void ShouldCreateAnAdapterForEachShiftThatTheOnPremisePersonWillBeOnSiteDurring()
        {
            var start = new DateTime(2014, 7, 1, 18, 30, 0);
            var end = new DateTime(2014, 7, 3, 18, 31, 0);
            var reportingPeriod = new Range<DateTime>(start, end);
            var edmontonShiftPatterns = new List<ShiftPattern>
            {
                ShiftPatternFixture.CreateEdmontonDayShift(),
                ShiftPatternFixture.CreateEdmontonNightShift()
            };
            var onPremisePersonnelShiftReportAdapter =
                new OnPremisePersonnelShiftReportAdapter(
                    new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                        edmontonShiftPatterns,
                        new List<OnPremisePersonnelShiftReportDetailDTO>
                        {
                            new OnPremisePersonnelShiftReportDetailDTO(0,
                                "Trade",
                                "Some Name",
                                "Some Location",
                                true,
                                true,
                                start,
                                end,
                                "403 123 4567",
                                "R21",
                                "Co Name",
                                "This is the description")
                        }));

            var adapters = onPremisePersonnelShiftReportAdapter.OnPremisePersonnelShiftReportDetailsAdapters;

            Assert.AreEqual("Shift: 7/1/2014 - N", adapters[0].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - D", adapters[1].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - N", adapters[2].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - D", adapters[3].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - N", adapters[4].ShiftLabel);
            Assert.IsTrue(adapters.Count == 5);
        }

        [Test]
        public void ShouldCreateAnAdapterForOnlyEachDayShiftThatTheOnPremisePersonWillBeOnSiteDurringWhenTheyIndicateTheyAreNotOnAtNight()
        {
            var start = new DateTime(2014, 7, 1, 18, 30, 0);
            var end = new DateTime(2014, 7, 3, 18, 31, 0);
            var reportingPeriod = new Range<DateTime>(start, end);
            var edmontonShiftPatterns = new List<ShiftPattern>
            {
                ShiftPatternFixture.CreateEdmontonDayShift(),
                ShiftPatternFixture.CreateEdmontonNightShift()
            };
            var onPremisePersonnelShiftReportAdapter =
                new OnPremisePersonnelShiftReportAdapter(
                    new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                        edmontonShiftPatterns,
                        new List<OnPremisePersonnelShiftReportDetailDTO>
                        {
                            new OnPremisePersonnelShiftReportDetailDTO(0,
                                "Trade",
                                "Some Name",
                                "Some Location",
                                true,
                                false,
                                start,
                                end,
                                "403 123 4567",
                                "R21",
                                "Co Name",
                                "This is the description")
                        }));

            var adapters = onPremisePersonnelShiftReportAdapter.OnPremisePersonnelShiftReportDetailsAdapters;

            Assert.AreEqual("Shift: 7/2/2014 - D", adapters[0].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - D", adapters[1].ShiftLabel);
            Assert.IsTrue(adapters.Count == 2);
        }

        [Test]
        public void ShouldCreateAnAdapterForOnlyEachNightShiftThatTheOnPremisePersonWillBeOnSiteDurringWhenTheyIndicateTheyAreNotOnAtDay()
        {
            var start = new DateTime(2014, 7, 1, 18, 30, 0);
            var end = new DateTime(2014, 7, 3, 18, 31, 0);
            var reportingPeriod = new Range<DateTime>(start, end);
            var edmontonShiftPatterns = new List<ShiftPattern>
            {
                ShiftPatternFixture.CreateEdmontonDayShift(),
                ShiftPatternFixture.CreateEdmontonNightShift()
            };
            var onPremisePersonnelShiftReportAdapter =
                new OnPremisePersonnelShiftReportAdapter(
                    new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                        edmontonShiftPatterns,
                        new List<OnPremisePersonnelShiftReportDetailDTO>
                        {
                            new OnPremisePersonnelShiftReportDetailDTO(0,
                                "Trade",
                                "Some Name",
                                "Some Location",
                                false,
                                true,
                                start,
                                end,
                                "403 123 4567",
                                "R21",
                                "Co Name",
                                "This is the description")
                        }));

            var adapters = onPremisePersonnelShiftReportAdapter.OnPremisePersonnelShiftReportDetailsAdapters;

            Assert.AreEqual("Shift: 7/1/2014 - N", adapters[0].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - N", adapters[1].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - N", adapters[2].ShiftLabel);
            Assert.IsTrue(adapters.Count == 3);
        }

        [Test]
        public void ShouldStillCalculateProperShiftContainersWhenTheShiftStartAndEndTimesAreDifferent()
        {
            var start = new DateTime(2014, 7, 1, 18, 30, 0);
            var end = new DateTime(2014, 7, 3, 18, 31, 0);
            var reportingPeriod = new Range<DateTime>(start, end);
            var edmontonShiftPatterns = new List<ShiftPattern>
            {
                new ShiftPattern(19,
                    "D",
                    new Time(0, 0, 0),
                    new Time(12, 12, 12),
                    DateTimeFixture.DateTimeNow,
                    SiteFixture.Edmonton(),
                    new TimeSpan(0, 0, 30),
                    new TimeSpan(0, 0, 30)),
                new ShiftPattern(20,
                    "N",
                    new Time(12, 12, 12),
                    new Time(0, 0, 0),
                    DateTimeFixture.DateTimeNow,
                    SiteFixture.Edmonton(),
                    new TimeSpan(0, 0, 30),
                    new TimeSpan(0, 0, 30)),
            };
            var onPremisePersonnelShiftReportAdapter =
                new OnPremisePersonnelShiftReportAdapter(
                    new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                        edmontonShiftPatterns,
                        new List<OnPremisePersonnelShiftReportDetailDTO>
                        {
                            new OnPremisePersonnelShiftReportDetailDTO(0,
                                "Trade",
                                "Some Name",
                                "Some Location",
                                true,
                                true,
                                start,
                                end.AddDays(10),
                                "403 123 4567",
                                "R21",
                                "Co Name",
                                "This is the description")
                        }));

            var adapters = onPremisePersonnelShiftReportAdapter.OnPremisePersonnelShiftReportDetailsAdapters;

            Assert.AreEqual("Shift: 7/1/2014 - N", adapters[0].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - D", adapters[1].ShiftLabel);
            Assert.AreEqual("Shift: 7/2/2014 - N", adapters[2].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - D", adapters[3].ShiftLabel);
            Assert.AreEqual("Shift: 7/3/2014 - N", adapters[4].ShiftLabel);
            Assert.IsTrue(
                adapters.TrueForAll(
                    adapter => adapter.ShiftStart.Hour == 0 && adapter.ShiftLabel.EndsWith("D") || adapter.ShiftStart.Hour == 12 && adapter.ShiftLabel.EndsWith("N")));

            Assert.IsTrue(adapters.Count == 5);
        }
    }
}