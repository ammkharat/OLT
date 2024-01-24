using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverAnswerDaoTest : AbstractDaoTest
    {
        private IShiftHandoverAnswerDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverAnswerDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryByQuestionnaireId()
        {
            List<ShiftHandoverAnswer> list = dao.QueryByQuestionnaireId(1);
            Assert.IsNotEmpty(list);

            ShiftHandoverAnswer answer = list[0];

            Assert.AreEqual(true, answer.Answer);
            Assert.AreEqual("These are comments for an answer 1", answer.Comments);
            Assert.AreEqual("Dogs make better pets than cats", answer.QuestionText);
            Assert.AreEqual(answer.QuestionDisplayOrder, 212);       
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            //Yes and email is added by ppanigrahi
            ShiftHandoverAnswer answer = new ShiftHandoverAnswer(
                null,
                true,
                "comments-asfdasasda12232322",
                "question text is not stored by dao insert call","Yes","pk@hotmail.com",
                42,
                1);

            ShiftHandoverAnswer inserted = dao.Insert(answer, 1);

            List<ShiftHandoverAnswer> answers = dao.QueryByQuestionnaireId(1);
            ShiftHandoverAnswer retrievedAnswer = answers.FindById(inserted);

            Assert.AreEqual(answer.Answer, retrievedAnswer.Answer);
            Assert.AreEqual(answer.Comments, retrievedAnswer.Comments);
            Assert.AreEqual("Dogs make better pets than cats", retrievedAnswer.QuestionText);
            Assert.AreEqual(answer.QuestionDisplayOrder, retrievedAnswer.QuestionDisplayOrder);
            Assert.AreEqual(answer.ShiftHandoverQuestionId, retrievedAnswer.ShiftHandoverQuestionId);
        }   
     
        [Ignore] [Test]
        public void ShouldUpdate()
        {
            //YesNo is added by ppanigrahi
            ShiftHandoverAnswer answer = new ShiftHandoverAnswer(
                null,
                true,
                "asfdasasda12232322",
                "ASFDAasfdasd2354wasf1111","Yes","pk@hotmail.com",
                42,
                1);

            ShiftHandoverAnswer inserted = dao.Insert(answer, 1);

            inserted.Answer = false;
            inserted.Comments = "abcdef";

            dao.Update(inserted);

            List<ShiftHandoverAnswer> answers = dao.QueryByQuestionnaireId(1);
            ShiftHandoverAnswer retrievedAnswer = answers.FindById(inserted);

            Assert.AreEqual(false, retrievedAnswer.Answer);
            Assert.AreEqual("abcdef", retrievedAnswer.Comments);
        }
    }
}