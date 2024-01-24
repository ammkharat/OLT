using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ObjectLockingServiceTest
    {
        private Mockery mocks;
        private IObjectLockDao mockObjectLockingDao;
        private IObjectLockingService objectLockingService;

        private readonly TestDomainObject testDomainObjectWithIdOfOne = new TestDomainObject(1);
        private readonly User userMickey = UserFixture.CreateOperatorMickeyInFortMcMurrySite();


        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockObjectLockingDao = mocks.NewMock<IObjectLockDao>();
            objectLockingService = new ObjectLockingService(mockObjectLockingDao);
        }

        [Ignore] [Test]
        public void GetLockShouldSimplyDelegateCallToTheDao()
        {
            string guid = Guid.NewGuid().ToString();
            var expectedLockResult = new ObjectLockResult(true, (long) userMickey.Id, new DateTime(2005, 11, 30));
            Expect.Once.On(mockObjectLockingDao).Method("GetLock").With(testDomainObjectWithIdOfOne, userMickey.Id, guid).Will(
                Return.Value(expectedLockResult));
            ObjectLockResult actualLockResult =
                objectLockingService.GetLock(testDomainObjectWithIdOfOne, (long)userMickey.Id, guid);
            Assert.AreEqual(expectedLockResult, actualLockResult);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ReleaseLockShouldSimplyDelegateCallToTheDao()
        {
            Expect.Once.On(mockObjectLockingDao).Method("ReleaseLock").With(testDomainObjectWithIdOfOne, userMickey.Id);
            objectLockingService.ReleaseLock(testDomainObjectWithIdOfOne, (long) userMickey.Id);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

    }


    internal class TestDomainObject : DomainObject
    {
        public TestDomainObject(long? id)
        {
            this.id = id;
        }
    }
}