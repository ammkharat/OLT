using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverQuestionnaireDTODaoTest : AbstractDaoTest
    {
        private IShiftHandoverQuestionnaireDTODao dao;
        private IShiftHandoverQuestionnaireDao questionnaireDao;
        private IShiftPatternDao shiftPatternDao;
        private IFunctionalLocationDao functionalLocationDao;
        private IQuestionnaireReadDao questionnaireReadDao;
        private IUserDao userDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireDTODao>();
            questionnaireDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            questionnaireReadDao = DaoRegistry.GetDao<IQuestionnaireReadDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldReturnPopulatedDTO()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            ShiftHandoverQuestionnaire questionnaire1 = Create(SiteFixture.Sarnia(), floc);
            questionnaireDao.Insert(questionnaire1);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> {floc};
            DateRange dateRange = new DateRange(new Date(2005, 01, 01), null);

            List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);

            Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));

            ShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.Id == questionnaire1.Id);
            Assert.AreEqual(questionnaire1.Shift.Id, dto.ShiftId);
            Assert.AreEqual(questionnaire1.CreateUser.Id, dto.CreateUserId);
            Assert.AreEqual(questionnaire1.CreateUser.Id, dto.CreateUserId);
            Assert.AreEqual(questionnaire1.HasYesAnswer, dto.HasYesAnswer);

            foreach (ShiftHandoverQuestionnaireDTO result in results)
            {
                Assert.IsTrue(result.FunctionalLocations.Contains(dto.FunctionalLocations));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryBySecondOrThirdLevelFloc()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc4 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D"));
            FunctionalLocation floc5 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D-E"));
            FunctionalLocation floc6 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("X-Y"));

            ShiftHandoverQuestionnaire questionnaire2 = Create(SiteFixture.Sarnia(), floc2);
            questionnaireDao.Insert(questionnaire2);
            ShiftHandoverQuestionnaire questionnaire3 = Create(SiteFixture.Sarnia(), floc3);
            questionnaireDao.Insert(questionnaire3);
            ShiftHandoverQuestionnaire questionnaire4 = Create(SiteFixture.Sarnia(), floc4);
            questionnaireDao.Insert(questionnaire4);
            ShiftHandoverQuestionnaire questionnaire5 = Create(SiteFixture.Sarnia(), floc5);
            questionnaireDao.Insert(questionnaire5);
            ShiftHandoverQuestionnaire questionnaire6 = Create(SiteFixture.Sarnia(), floc6);
            questionnaireDao.Insert(questionnaire6);

            DateRange dateRange = new DateRange(new Date(2005, 01, 01), null);
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc2 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc3 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc4 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc5 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc6 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc3, floc6 };
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire6.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByAssignment()
        {
            Site site = SiteFixture.Sarnia();
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            WorkAssignment consoleOperatorAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            WorkAssignment unitLeaderAssignment = WorkAssignmentFixture.CreateUnitLeader();

            DateTime now = DateTimeFixture.DateTimeNow;
            Date dateNow = DateTimeFixture.DateNow;
            DateRange range = new DateRange(dateNow, null);
            ShiftHandoverQuestionnaire questionnaire1 = Create(site, functionalLocation, consoleOperatorAssignment, now.AddDays(1));
            questionnaireDao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = Create(site, functionalLocation, unitLeaderAssignment, now.AddDays(1));
            questionnaireDao.Insert(questionnaire2);

            List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocationAndAssignment(new RootFlocSet(functionalLocation), consoleOperatorAssignment.Id, range, null, null);
            Assert.IsTrue(results.Exists(dto => dto.Id == questionnaire1.Id));
            Assert.IsFalse(results.Exists(dto => dto.Id == questionnaire2.Id));
        }

        [Ignore] [Test]
        public void QueryingWithNoAssignmentFindsQuestionnairesThatHaveNoAssignment()
        {
            Site site = SiteFixture.Sarnia();
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            WorkAssignment unitLeaderAssignment = WorkAssignmentFixture.CreateUnitLeader();

            DateTime now = DateTimeFixture.DateTimeNow;
            Date dateNow = DateTimeFixture.DateNow;
            DateRange range = new DateRange(dateNow, null);

            ShiftHandoverQuestionnaire questionnaire1 = Create(site, functionalLocation, null, now.AddDays(1));
            questionnaireDao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = Create(site, functionalLocation, unitLeaderAssignment, now.AddDays(1));
            questionnaireDao.Insert(questionnaire2);

            List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocationAndAssignment(new RootFlocSet(functionalLocation), null, range, null, null);
            Assert.IsTrue(results.Exists(dto => dto.Id == questionnaire1.Id));
            Assert.IsFalse(results.Exists(dto => dto.Id == questionnaire2.Id));
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndQueryByFunctionalLocationsAndAssignment_VaryVisibilityGroups()
        {
            Site site = SiteFixture.Sarnia();

            IWorkAssignmentDao workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
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

            DateTime now = Clock.Now;

            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            ShiftHandoverQuestionnaire questionnaire1 = Create(SiteFixture.Sarnia(), functionalLocation, horseAssignment, now.AddDays(1));
            questionnaireDao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = Create(SiteFixture.Sarnia(), functionalLocation, clothingAssignment, now.AddDays(1));
            questionnaireDao.Insert(questionnaire2);
            ShiftHandoverQuestionnaire questionnaire3 = Create(SiteFixture.Sarnia(), functionalLocation, null, now.AddDays(1));
            questionnaireDao.Insert(questionnaire3);

            DateRange queryDateRange = new DateRange(now.AddDays(-1).ToDate(), now.AddDays(2).ToDate());
            RootFlocSet queryFlocSet = new RootFlocSet(functionalLocation);

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };
                List<ShiftHandoverQuestionnaireDTO> results1 = dao.QueryByFunctionalLocation(queryFlocSet, queryDateRange, null, visibilityGroupIds);

                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire3.Id));

                List<ShiftHandoverQuestionnaireDTO> results2 = dao.QueryByFunctionalLocationAndAssignment(queryFlocSet, clothingAssignment.Id, queryDateRange, null, visibilityGroupIds);

                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == questionnaire2.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };
                List<ShiftHandoverQuestionnaireDTO> results1 = dao.QueryByFunctionalLocation(queryFlocSet, queryDateRange, null, visibilityGroupIds);

                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire3.Id));

                List<ShiftHandoverQuestionnaireDTO> results2 = dao.QueryByFunctionalLocationAndAssignment(queryFlocSet, horseAssignment.Id, queryDateRange, null, visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == questionnaire1.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };
                List<ShiftHandoverQuestionnaireDTO> results1 = dao.QueryByFunctionalLocation(queryFlocSet, queryDateRange, null, visibilityGroupIds);

                Assert.AreEqual(3, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == questionnaire3.Id));

                List<ShiftHandoverQuestionnaireDTO> results2 = dao.QueryByFunctionalLocationAndAssignment(queryFlocSet, clothingAssignment.Id, queryDateRange, null, visibilityGroupIds);
                Assert.AreEqual(1, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == questionnaire2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByMarkedAsRead()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            Site site = SiteFixture.Sarnia();
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("1"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("2-A"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("3-B-C"));

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire1 = Create(site, now, floc1);
            AddAnswers(shiftHandoverQuestionnaire1, "c1");
            questionnaireDao.Insert(shiftHandoverQuestionnaire1);
            long id1 = shiftHandoverQuestionnaire1.IdValue;

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire2 = Create(site, now, floc2, floc1);
            AddAnswers(shiftHandoverQuestionnaire2, "c3", "c4");
            questionnaireDao.Insert(shiftHandoverQuestionnaire2);
            long id2 = shiftHandoverQuestionnaire2.IdValue;

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire3 = Create(site, now, floc3, floc2, floc1);
            AddAnswers(shiftHandoverQuestionnaire3, "c5", "c6");
            questionnaireDao.Insert(shiftHandoverQuestionnaire3);
            long id3 = shiftHandoverQuestionnaire3.IdValue;

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire4 = Create(site, now, floc1);
            AddAnswers(shiftHandoverQuestionnaire4, "c7", "c8");
            questionnaireDao.Insert(shiftHandoverQuestionnaire4);
            long id4 = shiftHandoverQuestionnaire4.IdValue;

            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user2", "first2", "last2"));
            User user3 = userDao.Insert(UserFixture.CreateUser("user3", "first3", "last3"));

            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id1, user1.IdValue, DateTimeFixture.DateTimeNow));
            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id3, user2.IdValue, DateTimeFixture.DateTimeNow));
            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id3, user3.IdValue, DateTimeFixture.DateTimeNow));

            {
                List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> results = dao.QueryByParentFlocListAndMarkedAsRead(
                    site, now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc1), true);
                Assert.AreEqual(2, results.Count);
                {
                    MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.FunctionalLocations == "1");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(1, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last1, first1 [user1]"));
                    Assert.AreEqual(1, dto.Answers.Count);
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c1" && obj.QuestionDisplayOrder == 0 && obj.QuestionText == "Dogs make better pets than cats"));
                }
                {
                    MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.FunctionalLocations == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    Assert.AreEqual(2, dto.Answers.Count);
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c5" && obj.QuestionDisplayOrder == 0 && obj.QuestionText == "Dogs make better pets than cats"));
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c6" && obj.QuestionDisplayOrder == 1 && obj.QuestionText == "Dogs make better pets than cats"));
                }
            }
            {
                List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> results = dao.QueryByParentFlocListAndMarkedAsRead(
                    site, now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc2),true);
                Assert.AreEqual(1, results.Count);
                {
                    MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.FunctionalLocations == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    Assert.AreEqual(2, dto.Answers.Count);
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c5" && obj.QuestionDisplayOrder == 0 && obj.QuestionText == "Dogs make better pets than cats"));
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c6" && obj.QuestionDisplayOrder == 1 && obj.QuestionText == "Dogs make better pets than cats"));
                }
            }
            {
                List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> results = dao.QueryByParentFlocListAndMarkedAsRead(
                    site, now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc3),true);
                Assert.AreEqual(1, results.Count);
                {
                    MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.FunctionalLocations == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    Assert.AreEqual(2, dto.Answers.Count);
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c5" && obj.QuestionDisplayOrder == 0 && obj.QuestionText == "Dogs make better pets than cats"));
                    Assert.IsTrue(dto.Answers.Exists(obj => obj.Comments == "c6" && obj.QuestionDisplayOrder == 1 && obj.QuestionText == "Dogs make better pets than cats"));
                }
            }
        }

        [Ignore] [Test]
        public void QueryingDtosShouldIncludeMarkedAsReadInformation()
        {
            Site site = SiteFixture.Sarnia();
            FunctionalLocation floc = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("3-B-C"));

            ShiftHandoverQuestionnaire q1 = Create(site, floc);
            questionnaireDao.Insert(q1);
            long id1 = q1.IdValue;

            ShiftHandoverQuestionnaire q2 = Create(site, floc);
            questionnaireDao.Insert(q2);
            long id2 = q2.IdValue;

            ShiftHandoverQuestionnaire q3 = Create(site, floc);
            questionnaireDao.Insert(q3);
            long id3 = q3.IdValue;

            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user3", "first3", "last3"));

            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id1, user1.IdValue, DateTimeFixture.DateTimeNow));
            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id2, user2.IdValue, DateTimeFixture.DateTimeNow));
            questionnaireReadDao.Insert(new ItemRead<ShiftHandoverQuestionnaire>(id3, user2.IdValue, DateTimeFixture.DateTimeNow));

            DateRange dateRange = new DateRange(new Date(2005, 01, 01), null);

            {
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(floc), dateRange, user1.Id, null);
                Assert.AreEqual(3, results.Count);
                List<ShiftHandoverQuestionnaireDTO> dtosReadByUser1 = results.FindAll(dto => dto.IsReadByCurrentUser == true);
                Assert.AreEqual(1, dtosReadByUser1.Count);
                Assert.AreEqual(2, results.FindAll(dto => dto.IsReadByCurrentUser == false).Count);
                Assert.AreEqual(id1, dtosReadByUser1[0].IdValue);
            }

            {
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(floc), dateRange, user2.Id, null);
                Assert.AreEqual(3, results.Count);
                List<ShiftHandoverQuestionnaireDTO> dtosReadByUser2 = results.FindAll(dto => dto.IsReadByCurrentUser == true);
                Assert.AreEqual(2, dtosReadByUser2.Count);
                Assert.AreEqual(1, results.FindAll(dto => dto.IsReadByCurrentUser == false).Count);
                Assert.IsTrue(dtosReadByUser2.Exists(dto => dto.IdValue == id2));
                Assert.IsTrue(dtosReadByUser2.Exists(dto => dto.IdValue == id3));
            }

            {
                List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(floc), dateRange, null, null);
                Assert.AreEqual(3, results.Count);
                List<ShiftHandoverQuestionnaireDTO> dtosWithNoReadByInfo = results.FindAll(dto => dto.IsReadByCurrentUser == null);
                Assert.AreEqual(3, dtosWithNoReadByInfo.Count);
            }
        }


        [Ignore] [Test]
        public void ShouldInsertAndRetrieveFunctionalLocationList()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM();
            ShiftHandoverQuestionnaire questionnaire1 = Create(SiteFixture.Sarnia(), Clock.Now, floc1, floc2);
            questionnaireDao.Insert(questionnaire1);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS() };
            DateRange dateRange = new DateRange(new Date(2005, 01, 01), null);

            List<ShiftHandoverQuestionnaireDTO> results = dao.QueryByFunctionalLocation(new RootFlocSet(flocs), dateRange, null, null);

            Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));

            ShiftHandoverQuestionnaireDTO dto = results.Find(obj => obj.Id == questionnaire1.Id);
            Assert.AreEqual("SR1-OFFS-BDOF, SR1-OFFS-TKFM", dto.FunctionalLocations);
        }

        [Ignore] [Test]
        public void QueryOnesWithYesAnswerByDateRangeShouldOnlyReturnOnesInThatDateRangeAndWithTheRightFlocsAndAllThat()
        {
            Site site = SiteFixture.Sarnia();

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            DateTime nowQ1 = new DateTime(2012, 3, 28);
            DateTime nowQ2 = nowQ1;
            DateTime nowQ3 = new DateTime(2012, 2, 25);

            ShiftHandoverQuestionnaire q1 = Create(site, nowQ1, floc);
            AddAnswers(q1, "c1");
            questionnaireDao.Insert(q1);

            ShiftHandoverQuestionnaire q2 = Create(site, nowQ2, floc);
            questionnaireDao.Insert(q2);
            ShiftHandoverQuestionnaire q3 = Create(site, nowQ3, floc);
            AddAnswers(q3, "c5", "c6");
            questionnaireDao.Insert(q3);

            // case: date range covers q1 and q2, but q2 has no yes answers so it won't be returned
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(new RootFlocSet(floc), new DateRange(new Date(2012, 3, 27), new Date(2012, 3, 29)), null);
                Assert.AreEqual(1, dtos.Count);
                Assert.AreEqual(q1.IdValue, dtos[0].IdValue);
            }

            // case: date range covers q3
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(new RootFlocSet(floc), new DateRange(new Date(2012, 2, 25), new Date(2012, 2, 25)), null);
                Assert.AreEqual(1, dtos.Count);
                Assert.AreEqual(q3.IdValue, dtos[0].IdValue);
            }

            // case: date range covers q3 but has the wrong floc
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_PLT1_AFTU_SIC()), new DateRange(new Date(2012, 2, 25), new Date(2012, 2, 25)), null);
                Assert.AreEqual(0, dtos.Count);
            }
        }

        [Ignore] [Test]
        public void QueryOnesWithYesAnswerByShiftShouldOnlyReturnOnesInTheShiftAndWithTheRightFlocsAndAllThat()
        {
            Site site = SiteFixture.Sarnia();

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            DateTime now = new DateTime(2012, 3, 28);

            ShiftHandoverQuestionnaire q1 = Create(site, now, floc);
            AddAnswers(q1, "c1");
            questionnaireDao.Insert(q1);

            ShiftHandoverQuestionnaire q2 = Create(site, now, floc);
            questionnaireDao.Insert(q2);

            ShiftHandoverQuestionnaire q3 = Create(site, now, floc);
            AddAnswers(q3, "c5", "c6");
            questionnaireDao.Insert(q3);

            // case: right shift id, right day
            {
                // q1
                {
                    List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(new RootFlocSet(floc), new UserShift(q1.Shift, now), null);
                    Assert.AreEqual(1, dtos.Count);
                    Assert.AreEqual(q1.IdValue, dtos[0].IdValue);
                }

                // q3
                {
                    List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(new RootFlocSet(floc), new UserShift(q3.Shift, now), null);
                    Assert.AreEqual(1, dtos.Count);
                    Assert.AreEqual(q3.IdValue, dtos[0].IdValue);
                }
            }

            // case: right shift id, wrong day
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(new RootFlocSet(floc), new UserShift(q1.Shift, now.AddDays(1)), null);
                Assert.AreEqual(0, dtos.Count);
            }

            // case: wrong floc
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(new RootFlocSet(FunctionalLocationFixture.GetReal_SR1_PLT1_AFTU_SIC()), new UserShift(q1.Shift, now), null);
                Assert.AreEqual(0, dtos.Count);
            }

            // case: no yes answers
            {
                List<ShiftHandoverQuestionnaireDTO> dtos = dao.QueryOnesWithYesAnswersByFunctionalLocationAndShift(new RootFlocSet(floc), new UserShift(q2.Shift, now), null);
                Assert.AreEqual(0, dtos.Count);
            }
        }

        private static void AddAnswers(ShiftHandoverQuestionnaire questionnaire, params string[] answerCommentTexts)
        {
            questionnaire.Answers.Clear();
            for (int i = 0; i < answerCommentTexts.Length; i++)
            {
                string answerCommentText = answerCommentTexts[i];
                questionnaire.Answers.Add(new ShiftHandoverAnswer(null, true, answerCommentText, "who cares","Yes","pk@hotmail.com",i, 1));//YesNo value is added by ppanigrahi
            }
        }

        private ShiftHandoverQuestionnaire Create(Site site, DateTime createDateTime, params FunctionalLocation[] flocs)
        {
            return Create(site, WorkAssignmentFixture.CreateShiftEngineer(), createDateTime, new List<FunctionalLocation>(flocs));
        }

        private ShiftHandoverQuestionnaire Create(Site site, FunctionalLocation floc)
        {
            return Create(site, floc, WorkAssignmentFixture.CreateShiftEngineer(), new DateTime(2010, 2, 11, 8, 15, 0));
        }

        private ShiftHandoverQuestionnaire Create(Site site, FunctionalLocation floc, WorkAssignment assignment, DateTime createDateTime)
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            return Create(site, assignment, createDateTime, flocs);
        }

        private ShiftHandoverQuestionnaire Create(Site site, WorkAssignment assignment, DateTime createDateTime, List<FunctionalLocation> flocs)
        {
            Time from = new Time(createDateTime).Add(0, -1);
            Time to = new Time(createDateTime).Add(0, 1);
            ShiftPattern shift = ShiftPatternFixture.CreateShiftPattern(from, to, createDateTime, site);

            shift = shiftPatternDao.Insert(shift);

            return new ShiftHandoverQuestionnaire(
                null,
                "no way",
                shift,
                assignment,
                UserFixture.CreateUserWithGivenId(1),
                createDateTime,
                flocs,
                new List<ShiftHandoverAnswer>(), 
                new List<long>(), DateTime.MinValue, DateTime.MinValue, true);
        }

    }
}