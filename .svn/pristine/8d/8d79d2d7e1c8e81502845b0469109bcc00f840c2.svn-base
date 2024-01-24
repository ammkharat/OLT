using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;
using Has = NUnit.Framework.Has;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ShiftServiceTest
    {
        private ShiftPatternService shiftPatternService;
        private IShiftPatternDao shiftPatternDaoMock;
        private Mockery mock;

        private const string QUERY_ALL = "QueryAll";

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            shiftPatternDaoMock = mock.NewMock<IShiftPatternDao>();
            DaoRegistry.RegisterDaoFor( shiftPatternDaoMock);

            shiftPatternService = new ShiftPatternService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldGetAllShift()
        {
            Expect.Once.On(shiftPatternDaoMock).Method(QUERY_ALL);
            shiftPatternService.QueryAll();
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #region 18 hour tests

        [Ignore] [Test]
        public void ShouldReturn2ShiftFlocDTOsAt18hour()
        {
            DateTime now = new DateTime(2005, 01, 01, 18, 00, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(2, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12DA_ID, returnedShifts[0].Id);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12e_ID, returnedShifts[1].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        #endregion

        #region One minute before shift grace period start tests

        [Ignore] [Test]
        public void ShouldReturn1ShiftFlocDTOsAtOneMinuteBeforeShiftGracePeriodStart()
        {
            DateTime now = new DateTime(2005, 01, 01, 17, 29, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(1, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12DA_ID, returnedShifts[0].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #endregion

        #region One minute after shift grace period start tests

        [Ignore] [Test]
        public void ShouldReturn2ShiftFlocDTOsAtOneMinuteAfterShiftGracePeriodStart()
        {
            DateTime now = new DateTime(2005, 01, 01, 17, 46, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(2, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12DA_ID, returnedShifts[0].Id);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12e_ID, returnedShifts[1].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #endregion

        #region One second after shift grace period start tests

        [Ignore] [Test]
        public void ShouldReturn2ShiftFlocDTOsAtOneSecondAfterShiftGracePeriodStart()
        {
            DateTime now = new DateTime(2005, 01, 01, 17, 45, 01);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(2, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12DA_ID, returnedShifts[0].Id);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12e_ID, returnedShifts[1].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #endregion

        [Ignore] [Test]
        public void ShouldReturn1ShiftFlocAt16Hours()
        {
            DateTime now = new DateTime(2005, 01, 01, 16, 00, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(1, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12DA_ID, returnedShifts[0].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturn1ShiftFLOCsForeachShiftAt23Hours()
        {
            DateTime now = new DateTime(2005, 01, 01, 23, 00, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.CreateNightShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(1, returnedShifts.Count);
            Assert.AreEqual(ShiftPatternFixture.SARNIA_12e_ID, returnedShifts[0].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturn2ShiftFLOCsForTwoDifferentFlocsHavingDifferentShiftPatternIdsAt9am()
        {
            DateTime now = new DateTime(2005, 01, 01, 9, 00, 00);

            var shiftFlocList = new List<ShiftPattern>(2) { ShiftPatternFixture.CreateDayShift(), ShiftPatternFixture.Create6am_8hour_DayShift() };

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shiftFlocList));

            List<ShiftPattern> returnedShifts =
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(SiteFixture.Sarnia(), new Time(now));

            Assert.AreEqual(2, returnedShifts.Count);
            Assert.AreEqual(1, returnedShifts[0].Id);
            Assert.AreEqual(25, returnedShifts[1].Id);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #region 24 Hours Shift Tests

        [Ignore] [Test] 
        public void IfShiftTimeIsEndTimeOfShift_A_AndStartTimeOfShift_B_ReturnShift_B()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();
            var flocs = new List<FunctionalLocation> {sectionFloc};
            List<ShiftPattern> shifts24HourCoverage =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 ShiftPatternFixture.CreateDayShift(),
                                                                 ShiftPatternFixture.CreateNightShift()
                                                             });
            Assert.IsTrue(shifts24HourCoverage[0].EndTime == shifts24HourCoverage[1].StartTime);
            
            Time timeDuringShift = shifts24HourCoverage[0].EndTime;

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shifts24HourCoverage));
            
            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTime(sectionFloc.Site, DateTimeFixture.DateTimeNow.ToDate().CreateDateTime(timeDuringShift));
            Assert.AreEqual(shifts24HourCoverage[1], foundShift);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test] 
        public void WhenFavouringEarlyShift_IfShiftTimeIsEndTimeOfShift_A_AndStartTimeOfShift_B_ReturnShift_A()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();
           
            List<ShiftPattern> shifts24HourCoverage =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 ShiftPatternFixture.CreateDayShift(),
                                                                 ShiftPatternFixture.CreateNightShift()
                                                             });
            Assert.IsTrue(shifts24HourCoverage[0].EndTime == shifts24HourCoverage[1].StartTime);
            
            Time timeDuringShift = shifts24HourCoverage[0].EndTime;

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shifts24HourCoverage));
            
            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTimeFavourEarlierShift(sectionFloc.Site, DateTimeFixture.DateTimeNow.ToDate().CreateDateTime(timeDuringShift));
            Assert.AreEqual(shifts24HourCoverage[0], foundShift);

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Ignore] [Test]
        public void WhenFavouringEarlyShift_IfShiftTimeIsEndTimeOfShift_B_AndStartTimeOfShift_A_ReturnShift_B()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();

            List<ShiftPattern> shifts24HourCoverage =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 ShiftPatternFixture.CreateDayShift(),
                                                                 ShiftPatternFixture.CreateNightShift()
                                                             });
            Assert.IsTrue(shifts24HourCoverage[0].EndTime == shifts24HourCoverage[1].StartTime);

            Time timeDuringShift = shifts24HourCoverage[1].EndTime;

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(shifts24HourCoverage));

            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTimeFavourEarlierShift(sectionFloc.Site, DateTimeFixture.DateTimeNow.ToDate().CreateDateTime(timeDuringShift));
            Assert.AreEqual(shifts24HourCoverage[1], foundShift);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldPickShiftFromPreviousDayThatStartsEarliestWhenThereAreMultipleShiftsOverlappingTheDay()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();

            ShiftPattern fireBagShiftd = ShiftPatternFixture.CreateShiftPattern(new Time(5), new Time(13));  // 5am - 1pm
            ShiftPattern fireBagShiftN = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(7));  // 7pm - 7am
            ShiftPattern fireBagShiftN1 = ShiftPatternFixture.CreateShiftPattern(new Time(21), new Time(7)); // 9pm - 7am
            ShiftPattern fireBagShiftD = ShiftPatternFixture.CreateShiftPattern(new Time(4), new Time(11));  // 4am - 11am

            List<ShiftPattern> fourShiftsWithTwoOverlapping =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 fireBagShiftd, fireBagShiftN, fireBagShiftN1,
                                                                 fireBagShiftD
                                                             });

            DateTime now = new DateTime(2009, 03, 25, 6, 0, 5);  // 6:05AM

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(fourShiftsWithTwoOverlapping));

            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTime(sectionFloc.Site, now);
            Assert.AreEqual(fireBagShiftN, foundShift);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test] 
        public void ShouldPickShiftFromTodayThatStartsEarliestWhenThereAreMultipleShiftsOverlappingTheDay()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();
            var flocs = new List<FunctionalLocation> {sectionFloc};

            ShiftPattern fireBagShiftA = ShiftPatternFixture.CreateShiftPattern(new Time(13), new Time(21));  // 1pm - 9pm
            ShiftPattern fireBagShiftN = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(7));   // 7pm - 7am
            ShiftPattern fireBagShiftN2 = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(5));  // 7pm - 5am
            ShiftPattern fireBagShiftD = ShiftPatternFixture.CreateShiftPattern(new Time(18), new Time(4));   // 6pm - 4am

            List<ShiftPattern> fourShiftsWithTwoOverlapping =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 fireBagShiftA, fireBagShiftN, fireBagShiftN2,
                                                                 fireBagShiftD
                                                             });


            DateTime now = new DateTime(2009, 03, 25, 20, 0, 5);  //8:05PM

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(fourShiftsWithTwoOverlapping));

            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTime(sectionFloc.Site, now);
            Assert.AreEqual(fireBagShiftA, foundShift);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test] 
        public void ShouldPickOneOfTheEarliestStartingShiftsFromTodayWhenMultipleStartAtTheSameTime()
        {
            FunctionalLocation sectionFloc = FunctionalLocationFixture.GetAny_Section();
            var flocs = new List<FunctionalLocation> {sectionFloc};

            ShiftPattern shiftA = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(7));   // 7pm - 7am
            ShiftPattern shiftB = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(5));  // 7pm - 5am
            ShiftPattern shiftC = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(4));   // 8pm - 4am
            ShiftPattern shiftD = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(23));   // 8pm - 11pm

            List<ShiftPattern> fourShiftsWithTwoOverlapping =
                new List<ShiftPattern>(new[]
                                                             {
                                                                 shiftA, shiftB, shiftC,
                                                                 shiftD
                                                             });

            DateTime now = new DateTime(2009, 03, 25, 20, 0, 5);  //8:05PM

            Expect.Once.On(shiftPatternDaoMock).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue).Will(
                Return.Value(fourShiftsWithTwoOverlapping));

            ShiftPattern foundShift =
                shiftPatternService.GetShiftBySiteAndDateTime(sectionFloc.Site, now);
            Assert.AreEqual(shiftB.StartTime, foundShift.StartTime);
            Assert.AreEqual(shiftA.StartTime, foundShift.StartTime);
            Assert.That(foundShift, Is.EqualTo(shiftA) | Is.EqualTo(shiftB));
            Assert.IsTrue(foundShift == shiftA || foundShift == shiftB);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        #endregion

        [Ignore] [Test]
        public void ShouldGetAllShiftsInRange()
        {
            ShiftPattern shiftA = ShiftPatternFixture.CreateShiftPattern(new Time(8), new Time(10));
            ShiftPattern shiftB = ShiftPatternFixture.CreateShiftPattern(new Time(8), new Time(20));
            ShiftPattern shiftC = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(8));

            List<ShiftPattern> shiftList = new List<ShiftPattern>
                                               {
                                                   shiftA,
                                                   shiftB,
                                                   shiftC
                                               };

            Time time = new Time(9);

            List<ShiftPattern> inRangeShifts = shiftPatternService.GetInRangeShift(shiftList, time, TimeSpan.Zero, TimeSpan.Zero);

            Assert.That(inRangeShifts, Has.Count.EqualTo(2));
            Assert.That(inRangeShifts, Has.Member(shiftA));
            Assert.That(inRangeShifts, Has.Member(shiftB));
            Assert.That(inRangeShifts, Has.No.Member(shiftC));
        }

    }
}