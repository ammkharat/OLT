using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class IntExtensionsTest
    {
        [Test]
        public void ShouldDisplayAsPercentWithCorrectRoundingDown()
        {
            Assert.That(17, Is.EqualTo(390.ToPercent(2240)));
        }

        [Test]
        public void ShouldDisplayAsPercentWithCorrectRoundingUp()
        {
            Assert.That(83, Is.EqualTo(1850.ToPercent(2240)));
        }
    }
}