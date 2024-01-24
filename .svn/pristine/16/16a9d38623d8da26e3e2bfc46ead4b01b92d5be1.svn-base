using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogReadDaoTest : AbstractDaoTest
    {
        private ILogReadDao dao;
        private ILogDao logDao;
        private User user;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogReadDao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(
                UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldMarkLogAsRead()
        {
            Log log = CreateLogMarkedAsRead();
            List<ItemReadBy> logsMarkedAsRead = dao.UsersThatMarkedLogAsRead(log.IdValue);

            Assert.That(logsMarkedAsRead,
                        Has.Some.Property("UserFullNameWithUserName").EqualTo(User.ToFullNameWithUserName(
                                                                                  user.LastName, user.FirstName,
                                                                                  user.Username)),
                        "Log was not marked as read by user");
        }

        [Ignore] [Test]
        public void ShouldQueryIfLogAlreadyReadByUser()
        {
            Log logToBeReadA = CreateLogMarkedAsRead();
            Log logNotToBeRead = logDao.Insert(LogFixture.CreateLogNotInDatabase(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()));
            Log logToBeReadB = CreateLogMarkedAsRead();

            Assert.IsNotNull(dao.UserMarkedLogAsRead(logToBeReadA.IdValue, user.IdValue));
            Assert.IsNull(dao.UserMarkedLogAsRead(logNotToBeRead.IdValue, user.IdValue));
            Assert.IsNotNull(dao.UserMarkedLogAsRead(logToBeReadB.IdValue, user.IdValue));
        }

        private Log CreateLogMarkedAsRead()
        {
            Log log = LogFixture.CreateLogItemCreatedByUser(user);
            log = logDao.Insert(log);
            LogRead logRead = new LogRead(log, user, DateTimeFixture.DateTimeNow);
            dao.Insert(logRead);
            return log;
        }

    }
}
