using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class PermitAssessmentHistoryDaoTest : AbstractDaoTest
    {
        private IQuestionnaireConfigurationDao configDao;
        private IPermitAssessmentDao assessmentDao;
        private IPermitAssessmentHistoryDao historyDao;

        private PermitAssessment assessment1;
        private QuestionnaireConfiguration configuration1;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var answerId1 = assessment1.Answers[0].IdValue;
            var answerId2 = assessment1.Answers[1].IdValue;

            var answerHistories =
                new List<PermitAssessmentAnswerHistory>
                {
                    new PermitAssessmentAnswerHistory(1, 0, answerId1, "question is fk, not stored",
                        3, 25.47m, "abc"),
                    new PermitAssessmentAnswerHistory(2, 0, answerId2, "question is fk, not stored",
                        4, 45.12m, "def")
                };

            var history = new PermitAssessmentHistory(
                123,
                new DateTime(2015, 05, 30),
                new DateTime(2015, 06, 14),
                FormStatus.Approved,
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2015, 05, 30),
                false,
                true,
                "contractor",
                "trade",
                4,
                OilsandsWorkPermitType.BlanketCold,
                "Permit #",
                "Location/equipment #",
                45.67m,
                245,
                456,
                125,
                "Job description",
                "Overall feedback",
                "Job Coordinator",
                false,
                "FLOCs",
                "Doc Links",
                answerHistories);
            historyDao.Insert(history);

            var histories = historyDao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            var requeried = histories[0];
            Assert.AreEqual(123, requeried.Id);
            Assert.AreEqual("FLOCs", requeried.FunctionalLocations);
            Assert.AreEqual(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2015, 05, 30), requeried.LastModifiedDate);

            Assert.AreEqual(2, requeried.Answers.Count);
            Assert.IsTrue(
                requeried.Answers.Exists(
                    obj =>
                        obj.QuestionText == "Question 1" && obj.Comments == "abc" &&
                        obj.Score == 3 && obj.SectionScoredPercentage == 25.47m && obj.Id == 1));
            Assert.IsTrue(
                requeried.Answers.Exists(
                    obj =>
                        obj.QuestionText == "Question 2" && obj.Comments == "def" &&
                        obj.Score == 4 && obj.SectionScoredPercentage == 45.12m && obj.Id == 2));
        }

        protected override void TestInitialize()
        {
            configDao = DaoRegistry.GetDao<IQuestionnaireConfigurationDao>();
            assessmentDao = DaoRegistry.GetDao<IPermitAssessmentDao>();
            historyDao = DaoRegistry.GetDao<IPermitAssessmentHistoryDao>();

            SetupConfigurations();
            SetupPermits();
        }

        private void SetupConfigurations()
        {
            var type = QuestionnaireConfigurationType.SafeWorkPermit.GetName();
            configuration1 = QuestionnaireConfigurationFixture.Create(Site.OILSAND_ID, type, "Configuration 1");
            configDao.Insert(configuration1);
        }

        private void SetupPermits()
        {
            assessment1 = PermitAssessmentFixture.Create(configuration1, new DateTime(2014, 12, 12), new DateTime(2015, 12, 31));
            assessmentDao.Insert(assessment1);
        }

        protected override void Cleanup()
        {
        }
    }
}