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
    [TestFixture]
    [Category("Database")]
    public class WorkPermitEdmontonDTODaoTest : AbstractDaoTest
    {
        private IWorkPermitEdmontonDTODao dtoDao;
        private IWorkPermitEdmontonDao dao;
        private IWorkPermitEdmontonGroupDao groupDao;

        private DateTime NOW;
        private DateTime NOW_PLUS_8_HOURS;
        private Date END_OF_TIME;
        private DateTime ONE_WEEK_AGO;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IWorkPermitEdmontonDTODao>();
            dao = DaoRegistry.GetDao<IWorkPermitEdmontonDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();

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
            WorkPermitEdmonton permit1 = dao.Insert(WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2010, 1, 2), new DateTime(2010, 1, 2), new DateTime(2010, 1, 4)), null);
            WorkPermitEdmonton permit2 = dao.Insert(WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2010, 1, 2), new DateTime(2010, 1, 2), new DateTime(2010, 1, 2)), null);

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
        
        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldQueryUsingRequestedStartDateAndNotIssuedDate()
        {
            WorkPermitEdmonton permit1 = dao.Insert(WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2010, 1, 2), new DateTime(2010, 1, 8), new DateTime(2010, 1, 10)), null);
            WorkPermitEdmonton permit2 = dao.Insert(WorkPermitEdmontonFixture.CreateForInsert(new DateTime(2010, 1, 8), new DateTime(2010, 1, 8), new DateTime(2010, 1, 10)), null);

            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 9), permit1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 9), permit2);

            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 5), permit1);
            AssertQueryByDateRange(false, new Date(2010, 1, 3), new Date(2010, 1, 5), permit2);
        }

        private void AssertQueryByDateRange(bool permitExists, Date from, Date to, WorkPermitEdmonton permit)
        {
            FunctionalLocation functionalLocation = permit.FunctionalLocation;
            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(from, to), new RootFlocSet(functionalLocation));
            Assert.AreEqual(permitExists, results.Exists(obj => obj.Id == permit.Id));
        }
        
        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackPermitsThatFallUnderTheSpecifiedFLOC()
        {
            // Insert a Permit that starts today in Area 1 at level 3
            FunctionalLocation areaOneFloc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton areaOneWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, areaOneFloc);
            dao.Insert(areaOneWorkPermit, null);

            // Insert a Permit that starts today in Area 2 at level 3
            WorkPermitEdmonton areaTwoWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, FunctionalLocationFixture.GetReal("ED1-A002-U005"));
            dao.Insert(areaTwoWorkPermit, null);
            
            // Query for date range that includes today in the Montreal Area 1 Floc
            List<WorkPermitEdmontonDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { areaOneFloc }));

            // Assert that only the Area 1 Permit comes back
            Assert.AreEqual(1, dtos.Count);
            Assert.AreEqual(areaOneFloc.FullHierarchy, dtos[0].FunctionalLocation);
        }
       
        [Ignore] [Test]
        public void QueryByDateRangeAndFlocShouldSupportQueryingByFourthLevelFlocs()
        {
            FunctionalLocation thirdLevelFloc = FunctionalLocationFixture.GetReal("ED1-A002-U005");
            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal("ED1-A002-U005-SCH");
            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal("ED1-A002-U005-SCH-T0001");
            FunctionalLocation anotherFourthLevelFloc = FunctionalLocationFixture.GetReal("ED1-A002-U005-SEG");

            WorkPermitEdmonton thirdLevelPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, thirdLevelFloc);
            dao.Insert(thirdLevelPermit, null);

            WorkPermitEdmonton fourthLevelPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, fourthLevelFloc);
            dao.Insert(fourthLevelPermit, null);

            WorkPermitEdmonton fifthLevelPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, fifthLevelFloc);
            dao.Insert(fifthLevelPermit, null);

            WorkPermitEdmonton anotherFourthLevelPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, anotherFourthLevelFloc);
            dao.Insert(anotherFourthLevelPermit, null);

            // query at the 4th level to get the main 4th level permit and its child
            {
                List<WorkPermitEdmontonDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { fourthLevelFloc }));
                Assert.AreEqual(3, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fourthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
            }

            // query at the 5th level to just get the 5th level
            {
                List<WorkPermitEdmontonDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { fifthLevelFloc }));
                Assert.AreEqual(3, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
            }

            // query at the third level to get everything
            {
                List<WorkPermitEdmontonDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(new List<FunctionalLocation> { thirdLevelFloc }));
                Assert.AreEqual(4, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == thirdLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fourthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == fifthLevelPermit.Id));
                Assert.IsTrue(dtos.Exists(dto => dto.Id == anotherFourthLevelPermit.Id));
            }

        }
        
        [Ignore] [Test]
        public void QueryByFormGN59Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            dao.Insert(permit, null);

            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByFormGN59Id(permit.FormGN59.IdValue);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(permit.Id, results[0].Id);
        }
      
        [Ignore] [Test]
        public void QueryByFormGN7Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            dao.Insert(permit, null);

            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByFormGN7Id(permit.FormGN7.IdValue);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(permit.Id, results[0].Id);
        }
      
        [Ignore] [Test]
        public void QueryByFormGN6Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            dao.Insert(permit, null);

            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByFormGN6Id(permit.FormGN6.IdValue);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(permit.Id, results[0].Id);
        }
      
        [Ignore] [Test]
        public void QueryByFormGN24Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            dao.Insert(permit, null);

            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByFormGN24Id(permit.FormGN24.IdValue);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(permit.Id, results[0].Id);
        }
      
        [Ignore] [Test]
        public void ShouldPullBackRequestedByInformation()
        {
            DateTime startDateTime = new DateTime(2008, 1, 2);
            DateTime endDateTime = new DateTime(2008, 1, 4);
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            WorkPermitEdmonton permitNotRequestedByAnyone = WorkPermitEdmontonFixture.CreateForInsert(startDateTime, startDateTime, endDateTime, floc);
            permitNotRequestedByAnyone.PermitRequestCreatedByUser = null;
            permitNotRequestedByAnyone = dao.Insert(permitNotRequestedByAnyone, null);

            User sapUser = UserFixture.CreateSAPUser();
            WorkPermitEdmonton permitRequestedBySapUser = WorkPermitEdmontonFixture.CreateForInsert(startDateTime, startDateTime, endDateTime, floc);
            permitRequestedBySapUser.PermitRequestCreatedByUser = sapUser;
            permitRequestedBySapUser = dao.Insert(permitRequestedBySapUser, null);

            User regularUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            WorkPermitEdmonton permitRequestedByRegularUser = WorkPermitEdmontonFixture.CreateForInsert(startDateTime, startDateTime, endDateTime, floc);
            permitRequestedByRegularUser.PermitRequestCreatedByUser = regularUser;
            permitRequestedByRegularUser = dao.Insert(permitRequestedByRegularUser, null);

            List<WorkPermitEdmontonDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(startDateTime), new Date(endDateTime)), new RootFlocSet(floc));

            WorkPermitEdmontonDTO dtoNotRequestedByAnyone = results.Find(dto => dto.Id == permitNotRequestedByAnyone.Id);
            Assert.IsNull(dtoNotRequestedByAnyone.PermitRequestCreatedByFullnameWithUserName);

            WorkPermitEdmontonDTO dtoRequestedBySapUser = results.Find(dto => dto.Id == permitRequestedBySapUser.Id);
            Assert.AreEqual("User, SAP [SAPUser]", dtoRequestedBySapUser.PermitRequestCreatedByFullnameWithUserName);

            WorkPermitEdmontonDTO dtoRequestedByRegularUser = results.Find(dto => dto.Id == permitRequestedByRegularUser.Id);
            Assert.AreEqual("Simpson, Homer [oltuser1]", dtoRequestedByRegularUser.PermitRequestCreatedByFullnameWithUserName);
        }
       
        [Ignore] [Test]
        public void PermitsWithNoGroupShouldBeReturned()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A002-U005");

            WorkPermitEdmonton permitWithNoGroup = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            permitWithNoGroup.Group = null;
            dao.Insert(permitWithNoGroup, null);

            {
                List<WorkPermitEdmontonDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME), new RootFlocSet(floc));
                Assert.AreEqual(1, dtos.Count);
                Assert.IsTrue(dtos.Exists(dto => dto.Id == permitWithNoGroup.Id));
            }            
        }
       
        [Ignore] [Test]
        public void ShouldQueryOnlyThosePermitsWithPassedInPriorityIds()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A002-U005");
            Range<Date> range = new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME);
            RootFlocSet flocSet = new RootFlocSet(floc);

            WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit3 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit4 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit5 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);

            permit1.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "A", new List<long> { 5, 6, 7 }, 0, true));
            permit2.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "B", new List<long> { 8 }, 0, true));
            permit3.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "C", new List<long> { 9 }, 0, true));
            permit4.Group = null;
            permit5.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "D", null, 0, true));

            dao.Insert(permit1, null);
            dao.Insert(permit2, null);
            dao.Insert(permit3, null);
            dao.Insert(permit4, null);
            dao.Insert(permit5, null);

            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, new List<long> { 6, 7, 8 }, false);
                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit2.Id));
            }

            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, new List<long> { 9 }, false);
                Assert.AreEqual(1, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit3.Id));
            }

            // if you pass in null for the priority ids list it means "don't do any extra priority/group filtering"
            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, null, false);
                Assert.AreEqual(5, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit4.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit5.Id));
            }
        }
       
        [Ignore] [Test]
        public void ShouldQueryOnlyThosePermitsWithoutThePassedInPriorityIds()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A002-U005");

            Range<Date> range = new Range<Date>(new Date(ONE_WEEK_AGO), END_OF_TIME);
            RootFlocSet flocSet = new RootFlocSet(floc);

            WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit3 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit4 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            WorkPermitEdmonton permit5 = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);

            permit1.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "A", new List<long> { 5, 6, 7 }, 0, true));
            permit2.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "B", new List<long> { 8 }, 0, true));
            permit3.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "C", new List<long> { 9 }, 0, true));
            permit4.Group = null;
            permit5.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "D", null, 0, true));

            dao.Insert(permit1, null);
            dao.Insert(permit2, null);
            dao.Insert(permit3, null);
            dao.Insert(permit4, null);
            dao.Insert(permit5, null);

            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, new List<long> { 5, 6, 7, 8 }, true);
                Assert.AreEqual(3, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit4.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit5.Id));
            }

            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, new List<long> { 9 }, true);
                Assert.AreEqual(4, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit4.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit5.Id));
            }

            // if you pass in null for the group ids list it means "ignore group"
            {
                List<WorkPermitEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocsAndPriorityIds(range, flocSet, null, true);
                Assert.AreEqual(5, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == permit1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit4.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == permit5.Id));
            }

        }

    }
}
