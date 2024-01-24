using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class WorkPermitAttributesParseUtilityTest
    {
        [Test]
        public void ShouldParseNewStyleString()
        {
            string[] attributeArray = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"AA\AB\AC\AD\");
            List<string> attributeList = new List<string>(attributeArray);
            Assert.AreEqual(4, attributeList.Count);
            Assert.Contains("AA", attributeList);
            Assert.Contains("AB", attributeList);
            Assert.Contains("AC", attributeList);
            Assert.Contains("AD", attributeList);
        }

        [Test]
        public void ShouldParseNewStyleString_NoTrailingSlash()
        {
            string[] attributeArray = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"AA\AB\AC\AD");
            List<string> attributeList = new List<string>(attributeArray);
            Assert.AreEqual(4, attributeList.Count);
            Assert.Contains("AA", attributeList);
            Assert.Contains("AB", attributeList);
            Assert.Contains("AC", attributeList);
            Assert.Contains("AD", attributeList);
        }

        [Test]
        public void ShouldParseOldStyleString()
        {
            string[] attributeArray = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"ABCD");
            List<string> attributeList = new List<string>(attributeArray);
            Assert.AreEqual(4, attributeList.Count);
            Assert.Contains("A", attributeList);
            Assert.Contains("B", attributeList);
            Assert.Contains("C", attributeList);
            Assert.Contains("D", attributeList);
        }
    }
}
