using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class NullableDoubleFormaterTest
    {
        [Test]
        public void ShouldReturnEmptyStringIfValueIsNull()
        {
            double? nullValue = null;
            Assert.AreEqual(string.Empty, nullValue.Format());            
        }
        
        [Test]
        public void ShouldReturnValueAsStringIfValueIsNotNull()
        {
            double? doubleValue = new double?(67.24);
            Assert.AreEqual("67.24", doubleValue.Format());
        }
    }
}
