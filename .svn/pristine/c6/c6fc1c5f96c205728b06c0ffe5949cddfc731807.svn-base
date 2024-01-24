using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class DirectiveDTODaoTest : AbstractDaoTest
    {
        private IDirectiveDTODao dtoDao;
        private IDirectiveDao dao;
        private IWorkAssignmentDao workAssignmentDao;
        private IDirectiveReadDao readDao;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IDirectiveDTODao>();
            dao = DaoRegistry.GetDao<IDirectiveDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            readDao = DaoRegistry.GetDao<IDirectiveReadDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRangeAndFloc_VaryDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.ActiveFromDateTime = new DateTime(2013, 5, 20, 10, 30, 0);
            directive1.CreatedByWorkAssignmentName = "Dir1 WA Name";
            directive1.ActiveToDateTime = new Date(2013, 5, 25).CreateDateTime(Time.END_OF_DAY);
            directive1.FunctionalLocations = new List<FunctionalLocation> { floc };
            dao.Insert(directive1);

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.ActiveFromDateTime = new DateTime(2013, 5, 18, 11, 45, 0);
            directive2.ActiveToDateTime = new Date(2013, 5, 21).CreateDateTime(Time.END_OF_DAY);
            directive2.CreatedByWorkAssignmentName = "Dir2 WA Name";
            directive2.FunctionalLocations = new List<FunctionalLocation> { floc };
            dao.Insert(directive2);

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 20), new Date(2013, 5, 25)), new RootFlocSet(floc), null, null);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.CreatedByWorkAssignmentName == directive2.CreatedByWorkAssignmentName));
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 23), new Date(2013, 5, 28)), new RootFlocSet(floc), null, null);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 16), new Date(2013, 5, 19)), new RootFlocSet(floc), null, null);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive2.IdValue));
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 16), new Date(2013, 5, 17)), new RootFlocSet(floc), null, null);
                Assert.AreEqual(0, results.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRangeAndFloc_VaryFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM();

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.FunctionalLocations = new List<FunctionalLocation> { floc2 };
            dao.Insert(directive1);

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.FunctionalLocations = new List<FunctionalLocation> { floc3 };
            dao.Insert(directive2);

            Directive directive3 = DirectiveFixture.CreateForInsert();
            directive3.FunctionalLocations = new List<FunctionalLocation> { floc4, floc5 };
            dao.Insert(directive3);

            Directive directive4 = DirectiveFixture.CreateForInsert();
            directive4.FunctionalLocations = new List<FunctionalLocation> { floc5 };
            dao.Insert(directive4);

            Range<Date> range = new Range<Date>(new Date(1900, 1, 1), new Date(3000, 1, 1));

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(floc1), null, null);
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive3.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive4.IdValue));                
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(floc3, floc5), null, null);
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive3.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive4.IdValue));
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(floc5), null, null);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive3.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive4.IdValue));
            }

            {
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(range, new RootFlocSet(floc3), null, null);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.IdValue == directive3.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRangeAndFloc_VaryVisibilityGroups()
        {
            IVisibilityGroupDao visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();

            VisibilityGroup chapsVisibilityGroup = new VisibilityGroup(-1, "Chaps Department", Site.SARNIA_ID, true);
            VisibilityGroup horseshoeVisibilityGroup = new VisibilityGroup(-1, "Horseshoe Department", Site.SARNIA_ID, false);

            visibilityGroupDao.Insert(chapsVisibilityGroup);
            visibilityGroupDao.Insert(horseshoeVisibilityGroup);

            WorkAssignment horseAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Horse Supervisor"));
            WorkAssignment clothingAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Cowboy Clothing Supervisor"));

            // horse supervisor can read info about chaps and horseshoes, but can only write about horseshoes
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup1 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup2 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup3 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            // cowboy clothing supervisor can read info about chaps and horseshoes, but can only write about chaps
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup4 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup5 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup6 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup1);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup2);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup3);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup4);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup5);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup6);

            Date activeDate = new Date(2011, 3, 3);
            DateTime activeFromDateTime = new DateTime(2011, 3, 3, 11, 15, 0);
            DateTime activeToDateTime = new DateTime(2011, 3, 3, 23, 59, 59);

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.ActiveFromDateTime = activeFromDateTime;
            directive1.ActiveToDateTime = activeToDateTime;
            directive1.WorkAssignments = new List<WorkAssignment> { horseAssignment };
            directive1.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            dao.Insert(directive1);

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.ActiveFromDateTime = activeFromDateTime;
            directive2.ActiveToDateTime = activeToDateTime;
            directive2.WorkAssignments = new List<WorkAssignment> { clothingAssignment };
            directive2.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            dao.Insert(directive2);

            Directive directive3 = DirectiveFixture.CreateForInsert();
            directive3.ActiveFromDateTime = activeFromDateTime;
            directive3.ActiveToDateTime = activeToDateTime;
            directive3.WorkAssignments = new List<WorkAssignment>();
            directive3.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            dao.Insert(directive3);

            Range<Date> queryDateRange = new Range<Date>(activeDate, activeDate);
            RootFlocSet queryFlocSet = new RootFlocSet(FunctionalLocationFixture.GetReal_SR1());

            // case: I can read about chaps so I want to see all directives that were made with an assignment that has a chaps write group
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };

                List<DirectiveDTO> results1 = dtoDao.QueryByDateRangeAndFlocs(queryDateRange, queryFlocSet, visibilityGroupIds, null);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == directive2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == directive3.Id));
            }

            // case: I can read about horseshoes so I want to see all directives that were made with an assignment that has a horseshoe write group
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(queryDateRange, queryFlocSet, visibilityGroupIds, null);

                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == directive1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == directive3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all directives that were made with an assignment that has at least one of those write groups
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(queryDateRange, queryFlocSet, visibilityGroupIds, null);

                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == directive1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == directive2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == directive3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRangeAndFloc_GetMarkedAsReadInfoBack()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            User user1 = UserFixture.CreateUserWithGivenId(1);
            User user2 = UserFixture.CreateUserWithGivenId(2);

            DateTime activeFromDateTime = new DateTime(2013, 2, 2, 8, 15, 0);
            DateTime activeToDateTime = new DateTime(2013, 2, 3, 23, 59, 59);

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.ActiveFromDateTime = activeFromDateTime;
            directive1.ActiveToDateTime = new DateTime(2013, 2, 3);
            directive1.FunctionalLocations = flocs;
            dao.Insert(directive1);

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.ActiveFromDateTime = activeFromDateTime;
            directive2.ActiveToDateTime = activeToDateTime;
            directive2.FunctionalLocations = flocs;
            dao.Insert(directive2);

            readDao.Insert(new ItemRead<Directive>(directive1, user1, Clock.Now));
            readDao.Insert(new ItemRead<Directive>(directive2, user2, Clock.Now));

            Range<Date> dateRange = new Range<Date>(new Date(2013, 2, 2), new Date(2013, 2, 3));
            ExactFlocSet queryFlocSet = new ExactFlocSet(flocs);

            {
                List<DirectiveDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(dateRange, queryFlocSet, null, user1.IdValue);
                List<DirectiveDTO> dtosReadByUser1 = dtos.FindAll(dto => dto.IsReadByCurrentUser.HasValue && dto.IsReadByCurrentUser.Value);
                Assert.AreEqual(1, dtosReadByUser1.Count);
                Assert.AreEqual(directive1.IdValue, dtosReadByUser1[0].IdValue);
            }

            {
                List<DirectiveDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(dateRange, queryFlocSet, null, user2.IdValue);
                List<DirectiveDTO> dtosReadByUser2 = dtos.FindAll(dto => dto.IsReadByCurrentUser.HasValue && dto.IsReadByCurrentUser.Value);
                Assert.AreEqual(1, dtosReadByUser2.Count);
                Assert.AreEqual(directive2.IdValue, dtosReadByUser2[0].IdValue);
            }
        }

        [Ignore] [Test]
        public void ShouldPullOutSameWorkAssignmentStringAsTheStaticMethodDoes()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };
            WorkAssignment assignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.WorkAssignments = new List<WorkAssignment> { assignment };
            directive1.ActiveFromDateTime = new DateTime(2013, 2, 2, 6, 30, 0);
            directive1.ActiveToDateTime = new DateTime(2013, 2, 3);
            directive1.FunctionalLocations = flocs;
            dao.Insert(directive1);

            Range<Date> dateRange = new Range<Date>(new Date(2013, 2, 2), new Date(2013, 2, 3));
            ExactFlocSet queryFlocSet = new ExactFlocSet(flocs);

            List<DirectiveDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(dateRange, queryFlocSet, null, null);
            Assert.AreEqual(1, dtos.Count);
            Assert.AreEqual(DirectiveDTO.WorkAssignmentString(assignment), dtos[0].WorkAssignments);
        }

        [Ignore] [Test]
        public void ADirectiveWithNoAssignmentsShouldBePulledOutWithAnEmptyAssignmentList()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.WorkAssignments = new List<WorkAssignment>();
            directive1.ActiveFromDateTime = new DateTime(2013, 2, 2, 6, 15, 0);
            directive1.ActiveToDateTime = new DateTime(2013, 2, 3);
            directive1.FunctionalLocations = flocs;
            dao.Insert(directive1);

            Range<Date> dateRange = new Range<Date>(new Date(2013, 2, 2), new Date(2013, 2, 3));
            ExactFlocSet queryFlocSet = new ExactFlocSet(flocs);

            List<DirectiveDTO> dtos = dtoDao.QueryByDateRangeAndFlocs(dateRange, queryFlocSet, null, null);
            Assert.AreEqual(1, dtos.Count);
            // the dto should have an empty list of assignments in it and should therefore be relevant to any assignment
            Assert.IsTrue(dtos[0].IsRelevantToAssignment(WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData()));
        }

        [Ignore] [Test]
        public void MarkedAsReadQueryShouldGetDirectivesWithAtLeastOneFlocThatEqualsOrIsAChildOfTheGivenFlocs()
        {
            DateTime now = Clock.Now;

            FunctionalLocation sr1Offs = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation sr1OffsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation sr1Plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation sr1Plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.FunctionalLocations = new List<FunctionalLocation> { sr1OffsBdof, sr1Plt3 };
            directive1.ActiveFromDateTime = now;
            directive1.ActiveToDateTime = now.AddDays(1);
            directive1.PlainTextContent = "c1";
            dao.Insert(directive1);

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.FunctionalLocations = new List<FunctionalLocation> { sr1Offs, sr1Plt3 };
            directive2.ActiveFromDateTime = now;
            directive2.ActiveToDateTime = now.AddDays(1);
            directive2.PlainTextContent = "c2";
            dao.Insert(directive2);

            User user1 = UserFixture.CreateUserWithGivenId(1);
            User user2 = UserFixture.CreateUserWithGivenId(2);

            readDao.Insert(new ItemRead<Directive>(directive1.IdValue, user1.IdValue, now));
            readDao.Insert(new ItemRead<Directive>(directive2.IdValue, user2.IdValue, now));

            {
                List<MarkedAsReadReportDirectiveDTO> results = dtoDao.QueryByParentFlocListAndMarkedAsRead(now.SubtractDays(1), now.AddDays(1), new ExactFlocSet(sr1Offs));
                Assert.AreEqual(2, results.Count);
                Assert.AreEqual(1, results.FindAll(obj => obj.Content.Equals("c1")).Count);
                Assert.AreEqual(1, results.FindAll(obj => obj.Content.Equals("c2")).Count);
            }

            {
                List<MarkedAsReadReportDirectiveDTO> results = dtoDao.QueryByParentFlocListAndMarkedAsRead(now.SubtractDays(1), now.AddDays(1), new ExactFlocSet(sr1Plt3Gen3));
                Assert.AreEqual(0, results.Count);
            }
        }

    }
}
