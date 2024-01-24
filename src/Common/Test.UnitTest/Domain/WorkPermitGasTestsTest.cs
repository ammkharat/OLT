using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitGasTestsTest
    {
        private WorkPermitGasTests workPermitGasTests;

        [SetUp]
        public void SetUp()
        {
            workPermitGasTests = new WorkPermitGasTests();
        }

        [Test]
        public void ShouldBeSerializable()
        {
            TestUtil.SerializeAndDeSerialize<WorkPermitGasTests>(workPermitGasTests);
        }

        [Test]
        public void ShouldBeDerivedFromDomainObject()
        {
            Assert.AreEqual(typeof(DomainObject), typeof(WorkPermitGasTests).BaseType);
        }

        [Test]
        public void ShouldInitializedWithEmptyElementListConstantMonitoringRequiredFalseAndEmptyFrequencyDuration()
        {
            Assert.AreEqual(0, workPermitGasTests.Elements.Count);
            Assert.AreEqual(string.Empty, workPermitGasTests.FrequencyOrDuration);
            Assert.AreEqual(false, workPermitGasTests.ConstantMonitoringRequired);
        }

        [Test]
        public void HasDataShouldDetectIfFrequencyOrDurationHasData()
        {
            WorkPermitGasTests gasTestSection = WorkPermitGasTestsWithNoData();
            gasTestSection.FrequencyOrDuration = TestUtil.RandomString();
            Assert.IsTrue(gasTestSection.HasData());
        }
        
        [Test]
        public void HasDataShouldDetectIfConstantMonitoringRequiredHasData()
        {
            WorkPermitGasTests gasTestSection = WorkPermitGasTestsWithNoData();
            gasTestSection.ConstantMonitoringRequired = true;
            Assert.IsTrue(gasTestSection.HasData());
        }

        [Test]
        public void HasDataShouldDetectIfTestTimeHasData()
        {
            WorkPermitGasTests gasTestSection = WorkPermitGasTestsWithNoData();
            gasTestSection.ImmediateAreaTestTime = new Time(08, 00);
            Assert.IsTrue(gasTestSection.HasData());

            gasTestSection = WorkPermitGasTestsWithNoData();
            gasTestSection.ConfinedSpaceTestTime = new Time(08, 00);
            Assert.IsTrue(gasTestSection.HasData());
        }

        [Test]
        public void HasDataShouldDetectIfAnyGasElementHasData()
        {
            WorkPermitGasTests gasTestSection = WorkPermitGasTestsWithNoData();

            // Add a gas test element that has data:
            GasTestElement element = new GasTestElement();
            element.ImmediateAreaTestResult = TestUtil.RandomDoubleNumber();
            Assert.IsTrue(element.HasData());
            gasTestSection.Elements.Add(element);

            Assert.IsTrue(gasTestSection.HasData(),
                "The whole gas test section should be deemed to have data because at least one element has data.");
        }

        [Test]
        public void ShouldBeAbleToCompareThemForEquality()
        {
            WorkPermitGasTests gasTests1 = new WorkPermitGasTests();
            WorkPermitGasTests gasTests2 = new WorkPermitGasTests();

            Assert.AreEqual(gasTests1, gasTests2);

            gasTests1.Elements.Add(new GasTestElement());

            Assert.AreNotEqual(gasTests1, gasTests2);
        }

        private WorkPermitGasTests WorkPermitGasTestsWithNoData()
        {
            WorkPermitGasTests gasTestSection = new WorkPermitGasTests();
            gasTestSection.Elements.Add(new GasTestElement());
            Assert.IsFalse(gasTestSection.HasData());
            return gasTestSection;
        }
    }
}
