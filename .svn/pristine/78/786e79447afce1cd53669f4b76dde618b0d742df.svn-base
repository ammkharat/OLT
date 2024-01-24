using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class DirectiveReadDaoTest : AbstractDaoTest
    {
        private IDirectiveReadDao readDao;
        private IDirectiveDao directiveDao;
        private User user;

        protected override void TestInitialize()
        {
            readDao = DaoRegistry.GetDao<IDirectiveReadDao>();
            directiveDao = DaoRegistry.GetDao<IDirectiveDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));                
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldMarkDirectiveAsRead()
        {
            Directive log = CreateDirectiveAsRead();
            List<ItemReadBy> logsMarkedAsRead = readDao.UsersThatMarkedAsRead(log.IdValue);

            Assert.That(logsMarkedAsRead,
                        Has.Some.Property("UserFullNameWithUserName").EqualTo(User.ToFullNameWithUserName(
                            user.LastName, user.FirstName,
                            user.Username)),
                        "ShiftHandoverQuestionnaire was not marked as read by user");
        }

        [Ignore] [Test]
        public void ShouldQueryIfDirectiveAlreadyReadByUser()
        {
            Directive directiveToBeReadA = CreateDirectiveAsRead();
            Directive directiveNotToBeRead = CreateDirectiveNotInDatabase();
            directiveDao.Insert(directiveNotToBeRead);
            Directive directiveToBeReadB = CreateDirectiveAsRead();

            Assert.IsNotNull(readDao.UserMarkedAsRead(directiveToBeReadA.IdValue, user.IdValue));
            Assert.IsNull(readDao.UserMarkedAsRead(directiveNotToBeRead.IdValue, user.IdValue));
            Assert.IsNotNull(readDao.UserMarkedAsRead(directiveToBeReadB.IdValue, user.IdValue));
        }

        [Ignore] [Test]
        public void ShouldConvertLogMarkedAsReadInfoToDirectiveMarkedAsReadInfo()
        {
            ILogDao logDao = DaoRegistry.GetDao<ILogDao>();
            ILogReadDao logReadDao = DaoRegistry.GetDao<ILogReadDao>();

            Log log = LogFixture.CreateLogItemCreatedByUser(user);
            log = logDao.Insert(log);
            LogRead logRead = new LogRead(log, user, DateTimeFixture.DateTimeNow);
            logReadDao.Insert(logRead);

            Directive directive = CreateDirectiveNotInDatabase();
            directiveDao.Insert(directive);
            
            readDao.ConvertMarkedAsReadInformation(log.IdValue, directive.IdValue);

            List<ItemReadBy> itemReadBys = readDao.UsersThatMarkedAsRead(directive.IdValue);
            Assert.AreEqual(1, itemReadBys.Count);
            Assert.IsTrue(itemReadBys.Exists(itemReadBy => itemReadBy.UserFullNameWithUserName == user.FullNameWithUserName));
        }

        private static Directive CreateDirectiveNotInDatabase()
        {
            Directive directive = DirectiveFixture.CreateForInsert();
            directive.Id = null;
            return directive;
        }

        private Directive CreateDirectiveAsRead()
        {
            Directive directive = DirectiveFixture.CreateForInsert();
            directiveDao.Insert(directive);
            ItemRead<Directive> itemRead = new ItemRead<Directive>(directive, user, DateTimeFixture.DateTimeNow);
            readDao.Insert(itemRead);
            return directive;
        }
    }
}