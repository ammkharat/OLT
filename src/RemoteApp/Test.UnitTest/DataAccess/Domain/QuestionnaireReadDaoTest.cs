using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class QuestionnaireReadDaoTest : AbstractDaoTest
    {
        private IQuestionnaireReadDao dao;
        private IShiftHandoverQuestionnaireDao questionnaireDao;
        private User user;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IQuestionnaireReadDao>();
            questionnaireDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(
                UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldMarkQuestionnaireAsRead()
        {
            ShiftHandoverQuestionnaire log = CreateQuestionnaireAsRead();
            List<ItemReadBy> logsMarkedAsRead = dao.UsersThatMarkedAsRead(log.IdValue);

            Assert.That(logsMarkedAsRead,
                        Has.Some.Property("UserFullNameWithUserName").EqualTo(User.ToFullNameWithUserName(
                            user.LastName, user.FirstName,
                            user.Username)),
                        "ShiftHandoverQuestionnaire was not marked as read by user");
        }

        [Ignore] [Test]
        public void ShouldQueryIfQuestionnaireAlreadyReadByUser()
        {
            ShiftHandoverQuestionnaire logToBeReadA = CreateQuestionnaireAsRead();
            ShiftHandoverQuestionnaire logNotToBeRead = CreateQuestionaireNotInDatabase();
            questionnaireDao.Insert(logNotToBeRead);

            ShiftHandoverQuestionnaire logToBeReadB = CreateQuestionnaireAsRead();

            Assert.IsNotNull(dao.UserMarkedAsRead(logToBeReadA.IdValue, user.IdValue));
            Assert.IsNull(dao.UserMarkedAsRead(logNotToBeRead.IdValue, user.IdValue));
            Assert.IsNotNull(dao.UserMarkedAsRead(logToBeReadB.IdValue, user.IdValue));
        }

        private static ShiftHandoverQuestionnaire CreateQuestionaireNotInDatabase()
        {
            ShiftHandoverQuestionnaire questionaireNotInDatabase = ShiftHandoverQuestionnaireFixture.Create();
            questionaireNotInDatabase.Id = null;
            return questionaireNotInDatabase;
        }

        private ShiftHandoverQuestionnaire CreateQuestionnaireAsRead()
        {
            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaireDao.Insert(questionnaire);
            ItemRead<ShiftHandoverQuestionnaire> logRead = new ItemRead<ShiftHandoverQuestionnaire>(questionnaire, user, DateTimeFixture.DateTimeNow);
            dao.Insert(logRead);
            return questionnaire;
        }
    }
}