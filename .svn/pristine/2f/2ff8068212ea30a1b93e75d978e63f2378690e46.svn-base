using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class LogReadTest
    {
        [Test]
        public void Initialize()
        {
            Log log = LogFixture.CreateLogItemCreatedByUserWithSpecificId(42, UserFixture.CreateOperator());
            User readByUser = UserFixture.CreateUserWithGivenId(100);

            LogRead logRead = new LogRead(log, readByUser, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(log.Id.Value, logRead.LogId);
            Assert.AreEqual(readByUser.Id.Value, logRead.ReadByUserId);
        }

        [Test]
        public void MustBeSerializeable()
        {
            Assert.IsTrue(typeof(LogRead).IsSerializable);
        }

        [Test]
        public void MustBeDerivedFromDomanObject()
        {
            LogRead logRead = new LogRead(1, 42, DateTimeFixture.DateTimeNow);
            Assert.IsTrue(logRead is DomainObject);
        }
    }
}
