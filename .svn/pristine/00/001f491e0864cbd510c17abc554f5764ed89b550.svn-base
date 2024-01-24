using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class UserSpecifiedCraftOrTradeTest
    {
        [Test]
        public void ShouldMakeCopyOfUserSpecifiedCraftOrTrade()
        {
            UserSpecifiedCraftOrTrade original = new UserSpecifiedCraftOrTrade("some name");
            ICraftOrTrade copy = original.Copy();

            Assert.AreNotSame(original, copy);
            Assert.AreEqual(original.Name, copy.Name);
        }
    }
}
