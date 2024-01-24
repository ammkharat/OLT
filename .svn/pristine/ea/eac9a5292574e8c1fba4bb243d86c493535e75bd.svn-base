using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class UserLoginHistoryServiceClientTest
    {
        private IUserLoginHistoryService userLoginHistoryService;

        [SetUp]
        public void SetUp()
        {
            userLoginHistoryService = GenericServiceRegistry.Instance.GetService<IUserLoginHistoryService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldSaveOnlyTheLastLogin()
        {
            var user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            var dateTime = new DateTime(2001, 3, 10, 10, 0, 0);

            var loginHistory1 = UserLoginHistoryFixture.Create(user.IdValue, dateTime);
            var id1 = userLoginHistoryService.SaveLoginHistory(loginHistory1).IdValue;

            {
                var userLoginHistory = userLoginHistoryService.GetLastLogin(user);
                Assert.AreEqual(id1, userLoginHistory.Id);
            }

            var loginHistory2 = UserLoginHistoryFixture.Create(user.IdValue, dateTime);
            var id2 = userLoginHistoryService.SaveLoginHistory(loginHistory2).IdValue;

            {
                var userLoginHistory = userLoginHistoryService.GetLastLogin(user);
                Assert.AreEqual(id2, userLoginHistory.Id);
            }
        }
    }
}