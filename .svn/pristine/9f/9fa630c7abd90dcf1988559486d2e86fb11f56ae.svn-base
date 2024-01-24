using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ShiftHandoverQuestionnaireTest
    {
        private FunctionalLocation flocEq1A;
        private FunctionalLocation flocUnitA;
        private FunctionalLocation flocUnitASibling;
        private FunctionalLocation flocSectionA;
        private FunctionalLocation flocSectionASibling;
        private FunctionalLocation flocDivisionA;
        private FunctionalLocation flocEq2A;
        private FunctionalLocation flocDivisionB;
        private FunctionalLocation flocSectionB;

        [SetUp]
        public void SetUp()
        {
            SetupFlocs();
        }

        [TearDown]
        public void TearDown()
        {
        }

        private void SetupFlocs()
        {
            // DivA
            //  - SecA
            //     - UnitA
            //        - Equip1
            //           - Equip2
            // DivB
            //  -  SecB

            int flocId = 1;

            Site oilsands = SiteFixture.Oilsands();

            flocDivisionA = FunctionalLocationFixture.CreateNew(oilsands, "DivA");
            flocDivisionA.Id = flocId++;

            flocSectionA = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecA");
            flocSectionA.Id = flocId++;

            flocSectionASibling = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecASibling");
            flocSectionASibling.Id = flocId++;

            flocUnitA = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecA-UnitA");
            flocUnitA.Id = flocId++;

            flocUnitASibling = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecA-UnitASibling");
            flocUnitASibling.Id = flocId++;

            flocEq1A = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecA-UnitA-Equip1");
            flocEq1A.Id = flocId++;

            flocEq2A = FunctionalLocationFixture.CreateNew(oilsands, "DivA-SecA-UnitA-Equip1-Equip2");
            flocEq2A.Id = flocId++;

            flocDivisionB = FunctionalLocationFixture.CreateNew(oilsands, "DivB");
            flocDivisionB.Id = flocId++;

            flocSectionB = FunctionalLocationFixture.CreateNew(oilsands, "DivB-SecB");
            flocSectionB.Id = flocId++;
        }


        [Test]
        public void QuestionnaireShouldKnowWhenItIsAPriority()
        {
            DateTime questionnaireCreatedDateTime = new DateTime(2009, 12, 2, 9, 0, 0);
            DateTime oneDayAfterQuestionnaireCreated = questionnaireCreatedDateTime.AddDays(1);
            DateTime now = oneDayAfterQuestionnaireCreated;

            WorkAssignment questionnaireAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            User questionnaireUser = UserFixture.CreateOperator();
            ShiftPattern questionnaireShiftPattern = ShiftPatternFixture.Create8HourDayShift();
            UserShift questionnaireUserShift = UserShiftFixture.CreateUserShift(questionnaireShiftPattern);

            User nonQuestionnaireUser = UserFixture.CreateSupervisor();
            WorkAssignment nonQuestionnaireAssignment = WorkAssignmentFixture.CreateUnitLeader();
            UserShift nonQuestionnaireUserShift = new UserShift(questionnaireShiftPattern, oneDayAfterQuestionnaireCreated);

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = ShiftHandoverQuestionnaireFixture.Create(
                questionnaireAssignment, questionnaireUser, questionnaireShiftPattern, questionnaireCreatedDateTime,
                new List<FunctionalLocation>());

            // case: happy path
            Assert.IsTrue(shiftHandoverQuestionnaire.IsAPriority(nonQuestionnaireUser, questionnaireAssignment, nonQuestionnaireUserShift, now));

            // case: questionnaire created by current user
            Assert.IsFalse(shiftHandoverQuestionnaire.IsAPriority(questionnaireUser, questionnaireAssignment, nonQuestionnaireUserShift, now));

            // case: questionnaire created under different work assignment
            Assert.IsFalse(shiftHandoverQuestionnaire.IsAPriority(nonQuestionnaireUser, nonQuestionnaireAssignment, nonQuestionnaireUserShift, now));

            // case: more than three days after questionnaire was created
            now = questionnaireCreatedDateTime.AddDays(4);
            Assert.IsFalse(shiftHandoverQuestionnaire.IsAPriority(nonQuestionnaireUser, questionnaireAssignment, nonQuestionnaireUserShift, now));

            // case: we are inside shift that questionnaire was created in
            now = questionnaireCreatedDateTime.AddHours(2);
            Assert.IsFalse(shiftHandoverQuestionnaire.IsAPriority(nonQuestionnaireUser, questionnaireAssignment, questionnaireUserShift, now));
        }

        [Test]
        public void QuestionnaireShouldKnowItIsAPriorityWhenAssignmentsAreNull()
        {
            DateTime questionnaireCreatedDateTime = new DateTime(2009, 12, 2, 9, 0, 0);
            DateTime oneDayAfterQuestionnaireCreated = questionnaireCreatedDateTime.AddDays(1);
            DateTime now = oneDayAfterQuestionnaireCreated;

            WorkAssignment questionnaireAssignment = null;
            User questionnaireUser = UserFixture.CreateOperator();
            ShiftPattern questionnaireShiftPattern = ShiftPatternFixture.Create8HourDayShift();
            UserShift questionnaireUserShift = UserShiftFixture.CreateUserShift(questionnaireShiftPattern);

            User nonQuestionnaireUser = UserFixture.CreateSupervisor();
            UserShift nonQuestionnaireUserShift = new UserShift(questionnaireShiftPattern, oneDayAfterQuestionnaireCreated);

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = ShiftHandoverQuestionnaireFixture.Create(
                questionnaireAssignment, questionnaireUser, questionnaireShiftPattern, questionnaireCreatedDateTime,
                new List<FunctionalLocation>());

            Assert.IsTrue(shiftHandoverQuestionnaire.IsAPriority(nonQuestionnaireUser, questionnaireAssignment, nonQuestionnaireUserShift, now));
        }

        [Test]
        public void ShouldDetermineWhetherALogIsAssociatedWithQuestionnaire()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(8), new Time(20), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(8), 2);

            {
                WorkAssignment questionnaireAssignment = WorkAssignmentFixture.CreateConsoleOperator();
                User questionnaireUser = UserFixture.CreateUserWithGivenId(1);
                ShiftPattern questionnaireShiftPattern = nightShift;
                DateTime questionnaireCreatedDateTime = new DateTime(2009, 12, 2, 23, 0, 0);

                ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create(
                    questionnaireAssignment,
                    questionnaireUser,
                    questionnaireShiftPattern,
                    questionnaireCreatedDateTime,
                    new List<FunctionalLocation>());

                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, questionnaireCreatedDateTime, questionnaireShiftPattern));

                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(UserFixture.CreateUserWithGivenId(2), questionnaireAssignment, questionnaireCreatedDateTime,
                                                                               questionnaireShiftPattern));
                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(null, questionnaireAssignment, questionnaireCreatedDateTime, questionnaireShiftPattern));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, null, questionnaireCreatedDateTime, questionnaireShiftPattern));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(UserFixture.CreateUserWithGivenId(2), null, questionnaireCreatedDateTime, questionnaireShiftPattern));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(null, null, questionnaireCreatedDateTime, questionnaireShiftPattern));

                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 8, 0, 0), nightShift));
                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 20, 0, 0), nightShift));
                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 8, 0, 0), nightShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 20, 0, 0), nightShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 8, 0, 0), dayShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 20, 0, 0), dayShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 8, 0, 0), dayShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 20, 0, 0), dayShift));

            }

            {
                WorkAssignment questionnaireAssignment = null;
                User questionnaireUser = UserFixture.CreateUserWithGivenId(1);
                ShiftPattern questionnaireShiftPattern = dayShift;
                DateTime questionnaireCreatedDateTime = new DateTime(2009, 12, 2, 13, 0, 0);

                ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create(
                    questionnaireAssignment,
                    questionnaireUser,
                    questionnaireShiftPattern,
                    questionnaireCreatedDateTime,
                    new List<FunctionalLocation>());

                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, questionnaireCreatedDateTime, questionnaireShiftPattern));

                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(UserFixture.CreateUserWithGivenId(2), questionnaireAssignment, questionnaireCreatedDateTime,
                                                                                questionnaireShiftPattern));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(null, questionnaireAssignment, questionnaireCreatedDateTime, questionnaireShiftPattern));

                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 8, 0, 0), nightShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 20, 0, 0), nightShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 8, 0, 0), nightShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 20, 0, 0), nightShift));
                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 8, 0, 0), dayShift));
                Assert.IsTrue(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 2, 20, 0, 0), dayShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 8, 0, 0), dayShift));
                Assert.IsFalse(questionnaire.MatchesLogByUserAssignmentAndShift(questionnaireUser, questionnaireAssignment, new DateTime(2009, 12, 3, 20, 0, 0), dayShift));

            }

        }

        [Test]
        public void ShouldSortByShiftThenAssignmentThenCreateUser()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(8), new Time(20), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(8), 2);

            WorkAssignment assignment1 = WorkAssignmentFixture.CreateConsoleOperator();
            assignment1.Name = "name N";
            assignment1.Id = 2;

            WorkAssignment assignment2 = WorkAssignmentFixture.CreateConsoleOperator();
            assignment2.Name = "name M";
            assignment2.Id = 3;

            User userPerkins = UserFixture.CreateUserWithGivenId(1);
            userPerkins.LastName = "Perkins";

            User userMcErnie = UserFixture.CreateUserWithGivenId(2);
            userPerkins.LastName = "McErnie";

            ShiftHandoverQuestionnaire questionnaireA = ShiftHandoverQuestionnaireFixture.Create(
                assignment1,
                userPerkins,
                dayShift,
                new DateTime(2010, 12, 2, 9, 0, 0),
                new List<FunctionalLocation>());

            ShiftHandoverQuestionnaire questionnaireB = ShiftHandoverQuestionnaireFixture.Create(
                assignment1,
                userMcErnie,
                dayShift,
                new DateTime(2010, 12, 2, 10, 0, 0),
                new List<FunctionalLocation>());

            ShiftHandoverQuestionnaire questionnaireC = ShiftHandoverQuestionnaireFixture.Create(
                assignment1,
                userPerkins,
                nightShift,
                new DateTime(2010, 12, 3, 7, 0, 0),
                new List<FunctionalLocation>());

            ShiftHandoverQuestionnaire questionnaireD = ShiftHandoverQuestionnaireFixture.Create(
                assignment1,
                userMcErnie,
                nightShift,
                new DateTime(2010, 12, 3, 7, 0, 0),
                new List<FunctionalLocation>());

            ShiftHandoverQuestionnaire questionnaireE = ShiftHandoverQuestionnaireFixture.Create(
                assignment2,
                userMcErnie,
                nightShift,
                new DateTime(2010, 12, 3, 7, 0, 0),
                new List<FunctionalLocation>());

            ShiftHandoverQuestionnaire questionnaireF = ShiftHandoverQuestionnaireFixture.Create(
                null,
                userMcErnie,
                nightShift,
                new DateTime(2010, 12, 3, 7, 0, 0),
                new List<FunctionalLocation>());

            List<ShiftHandoverQuestionnaire> questionnaires = new List<ShiftHandoverQuestionnaire>();
            questionnaires.Add(questionnaireA);
            questionnaires.Add(questionnaireB);
            questionnaires.Add(questionnaireC);
            questionnaires.Add(questionnaireD);
            questionnaires.Add(questionnaireE);
            questionnaires.Add(questionnaireF);

            questionnaires.Sort(ShiftHandoverQuestionnaire.CompareByShiftThenWorkAssignmentThenCreateUser);

            Assert.AreEqual(0, questionnaires.IndexOf(questionnaireB));
            Assert.AreEqual(1, questionnaires.IndexOf(questionnaireA));
            Assert.AreEqual(2, questionnaires.IndexOf(questionnaireF));
            Assert.AreEqual(3, questionnaires.IndexOf(questionnaireE));
            Assert.AreEqual(4, questionnaires.IndexOf(questionnaireD));
            Assert.AreEqual(5, questionnaires.IndexOf(questionnaireC));
        }

        [Test]
        public void IsRelevantToShouldReturnTrueIfHandoverIsAtLevelFiveAndUserIsLoggedInUnderRelevantFunctionalLocations()
        {
            List<FunctionalLocation> flocsOfQuestionnaire = new List<FunctionalLocation> {flocEq1A};
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire =
                ShiftHandoverQuestionnaireFixture.Create(flocsOfQuestionnaire);

            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> {flocDivisionA, flocSectionA, flocUnitA, flocEq1A, flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionA, flocUnitA, flocEq1A, flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitA, flocEq1A, flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocDivisionB, flocSectionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionB, flocUnitA, flocEq1A, flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq1A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocDivisionA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

        }

        [Test]
        public void IsRelevantToShouldReturnTrueIfHandoverIsUnderLevelThreeAndUserIsLoggedInUnderRelevantFunctionalLocations()
        {
            List<FunctionalLocation> flocsOfQuestionnaire = new List<FunctionalLocation> {flocUnitA};
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire =
                ShiftHandoverQuestionnaireFixture.Create(flocsOfQuestionnaire);

            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> {flocDivisionA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocDivisionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionASibling};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitASibling};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq1A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));
        }

        [Test]
        public void IsRelevantToShouldReturnTrueIfHandoverIsUnderLevelTwoAndUserIsLoggedInUnderRelevantFunctionalLocations()
        {
            List<FunctionalLocation> flocsOfQuestionnaire = new List<FunctionalLocation> {flocSectionA};
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire =
                ShiftHandoverQuestionnaireFixture.Create(flocsOfQuestionnaire);

            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> {flocDivisionA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocDivisionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionASibling};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocSectionB};
            Assert.IsFalse(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitA};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocUnitASibling};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq1A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

            usersFlocs = new List<FunctionalLocation> {flocEq2A};
            Assert.IsTrue(
                shiftHandoverQuestionnaire.IsRelevantTo(Site.OILSAND_ID, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null, null));

        }

        [Test]
        public void QuestionnaireShouldKnowIfItHasAYesAnswer()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> {flocSectionA};

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = ShiftHandoverQuestionnaireFixture.Create(flocs);

            ShiftHandoverAnswer yesAnswer = ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments 1", "question 1", "Yes", "pk@hotmail.com");//Yes is added by ppanigrahi
            yesAnswer.Answer = true;

            ShiftHandoverAnswer noAnswer = ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments 2", "question 2","No","pk@hotmail.com");//No is added by ppanigrahi
            noAnswer.Answer = false;

            shiftHandoverQuestionnaire.Answers.Clear();
            shiftHandoverQuestionnaire.Answers.Add(noAnswer);
            Assert.IsFalse(shiftHandoverQuestionnaire.HasYesAnswer);

            shiftHandoverQuestionnaire.Answers.Add(yesAnswer);
            Assert.IsTrue(shiftHandoverQuestionnaire.HasYesAnswer);
        }

        [Test]
        public void ShouldBeSameUser()
        {
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = ShiftHandoverQuestionnaireFixture.Create();
            
            SummaryLog sl1 = SummaryLogFixture.CreateSummaryLogItemCreatedByUser(shiftHandoverQuestionnaire.CreateUser);
            SummaryLog sl2 = SummaryLogFixture.CreateSummaryLogItemCreatedByUser(shiftHandoverQuestionnaire.CreateUser);

            List<HasCommentsDTO> list = new List<HasCommentsDTO> { new HasCommentsDTO(sl1), new HasCommentsDTO(sl2) };

            Assert.That(shiftHandoverQuestionnaire.IsSameUser(list), Is.True);
        }
    }
}