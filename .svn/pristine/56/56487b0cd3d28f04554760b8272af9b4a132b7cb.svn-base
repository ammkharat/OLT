using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture, Category("Unit")]
    public class ImmediateAreaGasTestResultValidationTest
    {
        [Test][Ignore]
        public void ShouldNotPassValidationIfElementIsOutsideofRange()
        {
            var gasTestElementInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            gasTestElementInfo.Id = 1;            

            var gasTestElement = new GasTestElement
                                     {
                                         ImmediateAreaTestRequired = true,
                                         ImmediateAreaTestResult = 110, // out of range from 50-75 value that is standard.
                                         ElementInfo = gasTestElementInfo
                                     };

            var validation = new ImmediateAreaGasTestResultValidation(SiteFixture.Sarnia(), gasTestElement, GasTestElementInfoFixture.SarniaStandardGasTestElementInfos);

            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermit(1);
            permit.WorkPermitType = WorkPermitType.COLD;
            permit.Attributes.IsConfinedSpaceEntry = false;
            permit.Attributes.IsInertConfinedSpaceEntry = false;
            bool result = validation.Evaluate(permit);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldPassValidationIfElementIsNotStandard()
        {
            var gasTestElementInfo = GasTestElementInfoFixture.CreateOtherElementInfo(100, SiteFixture.Sarnia());
            gasTestElementInfo.Id = 1;

            var gasTestElement = new GasTestElement
            {
                ImmediateAreaTestRequired = true,
                ImmediateAreaTestResult = 110, // out of range from 50-75 value, but this is non-standard so it does not matter.
                ElementInfo = gasTestElementInfo
            };

            var validation = new ImmediateAreaGasTestResultValidation(SiteFixture.Sarnia(), gasTestElement, GasTestElementInfoFixture.SarniaStandardGasTestElementInfos);

            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermit(1);
            permit.WorkPermitType = WorkPermitType.COLD;
            permit.Attributes.IsConfinedSpaceEntry = false;
            permit.Attributes.IsInertConfinedSpaceEntry = false;
            bool result = validation.Evaluate(permit);
            Assert.IsFalse(result);
            
        }

        [Test]
        public void ShouldPassValidationIfImmediateTestAreaNotRequired()
        {
            var gasTestElementInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            gasTestElementInfo.Id = 1;

            var gasTestElement = new GasTestElement
            {
                ImmediateAreaTestRequired = false,
                ImmediateAreaTestResult = 110, // out of range from 50-75 value, but this is non-standard so it does not matter.
                ElementInfo = gasTestElementInfo
            };

            var validation = new ImmediateAreaGasTestResultValidation(SiteFixture.Sarnia(), gasTestElement, GasTestElementInfoFixture.SarniaStandardGasTestElementInfos);

            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermit(1);
            permit.WorkPermitType = WorkPermitType.COLD;
            permit.Attributes.IsConfinedSpaceEntry = false;
            permit.Attributes.IsInertConfinedSpaceEntry = false;
            bool result = validation.Evaluate(permit);
            Assert.IsFalse(result);

        }
    }
}

