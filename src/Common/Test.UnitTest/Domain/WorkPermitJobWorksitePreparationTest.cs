using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitJobWorksitePreparationTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsSewerIsolationMethodSealedOrCovered", true);
            TestHasData("IsSewerIsolationMethodPlugged", true);
            TestHasData("IsSewerIsolationMethodBlindedOrBlanked", true);
            TestHasData("SewerIsolationMethodOtherDescription", TestUtil.RandomString());
            TestHasData("IsAreaPreparationBarricade", true);
            TestHasData("IsAreaPreparationNonEssentialEvac", true);
            TestHasData("IsAreaPreparationBoundaryRopeTape", true);
            TestHasData("IsAreaPreparationRadiationRope", true);
            TestHasData("AreaPreparationOtherDescription", TestUtil.RandomString());
            TestHasData("IsLightingElectricalRequirementLowVoltage12V", true);
            TestHasData("IsLightingElectricalRequirement110VWithGFCI", true);
            TestHasData("IsLightingElectricalRequirementGeneratorLights", true);
            TestHasData("LightingElectricalRequirementOtherDescription", TestUtil.RandomString());
        }

        private static void TestHasData(string propertyName, object dataValue)
        {
            var preparation = new WorkPermitJobWorksitePreparation();
            Assert.IsFalse(preparation.HasData());
            TestUtil.SetProperty(preparation, propertyName, dataValue);
            Assert.IsTrue(preparation.HasData());
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
            var preparation = new WorkPermitJobWorksitePreparation();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);
            preparation.InitializeWithSensibleDefaults(siteConfiguration);

            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsAreaPreparationNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsBondingOrGroundingRequiredNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsCriticalConditionRemainJobSiteNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsFlowRequiredForJobNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsLightingElectricalRequirementNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsSewerIsolationMethodNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsVestedBuddySystemInEffectNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, preparation.IsWeldingGroundWireInTestAreaNotApplicable);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPropertiesToNullBasedOnSiteConfiguration()
        {
            var preparation = new WorkPermitJobWorksitePreparation();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitOptionAutoSelected(false);
            preparation.InitializeWithSensibleDefaults(siteConfiguration);
            
            Assert.IsNull(preparation.IsFlowRequiredForJob);
            Assert.IsNull(preparation.IsBondingOrGroundingRequired);
            Assert.IsNull(preparation.IsWeldingGroundWireInTestArea);
            Assert.IsNull(preparation.IsSurroundingConditionsAffectOrContaminated);
            Assert.IsNull(preparation.IsVestedBuddySystemInEffect);
            Assert.IsNull(preparation.IsCriticalConditionRemainJobSite);
            Assert.IsNull(preparation.IsPermitReceiverFieldOrEquipmentOrientation);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPropertiesToDefaultBasedOnSiteConfiguration()
        {
            var preparation = new WorkPermitJobWorksitePreparation();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitOptionAutoSelected(true);
            preparation.InitializeWithSensibleDefaults(siteConfiguration);

            Assert.IsFalse(preparation.IsFlowRequiredForJob.Value);
            Assert.IsTrue(preparation.IsBondingOrGroundingRequired.Value);
            Assert.IsTrue(preparation.IsWeldingGroundWireInTestArea.Value);
            Assert.IsFalse(preparation.IsSurroundingConditionsAffectOrContaminated.Value);
            Assert.IsFalse(preparation.IsVestedBuddySystemInEffect.Value);
            Assert.IsFalse(preparation.IsCriticalConditionRemainJobSite.Value);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetPropertiesNotApplicableToSarniaToNullOrFalse()
        {
            var preparation = new WorkPermitJobWorksitePreparation();
            preparation.InitializeWithSensibleDefaults(SiteConfigurationFixture.CreateWorkPermitOptionAutoSelected(false));

            // LightingElectrical is not applicable to Sarnia
            Assert.IsFalse(preparation.IsLightingElectricalRequirementNotApplicable);
            Assert.IsNull(preparation.LightingElectricalRequirementOtherDescription);
            Assert.IsFalse(preparation.IsLightingElectricalRequirementGeneratorLights);
            Assert.IsFalse(preparation.IsLightingElectricalRequirement110VWithGFCI);
            Assert.IsFalse(preparation.IsLightingElectricalRequirementLowVoltage12V);

            // Non-Essential Evac is not applicable to Sarnia
            Assert.IsFalse(preparation.IsAreaPreparationNonEssentialEvac);

            // Flow is not applicable to Sarnia
            Assert.IsFalse(preparation.IsFlowRequiredForJobNotApplicable);
            Assert.IsNull(preparation.IsFlowRequiredForJob);
            Assert.IsNull(preparation.FlowRequiredComments);
        }
    }
}
