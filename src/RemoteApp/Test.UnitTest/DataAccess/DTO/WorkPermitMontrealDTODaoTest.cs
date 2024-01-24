using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class WorkPermitMontrealDTODaoTest : AbstractDaoTest
    {
        private IWorkPermitMontrealDTODao dtoDao;
        private IWorkPermitMontrealDao dao;

        private DateTime NOW;
        private DateTime NOW_PLUS_8_HOURS;
        private Date END_OF_TIME;
        private DateTime ONE_WEEK_AGO;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IWorkPermitMontrealDTODao>();
            dao = DaoRegistry.GetDao<IWorkPermitMontrealDao>();

            NOW = DateTimeFixture.DateTimeNow;
            NOW_PLUS_8_HOURS = NOW.AddHours(8);
            END_OF_TIME = new Date(2075, 01, 31);
            ONE_WEEK_AGO = NOW.AddDays(-7);
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackPermitsThatFallWithinDateRangeSpecified()
        {
            WorkPermitMontreal permit1 = dao.Insert(WorkPermitMontrealFixture.CreateForInsert(
                new DateTime(2010, 1, 2), new DateTime(2010, 1, 4)), null);
            WorkPermitMontreal permit2 = dao.Insert(WorkPermitMontrealFixture.CreateForInsert(
                new DateTime(2010, 1, 2), new DateTime(2010, 1, 2)), null);

            AssertQueryByDateRange(true, null, null, permit1);

            AssertQueryByDateRange(false, new Date(2010, 1, 1), new Date(2010, 1, 1), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 2), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 3), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 4), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 5), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 2), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 3), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 4), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 5), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 3), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 4), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 5), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 4), new Date(2010, 1, 4), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 4), new Date(2010, 1, 5), permit1);
            AssertQueryByDateRange(false, new Date(2010, 1, 5), new Date(2010, 1, 5), permit1);

            AssertQueryByDateRange(true, null, null, permit2);

            AssertQueryByDateRange(false, new Date(2010, 1, 1), new Date(2010, 1, 1), permit2);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 2), permit2);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 3), permit2);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 2), permit2);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 3), permit2);
            AssertQueryByDateRange(false, new Date(2010, 1, 3), new Date(2010, 1, 3), permit2);
        }

        private void AssertQueryByDateRange(bool permitExists, Date from, Date to, WorkPermitMontreal permit)
        {
            List<FunctionalLocation> functionalLocations = permit.FunctionalLocations;
            List<WorkPermitMontrealDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(from, to), new RootFlocSet(functionalLocations));
            Assert.AreEqual(permitExists, results.Exists(obj => obj.Id == permit.Id));
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackPermitsThatFallUnderTheSpecifiedFLOC()
        {
            // Insert a Permit that starts today in Montreal Area 1 at level 3
            FunctionalLocation areaOneFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            WorkPermitMontreal areaOneWorkPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, areaOneFloc);
            dao.Insert(areaOneWorkPermit, null);
            
            // Insert a Permit that starts today in Montreal Area 2 at level 3
            WorkPermitMontreal areaTwoWorkPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, FunctionalLocationFixture.GetReal_MT1_A001_IFST_SAB_K00162());
            dao.Insert(areaTwoWorkPermit, null);
            
            // Query for date range that includes today in the Montreal Area 1 Floc
            List<WorkPermitMontrealDTO> workPermitMontrealDtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { areaOneFloc }));

            // Assert that only the Montreal Area 1 Permit comes back
//            Assert.AreEqual(1, workPermitMontrealDtos.Count);
            foreach (WorkPermitMontrealDTO dto in workPermitMontrealDtos)
            {
                Assert.That(dto.FunctionalLocationFullHierarchies.Contains(areaOneFloc.FullHierarchy));
            }
//            Assert.AreEqual(areaOneFloc.FullHierarchy, workPermitMontrealDtos[0].FunctionalLocationFullHierarchies);
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFlocShouldSupportQueryingByFourthLevelFlocs()
        {
            FunctionalLocation thirdLevelFloc = FunctionalLocationFixture.GetReal("MT1-A001-U010");
            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal("MT1-A001-U010-SLE");
            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal("MT1-A001-U010-SLE-R01112");
            FunctionalLocation anotherFourthLevelFloc = FunctionalLocationFixture.GetReal("MT1-A001-U010-SSA");

            WorkPermitMontreal thirdLevelPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, thirdLevelFloc);
            dao.Insert(thirdLevelPermit, null);

            WorkPermitMontreal fourthLevelPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, fourthLevelFloc);
            dao.Insert(fourthLevelPermit, null);

            WorkPermitMontreal fifthLevelPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, fifthLevelFloc);
            dao.Insert(fifthLevelPermit, null);

            WorkPermitMontreal anotherFourthLevelPermit = WorkPermitMontrealFixture.CreateForInsert(NOW, NOW_PLUS_8_HOURS, anotherFourthLevelFloc);
            dao.Insert(anotherFourthLevelPermit, null);

            // query at the 4th level to get the main 4th level permit and its child
            {
                List<WorkPermitMontrealDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { fourthLevelFloc }));
                Assert.AreEqual(2, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fourthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
            }

            // query at the 5th level to just get the 5th level
            {
                List<WorkPermitMontrealDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { fifthLevelFloc }));
                Assert.AreEqual(1, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
            }

            // query at the third level to get everything
            {
                List<WorkPermitMontrealDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { thirdLevelFloc }));
//                Assert.AreEqual(4, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == thirdLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fourthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == anotherFourthLevelPermit.Id));
            }
            
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeleted()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit = dao.Insert(workPermit, null);

            List<FunctionalLocation> functionalLocations = workPermit.FunctionalLocations;
            Range<Date> range = new Range<Date>(new Date(workPermit.StartDateTime.AddDays(-1)), new Date(workPermit.EndDateTime.AddDays(1)));

            {
                List<WorkPermitMontrealDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(functionalLocations));
                Assert.IsTrue(results.Exists(obj => obj.Id == workPermit.Id));
            }

            dao.Remove(workPermit);

            {
                List<WorkPermitMontrealDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(functionalLocations));
                Assert.IsFalse(results.Exists(obj => obj.Id == workPermit.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldOnlyReturnOneDtoPerPermitEvenIfThePermitHasMultipleFlocs()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.FunctionalLocations.Clear();
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A002_U430());
            workPermit = dao.Insert(workPermit, null);

            Range<Date> range = new Range<Date>(new Date(workPermit.StartDateTime.AddDays(-1)), new Date(workPermit.EndDateTime.AddDays(1)));

            List<WorkPermitMontrealDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(FunctionalLocationFixture.GetReal_MT1_A001_U010()));
            Assert.AreEqual(1, results.FindAll(result => result.Id == workPermit.Id).Count);
            WorkPermitMontrealDTO queriedPermit = results.Find(result => result.Id == workPermit.Id);
            Assert.AreEqual("MT1-A001-U010, MT1-A002-U430", queriedPermit.FunctionalLocationFullHierarchies);
        }
    }
}
