using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for PriorityTest
    /// </summary>
    [TestFixture]
    public class PriorityTest
    {
        [Test]
        public void ToStringShouldReturnNormalForANormalPrioritySoThatItDisplaysProperlyOnEditHistory()
        {
            Assert.AreEqual("Normal", Priority.Normal.ToString());
        }

        [Test]
        public void ToStringShouldReturnElevatedForAnElevatedPrioritySoThatItDisplaysProperlyOnEditHistory()
        {
            Assert.AreEqual("Elevated", Priority.Elevated.ToString());
        }

        [Test]
        public void ToStringShouldReturnHighForAHighPrioritySoThatItDisplaysProperlyOnEditHistory()
        {
            Assert.AreEqual("High", Priority.High.ToString());
        }
    }
}
