using System;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class UserDaoTest : AbstractDaoTest
    {
        private IUserDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup() {}

        private static bool IsDefaultConfiguration(UserPrintPreference preference)
        {
            return preference.PrinterName == null
                   && preference.NumberOfCopies == 1
                   && preference.ShowPrintDialog;
        }

        [Ignore] [Test]
        public void QueryByIdShouldReturnAPopulatedUser()
        {
            User user = dao.QueryById(1);
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.LastModifiedDate);
        }

        [Ignore] [Test]
        public void QueryByIdShouldCreateEmptyWorkPermitPrintPreference()
        {
            User findUser = dao.QueryById(1);
            Assert.IsNotNull(findUser);
            Assert.IsTrue(IsDefaultConfiguration(findUser.WorkPermitPrintPreference));
        }

        [Ignore] [Test]
        public void QueryByUsernameShouldCreateEmptyWorkPermitPrintPreferenceForUserWithoutAny()
        {
            User findUser = dao.QueryByUsername("oltuser1");
            Assert.IsNotNull(findUser);
            Assert.IsTrue(IsDefaultConfiguration(findUser.WorkPermitPrintPreference));
        }
        
        [Ignore] [Test]
        public void ShouldQueryByIdAndCreateEmptyWorkPermitDefaultTimePreference()
        {
            User user = dao.Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
            User savedUser = dao.QueryById(user.Id.Value);
            Assert.IsNotNull(savedUser.WorkPermitDefaultTimePreferences);
        }

        [Ignore] [Test]
        public void ShouldQueryByIdAndPopulateWorkPermitDefaultTimePreferenceWithDefaults()
        {
            User user = dao.QueryById(2);
            Assert.IsNotNull(user.WorkPermitDefaultTimePreferences);
            Assert.AreEqual(new TimeSpan(), user.WorkPermitDefaultTimePreferences.PreShiftPadding);
            Assert.AreEqual(new TimeSpan(), user.WorkPermitDefaultTimePreferences.PostShiftPadding);
        }

        [Ignore] [Test]
        public void WhenQueryByUsernameShouldPopulateWorkPermitTimePreference()
        {
            User user = dao.QueryByUsername("oltuser2");
            Assert.IsNotNull(user);

            Assert.IsNotNull(user.WorkPermitDefaultTimePreferences);
            Assert.AreEqual(new TimeSpan(02, 00, 00), user.WorkPermitDefaultTimePreferences.PreShiftPadding);
            Assert.AreEqual(new TimeSpan(01, 00, 00), user.WorkPermitDefaultTimePreferences.PostShiftPadding);
        }

        [Ignore] [Test]
        public void ShouldQueryByUsernameAndLoadExistingWorkPermitPrintPreference()
        {
            User user = dao.Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
            IUserPrintPreferenceDao preferenceDao = DaoRegistry.GetDao<IUserPrintPreferenceDao>();
            UserPrintPreference preference = preferenceDao.Insert(UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(user));
            User findUser = dao.QueryByUsername(user.Username);
            Assert.IsNotNull(findUser);
            Assert.IsFalse(IsDefaultConfiguration(findUser.WorkPermitPrintPreference));
            Assert.AreEqual(preference.UserId, findUser.WorkPermitPrintPreference.UserId, "UserId");
            Assert.AreEqual(preference.PrinterName, findUser.WorkPermitPrintPreference.PrinterName, "PrinterName");
            Assert.AreEqual(preference.NumberOfCopies, findUser.WorkPermitPrintPreference.NumberOfCopies, "NumberOfCopies");
            Assert.AreEqual(preference.ShowPrintDialog, findUser.WorkPermitPrintPreference.ShowPrintDialog, "ShowPrintDialog");
        }
        
        [Ignore] [Test]
        public void ShouldQueryByUserIdAndLoadExistingUserPreferences()
        {
            User user = dao.Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
            IUserPreferencesDao userPreferencesDao = DaoRegistry.GetDao<IUserPreferencesDao>();
            UserPreferences userPreferences = userPreferencesDao.Insert(new UserPreferences(null,user.Id.Value,1234));
            User retrievedUser = dao.QueryByUsername(user.Username);
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(retrievedUser.UserPreferences.UserId, retrievedUser.WorkPermitPrintPreference.UserId, "UserId");
            Assert.AreEqual(userPreferences.ActionItemDefinitionLastUsedWorkAssignmentId, retrievedUser.UserPreferences.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        [Ignore] [Test]
        public void ShouldInsertAUser()
        {
            User userToInsert = UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName());
            User insertedUser = dao.Insert(userToInsert);

            User retrievedUser = dao.QueryById(insertedUser.Id.Value);
            Assert.IsNotNull(retrievedUser);
        }

        [Ignore] [Test]
        public void ShouldUndoRemoveAUser()
        {
            User user = UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName());
            dao.Insert(user);
            long currentUserId = 6;
            dao.Remove(user, currentUserId);
            int count = TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format("select count(*) from [User] where id = {0} and deleted = 1 and LastModifiedUserId = {1}",
                                  user.Id, currentUserId));
            Assert.AreEqual(1, count);
            currentUserId = 7;
            dao.UndoRemove(user, currentUserId);
            count = TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format("select count(*) from [User] where id = {0} and deleted = 0 and LastModifiedUserId = {1}",
                                  user.Id, currentUserId));
            Assert.AreEqual(1, count);
        }

        [Ignore] [Test]
        public void ShouldUpdateAUser()
        {
            User userToUpdate = CreateUserToUpdate();
            User insertedUser = dao.Insert(userToUpdate);

            string username = userToUpdate.Username;
            userToUpdate = new User(
            insertedUser.Id.Value, username, "Mint", "Chutney", insertedUser.SiteRolePlants, "88888822", null, null, null, DateTimeFixture.DateTimeNow);
            dao.Update(userToUpdate);
            User updatedUserResult = dao.QueryByUsername(userToUpdate.Username);
            Assert.AreEqual("Mint", updatedUserResult.FirstName);
            Assert.AreEqual("Chutney", updatedUserResult.LastName);
            Assert.AreEqual("88888822", updatedUserResult.SAPId);
        }

        private static User CreateUserToUpdate()
        {
            User userToUpdate = UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName());
            return new User(UserFixture.CreateRandomUserName(), "Hooha", "Giggles", userToUpdate.SiteRolePlants, "7777", null, null, null, DateTimeFixture.DateTimeNow);
        }

        [Ignore] [Test]
        public void TestQueryForKnownTestUser()
        {
            User result = dao.QueryByUsername("oltuser1");
            Equals(1, result.Id);
            Equals("Homer", result.FirstName);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(NoDataFoundException))]
        public void TestQueryForNonExistentUser()
        {
            dao.QueryByUsername("a");
        }

        [Ignore] [Test]
        public void ShouldFindDeletedUserByUserName()
        {
            User user = CreateUserToUpdate();
            user = dao.Insert(user);

            {
                User queried = dao.QueryDeletedUserByUserName(user.Username);
                Assert.IsNull(queried);
            }

            dao.Remove(user, -1);

            {
                User queried = dao.QueryDeletedUserByUserName(user.Username);
                Assert.IsNotNull(queried);
                Assert.AreEqual(user.Id, queried.Id);
            }

            dao.UndoRemove(user, -1);

            {
                User queried = dao.QueryDeletedUserByUserName(user.Username);
                Assert.IsNull(queried);
            }
        }
    }
}