using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class NullableDecimalFormaterTest
    {
        [Test]
        public void ShouldReturnEmptyStringIfValueIsNull()
        {
            decimal? nullValue = null;
            Assert.AreEqual(string.Empty, nullValue.Format());            
        }
        
        [Test]
        public void ShouldReturnValueAsStringIfValueIsNotNull()
        {
            decimal? decimalValue = new decimal?(67.24M);
            Assert.AreEqual("67.24", decimalValue.Format());
        }
    }
}
