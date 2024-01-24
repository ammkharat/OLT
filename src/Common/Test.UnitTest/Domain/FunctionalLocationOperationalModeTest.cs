using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for FunctionalLocationOperationalModeTest
    /// </summary>
    [TestFixture]
    public class FunctionalLocationOperationalModeTest
    {
        [Test]
        public void ToStringShouldReturnTheNameOfTheOperationalModeSoItDisplaysProperlyInGrids()
        {
            Assert.AreEqual("Shut Down", OperationalMode.ShutDown.ToString());
        }
    }
}
