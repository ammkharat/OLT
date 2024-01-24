using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitRadiationInformationTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsSealedSourceIsolationLOTO", true);
            TestHasData("IsSealedSourceIsolationOpen", true);
            TestHasData("SealedSourceIsolationNumberOfSources", TestUtil.RandomNumber());
        }

        private static void TestHasData(string propertyName, object dataValue)
        {
            var info = new WorkPermitRadiationInformation();
            Assert.IsFalse(info.HasData());
            TestUtil.SetProperty(info, propertyName, dataValue);
            Assert.IsTrue(info.HasData());
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesToFalseBasedOnSiteConfiguration()
        {
            TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(false);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesToTrueBasedOnSiteConfiguration()
        {
            TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(true);
        }

        private static void TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(bool workPermitNotApplicableAutoSelected)
        {
            var radiationInformation = new WorkPermitRadiationInformation();
            var siteConfiguration = SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);
            radiationInformation.InitializeWithSensibleDefaults(siteConfiguration);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, radiationInformation.IsSealedSourceIsolationNotApplicable);
        }
    }
}
