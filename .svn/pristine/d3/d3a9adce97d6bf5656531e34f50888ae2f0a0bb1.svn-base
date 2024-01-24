using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ObjectLockDaoTest : AbstractDaoTest
    {
        IObjectLockDao dao;
        readonly TestDomainObject testDomainObjectWithIdOfOne = new TestDomainObject(1);
        readonly TestDomainObject testDomainObjectWithIdOfTwo = new TestDomainObject(2);
        readonly AnotherTestDomainObject anotherTestDomainObjectWithIdOfOne = new AnotherTestDomainObject(1);

        readonly User userMickey = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
        readonly User userGoofey = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
        string guid;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IObjectLockDao>();
            guid = Guid.NewGuid().ToString();
        }

        protected override void Cleanup()
        {
            dao.ReleaseAllLocks();
        }

        [Ignore] [Test]
        public void ASuccessfullLockRequestShouldReturnALockResultContainingTheUsersId()
        {
            ObjectLockResult lockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.IsTrue(lockResult.Succeeded);
            Assert.AreEqual(userMickey.Id, lockResult.LockedByUserId);
        }

        [Ignore] [Test]
        public void ASuccessfulLockShouldPersistALockInTheDatabase()
        {
            ObjectLockResult lockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.IsTrue(dao.IsLocked(testDomainObjectWithIdOfOne));
        }

        [Ignore] [Test]
        public void IsLockedShouldReturnFalseIfNoLockWasRequestedForAnObject()
        {
            Assert.IsFalse(dao.IsLocked(testDomainObjectWithIdOfOne));
        }

        [Ignore] [Test]
        public void AttemptToGetALockByASecondUserShouldFail()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.IsTrue(mickeyLockResult.Succeeded);
            ObjectLockResult goofyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userGoofey.Id, guid);
            Assert.IsFalse(goofyLockResult.Succeeded);
        }

        [Ignore] [Test]
        public void AFailedLockAttemptShouldReturnALockResultWithTheUserIdOfTheUserThatSuccessfullyObtainedTheLock()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            ObjectLockResult goofyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userGoofey.Id, guid);
            Assert.IsFalse(goofyLockResult.Succeeded);
            Assert.AreEqual(userMickey.Id, goofyLockResult.LockedByUserId);
        }

        [Ignore] [Test]
        public void ReleasingALockShouldMakeItPossibleForAnotherUserToSuccessfullyGetALockForThatObject()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            ObjectLockResult goofyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userGoofey.Id, guid);
            Assert.IsFalse(goofyLockResult.Succeeded);
            dao.ReleaseLock(testDomainObjectWithIdOfOne, (long)userMickey.Id);
            goofyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userGoofey.Id, guid);
            Assert.IsTrue(goofyLockResult.Succeeded);
        }

        [Ignore] [Test]
        public void ShouldNotThrowExceptionIfReleaseLockCannotFindTheLock()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            dao.ReleaseLock(testDomainObjectWithIdOfOne, (long)userGoofey.Id);
        }

        [Ignore] [Test]
        public void TwoUsersShouldBeAbleToLockTwoObjectsOfTheSameClassWithDifferentIds()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.IsTrue(mickeyLockResult.Succeeded);

            ObjectLockResult goofyLockResult = dao.GetLock(testDomainObjectWithIdOfTwo, (long)userGoofey.Id, guid);
            Assert.IsTrue(goofyLockResult.Succeeded);
        }

        [Ignore] [Test]
        public void TwoUsersShouldBeAbleToLockTwoObjectsWithTheSameIdsButDifferentClasses()
        {
            ObjectLockResult mickeyLockResult = dao.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.IsTrue(mickeyLockResult.Succeeded);

            ObjectLockResult goofyLockResult = dao.GetLock(anotherTestDomainObjectWithIdOfOne, (long)userGoofey.Id, guid);
            Assert.IsTrue(goofyLockResult.Succeeded);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(LockException))]
        public void ExceptionShouldBeThrownIfAttemptToGetLockForDomainObjectWithANullId()
        {
            TestDomainObject objectWithNullId = new TestDomainObject(null);
            dao.GetLock(objectWithNullId, (long)userMickey.Id, guid);
        }

    }

    class TestDomainObject : DomainObject
    {
        public TestDomainObject(long? id)
        {
            this.id = id;
        }
    }

    class AnotherTestDomainObject : DomainObject
    {
        public AnotherTestDomainObject(long id)
        {
            this.id = id;
        }
    }
}
