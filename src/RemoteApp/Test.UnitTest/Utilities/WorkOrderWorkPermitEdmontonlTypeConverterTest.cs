using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class WorkOrderWorkPermitEdmontonTypeConverterTest
    {
        [Ignore] [Test]
        public void ShouldReturnColdPermitTypeForColdCode()
        {
            Assert.AreEqual(WorkPermitEdmontonType.ROUTINE_MAINTENANCE, WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType("7"));
            Assert.AreEqual(WorkPermitEdmontonType.COLD_WORK, WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType("8"));
            Assert.AreEqual(WorkPermitEdmontonType.HOT_WORK, WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType("9"));
            Assert.AreEqual(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK, WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType("10"));
            Assert.AreEqual(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK, WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType(@"10\"));                     
        }     
    }
}