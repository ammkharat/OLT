using Com.Suncor.Olt.Common.Domain.Target;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for TargetCategoryTest
    /// </summary>
    [TestFixture]
    public class TargetCategoryTest
    {
        [Test]
        public void ToStringShouldReturnAFriendlyValueForDisplayInEditHistory()
        {
            Assert.AreEqual("Production", TargetCategory.PRODUCTION.ToString());
        }
    }
}
