using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class FunctionalLocationModeTest
    {
        [Test]
        public void ShouldGetModeForItemsForMontreal()
        {
            Site montreal = SiteFixture.Montreal();

            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(montreal);
            FunctionalLocationMode functionalLocationMode = FunctionalLocationMode.GetLevelTwoAndBelow(siteConfiguration);

            Assert.That(functionalLocationMode.AllowedTypes.Contains(FunctionalLocationType.Level7));
        }

        [Test]
        public void ShouldGetLevelTwoAndBelow()
        {
            Site montreal = SiteFixture.Montreal();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(montreal);
            FunctionalLocationMode mode = FunctionalLocationMode.GetLevelTwoAndBelow(siteConfiguration);
            Assert.That(mode.AllowedTypes.Contains(FunctionalLocationType.Level7));
        }
    }
}