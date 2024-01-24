using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverQuestionnaireHistoryDaoTest : AbstractDaoTest
    {
        private IShiftHandoverQuestionnaireHistoryDao historyDao;

        protected override void TestInitialize()
        {
            historyDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var answerHistories =
                new List<ShiftHandoverAnswerHistory>
                    {
                        new ShiftHandoverAnswerHistory(1, 0, 1, "question is fk, not stored",
                                                       true, "abc"),
                        new ShiftHandoverAnswerHistory(2, 0, 2, "question is fk, not stored",
                                                       false, "def")
                    };

            ShiftHandoverQuestionnaireHistory history = new ShiftHandoverQuestionnaireHistory(
                123,
                "flocs abc",
                answerHistories,
                UserFixture.CreateSAPUser(),
                new DateTime(2010, 1, 2));
            historyDao.Insert(history);

            List<ShiftHandoverQuestionnaireHistory> histories = historyDao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            ShiftHandoverQuestionnaireHistory requeried = histories[0];
            Assert.AreEqual(123, requeried.Id);
            Assert.AreEqual("flocs abc", requeried.FunctionalLocations);
            Assert.AreEqual(UserFixture.CreateSAPUser().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2010, 1, 2), requeried.LastModifiedDate);

            Assert.AreEqual(2, requeried.Answers.Count);
            Assert.IsTrue(requeried.Answers.Exists(obj => obj.QuestionText == "Dogs make better pets than cats" && obj.Answer && obj.Comments == "abc" && obj.Id == 1));
            Assert.IsTrue(requeried.Answers.Exists(obj => obj.QuestionText == "Kent is a metrosexual. True or False?" && !obj.Answer && obj.Comments == "def" && obj.Id == 2));
        }
    }
}
