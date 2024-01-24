using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class EdmontonPermitSpecialWorkTypeTest
    {
        [Test]
        public void ShouldKnowIfContinuousGasMonitorIsRequired()
        {
            Assert.IsTrue(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.HotTapping));
            Assert.IsTrue(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.PowderActuatedTool));
            Assert.IsTrue(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.OnstreamLeakSealing));
            Assert.IsTrue(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.HighVoltageElectricalWork));

            Assert.IsFalse(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.RadiographyInspections));
            Assert.IsFalse(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.DivingOperations));
            Assert.IsFalse(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.Excavation));
            Assert.IsFalse(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.TransaltaUtilityWork));
            Assert.IsFalse(EdmontonPermitSpecialWorkType.ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType.FreezePlug));                                                                                          
        }
    }
}
