using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers
{
    [TestFixture]
    public class LanguageCodeTest
    {
        [Test]
        public void ShouldReturnEForNull()
        {
            Assert.AreEqual("en", LanguageCode.GetCultureInfoFromSAPALanguageCode(null).Name);
        }

        [Test]
        public void ShouldReturnEnglishForE()
        {
            var hopefullyEnglishCultureInfo = LanguageCode.GetCultureInfoFromSAPALanguageCode("E");
            Assert.AreEqual("en", hopefullyEnglishCultureInfo.Name);
        }

        [Test]
        public void ShouldReturnEnglishForEN()
        {
            var hopefullyEnglishCultureInfo = LanguageCode.GetCultureInfoFromSAPALanguageCode("EN");
            Assert.AreEqual("en", hopefullyEnglishCultureInfo.Name);
        }

        [Test]
        public void ShouldReturnFrenchForF()
        {
            var hopefullyFrenchCultureInfo = LanguageCode.GetCultureInfoFromSAPALanguageCode("F");
            Assert.AreEqual("fr", hopefullyFrenchCultureInfo.Name);
        }

        [Test]
        public void ShouldReturnFrenchForFR()
        {
            var hopefullyFrenchCultureInfo = LanguageCode.GetCultureInfoFromSAPALanguageCode("FR");
            Assert.AreEqual("fr", hopefullyFrenchCultureInfo.Name);
        }
    }
}