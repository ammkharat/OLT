using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class DecimalExtensionsTest
    {
        [Test]
        public void ShouldFormatCanadianFrenchDecimalProperly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-CA");
            Assert.That(123456.45m.Format(), Is.EqualTo("123\u00A0456,45"));
        }        

        [Test]
        public void ShouldFormatGenericFrenchDecimalProperly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr");
            string result = 123456.45m.Format();
            string expected = "123\u00A0456,45";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test][Ignore]
        public void ShouldFormatGenericFrenchCurrencyProperly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr");
            Assert.That(123456.45m.ToCurrency(), Is.EqualTo("123\u00A0456,45 €"));
        }

        [Test][Ignore]
        public void ShouldFormatGenericCanadianFrenchCurrencyProperly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-CA");
            Assert.That(123456.45m.ToCurrency(), Is.EqualTo("123\u00A0456,45 $"));
        }

        [Test]
        public void ShouldParseDecimalStringToDecimal()
        {
            decimal? result = "123456.5".ParseOrNull();
            Assert.That(result, Is.EqualTo(123456.5m));
        }

        [Test]
        public void ShouldParseNonDecimalStringToNull()
        {
            decimal? result = "123456f.5".ParseOrNull();
            Assert.That(result, Is.Null);
        }
    }
}