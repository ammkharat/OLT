using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for SiteTest
    /// </summary>
    [TestFixture]
    public class SiteTest
    {
        [Test]
        public void SarniaSiteShouldReturnTheESTTimeZone()
        {
            Assert.AreEqual("Eastern Standard Time", SiteFixture.Sarnia().TimeZone.Id);
        }

        [Test]
        public void DenverSiteShouldReturnTheMSTTimeZone()
        {
            Assert.AreEqual("Mountain Standard Time", SiteFixture.Denver().TimeZone.Id);
        }

        [Test]
        public void OilSandsShouldReturnTheMSTTimeZone()
        {
            Assert.AreEqual("Mountain Standard Time", SiteFixture.Oilsands().TimeZone.Id);
        }
    }
}
