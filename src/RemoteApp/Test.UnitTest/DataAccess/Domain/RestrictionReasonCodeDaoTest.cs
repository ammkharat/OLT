using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class RestrictionReasonCodeDaoTest : AbstractDaoTest
    {
        private IRestrictionReasonCodeDao dao;

        protected override void TestInitialize()
        {            
            dao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void InsertShouldInsert()
        {
            const string expectedName = "TEST CODE 1";
            User expectedLastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            DateTime expectedLastModifiedDate = DateTimeFixture.DateTimeNow;

            RestrictionReasonCode restrictionReasonCode =
                new RestrictionReasonCode(expectedName, expectedLastModifiedBy, expectedLastModifiedDate, 0);    //ayman restriction reason codes
            
            dao.Insert(restrictionReasonCode);

            Assert.IsNotNull(restrictionReasonCode.Id);

            RestrictionReasonCode queriedResult = dao.QueryById(restrictionReasonCode.Id.Value);
            Assert.IsNotNull(queriedResult);
            Assert.AreEqual(expectedName, restrictionReasonCode.Name);            
            Assert.AreEqual(expectedLastModifiedBy.Id, restrictionReasonCode.LastModifiedBy.Id);                        
            Assert.AreEqual(expectedLastModifiedDate, restrictionReasonCode.LastModifiedDate);
            Assert.IsFalse(restrictionReasonCode.Deleted);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            // Insert
            const string originalName = "TEST CODE 2";
            User originalLastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            DateTime originalLastModifiedDate = DateTimeFixture.DateTimeNow;

            RestrictionReasonCode restrictionReasonCode = new RestrictionReasonCode(originalName, originalLastModifiedBy, originalLastModifiedDate, 0);            //ayman restriction reason codes            
            dao.Insert(restrictionReasonCode);

            // Query and change
            RestrictionReasonCode queriedResult = dao.QueryById(restrictionReasonCode.IdValue);
            
            const string newName = "TEST CODE 123";
            DateTime newLastModifiedDate = originalLastModifiedDate.AddHours(1);

            queriedResult.Name = newName;
            queriedResult.LastModifiedBy = UserFixture.CreateUserWithGivenId(2);
            queriedResult.LastModifiedDate = newLastModifiedDate;

            dao.Update(queriedResult);

            // Query and Check
            RestrictionReasonCode updatedResult = dao.QueryById(restrictionReasonCode.IdValue);
            Assert.AreEqual(newName, updatedResult.Name);
            Assert.AreEqual(2, updatedResult.LastModifiedBy.Id);
            Assert.That(newLastModifiedDate, Is.EqualTo(updatedResult.LastModifiedDate).Within(new TimeSpan(0, 0, 2)));
            Assert.AreEqual(newLastModifiedDate.Year, updatedResult.LastModifiedDate.Year);
            Assert.AreEqual(newLastModifiedDate.Month, updatedResult.LastModifiedDate.Month);
            Assert.AreEqual(newLastModifiedDate.Day, updatedResult.LastModifiedDate.Day);
            Assert.AreEqual(newLastModifiedDate.Minute, updatedResult.LastModifiedDate.Minute);

        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            // Insert
            const string originalName = "TEST CODE 3";
            User originalLastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            DateTime originalLastModifiedDate = DateTimeFixture.DateTimeNow;

            RestrictionReasonCode restrictionReasonCode = new RestrictionReasonCode(originalName, originalLastModifiedBy, originalLastModifiedDate, 0);    //ayman restriction reason codes
            dao.Insert(restrictionReasonCode);

            // Query and Remove
            DateTime newLastModifiedDate = originalLastModifiedDate.AddDays(1);
            User newLastModifiedUser = UserFixture.CreateUserWithGivenId(2);

            RestrictionReasonCode queriedResult = dao.QueryById(restrictionReasonCode.IdValue);
            queriedResult.LastModifiedBy = newLastModifiedUser;
            queriedResult.LastModifiedDate = newLastModifiedDate;
            Assert.IsFalse(queriedResult.Deleted);
            dao.Remove(queriedResult);
            
            // Query and Check
            RestrictionReasonCode removed = dao.QueryById(restrictionReasonCode.IdValue);
            Assert.IsTrue(removed.Deleted);            
            Assert.That(removed.LastModifiedDate, Is.EqualTo(newLastModifiedDate).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(newLastModifiedUser.Id, removed.LastModifiedBy.Id);
        }
    }
}