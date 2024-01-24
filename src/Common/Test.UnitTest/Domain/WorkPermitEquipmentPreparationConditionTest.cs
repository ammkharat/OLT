using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitEquipmentPreparationConditionTest
    {
        [Test]
        public void ShouldDetermineIfHasData()
        {
            TestHasData("IsConditionDepressured", true);
            TestHasData("IsConditionDrained", true);
            TestHasData("IsConditionCleaned", true);
            TestHasData("IsConditionVentilated", true);
            TestHasData("IsConditionH20Washed", true);
            TestHasData("IsConditionNeutralized", true);
            TestHasData("IsConditionPurged", true);
            TestHasData("ConditionPurgedDescription", TestUtil.RandomString());
            TestHasData("IsConditionPurgedN2", true);
            TestHasData("IsConditionPurgedSteamed", true);
            TestHasData("IsConditionPurgedAir", true);
            TestHasData("ConditionOtherDescription", TestUtil.RandomString());
            TestHasData("IsPreviousContentsHydrocarbon", true);
            TestHasData("IsPreviousContentsAcid", true);
            TestHasData("IsPreviousContentsCaustic", true);
            TestHasData("IsPreviousContentsH2S", true);
            TestHasData("PreviousContentsOtherDescription", TestUtil.RandomString());
            TestHasData("IsIsolationMethodBlindedorBlanked", true);
            TestHasData("IsIsolationMethodSeparation", true);
            TestHasData("IsIsolationMethodMudderPlugs", true);
            TestHasData("IsIsolationMethodBlockedIn", true);
            TestHasData("IsIsolationMethodCarBer", true);
            TestHasData("IsolationMethodOtherDescription", TestUtil.RandomString());
            TestHasData("IsElectricalIsolationMethodLOTO", true);
            TestHasData("IsElectricalIsolationMethodWiring", true);
            TestHasData("IsVentilationMethodNaturalDraft", true);
            TestHasData("IsVentilationMethodLocalExhaust", true);
            TestHasData("IsVentilationMethodForced", true);
        }

        private void TestHasData(string propertyName, object dataValue)
        {
            WorkPermitEquipmentPreparationCondition equipment = new WorkPermitEquipmentPreparationCondition(
                SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(false), SiteSpecificHandlerFactory.GetDateTimeHandler(SiteFixture.Sarnia()));    // TODO: The site doesn't really match the fixture.

            // TODO: The site doesn't really match the fixture.
            Assert.IsFalse(equipment.HasData());
            TestUtil.SetProperty(equipment, propertyName, dataValue);
            Assert.IsTrue(equipment.HasData());
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
            SiteConfiguration siteConfiguration =
                SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);

            // TODO: The site doesn't really match the fixture.
            WorkPermitEquipmentPreparationCondition equipment = new WorkPermitEquipmentPreparationCondition(
                siteConfiguration, SiteSpecificHandlerFactory.GetDateTimeHandler(SiteFixture.Sarnia()));    

            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsConditionNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsElectricalIsolationMethodNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsIsolationMethodNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsLeakingValvesNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsPreviousContentsNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsStillContainsResidualNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsTestBumpNotApplicable);
            Assert.AreEqual(workPermitNotApplicableAutoSelected, equipment.IsVentilationMethodNotApplicable);
        }

        [Test]
        public void InitializeWithSensibleDefaultsShouldSetEquipmentOptionsToNullIfNotAutoSelected()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateWorkPermitOptionAutoSelected(false);
            WorkPermitEquipmentPreparationCondition equipment = new WorkPermitEquipmentPreparationCondition(
                siteConfiguration, SiteSpecificHandlerFactory.GetDateTimeHandler(SiteFixture.Sarnia()));  // TODO: The site doesn't really match the fixture.
            
            Assert.IsNull(equipment.IsTestBump);
            Assert.IsNull(equipment.IsOutOfService);
            Assert.IsNull(equipment.IsStillContainsResidual);
            Assert.IsNull(equipment.IsLeakingValves);
        }
    }
}