using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Integration
{
    [TestFixture]
    public class EdmontonSwipeCardReaderTest
    {
        [Ignore] [Test]
        public void ShouldParseUtcDateProperlyFromTheService()
        {
            var userCardData = new UserCardData
            {
                FirstName = "LARRY",
                LastName = "MOE",
                Identifier = "90210",
                LastAccessDateTime = "2014-08-06T17:00:00-06:00",
                LastDoorName = "PC-IN",
            };

            var edmontonPerson = new EdmontonSwipeCardReader().CreateIfIsValid(userCardData);

            Assert.AreEqual(new DateTime(2014, 8, 6, 11, 0, 0), edmontonPerson.LastScan);
        }
    }
}