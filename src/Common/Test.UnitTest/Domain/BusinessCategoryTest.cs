using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class BusinessCategoryTest
    {
        [Test]
        public void ToStringShouldReturnTheNameOfTheCategorySoItDisplaysProperlyInGrids()
        {
            Assert.AreEqual("Environmental / Safety", BusinessCategoryFixture.GetEnvironmentalSafetyCategory().ToString());
        }
    }
}
