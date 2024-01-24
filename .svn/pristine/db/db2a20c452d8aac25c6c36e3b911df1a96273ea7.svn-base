using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class UserWorkPermitDefaultTimePreferencesDaoTest : AbstractDaoTest
    {
        private IUserWorkPermitDefaultTimePreferencesDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IUserWorkPermitDefaultTimePreferencesDao>();
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void QueryByUserIdShouldReturnTheCorrespondingUserPreference()
        {
            UserWorkPermitDefaultTimePreferences userWorkPermitDefaultTimePreferences = dao.QueryByUserId(1);
            Assert.IsNotNull(userWorkPermitDefaultTimePreferences);
        }

        [Ignore] [Test]
        public void InsertShouldInsertUserIdAndTimePadding()
        {
            UserWorkPermitDefaultTimePreferences preferences =
                new UserWorkPermitDefaultTimePreferences(3, new TimeSpan(01, 02, 03), new TimeSpan(04, 05, 06));
            dao.Insert(preferences);
            UserWorkPermitDefaultTimePreferences savedPreferences = dao.QueryByUserId(3);

            Assert.AreEqual(3, savedPreferences.UserId);
            Assert.AreEqual(new TimeSpan(01, 02, 03), savedPreferences.PreShiftPadding);
            Assert.AreEqual(new TimeSpan(04, 05, 06), savedPreferences.PostShiftPadding);
        }

        [Ignore] [Test]
        public void InsertShouldInsertWithNewId()
        {
            UserWorkPermitDefaultTimePreferences preferences = 
                    new UserWorkPermitDefaultTimePreferences(3, new TimeSpan(), new TimeSpan());
            dao.Insert(preferences);
            UserWorkPermitDefaultTimePreferences savedPreferences = dao.QueryByUserId(3);

            Assert.IsNotNull(savedPreferences.Id);
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkPermitDefaultTimePreferences()
        {
            UserWorkPermitDefaultTimePreferences preferences = dao.QueryByUserId(1);
            preferences.PreShiftPadding = Change(preferences.PreShiftPadding);
            preferences.PostShiftPadding = Change(preferences.PostShiftPadding);
            dao.Update(preferences);
            UserWorkPermitDefaultTimePreferences savedPreferences = dao.QueryByUserId(1);
            Assert.AreEqual(preferences, savedPreferences);
        }

        private static TimeSpan Change(TimeSpan timeSpan)
        {
            return timeSpan.Add(new TimeSpan(00, 01, 00));
        }
    }
}