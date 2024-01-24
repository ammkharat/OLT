using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class LogReadByTest
    {
        [Test]
        public void Initialize()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            ItemReadBy itemReadBy = new ItemReadBy("Simpson, Bart [oltuser2]", now);
            Assert.AreEqual(now, itemReadBy.DateTime);
            Assert.AreEqual("Simpson, Bart [oltuser2]", itemReadBy.UserFullNameWithUserName);
        }

        [Test]
        public void MustBeSerializeable()
        {
            Assert.IsTrue(typeof(ItemReadBy).IsSerializable);
        }

        [Test]
        public void MustBeDerivedFromDomanObject()
        {
            ItemReadBy itemReadBy = new ItemReadBy("Simpson, Bart [oltuser2]", DateTimeFixture.DateTimeNow); 
            Assert.IsTrue(itemReadBy is DomainObject);
        }
    }
}
