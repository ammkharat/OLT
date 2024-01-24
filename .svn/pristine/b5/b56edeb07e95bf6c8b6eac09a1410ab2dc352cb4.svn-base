using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitRespiratoryProtectionRequirementsTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsAirCartorAirLine", true);
            TestHasData("IsDustMask", true);
            TestHasData("IsSCBA", true);
            TestHasData("IsAirHood", true);
            TestHasData("IsHalfFaceRespirator", true);
            TestHasData("IsFullFaceRespirator", true);
            TestHasData("OtherDescription", TestUtil.RandomString());
            TestHasData("CartridgeTypeDescription", TestUtil.RandomString());
            TestHasData("CartridgeType", WorkPermitRespiratoryCartridgeType.AMMONIA);
//
//            TestHasData("IsOVAGHEPA", true);
//            TestHasData("IsOVAG", true);
//            TestHasData("IsHEPA", true);
//            TestHasData("IsAmmonia", true);
        }

        private void TestHasData(string propertyName, object dataValue)
        {
            WorkPermitRespiratoryProtectionRequirements requirements = new WorkPermitRespiratoryProtectionRequirements();
            Assert.IsFalse(requirements.HasData());
            TestUtil.SetProperty(requirements, propertyName, dataValue);
            Assert.IsTrue(requirements.HasData());
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

        private void TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(bool workPermitNotApplicableAutoSelected)
        {
            WorkPermitRespiratoryProtectionRequirements requirements = new WorkPermitRespiratoryProtectionRequirements();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);
            requirements.InitializeWithSensibleDefaults(siteConfiguration);

            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsNotApplicable);
        }
    }
}
