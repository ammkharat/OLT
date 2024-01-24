using Com.Suncor.Olt.Remote.Integration;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration
{
    [TestFixture]
    [Category("Integration")]
    public class SwipeCardReaderTest
    {
        [Ignore] [Test]
        public void ShouldGetSwipeCardDataFromService()
        {
            var reader = new EdmontonSwipeCardReader();
            var edmontonPersons = reader.GetCardsFromSwipeCardSystem(1);
            Assert.That(edmontonPersons, Is.Not.Null);
            Assert.That(edmontonPersons.Count, Is.GreaterThan(0));
        }
    }
}