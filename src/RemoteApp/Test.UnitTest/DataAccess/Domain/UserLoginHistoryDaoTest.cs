using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{   
    [TestFixture] [Category("Database")]
    public class UserLoginHistoryDaoTest : AbstractDaoTest
    {
        private const long userId = 1;

        private IUserLoginHistoryDao userLoginHistoryDao;

        protected override void TestInitialize()
        {
            userLoginHistoryDao = DaoRegistry.GetDao<IUserLoginHistoryDao>();
        }

        protected override void Cleanup() { }

        [Ignore] [Test]
        public void QueryByUserIdShouldReturnUserLoginHistory()
        {
            const long assignmentId = 2;
 
            UserLoginHistory loginHistory = UserLoginHistoryFixture.Create(userId, assignmentId);
            Assert.IsTrue(loginHistory.IsClickOnce);
            userLoginHistoryDao.Insert(loginHistory);

            UserLoginHistory userLoginHistory = userLoginHistoryDao.QueryLastLoginByUserId(userId);
            Assert.AreEqual(userId, userLoginHistory.User.Id);
            Assert.AreEqual(assignmentId, userLoginHistory.Assignment.Id);
            Assert.IsTrue(userLoginHistory.IsClickOnce);
        }

        [Ignore] [Test]
        public void CanQueryHistoryWithNullAssignment()
        {
            UserLoginHistory loginHistory = UserLoginHistoryFixture.CreateWithNoAssignment(userId);
            userLoginHistoryDao.Insert(loginHistory);

            UserLoginHistory userLoginHistory = userLoginHistoryDao.QueryLastLoginByUserId(userId);
            Assert.AreEqual(userId, userLoginHistory.User.Id);
            Assert.IsNull(userLoginHistory.Assignment);
        }

        [Ignore] [Test]
        public void CanInsertPreference()
        {
            const long originalAssignmentId = 2;

            userLoginHistoryDao.Insert(UserLoginHistoryFixture.Create(userId, originalAssignmentId));

            UserLoginHistory userLoginHistory = userLoginHistoryDao.QueryLastLoginByUserId(userId);
            Assert.AreEqual(originalAssignmentId, userLoginHistory.Assignment.Id);
        }

        [Ignore] [Test]
        public void ShouldInsertFunctionalLocations()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            UserLoginHistory history = UserLoginHistoryFixture.Create(userId, DateTime.Now);
            
            history.SelectedFunctionalLocations.Clear();
            history.SelectedFunctionalLocations.Add(floc1);
            history.SelectedFunctionalLocations.Add(floc2);

            userLoginHistoryDao.Insert(history);
            
            UserLoginHistory requeried = userLoginHistoryDao.QueryLastLoginByUserId(userId);
            Assert.AreEqual(2, requeried.SelectedFunctionalLocations.Count);
            Assert.IsTrue(requeried.SelectedFunctionalLocations.ExistsById(floc1));
            Assert.IsTrue(requeried.SelectedFunctionalLocations.ExistsById(floc2));
        }

        [Ignore] [Test]
        public void ShouldFindLastLogin()
        {
            UserLoginHistory loginHistory1 = UserLoginHistoryFixture.Create(userId, new DateTime(2001, 3, 10, 10, 0, 0));
            userLoginHistoryDao.Insert(loginHistory1);

            UserLoginHistory loginHistory2 = UserLoginHistoryFixture.Create(userId, new DateTime(2001, 3, 11, 10, 0, 0));
            userLoginHistoryDao.Insert(loginHistory2);

            UserLoginHistory loginHistory3 = UserLoginHistoryFixture.Create(userId, new DateTime(2001, 3, 09, 10, 0, 0));
            userLoginHistoryDao.Insert(loginHistory3);

            UserLoginHistory requeried = userLoginHistoryDao.QueryLastLoginByUserId(userId);
            Assert.That(requeried.LoginDateTime, Is.EqualTo(new DateTime(2001, 3, 11, 10, 0, 0)).Within(TimeSpan.FromSeconds(10)));
        }
    }
}
