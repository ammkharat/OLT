using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitSpecialPPERequirementsTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsEyeOrFaceProtectionGoggles", true);
            TestHasData("IsEyeOrFaceProtectionFaceshield", true);
            TestHasData("EyeOrFaceProtectionOtherDescription", TestUtil.RandomString());
            
            TestHasData("IsProtectiveClothingTypeRainCoat", true);
            TestHasData("IsProtectiveClothingTypeRainPants", true);
            TestHasData("IsProtectiveClothingTypeAcidClothing", true);
            TestHasData("IsProtectiveClothingTypeCausticWear", true);
            TestHasData("IsProtectiveClothingTypePaperCoveralls", true);
            TestHasData("IsProtectiveClothingTypeTyvekSuit", true);
            TestHasData("IsProtectiveClothingTypeKapplerSuit", true);
            TestHasData("IsProtectiveClothingTypeElectricalFlashGear", true);
            TestHasData("IsProtectiveClothingTypeCorrosiveClothing", true);
            TestHasData("ProtectiveClothingTypeOtherDescription", TestUtil.RandomString());

            TestHasData("IsProtectiveFootwearChemicalImperviousBoots", true);
            TestHasData("IsProtectiveFootwearToeGuard", true);
            TestHasData("ProtectiveFootwearOtherDescription", TestUtil.RandomString());

            TestHasData("IsHandProtectionChemicalNeoprene", true);
            TestHasData("IsHandProtectionNaturalRubber", true);
            TestHasData("IsHandProtectionNitrile", true);
            TestHasData("IsHandProtectionPVC", true);
            TestHasData("IsHandProtectionHighVoltage", true);
            TestHasData("IsHandProtectionLeather", true);
            TestHasData("IsHandProtectionWelding", true);
            TestHasData("IsHandProtectionChemicalGloves", true);
            TestHasData("HandProtectionOtherDescription", TestUtil.RandomString());

            TestHasData("IsRescueOrFallBodyHarness", true);
            TestHasData("IsRescueOrFallLifeline", true);
            TestHasData("IsRescueOrFallYoYo", true);
            TestHasData("IsRescueOrFallRescueDevice", true);
            TestHasData("RescueOrFallOtherDescription", TestUtil.RandomString());
        }

        private static void TestHasData(string propertyName, object dataValue)
        {
            var requirements = new WorkPermitSpecialPPERequirements();
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

        private static void TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(bool workPermitNotApplicableAutoSelected)
        {
            var requirements = new WorkPermitSpecialPPERequirements();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);
            requirements.InitializeWithSensibleDefaults(siteConfiguration);

            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsEyeOrFaceProtectionNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsProtectiveClothingTypeNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsProtectiveFootwearNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsHandProtectionNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, requirements.IsRescueOrFallNotApplicable);
        }
    }
}
