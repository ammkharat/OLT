using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverQuestionnaireDaoTest : AbstractDaoTest
    {
        private IShiftHandoverQuestionnaireDao dao;
        private IFunctionalLocationDao functionalLocationDao;
        private IWorkAssignmentDao workAssignmentDao;
        private ICokerCardConfigurationDao cokerCardConfigurationDao;
        private IShiftHandoverQuestionnaireDTODao dtoDao;
        private ILogDao logDao;
        private ISummaryLogDao summaryLogDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            cokerCardConfigurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();
            dtoDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireDTODao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            ShiftHandoverQuestionnaire questionnaire = dao.QueryById(1);

            Assert.IsNotNull(questionnaire);
            Assert.AreEqual(1, questionnaire.Shift.Id);
            Assert.AreEqual(2, questionnaire.Assignment.Id);
            Assert.AreEqual(1, questionnaire.CreateUser.Id);            
            Assert.AreEqual(21, questionnaire.CreateDateTime.Day);
            Assert.AreEqual(25, questionnaire.LastModifiedDate.Day);

            Assert.IsTrue(questionnaire.Answers.Count == 2);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            Log log = LogFixture.CreateLog(false);
            logDao.Insert(log);

            SummaryLog summaryLog = SummaryLogFixture.CreateSummaryLog();
            summaryLogDao.Insert(summaryLog);

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();

            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1_3003_0000());
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());

            questionnaire.LastModifiedDate = new DateTime(2010, 3, 15, 5,23, 0);
            questionnaire.LogId = log.IdValue;
            questionnaire.SummaryLogId = summaryLog.IdValue;

            dao.Insert(questionnaire);
            ShiftHandoverQuestionnaire retrievedQuestionnaire = dao.QueryById(questionnaire.IdValue);

            Assert.AreEqual(questionnaire.ShiftHandoverConfigurationName, retrievedQuestionnaire.ShiftHandoverConfigurationName);
            Assert.AreEqual(questionnaire.Shift.Id, retrievedQuestionnaire.Shift.Id);
            Assert.AreEqual(questionnaire.Assignment.Id, retrievedQuestionnaire.Assignment.Id);
            Assert.AreEqual(questionnaire.CreateUser.Id, retrievedQuestionnaire.CreateUser.Id);
            Assert.AreEqual(questionnaire.CreateDateTime.Day, retrievedQuestionnaire.CreateDateTime.Day);
            Assert.AreEqual(questionnaire.LastModifiedDate.Day, retrievedQuestionnaire.LastModifiedDate.Day);
            Assert.AreEqual(questionnaire.LogId.Value, retrievedQuestionnaire.LogId);
            Assert.AreEqual(questionnaire.SummaryLogId.Value, retrievedQuestionnaire.SummaryLogId);

            Assert.AreEqual(2, retrievedQuestionnaire.FunctionalLocations.Count);
            Assert.IsTrue(retrievedQuestionnaire.FunctionalLocations.ExistsById(FunctionalLocationFixture.GetReal_DN1_3003_0000()));
            Assert.IsTrue(retrievedQuestionnaire.FunctionalLocations.ExistsById(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()));

            Assert.IsTrue(retrievedQuestionnaire.Answers.Count == 2);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            Log log1 = LogFixture.CreateLog(false);
            Log log2 = LogFixture.CreateLog(false);
            logDao.Insert(log1);
            logDao.Insert(log2);

            SummaryLog summaryLog1 = SummaryLogFixture.CreateSummaryLog();
            SummaryLog summaryLog2 = SummaryLogFixture.CreateSummaryLog();
            summaryLogDao.Insert(summaryLog1);
            summaryLogDao.Insert(summaryLog2);

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1_3003_0000());
            questionnaire.Answers[0].Answer = true;
            questionnaire.Answers[0].Comments = "a1";
            questionnaire.Answers[1].Answer = false;
            questionnaire.Answers[1].Comments = "a2";
            questionnaire.LogId = log1.Id;
            questionnaire.SummaryLogId = summaryLog1.Id;
            dao.Insert(questionnaire);

            {
                ShiftHandoverQuestionnaire retrievedQuestionnaire = dao.QueryById(questionnaire.IdValue);                
                Assert.AreEqual(1, retrievedQuestionnaire.FunctionalLocations.Count);
                Assert.IsTrue(retrievedQuestionnaire.FunctionalLocations.ExistsById(FunctionalLocationFixture.GetReal_DN1_3003_0000()));
                Assert.IsTrue(retrievedQuestionnaire.Answers.Exists(obj => obj.Answer && obj.Comments == "a1"));
                Assert.IsTrue(retrievedQuestionnaire.Answers.Exists(obj => obj.Answer == false && obj.Comments == "a2"));
            }

            questionnaire.Answers[0].Answer = false;
            questionnaire.Answers[0].Comments = "a1 update";
            questionnaire.Answers[1].Answer = true;
            questionnaire.Answers[1].Comments = "a2 update";
            questionnaire.LogId = log2.Id;
            questionnaire.SummaryLogId = summaryLog2.Id;
            dao.Update(questionnaire);

            {
                ShiftHandoverQuestionnaire retrievedQuestionnaire = dao.QueryById(questionnaire.IdValue);               
                Assert.IsTrue(retrievedQuestionnaire.Answers.Exists(obj => obj.Answer == false && obj.Comments == "a1 update"));
                Assert.IsTrue(retrievedQuestionnaire.Answers.Exists(obj => obj.Answer && obj.Comments == "a2 update"));
                Assert.AreEqual(log2.Id, retrievedQuestionnaire.LogId);
                Assert.AreEqual(summaryLog2.Id, retrievedQuestionnaire.SummaryLogId);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_DN1_3003_0000());
            questionnaire.RelevantCokerCardConfigurations.Clear();
            questionnaire.RelevantCokerCardConfigurations.Add(
                cokerCardConfigurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue)[0].IdValue);

            dao.Insert(questionnaire);
            long id = questionnaire.IdValue;

            Assert.IsNotNull(dao.QueryById(id));
            
            dao.Delete(questionnaire);

            Assert.IsNull(dao.QueryById(id));
        }

        [Ignore] [Test]
        public void ShouldQueryQuestionnairesByFunctionalLocation()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc4 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D"));
            FunctionalLocation floc5 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D-E"));
            FunctionalLocation floc6 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("X-Y"));

            WorkAssignment workAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();


            ShiftHandoverQuestionnaire questionnaire2 = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc2}, workAssignment);
            dao.Insert(questionnaire2);
            ShiftHandoverQuestionnaire questionnaire3 = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc3}, workAssignment);
            dao.Insert(questionnaire3);
            ShiftHandoverQuestionnaire questionnaire4 = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc4}, workAssignment);
            dao.Insert(questionnaire4);
            ShiftHandoverQuestionnaire questionnaire5 = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc5}, workAssignment);
            dao.Insert(questionnaire5);
            ShiftHandoverQuestionnaire questionnaire6 = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc6}, workAssignment);
            dao.Insert(questionnaire6);

            DateTime tomorrow = DateTimeFixture.DateTimeNow.AddDays(1);
            List<WorkAssignment> queryWorkAssignments = new List<WorkAssignment>{workAssignment};

            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1, floc2, floc3 };
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow, queryWorkAssignments, false);
                Assert.IsTrue(results.ExistsById(questionnaire2));
                Assert.IsTrue(results.ExistsById(questionnaire3));
                Assert.IsTrue(results.ExistsById(questionnaire4));
                Assert.IsTrue(results.ExistsById(questionnaire5));
                Assert.IsFalse(results.ExistsById(questionnaire6));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc2, floc3 };
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow, queryWorkAssignments, false);
                Assert.IsTrue(results.ExistsById(questionnaire2));
                Assert.IsTrue(results.ExistsById(questionnaire3));
                Assert.IsTrue(results.ExistsById(questionnaire4));
                Assert.IsTrue(results.ExistsById(questionnaire5));
                Assert.IsFalse(results.ExistsById(questionnaire6));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc3 };
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow, queryWorkAssignments, false);
                Assert.IsFalse(results.ExistsById(questionnaire2));
                Assert.IsTrue(results.ExistsById(questionnaire3));
                Assert.IsTrue(results.ExistsById(questionnaire4));
                Assert.IsTrue(results.ExistsById(questionnaire5));
                Assert.IsFalse(results.ExistsById(questionnaire6));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc6 };
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow, queryWorkAssignments, false);
                Assert.IsFalse(results.ExistsById(questionnaire2));
                Assert.IsFalse(results.ExistsById(questionnaire3));
                Assert.IsFalse(results.ExistsById(questionnaire4));
                Assert.IsFalse(results.ExistsById(questionnaire5));
                Assert.IsTrue(results.ExistsById(questionnaire6));
            }
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc3, floc6 };
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow, queryWorkAssignments, false);
                Assert.IsFalse(results.ExistsById(questionnaire2));
                Assert.IsTrue(results.ExistsById(questionnaire3));
                Assert.IsTrue(results.ExistsById(questionnaire4));
                Assert.IsTrue(results.ExistsById(questionnaire5));
                Assert.IsTrue(results.ExistsById(questionnaire6));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryQuestionnairesByWorkAssignment()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));

            WorkAssignment workAssignmentA = InsertWorkAssignment(floc3.Site, RoleFixture.GetRealRoleA(floc3.Site.IdValue));
            WorkAssignment workAssignmentB = InsertWorkAssignment(floc3.Site, RoleFixture.GetRealRoleB(floc3.Site.IdValue));

            ShiftHandoverQuestionnaire questionnaireA = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc3}, workAssignmentA);
            dao.Insert(questionnaireA);
            ShiftHandoverQuestionnaire questionnaireB = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc3}, workAssignmentB);
            dao.Insert(questionnaireB);
            ShiftHandoverQuestionnaire questionnaireC = ShiftHandoverQuestionnaireFixture.Create(new List<FunctionalLocation> {floc3}, null);
            dao.Insert(questionnaireC);

            DateTime tomorrow = DateTimeFixture.DateTimeNow.AddDays(1);
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1, floc2, floc3 };

            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                    new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow,
                    new List<WorkAssignment> { workAssignmentA, workAssignmentB }, true);
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                    new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow,
                    new List<WorkAssignment> { workAssignmentA, workAssignmentB }, false);
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
                Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                    new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow,
                    new List<WorkAssignment> { workAssignmentA }, true);
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
                Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(
                    new RootFlocSet(flocs), new DateTime(2005, 01, 01), tomorrow,
                    new List<WorkAssignment> { workAssignmentB }, false);
                Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
                Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
                Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryQuestionnairesByCreationDateRange()
        {
            FunctionalLocation floc = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));

            WorkAssignment workAssignment = InsertWorkAssignment(floc.Site, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            User user = UserFixture.CreateUserWithGivenId(1);
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };

            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 2));
            ShiftPattern shiftPattern = userShift.ShiftPattern;

            ShiftHandoverQuestionnaire questionnaireA = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaireA);
            ShiftHandoverQuestionnaire questionnaireB = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, shiftPattern, new DateTime(2010, 12, 2, 17, 0, 0), flocs);
            dao.Insert(questionnaireB);
            ShiftHandoverQuestionnaire questionnaireC = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, shiftPattern, new DateTime(2010, 12, 2, 19, 0, 0), flocs);
            dao.Insert(questionnaireC);

            List<WorkAssignment> queryWorkAssignments = new List<WorkAssignment> { workAssignment };

            List<ShiftHandoverQuestionnaire> results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2010, 12, 2, 8, 0, 0), new DateTime(2010, 12, 2, 17, 10, 0), queryWorkAssignments, false);
            Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
            Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
            Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));

            results = dao.QueryByFunctionalLocationAndDateRangeAndAssignment(new RootFlocSet(flocs), new DateTime(2010, 12, 2, 18, 0, 0), new DateTime(2010, 12, 4, 0, 0, 0), queryWorkAssignments, false);
            Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireA.IdValue));
            Assert.IsFalse(results.Exists(questionnaire => questionnaire.IdValue == questionnaireB.IdValue));
            Assert.IsTrue(results.Exists(questionnaire => questionnaire.IdValue == questionnaireC.IdValue));
        }

        [Ignore] [Test]
        public void ShouldQueryByUserWorkAssignmentAndShift_VaryUser()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI() };

            User user1 = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            User user2 = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            WorkAssignment workAssignment = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 2));
            ShiftPattern shiftPattern = userShift.ShiftPattern;

            ShiftHandoverQuestionnaire questionnaire1 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user1, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user2, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire2);

            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user1.IdValue, workAssignment.IdValue, userShift);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user2.IdValue, workAssignment.IdValue, userShift);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByUserWorkAssignmentAndShift_VaryWorkAssignment()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI() };

            WorkAssignment workAssignment1 = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));
            WorkAssignment workAssignment2 = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));

            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 2));
            ShiftPattern shiftPattern = userShift.ShiftPattern;

            ShiftHandoverQuestionnaire questionnaire1 = ShiftHandoverQuestionnaireFixture.Create(
                workAssignment1, user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = ShiftHandoverQuestionnaireFixture.Create(
                workAssignment2, user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire2);

            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user.IdValue, workAssignment1.IdValue, userShift);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user.IdValue, workAssignment2.IdValue, userShift);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByUserWorkAssignmentAndShift_VaryShift()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI() };

            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            WorkAssignment workAssignment = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));

            UserShift userShift1 = UserShiftFixture.CreateUserShift(
                ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 12, 2));
            UserShift userShift2 = UserShiftFixture.CreateUserShift(
                ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 12, 2));
            UserShift userShift3 = UserShiftFixture.CreateUserShift(
                ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 12, 3));

            ShiftHandoverQuestionnaire questionnaire1 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift1.ShiftPattern, userShift1.StartDateTimeWithPadding, flocs);
            dao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift1.ShiftPattern, userShift1.StartDateTime, flocs);
            dao.Insert(questionnaire2);
            ShiftHandoverQuestionnaire questionnaire3 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift1.ShiftPattern, userShift1.EndDateTime, flocs);
            dao.Insert(questionnaire3);
            ShiftHandoverQuestionnaire questionnaire4 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift1.ShiftPattern, userShift1.EndDateTimeWithPadding, flocs);
            dao.Insert(questionnaire4);
            ShiftHandoverQuestionnaire questionnaire5 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift2.ShiftPattern, userShift2.StartDateTimeWithPadding, flocs);
            dao.Insert(questionnaire5);
            ShiftHandoverQuestionnaire questionnaire6 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift2.ShiftPattern, userShift2.StartDateTime, flocs);
            dao.Insert(questionnaire6);
            ShiftHandoverQuestionnaire questionnaire7 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift2.ShiftPattern, userShift2.EndDateTime, flocs);
            dao.Insert(questionnaire7);
            ShiftHandoverQuestionnaire questionnaire8 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift2.ShiftPattern, userShift2.EndDateTimeWithPadding, flocs);
            dao.Insert(questionnaire8);
            ShiftHandoverQuestionnaire questionnaire9 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift3.ShiftPattern, userShift3.StartDateTimeWithPadding, flocs);
            dao.Insert(questionnaire9);
            ShiftHandoverQuestionnaire questionnaire10 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift3.ShiftPattern, userShift3.StartDateTime, flocs);
            dao.Insert(questionnaire10);
            ShiftHandoverQuestionnaire questionnaire11 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift3.ShiftPattern, userShift3.EndDateTime, flocs);
            dao.Insert(questionnaire11);
            ShiftHandoverQuestionnaire questionnaire12 = ShiftHandoverQuestionnaireFixture.Create(workAssignment, user, userShift3.ShiftPattern, userShift3.EndDateTimeWithPadding, flocs);
            dao.Insert(questionnaire12);

            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user.IdValue, workAssignment.IdValue, userShift1);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire9.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire10.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire11.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire12.Id));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user.IdValue, workAssignment.IdValue, userShift2);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire6.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire7.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire8.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire9.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire10.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire11.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire12.Id));
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByUserWorkAssignmentAndShift(
                    user.IdValue, workAssignment.IdValue, userShift3);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire5.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire6.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire7.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire8.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire9.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire10.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire11.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire12.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignmentAndShift_VaryUser()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI() };

            WorkAssignment workAssignment1 = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));
            WorkAssignment workAssignment2 = InsertWorkAssignment(flocs[0].Site, RoleFixture.GetRealRoleA(flocs[0].Site.IdValue));            

            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 2));
            ShiftPattern shiftPattern = userShift.ShiftPattern;

            ShiftHandoverQuestionnaire questionnaire1 = ShiftHandoverQuestionnaireFixture.Create(workAssignment1, user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire1);
            ShiftHandoverQuestionnaire questionnaire2 = ShiftHandoverQuestionnaireFixture.Create(workAssignment2, user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), flocs);
            dao.Insert(questionnaire2);

            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByWorkAssignmentAndShift(workAssignment1.IdValue, userShift);
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire2.Id));                
            }
            {
                List<ShiftHandoverQuestionnaire> results = dao.QueryByWorkAssignmentAndShift(workAssignment2.IdValue, userShift);
                Assert.IsFalse(results.Exists(obj => obj.Id == questionnaire1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == questionnaire2.Id));                
            }            
        }

        private WorkAssignment InsertWorkAssignment(Site site, Role role)
        {
            WorkAssignment workAssignment = new WorkAssignment("test floc for " + role.Name, "description for " + role.Name, null, site.IdValue, role);
            workAssignment = workAssignmentDao.Insert(workAssignment);
            return workAssignment;
        }

        [Ignore] [Test]
        public void ShouldInsertCokerCardConfiguration()
        {
            List<CokerCardConfiguration> configurations = cokerCardConfigurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            long configurationId = configurations[0].IdValue;

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.RelevantCokerCardConfigurations.Clear();
            questionnaire.RelevantCokerCardConfigurations.Add(configurationId);

            dao.Insert(questionnaire);

            {
                ShiftHandoverQuestionnaire requeried = dao.QueryById(questionnaire.IdValue);
                Assert.AreEqual(1, requeried.RelevantCokerCardConfigurations.Count);
                Assert.AreEqual(configurationId, requeried.RelevantCokerCardConfigurations[0]);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateHasYesAnswer()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_MT1_A001_U010();

            WorkAssignment workAssignment = InsertWorkAssignment(floc.Site, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            User user = UserFixture.CreateUserWithGivenId(1);
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 2));
            ShiftPattern shiftPattern = userShift.ShiftPattern;

            DateRange range = new DateRange(new Date(2010, 12, 1), null);

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create(workAssignment,
                user, shiftPattern, new DateTime(2010, 12, 2, 9, 10, 0), new List<FunctionalLocation> { floc });                
            questionnaire.Answers.Clear();
            questionnaire.Answers.Add(ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments", "question","Yes","pk@hotmail.com", true));
            questionnaire.Answers.Add(ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments", "question","No","pk@hotmail.com",false));

            dao.Insert(questionnaire);

            List<ShiftHandoverQuestionnaireDTO> dtos = dtoDao.QueryByFunctionalLocation(new RootFlocSet(floc), range, null, null);
            ShiftHandoverQuestionnaireDTO dto = dtos.Find(obj => obj.Id == questionnaire.Id);
            Assert.AreEqual(true, dto.HasYesAnswer);

            questionnaire.Answers.RemoveAll(answer => answer.Answer);
            dao.Update(questionnaire);
            dtos = dtoDao.QueryByFunctionalLocation(new RootFlocSet(floc), range, null, null);
            dto = dtos.Find(obj => obj.Id == questionnaire.Id);
            Assert.AreEqual(false, dto.HasYesAnswer);
        }
    }
}