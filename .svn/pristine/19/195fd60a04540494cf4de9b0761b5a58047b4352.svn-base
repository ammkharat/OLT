using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class UserPreferencesDaoTest : AbstractDaoTest
    {
        private User user;
        private UserPreferences preferencesToInsert;
        private UserPreferences dataBasePreferences;
        private IUserPreferencesDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IUserPreferencesDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
            user.Id = 2222;
            preferencesToInsert = new UserPreferences(1111,user.Id.Value,3333);
        }

        protected override void Cleanup()
        {
            //do nothing
        }

        private void InsertUserPreferencesIntoDatabase()
        {
            dataBasePreferences = dao.Insert(preferencesToInsert);
        }

        [Ignore] [Test]
        public void ShouldInsertUserPreferences()
        {
            InsertUserPreferencesIntoDatabase();
            Assert.IsNotNull(dataBasePreferences);
            UserPreferences found = dao.QueryByUserId(user.IdValue);
            Assert.AreEqual(found.UserId, dataBasePreferences.UserId);
            Assert.AreEqual(found.ActionItemDefinitionLastUsedWorkAssignmentId, dataBasePreferences.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        [Ignore] [Test]
        public void ShouldUpdateUserPreferences()
        {
            const long actionItemDefinitionLastUsedWorkAssignmentId = 9999;
            InsertUserPreferencesIntoDatabase();
            dataBasePreferences.ActionItemDefinitionLastUsedWorkAssignmentId = actionItemDefinitionLastUsedWorkAssignmentId;
            dao.Update(dataBasePreferences);
            UserPreferences found = dao.QueryByUserId(user.IdValue);
            Assert.AreEqual(actionItemDefinitionLastUsedWorkAssignmentId, found.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        [Ignore] [Test]
        public void ShouldQueryByUserId()
        {
            InsertUserPreferencesIntoDatabase();
            UserPreferences found = dao.QueryByUserId(user.IdValue);
            Assert.IsNotNull(found);
            Assert.AreEqual(dataBasePreferences.Id, found.Id);
            Assert.AreEqual(dataBasePreferences.UserId, found.UserId);
            Assert.AreEqual(dataBasePreferences.ActionItemDefinitionLastUsedWorkAssignmentId, found.ActionItemDefinitionLastUsedWorkAssignmentId);
        }

        [Ignore] [Test]
        public void ShouldRemoveUserPrintPreference()
        {
            InsertUserPreferencesIntoDatabase();
            dao.Remove(dataBasePreferences);
            int count = TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format("select count(*) from [UserPreferences] where id = {0}", dataBasePreferences.Id));
            Assert.IsTrue(count == 0);
        }
    }
}