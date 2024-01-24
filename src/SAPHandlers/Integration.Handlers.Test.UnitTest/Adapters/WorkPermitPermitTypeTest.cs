using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    [TestFixture]
    public class WorkOrderWorkPermitTypeTest
    {
        [Test]
        public void ShouldReturnCorrectWorkOrderWorkPermitType()
        {
            Assert.AreEqual(WorkPermitType.HOT, WorkOrderWorkPermitType.ToWorkPermitType("2"));
            Assert.AreEqual(WorkPermitType.COLD, WorkOrderWorkPermitType.ToWorkPermitType("1"));

            Assert.AreEqual(WorkPermitType.HOT, WorkOrderWorkPermitType.ToWorkPermitType("HOT"));
            Assert.AreEqual(WorkPermitType.COLD, WorkOrderWorkPermitType.ToWorkPermitType("COLD"));
        }

        [Test]
        public void ShouldThrowAnExceptionIfThePermitTypeIsUnknown()
        {
            var workPermitType = WorkOrderWorkPermitType.ToWorkPermitType("TEPID");
            Assert.That(workPermitType, Is.Null);
        }
    }
}