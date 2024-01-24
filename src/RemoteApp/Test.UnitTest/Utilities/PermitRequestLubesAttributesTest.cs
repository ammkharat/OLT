using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class PermitRequestLubesAttributesTest
    {       
        [Ignore] [Test]
        public void ShouldHandleVariousRandomAttributes()
        {
            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateEmptyPermitRequest();

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"LA\LB\LU\LV");
            
            PermitRequestLubesAttributes atts = new PermitRequestLubesAttributes(attribs);

            atts.SetAttributesOnPermitRequest(permitRequest);

            Assert.IsTrue(permitRequest.ConfinedSpace);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EntryAndControlPlan);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, permitRequest.EnergizedElectrical);
            Assert.IsTrue(permitRequest.HydrantPermit);
            Assert.IsFalse(permitRequest.HazardOxygenDeficiency);
            Assert.IsFalse(permitRequest.HazardRadioactiveSources);
            Assert.IsFalse(permitRequest.HazardUndergroundOverheadHazards);
            Assert.IsFalse(permitRequest.FireWatch);
        }
    }
}
