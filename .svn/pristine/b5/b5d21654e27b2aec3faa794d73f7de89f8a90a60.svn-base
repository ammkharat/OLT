using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitCommunicationTest
    {
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

        [Test]
        public void IsRadioShouldReturnTrueOnlyIfCommunicationMethodIsApplicableAndByRadioHasTrueValue()
        {
            Assert.IsTrue(
                new WorkPermitCommunication {IsWorkPermitCommunicationNotApplicable = false, ByRadio = true}.IsRadio);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = true, ByRadio = true }.IsRadio);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = false, ByRadio = false }.IsRadio);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = true, ByRadio = false }.IsRadio);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = false, ByRadio = null }.IsRadio);
        }

        [Test]
        public void IsOtherShouldReturnTrueOnlyIfCommunicationMethodIsApplicableAndIsNotByRadio()
        {
            Assert.IsTrue(
                new WorkPermitCommunication {IsWorkPermitCommunicationNotApplicable = false, ByRadio = false}.IsOther);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = true, ByRadio = true }.IsOther);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = false, ByRadio = true }.IsOther);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = true, ByRadio = false }.IsOther);
            Assert.IsFalse(
                new WorkPermitCommunication { IsWorkPermitCommunicationNotApplicable = false, ByRadio = null }.IsOther);
        }

        private void TestInitializeWithSensibleDefaultsShouldSetNotApplicablePropertiesBasedOnSiteConfiguration(bool workPermitNotApplicableAutoSelected)
        {
            var communication = new WorkPermitCommunication();
            SiteConfiguration siteConfiguration =
                SiteConfigurationFixture.CreateWorkPermitNotApplicableAutoSelected(workPermitNotApplicableAutoSelected);
            communication.InitializeWithSensibleDefaults(siteConfiguration);

            Assert.AreEqual(workPermitNotApplicableAutoSelected, communication.IsWorkPermitCommunicationNotApplicable);
        }

    }
}