using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SummaryLogReadDaoTest : AbstractDaoTest
    {
        private ISummaryLogReadDao dao;
        private ISummaryLogDao logDao;
        private User user;
        
        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISummaryLogReadDao>();
            logDao = DaoRegistry.GetDao<ISummaryLogDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(
                UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldMarkSummaryLogAsRead()
        {
            SummaryLog log = CreateSummaryLogMarkedAsRead();
            List<ItemReadBy> logsMarkedAsRead = dao.UsersThatMarkedSummaryLogAsRead(log.IdValue);

            Assert.That(logsMarkedAsRead,
                        Has.Some.Property("UserFullNameWithUserName").EqualTo(User.ToFullNameWithUserName(
                                                                                  user.LastName, user.FirstName,
                                                                                  user.Username)),
                        "SummaryLog was not marked as read by user");
        }

        [Ignore] [Test]
        public void ShouldQueryIfSummaryLogAlreadyReadByUser()
        {
            SummaryLog logToBeReadA = CreateSummaryLogMarkedAsRead();
            SummaryLog logNotToBeRead = SummaryLogFixture.CreateSummaryLogNotInDatabase();
            logNotToBeRead.FunctionalLocations.Clear();
            logNotToBeRead.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS());
            logNotToBeRead = logDao.Insert(logNotToBeRead);
            SummaryLog logToBeReadB = CreateSummaryLogMarkedAsRead();

            Assert.IsNotNull(dao.UserMarkedSummaryLogAsRead(logToBeReadA.IdValue, user.IdValue));
            Assert.IsNull(dao.UserMarkedSummaryLogAsRead(logNotToBeRead.IdValue, user.IdValue));
            Assert.IsNotNull(dao.UserMarkedSummaryLogAsRead(logToBeReadB.IdValue, user.IdValue));
        }

        private SummaryLog CreateSummaryLogMarkedAsRead()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLogItemCreatedByUser(user);
            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS());
            log = logDao.Insert(log);
            SummaryLogRead logRead = new SummaryLogRead(log, user, DateTimeFixture.DateTimeNow);
            dao.Insert(logRead);
            return log;
        }

    }
}
